using BeerScheduler.Accessors;
using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.AccessorTests
{
    public class BaseTestAccessor
    {
        #region Fields

        public DatabaseContext MockDatabaseContext;

        #endregion

        #region Properties

        public List<Equipment> MockEquipment = new List<Equipment>
        {
            new Equipment
            {
                EquipmentId = 1,
                EquipmentTypeId = 1,
                Name = "Name 1",
                Description = "Description 1",
                DateAquired = new DateTime(2016, 11, 11),
                Deleted = false
            },
            new Equipment
            {
                EquipmentId = 2,
                EquipmentTypeId = 1,
                Name = "Name 2",
                Description = "Description 2",
                DateAquired = new DateTime(2016, 11, 11),
                Deleted = false
            },
            new Equipment
            {
                EquipmentId = 3,
                EquipmentTypeId = 2,
                Name = "Name 3",
                Description = "Description 3",
                DateAquired = new DateTime(2016, 11, 11),
                Deleted = false
            },
            new Equipment
            {
                EquipmentId = 4,
                EquipmentTypeId = 1,
                Name = "Name 4",
                Description = "Description 4",
                DateAquired = new DateTime(2016, 11, 11),
                Deleted = true
            }
        };

        public List<EquipmentType> MockEquipmentTypes = new List<EquipmentType>
        {
            new EquipmentType
            {
                EquipmentTypeId = 1,
                Name = "Type 1",
                Deleted = false
            },
            new EquipmentType
            {
                EquipmentTypeId = 2,
                Name = "Type 2",
                Deleted = false
            },
            new EquipmentType
            {
                EquipmentTypeId = 3,
                Name = "Type 3",
                Deleted = true
            }
        };

        public List<EquipmentSchedule> MockEquipmentSchedule = new List<EquipmentSchedule>
        {
            new EquipmentSchedule
            {
                EquipmentScheduleId = 1,
                EquipmentId = 1,
                StartDate = new DateTime(2016, 11, 11),
                EndDate = new DateTime(2016, 11, 21),
                Deleted = false
            },
            new EquipmentSchedule
            {
                EquipmentScheduleId = 2,
                EquipmentId = 1,
                StartDate = new DateTime(2016, 11, 11),
                EndDate = new DateTime(2016, 11, 21),
                Deleted = false
            },
            new EquipmentSchedule
            {
                EquipmentScheduleId = 3,
                EquipmentId = 2,
                StartDate = new DateTime(2016, 11, 11),
                EndDate = new DateTime(2016, 11, 21),
                Deleted = false
            },
            new EquipmentSchedule
            {
                EquipmentScheduleId = 4,
                EquipmentId = 1,
                StartDate = new DateTime(2016, 11, 11),
                EndDate = new DateTime(2016, 11, 21),
                Deleted = true
            }
        };

        #endregion

        #region Methods



        #endregion
    }
}
