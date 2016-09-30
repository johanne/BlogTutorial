using SecretSolution_g_3_1.Implementation;
using SecretSolution_g_3_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_g_3_1
{
    class Program
    {
        static int test_cases = 1;
        static void Main(string[] args)
        {
            IAnswer solver = new EscapeBunnyAnswer();
            int[,] input = new int[,]{{0, 1, 1, 0}, {0, 0, 0, 1}, {1, 1, 0, 0}, {1, 1, 1, 0}};
            Console.WriteLine("#{0}: Nodes={1}", test_cases, solver.answer(input));
            int[,] input2 = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 1 },
            { 1, 1, 1, 0, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 } };
            Console.WriteLine("#{0}: Nodes={1}", 2, solver.answer(input2));
            Console.ReadKey();
        }
    }
}
