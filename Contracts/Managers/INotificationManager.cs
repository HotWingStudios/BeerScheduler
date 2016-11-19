using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.Contracts
{
    public interface INotificationManager
    {
        void SendInvitationEmail(string email, string callbackUrl);
    }
}
