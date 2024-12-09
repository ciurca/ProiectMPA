using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMPA.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_IdentityUser_EmployeeId",
                table: "OrderStatuses");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "OrderStatuses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderStatuses_EmployeeId",
                table: "OrderStatuses",
                newName: "IX_OrderStatuses_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_IdentityUser_UserId",
                table: "OrderStatuses",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_IdentityUser_UserId",
                table: "OrderStatuses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrderStatuses",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderStatuses_UserId",
                table: "OrderStatuses",
                newName: "IX_OrderStatuses_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_IdentityUser_EmployeeId",
                table: "OrderStatuses",
                column: "EmployeeId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
