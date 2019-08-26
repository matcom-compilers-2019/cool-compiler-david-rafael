﻿using Antlr4.Runtime.Tree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute

namespace CodeGenerator
{
    internal class IdentifierNode : Node
    {
        //private string v;
        private CoolParser.IdentifierExpContext context;
        //private Node s;
        

        public IdentifierNode(CoolParser.IdentifierExpContext context, Node s) : base(s.Childs)
        {
            this.context = context;
            this.Name = context.ID().GetText();
            Console.WriteLine(  context.ID().GetType().ReflectedType);
           
            //CoolParser.ClassdefContext p = context.Parent.Parent as CoolParser.ClassdefContext;
            //var classname = p.t.Text;
            //if (SymbolTable.Classes[classname].Attributes.ContainsKey(this.Name))
            //{
            //    this.Type = SymbolTable.Classes[classname].Attributes[this.Name].Type;
            //}


            // this.Type = SymbolTable.Classes[context.Parent.cl]
            //this.s = s;
            I = MIPS.intCount++;
        }

        public int I { get; internal set; }
        public string Name { get; private set; }

        public override string GenerateCode()
        {
            //this.Type = SymbolTable.Symbols.Peek()[Name].Name;

            var s = "";
            var reg1 = "";
            reg1 = MIPS.GetReg();// here we asume that an int has been loaded to the last position
            s += MIPS.Emit(MIPS.Opcodes.lw, reg1, Name);

            return s;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}