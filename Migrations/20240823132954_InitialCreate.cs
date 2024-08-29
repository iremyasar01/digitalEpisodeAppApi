using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitalEpisodeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tv_shows",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesPosterPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesVote = table.Column<double>(type: "float", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tv_shows", x => x.SeriesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tv_shows");
        }
    }
}
