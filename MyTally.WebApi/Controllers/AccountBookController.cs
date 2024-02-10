using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mytally.Models;
using Mytally.Service.IService;
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
        List<AccountBookDef>? data = await _iAccountBookDefService.QueryAsync();
        if (data == null)
            return ApiResultHeaper.Error("查询失败");
        if (data.Count == 0)
            return ApiResultHeaper.Error("数据库无数据");
        if (data.Count >= 100)
            return ApiResultHeaper.Error("数量过多，使用分页查询");

        return ApiResultHeaper.Success(data);
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
    //        return ApiResultHeaper.Error("数据库插入失败");
    //    return ApiResultHeaper.Success(data);
    //}
}
