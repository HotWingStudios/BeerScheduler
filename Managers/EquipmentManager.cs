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
        public async Task<Equipment> GetEquipment(long equipmentId)
        {
            return await EquipmentAccessor.GetEquipment(equipmentId);
        }

        public async Task<Equipment> SaveEquipment(Equipment equipment)
        {
            return await EquipmentAccessor.SaveEquipment(equipment);
        }
    }
}
