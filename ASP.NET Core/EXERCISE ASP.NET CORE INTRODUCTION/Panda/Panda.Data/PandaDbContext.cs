using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;

namespace Panda.Data
{
    public class PandaDbContext : IdentityDbContext
    {
        public DbSet<Package> Packages { get; set; }

        public DbSet<PandaUser> PandaUsers { get; set; }

        public DbSet<PandaUserRole> PandaUsersRoles { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {
        }
    }
}
