using eNamjestaj.Data;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Controllers;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace eNamjestaj.UnitTest
{
    
    [TestClass]
    public class AutentifikacijaControllerTest
    {
        AutentifikacijaController ac = new AutentifikacijaController();

        [TestMethod]
        public void IndexView_NotNull()
        {
            Assert.IsNotNull(ac.Index());
        }


        [TestMethod]
        public void LoginView_NotNull()
        {
            LoginVM obj = new LoginVM();
           // ViewResult vr = ac.Login(obj) as ViewResult;
            Assert.IsNotNull(ac.Login(obj));
        }
    }


    [TestClass]
    public class IB120060_UnitTests
    {
        //public MojContext CreateContextForInMemory()
        //{
        //    var option = new DbContextOptionsBuilder<MojContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

        //    var context = new MojContext(option);
        //    if (context != null)
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();
        //    }

        //    return context;
        //}

        MojContext _context = new MojContext();


        //public IB120060_UnitTests()
        //{
        //    _context = CreateContextForInMemory();

        //    var drzava = new Drzava { Naziv = "..." };
        //    var kanton = new Kanton { Naziv="...", Drzava=drzava };
        //    var opstina = new Opstina { Naziv = "...", Kanton = kanton, PostanskiBroj="..." };
        //    var uloga = new Uloga { TipUloge="..."};

        //    var korisnik = new Korisnik
        //    {
        //        KorisnickoIme="...",
        //        Lozinka="...",
        //        Opstina=opstina,
        //        Uloga=uloga
        //    };

        //    var vrstaProizvoda = new VrstaProizvoda { Naziv = "..." };

        //    var proizvod = new Proizvod
        //    {
        //        Cijena=100,
        //        Naziv="...",
        //        Sifra="...",
        //        Slika="...",
        //        Korisnik=korisnik,
        //        VrstaProizvoda=vrstaProizvoda
        //    };

        //    _context.AddRange(drzava,kanton,opstina,uloga,korisnik,vrstaProizvoda,proizvod);
        //    _context.SaveChanges();
        //}

        ProizvodiController pc = new ProizvodiController();
        [TestMethod]
        public void Test_ListaProizvoda()
        {

            List<Proizvod> ocekivani = _context.Proizvod.ToList();
            ViewResult vr = pc.Index() as ViewResult;
            ProizvodiIndexVM aktuelni = vr.Model as ProizvodiIndexVM;
            
            Assert.AreEqual(ocekivani.Count, aktuelni.Proizvodi.Count);
        }


    }


}
