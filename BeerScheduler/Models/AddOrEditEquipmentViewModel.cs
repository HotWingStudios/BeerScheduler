using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BeerScheduler.Web.Models
{
    public class AddOrEditEquipmentViewModel
    {
        public Equipment Equipment { get; set; }

        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public String Title { get; set; }

        public long SelectedID { get; set; }

        public IEnumerable<SelectListItem> SelectTypes { get; set; }

        public AddOrEditEquipmentViewModel()
        {
            Equipment = new Equipment();
            Errors = Enumerable.Empty<string>();
        }

        public AddOrEditEquipmentViewModel(Equipment input, IEnumerable<EquipmentType> types, IEnumerable<string> error = null)
        {
            Equipment = input;
            EquipmentTypes = types;
            Errors = error ?? Enumerable.Empty<string>();
        }
    }
}