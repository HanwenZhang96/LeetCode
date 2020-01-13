using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        // 整数逆转
        public static int Reverse(int x)
        {
            int res = 0;
            try
            {
                while (x != 0)
                {
                    checked
                    {
                        res = res * 10 + x % 10;
                    }
                    x = x / 10;
                }
            }
            catch (OverflowException e)
            {
                return 0;
            }
            return res;
        }
    }
}
