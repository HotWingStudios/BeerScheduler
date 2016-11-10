using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.DataContracts
{
    public class Equipment
    {
        public long EquipmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long EquipmentTypeId { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public DateTime DateAquired { get; set; }

        public virtual List<EquipmentSchedule> Schedule { get; set; }

        public bool Deleted { get; set; }
    }
}
