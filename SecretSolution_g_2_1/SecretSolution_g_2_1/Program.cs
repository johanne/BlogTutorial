using SecretSolution_g_2_1.Implementation;
using SecretSolution_g_2_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_g_2_1
{
    class Program
    {
        private static IAnswer _solver;
        private const int test_cases = 2;
        private static int[] tests = { 11, 143 };
        static void Main(string[] args)
        {
            _solver = new DivideLambAnswer();
            
            for(int i = 0; i< test_cases; i++)
            {
                Console.WriteLine("Test #{0} - Input: {1}, Answer = {2}", i + 1, tests[i], _solver.answer(tests[i]));
            }
            Console.ReadKey();
        }
    }
}
