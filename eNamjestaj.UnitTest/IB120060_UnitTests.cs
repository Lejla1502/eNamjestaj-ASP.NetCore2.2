using eNamjestaj.Data;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Controllers;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
        //[DataRow(null,null)]
        //[DataRow(1,null)]
        //[DataRow(2,null)]
        //[DataRow(5,null)]
        //[DataRow(null,2)]

        //Testni podaci su samo za bazu na serveru
        //jer se ID-evi za proizvode ne poklapaju sa onima u lokalnoj
        //bazi
        //Na lokalnoj bazi ID-evi se krecu od 17-35
        //a na app.fit.ba od 1 do 16
        public void Test_ListaProizvoda()
        {
            var random = new Random();
            int randomVrstaID = random.Next(0, 5);
            int randomBojaID = random.Next(0, 5);
            int? vrstaID = null;
            int? bojaID = null;

            if (randomVrstaID != 0)
                vrstaID = randomVrstaID;
            if (randomBojaID != 0)
                bojaID = randomBojaID;


            List<Proizvod> ocekivani = new List<Proizvod>();

            if (vrstaID == null && bojaID == null)
                ocekivani = _context.Proizvod.ToList();
            else
               ocekivani= _context.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID && bojaID == null ||
                                     ((x.ProizvodBojas.Any(pb => pb.BojaId == bojaID) && vrstaID == null) ||
                                     (x.VrstaProizvodaId == vrstaID && x.ProizvodBojas.Any(pb => pb.BojaId == bojaID)))
                                    ).ToList();

            ViewResult vr = pc.Index(vrstaID,bojaID) as ViewResult;
            ProizvodiIndexVM aktuelni = vr.Model as ProizvodiIndexVM;
            List<Proizvod> aProizvodi = new List<Proizvod>();
            for (int i=0;i< aktuelni.Proizvodi.Count;i++)
            {
                Proizvod p = new Proizvod();
                p.Id = aktuelni.Proizvodi[i].Id;
                p.Cijena = aktuelni.Proizvodi[i].Cijena;
                p.Naziv = aktuelni.Proizvodi[i].Naziv;
                p.Sifra = aktuelni.Proizvodi[i].Sifra;
                p.Slika = aktuelni.Proizvodi[i].Slika;
                aProizvodi.Add(p);
               
            }

            
            Assert.AreEqual(ocekivani.Count, aktuelni.Proizvodi.Count);
            CollectionAssert.AreEqual(ocekivani,aProizvodi, 
                                      Comparer<Proizvod>.Create((prvi,drugi)=>
                                      prvi.Id==drugi.Id && prvi.Sifra==drugi.Sifra?0:1));
        }


    }


}
