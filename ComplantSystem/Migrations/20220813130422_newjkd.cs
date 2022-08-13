using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class newjkd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_User_UserId1",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_User_UserId1",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_User_UserId1",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId1",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId1",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_UserId1",
                schema: "Identity",
                table: "UserClaims");

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

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ea5b878b-f17c-474f-869a-38fd6694ddc5");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "d475397d-6acc-40ac-94e9-ebac6b4be4a7");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "03306345-9c7d-4973-98ac-b6307522cfc3");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "53cdcaa0-886f-4264-bb7e-3acb74f1ae2e");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf",
                column: "ConcurrencyStamp",
                value: "f5cf30d1-4e96-44b1-a0a5-5e43ddcca421");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "c25a3650-0a80-4385-aae9-f9eddf0e0117", new DateTime(2022, 8, 13, 16, 4, 19, 909, DateTimeKind.Local).AddTicks(3321), "زراعية", null },
                    { "8dfd7949-b4f9-46b0-93b2-526078d3fc11", new DateTime(2022, 8, 13, 16, 4, 19, 909, DateTimeKind.Local).AddTicks(4241), "فساد", null },
                    { "5f4a51bc-c568-4747-b01e-873662c656a9", new DateTime(2022, 8, 13, 16, 4, 19, 909, DateTimeKind.Local).AddTicks(4254), "مماطلة", null },
                    { "6ff254c3-8093-4eb5-981e-641cb2fb1e11", new DateTime(2022, 8, 13, 16, 4, 19, 909, DateTimeKind.Local).AddTicks(4266), "إرتشاء", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "5f4a51bc-c568-4747-b01e-873662c656a9");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "6ff254c3-8093-4eb5-981e-641cb2fb1e11");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "8dfd7949-b4f9-46b0-93b2-526078d3fc11");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "c25a3650-0a80-4385-aae9-f9eddf0e0117");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "UserClaims",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId1",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId1",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId1",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_User_UserId1",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_User_UserId1",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_User_UserId1",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
