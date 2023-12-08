using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ads.Dal.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    ConditionEnum = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    DarkMode = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertComments_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvertImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertImages_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubcategoryAdverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcategoryAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubcategoryAdverts_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    DetailedAddress = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d0dd58b0-a281-4ca8-8f00-226852a9b2dd", "Superadmin", "SUPERADMIN" },
                    { 2, "b55dc9ac-4fc6-470b-a8ec-8ec8cfd851fb", "Admin", "ADMIN" },
                    { 3, "0efb4b3b-fd9b-4677-ad47-341023e2b8e4", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "741e9e7a-6ebd-4703-99a2-697e39907179", new DateTime(2023, 12, 8, 19, 59, 22, 392, DateTimeKind.Local).AddTicks(4579), null, "superadmin@gmail.com", true, "SuperAdmin", "deneme", true, "SuperAdmin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEHi1TbrI8SYZfL1nUvkQ1a1VBlv1L7+zkbx6lfDnDQkT91yjf5oOsrmYhjgb21h8wA==", "+000000000", true, "759da058-f834-4a5f-8605-e2411d8d05a1", false, null, "superadmin@gmail.com" },
                    { 2, 0, "b8625f3f-fcde-46d2-b5c7-465106a2a1e5", new DateTime(2023, 12, 8, 19, 59, 22, 447, DateTimeKind.Local).AddTicks(8954), null, "admin@gmail.com", false, "Admin", "deneme", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBaSFlMkvRgL0N0rZBA7QegvngveIvLmVsulWcdxz3mSH0165c5QlRIWSQy8DJMWDg==", "+000000000", false, "351560e6-1f56-4293-8a1a-c3be1e781eab", false, null, "admin@gmail.com" },
                    { 3, 0, "2a66ed0e-9e90-4557-a992-f532874b03ca", new DateTime(2023, 12, 8, 19, 59, 22, 501, DateTimeKind.Local).AddTicks(4089), null, "arasmentese96@gmail.com", false, "Aras", "deneme", true, "Menteşe", false, null, "arasmentese96@GMAIL.COM", "arasmentese96@GMAIL.COM", "AQAAAAIAAYagAAAAEAHifnfMUM8T2Q5q/QK+iM/Z3BsBEclbEFLINe5zSRoeo/cf7eakNKQkTEoSPBF3Tw==", "+000000000", false, "6d70da96-927d-497a-8e67-6b5969a91125", false, null, "arasmentese96@gmail.com" },
                    { 4, 0, "ead9a162-64f7-41d3-b8a5-ec067ea3638a", new DateTime(2023, 12, 8, 19, 59, 22, 555, DateTimeKind.Local).AddTicks(4100), null, "elif@gmail.com", false, "Elif", "deneme", true, "Sakçı Tuncer", false, null, "ELIF@GMAIL.COM", "ELIF@GMAIL.COM", "AQAAAAIAAYagAAAAEGAdI21tzStaJNqUds3csNql34xgCDJIwSHkhsdd/61KKo1mEgj/7Y6qZF/0nP8DaA==", "+000000000", false, "ab0d403e-b584-41fa-9aaf-f4d1b7fdeb2a", false, null, "elif@gmail.com" },
                    { 5, 0, "4aa75991-1ec3-4b73-aaea-47008457ad8e", new DateTime(2023, 12, 8, 19, 59, 22, 611, DateTimeKind.Local).AddTicks(1946), null, "ismailycer@gmail.com", false, "İsmail", "deneme", true, "Yücer", false, null, "ISMAILYCER@GMAIL.COM", "ISMAILYCER@GMAIL.COM", "AQAAAAIAAYagAAAAEOH8tFZhyuzuTrtHst1EH+AjflWW1TQlUiDfmUvob9k+zv+lgCiHJmrsMXLwBYou8g==", "+000000000", false, "342c49da-3733-4d44-8e92-fb3413b1ec8c", false, null, "ismailycer@gmail.com" },
                    { 6, 0, "3ec53b51-cc82-4dba-a974-751c02dbca42", new DateTime(2023, 12, 8, 19, 59, 22, 667, DateTimeKind.Local).AddTicks(632), null, "muratcanagic@hotmail.com", false, "Muratcan", "deneme", true, "Agıç", false, null, "MURATCANAGIC@HOTMAIL.COM", "MURATCANAGIC@HOTMAIL.COM", "AQAAAAIAAYagAAAAEC2zXutObYHttddwat8TgJFPyb434nExtEcYy63noThBJ73goEJvEsEXYbryEUCnNA==", "+000000000", false, "3eaa7bfa-e2ed-413d-9ac3-b0d3c7eb00e9", false, null, "muratcanagic@hotmail.com" },
                    { 7, 0, "6ffe299f-b940-4acb-8eca-c1d5b3328abc", new DateTime(2023, 12, 8, 19, 59, 22, 734, DateTimeKind.Local).AddTicks(5938), null, "ridvankesken@gmail.com", false, "Rıdvan", "deneme", true, "Kesken", false, null, "RIDVANKESKEN@GMAIL.COM", "RIDVANKESKEN@GMAIL.COM", "AQAAAAIAAYagAAAAEMPyQdZOhZo5pHUKtXpMrS5L9swum6E1673oVC6i7/l344g2Dgf6M8BqvKoOERBTkg==", "+000000000", false, "8e08a55e-7df8-4213-9200-a6ae24ec8995", false, null, "ridvankesken@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconClass", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6356), null, "Elektronik araçların satıldığı kategoridir", "fa fa-laptop icon-bg-1", true, "Elektronik", null },
                    { 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6361), null, "Restoranlarınız ile ilgili reklamları burda verebilirsiniz", "fa fa-apple icon-bg-2", true, "Restoran", null },
                    { 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6363), null, "Ev,arsa,dükkan.", "fa fa-home icon-bg-3", true, "Emlak", null },
                    { 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6364), null, "7'den 70'e tüm ürünler.", "fa fa-shopping-basket icon-bg-4", true, "Alışveriş", null },
                    { 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6365), null, "Kendi mesleğine göre ilan verebilirsin.", "fa fa-briefcase icon-bg-5", true, "Meslekler", null },
                    { 6, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6365), null, "Aradığın araçlar burada", "fa fa-car icon-bg-6", true, "Araçlar", null },
                    { 7, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6366), null, "Evcil Hayvanlarınız İçin Herşey", "fa fa-paw icon-bg-7", true, "Pet Ürünleri", null },
                    { 8, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(6367), null, "Aradığınız hizmetler burada !", "fa fa-laptop icon-bg-8", true, "Hizmetler", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(7691), null, true, "Eskişehir", null },
                    { 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(7694), null, true, "İstanbul", null },
                    { 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(7695), null, true, "Ankara", null },
                    { 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(7696), null, true, "İzmir", null },
                    { 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(7696), null, true, "Adana", null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedDate", "IsActive", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Bizim Hakkımızda Herşey Burada", new DateTime(2023, 12, 8, 19, 59, 22, 802, DateTimeKind.Local).AddTicks(9822), null, true, "Hakkımızda", null },
                    { 2, "Bize Ulaşın ve Soru Sorun", new DateTime(2023, 12, 8, 19, 59, 22, 802, DateTimeKind.Local).AddTicks(9832), null, true, "Bize Ulaşın", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "ClickCount", "ConditionEnum", "CreatedDate", "DeletedDate", "Description", "IsActive", "Price", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3453), null, "Siyah az kullanılmıs laptop", true, 140, "Siyah Laptop", null, 3 },
                    { 2, null, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3459), null, "Beyaz laptop. İhtiyacım olduğu için satıyorum", true, 250, "Beyaz Laptop", null, 4 },
                    { 3, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3460), null, "2013 model İphone", true, 340, "Iphone Telefon", null, 5 },
                    { 4, null, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3461), null, "Android telefon en iyi telefondur", true, 240, "Android Telefon", null, 7 },
                    { 5, null, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3462), null, "Samsung Android Tablet. Sahibinden satılıktır", true, 220, "Android Tablet", null, 4 },
                    { 6, null, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3463), null, "Kardeşimin ipadini satıyoruz. Üstünde az çizik vardır", true, 180, "İPhone Tablet IPad", null, 6 },
                    { 7, null, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3464), null, "Led ekran televizyon. 20 cm e 50 cm. Az kullanılmış", true, 540, "Led Ekran", null, 6 },
                    { 8, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3465), null, "17 inch ekranımı satıyorum", true, 40, "Pc Ekranı", null, 3 },
                    { 9, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3466), null, "Ayşin kafede ev yemekleri seni çağırıyor", true, 400, "Ayşin Kafe", null, 5 },
                    { 10, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3467), null, "Kafe Paranoma, dünyaca ünlü kahve çeşitleri burada", true, 470, "Cafe Paranoma", null, 6 },
                    { 11, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3468), null, "Mcdonals seni çağırıyor", true, 200, "Mcdonalds", null, 4 },
                    { 12, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3469), null, "Tostumu yiyen başka bişey yemez", true, 120, "Tostçu Erol", null, 3 },
                    { 13, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3470), null, "Her tür yemek bulunur", true, 30, "Restoran Eskargo", null, 6 },
                    { 14, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3471), null, "Yeşim restoranda her şey var", true, 140, "Yeşim Restoran", null, 5 },
                    { 15, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3472), null, "Yemekler bizden sorulur", true, 340, "Ayşe Teyze Restoran", null, 6 },
                    { 16, null, 0, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3473), null, "Bodrum un eşsiz yemek lezzetleri burada", true, 120, "Bodrum Ev Yemekleri", null, 7 },
                    { 17, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3474), null, "10 numara arsa!", true, 40, "20 metrekare, denize karşı ", null, 3 },
                    { 18, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3475), null, "İstediğini ek, biç.", true, 75, "30x35 arsa, sahibinden.", null, 4 },
                    { 19, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3477), null, "Kullanıma hazır spor salonu.", true, 40, "Her türlü alet mevcut", null, 6 },
                    { 20, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3478), null, "Ben olsam düşünmeden alırım.", true, 25, "3 kuşaktır işlettiğimiz spor salonu satılık.", null, 5 },
                    { 21, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3479), null, "Dahiliye dahil.", true, 100000, "Hastane satılır mı demeyin, satılır.", null, 3 },
                    { 22, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3480), null, "Çok da alet yok ama iş görür.", true, 165, "Küçük klinik, her türlü hastaya bi bakarsınız.", null, 7 },
                    { 23, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3481), null, "Hiç düşünmeden kirala dayıoğlu. ", true, 270, "İstanbulun gözde semti Bağcılarda 0+0 daire", null, 4 },
                    { 24, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3482), null, "Parası olmayan aramasın lütfen.", true, 375, "3+1 fıstık gibi aileye daire.", null, 6 },
                    { 25, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3483), null, "Yaz, kış giyilir. Sıcak tutar.", true, 85, "Siyah Atlet", null, 7 },
                    { 26, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3484), null, "Biraz rahatsız eder ama, ortamlarda en şık sen olursun!", true, 185, "Slip Don", null, 5 },
                    { 27, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3484), null, "Al ve teklif et!", true, 30, "Altın Yüzük", null, 4 },
                    { 28, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3485), null, "Çok şık, çok güzel!", true, 45, "Gümüş Bileklik", null, 3 },
                    { 29, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3486), null, "Çocuğunuzun kafası sıccacık!", true, 20, "Bere", null, 2 },
                    { 30, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3487), null, "Bebeniz kar oynasın.", true, 45, "Eldiven", null, 5 },
                    { 31, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3488), null, "Her işinizi bununla yapın.", true, 50, "SoftMicro 360", null, 3 },
                    { 32, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3489), null, "Müzik dinlemek ister misin?", true, 65, "Stopify", null, 4 },
                    { 33, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3490), null, "Lorem Ipsum is simply dummy text of the printing", true, 400, "Vergi Ödeme", null, 3 },
                    { 34, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3491), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Fatura Kesme", null, 5 },
                    { 35, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3493), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Hızlı Çözüm", null, 6 },
                    { 36, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3494), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Yedek Malzeme", null, 6 },
                    { 37, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3495), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Matematik", null, 5 },
                    { 38, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3496), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Türkçe", null, 3 },
                    { 39, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3497), null, "Lorem Ipsum is simply dummy text of the printing", true, 1000, "Bina", null, 7 },
                    { 40, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3498), null, "Lorem Ipsum is simply dummy text of the printing", true, 760, "Daire", null, 3 },
                    { 41, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3499), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "Büyük Otobüs", null, 3 },
                    { 42, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3500), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Küçük Otobüs", null, 5 },
                    { 43, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3501), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "SUV", null, 7 },
                    { 44, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3502), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Sedan", null, 4 },
                    { 45, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3503), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Scooter", null, 7 },
                    { 46, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3504), null, "Lorem Ipsum is simply dummy text of the printing", true, 350, "Adventure", null, 4 },
                    { 47, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3505), null, "Lorem Ipsum is simply dummy text of the printing", true, 10000, "Yelkenli", null, 7 },
                    { 48, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3506), null, "Lorem Ipsum is simply dummy text of the printing", true, 15000, "Kamaralı ", null, 4 },
                    { 49, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3507), null, "Kediniz için şık tasma", true, 100, "Kedi Tasması", null, 3 },
                    { 50, null, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3508), null, "10+2 Kilogram Kedi Kumu", true, 120, "Kedi Kumu", null, 3 },
                    { 51, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3509), null, "Köpeğiniz için şık tasma", true, 100, "Köpek Tasması", null, 3 },
                    { 52, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3536), null, "10+2 Kilogram Kuru Köpek Maması", true, 900, "Kuru Köpek Maması", null, 4 },
                    { 53, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3539), null, "1 Kilogram Kuş Yemi", true, 150, "Kuş Yemi", null, 5 },
                    { 54, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3540), null, "Suluk ve dalları olan kuş kafesi", true, 500, "Kafes", null, 5 },
                    { 55, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3537), null, "1 Kilogram Balık Maması", true, 200, "Balık Maması", null, 4 },
                    { 56, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3538), null, "Büyük boy akvaryum", true, 1500, "Akvaryum", null, 4 },
                    { 57, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3541), null, "Detaylı ev temizliği", true, 700, "Ev Temizliği", null, 5 },
                    { 58, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3542), null, "Detaylı ofis temizliği", true, 2500, "Ofis Temizliği", null, 6 },
                    { 59, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3543), null, "Detaylı İç-Dış Yıkama", true, 300, "İç-Dış Yıkama", null, 6 },
                    { 60, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3544), null, "Oto-Kuaför Servisi", true, 1200, "Oto-Kuaför", null, 6 },
                    { 61, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3545), null, "Takım elbiselerinizi 1 günde tertemiz yapıyoruz.", true, 200, "Takım Elbiseler için Kuru Temizleme", null, 7 },
                    { 62, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3546), null, "Giyecekleriniz için hızlı kuru temizleme servisi", true, 50, "Diğer Kuru Temizleme", null, 7 },
                    { 63, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3547), null, "İçine girince güzel.", true, 3500, "Tabut", null, 7 },
                    { 64, null, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(3548), null, "Hayır duası için ...", true, 7500, "Cenaze Yemeği", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9024), null, true, "Odunpazarı", null },
                    { 2, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9027), null, true, "Tepebaşı", null },
                    { 3, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9029), null, true, "Beşiktaş", null },
                    { 4, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9029), null, true, "Beyoğlu", null },
                    { 5, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9030), null, true, "Çankaya", null },
                    { 6, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9031), null, true, "Sincan", null },
                    { 7, 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9032), null, true, "Bayraklı", null },
                    { 8, 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9033), null, true, "Foça", null },
                    { 9, 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9033), null, true, "Çukurova", null },
                    { 10, 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(9034), null, true, "Seyhan", null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DarkMode", "DeletedDate", "IsActive", "Name", "UpdatedDate", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(1185), false, null, true, "MaxPostPerPage", null, 1, "50" },
                    { 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(1189), false, null, true, "MaxPostPerPage", null, 2, "20" },
                    { 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(1190), false, null, true, "MaxPostPerPage", null, 3, "10" },
                    { 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(1191), false, null, true, "DarkMode", null, 1, "0" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3665), null, true, "Laptop", null },
                    { 2, 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3668), null, true, "Telefon", null },
                    { 3, 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3669), null, true, "Tablet", null },
                    { 4, 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3669), null, true, "Ekran", null },
                    { 5, 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3670), null, true, "Kafe", null },
                    { 6, 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3671), null, true, "Fast Food", null },
                    { 7, 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3671), null, true, "Restoran", null },
                    { 8, 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3672), null, true, "Yöresel Yemekler", null },
                    { 9, 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3673), null, true, "Arsa", null },
                    { 10, 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3673), null, true, "Spor Salonu", null },
                    { 11, 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3674), null, true, "Hastane", null },
                    { 12, 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3674), null, true, "Ev", null },
                    { 13, 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3675), null, true, "Erkek Giysileri", null },
                    { 14, 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3676), null, true, "Aksesuarlar", null },
                    { 15, 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3676), null, true, "Çocuk Giysileri", null },
                    { 16, 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3677), null, true, "Yazılım", null },
                    { 17, 5, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3678), null, true, "Muhasebe", null },
                    { 18, 5, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3678), null, true, "Kombi Tamiri", null },
                    { 19, 5, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3679), null, true, "Özel Ders", null },
                    { 20, 5, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3679), null, true, "Boyacı", null },
                    { 21, 6, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3680), null, true, "Otobüs", null },
                    { 22, 6, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3681), null, true, "Araç", null },
                    { 23, 6, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3681), null, true, "Motorsiklet", null },
                    { 24, 6, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3682), null, true, "Yat", null },
                    { 25, 7, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3683), null, true, "Kedi Ürünleri", null },
                    { 26, 7, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3683), null, true, "Köpek Ürünleri", null },
                    { 27, 7, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3684), null, true, "Kuş Ürünleri", null },
                    { 28, 7, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3684), null, true, "Balık Ürünleri", null },
                    { 29, 8, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3685), null, true, "Temizlik", null },
                    { 30, 8, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3686), null, true, "Araba Yıkama", null },
                    { 31, 8, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3686), null, true, "Kuru Temizleme", null },
                    { 32, 8, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(3687), null, true, "Cenaze", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "Country", "CreatedDate", "DeletedDate", "DetailedAddress", "DistrictId", "IsActive", "PostCode", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Türkiye", new DateTime(2023, 12, 8, 19, 59, 22, 388, DateTimeKind.Local).AddTicks(9314), null, "Emin Sokak", 1, true, "341449", null, 3 },
                    { 2, 2, "Türkiye", new DateTime(2023, 12, 8, 19, 59, 22, 388, DateTimeKind.Local).AddTicks(9333), null, "Kerem Sokak Kus Apartmani", 3, true, "25123", null, 4 },
                    { 3, 4, "Türkiye", new DateTime(2023, 12, 8, 19, 59, 22, 388, DateTimeKind.Local).AddTicks(9334), null, "Reşadiye cami üstü", 7, true, "26120", null, 5 },
                    { 4, 1, "Türkiye", new DateTime(2023, 12, 8, 19, 59, 22, 388, DateTimeKind.Local).AddTicks(9335), null, "Akşemsettin Mahallesi", 2, true, "341449", null, 6 },
                    { 5, 3, "Türkiye", new DateTime(2023, 12, 8, 19, 59, 22, 388, DateTimeKind.Local).AddTicks(9337), null, "Odabaşı Cd.", 6, true, "06810", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "AdvertComments",
                columns: new[] { "Id", "AdvertId", "Comment", "CreatedDate", "DeletedDate", "IsActive", "StarCount", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Kargo hızlı geldi. Çok memnun kaldım", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1951), null, true, 5, null, 3 },
                    { 2, 3, "Ürün hiç beklediğim gibi değildi. Hiç beğenmedim", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1957), null, true, 1, null, 3 },
                    { 3, 3, "Ürün çok kötüydü. Hiç beğenmedim", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1958), null, true, 2, null, 4 },
                    { 4, 2, "Bu nasıl bir ürün, ben böyle bir şey görmemişim.", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1959), null, true, 1, null, 4 },
                    { 5, 2, "Ürün görüldüğü gibiydi.", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1960), null, true, 4, null, 7 },
                    { 6, 3, "Güzel paketlenmişti.", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1961), null, true, 4, null, 5 },
                    { 7, 6, "Fiyat performans bekledik fos çıktı !", new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(1962), null, true, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AdvertImages",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "ImagePath", "IsActive", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4846), null, "http://via.placeholder.com/610x400", true, null },
                    { 2, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4851), null, "http://via.placeholder.com/610x400", true, null },
                    { 3, 1, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4852), null, "http://via.placeholder.com/610x400", true, null },
                    { 4, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4852), null, "http://via.placeholder.com/610x400", true, null },
                    { 5, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4853), null, "http://via.placeholder.com/610x400", true, null },
                    { 6, 2, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4855), null, "http://via.placeholder.com/610x400", true, null },
                    { 7, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4886), null, "http://via.placeholder.com/610x400", true, null },
                    { 8, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4887), null, "http://via.placeholder.com/610x400", true, null },
                    { 9, 3, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4888), null, "http://via.placeholder.com/610x400", true, null },
                    { 10, 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4889), null, "http://via.placeholder.com/610x400", true, null },
                    { 11, 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4890), null, "http://via.placeholder.com/610x400", true, null },
                    { 12, 4, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4890), null, "http://via.placeholder.com/610x400", true, null },
                    { 13, 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4891), null, "http://via.placeholder.com/610x400", true, null },
                    { 14, 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4891), null, "http://via.placeholder.com/610x400", true, null },
                    { 15, 5, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4892), null, "http://via.placeholder.com/610x400", true, null },
                    { 16, 6, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4892), null, "http://via.placeholder.com/610x400", true, null },
                    { 17, 6, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4893), null, "http://via.placeholder.com/610x400", true, null },
                    { 18, 6, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4894), null, "http://via.placeholder.com/610x400", true, null },
                    { 19, 7, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4894), null, "http://via.placeholder.com/610x400", true, null },
                    { 20, 7, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4895), null, "http://via.placeholder.com/610x400", true, null },
                    { 21, 7, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4895), null, "http://via.placeholder.com/610x400", true, null },
                    { 22, 8, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4895), null, "http://via.placeholder.com/610x400", true, null },
                    { 23, 8, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4896), null, "http://via.placeholder.com/610x400", true, null },
                    { 24, 8, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4896), null, "http://via.placeholder.com/610x400", true, null },
                    { 25, 9, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4897), null, "http://via.placeholder.com/610x400", true, null },
                    { 26, 9, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4897), null, "http://via.placeholder.com/610x400", true, null },
                    { 27, 9, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4897), null, "http://via.placeholder.com/610x400", true, null },
                    { 28, 10, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4898), null, "http://via.placeholder.com/610x400", true, null },
                    { 29, 10, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4898), null, "http://via.placeholder.com/610x400", true, null },
                    { 30, 10, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4899), null, "http://via.placeholder.com/610x400", true, null },
                    { 31, 11, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4899), null, "http://via.placeholder.com/610x400", true, null },
                    { 32, 11, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4899), null, "http://via.placeholder.com/610x400", true, null },
                    { 33, 11, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4900), null, "http://via.placeholder.com/610x400", true, null },
                    { 34, 12, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4901), null, "http://via.placeholder.com/610x400", true, null },
                    { 35, 12, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4901), null, "http://via.placeholder.com/610x400", true, null },
                    { 36, 12, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4902), null, "http://via.placeholder.com/610x400", true, null },
                    { 37, 13, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4902), null, "http://via.placeholder.com/610x400", true, null },
                    { 38, 13, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4903), null, "http://via.placeholder.com/610x400", true, null },
                    { 39, 13, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4903), null, "http://via.placeholder.com/610x400", true, null },
                    { 40, 14, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4904), null, "http://via.placeholder.com/610x400", true, null },
                    { 41, 14, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4904), null, "http://via.placeholder.com/610x400", true, null },
                    { 42, 14, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4904), null, "http://via.placeholder.com/610x400", true, null },
                    { 43, 15, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4905), null, "http://via.placeholder.com/610x400", true, null },
                    { 44, 15, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4905), null, "http://via.placeholder.com/610x400", true, null },
                    { 45, 15, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4906), null, "http://via.placeholder.com/610x400", true, null },
                    { 46, 16, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4906), null, "http://via.placeholder.com/610x400", true, null },
                    { 47, 16, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4906), null, "http://via.placeholder.com/610x400", true, null },
                    { 48, 16, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4907), null, "http://via.placeholder.com/610x400", true, null },
                    { 49, 17, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4907), null, "http://via.placeholder.com/610x400", true, null },
                    { 50, 17, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4908), null, "http://via.placeholder.com/610x400", true, null },
                    { 51, 17, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4908), null, "http://via.placeholder.com/610x400", true, null },
                    { 52, 18, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4908), null, "http://via.placeholder.com/610x400", true, null },
                    { 53, 18, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4909), null, "http://via.placeholder.com/610x400", true, null },
                    { 54, 18, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4909), null, "http://via.placeholder.com/610x400", true, null },
                    { 55, 19, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4910), null, "http://via.placeholder.com/610x400", true, null },
                    { 56, 19, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4910), null, "http://via.placeholder.com/610x400", true, null },
                    { 57, 19, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4911), null, "http://via.placeholder.com/610x400", true, null },
                    { 58, 20, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4911), null, "http://via.placeholder.com/610x400", true, null },
                    { 59, 20, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4911), null, "http://via.placeholder.com/610x400", true, null },
                    { 60, 20, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4912), null, "http://via.placeholder.com/610x400", true, null },
                    { 61, 21, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4912), null, "http://via.placeholder.com/610x400", true, null },
                    { 62, 21, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4913), null, "http://via.placeholder.com/610x400", true, null },
                    { 63, 21, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4913), null, "http://via.placeholder.com/610x400", true, null },
                    { 64, 22, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4913), null, "http://via.placeholder.com/610x400", true, null },
                    { 65, 22, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4914), null, "http://via.placeholder.com/610x400", true, null },
                    { 66, 22, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4915), null, "http://via.placeholder.com/610x400", true, null },
                    { 67, 23, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4916), null, "http://via.placeholder.com/610x400", true, null },
                    { 68, 23, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4916), null, "http://via.placeholder.com/610x400", true, null },
                    { 69, 23, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4916), null, "http://via.placeholder.com/610x400", true, null },
                    { 70, 24, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4917), null, "http://via.placeholder.com/610x400", true, null },
                    { 71, 24, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4917), null, "http://via.placeholder.com/610x400", true, null },
                    { 72, 24, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4918), null, "http://via.placeholder.com/610x400", true, null },
                    { 73, 25, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4918), null, "http://via.placeholder.com/610x400", true, null },
                    { 74, 25, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4918), null, "http://via.placeholder.com/610x400", true, null },
                    { 75, 25, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4919), null, "http://via.placeholder.com/610x400", true, null },
                    { 76, 26, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4919), null, "http://via.placeholder.com/610x400", true, null },
                    { 77, 26, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4944), null, "http://via.placeholder.com/610x400", true, null },
                    { 78, 26, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4945), null, "http://via.placeholder.com/610x400", true, null },
                    { 79, 27, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4945), null, "http://via.placeholder.com/610x400", true, null },
                    { 80, 27, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4946), null, "http://via.placeholder.com/610x400", true, null },
                    { 81, 27, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4946), null, "http://via.placeholder.com/610x400", true, null },
                    { 82, 28, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4947), null, "http://via.placeholder.com/610x400", true, null },
                    { 83, 28, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4947), null, "http://via.placeholder.com/610x400", true, null },
                    { 84, 28, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4947), null, "http://via.placeholder.com/610x400", true, null },
                    { 85, 29, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4948), null, "http://via.placeholder.com/610x400", true, null },
                    { 86, 29, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4948), null, "http://via.placeholder.com/610x400", true, null },
                    { 87, 29, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4949), null, "http://via.placeholder.com/610x400", true, null },
                    { 88, 30, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4949), null, "http://via.placeholder.com/610x400", true, null },
                    { 89, 30, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4949), null, "http://via.placeholder.com/610x400", true, null },
                    { 90, 30, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4950), null, "http://via.placeholder.com/610x400", true, null },
                    { 91, 31, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4950), null, "http://via.placeholder.com/610x400", true, null },
                    { 92, 31, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4951), null, "http://via.placeholder.com/610x400", true, null },
                    { 93, 31, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4951), null, "http://via.placeholder.com/610x400", true, null },
                    { 94, 32, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4951), null, "http://via.placeholder.com/610x400", true, null },
                    { 95, 32, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4952), null, "http://via.placeholder.com/610x400", true, null },
                    { 96, 32, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4952), null, "http://via.placeholder.com/610x400", true, null },
                    { 97, 33, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4953), null, "http://via.placeholder.com/610x400", true, null },
                    { 98, 33, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4953), null, "http://via.placeholder.com/610x400", true, null },
                    { 99, 33, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4953), null, "http://via.placeholder.com/610x400", true, null },
                    { 100, 34, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4954), null, "http://via.placeholder.com/610x400", true, null },
                    { 101, 34, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4954), null, "http://via.placeholder.com/610x400", true, null },
                    { 102, 34, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4955), null, "http://via.placeholder.com/610x400", true, null },
                    { 103, 35, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4955), null, "http://via.placeholder.com/610x400", true, null },
                    { 104, 35, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4955), null, "http://via.placeholder.com/610x400", true, null },
                    { 105, 35, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4956), null, "http://via.placeholder.com/610x400", true, null },
                    { 106, 36, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4956), null, "http://via.placeholder.com/610x400", true, null },
                    { 107, 36, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4957), null, "http://via.placeholder.com/610x400", true, null },
                    { 108, 36, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4957), null, "http://via.placeholder.com/610x400", true, null },
                    { 109, 37, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4958), null, "http://via.placeholder.com/610x400", true, null },
                    { 110, 37, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4958), null, "http://via.placeholder.com/610x400", true, null },
                    { 111, 37, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4958), null, "http://via.placeholder.com/610x400", true, null },
                    { 112, 38, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4959), null, "http://via.placeholder.com/610x400", true, null },
                    { 113, 38, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4959), null, "http://via.placeholder.com/610x400", true, null },
                    { 114, 38, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4960), null, "http://via.placeholder.com/610x400", true, null },
                    { 115, 39, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4960), null, "http://via.placeholder.com/610x400", true, null },
                    { 116, 39, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4960), null, "http://via.placeholder.com/610x400", true, null },
                    { 117, 39, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4961), null, "http://via.placeholder.com/610x400", true, null },
                    { 118, 40, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4961), null, "http://via.placeholder.com/610x400", true, null },
                    { 119, 40, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4961), null, "http://via.placeholder.com/610x400", true, null },
                    { 120, 40, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4962), null, "http://via.placeholder.com/610x400", true, null },
                    { 121, 41, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4962), null, "http://via.placeholder.com/610x400", true, null },
                    { 122, 41, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4963), null, "http://via.placeholder.com/610x400", true, null },
                    { 123, 41, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4963), null, "http://via.placeholder.com/610x400", true, null },
                    { 124, 42, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4963), null, "http://via.placeholder.com/610x400", true, null },
                    { 125, 42, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4964), null, "http://via.placeholder.com/610x400", true, null },
                    { 126, 42, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4964), null, "http://via.placeholder.com/610x400", true, null },
                    { 127, 43, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4965), null, "http://via.placeholder.com/610x400", true, null },
                    { 128, 43, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4965), null, "http://via.placeholder.com/610x400", true, null },
                    { 129, 43, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4965), null, "http://via.placeholder.com/610x400", true, null },
                    { 130, 44, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4967), null, "http://via.placeholder.com/610x400", true, null },
                    { 131, 44, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4967), null, "http://via.placeholder.com/610x400", true, null },
                    { 132, 44, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4967), null, "http://via.placeholder.com/610x400", true, null },
                    { 133, 45, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4968), null, "http://via.placeholder.com/610x400", true, null },
                    { 134, 45, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4968), null, "http://via.placeholder.com/610x400", true, null },
                    { 135, 45, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4969), null, "http://via.placeholder.com/610x400", true, null },
                    { 136, 46, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4969), null, "http://via.placeholder.com/610x400", true, null },
                    { 137, 46, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4969), null, "http://via.placeholder.com/610x400", true, null },
                    { 138, 46, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4970), null, "http://via.placeholder.com/610x400", true, null },
                    { 139, 47, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4970), null, "http://via.placeholder.com/610x400", true, null },
                    { 140, 47, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4971), null, "http://via.placeholder.com/610x400", true, null },
                    { 141, 47, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4971), null, "http://via.placeholder.com/610x400", true, null },
                    { 142, 48, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4971), null, "http://via.placeholder.com/610x400", true, null },
                    { 143, 48, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4972), null, "http://via.placeholder.com/610x400", true, null },
                    { 144, 48, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4972), null, "http://via.placeholder.com/610x400", true, null },
                    { 145, 49, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4973), null, "http://via.placeholder.com/610x400", true, null },
                    { 146, 49, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4997), null, "http://via.placeholder.com/610x400", true, null },
                    { 147, 49, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4998), null, "http://via.placeholder.com/610x400", true, null },
                    { 148, 50, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4998), null, "http://via.placeholder.com/610x400", true, null },
                    { 149, 50, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4998), null, "http://via.placeholder.com/610x400", true, null },
                    { 150, 50, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4999), null, "http://via.placeholder.com/610x400", true, null },
                    { 151, 51, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(4999), null, "http://via.placeholder.com/610x400", true, null },
                    { 152, 51, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5000), null, "http://via.placeholder.com/610x400", true, null },
                    { 153, 51, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5000), null, "http://via.placeholder.com/610x400", true, null },
                    { 154, 52, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5001), null, "http://via.placeholder.com/610x400", true, null },
                    { 155, 52, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5001), null, "http://via.placeholder.com/610x400", true, null },
                    { 156, 52, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5001), null, "http://via.placeholder.com/610x400", true, null },
                    { 157, 53, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5002), null, "http://via.placeholder.com/610x400", true, null },
                    { 158, 53, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5002), null, "http://via.placeholder.com/610x400", true, null },
                    { 159, 53, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5003), null, "http://via.placeholder.com/610x400", true, null },
                    { 160, 54, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5003), null, "http://via.placeholder.com/610x400", true, null },
                    { 161, 54, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5003), null, "http://via.placeholder.com/610x400", true, null },
                    { 162, 54, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5004), null, "http://via.placeholder.com/610x400", true, null },
                    { 163, 55, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5004), null, "http://via.placeholder.com/610x400", true, null },
                    { 164, 55, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5005), null, "http://via.placeholder.com/610x400", true, null },
                    { 165, 55, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5005), null, "http://via.placeholder.com/610x400", true, null },
                    { 166, 56, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5005), null, "http://via.placeholder.com/610x400", true, null },
                    { 167, 56, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5006), null, "http://via.placeholder.com/610x400", true, null },
                    { 168, 56, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5006), null, "http://via.placeholder.com/610x400", true, null },
                    { 169, 57, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5007), null, "http://via.placeholder.com/610x400", true, null },
                    { 170, 57, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5007), null, "http://via.placeholder.com/610x400", true, null },
                    { 171, 57, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5007), null, "http://via.placeholder.com/610x400", true, null },
                    { 172, 58, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5008), null, "http://via.placeholder.com/610x400", true, null },
                    { 173, 58, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5008), null, "http://via.placeholder.com/610x400", true, null },
                    { 174, 58, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5009), null, "http://via.placeholder.com/610x400", true, null },
                    { 175, 59, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5009), null, "http://via.placeholder.com/610x400", true, null },
                    { 176, 59, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5009), null, "http://via.placeholder.com/610x400", true, null },
                    { 177, 59, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5010), null, "http://via.placeholder.com/610x400", true, null },
                    { 178, 60, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5010), null, "http://via.placeholder.com/610x400", true, null },
                    { 179, 60, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5011), null, "http://via.placeholder.com/610x400", true, null },
                    { 180, 60, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5011), null, "http://via.placeholder.com/610x400", true, null },
                    { 181, 61, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5011), null, "http://via.placeholder.com/610x400", true, null },
                    { 182, 61, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5012), null, "http://via.placeholder.com/610x400", true, null },
                    { 183, 61, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5012), null, "http://via.placeholder.com/610x400", true, null },
                    { 184, 62, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5013), null, "http://via.placeholder.com/610x400", true, null },
                    { 185, 62, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5013), null, "http://via.placeholder.com/610x400", true, null },
                    { 186, 62, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5013), null, "http://via.placeholder.com/610x400", true, null },
                    { 187, 63, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5014), null, "http://via.placeholder.com/610x400", true, null },
                    { 188, 63, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5014), null, "http://via.placeholder.com/610x400", true, null },
                    { 189, 63, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5015), null, "http://via.placeholder.com/610x400", true, null },
                    { 190, 64, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5015), null, "http://via.placeholder.com/610x400", true, null },
                    { 191, 64, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5016), null, "http://via.placeholder.com/610x400", true, null },
                    { 192, 64, new DateTime(2023, 12, 8, 19, 59, 22, 389, DateTimeKind.Local).AddTicks(5016), null, "http://via.placeholder.com/610x400", true, null }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryAdverts",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "IsActive", "SubcategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2290), null, true, 1, null },
                    { 2, 2, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2292), null, true, 1, null },
                    { 3, 3, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2293), null, true, 2, null },
                    { 4, 4, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2293), null, true, 2, null },
                    { 5, 5, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2294), null, true, 3, null },
                    { 6, 6, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2295), null, true, 3, null },
                    { 7, 7, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2295), null, true, 4, null },
                    { 8, 8, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2296), null, true, 4, null },
                    { 9, 9, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2296), null, true, 5, null },
                    { 10, 10, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2297), null, true, 5, null },
                    { 11, 11, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2298), null, true, 6, null },
                    { 12, 12, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2298), null, true, 6, null },
                    { 13, 13, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2299), null, true, 7, null },
                    { 14, 14, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2300), null, true, 7, null },
                    { 15, 15, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2335), null, true, 8, null },
                    { 16, 16, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2336), null, true, 8, null },
                    { 17, 17, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2336), null, true, 9, null },
                    { 18, 18, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2337), null, true, 9, null },
                    { 19, 19, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2338), null, true, 10, null },
                    { 20, 20, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2338), null, true, 10, null },
                    { 21, 21, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2339), null, true, 11, null },
                    { 22, 22, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2340), null, true, 11, null },
                    { 23, 23, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2340), null, true, 12, null },
                    { 24, 24, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2341), null, true, 12, null },
                    { 25, 25, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2342), null, true, 13, null },
                    { 26, 26, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2342), null, true, 13, null },
                    { 27, 27, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2343), null, true, 14, null },
                    { 28, 28, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2344), null, true, 14, null },
                    { 29, 29, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2344), null, true, 15, null },
                    { 30, 30, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2345), null, true, 15, null },
                    { 31, 31, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2345), null, true, 16, null },
                    { 32, 32, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2346), null, true, 16, null },
                    { 33, 33, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2347), null, true, 17, null },
                    { 34, 34, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2347), null, true, 17, null },
                    { 35, 35, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2348), null, true, 18, null },
                    { 36, 36, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2349), null, true, 18, null },
                    { 37, 37, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2349), null, true, 19, null },
                    { 38, 38, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2350), null, true, 19, null },
                    { 39, 39, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2350), null, true, 20, null },
                    { 40, 40, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2351), null, true, 20, null },
                    { 41, 41, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2352), null, true, 21, null },
                    { 42, 42, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2352), null, true, 21, null },
                    { 43, 43, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2353), null, true, 22, null },
                    { 44, 44, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2354), null, true, 22, null },
                    { 45, 45, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2354), null, true, 23, null },
                    { 46, 46, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2355), null, true, 23, null },
                    { 47, 47, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2355), null, true, 24, null },
                    { 48, 48, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2356), null, true, 24, null },
                    { 49, 49, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2357), null, true, 25, null },
                    { 50, 50, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2357), null, true, 25, null },
                    { 51, 51, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2358), null, true, 26, null },
                    { 52, 52, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2358), null, true, 26, null },
                    { 53, 53, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2359), null, true, 27, null },
                    { 54, 54, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2360), null, true, 27, null },
                    { 55, 55, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2360), null, true, 28, null },
                    { 56, 56, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2361), null, true, 28, null },
                    { 57, 57, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2362), null, true, 29, null },
                    { 58, 58, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2362), null, true, 29, null },
                    { 59, 59, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2363), null, true, 30, null },
                    { 60, 60, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2363), null, true, 30, null },
                    { 61, 61, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2364), null, true, 31, null },
                    { 62, 62, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2365), null, true, 31, null },
                    { 63, 63, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2365), null, true, 32, null },
                    { 64, 64, new DateTime(2023, 12, 8, 19, 59, 22, 803, DateTimeKind.Local).AddTicks(2366), null, true, 32, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertComments_AdvertId",
                table: "AdvertComments",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertComments_UserId",
                table: "AdvertComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertImages_AdvertId",
                table: "AdvertImages",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserId",
                table: "Settings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryAdverts_AdvertId",
                table: "SubcategoryAdverts",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryAdverts_SubcategoryId",
                table: "SubcategoryAdverts",
                column: "SubcategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AdvertComments");

            migrationBuilder.DropTable(
                name: "AdvertImages");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SubcategoryAdverts");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
