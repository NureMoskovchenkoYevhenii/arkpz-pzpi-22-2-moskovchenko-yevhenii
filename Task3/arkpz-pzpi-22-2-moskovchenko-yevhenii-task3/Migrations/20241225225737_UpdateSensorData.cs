using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffFlow_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSensorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "SensorData",
                newName: "timestamp");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "SensorData",
                newName: "humidity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SensorData",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "SensorData",
                newName: "tmperature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timestamp",
                table: "SensorData",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "humidity",
                table: "SensorData",
                newName: "Humidity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SensorData",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tmperature",
                table: "SensorData",
                newName: "Temperature");
        }
    }
}
