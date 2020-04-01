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
            int[] nums = { 7, 5, 4, 2, 4, 5, 6 };
            Insertion_Sort(ref nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"nums[{i}]={nums[i]}");
            }
            Console.Read();
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
