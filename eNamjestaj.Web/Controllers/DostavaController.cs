﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Controllers
{
    public class DostavaController : Controller
    {
        private MojContext ctx;
        public DostavaController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(int narudzbaId, string total)
        {
            DostavaIndexVM model = new DostavaIndexVM
            {
                Dostave = ctx.Dostava.Select(x => new DostavaIndexVM.DostavaInfo
                {
                    Id = x.Id,
                    Cijena = x.Cijena.ToString().Replace(",", "."),
                    Opis = x.Opis,
                    Tip = x.Tip
                }).ToList(),
                NarudzbaID = narudzbaId,
                Total = total
            };
            return View(model);
        }
    }
}