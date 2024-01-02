using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptVault.Data.Migrations
{
    public partial class AddEncryptedPasswordAndPatternHashToPasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncryptedPassword",
                table: "Passwords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HashedPattern",
                table: "Passwords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedPassword",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "HashedPattern",
                table: "Passwords");
        }
    }
}
