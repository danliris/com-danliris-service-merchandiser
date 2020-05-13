using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.Migrations
{
    public partial class fixversimoonlayEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "_CreatedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_CreatedUtc",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_DeletedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_DeletedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_DeletedUtc",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_IsDeleted",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_LastModifiedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_LastModifiedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "_LastModifiedUtc",
                table: "ArticleColors");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "RO_Garments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "RO_Garments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RO_Garments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RO_Garments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "RO_Garments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "RO_Garment_SizeBreakdowns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "RO_Garment_SizeBreakdowns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RO_Garment_SizeBreakdowns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RO_Garment_SizeBreakdowns",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "RO_Garment_SizeBreakdowns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Rates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Lines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "Lines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Lines",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Lines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Efficiencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "Efficiencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Efficiencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Efficiencies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Efficiencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "CostCalculationGarments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "CostCalculationGarments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CostCalculationGarments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "CostCalculationGarments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "CostCalculationGarments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "CostCalculationGarment_Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "CostCalculationGarment_Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CostCalculationGarment_Materials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "CostCalculationGarment_Materials",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "CostCalculationGarment_Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedAgent",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "ArticleColors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedAgent",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "ArticleColors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArticleColors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedAgent",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ArticleColors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "ArticleColors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "RO_Garments");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "RO_Garment_SizeBreakdowns");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "RO_Garment_SizeBreakdown_Details");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Efficiencies");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "CostCalculationGarment_Materials");

            migrationBuilder.DropColumn(
                name: "CreatedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "DeletedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "LastModifiedAgent",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ArticleColors");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "ArticleColors");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "RO_Garments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "RO_Garments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "RO_Garments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "RO_Garments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "RO_Garments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "RO_Garment_SizeBreakdowns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "RO_Garment_SizeBreakdowns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "RO_Garment_SizeBreakdowns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "RO_Garment_SizeBreakdowns",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "RO_Garment_SizeBreakdowns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "RO_Garment_SizeBreakdown_Details",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "RO_Garment_SizeBreakdown_Details",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "RO_Garment_SizeBreakdown_Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "Rates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "Rates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "Rates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "Rates",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "Rates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "Lines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "Lines",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "Efficiencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "Efficiencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "Efficiencies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "Efficiencies",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "Efficiencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "CostCalculationGarments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "CostCalculationGarment_Materials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "CostCalculationGarment_Materials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "CostCalculationGarment_Materials",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "CostCalculationGarment_Materials",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "CostCalculationGarment_Materials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_CreatedAgent",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_CreatedBy",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_CreatedUtc",
                table: "ArticleColors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "_DeletedAgent",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_DeletedBy",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeletedUtc",
                table: "ArticleColors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "_IsDeleted",
                table: "ArticleColors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedAgent",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_LastModifiedBy",
                table: "ArticleColors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_LastModifiedUtc",
                table: "ArticleColors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
