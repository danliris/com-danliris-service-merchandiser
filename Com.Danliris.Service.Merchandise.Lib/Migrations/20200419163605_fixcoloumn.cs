using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.Migrations
{
    public partial class fixcoloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "RO_Garment_SizeBreakdowns",
                type: "bigint",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<long>(
                name: "WageId",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "THRId",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "RateId",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "OTL2Id",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "OTL1Id",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "EfficiencyId",
                table: "CostCalculationGarments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "WageId",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "THRId",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "RateId",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OTL2Id",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OTL1Id",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EfficiencyId",
                table: "CostCalculationGarments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
