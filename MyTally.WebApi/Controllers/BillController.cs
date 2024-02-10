using Microsoft.AspNetCore.Mvc;
using Mytally.Models;
using Mytally.Service.IService;
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
        List<Bill>? data = await _ibillService.QueryAsync(it => !it.IsDelete);
        if (data == null)
            return ApiResultHeaper.Error("查询失败");
        if (data.Count == 0)
            return ApiResultHeaper.Error("数据库无数据");
        if (data.Count >= 100)
            return ApiResultHeaper.Error("数量过多，使用分页查询");

        return ApiResultHeaper.Success(data);
    }

    [HttpGet("/Bill/SearchWithYear")]
    public async Task<ActionResult<ApiResult>> GetAllInMonth(int year)
    {
        List<Bill>? data = await _ibillService.QueryAsync(it => it.CreatDataTime.Year == year);
        if (data == null)
            return ApiResultHeaper.Error("查询失败");
        if (data.Count == 0)
            return ApiResultHeaper.Error("数据库无数据");
        if (data.Count >= 100)
            return ApiResultHeaper.Error("数量过多，使用分页查询");

        return ApiResultHeaper.Success(data);
    }

    [HttpGet("/Bill/SearchWithMonth")]
    public async Task<ActionResult<ApiResult>> GetAllInMonth(int year, int month)
    {
        List<Bill>? data = await _ibillService.QueryAsync(
            it => it.CreatDataTime.Year == year && it.CreatDataTime.Month == month
        );
        if (data == null)
            return ApiResultHeaper.Error("查询失败");
        if (data.Count == 0)
            return ApiResultHeaper.Error("数据库无数据");
        if (data.Count >= 100)
            return ApiResultHeaper.Error("数量过多，使用分页查询");

        return ApiResultHeaper.Success(data);
    }

    [HttpGet("/Bill/SearchWithDay")]
    public async Task<ActionResult<ApiResult>> GetAllInDay(int year, int month, int day)
    {
        List<Bill>? data = await _ibillService.QueryAsync(
            it =>
                it.CreatDataTime.Year == year
                && it.CreatDataTime.Month == month
                && it.CreatDataTime.Day == day
        );
        if (data == null)
            return ApiResultHeaper.Error("查询失败");
        if (data.Count == 0)
            return ApiResultHeaper.Error("数据库无数据");
        if (data.Count >= 100)
            return ApiResultHeaper.Error("数量过多，使用分页查询");

        return ApiResultHeaper.Success(data);
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
    //    return ApiResultHeaper.Success("添加成功");
    //}
    [HttpDelete("/Bill/D")]
    public async Task<ActionResult<ApiResult>> DeleteAsync(int id)
    {
        Bill bill = await _ibillService.FindAsync(id);
        if (bill == null)
            return ApiResultHeaper.Error("未找到");
        bill.IsDelete = true;
        bool b = await _ibillService.EditAsync(bill);
        if (!b)
            return ApiResultHeaper.Error("修改失败");
        return ApiResultHeaper.Success("删除成功");
    }
}
