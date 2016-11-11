using BeerScheduler.Contracts;
using BeerScheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerScheduler.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Fields

        private IEquipmentManager equipmentManager;

        private IEquipmentTypeManager equipmentTypeManager;

        #endregion

        #region Properties

        public IEquipmentManager EquipmentManager
        {
            get
            {
                return equipmentManager ?? (equipmentManager = ClassFactory.CreateClass<IEquipmentManager>());
            }
            set
            {
                equipmentManager = value;
            }
        }

        public IEquipmentTypeManager EquipmentTypeManager
        {
            get
            {
                return equipmentTypeManager ?? (equipmentTypeManager = ClassFactory.CreateClass<IEquipmentTypeManager>());
            }
            set
            {
                equipmentTypeManager = value;
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}