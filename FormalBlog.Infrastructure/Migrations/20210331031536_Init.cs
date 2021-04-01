using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormalBlog.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Role = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    EmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmailVerificationCodeDate = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ResetPasswordCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ResetPasswordCodeDate = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<int>(type: "int", nullable: false),
                    LastLoginIP = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
