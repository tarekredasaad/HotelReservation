using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Bookings_ReservationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Feedbacks_FeedbackId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FeedbackId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "NumberDays",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "RoomBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "RoomBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "Invoices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Bookings_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Bookings_ReservationId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "RoomBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberDays",
                table: "RoomBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Invoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FeedbackId",
                table: "Rooms",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Bookings_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Feedbacks_FeedbackId",
                table: "Rooms",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }
    }
}
