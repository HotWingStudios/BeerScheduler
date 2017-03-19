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

        private IUserManager userManager;

        private INotificationManager notificationManager;

        private IEquipmentScheduleManager equipmentScheduleManager;

        #endregion

        #region Properties

        public INotificationManager NotificationManager
        {
            get
            {
                return notificationManager ?? (notificationManager = ClassFactory.CreateClass<INotificationManager>());
            }
            set
            {
                notificationManager = value;
            }
        }

        public IUserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = ClassFactory.CreateClass<IUserManager>());
            }
            set
            {
                userManager = value;
            }
        }

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

        public IEquipmentScheduleManager EquipmentScheduleManager
        {
            get
            {
                return equipmentScheduleManager ?? (equipmentScheduleManager = ClassFactory.CreateClass<IEquipmentScheduleManager>());
            }

            set
            {
                equipmentScheduleManager = value;
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}