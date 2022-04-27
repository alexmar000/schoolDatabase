using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2Linq.Migrations
{
    public partial class AddedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SA13B" },
                    { 2, "EK12A" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mr. Larsson" },
                    { 2, "Mrs. Eriksson" },
                    { 3, "Ms. Filipsson" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Engelska 7", 2 },
                    { 2, "Matematik 3B", 3 },
                    { 3, "Samhällskunskap 1A", 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Johanna Simonsson" },
                    { 2, 1, "Darya Asaad" },
                    { 3, 2, "Philippos Halkias" },
                    { 4, 2, "Gina Digorno" }
                });

            migrationBuilder.InsertData(
                table: "ClassCourse",
                columns: new[] { "ClassesId", "CoursesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassCourse",
                keyColumns: new[] { "ClassesId", "CoursesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassCourse",
                keyColumns: new[] { "ClassesId", "CoursesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ClassCourse",
                keyColumns: new[] { "ClassesId", "CoursesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ClassCourse",
                keyColumns: new[] { "ClassesId", "CoursesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
