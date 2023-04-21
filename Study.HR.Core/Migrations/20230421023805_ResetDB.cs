using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Study.HR.Core.Migrations
{
    /// <inheritdoc />
    public partial class ResetDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetail");

            migrationBuilder.DropTable(
                name: "SalaryRecord");

            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EnteredDate",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "SalaryType",
                table: "Employee",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "SalaryCurrency",
                table: "Employee",
                newName: "RetireReason");

            migrationBuilder.RenameColumn(
                name: "LoginPassword",
                table: "Employee",
                newName: "ResidentNumber");

            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "Employee",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "CareerTypeId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHouseOwner",
                table: "Employee",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobPositionId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RetireDate",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CareerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    SalaryType = table.Column<string>(type: "text", nullable: true),
                    BaseSalary = table.Column<double>(type: "double precision", nullable: false),
                    SalaryCurrency = table.Column<string>(type: "text", nullable: true),
                    BonusRate = table.Column<double>(type: "double precision", nullable: false),
                    EmployeeId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayProfile_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayProfile_Employee_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    MinutesWorked = table.Column<int>(type: "integer", nullable: false),
                    BaseSalary = table.Column<double>(type: "double precision", nullable: false),
                    BonusRate = table.Column<double>(type: "double precision", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    WorkTimeId = table.Column<int>(type: "integer", nullable: false),
                    PayProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payroll_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payroll_PayProfile_PayProfileId",
                        column: x => x.PayProfileId,
                        principalTable: "PayProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payroll_WorkTime_WorkTimeId",
                        column: x => x.WorkTimeId,
                        principalTable: "WorkTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CareerTypeId",
                table: "Employee",
                column: "CareerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employee",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobPositionId",
                table: "Employee",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobRoleId",
                table: "Employee",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PayProfile_EmployeeId",
                table: "PayProfile",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayProfile_EmployeeId1",
                table: "PayProfile",
                column: "EmployeeId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeId",
                table: "Payroll",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_PayProfileId",
                table: "Payroll",
                column: "PayProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_WorkTimeId",
                table: "Payroll",
                column: "WorkTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CareerType_CareerTypeId",
                table: "Employee",
                column: "CareerTypeId",
                principalTable: "CareerType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmploymentType_EmploymentTypeId",
                table: "Employee",
                column: "EmploymentTypeId",
                principalTable: "EmploymentType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobPosition_JobPositionId",
                table: "Employee",
                column: "JobPositionId",
                principalTable: "JobPosition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobRole_JobRoleId",
                table: "Employee",
                column: "JobRoleId",
                principalTable: "JobRole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CareerType_CareerTypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmploymentType_EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobPosition_JobPositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobRole_JobRoleId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "CareerType");

            migrationBuilder.DropTable(
                name: "EmploymentType");

            migrationBuilder.DropTable(
                name: "JobPosition");

            migrationBuilder.DropTable(
                name: "JobRole");

            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropTable(
                name: "PayProfile");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CareerTypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobPositionId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobRoleId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CareerTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsHouseOwner",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobPositionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RetireDate",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Employee",
                newName: "SalaryType");

            migrationBuilder.RenameColumn(
                name: "RetireReason",
                table: "Employee",
                newName: "SalaryCurrency");

            migrationBuilder.RenameColumn(
                name: "ResidentNumber",
                table: "Employee",
                newName: "LoginPassword");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employee",
                newName: "LoginId");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalary",
                table: "Employee",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EnteredDate",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EmployeeDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Desc = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDetail_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    BaseSalary = table.Column<double>(type: "double precision", nullable: false),
                    BonusRate = table.Column<double>(type: "double precision", nullable: false),
                    ValidAfter = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidBefore = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeSalaryId = table.Column<int>(type: "integer", nullable: false),
                    WorkTimeId = table.Column<int>(type: "integer", nullable: false),
                    BaseSalary = table.Column<double>(type: "double precision", nullable: false),
                    BonusRate = table.Column<double>(type: "double precision", nullable: false),
                    MinutesWorked = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryRecord_EmployeeSalary_EmployeeSalaryId",
                        column: x => x.EmployeeSalaryId,
                        principalTable: "EmployeeSalary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryRecord_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryRecord_WorkTime_WorkTimeId",
                        column: x => x.WorkTimeId,
                        principalTable: "WorkTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetail_EmployeeId",
                table: "EmployeeDetail",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecord_EmployeeId",
                table: "SalaryRecord",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecord_EmployeeSalaryId",
                table: "SalaryRecord",
                column: "EmployeeSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecord_WorkTimeId",
                table: "SalaryRecord",
                column: "WorkTimeId");
        }
    }
}
