using BeerScheduler.DataContracts;
using BeerScheduler.Utilities;
using BeerScheduler.Web.Controllers;
using BeerScheduler.Web.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeerScheduler.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> ManageEquipmentTypes()
        {
            var model = new ManageEquipmentTypesViewModel();

            model.EquipmentTypes = await EquipmentTypeManager.GetEquipmentTypes();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEquipmentType(string name)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Type name cannot be left empty.");
            }
            else if (this.ModelState.IsValid)
            {
                // implement save type
                var equipmentType = new EquipmentType
                {
                    Name = name
                };

                await EquipmentTypeManager.SaveEquipmentType(equipmentType);
            }

            var model = new ManageEquipmentTypesViewModel();
            model.EquipmentTypes = await EquipmentTypeManager.GetEquipmentTypes();
            return View("ManageEquipmentTypes", model);
        }

        public async Task<ActionResult> DeleteEquipmentType(long equipmentTypeId)
        {
            await EquipmentTypeManager.DeleteEquipmentType(equipmentTypeId);

            return RedirectToAction("ManageEquipmentTypes");
        }
    }
}