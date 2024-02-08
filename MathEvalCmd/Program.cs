using System.Collections.Generic;
using System;
using MathEvalLogic;
using MathEvalLogic.MthComp;

namespace MathEvalCmd
{
    class Program
    {
        static void Main(string[] args) {

            while (true) {
                Console.Write(" > ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    return;

                Console.WriteLine("Result: " + MathEval.Calculate(line));
            }

        }
    }
}
