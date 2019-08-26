
using System;
using System.Collections.Generic;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
namespace CodeGenerator
{

    public class MethodNode : Node
    {
        private CoolParser.MethodFeatureContext context;
        //private Node Childs;
       
        /// <summary>
        /// this can only be called for the basic clases
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public MethodNode(string name, ClassNode type):base(new List<Node>())
        {
            Name = name;
            SetType(type);
            Params = new Dictionary<string, AttributeNode>();
            //Variables = new Dictionary<string, AttributeNode>();
            Symbols = new Dictionary<string, ClassNode>();
            ClassName = "";
        }
        public MethodNode(CoolParser.MethodFeatureContext context, Node s) : base(s.Childs)
        {
            Symbols = new Dictionary<string, ClassNode>();
            Params = new Dictionary<string, AttributeNode>();
            //Variables = new Dictionary<string, AttributeNode>();

            CoolParser.ClassdefContext p = (CoolParser.ClassdefContext)context.Parent;
            var classname = p.t.Text;
            var type = "Object";
            if (context.TYPE().GetText() != null)
                type = context.TYPE().GetText();

            var name = context.ID().GetText();
            Name = name;
            SetType(SymbolTable.Classes[type]);
            //Method c;
            if (SymbolTable.Classes.ContainsKey(type) && !(SymbolTable.Classes[classname].Methods.ContainsKey(name)))// if you know my type and not myself
            {
                //c = new Method(name, SymbolTable.Classes[type])
                {
                    Expression = context.expresion();// this shouln't be on the ctor
                    Self = context;
                }
                SymbolTable.Classes[classname].Methods.Add(Name, this);//let me introduce myself
                var formals = context.formal();
                //foreach (var item in formals)// add the parameters of the method
                //{
                //    //SymbolTable.Classes[classname].Methods[name].Params.Add(item.id.Text, new FormalNode(item.id.Text, SymbolTable.Classes[item.t.Text]));
                //}
                foreach (var item in Childs)
                {
                    try{SymbolTable.Classes[classname].Methods[name].Params.Add(((FormalNode)item).ID, new AttributeNode(((FormalNode)item).ID, ((FormalNode)item).GetType()));}catch (System.Exception){}
                }
            }
            this.context = context;
            var d = (CoolParser.ClassdefContext)context.Parent;
            this.ClassName = d.TYPE(0).GetText();// + ".";
            //this.Childs = s.Childs;
            this.Name = context.ID().GetText();
            if (ClassName.ToLower() == "main")
                ClassName = "";
            foreach (var item in Params)
            {
                Symbols.Add(item.Key, item.Value.GetType());// maybe here we could make a dict of atributes but i think this will be harder after in other places and since i only need the class :)
            }
        }

        public string ClassName { get; private set; }
        /// <summary>
        /// The name of the Method, useful for search and for index in a class
        /// </summary>
        public string Name { get; set; }

        private ClassNode type;

        public new ClassNode GetType()
        {
            return type;
        }

        public void SetType(ClassNode value)
        {
            type = value;
        }


        /// <summary>
        /// A Dictionary of Parameters
        /// </summary>
        public Dictionary<string, AttributeNode> Params { get; set; }
        /// <summary>
        /// This references to the context body of the expression
        /// It's not a part of the ctor because of the 'basic functions' that don't have any body 
        /// </summary>
        public CoolParser.ExpresionContext Expression { get; internal set; }
        public CoolParser.MethodFeatureContext Self { get; internal set; }
        /// <summary>
        /// A Dictionary of attributes defined in the methods scope?
        /// dont know if needed or even useful yet
        /// </summary>
        public Dictionary<string, ClassNode> Symbols { get; private set; }

        public override string GenerateCode()
        {
            SymbolTable.Symbols.Push(Symbols);

            var s = "";// = ClassName + "." + Name + ":\n";//todo add the calss name :(

            if (ClassName == "" || Name.ToLower() == "main")
                s += Name+":\n";
            else
                s+= ClassName + "." + Name + ":\n";
        
            
            var reg1 = MIPS.GetReg();//
           
            s += "\t" + "lw " + "$fp" + ", ($sp)" + "\n" +
                           "\t" + "addu $sp, $sp, 4" + "\n" ;
            foreach (var item in Params)
            {
                s += MIPS.Emit(MIPS.Opcodes.lw, reg1,"($sp)");//pop all your sons
                //correjir la pila
                s += "\taddu $sp, $sp, 4\n";

                s += MIPS.Emit(MIPS.Opcodes.sw, reg1,/* Name + "." +*/ item.Key);
               
            }
            s += "\t" + "subu $sp, $sp, 4 " + "\n" +
                        "\t" + "sw "+ "$fp" +", ($sp) " + "\n";
            s += base.GenerateCode();

            s = include(s, "value", Name);
            

            if (ClassName == "" && Name.ToLower() == "main")
                s += "\tli $v0, 10\t\t\t# 10 is the exit syscall.\n\tsyscall\t\t\t\t# do the syscall.\n";
            else
            {
                s += MIPS.Emit(MIPS.Opcodes.move, "$v0", MIPS.LastReg());

                try
                {
                    
                    var c = SymbolTable.Classes[ClassName];

                    var reg0 = MIPS.GetReg();
                    //before pop must save last callreturn
                    s += "\t" + "lw " + "$fp" + ", ($sp)" + "\n" +
                           "\t" + "addu $sp, $sp, 4" + "\n";

                    s += MIPS.Emit(MIPS.Opcodes.lw, reg0,"($sp)");//pop all your sons
                    s += "\taddu $sp, $sp, 4\n";

                    foreach (var item in c.Attributes)
                    {
                        s += MIPS.Emit(MIPS.Opcodes.lw, reg1, item.Key + "_" + Name );//pop all your sons
                        s += MIPS.Emit(MIPS.Opcodes.sw, reg1,  "(" + reg0 + ")");//pop all your sons
                       
                    }
                    s += "\t" + "subu $sp, $sp, 4 " + "\n" +
                        "\t" + "sw " + "$fp" + ", ($sp) " + "\n";

                }
                catch (System.Exception){}
                s += MIPS.Emit(MIPS.Opcodes.jr);
            }
            SymbolTable.Symbols.Pop();
            return s;
        }

        public override string GiveMeTheData()
        {
            var s = "";
            foreach (var item in Params)
            {
                //if(!includeed(item.Key,s))
                if(item.Key=="value")
                s += "\t"+/*Name+"."+*/item.Key+"_"+Name+":\t.word\t0\n";
                else
                    s += "\t" +/*Name+"."+*/item.Key +":\t.word\t0\n";
            }
            return s + base.GiveMeTheData();
        }

        private string include(string s,string m, string key)
        {
            string d = m+"_"+key;
            string acc = "";
            string temp = "";
            int count = 0;
            for (int i = 0; i < s.Length-1; i++)
            {
                if (s[i] == d[count])
                {
                    temp += s[i];
                    if (m.Length-1 == count && s[i + 1] != d[count + 1]) { temp = ""; acc += d; count = 0; }
                    else if (count == d.Length - 1) { count = 0;acc += d;temp = ""; }
                    else count++;
                }
                else {
                    count = 0;
                    if (temp != "")
                    {
                        acc += temp;
                        temp = "";
                    }
                    acc += s[i];
                }
            }

            return acc+ "\n";
        }
    } 
}