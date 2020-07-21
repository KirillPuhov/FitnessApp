using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.DateOfBirth);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.GenderName);
        }
    }
}