using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class RefactoreSupervisorFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Supervisor",
                newName: "SupervisorFullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DepartmentName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorFullName",
                table: "Supervisor",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "Name");
        }
    }
}
