using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bca.api.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutUsDB01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "AboutsUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "AboutsUs");
        }
    }
}
