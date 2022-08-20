using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class newdsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadsComplaintes_User_UserId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DropIndex(
                name: "IX_UploadsComplaintes_UserId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "177a7b6e-a329-4f0e-b992-199d2e71a327");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "1eddd7b2-59d4-46a2-bdc8-a28d7bb219c8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "a8ff77d9-507d-496f-96ea-62658df6c3fd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f496229c-19bc-4b08-8521-4d175ab76cc2");

            migrationBuilder.DropColumn(
                name: "SolutionsCompalints",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.RenameColumn(
                name: "CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions",
                newName: "UploadsComplainteId");

            migrationBuilder.RenameIndex(
                name: "IX_Compalints_Solutions_CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions",
                newName: "IX_Compalints_Solutions_UploadsComplainteId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "fabb22b6-dcdc-4c0b-9312-612f3a2a4eac");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "8c398d85-0501-4c99-aabd-d1bb7f69597a");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-gaaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "cfda7f99-8945-42df-882a-10d591413a6b");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "2a9d045e-1fa3-43dd-ab26-6f21e42ba4d5");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "2d809ad6-ff1c-4861-b1c4-a058f50f51de");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "9445c51b-110c-4835-89be-17fa2396c0f0");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "773f1d3b-37c3-43b6-952f-eea3521b133c", new DateTime(2022, 8, 19, 22, 2, 54, 491, DateTimeKind.Local).AddTicks(237), "زراعية", null },
                    { "0ef2675f-dde2-4e54-a7e2-6ae5c9c28520", new DateTime(2022, 8, 19, 22, 2, 54, 491, DateTimeKind.Local).AddTicks(804), "فساد", null },
                    { "0d25dd0c-aab4-49e2-ac63-53c97028d448", new DateTime(2022, 8, 19, 22, 2, 54, 491, DateTimeKind.Local).AddTicks(1039), "مماطلة", null },
                    { "d13662bc-0525-4368-acb0-e3755b03ef1b", new DateTime(2022, 8, 19, 22, 2, 54, 491, DateTimeKind.Local).AddTicks(1051), "إرتشاء", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId",
                principalSchema: "Identity",
                principalTable: "UploadsComplainte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UploadsComplainteId",
                principalSchema: "Identity",
                principalTable: "UploadsComplaintes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "0d25dd0c-aab4-49e2-ac63-53c97028d448");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "0ef2675f-dde2-4e54-a7e2-6ae5c9c28520");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "773f1d3b-37c3-43b6-952f-eea3521b133c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "d13662bc-0525-4368-acb0-e3755b03ef1b");

            migrationBuilder.RenameColumn(
                name: "UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions",
                newName: "CompalintId1");

            migrationBuilder.RenameIndex(
                name: "IX_Compalints_Solutions_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions",
                newName: "IX_Compalints_Solutions_CompalintId1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolutionsCompalints",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "258b2ac1-80c9-4e39-b9e5-fdfc09b8e49e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "c84e2df5-92f5-47fe-9e65-b2338bc8becc");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-gaaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "41928d89-68ce-491b-825b-4fe3e63b6f7e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "32c4bbef-59f5-48cc-9a2b-f4843dee51fc");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "945ef3db-b25e-4432-80cc-b734f2e36e13");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "619cfbd0-3eff-4e80-a65e-ced675da4099");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "a8ff77d9-507d-496f-96ea-62658df6c3fd", new DateTime(2022, 8, 18, 1, 22, 3, 157, DateTimeKind.Local).AddTicks(1896), "زراعية", null },
                    { "177a7b6e-a329-4f0e-b992-199d2e71a327", new DateTime(2022, 8, 18, 1, 22, 3, 157, DateTimeKind.Local).AddTicks(3049), "فساد", null },
                    { "1eddd7b2-59d4-46a2-bdc8-a28d7bb219c8", new DateTime(2022, 8, 18, 1, 22, 3, 157, DateTimeKind.Local).AddTicks(3085), "مماطلة", null },
                    { "f496229c-19bc-4b08-8521-4d175ab76cc2", new DateTime(2022, 8, 18, 1, 22, 3, 157, DateTimeKind.Local).AddTicks(3104), "إرتشاء", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_UserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId1",
                principalSchema: "Identity",
                principalTable: "UploadsComplainte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId",
                principalSchema: "Identity",
                principalTable: "UploadsComplaintes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadsComplaintes_User_UserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
