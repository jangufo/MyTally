using Mytally.Models;
using Mytally.Repository.IRepository;
using Mytally.Service.IService;

namespace Mytally.Service.Servce;

public class TagDefService : BaseService<TagDef>, ITagDefService
{
    private readonly ITagDefRespository _iTagDefRespository;

    public TagDefService(ITagDefRespository tagDefRespository)
    {
        _repository = tagDefRespository;
        _iTagDefRespository = tagDefRespository;
    }
}
