using Events.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace LocalTheatre.Models
{
    public class User : IdentityUser

    {


    //    //public int userID { get; set; }
    //    //[Required]
    //    //[Display(Name = "Email Address")]
    //    //public string EmailAddress { get; set; }

    //    public DateTime RegisteredAt { get; set; }

    //    public bool IsSuspended { get; set; }



    //    //navigational

    //    public virtual ICollection<Event> Events { get; set; }



    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> user)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await user.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }

    }
}