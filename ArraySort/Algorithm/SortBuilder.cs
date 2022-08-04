namespace ArraySort.Algorithm;

public class SortBuilder
{
    /// <summary>
    /// 创建排序器.
    /// </summary>
    /// <param name="sortAlgorithm"></param>
    /// <returns></returns>
    public static ISort Build(SortAlgorithm? sortAlgorithm = SortAlgorithm.Bubble)
    {
        switch (sortAlgorithm)
        {
            case SortAlgorithm.Bubble:
                return new BubbleSort();

            case SortAlgorithm.Insert:
                return new InsertSort();

            case SortAlgorithm.Selection:
                return new SelectionSort();
        }

        return new BubbleSort();
    } 
}