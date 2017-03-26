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
    public class EquipmentScheduleAccessor : BaseAccessor, IEquipmentScheduleAccessor
    {

        public async Task<IEnumerable<EquipmentSchedule>> GetAllSchedules()
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentSchedules.Where(x => !x.Deleted).ToListAsync();
            }
        }

        public async Task<EquipmentSchedule> GetScheduleContaining(DateTime time, long equipmentId)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.EquipmentSchedules.FirstOrDefaultAsync(x => !x.Deleted && x.EquipmentId == equipmentId && x.StartDate <= time && x.EndDate >= time);
            }
        }
        public async Task<EquipmentSchedule> GetCurrentSchedule(long equipmentId)
        {
            return await GetScheduleContaining(DateTime.Now, equipmentId);
        }

        public async Task<EquipmentSchedule> GetSchedule(long scheduleId)
        {
            using(var db = CreateDatabaseContext())
            {
                return await db.EquipmentSchedules.FirstOrDefaultAsync(x => x.EquipmentScheduleId == scheduleId && !x.Deleted);
            }
        }

        public async Task<IEnumerable<EquipmentSchedule>> GetEquipmentSchedules(long equipmentId)
        {
            using(var db = CreateDatabaseContext())
            {
                return await db.EquipmentSchedules.Where(x => !x.Deleted && x.EquipmentId == equipmentId).ToListAsync();
            }
        }

        public async Task<EquipmentSchedule> SaveEquipmentSchedule(EquipmentSchedule schedule)
        {
            /*if (GetScheduleContaining(schedule.StartDate, schedule.EquipmentId) == null || GetScheduleContaining(schedule.EndDate, schedule.EquipmentId) == null)
            {
                return null;
            }
            else
            {*/
                using (var db = CreateDatabaseContext())
                {
                    var dbSchedule = await db.EquipmentSchedules.FirstOrDefaultAsync(x => x.EquipmentScheduleId == schedule.EquipmentScheduleId);
                    
                    // create new schedule record
                    if (dbSchedule == null)
                    {
                        db.EquipmentSchedules.Add(schedule);
                    }
                    else
                    {
                        // update schedule if it exists
                        dbSchedule.StartDate = schedule.StartDate;
                        dbSchedule.EndDate = schedule.EndDate;
                        dbSchedule.Equipment = schedule.Equipment;
                        dbSchedule.EquipmentId = schedule.EquipmentId;
                        dbSchedule.EquipmentScheduleId = schedule.EquipmentScheduleId;
                        dbSchedule.Deleted = schedule.Deleted;
                    }

                    await db.SaveChangesAsync();
                }

                return schedule;
            //}
        }
    }
}
