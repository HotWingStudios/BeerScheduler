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
    public class EquipmentAccessorTests : BaseTestAccessor
    {
        #region Fields

        private EquipmentAccessor accessor;

        #endregion

        #region Properties



        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialize()
        {
            accessor = new EquipmentAccessor();
        }

        [TestMethod]
        public void EquipmentAccessor_Init()
        {
            Assert.IsNotNull(accessor);
        }

        #endregion

    }
}
