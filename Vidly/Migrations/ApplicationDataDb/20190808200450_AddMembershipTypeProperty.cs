using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations.ApplicationDataDb
{
    public partial class AddMembershipTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // These tables already exist from previous migrations. This migration needs to
            // add the Name property to MemberShipType

            //migrationBuilder.CreateTable(
            //    name: "MembershipType",
            //    columns: table => new
            //    {
            //        Id = table.Column<byte>(nullable: false),
            //        SignUpFee = table.Column<short>(nullable: false),
            //        DurationInMonths = table.Column<byte>(nullable: false),
            //        DiscountRate = table.Column<byte>(nullable: false),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MembershipType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        IsSubscribedToNewsLetter = table.Column<bool>(nullable: false),
            //        MembershipTypeId = table.Column<byte>(nullable: false),
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Customers_MembershipType_MembershipTypeId",
            //            column: x => x.MembershipTypeId,
            //            principalTable: "MembershipType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_MembershipTypeId",
            //    table: "Customers",
            //    column: "MembershipTypeId");

            migrationBuilder.Sql(
                @"

                ALTER TABLE MembershipType ADD COLUMN Name TEXT

                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipType");
        }
    }
}
