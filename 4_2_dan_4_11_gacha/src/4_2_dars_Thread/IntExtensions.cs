using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2_dars_Thread;

public static class IntExtensions
{
    public static int GetLength(this int num)
    {
        int counter = 0;
        while(true)
        {
            num /= 10;
            counter++;
            if (num == 0) break;
        }

        return counter;
    }
}
