using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class new7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadsComplaintes_Villages_VillageId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DropIndex(
                name: "IX_UploadsComplaintes_VillageId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "23872bc2-74fb-4836-bfbf-e083bd218ee0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "7ace66f0-becb-434e-83eb-9a7746b812c4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "93d230d5-454c-4be4-9c9c-8c94cf3bd55a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "b4b55307-1bfb-44c7-b4fc-5f2c5944bd22");

            migrationBuilder.DropColumn(
                name: "VillageId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.AddColumn<int>(
                name: "VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "int",
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
                name: "IX_UploadsComplaintes_VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadsComplaintes_Villages_VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillagesId",
                principalSchema: "Identity",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadsComplaintes_Villages_VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DropIndex(
                name: "IX_UploadsComplaintes_VillagesId",
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
                name: "VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ea083ed6-d121-4d1f-ac7f-50a23f62d86d");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "30ef6ab9-b4bd-45a0-90ab-9adfc9acf5cd");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-gaaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "fce261e1-4b5b-4487-85bb-c3d006b2c724");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "b4eec844-179f-45f4-805a-7972fe85bfc2");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "5aca9483-8348-4351-9c8f-8ddb2536c04e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "ed805d66-70c0-45e4-93ac-6f23080db2c5");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "b4b55307-1bfb-44c7-b4fc-5f2c5944bd22", new DateTime(2022, 8, 18, 1, 15, 13, 54, DateTimeKind.Local).AddTicks(834), "زراعية", null },
                    { "23872bc2-74fb-4836-bfbf-e083bd218ee0", new DateTime(2022, 8, 18, 1, 15, 13, 54, DateTimeKind.Local).AddTicks(1497), "فساد", null },
                    { "7ace66f0-becb-434e-83eb-9a7746b812c4", new DateTime(2022, 8, 18, 1, 15, 13, 54, DateTimeKind.Local).AddTicks(1510), "مماطلة", null },
                    { "93d230d5-454c-4be4-9c9c-8c94cf3bd55a", new DateTime(2022, 8, 18, 1, 15, 13, 54, DateTimeKind.Local).AddTicks(1522), "إرتشاء", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_VillageId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadsComplaintes_Villages_VillageId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillageId",
                principalSchema: "Identity",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
