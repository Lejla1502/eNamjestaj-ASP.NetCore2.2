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
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.DataProtection;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using eNamjestaj.Web.Areas;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using eNamjestaj.Web.Areas.ModulMenadzer.Controllers;
using eNamjestaj.Web.Areas.ModulKupac.Controllers;
using eNamjestaj.Web.Areas.ModulKupac.ViewModels;
using eNamjestaj.Web.Areas.ModulAdministrator.Controllers;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
//using Xunit;

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
            var uloga = new Uloga { TipUloge = "admin" };
            _context.AddRange(drzava, kanton, opstina, uloga);
            _context.SaveChanges();

            _context.Uloga.Add(new Uloga { TipUloge = "menadzer" });
            _context.Uloga.Add(new Uloga { TipUloge = "skladistar" });
            _context.Uloga.Add(new Uloga { TipUloge = "dostavljac" });
            _context.Uloga.Add(new Uloga { TipUloge = "kupac" });
            _context.SaveChanges();


            var korisnik = new Korisnik
            {
                KorisnickoIme = "johndoe",
                Lozinka = "...",
                Opstina = opstina,
                UlogaId = 5
            };

            var kupac = new Kupac
            {
                Ime = "kupac",
                Prezime = "...",
                Email = "...",
                Adresa = "...",
                Spol = "..",
                Korisnik = korisnik

            };
            _context.AddRange(korisnik,
                kupac
              );

            _context.SaveChanges();

            _context.Korisnik.Add(new Korisnik
            {
                KorisnickoIme = "zaposlenik",
                Lozinka = "zaposlenik",
                Opstina = opstina,
                UlogaId = 2
            });

            var zaposlenik = new Zaposlenik {
                Ime = "menadzer",
                Prezime = "menadzer",
                Email = "menadzerMail",
                Adresa = "...",
                Telefon = "-...",
                KorisnikId = 2
            };

            var vrstaProizvoda = new VrstaProizvoda { Naziv = "Ormar" };

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
                Naziv = "Skladiste",
                Opis = "Opis",
                Adresa = "Adresa",
                Korisnik = korisnik

            };

            var proizvodSkladiste = new ProizvodSkladiste
            {
                Proizvod = proizvod,
                Skladiste = skladiste,
                Kolicina = 100
            };

            var boja = new Boja
            {
                Naziv = ".."
            };

            var proizvodBoja = new ProizvodBoja
            {
                Proizvod = proizvod,
                Boja = boja
            };

            var dostava = new Dostava
            {
                Tip = "...",
                Cijena = 10,
                Opis = "..."
            };

            var narudzba = new Narudzba
            {
                BrojNarudzbe = "....",
                Datum = DateTime.Now,
                Status = false,
                Aktivna = false,
                Otkazano = false,
                NaCekanju = false,
                Kupac = kupac
            };

            var narudzbaStavka = new NarudzbaStavka
            {
                Kolicina = 3,
                ProizvodId = 1,
                Narudzba = narudzba,
                BojaId = 1,
                CijenaProizvoda = 1230,
                PopustNaCijenu = 10,
                TotalStavke = 1000
            };

            var izlaz = new Izlaz
            {
                BrojNarudzbe = "212121",
                Datum = DateTime.Now,
                Zakljucena = false,
                IznosBezPDV = 1000,
                IznosSaPDV = 1170,
                PovratNovca = false,
                Skladiste = skladiste,
                Korisnik = korisnik,
                Narudzba = narudzba,
                Dostava = dostava
            };

            var izlazStavka = new IzlazStavka
            {
                Cijena = 1230,
                Popust = 10,
                Kolicina = 3,
                Konacnacijena = 1000,
                Proizvod = proizvod,
                Izlaz = izlaz

            };

            var strJsonSer = JsonConvert.DeserializeObject("\"6K68sp5NupOcKWTwyaXvkqJ7s5JHZQiWfOI8mzehtq3eXQd3hv8mVjln51tak1iqBCHKQCo8IzQCilvjcfLXInzq7gpoYQ9mN6KffSgVd6IIqDVFaoL1Asl6n0MeCWXxapdLHDDapVzcA6LQ9LwA3L59vHj0vyJB1FEIpkenUtMPCQYXXw2TYq2VpZAGltHuOHz990aNPOEX3Hvr7Xk9onVAb1qgSdUsTvFe5UxCxe7RkrsskM5nx451glen3NPUM2M445pMLi3kA5rfDhk6brkDnoSdsjbyuJalxPMnfluVKFnoO36DwbwKPSGnDgxK3qk6spifXbkbXhkQzZQGpKTIcW1cRNLUs0QWuRPliNLAJiqYoPbQQOOYqgthhAnW8HxTf850iLtxpEtGtNy9t3SkHzmZsGVQdw4kv5HYXaf9svNnhM3COFiPNL3WvbVPuf3qrkQ2pgEqNd4DF11QcHpcbKUMJjM8VE82O3313joAQvrVWZ0JZfO7SKck10bj77sILYkjhoF00l5W4soRmxwVQ3yMtZ1PbzJrOOT3u7rXGkKO6YAn4dZ2u54mw4lftiB47GKi6nfelilXCpeH6AlIOYWHndaeE1medyfARIRWSF0bbwBgz5Yai7DbGHGwY0NeDMUyOHTKd8GDQbRTOgzRVKe3q6pDJ3YRNys8hSL6LXD7FfvEDidk9uJNUhthuCOaCCiQSjTjxlV3G59WKye9lTWAnX1iWM8fVLdH86m4DUhri3PZH1wsp8hBtP1rLD0pqQddpnUQ4XCnzyCzKOdCXATettbbTEWDg7yd3LrVWLokr40cwgoTOGzir5lt1OJbrFBosk5h4fZP55Bllgcc6RKc1NTn6Hx7fXwN0OkMU0l4EWa95ZAOlujzCQ86q0sklIJy5J145pJxb5e3CJWiikhDADYHwaCPTwmIVF4AVZEv0B2y7TyeLHL8aS8Pbqp7NUg7y2TC1oWutlGF0L9ShuMWeZ8TTlU4sCA56CcyG5ZVpXYC8XmlkWPPI2fPUDJfFEK5HM4czc4TCyW0Paqq3QuhA6LdWC1ydiY1MfgcG16khBmcZE5f7KyaEOpuaHtjk8KzRatlX3nAvKHoZyBYZGBMZyoQ4eYoLydPIf8gxKuNJt30w0UeBxv095vybPqMHSmtmkh15xm1k6NWiYRnNmfCoOwdP9kE98GYzJBhiYkKN9sm38VRXekIzAM3ZusNqqGrSLlthKO3a5IG9pC99NuPvj685eCIKOTIQNWoKCjF8wfG3vpQL4MwZwMl0eshi4plgCDZW4UEzAH32yp5g6oku9L3aV9077oqKFzL4NlnlPnhrfcFb8PmosFdiOOOTKDM2ytlKgqRqnu0s5HiWT4mEhjcxHVd1Ir5VbBDTLzrb8b3G6cbH1aE0zRRFKRZge6Llur5d6RE3htQpwBjhCEpGXkRA9unaPpqLBsPeTD9i7PoBfZJAVPVQYn4HWkAiCQJPF46cNwePxTqZp0eQDE0BxGXo86AFWsNCJvFoe26W72x25jHY7J2JP7mt6VrQBMVVW0EeUmKj7pvamB8OMtf2PKgvuty9t3MJPz3EkiYP7QzMBqsBA71qKHfRjCExjkSLvxQ07pebzwzb09cDEQUzHcMOygp0bQaiu4RjdhsdD2KmgbIDwubL1lj4qtPylki9XifPoziJflN3OTH4k5l85RsxxcBMsLOUFeZ5BFOhcYWiGQkzeeXh6hEfR7M1nbIQn0JN9dH7ETJb38Xs27DlDmxZPAWh4dyC29xKCOofrhz6Jy3bXHQmOPRlfUgZEQSVwKi8ZKjenrx0AeQqyAuwwRlUv0Yc3T6NBTWOI1epP71JKCsvbQytFFtOmqNCMjDqMVxQj7Pof47RY7oQvDKQQGHsx6kID8f038NgXnHuCUgRmnG0IOrHy8AY753INv1T65D0bB0nqtISvum0HMgwyhlamInZt9iEsyob20FmWhQIJZWaKVk5ebD9rek1toCJvLQX2v3mV3NSXtL1q07mgWAg8bQFEkit8JWRax1ncVjM1u6nZM7cmqh8ZFkTAdlvrHf4QCvcKrVAPNAKW6QIKvvu22K9LhdMET4d56wI1AISivAEpP9Ye71TK92IQ7zKOLsEl4hp6SHLMWwmfgB3a9riri5gTsJT3ttOhhSIL2REORGQa3Ux4PqxJyf6QjdRlqiGfgU6YJf7M2i1C0RKyEFGGWSXg5byFAzzqAoCMEtdYBt04SmEs6Yd4TToJ0mN1FCelDTeJ5Lssm7gpTBjTPKAhqueB4pHFIkeSXA77yVhlAMFT6t9OZ3aham0GJDnL4Jjz5MLZHiVwPcbbrEXv27Ce8a05rGstKPkZ73xiCQBUr2dsfJySYrIhgYNqIeGL8tfzFa8Uzo1NMj0uBAkitMPwzgY32VFXqR2SOzPtISuTNyxDiCqVgNL6TvrwUCCscUzsp6bF1qEyKw4tgyDwSeJtZofDRr3GhQGhM5JYxbngM8OmOJp6QXcBo7drl6D4TYlBfFwD2YR4QOUFY8qkaJZ28uw2uvZnoACPI0ZVqK8nGVkqySuhaF0pUakfWuLa0vbEqBVn27x0W8Zyx25fptF3jeZJCgA6hTrVatkTkc4XHEV8yP6yLWLIjV2rsjJ7fYlTjPhC3GUVQ3gGnDGkRWtjIzmGMEHIdKTMWk0kREzmTbij6CX83O1HELX8Ypec358MHx7JX6jL0RkFRdYNnxDuRhCgwVN7dMMWnUFQjU87lTSlCAn8IfPWu6eULUp6HtGTyYwDxP6ZaGKiYBH5YIu2bdpA1N04cPBelhKG7eT2KgORnNyYxlqVjYVCQx7ykSKWTUE8ybwZsDVKk4ECEPfDd6hefChnptj4IHjFxCLgSTF7xqOUi6TRbcemUgs01EWuJgqhmeaZLHmDCL0dPcU0eumEKEyo16GTZOkgznEoIgts6nK7Fp8uAxbtG3SFA6MmBB2PoyMqUs77IAZlCnZehdktX2Lqrp8VYZOSOwvOd8Nfb0deOkFVjVUzLw97GKx8hZdEhsNUfEkEEcL3UyPYD8yQXKdKjCs4ndDNtskKRMduDKMn3aNDorRyvNpZUtQOfpt0ROkdYfcRFCtBgejh8jgJei2bumjimtmTfydnlGzlxWkZguvfmBr4mgCzK6YuqUgsWVgWJ8W30TmiRV7CTpIPjEQpD7M7KmNKtwkwDPAPLzXILQC8AWa5Ct596RXlt12hLGL88FppFbl1E1E0BJ4N0CqJ8L1mwzFb8zreJd7YfMO3L9mC7uoGB9uXAlO1m2UYfxcyJf9zTymAKRf3mXivdu2jj9na0tL3VMD03rvjDmDDjgxUpCrCvmbC1R38vsLWbrGzoh6oAt1mUhP02d3EcGF24kKJef4w6Yo2oYOoiu7yP1J6H4Qw8BCpueHbIp2gHbDurnO6xhT3wbG2rZO5igdYjrBgEZwEkK2JsHFh3AN39ZQu647VklalZ142G3HGpfVwpafAfnebWgjesbhwT7n2jGYdCcvkaeKbhOLhpAAvVYcTgx3ZEKgAkHEgj4ZQTAOBp5sD8rmsBevCL7CoiEA565jcILYbjcB69VvdGxTCGAvfoUtqZJFopvnWwdlS42h5XF9nYvHvffrnFhYvJQLs130Z7U84JrwSKxsmBsLuIMT9soJeMHpMNcczlORSYiYtRkmu8ntgP5PAwUDQqmdBwZKIssAgjKPgmBQVyTPqU962cyduvwehnoXhuEhKZrSpI36cJWvh3wkWthK8h7YsvoZjiQNP6nxhZ5Wse8xQ5nzJekQF8lz3qNdYkgd5ZuIviqDQeCz7WOsb0wRoiX4Ta0ePB3XC6atxs9dTW2TYJYDL4T7kMb3JvxpzxlCdE8ihN0S7ybgw1ZsVhpyDKqKFZeytMIIBHIllKsIxotRmNiccjGcnCFL4jcwQoxeTg5ha9wtb1iZe8R9WKZDa7nzqRfkR5uFQrNocym2DtXbiyeafs6NfM1M56EUgGDB5dKD4yVbwQbhYWs1yT36FaS3xVD16egInievyM2kWXjsgQRC3aWUvq3cq6wnI8hffXSGrRAGJ46JPUm0gBlWgXGoQWvQiKkz75CU5lvY643qVP68KQetff8E683geD523g6i3Qxa3V9dJRRP0uuCcC57W2AN7oWHf4OdDuNHNXQEd81n5QsRolGfjFP2GqJnprfHm9eX4pETsM0Rmdlwf0SFFThzgNn74WsJBB6HpNXlkfwJGM2sJM1xpzFJxHMLn0iQyDlXngRad3ttjqxkgwHHHArTRT0SCzdHYEcauiVuIZJVAHmOgy3WGilzRhLBQUdBYAPO3eO07whkuQhuN0rKQIsAgKAuBLwrMzYz38nejxJdA5mBnAqf0eoxBOVFnyGcCtQXzgM1GJT5hrx0yPzaq4ES1I3T0jTj5xtF2PJiZ2ZMO4iHhvvDQyIwy2ilLJdVKv02Nnr1H4IDB0xSLCvfDLVztw43C1SteP9KPiGSJiPjBkjsggTyBa44jARVZOMISZdda0he2TYFPYZkEuHxwjWpzfXLFil0pCnp8T6DgkEkPtgNeWRWFqhN3Y8f5gkomifSOtgeLOcKVaaPrD4e4pw1CvHRbxMrN0KneBpzzznkrAfyTXyuDAqAelfAm1qtmAihWk3EaqeGlgfj9ZfhI9IKr6V6IBUn1qt3OhX837Ta9mLrMtYfgmAw93UJv9hsyRRO50LD2VlwEMwgesv9uAjQUMI4KD008MKEqSbDrPh0iVf4bkaZwrSOZaFQBkTBazgHhd5RqG2l63dk9dMk8CWj7ipd3Z42UQd1dv5kv7HF44d4T326UX7MwXBIoUeIUwA76cAKsELdjkNBAy0NPoy0iym1bo4lWjzb3URTHA3MLkbOiAFi68Q4Tv124dl7LeRC4e6WsvOy89bL3txsrQ7Y4JAZ6xsRJdCSxAwakvF7xWAjGnKBrx2aZAmEgeyvyAEECzdITLArm3OvU9WKKlMd74244iOZaAQcSLh7ct1vd27XNms\"");


            var autorizacijskiToken = new AutorizacijskiToken
            {
                Vrijednost = strJsonSer.ToString(),
                KorisnikId = 1,
                VrijemeEvidentiranja = DateTime.Now
            };

            var recenzija = new Recenzija
            {
                Proizvod = proizvod,
                Kupac = kupac,
                Ocjena = 3,
                Sadrzaj = "..",
                Datum = DateTime.Today
            };

            var akcijskiKatalog = new AkcijskiKatalog
            {
                Opis = "junski k.",
                DatumPocetka = Convert.ToDateTime("01/06/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/07/2020"),
                Aktivan = false
            };

            var katalogStavka = new KatalogStavka
            {
                PopustProcent = 10,
                Proizvod = proizvod,
                AkcijskiKatalog = akcijskiKatalog
            };

            var log = new Log
            {
                Username="korisnik",
                IPAddress="ip adresa",
                AreaAccessed="area",
                Timestamp=DateTime.Now
            };

            _context.AddRange(vrstaProizvoda, proizvod, skladiste,
                proizvodSkladiste, boja, proizvodBoja, dostava, narudzba,
                narudzbaStavka, izlaz, izlazStavka, zaposlenik,
                autorizacijskiToken, recenzija, akcijskiKatalog, katalogStavka, log);
            _context.SaveChanges();

            _context.AkcijskiKatalog.Add(new AkcijskiKatalog
            {
                Opis = "august k.",
                DatumPocetka = Convert.ToDateTime("01/08/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/09/2020"),
                Aktivan = true
            });

            _context.KatalogStavka.Add(new KatalogStavka
            {
                AkcijskiKatalogId = 2,
                ProizvodId = 1,
                PopustProcent = 10
            });

            //_context.Uloga.Add(new Uloga { TipUloge="admin" });
            //_context.Uloga.Add(new Uloga { TipUloge="menadzer"});
            //_context.SaveChanges();
            _context.Korisnik.Add(new Korisnik
            {
                KorisnickoIme = "admin",
                Lozinka = "admin",
                Opstina = opstina,
                UlogaId = 1
            });

            _context.SaveChanges();

            _context.Zaposlenik.Add(new Zaposlenik
            {
                Ime = "admin",
                Prezime = "admin",
                Email = "...",
                Adresa = "...",
                Telefon = "-...",
                KorisnikId = 3
            });
            _context.SaveChanges();

            _context.VrstaProizvoda.Add(
                new VrstaProizvoda
                {
                    Naziv = "Komoda"
                }
                );
            _context.SaveChanges();

            _context.Proizvod.Add(
                new Proizvod
                {
                    Cijena = 300,
                    Naziv = "Pr2",
                    KorisnikId = 2,
                    Sifra = "456888",
                    Slika = "...",
                    VrstaProizvodaId = 2
                }
                );
            _context.SaveChanges();
        }

        [TestMethod]
        public void TestiranjeDbContexta_ProvjeraBrojauloga()
        {
            List<Uloga> ocekivana = _context.Uloga.ToList();
            List<Korisnik> ocekivaniK = _context.Korisnik.ToList();
            // Assert.AreEqual("kupac", ocekivana[0].TipUloge);
            //Assert.AreEqual("menadzer", ocekivana[1].TipUloge);
            //Assert.AreEqual("admin", ocekivana[2].TipUloge);
            Assert.AreEqual(2, ocekivaniK[1].Id);
            //Assert.AreEqual(1,_context.Zaposlenik.ToList().Count);
            //Assert.AreEqual("menadzer", _context.Zaposlenik.First().Ime);
            //Assert.AreEqual(3, ocekivaniK.Count);

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

        const string expectedTestString = "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";


        public static Dictionary<string, StringValues> cookieResponseHeaders
        {
            get
            {
                var respHeaders = new Dictionary<string, StringValues>();
                var cookieValue = JsonConvert.SerializeObject("logirani_korisnik = 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; expires = Sat, 02 Sep 2020 23:19:18 GMT; path =/ ");
                byte[] dummy = System.Text.Encoding.UTF8.GetBytes(cookieValue);
                string jsonString = Encoding.UTF32.GetString(dummy);


                //var strJsonDer =JsonConvert.DeserializeObject("logirani_korisnik = 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; expires = Sat, 02 Sep 2020 23:19:18 GMT; path =/ ");
                respHeaders.Add("logirani_korisnik", jsonString);
                return respHeaders;
            }
        }

        public static Dictionary<string, string> cookieRequestHeaderList
        {
            get
            {
                var cookieHeaders = new Dictionary<string, string>();
                var strJsonSer = JsonConvert.SerializeObject("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");
                cookieHeaders.Add("logirani_korisnik", strJsonSer.ToString());
                return cookieHeaders;
            }
        }
        Random random = new Random();
        private IHostingEnvironment hostingEnvironment;
        private Dictionary<object, object> httpContextItems = new Dictionary<object, object>();

        public IUrlHelper GetUrlHelper()
        {
            var urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock.Setup(m => m.Action(It.IsAny<UrlActionContext>()))
                .Returns<UrlActionContext>(u => u.Controller + "/" + u.Action);

            return urlHelperMock.Object;

        }

        public ITempDataDictionary GetTempDataForRedirect()
        {
            var tempData = new Mock<ITempDataDictionary>(MockBehavior.Strict);
            tempData
                .Setup(m => m.Keep())
                .Verifiable();

            var tempDataFactory = new Mock<ITempDataDictionaryFactory>(MockBehavior.Strict);
            tempDataFactory
                .Setup(f => f.GetTempData(It.IsAny<HttpContext>()))
                .Returns(tempData.Object);

            return tempData.Object;
        }


        // ProizvodiController pc = new ProizvodiController(_context);
        private HttpContext GetMockedHttpContext(Korisnik kor = null)
        {

            IConfiguration configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddEnvironmentVariables()
      .Build();

            //services
            var services = new ServiceCollection();
            //services.AddLogging();

            services.AddMvc().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.ContractResolver =
                        new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
            services.AddOptions();
            //services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSession();
            services.AddDbContext<MojContext>(options =>
              options.UseInMemoryDatabase(databaseName: "Test_Database"));


            var serviceProvider = services.BuildServiceProvider();

            var serviceProviderGetContext = new Mock<IServiceProvider>();
            serviceProviderGetContext.Setup(s => s.GetService(typeof(MojContext)))
            .Returns(_context);


            //httpContext i session
            var mockContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            Korisnik sessionUser = kor;//_context.Korisnik.First();// new Korisnik() { KorisnickoIme = "MyValue" };
            var sessionValue = JsonConvert.SerializeObject(sessionUser);
            byte[] dummy = System.Text.Encoding.UTF8.GetBytes(sessionValue);

            if (kor != null)
            {
                _context.AutorizacijskiToken.First().KorisnikId = kor.Id;
                _context.SaveChanges();
            }
            // mockContext.Setup(s => s.Session).Returns(mockSession.Object);
            mockContext.SetupGet(ctx => ctx.RequestServices).Returns(serviceProviderGetContext.Object);
            mockContext.SetupGet(c => c.Items).Returns(httpContextItems);

            var collection = Mock.Of<IFormCollection>();
            var mockDataProtector = new Mock<IDataProtector>();
            Mock<IDataProtectionProvider> mockDataProtectionProvider = new Mock<IDataProtectionProvider>();


            var request = new Mock<HttpRequest>();
            //           request.Setup(f => f.ReadFormAsync(CancellationToken.None)).Returns
            // ---->                            (Task.FromResult(collection));
            request.SetupGet(r => r.Cookies).Returns(new RequestCookieCollection(cookieRequestHeaderList));

            mockContext.SetupGet(c => c.Request).Returns(request.Object);

            var response = new Mock<HttpResponse>();
            response.SetupProperty(it => it.StatusCode);

            response.SetupGet(resp => resp.Cookies).Returns(new ResponseCookies(new HeaderDictionary(cookieResponseHeaders), null));
            response.SetupGet(resp => resp.Headers).Returns(new HeaderDictionary(cookieResponseHeaders));


            mockContext.Setup(c => c.Response).Returns(response.Object);

            mockDataProtector.Setup(sut => sut.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("CfDJ8GnPj9ak8t1HphXa8mMbIoKnqw4YPtXOXoKasvmnPEhKDWkKreGRYzObYb6nsYj6zcIIiyuqWMic_lfwLkYv-Y-II7heGvYx0ffMSSIVD7JKrsX9ML74Ju2vmFPnhTtifbnFQBrUbluhJ2Pn34v3anAXHdYRTh2YlyJhJ3oJDUru_6xO_7EM9UJdwxU9VJOf0NpChZypR9Aa64JQX4CLx8i4Sy04gzxsKKvSq0TACNlY1RuW8fodu23osFIsIdQ96G2vIYwOyueFUXA2tcLCurbtm2kQGgqviZZoBQNdfiwTjxw6dvW5f9MmJHz_XpbQCYiEU8kG15DkyWglvq006C6A9xcCGvi6Fi0_Ow1gVhwSdvHun7M9vpNF9BWojdpdOwTD2y9nSjg3adU1IRml-zZxPJ0LVICVQ0yZ1ZnbqWfMxSVueoeEGVYoIu4h_EqT-Y6YqmSx0-Z5yOjK5AJauARFoU-5ho6yCSUIg_sdbhkRecFM0oChqfCFvjPl_T2irTUk2EO94FrC7TGZ-vM7VPs2F4_J7Td2IyaZBvwyGFL6A_Xp8MGoOoAgWUgBL4t-o8JscOLgVrGyBffQtM92sg6bsqEnrxerO4sE1QTxDF_TpCD5sLKMtaF3NItukOfVt9DPaTV9THgue6LVJFasotqv6b9UOd_o2Tpa_ZB0LHxhdZNRHYRqF0HcyCohphsRIJ5hCP5Os7DIT8isyYks_ZXKEmFd7TKTREVouO3T1EPx0bDV_qFGBZrQu6V_uybf7gNk9Crnge2Ekj6ElXgPIviauc7edKVnPsTRzwDsOYN1NWgk-UGkKFjISCrE_UkaMn8F6-y2umgVJTebmap-MczZq6eilD9r_7aDSJyZBIZPY0QdGSJlLx3CYySTJ0fsoz3t5sUlt1cuAeWng6oiE_ij0wbUfriP8YE1mF8RB8hSQtVXC3KH8_ukP2ofEuehzvm_NTRx5yKls4nkfnzaUpfU3VYvVUIuLWnQY5xeCnN2xn1Qgklbfv_Xx32ZEKAGmm6HxKkqlrz8y-WFUdrYcI4ng2EJvvt0B2IUopCL_DPEAh4sXmEy0pM_YOtOV_mCH4eMupKAD0tqBuTFrYeb85vsNqe4SOKkYTID83KtVxZ0fCo6Z4Gd6kLHQ4TQRokVnkHa1c9VHrzZKI6oy23uGwAyVGlFxTK4lM6Xg2HBjo_AYrxg5H6Yb3Kb1M188hImXvW8q6H-C7LMwM966FGTv1kOYYCPFxL-4876UziUcAw7hQGAoxCRZQVOmd7-K8DtQSeI4ctRzaghduMlYAbqG5s5ZerhUF-1Jbo3d4RTOxXdeH9l8D7St2WfHn1aObitZ8tPxY90V4y5YmOQbC267W9QaQUT0pcw7es6SZDbrNmxp6ktzxn34qcAkINmBnMTJKohl7tXCs3mJsXc7mpEeeFjy4NXa8f3pKKQ_hv4Qkfl-gOgfnFTQe6tD9VAQMdUQbjh_R4NoKaRGnRQTHSWBn4dHFQSWwSyshHbvyq8rXB4eRbB1yb5WD4BdpWVNa2d2k2NU1jZy_FI4SZoKsO-H5gPl3j6xnvyk20swbBE2RdLG_SGEWUNMYUdJEOxgH7FC3amwh3-MGhxwJ6m0maGukIL_uAjbH7N_Yt7pf1c5WNWbfQEGkhw3KBIf_vrbr4USZt_0zGWvFM64IXvJl8D5JNvsuVlOrrihfv0TMjhcmFinYM40FSVg3R9qkGHK-kftfYCxK_hoOrxkETEcNZfcE9sgr5F2abXqDM_nhExF35brEt3jrNRJb5DTFV9DV7VidQfec8qjF-c6UTosoa6hgkK2LCeriZ7x3olFjkeUSW501bYDDEJjcphMA5nr1HKsuPt1C9OR3O5UhPwR_quYKQRnbqvPbfljKlBIy0rzVUVVEoZz58vpoDC96di-L-TRLUVPFlukY5k43P5mFLRkWiMZ3GFz88qdOKM_AtPdc-Vi4r77h-fdzvtW5sBiBQ54ViAqHW592XRVjQZHx6_UFyT9rqVgVgjSn_PAJ9Nqv-1S4V30DT4QmgYhLb_UW8oyB7q4dAXPiQWz26LRkPRR-93fl-XiIYTm0TMTv3yT8p51Sl4LaPmJwlPSszPgziEnZET1ypX3xMaJ8oIBEakk5uAnvdToHintIN6a3z6L7Aon0DlEvfrUOvf7cTXtDrfrJx-6NX7Bkj5W2R24_QFTR-rst6gXNQJzBCU9H5ml9m8WVapWX25g4oADScfg72FiTAHBLn2T1lC16YncicOLsyK2jxvXtJ716ECq6b3Lv6lvuHkB_vWQYSpRCsnJnmDjWebUao11WhpwaqgDiDyGAgQpsSWKdMch8hpSK9911LWIc29lXozwb73igIvekGKIZRER9ZdxFiEnF5SggQyChvWsLW-SSSyaKd5nvcLO4PCJTjDAlkym7FIZWpHtqGvr_wGLPq_oFQ6nsy1AWn8gg6fVd6Zn4hqvan8_FEwJz44UTXJoG6s_IJns4SbivRyNnyByfGPr8ytzDUQ0fcCmtEJABu9SNr575q9-YuZr-6qa5bzDMtt7PAqSvrcI7z2IWW8quKmf5wD_u74rCuVfQk8aLxqxBb-yoJx-OGhWMAHO1Sxl5wW_MKkYeJvwJjC9vOang1aq_Rcpb0xnPEz5uhjJIUiugFdpL34-mjNyA4dXRHsHiUuOOHTg2tYnyaLZ5Lm1wjmjxv1PT3ks2_d17QHjbBiquE1Bz3k2k0KMvrl9PFqrvrVxBdUq8AFYI-43XpAuJGu2QpxmFcTTz1d5MKgCdfX2hqX3wbg0ehUcEEGHkZE0kjOcnOr2MGb_U9rutEYy4nmUWSIEubrBVFSIJ1vXUua0j7-q9_Zc7per08akEGqCMxxzTXsWxgAAetFb-X-PKNC03SC3KhrFvZu7VlRJUetOb75Vfjhtpv9iSKRhvnlOSDmki5iAlP7jViQdZCeQGI3jSS4734dnRbB44J3WustkK5sj33o0U7gOWTuXtm2KqTDhjMPU5-FdxKKVVd9u4SF71PP2aNfiYv4V14kAB4IVV3qjINz3XUdPRsJK3C8XoNdwJeZTJvQGCIkw7wXNfTC5i634c7c98CT6X2I4d-q2s8HvjLRD9gvTEUE-E0A4GEMWhFwCqfhR0MfRmYKo-OJq6JGz6Z6QqolN4toTGjBJVUhVRMKTyg7g5fJcjYQPLp3gOLpsLd2z0silP1jH9NMI85eGf5_Pp7DSA_aGiwR6nfzgSerJWyCLHlUHK0_vLz0s0rB2u4xtsdttZ1JeIUqlHHcSokzxTLn3cAZ4QfjufMOiWNxcSUKRdt9fMCW4A7ncVEJpraLkJcfEYiE5XVPM_cYL0O6cZQdkJLo8PssIiVz7VWHM6nfnqVb2ILQf0ccuS4_O-HrPo4yMM_Tx5eYbVVXesYUEdQ8fRo34SqFT7i1p5h8kRJGU2xBSUzyKTQxZyzuXqoW5nSj9FMyrHp3hbawKVYbAcX7__GdZ7LjVWiMvRDjhLUpvzGUSBNLQ7OeAM1-ElGwXxyD_T_HWxykpl7q0m1F6hnU-j1Kg4zMFoPSSEYqlQxx_odRrvzhfq2EpiyUeT82V_PjkIVj42s3SEYOqTvLWwGZvTIvLsEzUX4vMoSjpWH3ZBNT-mVw7EY_QRxTe-rughjccvUtS3XBquMfNt7UGW7hWWYUeFmpbbdwy4gWaOH3NCuom-zoHE3XcNrTvamdNDnko-gxMDtd7b90Rbzd-MCXukS6qFqa4sePFY3drMmgD1uz-Rhti3MrtSjC9jiCu98vQKJulf06079XeJffMCcGIyk7GUD_jfFLVeJ4yK3chTz90o5PoS7lpxqbzTTWBoWZA9TcWspXmOTm2p5g49YOHHfDfYRyjXCDDJPnaxRBHYroZrwZP7NjsOQTU8XZCTmmZiRe9EMnGJJBo7B4vKKbM5zmj3czp9ydwOfQamSvM1_YdfVybsa1mpfzIXY_xMenGBvTxCQsZEshhAcoWzC1X1ZoMzilLGxgEct70uXzsuK90HZwbIyynme03hTK4l4vTH1qMjBNti-VnhxiHWKf1zAjRj7g-islGDRgf9mos5wzJ0_FRobCEISuhhKSk3KqNCd4rCAyoJOz_yw8aISP_DzHmCzESdV7ykuOtqjAfkODDL29RyMEpR81Q_ihoD-kIor8xi4pNevAmqpr6EMYN4sweiH6SsZSeh5fCDU5MMRIxipw5w-_9bU6A9XBwYTe5AbCBfcauiCnGzS7ZP0Uxyg7euT2652U6QvcTn2lhHlovL7FCMs19nIXsTBkgNVdHlH7rm_Mi1VAW_lqBBI7rVV0juKITvZIeUrkjfVOhh0ZdeX0dVjp_WPU2BimWiZk_rWG98JSI3zrJFAyJBTj2jIefzueE6kSkQuc3O9uUZWfptLkmmRcKTwQ8piTdQagWxIZ_pNOJo5cLkeLncbA2nbQfuwdNFhprNs65MYa3Q8tZby9sAvbqeY3o3t1Q9ZOF0TNE509kpceZyaWU35eulK8mA3VcGyTGBcNxtCih8T0d1RNzUzlaqpgrsPZEeLJuS6XBr1TPeLMOKGI4a2gdsLKAU7Ce1rAQ-BBcYv_RS_YsFL_FyHSr0QTzE301-TPaowcJQQb7bTDaFgFc9bttDVpOUgm6Zh20-91af2HIw2H-BVjn0Y7uBwFEADo9nIU2cCtWelvvMzGqReBWXRsr2pftwJtbrZozMf2eSniyUzXXd7zYQaSc-WkiejeIA9quvKvaybK2RVldCqP_TF8SaBpDrmboaxFGaSwdsc6L5_apwLkv3MxTx113J1NqqCinYKxjWsNV6wJ2NLiJdEzBkblwNSwSwf2JVfzGvcSEEfHxdNhXvPs7u3iqe1U2hDCyD82GismNhWsdd8k5WtvJ45rlrq7F2ERCe33lqjIp7PwXjhWpfA6WI9OM5Yhnak5Kv-lWQMVnwnrQnOn7vfnw5DwItGgAKFtdHyYSzl0bRB_t4Rb4K8TdVI3vfaT6aPemrHb7IHGQhFlRBceFDQ06nJU9lvmz0lKhXs-oi7EsWSe2KGFHIU76FEiTQEfQmDIaj1tdXqrDlBBVLpi9W9PWtQfQjkGQEmLriln5MRrmwD7BAqw__oiCpkebgONRp1pNvS-TebsmzXgrlrVXHCiKJuLuD_dN5Lkr8m5XSRomqj-yBzVlCHtZTEkDhRiZ7hzcHTE58eJrForozyMMzkgo4ri9M4gWOx8EzE54XmhtRvQu1IzL_O3yBDQyArjqS6xUcv_TVlc9gWsCr3I2S0A7C7EGe2J8195Y363AT-g7tix4CxKGseEHY8SMrtSgngE00wiqsru7R2XMW4QjAZ13ZBOTlqf_qb2DADXKNVl7hFlc27GyQCSihriKJY5P-xizFuq-OStOrKT7VqypP5_hE8uOU0v22k6tzanU7xdeDF8s8S9rw6tKdea038jbr72J94V9KRXwHwoP8zsfw3mbSPMxrkEC0D-7UmkjQMcOYHaWn40cwtUX7B6gRU93AQy7sa8rOdoNHbrNbuuSUmwIMwQn0TEBG6ZDGesIn7yKeBopUip-MAzh3PrHQ8hYZ32hQGI3W76pJf5t42PmMKbtz858MNY3TsNJUNwX8YOb5CAsreUjIw4dRqgp1uhmjbE-VyXrIuI9qu8pju2e_BpwobJBQYXZvnbus3H7Bj2VPlsWNdTPQqk7HEl3qtvhacGo78ofgWjJswW4JOboLJQFbNxomn3rYH3oVbZRg1XJMcFBYzbXjRV89GV9IDNEOHtzx28nK4_gC_KzJCKi1URk6MTrwFl6NLCk64x1j_ZnBOwvne1yN-zjkcAoxBywSTbuheHQ_Mp79kxg9p5_GJMmexv_1FhNauTNdEbaKDuKq2CdNTPt5Z43J37hpzpKv-KftrlhHGj-dS4uZu7phTPKKhkCR_dUvWWy2RC6PVTj1hV8BA8K0y1q2VWWK2xf_XmbzG-VrSRb0wym28NadhCYTcB9uysnH3BhTirtR8Pqqy_kDaw6cURMVVedlEeWgdt-Hs2YhYEXy_q3FdM7LWPgl6HbDigIf2_Xw6JWjqeNTVCMaHrVOoEJax0rbXrqOm8LIB-UBshSrp6ximv0ARLED5jXHDGJgjhojYvWgvPGnUz-Ch8vhwYlwHO4j4kUJBcQqeQXztbqiXJc2KB9ftXDteLmd04tV7w-x_h21glp51p1rfasvarmurE8DNVJ4LlR4JFognzv7tunVwmMg0y8utKGukD9aa7NfZ-3W6srBbnfUcrFWH8Gn76WDq03EXwuRMJngcAh-ivLvjB-0_66O-lVJKLS1A-6yLj3XQc_0zNlZW4jcn_7KLePoZH3Yax6Kli5_BaJBtURK9F-Ot5jHibQub4-xnigiBMjyrLp8vG73bJ5RosfaCZ5qoCkN-PDg9bhSEwTjhPCVqNOC4Bt5OoymN6qzsvHwmI1Fj2h3HsuYxEEnbdQHcIsHGz5NBFHqNehh6pW2jhMm7gIJ2sBLWUxZzzWkO88uC3DqRUDTX8pmH0-bF1MrBYl8V382ADaPiG9Tox-elSPwe1HLDsPNAJzvQXlDHHLf9_MP8F_6AsOENr9wA4xtuHF4WcBMNAZzpHVZUomc1yk5wHiEIotBOQxcTYOEh9vigLXdrMeLRC3nJwTfjj9XG855HTgcAtUJv9A9CKCHu2lkKoCRefyrCixa36Ch9YJ113Fwjmtz9p1sQseflENtYOhj1_FPZVUl7U-yNWAI30fazh40TDGj9qca3KlLiPfAosGTuouzU0h-PmihTfJImDlCbC6BobgA"));
            mockDataProtector.Setup(sut => sut.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes(expectedTestString));

            mockDataProtectionProvider.Setup(s => s.CreateProtector(It.IsAny<string>())).Returns(mockDataProtector.Object);

            return mockContext.Object;



        }

        public void GetServicesTest()
        {
            var services = new ServiceCollection();

        }

        [TestMethod]
        public void Test_HomeController_Index_SendingNullUser_RedirectsToModulKupacProizvodiIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };
            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulKupac/Proizvodi/Index", redirectResult.Url);
        }

        [TestMethod]
        public void Test_HomeController_SendingUserKupac_RedirectsToAModulKupacProizvodiindex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 1).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };
            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulKupac/Proizvodi/Index", redirectResult.Url);

        }

        [TestMethod]
        public void Test_HomeController_SendingUserMenadzer_RedirectsToAModulMenadzerProizvodiMenadzerIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 2).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };

            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulMenadzer/ProizvodiMenadzer/Index", redirectResult.Url);

        }

        [TestMethod]
        public void Test_HomeController_SendingUserAdmin_RedirectsToAModulAdmiKorisniciIndexIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 3).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };

            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulAdministrator/Korisnici/Index", redirectResult.Url);

        }






        [TestMethod]
        public void Test_Autentifikacija_Index_REturnsView()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            ViewResult result = ac.Index() as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual(true, model.ZapamtiPassword);

        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateNotValid_returnsViewDataMessage()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.ModelState.AddModelError("username", "Required");
            ac.ModelState.AddModelError("password", "Required");
            var result = ac.Login(new LoginVM()) as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual("Niste unijeli ispravne podatke", result.ViewData["poruka"]);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNull(model.username);
            Assert.IsNull(model.password);
        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateValid_UserNull_returnsViewDataMessage()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            LoginVM novi = new LoginVM
            {
                username = "mmm",
                password = "mmm"
            };
            var result = ac.Login(novi) as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual("Pogrešan username ili password", result.ViewData["poruka"]);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(novi, model);
        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateValid_UserIspravan_redirectsToIndexProizvodi()
        {
            Mock<AutorizacijskiToken> _someDataRepositoryMock = new Mock<AutorizacijskiToken>();

            var mockSet = new Mock<DbSet<AutorizacijskiToken>>();
            var list = new List<AutorizacijskiToken>();
            var queryable = list.AsQueryable();
            mockSet.As<IQueryable<AutorizacijskiToken>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<AutorizacijskiToken>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<AutorizacijskiToken>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<AutorizacijskiToken>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());


            //var urlHelperMock = new Mock<IUrlHelper>();
            //urlHelperMock.Setup(m => m.Action(It.IsAny<UrlActionContext>()))
            //    .Returns<UrlActionContext>(u => u.Controller + "/" + u.Action);

            //var mockDeclaredProductSet = new Mock<DbSet<AutorizacijskiToken>>();
            //var mockContext = new Mock<MojContext>();
            //mockContext.Setup(c => c.AutorizacijskiToken).Returns(() => mockSet.Object);   // (*)

            AutentifikacijaController ac = new AutentifikacijaController(_context);

            //var mockContext = new Mock<HttpContext>();
            //var mockSession = new Mock<ISession>();
            //Korisnik sessionUser = null;
            //var sessionValue = JsonConvert.SerializeObject(sessionUser);
            //byte[] dummy = System.Text.Encoding.UTF8.GetBytes(sessionValue);
            //mockSession.Setup(x => x.TryGetValue(It.IsAny<string>(), out dummy)).Returns(true); //the out dummy does the trick
            //mockContext.Setup(s => s.Session).Returns(mockSession.Object);

            ac.Url = GetUrlHelper();
            ac.ControllerContext = new ControllerContext
            {

                HttpContext = GetMockedHttpContext()
            };



            LoginVM novi = new LoginVM
            {
                username = "johndoe",
                password = "..."
            };
            var result = (RedirectToActionResult)ac.Login(novi);

            //Assert.AreEqual("johndoe", ac.ControllerContext.HttpContext.GetLogiraniKorisnik().KorisnickoIme);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Proizvodi", result.ControllerName);
        }

        [TestMethod]
        public void Test_Autentifikacija_Logout__redirectsToIndex()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);


            ac.ControllerContext = new ControllerContext
            { HttpContext = GetMockedHttpContext() };


            var result = (RedirectToActionResult)ac.Logout();

            // var kor = ac.ControllerContext.HttpContext.GetLogiraniKorisnik();
            // Assert.IsNull(ac.ControllerContext.HttpContext.GetLogiraniKorisnik());
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 1)]
        public void Test_Proizvod_Index_ListaProizvoda(int? vrstaID, int? bojaID)
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
        [DataRow(1, 1)]
        public void Test_Proizvodi_ActionDetalji_VracaDetaljeProizvodaNaspramIDargumenta(int id, int brojac)
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
            pc.ModelState.AddModelError("kol", "Required");

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
            var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110, bojaID, brojac, null);
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
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
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
            // GetMockedHttpContext();
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

            ProizvodiDodajVM newPr = new ProizvodiDodajVM
            {
                Naziv = "...",
                Sifra = "...",
                Cijena = "...",
                VrstaID = 1,
                BojeID = { },
                Slika = "",
                UploadPic = null
            };

            var result = (RedirectToActionResult)pmc.UploadProduct(newPr);

            Assert.AreEqual("Dodaj", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateValid_AfterAddedProductRedirectsToIndexProizvodi()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext()
            };

            //var serviceProviderMock = new Mock<IServiceProvider>();


            //erviceProviderMock.Setup(serviceProvider => serviceProvider.GetService(typeof(MojContext)));
            //  pmc.ControllerContext.HttpContext.RequestServices = serviceProviderMock.Object;

            //var services = new ServiceCollection();
            //pmc.ControllerContext.HttpContext.RequestServices =services.BuildServiceProvider();


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

            int[] temp = { 1, 2 };
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

        [TestMethod]
        [DataRow(1)]
        public void Test_ProizvodiMenadzer_EditAction_CheckIfItReturnsCorrectView(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);

            ViewResult vr = pmc.Uredi(id) as ViewResult;

            ProizvodiUrediVM aktuelniP = vr.Model as ProizvodiUrediVM;

            Assert.AreEqual("NazivPr", aktuelniP.Naziv);


        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_EditProductSave_ModelStateValid_RedirectsToActionIdex_ControllerProizvodi()
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

            int[] temp = { 1, 2 };
            ProizvodiUrediVM newPr = new ProizvodiUrediVM
            {
                ProizvodId = 1,
                Naziv = "Proizvod123",
                Sifra = "11111",
                Cijena = "111.11",
                VrstaID = 1,
                BojeID = temp,
                Slika = "defaultString",
                UploadPic = file
            };

            var result = (RedirectToActionResult)pmc.EditProductSave(newPr);

            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            Assert.AreEqual("Proizvodi", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
                                                                // Assert.AreEqual(3, _context.Proizvod.Count); 
        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_Index_VrstaNull_VracaSveProizvode()
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            pmc.TempData = GetTempDataForRedirect();



            var result = pmc.Index(null) as ViewResult;
            ProizvodiIndexMenadzerVM model = result.Model as ProizvodiIndexMenadzerVM;


            Assert.AreEqual(2, model.Proizvodi.Count);

        }

        [TestMethod]
        [DataRow(2)]
        public void Test_ProizvodiMenadzer_Index_Vrsta2_VracaProizvodteVrste(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            pmc.TempData = GetTempDataForRedirect();


            var result = pmc.Index(id) as ViewResult;
            ProizvodiIndexMenadzerVM model = result.Model as ProizvodiIndexMenadzerVM;


            Assert.AreEqual(1, model.Proizvodi.Count);
            Assert.AreEqual("456888", model.Proizvodi[0].Sifra);
            Assert.AreEqual(2, model.Proizvodi[0].Id);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_EditProductSave_ModelStateNotValid_ReturnsBadRequest()
        {

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


            var result = pmc.EditProductSave(new ProizvodiUrediVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        [DataRow(2)]
        public void Test_ProizvodiMenadzer_Obrisi(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.Url = GetUrlHelper();

            var result = pmc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual(1, _context.Proizvod.ToList().Count);
            Assert.AreEqual("Index", result.ActionName);

        }


        [TestMethod]
        public void Test_NarudzbaStavke_IndexAkcijaNotNull_CheckIfITreturnsCorrectModel()
        {
            GetMockedHttpContext();
            NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);
            ns.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };


            _context.Narudzba.First().Aktivna = true;
            _context.SaveChanges();


            ViewResult result = ns.Index() as ViewResult;
            NarudzbaStavkeIndexVM model = result.Model as NarudzbaStavkeIndexVM;
            Assert.AreEqual(1, model.proizvodiNarudzbe.Count);

        }

        [TestMethod]
        public void Test_NarudzbaStavke_IndexAkcija_ReturnsNullInView()
        {
            GetMockedHttpContext();
            NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);
            ns.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };


            ViewResult result = ns.Index() as ViewResult;
            Assert.IsNull(result.Model);

        }

        [TestMethod]
        [DataRow(1, 1)]
        public void Test_NarudzbaStavke_ObrisiAkcija_RedirectsToIndex(int id, int narudzbaId)
        {
            GetMockedHttpContext();
            NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);

            var result = (RedirectToActionResult)ns.Obrisi(id, narudzbaId);

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("NarudzbaStavke", result.ControllerName);
            Assert.AreEqual(0, _context.Narudzba.ToList().Count);
        }



        [TestMethod]
        [DataRow(1, "100")]
        public void Test_Dostava_IndexAkcija_ProvjeraDaLiProsljedjujeIspravanModelNaView(int narudzbaId, string total)
        {
            DostavaController dc = new DostavaController(_context);
            ViewResult result = dc.Index(narudzbaId, total) as ViewResult;
            DostavaIndexVM model = result.Model as DostavaIndexVM;

            Assert.AreEqual(1, model.Dostave.Count);
        }



        [TestMethod]
        [DataRow(1, 0, "100")]
        public void Test_Narudzbe_ZakljuciAkcija_ModelStateNotValid(int narudzbaId, int dostava, string total)
        {
            NarudzbeController nc = new NarudzbeController(_context);
            nc.ModelState.AddModelError("dostava", "Required");


            var result = (RedirectToActionResult)nc.Zakljuci(narudzbaId, dostava, total);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("NarudzbaStavke", result.ControllerName);
        }

        [TestMethod]
        [DataRow(1, 0, "100")]
        public void Test_Narudzbe_ZakljuciAkcija_ModelStateValid_ReturnsPartialView(int narudzbaId, int dostava, string total)
        {
            NarudzbeController nc = new NarudzbeController(_context);

            PartialViewResult result = nc.Zakljuci(narudzbaId, dostava, total) as PartialViewResult;
            Assert.AreEqual("Zakljuci", result.ViewName);
        }

        [TestMethod]
        public void Test_Narudzbe_IndexAkcija_CheckIfItReturnsValidModel()
        {
            //GetMockedHttpContext();
            NarudzbeController nc = new NarudzbeController(_context);
            nc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            ViewResult result = nc.Index() as ViewResult;
            NarudzbeIndexVM model = result.Model as NarudzbeIndexVM;

            Assert.AreEqual(1, model.Narudzbe.Count);

        }

        [TestMethod]
        public void Test_Narudzbe_IndexAkcija_CheckIfItReturnsNull()
        {
            //GetMockedHttpContext();
            NarudzbeController nc = new NarudzbeController(_context);
            nc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            _context.Narudzba.First().Aktivna = true;
            _context.SaveChanges();

            ViewResult result = nc.Index() as ViewResult;

            Assert.IsNull(result.Model);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_DetaljiAkcija_CheckIfItReturnsPartialView(int id)
        {
            NarudzbeController nc = new NarudzbeController(_context);
            var result = nc.Detalji(id);


            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_DetaljiAkcija_CheckIfItReturnsCorrectModel(int id)
        {
            NarudzbeController nc = new NarudzbeController(_context);
            PartialViewResult result = nc.Detalji(id) as PartialViewResult;
            NarudzbeDetaljiVM model = result.Model as NarudzbeDetaljiVM;



            Assert.AreEqual(1, model.DetaljiNarudzbe.Count); ;
        }

        [TestMethod]
        public void Test_Sesija_Index_VracaKorektanModel()
        {
            List<AutorizacijskiToken> sesijeOcekivane = _context.AutorizacijskiToken.ToList();
            SesijaController sc = new SesijaController(_context);
            sc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };

            sc.TempData = GetTempDataForRedirect();

            var result = sc.Index() as ViewResult;


            SesijaIndexVM vraceneSesije = result.Model as SesijaIndexVM;

            Assert.AreEqual(sesijeOcekivane[0].Vrijednost, vraceneSesije.Rows[0].token);

        }

        [TestMethod]
        public void Test_Sesija_Obrisi_redirectsToIndex()
        {
            SesijaController sc = new SesijaController(_context);
            sc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };
            sc.Url = GetUrlHelper();

            sc.Obrisi(expectedTestString);

            Assert.AreEqual(0, _context.AutorizacijskiToken.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Recenzije_Index_VracaListuRecenzija(int id)
        {
            RecenzijeController rc = new RecenzijeController(_context);

            rc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };
            rc.Url = GetUrlHelper();
            rc.TempData = GetTempDataForRedirect();

            PartialViewResult result = rc.Index(id) as PartialViewResult;
            RecenzijeIndexVM model = result.Model as RecenzijeIndexVM;

            Assert.AreEqual(1, model.Recenzijes.Count);
            Assert.AreEqual(3, model.Recenzijes[0].Ocjena);
            Assert.AreEqual("..", model.Recenzijes[0].Sadrzaj);


        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Recenzije_Dodaj_VracaViewDodaj(int id)
        {
            RecenzijeController rc = new RecenzijeController(_context);

            rc.Url = GetUrlHelper();
            rc.TempData = GetTempDataForRedirect();

            PartialViewResult result = rc.Dodaj(id) as PartialViewResult;
            RecenzijeDodajVM model = result.Model as RecenzijeDodajVM;

            Assert.AreEqual(1, model.ProizvodId);


        }



        [TestMethod]
        [DataRow(1)]
        public void Test_Recenzije_Snimi_RedirectsToIndexrecenzije(int id)
        {
            RecenzijeController rc = new RecenzijeController(_context);

            rc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };
            rc.Url = GetUrlHelper();
            RecenzijeDodajVM model = new RecenzijeDodajVM
            {
                ProizvodId = id,
                Sadrzaj = "..",
                Ocjena = 3
            };
            RedirectToActionResult result = rc.Snimi(model) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Recenzije", result.ControllerName);


        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Recenzije_Snimi_ReturnsBadRequest(int id)
        {
            RecenzijeController rc = new RecenzijeController(_context);

            rc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };
            rc.Url = GetUrlHelper();

            rc.ModelState.AddModelError("Sadrzaj", "Required");


            var result = rc.Snimi(new RecenzijeDodajVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));



        }

        [TestMethod]
        public void Test_Naruudzbe_NaCekanju_VracaNullModel()
        {
            NarudzbeController nc = new NarudzbeController(_context);
            nc.TempData = GetTempDataForRedirect();
            nc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };

            ViewResult result = nc.NaCekanjuIndex() as ViewResult;
            NaCekanjuIndexVM model = result.Model as NaCekanjuIndexVM;

            Assert.AreEqual(null, model);
        }

        [TestMethod]
        public void Test_Naruudzbe_NaCekanju_VracaIspravanModel()
        {
            NarudzbeController nc = new NarudzbeController(_context);
            nc.TempData = GetTempDataForRedirect();
            nc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };
            _context.Narudzba.First().NaCekanju = true;
            _context.SaveChanges();

            ViewResult result = nc.NaCekanjuIndex() as ViewResult;
            NaCekanjuIndexVM model = result.Model as NaCekanjuIndexVM;

            Assert.AreEqual(1, model.Narudzbe.Count);
            Assert.AreEqual(1, model.Narudzbe[0].NarudzbaId);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Nardzbe_Nacekanjuu_Otkazi(int id)
        {
            NarudzbeController nc = new NarudzbeController(_context);
            nc.Url = GetUrlHelper();
            nc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
            };

            var result = nc.OtkaziNarudzbu(id) as RedirectToActionResult;

            Assert.AreEqual(true, _context.Narudzba.First().Otkazano);
            Assert.AreEqual(false, _context.Narudzba.First().NaCekanju);
            Assert.AreEqual("NaCekanjuIndex", result.ActionName);
            Assert.AreEqual("Narudzbe", result.ControllerName);
        }

        [TestMethod]
        public void Test_AkcijskiKatalogMenadzer_Index_VracaListuKataloga()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.TempData = GetTempDataForRedirect();

            ViewResult result = ac.Index() as ViewResult;
            AkcijskiKatalogIndexVM model = result.Model as AkcijskiKatalogIndexVM;

            Assert.AreEqual(2, model.Katalozi.Count);

        }

        [TestMethod]
        public void Test_AkcijskiKatalog_Dodaj_ReturnsPartialView()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.TempData = GetTempDataForRedirect();

            PartialViewResult result = ac.Dodaj() as PartialViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_AkcijskiKatalog_Obriši_RedirectToIndex(int id)
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();

            RedirectToActionResult result = ac.Obrisi(id) as RedirectToActionResult;
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Test_AkcijskiKatalog_SnimiModelStateNotValid_ReturnsBadreq()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();
            ac.ModelState.AddModelError("Opis", "Required");
            ac.ModelState.AddModelError("DatumPocetka", "Required");
            ac.ModelState.AddModelError("DatumZavrsetka", "Required");

            var result = ac.Snimi(new AkcijskiKatalogDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_AkcijskiKatalog_SnimiModelStateValid_RedirectTOIndex()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();

            AkcijskiKatalogDodajVM model = new AkcijskiKatalogDodajVM
            {
                Opis = "...",
                DatumPocetka = Convert.ToDateTime("01/01/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/02/2020")
            };

            var result = ac.Snimi(model) as RedirectToActionResult;
            Assert.AreEqual(model.Opis, _context.AkcijskiKatalog.Last().Opis);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("AkcijskiKatalog", result.ControllerName);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_AkcijskikatalogStavke_Index(int id)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();

            PartialViewResult result = asc.Index(id) as PartialViewResult;
            AkcijskiKatalogStavkeIndexVM model = result.Model as AkcijskiKatalogStavkeIndexVM;

            Assert.AreEqual(1, model.KatalogId);
            Assert.AreEqual(1, model.KatalogProizvodi.Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_akcijskiKatalogStavke_Dodaj_VracaPartialview(int id)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();

            PartialViewResult result = asc.Dodaj(id) as PartialViewResult;
            AkcijskiKatalogStavkeDodajVM model = result.Model as AkcijskiKatalogStavkeDodajVM;

            Assert.AreEqual(1, model.Proizvodi.Count);
            Assert.AreEqual(id, model.KatalogID);
        }

        [TestMethod]
        public void Test_AkcijskiKatalogStavke_SnimiSlanjeNullVracaPartialviewIndex()
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();
            asc.ModelState.AddModelError("ProizvodID", "Required");
            asc.ModelState.AddModelError("Procenat", "Required");

            AkcijskiKatalogStavkeDodajVM par = new AkcijskiKatalogStavkeDodajVM
            {
                KatalogID = 1
            };

            PartialViewResult result = asc.Snimi(par) as PartialViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Test_AkcijskiKatalogStavke_SnimiSlanjeIspravnogModelaVracaPartialviewIndex()
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();
            AkcijskiKatalogStavkeDodajVM ocekivani = new AkcijskiKatalogStavkeDodajVM
            {
                KatalogID = 1,
                Procenat = 10,
                ProizvodID = 1
            };

            PartialViewResult result = asc.Snimi(ocekivani) as PartialViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        [DataRow(1, 1)]
        public void Test_AkcijskiKatalogStavke_Obrisi_SlanjeStavkaIKatalogID_RedirectToIndex(int katalogID, int stavkaID)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.Url = GetUrlHelper();

            var result = asc.Obrisi(katalogID, stavkaID) as RedirectToActionResult;
            Assert.AreEqual(0, _context.KatalogStavka.ToList().Count);
            Assert.AreEqual("Index", result.ActionName);

        }

        [TestMethod]
        public void Test_AkcijskiKatalogKupacIndex_returnsNullInView()
        {
            AkcijskiKatalogKupacController akkc = new AkcijskiKatalogKupacController(_context);
            akkc.TempData = GetTempDataForRedirect();

            _context.AkcijskiKatalog.Find(2).Aktivan = false;
            _context.SaveChanges();
            ViewResult result = akkc.Index() as ViewResult;

            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void Test_AkcijskiKatalogKupacIndex_returnsStavkeAktivnogAkcijskogKatalogaInView()
        {
            AkcijskiKatalogKupacController akkc = new AkcijskiKatalogKupacController(_context);
            akkc.TempData = GetTempDataForRedirect();

            ViewResult result = akkc.Index() as ViewResult;
            AkcijskiKatalogKupacIndexVM ocekivani = result.Model as AkcijskiKatalogKupacIndexVM;

            Assert.AreEqual("august k.", ocekivani.NazivKataloga);
            Assert.AreEqual(1, ocekivani.Proizvodi.Count);
        }

        [TestMethod]
        public void Test_Profil_Index_VracaPodatkeOKupcu()
        {
            ProfilController pc = new ProfilController(_context);
            pc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.First())
            };
            pc.TempData = GetTempDataForRedirect();

            ViewResult result = pc.Index() as ViewResult;
            ProfilIndexVM model = result.Model as ProfilIndexVM;

            Assert.AreEqual("kupac", model.Ime);
            Assert.AreEqual("johndoe", model.KorisnickoIme);
        }

        [TestMethod]
        public void Test_Profil_Uredi_VracaIspravanModel()
        {
            ProfilController pc = new ProfilController(_context);
            pc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.First())
            };
            pc.TempData = GetTempDataForRedirect();

            ViewResult result = pc.Uredi() as ViewResult;
            ProfilUrediVM model = result.Model as ProfilUrediVM;

            Assert.AreEqual("kupac", model.Ime);
            Assert.AreEqual("johndoe", model.KorisnickoIme);
        }

        [TestMethod]
        public void Test_Profil_Snimi_SlanjeNullModela_VracaBadReq()
        {
            ProfilController pc = new ProfilController(_context);
            pc.ModelState.AddModelError("KorisnickoIme", "Required");
            pc.ModelState.AddModelError("Lozinka", "Required");
            pc.ModelState.AddModelError("PotvrdaLozinke", "Required");
            pc.ModelState.AddModelError("Ime", "Required");
            pc.ModelState.AddModelError("Prezime", "Required");
            pc.ModelState.AddModelError("Email", "Required");
            pc.ModelState.AddModelError("Adresa", "Required");
            pc.ModelState.AddModelError("OpstinaID", "Required");



            var result = pc.Snimi(new ProfilUrediVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Profil_Snimi_SlanjeIspravnogModela_RedirectsTOIndex()
        {
            ProfilController pc = new ProfilController(_context);
            pc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.First())
            };
            pc.Url = GetUrlHelper();

            ProfilUrediVM model = new ProfilUrediVM
            {
                KorisnickoIme = "user",
                Lozinka = "user",
                OpstinaID = 1,
                Email = "user_mail",
                Adresa = "user_Adr",
            };

            var result = pc.Snimi(model) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("user", _context.Korisnik.First().KorisnickoIme);
            Assert.AreEqual("user_mail", _context.Kupac.First().Email);

        }

        [TestMethod]
        public void Test_Registracija_Index_VracaListuOpstina()
        {
            RegistracijaController rc = new RegistracijaController(_context);
            rc.TempData = GetTempDataForRedirect();

            ViewResult result = rc.Index() as ViewResult;
            RegistracijaIndexVM model = result.Model as RegistracijaIndexVM;

            Assert.AreEqual(1, model.Opstine.Count);
        }

        [TestMethod]
        public void Test_Registracija_Snimi_SlanjeNullVrijednosti_VracaBadReq()
        {
            RegistracijaController rc = new RegistracijaController(_context);
            rc.ModelState.AddModelError("KorisnickoIme", "Required");
            rc.ModelState.AddModelError("Lozinka", "Required");
            rc.ModelState.AddModelError("PotvrdaLozinke", "Required");
            rc.ModelState.AddModelError("Ime", "Required");
            rc.ModelState.AddModelError("Prezime", "Required");
            rc.ModelState.AddModelError("Email", "Required");
            rc.ModelState.AddModelError("Adresa", "Required");
            rc.ModelState.AddModelError("Spol", "Required");
            rc.ModelState.AddModelError("OpstinaID", "Required");

            var result = rc.Snimi(new RegistracijaIndexVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Registracija_Snimi_SlanjeIspravneVrijednosti_RedirectToPrikazPoruke()
        {
            RegistracijaController rc = new RegistracijaController(_context);
            rc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };
            rc.Url = GetUrlHelper();

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                KorisnickoIme = "neki",
                Lozinka = "neki",
                PotvrdaLozinke = "neki",
                Ime = "neki",
                Prezime = "neki",
                Email = "neki",
                Adresa = "neki",
                Spol = "M",
                OpstinaID = 1
            };

            RedirectToActionResult result = rc.Snimi(model) as RedirectToActionResult;

            Assert.AreEqual("PrikazPoruke", result.ActionName);
            Assert.AreEqual("neki", _context.Korisnik.Last().KorisnickoIme);
            Assert.AreEqual("neki", _context.Kupac.Last().Email);

        }

        [TestMethod]
        public void Test_Registracija_PrikazPoruke_NotNull()
        {
            RegistracijaController rc = new RegistracijaController(_context);
            Assert.IsNotNull(rc.PrikazPoruke());
        }

        [TestMethod]
        public void Test_Admin_Korisnici_Index()
        {
            KorisniciController kc = new KorisniciController(_context);

            Assert.IsNotNull(kc.Index());
        }

        [TestMethod]
        public void Test_Admin_Korisnici_IndexKupci_VracaListuKupaca()
        {
            KorisniciController kc = new KorisniciController(_context);
            kc.TempData = GetTempDataForRedirect();

            ViewResult result = kc.IndexKupci() as ViewResult;
            KupciIndexVM model = result.Model as KupciIndexVM;

            Assert.AreEqual(1,model.Kupci.Count);
        }

        [TestMethod]
        public void Test_Admin_Korisnici_IndexZaposlenici_VracaListuZaposlenika()
        {
            KorisniciController kc = new KorisniciController(_context);
            kc.TempData = GetTempDataForRedirect();

            ViewResult result = kc.IndexZaposlenici() as ViewResult;
            ZaposleniciIndexVM model = result.Model as ZaposleniciIndexVM;

            Assert.AreEqual(2, model.Zaposlenici.Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Zaposlenici_Obrisi_RedirectTOIndexZaposlenici(int id)
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            var result = zc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual("IndexZaposlenici", result.ActionName);
            Assert.AreEqual("Korisnici", result.ControllerName);
            Assert.AreEqual(1, _context.Zaposlenik.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Zaposlenici_Uredi_SaljeSeIDZaposlenika_VracaDatogZaposlenika(int id)
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();
            
            PartialViewResult result = zc.Uredi(id) as PartialViewResult;
            ZaposleniciUrediVM aktualni = result.Model as ZaposleniciUrediVM;

            Assert.AreEqual("menadzer",aktualni.Ime);
            Assert.AreEqual(2, aktualni.UlogaID);
            Assert.AreEqual("zaposlenik",aktualni.KorisnickoIme);

        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Snimi_ModelStateNotValidReturnsBadReq()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.ModelState.AddModelError("KorisnickoIme", "Required");
            zc.ModelState.AddModelError("UlogaID", "Required");

            var result = zc.Snimi(new ZaposleniciUrediVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Snimi_ModelStateValidRedirectTOIndexZaposlenici()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            ZaposleniciUrediVM model = new ZaposleniciUrediVM
            {
                ZaposlenikId=1,
                Ime="Zapo",
                Prezime="zapo",
                KorisnickoIme="zapo",
                UlogaID=1
            };

            var result = zc.Snimi(model) as RedirectToActionResult;
            Assert.AreEqual("IndexZaposlenici", result.ActionName);
            Assert.AreEqual("Korisnici", result.ControllerName);
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Dodaj_VracaListuOpstinaIUloga()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();

            PartialViewResult result = zc.Dodaj() as PartialViewResult;
            ZaposleniciDodajVM model = result.Model as ZaposleniciDodajVM;

            Assert.AreEqual(1, model.Opstine.Count);
            Assert.AreEqual(5, model.Uloge.Count);
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_SnimiNovogZaposlenika_ModelStateNotValid_REturnBadReq()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.ModelState.AddModelError("KorisnickoIme", "Required");
            zc.ModelState.AddModelError("Lozinka", "Required");
            zc.ModelState.AddModelError("PotvrdaLozinke", "Required");
            zc.ModelState.AddModelError("Ime", "Required");
            zc.ModelState.AddModelError("Prezime", "Required");
            zc.ModelState.AddModelError("Email", "Required");
            zc.ModelState.AddModelError("Adresa", "Required");
            zc.ModelState.AddModelError("UlogaId", "Required");
            zc.ModelState.AddModelError("OpstinaId", "Required");

            var result = zc.SpremiNovogZaposlenika(new ZaposleniciDodajVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_SpremiNovog_ModelStateValid_REdirectToIndexZaposlenici()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            ZaposleniciDodajVM model = new ZaposleniciDodajVM
            {
                KorisnickoIme = "neki",
                Lozinka = "neki",
                PotvrdaLozinke = "neki",
                Ime = "neki",
                Prezime = "neki",
                Email = "neki",
                Adresa = "neki",
                UlogaId = 1,
                OpstinaId = 1,
                Telefon="..."
            };

            var result = zc.SpremiNovogZaposlenika(model) as RedirectResult;

            Assert.AreEqual("neki",_context.Zaposlenik.Last().Email);
            Assert.AreEqual("neki", _context.Korisnik.Last().KorisnickoIme);
            Assert.AreEqual("/ModulAdministrator/Korisnici/IndexZaposlenici", result.Url);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Kupci_Uredi(int id)
        {
            KupciController kc = new KupciController(_context);
            kc.TempData = GetTempDataForRedirect();

            PartialViewResult result = kc.Uredi(id) as PartialViewResult;
            KupciUrediVM model = result.Model as KupciUrediVM;

            Assert.AreEqual("johndoe", model.KorisnickoIme);
            Assert.AreEqual("kupac", model.Ime);
             Assert.AreEqual(id, model.KupacId);
        }

        [TestMethod]
        public void Test_Admin_Kupci_Snimi_ModelStateNotValid_ReturnsBadReq()
        {
            KupciController kc = new KupciController(_context);
            kc.ModelState.AddModelError("KorisnickoIme", "Required");
            kc.ModelState.AddModelError("Lozinka", "Required");
            kc.ModelState.AddModelError("PotvrdaLozinke", "Required");

            var result = kc.Snimi(new KupciUrediVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_Admin_Kupci_Snimi_ModelStateValid_RedirectsToIndexKupci()
        {
            KupciController kc = new KupciController(_context);
            kc.Url = GetUrlHelper();

            KupciUrediVM model = new KupciUrediVM
            {
                KupacId=1,
                KorisnickoIme="novi",
                Ime="novi",
                Prezime="novi"
            };

            RedirectToActionResult result = kc.Snimi(model) as RedirectToActionResult;

            Assert.AreEqual("IndexKupci", result.ActionName);
            Assert.AreEqual("Korisnici", result.ControllerName);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Kupci_Obrisi_RedirectToIndexKupci(int id)
        {
            KupciController kc = new KupciController(_context);
            kc.Url = GetUrlHelper();

            RedirectToActionResult result = kc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual("IndexKupci", result.ActionName);
            Assert.AreEqual("Korisnici", result.ControllerName);
        }

        [TestMethod]
        public void Test_Admin_Logs_Index()
        {
            LogController lc = new LogController(_context);
            lc.TempData = GetTempDataForRedirect();

            ViewResult result = lc.Index() as ViewResult;
            LogIndexVM model = result.Model as LogIndexVM;

            Assert.AreEqual(1, model.Audits.Count);
        }
    }


}
