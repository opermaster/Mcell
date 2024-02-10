using System.Collections.Generic;
using System;
using System.IO;
using MathEvalLogic;
using MathEvalLogic.MthComp;
using TableIOLogic;
namespace MathEvalCmd
{
    class Program
    {
        static void PrintTable(string[,] table) {
            for(int i = 0; i < table.GetLength(0); i++) {
                for (int j = 0; j < table.GetLength(1); j++) {
                    Console.Write(table[i,j]+"  ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args) {
            string[] commands = new string[] {
                "AA=10",
                "BA=2",
                "CA=3",
                "AB:AA+BA",
                "AC:AB*2",
            };
            //commands=File.ReadAllLines(args[0]);
            PrintTable(TableIO.Main(commands));
        }
    }
}
