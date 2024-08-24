using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Reservations_ReservationId",
                table: "RoomFacilities");

            migrationBuilder.DropIndex(
                name: "IX_RoomFacilities_ReservationId",
                table: "RoomFacilities");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "RoomFacilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "RoomFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_ReservationId",
                table: "RoomFacilities",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Reservations_ReservationId",
                table: "RoomFacilities",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
