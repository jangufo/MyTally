using Mytally.Models;
using Mytally.Repository.IRepository;
using Mytally.Service.IService;

namespace Mytally.Service.Servce;

public class BillService : BaseService<Bill>, IBillService
{
    private readonly IBillRespository _iBillRespository;

    public BillService(IBillRespository billRespository)
    {
        _repository = billRespository;
        _iBillRespository = billRespository;
    }
}
