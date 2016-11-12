using BeerScheduler.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.ManagerTests
{
    [TestClass]
    public class EquipmentTypeManagerTests : BaseTestManager
    {
        #region Fields

        private EquipmentTypeManager manager;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            manager = new EquipmentTypeManager();
        }

        [TestMethod]
        public void EquipmentTypeManager_Init()
        {
            Assert.IsNotNull(manager);
        }
        #endregion
    }
}
