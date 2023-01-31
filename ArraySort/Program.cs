// See https://aka.ms/new-console-template for more information

using ArraySort.Algorithm;

while (true)
{
    Console.WriteLine("请输入要排序的数组，用空格隔开，回车确认");
    var arr = Console.ReadLine()
        ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Where(e => int.TryParse(e, out _))
        .Select(int.Parse)
        .ToList();
    if (arr?.Count > 0)
    {
        // var sort = SortBuilder.Build(SortAlgorithm.Bubble);
        // var sort = SortBuilder.Build(SortAlgorithm.Selection);
        var sort = SortBuilder.Build(SortAlgorithm.Insert);
        Console.WriteLine($"正序：{string.Join(' ', sort.Sort(arr))}");
        Console.WriteLine($"倒序：{string.Join(' ', sort.DescSort(arr))}");
    }
}

