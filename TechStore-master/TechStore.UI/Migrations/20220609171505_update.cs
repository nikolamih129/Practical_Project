using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechStore.UI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dddfb74-9017-4d59-bbb5-91855daac429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "785ab8c6-180e-4f08-9b07-9ecb5cdcc0c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "020163c6-e99f-4bca-8b67-0ae7ec4b2991", "233fe899-29bd-4827-a432-92abc65800de", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5d3e989-e08b-4b28-a698-d10d267bf4b3", "043958ea-1d79-49d6-9be1-b261963cabb1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020163c6-e99f-4bca-8b67-0ae7ec4b2991");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d3e989-e08b-4b28-a698-d10d267bf4b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2dddfb74-9017-4d59-bbb5-91855daac429", "9afe8087-019e-40ff-b5db-bdabc0d6e560", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "785ab8c6-180e-4f08-9b07-9ecb5cdcc0c1", "1705914a-d69d-44ba-91c3-9d09f25871de", "Admin", "ADMIN" });
        }
    }
}
