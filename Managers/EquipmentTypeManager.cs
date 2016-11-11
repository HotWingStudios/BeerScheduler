using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;
using System.Diagnostics;
using BeerScheduler.Utilities;

namespace BeerScheduler.Managers
{
    public class EquipmentTypeManager : BaseManager, IEquipmentTypeManager
    {
        public async Task<bool> DeleteEquipmentType(long equipmentTypeId)
        {
            var equipmentType = await EquipmentTypeAccessor.GetEquipmentType(equipmentTypeId);
            equipmentType.Deleted = true;

            try
            {
                await EquipmentTypeAccessor.SaveEquipmentType(equipmentType);
                Logger.Log($"Equipment type deleted - Id: {equipmentTypeId}", TraceEventType.Information);

                // update the equipment type for existing equipment with the deleted type
                var equipments = await EquipmentAccessor.GetEquipmentByType(equipmentTypeId);
                foreach(var equipment in equipments)
                {
                    try
                    {
                        equipment.EquipmentTypeId = 1;
                        await EquipmentAccessor.SaveEquipment(equipment);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Could not reassign equipment Type - EquipmentId: {equipment.EquipmentId}", TraceEventType.Error, ex);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Could not delete equipment type", TraceEventType.Error, ex);
                return false;
            }
        }

        public async Task<EquipmentType> SaveEquipmentType(EquipmentType equipmentType)
        {
            return await EquipmentTypeAccessor.SaveEquipmentType(equipmentType);
        }

        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypes()
        {
            return await EquipmentTypeAccessor.GetEquipmentTypes();
        }
    }
}
