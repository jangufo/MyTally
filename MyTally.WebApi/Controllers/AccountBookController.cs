using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTally.Models;
using MyTally.Service.IService;
using MyTally.WebApi.Utils.ApiResults;

namespace MyTally.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountBookController(IAccountBookDefService accountBookDefService) : ControllerBase
{
    private readonly IAccountBookDefService _iAccountBookDefService = accountBookDefService;

    /// <summary>
    /// 查询所有账本数据
    /// </summary>
    /// <returns></returns>
    [HttpGet("/AccountBook/GetAll")]
    public async Task<ActionResult<ApiResult>> GetAllAsync()
    {
        var data = await _iAccountBookDefService.QueryAsync();
        return data.Count switch
        {
            0 => ApiResultHelper.Error("数据库无数据"),
            >= 100 => ApiResultHelper.Error("数量过多，使用分页查询"),
            _ => ApiResultHelper.Success(data)
        };
    }

    ///// <summary>
    ///// 创建一个账本
    ///// </summary>
    ///// <param name="name"></param>
    ///// <param name="balance"></param>
    ///// <param name="quota"></param>
    ///// <returns></returns>
    //[HttpPost("/AccountBook")]
    //public async Task<ActionResult<ApiResult>> CreatAsync(
    //    string name,
    //    double balance,
    //    double? quota
    //)
    //{
    //    AccountBookDef accountBookDef = new() { Name = name, Balance = balance, };
    //    if (quota != null)
    //    {
    //        accountBookDef.Quota = quota.Value;
    //    }
    //    var data = await _iAccountBookDefService.CreatAsync(accountBookDef);
    //    if (!data)
    //        return ApiResultHelper.Error("数据库插入失败");
    //    return ApiResultHelper.Success(data);
    //}
}
