using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "BenefCommunication",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TypeCommunicationId = table.Column<string>(type: "varchar(100)", nullable: false),
                    CommunDescribed = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    BeneficiariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefCommunication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LimitationOrders",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    UserResponsibleId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitationOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societys",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StagesComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagesComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCompalints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCompalints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBeneficiari",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBeneficiari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directorates_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectorates_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villages_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "تحديد وقت ادخال الصف في قاعدية البيانات"),
                    Update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeBeneficiariId = table.Column<int>(type: "int", nullable: true),
                    TypeBeneficiarisId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_TypeBeneficiari_TypeBeneficiarisId",
                        column: x => x.TypeBeneficiarisId,
                        principalSchema: "Identity",
                        principalTable: "TypeBeneficiari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_User_AdminId",
                        column: x => x.AdminId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersAddTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeComplaints_User_UsersAddTypeId",
                        column: x => x.UsersAddTypeId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersCommunications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsersHasId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Titile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_User_UsersHasId",
                        column: x => x.UsersHasId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefCommunicationBeneficiarie",
                schema: "Identity",
                columns: table => new
                {
                    BenefCommunicationsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeneficiariesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefCommunicationBeneficiarie", x => new { x.BenefCommunicationsId, x.BeneficiariesId });
                    table.ForeignKey(
                        name: "FK_BenefCommunicationBeneficiarie_BenefCommunication_BenefCommunicationsId",
                        column: x => x.BenefCommunicationsId,
                        principalSchema: "Identity",
                        principalTable: "BenefCommunication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefCommunicationBeneficiarie_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communication_Counter",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Communic_Counter = table.Column<int>(type: "int", nullable: false),
                    BeneficiarieId = table.Column<int>(type: "int", nullable: false),
                    BeneficiariesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BenefCommunicationId = table.Column<int>(type: "int", nullable: false),
                    BenefCommunicationsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication_Counter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communication_Counter_BenefCommunication_BenefCommunicationsId",
                        column: x => x.BenefCommunicationsId,
                        principalSchema: "Identity",
                        principalTable: "BenefCommunication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communication_Counter_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TitileProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSubmeted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "تحديد وقت ادخال الصف في قاعدية البيانات"),
                    BeneficiarieId = table.Column<int>(type: "int", nullable: false),
                    BeneficiarieId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Beneficiaries_BeneficiarieId1",
                        column: x => x.BeneficiarieId1,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadsComplainte",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TitleComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeComplaintId = table.Column<int>(type: "int", nullable: false),
                    TypeComplaintId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    StatusCompalintId = table.Column<int>(type: "int", nullable: false),
                    StagesComplaintId = table.Column<int>(type: "int", nullable: false),
                    PropBeneficiarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    CompDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompDateUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BeneficiarieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadsComplainte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Beneficiaries_BeneficiarieId",
                        column: x => x.BeneficiarieId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_StagesComplaints_StagesComplaintId",
                        column: x => x.StagesComplaintId,
                        principalSchema: "Identity",
                        principalTable: "StagesComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_StatusCompalints_StatusCompalintId",
                        column: x => x.StatusCompalintId,
                        principalSchema: "Identity",
                        principalTable: "StatusCompalints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_TypeComplaints_TypeComplaintId1",
                        column: x => x.TypeComplaintId1,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_User_HoUserId",
                        column: x => x.HoUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadsComplaintes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeComplaintId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DescComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    StatusCompalintId = table.Column<int>(type: "int", nullable: false),
                    StagesComplaintId = table.Column<int>(type: "int", nullable: false),
                    PropBeneficiarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    SolutionsCompalints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadsComplaintes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StagesComplaints_StagesComplaintId",
                        column: x => x.StagesComplaintId,
                        principalSchema: "Identity",
                        principalTable: "StagesComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StatusCompalints_StatusCompalintId",
                        column: x => x.StatusCompalintId,
                        principalSchema: "Identity",
                        principalTable: "StatusCompalints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_TypeComplaints_TypeComplaintId",
                        column: x => x.TypeComplaintId,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_User_HoUserId",
                        column: x => x.HoUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compalints_Solutions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddSolutionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompalintId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BeneficiarieId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentSolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSolution = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompalintId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compalints_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_Beneficiaries_BeneficiarieId",
                        column: x => x.BeneficiarieId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId1",
                        column: x => x.CompalintId1,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplainte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_UploadsComplaintes_CompalintId",
                        column: x => x.CompalintId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplaintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_User_UserAddSolutionId",
                        column: x => x.UserAddSolutionId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Governorates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "صنعاء" },
                    { 2, " تعز" },
                    { 3, "الحديدة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "dc24d657-c8f8-4085-a98a-6d139d9805ea", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "fd56765f-d45a-4e79-8544-c03520aade7c", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "cbc43a8e-f7bb-4445-baaf-1wdd431ffbbf", "d66e61cd-c84d-4f05-83c9-0a7cb31d4d1e", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "cbc43a8e-f7bb-4445-baaf-1rdd431ffbbf", "84f093a6-bd73-4caa-97a3-6fd20b2759b6", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "cbc43a8e-f7bb-1445-baaf-1rdd431ffbbf", "9a9819fb-5155-436e-89e5-546e68564fd8", "AdminVillages", "ADMINVILLAGES" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Societys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جمعية البن" },
                    { 2, "جمعية الالبان" },
                    { 3, "جمعية الحبوب" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StagesComplaints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "الإتحاد العام" },
                    { 4, "المحافظة" },
                    { 1, "القرية" },
                    { 2, "العزلة" },
                    { 3, "المديرية" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StatusCompalints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جديدة" },
                    { 2, "محلولة" },
                    { 3, "مرفوضة" },
                    { 4, "معلقة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UsersAddTypeId" },
                values: new object[,]
                {
                    { "981ef06d-e099-4810-8893-75374e2d259f", new DateTime(2022, 8, 15, 19, 36, 37, 259, DateTimeKind.Local).AddTicks(2253), "مماطلة", null },
                    { "a75d3c95-3f46-4a88-89d4-3385c2bcebbc", new DateTime(2022, 8, 15, 19, 36, 37, 259, DateTimeKind.Local).AddTicks(1526), "زراعية", null },
                    { "f8b510ec-e91a-468b-938a-fb65ce645028", new DateTime(2022, 8, 15, 19, 36, 37, 259, DateTimeKind.Local).AddTicks(2240), "فساد", null },
                    { "0b2f9a0c-b4b4-4230-b368-f712df94ee8c", new DateTime(2022, 8, 15, 19, 36, 37, 259, DateTimeKind.Local).AddTicks(2279), "إرتشاء", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefCommunicationBeneficiarie_BeneficiariesId",
                schema: "Identity",
                table: "BenefCommunicationBeneficiarie",
                column: "BeneficiariesId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AdminId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DirectorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_GovernorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_SubDirectorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_TypeBeneficiarisId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "TypeBeneficiarisId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_VillageId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_Counter_BenefCommunicationsId",
                schema: "Identity",
                table: "Communication_Counter",
                column: "BenefCommunicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_Counter_BeneficiariesId",
                schema: "Identity",
                table: "Communication_Counter",
                column: "BeneficiariesId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_CompalintId1",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId1");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_UserAddSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UserAddSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorates_GovernorateId",
                schema: "Identity",
                table: "Directorates",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_BeneficiarieId1",
                schema: "Identity",
                table: "Proposals",
                column: "BeneficiarieId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId1",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectorates_DirectorateId",
                schema: "Identity",
                table: "SubDirectorates",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeComplaints_UsersAddTypeId",
                schema: "Identity",
                table: "TypeComplaints",
                column: "UsersAddTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_BeneficiarieId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "BeneficiarieId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_DirectorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_GovernorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_HoUserId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "HoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_SocietyId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_StagesComplaintId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "StagesComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_StatusCompalintId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "StatusCompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_SubDirectorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_TypeComplaintId1",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "TypeComplaintId1");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_VillageId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_DirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_GovernorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_HoUserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "HoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SocietyId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StagesComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StagesComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StatusCompalintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StatusCompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SubDirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_TypeComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "TypeComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_UserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_VillageId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_DirectorateId",
                schema: "Identity",
                table: "User",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GovernorateId",
                schema: "Identity",
                table: "User",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "Identity",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SocietyId",
                schema: "Identity",
                table: "User",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SubDirectorateId",
                schema: "Identity",
                table: "User",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_VillageId",
                schema: "Identity",
                table: "User",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_UsersHasId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UsersHasId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_SubDirectorateId",
                schema: "Identity",
                table: "Villages",
                column: "SubDirectorateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefCommunicationBeneficiarie",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Communication_Counter",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Compalints_Solutions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "LimitationOrders",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersCommunications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "BenefCommunication",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UploadsComplainte",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UploadsComplaintes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Beneficiaries",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StagesComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StatusCompalints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeBeneficiari",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Societys",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Villages",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SubDirectorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Directorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Governorates",
                schema: "Identity");
        }
    }
}
