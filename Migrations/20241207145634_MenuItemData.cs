using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProiectMPA.Migrations
{
    /// <inheritdoc />
    public partial class MenuItemData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Start your meal with a delicious appetizer.", "Appetizers" },
                    { 2, "Hearty and satisfying main courses.", "Main Courses" },
                    { 3, "Sweet treats to end your meal.", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Crispy rolls with a savory filling.", "https://www.vegrecipesofindia.com/wp-content/uploads/2015/10/spring-rolls-recipe.jpg", "Spring Rolls", 5.99m },
                    { 2, 1, "Grilled bread with tomato and basil.", "https://www.thespruceeats.com/thmb/0SP-Ui3K2C2jL5OkUvIQopCqVHo=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/how-to-make-bruschetta-2020459-hero-01-15950eb2b852461abc9cfbbf536382dd.jpg", "Bruschetta", 6.99m },
                    { 3, 2, "Juicy grilled chicken with herbs.", "https://www.thespruceeats.com/thmb/x7_ajSUFbjtLdfnIYCEl2Cplhfc=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/chickenmarsala-589de2165f9b58819c883593.jpg", "Grilled Chicken", 12.99m },
                    { 4, 2, "Classic Italian pasta with creamy sauce.", "https://www.thespruceeats.com/thmb/sUSIS7lVuErRIJHonesrPRjhXQQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/pasta-carbonara-recipe-5210168-hero-01-80090e56abc04ca19d88ebf7fad1d157.jpg", "Spaghetti Carbonara", 10.99m },
                    { 5, 3, "Rich and moist chocolate cake.", "https://www.thespruceeats.com/thmb/Y-wYwozMefSplJE_SNjFuQHVwOo=/425x300/filters:max_bytes(150000):strip_icc():format(webp)/chocolatelayercake-157558344-56c9e3113df78cfb37910f40.jpg", "Chocolate Cake", 6.99m },
                    { 6, 3, "Creamy cheesecake with a graham cracker crust.", "https://www.thespruceeats.com/thmb/gYQ1Y9rrhdv-Iul_QRPzQj_Bth4=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/cheesecake-1965daae33964b7e9507301678fd94f0.jpeg", "Cheesecake", 7.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
