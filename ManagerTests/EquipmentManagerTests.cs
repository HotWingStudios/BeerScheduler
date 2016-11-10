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
    public class EquipmentManagerTests : BaseTestManager
    {
        #region Fields

        private EquipmentManager manager;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            manager = new EquipmentManager();
        }

        [TestMethod]
        public void EquipmentManager_Init()
        {
            Assert.IsNotNull(manager);
        }

        #endregion
    }
}
