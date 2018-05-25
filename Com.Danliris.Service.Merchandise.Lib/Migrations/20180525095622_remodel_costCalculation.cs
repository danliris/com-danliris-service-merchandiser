using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.Migrations
{
    public partial class remodel_costCalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.AddColumn<string>(
                name: "Composition",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Construction",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Yarn",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Composition",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "Construction",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "Yarn",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "CostCalculationGarment_Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "CostCalculationGarment_Materials",
                maxLength: 500,
                nullable: true);
        }
    }
}
