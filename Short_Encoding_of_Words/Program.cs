string[] str = { "outint", "like", "int", "dislike", "nt" };
Console.WriteLine(MinimumLengthEncoding(str));
Console.Read();

static int MinimumLengthEncoding(string[] words)
{
    /*首先要理解题意，假设只有两个词A,B 
     * 那么就要检查A是否是B的后缀，或者B是A的后缀，
     * 这样显然麻烦，我们每次都要互相判断A或B是否是其的后缀，
     * 可以想到排序，这样就能保证判断一次，
     * 以单词的末尾进行排序显然是不方便的，所以可以考虑先将单词反转，然后进行排序
     */

    //1.使用HashSet<>和SortedSet<>容器时间会明显变长，因为每次加入新元素都要排序去重，
    //所以这里使用List<>
    var wordList = new List<string>();

    //2-1.遍历所有单词，将其反转
    foreach (var word in words)
    {
        //添加到List中
        wordList.Add(new string(word.Reverse().ToArray()));
    }

    //2-2去重，倒序
    //倒序，保证相同前缀的单词长的在前面
    wordList = wordList.Distinct().OrderByDescending(reWord => reWord).ToList();

    //3.首位作为初始值
    var curStr = wordList.First();       //初始索引字符串
    var count = curStr.Length;    //初始索引字符串长度

    //4.遍历单词集
    for (var i = 0; i < wordList.Count - 1; i++)
    {
        //加上每次比较后的结果，ref保证当前索引字符串更新
        count += CompareWords(ref curStr, wordList.ElementAt(i + 1));
    }

    //5.加上最后一个#
    return ++count;
}

/*
/// <summary>
/// 比较是否是前缀
/// </summary>
/// <param name="curStr">当前索引字符串</param>
/// <param name="nextWord">下一个准备比较单词</param>
/// <returns></returns>
*/
static int CompareWords(ref string curStr, string nextWord)
{
    var cnt = 0;

    //4-1.找出两个词中较短的数值
    var min = Math.Min(curStr.Length, nextWord.Length);

    //4-2.从后向前检查，
    //因为判断是否前缀，所以最后不同就不是前缀了，前面的就不用判断了
    for (var i = min - 1; i >= 0; i--)
    {
        //i==0即直到最后一个也符合，即next是cur的前缀
        if (curStr[i] == nextWord[i] && i == 0)
        {
            cnt = 0;
        }
        //不同，即不是前缀，直接跳出
        else if (curStr[i] != nextWord[i])
        {
            curStr = nextWord + curStr;
            cnt = nextWord.Length + 1;//有一个#
            break;
        }
    }

    //4-3.最后返回本次计算后需要的长度
    return cnt;
}
