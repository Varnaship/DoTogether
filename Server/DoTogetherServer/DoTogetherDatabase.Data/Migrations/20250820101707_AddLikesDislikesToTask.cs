using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoTogetherDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLikesDislikesToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Tasks");
        }
    }
}
