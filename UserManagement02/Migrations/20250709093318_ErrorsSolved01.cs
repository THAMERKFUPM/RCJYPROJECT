using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class ErrorsSolved01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AppUsers",
                newName: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "AppUsers",
                newName: "AppUserId");
        }
    }
}
