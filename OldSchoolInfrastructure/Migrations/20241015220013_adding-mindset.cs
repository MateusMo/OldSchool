using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldSchoolInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingmindset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MindsetDomainId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MindsetId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MindsetDomain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MindsetDomain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MindsetDomain_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MindsetDomainId",
                table: "Posts",
                column: "MindsetDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_MindsetDomain_UserId",
                table: "MindsetDomain",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_MindsetDomain_MindsetDomainId",
                table: "Posts",
                column: "MindsetDomainId",
                principalTable: "MindsetDomain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_MindsetDomain_MindsetDomainId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "MindsetDomain");

            migrationBuilder.DropIndex(
                name: "IX_Posts_MindsetDomainId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MindsetDomainId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MindsetId",
                table: "Posts");
        }
    }
}
