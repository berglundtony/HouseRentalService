using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseRentalService;
using HouseRentalService.Controllers;
using HouseRentalService.Models;
using HouseRentalService.Functions;

namespace HouseRentalService.Tests.Controllers
{
    [TestClass]
    public class ReservationControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ReservationController controller = new ReservationController();

            // Act
            var model = new ReservationModel();
            model._resarvationData = FunctionReservation.GetDataForReservations();
            var totalprice = model.TotalPrice;
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Testing total price are the same as expected for apartment
        /// </summary>

        [TestMethod]
        public void Details()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            int NumberOfdays = 6;
            double multiplicationvalue = 0;
            var housetype = "Apartment";
            var houseid = 2;
            double totalprice = BaseDayFee * NumberOfdays * multiplicationvalue;
            if (multiplicationvalue == 0) { totalprice = BaseDayFee * NumberOfdays; }

            // Act
                var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(13);
            var totalcost = model.TotalPrice;
            ViewResult result = controller.Details(13) as ViewResult;

            // Assert
            Assert.AreEqual(totalcost, totalprice);
        }

        /// <summary>
        /// Testing if totalcost are the same as expected for Bungalow
        /// </summary>

        [TestMethod]
        public void CheckHouseRentalCostForBungalowForTotaldays()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            double multiplacationvalue = 1.5;
            var housetype = "Bungalow";
            double dayprice = BaseDayFee * multiplacationvalue;
            if (multiplacationvalue == 0) dayprice = BaseDayFee;

            // Act
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(11);
            double? daycost = model.DayPrice;
            ViewResult result = controller.Details(11) as ViewResult;

            // Assert
            Assert.AreEqual(daycost, dayprice);
        }
        /// <summary>
        /// Testing daycost are the same as expected for Villa
        /// </summary>
        [TestMethod]
        public void CheckHouseRentalCostForVillaInTotalDays()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            double multiplacationvalue = 2.5;
            var housetype = "Villas";
            double dayprice = BaseDayFee * multiplacationvalue;
            if (multiplacationvalue == 0) dayprice = BaseDayFee;

            // Act
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(12);
            double? daycost = model.DayPrice;
            ViewResult result = controller.Details(12) as ViewResult;

            // Assert
            Assert.AreEqual(daycost, dayprice);
        }


        /// <summary>
        /// Testing daycost are the same as expected for Apartment
        /// </summary>

        [TestMethod]
        public void CheckHouseRentalCostForApartmentInOneDay()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            double multiplacationvalue = 0;
            var housetype = "Apartment";
            double dayprice = BaseDayFee * multiplacationvalue;
            if (multiplacationvalue == 0)  dayprice = BaseDayFee;

            // Act
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(13);
            double? daycost = model.DayPrice;
            ViewResult result = controller.Details(13) as ViewResult;

            // Assert
            Assert.AreEqual(daycost, dayprice);
        }
        /// <summary>
        /// Testing daycost are the same as expected for Bungalow
        /// </summary>

        [TestMethod]
        public void CheckHouseRentalCostForBungalowInOneDay()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            double multiplacationvalue = 1.5;
            var housetype = "Bungalow";
            double dayprice = BaseDayFee * multiplacationvalue;
            if (multiplacationvalue == 0) dayprice = BaseDayFee;

            // Act
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(11);
            double? daycost = model.DayPrice;
            ViewResult result = controller.Details(11) as ViewResult;

            // Assert
            Assert.AreEqual(daycost, dayprice);
        }
        /// <summary>
        /// Testing daycost are the same as expected for Villa
        /// </summary>
        [TestMethod]
        public void CheckHouseRentalCostForVillaInOneDay()
        {
            // Arrange
            ReservationController controller = new ReservationController();
            double BaseDayFee = 800;
            double multiplacationvalue = 2.5;
            var housetype = "Villas";
            double dayprice = BaseDayFee * multiplacationvalue;
            if (multiplacationvalue == 0) dayprice = BaseDayFee;

            // Act
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(12);
            double? daycost = model.DayPrice;
            ViewResult result = controller.Details(12) as ViewResult;

            // Assert
            Assert.AreEqual(daycost, dayprice);
        }








    }
}
