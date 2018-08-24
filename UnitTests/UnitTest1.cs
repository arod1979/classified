using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrationPractice.Controllers;
using System;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var controller = new ItemsController();
                var result = controller.Create("Canada", "MB", "Winnipeg", "Stolen", "Create") as ViewResult;
            }
            catch (Exception e)
            {

            }
        }
    }
}
