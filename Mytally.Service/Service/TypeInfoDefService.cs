using MyTally.Models;
using MyTally.Repository.IRepository;
using MyTally.Service.IService;

namespace MyTally.Service.Service;

public class TypeInfoDefService : BaseService<TypeInfoDef>, ITypeInfoDefService
{
    private readonly ITypeInfoDefRespository _iTypeInfoDefRepository;

    public TypeInfoDefService(ITypeInfoDefRespository typeInfoDefRepository)
    {
        _repository = typeInfoDefRepository;
        _iTypeInfoDefRepository = typeInfoDefRepository;
    }
}
