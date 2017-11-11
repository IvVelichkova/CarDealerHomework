namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;
    using CarDealer.Data.Models;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
            
        }
      public DbSet<Car> Cars { get; set; }
     
      public DbSet<Supplier> Supplaiers { get; set; }
     
      public DbSet<Sale> Sales { get; set; }
    
      public DbSet<Part> Parts { get; set; }
      
      public DbSet<Customer> Customers { get; set; }
      
      public DbSet<PartCar> PartCar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.CarId);

            builder.Entity<Sale>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(c => c.CustomerId);

            builder.Entity<Supplier>()
                .HasMany(p => p.Parts)
                .WithOne(s => s.Supplaier)
                .HasForeignKey(s => s.SupplaierId);

            builder.Entity<PartCar>()
                .HasKey(pc => new { pc.PartId, pc.CarId });

            builder.Entity<PartCar>()
                .HasOne(p => p.Car)
                .WithMany(c => c.Parts)
                .HasForeignKey(pc => pc.CarId);

            builder.Entity<PartCar>()
                .HasOne(pc => pc.Part)
                .WithMany(p => p.Cars)
                .HasForeignKey(pc => pc.PartId);

            base.OnModelCreating(builder);

        }
    }
}
