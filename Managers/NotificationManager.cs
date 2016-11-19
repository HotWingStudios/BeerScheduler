using BeerScheduler.Contracts;

namespace BeerScheduler.Managers
{
    public class NotificationManager : INotificationManager
    {
        #region Fields

        private ISendGridAccessor sendGridAccessor;

        #endregion

        #region Properties

        public ISendGridAccessor SendGridAccessor
        {
            get
            {
                return sendGridAccessor ?? (sendGridAccessor = Utilities.ClassFactory.CreateClass<ISendGridAccessor>());
            }
            set
            {
                sendGridAccessor = value;
            }
        }

        #endregion

        #region Methods



        #endregion
        public void SendInvitationEmail(string email, string callbackUrl)
        {
            SendGridAccessor.Send(
                email,
                "Time to Get Your Beer Schedule in Order!",
                string.Format(@"<p>You're invited to join a team on BeerScheduler</p>
                    <p><a href='{0}'>Click Here</a> to complete your account activation</p>",callbackUrl)
                );
        }
    }
}
