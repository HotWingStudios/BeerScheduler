using BeerScheduler.Contracts;
using BeerScheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Managers
{
    public class BaseManager
    {
        #region Fields

        private IEquipmentAccessor equipmentAccessor;

        private IEquipmentTypeAccessor equipmentTypeAccessor;

        #endregion

        #region Properties

        public IEquipmentAccessor EquipmentAccessor
        {
            get
            {
                return equipmentAccessor ?? (equipmentAccessor = ClassFactory.CreateClass<IEquipmentAccessor>());
            }
            set
            {
                equipmentAccessor = value;
            }
        }

        public IEquipmentTypeAccessor EquipmentTypeAccessor
        {
            get
            {
                return equipmentTypeAccessor ?? (equipmentTypeAccessor = ClassFactory.CreateClass<IEquipmentTypeAccessor>());
            }
            set
            {
                equipmentTypeAccessor = value;
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}
