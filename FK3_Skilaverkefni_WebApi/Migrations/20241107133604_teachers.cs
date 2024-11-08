using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FK3_Skilaverkefni_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class teachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "SubjectTeacher",
                newName: "TeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeachersTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                table: "SubjectTeacher",
                column: "TeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeachersTeacherId",
                table: "SubjectTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeachersTeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
