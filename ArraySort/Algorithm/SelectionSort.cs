namespace ArraySort.Algorithm;

/// <summary>
/// 选择排序.
/// </summary>
public class SelectionSort : ISort
{
    /// <summary>
    /// 查找最大数字索引.
    /// </summary>
    /// <param name="arr">数组.</param>
    /// <param name="arrLen">数组长度.</param>
    /// <param name="func">冒泡规则.</param>
    /// <returns></returns>
    private static int FindMaxIndex(int[] arr, int arrLen, Func<int, int, bool> func)
    {
        // 假设第一个元素最大.
        var maxIndex = 0;
        var max = arr[0];
        for (int i = 1; i < arrLen; i++)
        {
            if (func(arr[i], max))
            {
                maxIndex = i;
                max = arr[i];
            }
        }
        return maxIndex;   
    }

    private static void Selection_Sort(int[] arr, Func<int, int, bool> func)
    {
        var arrLen = arr.Length;
        while (arrLen > 0)
        {
            // 找到最大值位置与当前做交换
            var maxIndex = FindMaxIndex(arr, arrLen, func);

            // 交换
            (arr[arrLen - 1], arr[maxIndex]) = (arr[maxIndex], arr[arrLen - 1]);

            arrLen--;
        }
    }

    public int[] Sort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Selection_Sort(arr, (a, b) => a > b);
        return arr;
    }

    public int[] DescSort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Selection_Sort(arr, (a, b) => a < b);
        return arr;
    }
}