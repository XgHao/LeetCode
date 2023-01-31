Console.WriteLine(IsValid2("([)]"));
Console.Read();

static bool IsValid(string s)
{
    //单数直接返回false
    if (s.Length % 2 != 0)
        return false;

    var chars = s.ToCharArray();
    var openChar = new List<char> { '(', '{', '[' }; //开括号
    var closeChar = new List<char> { ')', '}', ']' };//闭括号
                                                     //从头开始遍历
                                                     //找到一个闭括号，下标为closeNum
    for (var closeNum = 0; closeNum < s.Length; closeNum++)
    {
        //找到闭括号
        if (closeChar.Contains(chars[closeNum]))
        {
            //从当前位置，向前找
            //找到第一个开括号
            for (var openNum = closeNum - 1; openNum >= 0; openNum--)
            {
                //找到第一个正括号
                if (openChar.Contains(chars[openNum]))
                {
                    //判断和当前闭括号是否闭合
                    if (IsClose(chars[openNum], chars[closeNum]))
                    {
                        //闭合，将两者改为'N'，表示null
                        chars[openNum] = chars[closeNum] = 'N';
                        //跳出循环找下一个闭括号
                        break;
                    }

                    //不闭合
                    return false;
                }
            }
        }
        //到最后都没有找到闭括号
        else if (closeNum == s.Length - 1)
        {
            return false;
        }
    }

    return true;
}

static bool IsValid2(string s)
{
    //单数直接返回false
    if (s.Length % 2 != 0)
        return false;

    var chars = s.ToCharArray();
    var closeChar = new List<char> { ')', '}', ']' };//闭括号

    var openArr = new List<int>();
    var closeArr = new List<int>();
    //从头开始遍历
    //找到一个闭括号，下标为closeNum
    for (var i = 0; i < s.Length; i++)
    {
        //找到闭括号
        if (closeChar.Contains(chars[i]))
        {
            closeArr.Add(i);
        }
        else
        {
            openArr.Add(i);
        }
    }

    if (closeArr.Count != openArr.Count)
        return false;

    //对于第一个闭括号在chars中的索引
    foreach (var closeIndex in closeArr)
    {
        //找到该位置前的第一个开括号索引
        for (var openNum = openArr.Count - 1; openNum >= 0; openNum--)
        {
            //找到最近的开括号索引
            if (openArr[openNum] < closeIndex)
            {
                //开括号索引
                var openIndex = openArr[openNum];
                //是否闭合
                if (IsClose(chars[openIndex], chars[closeIndex]))
                {
                    //在开括号中移除该项
                    openArr.RemoveAt(openNum);
                    break;
                }
                else
                {
                    return false;
                }
            }
            //在openArr中找到最后还没有找到开括号，说明不存在
            else if (openNum == 0)
            {
                return false;
            }
        }
    }

    return true;
}

/*
/// <summary>
/// 是否闭合
/// </summary>
/// <param name="open"></param>
/// <param name="close"></param>
/// <returns></returns>
*/
static bool IsClose(char open, char close)
{
    return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
}
