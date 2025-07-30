using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SectionManager_DepartmentId",
                table: "SectionManager");

            migrationBuilder.DropColumn(
                name: "SelectedDepartmentId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SelectedSupervisorId",
                table: "Trainees");

            migrationBuilder.AddColumn<int>(
                name: "SectionManagerId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_DepartmentId",
                table: "SectionManager",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SectionManager_DepartmentId",
                table: "SectionManager");

            migrationBuilder.DropColumn(
                name: "SectionManagerId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "SelectedDepartmentId",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedSupervisorId",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_DepartmentId",
                table: "SectionManager",
                column: "DepartmentId");
        }
    }
}
