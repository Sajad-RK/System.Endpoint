using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.DataAccessLayer.Migrations
{
    public partial class clientEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7615e57-11d4-40f6-8ba2-62ac8413cc45"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Wallet_NO = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "IsActive", "Mobile", "Name", "Phone", "Wallet_NO" },
                values: new object[] { new Guid("0997a8ca-95cb-4423-be35-42b340c6b447"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Sajad", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientId",
                table: "Users",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clients_ClientId",
                table: "Users",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clients_ClientId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClientId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "Name", "NationId", "Password", "Surname", "UserType", "Username" },
                values: new object[] { new Guid("c7615e57-11d4-40f6-8ba2-62ac8413cc45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sajad", "5560021784", "qt!99!s@j@d", "Ramezani", "Developer", "sajad91" });
        }
    }
}
