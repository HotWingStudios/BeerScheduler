using BeerScheduler.Accessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.AccessorTests
{
    [TestClass]
    public class EquipmentTypeAccessorTests : BaseTestAccessor
    {
        #region Fields

        private EquipmentTypeAccessor accessor;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            accessor = new EquipmentTypeAccessor();
        }

        [TestMethod]
        public void EquipmentTypeAccessor_Init()
        {
            Assert.IsNotNull(accessor);
        }

        #endregion
    }
}
