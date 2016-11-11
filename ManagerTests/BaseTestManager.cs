using BeerScheduler.Contracts;
using BeerScheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace BeerScheduler.ManagerTests
{
    public class BaseTestManager
    {
        #region Fields

        private IEquipmentAccessor equipmentAccessor;

        #endregion

        #region Properties

        public IEquipmentAccessor EquipmentAccessor
        {
            get
            {
                return equipmentAccessor ?? (equipmentAccessor = Mock.Create<IEquipmentAccessor>());
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}
