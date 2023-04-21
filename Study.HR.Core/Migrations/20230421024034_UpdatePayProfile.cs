using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.HR.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayProfile_Employee_EmployeeId1",
                table: "PayProfile");

            migrationBuilder.DropIndex(
                name: "IX_PayProfile_EmployeeId1",
                table: "PayProfile");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "PayProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "PayProfile",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayProfile_EmployeeId1",
                table: "PayProfile",
                column: "EmployeeId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PayProfile_Employee_EmployeeId1",
                table: "PayProfile",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
