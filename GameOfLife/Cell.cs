namespace GameOfLife;

/// <summary>
/// 细胞类
/// </summary>
public class Cell
{
    public Cell(int row, int col, bool isLive = false)
    {
        Row = row;
        Col = col;
        _isLive = isLive;
    }

    /// <summary>
    /// 当前细胞行数
    /// </summary>
    public int Row { get; }

    /// <summary>
    /// 当前细胞列数
    /// </summary>
    public int Col { get; }

    /// <summary>
    /// 是否存活.
    /// </summary>
    private bool _isLive;

    public override string ToString()
    {
        return _isLive ? "1 " : "0 ";
    }


    /// <summary>
    /// 是否存活
    /// </summary>
    /// <returns></returns>
    public bool IsLive()
    {
        return _isLive;
    }

    /// <summary>
    /// 致死
    /// </summary>
    public void Dead()
    {
        _isLive = false;
    }

    /// <summary>
    /// 复活
    /// </summary>
    public void Live()
    {
        _isLive = true;
    }
}