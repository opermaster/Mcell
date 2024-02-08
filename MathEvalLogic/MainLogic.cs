using System.Collections.Generic;
using System;
using MathEvalLogic.MthComp;

namespace MathEvalLogic
{
    public static class MathEval
    {   
        static void Main(string[] args) {

        }
        public static int Calculate(string text) {
            Lexer lexer = new Lexer(text);
            Parser pr = new Parser(lexer.Lex_Code());
            pr.Create();
            Evaluator evl = new Evaluator(pr.final_binop);
            return evl.Eval();
        }
    }
}
