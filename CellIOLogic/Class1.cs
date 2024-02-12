using MathEvalLogic;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace TableIOLogic
{
    public class TableIO {
        static private int bounds_s = 'A';
        static private int size = 15;
        static private string[,] table = new string[size, size];
        static private Dictionary<string[], string> cell_numbers = new Dictionary<string[], string>();
        static private int X;
        static private int Y;
        static private string text;

        public string[,] GetTable() => table;
        public void ClearTable() {
            table = new string[size, size];
            FillTableBase();
        }

        public TableIO() {
            FillTableBase();
        }
        static private void FillTableBase() {
            table[0, 0] = "  ";

            for (int i = bounds_s; i < bounds_s + size - 1; i++) {
                table[i - 64, 0] = ((char)i).ToString();
            }
            for (int i = bounds_s; i < bounds_s + size - 1; i++) {
                table[0, i - 64] = ((char)i).ToString();
            }
        }
        static private string[] ProcessNumRange(string text) {
            string[] future_commands = new string[0];
            string[] num_ident = text.Substring(6, text.Length - 6).Split(',');
            if (text[0] == text[3]) {
                int range = text[4] - text[1] + 1;
                future_commands = new string[range];
                string num = num_ident[0];
                int inc = Convert.ToInt32(num_ident[1]);
                for (int i = 0; i < range; i++) {
                    string nstring = text[0].ToString() + (char)(text[1] + i) + "=" + num;
                    future_commands[i] = nstring;
                    int temp = Convert.ToInt32(num) + inc;
                    num = Convert.ToString(temp);
                }
            }
            else if (text[1] == text[4]) {
                int range = text[3] - text[0] + 1;
                future_commands = new string[range];
                string num = num_ident[0];
                int inc = Convert.ToInt32(num_ident[1]);
                for (int i = 0; i < range; i++) {
                    string nstring = (char)(text[0] + i) + text[1].ToString() + "=" + num;
                    future_commands[i] = nstring;
                    int temp = Convert.ToInt32(num) + inc;
                    num = Convert.ToString(temp);
                }
            }
            return future_commands;
        }
        static private string[] ProcessExprRange(string text) {
            string[] future_commands = new string[0];
            string num_ident = text.Substring(6, text.Length - 6);
            if (text[0] == text[3]) {
                int range = text[4] - text[1] + 1;
                future_commands = new string[range];
                for (int i = 0; i < range; i++) {
                    string nstring = text[0].ToString() + (char)(text[1] + i) + ":" + num_ident;
                    future_commands[i] = nstring;

                }
            }
            else if (text[1] == text[4]) {
                int range = text[3] - text[0] + 1;
                future_commands = new string[range];
                for (int i = 0; i < range; i++) {
                    string nstring = (char)(text[0] + i) + text[1].ToString() + ":" + num_ident;
                    future_commands[i] = nstring;
                }
            }
            return future_commands;
        }
        static private void ProcessCell(string command) {
            ProcessComand(command);
            table[X, Y] = text;
        }
        static private string[] ProcessRange(string text) {
            if (text[5] == '=') {
                return ProcessNumRange(text);
            }
            else {
                return ProcessExprRange(text);
            }
        }
        static private string ProcessExpression(string text) {
            string final_text = text;
            foreach (var item in cell_numbers) {
                string ident = item.Key[0] + item.Key[1];
                final_text = final_text.Replace(ident, item.Value);
            }
            return Convert.ToString(MathEval.Calculate(final_text));
        }
        static private void ProcessComand(string command) {
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
            else if (command[2] == '-') {
                foreach (string item in ProcessRange(command)) {
                    ProcessCell(item
                        .Replace(" ", "")
                        .ToUpper());
                }
            }

            else text = "0";
        }
        public static string[,] Main(string[] args) {
            foreach (string item in args) {
                if (!(item == "") && !(item == " "))
                    ProcessCell(item
                        .Replace(" ", "")
                        .ToUpper());
                else continue;
            }

            return table;
        }
    }
}
