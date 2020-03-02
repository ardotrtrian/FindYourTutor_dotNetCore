using Microsoft.EntityFrameworkCore.Migrations;

namespace FYT.DataAccess.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedCourses_User_UserId",
                table: "ReservedCourses");

            migrationBuilder.DropIndex(
                name: "IX_ReservedCourses_UserId",
                table: "ReservedCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReservedCourses");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ReservedCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedCourses_StudentId",
                table: "ReservedCourses",
                column: "StudentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Course_TutorId",
            //    table: "Course",
            //    column: "TutorId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_User_TutorId",
            //    table: "Course",
            //    column: "TutorId",
            //    principalTable: "User",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedCourses_User_StudentId",
                table: "ReservedCourses",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_TutorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedCourses_User_StudentId",
                table: "ReservedCourses");

            migrationBuilder.DropIndex(
                name: "IX_ReservedCourses_StudentId",
                table: "ReservedCourses");

            migrationBuilder.DropIndex(
                name: "IX_Course_TutorId",
            table: "Course");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ReservedCourses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReservedCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedCourses_UserId",
                table: "ReservedCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedCourses_User_UserId",
                table: "ReservedCourses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
