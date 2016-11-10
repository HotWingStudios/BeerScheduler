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

        #endregion

        #region Methods



        #endregion
    }
}
