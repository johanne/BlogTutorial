using SecretSolution_G_3_2.Implementation;
using SecretSolution_G_3_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_G_3_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int test_cases = 2;
            int[,] tests = { { 0, 2000000 }, { 17, 4 } };

            IAnswer solver = new ChecksumAnswer();

            for (int i = 0; i < tests.GetLength(0); i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var answer = solver.Answer(tests[i, 0], tests[i, 1]);
                sw.Stop();
                Console.WriteLine("#{0}: start = {1}, length = {2}, Checksum = {3}. Execution time: {4} ms", i + 1, tests[i, 0], tests[i, 1], answer, sw.ElapsedMilliseconds);
                Console.ReadKey();
            }
        }
    }
}
