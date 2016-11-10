using BeerScheduler.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.ModelTests.EF_Models
{
    [TestClass]
    public class EquipmentTests : BaseTestModel
    {
        #region Fields

        private Equipment model;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            model = new Equipment();
        }

        [TestMethod]
        public void Equipment_Init()
        {
            Assert.IsNotNull(model);
        }

        #endregion
    }
}
