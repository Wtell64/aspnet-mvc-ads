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
                    { 1, "2abd9a08-0319-4161-b2c8-97b57e9dfaa8", "Superadmin", "SUPERADMIN" },
                    { 2, "c9970507-99b4-4f4f-b50c-3c5422dfc8c7", "Admin", "ADMIN" },
                    { 3, "8066badc-19f3-4592-8768-d3ba89cb98d3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "e54a38ec-d7c9-4737-b479-abb3f4d33c94", new DateTime(2023, 12, 14, 15, 35, 55, 411, DateTimeKind.Local).AddTicks(9699), null, "superadmin@gmail.com", true, "SuperAdmin", "deneme", true, "SuperAdmin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAb1Fm4rAZ3X/VVff6MR+7Z2EfDU/CykMVMpW/XnICdMQ6CaYRDjn+2TW4LsrmkQZw==", "+000000000", true, "1f0b036c-b6bd-4528-9026-cd46ef723e22", false, null, "superadmin@gmail.com" },
                    { 2, 0, "b0d164bf-11e0-4da3-aaeb-0bf9161694ea", new DateTime(2023, 12, 14, 15, 35, 55, 466, DateTimeKind.Local).AddTicks(8273), null, "admin@gmail.com", true, "Admin", "deneme", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMw/HPMwMfk21ecBsmJjQ21j4KR9S/Yt4rC8zfYAba2u3MZpZLMWGWiUf6i9qygUGg==", "+000000000", false, "a70c950b-2e61-4afb-aa1a-2ad19e10e79e", false, null, "admin@gmail.com" },
                    { 3, 0, "e562d65a-5ce8-4589-a046-e69a78dd729d", new DateTime(2023, 12, 14, 15, 35, 55, 521, DateTimeKind.Local).AddTicks(4744), null, "user1@gmail.com", true, "Aras", "deneme", true, "Menteşe", false, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEDVzoX1L+7xWzKqqhT3nZ8faIu0eMdboZ6R7unmci/G0ZOc/qvN4aSBC09La8vsdbw==", "+000000000", false, "04ce1edd-1e46-4c47-87f0-9cd520f66465", false, null, "user1@gmail.com" },
                    { 4, 0, "dc32c232-a9ce-4140-a027-0c3c2a472185", new DateTime(2023, 12, 14, 15, 35, 55, 575, DateTimeKind.Local).AddTicks(2946), null, "user2@gmail.com", true, "Elif", "deneme", true, "Sakçı Tuncer", false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEKqW52A46YPSuhOVDblZ3nUTGRgXsee2WFXyPtFLpy5whi4LYmY2BCS4Nzh1+jvrjw==", "+000000000", false, "c263a49f-2ded-4ea6-aeeb-8002aa639937", false, null, "user2@gmail.com" },
                    { 5, 0, "717d20c4-3272-4861-b202-91389a63411b", new DateTime(2023, 12, 14, 15, 35, 55, 628, DateTimeKind.Local).AddTicks(7824), null, "user3@gmail.com", true, "İsmail", "deneme", true, "Yücer", false, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEL/ZZ+NNRw/YoUuf/wgyWnOcOPcEz+BBWwlPAYYjlIvb18LFxhmQUcevG90XKYTbug==", "+000000000", false, "b381c445-49ca-428f-a706-82ea7e3d46fe", false, null, "user3@gmail.com" },
                    { 6, 0, "6ccae9ac-1d4c-47fc-9f7e-a7f4fc05b5a4", new DateTime(2023, 12, 14, 15, 35, 55, 682, DateTimeKind.Local).AddTicks(4352), null, "user4@gmail.com", true, "Muratcan", "deneme", true, "Agıç", false, null, "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEG9f+k8eHO4xUnxIWYhFqfvIqZ0mZWidRkZl+qze2rDBfkCRj8g6wtkKhf6NWmbYaw==", "+000000000", false, "13a1e51f-28d0-4431-9e95-df72b642b970", false, null, "user4@gmail.com" },
                    { 7, 0, "f83d6216-24f2-40f8-ae4d-24a96fa5348c", new DateTime(2023, 12, 14, 15, 35, 55, 736, DateTimeKind.Local).AddTicks(177), null, "user5@gmail.com", true, "Rıdvan", "deneme", true, "Kesken", false, null, "USER5@GMAIL.COM", "USER5@GMAIL.COM", "AQAAAAIAAYagAAAAEAe2gJOwdpoZvTist4NxXh+5dVHsquBLN73FS/opZ70kagNaO+oDEeEva+eHevnzdg==", "+000000000", false, "a74d690d-9f91-41e5-98f6-1e67034f91d2", false, null, "user5@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconClass", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1841), null, "Elektronik araçların satıldığı kategoridir", "fa fa-laptop icon-bg-1", true, "Elektronik", null },
                    { 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1847), null, "Restoranlarınız ile ilgili reklamları burda verebilirsiniz", "fa fa-apple icon-bg-2", true, "Restoran", null },
                    { 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1848), null, "Ev,arsa,dükkan.", "fa fa-home icon-bg-3", true, "Emlak", null },
                    { 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1849), null, "7'den 70'e tüm ürünler.", "fa fa-shopping-basket icon-bg-4", true, "Alışveriş", null },
                    { 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1850), null, "Kendi mesleğine göre ilan verebilirsin.", "fa fa-briefcase icon-bg-5", true, "Meslekler", null },
                    { 6, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1851), null, "Aradığın araçlar burada", "fa fa-car icon-bg-6", true, "Araçlar", null },
                    { 7, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1851), null, "Evcil Hayvanlarınız İçin Herşey", "fa fa-paw icon-bg-7", true, "Pet Ürünleri", null },
                    { 8, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(1852), null, "Aradığınız hizmetler burada !", "fa fa-laptop icon-bg-8", true, "Hizmetler", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(3283), null, true, "Eskişehir", null },
                    { 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(3288), null, true, "İstanbul", null },
                    { 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(3289), null, true, "Ankara", null },
                    { 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(3290), null, true, "İzmir", null },
                    { 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(3291), null, true, "Adana", null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedDate", "IsActive", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Bizim Hakkımızda Herşey Burada", new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(4832), null, true, "Hakkımızda", null },
                    { 2, "Bize Ulaşın ve Soru Sorun", new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(4841), null, true, "Bize Ulaşın", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "ClickCount", "ConditionEnum", "CreatedDate", "DeletedDate", "Description", "IsActive", "Price", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8434), null, "Siyah az kullanılmıs laptop", true, 140, "Siyah Laptop", null, 3 },
                    { 2, 0, 3, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8441), null, "Beyaz laptop. İhtiyacım olduğu için satıyorum", true, 250, "Beyaz Laptop", null, 4 },
                    { 3, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8474), null, "2013 model İphone", true, 340, "Iphone Telefon", null, 5 },
                    { 4, 0, 3, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8475), null, "Android telefon en iyi telefondur", true, 240, "Android Telefon", null, 7 },
                    { 5, 0, 2, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8476), null, "Samsung Android Tablet. Sahibinden satılıktır", true, 220, "Android Tablet", null, 4 },
                    { 6, 0, 3, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8477), null, "Kardeşimin ipadini satıyoruz. Üstünde az çizik vardır", true, 180, "İPhone Tablet IPad", null, 6 },
                    { 7, 0, 2, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8478), null, "Led ekran televizyon. 20 cm e 50 cm. Az kullanılmış", true, 540, "Led Ekran", null, 6 },
                    { 8, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8479), null, "17 inch ekranımı satıyorum", true, 40, "Pc Ekranı", null, 3 },
                    { 9, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8480), null, "Ayşin kafede ev yemekleri seni çağırıyor", true, 400, "Ayşin Kafe", null, 5 },
                    { 10, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8481), null, "Kafe Paranoma, dünyaca ünlü kahve çeşitleri burada", true, 470, "Cafe Paranoma", null, 6 },
                    { 11, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8482), null, "Mcdonals seni çağırıyor", true, 200, "Mcdonalds", null, 4 },
                    { 12, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8483), null, "Tostumu yiyen başka bişey yemez", true, 120, "Tostçu Erol", null, 3 },
                    { 13, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8485), null, "Her tür yemek bulunur", true, 30, "Restoran Eskargo", null, 6 },
                    { 14, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8486), null, "Yeşim restoranda her şey var", true, 140, "Yeşim Restoran", null, 5 },
                    { 15, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8487), null, "Yemekler bizden sorulur", true, 340, "Ayşe Teyze Restoran", null, 6 },
                    { 16, 0, 0, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8488), null, "Bodrum un eşsiz yemek lezzetleri burada", true, 120, "Bodrum Ev Yemekleri", null, 7 },
                    { 17, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8489), null, "10 numara arsa!", true, 40, "20 metrekare, denize karşı ", null, 3 },
                    { 18, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8490), null, "İstediğini ek, biç.", true, 75, "30x35 arsa, sahibinden.", null, 4 },
                    { 19, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8491), null, "Kullanıma hazır spor salonu.", true, 40, "Her türlü alet mevcut", null, 6 },
                    { 20, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8492), null, "Ben olsam düşünmeden alırım.", true, 25, "3 kuşaktır işlettiğimiz spor salonu satılık.", null, 5 },
                    { 21, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8493), null, "Dahiliye dahil.", true, 100000, "Hastane satılır mı demeyin, satılır.", null, 3 },
                    { 22, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8494), null, "Çok da alet yok ama iş görür.", true, 165, "Küçük klinik, her türlü hastaya bi bakarsınız.", null, 7 },
                    { 23, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8496), null, "Hiç düşünmeden kirala dayıoğlu. ", true, 270, "İstanbulun gözde semti Bağcılarda 0+0 daire", null, 4 },
                    { 24, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8497), null, "Parası olmayan aramasın lütfen.", true, 375, "3+1 fıstık gibi aileye daire.", null, 6 },
                    { 25, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8498), null, "Yaz, kış giyilir. Sıcak tutar.", true, 85, "Siyah Atlet", null, 7 },
                    { 26, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8499), null, "Biraz rahatsız eder ama, ortamlarda en şık sen olursun!", true, 185, "Slip Don", null, 5 },
                    { 27, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8500), null, "Al ve teklif et!", true, 30, "Altın Yüzük", null, 4 },
                    { 28, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8501), null, "Çok şık, çok güzel!", true, 45, "Gümüş Bileklik", null, 3 },
                    { 29, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8504), null, "Çocuğunuzun kafası sıccacık!", true, 20, "Bere", null, 2 },
                    { 30, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8505), null, "Bebeniz kar oynasın.", true, 45, "Eldiven", null, 5 },
                    { 31, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8506), null, "Her işinizi bununla yapın.", true, 50, "SoftMicro 360", null, 3 },
                    { 32, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8507), null, "Müzik dinlemek ister misin?", true, 65, "Stopify", null, 4 },
                    { 33, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8508), null, "Lorem Ipsum is simply dummy text of the printing", true, 400, "Vergi Ödeme", null, 3 },
                    { 34, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8509), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Fatura Kesme", null, 5 },
                    { 35, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8510), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Hızlı Çözüm", null, 6 },
                    { 36, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8511), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Yedek Malzeme", null, 6 },
                    { 37, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8512), null, "Lorem Ipsum is simply dummy text of the printing", true, 200, "Matematik", null, 5 },
                    { 38, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8513), null, "Lorem Ipsum is simply dummy text of the printing", true, 300, "Türkçe", null, 3 },
                    { 39, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8514), null, "Lorem Ipsum is simply dummy text of the printing", true, 1000, "Bina", null, 7 },
                    { 40, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8515), null, "Lorem Ipsum is simply dummy text of the printing", true, 760, "Daire", null, 3 },
                    { 41, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8516), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "Büyük Otobüs", null, 3 },
                    { 42, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8518), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Küçük Otobüs", null, 5 },
                    { 43, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8519), null, "Lorem Ipsum is simply dummy text of the printing", true, 5000, "SUV", null, 7 },
                    { 44, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8520), null, "Lorem Ipsum is simply dummy text of the printing", true, 3000, "Sedan", null, 4 },
                    { 45, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8521), null, "Lorem Ipsum is simply dummy text of the printing", true, 500, "Scooter", null, 7 },
                    { 46, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8522), null, "Lorem Ipsum is simply dummy text of the printing", true, 350, "Adventure", null, 4 },
                    { 47, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8523), null, "Lorem Ipsum is simply dummy text of the printing", true, 10000, "Yelkenli", null, 7 },
                    { 48, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8524), null, "Lorem Ipsum is simply dummy text of the printing", true, 15000, "Kamaralı ", null, 4 },
                    { 49, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8525), null, "Kediniz için şık tasma", true, 100, "Kedi Tasması", null, 3 },
                    { 50, 0, 2, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8526), null, "10+2 Kilogram Kedi Kumu", true, 120, "Kedi Kumu", null, 3 },
                    { 51, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8527), null, "Köpeğiniz için şık tasma", true, 100, "Köpek Tasması", null, 3 },
                    { 52, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8528), null, "10+2 Kilogram Kuru Köpek Maması", true, 900, "Kuru Köpek Maması", null, 4 },
                    { 53, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8531), null, "1 Kilogram Kuş Yemi", true, 150, "Kuş Yemi", null, 5 },
                    { 54, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8532), null, "Suluk ve dalları olan kuş kafesi", true, 500, "Kafes", null, 5 },
                    { 55, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8529), null, "1 Kilogram Balık Maması", true, 200, "Balık Maması", null, 4 },
                    { 56, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8530), null, "Büyük boy akvaryum", true, 1500, "Akvaryum", null, 4 },
                    { 57, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8533), null, "Detaylı ev temizliği", true, 700, "Ev Temizliği", null, 5 },
                    { 58, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8534), null, "Detaylı ofis temizliği", true, 2500, "Ofis Temizliği", null, 6 },
                    { 59, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8535), null, "Detaylı İç-Dış Yıkama", true, 300, "İç-Dış Yıkama", null, 6 },
                    { 60, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8536), null, "Oto-Kuaför Servisi", true, 1200, "Oto-Kuaför", null, 6 },
                    { 61, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8537), null, "Takım elbiselerinizi 1 günde tertemiz yapıyoruz.", true, 200, "Takım Elbiseler için Kuru Temizleme", null, 7 },
                    { 62, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8538), null, "Giyecekleriniz için hızlı kuru temizleme servisi", true, 50, "Diğer Kuru Temizleme", null, 7 },
                    { 63, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8564), null, "İçine girince güzel.", true, 3500, "Tabut", null, 7 },
                    { 64, 0, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(8566), null, "Hayır duası için ...", true, 7500, "Cenaze Yemeği", null, 7 }
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
                    { 1, 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4648), null, true, "Odunpazarı", null },
                    { 2, 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4653), null, true, "Tepebaşı", null },
                    { 3, 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4655), null, true, "Beşiktaş", null },
                    { 4, 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4656), null, true, "Beyoğlu", null },
                    { 5, 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4657), null, true, "Çankaya", null },
                    { 6, 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4658), null, true, "Sincan", null },
                    { 7, 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4659), null, true, "Bayraklı", null },
                    { 8, 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4660), null, true, "Foça", null },
                    { 9, 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4660), null, true, "Çukurova", null },
                    { 10, 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(4661), null, true, "Seyhan", null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DarkMode", "DeletedDate", "IsActive", "Name", "UpdatedDate", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(6115), false, null, true, "MaxPostPerPage", null, 1, "50" },
                    { 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(6119), false, null, true, "MaxPostPerPage", null, 2, "20" },
                    { 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(6120), false, null, true, "MaxPostPerPage", null, 3, "10" },
                    { 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(6121), false, null, true, "DarkMode", null, 1, "0" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8480), null, true, "Laptop", null },
                    { 2, 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8483), null, true, "Telefon", null },
                    { 3, 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8484), null, true, "Tablet", null },
                    { 4, 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8484), null, true, "Ekran", null },
                    { 5, 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8485), null, true, "Kafe", null },
                    { 6, 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8486), null, true, "Fast Food", null },
                    { 7, 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8486), null, true, "Restoran", null },
                    { 8, 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8487), null, true, "Yöresel Yemekler", null },
                    { 9, 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8488), null, true, "Arsa", null },
                    { 10, 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8488), null, true, "Spor Salonu", null },
                    { 11, 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8489), null, true, "Hastane", null },
                    { 12, 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8490), null, true, "Ev", null },
                    { 13, 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8490), null, true, "Erkek Giysileri", null },
                    { 14, 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8491), null, true, "Aksesuarlar", null },
                    { 15, 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8492), null, true, "Çocuk Giysileri", null },
                    { 16, 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8492), null, true, "Yazılım", null },
                    { 17, 5, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8493), null, true, "Muhasebe", null },
                    { 18, 5, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8494), null, true, "Kombi Tamiri", null },
                    { 19, 5, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8494), null, true, "Özel Ders", null },
                    { 20, 5, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8495), null, true, "Boyacı", null },
                    { 21, 6, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8496), null, true, "Otobüs", null },
                    { 22, 6, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8496), null, true, "Araç", null },
                    { 23, 6, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8497), null, true, "Motorsiklet", null },
                    { 24, 6, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8498), null, true, "Yat", null },
                    { 25, 7, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8498), null, true, "Kedi Ürünleri", null },
                    { 26, 7, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8499), null, true, "Köpek Ürünleri", null },
                    { 27, 7, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8500), null, true, "Kuş Ürünleri", null },
                    { 28, 7, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8500), null, true, "Balık Ürünleri", null },
                    { 29, 8, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8501), null, true, "Temizlik", null },
                    { 30, 8, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8502), null, true, "Araba Yıkama", null },
                    { 31, 8, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8502), null, true, "Kuru Temizleme", null },
                    { 32, 8, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(8503), null, true, "Cenaze", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "Country", "CreatedDate", "DeletedDate", "DetailedAddress", "DistrictId", "IsActive", "PostCode", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Türkiye", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(3529), null, "Emin Sokak", 1, true, "341449", null, 3 },
                    { 2, 2, "Türkiye", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(3552), null, "Kerem Sokak Kus Apartmani", 3, true, "25123", null, 4 },
                    { 3, 4, "Türkiye", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(3553), null, "Reşadiye cami üstü", 7, true, "26120", null, 5 },
                    { 4, 1, "Türkiye", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(3555), null, "Akşemsettin Mahallesi", 2, true, "341449", null, 6 },
                    { 5, 3, "Türkiye", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(3556), null, "Odabaşı Cd.", 6, true, "06810", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "AdvertComments",
                columns: new[] { "Id", "AdvertId", "Comment", "CreatedDate", "DeletedDate", "IsActive", "StarCount", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Kargo hızlı geldi. Çok memnun kaldım", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6861), null, true, 5, null, 3 },
                    { 2, 3, "Ürün hiç beklediğim gibi değildi. Hiç beğenmedim", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6873), null, true, 1, null, 3 },
                    { 3, 3, "Ürün çok kötüydü. Hiç beğenmedim", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6874), null, true, 2, null, 4 },
                    { 4, 2, "Bu nasıl bir ürün, ben böyle bir şey görmemişim.", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6875), null, true, 1, null, 4 },
                    { 5, 2, "Ürün görüldüğü gibiydi.", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6876), null, true, 4, null, 7 },
                    { 6, 3, "Güzel paketlenmişti.", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6877), null, true, 4, null, 5 },
                    { 7, 6, "Fiyat performans bekledik fos çıktı !", new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(6877), null, true, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AdvertImages",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "ImagePath", "IsActive", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 14, 15, 35, 55, 407, DateTimeKind.Local).AddTicks(9988), null, "http://via.placeholder.com/610x400", true, null },
                    { 2, 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(7), null, "http://via.placeholder.com/610x400", true, null },
                    { 3, 1, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(7), null, "http://via.placeholder.com/610x400", true, null },
                    { 4, 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(8), null, "http://via.placeholder.com/610x400", true, null },
                    { 5, 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(9), null, "http://via.placeholder.com/610x400", true, null },
                    { 6, 2, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(10), null, "http://via.placeholder.com/610x400", true, null },
                    { 7, 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(11), null, "http://via.placeholder.com/610x400", true, null },
                    { 8, 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(12), null, "http://via.placeholder.com/610x400", true, null },
                    { 9, 3, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(12), null, "http://via.placeholder.com/610x400", true, null },
                    { 10, 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(13), null, "http://via.placeholder.com/610x400", true, null },
                    { 11, 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(15), null, "http://via.placeholder.com/610x400", true, null },
                    { 12, 4, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(16), null, "http://via.placeholder.com/610x400", true, null },
                    { 13, 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(16), null, "http://via.placeholder.com/610x400", true, null },
                    { 14, 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(16), null, "http://via.placeholder.com/610x400", true, null },
                    { 15, 5, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(17), null, "http://via.placeholder.com/610x400", true, null },
                    { 16, 6, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(17), null, "http://via.placeholder.com/610x400", true, null },
                    { 17, 6, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(18), null, "http://via.placeholder.com/610x400", true, null },
                    { 18, 6, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(74), null, "http://via.placeholder.com/610x400", true, null },
                    { 19, 7, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(75), null, "http://via.placeholder.com/610x400", true, null },
                    { 20, 7, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(75), null, "http://via.placeholder.com/610x400", true, null },
                    { 21, 7, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(76), null, "http://via.placeholder.com/610x400", true, null },
                    { 22, 8, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(76), null, "http://via.placeholder.com/610x400", true, null },
                    { 23, 8, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(76), null, "http://via.placeholder.com/610x400", true, null },
                    { 24, 8, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(77), null, "http://via.placeholder.com/610x400", true, null },
                    { 25, 9, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(78), null, "http://via.placeholder.com/610x400", true, null },
                    { 26, 9, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(78), null, "http://via.placeholder.com/610x400", true, null },
                    { 27, 9, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(78), null, "http://via.placeholder.com/610x400", true, null },
                    { 28, 10, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(79), null, "http://via.placeholder.com/610x400", true, null },
                    { 29, 10, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(79), null, "http://via.placeholder.com/610x400", true, null },
                    { 30, 10, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(80), null, "http://via.placeholder.com/610x400", true, null },
                    { 31, 11, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(80), null, "http://via.placeholder.com/610x400", true, null },
                    { 32, 11, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(81), null, "http://via.placeholder.com/610x400", true, null },
                    { 33, 11, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(81), null, "http://via.placeholder.com/610x400", true, null },
                    { 34, 12, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(82), null, "http://via.placeholder.com/610x400", true, null },
                    { 35, 12, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(83), null, "http://via.placeholder.com/610x400", true, null },
                    { 36, 12, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(83), null, "http://via.placeholder.com/610x400", true, null },
                    { 37, 13, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(83), null, "http://via.placeholder.com/610x400", true, null },
                    { 38, 13, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(84), null, "http://via.placeholder.com/610x400", true, null },
                    { 39, 13, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(84), null, "http://via.placeholder.com/610x400", true, null },
                    { 40, 14, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(85), null, "http://via.placeholder.com/610x400", true, null },
                    { 41, 14, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(85), null, "http://via.placeholder.com/610x400", true, null },
                    { 42, 14, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(85), null, "http://via.placeholder.com/610x400", true, null },
                    { 43, 15, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(86), null, "http://via.placeholder.com/610x400", true, null },
                    { 44, 15, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(86), null, "http://via.placeholder.com/610x400", true, null },
                    { 45, 15, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(87), null, "http://via.placeholder.com/610x400", true, null },
                    { 46, 16, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(87), null, "http://via.placeholder.com/610x400", true, null },
                    { 47, 16, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(87), null, "http://via.placeholder.com/610x400", true, null },
                    { 48, 16, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(88), null, "http://via.placeholder.com/610x400", true, null },
                    { 49, 17, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(88), null, "http://via.placeholder.com/610x400", true, null },
                    { 50, 17, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(89), null, "http://via.placeholder.com/610x400", true, null },
                    { 51, 17, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(89), null, "http://via.placeholder.com/610x400", true, null },
                    { 52, 18, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(89), null, "http://via.placeholder.com/610x400", true, null },
                    { 53, 18, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(90), null, "http://via.placeholder.com/610x400", true, null },
                    { 54, 18, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(90), null, "http://via.placeholder.com/610x400", true, null },
                    { 55, 19, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(91), null, "http://via.placeholder.com/610x400", true, null },
                    { 56, 19, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(91), null, "http://via.placeholder.com/610x400", true, null },
                    { 57, 19, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(91), null, "http://via.placeholder.com/610x400", true, null },
                    { 58, 20, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(92), null, "http://via.placeholder.com/610x400", true, null },
                    { 59, 20, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(92), null, "http://via.placeholder.com/610x400", true, null },
                    { 60, 20, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(93), null, "http://via.placeholder.com/610x400", true, null },
                    { 61, 21, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(93), null, "http://via.placeholder.com/610x400", true, null },
                    { 62, 21, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(93), null, "http://via.placeholder.com/610x400", true, null },
                    { 63, 21, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(94), null, "http://via.placeholder.com/610x400", true, null },
                    { 64, 22, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(94), null, "http://via.placeholder.com/610x400", true, null },
                    { 65, 22, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(95), null, "http://via.placeholder.com/610x400", true, null },
                    { 66, 22, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(96), null, "http://via.placeholder.com/610x400", true, null },
                    { 67, 23, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(96), null, "http://via.placeholder.com/610x400", true, null },
                    { 68, 23, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(96), null, "http://via.placeholder.com/610x400", true, null },
                    { 69, 23, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(97), null, "http://via.placeholder.com/610x400", true, null },
                    { 70, 24, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(97), null, "http://via.placeholder.com/610x400", true, null },
                    { 71, 24, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(98), null, "http://via.placeholder.com/610x400", true, null },
                    { 72, 24, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(98), null, "http://via.placeholder.com/610x400", true, null },
                    { 73, 25, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(99), null, "http://via.placeholder.com/610x400", true, null },
                    { 74, 25, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(99), null, "http://via.placeholder.com/610x400", true, null },
                    { 75, 25, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(99), null, "http://via.placeholder.com/610x400", true, null },
                    { 76, 26, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(100), null, "http://via.placeholder.com/610x400", true, null },
                    { 77, 26, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(100), null, "http://via.placeholder.com/610x400", true, null },
                    { 78, 26, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(101), null, "http://via.placeholder.com/610x400", true, null },
                    { 79, 27, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(101), null, "http://via.placeholder.com/610x400", true, null },
                    { 80, 27, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(101), null, "http://via.placeholder.com/610x400", true, null },
                    { 81, 27, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(102), null, "http://via.placeholder.com/610x400", true, null },
                    { 82, 28, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(102), null, "http://via.placeholder.com/610x400", true, null },
                    { 83, 28, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(103), null, "http://via.placeholder.com/610x400", true, null },
                    { 84, 28, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(103), null, "http://via.placeholder.com/610x400", true, null },
                    { 85, 29, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(103), null, "http://via.placeholder.com/610x400", true, null },
                    { 86, 29, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(104), null, "http://via.placeholder.com/610x400", true, null },
                    { 87, 29, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(104), null, "http://via.placeholder.com/610x400", true, null },
                    { 88, 30, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(105), null, "http://via.placeholder.com/610x400", true, null },
                    { 89, 30, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(105), null, "http://via.placeholder.com/610x400", true, null },
                    { 90, 30, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(105), null, "http://via.placeholder.com/610x400", true, null },
                    { 91, 31, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(106), null, "http://via.placeholder.com/610x400", true, null },
                    { 92, 31, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(106), null, "http://via.placeholder.com/610x400", true, null },
                    { 93, 31, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(132), null, "http://via.placeholder.com/610x400", true, null },
                    { 94, 32, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(133), null, "http://via.placeholder.com/610x400", true, null },
                    { 95, 32, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(134), null, "http://via.placeholder.com/610x400", true, null },
                    { 96, 32, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(134), null, "http://via.placeholder.com/610x400", true, null },
                    { 97, 33, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(135), null, "http://via.placeholder.com/610x400", true, null },
                    { 98, 33, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(135), null, "http://via.placeholder.com/610x400", true, null },
                    { 99, 33, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(136), null, "http://via.placeholder.com/610x400", true, null },
                    { 100, 34, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(136), null, "http://via.placeholder.com/610x400", true, null },
                    { 101, 34, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(136), null, "http://via.placeholder.com/610x400", true, null },
                    { 102, 34, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(137), null, "http://via.placeholder.com/610x400", true, null },
                    { 103, 35, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(138), null, "http://via.placeholder.com/610x400", true, null },
                    { 104, 35, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(138), null, "http://via.placeholder.com/610x400", true, null },
                    { 105, 35, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(138), null, "http://via.placeholder.com/610x400", true, null },
                    { 106, 36, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(139), null, "http://via.placeholder.com/610x400", true, null },
                    { 107, 36, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(139), null, "http://via.placeholder.com/610x400", true, null },
                    { 108, 36, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(140), null, "http://via.placeholder.com/610x400", true, null },
                    { 109, 37, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(140), null, "http://via.placeholder.com/610x400", true, null },
                    { 110, 37, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(141), null, "http://via.placeholder.com/610x400", true, null },
                    { 111, 37, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(141), null, "http://via.placeholder.com/610x400", true, null },
                    { 112, 38, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(141), null, "http://via.placeholder.com/610x400", true, null },
                    { 113, 38, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(142), null, "http://via.placeholder.com/610x400", true, null },
                    { 114, 38, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(142), null, "http://via.placeholder.com/610x400", true, null },
                    { 115, 39, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(143), null, "http://via.placeholder.com/610x400", true, null },
                    { 116, 39, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(143), null, "http://via.placeholder.com/610x400", true, null },
                    { 117, 39, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(143), null, "http://via.placeholder.com/610x400", true, null },
                    { 118, 40, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(144), null, "http://via.placeholder.com/610x400", true, null },
                    { 119, 40, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(144), null, "http://via.placeholder.com/610x400", true, null },
                    { 120, 40, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(145), null, "http://via.placeholder.com/610x400", true, null },
                    { 121, 41, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(145), null, "http://via.placeholder.com/610x400", true, null },
                    { 122, 41, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(145), null, "http://via.placeholder.com/610x400", true, null },
                    { 123, 41, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(146), null, "http://via.placeholder.com/610x400", true, null },
                    { 124, 42, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(146), null, "http://via.placeholder.com/610x400", true, null },
                    { 125, 42, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(147), null, "http://via.placeholder.com/610x400", true, null },
                    { 126, 42, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(147), null, "http://via.placeholder.com/610x400", true, null },
                    { 127, 43, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(147), null, "http://via.placeholder.com/610x400", true, null },
                    { 128, 43, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(148), null, "http://via.placeholder.com/610x400", true, null },
                    { 129, 43, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(148), null, "http://via.placeholder.com/610x400", true, null },
                    { 130, 44, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(149), null, "http://via.placeholder.com/610x400", true, null },
                    { 131, 44, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(150), null, "http://via.placeholder.com/610x400", true, null },
                    { 132, 44, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(150), null, "http://via.placeholder.com/610x400", true, null },
                    { 133, 45, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(150), null, "http://via.placeholder.com/610x400", true, null },
                    { 134, 45, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(151), null, "http://via.placeholder.com/610x400", true, null },
                    { 135, 45, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(151), null, "http://via.placeholder.com/610x400", true, null },
                    { 136, 46, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(152), null, "http://via.placeholder.com/610x400", true, null },
                    { 137, 46, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(152), null, "http://via.placeholder.com/610x400", true, null },
                    { 138, 46, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(152), null, "http://via.placeholder.com/610x400", true, null },
                    { 139, 47, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(153), null, "http://via.placeholder.com/610x400", true, null },
                    { 140, 47, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(153), null, "http://via.placeholder.com/610x400", true, null },
                    { 141, 47, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(154), null, "http://via.placeholder.com/610x400", true, null },
                    { 142, 48, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(154), null, "http://via.placeholder.com/610x400", true, null },
                    { 143, 48, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(154), null, "http://via.placeholder.com/610x400", true, null },
                    { 144, 48, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(155), null, "http://via.placeholder.com/610x400", true, null },
                    { 145, 49, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(155), null, "http://via.placeholder.com/610x400", true, null },
                    { 146, 49, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(156), null, "http://via.placeholder.com/610x400", true, null },
                    { 147, 49, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(156), null, "http://via.placeholder.com/610x400", true, null },
                    { 148, 50, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(156), null, "http://via.placeholder.com/610x400", true, null },
                    { 149, 50, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(157), null, "http://via.placeholder.com/610x400", true, null },
                    { 150, 50, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(157), null, "http://via.placeholder.com/610x400", true, null },
                    { 151, 51, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(158), null, "http://via.placeholder.com/610x400", true, null },
                    { 152, 51, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(158), null, "http://via.placeholder.com/610x400", true, null },
                    { 153, 51, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(158), null, "http://via.placeholder.com/610x400", true, null },
                    { 154, 52, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(159), null, "http://via.placeholder.com/610x400", true, null },
                    { 155, 52, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(159), null, "http://via.placeholder.com/610x400", true, null },
                    { 156, 52, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(159), null, "http://via.placeholder.com/610x400", true, null },
                    { 157, 53, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(160), null, "http://via.placeholder.com/610x400", true, null },
                    { 158, 53, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(160), null, "http://via.placeholder.com/610x400", true, null },
                    { 159, 53, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(161), null, "http://via.placeholder.com/610x400", true, null },
                    { 160, 54, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(161), null, "http://via.placeholder.com/610x400", true, null },
                    { 161, 54, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(161), null, "http://via.placeholder.com/610x400", true, null },
                    { 162, 54, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(184), null, "http://via.placeholder.com/610x400", true, null },
                    { 163, 55, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(184), null, "http://via.placeholder.com/610x400", true, null },
                    { 164, 55, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(185), null, "http://via.placeholder.com/610x400", true, null },
                    { 165, 55, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(185), null, "http://via.placeholder.com/610x400", true, null },
                    { 166, 56, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(186), null, "http://via.placeholder.com/610x400", true, null },
                    { 167, 56, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(186), null, "http://via.placeholder.com/610x400", true, null },
                    { 168, 56, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(187), null, "http://via.placeholder.com/610x400", true, null },
                    { 169, 57, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(187), null, "http://via.placeholder.com/610x400", true, null },
                    { 170, 57, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(188), null, "http://via.placeholder.com/610x400", true, null },
                    { 171, 57, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(188), null, "http://via.placeholder.com/610x400", true, null },
                    { 172, 58, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(188), null, "http://via.placeholder.com/610x400", true, null },
                    { 173, 58, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(189), null, "http://via.placeholder.com/610x400", true, null },
                    { 174, 58, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(189), null, "http://via.placeholder.com/610x400", true, null },
                    { 175, 59, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(190), null, "http://via.placeholder.com/610x400", true, null },
                    { 176, 59, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(190), null, "http://via.placeholder.com/610x400", true, null },
                    { 177, 59, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(190), null, "http://via.placeholder.com/610x400", true, null },
                    { 178, 60, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(191), null, "http://via.placeholder.com/610x400", true, null },
                    { 179, 60, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(191), null, "http://via.placeholder.com/610x400", true, null },
                    { 180, 60, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(192), null, "http://via.placeholder.com/610x400", true, null },
                    { 181, 61, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(192), null, "http://via.placeholder.com/610x400", true, null },
                    { 182, 61, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(192), null, "http://via.placeholder.com/610x400", true, null },
                    { 183, 61, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(193), null, "http://via.placeholder.com/610x400", true, null },
                    { 184, 62, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(193), null, "http://via.placeholder.com/610x400", true, null },
                    { 185, 62, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(194), null, "http://via.placeholder.com/610x400", true, null },
                    { 186, 62, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(194), null, "http://via.placeholder.com/610x400", true, null },
                    { 187, 63, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(194), null, "http://via.placeholder.com/610x400", true, null },
                    { 188, 63, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(195), null, "http://via.placeholder.com/610x400", true, null },
                    { 189, 63, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(195), null, "http://via.placeholder.com/610x400", true, null },
                    { 190, 64, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(195), null, "http://via.placeholder.com/610x400", true, null },
                    { 191, 64, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(196), null, "http://via.placeholder.com/610x400", true, null },
                    { 192, 64, new DateTime(2023, 12, 14, 15, 35, 55, 408, DateTimeKind.Local).AddTicks(196), null, "http://via.placeholder.com/610x400", true, null }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryAdverts",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "IsActive", "SubcategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7200), null, true, 1, null },
                    { 2, 2, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7202), null, true, 1, null },
                    { 3, 3, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7203), null, true, 2, null },
                    { 4, 4, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7204), null, true, 2, null },
                    { 5, 5, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7205), null, true, 3, null },
                    { 6, 6, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7205), null, true, 3, null },
                    { 7, 7, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7206), null, true, 4, null },
                    { 8, 8, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7207), null, true, 4, null },
                    { 9, 9, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7207), null, true, 5, null },
                    { 10, 10, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7208), null, true, 5, null },
                    { 11, 11, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7209), null, true, 6, null },
                    { 12, 12, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7209), null, true, 6, null },
                    { 13, 13, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7210), null, true, 7, null },
                    { 14, 14, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7211), null, true, 7, null },
                    { 15, 15, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7211), null, true, 8, null },
                    { 16, 16, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7213), null, true, 8, null },
                    { 17, 17, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7213), null, true, 9, null },
                    { 18, 18, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7214), null, true, 9, null },
                    { 19, 19, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7215), null, true, 10, null },
                    { 20, 20, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7215), null, true, 10, null },
                    { 21, 21, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7216), null, true, 11, null },
                    { 22, 22, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7217), null, true, 11, null },
                    { 23, 23, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7217), null, true, 12, null },
                    { 24, 24, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7218), null, true, 12, null },
                    { 25, 25, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7219), null, true, 13, null },
                    { 26, 26, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7219), null, true, 13, null },
                    { 27, 27, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7220), null, true, 14, null },
                    { 28, 28, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7250), null, true, 14, null },
                    { 29, 29, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7251), null, true, 15, null },
                    { 30, 30, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7251), null, true, 15, null },
                    { 31, 31, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7252), null, true, 16, null },
                    { 32, 32, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7252), null, true, 16, null },
                    { 33, 33, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7253), null, true, 17, null },
                    { 34, 34, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7254), null, true, 17, null },
                    { 35, 35, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7254), null, true, 18, null },
                    { 36, 36, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7255), null, true, 18, null },
                    { 37, 37, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7256), null, true, 19, null },
                    { 38, 38, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7256), null, true, 19, null },
                    { 39, 39, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7257), null, true, 20, null },
                    { 40, 40, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7257), null, true, 20, null },
                    { 41, 41, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7258), null, true, 21, null },
                    { 42, 42, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7259), null, true, 21, null },
                    { 43, 43, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7259), null, true, 22, null },
                    { 44, 44, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7260), null, true, 22, null },
                    { 45, 45, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7260), null, true, 23, null },
                    { 46, 46, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7261), null, true, 23, null },
                    { 47, 47, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7262), null, true, 24, null },
                    { 48, 48, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7262), null, true, 24, null },
                    { 49, 49, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7263), null, true, 25, null },
                    { 50, 50, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7263), null, true, 25, null },
                    { 51, 51, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7264), null, true, 26, null },
                    { 52, 52, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7265), null, true, 26, null },
                    { 53, 53, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7265), null, true, 27, null },
                    { 54, 54, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7266), null, true, 27, null },
                    { 55, 55, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7266), null, true, 28, null },
                    { 56, 56, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7267), null, true, 28, null },
                    { 57, 57, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7268), null, true, 29, null },
                    { 58, 58, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7268), null, true, 29, null },
                    { 59, 59, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7269), null, true, 30, null },
                    { 60, 60, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7269), null, true, 30, null },
                    { 61, 61, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7270), null, true, 31, null },
                    { 62, 62, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7271), null, true, 31, null },
                    { 63, 63, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7271), null, true, 32, null },
                    { 64, 64, new DateTime(2023, 12, 14, 15, 35, 55, 792, DateTimeKind.Local).AddTicks(7272), null, true, 32, null }
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
