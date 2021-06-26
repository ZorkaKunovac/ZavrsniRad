using AutoMapper;
using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    [Authorize(Roles = "Administrator")]

    public class KonzolaService : BaseCRUDService<Model.Konzola, Database.Konzola, object, KonzolaUpsertRequest, KonzolaUpsertRequest>, IKonzolaService
    {
        public KonzolaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
