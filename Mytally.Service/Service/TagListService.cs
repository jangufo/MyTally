using MyTally.Models;
using MyTally.Repository.IRepository;
using MyTally.Service.IService;

namespace MyTally.Service.Service;

public class TagListService : BaseService<TagList>, ITagListService
{
    private readonly ITagListRespository _iTagListRepository;

    public TagListService(ITagListRespository tagListRepository)
    {
        _repository = tagListRepository;
        _iTagListRepository = tagListRepository;
    }
}
