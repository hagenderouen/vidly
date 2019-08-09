using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations.ApplicationDataDb
{
    public partial class CustomerBirthdateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Sqlite doesn't support this operation

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "Birthdate",
            //    table: "Customers",
            //    nullable: true,
            //    oldClrType: typeof(DateTime));

            
            migrationBuilder.Sql(
                @"

                CREATE TABLE Customers_temp (
                IsSubscribedToNewsletter BOOL,
                MembershipTypeId INTEGER,
                Id INTEGER NOT NULL,
                Birthdate TEXT,
                Name TEXT NOT NULL,
                PRIMARY KEY (Id),
                FOREIGN KEY (MembershipTypeId) REFERENCES MembershipType(Id)
                );

                DROP TABLE Customers;

                ALTER TABLE Customers_temp RENAME TO Customers;

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "Birthdate",
            //    table: "Customers",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);

        }
    }
}
