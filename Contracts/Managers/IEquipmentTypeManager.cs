using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Contracts
{
    [ServiceContract]
    public interface IEquipmentTypeManager
    {
        [OperationContract]
        Task<EquipmentType> SaveEquipmentType(EquipmentType equipmentType);

        [OperationContract]
        Task<bool> DeleteEquipmentType(long equipmentTypeId);

        [OperationContract]
        Task<IEnumerable<EquipmentType>> GetEquipmentTypes();
    }
}
