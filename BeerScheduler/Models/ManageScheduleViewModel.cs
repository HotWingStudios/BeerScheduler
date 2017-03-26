using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerScheduler.Web.Models
{
    public class ManageScheduleViewModel
    {
        public IEnumerable<EquipmentAggregator> ScheduleList { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public ManageScheduleViewModel()
        {
            ScheduleList = new List<EquipmentAggregator>();
            Errors = Enumerable.Empty<string>();
        }

        public ManageScheduleViewModel(IEnumerable<EquipmentAggregator> input, IEnumerable<string> error = null)
        {
            ScheduleList = input;
            Errors = error ?? Enumerable.Empty<string>();
        }
    }

    public class EquipmentAggregator {
        public EquipmentSchedule Schedule { get; set; }

        public Equipment Equipment { get; set; }

        public EquipmentAggregator(EquipmentSchedule schedule, Equipment equipment)
        {
            this.Schedule = schedule;

            this.Equipment = equipment;
        }
    }
}