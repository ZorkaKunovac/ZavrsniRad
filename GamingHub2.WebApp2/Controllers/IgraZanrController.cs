using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    public class IgraZanrController : Controller
    {
        APIService _service = new APIService("IgraZanr");

        public async Task<IActionResult> Index(int IgraID)
        {
            //var igrazanr = await _service.Get<Model.IgraZanrPrikazVM>(null, "GetIgraZanr");
            var igrazanr = await _service.Get<Model.IgraZanrPrikazVM>(IgraID, "GetIgraZanr");


            return View(igrazanr);
        }
    }
}
