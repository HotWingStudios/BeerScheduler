using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Managers
{
    public class EquipmentTypeManager : BaseManager, IEquipmentTypeManager
    {
        public Task<bool> DeleteEquipmentType(long equipmentTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<EquipmentType> SaveEquipmentType(EquipmentType equipmentType)
        {
            return await EquipmentTypeAccessor.SaveEquipmentType(equipmentType);
        }

        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypes()
        {
            return await EquipmentTypeAccessor.GetEquipmentTypes();
        }
    }
}
