// See https://aka.ms/new-console-template for more information

using Hanoi;

while(true)
{
    Console.WriteLine("输入要移动的塔层数:");
    if (!int.TryParse(Console.ReadLine(),out var count) || count <=0)
    {
        Console.WriteLine("请输入有效的数字\n");
        continue;
    }

    Console.WriteLine($"需要移动{HanoiImp.Build().Hanoi(count)}次，具体步骤如上：\n");
}
