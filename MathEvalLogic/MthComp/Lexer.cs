using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvalLogic.MthComp
{
    public class Lexer {
        public string source_code;
        public int n;
        private int Pos = 0;
        private Dictionary<string, TokenType> key_symb = new Dictionary<string, TokenType> {
            { "sin",TokenType.Sin },
            { "cos",TokenType.Cos },
            { "abs",TokenType.Abs },
            { "sqrt",TokenType.Sqrt },
        };
        public Lexer(string code) {
            source_code = code;
            n = source_code.Length;
        }

        private char Current => source_code[Pos];
        private void Next() {
            if(Pos<=source_code.Length)
                Pos++;
        }

        public Token[] Lex_Code() {
            List<Token> tokens=new List<Token>();

            while (Pos!=n) {
                if (char.IsDigit(Current)) {
                    int start = Pos;
                    do {
                        Next();
                    } while (Pos != n && char.IsDigit(Current));

                    string number = source_code.Substring(start, Pos - start);
                    tokens.Add(new Token(TokenType.Num, number));
                }
                else if (char.IsLetter(Current)) {
                    int start = Pos;
                    do {
                        Next();
                    } while (Pos != n && char.IsLetter(Current));

                    string word = source_code.Substring(start, Pos - start);
                    if (key_symb.TryGetValue(word, out var word_token_type)) {
                        int start_digit = Pos;
                        do {
                            Next();
                        } while (Pos != n && char.IsDigit(Current));
                        string number = source_code.Substring(start_digit, Pos - start_digit);
                        tokens.Add(new Token(word_token_type, number));
                    }
                    else throw new Exception($"Undefined math func: `{word}`");
                }
                else if (Current == '+' || Current == '-' || Current == '*' || Current == '/' ||Current =='^') {
                    tokens.Add(new Token(TokenType.Op, Current.ToString()));
                    Next();
                }
                else if (char.IsWhiteSpace(Current)) {
                    Next();
                }
                else throw new Exception($"Undefined token: `{Current}`");
            }
            tokens.Add(new Token(TokenType.End, ""));
            return tokens.ToArray();
        }

    }
}
