using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingAgencyApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniquePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unique_phone_number",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "unique_phone_number",
                table: "Person",
                column: "phone",
                unique: true);
        }
    }
}
