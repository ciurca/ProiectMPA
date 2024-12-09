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

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Appetizers", Description = "Start your meal with a delicious appetizer." },
            new Category { Id = 2, Name = "Main Courses", Description = "Hearty and satisfying main courses." },
            new Category { Id = 3, Name = "Desserts", Description = "Sweet treats to end your meal." }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Spring Rolls", ImageURL = "https://www.vegrecipesofindia.com/wp-content/uploads/2015/10/spring-rolls-recipe.jpg", Description = "Crispy rolls with a savory filling.", Price = 5.99m, CategoryId = 1 },
                new MenuItem { Id = 2, Name = "Bruschetta", ImageURL = "https://www.thespruceeats.com/thmb/0SP-Ui3K2C2jL5OkUvIQopCqVHo=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/how-to-make-bruschetta-2020459-hero-01-15950eb2b852461abc9cfbbf536382dd.jpg", Description = "Grilled bread with tomato and basil.", Price = 6.99m, CategoryId = 1 },
                new MenuItem { Id = 3, Name = "Grilled Chicken", ImageURL = "https://www.thespruceeats.com/thmb/x7_ajSUFbjtLdfnIYCEl2Cplhfc=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/chickenmarsala-589de2165f9b58819c883593.jpg", Description = "Juicy grilled chicken with herbs.", Price = 12.99m, CategoryId = 2 },
                new MenuItem { Id = 4, Name = "Spaghetti Carbonara", ImageURL = "https://www.thespruceeats.com/thmb/sUSIS7lVuErRIJHonesrPRjhXQQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/pasta-carbonara-recipe-5210168-hero-01-80090e56abc04ca19d88ebf7fad1d157.jpg", Description = "Classic Italian pasta with creamy sauce.", Price = 10.99m, CategoryId = 2 },
                new MenuItem { Id = 5, Name = "Chocolate Cake", ImageURL = "https://www.thespruceeats.com/thmb/Y-wYwozMefSplJE_SNjFuQHVwOo=/425x300/filters:max_bytes(150000):strip_icc():format(webp)/chocolatelayercake-157558344-56c9e3113df78cfb37910f40.jpg", Description = "Rich and moist chocolate cake.", Price = 6.99m, CategoryId = 3 },
                new MenuItem { Id = 6, Name = "Cheesecake", ImageURL = "https://www.thespruceeats.com/thmb/gYQ1Y9rrhdv-Iul_QRPzQj_Bth4=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/cheesecake-1965daae33964b7e9507301678fd94f0.jpeg", Description = "Creamy cheesecake with a graham cracker crust.", Price = 7.99m, CategoryId = 3 }
            );

            modelBuilder.Entity<Order>()
            .HasOne(o => o.DeliveryAddress) 
            .WithMany()
            .HasForeignKey(o => o.DeliveryAddressId) 
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderStatus>()
                .HasOne(os => os.User)
                .WithMany()
                .HasForeignKey(os => os.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
