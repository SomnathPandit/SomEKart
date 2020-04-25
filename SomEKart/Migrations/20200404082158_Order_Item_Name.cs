using Microsoft.EntityFrameworkCore.Migrations;

namespace SomEKart.Migrations
{
    public partial class Order_Item_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OrderItems");
        }
    }
}
