﻿Console.WriteLine(LastRemaining2(5, 3));
Console.WriteLine(LastRemaining(5, 3));
Console.Read();
static int LastRemaining2(int n,int m)
{
    if (n == 1) 
    {
        return 0;
    }
    return (LastRemaining2(n - 1, m) + m) % n;
}


static int LastRemaining(int n, int m)
{
    //使用链表
    var lists = new List<int>();
    for (var i = 0; i < n; i++)
    {
        lists.Add(i);
    }

    //取余就是除去第几个
    var times = n - 1;
    var res = 1;
    for (var i = 0; i < times; i++)
    {
        //取余
        res = (m + res - 1) % n;
        //余数 = 0，移除最后一项
        if (res == 0)
        {
            lists.Remove(lists.Last());
            //意味着移去了最后一个 所以res=1
            res = 1;
        }
        //不为0，移除该索引项
        else
            lists.RemoveAt(res - 1); //移除指定值
        n--;
    }

    return lists[0];
}
