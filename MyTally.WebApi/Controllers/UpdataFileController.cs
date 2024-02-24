using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTally.Service.IService;
using MyTally.WebApi.Utils.ApiResults;

namespace MyTally.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UpdataFileController(IAccountBookDefService abds, IBillService bs) : ControllerBase
{
    private readonly IAccountBookDefService _iAccountBookDefService = abds;
    private readonly IBillService _iBillService = bs;

    [HttpPost("/FileUpdata/Bills")]
    public async Task<ActionResult<ApiResult>> UpDataFile(IFormFile formFile)
    {
        try
        {
            using StreamReader streamReader = new(formFile.OpenReadStream());

            string data = streamReader.ReadToEnd();
            string name = formFile.FileName;
            return ApiResultHelper.Success(name);
        }
        catch (ArgumentException e)
        {
            return ApiResultHelper.Error($"上传失败: {e.Message}");
        }
    }
}
