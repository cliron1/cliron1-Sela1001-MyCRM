using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCRM.Migrations
{
    public partial class addedCustsTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Custs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Custs");
        }
    }
}
