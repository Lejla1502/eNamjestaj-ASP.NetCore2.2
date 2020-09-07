using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]
    [Area("ModulAdministrator")]
    public class KorisniciController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}