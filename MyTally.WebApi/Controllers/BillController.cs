using Microsoft.AspNetCore.Mvc;
using MyTally.Models;
using MyTally.Service.IService;
using MyTally.WebApi.Utils.ApiResults;

namespace MyTally.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillController(IBillService ibillService) : ControllerBase
{
    private readonly IBillService _ibillService = ibillService;

    [HttpGet("/Bill/GetAll")]
    public async Task<ActionResult<ApiResult>> GetAllAsync()
    {
        var data = await _ibillService.QueryAsync(it => !it.IsDelete);
        return data.Count switch
        {
            0 => ApiResultHelper.Error("数据库无数据"),
            >= 100 => ApiResultHelper.Error("数量过多，使用分页查询"),
            _ => ApiResultHelper.Success(data)
        };
    }

    [HttpGet("/Bill/SearchWithYear")]
    public async Task<ActionResult<ApiResult>> GetAllInMonth(int year)
    {
        var data = await _ibillService.QueryAsync(it => it.CreatDataTime.Year == year);
        return data.Count switch
        {
            0 => ApiResultHelper.Error("数据库无数据"),
            >= 100 => ApiResultHelper.Error("数量过多，使用分页查询"),
            _ => ApiResultHelper.Success(data)
        };
    }

    [HttpGet("/Bill/SearchWithMonth")]
    public async Task<ActionResult<ApiResult>> GetAllInMonth(int year, int month)
    {
        var data = await _ibillService.QueryAsync(
            it => it.CreatDataTime.Year == year && it.CreatDataTime.Month == month
        );

        return data.Count switch
        {
            0 => ApiResultHelper.Error("数据库无数据"),
            >= 100 => ApiResultHelper.Error("数量过多，使用分页查询"),
            _ => ApiResultHelper.Success(data)
        };
    }

    [HttpGet("/Bill/SearchWithDay")]
    public async Task<ActionResult<ApiResult>> GetAllInDay(int year, int month, int day)
    {
        var data = await _ibillService.QueryAsync(
            it =>
                it.CreatDataTime.Year == year
             && it.CreatDataTime.Month == month
             && it.CreatDataTime.Day == day
        );
        return data.Count switch
        {
            0 => ApiResultHelper.Error("数据库无数据"),
            >= 100 => ApiResultHelper.Error("数量过多，使用分页查询"),
            _ => ApiResultHelper.Success(data)
        };
    }

    //[HttpPost("/Bill")]
    //public async Task<ActionResult<ApiResult>> CreatAsync(
    //    double billAmount,
    //    int accountBookId,
    //    int type,
    //    int fatherTypeId,
    //    int childenTypeId,
    //    bool isNotIncludedInIncomeAndExpenditure,
    //    bool isReimburse,
    //    double? reimbursementRatio,
    //    double? reimbursementAmount
    //)
    //{
    //    Bill b =
    //        new()
    //        {
    //            CreatDataTime = DateTime.Now,
    //            BillAmount = billAmount,
    //            AccountBookId = accountBookId,
    //            Type = type,
    //            FatherTypeId = fatherTypeId,
    //            ChildenTypeId = childenTypeId,
    //            IsReimburse = isReimburse,
    //            IsNotIncludedInIncomeAndExpenditure = isNotIncludedInIncomeAndExpenditure,
    //            IsDelete = false
    //        };
    //    if (reimbursementRatio != null)
    //    {
    //        b.ReimbursementRatio = reimbursementRatio;
    //    }
    //    if (reimbursementAmount != null)
    //    {
    //        b.ReimbursementAmount = reimbursementAmount;
    //    }
    //    return ApiResultHelper.Success("添加成功");
    //}
    [HttpDelete("/Bill/D")]
    public async Task<ActionResult<ApiResult>> DeleteAsync(int id)
    {
        var bill = await _ibillService.FindAsync(id);
        bill.IsDelete = true;
        var b = await _ibillService.EditAsync(bill);
        return b ? ApiResultHelper.Success("删除成功") : ApiResultHelper.Error("修改失败");
    }
}