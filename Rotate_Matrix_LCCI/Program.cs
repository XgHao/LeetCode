static void Rotate(int[][] matrix)
{
    //获取长度
    var len1 = matrix.Length;
    var len2 = matrix[0].Length;

    //1.左右翻转
    //每层
    for (var i = 0; i < len1; i++)
    {
        for (var j = 0; j < len2 / 2; j++)
        {
            Swap(ref matrix[i][j], ref matrix[i][len2 - j - 1]);
        }
    }

    //2.对角线交换
    for (var i = 0; i < len1; i++)
    {
        var interval = len1 - 1 - i;
        for (var j = 0; j < len2 - 1 - i; j++)
        {
            Swap(ref matrix[i][j], ref matrix[i + interval][j + interval]);
            if (--interval == 0)
                break;
        }
    }
}

static void Swap(ref int a, ref int b)
{
    (a, b) = (b, a);
}
