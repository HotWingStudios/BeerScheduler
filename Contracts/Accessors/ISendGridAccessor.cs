using System.ServiceModel;

namespace BeerScheduler.Contracts
{
    [ServiceContract]
    public interface ISendGridAccessor
    {
        [OperationContract]
        void Send(string recipient, string subject, string body);
    }
}
