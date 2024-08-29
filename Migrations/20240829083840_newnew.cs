using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitalEpisodeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class newnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavSeries_TvShows_TvShowId",
                table: "FavSeries");

            migrationBuilder.RenameColumn(
                name: "TvShowId",
                table: "FavSeries",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_FavSeries_TvShowId",
                table: "FavSeries",
                newName: "IX_FavSeries_SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavSeries_TvShows_SeriesId",
                table: "FavSeries",
                column: "SeriesId",
                principalTable: "TvShows",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavSeries_TvShows_SeriesId",
                table: "FavSeries");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "FavSeries",
                newName: "TvShowId");

            migrationBuilder.RenameIndex(
                name: "IX_FavSeries_SeriesId",
                table: "FavSeries",
                newName: "IX_FavSeries_TvShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavSeries_TvShows_TvShowId",
                table: "FavSeries",
                column: "TvShowId",
                principalTable: "TvShows",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
