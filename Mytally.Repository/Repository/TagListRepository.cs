using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTally.Models;
using MyTally.Repository.IRepository;

namespace MyTally.Repository.Repository;

public class TagListRepository : BaseRepository<TagList>, ITagListRespository { }
