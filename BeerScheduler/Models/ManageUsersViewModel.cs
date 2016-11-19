using BeerScheduler.DataContracts;
using BeerScheduler.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerScheduler.Web.Models
{
    public class ManageUsersViewModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public long CurrentUserId { get; set; }

        public ManageUsersViewModel()
            : this(Enumerable.Empty<User>(), 0)
        {
        }

        public ManageUsersViewModel(IEnumerable<User> users, long currentUserId, IEnumerable<string> errors = null)
        {
            this.Users = users;
            this.Errors = errors ?? Enumerable.Empty<string>();
            this.CurrentUserId = currentUserId;
        }
    }
}