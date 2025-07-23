using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class changeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_AspNetUsers_AppUserId",
                table: "Supervisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId1",
                table: "Supervisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Departments_DepartmentId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Supervisor_SupervisorId",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisor",
                table: "Supervisor");

            migrationBuilder.RenameTable(
                name: "Trainee",
                newName: "Trainees");

            migrationBuilder.RenameTable(
                name: "Supervisor",
                newName: "Supervisors");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_SupervisorId",
                table: "Trainees",
                newName: "IX_Trainees_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_DepartmentId",
                table: "Trainees",
                newName: "IX_Trainees_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisor_DepartmentId1",
                table: "Supervisors",
                newName: "IX_Supervisors_DepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisor_AppUserId",
                table: "Supervisors",
                newName: "IX_Supervisors_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees",
                column: "TraineeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_AspNetUsers_AppUserId",
                table: "Supervisors",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId1",
                table: "Supervisors",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Supervisors_SupervisorId",
                table: "Trainees",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_AspNetUsers_AppUserId",
                table: "Supervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Departments_DepartmentId1",
                table: "Supervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Supervisors_SupervisorId",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors");

            migrationBuilder.RenameTable(
                name: "Trainees",
                newName: "Trainee");

            migrationBuilder.RenameTable(
                name: "Supervisors",
                newName: "Supervisor");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_SupervisorId",
                table: "Trainee",
                newName: "IX_Trainee_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_DepartmentId",
                table: "Trainee",
                newName: "IX_Trainee_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisors_DepartmentId1",
                table: "Supervisor",
                newName: "IX_Supervisor_DepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisors_AppUserId",
                table: "Supervisor",
                newName: "IX_Supervisor_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee",
                column: "TraineeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisor",
                table: "Supervisor",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_AspNetUsers_AppUserId",
                table: "Supervisor",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Departments_DepartmentId1",
                table: "Supervisor",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Departments_DepartmentId",
                table: "Trainee",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Supervisor_SupervisorId",
                table: "Trainee",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
