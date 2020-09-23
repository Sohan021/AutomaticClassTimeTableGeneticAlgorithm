using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTimeTable.Migrations
{
    public partial class akjsh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxNumOfStudents",
                table: "Courses",
                newName: "MaxNumOfStudents");

            migrationBuilder.AddColumn<string>(
                name: "BatchCode",
                table: "Batches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchCode",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "MaxNumOfStudents",
                table: "Courses",
                newName: "maxNumOfStudents");
        }
    }
}
