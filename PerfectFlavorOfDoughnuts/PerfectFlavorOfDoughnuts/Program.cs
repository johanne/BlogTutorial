using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectFlavorOfDoughnuts
{
    class Program
    {
        const int k = 1000; // problem definition states a maximum value of 1000 for k
        const int chocolate = 500;

        static void Main(string[] args)
        {
            // Get the number of test cases
            int T = int.Parse(Console.ReadLine());

            for(int test_case = 1; test_case<= T; test_case++)
            {
                // Get the length of the test case
                string sIn = Console.ReadLine();
                string[] indInput = sIn.Split(' ');
                int N = int.Parse(indInput[0]);

                // Create our input and output arrays
                int[] input = new int[N];
                int[] output = new int[N];
                int[] count = new int[k+1]; // Count array should include maximum k as countable.

                int highestNum = 0;

                // Get the input
                for (int i = 0; i < N; i++)
                {
                    input[i] = int.Parse(indInput[i + 1]);
                    // Store the highest num, the effective k
                    highestNum = highestNum < input[i] ? input[i] : highestNum;
                }

                // Fill the count array
                for (int i = 0; i < N; i++)
                {
                    count[input[i]]++;
                }

                /*
                // Adjust the indices as stated in the count array
                for (int i = 1; i <= highestNum; i++)
                {
                    count[i] += count[i - 1];
                }

                // Fill the output array with the ordered input
                for (int i = 0; i < N; i++)
                {
                    count[input[i]]--;
                    output[count[input[i]]] = input[i];
                }
                */

                // Get the unique index that appears the most frequent
                int D = 0;
                int frequency = 0;
                for (int i = 0; i <= highestNum; i++)
                {
                    if (count[i] > frequency)
                    {
                        frequency = i;
                        D = i;
                    }
                }

                // With chocolate set at index 500
                // Our output should show the frequency of chocolate, followed by
                // the flavor of doughnut that has the highest occurence
                Console.WriteLine("#{0} {1} {2}", test_case, count[chocolate], D);
            }


        }
    }
}
