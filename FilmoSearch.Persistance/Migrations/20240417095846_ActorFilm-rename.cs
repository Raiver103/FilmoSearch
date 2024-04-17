using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmoSearch.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ActorFilmrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilms_Actors_ActorId",
                table: "ActorFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilms_Films_FilmId",
                table: "ActorFilms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorFilms",
                table: "ActorFilms");

            migrationBuilder.RenameTable(
                name: "ActorFilms",
                newName: "ActorFilm");

            migrationBuilder.RenameIndex(
                name: "IX_ActorFilms_ActorId",
                table: "ActorFilm",
                newName: "IX_ActorFilm_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorFilm",
                table: "ActorFilm",
                columns: new[] { "FilmId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilm_Actors_ActorId",
                table: "ActorFilm",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilm_Films_FilmId",
                table: "ActorFilm",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilm_Actors_ActorId",
                table: "ActorFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilm_Films_FilmId",
                table: "ActorFilm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorFilm",
                table: "ActorFilm");

            migrationBuilder.RenameTable(
                name: "ActorFilm",
                newName: "ActorFilms");

            migrationBuilder.RenameIndex(
                name: "IX_ActorFilm_ActorId",
                table: "ActorFilms",
                newName: "IX_ActorFilms_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorFilms",
                table: "ActorFilms",
                columns: new[] { "FilmId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilms_Actors_ActorId",
                table: "ActorFilms",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilms_Films_FilmId",
                table: "ActorFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
