// See https://aka.ms/new-console-template for more information
Console.WriteLine("RecentCounter");

public class RecentCounter
{
    private readonly int[] _data;
    private int _dataIndex;
    private int _pingCnt;

    public RecentCounter()
    {
        _data = new int[10000];
        _dataIndex = 0;
        _pingCnt = 0;
    }

    public int Ping(int t)
    {
        _data[_pingCnt++] = t;
        while (_data[_dataIndex] < t - 3000)
        {
            _dataIndex++;
        }

        return _pingCnt - _dataIndex;
    }
}

public class RecentCounterV2
{
    private readonly Queue<int> _tList;

    public RecentCounterV2()
    {
        _tList = new Queue<int>();
    }

    public int Ping(int t)
    {
        _tList.Enqueue(t);
        while (_tList.Peek() < t - 3000)
        {
            _tList.Dequeue();
        }

        return _tList.Count;
    }
}

public class RecentCounterV3
{
    private readonly List<int> _tList;
    private int _pingCnt;

    public RecentCounterV3()
    {
        _tList = new List<int>();
        _pingCnt = 0;
    }

    public int Ping(int t)
    {
        _pingCnt++;
        _tList.Add(t);

        int res = 0;
        for (int i = _pingCnt - 1; i >= 0; i--)
        {
            if (_tList[i] < t - 3000)
            {
                break;
            }

            res++;
        }

        return res;
    }
}