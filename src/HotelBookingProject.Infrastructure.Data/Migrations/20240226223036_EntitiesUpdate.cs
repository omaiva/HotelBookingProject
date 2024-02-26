using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingProject.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelRooms_HotelRoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Password_Requirements",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "HashedPassword");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelRooms_HotelRoomId",
                table: "Bookings",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelRooms_HotelRoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "User",
                newName: "Password");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Password_Requirements",
                table: "User",
                sql: "\r\n            LEN(Password) >= 8 AND \r\n            Password LIKE '%[a-zA-Z]%' AND \r\n            Password LIKE '%[A-Z]%' AND \r\n            Password LIKE '%[0-9]%'");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelRooms_HotelRoomId",
                table: "Bookings",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
