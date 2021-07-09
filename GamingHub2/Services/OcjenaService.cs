using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class OcjenaService : BaseCRUDService<Model.Ocjena, Database.Ocjena, object, OcjenaInsertRequest, object>
    {
        public OcjenaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
