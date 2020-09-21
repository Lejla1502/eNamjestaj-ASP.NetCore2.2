using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NaslovnaStranaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}