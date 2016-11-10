using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.DataContracts
{
    public class EquipmentSchedule
    {
        public long EquipmentScheduleId { get; set; }

        public long EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Deleted { get; set; }
    }
}
