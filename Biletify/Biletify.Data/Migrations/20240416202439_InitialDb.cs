using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biletify.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentId = table.Column<string>(type: "TEXT", nullable: false),
                    ConversationId = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fdc2d79-c654-4ab3-bd10-7bce8cbb8c99", null, "Müşteri tipindeki kullanıcıların rolü", "Customer", "CUSTOMER" },
                    { "1e9dd0d9-b958-4780-a1cd-9da699a562c5", null, "Tüm yönetici yetkilere sahip kullanıcıların rolü", "Admin", "ADMIN" },
                    { "239fa00a-713a-4001-a71b-561158c164ab", null, "Sınırlı yönetici yetkilere sahip kullanıcıların rolü", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7e46ca32-d172-404c-a0d2-dfb1c3b9a6f7", 0, "Ortabayır Mahallesi Hünkar Sokak No:21 Kağıthane", "İstanbul", "1f99bdb6-77bd-4366-9e08-53ac0561218d", new DateTime(2024, 4, 16, 23, 24, 39, 223, DateTimeKind.Local).AddTicks(8413), new DateTime(1998, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "arslanyusuf8636@gmail.com", true, "Yusuf", "Erkek", "Arslan", false, null, "ARLSANYUSUF8636@GMAIL.COM", "MODERATOR", "AQAAAAIAAYagAAAAEM/pzSPuPA2DEU8H6LIqTEu3X0YcKz+W0ReztzWyvYcBTFxbTx82IeyhN0BvJz4jbw==", "538-064-20-74", false, "1e5030cf-aebc-49d6-b04e-902a81b09bef", false, "moderator" },
                    { "80c531f1-2399-4cbd-8f87-ed6feec731d2", 0, "Ortabayır Mahallesi Santral Caddesi No:21 Kağıthane", "İstanbul", "25855298-cbd2-4351-a932-16e0dce21b3e", new DateTime(2024, 4, 16, 23, 24, 39, 223, DateTimeKind.Local).AddTicks(8330), new DateTime(1998, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "aydogdumert19@gmail.com", true, "Mert", "Erkek", "Aydoğdu", false, null, "AYDOGDUMERT19@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJoN77dK5uQBbKvwjvJImrW7eQPP1Ao44JwOmYEHWx3oHMgKZx3v6TRGK6xtHCQ1yw==", "541-208-98-58", false, "7b0a0d23-e24f-4471-a6ce-79a846f630c2", false, "admin" },
                    { "928cc93a-be1f-4996-9327-bc1cfb44c686", 0, "Ortabayır Mahallesi Derviş Sokak No:1 Kağıthane", "İstanbul", "eb04a860-2432-408a-be11-b9be198f0aac", new DateTime(2024, 4, 16, 23, 24, 39, 223, DateTimeKind.Local).AddTicks(8449), new DateTime(1996, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "arslanmemo@gmail.com", true, "Mehmet", "Erkek", "Arslan", false, null, "ARSLANMEMO@GMAIL.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEB+0FuW2unOdXKDJlciz05ZFcPEd1Ccum1Mjh3cMWiuMCZgRMjhA7SJGZ7KJHonhgA==", "555-444-22-58", false, "dd96d1cd-4510-4fa5-aed5-ccd2cdd76c0f", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8270), "Spor Müsabakası Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8277), "Spor", "spor-biletleri" },
                    { 2, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8282), "Sinema Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8282), "Sinema", "sinema-biletleri" },
                    { 3, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8285), "Konser Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8285), "Müzik", "konser-biletleri" },
                    { 4, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8287), "Tiyatro Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8288), "Tiyatro ", "tiyatro-biletleri" },
                    { 5, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8290), "Festival Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8291), "Festival", "festival-biletleri" },
                    { 6, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8292), "Talk Show Biletleri", true, false, new DateTime(2024, 4, 16, 23, 24, 39, 704, DateTimeKind.Local).AddTicks(8293), "Talk Show", "talk-show-biletleri" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2455), "1.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2461), "Fenerbahçe-Galatasaray", 1000m, "Dev derbinin futbol maçı bileti", "fb-gs-bilet" },
                    { 2, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2470), "2.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2470), "Cem Yılmaz Diamond Elite Plus", 700m, "Ünlü komedyen Cem Yılmaz Stand-Up", "cem-yilmaz-bilet" },
                    { 3, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2474), "3.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2474), "Sezen Aksu Konseri (Zorlu PSM)", 350m, "Minik kuş Sezen Aksu'nun konser bileti", "sezen-aksu-bilet" },
                    { 4, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2478), "4.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2479), "Ata Demirer Gazinosu", 400m, "Ata Demirer talk show gösterisi", "ata-demirer-bilet" },
                    { 5, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2563), "5.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2564), "Konuşanlar", 550m, "Dijital dünyanın talk show gösterisi Hasan Can Kaya", "konusanlar-bilet" },
                    { 6, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2567), "6.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2568), "Mahşer-i Cümbüş Oyunu", 400m, "Türkiye’de modern doğaçlama tiyatronun öncüsü olan Mahşer-i Cümbüş, tiyatroseverler ile buluşmaya devam ediyor", "mahseri-cumbus-bilet" },
                    { 7, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2570), "7.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2571), "Duman Konseri (Kuruçeşme)", 800m, "Türkçe rock öncü grubu Duman", "duman-bilet" },
                    { 8, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2574), "8.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2574), "Beekeeper Sinema", 75m, "Ünlü aksiyon oyuncusu Jason Statham'ın son filmi", "beekeper-bilet" },
                    { 9, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2577), "9.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2578), "Fenerbahçe-Real Madrid", 450m, "Euroleague basketbol heyecanı burada", "fb-rma-bilet" },
                    { 10, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2581), "10.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2582), "Tomorrowland 2024 (Almanya)", 1800m, "Dünyanın en eğlenceli müzik festivali: Tomorrowland 2024", "tomorrowland-bilet" },
                    { 11, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2586), "11.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2587), "Örümcek Adam Eve Dönüş Yok Sinema", 75m, "Örümcek adam serisinin son filmi", "orumcek-adam-bilet" },
                    { 12, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2591), "12.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2591), "Chill-Out Festival Istanbul 2024", 600m, "“Yeryüzündeki Cennet” mottosu ile 18 yılı geride bırakan Chill-Out Festival, 19 Mayıs'ta müzikseverleri Garden Fiesta’da buluşturuyor.", "chill-out-bilet" },
                    { 13, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2594), "13.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2594), "80’ler 90’lar Gülümseten Hatıralar", 310m, "80’ler ‘90lar Gülümseten Hatıralar sizlerle…", "seksenler-doksanlar-bilet" },
                    { 14, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2597), "14.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2598), "Beşiktaş-Trabzonspor", 370m, "Kara kartal ve karadeniz fırtınası futbolda karşı karşıya.", "bjk-ts-bilet" },
                    { 15, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2600), "15.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2601), "Anadolu Efes-Galatasaray", 250m, "Basketbol Türkiye liginde kıyasıya mücadele", "efes-gs-bilet" },
                    { 16, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2604), "16.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2605), "Şampiyonlar Ligi Finali", 2000m, "Şampiyonlar ligi erken rezervasyon final bileti", "samp-ligi-bilet" },
                    { 17, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2607), "17.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2608), "Çok Güzel Hareketler 2", 500m, "Yaklaşık 2 yıl boyunca sahne, senaryo ve oyunculuk eğitimlerinden geçen ve 3 sezondur BKM’de kapalı gişe oynayan Çok Güzel Hareketler 2, Eser Yenenler kaptanlığında seyirciyle buluşmaya devam ediyor.", "cghb-2" },
                    { 18, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2610), "18.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2611), "Açık Mikrofon", 400m, "Eğlence dolu br akşam geçireceğiniz 'Açık Mikrofon Extra' stand up gösterisi sahnede!Yeni hikayeler ve kahkaha dolu anlarla dolu bu gösteri için indirimli stand up biletlerini sakın kaçırmayın...", "acik-mikrofon" },
                    { 19, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2614), "19.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2614), "LEGOLAND Discovery Centre", 220m, "Dünyaca ünlü çocuk ve aile eğlence merkezi LEGOLAND® Discovery Centre İstanbul, 2-17 yaş arasındaki çocuklar ve yetişkinler için bir arada keyifli vakit geçirip, yaratıcılıklarını geliştirecekleri eğlenceli ve öğretici etkinlikler sunuyor. ", "lego-land" },
                    { 20, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2616), "20.png", true, false, true, new DateTime(2024, 4, 16, 23, 24, 39, 707, DateTimeKind.Local).AddTicks(2617), "Samara Joy", 650m, "1999 doğumlu sanatçı müzik eğitimini 2021 yılında tamamladı. Aynı yıl kendi adını taşıyan ilk albümü ile JazzTimes tarafından ‘’En İyi Yeni Sanatçı’’ seçildi. Broadway, Inc.'in Porgy ve Bess'in (Summertime) adlı müzik videosunda Women of Color'da yer aldı. ", "samara-joy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0fdc2d79-c654-4ab3-bd10-7bce8cbb8c99", "7e46ca32-d172-404c-a0d2-dfb1c3b9a6f7" },
                    { "239fa00a-713a-4001-a71b-561158c164ab", "7e46ca32-d172-404c-a0d2-dfb1c3b9a6f7" },
                    { "1e9dd0d9-b958-4780-a1cd-9da699a562c5", "80c531f1-2399-4cbd-8f87-ed6feec731d2" },
                    { "0fdc2d79-c654-4ab3-bd10-7bce8cbb8c99", "928cc93a-be1f-4996-9327-bc1cfb44c686" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 23, 24, 39, 703, DateTimeKind.Local).AddTicks(5334), "80c531f1-2399-4cbd-8f87-ed6feec731d2" },
                    { 2, new DateTime(2024, 4, 16, 23, 24, 39, 703, DateTimeKind.Local).AddTicks(5478), "7e46ca32-d172-404c-a0d2-dfb1c3b9a6f7" },
                    { 3, new DateTime(2024, 4, 16, 23, 24, 39, 703, DateTimeKind.Local).AddTicks(5485), "928cc93a-be1f-4996-9327-bc1cfb44c686" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 2 },
                    { 3, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 4, 6 },
                    { 3, 7 },
                    { 2, 8 },
                    { 1, 9 },
                    { 3, 10 },
                    { 5, 10 },
                    { 2, 11 },
                    { 3, 12 },
                    { 5, 12 },
                    { 4, 13 },
                    { 6, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 4, 17 },
                    { 6, 18 },
                    { 4, 19 },
                    { 3, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
