using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseRentalService.Controllers;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.IO;
using HouseRentalService.Models;

namespace HouseRentalService.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Login()
        {
            // Arrange
            AdminController controller = new AdminController();

            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
