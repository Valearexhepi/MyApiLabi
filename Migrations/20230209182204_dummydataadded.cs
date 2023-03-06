using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class dummydataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseLength", "CourseLevel", "CourseNumber", "CourseStatus", "CourseTitle" },
                values: new object[,]
                {
                    { 1, "Svenska språket", 120, "Medel", 1, "Pensionerad", "Svenska1" },
                    { 2, "Svenska språket2", 127, "Medel", 2, "Pensionerad", "Svenska2" },
                    { 3, "Svenska språket3", 130, "Medel", 3, "Pensionerad", "Svenska3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Adress", "Email", "Name", "PhoneNumber", "SurName" },
                values: new object[] { 1, "Lvägen 2", "Hanna@gmail.com", "Hanna", 796854545, "Isson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
