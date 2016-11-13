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
            manager.EquipmentTypeAccessor = EquipmentTypeAccessor;
            manager.EquipmentAccessor = EquipmentAccessor;
        }

        [TestMethod]
        public void EquipmentTypeManager_Init()
        {
            Assert.IsNotNull(manager);
            Assert.IsNotNull(manager.EquipmentAccessor);
            Assert.IsNotNull(manager.EquipmentTypeAccessor);
        }

        [TestMethod]
        public void EquipmentTypeManager_SaveEquipmentType()
        {
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Returns(Task.FromResult(new EquipmentType()))
				.OccursOnce();

            var res = manager.SaveEquipmentType(new EquipmentType()).Result;
            EquipmentTypeAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(EquipmentType), res.GetType());
        }

        [TestMethod]
        public void EquipmentTypeManager_SaveEquipmentType_Values()
        {
            var equipmentType = new EquipmentType
            {
                Name = "Type",
                Deleted = false
            };

            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(equipmentType))
                .Returns(Task.FromResult(equipmentType))
                .OccursOnce();

            var res = manager.SaveEquipmentType(equipmentType).Result;
            EquipmentTypeAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(EquipmentType), res.GetType());
        }

        [TestMethod]
        public void EquipmentTypeManager_GetEquipmentTypes()
        {
            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentTypes())
                .Returns(Task.FromResult(new List<EquipmentType>().AsEnumerable()))
                .OccursOnce();

            var res = manager.GetEquipmentTypes().Result;
            EquipmentTypeAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(List<EquipmentType>), res.GetType());
        }

        [TestMethod]
        public void EquipmentTypeManager_GetEquipmentTypes_Values()
        {
            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentTypes())
                .Returns(Task.FromResult(new List<EquipmentType> { new EquipmentType(), new EquipmentType() }.AsEnumerable()))
                .OccursOnce();

            var res = manager.GetEquipmentTypes().Result;
            EquipmentTypeAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.AreEqual(typeof(List<EquipmentType>), res.GetType());
            Assert.AreEqual(2, res.Count());
        }

        [TestMethod]
        public void EquipmentTypeManager_DeleteEquipmentType()
        {
            var saveTask = Task<EquipmentType>.Factory.StartNew(() => { return new EquipmentType(); });

            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new EquipmentType()))
				.OccursOnce();
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Returns(saveTask)
				.OccursOnce();
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new List<Equipment>().AsEnumerable()))
				.OccursOnce();


            var res = manager.DeleteEquipmentType(5).Result;
            saveTask.Wait();
            EquipmentTypeAccessor.Assert();
            EquipmentAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void EquipmentTypeManager_DeleteEquipmentType_Error()
        {
            var saveTask = Task<EquipmentType>.Factory.StartNew(() => { return new EquipmentType(); });

            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new EquipmentType()))
                .OccursOnce();
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Throws(new Exception())
                .OccursOnce();

            var res = manager.DeleteEquipmentType(5).Result;
            saveTask.Wait();
            EquipmentTypeAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void EquipmentTypeManager_DeleteEquipmentType_Equipments()
        {
            var saveTask = Task<EquipmentType>.Factory.StartNew(() => { return new EquipmentType(); });
            var equipmentSave = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new EquipmentType()))
                .OccursOnce();
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Returns(saveTask)
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new List<Equipment> { new Equipment(), new Equipment() }.AsEnumerable()))
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.IsAny<Equipment>()))
                .Returns(equipmentSave)
				.Occurs(2);



            var res = manager.DeleteEquipmentType(5).Result;
            saveTask.Wait();
            equipmentSave.Wait();
            EquipmentTypeAccessor.Assert();
            EquipmentAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void EquipmentTypeManager_DeleteEquipmentType_EquipmentError()
        {
            var saveTask = Task<EquipmentType>.Factory.StartNew(() => { return new EquipmentType(); });
            var equipmentSave = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new EquipmentType()))
                .OccursOnce();
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Returns(saveTask)
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new List<Equipment> { new Equipment(), new Equipment() }.AsEnumerable()))
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.IsAny<Equipment>()))
                .Throws(new Exception())
                .Occurs(2);



            var res = manager.DeleteEquipmentType(5).Result;
            saveTask.Wait();
            equipmentSave.Wait();
            EquipmentTypeAccessor.Assert();
            EquipmentAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void EquipmentTypeManager_DeleteEquipmentType_Equipment_Values()
        {
            var saveTask = Task<EquipmentType>.Factory.StartNew(() => { return new EquipmentType(); });
            var equipmentSave = Task<Equipment>.Factory.StartNew(() => { return new Equipment(); });

            EquipmentTypeAccessor.Arrange(x => x.GetEquipmentType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new EquipmentType()))
                .OccursOnce();
            EquipmentTypeAccessor.Arrange(x => x.SaveEquipmentType(Arg.IsAny<EquipmentType>()))
                .Returns(saveTask)
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.GetEquipmentByType(Arg.IsAny<long>()))
                .Returns(Task.FromResult(new List<Equipment> { new Equipment { EquipmentTypeId = 5 }, new Equipment() }.AsEnumerable()))
                .OccursOnce();
            EquipmentAccessor.Arrange(x => x.SaveEquipment(Arg.Matches<Equipment>(y => y.EquipmentTypeId == 1)))
                .Returns(equipmentSave)
                .Occurs(2);



            var res = manager.DeleteEquipmentType(5).Result;
            saveTask.Wait();
            equipmentSave.Wait();
            EquipmentTypeAccessor.Assert();
            EquipmentAccessor.Assert();
            Assert.IsNotNull(res);
            Assert.IsTrue(res);
        }

        #endregion
    }
}
