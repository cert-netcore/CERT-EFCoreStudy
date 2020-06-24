using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class CERT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_teacher",
                schema: "11nstz",
                table: "CERT_teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_Student",
                schema: "11nstz",
                table: "CERT_Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_course",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "11nstz",
                table: "CERT_teacher");

            migrationBuilder.DropColumn(
                name: "number",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Friday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Monday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Saturday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Sunday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Thursday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Tuestday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                schema: "11nstz",
                table: "CERT_course");

            migrationBuilder.RenameTable(
                name: "CERT_teacher",
                schema: "11nstz",
                newName: "CERT_teacher_all",
                newSchema: "11nstz");

            migrationBuilder.RenameTable(
                name: "CERT_Student",
                schema: "11nstz",
                newName: "CERT_Student_all",
                newSchema: "11nstz");

            migrationBuilder.RenameTable(
                name: "CERT_course",
                schema: "11nstz",
                newName: "CERT_course_all",
                newSchema: "11nstz");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "11nstz",
                table: "CERT_teacher_all",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                schema: "11nstz",
                table: "CERT_teacher_all",
                type: "varchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                schema: "11nstz",
                table: "CERT_Student_all",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "11nstz",
                table: "CERT_Student_all",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "11nstz",
                table: "CERT_course_all",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                schema: "11nstz",
                table: "CERT_course_all",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "courseday",
                schema: "11nstz",
                table: "CERT_course_all",
                type: "varchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "coursename",
                schema: "11nstz",
                table: "CERT_course_all",
                type: "varchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "coursepoint",
                schema: "11nstz",
                table: "CERT_course_all",
                type: "vinyint",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentlistId",
                schema: "11nstz",
                table: "CERT_course_all",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_teacher_all",
                schema: "11nstz",
                table: "CERT_teacher_all",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_Student_all",
                schema: "11nstz",
                table: "CERT_Student_all",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_course_all",
                schema: "11nstz",
                table: "CERT_course_all",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CERT_course_studentlist",
                schema: "11nstz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    studentname = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERT_course_studentlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CERT_course_studentlist_CERT_Student_all_Id",
                        column: x => x.Id,
                        principalSchema: "11nstz",
                        principalTable: "CERT_Student_all",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CERT_course_privatelist",
                schema: "11nstz",
                columns: table => new
                {
                    courseid = table.Column<int>(nullable: false),
                    coursename = table.Column<string>(nullable: true),
                    courseday = table.Column<string>(nullable: true),
                    coursepoint = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    studentIdlistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERT_course_privatelist", x => x.courseid);
                    table.ForeignKey(
                        name: "FK_CERT_course_privatelist_CERT_course_all_courseid",
                        column: x => x.courseid,
                        principalSchema: "11nstz",
                        principalTable: "CERT_course_all",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CERT_course_privatelist_CERT_course_studentlist_studentIdlistId",
                        column: x => x.studentIdlistId,
                        principalSchema: "11nstz",
                        principalTable: "CERT_course_studentlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CERT_teacher_all_courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all",
                column: "courselistcourseid");

            migrationBuilder.CreateIndex(
                name: "IX_CERT_Student_all_courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all",
                column: "courselistcourseid");

            migrationBuilder.CreateIndex(
                name: "IX_CERT_course_all_TeacherId",
                schema: "11nstz",
                table: "CERT_course_all",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CERT_course_all_studentlistId",
                schema: "11nstz",
                table: "CERT_course_all",
                column: "studentlistId");

            migrationBuilder.CreateIndex(
                name: "IX_CERT_course_all_courseday_coursename_coursepoint",
                schema: "11nstz",
                table: "CERT_course_all",
                columns: new[] { "courseday", "coursename", "coursepoint" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CERT_course_privatelist_studentIdlistId",
                schema: "11nstz",
                table: "CERT_course_privatelist",
                column: "studentIdlistId");

            migrationBuilder.CreateIndex(
                name: "IX_CERT_course_privatelist_courseday_coursename_coursepoint",
                schema: "11nstz",
                table: "CERT_course_privatelist",
                columns: new[] { "courseday", "coursename", "coursepoint" },
                unique: true,
                filter: "[courseday] IS NOT NULL AND [coursename] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CERT_course_all_CERT_teacher_all_TeacherId",
                schema: "11nstz",
                table: "CERT_course_all",
                column: "TeacherId",
                principalSchema: "11nstz",
                principalTable: "CERT_teacher_all",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CERT_course_all_CERT_course_studentlist_studentlistId",
                schema: "11nstz",
                table: "CERT_course_all",
                column: "studentlistId",
                principalSchema: "11nstz",
                principalTable: "CERT_course_studentlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CERT_Student_all_CERT_course_privatelist_courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all",
                column: "courselistcourseid",
                principalSchema: "11nstz",
                principalTable: "CERT_course_privatelist",
                principalColumn: "courseid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CERT_teacher_all_CERT_course_privatelist_courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all",
                column: "courselistcourseid",
                principalSchema: "11nstz",
                principalTable: "CERT_course_privatelist",
                principalColumn: "courseid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CERT_course_all_CERT_teacher_all_TeacherId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropForeignKey(
                name: "FK_CERT_course_all_CERT_course_studentlist_studentlistId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropForeignKey(
                name: "FK_CERT_Student_all_CERT_course_privatelist_courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all");

            migrationBuilder.DropForeignKey(
                name: "FK_CERT_teacher_all_CERT_course_privatelist_courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all");

            migrationBuilder.DropTable(
                name: "CERT_course_privatelist",
                schema: "11nstz");

            migrationBuilder.DropTable(
                name: "CERT_course_studentlist",
                schema: "11nstz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_teacher_all",
                schema: "11nstz",
                table: "CERT_teacher_all");

            migrationBuilder.DropIndex(
                name: "IX_CERT_teacher_all_courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_Student_all",
                schema: "11nstz",
                table: "CERT_Student_all");

            migrationBuilder.DropIndex(
                name: "IX_CERT_Student_all_courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CERT_course_all",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropIndex(
                name: "IX_CERT_course_all_TeacherId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropIndex(
                name: "IX_CERT_course_all_studentlistId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropIndex(
                name: "IX_CERT_course_all_courseday_coursename_coursepoint",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "Sex",
                schema: "11nstz",
                table: "CERT_teacher_all");

            migrationBuilder.DropColumn(
                name: "courselistcourseid",
                schema: "11nstz",
                table: "CERT_teacher_all");

            migrationBuilder.DropColumn(
                name: "courselistcourseid",
                schema: "11nstz",
                table: "CERT_Student_all");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "courseday",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "coursename",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "coursepoint",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.DropColumn(
                name: "studentlistId",
                schema: "11nstz",
                table: "CERT_course_all");

            migrationBuilder.RenameTable(
                name: "CERT_teacher_all",
                schema: "11nstz",
                newName: "CERT_teacher",
                newSchema: "11nstz");

            migrationBuilder.RenameTable(
                name: "CERT_Student_all",
                schema: "11nstz",
                newName: "CERT_Student",
                newSchema: "11nstz");

            migrationBuilder.RenameTable(
                name: "CERT_course_all",
                schema: "11nstz",
                newName: "CERT_course",
                newSchema: "11nstz");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "11nstz",
                table: "CERT_teacher",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "11nstz",
                table: "CERT_teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                schema: "11nstz",
                table: "CERT_Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "11nstz",
                table: "CERT_Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)");

            migrationBuilder.AddColumn<int>(
                name: "number",
                schema: "11nstz",
                table: "CERT_course",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Friday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Monday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Saturday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sunday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thursday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tuestday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wednesday",
                schema: "11nstz",
                table: "CERT_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_teacher",
                schema: "11nstz",
                table: "CERT_teacher",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_Student",
                schema: "11nstz",
                table: "CERT_Student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CERT_course",
                schema: "11nstz",
                table: "CERT_course",
                column: "number");
        }
    }
}
