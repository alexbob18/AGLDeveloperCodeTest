using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AGLDeveloperCodeTest.Service;
using AGLDeveloperCodeTest.Models;
using AGLDeveloperCodeTest.Controllers;
using System.Web.Mvc;

namespace AGLDeveloperCodeTest.Tests
{
    [TestClass]
    public class PeoplePetsControllerTest
    {
        private Mock<IProcessJsonDataService> _Service;

        [TestInitialize]
        public void Initialize()
        {
            _Service = new Mock<IProcessJsonDataService>();
            _Service.Setup(service => service.GetPeoplePetsData())
                        .Returns(new PetsViewModel());
        }

        [TestMethod, Description("Test to check if controller returns expected model")]
        public void People_Pets_Controller_Model_Test()
        {
            // Arrange
            var peoplePetsTestController = new PeoplePetsController(_Service.Object);

            //Action
            var result = peoplePetsTestController.PeoplePets() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(PetsViewModel));
        }
        [TestMethod, Description("Test to check if controller returns expected view")]
        public void People_Pets_Return_Correct_View()
        {
            // Arrange
            var peoplePetsTestController = new PeoplePetsController();

            //Action
            var result = peoplePetsTestController.PeoplePets() as ViewResult;

            // Assert
            Assert.AreEqual("PeoplePets", result.ViewName);
        }
    }
}
