using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeToWork.Migrations
{
    /// <inheritdoc />
    public partial class kfdsldsnclas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceProviderId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceProviderId",
                table: "Appointment",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderId",
                table: "Appointment",
                column: "ServiceProviderId",
                principalTable: "ServiceProvider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceProviderId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                table: "Appointment");
        }
    }
}
