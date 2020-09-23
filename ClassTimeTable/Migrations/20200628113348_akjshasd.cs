using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTimeTable.Migrations
{
    public partial class akjshasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "CourseTitle");

            migrationBuilder.RenameColumn(
                name: "CourseNumber",
                table: "Courses",
                newName: "CourseCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseTitle",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Courses",
                newName: "CourseNumber");
        }
    }
}
