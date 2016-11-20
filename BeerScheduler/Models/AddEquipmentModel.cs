using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerScheduler.DataContracts;
using System.Web.Mvc;

namespace BeerScheduler.Web.Models
{
    public class AddEquipmentModel
    {
        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }
        public IEnumerable<SelectListItem> OptionList { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public AddEquipmentModel()
        {
            EquipmentTypes = new List<EquipmentType>();
            Errors = Enumerable.Empty<string>();
        }

        public AddEquipmentModel(IEnumerable<EquipmentType> input, IEnumerable<string> error = null)
        {
            EquipmentTypes = input;
            Errors = error ?? Enumerable.Empty<string>();
        }
    }
}