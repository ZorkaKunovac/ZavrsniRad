using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class KupacService : BaseCRUDService<Model.Kupac, Database.Kupac, object, KupacInsertRequest, object>
    {
        public KupacService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
