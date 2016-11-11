using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Contracts
{
    public interface IEquipmentTypeManager
    {
        Task<EquipmentType> SaveEquipmentType(EquipmentType equipmentType);

        Task<bool> DeleteEquipmentType(long equipmentTypeId);

        Task<IEnumerable<EquipmentType>> GetEquipmentTypes();
    }
}
