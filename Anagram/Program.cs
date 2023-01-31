// See https://aka.ms/new-console-template for more information

while (true)
{
    var sStr = Console.ReadLine();
    var tStr = Console.ReadLine();
    Console.WriteLine(IsAnagram(sStr?.ToCharArray(), tStr?.ToCharArray()));
}

static bool IsAnagram(IReadOnlyList<char>? sArr, IReadOnlyList<char>? tArr)
{
    if (sArr == null || tArr == null || sArr.Count != tArr.Count)
    {
        return false;
    }

    var sCount = new int[26];
    var tCount = new int[26];

    var len = sArr.Count;
    for (var i = 0; i < len; i++)
    {
        var sIndex = sArr[i] - 'a';
        sCount[sIndex]++;
        var tIndex = tArr[i] - 'a';
        tCount[tIndex]++;
    }

    for (var i = 0; i < sCount.Length; i++)
    {
        if (sCount[i] != tCount[i])
        {
            return false;
        }
    }

    return true;
}
