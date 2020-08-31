using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace eNamjestaj.Data.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool admin, bool kupci, bool menadzeri, bool anonim)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { admin, kupci, menadzeri, anonim };

        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        //private IEnumerable<Uloga> _uloga;

        public MyAuthorizeImpl(bool admin, bool kupci, bool menadzeri, bool anonim)
        {
            _admin = admin;
            _kupci = kupci;
            _menadzeri = menadzeri;
            _anonim = anonim;
        }

        private readonly bool _admin;
        private readonly bool _kupci;
        private readonly bool _menadzeri;
        private readonly bool _anonim;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null && _anonim)
            {
                //    if (filterContext.Controller is Controller controller)
                //    {
                //        controller.ViewData["error_poruka"] = "Niste logirani";
                //    }
                //    filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                await next();
                return;
            }


            MojContext db = filterContext.HttpContext.RequestServices.GetService<MojContext>();

            if (k != null)
            {
                if (_kupci && db.Kupac.Any(s => s.KorisnikId == k.Id))
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }

                if (_admin && db.Zaposlenik.Any(s => s.KorisnikId == k.Id))
                {
                    await next();//ok - ima pravo pristupa
                    return;
                }

                if (_menadzeri && db.Zaposlenik.Any(s => s.KorisnikId == k.Id))
                {
                    await next();//ok - ima pravo pristupa
                    return;
                }
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.ViewData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" });





            // filterContext.Result = new UnauthorizedResult();

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}
