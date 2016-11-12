using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Contracts
{
    public interface IEquipmentManager
    {
        Task<Equipment> SaveEquipment(Equipment equipment);

        Task<IEnumerable<Equipment>> GetAllEquipment();

        Task<Equipment> GetEquipment(long equipmentId);

        Task<IEnumerable<Equipment>> GetEquipmentByType(long equipmentTypeId);

        Task<bool> DeleteEquipment(long equipmentId);

        Task<IEnumerable<EquipmentSchedule>> GetEquipmentSchedule(long equipmentId);
    }
}
