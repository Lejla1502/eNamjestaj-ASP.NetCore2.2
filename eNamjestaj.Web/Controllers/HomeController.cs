using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eNamjestaj.Web.Models;
using eNamjestaj.Data.Helper;

namespace eNamjestaj.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
               return RedirectToAction("Index", "Autentifikacija");

            return View();
        }

        
    }
}
