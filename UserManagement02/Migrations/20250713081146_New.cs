using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Supervisors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_DepartmentId",
                table: "Supervisors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_DepartmentId1",
                table: "Supervisors",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId",
                table: "Supervisors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId1",
                table: "Supervisors",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId",
                table: "Supervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId1",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_DepartmentId",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_DepartmentId1",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Supervisors");
        }
    }
}
