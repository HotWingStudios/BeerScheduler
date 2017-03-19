using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerScheduler.Web.Models
{
    public class AddOrEditScheduleViewModel
    {
        public String Title { get; set; }
        public IEnumerable<Equipment> EquipmentList { get; set; }
        public EquipmentSchedule Schedule { get; set; }
        public IEnumerable<SelectListItem> Selectors { get; set; }
        public IEnumerable<String> Errors { get; set; }

        public AddOrEditScheduleViewModel()
        {
            this.Schedule = new EquipmentSchedule();
            this.EquipmentList = Enumerable.Empty<Equipment>();
            this.Errors = Enumerable.Empty<String>();
        }
        
        public AddOrEditScheduleViewModel(String title, EquipmentSchedule schedule, IEnumerable<Equipment> list, IEnumerable<SelectListItem> select, IEnumerable<String> errors)
        {
            this.Title = title;
            this.Schedule = schedule;
            this.EquipmentList = list;
            this.Selectors = select;
            this.Errors = errors ?? Enumerable.Empty<String>();
        }
    }
}