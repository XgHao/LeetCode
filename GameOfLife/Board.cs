using System.Text;

namespace GameOfLife;

public class Board
{
    private readonly int[,] _arr;
    private readonly Cell[,] _board;

    /// <summary>
    /// Board行数
    /// </summary>
    public int RowCnt { get; }

    /// <summary>
    /// Board列数
    /// </summary>
    public int ColCnt { get; }

    public Board(int[,] arr)
    {
        _arr = arr;
        var row = arr.GetLength(0);
        var col = arr.GetLength(1);
        if (row is < 1 or > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(row));
        }

        if (col is < 1 or > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(col));
        }

        RowCnt = row;
        ColCnt = col;
        _board = new Cell[row, col];
        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < col; j++)
            {
                _board[i, j] = new Cell(i, j, arr[i, j] > 0);
            }
        }
    }

    public Cell this[int row, int col]
    {
        get
        {
            try
            {
                return _board[row, col];
            }
            catch (IndexOutOfRangeException e)
            {
                return new Cell(-1, -1);
            }
        }
        set
        {
            try
            {
                _board[row, col] = value;
            }
            catch (IndexOutOfRangeException e)
            {
                // ignore.
            }
        }
    }

    /// <summary>
    /// 周围存货细胞数量
    /// </summary>
    /// <returns></returns>
    public int GetAroundLiveCellCount(Cell cell)
    {
        return GetAroundLiveCellCount(cell.Row, cell.Col);
    }

    /// <summary>
    /// 周围存货细胞数量
    /// </summary>
    /// <returns></returns>
    public int GetAroundLiveCellCount(int row, int col)
    {
        var liveCnt = 0;
        for (var i = row - 1; i <= row + 1; i++)
        {
            for (var j = col - 1; j <= col + 1; j++)
            {
                if (i == row && j == col)
                {
                    continue;
                }

                try
                {
                    if (this[i, j].IsLive())
                    {
                        liveCnt++;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Ignore.
                }
            }
        }

        return liveCnt;
    }

    /// <summary>
    /// 刷新下一个状态
    /// </summary>
    public Board RefreshStatus()
    {
        var newBoard = new Board(_arr);
        for (var i = 0; i < RowCnt; i++)
        {
            for (var j = 0; j < ColCnt; j++)
            {
                var curCell = newBoard[i, j];
                //获取周围细胞存活的个数
                var liveCnt = GetAroundLiveCellCount(i, j);

                //如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡
                if (liveCnt < 2)
                {
                    curCell.Dead();
                }
                //如果活细胞周围八个位置有两个活细胞，则该位置活细胞仍然存活，死细胞仍死；
                else if (liveCnt == 2)
                {
                    // ignore.
                }
                //如果活细胞周围八个位置有三个活细胞，则该位置活细胞仍然存活，死细胞复活；
                else if (liveCnt == 3)
                {
                    //复活
                    curCell.Live();
                }
                //如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
                else
                {
                    curCell.Dead();
                }
            }
        }

        return newBoard;
    }

    public override string ToString()
    {
        var sb = new StringBuilder($"Board:{Environment.NewLine}");
        for (var i = 0; i < RowCnt; i++)
        {
            for (var j = 0; j < ColCnt; j++)
            {
                sb.Append(this[i, j]);
            }

            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}