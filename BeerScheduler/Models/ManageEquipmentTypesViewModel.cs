using BeerScheduler.DataContracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BeerScheduler.Web.Models
{
    public class ManageEquipmentTypesViewModel
    {
        public string Name { get; set; }

        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public ManageEquipmentTypesViewModel() : this(new List<EquipmentType>()) { }

        public ManageEquipmentTypesViewModel(IEnumerable<EquipmentType> types, IEnumerable<string> errors = null)
        {
            EquipmentTypes = types;
            Errors = errors ?? Enumerable.Empty<string>();
        }
    }
}