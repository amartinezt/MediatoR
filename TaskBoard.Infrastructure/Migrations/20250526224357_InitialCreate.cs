using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Title", "Description", "IsCompleted", "CreatedAt" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Fix login issue",
                        "User cannot log in with correct credentials.",
                        false,
                        new DateTime(2024, 1, 1, 9, 0, 0, DateTimeKind.Utc)
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Update documentation",
                        "Add API usage examples and clarify error codes.",
                        true,
                        new DateTime(2024, 1, 2, 10, 30, 0, DateTimeKind.Utc)
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Design new logo",
                        "Create a modern version of the logo in SVG format.",
                        false,
                        new DateTime(2024, 1, 3, 14, 45, 0, DateTimeKind.Utc)
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Implement search feature",
                        "Allow users to search tasks by title or description.",
                        false,
                        new DateTime(2024, 1, 4, 8, 15, 0, DateTimeKind.Utc)
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Setup CI/CD pipeline",
                        "Integrate GitHub Actions for automated builds and deployments.",
                        true,
                        new DateTime(2024, 1, 5, 16, 0, 0, DateTimeKind.Utc)
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
