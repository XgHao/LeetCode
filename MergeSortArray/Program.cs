// See https://aka.ms/new-console-template for more information

while (true)
{
    var input = Console.ReadLine();
    var aArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(e => Convert.ToInt32(e)).ToArray();
    input = Console.ReadLine();
    var bArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(e => Convert.ToInt32(e)).ToArray();
    Merge(aArr, bArr).ToList().ForEach(Console.Write);
}

int[] Merge(int[] aArr, int[] bArr)
{
    // aArr及bArr以为排序数组
    var resArr = new int[aArr.Length + bArr.Length];

    int i = 0, j = 0, k = 0;
    while (i < aArr.Length && j < bArr.Length)
    {
        if (aArr[i] < bArr[j])
        {
            resArr[k++] = aArr[i++];
        }
        else
        {
            resArr[k++] = bArr[j++];
        }
    }

    // 放入剩下的
    while (i < aArr.Length)
    {
        resArr[k++]=aArr[i++];
    }

    // 放入剩下的
    while (j < bArr.Length)
    {
        resArr[k++] = bArr[j++];
    }

    return resArr;
}
