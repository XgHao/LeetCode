namespace Hanoi;

public class HanoiImp
{
    /// <summary>
    /// 需要移动的次数.
    /// </summary>
    private static int _moveCount;

    /// <summary>
    /// 塔名称.
    /// </summary>
    public char ATower { get; set; } = 'A';

    /// <summary>
    /// 塔名称.
    /// </summary>
    public char BTower { get; set; } = 'B';

    /// <summary>
    /// 塔名称.
    /// </summary>
    public char CTower { get; set; } = 'C';

    public static HanoiImp Build()
    {
        return new HanoiImp();
    }

    /// <summary>
    /// Hanoi.
    /// </summary>
    /// <param name="count">输入要移动的塔层数.</param>
    /// <returns>需要移动的次数.</returns>
    public int Hanoi(int count)
    {
        _moveCount = 0;
        HanoiMove(count, ATower, BTower, CTower);
        return _moveCount;
    }

    /// <summary>
    /// 移动.
    /// </summary>
    /// <param name="count">要移动的块（层数）.</param>
    /// <param name="begin">要移动块的起始塔位置.</param>
    /// <param name="transition">要移动块的中转塔位置.</param>
    /// <param name="destination">要移动块的目标塔位置.</param>
    private void HanoiMove(int count, char begin, char transition, char destination)
    {
        // 如果只有一层，那么直接从起始位置移动到目标位置.
        if (count == 1)
        {
            Console.WriteLine($"{begin} -> {destination}");
            _moveCount++;
            return;
        }

        // 否则将其 分为底层(n)和底层以上(n-1)两层
        // 将n-1的块移动到B.
        HanoiMove(count - 1, begin, destination, transition);

        // 最底下的一层移动到C
        Console.WriteLine($"{begin} -> {destination}");
        _moveCount++;

        // 再把B中的所有移动到C
        HanoiMove(count - 1, transition, begin, destination);
    }
}