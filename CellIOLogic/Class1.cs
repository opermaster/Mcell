using System;
using System.Collections.Generic;
using MathEvalLogic;

namespace TableIOLogic
{
    public class TableIO
    {
        static private int bounds_s = 'A';
        static private int size = 15;
        static private string[,] table = new string[size, size];
        static public Dictionary<string[],string> cell_numbers= new Dictionary<string[], string>();
        static private void FillTableBase() {
            table[0, 0] = " ";

            for (int i = bounds_s; i < bounds_s+size-1; i++) {
                table[i - 64, 0] = ((char)i).ToString();
            }
            for (int i = bounds_s; i < bounds_s + size-1; i++) {
                table[0, i - 64] = ((char)i).ToString();
            }
        }
        static private void ProcessCell(string command) {
            int X,Y;
            string text;
            ProcessComand(command, out X, out Y, out text);
            table[X, Y] = text;
        }
        static private string ProcessExpression(string text) {
            string final_text=text;
            foreach(var item in cell_numbers) {
                string ident = item.Key[0] + item.Key[1];
                final_text=final_text.Replace(ident, item.Value);
            }
            return Convert.ToString(MathEval.Calculate(final_text));
        }
        static private void ProcessComand(string command,out int X, out int Y, out string text) {
            X = command[1] - 64;
            Y = command[0] - 64;
            if (command[2] == '=') {
                text = command.Substring(3, command.Length - 3);
                cell_numbers.Add(new string[] { command[0].ToString(), command[1].ToString() }, text);
            }
            else if (command[2] == ':') {
                text = ProcessExpression(command.Substring(3, command.Length - 3));
                cell_numbers.Add(new string[] { command[0].ToString(), command[1].ToString() }, text);
            }
            else text = "0";
        }
        public static string[,] Main(string[] args) {
            FillTableBase();
            foreach(string item in args) {
                ProcessCell(item);
            }
            
            return table;
        }
    }
}
