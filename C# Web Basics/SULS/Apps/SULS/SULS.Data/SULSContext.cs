using SULS.Models;

namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SULSContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submission { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Problem>()
            //    .HasKey(problem => problem.Id);

            //modelBuilder.Entity<Problem>()
            //    .HasMany(x => x.Submissions)
            //    .WithOne(x => x.Problem);

            //modelBuilder.Entity<Submission>()
            //    .HasKey(submission => submission.Id);

            //modelBuilder.Entity<User>()
            //    .HasKey(user => user.Id);

            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Submissions)
            //    .WithOne(x => x.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}