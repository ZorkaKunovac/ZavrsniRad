using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KonzolaController : BaseCRUDController<Model.Konzola, object, KonzolaUpsertRequest, KonzolaUpsertRequest>
    {
        public KonzolaController(IKonzolaService service) : base(service)
        {
        }
    }
}