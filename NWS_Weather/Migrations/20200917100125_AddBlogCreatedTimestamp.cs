using Microsoft.EntityFrameworkCore.Migrations;

namespace NWS_Weather.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_geometries_WeatherStations_weatherStationpolygonId",
                table: "geometries");

            migrationBuilder.DropTable(
                name: "WeatherStations");

            migrationBuilder.DropIndex(
                name: "IX_geometries_weatherStationpolygonId",
                table: "geometries");

            migrationBuilder.DropColumn(
                name: "weatherStationpolygonId",
                table: "geometries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "weatherStationpolygonId",
                table: "geometries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeatherStations",
                columns: table => new
                {
                    polygonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStations", x => x.polygonId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_geometries_weatherStationpolygonId",
                table: "geometries",
                column: "weatherStationpolygonId");

            migrationBuilder.AddForeignKey(
                name: "FK_geometries_WeatherStations_weatherStationpolygonId",
                table: "geometries",
                column: "weatherStationpolygonId",
                principalTable: "WeatherStations",
                principalColumn: "polygonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
