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
    public class EquipmentTypeAccessor : BaseAccessor, IEquipmentTypeAccessor
    {
        public async Task<EquipmentType> GetEquipmentType(long equipmentTypeId)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentTypes.FirstOrDefaultAsync(x => !x.Deleted && x.EquipmentTypeId == equipmentTypeId);
            }
        }

        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypes()
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentTypes.Where(x => !x.Deleted).ToListAsync();
            }
        }

        public async Task<EquipmentType> SaveEquipmentType(EquipmentType equipmentType)
        {
            using (var db = CreateDatabaseContext())
            {
                var dbEquipmentType = await db.EquipmentTypes.FirstOrDefaultAsync(x => x.EquipmentTypeId == equipmentType.EquipmentTypeId);

                // create new equipment record
                if (dbEquipmentType == null)
                {
                    db.EquipmentTypes.Add(equipmentType);
                }
                else
                {
                    // update equipment if it exists
                    dbEquipmentType.Name = equipmentType.Name;
                    dbEquipmentType.Deleted = equipmentType.Deleted;
                }

                await db.SaveChangesAsync();
            }

            return equipmentType;
        }
    }
}
