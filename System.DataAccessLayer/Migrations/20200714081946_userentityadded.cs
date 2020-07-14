using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.DataAccessLayer.Migrations
{
    public partial class userentityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseInfoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 14, 12, 49, 45, 510, DateTimeKind.Local).AddTicks(4077)),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar", maxLength: 60, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar", maxLength: 80, nullable: true),
                    NationId = table.Column<string>(maxLength: 10, nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfoModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BaseInfoModel",
                columns: new[] { "Id", "Description", "Discriminator" },
                values: new object[] { new Guid("2bf5bce6-27a8-4b33-9ba2-7d97245bb4d2"), null, "BaseInfoModel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseInfoModel");
        }
    }
}
