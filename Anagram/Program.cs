// See https://aka.ms/new-console-template for more information

while (true)
{
    var sStr = Console.ReadLine();
    var tStr = Console.ReadLine();
    Console.WriteLine(IsAnagram(sStr.ToCharArray(), tStr.ToCharArray()));
}

bool IsAnagram(char[] sArr, char[] tArr)
{
    if (sArr.Length != tArr.Length)
    {
        return false;
    }

    var sCount = new int[26];
    var tCount = new int[26];

    var len = sArr.Length;
    for (int i = 0; i < len; i++)
    {
        var sIndex = sArr[i] - 'a';
        sCount[sIndex]++;
        var tIndex = tArr[i] - 'a';
        tCount[tIndex]++;
    }

    for (int i = 0; i < sCount.Length; i++)
    {
        if (sCount[i] != tCount[i])
        {
            return false;
        }
    }

    return true;
}
