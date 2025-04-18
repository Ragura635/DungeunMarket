using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ConsoleUtil
    {
        //TODO: InvalidInput메서드를 여기에 넣기 혹은 다른 템플릿용 스크립트로 분리하기

        public static void WaitForNext()
        {
            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }

        public static string AlignKoreanLeft(string str, int width)
        {
            int len = 0;
            foreach (char c in str)
            {
                len += (c >= 0xAC00 && c <= 0xD7A3) ? 2 : 1;
            }

            int pad = Math.Max(width - len, 0);
            return str + new string(' ', pad);
        }
    }
}
