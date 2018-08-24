using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrationPractice.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create()
        {


            var controller = new ItemsController();

            var result2 = controller.Create("Canada", "MB", "Winnipeg", "Stolen", "create") as ViewResult;
            Assert.AreEqual("Create", result2.ViewName);


        }

        [TestMethod]
        public async Task CityIndex_InvalidCityAsync()
        {
            var controller = new ItemsController();


            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg1", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);

        }

        [TestMethod]
        public async Task CityIndex_InvalidCountry()
        {
            var controller = new ItemsController();

            var result2 = await controller.CityIndex("Canada1", "MB", "Winnipeg", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_InvalidProvince()
        {
            var controller = new ItemsController();

            var result2 = await controller.CityIndex("Canada", "MB1", "Winnipeg", "Stolen", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);

        }

        [TestMethod]
        public async Task CityIndex_InvalidPostType()
        {
            var controller = new ItemsController();

            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg", "Stolen1", "cityindex", "") as ViewResult;
            Assert.AreEqual("invalidcity", result2.ViewName);
        }

        [TestMethod]
        public async Task CityIndex_Post()
        {
            var controller = new ItemsController();

            var result2 = await controller.CityIndex("Canada", "MB", "Winnipeg", "Stolen1", "cityindex", "post") as ViewResult;
            Assert.AreEqual("Create", result2.ViewName);
        }


    }
}
