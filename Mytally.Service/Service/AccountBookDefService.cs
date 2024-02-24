using MyTally.Models;
using MyTally.Repository.IRepository;
using MyTally.Service.IService;

namespace MyTally.Service.Service;

public class AccountBookDefService : BaseService<AccountBookDef>, IAccountBookDefService
{
    private readonly IAccountBookDefRespository _iAccountBookDefRepository;

    public AccountBookDefService(IAccountBookDefRespository accountBookDefRepository)
    {
        _repository = accountBookDefRepository;
        _iAccountBookDefRepository = accountBookDefRepository;
    }
}
