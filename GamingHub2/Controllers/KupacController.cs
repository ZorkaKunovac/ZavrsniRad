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
    public class KupacController : BaseCRUDController<Model.Kupac, object, KupacInsertRequest, object>
    {
        public KupacController(ICRUDService<Kupac, object, KupacInsertRequest, object> service) : base(service)
        {
        }
    }
}
