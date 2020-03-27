using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] deck = { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3 };
            Console.WriteLine(HasGroupsSizeX(deck));
            Console.Read();
        }

        public static bool HasGroupsSizeX(int[] deck)
        {
            //1:总长度小于2直接返回
            if (deck.Length < 2) 
                return false;

            //2:统计每个数出现的次数
            //Key：该数字。   Value：该数字出现的次数
            Dictionary<int, int> NumcntDic = new Dictionary<int, int>();
            //遍历数组
            for (int i = 0; i < deck.Length; i++)
            {
                //字典键中是否包含当前数，包含，即该数已存在，则加一，不包含，即不存在，则赋值为1
                NumcntDic[deck[i]] = NumcntDic.ContainsKey(deck[i]) ? NumcntDic[deck[i]] + 1 : 1;
            }

            //3:找到字典值集合中的最小值
            int minCnt = NumcntDic.Values.Min();
            //如果最小值小于二，则返回false
            if (minCnt < 2) 
                return false;

            //若最小则是a，其他值是b
            //若满足条件，则a和b中有一个大于1的公约数
            //eg:如果最小值a=6，其他值b=15。因为a=6=2*3，b=15=3*5，存在一个大于1的公约数3
            //所以可以每组分配3个，符合条件，返回true

            //4:找到最小值a的约数大于1的集合
            //公约数集合
            List<int> comList = new List<int>();
            //从1开始，到minCnt的算术平方根结束
            for (int i = 1; i <= Math.Sqrt(minCnt); i++) 
            {
                //取余等于0
                if (minCnt % i == 0) 
                {
                    //只记录大于1的约数
                    if (i > 1)
                        comList.Add(i);
                    //若i与其对应的约数不同，则添加
                    if (i != minCnt / i) 
                        comList.Add(minCnt / i);
                }
            }
            //遍历所有其他值b
            foreach (int curCnt in NumcntDic.Values)
            {
                //相同不用计算
                if (curCnt != minCnt) 
                {
                    //遍历最小值约数集合
                    //由于遍历时，移除元素不方便
                    //所以规定：集合中已舍去的约数用-1代替
                    for (int i = 0; i < comList.Count; i++)
                    {
                        if (comList[i] != -1)
                        {
                            //当前约数是公约数，则继续查找
                            if (curCnt % comList[i] == 0)
                                continue;
                            //当前约数不是公约数，则舍去，赋值为-1
                            comList[i] = -1;
                        }
                    }
                }
            }

            //最后检查约数集合里是否含有非-1值
            return comList.Any(com => com != -1);
        }
    }
}
