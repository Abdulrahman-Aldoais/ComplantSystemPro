using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class hk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "59ea2b07-ce28-4e65-b9ee-49ca010c80d9");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "61680aac-208a-4ae6-90b2-8fe09449c072");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "7df4b063-e41d-46ea-84f5-d6bcda26ac19");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "9b57793c-fc7c-48b1-90fe-4cca1f86a663");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "fc78f90d-c640-4f79-8d6f-062f15f745a6");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "2e39b9c8-6e4a-4599-accf-7b605a96b7a7");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "437cfddb-1335-4052-8d30-f861cba1e51d");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "25cb906c-1a00-4ac6-bc11-f3fca80bee7f");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "87018486-9813-4f91-b225-2059168119f1");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "bc94c08a-ff16-4770-bd32-44b3a06e2572", new DateTime(2022, 8, 13, 9, 3, 37, 108, DateTimeKind.Local).AddTicks(8174), "زراعية", null },
                    { "b83e551a-0821-467a-975d-8938c103e9f1", new DateTime(2022, 8, 13, 9, 3, 37, 108, DateTimeKind.Local).AddTicks(9537), "فساد", null },
                    { "81467656-db0c-4928-8cd9-924041b9ab3a", new DateTime(2022, 8, 13, 9, 3, 37, 108, DateTimeKind.Local).AddTicks(9558), "مماطلة", null },
                    { "bb95fd38-4d8e-4aa6-9f74-d5fab0a87362", new DateTime(2022, 8, 13, 9, 3, 37, 108, DateTimeKind.Local).AddTicks(9595), "إرتشاء", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "81467656-db0c-4928-8cd9-924041b9ab3a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "b83e551a-0821-467a-975d-8938c103e9f1");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "bb95fd38-4d8e-4aa6-9f74-d5fab0a87362");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "bc94c08a-ff16-4770-bd32-44b3a06e2572");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "f0d4f427-9faa-453f-8b75-9056ab6dcfab");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "9617b8ec-35ff-4cff-97ae-a259a0f4de23");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "bfd93fc6-ec9d-44e1-b300-9d7fbe51b145");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "5cebea18-5120-474b-ae24-68691534474a");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "f3eed1fa-80ec-4f61-a096-f9c5a75df10a");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "59ea2b07-ce28-4e65-b9ee-49ca010c80d9", new DateTime(2022, 8, 12, 0, 8, 28, 0, DateTimeKind.Local).AddTicks(958), "زراعية", null },
                    { "7df4b063-e41d-46ea-84f5-d6bcda26ac19", new DateTime(2022, 8, 12, 0, 8, 28, 0, DateTimeKind.Local).AddTicks(1915), "فساد", null },
                    { "9b57793c-fc7c-48b1-90fe-4cca1f86a663", new DateTime(2022, 8, 12, 0, 8, 28, 0, DateTimeKind.Local).AddTicks(1930), "مماطلة", null },
                    { "61680aac-208a-4ae6-90b2-8fe09449c072", new DateTime(2022, 8, 12, 0, 8, 28, 0, DateTimeKind.Local).AddTicks(2216), "إرتشاء", null }
                });
        }
    }
}
