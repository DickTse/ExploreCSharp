/* Build the exe of this project. Then read the CIL of the exe with ILSpy, and compare the complexity of for-loop and foreach-loop.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForVsForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new int[1];

            // for-loop
            int total = 0;
            for (int i = 0; i < integers.Length; i++)
                total += integers[i];

            // foreach-loop
            total = 0;
            foreach (int i in integers)
                total += i;
        }
    }
}
