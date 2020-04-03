using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace String_to_Integer_atoi_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyAtoi(""));
            Console.Read();
        }

        public static int MyAtoi(string str)
        {
            char[] charArr = str.ToCharArray();
            string res = "0";
            for (int i = 0; i < charArr.Length; i++)
            {
                //找到第一个不是空格的值
                if (!char.IsWhiteSpace(charArr[i]))
                {
                    char curChar = charArr[i];
                    //1.如果第一个非空字符为正或者负号时，则将该符号与之后面【尽可能多】的【连续数字】字符组合起来，形成一个有符号整数
                    //2.是数字
                    if (curChar == '+' || curChar == '-' || int.TryParse(curChar.ToString(), out int _))
                        res = GetMaxStr(charArr, i);
                    break;
                }
            }

            try
            {
                return Convert.ToInt32(res);
            }
            catch (OverflowException)
            {
                return res.Contains('-') ? int.MinValue : int.MaxValue;
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        private static string GetMaxStr(char[] charArr, int start = 0)
        {
            int len = 1;

            for (int i = start + 1; i < charArr.Length; i++)
            {
                //找到第一个不是数字
                if (!int.TryParse(charArr[i].ToString(), out int _))
                    break;
                len++;
            }

            return new string(charArr.Skip(start).Take(len).ToArray());
        }
    }
}
