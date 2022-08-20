using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "34e00262-6b97-4a09-9e91-20fb571d18b6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "5ecfe6bc-6da3-4c33-acd0-e2e44aaf7af6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "cd3b2a3d-52cf-46ed-b7ca-3ab6e10c6309");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "eeaf689f-d894-4db9-b029-a6f80ccc7d62");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a6ea2803-3372-4541-bc9e-410a98abe87d");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "405b8d95-bbea-488a-abba-82084c1041d2");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-gaaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "40b972b6-1391-48ec-9ee4-17482eeff65a");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "f210211a-8cd5-4af3-ba08-b7fcb16dda1e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "e3db8532-aa47-4b50-9d1e-27ba0df53a30");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "3476ddbb-3976-45ae-b8f9-fb56f7c5b588");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "5ecfe6bc-6da3-4c33-acd0-e2e44aaf7af6", new DateTime(2022, 8, 17, 19, 33, 50, 497, DateTimeKind.Local).AddTicks(3238), "زراعية", null },
                    { "cd3b2a3d-52cf-46ed-b7ca-3ab6e10c6309", new DateTime(2022, 8, 17, 19, 33, 50, 497, DateTimeKind.Local).AddTicks(3757), "فساد", null },
                    { "eeaf689f-d894-4db9-b029-a6f80ccc7d62", new DateTime(2022, 8, 17, 19, 33, 50, 497, DateTimeKind.Local).AddTicks(3876), "مماطلة", null },
                    { "34e00262-6b97-4a09-9e91-20fb571d18b6", new DateTime(2022, 8, 17, 19, 33, 50, 497, DateTimeKind.Local).AddTicks(3886), "إرتشاء", null }
                });
        }
    }
}
