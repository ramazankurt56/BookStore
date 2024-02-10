using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderStatuses",
                table: "orderStatuses");

            migrationBuilder.RenameTable(
                name: "orderStatuses",
                newName: "OrderStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses");

            migrationBuilder.RenameTable(
                name: "OrderStatuses",
                newName: "orderStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderStatuses",
                table: "orderStatuses",
                column: "Id");
        }
    }
}
