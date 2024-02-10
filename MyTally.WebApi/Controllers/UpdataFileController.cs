using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mytally.Service.IService;
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
            return ApiResultHeaper.Success(name);
        }
        catch (ArgumentException e)
        {
            return ApiResultHeaper.Error($"上传失败: {e.Message}");
        }
    }
}
