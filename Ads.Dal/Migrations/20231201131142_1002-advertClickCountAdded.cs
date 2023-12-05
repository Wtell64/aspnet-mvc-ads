using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Dal.Migrations
{
    /// <inheritdoc />
    public partial class _1002advertClickCountAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClickCount",
                table: "Adverts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Afganistan", "Harman Yolu Sokak  56a, Isparta, Arnavutluk", "49781" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Amerikan Samoa", "Kerimoğlu Sokak 1, Isparta, Fiji", "35466" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Bosna Hersek", "Bahçe Sokak 94, Tokat, Virgin Adaları, İngiltere", "54322" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Güney Georgia ve Güney Sandviç Adaları, İngiltere", "Sıran Söğüt Sokak 69b, Düzce, Antigua ve Barbuda", "60190" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Kuzey Maryana Adaları", "Güven Yaka Sokak 06, Batman, Namibia", "91143" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Guatemala", "Ali Çetinkaya Caddesi 80c, Niğde, Folkland Adaları, İngiltere", "83069" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Nepal", "Tevfik Fikret Caddesi 78c, Erzincan, Kenya", "32229" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Fransız Güney Eyaletleri (Kerguelen Adaları)", "Namık Kemal Caddesi 609, Mardin, Somali", "63143" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Bulgaristan", "İsmet Paşa Caddesi 708, Kars, Kamboçya", "94005" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Letonya", "Dağınık Evler Sokak 11, Erzincan, Norveç", "84735" });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ClickCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "39f05cb9-a745-499b-b793-06340d01df4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d633ec03-3a62-4599-ac15-ea0e92f54375");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2ff9a13a-3f09-4285-83d2-e84c9dd7aeb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "286c3c02-891f-41dd-9ba1-120a960e77a4", "AQAAAAIAAYagAAAAEFs7CJQu5Kfn/GQdftdtTzEJW6otaY2O6PVUlQF7QHBXryEewRYVRAb6a8gspUtnHQ==", "64ec2f6e-c09c-40d9-9cf7-d33ec55beb8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "038ed4a8-7c58-4e80-99a0-c0f83ba56698", "AQAAAAIAAYagAAAAEI9XtI5Din+dhgIuFYqBw+gfMho4olAcas1y3J3xnicnoPlI3TcRVxMcjUhXDObwRQ==", "1256e442-b70b-41f3-96af-3e24b26ee29b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f295bf2f-9924-47b7-9d16-772abfbcfc54");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Books" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Garden" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Garden" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", "Grocery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Computers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Electronics" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Shoes" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClickCount",
                table: "Adverts");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Libya", "Menekşe Sokak 31, Amasya, Rusya Federasyonu", "43629" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Irak", "İsmet Attila Caddesi 75b, Bursa, Malavi", "66314" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Cibuti", "Afyon Kaya Sokak 55c, Ardahan, Danimarka", "85479" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Togo", "Tevfik Fikret Caddesi 329, Bilecik, Antigua ve Barbuda", "55328" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Mauritius", "Lütfi Karadirek Caddesi 11, Aksaray, Vanuatu", "38517" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Kongo", "Harman Altı Sokak 49a, Manisa, Surinam", "01196" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Kırgızistan", "Barış Sokak 6, Siirt, Santa Lucia", "43446" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Somali", "Namık Kemal Caddesi 04c, Sakarya, Japonya", "89244" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Venezuela", "Sarıkaya Caddesi 380, Adıyaman, Nijer", "41626" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Country", "DetailedAddress", "PostCode" },
                values: new object[] { "Antigua ve Barbuda", "Bahçe Sokak 3, Hakkari, Tanzanya", "57964" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a7434017-b625-44b1-a703-8a325826771d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0eace13d-9d3a-48a7-b93c-22d608b46610");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2dcfc899-d8fe-44de-8fb0-463891b6904d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fe640f8-a54c-4906-ac35-10712e50c83f", "AQAAAAIAAYagAAAAEPTCzFNnSGrZbGcA+b9HasrDXldcgqGXC2NZFhyxEIMXZT61RhEgTMgQkr/tlSz4Tw==", "187f7df2-74ab-41c9-a311-213221b5246a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "318c95b4-c687-4f71-848e-84eecfa27575", "AQAAAAIAAYagAAAAEEYMQLfFHfDuF0a2MWnPdV3zAvNE5yUZVhTfHlO8ggT79NV5zrBGUAo2rKcXpYR44Q==", "bed5e817-99d0-43ce-845f-c2824ea8706d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e21a45dd-b1a6-4798-a002-e45eb2a2b526");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Tools" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Baby" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Tools" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Tools" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Shoes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Automotive" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Games" });
        }
    }
}
