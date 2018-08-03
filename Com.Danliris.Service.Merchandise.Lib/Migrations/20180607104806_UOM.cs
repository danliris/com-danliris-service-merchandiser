using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.Migrations
{
    public partial class UOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UOMCode",
                table: "CostCalculationGarments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOMID",
                table: "CostCalculationGarments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOMUnit",
                table: "CostCalculationGarments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOMCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "UOMID",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "UOMUnit",
                table: "CostCalculationGarments");
        }
    }
}
