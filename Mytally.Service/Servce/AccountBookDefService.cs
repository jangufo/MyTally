using Mytally.Models;
using Mytally.Repository.IRepository;
using Mytally.Service.IService;

namespace Mytally.Service.Servce;

public class AccountBookDefService : BaseService<AccountBookDef>, IAccountBookDefService
{
    private readonly IAccountBookDefRespository _iAccountBookDefRespository;

    public AccountBookDefService(IAccountBookDefRespository accountBookDefRespository)
    {
        _repository = accountBookDefRespository;
        _iAccountBookDefRespository = accountBookDefRespository;
    }
}
