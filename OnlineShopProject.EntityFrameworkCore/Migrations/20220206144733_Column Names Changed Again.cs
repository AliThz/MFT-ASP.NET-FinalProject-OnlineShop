using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopProject.EntityFrameworkCore.Migrations
{
    public partial class ColumnNamesChangedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_BuyerId1",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_SellerId1",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "SellerId1",
                table: "OrderHeader",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "BuyerId1",
                table: "OrderHeader",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_SellerId1",
                table: "OrderHeader",
                newName: "IX_OrderHeader_SellerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Person_SellerId",
                table: "OrderHeader",
                column: "SellerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_BuyerId",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Person_SellerId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "OrderHeader",
                newName: "SellerId1");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderHeader",
                newName: "BuyerId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_SellerId",
                table: "OrderHeader",
                newName: "IX_OrderHeader_SellerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Person_SellerId1",
                table: "OrderHeader",
                column: "SellerId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
