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

        #endregion

        #region Methods



        #endregion
    }
}