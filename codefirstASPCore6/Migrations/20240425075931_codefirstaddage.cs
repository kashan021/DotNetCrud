using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codefirstASPCore6.Migrations
{
    public partial class codefirstaddage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Students");
        }
    }
}
