using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParkEFI.Crosscutting.Identity.Models
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public const string SCHEMA = "Id5";

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(SCHEMA);
        }
    }
}
