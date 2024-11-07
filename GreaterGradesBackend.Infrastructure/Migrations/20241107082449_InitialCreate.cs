using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreaterGradesBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    ClassId = table.Column<int>(type: "int", nullable: false)
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
                    { 1, "student1", 1, "student1", "AQAAAAEAACcQAAAAEO6rKI0RYbgrpI1Hr1uAKUtTuG8R3H+A1jUAWm9BWLGnO7E3916EFVNa6PQnIabi4Q==", 0, "student1" },
                    { 2, "student2", 2, "student2", "AQAAAAEAACcQAAAAEHXz14T30KtTJIsJhWpFz3xaosQ1QSTVzeSVH0B8YfOm8buI0+BPi61q8zN5ppskpg==", 0, "student2" },
                    { 3, "studentTA1", 1, "studentTA1", "AQAAAAEAACcQAAAAEAUHPRrwX1EKKOUpx/KpAWt7WdyaFYy+vnQZ5+Hhw7zRsa8iFw1F3yhLp4sOOy6j2A==", 0, "studentTA1" },
                    { 4, "studentTA2", 2, "studentTA2", "AQAAAAEAACcQAAAAEADJ48U3a8vmiuo3UqNQ9BqPfNj/QFKU68XR+hiTwz+muUrNEyxHAsOGgrGFmAvHeQ==", 0, "studentTA2" },
                    { 5, "teacher1", 1, "teacher1", "AQAAAAEAACcQAAAAEF7EQqiNcFhiWoa3H9deTtTgAtrZGtNwBnSUxPzP0BKqht9/Wij9THcZeZD0JDTPcQ==", 1, "teacher1" },
                    { 6, "teacher2", 2, "teacher2", "AQAAAAEAACcQAAAAEGPNN7JHxQj/C7TLqgNGFXNb7Z9ArKqK2yu1N3VqB+tnSbB8LKp1JXUVJJrB89+auw==", 1, "teacher2" },
                    { 7, "teacherST1", 1, "teacherST1", "AQAAAAEAACcQAAAAEDqflsmUeiNNlV/TvhnZMqzl6RRh+1GrVHUKgA2oaO94N3QWgrV/vpJFQBwqjcM8kA==", 1, "teacherST1" },
                    { 8, "teacherST2", 2, "teacherST2", "AQAAAAEAACcQAAAAEKXlVc1g2EXcJ5p2nAjUNLeyoh1Q0Zoix2Hb76In5irEoWv+qyB/3VwWbCCUevni7Q==", 1, "teacherST2" },
                    { 9, "iadmin1", 1, "iadmin1", "AQAAAAEAACcQAAAAECGokhPYA2uCSyqrPZFb2CYHpUKd5tuHUSby+loX92SAU3rfg5tLwJWoEdn9xzximg==", 2, "iadmin1" },
                    { 10, "iadmin2", 2, "iadmin2", "AQAAAAEAACcQAAAAEIzAsVKZAVX7WvfRbOgpzDyYVs5sqADfz4xm0myaqfgFuzJC5LvmYdPK2JD/LKylKw==", 2, "iadmin2" },
                    { 11, "admin1", 1, "admin1", "AQAAAAEAACcQAAAAEEZUxo+6PfJClnU1xj6DPetE3EhqHZmduWGbsnI14x9TWSK9DlDb3uoGjdhwvLWW/Q==", 3, "admin1" },
                    { 12, "admin2", 2, "admin2", "AQAAAAEAACcQAAAAEHbbLB/+uT8bS81Zi2wRd/H/9HTCoZazpOYeAOQNXvIfLyZhA92qEDq4rMibK15Dbg==", 3, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "assignment1" },
                    { 2, 2, "assignment2" },
                    { 3, 3, "assignment3" },
                    { 4, 4, "assignment4" },
                    { 5, 5, "assignment5" },
                    { 6, 6, "assignment6" },
                    { 7, 7, "assignment7" },
                    { 8, 8, "assignment8" }
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
