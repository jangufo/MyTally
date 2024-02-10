using SqlSugar;

namespace MyTally.WebApi.Utils.ApiResults;

public static class ApiResultHeaper
{
    public static ApiResult Success(dynamic data)
    {
        return new ApiResult()
        {
            Code = 200,
            Msg = "操作成功",
            Data = data
        };
    }

    public static ApiResult Success(dynamic data, RefAsync<int> total)
    {
        return new ApiResult()
        {
            Code = 200,
            Msg = "操作成功",
            Total = total,
            Data = data
        };
    }

    public static ApiResult Error(string msg)
    {
        return new ApiResult()
        {
            Code = 500,
            Msg = $"服务器发生错误: {msg}",
            Data = ""
        };
    }
}
