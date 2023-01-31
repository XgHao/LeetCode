namespace ArraySort.Algorithm;

public class InsertSort : ISort
{
    /// <summary>
    /// 插入.
    /// </summary>
    /// <param name="arr">数组.</param>
    /// <param name="arrLen">数组长度.</param>
    /// <param name="func">排序规则.</param>
    /// <returns></returns>
    private static void Insert(IList<int> arr, int arrLen, Func<int, int, bool> func)
    {
        var keyIndex = arrLen - 1;
        var key = arr[keyIndex];

        // key与前一个值相比
        while (func(key, arr[keyIndex - 1]))
        {
            arr[keyIndex] = arr[keyIndex - 1];
            keyIndex--;

            // 如果越界
            if (keyIndex == 0)
            {
                break;
            }
        }
        
        arr[keyIndex] = key;
    }

    private static void Insert_Sort(IList<int> arr, Func<int, int, bool> func)
    {
        // 从第二个数开始插入
        for (var i = 2; i <= arr.Count; i++)
        {
            Insert(arr, i, func);
        }
    }

    public int[] Sort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Insert_Sort(arr, (key, cur) => key < cur);
        return arr;
    }

    public int[] DescSort(IEnumerable<int> source)
    {
        var arr = source.ToArray();
        Insert_Sort(arr, (key, cur) => key > cur);
        return arr;
    }
}