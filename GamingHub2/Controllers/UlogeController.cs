using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamingHub2.Model;
using GamingHub2.Services;

namespace GamingHub2.Controllers
{
    public class UlogeController : BaseReadController<Model.Uloge, object>
    {
        public UlogeController(IReadService<Uloge, object> service) : base(service)
        {
        }
    }
}