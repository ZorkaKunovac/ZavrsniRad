using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    public class UlogeController : Controller
    {

        APIService _service = new APIService("Uloge");

        public async Task<IActionResult> Index()
        {
            var roles = await _service.Get<List<Uloge>>(null);
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                if (roleName != null)
                {
                    UlogaInsertRequest request = new UlogaInsertRequest();
                    request.Naziv = roleName;
                    await _service.Insert<Model.Uloge>(request);
                }
            }
            catch
            {
                return View("Neispravan naziv");
            }

            return Redirect("/Uloge/Index");
        }
    }
}
