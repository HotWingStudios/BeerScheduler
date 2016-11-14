using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeerScheduler.DataContracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string SecurityStamp { get; set; }

        [DataMember]
        public DateTimeOffset LockoutEndDateUtc { get; set; }

        [DataMember]
        public int AccessFailedCount { get; set; }

        [DataMember]
        public bool Admin { get; set; }

        [DataMember]
        public bool Deleted { get; set; }

        [DataMember]
        public bool Activated { get; set; }
    }
}
