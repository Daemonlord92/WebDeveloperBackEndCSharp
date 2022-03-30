using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDeveloperDataLayer.Model;

namespace WebDeveloperVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebDeveloperDataLayer.Model.BugTracker> BugTracker { get; set; }
        public DbSet<WebDeveloperDataLayer.Model.Project> Project { get; set; }
    }
}