using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class AssignSupervisor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId",
                table: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Supervisor_DepartmentId",
                table: "Supervisor");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Supervisor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_DepartmentId1",
                table: "Supervisor",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                unique: true,
                filter: "[SupervisorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId1",
                table: "Supervisor",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId1",
                table: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Supervisor_DepartmentId1",
                table: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Departments_SupervisorId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Supervisor");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_DepartmentId",
                table: "Supervisor",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId",
                table: "Supervisor",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
