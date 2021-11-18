using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Model;

namespace GamingHub2.WebApp2.Helpers
{

    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool administrator = false, bool moderator = false, bool korisnik = false)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { administrator, moderator, korisnik };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool administrator, bool moderator, bool korisnik)
        {
            _administrator = administrator;
            _moderator = moderator;
            _korisnik = korisnik;
        }
        private readonly bool _administrator;
        private readonly bool _moderator;
        private readonly bool _korisnik;
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Korisnici k = await filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_message"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Login", new { @area = "" });
                return;
            }

            //mogu pristupiti administratori
            if (_administrator && k.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator"))
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            // mogu pristupiti moderatori
            if (_moderator && k.KorisniciUloge.Any(x => x.Uloga.Naziv == "Moderator"))
            {
                await next();//ok - ima pravo pristupa
                return;
            }

            //mogu pristupiti korisnici
            if (_korisnik && k.KorisniciUloge.Any(x => x.Uloga.Naziv == "Korisnik"))
            {
                await next();//ok - ima pravo pristupa
                return;
            }

            filterContext.Result = new RedirectToActionResult("AccessDenied", "Login", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}
