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
    [Authorize]
    public class IgraController : BaseCRUDController<Model.Igra, IgraSearchRequest, IgraUpsertRequest, IgraUpsertRequest>
    {
        public IgraController(IIgraService service) : base(service)
        {
        }
    }
}
