using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactRedux.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    FullName = table.Column<string>(maxLength: 500, nullable: true),
                    AlphaCode2 = table.Column<string>(type: "nchar(2)", nullable: false),
                    AlphaCode3 = table.Column<string>(type: "nchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FederalDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FederalDistricts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    NumberFormat = table.Column<string>(maxLength: 50, nullable: false),
                    NumberRegex = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    Weight = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    IconColor = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    FederalDistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_FederalDistricts_FederalDistrictId",
                        column: x => x.FederalDistrictId,
                        principalTable: "FederalDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 100, nullable: false),
                    IdentityDocumentId = table.Column<int>(nullable: false),
                    IdentityDocumentNumber = table.Column<string>(maxLength: 50, nullable: false),
                    BirthPlace = table.Column<string>(maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Sex = table.Column<string>(maxLength: 20, nullable: false),
                    FederalDistrictId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    FamilyStatus = table.Column<string>(maxLength: 50, nullable: true),
                    ChildrenInfo = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoId = table.Column<Guid>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    ReadyMoveToRussia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_FederalDistricts_FederalDistrictId",
                        column: x => x.FederalDistrictId,
                        principalTable: "FederalDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_IdentityDocuments_IdentityDocumentId",
                        column: x => x.IdentityDocumentId,
                        principalTable: "IdentityDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEducation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    EducationLevelId = table.Column<int>(nullable: false),
                    University = table.Column<string>(maxLength: 100, nullable: false),
                    Specialty = table.Column<string>(maxLength: 200, nullable: false),
                    GraduationYear = table.Column<int>(nullable: true),
                    ExtraInfo = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonEducation_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEducation_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonJob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    Position = table.Column<string>(maxLength: 100, nullable: false),
                    IndustryId = table.Column<int>(nullable: false),
                    WorkAreaId = table.Column<int>(nullable: false),
                    ManagementLevelId = table.Column<int>(nullable: false),
                    ManagementExperienceId = table.Column<int>(nullable: false),
                    EmployeesNumberId = table.Column<int>(nullable: false),
                    HireYear = table.Column<int>(nullable: true),
                    PreviousJobs = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonJob_EmployeesNumbers_EmployeesNumberId",
                        column: x => x.EmployeesNumberId,
                        principalTable: "EmployeesNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonJob_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonJob_ManagementExperiences_ManagementExperienceId",
                        column: x => x.ManagementExperienceId,
                        principalTable: "ManagementExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonJob_ManagementLevels_ManagementLevelId",
                        column: x => x.ManagementLevelId,
                        principalTable: "ManagementLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonJob_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonJob_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSocialNetwork",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<string>(maxLength: 100, nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    SocialNetworkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSocialNetwork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSocialNetwork_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSocialNetwork_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "AB", "ABH", "Developer", "895", "Республика Абхазия", null, null, "АБХАЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 161, "PA", "PAN", "Developer", "591", "Республика Панама", null, null, "ПАНАМА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 162, "VA", "VAT", "Developer", "336", null, null, null, "ПАПСКИЙ ПРЕСТОЛ (ГОСУДАРСТВО — ГОРОД ВАТИКАН)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 163, "PG", "PNG", "Developer", "598", null, null, null, "ПАПУА-НОВАЯ ГВИНЕЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 164, "PY", "PRY", "Developer", "600", "Республика Парагвай", null, null, "ПАРАГВАЙ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 165, "PE", "PER", "Developer", "604", "Республика Перу", null, null, "ПЕРУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 166, "PN", "PCN", "Developer", "612", null, null, null, "ПИТКЭРН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 167, "PL", "POL", "Developer", "616", "Республика Польша", null, null, "ПОЛЬША" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 168, "PT", "PRT", "Developer", "620", "Португальская Республика", null, null, "ПОРТУГАЛИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 169, "PR", "PRI", "Developer", "630", null, null, null, "ПУЭРТО-РИКО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 170, "RE", "REU", "Developer", "638", null, null, null, "РЕЮНЬОН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 171, "RU", "RUS", "Developer", "643", "Российская Федерация", null, null, "РОССИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 172, "RW", "RWA", "Developer", "646", "Руандийская Республика", null, null, "РУАНДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 173, "RO", "ROU", "Developer", "642", null, null, null, "РУМЫНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 174, "WS", "WSM", "Developer", "882", "Независимое Государство Самоа", null, null, "САМОА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 175, "SM", "SMR", "Developer", "674", "Республика Сан-Марино", null, null, "САН-МАРИНО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 176, "ST", "STP", "Developer", "678", "Демократическая Республика Сан-Томе и Принсипи", null, null, "САН-ТОМЕ И ПРИНСИПИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 177, "SA", "SAU", "Developer", "682", "Королевство Саудовская Аравия", null, null, "САУДОВСКАЯ АРАВИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 178, "SZ", "SWZ", "Developer", "748", "Королевство Свазиленд", null, null, "СВАЗИЛЕНД" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 179, "SH", "SHN", "Developer", "654", null, null, null, "СВЯТАЯ ЕЛЕНА, ОСТРОВ ВОЗНЕСЕНИЯ, ТРИСТАН-ДА-КУНЬЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 180, "MP", "MNP", "Developer", "580", "Содружество Северных Марианских островов", null, null, "СЕВЕРНЫЕ МАРИАНСКИЕ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 181, "SC", "SYC", "Developer", "690", "Республика Сейшелы", null, null, "СЕЙШЕЛЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 182, "BL", "BLM", "Developer", "652", null, null, null, "СЕН-БАРТЕЛЕМИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 183, "MF", "MAF", "Developer", "663", null, null, null, "СЕН-МАРТЕН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 184, "SX", "SXM", "Developer", "534", null, null, null, "СЕН-МАРТЕН (нидерландская часть)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 185, "SN", "SEN", "Developer", "686", "Республика Сенегал", null, null, "СЕНЕГАЛ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 186, "VC", "VCT", "Developer", "670", null, null, null, "СЕНТ-ВИНСЕНТ И ГРЕНАДИНЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 187, "KN", "KNA", "Developer", "659", null, null, null, "СЕНТ-КИТС И НЕВИС" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 160, "PS", "PSE", "Developer", "275", "Государство Палестина", null, null, "ПАЛЕСТИНА, ГОСУДАРСТВО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 159, "PW", "PLW", "Developer", "585", "Республика Палау", null, null, "ПАЛАУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 158, "PK", "PAK", "Developer", "586", "Исламская Республика Пакистан", null, null, "ПАКИСТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 157, "HM", "HMD", "Developer", "334", null, null, null, "ОСТРОВ ХЕРД И ОСТРОВА МАКДОНАЛЬД" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 129, "MX", "MEX", "Developer", "484", "Мексиканские Соединенные Штаты", null, null, "МЕКСИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 130, "FM", "FSM", "Developer", "583", "Федеративные Штаты Микронезии", null, null, "МИКРОНЕЗИЯ, ФЕДЕРАТИВНЫЕ ШТАТЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 131, "MZ", "MOZ", "Developer", "508", "Республика Мозамбик", null, null, "МОЗАМБИК" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 132, "MD", "MDA", "Developer", "498", "Республика Молдова", null, null, "МОЛДОВА, РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 133, "MC", "MCO", "Developer", "492", "Княжество Монако", null, null, "МОНАКО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 134, "MN", "MNG", "Developer", "496", null, null, null, "МОНГОЛИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 135, "MS", "MSR", "Developer", "500", null, null, null, "МОНТСЕРРАТ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 136, "MM", "MMR", "Developer", "104", "Республика Союза Мьянма", null, null, "МЬЯНМА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 137, "NA", "NAM", "Developer", "516", "Республика Намибия", null, null, "НАМИБИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 138, "NR", "NRU", "Developer", "520", "Республика Науру", null, null, "НАУРУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 139, "NP", "NPL", "Developer", "524", "Федеративная Демократическая Республика Непал", null, null, "НЕПАЛ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 140, "NE", "NER", "Developer", "562", "Республика Нигер", null, null, "НИГЕР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 141, "NG", "NGA", "Developer", "566", "Федеративная Республика Нигерия", null, null, "НИГЕРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 188, "LC", "LCA", "Developer", "662", null, null, null, "СЕНТ-ЛЮСИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 142, "NL", "NLD", "Developer", "528", "Королевство Нидерландов", null, null, "НИДЕРЛАНДЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 144, "NU", "NIU", "Developer", "570", "Ниуэ", null, null, "НИУЭ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 145, "NZ", "NZL", "Developer", "554", null, null, null, "НОВАЯ ЗЕЛАНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 146, "NC", "NCL", "Developer", "540", null, null, null, "НОВАЯ КАЛЕДОНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 147, "NO", "NOR", "Developer", "578", "Королевство Норвегия", null, null, "НОРВЕГИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 148, "AE", "ARE", "Developer", "784", null, null, null, "ОБЪЕДИНЕННЫЕ АРАБСКИЕ ЭМИРАТЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 149, "OM", "OMN", "Developer", "512", "Султанат Оман", null, null, "ОМАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 150, "KY", "CYM", "Developer", "136", null, null, null, "ОСТРОВА КАЙМАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 151, "CK", "COK", "Developer", "184", null, null, null, "ОСТРОВА КУКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 152, "TC", "TCA", "Developer", "796", null, null, null, "ОСТРОВА ТЕРКС И КАЙКОС" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 153, "BV", "BVT", "Developer", "074", null, null, null, "ОСТРОВ БУВЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 154, "IM", "IMN", "Developer", "833", null, null, null, "ОСТРОВ МЭН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 155, "NF", "NFK", "Developer", "574", null, null, null, "ОСТРОВ НОРФОЛК" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 156, "CX", "CXR", "Developer", "162", null, null, null, "ОСТРОВ РОЖДЕСТВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 143, "NI", "NIC", "Developer", "558", "Республика Никарагуа", null, null, "НИКАРАГУА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 128, "MH", "MHL", "Developer", "584", "Республика Маршалловы Острова", null, null, "МАРШАЛЛОВЫ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 189, "PM", "SPM", "Developer", "666", null, null, null, "СЕН-ПЬЕР И МИКЕЛОН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 191, "SG", "SGP", "Developer", "702", "Республика Сингапур", null, null, "СИНГАПУР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 224, "FK", "FLK", "Developer", "238", null, null, null, "ФОЛКЛЕНДСКИЕ ОСТРОВА (МАЛЬВИНСКИЕ)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 225, "FR", "FRA", "Developer", "250", "Французская Республика", null, null, "ФРАНЦИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 226, "GF", "GUF", "Developer", "254", null, null, null, "ФРАНЦУЗСКАЯ ГВИАНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 227, "PF", "PYF", "Developer", "258", null, null, null, "ФРАНЦУЗСКАЯ ПОЛИНЕЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 228, "TF", "ATF", "Developer", "260", null, null, null, "ФРАНЦУЗСКИЕ ЮЖНЫЕ ТЕРРИТОРИИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 229, "HR", "HRV", "Developer", "191", "Республика Хорватия", null, null, "ХОРВАТИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 230, "CF", "CAF", "Developer", "140", null, null, null, "ЦЕНТРАЛЬНО-АФРИКАНСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 231, "TD", "TCD", "Developer", "148", "Республика Чад", null, null, "ЧАД" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 232, "ME", "MNE", "Developer", "499", null, null, null, "ЧЕРНОГОРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 234, "CL", "CHL", "Developer", "152", "Республика Чили", null, null, "ЧИЛИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 235, "CH", "CHE", "Developer", "756", "Швейцарская Конфедерация", null, null, "ШВЕЙЦАРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 236, "SE", "SWE", "Developer", "752", "Королевство Швеция", null, null, "ШВЕЦИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 237, "SJ", "SJM", "Developer", "744", null, null, null, "ШПИЦБЕРГЕН И ЯН МАЙЕН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 238, "LK", "LKA", "Developer", "144", "Демократическая Социалистическая Республика Шри-Ланка", null, null, "ШРИ-ЛАНКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 239, "EC", "ECU", "Developer", "218", "Республика Эквадор", null, null, "ЭКВАДОР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 240, "GQ", "GNQ", "Developer", "226", "Республика Экваториальная Гвинея", null, null, "ЭКВАТОРИАЛЬНАЯ ГВИНЕЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 241, "AX", "ALA", "Developer", "248", null, null, null, "ЭЛАНДСКИЕ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 242, "SV", "SLV", "Developer", "222", "Республика Эль-Сальвадор", null, null, "ЭЛЬ-САЛЬВАДОР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 243, "ER", "ERI", "Developer", "232", null, null, null, "ЭРИТРЕЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 244, "EE", "EST", "Developer", "233", "Эстонская Республика", null, null, "ЭСТОНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 245, "ET", "ETH", "Developer", "231", "Федеративная Демократическая Республика Эфиопия", null, null, "ЭФИОПИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 246, "ZA", "ZAF", "Developer", "710", "Южно-Африканская Республика", null, null, "ЮЖНАЯ АФРИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 247, "GS", "SGS", "Developer", "239", null, null, null, "ЮЖНАЯ ДЖОРДЖИЯ И ЮЖНЫЕ САНДВИЧЕВЫ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 248, "OS", "OST", "Developer", "896", "Республика Южная Осетия", null, null, "ЮЖНАЯ ОСЕТИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 249, "SS", "SSD", "Developer", "728", "Республика Южный Судан", null, null, "ЮЖНЫЙ СУДАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 250, "JM", "JAM", "Developer", "388", null, null, null, "ЯМАЙКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 251, "JP", "JPN", "Developer", "392", null, null, null, "ЯПОНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 223, "FI", "FIN", "Developer", "246", "Финляндская Республика", null, null, "ФИНЛЯНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 222, "PH", "PHL", "Developer", "608", "Республика Филиппины", null, null, "ФИЛИППИНЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 221, "FJ", "FJI", "Developer", "242", "Республика Фиджи", null, null, "ФИДЖИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 220, "FO", "FRO", "Developer", "234", null, null, null, "ФАРЕРСКИЕ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 192, "SY", "SYR", "Developer", "760", null, null, null, "СИРИЙСКАЯ АРАБСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 193, "SK", "SVK", "Developer", "703", "Словацкая Республика", null, null, "СЛОВАКИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 194, "SI", "SVN", "Developer", "705", "Республика Словения", null, null, "СЛОВЕНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 195, "GB", "GBR", "Developer", "826", "Соединенное Королевство Великобритании и Северной Ирландии", null, null, "СОЕДИНЕННОЕ КОРОЛЕВСТВО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 196, "US", "USA", "Developer", "840", "Соединенные Штаты Америки", null, null, "СОЕДИНЕННЫЕ ШТАТЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 197, "SB", "SLB", "Developer", "090", null, null, null, "СОЛОМОНОВЫ ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 198, "SO", "SOM", "Developer", "706", "Федеративная Республика Сомали", null, null, "СОМАЛИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 199, "SD", "SDN", "Developer", "729", "Республика Судан", null, null, "СУДАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 200, "SR", "SUR", "Developer", "740", "Республика Суринам", null, null, "СУРИНАМ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 201, "SL", "SLE", "Developer", "694", "Республика Сьерра-Леоне", null, null, "СЬЕРРА-ЛЕОНЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 202, "TJ", "TJK", "Developer", "762", "Республика Таджикистан", null, null, "ТАДЖИКИСТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 203, "TH", "THA", "Developer", "764", "Королевство Таиланд", null, null, "ТАИЛАНД" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 204, "TW", "TWN", "Developer", "158", null, null, null, "ТАЙВАНЬ (КИТАЙ)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 190, "RS", "SRB", "Developer", "688", "Республика Сербия", null, null, "СЕРБИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 205, "TZ", "TZA", "Developer", "834", "Объединенная Республика Танзания", null, null, "ТАНЗАНИЯ, ОБЪЕДИНЕННАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 207, "TG", "TGO", "Developer", "768", "Тоголезская Республика", null, null, "ТОГО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 208, "TK", "TKL", "Developer", "772", null, null, null, "ТОКЕЛАУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 209, "TO", "TON", "Developer", "776", "Королевство Тонга", null, null, "ТОНГА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 210, "TT", "TTO", "Developer", "780", "Республика Тринидад и Тобаго", null, null, "ТРИНИДАД И ТОБАГО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 211, "TV", "TUV", "Developer", "798", null, null, null, "ТУВАЛУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 212, "TN", "TUN", "Developer", "788", "Тунисская Республика", null, null, "ТУНИС" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 213, "TM", "TKM", "Developer", "795", "Туркменистан", null, null, "ТУРКМЕНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 214, "TR", "TUR", "Developer", "792", "Турецкая Республика", null, null, "ТУРЦИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 215, "UG", "UGA", "Developer", "800", "Республика Уганда", null, null, "УГАНДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 216, "UZ", "UZB", "Developer", "860", "Республика Узбекистан", null, null, "УЗБЕКИСТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 217, "UA", "UKR", "Developer", "804", null, null, null, "УКРАИНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 218, "WF", "WLF", "Developer", "876", null, null, null, "УОЛЛИС И ФУТУНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 219, "UY", "URY", "Developer", "858", "Восточная Республика Уругвай", null, null, "УРУГВАЙ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 206, "TL", "TLS", "Developer", "626", "Демократическая Республика Тимор-Лесте", null, null, "ТИМОР-ЛЕСТЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 127, "MQ", "MTQ", "Developer", "474", null, null, null, "МАРТИНИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 233, "CZ", "CZE", "Developer", "203", "Чешская Республика", null, null, "ЧЕХИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 125, "MT", "MLT", "Developer", "470", "Республика Мальта", null, null, "МАЛЬТА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 33, "BN", "BRN", "Developer", "096", null, null, null, "БРУНЕЙ-ДАРУССАЛАМ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 34, "BF", "BFA", "Developer", "854", null, null, null, "БУРКИНА-ФАСО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 35, "BI", "BDI", "Developer", "108", "Республика Бурунди", null, null, "БУРУНДИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 36, "BT", "BTN", "Developer", "064", "Королевство Бутан", null, null, "БУТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 38, "HU", "HUN", "Developer", "348", null, null, null, "ВЕНГРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 39, "VE", "VEN", "Developer", "862", "Боливарианская Республика Венесуэла", null, null, "ВЕНЕСУЭЛА БОЛИВАРИАНСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 40, "VG", "VGB", "Developer", "092", "Британские Виргинские острова", null, null, "ВИРГИНСКИЕ ОСТРОВА, БРИТАНСКИЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 41, "VI", "VIR", "Developer", "850", "Виргинские острова Соединенных Штатов", null, null, "ВИРГИНСКИЕ ОСТРОВА, США" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 42, "VN", "VNM", "Developer", "704", "Социалистическая Республика Вьетнам", null, null, "ВЬЕТНАМ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 43, "GA", "GAB", "Developer", "266", "Габонская Республика", null, null, "ГАБОН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 44, "HT", "HTI", "Developer", "332", "Республика Гаити", null, null, "ГАИТИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 45, "GY", "GUY", "Developer", "328", "Республика Гайана", null, null, "ГАЙАНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 46, "GM", "GMB", "Developer", "270", "Исламская Республика Гамбия", null, null, "ГАМБИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 47, "GH", "GHA", "Developer", "288", "Республика Гана", null, null, "ГАНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 48, "GP", "GLP", "Developer", "312", null, null, null, "ГВАДЕЛУПА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 49, "GT", "GTM", "Developer", "320", "Республика Гватемала", null, null, "ГВАТЕМАЛА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 50, "GN", "GIN", "Developer", "324", "Гвинейская Республика", null, null, "ГВИНЕЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 51, "GW", "GNB", "Developer", "624", "Республика Гвинея-Бисау", null, null, "ГВИНЕЯ-БИСАУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 52, "DE", "DEU", "Developer", "276", "Федеративная Республика Германия", null, null, "ГЕРМАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 53, "GG", "GGY", "Developer", "831", null, null, null, "ГЕРНСИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 54, "GI", "GIB", "Developer", "292", null, null, null, "ГИБРАЛТАР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 55, "HN", "HND", "Developer", "340", "Республика Гондурас", null, null, "ГОНДУРАС" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 56, "HK", "HKG", "Developer", "344", "Специальный административный регион Китая Гонконг", null, null, "ГОНКОНГ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 57, "GD", "GRD", "Developer", "308", null, null, null, "ГРЕНАДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 58, "GL", "GRL", "Developer", "304", null, null, null, "ГРЕНЛАНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 59, "GR", "GRC", "Developer", "300", "Греческая Республика", null, null, "ГРЕЦИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 60, "GE", "GEO", "Developer", "268", null, null, null, "ГРУЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 32, "IO", "IOT", "Developer", "086", null, null, null, "БРИТАНСКАЯ ТЕРРИТОРИЯ В ИНДИЙСКОМ ОКЕАНЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 31, "BR", "BRA", "Developer", "076", "Федеративная Республика Бразилия", null, null, "БРАЗИЛИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 30, "BW", "BWA", "Developer", "072", "Республика Ботсвана", null, null, "БОТСВАНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 29, "BA", "BIH", "Developer", "070", null, null, null, "БОСНИЯ И ГЕРЦЕГОВИНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 126, "MA", "MAR", "Developer", "504", "Королевство Марокко", null, null, "МАРОККО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "AU", "AUS", "Developer", "036", null, null, null, "АВСТРАЛИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "AT", "AUT", "Developer", "040", "Австрийская Республика", null, null, "АВСТРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "AZ", "AZE", "Developer", "031", "Республика Азербайджан", null, null, "АЗЕРБАЙДЖАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "AL", "ALB", "Developer", "008", "Республика Албания", null, null, "АЛБАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "DZ", "DZA", "Developer", "012", "Алжирская Народная Демократическая Республика", null, null, "АЛЖИР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "AS", "ASM", "Developer", "016", null, null, null, "АМЕРИКАНСКОЕ САМОА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "AI", "AIA", "Developer", "660", null, null, null, "АНГИЛЬЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 9, "AO", "AGO", "Developer", "024", "Республика Ангола", null, null, "АНГОЛА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 10, "AD", "AND", "Developer", "020", "Княжество Андорра", null, null, "АНДОРРА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 11, "AQ", "ATA", "Developer", "010", null, null, null, "АНТАРКТИДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 12, "AG", "ATG", "Developer", "028", null, null, null, "АНТИГУА И БАРБУДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 13, "AR", "ARG", "Developer", "032", "Аргентинская Республика", null, null, "АРГЕНТИНА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 61, "GU", "GUM", "Developer", "316", null, null, null, "ГУАМ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 14, "AM", "ARM", "Developer", "051", "Республика Армения", null, null, "АРМЕНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 16, "AF", "AFG", "Developer", "004", "Переходное Исламское Государство Афганистан", null, null, "АФГАНИСТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 17, "BS", "BHS", "Developer", "044", "Содружество Багамы", null, null, "БАГАМЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 18, "BD", "BGD", "Developer", "050", "Народная Республика Бангладеш", null, null, "БАНГЛАДЕШ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 19, "BB", "BRB", "Developer", "052", null, null, null, "БАРБАДОС" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 20, "BH", "BHR", "Developer", "048", "Королевство Бахрейн", null, null, "БАХРЕЙН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 21, "BY", "BLR", "Developer", "112", "Республика Беларусь", null, null, "БЕЛАРУСЬ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 22, "BZ", "BLZ", "Developer", "084", null, null, null, "БЕЛИЗ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 23, "BE", "BEL", "Developer", "056", "Королевство Бельгии", null, null, "БЕЛЬГИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 24, "BJ", "BEN", "Developer", "204", "Республика Бенин", null, null, "БЕНИН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 25, "BM", "BMU", "Developer", "060", null, null, null, "БЕРМУДЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 26, "BG", "BGR", "Developer", "100", "Республика Болгария", null, null, "БОЛГАРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 27, "BO", "BOL", "Developer", "068", "Многонациональное Государство Боливия", null, null, "БОЛИВИЯ, МНОГОНАЦИОНАЛЬНОЕ ГОСУДАРСТВО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 28, "BQ", "BES", "Developer", "535", null, null, null, "БОНЭЙР, СИНТ-ЭСТАТИУС И САБА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 15, "AW", "ABW", "Developer", "533", null, null, null, "АРУБА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 62, "DK", "DNK", "Developer", "208", "Королевство Дания", null, null, "ДАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 37, "VU", "VUT", "Developer", "548", "Республика Вануату", null, null, "ВАНУАТУ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 64, "DJ", "DJI", "Developer", "262", "Республика Джибути", null, null, "ДЖИБУТИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 97, "CD", "COD", "Developer", "180", null, null, null, "КОНГО, ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 98, "KP", "PRK", "Developer", "408", "Корейская Народно-Демократическая Республика", null, null, "КОРЕЯ, НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 99, "KR", "KOR", "Developer", "410", "Республика Корея", null, null, "КОРЕЯ, РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 100, "CR", "CRI", "Developer", "188", "Республика Коста-Рика", null, null, "КОСТА-РИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 101, "CI", "CIV", "Developer", "384", "Республика Кот д’Ивуар", null, null, "КОТ Д’ИВУАР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 102, "CU", "CUB", "Developer", "192", "Республика Куба", null, null, "КУБА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 103, "KW", "KWT", "Developer", "414", "Государство Кувейт", null, null, "КУВЕЙТ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 104, "CW", "CUW", "Developer", "531", null, null, null, "КЮРАСАО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 105, "LA", "LAO", "Developer", "418", null, null, null, "ЛАОССКАЯ НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 106, "LV", "LVA", "Developer", "428", "Латвийская Республика", null, null, "ЛАТВИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 107, "LS", "LSO", "Developer", "426", "Королевство Лесото", null, null, "ЛЕСОТО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 108, "LR", "LBR", "Developer", "430", "Республика Либерия", null, null, "ЛИБЕРИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 109, "LB", "LBN", "Developer", "422", "Ливанская Республика", null, null, "ЛИВАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 96, "CG", "COG", "Developer", "178", "Республика Конго", null, null, "КОНГО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 110, "LY", "LBY", "Developer", "434", "Ливия", null, null, "ЛИВИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 112, "LI", "LIE", "Developer", "438", "Княжество Лихтенштейн", null, null, "ЛИХТЕНШТЕЙН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 113, "LU", "LUX", "Developer", "442", "Великое Герцогство Люксембург", null, null, "ЛЮКСЕМБУРГ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 114, "MU", "MUS", "Developer", "480", "Республика Маврикий", null, null, "МАВРИКИЙ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 115, "MR", "MRT", "Developer", "478", "Исламская Республика Мавритания", null, null, "МАВРИТАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 116, "MG", "MDG", "Developer", "450", "Республика Мадагаскар", null, null, "МАДАГАСКАР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 117, "YT", "MYT", "Developer", "175", null, null, null, "МАЙОТТА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 63, "JE", "JEY", "Developer", "832", null, null, null, "ДЖЕРСИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 119, "MK", "MKD", "Developer", "807", null, null, null, "РЕСПУБЛИКА МАКЕДОНИЯ[2]" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 120, "MW", "MWI", "Developer", "454", "Республика Малави", null, null, "МАЛАВИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 121, "MY", "MYS", "Developer", "458", null, null, null, "МАЛАЙЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 122, "ML", "MLI", "Developer", "466", "Республика Мали", null, null, "МАЛИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 123, "UM", "UMI", "Developer", "581", null, null, null, "МАЛЫЕ ТИХООКЕАНСКИЕ ОТДАЛЕННЫЕ ОСТРОВА СОЕДИНЕННЫХ ШТАТОВ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 124, "MV", "MDV", "Developer", "462", "Мальдивская Республика", null, null, "МАЛЬДИВЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 111, "LT", "LTU", "Developer", "440", "Литовская Республика", null, null, "ЛИТВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 95, "KM", "COM", "Developer", "174", "Союз Коморы", null, null, "КОМОРЫ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 118, "MO", "MAC", "Developer", "446", "Специальный административный регион Китая Макао", null, null, "МАКАО" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 93, "CC", "CCK", "Developer", "166", null, null, null, "КОКОСОВЫЕ (КИЛИНГ) ОСТРОВА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 66, "DO", "DOM", "Developer", "214", null, null, null, "ДОМИНИКАНСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 67, "EG", "EGY", "Developer", "818", "Арабская Республика Египет", null, null, "ЕГИПЕТ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 68, "ZM", "ZMB", "Developer", "894", "Республика Замбия", null, null, "ЗАМБИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 69, "EH", "ESH", "Developer", "732", null, null, null, "ЗАПАДНАЯ САХАРА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 70, "ZW", "ZWE", "Developer", "716", "Республика Зимбабве", null, null, "ЗИМБАБВЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 71, "IL", "ISR", "Developer", "376", "Государство Израиль", null, null, "ИЗРАИЛЬ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 72, "IN", "IND", "Developer", "356", "Республика Индия", null, null, "ИНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 73, "ID", "IDN", "Developer", "360", "Республика Индонезия", null, null, "ИНДОНЕЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 74, "JO", "JOR", "Developer", "400", "Иорданское Хашимитское Королевство", null, null, "ИОРДАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 76, "IR", "IRN", "Developer", "364", "Исламская Республика Иран", null, null, "ИРАН, ИСЛАМСКАЯ РЕСПУБЛИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 77, "IE", "IRL", "Developer", "372", null, null, null, "ИРЛАНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 78, "IS", "ISL", "Developer", "352", "Республика Исландия", null, null, "ИСЛАНДИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 79, "ES", "ESP", "Developer", "724", "Королевство Испания", null, null, "ИСПАНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 80, "IT", "ITA", "Developer", "380", "Итальянская Республика", null, null, "ИТАЛИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 75, "IQ", "IRQ", "Developer", "368", "Республика Ирак", null, null, "ИРАК" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 82, "CV", "CPV", "Developer", "132", "Республика Кабо-Верде", null, null, "КАБО-ВЕРДЕ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 92, "CN", "CHN", "Developer", "156", "Китайская Народная Республика", null, null, "КИТАЙ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 81, "YE", "YEM", "Developer", "887", "Йеменская Республика", null, null, "ЙЕМЕН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 90, "KG", "KGZ", "Developer", "417", "Киргизская Республика", null, null, "КИРГИЗИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 89, "CY", "CYP", "Developer", "196", "Республика Кипр", null, null, "КИПР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 65, "DM", "DMA", "Developer", "212", "Содружество Доминики", null, null, "ДОМИНИКА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 88, "KE", "KEN", "Developer", "404", "Республика Кения", null, null, "КЕНИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 91, "KI", "KIR", "Developer", "296", "Республика Кирибати", null, null, "КИРИБАТИ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 86, "CA", "CAN", "Developer", "124", null, null, null, "КАНАДА" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 87, "QA", "QAT", "Developer", "634", "Государство Катар", null, null, "КАТАР" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 83, "KZ", "KAZ", "Developer", "398", "Республика Казахстан", null, null, "КАЗАХСТАН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 94, "CO", "COL", "Developer", "170", "Республика Колумбия", null, null, "КОЛУМБИЯ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 85, "CM", "CMR", "Developer", "120", "Республика Камерун", null, null, "КАМЕРУН" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlphaCode2", "AlphaCode3", "Author", "Code", "FullName", "Modified", "Modifier", "Name" },
                values: new object[] { 84, "KH", "KHM", "Developer", "116", "Королевство Камбоджа", null, null, "КАМБОДЖА" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Среднее профессиональное" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "Незаконченное высшее" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "Высшее, специалитет, магистратура" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "Высшее образование и MBA" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Два и более высших образований" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", null, null, "Кандидат наук" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "08", null, null, "Доктор наук" });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "Высшее, бакалавриат" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Свыше 1000" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "От 101 до 500" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "От 501 до 1000" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "От 51 до 100" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "До 10" });

            migrationBuilder.InsertData(
                table: "EmployeesNumbers",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "От 11 до 50" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Центральный" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "Северо-Западный" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "Южный" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "Северо-Кавказский" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "Приволжский" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Уральский" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", null, null, "Сибирский" });

            migrationBuilder.InsertData(
                table: "FederalDistricts",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "08", null, null, "Дальневосточный" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 6, "Developer", "26", null, null, "Паспорт моряка", "бб 9999999", "[А-Я]{2} \\d{6,7}" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 5, "Developer", "24", null, null, "Удостоверение личности военнослужащего Российской Федерации", "бб 9999999", "[А-Я]{2} \\d{7}" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 4, "Developer", "04", null, null, "Удостоверение личности офицера", "бб 9999999", "[А-Я]{2} \\d{6,7}" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 2, "Developer", "22", null, null, "Загранпаспорт", "99 9999999", "\\d{2} \\d{7}" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 1, "Developer", "21", null, null, "Паспорт", "99 99 9999999", "\\d{2} ?\\d{2} \\d{6,7}" });

            migrationBuilder.InsertData(
                table: "IdentityDocuments",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "NumberFormat", "NumberRegex" },
                values: new object[] { 3, "Developer", "27", null, null, "Военный билет", "бб 9999999", "[А-Я]{2} \\d{6,7}" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 36, "Developer", "36", null, null, "Спорт и отдых" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 29, "Developer", "29", null, null, "Пищевая промышленность" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 30, "Developer", "30", null, null, "Работа с персоналом" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 31, "Developer", "31", null, null, "Реклама и маркетинг" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 28, "Developer", "28", null, null, "Переработка сырья и вторсырья" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 32, "Developer", "32", null, null, "Религиозные организации" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 27, "Developer", "27", null, null, "Оптовая торговля" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 33, "Developer", "33", null, null, "Рестораны и заведения общественного питания" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 34, "Developer", "34", null, null, "Ритейл" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 35, "Developer", "35", null, null, "Сельское хозяйство" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 37, "Developer", "37", null, null, "Строительство" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 45, "Developer", "45", null, null, "Электроника и электротехника" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 39, "Developer", "39", null, null, "Телекоммуникации и связь" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 40, "Developer", "40", null, null, "Товары повседневного спроса" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 41, "Developer", "41", null, null, "Транспорт и логистика" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 42, "Developer", "42", null, null, "Туризм и гостиничный бизнес" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 43, "Developer", "43", null, null, "Фармацевтика" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 44, "Developer", "44", null, null, "Финансы и инвестиции" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 46, "Developer", "46", null, null, "Энергетика" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 47, "Developer", "47", null, null, "Химическая промышленность" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 48, "Developer", "48", null, null, "Экология" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 49, "Developer", "49", null, null, "Юридические услуги" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 38, "Developer", "38", null, null, "Судостроение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 26, "Developer", "26", null, null, "Общественные организации и профсоюзы" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 17, "Developer", "17", null, null, "Лесозаготовка и производство изделий из дерева" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 24, "Developer", "24", null, null, "Образование" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 25, "Developer", "25", null, null, "Обслуживание населения" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Авиастроение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "Автомобилестроение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "Банки и страхование" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "Безопасность и охрана" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "Военная служба" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Государственная служба" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", null, null, "Гражданская авиация" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "08", null, null, "Гражданская служба" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 9, "Developer", "09", null, null, "Добыча полезных ископаемых" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 10, "Developer", "10", null, null, "Здравоохранение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 11, "Developer", "11", null, null, "ЖКХ, Муниципальные учреждения" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 12, "Developer", "12", null, null, "Издательская деятельность и СМИ" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 13, "Developer", "13", null, null, "Информационные технологии" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 14, "Developer", "14", null, null, "Искусство, культура и развлечения" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 15, "Developer", "15", null, null, "Кино, радио и телевидение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 16, "Developer", "16", null, null, "Консалтинг" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 18, "Developer", "18", null, null, "Машиностроение" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 19, "Developer", "19", null, null, "Металлургия" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 20, "Developer", "20", null, null, "Научные исследования и разработки" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 21, "Developer", "21", null, null, "Недвижимость" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 22, "Developer", "22", null, null, "Нефтехимическая промышленность" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 23, "Developer", "23", null, null, "Нефтепереработка, добыча" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "beginner", null, null, "Начальный" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "elementary", null, null, "Элементарный" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "advance", null, null, "В совершенстве" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "intermediate", null, null, "Средний" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "upper-intermediate", null, null, "Выше среднего" });

            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "pre-intermediate", null, null, "Ниже среднего" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 65, "Developer", "som", null, null, "Сомали" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 64, "Developer", "slv", null, null, "Словенский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 63, "Developer", "slk", null, null, "Словацкий" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 62, "Developer", "syr", null, null, "Сирийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 61, "Developer", "srp", null, null, "Сербский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 60, "Developer", "san", null, null, "Санскрит" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 59, "Developer", "rus", null, null, "Русский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 58, "Developer", "ron", null, null, "Румынский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 66, "Developer", "swa", null, null, "Суахили" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 55, "Developer", "pol", null, null, "Польский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 54, "Developer", "nor", null, null, "Норвежский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 53, "Developer", "nld", null, null, "Нидерландский (Голландский)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 52, "Developer", "nep", null, null, "Непальский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 51, "Developer", "deu", null, null, "Немецкий", 90 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 50, "Developer", "mon", null, null, "Монгольский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 49, "Developer", "—", null, null, "Молдавский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 56, "Developer", "por", null, null, "Португальский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 67, "Developer", "tgk", null, null, "Таджикский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 81, "Developer", "hrv", null, null, "Хорватский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 69, "Developer", "tat", null, null, "Татарский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 86, "Developer", "jpn", null, null, "Японский", 80 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 85, "Developer", "jav", null, null, "Яванский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 84, "Developer", "est", null, null, "Эстонский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 83, "Developer", "sco", null, null, "Шотландский (англо-шотландский)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 82, "Developer", "ces", null, null, "Чешский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 48, "Developer", "mah", null, null, "Маршалльский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 80, "Developer", "hin", null, null, "Хинди" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 79, "Developer", "fra", null, null, "Французский", 100 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 78, "Developer", "fin", null, null, "Финский (Suomi)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 77, "Developer", "phn", null, null, "Финикийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 76, "Developer", "fil", null, null, "Филиппинский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 75, "Developer", "fij", null, null, "Фиджи" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 74, "Developer", "ukr", null, null, "Украинский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 73, "Developer", "uzb", null, null, "Узбекский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 72, "Developer", "tuk", null, null, "Туркменский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 71, "Developer", "tur", null, null, "Турецкий" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 70, "Developer", "bod", null, null, "Тибетский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 68, "Developer", "tha", null, null, "Тайский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 47, "Developer", "mlt", null, null, "Мальтийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 57, "Developer", "kin", null, null, "Руанда" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 45, "Developer", "mlg", null, null, "Малагасийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 20, "Developer", "kal", null, null, "Гренландский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 19, "Developer", "haw", null, null, "Гавайский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 18, "Developer", "vie", null, null, "Вьетнамский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 17, "Developer", "hun", null, null, "Венгерский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 16, "Developer", "cym", null, null, "Валлийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 15, "Developer", "bre", null, null, "Бретонский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 14, "Developer", "bos", null, null, "Боснийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 13, "Developer", "bul", null, null, "Болгарский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 12, "Developer", "mya", null, null, "Бирманский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 21, "Developer", "ell", null, null, "Греческий (новогреческий)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 11, "Developer", "bel", null, null, "Белорусский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 9, "Developer", "ban", null, null, "Балийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "afr", null, null, "Африкаанс" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "aii", null, null, "Ассирийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "ara", null, null, "Арабский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 4, "Developer", "eng", null, null, "Английский", 100 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "sqi", null, null, "Албанский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "aze", null, null, "Азербайджанский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "abk", null, null, "Абхазский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 46, "Developer", "msa", null, null, "Малайский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 10, "Developer", "eus", null, null, "Баскский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 22, "Developer", "kat", null, null, "Грузинский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "hye/axm/xcl", null, null, "Армянский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 24, "Developer", "jrb", null, null, "Еврейско-арабский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 44, "Developer", "mkd", null, null, "Македонский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 43, "Developer", "mad", null, null, "Мадурский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 42, "Developer", "ltz", null, null, "Люксембургский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 41, "Developer", "lit", null, null, "Литовский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 40, "Developer", "lav", null, null, "Латышский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 39, "Developer", "lao", null, null, "Лаосский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 23, "Developer", "dan", null, null, "Датский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 37, "Developer", "kor", null, null, "Корейский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 36, "Developer", "kon", null, null, "Конго" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 35, "Developer", "zho", null, null, "Китайский", 80 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 38, "Developer", "kur", null, null, "Курдский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 33, "Developer", "cat", null, null, "Каталанский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 25, "Developer", "jpr", null, null, "Еврейско-персидский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 34, "Developer", "kir", null, null, "Киргизский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 27, "Developer", "ind", null, null, "Индонезийский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 28, "Developer", "gle", null, null, "Ирландский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 26, "Developer", "heb", null, null, "Иврит" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 30, "Developer", "spa", null, null, "Испанский", 80 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name", "Weight" },
                values: new object[] { 31, "Developer", "ita", null, null, "Итальянский", 80 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 32, "Developer", "kaz", null, null, "Казахский" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 29, "Developer", "isl", null, null, "Исландский" });

            migrationBuilder.InsertData(
                table: "ManagementExperiences",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Менее 2 лет" });

            migrationBuilder.InsertData(
                table: "ManagementExperiences",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "От 2 до 5 лет" });

            migrationBuilder.InsertData(
                table: "ManagementExperiences",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "От 5 до 10 лет" });

            migrationBuilder.InsertData(
                table: "ManagementExperiences",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "10 лет и более" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", null, null, "Ведущий специалист" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Линейное/функциональное руководство" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "Руководство среднего звена" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "Член правления" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "Глава организации" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Акционер/собственник" });

            migrationBuilder.InsertData(
                table: "ManagementLevels",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "Руководство высшего звена" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 13, "Developer", "pinterest", "pinterest", "#ee2d34", null, null, "Pinterest", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 12, "Developer", "tumblr", "tumblr", "#395976", null, null, "Tumblr", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 11, "Developer", "google-plus", "google-plus", "#ce3525", null, null, "Google+", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 9, "Developer", "telegram", "telegram", "#29a7d9", null, null, "Telegram", "Messenger" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 8, "Developer", "skype", "skype", "#00aff0", null, null, "Skype", "Messenger" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 7, "Developer", "viber", "viber", "#574e92", null, null, "Viber", "Messenger" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 10, "Developer", "youtube", "youtube", "#ff0000", null, null, "YouTube", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 5, "Developer", "instagram", "instagram", "#ff5241", null, null, "Instagram", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 4, "Developer", "twitter", "twitter", "#1da1f2", null, null, "Twitter", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 3, "Developer", "ok", "odnoklassniki", "#ee8208", null, null, "Одноклассники", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 2, "Developer", "vk", "vk", "#4a76a8", null, null, "ВКонтакте", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 1, "Developer", "facebook", "facebook", "#3b5998", null, null, "Facebook", "SocialNetwork" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Author", "Code", "Icon", "IconColor", "Modified", "Modifier", "Name", "Type" },
                values: new object[] { 6, "Developer", "whatsapp", "whatsapp", "#00E676", null, null, "WhatsApp", "Messenger" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 12, "Developer", "12", null, null, "Охрана труда" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 20, "Developer", "20", null, null, "Управления персоналом" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 19, "Developer", "19", null, null, "Управление рисками" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 18, "Developer", "18", null, null, "Управление проектами" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 17, "Developer", "17", null, null, "Стратегический менеджмент" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 16, "Developer", "16", null, null, "Снабжение и закупки" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 15, "Developer", "15", null, null, "Связи с общественностью" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 14, "Developer", "14", null, null, "Производство" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 13, "Developer", "13", null, null, "Продажи" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 11, "Developer", "11", null, null, "Отношения с органами власти" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 21, "Developer", "21", null, null, "Финансы" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 9, "Developer", "09", null, null, "Маркетинг" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "08", null, null, "Логистика" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", null, null, "IT" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", null, null, "Делопроизводство" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", null, null, "Высшее руководство" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", null, null, "Безопасность" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", null, null, "Аудит" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", null, null, "Аналитика и исследования" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", null, null, "Административно-хозяйственное направление" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 10, "Developer", "10", null, null, "Обучение" });

            migrationBuilder.InsertData(
                table: "WorkAreas",
                columns: new[] { "Id", "Author", "Code", "Modified", "Modifier", "Name" },
                values: new object[] { 22, "Developer", "22", null, null, "Юриспруденция" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 31, "Developer", "31", 1, null, null, "Белгородская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 72, "Developer", "72", 6, null, null, "Тюменская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 66, "Developer", "66", 6, null, null, "Свердловская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 45, "Developer", "45", 6, null, null, "Курганская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 73, "Developer", "73", 5, null, null, "Ульяновская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 64, "Developer", "64", 5, null, null, "Саратовская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 63, "Developer", "63", 5, null, null, "Самарская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 59, "Developer", "59", 5, null, null, "Пермский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 58, "Developer", "58", 5, null, null, "Пензенская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 56, "Developer", "56", 5, null, null, "Оренбургская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 52, "Developer", "52", 5, null, null, "Нижегородская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 43, "Developer", "43", 5, null, null, "Кировская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 21, "Developer", "21", 5, null, null, "Чувашская Республика - Чувашия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 18, "Developer", "18", 5, null, null, "Удмуртская Республика" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 16, "Developer", "16", 5, null, null, "Республика Татарстан (Татарстан)" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 13, "Developer", "13", 5, null, null, "Республика Мордовия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 12, "Developer", "12", 5, null, null, "Республика Марий Эл" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 2, "Developer", "02", 5, null, null, "Республика Башкортостан" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 74, "Developer", "74", 6, null, null, "Челябинская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 86, "Developer", "86", 6, null, null, "Ханты-Мансийский автономный округ - Югра" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 89, "Developer", "89", 6, null, null, "Ямало-Ненецкий автономный округ" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 4, "Developer", "04", 7, null, null, "Республика Алтай" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 75, "Developer", "75", 8, null, null, "Забайкальский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 65, "Developer", "65", 8, null, null, "Сахалинская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 49, "Developer", "49", 8, null, null, "Магаданская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 41, "Developer", "41", 8, null, null, "Камчатский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 28, "Developer", "28", 8, null, null, "Амурская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 27, "Developer", "27", 8, null, null, "Хабаровский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 25, "Developer", "25", 8, null, null, "Приморский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 14, "Developer", "14", 8, null, null, "Республика Саха (Якутия)" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 26, "Developer", "26", 4, null, null, "Ставропольский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 3, "Developer", "03", 8, null, null, "Республика Бурятия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 55, "Developer", "55", 7, null, null, "Омская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 54, "Developer", "54", 7, null, null, "Новосибирская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 42, "Developer", "42", 7, null, null, "Кемеровская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 38, "Developer", "38", 7, null, null, "Иркутская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 24, "Developer", "24", 7, null, null, "Красноярский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 22, "Developer", "22", 7, null, null, "Алтайский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 19, "Developer", "19", 7, null, null, "Республика Хакасия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 17, "Developer", "17", 7, null, null, "Республика Тыва" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 70, "Developer", "70", 7, null, null, "Томская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 79, "Developer", "79", 8, null, null, "Еврейская автономная область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 20, "Developer", "20", 4, null, null, "Чеченская Республика" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 9, "Developer", "09", 4, null, null, "Карачаево-Черкесская Республика" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 77, "Developer", "77", 1, null, null, "Москва" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 76, "Developer", "76", 1, null, null, "Ярославская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 71, "Developer", "71", 1, null, null, "Тульская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 69, "Developer", "69", 1, null, null, "Тверская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 68, "Developer", "68", 1, null, null, "Тамбовская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 67, "Developer", "67", 1, null, null, "Смоленская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 62, "Developer", "62", 1, null, null, "Рязанская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 57, "Developer", "57", 1, null, null, "Орловская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 50, "Developer", "50", 1, null, null, "Московская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 48, "Developer", "48", 1, null, null, "Липецкая область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 46, "Developer", "46", 1, null, null, "Курская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 44, "Developer", "44", 1, null, null, "Костромская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 40, "Developer", "40", 1, null, null, "Калужская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 37, "Developer", "37", 1, null, null, "Ивановская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 36, "Developer", "36", 1, null, null, "Воронежская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 33, "Developer", "33", 1, null, null, "Владимирская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 32, "Developer", "32", 1, null, null, "Брянская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 10, "Developer", "10", 2, null, null, "Республика Карелия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 11, "Developer", "11", 2, null, null, "Республика Коми" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 29, "Developer", "29", 2, null, null, "Архангельская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 35, "Developer", "35", 2, null, null, "Вологодская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 7, "Developer", "07", 4, null, null, "Кабардино-Балкарская Республика" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 6, "Developer", "06", 4, null, null, "Республика Ингушетия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 5, "Developer", "05", 4, null, null, "Республика Дагестан" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 92, "Developer", "92", 3, null, null, "Севастополь" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 91, "Developer", "91", 3, null, null, "Республика Крым" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 61, "Developer", "61", 3, null, null, "Ростовская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 34, "Developer", "34", 3, null, null, "Волгоградская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 30, "Developer", "30", 3, null, null, "Астраханская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 15, "Developer", "15", 4, null, null, "Республика Северная Осетия - Алания" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 23, "Developer", "23", 3, null, null, "Краснодарский край" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 1, "Developer", "01", 3, null, null, "Республика Адыгея" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 83, "Developer", "83", 2, null, null, "Ненецкий автономный округ" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 78, "Developer", "78", 2, null, null, "Санкт-Петербург" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 60, "Developer", "60", 2, null, null, "Псковская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 53, "Developer", "53", 2, null, null, "Новгородская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 51, "Developer", "51", 2, null, null, "Мурманская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 47, "Developer", "47", 2, null, null, "Ленинградская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 39, "Developer", "39", 2, null, null, "Калининградская область" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 8, "Developer", "08", 3, null, null, "Республика Калмыкия" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Author", "Code", "FederalDistrictId", "Modified", "Modifier", "Name" },
                values: new object[] { 87, "Developer", "87", 8, null, null, "Чукотский автономный округ" });

            migrationBuilder.CreateIndex(
                name: "UX_Country_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_EducationLevel_Code",
                table: "EducationLevels",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_EmployeesNumber_Code",
                table: "EmployeesNumbers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_FederalDistrict_Code",
                table: "FederalDistricts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_IdentityDocument_Code",
                table: "IdentityDocuments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Industry_Code",
                table: "Industries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_LanguageLevel_Code",
                table: "LanguageLevels",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Language_Code",
                table: "Languages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_ManagementExperience_Code",
                table: "ManagementExperiences",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_ManagementLevel_Code",
                table: "ManagementLevels",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducation_EducationLevelId",
                table: "PersonEducation",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducation_PersonId",
                table: "PersonEducation",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_EmployeesNumberId",
                table: "PersonJob",
                column: "EmployeesNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_IndustryId",
                table: "PersonJob",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_ManagementExperienceId",
                table: "PersonJob",
                column: "ManagementExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_ManagementLevelId",
                table: "PersonJob",
                column: "ManagementLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_PersonId",
                table: "PersonJob",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonJob_WorkAreaId",
                table: "PersonJob",
                column: "WorkAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageLevelId",
                table: "PersonLanguage",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_PersonId",
                table: "PersonLanguage",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FederalDistrictId",
                table: "Persons",
                column: "FederalDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentityDocumentId",
                table: "Persons",
                column: "IdentityDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NationalityId",
                table: "Persons",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegionId",
                table: "Persons",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialNetwork_PersonId",
                table: "PersonSocialNetwork",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialNetwork_SocialNetworkId",
                table: "PersonSocialNetwork",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "UX_Region_Code",
                table: "Region",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Region_FederalDistrictId",
                table: "Region",
                column: "FederalDistrictId");

            migrationBuilder.CreateIndex(
                name: "UX_SocialNetwork_Code",
                table: "SocialNetworks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_WorkArea_Code",
                table: "WorkAreas",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonEducation");

            migrationBuilder.DropTable(
                name: "PersonJob");

            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.DropTable(
                name: "PersonSocialNetwork");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "EmployeesNumbers");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "ManagementExperiences");

            migrationBuilder.DropTable(
                name: "ManagementLevels");

            migrationBuilder.DropTable(
                name: "WorkAreas");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "IdentityDocuments");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "FederalDistricts");
        }
    }
}
