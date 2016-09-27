using SecretSolution_g_2_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_g_2_2.Implementation
{
    public class EnRouteSaluteAnswer : IAnswer
    {
        // what we'll need here is to collide each
        public int answer(string s)
        {
            s = s.Replace("-", "");
            int collector = 0;
            int tempVal = 0;
            foreach (char c in s)
            {
                if (c.Equals('>'))
                {
                    tempVal += 1;
                }
                else 
                {
                    collector += tempVal * 2;
                }
            }

            return collector;
        }
    }
}
