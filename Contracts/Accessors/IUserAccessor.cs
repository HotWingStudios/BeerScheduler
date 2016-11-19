using BeerScheduler.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Contracts
{
    [ServiceContract]
    public interface IUserAccessor
    {
        #region Methods

        [OperationContract]
        Task<IEnumerable<User>> GetUsersAsync(bool includeDeleted = false);

        [OperationContract]
        IEnumerable<User> GetUsers(bool includeDeleted = false);

        [OperationContract]
        Task<User> GetById(long id);

        [OperationContract]
        Task<User> GetByEmailAsync(string email);

        [OperationContract]
        User GetByEmail(string email);

        [OperationContract]
        Task Save(User user);
        #endregion
    }
}
