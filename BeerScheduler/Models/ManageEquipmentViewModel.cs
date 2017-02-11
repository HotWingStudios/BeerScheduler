using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Web.Models
{
    public class ManageEquipmentViewModel
    {
        public IEnumerable<Equipment> EquipmentList { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public ManageEquipmentViewModel()
        {
            EquipmentList = new List<Equipment>();
            Errors = Enumerable.Empty<string>();
        }

        public ManageEquipmentViewModel(IEnumerable<Equipment> input, IEnumerable<string> error = null)
        {
            EquipmentList = input;
            Errors = error ?? Enumerable.Empty<string>();
        }
    }
}