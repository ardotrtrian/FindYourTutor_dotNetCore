using Microsoft.EntityFrameworkCore.Migrations;

namespace FYT.DataAccess.Migrations
{
    public partial class removeTwoColumnsFromCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_Category_CategoryId",
            //    table: "Course");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_User_TutorId",
            //    table: "Course");

            //migrationBuilder.DropIndex(
            //    name: "IX_Course_TutorId",
            //    table: "Course");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Course");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CategoryId",
            //    table: "Course",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_Category_CategoryId",
            //    table: "Course",
            //    column: "CategoryId",
            //    principalTable: "Category",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
