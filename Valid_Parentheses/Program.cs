using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid2("([)]"));
            Console.Read();
        }

        public static bool IsValid(string s)
        {
            //单数直接返回false
            if (s.Length % 2 != 0) 
                return false;

            char[] chars = s.ToCharArray();
            List<char> openChar = new List<char> { '(', '{', '[' }; //开括号
            List<char> closeChar = new List<char> { ')', '}', ']' };//闭括号
            //从头开始遍历
            //找到一个闭括号，下标为closeNum
            for (int closeNum = 0; closeNum < s.Length; closeNum++) 
            {
                //找到闭括号
                if (closeChar.Contains(chars[closeNum]))
                {
                    //从当前位置，向前找
                    //找到第一个开括号
                    for (int openNum = closeNum - 1; openNum >= 0; openNum--)
                    {
                        //找到第一个正括号
                        if (openChar.Contains(chars[openNum]))
                        {
                            //判断和当前闭括号是否闭合
                            if (IsClose(chars[openNum], chars[closeNum]))
                            {
                                //闭合，将两者改为'N'，表示null
                                chars[openNum] = chars[closeNum] = 'N';
                                //跳出循环找下一个闭括号
                                break;
                            }
                            //不闭合
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                //到最后都没有找到闭括号
                else if (closeNum == s.Length - 1) 
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValid2(string s)
        {
            //单数直接返回false
            if (s.Length % 2 != 0)
                return false;

            char[] chars = s.ToCharArray();
            List<char> closeChar = new List<char> { ')', '}', ']' };//闭括号

            List<int> openArr = new List<int>();
            List<int> closeArr = new List<int>();
            //从头开始遍历
            //找到一个闭括号，下标为closeNum
            for (int i = 0; i < s.Length; i++)
            {
                //找到闭括号
                if (closeChar.Contains(chars[i]))
                {
                    closeArr.Add(i);
                }
                else
                {
                    openArr.Add(i);
                }
            }

            if (closeArr.Count != openArr.Count) 
                return false;

            //对于第一个闭括号在chars中的索引
            for (int closeNum = 0; closeNum < closeArr.Count; closeNum++)
            {
                int closeIndex = closeArr[closeNum];
                //找到该位置前的第一个开括号索引
                for (int openNum = openArr.Count - 1; openNum >= 0; openNum--) 
                {
                    //找到最近的开括号索引
                    if (openArr[openNum] < closeIndex)
                    {
                        //开括号索引
                        int openIndex = openArr[openNum];
                        //是否闭合
                        if (IsClose(chars[openIndex], chars[closeIndex]))
                        {
                            //在开括号中移除该项
                            openArr.RemoveAt(openNum);
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    //在openArr中找到最后还没有找到开括号，说明不存在
                    else if (openNum == 0) 
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 是否闭合
        /// </summary>
        /// <param name="open"></param>
        /// <param name="close"></param>
        /// <returns></returns>
        private static bool IsClose(char open, char close)
        {
            return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
        }
    }
}
