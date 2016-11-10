using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Accessors
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BeerScheduler")
        {
        }

        public IDbSet<Equipment> Equipment { get; set; }

        public IDbSet<EquipmentSchedule> EquipmentSchedules { get; set; }

        public IDbSet<EquipmentType> EquipmentTypes { get; set; }

        public static DatabaseContext Create()
        {
            Database.SetInitializer<DatabaseContext>(null);
            return new DatabaseContext();
        }
    }
}
