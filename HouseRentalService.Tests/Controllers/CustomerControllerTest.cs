using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseRentalService.Controllers;
using HouseRentalService.Models;
using System.Web.Mvc;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.IO;

namespace HouseRentalService.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act

            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            var model = new ReservationModel();

            ViewResult result = controller.Details(6) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditCustomer()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            var model = new ReservationModel();

            ViewResult result = controller.EditCustomer(6) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
