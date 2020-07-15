using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.DataAccessLayer.Migrations
{
    public partial class addusernamepassworduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("31845446-a9c9-45fe-b102-bded6b1e0684"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "Name", "NationId", "Password", "Surname", "UserType", "Username" },
                values: new object[] { new Guid("c7615e57-11d4-40f6-8ba2-62ac8413cc45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sajad", "5560021784", "qt!99!s@j@d", "Ramezani", "Developer", "sajad91" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7615e57-11d4-40f6-8ba2-62ac8413cc45"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "Name", "NationId", "Surname", "UserType" },
                values: new object[] { new Guid("31845446-a9c9-45fe-b102-bded6b1e0684"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sajad", "5560021784", "Ramezani", "Developer" });
        }
    }
}
