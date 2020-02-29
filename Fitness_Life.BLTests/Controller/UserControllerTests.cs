using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness_Life.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Life.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {


        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 180;
            var gender = "man";
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller_2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller_2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller_2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller_2.CurrentUser.Weight);
            Assert.AreEqual(height, controller_2.CurrentUser.Height);
            Assert.AreEqual(gender, controller_2.CurrentUser.Gender.Name);
        }

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
    }
}