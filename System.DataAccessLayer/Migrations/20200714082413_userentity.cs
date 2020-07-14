using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.DataAccessLayer.Migrations
{
    public partial class userentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseInfoModel",
                table: "BaseInfoModel");

            migrationBuilder.DeleteData(
                table: "BaseInfoModel",
                keyColumn: "Id",
                keyValue: new Guid("2bf5bce6-27a8-4b33-9ba2-7d97245bb4d2"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseInfoModel");

            migrationBuilder.RenameTable(
                name: "BaseInfoModel",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 14, 12, 49, 45, 510, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "Name", "NationId", "Surname", "UserType" },
                values: new object[] { new Guid("e869f991-63f8-4602-93ad-009abf2d08e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, null, "0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e869f991-63f8-4602-93ad-009abf2d08e3"));

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BaseInfoModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "BaseInfoModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BaseInfoModel",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BaseInfoModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 14, 12, 49, 45, 510, DateTimeKind.Local).AddTicks(4077),
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseInfoModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseInfoModel",
                table: "BaseInfoModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BaseInfoModel",
                columns: new[] { "Id", "Description", "Discriminator" },
                values: new object[] { new Guid("2bf5bce6-27a8-4b33-9ba2-7d97245bb4d2"), null, "BaseInfoModel" });
        }
    }
}
