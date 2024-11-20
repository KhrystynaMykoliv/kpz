using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingAgencyApi.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unique_email",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "Person",
                column: "email",
                unique: true);
        }
    }
}
