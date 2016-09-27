using SecretSolution_g_2_2.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_g_2_2
{
    class Program
    {
        static int test_cases = 3;
        static string[] input = {"--->-><-><-->-", ">----<", "<<>><"};

        static void Main(string[] args)
        {
            var solver = new EnRouteSaluteAnswer();
            for(int i = 0; i < test_cases; i++)
            {
                Console.WriteLine("#{0}: Input = {1}, Answer = {2}", test_cases + 1, input[i], solver.answer(input[i]));
            }

            Console.ReadKey();
        }
    }
}
