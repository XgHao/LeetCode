namespace ArraySort.Algorithm;

/// <summary>
/// 排序.
/// </summary>
public interface ISort
{
    /// <summary>
    /// 排序.
    /// </summary>
    /// <param name="source">数据源.</param>
    int[] Sort(IEnumerable<int> source);

    /// <summary>
    /// 倒序.
    /// </summary>
    /// <param name="source">数据源.</param>
    int[] DescSort(IEnumerable<int> source);
}