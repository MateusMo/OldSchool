using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldSchoolInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactoringpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASCII",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Links",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ASCII",
                table: "Posts",
                type: "NVARCHAR(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "Posts",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Links",
                table: "Posts",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
