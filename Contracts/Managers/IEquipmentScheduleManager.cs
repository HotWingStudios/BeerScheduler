using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Contracts
{
    public interface IEquipmentScheduleManager
    {
        Task<EquipmentSchedule> SaveEquipmentSchedule(EquipmentSchedule schedule);

        Task<IEnumerable<EquipmentSchedule>> GetAllEquipmentSchedules();

        Task<EquipmentSchedule> GetEquipmentSchedule(long scheduleId);

        Task<EquipmentSchedule> GetCurrentEquipmentSchedule(long equipmentId);

        Task<bool> DeleteEquipmentSchedule(long equipmentId);

        Task<IEnumerable<EquipmentSchedule>> GetSchedulesByEquipment(long equipmentId);
    }
}
