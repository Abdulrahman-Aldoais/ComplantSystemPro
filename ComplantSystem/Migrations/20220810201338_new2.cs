using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "1c90cf0a-cf32-4bce-b690-403a124a41f5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "6a0da0fe-1094-47fc-94da-1ad0def26eb0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "92707573-32dd-4c0c-96ad-0dac793fe68e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f05f0e9a-faff-4908-b387-d58b348957be");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "UploadsComplaintes");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5b8380ed-6ddb-4b04-9d60-392bff38a1ce");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "86ec2bf8-018f-48b6-b331-aaf2c1f0b44f");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "69078d9c-63ad-4378-bfa8-fa48983abea6");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "9411a7c3-59cb-4d83-819e-2a14b0836825");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "352165a9-b18c-4a41-a742-eebe80755624");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "f295ead7-2d69-450b-ba21-8af6f813accb", new DateTime(2022, 8, 10, 23, 13, 37, 554, DateTimeKind.Local).AddTicks(382), "زراعية", null },
                    { "acce0ce8-5a50-440c-b9b1-073317b75f09", new DateTime(2022, 8, 10, 23, 13, 37, 554, DateTimeKind.Local).AddTicks(916), "فساد", null },
                    { "efcace93-91d6-4b12-81bc-d6d96215a200", new DateTime(2022, 8, 10, 23, 13, 37, 554, DateTimeKind.Local).AddTicks(940), "مماطلة", null },
                    { "08cf3bd8-f424-4571-a06a-1e4863a4f257", new DateTime(2022, 8, 10, 23, 13, 37, 554, DateTimeKind.Local).AddTicks(948), "إرتشاء", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "08cf3bd8-f424-4571-a06a-1e4863a4f257");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "acce0ce8-5a50-440c-b9b1-073317b75f09");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "efcace93-91d6-4b12-81bc-d6d96215a200");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f295ead7-2d69-450b-ba21-8af6f813accb");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
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
                value: "4602abc2-36e8-4e12-b70b-ad040138cea1");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "b079a149-9a51-449f-9b6d-f2e90522e9bb");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "a824b195-d93c-4cf6-b899-caed79b2ef5a");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "5641b76d-7792-45aa-bbf0-02a5ce2d57b3");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "8a2631e9-5220-44df-8dc1-41049bd0862b");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "f05f0e9a-faff-4908-b387-d58b348957be", new DateTime(2022, 8, 10, 21, 13, 40, 868, DateTimeKind.Local).AddTicks(5188), "زراعية", null },
                    { "6a0da0fe-1094-47fc-94da-1ad0def26eb0", new DateTime(2022, 8, 10, 21, 13, 40, 868, DateTimeKind.Local).AddTicks(6029), "فساد", null },
                    { "92707573-32dd-4c0c-96ad-0dac793fe68e", new DateTime(2022, 8, 10, 21, 13, 40, 868, DateTimeKind.Local).AddTicks(6062), "مماطلة", null },
                    { "1c90cf0a-cf32-4bce-b690-403a124a41f5", new DateTime(2022, 8, 10, 21, 13, 40, 868, DateTimeKind.Local).AddTicks(6074), "إرتشاء", null }
                });
        }
    }
}
