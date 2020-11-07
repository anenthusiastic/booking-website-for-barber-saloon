using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public class BarberContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source = BookingDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                    .HasKey(c => new { c.CategoryId, c.ProductId });

            modelBuilder.Entity<BookingService>()
                    .HasKey(c => new { c.BookingId, c.ServiceId });
            
        }
    }
}