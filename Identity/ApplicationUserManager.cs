using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BeerScheduler.Identity
{
    public class ApplicationUserManager : UserManager<IdentityUser, long>
    {
        public ApplicationUserManager(IUserStore<IdentityUser, long> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
       {
            var manager = new ApplicationUserManager(new CustomUserStore());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<IdentityUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUser, long>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUser, long>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            // manager.EmailService = new EmailService();
            // manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<IdentityUser, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            var users = manager.Users;

            // if there's no admin user, create one
            if (!manager.Users.Any())
            {
                var user = new IdentityUser { UserName = "support@beerscheduler.com", Email = "support@beerscheduler.com", Activated = true, Admin = true };
                manager.Create(user, "Password1!");
            }

            return manager;
        }
    }
}
