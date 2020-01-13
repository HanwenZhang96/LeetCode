using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = RemoveElement(new int[] {3,2,2,3},3);
            Console.WriteLine(res);
            Console.ReadKey();
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

        // 判断回文
        public static bool IsPalindrome(int x)
        {
            bool isPalindrome = false;

            char[] c = x.ToString().ToCharArray();
            Array.Reverse(c);
            string str = new string(c);
            if (str == x.ToString())
                isPalindrome = true;

            return isPalindrome;
        }

        // 罗马数字转整数
        public static int RomanToInt(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("I", 1);
            dic.Add("V", 5);
            dic.Add("X", 10);
            dic.Add("L", 50);
            dic.Add("C", 100);
            dic.Add("D", 500);
            dic.Add("M", 1000);
            dic.Add("IV", 4);
            dic.Add("IX", 9);
            dic.Add("XL", 40);
            dic.Add("XC", 90);
            dic.Add("CD", 400);
            dic.Add("CM", 900);

            int res = 0;
            char[] c = s.ToString().ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (i < c.Length - 1 && dic[s[i].ToString()] < dic[s[i+1].ToString()])
                {
                    string temp = s[i].ToString() + s[i + 1].ToString();
                    res += dic[temp];
                    i++;
                }
                else
                {
                    res += dic[s[i].ToString()];
                }
            }

            return res;
        }

        // 有效括号
        public static bool IsValid(string s)
        {
            Dictionary<char,char> dic = new Dictionary<char, char> ();
            dic.Add(')', '(');
            dic.Add('}', '{');
            dic.Add(']', '[');

            List<char> list = new List<char> () { '(','{','[' };

            bool isValid = false;
            if (s.Length == 0 || s.Length % 2 == 0)
            {
                Stack<char> st = new Stack<char>();
                foreach (var c in s)
                {
                    if (list.Contains(c))
                    {
                        st.Push(c);
                    }
                    else if(st.Count>0 && dic[c]!= st.Pop())
                    {
                        return isValid;
                    }
                }
                if (st.Count == 0)
                    isValid = true;
            }
            return isValid;
        }

        // 删除排序数组中的重复性（双指针）
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i+1;
        }

        // 移除元素（双指针）
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;

            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }
    }
}
