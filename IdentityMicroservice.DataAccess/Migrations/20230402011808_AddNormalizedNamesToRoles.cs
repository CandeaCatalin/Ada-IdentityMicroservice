using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNormalizedNamesToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e86b582a-93f9-414e-937a-fc7614225b66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f881eb3d-b85c-4bb2-b5b4-ee166515be82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17579b49-69e6-48ca-95d6-bfab21dfb966", null, "User", "USER" },
                    { "51438481-aa7e-405e-b060-9b4a8cb2b3c7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17579b49-69e6-48ca-95d6-bfab21dfb966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51438481-aa7e-405e-b060-9b4a8cb2b3c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e86b582a-93f9-414e-937a-fc7614225b66", null, "User", null },
                    { "f881eb3d-b85c-4bb2-b5b4-ee166515be82", null, "Admin", null }
                });
        }
    }
}
