using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] arr1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //int[][] arr2 = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int m = 5, n = 6;

            int[,] arr1 = new int[m, n];
            int[][] arr2 = new int[m][];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr1[i, j] = i + 1;
                }
            }

            for (int i = 0; i < m; i++)
            {
                int[] arr = new int[n];
                for (int j = 0; j < n; j++)
                {
                    arr[j] = i + 1;
                }
                arr2[i] = arr;
            }

            int num1 = arr1[1, 2];
            int num2 = arr2[1][2];

            arr1[1, 2] = 10;
            arr2[2][2] = 10;

            int len1 = arr1.Length;
            int len2 = arr2.Length;

            int len11 = arr1.GetLength(0);
            int len111 = arr1.GetLength(1);

            int len22 = arr2.GetLength(0);
            //int len222 = arr2.GetLength(1);  


            //遍历
            int rank1 = arr1.Rank;
            int rank2 = arr2.Rank;

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    //To Do
                }
            }
        }

        #region 插入排序
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private static void Insertion_Sort(ref int[] nums)
        {
            //从nums[1]开始，直到nums.Length
            for (int i = 1; i < nums.Length; i++)
            {
                Insertion(ref nums, i);
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="index">当前数下标</param>
        private static void Insertion(ref int[] nums, int index)
        {
            int temp = nums[index]; //当前数
            //向前查找
            for (int i = index - 1; i >= 0; i--)
            {
                //如果当前查找的数temp大于nums[i]，则交换
                if (temp < nums[i])
                {
                    //交换位置i和i+1的位置
                    int tmp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = tmp;
                    continue;
                }
                break;
            }
        }
        #endregion

        #region 冒泡排序
        private static void Bubble_Sort(ref int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                Bubble(ref nums, i);
            }
        }

        private static void Bubble(ref int[] nums, int pos)
        {
            for (int i = 0; i < nums.Length - 1 - pos; i++)
            {
                //交换
                if (nums[i] > nums[i + 1])
                {
                    int temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                }
            }
        }
        #endregion
    }
}
