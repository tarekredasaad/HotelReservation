using System;
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
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Bookings_ReservationId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Facilities_FacilityId",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Offers_OfferId",
                table: "RoomOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Rooms_RoomId",
                table: "RoomOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_users_UserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bookings");

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "RoomBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Bookings_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Bookings_ReservationId",
                table: "RoomBookings",
                column: "ReservationId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Facilities_FacilityId",
                table: "RoomFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                table: "RoomFacilities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_users_UserId",
                table: "Staff",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Bookings_ReservationId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Facilities_FacilityId",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Offers_OfferId",
                table: "RoomOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOffers_Rooms_RoomId",
                table: "RoomOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_users_UserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Bookings_ReservationId",
                table: "RoomBookings",
                column: "ReservationId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Facilities_FacilityId",
                table: "RoomFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                table: "RoomFacilities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOffers_Offers_OfferId",
                table: "RoomOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOffers_Rooms_RoomId",
                table: "RoomOffers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_users_UserId",
                table: "Staff",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
