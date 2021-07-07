using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    public class KupacController : BaseCRUDController<Model.Kupac, KupacSearchRequest, KupacUpsertRequest, KupacUpsertRequest>
    {
        public KupacController(ICRUDService<Kupac, KupacSearchRequest, KupacUpsertRequest, KupacUpsertRequest> service) : base(service)
        {
        }
    }
}
