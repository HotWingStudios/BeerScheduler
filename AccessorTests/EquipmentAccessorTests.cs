using BeerScheduler.Accessors;
using BeerScheduler.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;

namespace BeerScheduler.AccessorTests
{
    [TestClass]
    public class EquipmentAccessorTests : BaseTestAccessor
    {
        #region Fields

        private EquipmentAccessor accessor;

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
        public void EquipmentAccessor_Init()
        {
            accessor = GetAccessor();

            Assert.IsNotNull(accessor);
            Assert.IsNotNull(MockDatabaseContext);
            Assert.IsNotNull(MockDatabaseContext.Equipment);
            Assert.IsNotNull(MockDatabaseContext.EquipmentTypes);
        }

        [TestMethod]
        public void EquipmentAccessor_GetAllEquipment()
        {
            accessor = GetAccessor();

            var res = accessor.GetAllEquipment().Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(List<Equipment>), res.GetType());
            Assert.AreEqual(3, res.Count());
            Assert.AreEqual("Name 1", res.First().Name);
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipment()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipment(2).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(Equipment), res.GetType());
            Assert.AreEqual("Name 2", res.Name);
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipment_Null()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipment(99).Result;
            Assert.IsNull(res);
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipmentByType()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentByType(1).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Count());
            Assert.AreEqual(typeof(List<Equipment>), res.GetType());
            Assert.AreEqual("Name 1", res.First().Name);
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipmentByType_Empty()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentByType(99).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(0, res.Count());
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipmentSchedule()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentSchedule(1).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count());
            Assert.AreEqual(typeof(List<EquipmentSchedule>), res.GetType());
            Assert.AreEqual(new DateTime(2016, 11, 11), res.First().StartDate);
        }

        [TestMethod]
        public void EquipmentAccessor_GetEquipmentSchedule_Empty()
        {
            accessor = GetAccessor();

            var res = accessor.GetEquipmentSchedule(99).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(0, res.Count());
        }

        [TestMethod]
        public void EquipmentAccessor_SaveEquipment()
        {
            accessor = GetAccessor();

            var equipment = new Equipment
            {
                Name = "New Equipment",
                Description = "New Description",
                DateAquired = new DateTime(2016, 11, 11),
                EquipmentTypeId = 1
            };

            var res = accessor.SaveEquipment(equipment).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(5, MockDatabaseContext.Equipment.Count());
            Assert.AreEqual("New Equipment", MockDatabaseContext.Equipment.Last().Name);
        }

        [TestMethod]
        public void EquipmentAccessor_SaveEquipment_Update()
        {
            accessor = GetAccessor();

            var equipment = new Equipment
            {
                EquipmentId = 3,
                Name = "New Equipment",
                Description = "New Description",
                DateAquired = new DateTime(2015, 11, 11),
                EquipmentTypeId = 99,
                Deleted = true
            };

            var res = accessor.SaveEquipment(equipment).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(5, MockDatabaseContext.Equipment.Count());
            Assert.AreEqual("New Equipment", MockDatabaseContext.Equipment.First(x => x.EquipmentId == 3).Name);
            Assert.AreEqual("New Description", MockDatabaseContext.Equipment.First(x => x.EquipmentId == 3).Description);
            Assert.AreEqual(new DateTime(2015, 11, 11), MockDatabaseContext.Equipment.First(x => x.EquipmentId == 3).DateAquired);
            Assert.AreEqual(99, MockDatabaseContext.Equipment.First(x => x.EquipmentId == 3).EquipmentTypeId);
        }

        #endregion

        #region HelperClasses

        public EquipmentAccessor GetAccessor()
        {
            return new EquipmentAccessor
            {
                DatabaseContextInstance = MockDatabaseContext
            };
        }

        #endregion

    }
}
