using MyTally.Models;
using MyTally.Repository.IRepository;
using MyTally.Service.IService;
using MyTally.Service.Service;

namespace MyTally.Service.Service;

public class BillService : BaseService<Bill>, IBillService
{
    private readonly IBillRespository _iBillRepository;

    public BillService(IBillRespository billRepository)
    {
        _repository = billRepository;
        _iBillRepository = billRepository;
    }
}