using Mytally.Models;
using Mytally.Repository.IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mytally.Repository.Repository;

public class AccountBookDefRespository
    : BaseRepository<AccountBookDef>,
        IAccountBookDefRespository { }
