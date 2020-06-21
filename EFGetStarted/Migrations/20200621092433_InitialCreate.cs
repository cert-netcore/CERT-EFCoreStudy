using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "11nstz");

            migrationBuilder.CreateTable(
                name: "CERT_course",
                schema: "11nstz",
                columns: table => new
                {
                    number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<string>(nullable: true),
                    Tuestday = table.Column<string>(nullable: true),
                    Wednesday = table.Column<string>(nullable: true),
                    Thursday = table.Column<string>(nullable: true),
                    Friday = table.Column<string>(nullable: true),
                    Saturday = table.Column<string>(nullable: true),
                    Sunday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERT_course", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "CERT_Student",
                schema: "11nstz",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERT_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "CERT_teacher",
                schema: "11nstz",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERT_teacher", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CERT_course",
                schema: "11nstz");

            migrationBuilder.DropTable(
                name: "CERT_Student",
                schema: "11nstz");

            migrationBuilder.DropTable(
                name: "CERT_teacher",
                schema: "11nstz");
        }
    }
}
