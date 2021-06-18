using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class KonzolaService : BaseCRUDService<Model.Konzola, Database.Konzola, object, KonzolaUpsertRequest, KonzolaUpsertRequest>, IKonzolaService
    {
        public KonzolaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
