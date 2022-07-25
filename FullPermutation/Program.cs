// See https://aka.ms/new-console-template for more information

using FullPermutation;

while (true)
{
    Console.WriteLine("输入要全排列的数字（会进行去重），通过空格分开，回车确认");
    Console.ReadLine()
        ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Where(e => int.TryParse(e, out _))
        .Select(int.Parse)
        .Distinct()
        .ToArray()
        .PrintFullPermutation();
}

