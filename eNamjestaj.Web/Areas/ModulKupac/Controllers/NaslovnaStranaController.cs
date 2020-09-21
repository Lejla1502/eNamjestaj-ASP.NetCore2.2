using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false, true, false, true)]
    [Area("ModulKupac")]
    public class NaslovnaStranaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}