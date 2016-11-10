using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Contracts
{
    public interface IEquipmentAccessor
    {
        Task<Equipment> SaveEquipment(Equipment equipment);

        Task<Equipment> GetEquipment(long equipmentId);
    }
}
