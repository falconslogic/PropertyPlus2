using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyPlusApp.Migrations
{
    public partial class Datatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                schema: "Identity",
                table: "MaintenanceRequest",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Priority",
                schema: "Identity",
                table: "MaintenanceRequest",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
