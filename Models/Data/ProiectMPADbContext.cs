using Microsoft.EntityFrameworkCore;

namespace ProiectMPA.Models.Data
{
    public class ProiectMPADbContext : DbContext
    {
        public ProiectMPADbContext(DbContextOptions<ProiectMPADbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = default!;
        public DbSet<MenuItem> MenuItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Address) 
            .WithMany()
            .HasForeignKey(o => o.DeliveryAddress) 
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderStatus>()
                .HasOne(os => os.Employee)
                .WithMany()
                .HasForeignKey(os => os.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
