namespace ArraySort.Algorithm;

public static class SortBuilder
{
    /// <summary>
    /// 创建排序器.
    /// </summary>
    /// <param name="sortAlgorithm"></param>
    /// <returns></returns>
    public static ISort Build(SortAlgorithm? sortAlgorithm = SortAlgorithm.Bubble)
    {
        return sortAlgorithm switch
        {
            SortAlgorithm.Bubble => new BubbleSort(),
            SortAlgorithm.Insert => new InsertSort(),
            SortAlgorithm.Selection => new SelectionSort(),
            _ => new BubbleSort(),
        };
    } 
}