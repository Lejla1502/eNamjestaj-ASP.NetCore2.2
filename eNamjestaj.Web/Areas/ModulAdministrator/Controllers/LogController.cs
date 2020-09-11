using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]

    [Area("ModulAdministrator")]
    public class LogController : Controller
    {
        private MojContext ctx ;

        public LogController(MojContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            LogIndexVM model = new LogIndexVM()
            {
                Audits = ctx.Log.Select(x => new LogIndexVM.Audit
                {
                    Username = x.Username,
                    IPAddress = x.IPAddress,
                    AreaAccessed = x.AreaAccessed,
                    Timestamp = x.Timestamp
                }).ToList()
            };

            return View(model);
        }
    }
}