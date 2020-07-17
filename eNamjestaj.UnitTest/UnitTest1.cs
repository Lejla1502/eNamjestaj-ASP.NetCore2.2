using eNamjestaj.Web.Controllers;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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


}
