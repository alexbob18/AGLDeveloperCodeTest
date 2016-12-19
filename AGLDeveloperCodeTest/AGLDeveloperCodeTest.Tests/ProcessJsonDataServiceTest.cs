using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AGLDeveloperCodeTest.Models;
using System.Collections.Generic;
using AGLDeveloperCodeTest.Service;
using System.Web.Mvc;
using AGLDeveloperCodeTest.Controllers;

namespace AGLDeveloperCodeTest.Tests
{
    [TestClass]
    public class ProcessJsonDataServiceTest
    {
        private IProcessJsonDataService _Service;

        [TestInitialize]
        public void Initialize()
        {
            _Service = new ProcessJsonDataService();
        }
        [TestMethod, Description("Compare sorted actual data with Moq data")]
        public void SortedPetsTest()
        {
            //Arrange
            Mock<IProcessJsonDataService> _processMoqJsonDataService = new Mock<IProcessJsonDataService>();

            _processMoqJsonDataService.Setup(service => service.GetPeoplePetsData())
                        .Returns(GetMocPetsViewModelData());

            var testPeoplePetsController = new PeoplePetsController(_processMoqJsonDataService.Object);
            var moqResult = testPeoplePetsController.PeoplePets() as ViewResult;

            PetsViewModel moqPeoplePets = (PetsViewModel)moqResult.ViewData.Model;

            PetsViewModel peoplePets = _Service.GetPeoplePetsData();

            //Action
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var expectedResult = serializer.Serialize(moqPeoplePets);
            var actualResult = serializer.Serialize(peoplePets);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod, Description("Check if the collection of male pets is of type cat")]
        public void MaleCatsTest()
        {
            //Arrange
            var testPeoplePetsController = new PeoplePetsController(_Service);

            //Action
            var result = testPeoplePetsController.PeoplePets() as ViewResult;

            //Assert
            var testPeoplePetsViewModel = (PetsViewModel)result.ViewData.Model;

            foreach (var maleCats in testPeoplePetsViewModel.MaleCats)
            {
                Assert.AreEqual("Cat", maleCats.Type);
            }

        }
        [TestMethod, Description("Check if the collection of female pets is of type cat")]
        public void FemaleCatsTest()
        {
            //Arrange
            var testPeoplePetsController = new PeoplePetsController(_Service);

            //Action
            var result = testPeoplePetsController.PeoplePets() as ViewResult;

            //Assert
            var testPeoplePetsViewModel = (PetsViewModel)result.ViewData.Model;

            foreach (var femaleCats in testPeoplePetsViewModel.FemaleCats)
            {
                Assert.AreEqual("Cat", femaleCats.Type);
            }
        }

        /// <summary>
        /// Sorted moc data to be compared with actual json source
        /// </summary>
        private PetsViewModel GetMocPetsViewModelData()
        {
            return new PetsViewModel
            {
                FemaleCats = new List<PetModel> {
                                                    new PetModel { Name = "Garfield", Type = "Cat" },
                                                    new PetModel { Name = "Simba", Type = "Cat"  },
                                                    new PetModel { Name = "Tabby", Type = "Cat"  },
                                                 },
                MaleCats = new List<PetModel> {
                                                    new PetModel { Name = "Garfield", Type = "Cat" },
                                                    new PetModel { Name = "Jim", Type = "Cat" },
                                                    new PetModel { Name = "Max", Type = "Cat" },
                                                    new PetModel { Name = "Tom", Type = "Cat" }}
            };
        }
    }
}
