using Antlr4.Runtime.Tree;

namespace CodeGenerator
{
    internal class MethodCallNode : Node
    {
        private CoolParser.MethodCallExpContext context;

        public MethodCallNode(CoolParser.MethodCallExpContext context, Node s) : base(s.Childs)
        {
            this.context = context;
            this.MethodName = context.ID().GetText();
        }

        public string MethodName { get; private set; }

        public override string GenerateCode()
        {
            var s = "# Method Call\t\t\t"+MethodName+"\n";

            //foreach son generate his code and 
            //give me the reg where its values 
            //its located
          

            foreach (var item in Childs)
            {

                //if (item is IdentifierNode && item.ToString() == "value")
                //    continue;
                

                s += item.GenerateCode();
                
                    var reg1 = MIPS.LastReg();//
                s += ("\tsubu $sp, $sp, 4\n");
                s += MIPS.Emit(MIPS.Opcodes.sw, reg1, "($sp)" );//push all your sons
                
               
            }
            
            // in this case we dont need a regg
            s += MIPS.Emit(MIPS.Opcodes.jal, MethodName);

            var reg2 = MIPS.GetReg();//

            s += MIPS.Emit(MIPS.Opcodes.move, reg2, "$v0\t\t#Method return value");

            return s;
        }
    }
}