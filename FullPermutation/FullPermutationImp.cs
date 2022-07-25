namespace FullPermutation;

public static class FullPermutationImp
{
    private static int _count = 0;

    /// <summary>
    /// 全排列.
    /// </summary>
    /// <param name="arr">要排列的数组.</param>
    /// <param name="beginIndex">排列的开始索引.</param>
    public static void FullPermutation(this int[] arr, int beginIndex = 0)
    {
        // 只剩一个数字时，排列结束
        if (beginIndex + 1 == arr.Length)
        {
            Console.Write($"第{(++_count),-3}种排列：[");
            arr.ToList().ForEach(Console.Write);
            Console.WriteLine("]");
            return;
        }

        // 每个数字都放到头部.
        for (int index = beginIndex; index < arr.Length; index++)
        {
            (arr[index], arr[beginIndex]) = (arr[beginIndex], arr[index]);

            FullPermutation(arr, beginIndex + 1);

            (arr[index], arr[beginIndex]) = (arr[beginIndex], arr[index]);
        }
    }
}