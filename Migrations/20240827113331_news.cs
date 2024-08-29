using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitalEpisodeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class news : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tv_shows",
                table: "tv_shows");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tv_shows",
                newName: "TvShows");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeriesPosterPath",
                table: "TvShows",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeriesName",
                table: "TvShows",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeriesCountry",
                table: "TvShows",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "TvShows",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvShows",
                table: "TvShows",
                column: "SeriesId");

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EpisodeNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EpisodeOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vote = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.EpisodeId);
                });

            migrationBuilder.CreateTable(
                name: "FavSeries",
                columns: table => new
                {
                    FavSeriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TvShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavSeries", x => x.FavSeriesId);
                    table.ForeignKey(
                        name: "FK_FavSeries_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "SeriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavSeries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    posterPath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    movieOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieCountry = table.Column<double>(type: "float", nullable: false),
                    vote = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "SeriesWatch",
                columns: table => new
                {
                    SeriesWatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesWatch", x => x.SeriesWatchId);
                    table.ForeignKey(
                        name: "FK_SeriesWatch_TvShows_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "TvShows",
                        principalColumn: "SeriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesWatch_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavMovies",
                columns: table => new
                {
                    FavMoviesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavMovies", x => x.FavMoviesId);
                    table.ForeignKey(
                        name: "FK_FavMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieWatch",
                columns: table => new
                {
                    MovieWatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWatch", x => x.MovieWatchId);
                    table.ForeignKey(
                        name: "FK_MovieWatch_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieWatch_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavMovies_MoviesId",
                table: "FavMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_FavMovies_UserId",
                table: "FavMovies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavSeries_TvShowId",
                table: "FavSeries",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_FavSeries_UserId",
                table: "FavSeries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatch_MovieId",
                table: "MovieWatch",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatch_UserId",
                table: "MovieWatch",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesWatch_SeriesId",
                table: "SeriesWatch",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesWatch_UserId",
                table: "SeriesWatch",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "FavMovies");

            migrationBuilder.DropTable(
                name: "FavSeries");

            migrationBuilder.DropTable(
                name: "MovieWatch");

            migrationBuilder.DropTable(
                name: "SeriesWatch");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvShows",
                table: "TvShows");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "TvShows",
                newName: "tv_shows");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SeriesPosterPath",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SeriesName",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SeriesCountry",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tv_shows",
                table: "tv_shows",
                column: "SeriesId");
        }
    }
}
