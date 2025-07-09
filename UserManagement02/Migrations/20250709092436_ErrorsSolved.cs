using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class ErrorsSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Supervisors");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Supervisors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Supervisors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Supervisors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Supervisors",
                newName: "DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Supervisors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Supervisors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Supervisors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors",
                column: "SupervisorId");
        }
    }
}
