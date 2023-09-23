using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonA.Thiya
{
    class SwapWithOutTemp
    {

        public static void QuestionSeven()
        {
            int v1 = 28;
            int v2 = 01;
            Console.WriteLine($"before swap v1:{v1}, v2:{v2}");
            Swap(ref v1, ref v2);
            Console.WriteLine($"after swap v1:{v1}, v2:{v2}");
        }
        public static void Swap(ref int x, ref int y)
        {
            x = x + y;  
            y = x - y; 
            x = x - y;         }
    }
}
