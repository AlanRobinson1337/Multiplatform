using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Events.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //adding Events and Comments
        public IDbSet<Event> Events { get; set; }
        public IDbSet<Comment> Comments { get; set; }  
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Events.Web.Models.EventViewModel> EventViewModels { get; set; }
    }
}