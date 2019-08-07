using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class AddCustomerNameAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // AlterColumn not supported in Sqlite
            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Customers",
            //    maxLength: 255,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            // This creates a new customer table copy with the annotations
            migrationBuilder.Sql(
            @"

            CREATE TABLE Customers_temp (
            Id INTEGER PRIMARY KEY NOT NULL,
            IsSubscribedToNewsletter BOOLEAN DEFAULT FALSE,
            MembershipTypeId INTEGER NOT NULL, 
            Name TEXT NOT NULL,
            FOREIGN KEY (MembershiptypeId) REFERENCES MembershipType(Id)
            );

            DROP TABLE Customers;

            ALTER TABLE Customers_temp RENAME TO Customers;

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // AlterColumn not supported in Sqlite
            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Customers",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 255);
        }
    }
}
