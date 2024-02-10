using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Books_BookId",
                table: "shoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Users_UserId",
                table: "shoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts");

            migrationBuilder.RenameTable(
                name: "shoppingCarts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_UserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_BookId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Books_BookId",
                table: "ShoppingCarts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Books_BookId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "shoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_BookId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Books_BookId",
                table: "shoppingCarts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Users_UserId",
                table: "shoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
