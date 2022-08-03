namespace ArraySort.Algorithm;

/// <summary>
/// 冒泡排序.
/// </summary>
public class BubbleSort : ISort
{
    /// <summary>
    /// 冒泡.
    /// </summary>
    /// <param name="arr">数组.</param>
    /// <param name="arrLen">数组长度..</param>
    /// <param name="func">冒泡规则.</param>
    private static void Bubble(int[] arr, int arrLen, Func<int, int, bool> func)
    {
        for (int i = 0; i < arrLen - 1; i++)
        {
            if (func(arr[i], arr[i + 1]))
            {
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
            }
        }
    }

    /// <summary>
    /// 冒泡排序.
    /// </summary>
    /// <param name="arr">数组.</param>
    /// <param name="func">冒泡规则.</param>
    private static void Bubble_Sort(int[] arr, Func<int, int, bool> func)
    {
        // 从最后一个开始排序
        var arrLen = arr.Length;
        while (arrLen > 0)
        {
            Bubble(arr, arrLen, func);
            arrLen--;
        }
    }


    public int[] Sort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Bubble_Sort(arr, (a, b) => a > b);
        return arr;
    }

    public int[] DescSort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Bubble_Sort(arr, (a, b) => a < b);
        return arr;
    }
}
