using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BeerScheduler.Identity
{
    using Contracts;
    using DataContracts;
    using DontPanic.Helpers;

    public class CustomUserStore : IUserPasswordStore<IdentityUser, long>,
                                   IUserEmailStore<IdentityUser, long>,
                                   IUserLockoutStore<IdentityUser, long>,
                                   IUserSecurityStampStore<IdentityUser, long>,
                                   IUserTwoFactorStore<IdentityUser, long>,
                                   IQueryableUserStore<IdentityUser, long>
    {
        private bool disposed;

        private IUserManager userManager;

        public IUserManager UserManager
        {
            get
            {
                return this.userManager ?? (this.userManager = factory.Proxy<IUserManager>());
            }
        }

        private ProxyFactory factory = new ProxyFactory();
        public ProxyFactory Factory
        {
            get
            {
                factory.LogEnabled = false;
                return factory;
            }

            set { factory = value; }
        }

        ~CustomUserStore()
        {
            this.Dispose(false);
        }

        #region IDisposable implementation

        public void Dispose()
        {
            this.Dispose(true);
            // GC.SuppressFinalize(this);
        }

        #endregion

        #region IUserStore<IdentityUser, long> implementation

        public Task CreateAsync(IdentityUser user)
        {
            return this.UserManager.Save(IdentityUserToUser(user));
        }

        public Task UpdateAsync(IdentityUser user)
        {
            return this.UserManager.Save(IdentityUserToUser(user));
        }

        public Task DeleteAsync(IdentityUser user)
        {
            return this.UserManager.Delete(IdentityUserToUser(user));
        }

        public async Task<IdentityUser> FindByIdAsync(long userId)
        {
            var user = await this.UserManager.GetById(userId);

            return UserToIdentityUser(user);
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var user = await this.UserManager.GetByEmailAsync(userName);

            return UserToIdentityUser(user);
        }

        #endregion

        #region IUserPasswordStore<IdentityUser, long> implementation

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(false);
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        #endregion

        #region IUserLockoutStore<IdentityUser, long> implementation

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            return Task.FromResult(user.LockoutEndDateUtc);
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd;

            return Task.FromResult(false);
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult(user.AccessFailedCount++);
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult(user.AccessFailedCount = 0);
        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }


        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            return Task.FromResult(true);
        }


        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            return Task.FromResult(false);
        }

        #endregion

        #region IUserSecurityStampStore<IdentityUser, long> implementation

        public Task SetSecurityStampAsync(IdentityUser user, string stamp)
        {
            return Task.FromResult(user.SecurityStamp = stamp);
        }

        /// <summary>
        /// Get the user security stamp
        /// 
        /// </summary>
        /// <param name="user"/>
        /// <returns/>
        public Task<string> GetSecurityStampAsync(IdentityUser user)
        {
            return Task.FromResult(user.SecurityStamp ?? string.Empty);
        }

        #endregion

        #region IUserEmailStore<IdentityUser, long> implementation

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            return Task.FromResult(user.Email = email);
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            return Task.FromResult(user.Activated);
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            return Task.FromResult(user.Activated = confirmed);
        }

        public async Task<IdentityUser> FindByEmailAsync(string email)
        {
            var user = await this.UserManager.GetByEmailAsync(email);

            return UserToIdentityUser(user);
        }

        #endregion

        #region IQueryableUserStore<IdentityUser, long>

        public IQueryable<IdentityUser> Users
        {
            get
            {
                return Enumerable.Empty<IdentityUser>().AsQueryable();
                // return this.UserManager.GetUsers().Select(UserToIdentityUser).AsQueryable();
            }
        }


        #endregion

        #region IUserTwoFactorStore<IdentityUser, long> implementation

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;

            // NOTE: There is nothing to dispose of in this object for now, 
            //       but if that changes it should be done here.
        }

        private static IdentityUser UserToIdentityUser(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new IdentityUser
            {
                AccessFailedCount = user.AccessFailedCount,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Activated = user.Activated,
                SecurityStamp = user.SecurityStamp,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                Deleted = user.Deleted,
                UserId = user.UserId,
                PasswordHash = user.PasswordHash,
                Admin = user.Admin
            };
        }

        private static User IdentityUserToUser(IdentityUser user)
        {
            if (user == null)
            {
                return null;
            }

            return new User
            {
                AccessFailedCount = user.AccessFailedCount,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Activated = user.Activated,
                SecurityStamp = user.SecurityStamp,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                Deleted = user.Deleted,
                UserId = user.UserId,
                PasswordHash = user.PasswordHash,
                Admin = user.Admin
            };
        }
    }
}