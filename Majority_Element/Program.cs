// See https://aka.ms/new-console-template for more information
while (true)
{
    var input = Console.ReadLine();
    var arr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(e => Convert.ToInt32(e)).ToArray();
    Console.WriteLine(MajorityElement(arr));
    Console.WriteLine(MajorityElementV2(arr));
}

int MajorityElement(int[] arr)
{
    if (!(arr?.Length > 0))
    {
        return 0;
    }
    var stack = new Stack<int>();

    foreach (var num in arr)
    {
        // 没有元素Push
        if (!stack.TryPeek(out var popNum))
        {
            stack.Push(num);
        }
        // 有元素，且值相同Push
        else if (popNum == num)
        {
            stack.Push(num);
        }
        // 有元素，值不同Pop
        else
        {
            stack.Pop();
        }
    }

    return stack.Pop();
}

int MajorityElementV2(int[] arr)
{
    if (!(arr?.Length > 0))
    {
        return 0;
    }

    var keyNum = 0;
    var keyNumCount = 0;

    foreach (var num in arr)
    {
        // 没有元素Push
        if (keyNumCount == 0)
        {
            keyNum = num;
            keyNumCount++;
        }
        else if (keyNum == num)
        {
            keyNumCount++;
        }
        else
        {
            keyNumCount--;
        }
    }

    return keyNum;
}
