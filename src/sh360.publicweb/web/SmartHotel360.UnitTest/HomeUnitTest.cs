using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHotel360.PublicWeb.Controllers;

namespace SmartHotel360.UnitTest
{
    [TestClass]
    public class HomeUnitTest
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();

            Assert.IsInstanceOfType(controller.Index(), typeof(IActionResult));
        }

        [TestMethod]
        public void AboutTest()
        {
            HomeController controller = new HomeController();

            Assert.IsInstanceOfType(controller.About(), typeof(IActionResult));
        }

        [TestMethod]
        public void ContactTest()
        {
            HomeController controller = new HomeController();

            Assert.IsInstanceOfType(controller.ContactUs(), typeof(IActionResult));
        }
    }
}
