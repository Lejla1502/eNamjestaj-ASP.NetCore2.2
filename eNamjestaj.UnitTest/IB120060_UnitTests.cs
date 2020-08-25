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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace eNamjestaj.UnitTest
{
    
    [TestClass]
    public class IB120060_UnitTests
    {
    //    [TestClass]
    //    public class AutentifikacijaControllerTest
    //    {
    //        AutentifikacijaController ac = new AutentifikacijaController(_context);

    //        [TestMethod]
    //        public void IndexView_NotNull()
    //        {
    //            Assert.IsNotNull(ac.Index());
    //        }


    //        [TestMethod]
    //        public void LoginView_NotNull()
    //        {
    //            LoginVM obj = new LoginVM();
    //            // ViewResult vr = ac.Login(obj) as ViewResult;
    //            Assert.IsNotNull(ac.Login(obj));
    //        }
    //    }


        public MojContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<MojContext>().
                UseInMemoryDatabase(databaseName: "Test_Database").Options;
            //var option = new DbContextOptionsBuilder<MojContext>().
            //    UseSqlServer("Server=localhost,1433;Database=TestExample;User=sa;Password=password");//UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new MojContext(option);//option.Options);
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
                Naziv = "NazivPr",
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

        //[TestMethod]
        //public void Test_ListaSvihProizvoda_SlanjeNullVrijednostiUIndexView()
        //{
        //    List<Proizvod> ocekivani = _context.Proizvod.ToList();
        //    var mockUserSession = new Mock<IUserSession>();
        //    mockUserSession.Setup(x => x.User).Returns(_user);

        //    ProizvodiController kontroler = new ProizvodiController(mockUserSession.Object);
        //    var vr = kontroler.Index(null,null) as ViewResult;
        //    ProizvodiIndexVM rezultat = vr.Model as ProizvodiIndexVM;

        //    Assert.AreEqual(ocekivani.Count, rezultat.Proizvodi.Count);
        //}



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
        private IHostingEnvironment hostingEnvironment;

        // ProizvodiController pc = new ProizvodiController(_context);
        private HttpContext GetMockedHttpContext()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            var mockUserSession = new Mock<IUserSession>();
            Korisnik sessionUser = _context.Korisnik.First();// new Korisnik() { KorisnickoIme = "MyValue" };
            var sessionValue = JsonConvert.SerializeObject(sessionUser);
            byte[] dummy = System.Text.Encoding.UTF8.GetBytes(sessionValue);
            mockSession.Setup(x => x.TryGetValue(It.IsAny<string>(), out dummy)).Returns(true); //the out dummy does the trick
            mockContext.Setup(s => s.Session).Returns(mockSession.Object);
            
            return mockContext.Object;
            

        }

       

        [TestMethod]
        [DataRow(null,null)]
        [DataRow(1,1)]
        public void Test_ListaProizvoda(int? vrstaID, int? bojaID)
        {
            List<Proizvod> ocekivani = new List<Proizvod>();

            if (vrstaID == null && bojaID == null)
                ocekivani = _context.Proizvod.ToList();
            else
                ocekivani = _context.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID && bojaID == null ||
                                       ((x.ProizvodBojas.Any(pb => pb.BojaId == bojaID) && vrstaID == null) ||
                                       (x.VrstaProizvodaId == vrstaID && x.ProizvodBojas.Any(pb => pb.BojaId == bojaID)))
                                     ).ToList();

            //var mockUserSession = new Mock<IUserSession>();
            //mockUserSession.Setup(x => x.User).Returns(_user);
            //var pc = new ProizvodiController();//(mockUserSession.Object);
            // GetMockedHttpContext();
            ProizvodiController pc = new ProizvodiController(_context);
            pc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            ViewResult vr = pc.Index(vrstaID, bojaID) as ViewResult;
            ProizvodiIndexVM aktuelni = vr.Model as ProizvodiIndexVM;
            //List<Proizvod> aProizvodi = new List<Proizvod>();
            
            
            Assert.AreEqual(ocekivani.Count, aktuelni.Proizvodi.Count);
          }

        [TestMethod]
        [DataRow(1,1)]
        public void Test_VracaDetaljeProizvodaNaspramIDargumenta(int id, int brojac)
        {

            //var mockUserSession = new Mock<IUserSession>();
            //mockUserSession.Setup(x => x.User).Returns(_user);
            //var pc = new ProizvodiController();// (mockUserSession.Object);
            ProizvodiController pc = new ProizvodiController(_context);
            pc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            ViewResult vr = pc.Detalji(id, brojac) as ViewResult;
            
            ProizvodiDetaljiVM aktuelniP = vr.Model as ProizvodiDetaljiVM;

            Assert.AreEqual("NazivPr", aktuelniP.Naziv);


            }

        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateNotValid_CheckIfItRedirectsToActionDetalji()
        {
            int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
            int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
            int bojaID = _context.Boja.Select(b => b.Id).First();
            
            GetMockedHttpContext();
            ProizvodiController pc = new ProizvodiController(_context);
            pc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            pc.ModelState.AddModelError("kol","Required");
            
            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110, bojaID, brojac, null);
            
            Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
        }

       

        //private const string LogiraniKorisnik = "logirani_korisnik";


        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_CheckIfItRedirectsToActionDetalji()
        {
             int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
            int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
            int bojaID = _context.Boja.Select(b => b.Id).First();

            GetMockedHttpContext();
            ProizvodiController pc = new ProizvodiController(_context);
            pc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110,bojaID ,brojac, null);
            Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_CheckIfItRedirectsToNarudzbaStavke_IndexAction()
        {
            int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
            int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
            int bojaID = _context.Boja.Select(b => b.Id).First();

            GetMockedHttpContext();
            ProizvodiController pc = new ProizvodiController(_context);
            pc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            
            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 2, bojaID, brojac, null);


            Assert.AreEqual("NarudzbaStavke", result.ControllerName);
            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

       

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkicjaDodaj_ViewNotNull_VracaIspravanModel()
        {
            GetMockedHttpContext();
             ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment,_context );
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            ViewResult result = pmc.Dodaj() as ViewResult;
            ProizvodiDodajVM aktualni = result.Model as ProizvodiDodajVM;

            Assert.IsNotNull(pmc.Dodaj());
            Assert.AreEqual(_context.VrstaProizvoda.ToList().Count, aktualni.Vrste.Count);
            Assert.AreEqual(_context.Boja.ToList().Count, aktualni.Boje.ToList().Count);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateNotValid()
        {
            GetMockedHttpContext();
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            pmc.ModelState.AddModelError("Naziv", "Required");
            pmc.ModelState.AddModelError("Sifra", "Required");
            pmc.ModelState.AddModelError("Cijena", "Required");
            pmc.ModelState.AddModelError("VrstaID", "Required");
            pmc.ModelState.AddModelError("BojaID", "Required");
            pmc.ModelState.AddModelError("UploadPic", "Required");
            

            var result = pmc.UploadProduct(new ProizvodiDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateValid_IFormFileNull_RedirectsToDodaj()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");
            
            GetMockedHttpContext();
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            ProizvodiDodajVM newPr = new ProizvodiDodajVM {
                Naziv="...",
                Sifra="...",
                Cijena="...",
                VrstaID=1,
                BojeID = { },
                Slika="",
                UploadPic=null
            };

            var result=(RedirectToActionResult) pmc.UploadProduct(newPr);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Dodaj", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateValid_AfterAddedProductRedirectsToIndexProizvodi()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");
           // mockEnvironment.Setup(m => m.WebRootPath).Returns("@C:\\Users\\User\\source\\repos\\eNamjestaj.UnitTest");

            GetMockedHttpContext();
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var physicalFile = new FileInfo(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg");
            var fileName = physicalFile.Name;
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(physicalFile.OpenRead());
            writer.Flush();
            ms.Position = 0;
           fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
           
            fileMock.Verify();
           
            var file = fileMock.Object;

            int[] temp = { 1,2};
            ProizvodiDodajVM newPr = new ProizvodiDodajVM
            {
                Naziv = "Proizvod123",
                Sifra = "11111",
                Cijena = "111.11",
                VrstaID = 1,
                BojeID = temp,
                Slika = "defaultString",
                UploadPic = file
            };

            var result = (RedirectToActionResult)pmc.UploadProduct(newPr);

            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            Assert.AreEqual("Proizvodi", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }
    }


}
