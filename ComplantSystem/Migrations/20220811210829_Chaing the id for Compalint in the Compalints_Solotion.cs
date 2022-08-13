using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class ChaingtheidforCompalintintheCompalints_Solotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_Beneficiaries_BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Compalints_Solutions_BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Compalints_Solutions_CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions");

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

            migrationBuilder.DropColumn(
                name: "BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropColumn(
                name: "CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions");

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

            migrationBuilder.AddColumn<string>(
                name: "SolutionsCompalints",
                schema: "Identity",
                table: "UploadsComplaintes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "BeneficiarieId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_Beneficiaries_BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "BeneficiarieId",
                principalSchema: "Identity",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_Beneficiaries_BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplaintes_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Compalints_Solutions_BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Compalints_Solutions_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarieId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "BeneficiariesId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintsHasSolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_Beneficiaries_BeneficiariesId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "BeneficiariesId",
                principalSchema: "Identity",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compalints_Solutions_UploadsComplainte_CompalintsHasSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintsHasSolutionId",
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
    }
}
