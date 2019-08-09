using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations.ApplicationDataDb
{
    public partial class UpdateMovieAndGenreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // DropForeignKey not supported in SqLite.
            // Using Sql string query to create new Movies table and drop the old one.
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

            migrationBuilder.Sql(
                @"
                DROP TABLE Movies;
                
                CREATE TABLE Movies (
                Id INTEGER NOT NULL,
                Name TEXT NOT NULL,
                GenreId INTEGER NOT NULL,
                ReleaseDate TEXT,
                DateAdded TEXT,
                NumberInStock INTEGER,
                PRIMARY KEY (Id),
                FOREIGN KEY (GenreID) REFERENCES Genre(Id)
                );

                CREATE INDEX IX_Movies_GenreId ON Movies(GenreId);

                ");

            // Seeds Movie data
            migrationBuilder.Sql(
                @"
                REPLACE INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock)
                VALUES (1, 'Hangover', 1, '6/2/2009', '8/9/2019', 125),
                (2, 'Die Hard', 2, '7/15/1988', '8/9/2019', 100),
                (3, 'The Terminator', 2, '10/26/1984', '8/9/2019', 50),
                (4, 'Toy Story', 3, '11/22/1995', '8/9/2019', 200),
                (5, 'Titanic', 4, '12/19/1997', '8/9/2019', 110);

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GenreId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
