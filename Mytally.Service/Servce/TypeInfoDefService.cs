using Mytally.Models;
using Mytally.Repository.IRepository;
using Mytally.Service.IService;

namespace Mytally.Service.Servce;

public class TypeInfoDefService : BaseService<TypeInfoDef>, ITypeInfoDefService
{
    private readonly ITypeInfoDefRespository _iTypeInfoDefRespository;

    public TypeInfoDefService(ITypeInfoDefRespository typeInfoDefRespository)
    {
        _repository = typeInfoDefRespository;
        _iTypeInfoDefRespository = typeInfoDefRespository;
    }
}
