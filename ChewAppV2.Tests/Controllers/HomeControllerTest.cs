using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChewAppV2;
using ChewAppV2.Controllers;

namespace ChewAppV2.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
