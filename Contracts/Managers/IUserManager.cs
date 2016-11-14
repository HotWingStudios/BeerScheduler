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
    public interface IUserManager
    {
        [OperationContract]
        IEnumerable<User> GetUsers(bool includeDeleted = false);

        [OperationContract]
        Task<User> GetById(long userId);

        [OperationContract]
        Task<User> GetByEmailAsync(string email);

        [OperationContract]
        User GetByEmail(string email);

        [OperationContract]
        Task Save(User user);

        [OperationContract]
        Task Delete(User user);

        [OperationContract]
        Task DeleteById(long id);

        [OperationContract]
        void SendUserInvitation(string email, string callbackUrl);

        [OperationContract]
        void ForgotPassword(string email, string callbackUrl);
    }
}
