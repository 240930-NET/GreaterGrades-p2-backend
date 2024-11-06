using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreaterGradesBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionId", "Name" },
                values: new object[,]
                {
                    { 1, "Institution 1" },
                    { 2, "Institution 2" }
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
                    { 1, "student1", 1, "student1", "AQAAAAIAAYagAAAAEJRHJW6Pmt32slfaF6sw/Le4JJ7/jRXWS66renLeG1K7A1CAq/BOl0rQ0OEknVzR6g==", 0, "student1" },
                    { 2, "student2", 2, "student2", "AQAAAAIAAYagAAAAECALOaUuxGCLcAmRjBsYneHJUk8CwZIsALeivrL1yAcRredHuu3/kqgsjnbCuE0/VQ==", 0, "student2" },
                    { 3, "studentTA1", 1, "studentTA1", "AQAAAAIAAYagAAAAENx+bn7k/Yqqtm5jvOFXHFPBdUfrZKatnXCi31S5R6sKG/CapB1Dj6tUW6fguKJNuA==", 0, "studentTA1" },
                    { 4, "studentTA2", 2, "studentTA2", "AQAAAAIAAYagAAAAEMKE9x2/dZ/CU7AkKOsViMhs438nHV68sijI3uWtr/rUjU12cYnF1/ZNLU/PDPKd9g==", 0, "studentTA2" },
                    { 5, "teacher1", 1, "teacher1", "AQAAAAIAAYagAAAAEM2XGT4LyJ+9LnUl1pqGlM6wgFY8r7WeZstOoi6xnCWX5nKh/hhaOx/9NB2T3EJObA==", 1, "teacher1" },
                    { 6, "teacher2", 2, "teacher2", "AQAAAAIAAYagAAAAEIaVgXGsl5d5QgWoqpWYSqidrhEolRU7G4t/PKWgiSwCq0gfTiWhfbCR435X6I/cOA==", 1, "teacher2" },
                    { 7, "teacherST1", 1, "teacherST1", "AQAAAAIAAYagAAAAEHDe0dQFr7Gk62UXKEpX9dBEC3AEOKx0c7a3iQkNwfpSHourB1vOvIj62jaLm82GSg==", 1, "teacherST1" },
                    { 8, "teacherST2", 2, "teacherST2", "AQAAAAIAAYagAAAAECgDCjvgyuh8Oq5sunH+1uQkLcod+s+wpiKAItYutp3tUwj29mnMzkzOX1CFToU2Sg==", 1, "teacherST2" },
                    { 9, "iadmin1", 1, "iadmin1", "AQAAAAIAAYagAAAAEPAMXd2wzUVNeSJMi/+FprLwxwpV5c/tid9hv81i4bzNgUgeMprGKsEtcAun/VCoDg==", 2, "iadmin1" },
                    { 10, "iadmin2", 2, "iadmin2", "AQAAAAIAAYagAAAAEBxxYndS6KGQe8Q1lGv8Nnd1n/g7dmNWgZiWFkvDMcaCIyco8jSqisBoZ16tl3mpGQ==", 2, "iadmin2" },
                    { 11, "admin1", 1, "admin1", "AQAAAAIAAYagAAAAEI7Fh7wNrcXXP9CiRxKM5W1+ygQ7DHzpyvjtmknvAiLPrTSjFuOfTsJz9q0r6e4deQ==", 3, "admin1" },
                    { 12, "admin2", 2, "admin2", "AQAAAAIAAYagAAAAEMuD7n4gqGoRsJPsnVR9nFggbAe368sBQdL26RCNc/eIXH0/UYe3tpxNMRdkmQnGXw==", 3, "admin2" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "StudentClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "TeacherClass",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Institutions",
                keyColumn: "InstitutionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Institutions",
                keyColumn: "InstitutionId",
                keyValue: 2);
        }
    }
}
