using BeerScheduler.Accessors;
using BeerScheduler.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock.EntityFramework;

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
            MockDatabaseContext = Telerik.JustMock.Mock.Create<DatabaseContext>().PrepareMock();
            MockDatabaseContext.EquipmentTypes.Bind(MockEquipmentTypes);
            MockDatabaseContext.Equipment.Bind(MockEquipment);
            MockDatabaseContext.EquipmentSchedules.Bind(MockEquipmentSchedule);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_Init()
        {
            accessor = GetAccessor();

            Assert.IsNotNull(accessor);
            Assert.IsNotNull(MockDatabaseContext.Equipment);
            Assert.IsNotNull(MockDatabaseContext.EquipmentTypes);
            Assert.IsNotNull(MockDatabaseContext.EquipmentSchedules);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_GetEquipmentType()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentType(2).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(EquipmentType), res.GetType());
            Assert.AreEqual("Type 2", res.Name);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_GetEquipmentType_Null()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentType(99).Result;
            Assert.IsNull(res);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_GetEquipmentTypes()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentTypes().Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(List<EquipmentType>), res.GetType());
            Assert.AreEqual(2, res.Count());
            Assert.AreEqual("Type 1", res.First().Name);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_SaveEquipmentType()
        {
            accessor = GetAccessor();

            var equipmentType = new EquipmentType
            {
                Name = "New Equipment Type"
            };

            var res = accessor.SaveEquipmentType(equipmentType).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(4, MockDatabaseContext.Equipment.Count());
            Assert.AreEqual("New Equipment Type", MockDatabaseContext.EquipmentTypes.Last().Name);
        }

        [TestMethod]
        public void EquipmentTypeAccessor_SaveEquipmentType_Update()
        {
            accessor = GetAccessor();

            var equipmentType = new EquipmentType
            {
                EquipmentTypeId = 1,
                Name = "New Equipment Type",
                Deleted = true
            };

            var res = accessor.SaveEquipmentType(equipmentType).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(4, MockDatabaseContext.Equipment.Count());
            Assert.AreEqual("New Equipment Type", MockDatabaseContext.EquipmentTypes.First(x => x.EquipmentTypeId == 1).Name);
            Assert.IsTrue(MockDatabaseContext.EquipmentTypes.First().Deleted);
        }

        #endregion

        #region HelperClasses

        public EquipmentTypeAccessor GetAccessor()
        {
            return new EquipmentTypeAccessor
            {
                DatabaseContextInstance = MockDatabaseContext
            };
        }

        #endregion
    }
}
