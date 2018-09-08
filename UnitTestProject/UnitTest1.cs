using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrationPractice.Classes.Globals;
using RegistrationPractice.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {


        ItemsController controller = new ItemsController(new Constants());
        public UnitTest1()
        {
            ItemsController.testing = true;
        }
        [TestMethod]
        public void Create()
        {

            var result2 = controller.Create("Canada", "MB", "Winnipeg", "Stolen", "create") as ViewResult;
            Assert.AreEqual("Create", result2.ViewName);


        }

        [TestMethod]
        public async Task CityIndex_InvalidCityAsync()
        {
            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg1", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_InvalidCountry()
        {
            var result2 = await controller.CityIndex("Canada1", "MB", "Winnipeg", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_InvalidProvince()
        {
            var result2 = await controller.CityIndex("Canada", "MB1", "Winnipeg", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_InvalidPostType()
        {
            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg", "Stolen1", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_Post()
        {
            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg", "Stolen1", "cityindex", "post") as ViewResult;
            Assert.AreEqual("Create", result2.ViewName);
        }


    }
}
