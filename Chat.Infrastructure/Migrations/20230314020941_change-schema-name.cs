using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeschemaname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_User_OwnerId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_ChatRoomId",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_User_UserId",
                table: "ChatRoomUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomUsers",
                table: "ChatRoomUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms");

            migrationBuilder.RenameTable(
                name: "ChatRoomUsers",
                newName: "ChatRoomUser",
                newSchema: "Chat");

            migrationBuilder.RenameTable(
                name: "ChatRooms",
                newName: "ChatRoom",
                newSchema: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUsers_UserId",
                schema: "Chat",
                table: "ChatRoomUser",
                newName: "IX_ChatRoomUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUsers_ChatRoomId",
                schema: "Chat",
                table: "ChatRoomUser",
                newName: "IX_ChatRoomUser_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_OwnerId",
                schema: "Chat",
                table: "ChatRoom",
                newName: "IX_ChatRoom_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomUser",
                schema: "Chat",
                table: "ChatRoomUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoom",
                schema: "Chat",
                table: "ChatRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoom_User_OwnerId",
                schema: "Chat",
                table: "ChatRoom",
                column: "OwnerId",
                principalSchema: "Chat",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_ChatRoom_ChatRoomId",
                schema: "Chat",
                table: "ChatRoomUser",
                column: "ChatRoomId",
                principalSchema: "Chat",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_User_UserId",
                schema: "Chat",
                table: "ChatRoomUser",
                column: "UserId",
                principalSchema: "Chat",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoom_User_OwnerId",
                schema: "Chat",
                table: "ChatRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_ChatRoom_ChatRoomId",
                schema: "Chat",
                table: "ChatRoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_User_UserId",
                schema: "Chat",
                table: "ChatRoomUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomUser",
                schema: "Chat",
                table: "ChatRoomUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoom",
                schema: "Chat",
                table: "ChatRoom");

            migrationBuilder.RenameTable(
                name: "ChatRoomUser",
                schema: "Chat",
                newName: "ChatRoomUsers");

            migrationBuilder.RenameTable(
                name: "ChatRoom",
                schema: "Chat",
                newName: "ChatRooms");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUser_UserId",
                table: "ChatRoomUsers",
                newName: "IX_ChatRoomUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUser_ChatRoomId",
                table: "ChatRoomUsers",
                newName: "IX_ChatRoomUsers_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoom_OwnerId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomUsers",
                table: "ChatRoomUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_User_OwnerId",
                table: "ChatRooms",
                column: "OwnerId",
                principalSchema: "Chat",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_ChatRoomId",
                table: "ChatRoomUsers",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_User_UserId",
                table: "ChatRoomUsers",
                column: "UserId",
                principalSchema: "Chat",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
