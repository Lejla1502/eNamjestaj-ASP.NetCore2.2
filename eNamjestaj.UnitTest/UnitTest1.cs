using eNamjestaj.Web.Controllers;
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
            Assert.IsNotNull(ac.Login(null));
        }
    }


}
