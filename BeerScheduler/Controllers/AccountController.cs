using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BeerScheduler.Models;
using BeerScheduler.Identity;
using BeerScheduler.Managers;
using BeerScheduler.Web.Controllers;

namespace BeerScheduler.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        #region FIELDS

        private ApplicationUserManager identityUserManager;

        private ApplicationSignInManager signInManager;

        #endregion

        #region Properties

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager IdentityUserManager
        {
            get
            {
                return this.identityUserManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                this.identityUserManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        #endregion

        #region Methods
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var user = await UserManager.GetByEmailAsync(model.Email);
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                default:
                    this.ModelState.AddModelError("", "Invalid login attempt.");
                    return this.View(model);
            }
        }

        //[AllowAnonymous]
        //public ActionResult Registration(long userId, string code)
        //{
        //    var model = new RegistrationViewModel { UserId = userId, Code = code };
        //    return View(model);
        //}

        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<ActionResult> Registration(RegistrationViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //        return this.View(model);

        //    var user = await IdentityUserManager.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return this.RedirectToAction("Login", "Account");
        //    }
        //    var result = await IdentityUserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        user = await IdentityUserManager.FindByNameAsync(model.Email);

        //        // Update the user so we know they have been activated
        //        user.Activated = true;
        //        user.FirstName = model.FirstName;
        //        user.LastName = model.LastName;
        //        user.Phone = model.Phone;

        //        await IdentityUserManager.UpdateAsync(user);

        //        // Automatic sign in after password has been reset
        //        SignInManager.SignIn(user, false, false);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //    return View(model);
        //}

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.IdentityUserManager.FindByNameAsync(model.Email);
                if (user == null || !await this.IdentityUserManager.IsEmailConfirmedAsync(user.Id))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return this.View("ForgotPasswordConfirmation");
                }

                if (this.Request.Url == null)
                {
                    // This should never happen
                    return null;
                }

                string code = await this.IdentityUserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = this.Url.Action(
                    "ResetPassword",
                    "Account",
                    new { userId = user.Id, code },
                    protocol: this.Request.Url.Scheme);

                UserManager.ForgotPassword(user.Email, callbackUrl);
                return this.RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(int userId, string code)
        {
            if (!this.IdentityUserManager.VerifyUserToken(userId, "ResetPassword", code))
            {
                return this.RedirectToAction("Login");
            }

            return code == null ? this.View("Error") : this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await IdentityUserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return this.RedirectToAction("Login", "Account");
            }
            var result = await IdentityUserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                user = await this.IdentityUserManager.FindByNameAsync(model.Email);

                // Update the user so we know they have been activated
                user.Activated = true;
                await this.IdentityUserManager.UpdateAsync(user);

                // Automatic sign in after password has been reset
                this.SignInManager.SignIn(user, false, false);
                return this.RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
            return this.View();
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }
        
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var result = await this.IdentityUserManager.ChangePasswordAsync(this.User.Identity.GetUserId<long>(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.IdentityUserManager.FindByIdAsync(this.User.Identity.GetUserId<long>());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return this.RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.View(model);
        }

        public ActionResult Logout()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return this.RedirectToAction("Login", "Account");
        }
        #endregion
    }
}