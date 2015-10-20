using System;
using System.Web.Mvc;
using GroceryList.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryList.Tests.Controllers
{
    [TestClass]
    public class IngredientsTestController
    {
        [TestMethod]
        public void IndexDataTest()
        {
            //Arrange
            var controller = new GroceryList.IngredientsTestController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var ingredient = (Ingredient) result.ViewData.Model;
            Assert.AreEqual("Bananas", ingredient.Name);
        }
    }
}
