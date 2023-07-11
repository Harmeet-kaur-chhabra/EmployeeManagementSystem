using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_designation_DesignationId",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_designation",
                table: "designation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "designation",
                newName: "designations");

            migrationBuilder.RenameTable(
                name: "department",
                newName: "departments");

            migrationBuilder.RenameIndex(
                name: "IX_employee_DesignationId",
                table: "employees",
                newName: "IX_employees_DesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_DepartmentId",
                table: "employees",
                newName: "IX_employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_designations",
                table: "designations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_designations_DesignationId",
                table: "employees",
                column: "DesignationId",
                principalTable: "designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_designations_DesignationId",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_designations",
                table: "designations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "designations",
                newName: "designation");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "department");

            migrationBuilder.RenameIndex(
                name: "IX_employees_DesignationId",
                table: "employee",
                newName: "IX_employee_DesignationId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_DepartmentId",
                table: "employee",
                newName: "IX_employee_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_designation",
                table: "designation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_designation_DesignationId",
                table: "employee",
                column: "DesignationId",
                principalTable: "designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
