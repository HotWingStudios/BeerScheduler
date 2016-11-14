using BeerScheduler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerScheduler.DataContracts;
using System.Data.Entity;

namespace BeerScheduler.Accessors
{
    public class UserAccessor : BaseAccessor, IUserAccessor
    {
        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            using (var db = CreateDatabaseContext())
            {
                return db.Users.FirstOrDefault(x => !x.Deleted && x.Email == email);
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.Users.FirstOrDefaultAsync(x => !x.Deleted && x.Email == email);
            }
        }

        public async Task<User> GetById(long userId)
        {
            using (var db = CreateDatabaseContext())
            {
                return await db.Users.FirstOrDefaultAsync(x => !x.Deleted && x.UserId == userId);
            }
        }

        public IEnumerable<User> GetUsers(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task Save(User user)
        {
            using (var db = CreateDatabaseContext())
            {
                var existingUser = await db.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
                if (existingUser == null)
                {
                    db.Users.Add(user);
                }
                else
                {
                    // update existing user
                    existingUser.AccessFailedCount = user.AccessFailedCount;
                    existingUser.Activated = user.Activated;
                    existingUser.Admin = user.Admin;
                    existingUser.Email = user.Email;
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.PasswordHash = user.PasswordHash;
                    existingUser.SecurityStamp = user.SecurityStamp;
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
