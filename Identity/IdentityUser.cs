using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BeerScheduler.Identity
{
    using DataContracts;
    using System.Security.Claims;

    public class IdentityUser : User, IUser<long>
    {
        public long Id
        {
            get
            {
                return this.UserId;
            }
        }

        public string UserName
        {
            get
            {
                return this.Email;
            }

            set
            {
                this.Email = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<IdentityUser, long> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public User ToUser()
        {
            return new User
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Deleted = this.Deleted,
                UserId = this.UserId,
                PasswordHash = this.PasswordHash,
                SecurityStamp = this.SecurityStamp,
                Admin = this.Admin,
                AccessFailedCount = this.AccessFailedCount,
                Activated = this.Activated,
                LockoutEndDateUtc = this.LockoutEndDateUtc
            };
        }
    }
}
