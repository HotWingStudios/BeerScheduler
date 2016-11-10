using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;
using System.Data.Entity;

namespace BeerScheduler.Accessors
{
    public class EquipmentAccessor : BaseAccessor, IEquipmentAccessor
    {
        public async Task<Equipment> GetEquipment(long equipmentId)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.Equipment.FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);
            }
        }

        public async Task<IEnumerable<EquipmentSchedule>> GetEquipmentSchedule(long equipmentId)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentSchedules.Where(x => !x.Deleted && x.EquipmentId == equipmentId).ToListAsync();
            }
        }

        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypes()
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentTypes.Where(x => !x.Deleted).ToListAsync();
            }
        }

        public async Task<Equipment> SaveEquipment(Equipment equipment)
        {
            using (var db = CreateDatabaseContext())
            {
                var dbEquipment = await db.Equipment.FirstOrDefaultAsync(x => x.EquipmentId == equipment.EquipmentId);

                // create new equipment record
                if(dbEquipment == null)
                {
                    db.Equipment.Add(equipment);
                }
                else
                {
                    // update equipment if it exists
                    dbEquipment.Description = equipment.Description;
                    dbEquipment.Name = equipment.Name;
                    dbEquipment.Deleted = equipment.Deleted;
                    dbEquipment.EquipmentType = equipment.EquipmentType;
                }

                await db.SaveChangesAsync();
            }

            return equipment;
        }
    }
}
