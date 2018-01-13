using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PartialFoods.Services.OrderManagementServer.Migrations
{
    public partial class AddActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    OrderID = table.Column<string>(type: "text", nullable: false),
                    ActivityID = table.Column<string>(type: "text", nullable: false),
                    Activity = table.Column<int>(type: "int4", nullable: false),
                    OccuredOn = table.Column<long>(type: "int8", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => new { x.OrderID, x.ActivityID });
                    table.ForeignKey(
                        name: "FK_Activities_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
