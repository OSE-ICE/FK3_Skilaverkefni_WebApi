using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FK3_Skilaverkefni_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class subjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "SubjectTeacher",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Marks",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groups",
                newName: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "SubjectTeacher",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "Marks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Groups",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
