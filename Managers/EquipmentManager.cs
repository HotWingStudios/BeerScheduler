using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Managers
{
    public class EquipmentManager : BaseManager, IEquipmentManager
    {
        public async Task<bool> DeleteEquipment(long equipmentId)
        {
            var equipment = await EquipmentAccessor.GetEquipment(equipmentId);
            equipment.Deleted = true;

            try
            {
                await EquipmentAccessor.SaveEquipment(equipment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipment()
        {
            return await EquipmentAccessor.GetAllEquipment();
        }

        public async Task<Equipment> GetEquipment(long equipmentId)
        {
            return await EquipmentAccessor.GetEquipment(equipmentId);
        }

        public async Task<Equipment> GetEquipmentByType(long equipmentTypeId)
        {
            return await EquipmentAccessor.GetEquipmentByType(equipmentTypeId);
        }

        public async Task<IEnumerable<EquipmentSchedule>> GetEquipmentSchedule(long equipmentId)
        {
            return await EquipmentAccessor.GetEquipmentSchedule(equipmentId);
        }

        public async Task<Equipment> SaveEquipment(Equipment equipment)
        {
            return await EquipmentAccessor.SaveEquipment(equipment);
        }
    }
}
