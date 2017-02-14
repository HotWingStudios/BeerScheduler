using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;
using System.Data.Entity;

namespace BeerScheduler.Contracts.Accessors
{
    public interface IEquipmentScheduleAccessor
    {
        Task<IEnumerable<EquipmentSchedule>> GetAllSchedules();

        Task<IEnumerable<EquipmentSchedule>> GetEquipmentSchedules(long equipmentId);

        Task<EquipmentSchedule> GetScheduleContaining(DateTime time, long equipmentId);

        Task<EquipmentSchedule> GetCurrentSchedule(long equipmentId);

        Task<EquipmentSchedule> SaveEquipmentSchedule(EquipmentSchedule schedule);

        
    }
}
