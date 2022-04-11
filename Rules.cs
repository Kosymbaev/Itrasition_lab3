using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Rules
    {
        public int Winer(List<string> turns, int comp, int user)
        {
            if (comp == user) return 0;
            int range = turns.Count() / 2;
            int temp = user + 1;
            int rangeCheck = 1;
            while (rangeCheck <= range)
            {
                if (temp >= turns.Count())
                {
                    temp = 0;
                }
                if (temp == comp)
                {
                    return -1;
                }
                rangeCheck++;
                temp++;
            }
            return 1;
        }
    }
}
