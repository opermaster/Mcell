using System;
using System.Collections.Generic;

namespace MathEvalLogic.MthComp
{
    public class Parser
    {
        public Token[] Tokens;
        public int Pos = 0;
        public BinaryExpr final_binop;
        public Parser(Token[] tokens) {
            Tokens = tokens;
        }

        private Token Current => Tokens[Pos];
        private void Next() => Pos++;

        public Expr Parse() {
            Expr left = ParseMuiltExpr();
            while (Current.Value == "+" || Current.Value == "-" || Current.Value == "^") {
                string op = Current.Value; Next();
                Expr right = ParseMuiltExpr();
                left = new BinaryExpr(left, right, op);
            }
            return left;
        }

        public Expr ParseMuiltExpr() {
            Expr left = Parse_PrimaryExpr();
            while (Current.Value == "*" || Current.Value == "/") {
                string op = Current.Value; Next();
                Expr right = Parse_PrimaryExpr();
                left = new BinaryExpr(left, right, op);
            }
            return left;
        }
        public Expr Parse_PrimaryExpr() {
            TokenType tk = Current.Type;
            switch (tk) {
                case TokenType.Num:
                    Token cur = Current;
                    Next();
                    return new Numeric(Convert.ToInt32(cur.Value));
                case TokenType.Sin:
                    Token sin_cur = Current;
                    Next();
                    return new Sin(Convert.ToInt32(sin_cur.Value));
                case TokenType.Cos:
                    Token cos_cur = Current;
                    Next();
                    return new Cos(Convert.ToInt32(cos_cur.Value));
                case TokenType.Abs:
                    Token abs_cur = Current;
                    Next();
                    return new Abs(Convert.ToInt32(abs_cur.Value));
                case TokenType.Sqrt:
                    Token sqrt_cur = Current;
                    Next();
                    return new Sqrt(Convert.ToInt32(sqrt_cur.Value));
                default:
                    throw new Exception($"Failed: Undefined token `{Current.Value}`");
                    throw new Exception("Failed"); 
            }
        }
        public void Create() {
            while (Current.Type != TokenType.End) {
                final_binop = (BinaryExpr)Parse();
            }
        }
    }

}
