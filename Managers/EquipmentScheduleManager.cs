using BeerScheduler.Utilities;
using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.Contracts;
using BeerScheduler.Accessors;

namespace BeerScheduler.Managers
{
    public class EquipmentScheduleManager: BaseManager, IEquipmentScheduleManager
    {
        public async Task<bool> DeleteEquipmentSchedule(long scheduleId)
        {

            var schedule = await EquipmentScheduleAccessor.GetSchedule(scheduleId);
            schedule.Deleted = true;

            try
            {
                await EquipmentScheduleAccessor.SaveEquipmentSchedule(schedule);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Could not delete schedule", TraceEventType.Error, ex);
                return false;
            }
        }

        public async Task<IEnumerable<EquipmentSchedule>> GetAllEquipmentSchedules()
        {
            
            return await EquipmentScheduleAccessor.GetAllSchedules();
        }

        public async Task<EquipmentSchedule> GetCurrentEquipmentSchedule(long equipmentId)
        {
            return await EquipmentScheduleAccessor.GetCurrentSchedule(equipmentId);
        }

        public async Task<EquipmentSchedule> GetEquipmentSchedule(long scheduleId)
        {
            return await EquipmentScheduleAccessor.GetSchedule(scheduleId);
        }

        public async Task<IEnumerable<EquipmentSchedule>> GetSchedulesByEquipment(long equipmentId)
        {
            return await EquipmentScheduleAccessor.GetEquipmentSchedules(equipmentId);
        }

        public async Task<EquipmentSchedule> SaveEquipmentSchedule(EquipmentSchedule schedule)
        {   
            return await EquipmentScheduleAccessor.SaveEquipmentSchedule(schedule);
                
        }
    }
}
