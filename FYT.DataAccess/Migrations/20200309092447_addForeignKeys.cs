using Microsoft.EntityFrameworkCore.Migrations;

namespace FYT.DataAccess.Migrations
{
    public partial class addForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Course",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Course",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
               name: "IX_Course_CategoryId",
               table: "Course",
               column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TutorId",
                table: "Course",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_TutorId",
                table: "Course",
                column: "TutorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
