using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,] { { 0, 1, 0 }, { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 0 } };
            int[][] b = { new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 }, new int[] { 1, 1, 1 }, new int[] { 0, 0, 0 } };
            GameOfLife(b);
        }


        public static void GameOfLife(int[][] board)
        {
            int row = board.Length;
            int col = board[0].Length;
            int[][] preBoard = board;

            //下次board
            //初始化都为0，所以只需更新复活的位置
            board = new int[row][];
            for (int i = 0; i < row; i++)
            {
                board[i] = new int[col];
            }


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    RefreshStatus(preBoard, ref board, i, j);
                }
            }
        }


        /// <summary>
        /// 刷新下一个状态
        /// </summary>
        /// <param name="preBoard"></param>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private static void RefreshStatus(int[][] preBoard, ref int[][] board, int row, int col)
        {
            //当前细胞
            Cell curCell = new Cell
            {
                Col = col,
                Row = row
            };

            //获取周围细胞存活的个数
            int liveCnt = curCell.GetLiveCnt(preBoard);

            //如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡
            if (liveCnt < 2)
            {
                curCell.Dead(ref board);
            }
            //如果活细胞周围八个位置有两个活细胞，则该位置活细胞仍然存活，死细胞仍死；
            else if (liveCnt == 2)
            {
                curCell.Copy(preBoard, ref board);
            }
            //如果活细胞周围八个位置有三个活细胞，则该位置活细胞仍然存活，死细胞复活；
            else if (liveCnt == 3) 
            {
                //复活
                curCell.Live(ref board);
            }
            //如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
            else
            {
                curCell.Dead(ref board);
            }
        } 

        /// <summary>
        /// 细胞类
        /// </summary>
        public class Cell
        {
            /// <summary>
            /// 当前细胞行数
            /// </summary>
            public int Row { get; set; }

            /// <summary>
            /// 当前细胞列数
            /// </summary>
            public int Col { get; set; }

            /// <summary>
            /// 是否存活
            /// </summary>
            /// <param name="preBoard"></param>
            /// <returns></returns>
            public bool IsLive(int[][] preBoard)
            {
                return preBoard[Row][Col] == 1;
            }

            /// <summary>
            /// 致死
            /// </summary>
            /// <param name="board"></param>
            public void Dead(ref int[][] board)
            {
                board[Row][Col] = 0;
            }

            /// <summary>
            /// 复活
            /// </summary>
            /// <param name="board"></param>
            public void Live(ref int[][] board)
            {
                board[Row][Col] = 1;
            }

            /// <summary>
            /// 复制
            /// </summary>
            /// <param name="preBoard"></param>
            /// <param name="board"></param>
            public void Copy(int[][] preBoard, ref int[][] board)
            {
                board[Row][Col] = preBoard[Row][Col];
            }

            /// <summary>
            /// 周围存货细胞数量
            /// </summary>
            /// <param name="board"></param>
            /// <returns></returns>
            public int GetLiveCnt(int[][] preBoard)
            {
                int liveCnt = 0;
                for (int i = Row -1; i <= Row + 1 ; i++)
                {
                    for (int j = Col - 1; j <= Col + 1; j++)
                    {
                        try
                        {
                            if (preBoard[i][j] == 1 && (Row != i || Col != j))
                                liveCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                        }
                    }
                }
                return liveCnt;
            }
        }
    }
}
