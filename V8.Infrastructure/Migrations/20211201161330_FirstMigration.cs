using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace V8.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    IDChannel = table.Column<int>(nullable: false),
                    IDPosition = table.Column<int>(nullable: true),
                    IDAgency = table.Column<int>(nullable: false),
                    IDOrgan = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    IdentityNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Birthplace = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Avatar = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IDTeam = table.Column<int>(nullable: true),
                    CountLoginFail = table.Column<int>(nullable: false, defaultValue: 0),
                    HasOrganPermission = table.Column<bool>(nullable: false, defaultValue: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    PhysicalPath = table.Column<string>(maxLength: 1000, nullable: true),
                    FileType = table.Column<int>(nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
