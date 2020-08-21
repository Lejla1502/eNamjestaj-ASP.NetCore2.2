using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Controllers;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;

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
        private readonly User _user;
        
        public MojContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<MojContext>().
                UseSqlServer("Server=localhost,1433;Database=TestExample;User=sa;Password=password");//UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new MojContext(option.Options);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }


        private MojContext _context;


        public IB120060_UnitTests()
        {
            _user = new User { Username = "johndoe" };
            _context = CreateContextForInMemory();

            var drzava = new Drzava { Naziv = "..." };
            var kanton = new Kanton { Naziv = "...", Drzava = drzava };
            var opstina = new Opstina { Naziv = "...", Kanton = kanton, PostanskiBroj = "..." };
            var uloga = new Uloga { TipUloge = "..." };

            var korisnik = new Korisnik
            {
                KorisnickoIme = "johndoe",
                Lozinka = "...",
                Opstina = opstina,
                Uloga = uloga
            };

            var kupac = new Kupac
            {
                Ime="...",
                Prezime="...",
                Email="...",
                Adresa="...",
                Spol="..",
                Korisnik=korisnik

            };

            var vrstaProizvoda = new VrstaProizvoda { Naziv = "..." };

            var proizvod = new Proizvod
            {
                Cijena = 100,
                Naziv = "...",
                Sifra = "...",
                Slika = "...",
                Korisnik = korisnik,
                VrstaProizvoda = vrstaProizvoda
            };

            var skladiste = new Skladiste
            {
                Naziv="Skladiste",
                Opis="Opis",
                Adresa="Adresa",
                Korisnik=korisnik

            };

            var proizvodSkladiste = new ProizvodSkladiste
            {
                Proizvod=proizvod,
                Skladiste=skladiste,
                Kolicina=100
            };

            var boja = new Boja
            {
                Naziv=".."
            };

            var proizvodBoja = new ProizvodBoja
            {
                Proizvod=proizvod,
                Boja=boja
            };

            _context.AddRange(drzava, kanton, opstina, uloga, korisnik,kupac, vrstaProizvoda, proizvod, skladiste,
                proizvodSkladiste, boja, proizvodBoja);
            _context.SaveChanges();
        }

//        ProizvodiController pc = new ProizvodiController();
       // NarudzbaStavkeController nsc = new NarudzbaStavkeController();

        [TestMethod]
        public void Test_ListaSvihProizvoda_SlanjeNullVrijednostiUIndexView()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            Korisnik sessionUser = _context.Korisnik.First();
            var sessionValue = JsonConvert.SerializeObject(sessionUser);
            byte[] dummy = System.Text.Encoding.UTF8.GetBytes(sessionValue);

            mockSession.Setup(x => x.TryGetValue(It.IsAny<string>(), out dummy)).Returns(true); //the out dummy does the trick
            mockContext.Setup(s => s.Session).Returns(mockSession.Object);

            List<Proizvod> ocekivani = _context.Proizvod.ToList();
            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            //var sut = new HomeController(mockUserSession.Object);

            ProizvodiController kontroler = new ProizvodiController(mockUserSession.Object);
            var vr = kontroler.Index(null,null) as ViewResult;
            ProizvodiIndexVM rezultat = vr.Model as ProizvodiIndexVM;

            Assert.AreEqual(ocekivani.Count, rezultat.Proizvodi.Count);
        }



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



        Random random = new Random();

        


        [TestMethod]
        public void Test_ListaProizvoda()
        {
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
                ocekivani = _context.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID && bojaID == null ||
                                       ((x.ProizvodBojas.Any(pb => pb.BojaId == bojaID) && vrstaID == null) ||
                                       (x.VrstaProizvodaId == vrstaID && x.ProizvodBojas.Any(pb => pb.BojaId == bojaID)))
                                     ).ToList();

            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            var pc = new ProizvodiController(mockUserSession.Object);

            ViewResult vr = pc.Index(vrstaID, bojaID) as ViewResult;
            ProizvodiIndexVM aktuelni = vr.Model as ProizvodiIndexVM;
            List<Proizvod> aProizvodi = new List<Proizvod>();
            for (int i = 0; i < aktuelni.Proizvodi.Count; i++)
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
            CollectionAssert.AreEqual(ocekivani, aProizvodi,
                                      Comparer<Proizvod>.Create((prvi, drugi) =>
                                      prvi.Id == drugi.Id && prvi.Sifra == drugi.Sifra ? 0 : 1));
        }

        [TestMethod]
        public void Test_VracaDetaljeProizvodaNaspramIDargumenta()
        {
         
            List<int> listaIdProizvodaIzBaze = _context.Proizvod.Select(x => x.Id).ToList();
            int proizvodIdRand = random.Next(listaIdProizvodaIzBaze[0], listaIdProizvodaIzBaze[listaIdProizvodaIzBaze.Count - 1]);

            int brojacRand = random.Next(0, 3);

            Proizvod ocekivani = _context.Proizvod.Find(proizvodIdRand);

            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            var pc = new ProizvodiController(mockUserSession.Object);

            ViewResult vr = pc.Detalji(proizvodIdRand, brojacRand) as ViewResult;
            ProizvodiDetaljiVM aktuelniP = vr.Model as ProizvodiDetaljiVM;
            Proizvod aktuelni = _context.Proizvod.Find(aktuelniP.ProizvodId);

            Assert.AreEqual(ocekivani, aktuelni);


            }

        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateNotValid_CheckIfItRedirectsToActionDetalji()
        {
            List<Proizvod> listaP = _context.Proizvod.ToList();
            int proizvodId = random.Next(listaP[0].Id, listaP[listaP.Count - 1].Id);

            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            var pc = new ProizvodiController(mockUserSession.Object);

            pc.ModelState.AddModelError("kol","Required");
            ProizvodiDetaljiVM modelo = new ProizvodiDetaljiVM()
            {
                ProizvodId =proizvodId ,
                kol=0,
                BojaID=0,
                Brojac= _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count()
            };
            var result = (RedirectToActionResult)pc.ProvjeraKolicine(modelo.ProizvodId,modelo.kol,modelo.BojaID,modelo.Brojac,null);

            // Assert
           // Assert.AreEqual("Proizvodi", result.ControllerName);
            Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
        }
        //private const string LogiraniKorisnik = "logirani_korisnik";
        

        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_CheckIfItRedirectsToActionDetalji()
        {
             int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
            int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
            int bojaID = _context.Boja.Select(b => b.Id).First();
            
            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            var pc = new ProizvodiController(mockUserSession.Object);

            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110,bojaID ,brojac, null);
            
            
            
            Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_CheckIfItRedirectsToNarudzbaStavke_IndexAction()
        {
            int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
            int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
            int bojaID = _context.Boja.Select(b => b.Id).First();

            var mockUserSession = new Mock<IUserSession>();
            mockUserSession.Setup(x => x.User).Returns(_user);
            var pc = new ProizvodiController(mockUserSession.Object);

            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 2, bojaID, brojac, null);


            Assert.AreEqual("NarudzbaStavke", result.ControllerName);
            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }


    }


}
