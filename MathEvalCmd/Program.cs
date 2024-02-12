using TableIOLogic;
using System.IO;
using System;

namespace MathEvalCmd
{
    class Program
    {

        static void PrintTable(string[,] table) {
            for (int i = 0; i < table.GetLength(0); i++) {
                for (int j = 0; j < table.GetLength(1); j++) {
                    Console.Write(table[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args) {
            string[] commands = new string[] {
                "AA=2",
                "BA-BF:AA*1",
                "CA-CF:AA*2",
                "DA=5",
                "FA-FF:DA*5",
                "EA-EF:DA*8",
            };
            //commands = File.ReadAllLines(args[0]);
            TableIO table = new TableIO();
            PrintTable(TableIO.Main(commands));

            //foreach(var item in ProcessRange("AA-AC:BA-BB")) Console.WriteLine(item);

        }
    }
}
