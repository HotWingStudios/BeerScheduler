using BeerScheduler.DataContracts;
using BeerScheduler.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

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
            manager.EquipmentAccessor = EquipmentAccessor;
        }

        [TestMethod]
        public void EquipmentManager_Init()
        {
            Assert.IsNotNull(manager);
            Assert.IsNotNull(manager.EquipmentAccessor);
        }

        [TestMethod]
        public void EquipmentManager_DeleteEquipment()
        {
            var saveTask = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentAccessor.Arrange(x => x.GetEquipment(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new Equipment()))
				.OccursOnce();

            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.IsAny<Equipment>()))
                .Returns(saveTask)
				.OccursOnce();

            var res = manager.DeleteEquipment(5).Result;
            saveTask.Wait();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_DeleteEquipment_Values()
        {
            var saveTask = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentAccessor.Arrange(x => x.GetEquipment(5))
                .Returns(Task.FromResult(new Equipment { Deleted = false }))
                .OccursOnce();

            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.Matches<Equipment>(y => y.Deleted)))
                .Returns(saveTask)
                .OccursOnce();

            var res = manager.DeleteEquipment(5).Result;
            saveTask.Wait();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_DeleteEquipment_CatchException()
        {
            var saveTask = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentAccessor.Arrange(x => x.GetEquipment(5))
                .Returns(Task.FromResult(new Equipment { Deleted = false }))
                .OccursOnce();

            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.Matches<Equipment>(y => y.Deleted)))
                .Throws(new Exception())
                .OccursOnce();

            var res = manager.DeleteEquipment(5).Result;
            saveTask.Wait();
            Assert.IsNotNull(res);
            Assert.IsFalse(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetAllEquipment()
        {
            EquipmentAccessor.Arrange(x => x.GetAllEquipment())
                .Returns(Task.FromResult(Enumerable.Empty<Equipment>()))
				.OccursOnce();

            var res = manager.GetAllEquipment().Result;
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetAllEquipment_Values()
        {
            EquipmentAccessor.Arrange(x => x.GetAllEquipment())
                .Returns(Task.FromResult(new List<Equipment> { new Equipment(), new Equipment() }.AsEnumerable()))
                .OccursOnce();

            var res = manager.GetAllEquipment().Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count());
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipment()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipment(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new Equipment()))
                .OccursOnce();

            var res = manager.GetEquipment(5).Result;
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipment_Values()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipment(5))
                .Returns(Task.FromResult(new Equipment { Name = "test" }))
                .OccursOnce();

            var res = manager.GetEquipment(5).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual("test", res.Name);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipmentByType()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(Enumerable.Empty<Equipment>()))
                .OccursOnce();

            var res = manager.GetEquipmentByType(5).Result;
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipmentByType_Values()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(5))
                .Returns(Task.FromResult(new List<Equipment> { new Equipment(), new Equipment() }.AsEnumerable()))
                .OccursOnce();

            var res = manager.GetEquipmentByType(5).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count());
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipmentSchedule()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipmentSchedule(Arg.IsAny<long>()))
                .Returns(Task.FromResult(Enumerable.Empty<EquipmentSchedule>()))
                .OccursOnce();

            var res = manager.GetEquipmentSchedule(5).Result;
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_GetEquipmentSchedule_Values()
        {
            EquipmentAccessor.Arrange(x => x.GetEquipmentSchedule(5))
                .Returns(Task.FromResult(new List<EquipmentSchedule> { new EquipmentSchedule(), new EquipmentSchedule() }.AsEnumerable()))
                .OccursOnce();

            var res = manager.GetEquipmentSchedule(5).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count());
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_SaveEquipment()
        {
            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.IsAny<Equipment>()))
                .Returns(Task.FromResult(new Equipment()))
                .OccursOnce();

            var res = manager.SaveEquipment(new Equipment()).Result;
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        [TestMethod]
        public void EquipmentManager_SaveEquipment_Values()
        {
            var equip = new Equipment { EquipmentId = 5 };
            var saveTask = Task<Equipment>.Factory.StartNew(() => { return equip; });
            EquipmentAccessor.Arrange(x => x.SaveEquipment(equip))
                .Returns(saveTask)
                .OccursOnce();

            var res = manager.SaveEquipment(equip).Result;
            saveTask.Wait();
            Assert.IsNotNull(res);
            EquipmentAccessor.Assert();
        }

        #endregion
    }
}
