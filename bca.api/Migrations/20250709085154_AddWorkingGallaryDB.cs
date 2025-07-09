using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bca.api.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkingGallaryDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingGallery_HomeMasters_HomeMasterId",
                table: "WorkingGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingGallery",
                table: "WorkingGallery");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkingGallery");

            migrationBuilder.RenameTable(
                name: "WorkingGallery",
                newName: "WorkingGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingGallery_HomeMasterId",
                table: "WorkingGalleries",
                newName: "IX_WorkingGalleries_HomeMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingGalleries",
                table: "WorkingGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingGalleries_HomeMasters_HomeMasterId",
                table: "WorkingGalleries",
                column: "HomeMasterId",
                principalTable: "HomeMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingGalleries_HomeMasters_HomeMasterId",
                table: "WorkingGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingGalleries",
                table: "WorkingGalleries");

            migrationBuilder.RenameTable(
                name: "WorkingGalleries",
                newName: "WorkingGallery");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingGalleries_HomeMasterId",
                table: "WorkingGallery",
                newName: "IX_WorkingGallery_HomeMasterId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkingGallery",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingGallery",
                table: "WorkingGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingGallery_HomeMasters_HomeMasterId",
                table: "WorkingGallery",
                column: "HomeMasterId",
                principalTable: "HomeMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
