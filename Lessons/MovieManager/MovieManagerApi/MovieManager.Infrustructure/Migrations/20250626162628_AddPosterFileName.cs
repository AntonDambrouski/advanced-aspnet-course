using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManager.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPosterFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterFileName",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterFileName",
                table: "Movies");
        }
    }
}
