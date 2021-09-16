using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetSandBox.Migrations
{
    public partial class AddPurchasePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Book",
                newName: "PurchasePrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Book",
                newName: "Price");
        }
    }
}
