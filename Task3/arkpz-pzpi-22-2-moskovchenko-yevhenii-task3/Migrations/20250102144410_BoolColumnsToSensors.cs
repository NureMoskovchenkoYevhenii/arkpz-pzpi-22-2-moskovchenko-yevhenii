using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffFlow_api.Migrations
{
    /// <inheritdoc />
    public partial class BoolColumnsToSensors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tmperature",
                table: "SensorData",
                newName: "temperature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temperature",
                table: "SensorData",
                newName: "tmperature");
        }
    }
}
