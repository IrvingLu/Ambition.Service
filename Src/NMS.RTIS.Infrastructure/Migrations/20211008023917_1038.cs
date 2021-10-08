using Microsoft.EntityFrameworkCore.Migrations;

namespace NMS.RTIS.Infrastructure.Migrations
{
    public partial class _1038 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Patient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Patient");
        }
    }
}
