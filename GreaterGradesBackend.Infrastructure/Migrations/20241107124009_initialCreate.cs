using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreaterGradesBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClass", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeacherClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherClass_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GradingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "1600 Pennsylvania Avenue NW, Washington, DC 20500", "Institution 1" },
                    { 2, "600 1st St W, Mt Vernon, IA 52314", "Institution 2" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "InstitutionId", "Subject" },
                values: new object[,]
                {
                    { 1, 1, "math1" },
                    { 2, 2, "math2" },
                    { 3, 1, "english1" },
                    { 4, 2, "english2" },
                    { 5, 1, "science1" },
                    { 6, 2, "science2" },
                    { 7, 1, "history1" },
                    { 8, 2, "history2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "InstitutionId", "LastName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "student1", 1, "student1", "AQAAAAEAACcQAAAAEEy4rD9aLC3dj4HArMQC6nXcrMIhO244V3Kp54hzOmhZPTJlTAIXlCVSEmSBWFs3xA==", 0, "student1" },
                    { 2, "student2", 2, "student2", "AQAAAAEAACcQAAAAEDYnocpr9lktvYibUe2HvUwGBhBBDG+3wGIgYAHsZZhIyOeWRkKzCuEKzC4xkK84Kg==", 0, "student2" },
                    { 3, "studentTA1", 1, "studentTA1", "AQAAAAEAACcQAAAAEGiLs2fq63or9xPYLpW9x7ciui+sNQgRJNfu8U9Dl7Ep60DdRUFd6LqnbaWfLEoM/g==", 0, "studentTA1" },
                    { 4, "studentTA2", 2, "studentTA2", "AQAAAAEAACcQAAAAEALd6bXNq19BrJkDuaT7kjBjZpZ0orEy+3HKWxrNceRzwTbOxaw0kxy/DHEmlg371w==", 0, "studentTA2" },
                    { 5, "teacher1", 1, "teacher1", "AQAAAAEAACcQAAAAED7mS4xutH5/2N1rT/VGRsvRCV3pw7PnaVynWtvJc2qh03zkxP31YRs938YUov99Qg==", 1, "teacher1" },
                    { 6, "teacher2", 2, "teacher2", "AQAAAAEAACcQAAAAEE6/XuXUyxyrJ57+O6wi116mAPsFpDNJIXSUqWfSo+ckh0o4BeFF+wFWw18iRu9cDw==", 1, "teacher2" },
                    { 7, "teacherST1", 1, "teacherST1", "AQAAAAEAACcQAAAAEKgm9+FXVcVq+OmKH06UeN7vFojgWW00s++dosGowPISy9zxzVksdodNBP9FK0K9IA==", 1, "teacherST1" },
                    { 8, "teacherST2", 2, "teacherST2", "AQAAAAEAACcQAAAAEF57mLUK1yIUc7rAEIxuE6qkrWLhXXhnLJFbSBzpVEumDLKGdt0kC5bhI2emlUaeAA==", 1, "teacherST2" },
                    { 9, "iadmin1", 1, "iadmin1", "AQAAAAEAACcQAAAAEMitdprP4FYTaI+rySAv3iImy3YJ2Y/97AEuCZD1A0bbateUZaHb3MrncP4NW2ivqA==", 2, "iadmin1" },
                    { 10, "iadmin2", 2, "iadmin2", "AQAAAAEAACcQAAAAEBT489P6jMMkM+Y6B9YtuqLk01m5o4Q2UBJuiE2Np8kYlaB8Px9OjuI4l87vFLGQlQ==", 2, "iadmin2" },
                    { 11, "admin1", 1, "admin1", "AQAAAAEAACcQAAAAEG8lhxKmxqTkF5wvqh2rELPc73HcmbL/m4/BjIpTkqQA/twp3eu7NQbUl474QPlziw==", 3, "admin1" },
                    { 12, "admin2", 2, "admin2", "AQAAAAEAACcQAAAAEJ9Ujbj2CSMnxuB/42mR9PgJTDuEk9HKAK/gyg+fG5/IgDhpo2T7EHr2jmDNqKULOg==", 3, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "ClassId", "MaxScore", "Name" },
                values: new object[,]
                {
                    { 1, 1, 100, "assignment1" },
                    { 2, 2, 100, "assignment2" },
                    { 3, 3, 100, "assignment3" },
                    { 4, 4, 100, "assignment4" },
                    { 5, 5, 100, "assignment5" },
                    { 6, 6, 100, "assignment6" },
                    { 7, 7, 100, "assignment7" },
                    { 8, 8, 100, "assignment8" }
                });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherClass",
                columns: new[] { "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "AssignmentId", "GradingStatus", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 0, 20, 1 },
                    { 2, 2, 0, 25, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_InstitutionId",
                table: "Classes",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AssignmentId",
                table: "Grades",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserId",
                table: "Grades",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_UserId",
                table: "StudentClass",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_UserId",
                table: "TeacherClass",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstitutionId",
                table: "Users",
                column: "InstitutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "TeacherClass");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
