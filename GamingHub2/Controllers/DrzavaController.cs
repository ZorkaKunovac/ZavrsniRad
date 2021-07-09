using GamingHub2.Model;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    public class DrzavaController : BaseReadController<Model.Drzava, object>
    {
        public DrzavaController(IReadService<Drzava, object> service) : base(service)
        {
        }
    }
}
