using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate_Matrix_LCCI
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Rotate(int[][] matrix)
        {
            //获取长度
            int len1 = matrix.Length;
            int len2 = matrix[0].Length;

            //1.左右翻转
            //每层
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2 / 2; j++)
                {
                    Swap(ref matrix[i][j], ref matrix[i][len2 - j - 1]);
                }
            }

            //2.对角线交换
            for (int i = 0; i < len1; i++)
            {
                int interval = len1 - 1 - i;
                for (int j = 0; j < len2 - 1 - i; j++)
                {
                    Swap(ref matrix[i][j], ref matrix[i + interval][j + interval]);
                    if (--interval == 0)
                        break;
                }
            }
        }

        /// <summary>
        /// 交换位置
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
