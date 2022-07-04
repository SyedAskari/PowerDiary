using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerDiary.ChatHistory.Persistance.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Enter" },
                    { 2, "Leave" },
                    { 3, "Comment" },
                    { 4, "High-Five" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ali" },
                    { 2, "Snow" },
                    { 3, "Harry" },
                    { 4, "Anam" },
                    { 5, "Vareesha" }
                });

            migrationBuilder.InsertData(
                table: "ChatRoomEvents",
                columns: new[] { "Id", "EventDetails", "EventId", "ReceiverId", "SenderId", "TimeStamp" },
                values: new object[,]
                {
                    { 1, "", 1, null, 4, new DateTime(2022, 7, 3, 12, 48, 44, 260, DateTimeKind.Local).AddTicks(1009) },
                    { 2, "", 1, null, 5, new DateTime(2022, 7, 3, 12, 48, 44, 260, DateTimeKind.Local).AddTicks(1047) },
                    { 3, "", 1, null, 1, new DateTime(2022, 7, 3, 13, 48, 44, 260, DateTimeKind.Local).AddTicks(1049) },
                    { 4, "", 1, null, 2, new DateTime(2022, 7, 3, 13, 48, 44, 260, DateTimeKind.Local).AddTicks(1051) },
                    { 5, "", 1, null, 3, new DateTime(2022, 7, 3, 13, 48, 44, 260, DateTimeKind.Local).AddTicks(1053) },
                    { 6, "", 1, null, 4, new DateTime(2022, 7, 3, 13, 50, 44, 260, DateTimeKind.Local).AddTicks(1056) },
                    { 7, "", 1, null, 5, new DateTime(2022, 7, 3, 13, 50, 44, 260, DateTimeKind.Local).AddTicks(1058) },
                    { 8, "", 1, null, 1, new DateTime(2022, 7, 3, 15, 48, 44, 260, DateTimeKind.Local).AddTicks(1060) },
                    { 9, "", 2, null, 4, new DateTime(2022, 7, 3, 13, 48, 44, 260, DateTimeKind.Local).AddTicks(1062) },
                    { 10, "", 2, null, 5, new DateTime(2022, 7, 3, 13, 48, 44, 260, DateTimeKind.Local).AddTicks(1065) },
                    { 11, "", 2, null, 1, new DateTime(2022, 7, 3, 15, 18, 44, 260, DateTimeKind.Local).AddTicks(1067) },
                    { 12, "", 2, null, 2, new DateTime(2022, 7, 3, 16, 48, 44, 260, DateTimeKind.Local).AddTicks(1069) },
                    { 13, "", 2, null, 3, new DateTime(2022, 7, 3, 16, 48, 44, 260, DateTimeKind.Local).AddTicks(1071) },
                    { 14, "Hey - Vareesha how are you", 3, 5, 4, new DateTime(2022, 7, 3, 13, 58, 44, 260, DateTimeKind.Local).AddTicks(1074) },
                    { 15, "Hey - Anam how are you", 3, 5, 4, new DateTime(2022, 7, 3, 14, 0, 44, 260, DateTimeKind.Local).AddTicks(1077) },
                    { 16, "Hey - Harry how are you", 3, 3, 1, new DateTime(2022, 7, 3, 14, 48, 44, 260, DateTimeKind.Local).AddTicks(1079) },
                    { 17, "Hey - Ali how are you", 3, 1, 3, new DateTime(2022, 7, 3, 14, 53, 44, 260, DateTimeKind.Local).AddTicks(1081) },
                    { 18, "Hey - Ali how are you", 3, 1, 2, new DateTime(2022, 7, 3, 14, 58, 44, 260, DateTimeKind.Local).AddTicks(1083) },
                    { 19, "Hey - Snow how are you", 3, 2, 1, new DateTime(2022, 7, 3, 14, 0, 44, 260, DateTimeKind.Local).AddTicks(1086) },
                    { 20, "", 4, 1, 4, new DateTime(2022, 7, 3, 13, 52, 44, 260, DateTimeKind.Local).AddTicks(1089) },
                    { 21, "", 4, 1, 5, new DateTime(2022, 7, 3, 13, 52, 44, 260, DateTimeKind.Local).AddTicks(1092) },
                    { 22, "", 4, 5, 4, new DateTime(2022, 7, 3, 14, 4, 44, 260, DateTimeKind.Local).AddTicks(1094) },
                    { 23, "", 4, 4, 5, new DateTime(2022, 7, 3, 14, 6, 44, 260, DateTimeKind.Local).AddTicks(1096) },
                    { 24, "", 4, 4, 2, new DateTime(2022, 7, 3, 14, 52, 44, 260, DateTimeKind.Local).AddTicks(1098) },
                    { 25, "", 4, 5, 2, new DateTime(2022, 7, 3, 14, 52, 44, 260, DateTimeKind.Local).AddTicks(1101) },
                    { 26, "", 4, 2, 4, new DateTime(2022, 7, 3, 14, 52, 44, 260, DateTimeKind.Local).AddTicks(1103) },
                    { 27, "", 4, 2, 5, new DateTime(2022, 7, 3, 14, 52, 44, 260, DateTimeKind.Local).AddTicks(1105) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ChatRoomEvents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
