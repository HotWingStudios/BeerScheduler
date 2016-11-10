using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.DataContracts
{
    public class EquipmentType
    {
        public long EquipmentTypeId { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}
