using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;

namespace BeerScheduler.Managers
{
    public class UserManager : BaseManager, IUserManager
    {
        public async Task Delete(User user)
        {
            user.Deleted = true;
            await UserAccessor.Save(user);
        }

        public async Task DeleteById(long id)
        {
            await UserAccessor.DeleteById(id);
        }

        public void ForgotPassword(string email, string callbackUrl)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return UserAccessor.GetByEmail(email);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await UserAccessor.GetByEmailAsync(email);
        }

        public async Task<User> GetById(long userId)
        {
            return await UserAccessor.GetById(userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool includeDeleted = false)
        {
            return await UserAccessor.GetUsersAsync(includeDeleted);
        }

        public IEnumerable<User> GetUsers(bool includeDeleted = false)
        {
            return UserAccessor.GetUsers(includeDeleted);
        }

        public async Task Save(User user)
        {
            await UserAccessor.Save(user);
        }

        public async Task SendUserInvitation(string email, string callbackUrl)
        {
            throw new NotImplementedException();
        }
    }
}
