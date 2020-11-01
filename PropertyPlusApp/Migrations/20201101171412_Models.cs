using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyPlusApp.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                schema: "Identity",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPayments = table.Column<int>(nullable: true),
                    TotalPaid = table.Column<int>(nullable: true),
                    TotalLate = table.Column<int>(nullable: true),
                    TotalMonths = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyLeaser",
                schema: "Identity",
                columns: table => new
                {
                    LeaserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyLeaser", x => x.LeaserId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwner",
                schema: "Identity",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                schema: "Identity",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: false),
                    LeaserId = table.Column<int>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SquareFeet = table.Column<int>(nullable: true),
                    Bedrooms = table.Column<int>(nullable: true),
                    Baths = table.Column<double>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    MonthlyRate = table.Column<int>(nullable: true),
                    Utilities = table.Column<string>(nullable: true),
                    ContractTime = table.Column<string>(nullable: true),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_PropertyLeaser_LeaserId",
                        column: x => x.LeaserId,
                        principalSchema: "Identity",
                        principalTable: "PropertyLeaser",
                        principalColumn: "LeaserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_PropertyOwner_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Identity",
                        principalTable: "PropertyOwner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_PaymentHistory_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "Identity",
                        principalTable: "PaymentHistory",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequest",
                schema: "Identity",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Documents = table.Column<string>(nullable: true),
                    Priority = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequest", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequest_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "Identity",
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequest_PropertyId",
                schema: "Identity",
                table: "MaintenanceRequest",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_LeaserId",
                schema: "Identity",
                table: "Property",
                column: "LeaserId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                schema: "Identity",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PaymentId",
                schema: "Identity",
                table: "Property",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRequest",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Property",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PropertyLeaser",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PropertyOwner",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PaymentHistory",
                schema: "Identity");
        }
    }
}
