﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement02.Migrations
{
    /// <inheritdoc />
    public partial class AddEvaluationScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Evaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Evaluations");
        }
    }
}
