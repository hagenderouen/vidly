using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations.ApplicationDataDb
{
    public partial class RemoveMovieProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // DropForeignKey is not supported in SqLite.
            // Working around by creating a new Movies table and index.
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Movies_Genre_GenreId1",
            //    table: "Movies");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movies_GenreId1",
            //    table: "Movies");

            //migrationBuilder.DropColumn(
            //    name: "GenreId1",
            //    table: "Movies");

            //migrationBuilder.AlterColumn<int>(
            //    name: "GenreId",
            //    table: "Movies",
            //    nullable: true,
            //    oldClrType: typeof(byte));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movies_GenreId",
            //    table: "Movies",
            //    column: "GenreId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Movies_Genre_GenreId",
            //    table: "Movies",
            //    column: "GenreId",
            //    principalTable: "Genre",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(
                @"
                CREATE TABLE Movies_temp (
                GenreId INTEGER NOT NULL,
                RelaseDate TEXT,
                DateAdded TEXT,
                NumberInStock INTEGER,
                Id INTEGER NOT NULL,
                Name TEXT NOT NULL,
                PRIMARY KEY (Id),
                FOREIGN KEY (GenreId) REFERENCES Genre(Id)
                );

                DROP TABLE Movies;

                CREATE UNIQUE INDEX IX_Movies_GenreId ON Movies_temp(GenreId);

                ALTER TABLE Movies_temp RENAME TO Movies; 

                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Movies_Genre_GenreId",
            //    table: "Movies");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movies_GenreId",
            //    table: "Movies");

            //migrationBuilder.AlterColumn<byte>(
            //    name: "GenreId",
            //    table: "Movies",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "GenreId1",
            //    table: "Movies",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movies_GenreId1",
            //    table: "Movies",
            //    column: "GenreId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Movies_Genre_GenreId1",
            //    table: "Movies",
            //    column: "GenreId1",
            //    principalTable: "Genre",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
