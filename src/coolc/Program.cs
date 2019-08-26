using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using CodeGenerator;
using coolc.AST;
using System.Diagnostics;
using cool.types;

namespace coolc
{
    class Program
    {
        static void Main(string[] args)
        {
                   
            #region Variables

            double version = 0.2;
            string copyright = "David Clavijo Castro & Rafael Martinex Martinez";
            var verbose = true;
            string usage = "Usage:\n\tcoolc [--verbose/--v] [ -o fileout ] file1.cl file2.cl ... filen.cl";
            #endregion

            #region Welcome Message
            ////// ////// Welcome Message   ////// //////
           
            #endregion

            #region Open file
            ////// ////// Open file         ////// //////

            if (args.Length == 0)
            {
	            Console.ForegroundColor = ConsoleColor.Red;
	            Console.WriteLine("ERROR: No arguments given ");
	            Console.ForegroundColor = ConsoleColor.Gray;
	            Console.WriteLine(usage);
	            Environment.Exit(1);
	            return;
            }
            
            string exitname = args[0];
            StreamWriter tempwriter = new StreamWriter(args[0] + ".tempread.txt");
            for (int i = 0; i < args.Count()-1; i++)
            {
                if (args[i].Contains("-v") || args[i].Contains("--verbose")) verbose = true;
                else
                    try
                    {
                        if (args[i].Contains("-o")) { string[] sp = args[i].Split(' '); exitname = sp[1]; }
                        else {
                            
                            try
                            {
                                StreamReader file_s = new StreamReader(args[i]);
                                tempwriter.WriteLine(file_s.ReadToEnd()+ "\n");
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR: Opening file {0}",args[i]);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                
                                Environment.Exit(1);
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Mala Entrada de argumentos en {0}",args[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        
                        Console.WriteLine(usage);
                        Environment.Exit(1);
                    }
            }

            if (verbose == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("A cool compiler :)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Version: {0}", version);
                Console.WriteLine("Copyright (C) 2018-2019: {0}", copyright);
            }


            Console.WriteLine("Opening: {0}\t", "E:\\coolDavid y Rafael\\mytest\\test_code.cl");
			AntlrFileStream input_file = new AntlrFileStream(args[0] + ".tempread.txt");
            #endregion

            #region Parse
            ////// ////// Parse             ////// //////
            //Error Logerss

            StreamWriter lexerwriter = new StreamWriter(input_file.SourceName + ".lexer.errors.txt");
            StreamWriter parserwriter = new StreamWriter(input_file.SourceName + ".parser.errors.txt");


            CoolLexer lexer = new CoolLexer(input_file, lexerwriter, lexerwriter);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CoolParser parser = new CoolParser(tokens, parserwriter, parserwriter);

            

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //IParseTree tree = parser.program(); //si aqui pongo ParseTree da palo
            //CoolBaseVisitor<bool> visitor = new CoolBaseVisitor<bool>();
            /*Chequeo de errores en logger*/
            //var myerror = new BaseErrorListener();
            //parser.AddErrorListener(myerror);
            IParseTree tree = parser.program();

            lexerwriter.Close();
            parserwriter.Close();

            //Imprimir en consola los errores de parsear o lexear
            if (parser.NumberOfSyntaxErrors > 0)
            {
                //Console.WriteLine("{0,20}","[Parsing Error]");
                Console.WriteLine();
                StreamReader lexread = new StreamReader(input_file.SourceName + ".lexer.errors.txt");
                StreamReader parseread = new StreamReader(input_file.SourceName + ".parser.errors.txt");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Compiler Lexer Errors:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(lexread.ReadToEnd());
                lexread.Close();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("compiler Parser Errors:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(parseread.ReadToEnd());
                parseread.Close();
                Console.ForegroundColor = ConsoleColor.Gray;

                Environment.Exit(1);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            //Devolver el color de la consola
            



            //parser.ErrorListeners.RemoveAt(0);



            Console.ForegroundColor = ConsoleColor.Gray;

            #endregion

            #region Semantics Check 
            // My_visitor semantic = new My_visitor();
            VisitASTFactory semantic = new VisitASTFactory();

            ProgramSemantic ast = (ProgramSemantic)semantic.Visit(tree);



            if (ast.Errors.Count > 0 || ast.CheckSemantics().Count > 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Semantic errors: ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (Error e in ast.Errors)
                    Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.Gray;

                //File.Delete(args[0] + ".lexer.errors.txt");
                //File.Delete(args[0] + ".parser.errors.txt");

                Environment.Exit(1);
                //Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("No semantic Errors so far \t");
                Console.ForegroundColor = ConsoleColor.Gray;
            }







            #endregion

            #region Generate Code
            ////// ////// Code Generation      ////// //////
            // TODO Generate Code
            
            //DotCodeGenerator dcg = new DotCodeGenerator(input_file.SourceName);
            //dcg.Visit(tree);

            Builder b = new Builder(input_file.SourceName);
            try
            {
                b.Compile(tree,exitname);
            #endregion

                #region Exit
                ////// ////// Exit              ////// //////
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,17}", "[Build succeded]");
                Console.ForegroundColor = ConsoleColor.Gray;
                #endregion
            }
            catch (Exception)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,20}", "[Build failed]");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            File.Delete(input_file.SourceName + ".lexer.errors.txt");
            File.Delete(input_file.SourceName + ".parser.errors.txt");
            File.Delete(input_file.SourceName);
            Console.ReadLine();
        }
    }
}
