using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nice_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class collectionsaddeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Employees_EmployeeModelId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_EmployeeModelId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "EmployeeModelId",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CountryId",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeModelId",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_EmployeeModelId",
                table: "Countries",
                column: "EmployeeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Employees_EmployeeModelId",
                table: "Countries",
                column: "EmployeeModelId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
