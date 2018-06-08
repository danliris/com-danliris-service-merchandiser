using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.Migrations
{
    public partial class addAutoIncrementCostCalculation_Material : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PO_SerialNumber",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoIncrementNumber",
                table: "CostCalculationGarment_Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Convection",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoIncrementNumber",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "Convection",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.AlterColumn<int>(
                name: "PO_SerialNumber",
                table: "CostCalculationGarment_Materials",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
