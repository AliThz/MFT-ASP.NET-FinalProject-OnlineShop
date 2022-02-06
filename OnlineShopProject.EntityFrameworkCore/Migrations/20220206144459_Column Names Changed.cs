using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopProject.EntityFrameworkCore.Migrations
{
    public partial class ColumnNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_BuyerId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderHeader",
                newName: "BuyerId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_BuyerId",
                table: "OrderHeader",
                newName: "IX_OrderHeader_BuyerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Person_BuyerId1",
                table: "OrderHeader",
                column: "BuyerId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_BuyerId1",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "BuyerId1",
                table: "OrderHeader",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_BuyerId1",
                table: "OrderHeader",
                newName: "IX_OrderHeader_BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Person_BuyerId",
                table: "OrderHeader",
                column: "BuyerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
