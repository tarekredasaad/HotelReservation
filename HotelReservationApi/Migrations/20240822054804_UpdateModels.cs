using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
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
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures");

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
                name: "FK_Staff_users_UserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users");

            migrationBuilder.DropTable(
                name: "RoomOffers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Pictures",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "RoomBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RoomBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "URL",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_RoomId",
                table: "Offers",
                column: "RoomId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Rooms_RoomId",
                table: "Offers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Bookings_ReservationId",
                table: "RoomBookings",
                column: "ReservationId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Facilities_FacilityId",
                table: "RoomFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                table: "RoomFacilities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_users_UserId",
                table: "Staff",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Rooms_RoomId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Staff_StaffId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures");

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
                name: "FK_Staff_users_UserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_GroupId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Offers_RoomId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pictures",
                newName: "name");

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

            migrationBuilder.CreateTable(
                name: "RoomOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomOffers_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOffers_OfferId",
                table: "RoomOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOffers_RoomId",
                table: "RoomOffers",
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
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures",
                column: "RoomId",
                principalTable: "Rooms",
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
