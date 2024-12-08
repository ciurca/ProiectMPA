using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMPA.Migrations
{
    /// <inheritdoc />
    public partial class NullableItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_OrderId",
                table: "OrderStatuses",
                column: "OrderId",
                unique: true);
        }
    }
}
