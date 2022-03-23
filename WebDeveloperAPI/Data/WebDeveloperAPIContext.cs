#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDeveloperDataLayer.Model;

namespace WebDeveloperAPI.Data
{
    public class WebDeveloperAPIContext : DbContext
    {
        public WebDeveloperAPIContext (DbContextOptions<WebDeveloperAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebDeveloperDataLayer.Model.Project> Project { get; set; }

        public DbSet<WebDeveloperDataLayer.Model.BugTracker> BugTracker { get; set; }
    }
}
