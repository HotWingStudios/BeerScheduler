using BeerScheduler.DataContracts;
using BeerScheduler.Identity;
using BeerScheduler.Utilities;
using BeerScheduler.Web.Controllers;
using BeerScheduler.Web.Models;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeerScheduler.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Fields

        private ApplicationUserManager appUserManager;

        #endregion

        #region Properties

        public ApplicationUserManager ApplicationUserManager
        {
            get
            {
                return this.appUserManager
                       ?? (this.appUserManager =
                           this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }

            set
            {
                this.appUserManager = value;
            }
        }

        #endregion

        #region Methods



        #endregion

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

        public async Task<ActionResult> ManageEquipment()
        {
            var model = new ManageEquipmentViewModel(await EquipmentManager.GetAllEquipment());
            
            return View(model);
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

        public async Task<ActionResult> ManageUsers()
        {
            var users = await UserManager.GetUsersAsync();
            var model = new ManageUsersViewModel(users, this.User.Identity.GetUserId<long>());
            

            return View(model);
        }

        public async Task<ActionResult> AddUser(string email)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add("Email cannot be left empty.");
            }
            else if (this.ModelState.IsValid)
            {
                // create a new user based on user type
                var user = new IdentityUser { Email = email };

                var result = await this.ApplicationUserManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors);
                }
                else
                {
                    user = await this.ApplicationUserManager.FindByEmailAsync(email);
                    var code = await this.ApplicationUserManager.GeneratePasswordResetTokenAsync(user.Id);

                    if (this.Request == null || this.Request.Url == null)
                    {
                        // This should never happen
                        return null;
                    }

                    var callbackUrl = this.Url.Action(
                        "ResetPassword",
                        "Account",
                        new { userId = user.Id, code },
                        this.Request.Url.Scheme);


                    NotificationManager.SendInvitationEmail(user.ToUser().Email, callbackUrl);
                }
            }
            else
            {
                errors.Add("You must submit a valid email address.");
            }

            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(long userId)
        {
            var user = await this.ApplicationUserManager.FindByIdAsync(userId);
            var result = await this.ApplicationUserManager.DeleteAsync(user);

            var errors = result.Errors.ToList();

            this.TempData["ErrorList"] = errors;

            // return based on admin Type
            return this.RedirectToAction("ManageUsers");
        }

        public async Task<ActionResult> AddEquipment()
        {
            var model = new AddEquipmentModel();
            model.EquipmentTypes = await EquipmentTypeManager.GetEquipmentTypes();
            model.OptionList = from m in model.EquipmentTypes select new SelectListItem {Text = m.Name, Value = m.EquipmentTypeId.ToString() };
            return View(model);
        }

        public ActionResult EditEquipment(long equipmentId = 0)
        {
            if(equipmentId == 0)
            {
                return RedirectToAction("ManageEquipment");
            }
            return View();
        }

        public async Task<ActionResult> DeleteEquipment(long equipmentId)
        {
            await EquipmentManager.DeleteEquipment(equipmentId); 

            return RedirectToAction("ManageEquipment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewEquipment(string name, string description, string date, string equipmentType)
        {
            Equipment temp = new Equipment();
            try
            {
                temp.EquipmentTypeId = Convert.ToInt64(equipmentType);
                temp.DateAquired = DateTime.Parse(date);
                temp.Description = description;
                temp.Name = name;
            }catch(Exception e)
            {
                return RedirectToAction("AddEquipment");
            }
            await EquipmentManager.SaveEquipment(temp);
            return RedirectToAction("ManageEquipment");
        }
    }
}