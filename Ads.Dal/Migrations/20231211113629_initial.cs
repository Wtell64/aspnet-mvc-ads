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
                    { 1, "7f454c85-24ca-4b9a-a5fe-42d23bacf081", "Superadmin", "SUPERADMIN" },
                    { 2, "93e565aa-dd4a-4fe3-93ec-9ea5e5d36c47", "Admin", "ADMIN" },
                    { 3, "be6ff183-e969-46e0-b8a9-38c8ddf32b7d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "438c151b-31dc-4dd8-ac9a-26b0dab051d0", new DateTime(2023, 12, 11, 14, 36, 28, 967, DateTimeKind.Local).AddTicks(3921), null, "superadmin@gmail.com", true, "SuperAdmin", "deneme", true, "SuperAdmin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEE1kbdr3b5a5q9uhHDU3PsIda0CKxuV5cRrYt3T/QzSgGGqUKhhdBa2qP8fvkBgdIQ==", "+000000000", true, "59a21197-fcdc-4fc7-b67a-69d5166c68ff", false, null, "superadmin@gmail.com" },
                    { 2, 0, "73f26f8a-9f1b-4bd7-a37d-c1c0bdd918f3", new DateTime(2023, 12, 11, 14, 36, 28, 999, DateTimeKind.Local).AddTicks(9160), null, "admin@gmail.com", true, "Admin", "deneme", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEME0uVzZOmiEb9T6+n4/hsTEfKV13FQDxJeZh2QJGQYInwiCcD3lma2DUd3bgHQSpQ==", "+000000000", false, "f7a21ed7-d4bd-44da-a865-6a45f1db7006", false, null, "admin@gmail.com" },
                    { 3, 0, "8d50cf75-23cf-4a4a-b385-14ce615f15f5", new DateTime(2023, 12, 11, 14, 36, 29, 32, DateTimeKind.Local).AddTicks(4639), null, "user1@gmail.com", true, "Aras", "deneme", true, "Menteşe", false, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEHGZ2JDN3w9CS0WjxV185IZLPp0pZ4kxL5TfLG2YitwEhkzrZ4gKnM+jhX3IU+TI4w==", "+000000000", false, "b7ca4fad-0f83-41f7-9851-98e737039e01", false, null, "user1@gmail.com" },
                    { 4, 0, "1eddc877-60c9-4a28-b7bd-219e3539deca", new DateTime(2023, 12, 11, 14, 36, 29, 64, DateTimeKind.Local).AddTicks(9999), null, "user2@gmail.com", true, "Elif", "deneme", true, "Sakçı Tuncer", false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEPqrvKXlu8Qjy7rjXMksEAj+uMZhCWMwxleRgyg5/0yaTMhsr48ILSFN+dkeNZx8HA==", "+000000000", false, "65a77909-7f03-4d85-b1fa-f2fbba35f4e9", false, null, "user2@gmail.com" },
                    { 5, 0, "85623bf6-d566-4156-b607-efe2e77dc290", new DateTime(2023, 12, 11, 14, 36, 29, 97, DateTimeKind.Local).AddTicks(4272), null, "user3@gmail.com", true, "İsmail", "deneme", true, "Yücer", false, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEN+BkDlX+LMmXAu/ZlMkPn/O7f9K/PUHcBNXMurWxjT/gjXSVPdbTiIAGxxa4rPBHA==", "+000000000", false, "8dfd84f5-5441-471a-a726-5419064670e4", false, null, "user3@gmail.com" },
                    { 6, 0, "7524b66d-1007-4b63-82dd-0ab65c7fba16", new DateTime(2023, 12, 11, 14, 36, 29, 130, DateTimeKind.Local).AddTicks(2497), null, "user4@gmail.com", true, "Muratcan", "deneme", true, "Agıç", false, null, "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEAn3+zBKxL6MZa8t9uPKQ8ciOj+RmcKTBfKdZVoV19xmH+039yHek1GQeO87WpPQEw==", "+000000000", false, "7fe6a252-5ff4-44e2-b73d-10b7f124be67", false, null, "user4@gmail.com" },
                    { 7, 0, "c13dcae7-3c7f-4eab-9c7f-d9e60af2e5a5", new DateTime(2023, 12, 11, 14, 36, 29, 162, DateTimeKind.Local).AddTicks(8314), null, "user5@gmail.com", true, "Rıdvan", "deneme", true, "Kesken", false, null, "USER5@GMAIL.COM", "USER5@GMAIL.COM", "AQAAAAIAAYagAAAAENM7nhwuOen1CKNGXoP9nwSB9OpF9iSBNVEeA76DLUwviQG2CVILGmkagLO/Lt6mhg==", "+000000000", false, "e9e0ab42-55de-4db0-8c0f-f7dbb98bdf95", false, null, "user5@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconClass", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4139), null, "Elektronik araçların satıldığı kategoridir", "fa fa-laptop icon-bg-1", true, "Elektronik", null },
                    { 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4145), null, "Restoranlarınız ile ilgili reklamları burda verebilirsiniz", "fa fa-apple icon-bg-2", true, "Restoran", null },
                    { 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4146), null, "Ev,arsa,dükkan.", "fa fa-home icon-bg-3", true, "Emlak", null },
                    { 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4146), null, "7'den 70'e tüm ürünler.", "fa fa-shopping-basket icon-bg-4", true, "Alışveriş", null },
                    { 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4147), null, "Kendi mesleğine göre ilan verebilirsin.", "fa fa-briefcase icon-bg-5", true, "Meslekler", null },
                    { 6, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4147), null, "Aradığın araçlar burada", "fa fa-car icon-bg-6", true, "Araçlar", null },
                    { 7, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4148), null, "Evcil Hayvanlarınız İçin Herşey", "fa fa-paw icon-bg-7", true, "Pet Ürünleri", null },
                    { 8, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(4149), null, "Aradığınız hizmetler burada !", "fa fa-laptop icon-bg-8", true, "Hizmetler", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(5283), null, true, "Eskişehir", null },
                    { 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(5287), null, true, "İstanbul", null },
                    { 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(5288), null, true, "Ankara", null },
                    { 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(5289), null, true, "İzmir", null },
                    { 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(5289), null, true, "Adana", null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedDate", "IsActive", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Bizim Hakkımızda Herşey Burada", new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(7662), null, true, "Hakkımızda", null },
                    { 2, "Bize Ulaşın ve Soru Sorun", new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(7665), null, true, "Bize Ulaşın", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "ClickCount", "ConditionEnum", "CreatedDate", "DeletedDate", "Description", "IsActive", "Price", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1669), null, "Siyah az kullanılmıs laptop", true, 140, "Siyah Laptop", null, 3 },
                    { 2, null, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1675), null, "Beyaz laptop. İhtiyacım olduğu için satıyorum", true, 250, "Beyaz Laptop", null, 4 },
                    { 3, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1676), null, "2013 model İphone", true, 340, "Iphone Telefon", null, 5 },
                    { 4, null, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1676), null, "Android telefon en iyi telefondur", true, 240, "Android Telefon", null, 7 },
                    { 5, null, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1677), null, "Samsung Android Tablet. Sahibinden satılıktır", true, 220, "Android Tablet", null, 4 },
                    { 6, null, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1678), null, "Kardeşimin ipadini satıyoruz. Üstünde az çizik vardır", true, 180, "İPhone Tablet IPad", null, 6 },
                    { 7, null, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1679), null, "Led ekran televizyon. 20 cm e 50 cm. Az kullanılmış", true, 540, "Led Ekran", null, 6 },
                    { 8, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1679), null, "17 inch ekranımı satıyorum", true, 40, "Pc Ekranı", null, 3 },
                    { 9, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1680), null, "Ayşin kafede ev yemekleri seni çağırıyor", true, 400, "Ayşin Kafe", null, 5 },
                    { 10, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1681), null, "Kafe Paranoma, dünyaca ünlü kahve çeşitleri burada", true, 470, "Cafe Paranoma", null, 6 },
                    { 11, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1682), null, "Mcdonals seni çağırıyor", true, 200, "Mcdonalds", null, 4 },
                    { 12, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1682), null, "Tostumu yiyen başka bişey yemez", true, 120, "Tostçu Erol", null, 3 },
                    { 13, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1683), null, "Her tür yemek bulunur", true, 30, "Restoran Eskargo", null, 6 },
                    { 14, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1684), null, "Yeşim restoranda her şey var", true, 140, "Yeşim Restoran", null, 5 },
                    { 15, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1685), null, "Yemekler bizden sorulur", true, 340, "Ayşe Teyze Restoran", null, 6 },
                    { 16, null, 0, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1686), null, "Bodrum un eşsiz yemek lezzetleri burada", true, 120, "Bodrum Ev Yemekleri", null, 7 },
                    { 17, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1686), null, "10 numara arsa!", true, 40, "20 metrekare, denize karşı ", null, 3 },
                    { 18, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1687), null, "İstediğini ek, biç.", true, 75, "30x35 arsa, sahibinden.", null, 4 },
                    { 19, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1688), null, "Kullanıma hazır spor salonu.", true, 40, "Her türlü alet mevcut", null, 6 },
                    { 20, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1689), null, "Ben olsam düşünmeden alırım.", true, 25, "3 kuşaktır işlettiğimiz spor salonu satılık.", null, 5 },
                    { 21, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1689), null, "Dahiliye dahil.", true, 100000, "Hastane satılır mı demeyin, satılır.", null, 3 },
                    { 22, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1690), null, "Çok da alet yok ama iş görür.", true, 165, "Küçük klinik, her türlü hastaya bi bakarsınız.", null, 7 },
                    { 23, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1691), null, "Hiç düşünmeden kirala dayıoğlu. ", true, 270, "İstanbulun gözde semti Bağcılarda 0+0 daire", null, 4 },
                    { 24, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1692), null, "Parası olmayan aramasın lütfen.", true, 375, "3+1 fıstık gibi aileye daire.", null, 6 },
                    { 25, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1693), null, "Yaz, kış giyilir. Sıcak tutar.", true, 85, "Siyah Atlet", null, 7 },
                    { 26, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1694), null, "Biraz rahatsız eder ama, ortamlarda en şık sen olursun!", true, 185, "Slip Don", null, 5 },
                    { 27, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1694), null, "Al ve teklif et!", true, 30, "Altın Yüzük", null, 4 },
                    { 28, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1695), null, "Çok şık, çok güzel!", true, 45, "Gümüş Bileklik", null, 3 },
                    { 29, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1696), null, "Çocuğunuzun kafası sıccacık!", true, 20, "Bere", null, 2 },
                    { 30, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1697), null, "Bebeniz kar oynasın.", true, 45, "Eldiven", null, 5 },
                    { 31, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1698), null, "Her işinizi bununla yapın.", true, 50, "SoftMicro 360", null, 3 },
                    { 32, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1698), null, "Müzik dinlemek ister misin?", true, 65, "Stopify", null, 4 },
                    { 33, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1699), null, "Lorem Ipsum is simply dummy text of the printing", true, 400, "Vergi Ödeme", null, 3 },
                    { 34, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1700), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Fatura Kesme", null, 5 },
                    { 35, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1701), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Hızlı Çözüm", null, 6 },
                    { 36, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1701), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Yedek Malzeme", null, 6 },
                    { 37, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1702), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Matematik", null, 5 },
                    { 38, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1703), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Türkçe", null, 3 },
                    { 39, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1704), null, "Lorem Ipsum is simply dummy text of the printing", true, 1000, "Bina", null, 7 },
                    { 40, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1705), null, "Lorem Ipsum is simply dummy text of the printing", true, 760, "Daire", null, 3 },
                    { 41, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1705), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "Büyük Otobüs", null, 3 },
                    { 42, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1708), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Küçük Otobüs", null, 5 },
                    { 43, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1709), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "SUV", null, 7 },
                    { 44, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1710), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Sedan", null, 4 },
                    { 45, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1710), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Scooter", null, 7 },
                    { 46, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1711), null, "Lorem Ipsum is simply dummy text of the printing", true, 350, "Adventure", null, 4 },
                    { 47, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1712), null, "Lorem Ipsum is simply dummy text of the printing", true, 10000, "Yelkenli", null, 7 },
                    { 48, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1731), null, "Lorem Ipsum is simply dummy text of the printing", true, 15000, "Kamaralı ", null, 4 },
                    { 49, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1732), null, "Kediniz için şık tasma", true, 100, "Kedi Tasması", null, 3 },
                    { 50, null, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1732), null, "10+2 Kilogram Kedi Kumu", true, 120, "Kedi Kumu", null, 3 },
                    { 51, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1733), null, "Köpeğiniz için şık tasma", true, 100, "Köpek Tasması", null, 3 },
                    { 52, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1734), null, "10+2 Kilogram Kuru Köpek Maması", true, 900, "Kuru Köpek Maması", null, 4 },
                    { 53, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1736), null, "1 Kilogram Kuş Yemi", true, 150, "Kuş Yemi", null, 5 },
                    { 54, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1737), null, "Suluk ve dalları olan kuş kafesi", true, 500, "Kafes", null, 5 },
                    { 55, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1735), null, "1 Kilogram Balık Maması", true, 200, "Balık Maması", null, 4 },
                    { 56, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1735), null, "Büyük boy akvaryum", true, 1500, "Akvaryum", null, 4 },
                    { 57, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1738), null, "Detaylı ev temizliği", true, 700, "Ev Temizliği", null, 5 },
                    { 58, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1738), null, "Detaylı ofis temizliği", true, 2500, "Ofis Temizliği", null, 6 },
                    { 59, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1739), null, "Detaylı İç-Dış Yıkama", true, 300, "İç-Dış Yıkama", null, 6 },
                    { 60, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1740), null, "Oto-Kuaför Servisi", true, 1200, "Oto-Kuaför", null, 6 },
                    { 61, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1741), null, "Takım elbiselerinizi 1 günde tertemiz yapıyoruz.", true, 200, "Takım Elbiseler için Kuru Temizleme", null, 7 },
                    { 62, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1742), null, "Giyecekleriniz için hızlı kuru temizleme servisi", true, 50, "Diğer Kuru Temizleme", null, 7 },
                    { 63, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1742), null, "İçine girince güzel.", true, 3500, "Tabut", null, 7 },
                    { 64, null, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(1743), null, "Hayır duası için ...", true, 7500, "Cenaze Yemeği", null, 7 }
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
                    { 1, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6394), null, true, "Odunpazarı", null },
                    { 2, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6399), null, true, "Tepebaşı", null },
                    { 3, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6399), null, true, "Beşiktaş", null },
                    { 4, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6400), null, true, "Beyoğlu", null },
                    { 5, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6400), null, true, "Çankaya", null },
                    { 6, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6401), null, true, "Sincan", null },
                    { 7, 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6401), null, true, "Bayraklı", null },
                    { 8, 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6402), null, true, "Foça", null },
                    { 9, 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6402), null, true, "Çukurova", null },
                    { 10, 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(6403), null, true, "Seyhan", null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DarkMode", "DeletedDate", "IsActive", "Name", "UpdatedDate", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(8771), false, null, true, "MaxPostPerPage", null, 1, "50" },
                    { 2, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(8775), false, null, true, "MaxPostPerPage", null, 2, "20" },
                    { 3, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(8775), false, null, true, "MaxPostPerPage", null, 3, "10" },
                    { 4, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(8776), false, null, true, "DarkMode", null, 1, "0" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(687), null, true, "Laptop", null },
                    { 2, 1, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(689), null, true, "Telefon", null },
                    { 3, 1, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(689), null, true, "Tablet", null },
                    { 4, 1, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(690), null, true, "Ekran", null },
                    { 5, 2, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(690), null, true, "Kafe", null },
                    { 6, 2, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(691), null, true, "Fast Food", null },
                    { 7, 2, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(691), null, true, "Restoran", null },
                    { 8, 2, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(692), null, true, "Yöresel Yemekler", null },
                    { 9, 3, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(693), null, true, "Arsa", null },
                    { 10, 3, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(693), null, true, "Spor Salonu", null },
                    { 11, 3, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(694), null, true, "Hastane", null },
                    { 12, 3, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(694), null, true, "Ev", null },
                    { 13, 4, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(695), null, true, "Erkek Giysileri", null },
                    { 14, 4, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(695), null, true, "Aksesuarlar", null },
                    { 15, 4, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(696), null, true, "Çocuk Giysileri", null },
                    { 16, 4, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(697), null, true, "Yazılım", null },
                    { 17, 5, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(697), null, true, "Muhasebe", null },
                    { 18, 5, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(698), null, true, "Kombi Tamiri", null },
                    { 19, 5, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(698), null, true, "Özel Ders", null },
                    { 20, 5, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(699), null, true, "Boyacı", null },
                    { 21, 6, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(699), null, true, "Otobüs", null },
                    { 22, 6, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(700), null, true, "Araç", null },
                    { 23, 6, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(700), null, true, "Motorsiklet", null },
                    { 24, 6, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(701), null, true, "Yat", null },
                    { 25, 7, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(701), null, true, "Kedi Ürünleri", null },
                    { 26, 7, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(702), null, true, "Köpek Ürünleri", null },
                    { 27, 7, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(702), null, true, "Kuş Ürünleri", null },
                    { 28, 7, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(703), null, true, "Balık Ürünleri", null },
                    { 29, 8, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(703), null, true, "Temizlik", null },
                    { 30, 8, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(704), null, true, "Araba Yıkama", null },
                    { 31, 8, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(704), null, true, "Kuru Temizleme", null },
                    { 32, 8, new DateTime(2023, 12, 11, 14, 36, 29, 197, DateTimeKind.Local).AddTicks(705), null, true, "Cenaze", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "Country", "CreatedDate", "DeletedDate", "DetailedAddress", "DistrictId", "IsActive", "PostCode", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Türkiye", new DateTime(2023, 12, 11, 14, 36, 28, 964, DateTimeKind.Local).AddTicks(8452), null, "Emin Sokak", 1, true, "341449", null, 3 },
                    { 2, 2, "Türkiye", new DateTime(2023, 12, 11, 14, 36, 28, 964, DateTimeKind.Local).AddTicks(8472), null, "Kerem Sokak Kus Apartmani", 3, true, "25123", null, 4 },
                    { 3, 4, "Türkiye", new DateTime(2023, 12, 11, 14, 36, 28, 964, DateTimeKind.Local).AddTicks(8472), null, "Reşadiye cami üstü", 7, true, "26120", null, 5 },
                    { 4, 1, "Türkiye", new DateTime(2023, 12, 11, 14, 36, 28, 964, DateTimeKind.Local).AddTicks(8473), null, "Akşemsettin Mahallesi", 2, true, "341449", null, 6 },
                    { 5, 3, "Türkiye", new DateTime(2023, 12, 11, 14, 36, 28, 964, DateTimeKind.Local).AddTicks(8474), null, "Odabaşı Cd.", 6, true, "06810", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "AdvertComments",
                columns: new[] { "Id", "AdvertId", "Comment", "CreatedDate", "DeletedDate", "IsActive", "StarCount", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Kargo hızlı geldi. Çok memnun kaldım", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(412), null, true, 5, null, 3 },
                    { 2, 3, "Ürün hiç beklediğim gibi değildi. Hiç beğenmedim", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(418), null, true, 1, null, 3 },
                    { 3, 3, "Ürün çok kötüydü. Hiç beğenmedim", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(419), null, true, 2, null, 4 },
                    { 4, 2, "Bu nasıl bir ürün, ben böyle bir şey görmemişim.", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(419), null, true, 1, null, 4 },
                    { 5, 2, "Ürün görüldüğü gibiydi.", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(420), null, true, 4, null, 7 },
                    { 6, 3, "Güzel paketlenmişti.", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(421), null, true, 4, null, 5 },
                    { 7, 6, "Fiyat performans bekledik fos çıktı !", new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(421), null, true, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AdvertImages",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "ImagePath", "IsActive", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2874), null, "http://via.placeholder.com/610x400", true, null },
                    { 2, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2879), null, "http://via.placeholder.com/610x400", true, null },
                    { 3, 1, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2879), null, "http://via.placeholder.com/610x400", true, null },
                    { 4, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2880), null, "http://via.placeholder.com/610x400", true, null },
                    { 5, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2880), null, "http://via.placeholder.com/610x400", true, null },
                    { 6, 2, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2881), null, "http://via.placeholder.com/610x400", true, null },
                    { 7, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2882), null, "http://via.placeholder.com/610x400", true, null },
                    { 8, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2882), null, "http://via.placeholder.com/610x400", true, null },
                    { 9, 3, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2882), null, "http://via.placeholder.com/610x400", true, null },
                    { 10, 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2883), null, "http://via.placeholder.com/610x400", true, null },
                    { 11, 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2884), null, "http://via.placeholder.com/610x400", true, null },
                    { 12, 4, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2884), null, "http://via.placeholder.com/610x400", true, null },
                    { 13, 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2884), null, "http://via.placeholder.com/610x400", true, null },
                    { 14, 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2885), null, "http://via.placeholder.com/610x400", true, null },
                    { 15, 5, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2885), null, "http://via.placeholder.com/610x400", true, null },
                    { 16, 6, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2886), null, "http://via.placeholder.com/610x400", true, null },
                    { 17, 6, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2886), null, "http://via.placeholder.com/610x400", true, null },
                    { 18, 6, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2887), null, "http://via.placeholder.com/610x400", true, null },
                    { 19, 7, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2887), null, "http://via.placeholder.com/610x400", true, null },
                    { 20, 7, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2887), null, "http://via.placeholder.com/610x400", true, null },
                    { 21, 7, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2888), null, "http://via.placeholder.com/610x400", true, null },
                    { 22, 8, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2888), null, "http://via.placeholder.com/610x400", true, null },
                    { 23, 8, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2889), null, "http://via.placeholder.com/610x400", true, null },
                    { 24, 8, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2889), null, "http://via.placeholder.com/610x400", true, null },
                    { 25, 9, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2889), null, "http://via.placeholder.com/610x400", true, null },
                    { 26, 9, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2890), null, "http://via.placeholder.com/610x400", true, null },
                    { 27, 9, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2890), null, "http://via.placeholder.com/610x400", true, null },
                    { 28, 10, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2890), null, "http://via.placeholder.com/610x400", true, null },
                    { 29, 10, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2891), null, "http://via.placeholder.com/610x400", true, null },
                    { 30, 10, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2891), null, "http://via.placeholder.com/610x400", true, null },
                    { 31, 11, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2891), null, "http://via.placeholder.com/610x400", true, null },
                    { 32, 11, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2892), null, "http://via.placeholder.com/610x400", true, null },
                    { 33, 11, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2892), null, "http://via.placeholder.com/610x400", true, null },
                    { 34, 12, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2893), null, "http://via.placeholder.com/610x400", true, null },
                    { 35, 12, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2893), null, "http://via.placeholder.com/610x400", true, null },
                    { 36, 12, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2893), null, "http://via.placeholder.com/610x400", true, null },
                    { 37, 13, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2894), null, "http://via.placeholder.com/610x400", true, null },
                    { 38, 13, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2894), null, "http://via.placeholder.com/610x400", true, null },
                    { 39, 13, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2895), null, "http://via.placeholder.com/610x400", true, null },
                    { 40, 14, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2895), null, "http://via.placeholder.com/610x400", true, null },
                    { 41, 14, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2895), null, "http://via.placeholder.com/610x400", true, null },
                    { 42, 14, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2896), null, "http://via.placeholder.com/610x400", true, null },
                    { 43, 15, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2896), null, "http://via.placeholder.com/610x400", true, null },
                    { 44, 15, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2896), null, "http://via.placeholder.com/610x400", true, null },
                    { 45, 15, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2897), null, "http://via.placeholder.com/610x400", true, null },
                    { 46, 16, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2897), null, "http://via.placeholder.com/610x400", true, null },
                    { 47, 16, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2897), null, "http://via.placeholder.com/610x400", true, null },
                    { 48, 16, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2898), null, "http://via.placeholder.com/610x400", true, null },
                    { 49, 17, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2898), null, "http://via.placeholder.com/610x400", true, null },
                    { 50, 17, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2898), null, "http://via.placeholder.com/610x400", true, null },
                    { 51, 17, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2899), null, "http://via.placeholder.com/610x400", true, null },
                    { 52, 18, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2899), null, "http://via.placeholder.com/610x400", true, null },
                    { 53, 18, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2899), null, "http://via.placeholder.com/610x400", true, null },
                    { 54, 18, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2900), null, "http://via.placeholder.com/610x400", true, null },
                    { 55, 19, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2900), null, "http://via.placeholder.com/610x400", true, null },
                    { 56, 19, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2901), null, "http://via.placeholder.com/610x400", true, null },
                    { 57, 19, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2901), null, "http://via.placeholder.com/610x400", true, null },
                    { 58, 20, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2901), null, "http://via.placeholder.com/610x400", true, null },
                    { 59, 20, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2902), null, "http://via.placeholder.com/610x400", true, null },
                    { 60, 20, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2902), null, "http://via.placeholder.com/610x400", true, null },
                    { 61, 21, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2902), null, "http://via.placeholder.com/610x400", true, null },
                    { 62, 21, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2903), null, "http://via.placeholder.com/610x400", true, null },
                    { 63, 21, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2903), null, "http://via.placeholder.com/610x400", true, null },
                    { 64, 22, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2903), null, "http://via.placeholder.com/610x400", true, null },
                    { 65, 22, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2904), null, "http://via.placeholder.com/610x400", true, null },
                    { 66, 22, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2905), null, "http://via.placeholder.com/610x400", true, null },
                    { 67, 23, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2905), null, "http://via.placeholder.com/610x400", true, null },
                    { 68, 23, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2922), null, "http://via.placeholder.com/610x400", true, null },
                    { 69, 23, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2923), null, "http://via.placeholder.com/610x400", true, null },
                    { 70, 24, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2923), null, "http://via.placeholder.com/610x400", true, null },
                    { 71, 24, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2924), null, "http://via.placeholder.com/610x400", true, null },
                    { 72, 24, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2924), null, "http://via.placeholder.com/610x400", true, null },
                    { 73, 25, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2924), null, "http://via.placeholder.com/610x400", true, null },
                    { 74, 25, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2925), null, "http://via.placeholder.com/610x400", true, null },
                    { 75, 25, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2925), null, "http://via.placeholder.com/610x400", true, null },
                    { 76, 26, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2925), null, "http://via.placeholder.com/610x400", true, null },
                    { 77, 26, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2926), null, "http://via.placeholder.com/610x400", true, null },
                    { 78, 26, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2926), null, "http://via.placeholder.com/610x400", true, null },
                    { 79, 27, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2926), null, "http://via.placeholder.com/610x400", true, null },
                    { 80, 27, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2927), null, "http://via.placeholder.com/610x400", true, null },
                    { 81, 27, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2927), null, "http://via.placeholder.com/610x400", true, null },
                    { 82, 28, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2927), null, "http://via.placeholder.com/610x400", true, null },
                    { 83, 28, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2928), null, "http://via.placeholder.com/610x400", true, null },
                    { 84, 28, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2928), null, "http://via.placeholder.com/610x400", true, null },
                    { 85, 29, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2928), null, "http://via.placeholder.com/610x400", true, null },
                    { 86, 29, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2929), null, "http://via.placeholder.com/610x400", true, null },
                    { 87, 29, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2929), null, "http://via.placeholder.com/610x400", true, null },
                    { 88, 30, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2930), null, "http://via.placeholder.com/610x400", true, null },
                    { 89, 30, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2930), null, "http://via.placeholder.com/610x400", true, null },
                    { 90, 30, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2930), null, "http://via.placeholder.com/610x400", true, null },
                    { 91, 31, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2931), null, "http://via.placeholder.com/610x400", true, null },
                    { 92, 31, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2931), null, "http://via.placeholder.com/610x400", true, null },
                    { 93, 31, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2931), null, "http://via.placeholder.com/610x400", true, null },
                    { 94, 32, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2932), null, "http://via.placeholder.com/610x400", true, null },
                    { 95, 32, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2932), null, "http://via.placeholder.com/610x400", true, null },
                    { 96, 32, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2932), null, "http://via.placeholder.com/610x400", true, null },
                    { 97, 33, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2933), null, "http://via.placeholder.com/610x400", true, null },
                    { 98, 33, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2933), null, "http://via.placeholder.com/610x400", true, null },
                    { 99, 33, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2933), null, "http://via.placeholder.com/610x400", true, null },
                    { 100, 34, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2934), null, "http://via.placeholder.com/610x400", true, null },
                    { 101, 34, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2934), null, "http://via.placeholder.com/610x400", true, null },
                    { 102, 34, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2934), null, "http://via.placeholder.com/610x400", true, null },
                    { 103, 35, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2935), null, "http://via.placeholder.com/610x400", true, null },
                    { 104, 35, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2935), null, "http://via.placeholder.com/610x400", true, null },
                    { 105, 35, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2936), null, "http://via.placeholder.com/610x400", true, null },
                    { 106, 36, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2936), null, "http://via.placeholder.com/610x400", true, null },
                    { 107, 36, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2936), null, "http://via.placeholder.com/610x400", true, null },
                    { 108, 36, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2937), null, "http://via.placeholder.com/610x400", true, null },
                    { 109, 37, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2937), null, "http://via.placeholder.com/610x400", true, null },
                    { 110, 37, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2937), null, "http://via.placeholder.com/610x400", true, null },
                    { 111, 37, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2938), null, "http://via.placeholder.com/610x400", true, null },
                    { 112, 38, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2938), null, "http://via.placeholder.com/610x400", true, null },
                    { 113, 38, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2938), null, "http://via.placeholder.com/610x400", true, null },
                    { 114, 38, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2939), null, "http://via.placeholder.com/610x400", true, null },
                    { 115, 39, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2939), null, "http://via.placeholder.com/610x400", true, null },
                    { 116, 39, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2939), null, "http://via.placeholder.com/610x400", true, null },
                    { 117, 39, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2940), null, "http://via.placeholder.com/610x400", true, null },
                    { 118, 40, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2940), null, "http://via.placeholder.com/610x400", true, null },
                    { 119, 40, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2940), null, "http://via.placeholder.com/610x400", true, null },
                    { 120, 40, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2941), null, "http://via.placeholder.com/610x400", true, null },
                    { 121, 41, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2941), null, "http://via.placeholder.com/610x400", true, null },
                    { 122, 41, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2941), null, "http://via.placeholder.com/610x400", true, null },
                    { 123, 41, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2942), null, "http://via.placeholder.com/610x400", true, null },
                    { 124, 42, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2942), null, "http://via.placeholder.com/610x400", true, null },
                    { 125, 42, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2943), null, "http://via.placeholder.com/610x400", true, null },
                    { 126, 42, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2943), null, "http://via.placeholder.com/610x400", true, null },
                    { 127, 43, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2943), null, "http://via.placeholder.com/610x400", true, null },
                    { 128, 43, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2944), null, "http://via.placeholder.com/610x400", true, null },
                    { 129, 43, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2944), null, "http://via.placeholder.com/610x400", true, null },
                    { 130, 44, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2945), null, "http://via.placeholder.com/610x400", true, null },
                    { 131, 44, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2945), null, "http://via.placeholder.com/610x400", true, null },
                    { 132, 44, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2945), null, "http://via.placeholder.com/610x400", true, null },
                    { 133, 45, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2946), null, "http://via.placeholder.com/610x400", true, null },
                    { 134, 45, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2946), null, "http://via.placeholder.com/610x400", true, null },
                    { 135, 45, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2946), null, "http://via.placeholder.com/610x400", true, null },
                    { 136, 46, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2947), null, "http://via.placeholder.com/610x400", true, null },
                    { 137, 46, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2947), null, "http://via.placeholder.com/610x400", true, null },
                    { 138, 46, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2963), null, "http://via.placeholder.com/610x400", true, null },
                    { 139, 47, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2964), null, "http://via.placeholder.com/610x400", true, null },
                    { 140, 47, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2964), null, "http://via.placeholder.com/610x400", true, null },
                    { 141, 47, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2964), null, "http://via.placeholder.com/610x400", true, null },
                    { 142, 48, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2965), null, "http://via.placeholder.com/610x400", true, null },
                    { 143, 48, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2965), null, "http://via.placeholder.com/610x400", true, null },
                    { 144, 48, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2965), null, "http://via.placeholder.com/610x400", true, null },
                    { 145, 49, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2966), null, "http://via.placeholder.com/610x400", true, null },
                    { 146, 49, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2966), null, "http://via.placeholder.com/610x400", true, null },
                    { 147, 49, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2966), null, "http://via.placeholder.com/610x400", true, null },
                    { 148, 50, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2967), null, "http://via.placeholder.com/610x400", true, null },
                    { 149, 50, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2967), null, "http://via.placeholder.com/610x400", true, null },
                    { 150, 50, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2967), null, "http://via.placeholder.com/610x400", true, null },
                    { 151, 51, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2968), null, "http://via.placeholder.com/610x400", true, null },
                    { 152, 51, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2968), null, "http://via.placeholder.com/610x400", true, null },
                    { 153, 51, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2968), null, "http://via.placeholder.com/610x400", true, null },
                    { 154, 52, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2969), null, "http://via.placeholder.com/610x400", true, null },
                    { 155, 52, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2969), null, "http://via.placeholder.com/610x400", true, null },
                    { 156, 52, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2969), null, "http://via.placeholder.com/610x400", true, null },
                    { 157, 53, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2970), null, "http://via.placeholder.com/610x400", true, null },
                    { 158, 53, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2970), null, "http://via.placeholder.com/610x400", true, null },
                    { 159, 53, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2970), null, "http://via.placeholder.com/610x400", true, null },
                    { 160, 54, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2971), null, "http://via.placeholder.com/610x400", true, null },
                    { 161, 54, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2971), null, "http://via.placeholder.com/610x400", true, null },
                    { 162, 54, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2972), null, "http://via.placeholder.com/610x400", true, null },
                    { 163, 55, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2972), null, "http://via.placeholder.com/610x400", true, null },
                    { 164, 55, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2972), null, "http://via.placeholder.com/610x400", true, null },
                    { 165, 55, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2973), null, "http://via.placeholder.com/610x400", true, null },
                    { 166, 56, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2973), null, "http://via.placeholder.com/610x400", true, null },
                    { 167, 56, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2973), null, "http://via.placeholder.com/610x400", true, null },
                    { 168, 56, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2974), null, "http://via.placeholder.com/610x400", true, null },
                    { 169, 57, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2974), null, "http://via.placeholder.com/610x400", true, null },
                    { 170, 57, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2974), null, "http://via.placeholder.com/610x400", true, null },
                    { 171, 57, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2975), null, "http://via.placeholder.com/610x400", true, null },
                    { 172, 58, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2975), null, "http://via.placeholder.com/610x400", true, null },
                    { 173, 58, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2975), null, "http://via.placeholder.com/610x400", true, null },
                    { 174, 58, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2976), null, "http://via.placeholder.com/610x400", true, null },
                    { 175, 59, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2976), null, "http://via.placeholder.com/610x400", true, null },
                    { 176, 59, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2976), null, "http://via.placeholder.com/610x400", true, null },
                    { 177, 59, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2977), null, "http://via.placeholder.com/610x400", true, null },
                    { 178, 60, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2977), null, "http://via.placeholder.com/610x400", true, null },
                    { 179, 60, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2977), null, "http://via.placeholder.com/610x400", true, null },
                    { 180, 60, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2978), null, "http://via.placeholder.com/610x400", true, null },
                    { 181, 61, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2978), null, "http://via.placeholder.com/610x400", true, null },
                    { 182, 61, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2979), null, "http://via.placeholder.com/610x400", true, null },
                    { 183, 61, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2979), null, "http://via.placeholder.com/610x400", true, null },
                    { 184, 62, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2979), null, "http://via.placeholder.com/610x400", true, null },
                    { 185, 62, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2980), null, "http://via.placeholder.com/610x400", true, null },
                    { 186, 62, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2980), null, "http://via.placeholder.com/610x400", true, null },
                    { 187, 63, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2980), null, "http://via.placeholder.com/610x400", true, null },
                    { 188, 63, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2981), null, "http://via.placeholder.com/610x400", true, null },
                    { 189, 63, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2981), null, "http://via.placeholder.com/610x400", true, null },
                    { 190, 64, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2981), null, "http://via.placeholder.com/610x400", true, null },
                    { 191, 64, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2982), null, "http://via.placeholder.com/610x400", true, null },
                    { 192, 64, new DateTime(2023, 12, 11, 14, 36, 28, 965, DateTimeKind.Local).AddTicks(2982), null, "http://via.placeholder.com/610x400", true, null }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryAdverts",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "IsActive", "SubcategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9662), null, true, 1, null },
                    { 2, 2, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9665), null, true, 1, null },
                    { 3, 3, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9665), null, true, 2, null },
                    { 4, 4, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9666), null, true, 2, null },
                    { 5, 5, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9690), null, true, 3, null },
                    { 6, 6, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9690), null, true, 3, null },
                    { 7, 7, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9691), null, true, 4, null },
                    { 8, 8, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9691), null, true, 4, null },
                    { 9, 9, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9692), null, true, 5, null },
                    { 10, 10, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9692), null, true, 5, null },
                    { 11, 11, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9693), null, true, 6, null },
                    { 12, 12, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9693), null, true, 6, null },
                    { 13, 13, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9694), null, true, 7, null },
                    { 14, 14, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9694), null, true, 7, null },
                    { 15, 15, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9695), null, true, 8, null },
                    { 16, 16, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9695), null, true, 8, null },
                    { 17, 17, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9696), null, true, 9, null },
                    { 18, 18, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9696), null, true, 9, null },
                    { 19, 19, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9697), null, true, 10, null },
                    { 20, 20, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9697), null, true, 10, null },
                    { 21, 21, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9698), null, true, 11, null },
                    { 22, 22, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9698), null, true, 11, null },
                    { 23, 23, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9699), null, true, 12, null },
                    { 24, 24, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9699), null, true, 12, null },
                    { 25, 25, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9700), null, true, 13, null },
                    { 26, 26, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9700), null, true, 13, null },
                    { 27, 27, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9700), null, true, 14, null },
                    { 28, 28, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9701), null, true, 14, null },
                    { 29, 29, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9701), null, true, 15, null },
                    { 30, 30, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9702), null, true, 15, null },
                    { 31, 31, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9702), null, true, 16, null },
                    { 32, 32, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9703), null, true, 16, null },
                    { 33, 33, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9703), null, true, 17, null },
                    { 34, 34, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9704), null, true, 17, null },
                    { 35, 35, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9704), null, true, 18, null },
                    { 36, 36, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9705), null, true, 18, null },
                    { 37, 37, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9705), null, true, 19, null },
                    { 38, 38, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9706), null, true, 19, null },
                    { 39, 39, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9706), null, true, 20, null },
                    { 40, 40, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9707), null, true, 20, null },
                    { 41, 41, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9707), null, true, 21, null },
                    { 42, 42, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9708), null, true, 21, null },
                    { 43, 43, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9708), null, true, 22, null },
                    { 44, 44, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9708), null, true, 22, null },
                    { 45, 45, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9709), null, true, 23, null },
                    { 46, 46, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9709), null, true, 23, null },
                    { 47, 47, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9710), null, true, 24, null },
                    { 48, 48, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9710), null, true, 24, null },
                    { 49, 49, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9711), null, true, 25, null },
                    { 50, 50, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9711), null, true, 25, null },
                    { 51, 51, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9712), null, true, 26, null },
                    { 52, 52, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9712), null, true, 26, null },
                    { 53, 53, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9713), null, true, 27, null },
                    { 54, 54, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9713), null, true, 27, null },
                    { 55, 55, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9714), null, true, 28, null },
                    { 56, 56, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9714), null, true, 28, null },
                    { 57, 57, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9715), null, true, 29, null },
                    { 58, 58, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9715), null, true, 29, null },
                    { 59, 59, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9716), null, true, 30, null },
                    { 60, 60, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9716), null, true, 30, null },
                    { 61, 61, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9717), null, true, 31, null },
                    { 62, 62, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9717), null, true, 31, null },
                    { 63, 63, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9718), null, true, 32, null },
                    { 64, 64, new DateTime(2023, 12, 11, 14, 36, 29, 196, DateTimeKind.Local).AddTicks(9718), null, true, 32, null }
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
