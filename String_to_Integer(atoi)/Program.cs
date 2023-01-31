Console.WriteLine(MyAtoi(""));
Console.Read();
static int MyAtoi(string str)
{
    var charArr = str.ToCharArray();
    var res = "0";
    for (var i = 0; i < charArr.Length; i++)
    {
        //找到第一个不是空格的值
        if (!char.IsWhiteSpace(charArr[i]))
        {
            var curChar = charArr[i];
            //1.如果第一个非空字符为正或者负号时，则将该符号与之后面【尽可能多】的【连续数字】字符组合起来，形成一个有符号整数
            //2.是数字
            if (curChar is '+' or '-' || int.TryParse(curChar.ToString(), out _))
                res = GetMaxStr(charArr, i);
            break;
        }
    }

    try
    {
        return Convert.ToInt32(res);
    }
    catch (OverflowException)
    {
        return res.Contains('-') ? int.MinValue : int.MaxValue;
    }
    catch (FormatException)
    {
        return 0;
    }
}

static string GetMaxStr(char[] charArr, int start = 0)
{
    var len = 1;

    for (var i = start + 1; i < charArr.Length; i++)
    {
        //找到第一个不是数字
        if (!int.TryParse(charArr[i].ToString(), out _))
            break;
        len++;
    }

    return new string(charArr.Skip(start).Take(len).ToArray());
}
