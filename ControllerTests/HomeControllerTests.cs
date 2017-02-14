using BeerScheduler.Controllers;
using BeerScheduler.DataContracts;
using BeerScheduler.Managers;
using BeerScheduler.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.ControllerTests
{
    [TestClass]
    public class HomeControllerTests : BaseTestController
    {
        #region Fields

        private HomeController controller;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void HomeController_Init()
        {
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public async void HomeController_AddEquipment()
        {
            var model = new AddOrEditEquipmentViewModel();
            var equipment = new Equipment();


            controller.AddEquipmentType("test");
            var manager = new EquipmentTypeManager();
            model.Equipment = new Equipment
            {
                Name = "Test",
               
                
            }
        }

        #endregion
    }
}
