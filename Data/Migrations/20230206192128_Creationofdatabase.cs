using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FM_Secrets_Web_App.Data.Migrations
{
    public partial class Creationofdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "HairProducts",
                columns: table => new
                {
                    HairProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairProductsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairProduct_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairProduct_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairProduct_Quantity = table.Column<int>(type: "int", nullable: false),
                    HairProduct_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairProducts", x => x.HairProductsId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "HairProducts");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
