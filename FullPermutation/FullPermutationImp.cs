namespace FullPermutation;

public static class FullPermutationImp
{
    private static int _count;

    /// <summary>
    /// 对数字进行全排列.
    /// </summary>
    /// <param name="arr"></param>
    public static void PrintFullPermutation(this int[] arr)
    {
        _count = 0;
        FullPermutation(arr, 0);
    }

    private static void FullPermutation(int[] arr, int beginIndex)
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