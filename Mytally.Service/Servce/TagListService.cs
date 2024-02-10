using Mytally.Models;
using Mytally.Repository.IRepository;
using Mytally.Service.IService;

namespace Mytally.Service.Servce;

public class TagListService : BaseService<TagList>, ITagListService
{
    private readonly ITagListRespository _iTagListRespository;

    public TagListService(ITagListRespository tagListRespository)
    {
        _repository = tagListRespository;
        _iTagListRespository = tagListRespository;
    }
}
