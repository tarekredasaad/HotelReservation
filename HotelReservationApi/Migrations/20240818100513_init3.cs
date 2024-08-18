using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Pictures");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Pictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Pictures",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Facilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomOffers_OfferId",
                table: "RoomOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOffers_RoomId",
                table: "RoomOffers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOffers_Offers_OfferId",
                table: "RoomOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOffers_Rooms_RoomId",
                table: "RoomOffers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Offers_OfferId",
                table: "RoomOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Rooms_RoomId",
                table: "RoomOffers");

            migrationBuilder.DropIndex(
                name: "IX_RoomOffers_OfferId",
                table: "RoomOffers");

            migrationBuilder.DropIndex(
                name: "IX_RoomOffers_RoomId",
                table: "RoomOffers");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Facilities");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
