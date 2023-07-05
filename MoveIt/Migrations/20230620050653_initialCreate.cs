using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoveIt.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    PhotoURL = table.Column<string>(type: "TEXT", nullable: false),
                    AdTitle = table.Column<string>(type: "TEXT", nullable: false),
                    TransportDate = table.Column<string>(type: "TEXT", nullable: false),
                    TransportHour = table.Column<string>(type: "TEXT", nullable: false),
                    FromWhere = table.Column<string>(type: "TEXT", nullable: false),
                    ToWhere = table.Column<string>(type: "TEXT", nullable: false),
                    DetailedAddress = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsCategory = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsName = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsVolume = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsLength = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsWidth = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsDepth = table.Column<string>(type: "TEXT", nullable: false),
                    GoodsWeight = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    isDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarrierId = table.Column<long>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false),
                    AdId = table.Column<long>(type: "INTEGER", nullable: false),
                    AdTitle = table.Column<string>(type: "TEXT", nullable: false),
                    TransportDay = table.Column<string>(type: "TEXT", nullable: false),
                    TransportHour = table.Column<string>(type: "TEXT", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: false),
                    OfferValue = table.Column<string>(type: "TEXT", nullable: false),
                    isAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    isCarrierConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    isCustomerConfirmed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMail = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    isCarrier = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
