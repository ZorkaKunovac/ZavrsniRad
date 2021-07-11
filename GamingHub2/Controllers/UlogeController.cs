using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamingHub2.Model;
using GamingHub2.Services;
using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Authorization;

namespace GamingHub2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UlogeController : BaseCRUDController<Model.Uloge, object,UlogaInsertRequest,object>
    {
        public UlogeController(ICRUDService<Uloge, object,UlogaInsertRequest,object> service) : base(service)
        {
        }
    }
}