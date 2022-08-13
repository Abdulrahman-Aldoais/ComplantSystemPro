using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class newjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_UserId1",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId1",
                schema: "Identity",
                table: "UserRoles");

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

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "79df7c5c-1079-4369-9543-ebe1078cdeb7");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "36653d4d-6ffb-45ff-9101-fc9312c7cab2");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "45031fc1-7761-43ae-b1e0-ef286d49beb2");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "90d72404-c5da-4221-be93-4410554afb44");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "c4abe6e9-daaa-49ad-b341-ac97ce35a712");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "a874bc02-58a9-43d1-8143-c7c7b97a4aff", new DateTime(2022, 8, 13, 15, 58, 39, 900, DateTimeKind.Local).AddTicks(4787), "زراعية", null },
                    { "c263c89f-d2f0-4268-ac58-c2ee8f3cb1c3", new DateTime(2022, 8, 13, 15, 58, 39, 900, DateTimeKind.Local).AddTicks(5451), "فساد", null },
                    { "77cd4239-dbfe-4b93-8fb6-33bb98d945d6", new DateTime(2022, 8, 13, 15, 58, 39, 900, DateTimeKind.Local).AddTicks(5460), "مماطلة", null },
                    { "f9eb62ea-6ff5-4903-979d-41cac15cc860", new DateTime(2022, 8, 13, 15, 58, 39, 900, DateTimeKind.Local).AddTicks(5641), "إرتشاء", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "77cd4239-dbfe-4b93-8fb6-33bb98d945d6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "a874bc02-58a9-43d1-8143-c7c7b97a4aff");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "c263c89f-d2f0-4268-ac58-c2ee8f3cb1c3");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f9eb62ea-6ff5-4903-979d-41cac15cc860");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId1",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_UserId1",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
