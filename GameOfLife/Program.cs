// See https://aka.ms/new-console-template for more information

using GameOfLife;

var board = new Board(new[,] { { 0, 1, 0 }, { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 0 } });
Console.WriteLine(board);
var newBoard = board.RefreshStatus();
Console.WriteLine(newBoard);

