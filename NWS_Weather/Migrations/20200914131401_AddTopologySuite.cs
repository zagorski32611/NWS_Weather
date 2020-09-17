using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWS_Weather.Migrations
{
    public partial class AddTopologySuite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "elevations",
                columns: table => new
                {
                    elevationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<double>(nullable: false),
                    unitCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elevations", x => x.elevationId);
                });

            migrationBuilder.CreateTable(
                name: "WeatherStations",
                columns: table => new
                {
                    polygonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStations", x => x.polygonId);
                });

            migrationBuilder.CreateTable(
                name: "dbProperties",
                columns: table => new
                {
                    propertiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    updated = table.Column<DateTime>(nullable: false),
                    units = table.Column<string>(nullable: true),
                    forecastGenerator = table.Column<string>(nullable: true),
                    generatedAt = table.Column<DateTime>(nullable: false),
                    updateTime = table.Column<DateTime>(nullable: false),
                    validTimes = table.Column<DateTime>(nullable: false),
                    elevationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProperties", x => x.propertiesId);
                    table.ForeignKey(
                        name: "FK_dbProperties_elevations_elevationId",
                        column: x => x.elevationId,
                        principalTable: "elevations",
                        principalColumn: "elevationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "geometries",
                columns: table => new
                {
                    geometryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    weatherStationpolygonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_geometries", x => x.geometryId);
                    table.ForeignKey(
                        name: "FK_geometries_WeatherStations_weatherStationpolygonId",
                        column: x => x.weatherStationpolygonId,
                        principalTable: "WeatherStations",
                        principalColumn: "polygonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    periodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    isDaytime = table.Column<bool>(nullable: false),
                    temperature = table.Column<int>(nullable: false),
                    temperatureUnit = table.Column<string>(nullable: true),
                    temperatureTrend = table.Column<string>(nullable: true),
                    windSpeed = table.Column<string>(nullable: true),
                    windDirection = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    shortForecast = table.Column<string>(nullable: true),
                    detailedForecast = table.Column<string>(nullable: true),
                    propertiesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.periodId);
                    table.ForeignKey(
                        name: "FK_periods_dbProperties_propertiesId",
                        column: x => x.propertiesId,
                        principalTable: "dbProperties",
                        principalColumn: "propertiesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roots",
                columns: table => new
                {
                    rootId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    geometryId = table.Column<int>(nullable: true),
                    propertiesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roots", x => x.rootId);
                    table.ForeignKey(
                        name: "FK_roots_geometries_geometryId",
                        column: x => x.geometryId,
                        principalTable: "geometries",
                        principalColumn: "geometryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roots_dbProperties_propertiesId",
                        column: x => x.propertiesId,
                        principalTable: "dbProperties",
                        principalColumn: "propertiesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbProperties_elevationId",
                table: "dbProperties",
                column: "elevationId");

            migrationBuilder.CreateIndex(
                name: "IX_geometries_weatherStationpolygonId",
                table: "geometries",
                column: "weatherStationpolygonId");

            migrationBuilder.CreateIndex(
                name: "IX_periods_propertiesId",
                table: "periods",
                column: "propertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_roots_geometryId",
                table: "roots",
                column: "geometryId");

            migrationBuilder.CreateIndex(
                name: "IX_roots_propertiesId",
                table: "roots",
                column: "propertiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "periods");

            migrationBuilder.DropTable(
                name: "roots");

            migrationBuilder.DropTable(
                name: "geometries");

            migrationBuilder.DropTable(
                name: "dbProperties");

            migrationBuilder.DropTable(
                name: "WeatherStations");

            migrationBuilder.DropTable(
                name: "elevations");
        }
    }
}
