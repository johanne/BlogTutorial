using SecretSolution_G_3_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_G_3_2.Implementation
{
    class ChecksumAnswer : IAnswer
    {
        public int Answer(int start, int length)
        {
            return answer(start, length);
        }

        public static int answer(int start, int length)
        {
            int key = 0;
            int current = start;
            int tempLength = length;

            for (int j = 0; j < length; j++)
            {
                // get the start of the current row
                current = start + (j* length);
                // get the length at the current row
                tempLength = length - j;

                for (int i = current; i < current + tempLength; i++)
                {
                    // generate the horizontal values
                        key ^= i;
                    // generate the vertical values

                }
            }

            return key;
        }
    }
}
