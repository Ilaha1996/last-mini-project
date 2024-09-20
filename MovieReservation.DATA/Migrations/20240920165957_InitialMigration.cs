using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReservation.DATA.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId",
                table: "SeatReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_ShowTimes_ShowTimeId",
                table: "SeatReservations");

            migrationBuilder.DropIndex(
                name: "IX_SeatReservations_AppUserId",
                table: "SeatReservations");

            migrationBuilder.DropIndex(
                name: "IX_SeatReservations_ShowTimeId",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "SeatReservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "SeatReservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "SeatReservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "SeatReservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShowTimeId",
                table: "SeatReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_AppUserId",
                table: "SeatReservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_ShowTimeId",
                table: "SeatReservations",
                column: "ShowTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId",
                table: "SeatReservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_ShowTimes_ShowTimeId",
                table: "SeatReservations",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
