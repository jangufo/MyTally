using MyTally.Models;
using MyTally.Repository.IRepository;
using MyTally.Service.IService;

namespace MyTally.Service.Service;

public class TagDefService : BaseService<TagDef>, ITagDefService
{
    private readonly ITagDefRespository _iTagDefRepository;

    public TagDefService(ITagDefRespository tagDefRepository)
    {
        _repository = tagDefRepository;
        _iTagDefRepository = tagDefRepository;
    }
}
