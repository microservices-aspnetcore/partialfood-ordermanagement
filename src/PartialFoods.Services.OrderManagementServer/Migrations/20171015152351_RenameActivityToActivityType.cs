using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PartialFoods.Services.OrderManagementServer.Migrations
{
    public partial class RenameActivityToActivityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityType",
                table: "Activities",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "Activity",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }
    }
}
