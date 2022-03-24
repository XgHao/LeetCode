// See https://aka.ms/new-console-template for more information
while (true)
{
    var num = Console.ReadLine();
    Console.WriteLine(IsPowerOfTwo(long.Parse(num)));
    Console.WriteLine(IsPowerOfTwoV2(long.Parse(num)));
}

bool IsPowerOfTwo(long num)
{
    if (num <= 1)
    {
        return true;
    }

    if (num % 2 != 0)
    {
        return false;
    }

    return IsPowerOfTwo(num / 2);
}

bool IsPowerOfTwoV2(long num)
{
    if (num <= 1)
    {
        return true;
    }

    return (num & (num - 1)) == 0;
}
