using MUSACA.Models;

namespace MUSACA.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MUSACADbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public virtual DbSet<UserReceipt> UserReceipts { get; set; }

        public virtual DbSet<ReceiptOrder> ReceiptOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Order>()
                .HasKey(order => order.Id);

            modelBuilder.Entity<Receipt>()
                .HasKey(receipt => receipt.Id);
            modelBuilder.Entity<Receipt>()
                .HasMany(receipt => receipt.ReceiptOrders);

            base.OnModelCreating(modelBuilder);
        }
    }
}
