using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ads.Dal.Migrations
{
    /// <inheritdoc />
    public partial class _1001_update : Migration
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
                        principalColumn: "Id");
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
                    { 1, "e7bad36e-4d9a-4d2a-840f-96fdcf34c09a", "Superadmin", "SUPERADMIN" },
                    { 2, "e0b7bc79-56a8-4b1d-bb11-ad228528cabf", "Admin", "ADMIN" },
                    { 3, "69bbc6a5-8ba6-43c7-9ca8-724a2c93c45a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "09660182-b563-4e23-a4b0-dd3e9b24eb0b", new DateTime(2023, 12, 28, 11, 25, 43, 965, DateTimeKind.Local).AddTicks(2418), null, "superadmin@gmail.com", true, "SuperAdmin", "deneme", true, "SuperAdmin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEC5QflTC8FL68hMf7WW5U1Gtq6RR696P20hWp7JErUO4uH400qCu3ARgx5H1XBQsDw==", "+000000000", true, "06e5bcf3-030b-49c5-923b-ad1e19bdf41a", false, null, "superadmin@gmail.com" },
                    { 2, 0, "cd3b5611-0023-4b4c-bf86-eb9a6ecd4cf0", new DateTime(2023, 12, 28, 11, 25, 44, 9, DateTimeKind.Local).AddTicks(6661), null, "admin@gmail.com", true, "Admin", "deneme", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEWsHjqB5jIIQDwjKovjsrQhJ01EUZLaYDHaoGJUyoB1g3rUalj92zvepv0A2ZbboA==", "+000000000", false, "975a4c16-d2a9-4bdb-aa10-45a68291679e", false, null, "admin@gmail.com" },
                    { 3, 0, "163738d0-69ea-415a-94d0-dac00ded3c98", new DateTime(2023, 12, 28, 11, 25, 44, 53, DateTimeKind.Local).AddTicks(8295), null, "user1@gmail.com", true, "Aras", "deneme", true, "Menteşe", false, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEL3Q+HS9GoTDjnFimV+byYWnebMBZPBvUHR5tesHaMy3GHgjlOIY2r9WfbqGAty4XA==", "+000000000", false, "e48818c5-dc77-44ff-9123-94893d38e18c", false, null, "user1@gmail.com" },
                    { 4, 0, "23a14133-93aa-49c5-972f-ea7743cdd39d", new DateTime(2023, 12, 28, 11, 25, 44, 98, DateTimeKind.Local).AddTicks(1452), null, "user2@gmail.com", true, "Elif", "deneme", true, "Sakçı Tuncer", false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEDpR/IGC+06DD/dt9hiKFN/92Pu3oT0SVhXQUUtXLtcEnBVlfooTaTpwpQVnXFzpdw==", "+000000000", false, "0d2f8b69-f55b-4597-9d14-473da40b8b57", false, null, "user2@gmail.com" },
                    { 5, 0, "f31a9dbf-c76e-4e5d-860e-78faf12eceb2", new DateTime(2023, 12, 28, 11, 25, 44, 142, DateTimeKind.Local).AddTicks(4211), null, "user3@gmail.com", true, "İsmail", "deneme", true, "Yücer", false, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAENpBQY1mvk+6dFkiUhH8vmswMNod1HfivGhEaQv8PY2bx+PoNlimXKUcLcgsz0PXEw==", "+000000000", false, "19162f77-169a-416b-8e6e-ede2a428882e", false, null, "user3@gmail.com" },
                    { 6, 0, "d5bc9cc0-58fb-42e5-b428-d7ade114c5cf", new DateTime(2023, 12, 28, 11, 25, 44, 186, DateTimeKind.Local).AddTicks(6438), null, "user4@gmail.com", true, "Muratcan", "deneme", true, "Agıç", false, null, "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEBO99KE+n+m01LtCAEHde9qqVUhM9k6AxH6qoNM804Y3qkd2QneZbmZFAQp/wP7PiQ==", "+000000000", false, "84321b8b-f0b7-4e49-8319-cef57d60a7dc", false, null, "user4@gmail.com" },
                    { 7, 0, "878075b3-0909-4e01-b71e-33ba362eea75", new DateTime(2023, 12, 28, 11, 25, 44, 230, DateTimeKind.Local).AddTicks(9179), null, "user5@gmail.com", true, "Rıdvan", "deneme", true, "Kesken", false, null, "USER5@GMAIL.COM", "USER5@GMAIL.COM", "AQAAAAIAAYagAAAAEA29llYR2LwQkizcVMf9kEuLMQHypf2auEsXiRSA89XphuBkpvcEYBbsh4gtLD0OJQ==", "+000000000", false, "e55f668a-add1-4973-abd9-1e17515fb4d2", false, null, "user5@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconClass", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9700), null, "Elektronik araçların satıldığı kategoridir", "fa fa-laptop icon-bg-1", true, "Elektronik", null },
                    { 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9706), null, "Restoranlarınız ile ilgili reklamları burda verebilirsiniz", "fa fa-apple icon-bg-2", true, "Restoran", null },
                    { 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9707), null, "Ev,arsa,dükkan.", "fa fa-home icon-bg-3", true, "Emlak", null },
                    { 4, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9708), null, "7'den 70'e tüm ürünler.", "fa fa-shopping-basket icon-bg-4", true, "Alışveriş", null },
                    { 5, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9708), null, "Kendi mesleğine göre ilan verebilirsin.", "fa fa-briefcase icon-bg-5", true, "Meslekler", null },
                    { 6, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9709), null, "Aradığın araçlar burada", "fa fa-car icon-bg-6", true, "Araçlar", null },
                    { 7, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9710), null, "Evcil Hayvanlarınız İçin Herşey", "fa fa-paw icon-bg-7", true, "Pet Ürünleri", null },
                    { 8, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(9711), null, "Aradığınız hizmetler burada !", "fa fa-laptop icon-bg-8", true, "Hizmetler", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(1008), null, true, "Eskişehir", null },
                    { 2, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(1012), null, true, "İstanbul", null },
                    { 3, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(1013), null, true, "Ankara", null },
                    { 4, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(1014), null, true, "İzmir", null },
                    { 5, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(1015), null, true, "Adana", null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedDate", "IsActive", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "<section class=\"section\">\r\n  <div class=\"container\">\r\n    <div class=\"row\">\r\n      <div class=\"col-lg-6\">\r\n        <div class=\"about-img\">\r\n          <img src=\"~/template/images/about/about.jpg\" class=\"img-fluid w-100 rounded\" alt=\"\">\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-6 pt-5 pt-lg-0\">\r\n        <div class=\"about-content\">\r\n          <h3 class=\"font-weight-bold\">Introduction</h3>\r\n          <p>\r\n            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc est justo, aliquam nec tempor\r\n            fermentum, commodo et libero. Quisque et rutrum arcu. Vivamus dictum tincidunt magna id\r\n            euismod. Nam sollicitudin mi quis orci lobortis feugiat.\r\n          </p>\r\n          <h3 class=\"font-weight-bold\">How we can help</h3>\r\n          <p>\r\n            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc est justo, aliquam nec tempor\r\n            fermentum, commodo et libero. Quisque et rutrum arcu. Vivamus dictum tincidunt magna id\r\n            euismod. Nam sollicitudin mi quis orci lobortis feugiat. Lorem ipsum dolor sit amet,\r\n            consectetur adipiscing elit. Nunc est justo, aliquam nec tempor fermentum, commodo et libero.\r\n            Quisque et rutrum arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc est\r\n            justo, aliquam nec tempor fermentum, commodo et libero. Quisque et rutrum arcu. Vivamus dictum\r\n            tincidunt magna id euismod. Nam sollicitudin mi quis orci lobortis feugiat.\r\n          </p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</section>\r\n\r\n<section class=\"mb-5\">\r\n  <div class=\"container\">\r\n    <div class=\"row\">\r\n      <div class=\"col-lg-12\">\r\n        <div class=\"heading text-center text-capitalize font-weight-bold py-5\">\r\n          <h2>our team</h2>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6\">\r\n        <div class=\"card my-3 my-lg-0\">\r\n          <img class=\"card-img-top\" src=\"~/template/images/team/team1.jpg\" class=\"img-fluid w-100\" alt=\"Card image cap\">\r\n          <div class=\"card-body bg-gray text-center\">\r\n            <h5 class=\"card-title\">John Doe</h5>\r\n            <p class=\"card-text\">Founder / CEO</p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6\">\r\n        <div class=\"card my-3 my-lg-0\">\r\n          <img class=\"card-img-top\" src=\"~/template/images/team/team2.jpg\" class=\"img-fluid w-100\" alt=\"Card image cap\">\r\n          <div class=\"card-body bg-gray text-center\">\r\n            <h5 class=\"card-title\">John Doe</h5>\r\n            <p class=\"card-text\">Founder / CEO</p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6\">\r\n        <div class=\"card my-3 my-lg-0\">\r\n          <img class=\"card-img-top\" src=\"~/template/images/team/team3.jpg\" class=\"img-fluid w-100\" alt=\"Card image cap\">\r\n          <div class=\"card-body bg-gray text-center\">\r\n            <h5 class=\"card-title\">John Doe</h5>\r\n            <p class=\"card-text\">Founder / CEO</p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6\">\r\n        <div class=\"card my-3 my-lg-0\">\r\n          <img class=\"card-img-top\" src=\"~/template/images/team/team4.jpg\" class=\"img-fluid w-100\" alt=\"Card image cap\">\r\n          <div class=\"card-body bg-gray text-center\">\r\n            <h5 class=\"card-title\">John Doe</h5>\r\n            <p class=\"card-text\">Founder / CEO</p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</section>\r\n\r\n<section class=\"section bg-gray\">\r\n  <div class=\"container\">\r\n    <div class=\"row\">\r\n      <div class=\"col-lg-3 col-sm-6 my-lg-0 my-3\">\r\n        <div class=\"counter-content text-center bg-light py-4 rounded\">\r\n          <i class=\"fa fa-smile-o d-block\"></i>\r\n          <span class=\"counter my-2 d-block\" data-count=\"2314\">0</span>\r\n          <h5>Happy Customers</h5>\r\n          </script>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6 my-lg-0 my-3\">\r\n        <div class=\"counter-content text-center bg-light py-4 rounded\">\r\n          <i class=\"fa fa-user-o d-block\"></i>\r\n          <span class=\"counter my-2 d-block\" data-count=\"1013\">0</span>\r\n          <h5>Active Members</h5>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6 my-lg-0 my-3\">\r\n        <div class=\"counter-content text-center bg-light py-4 rounded\">\r\n          <i class=\"fa fa-bookmark-o d-block\"></i>\r\n          <span class=\"counter my-2 d-block\" data-count=\"2413\">0</span>\r\n          <h5>Verified Ads</h5>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-lg-3 col-sm-6 my-lg-0 my-3\">\r\n        <div class=\"counter-content text-center bg-light py-4 rounded\">\r\n          <i class=\"fa fa-smile-o d-block\"></i>\r\n          <span class=\"counter my-2 d-block\" data-count=\"200\">0</span>\r\n          <h5>Happy Customers</h5>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</section>\r\n", new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(5539), null, true, "Hakkımızda", null },
                    { 2, "<section class=\"section\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <div class=\"contact-us-content p-4\">\r\n                    <h5>Contact Us</h5>\r\n                    <h1 class=\"pt-3\">Hello, what's on your mind?</h1>\r\n                    <p class=\"pt-3 pb-5\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla elit dolor, blandit vel euismod ac, lentesque et dolor. Ut id tempus ipsum.</p>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                    <form action=\"#\">\r\n                        <fieldset class=\"p-4\">\r\n                            <div class=\"form-group\">\r\n                                <div class=\"row\">\r\n                                    <div class=\"col-lg-6 py-2\">\r\n                                        <input type=\"text\" placeholder=\"Name *\" class=\"form-control\" required>\r\n                                    </div>\r\n                                    <div class=\"col-lg-6 pt-2\">\r\n                                        <input type=\"email\" placeholder=\"Email *\" class=\"form-control\" required>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <select name=\"\" id=\"\" class=\"form-control w-100\">\r\n                                <option value=\"1\">Select Category</option>\r\n                                <option value=\"1\">Laptop</option>\r\n                                <option value=\"1\">iPhone</option>\r\n                                <option value=\"1\">Monitor</option>\r\n                                <option value=\"1\">I need</option>\r\n                            </select>\r\n                            <textarea name=\"message\" id=\"\"  placeholder=\"Message *\" class=\"border w-100 p-3 mt-3 mt-lg-4\"></textarea>\r\n                            <div class=\"btn-grounp\">\r\n                                <button type=\"submit\" class=\"btn btn-primary mt-2 float-right\">SUBMIT</button>\r\n                            </div>\r\n                        </fieldset>\r\n                    </form>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>", new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(5544), null, true, "Bize Ulaşın", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "ClickCount", "ConditionEnum", "CreatedDate", "DeletedDate", "Description", "IsActive", "Price", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6763), null, "Siyah az kullanılmıs laptop", true, 140, "Siyah Laptop", null, 3 },
                    { 2, 0, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6768), null, "Beyaz laptop. İhtiyacım olduğu için satıyorum", true, 250, "Beyaz Laptop", null, 4 },
                    { 3, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6769), null, "2013 model İphone", true, 340, "Iphone Telefon", null, 5 },
                    { 4, 0, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6771), null, "Android telefon en iyi telefondur", true, 240, "Android Telefon", null, 7 },
                    { 5, 0, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6772), null, "Samsung Android Tablet. Sahibinden satılıktır", true, 220, "Android Tablet", null, 4 },
                    { 6, 0, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6773), null, "Kardeşimin ipadini satıyoruz. Üstünde az çizik vardır", true, 180, "İPhone Tablet IPad", null, 6 },
                    { 7, 0, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6774), null, "Led ekran televizyon. 20 cm e 50 cm. Az kullanılmış", true, 540, "Led Ekran", null, 6 },
                    { 8, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6775), null, "17 inch ekranımı satıyorum", true, 40, "Pc Ekranı", null, 3 },
                    { 9, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6776), null, "Ayşin kafede ev yemekleri seni çağırıyor", true, 400, "Ayşin Kafe", null, 5 },
                    { 10, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6777), null, "Kafe Paranoma, dünyaca ünlü kahve çeşitleri burada", true, 470, "Cafe Paranoma", null, 6 },
                    { 11, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6778), null, "Mcdonals seni çağırıyor", true, 200, "Mcdonalds", null, 4 },
                    { 12, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6779), null, "Tostumu yiyen başka bişey yemez", true, 120, "Tostçu Erol", null, 3 },
                    { 13, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6780), null, "Her tür yemek bulunur", true, 30, "Restoran Eskargo", null, 6 },
                    { 14, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6781), null, "Yeşim restoranda her şey var", true, 140, "Yeşim Restoran", null, 5 },
                    { 15, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6782), null, "Yemekler bizden sorulur", true, 340, "Ayşe Teyze Restoran", null, 6 },
                    { 16, 0, 0, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6783), null, "Bodrum un eşsiz yemek lezzetleri burada", true, 120, "Bodrum Ev Yemekleri", null, 7 },
                    { 17, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6784), null, "10 numara arsa!", true, 40, "20 metrekare, denize karşı ", null, 3 },
                    { 18, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6785), null, "İstediğini ek, biç.", true, 75, "30x35 arsa, sahibinden.", null, 4 },
                    { 19, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6786), null, "Kullanıma hazır spor salonu.", true, 40, "Her türlü alet mevcut", null, 6 },
                    { 20, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6787), null, "Ben olsam düşünmeden alırım.", true, 25, "3 kuşaktır işlettiğimiz spor salonu satılık.", null, 5 },
                    { 21, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6788), null, "Dahiliye dahil.", true, 100000, "Hastane satılır mı demeyin, satılır.", null, 3 },
                    { 22, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6789), null, "Çok da alet yok ama iş görür.", true, 165, "Küçük klinik, her türlü hastaya bi bakarsınız.", null, 7 },
                    { 23, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6790), null, "Hiç düşünmeden kirala dayıoğlu. ", true, 270, "İstanbulun gözde semti Bağcılarda 0+0 daire", null, 4 },
                    { 24, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6791), null, "Parası olmayan aramasın lütfen.", true, 375, "3+1 fıstık gibi aileye daire.", null, 6 },
                    { 25, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6814), null, "Yaz, kış giyilir. Sıcak tutar.", true, 85, "Siyah Atlet", null, 7 },
                    { 26, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6815), null, "Biraz rahatsız eder ama, ortamlarda en şık sen olursun!", true, 185, "Slip Don", null, 5 },
                    { 27, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6816), null, "Al ve teklif et!", true, 30, "Altın Yüzük", null, 4 },
                    { 28, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6817), null, "Çok şık, çok güzel!", true, 45, "Gümüş Bileklik", null, 3 },
                    { 29, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6818), null, "Çocuğunuzun kafası sıccacık!", true, 20, "Bere", null, 2 },
                    { 30, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6819), null, "Bebeniz kar oynasın.", true, 45, "Eldiven", null, 5 },
                    { 31, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6820), null, "Her işinizi bununla yapın.", true, 50, "SoftMicro 360", null, 3 },
                    { 32, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6821), null, "Müzik dinlemek ister misin?", true, 65, "Stopify", null, 4 },
                    { 33, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6822), null, "Lorem Ipsum is simply dummy text of the printing", true, 400, "Vergi Ödeme", null, 3 },
                    { 34, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6823), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Fatura Kesme", null, 5 },
                    { 35, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6824), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Hızlı Çözüm", null, 6 },
                    { 36, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6825), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Yedek Malzeme", null, 6 },
                    { 37, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6826), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Matematik", null, 5 },
                    { 38, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6827), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Türkçe", null, 3 },
                    { 39, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6828), null, "Lorem Ipsum is simply dummy text of the printing", true, 1000, "Bina", null, 7 },
                    { 40, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6829), null, "Lorem Ipsum is simply dummy text of the printing", true, 760, "Daire", null, 3 },
                    { 41, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6830), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "Büyük Otobüs", null, 3 },
                    { 42, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6831), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Küçük Otobüs", null, 5 },
                    { 43, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6832), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "SUV", null, 7 },
                    { 44, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6833), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Sedan", null, 4 },
                    { 45, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6834), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Scooter", null, 7 },
                    { 46, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6835), null, "Lorem Ipsum is simply dummy text of the printing", true, 350, "Adventure", null, 4 },
                    { 47, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6836), null, "Lorem Ipsum is simply dummy text of the printing", true, 10000, "Yelkenli", null, 7 },
                    { 48, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6837), null, "Lorem Ipsum is simply dummy text of the printing", true, 15000, "Kamaralı ", null, 4 },
                    { 49, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6838), null, "Kediniz için şık tasma", true, 100, "Kedi Tasması", null, 3 },
                    { 50, 0, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6839), null, "10+2 Kilogram Kedi Kumu", true, 120, "Kedi Kumu", null, 3 },
                    { 51, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6840), null, "Köpeğiniz için şık tasma", true, 100, "Köpek Tasması", null, 3 },
                    { 52, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6841), null, "10+2 Kilogram Kuru Köpek Maması", true, 900, "Kuru Köpek Maması", null, 4 },
                    { 53, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6844), null, "1 Kilogram Kuş Yemi", true, 150, "Kuş Yemi", null, 5 },
                    { 54, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6845), null, "Suluk ve dalları olan kuş kafesi", true, 500, "Kafes", null, 5 },
                    { 55, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6842), null, "1 Kilogram Balık Maması", true, 200, "Balık Maması", null, 4 },
                    { 56, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6843), null, "Büyük boy akvaryum", true, 1500, "Akvaryum", null, 4 },
                    { 57, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6846), null, "Detaylı ev temizliği", true, 700, "Ev Temizliği", null, 5 },
                    { 58, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6847), null, "Detaylı ofis temizliği", true, 2500, "Ofis Temizliği", null, 6 },
                    { 59, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6848), null, "Detaylı İç-Dış Yıkama", true, 300, "İç-Dış Yıkama", null, 6 },
                    { 60, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6849), null, "Oto-Kuaför Servisi", true, 1200, "Oto-Kuaför", null, 6 },
                    { 61, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6850), null, "Takım elbiselerinizi 1 günde tertemiz yapıyoruz.", true, 200, "Takım Elbiseler için Kuru Temizleme", null, 7 },
                    { 62, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6851), null, "Giyecekleriniz için hızlı kuru temizleme servisi", true, 50, "Diğer Kuru Temizleme", null, 7 },
                    { 63, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6852), null, "İçine girince güzel.", true, 3500, "Tabut", null, 7 },
                    { 64, 0, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(6853), null, "Hayır duası için ...", true, 7500, "Cenaze Yemeği", null, 7 }
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
                    { 1, 1, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2324), null, true, "Odunpazarı", null },
                    { 2, 1, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2330), null, true, "Tepebaşı", null },
                    { 3, 2, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2331), null, true, "Beşiktaş", null },
                    { 4, 2, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2331), null, true, "Beyoğlu", null },
                    { 5, 3, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2332), null, true, "Çankaya", null },
                    { 6, 3, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2333), null, true, "Sincan", null },
                    { 7, 4, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2334), null, true, "Bayraklı", null },
                    { 8, 4, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2334), null, true, "Foça", null },
                    { 9, 5, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2335), null, true, "Çukurova", null },
                    { 10, 5, new DateTime(2023, 12, 28, 11, 25, 43, 963, DateTimeKind.Local).AddTicks(2336), null, true, "Seyhan", null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DarkMode", "DeletedDate", "IsActive", "Name", "UpdatedDate", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(7882), false, null, true, "Sayfa Başına İlan Sayısı", null, 1, "50" },
                    { 2, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(7888), false, null, true, "Sayfa Başına İlan Sayısı", null, 2, "20" },
                    { 3, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(7890), false, null, true, "Sayfa Başına İlan Sayısı", null, 3, "10" },
                    { 4, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(7890), false, null, true, "Karanlı Mod", null, 1, "Açık" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1148), null, true, "Laptop", null },
                    { 2, 1, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1153), null, true, "Telefon", null },
                    { 3, 1, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1153), null, true, "Tablet", null },
                    { 4, 1, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1154), null, true, "Ekran", null },
                    { 5, 2, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1155), null, true, "Kafe", null },
                    { 6, 2, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1156), null, true, "Fast Food", null },
                    { 7, 2, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1156), null, true, "Restoran", null },
                    { 8, 2, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1157), null, true, "Yöresel Yemekler", null },
                    { 9, 3, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1158), null, true, "Arsa", null },
                    { 10, 3, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1158), null, true, "Spor Salonu", null },
                    { 11, 3, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1159), null, true, "Hastane", null },
                    { 12, 3, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1160), null, true, "Ev", null },
                    { 13, 4, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1161), null, true, "Erkek Giysileri", null },
                    { 14, 4, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1161), null, true, "Aksesuarlar", null },
                    { 15, 4, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1162), null, true, "Çocuk Giysileri", null },
                    { 16, 4, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1163), null, true, "Yazılım", null },
                    { 17, 5, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1164), null, true, "Muhasebe", null },
                    { 18, 5, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1164), null, true, "Kombi Tamiri", null },
                    { 19, 5, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1194), null, true, "Özel Ders", null },
                    { 20, 5, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1195), null, true, "Boyacı", null },
                    { 21, 6, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1195), null, true, "Otobüs", null },
                    { 22, 6, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1196), null, true, "Araç", null },
                    { 23, 6, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1201), null, true, "Motorsiklet", null },
                    { 24, 6, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1201), null, true, "Yat", null },
                    { 25, 7, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1202), null, true, "Kedi Ürünleri", null },
                    { 26, 7, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1203), null, true, "Köpek Ürünleri", null },
                    { 27, 7, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1204), null, true, "Kuş Ürünleri", null },
                    { 28, 7, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1204), null, true, "Balık Ürünleri", null },
                    { 29, 8, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1205), null, true, "Temizlik", null },
                    { 30, 8, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1206), null, true, "Araba Yıkama", null },
                    { 31, 8, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1206), null, true, "Kuru Temizleme", null },
                    { 32, 8, new DateTime(2023, 12, 28, 11, 25, 44, 278, DateTimeKind.Local).AddTicks(1207), null, true, "Cenaze", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "Country", "CreatedDate", "DeletedDate", "DetailedAddress", "DistrictId", "IsActive", "PostCode", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Türkiye", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(2368), null, "Emin Sokak", 1, true, "341449", null, 3 },
                    { 2, 2, "Türkiye", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(2378), null, "Kerem Sokak Kus Apartmani", 3, true, "25123", null, 4 },
                    { 3, 4, "Türkiye", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(2379), null, "Reşadiye cami üstü", 7, true, "26120", null, 5 },
                    { 4, 5, "Türkiye", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(2380), null, "Akşemsettin Mahallesi", 10, true, "01240", null, 6 },
                    { 5, 3, "Türkiye", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(2381), null, "Odabaşı Cd.", 6, true, "06810", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "AdvertComments",
                columns: new[] { "Id", "AdvertId", "Comment", "CreatedDate", "DeletedDate", "IsActive", "StarCount", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Kargo hızlı geldi. Çok memnun kaldım", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4579), null, true, 5, null, 3 },
                    { 2, 3, "Ürün hiç beklediğim gibi değildi. Hiç beğenmedim", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4585), null, true, 1, null, 3 },
                    { 3, 3, "Ürün çok kötüydü. Hiç beğenmedim", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4586), null, true, 2, null, 4 },
                    { 4, 2, "Bu nasıl bir ürün, ben böyle bir şey görmemişim.", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4587), null, true, 1, null, 4 },
                    { 5, 2, "Ürün görüldüğü gibiydi.", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4588), null, true, 4, null, 7 },
                    { 6, 3, "Güzel paketlenmişti.", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4588), null, true, 4, null, 5 },
                    { 7, 6, "Fiyat performans bekledik fos çıktı !", new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(4590), null, true, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AdvertImages",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "ImagePath", "IsActive", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8158), null, "http://via.placeholder.com/610x400", true, null },
                    { 2, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8164), null, "http://via.placeholder.com/610x400", true, null },
                    { 3, 1, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8164), null, "http://via.placeholder.com/610x400", true, null },
                    { 4, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8165), null, "http://via.placeholder.com/610x400", true, null },
                    { 5, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8166), null, "http://via.placeholder.com/610x400", true, null },
                    { 6, 2, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8167), null, "http://via.placeholder.com/610x400", true, null },
                    { 7, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8168), null, "http://via.placeholder.com/610x400", true, null },
                    { 8, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8169), null, "http://via.placeholder.com/610x400", true, null },
                    { 9, 3, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8169), null, "http://via.placeholder.com/610x400", true, null },
                    { 10, 4, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8170), null, "http://via.placeholder.com/610x400", true, null },
                    { 11, 4, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8171), null, "http://via.placeholder.com/610x400", true, null },
                    { 12, 4, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8171), null, "http://via.placeholder.com/610x400", true, null },
                    { 13, 5, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8172), null, "http://via.placeholder.com/610x400", true, null },
                    { 14, 5, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8172), null, "http://via.placeholder.com/610x400", true, null },
                    { 15, 5, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8173), null, "http://via.placeholder.com/610x400", true, null },
                    { 16, 6, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8173), null, "http://via.placeholder.com/610x400", true, null },
                    { 17, 6, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8174), null, "http://via.placeholder.com/610x400", true, null },
                    { 18, 6, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8175), null, "http://via.placeholder.com/610x400", true, null },
                    { 19, 7, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8175), null, "http://via.placeholder.com/610x400", true, null },
                    { 20, 7, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8176), null, "http://via.placeholder.com/610x400", true, null },
                    { 21, 7, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8176), null, "http://via.placeholder.com/610x400", true, null },
                    { 22, 8, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8177), null, "http://via.placeholder.com/610x400", true, null },
                    { 23, 8, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8177), null, "http://via.placeholder.com/610x400", true, null },
                    { 24, 8, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8178), null, "http://via.placeholder.com/610x400", true, null },
                    { 25, 9, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8178), null, "http://via.placeholder.com/610x400", true, null },
                    { 26, 9, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8179), null, "http://via.placeholder.com/610x400", true, null },
                    { 27, 9, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8179), null, "http://via.placeholder.com/610x400", true, null },
                    { 28, 10, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8180), null, "http://via.placeholder.com/610x400", true, null },
                    { 29, 10, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8180), null, "http://via.placeholder.com/610x400", true, null },
                    { 30, 10, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8181), null, "http://via.placeholder.com/610x400", true, null },
                    { 31, 11, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8181), null, "http://via.placeholder.com/610x400", true, null },
                    { 32, 11, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8182), null, "http://via.placeholder.com/610x400", true, null },
                    { 33, 11, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8182), null, "http://via.placeholder.com/610x400", true, null },
                    { 34, 12, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8183), null, "http://via.placeholder.com/610x400", true, null },
                    { 35, 12, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8184), null, "http://via.placeholder.com/610x400", true, null },
                    { 36, 12, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8184), null, "http://via.placeholder.com/610x400", true, null },
                    { 37, 13, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8185), null, "http://via.placeholder.com/610x400", true, null },
                    { 38, 13, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8185), null, "http://via.placeholder.com/610x400", true, null },
                    { 39, 13, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8186), null, "http://via.placeholder.com/610x400", true, null },
                    { 40, 14, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8186), null, "http://via.placeholder.com/610x400", true, null },
                    { 41, 14, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8187), null, "http://via.placeholder.com/610x400", true, null },
                    { 42, 14, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8187), null, "http://via.placeholder.com/610x400", true, null },
                    { 43, 15, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8188), null, "http://via.placeholder.com/610x400", true, null },
                    { 44, 15, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8188), null, "http://via.placeholder.com/610x400", true, null },
                    { 45, 15, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8189), null, "http://via.placeholder.com/610x400", true, null },
                    { 46, 16, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8215), null, "http://via.placeholder.com/610x400", true, null },
                    { 47, 16, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8216), null, "http://via.placeholder.com/610x400", true, null },
                    { 48, 16, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8216), null, "http://via.placeholder.com/610x400", true, null },
                    { 49, 17, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8217), null, "http://via.placeholder.com/610x400", true, null },
                    { 50, 17, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8217), null, "http://via.placeholder.com/610x400", true, null },
                    { 51, 17, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8218), null, "http://via.placeholder.com/610x400", true, null },
                    { 52, 18, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8218), null, "http://via.placeholder.com/610x400", true, null },
                    { 53, 18, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8219), null, "http://via.placeholder.com/610x400", true, null },
                    { 54, 18, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8219), null, "http://via.placeholder.com/610x400", true, null },
                    { 55, 19, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8220), null, "http://via.placeholder.com/610x400", true, null },
                    { 56, 19, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8220), null, "http://via.placeholder.com/610x400", true, null },
                    { 57, 19, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8221), null, "http://via.placeholder.com/610x400", true, null },
                    { 58, 20, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8221), null, "http://via.placeholder.com/610x400", true, null },
                    { 59, 20, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8222), null, "http://via.placeholder.com/610x400", true, null },
                    { 60, 20, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8222), null, "http://via.placeholder.com/610x400", true, null },
                    { 61, 21, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8223), null, "http://via.placeholder.com/610x400", true, null },
                    { 62, 21, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8223), null, "http://via.placeholder.com/610x400", true, null },
                    { 63, 21, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8224), null, "http://via.placeholder.com/610x400", true, null },
                    { 64, 22, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8224), null, "http://via.placeholder.com/610x400", true, null },
                    { 65, 22, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8225), null, "http://via.placeholder.com/610x400", true, null },
                    { 66, 22, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8226), null, "http://via.placeholder.com/610x400", true, null },
                    { 67, 23, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8227), null, "http://via.placeholder.com/610x400", true, null },
                    { 68, 23, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8227), null, "http://via.placeholder.com/610x400", true, null },
                    { 69, 23, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8228), null, "http://via.placeholder.com/610x400", true, null },
                    { 70, 24, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8228), null, "http://via.placeholder.com/610x400", true, null },
                    { 71, 24, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8229), null, "http://via.placeholder.com/610x400", true, null },
                    { 72, 24, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8229), null, "http://via.placeholder.com/610x400", true, null },
                    { 73, 25, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8230), null, "http://via.placeholder.com/610x400", true, null },
                    { 74, 25, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8230), null, "http://via.placeholder.com/610x400", true, null },
                    { 75, 25, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8231), null, "http://via.placeholder.com/610x400", true, null },
                    { 76, 26, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8231), null, "http://via.placeholder.com/610x400", true, null },
                    { 77, 26, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8232), null, "http://via.placeholder.com/610x400", true, null },
                    { 78, 26, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8232), null, "http://via.placeholder.com/610x400", true, null },
                    { 79, 27, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8233), null, "http://via.placeholder.com/610x400", true, null },
                    { 80, 27, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8233), null, "http://via.placeholder.com/610x400", true, null },
                    { 81, 27, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8233), null, "http://via.placeholder.com/610x400", true, null },
                    { 82, 28, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8234), null, "http://via.placeholder.com/610x400", true, null },
                    { 83, 28, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8234), null, "http://via.placeholder.com/610x400", true, null },
                    { 84, 28, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8235), null, "http://via.placeholder.com/610x400", true, null },
                    { 85, 29, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8235), null, "http://via.placeholder.com/610x400", true, null },
                    { 86, 29, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8236), null, "http://via.placeholder.com/610x400", true, null },
                    { 87, 29, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8236), null, "http://via.placeholder.com/610x400", true, null },
                    { 88, 30, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8237), null, "http://via.placeholder.com/610x400", true, null },
                    { 89, 30, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8237), null, "http://via.placeholder.com/610x400", true, null },
                    { 90, 30, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8238), null, "http://via.placeholder.com/610x400", true, null },
                    { 91, 31, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8238), null, "http://via.placeholder.com/610x400", true, null },
                    { 92, 31, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8239), null, "http://via.placeholder.com/610x400", true, null },
                    { 93, 31, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8239), null, "http://via.placeholder.com/610x400", true, null },
                    { 94, 32, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8240), null, "http://via.placeholder.com/610x400", true, null },
                    { 95, 32, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8240), null, "http://via.placeholder.com/610x400", true, null },
                    { 96, 32, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8240), null, "http://via.placeholder.com/610x400", true, null },
                    { 97, 33, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8241), null, "http://via.placeholder.com/610x400", true, null },
                    { 98, 33, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8241), null, "http://via.placeholder.com/610x400", true, null },
                    { 99, 33, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8242), null, "http://via.placeholder.com/610x400", true, null },
                    { 100, 34, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8242), null, "http://via.placeholder.com/610x400", true, null },
                    { 101, 34, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8243), null, "http://via.placeholder.com/610x400", true, null },
                    { 102, 34, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8243), null, "http://via.placeholder.com/610x400", true, null },
                    { 103, 35, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8244), null, "http://via.placeholder.com/610x400", true, null },
                    { 104, 35, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8244), null, "http://via.placeholder.com/610x400", true, null },
                    { 105, 35, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8245), null, "http://via.placeholder.com/610x400", true, null },
                    { 106, 36, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8245), null, "http://via.placeholder.com/610x400", true, null },
                    { 107, 36, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8246), null, "http://via.placeholder.com/610x400", true, null },
                    { 108, 36, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8246), null, "http://via.placeholder.com/610x400", true, null },
                    { 109, 37, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8246), null, "http://via.placeholder.com/610x400", true, null },
                    { 110, 37, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8247), null, "http://via.placeholder.com/610x400", true, null },
                    { 111, 37, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8247), null, "http://via.placeholder.com/610x400", true, null },
                    { 112, 38, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8248), null, "http://via.placeholder.com/610x400", true, null },
                    { 113, 38, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8248), null, "http://via.placeholder.com/610x400", true, null },
                    { 114, 38, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8249), null, "http://via.placeholder.com/610x400", true, null },
                    { 115, 39, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8249), null, "http://via.placeholder.com/610x400", true, null },
                    { 116, 39, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8250), null, "http://via.placeholder.com/610x400", true, null },
                    { 117, 39, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8250), null, "http://via.placeholder.com/610x400", true, null },
                    { 118, 40, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8251), null, "http://via.placeholder.com/610x400", true, null },
                    { 119, 40, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8251), null, "http://via.placeholder.com/610x400", true, null },
                    { 120, 40, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8252), null, "http://via.placeholder.com/610x400", true, null },
                    { 121, 41, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8252), null, "http://via.placeholder.com/610x400", true, null },
                    { 122, 41, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8253), null, "http://via.placeholder.com/610x400", true, null },
                    { 123, 41, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8253), null, "http://via.placeholder.com/610x400", true, null },
                    { 124, 42, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8253), null, "http://via.placeholder.com/610x400", true, null },
                    { 125, 42, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8254), null, "http://via.placeholder.com/610x400", true, null },
                    { 126, 42, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8254), null, "http://via.placeholder.com/610x400", true, null },
                    { 127, 43, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8271), null, "http://via.placeholder.com/610x400", true, null },
                    { 128, 43, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8272), null, "http://via.placeholder.com/610x400", true, null },
                    { 129, 43, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8272), null, "http://via.placeholder.com/610x400", true, null },
                    { 130, 44, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8273), null, "http://via.placeholder.com/610x400", true, null },
                    { 131, 44, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8274), null, "http://via.placeholder.com/610x400", true, null },
                    { 132, 44, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8274), null, "http://via.placeholder.com/610x400", true, null },
                    { 133, 45, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8275), null, "http://via.placeholder.com/610x400", true, null },
                    { 134, 45, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8275), null, "http://via.placeholder.com/610x400", true, null },
                    { 135, 45, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8276), null, "http://via.placeholder.com/610x400", true, null },
                    { 136, 46, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8276), null, "http://via.placeholder.com/610x400", true, null },
                    { 137, 46, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8277), null, "http://via.placeholder.com/610x400", true, null },
                    { 138, 46, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8277), null, "http://via.placeholder.com/610x400", true, null },
                    { 139, 47, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8278), null, "http://via.placeholder.com/610x400", true, null },
                    { 140, 47, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8278), null, "http://via.placeholder.com/610x400", true, null },
                    { 141, 47, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8279), null, "http://via.placeholder.com/610x400", true, null },
                    { 142, 48, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8279), null, "http://via.placeholder.com/610x400", true, null },
                    { 143, 48, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8280), null, "http://via.placeholder.com/610x400", true, null },
                    { 144, 48, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8280), null, "http://via.placeholder.com/610x400", true, null },
                    { 145, 49, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8280), null, "http://via.placeholder.com/610x400", true, null },
                    { 146, 49, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8281), null, "http://via.placeholder.com/610x400", true, null },
                    { 147, 49, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8281), null, "http://via.placeholder.com/610x400", true, null },
                    { 148, 50, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8282), null, "http://via.placeholder.com/610x400", true, null },
                    { 149, 50, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8282), null, "http://via.placeholder.com/610x400", true, null },
                    { 150, 50, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8283), null, "http://via.placeholder.com/610x400", true, null },
                    { 151, 51, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8283), null, "http://via.placeholder.com/610x400", true, null },
                    { 152, 51, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8284), null, "http://via.placeholder.com/610x400", true, null },
                    { 153, 51, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8284), null, "http://via.placeholder.com/610x400", true, null },
                    { 154, 52, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8285), null, "http://via.placeholder.com/610x400", true, null },
                    { 155, 52, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8285), null, "http://via.placeholder.com/610x400", true, null },
                    { 156, 52, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8286), null, "http://via.placeholder.com/610x400", true, null },
                    { 157, 53, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8286), null, "http://via.placeholder.com/610x400", true, null },
                    { 158, 53, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8286), null, "http://via.placeholder.com/610x400", true, null },
                    { 159, 53, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8287), null, "http://via.placeholder.com/610x400", true, null },
                    { 160, 54, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8287), null, "http://via.placeholder.com/610x400", true, null },
                    { 161, 54, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8288), null, "http://via.placeholder.com/610x400", true, null },
                    { 162, 54, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8288), null, "http://via.placeholder.com/610x400", true, null },
                    { 163, 55, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8289), null, "http://via.placeholder.com/610x400", true, null },
                    { 164, 55, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8289), null, "http://via.placeholder.com/610x400", true, null },
                    { 165, 55, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8290), null, "http://via.placeholder.com/610x400", true, null },
                    { 166, 56, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8290), null, "http://via.placeholder.com/610x400", true, null },
                    { 167, 56, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8291), null, "http://via.placeholder.com/610x400", true, null },
                    { 168, 56, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8291), null, "http://via.placeholder.com/610x400", true, null },
                    { 169, 57, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8292), null, "http://via.placeholder.com/610x400", true, null },
                    { 170, 57, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8292), null, "http://via.placeholder.com/610x400", true, null },
                    { 171, 57, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8293), null, "http://via.placeholder.com/610x400", true, null },
                    { 172, 58, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8293), null, "http://via.placeholder.com/610x400", true, null },
                    { 173, 58, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8293), null, "http://via.placeholder.com/610x400", true, null },
                    { 174, 58, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8294), null, "http://via.placeholder.com/610x400", true, null },
                    { 175, 59, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8294), null, "http://via.placeholder.com/610x400", true, null },
                    { 176, 59, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8295), null, "http://via.placeholder.com/610x400", true, null },
                    { 177, 59, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8295), null, "http://via.placeholder.com/610x400", true, null },
                    { 178, 60, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8296), null, "http://via.placeholder.com/610x400", true, null },
                    { 179, 60, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8296), null, "http://via.placeholder.com/610x400", true, null },
                    { 180, 60, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8297), null, "http://via.placeholder.com/610x400", true, null },
                    { 181, 61, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8297), null, "http://via.placeholder.com/610x400", true, null },
                    { 182, 61, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8298), null, "http://via.placeholder.com/610x400", true, null },
                    { 183, 61, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8298), null, "http://via.placeholder.com/610x400", true, null },
                    { 184, 62, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8299), null, "http://via.placeholder.com/610x400", true, null },
                    { 185, 62, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8299), null, "http://via.placeholder.com/610x400", true, null },
                    { 186, 62, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8300), null, "http://via.placeholder.com/610x400", true, null },
                    { 187, 63, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8300), null, "http://via.placeholder.com/610x400", true, null },
                    { 188, 63, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8301), null, "http://via.placeholder.com/610x400", true, null },
                    { 189, 63, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8301), null, "http://via.placeholder.com/610x400", true, null },
                    { 190, 64, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8301), null, "http://via.placeholder.com/610x400", true, null },
                    { 191, 64, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8302), null, "http://via.placeholder.com/610x400", true, null },
                    { 192, 64, new DateTime(2023, 12, 28, 11, 25, 43, 962, DateTimeKind.Local).AddTicks(8302), null, "http://via.placeholder.com/610x400", true, null }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryAdverts",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "IsActive", "SubcategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9292), null, true, 1, null },
                    { 2, 2, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9297), null, true, 1, null },
                    { 3, 3, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9297), null, true, 2, null },
                    { 4, 4, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9298), null, true, 2, null },
                    { 5, 5, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9299), null, true, 3, null },
                    { 6, 6, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9300), null, true, 3, null },
                    { 7, 7, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9301), null, true, 4, null },
                    { 8, 8, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9301), null, true, 4, null },
                    { 9, 9, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9302), null, true, 5, null },
                    { 10, 10, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9303), null, true, 5, null },
                    { 11, 11, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9310), null, true, 6, null },
                    { 12, 12, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9311), null, true, 6, null },
                    { 13, 13, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9311), null, true, 7, null },
                    { 14, 14, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9312), null, true, 7, null },
                    { 15, 15, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9313), null, true, 8, null },
                    { 16, 16, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9314), null, true, 8, null },
                    { 17, 17, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9314), null, true, 9, null },
                    { 18, 18, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9315), null, true, 9, null },
                    { 19, 19, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9316), null, true, 10, null },
                    { 20, 20, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9367), null, true, 10, null },
                    { 21, 21, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9376), null, true, 11, null },
                    { 22, 22, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9376), null, true, 11, null },
                    { 23, 23, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9377), null, true, 12, null },
                    { 24, 24, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9378), null, true, 12, null },
                    { 25, 25, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9379), null, true, 13, null },
                    { 26, 26, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9379), null, true, 13, null },
                    { 27, 27, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9380), null, true, 14, null },
                    { 28, 28, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9381), null, true, 14, null },
                    { 29, 29, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9381), null, true, 15, null },
                    { 30, 30, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9382), null, true, 15, null },
                    { 31, 31, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9383), null, true, 16, null },
                    { 32, 32, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9383), null, true, 16, null },
                    { 33, 33, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9384), null, true, 17, null },
                    { 34, 34, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9385), null, true, 17, null },
                    { 35, 35, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9385), null, true, 18, null },
                    { 36, 36, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9386), null, true, 18, null },
                    { 37, 37, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9387), null, true, 19, null },
                    { 38, 38, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9388), null, true, 19, null },
                    { 39, 39, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9388), null, true, 20, null },
                    { 40, 40, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9389), null, true, 20, null },
                    { 41, 41, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9390), null, true, 21, null },
                    { 42, 42, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9390), null, true, 21, null },
                    { 43, 43, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9391), null, true, 22, null },
                    { 44, 44, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9392), null, true, 22, null },
                    { 45, 45, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9392), null, true, 23, null },
                    { 46, 46, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9393), null, true, 23, null },
                    { 47, 47, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9394), null, true, 24, null },
                    { 48, 48, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9394), null, true, 24, null },
                    { 49, 49, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9395), null, true, 25, null },
                    { 50, 50, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9396), null, true, 25, null },
                    { 51, 51, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9396), null, true, 26, null },
                    { 52, 52, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9397), null, true, 26, null },
                    { 53, 53, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9398), null, true, 27, null },
                    { 54, 54, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9399), null, true, 27, null },
                    { 55, 55, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9399), null, true, 28, null },
                    { 56, 56, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9400), null, true, 28, null },
                    { 57, 57, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9401), null, true, 29, null },
                    { 58, 58, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9401), null, true, 29, null },
                    { 59, 59, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9402), null, true, 30, null },
                    { 60, 60, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9403), null, true, 30, null },
                    { 61, 61, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9403), null, true, 31, null },
                    { 62, 62, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9431), null, true, 31, null },
                    { 63, 63, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9432), null, true, 32, null },
                    { 64, 64, new DateTime(2023, 12, 28, 11, 25, 44, 277, DateTimeKind.Local).AddTicks(9433), null, true, 32, null }
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
