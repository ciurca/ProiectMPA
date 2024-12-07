using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMPA.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAddressChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_IdentityUser_UserId1",
                table: "DeliveryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAddresses_UserId1",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "DeliveryAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DeliveryAddresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_UserId",
                table: "DeliveryAddresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_IdentityUser_UserId",
                table: "DeliveryAddresses",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_IdentityUser_UserId",
                table: "DeliveryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAddresses_UserId",
                table: "DeliveryAddresses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DeliveryAddresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "DeliveryAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_UserId1",
                table: "DeliveryAddresses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_IdentityUser_UserId1",
                table: "DeliveryAddresses",
                column: "UserId1",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
