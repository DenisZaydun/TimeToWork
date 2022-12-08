using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeToWork.Migrations
{
    /// <inheritdoc />
    public partial class qwertyuiop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderId",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderId",
                table: "Appointment",
                newName: "ServiceProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ServiceProviderId",
                table: "Appointment",
                newName: "IX_Appointment_ServiceProviderID");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderID",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderID",
                table: "Appointment",
                column: "ServiceProviderID",
                principalTable: "ServiceProvider",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderID",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderID",
                table: "Appointment",
                newName: "ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ServiceProviderID",
                table: "Appointment",
                newName: "IX_Appointment_ServiceProviderId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_ServiceProvider_ServiceProviderId",
                table: "Appointment",
                column: "ServiceProviderId",
                principalTable: "ServiceProvider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
