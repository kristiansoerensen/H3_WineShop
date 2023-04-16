using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 12, 37, 126, DateTimeKind.Local).AddTicks(8372), new DateTime(2022, 10, 27, 22, 18, 50, 390, DateTimeKind.Local).AddTicks(7860), "Chrysler" },
                    { 2, new DateTime(2022, 8, 19, 9, 27, 43, 356, DateTimeKind.Local).AddTicks(7986), new DateTime(2022, 11, 9, 10, 9, 7, 76, DateTimeKind.Local).AddTicks(6217), "Polestar" },
                    { 3, new DateTime(2022, 5, 6, 21, 5, 38, 451, DateTimeKind.Local).AddTicks(3533), new DateTime(2023, 3, 10, 10, 14, 0, 311, DateTimeKind.Local).AddTicks(9272), "Ford" },
                    { 4, new DateTime(2023, 4, 5, 22, 28, 8, 665, DateTimeKind.Local).AddTicks(5852), new DateTime(2023, 1, 15, 20, 35, 32, 57, DateTimeKind.Local).AddTicks(8935), "Mazda" },
                    { 5, new DateTime(2022, 4, 20, 2, 58, 2, 421, DateTimeKind.Local).AddTicks(7335), new DateTime(2022, 8, 10, 9, 55, 44, 514, DateTimeKind.Local).AddTicks(7755), "Fiat" },
                    { 6, new DateTime(2023, 1, 3, 4, 37, 10, 384, DateTimeKind.Local).AddTicks(2051), new DateTime(2022, 9, 3, 18, 53, 34, 860, DateTimeKind.Local).AddTicks(535), "Mazda" },
                    { 7, new DateTime(2022, 8, 3, 5, 35, 19, 234, DateTimeKind.Local).AddTicks(9686), new DateTime(2022, 5, 4, 17, 16, 6, 89, DateTimeKind.Local).AddTicks(6841), "Mini" },
                    { 8, new DateTime(2023, 2, 16, 15, 46, 50, 182, DateTimeKind.Local).AddTicks(6642), new DateTime(2022, 11, 27, 23, 15, 39, 284, DateTimeKind.Local).AddTicks(7313), "Bentley" },
                    { 9, new DateTime(2023, 2, 13, 12, 47, 43, 50, DateTimeKind.Local).AddTicks(8912), new DateTime(2022, 6, 30, 15, 46, 58, 865, DateTimeKind.Local).AddTicks(8617), "Porsche" },
                    { 10, new DateTime(2022, 6, 19, 23, 35, 54, 614, DateTimeKind.Local).AddTicks(5737), new DateTime(2022, 5, 27, 19, 51, 15, 758, DateTimeKind.Local).AddTicks(9311), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 12, 37, 130, DateTimeKind.Local).AddTicks(3865), null, new DateTime(2022, 10, 27, 22, 18, 50, 394, DateTimeKind.Local).AddTicks(3346), "Computers" },
                    { 2, new DateTime(2022, 8, 19, 9, 27, 43, 360, DateTimeKind.Local).AddTicks(3482), null, new DateTime(2022, 11, 9, 10, 9, 7, 80, DateTimeKind.Local).AddTicks(1712), "Shoes" },
                    { 3, new DateTime(2022, 5, 6, 21, 5, 38, 454, DateTimeKind.Local).AddTicks(9030), null, new DateTime(2023, 3, 10, 10, 14, 0, 315, DateTimeKind.Local).AddTicks(4769), "Garden" },
                    { 4, new DateTime(2023, 4, 5, 22, 28, 8, 669, DateTimeKind.Local).AddTicks(1350), null, new DateTime(2023, 1, 15, 20, 35, 32, 61, DateTimeKind.Local).AddTicks(4432), "Baby" },
                    { 5, new DateTime(2022, 4, 20, 2, 58, 2, 425, DateTimeKind.Local).AddTicks(2831), null, new DateTime(2022, 8, 10, 9, 55, 44, 518, DateTimeKind.Local).AddTicks(3251), "Garden" },
                    { 6, new DateTime(2023, 1, 3, 4, 37, 10, 387, DateTimeKind.Local).AddTicks(7547), null, new DateTime(2022, 9, 3, 18, 53, 34, 863, DateTimeKind.Local).AddTicks(6031), "Baby" },
                    { 7, new DateTime(2022, 8, 3, 5, 35, 19, 238, DateTimeKind.Local).AddTicks(5182), null, new DateTime(2022, 5, 4, 17, 16, 6, 93, DateTimeKind.Local).AddTicks(2337), "Clothing" },
                    { 8, new DateTime(2023, 2, 16, 15, 46, 50, 186, DateTimeKind.Local).AddTicks(2138), null, new DateTime(2022, 11, 27, 23, 15, 39, 288, DateTimeKind.Local).AddTicks(2810), "Music" },
                    { 9, new DateTime(2023, 2, 13, 12, 47, 43, 54, DateTimeKind.Local).AddTicks(4410), null, new DateTime(2022, 6, 30, 15, 46, 58, 869, DateTimeKind.Local).AddTicks(4115), "Jewelery" },
                    { 10, new DateTime(2022, 6, 19, 23, 35, 54, 618, DateTimeKind.Local).AddTicks(1236), null, new DateTime(2022, 5, 27, 19, 51, 15, 762, DateTimeKind.Local).AddTicks(4809), "Home" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 12, 37, 119, DateTimeKind.Local).AddTicks(1564), new DateTime(2022, 10, 27, 22, 18, 50, 383, DateTimeKind.Local).AddTicks(1088), "Ecuador" },
                    { 2, new DateTime(2022, 8, 19, 9, 27, 43, 349, DateTimeKind.Local).AddTicks(1218), new DateTime(2022, 11, 9, 10, 9, 7, 68, DateTimeKind.Local).AddTicks(9451), "Samoa" },
                    { 3, new DateTime(2022, 5, 6, 21, 5, 38, 443, DateTimeKind.Local).AddTicks(6773), new DateTime(2023, 3, 10, 10, 14, 0, 304, DateTimeKind.Local).AddTicks(2512), "Guatemala" },
                    { 4, new DateTime(2023, 4, 5, 22, 28, 8, 657, DateTimeKind.Local).AddTicks(9095), new DateTime(2023, 1, 15, 20, 35, 32, 50, DateTimeKind.Local).AddTicks(2177), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 20, 2, 58, 2, 414, DateTimeKind.Local).AddTicks(578), new DateTime(2022, 8, 10, 9, 55, 44, 507, DateTimeKind.Local).AddTicks(997), "Germany" },
                    { 6, new DateTime(2023, 1, 3, 4, 37, 10, 376, DateTimeKind.Local).AddTicks(5294), new DateTime(2022, 9, 3, 18, 53, 34, 852, DateTimeKind.Local).AddTicks(3779), "Niue" },
                    { 7, new DateTime(2022, 8, 3, 5, 35, 19, 227, DateTimeKind.Local).AddTicks(2929), new DateTime(2022, 5, 4, 17, 16, 6, 82, DateTimeKind.Local).AddTicks(85), "Philippines" },
                    { 8, new DateTime(2023, 2, 16, 15, 46, 50, 174, DateTimeKind.Local).AddTicks(9887), new DateTime(2022, 11, 27, 23, 15, 39, 277, DateTimeKind.Local).AddTicks(558), "Benin" },
                    { 9, new DateTime(2023, 2, 13, 12, 47, 43, 43, DateTimeKind.Local).AddTicks(2158), new DateTime(2022, 6, 30, 15, 46, 58, 858, DateTimeKind.Local).AddTicks(1863), "Seychelles" },
                    { 10, new DateTime(2022, 6, 19, 23, 35, 54, 606, DateTimeKind.Local).AddTicks(8984), new DateTime(2022, 5, 27, 19, 51, 15, 751, DateTimeKind.Local).AddTicks(2558), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "CountryId", "CreateDate", "Mobile", "ModifiedDate", "Name", "Phone", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Okunevaview", 3, new DateTime(2022, 6, 29, 3, 18, 20, 606, DateTimeKind.Local).AddTicks(8060), "(252) 696-3466 x42351", new DateTime(2022, 12, 10, 21, 13, 5, 940, DateTimeKind.Local).AddTicks(9419), "Bernita Konopelski", "888.457.6098", "239 Lucy Burg", "62677-9013" },
                    { 2, "Boganshire", 7, new DateTime(2022, 5, 5, 12, 1, 34, 23, DateTimeKind.Local).AddTicks(6088), "(808) 228-4311 x34353", new DateTime(2023, 3, 22, 9, 29, 23, 184, DateTimeKind.Local).AddTicks(5027), "Golda Crist", "1-504-433-3068", "0353 Bo Field", "87211-4947" },
                    { 3, "Dareland", 2, new DateTime(2022, 5, 13, 9, 46, 23, 82, DateTimeKind.Local).AddTicks(8741), "352-226-6156 x3351", new DateTime(2022, 4, 18, 15, 4, 44, 382, DateTimeKind.Local).AddTicks(181), "Dexter Kessler", "(818) 969-0327 x106", "869 Wilton Ports", "61001-0220" },
                    { 4, "Prohaskaburgh", 9, new DateTime(2022, 12, 26, 8, 6, 21, 403, DateTimeKind.Local).AddTicks(3591), "248.924.7120", new DateTime(2023, 2, 21, 2, 10, 59, 58, DateTimeKind.Local).AddTicks(3820), "Andrew Hermiston", "(745) 533-8336 x82933", "837 Efrain Run", "50338-0798" },
                    { 5, "South Joycefort", 3, new DateTime(2022, 5, 27, 0, 57, 53, 914, DateTimeKind.Local).AddTicks(4213), "1-769-371-0191", new DateTime(2023, 4, 5, 10, 54, 52, 485, DateTimeKind.Local).AddTicks(7624), "Vada Corwin", "246-526-2232 x5315", "3904 Trisha Village", "68305" },
                    { 6, "Ashamouth", 7, new DateTime(2022, 11, 19, 8, 19, 45, 281, DateTimeKind.Local).AddTicks(9509), "1-726-591-1553", new DateTime(2022, 4, 20, 22, 11, 48, 569, DateTimeKind.Local).AddTicks(4709), "Jeffery Johns", "302.554.1978 x618", "1481 Betty Bypass", "61362-5302" },
                    { 7, "North Erinview", 6, new DateTime(2022, 9, 17, 6, 2, 1, 758, DateTimeKind.Local).AddTicks(9434), "565-824-6464", new DateTime(2022, 12, 8, 2, 4, 28, 597, DateTimeKind.Local).AddTicks(7138), "Jaylen Schinner", "322-546-9620", "84628 Beatty Club", "79943" },
                    { 8, "East Nelsonview", 3, new DateTime(2022, 5, 17, 16, 41, 16, 441, DateTimeKind.Local).AddTicks(9663), "442.312.9816 x66098", new DateTime(2023, 2, 19, 10, 29, 22, 91, DateTimeKind.Local).AddTicks(2188), "Eden Tromp", "(865) 389-9671", "99247 Cydney Creek", "04546" },
                    { 9, "Millsshire", 6, new DateTime(2022, 5, 30, 12, 4, 6, 807, DateTimeKind.Local).AddTicks(1391), "503.733.0063 x8679", new DateTime(2023, 2, 20, 8, 26, 24, 67, DateTimeKind.Local).AddTicks(2085), "Tracy Runolfsson", "1-477-640-5659", "2125 Ryan Lodge", "72157" },
                    { 10, "Howeborough", 5, new DateTime(2023, 2, 12, 14, 45, 30, 246, DateTimeKind.Local).AddTicks(4562), "(748) 605-1503 x77284", new DateTime(2022, 12, 12, 3, 45, 59, 514, DateTimeKind.Local).AddTicks(3459), "Ronny Sanford", "947-829-5808 x267", "2739 Delta Station", "92378" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 20, 13, 9, 46, 86, DateTimeKind.Local).AddTicks(1502), null, new DateTime(2022, 4, 20, 2, 58, 2, 428, DateTimeKind.Local).AddTicks(9862), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 6, 30, 15, 46, 58, 873, DateTimeKind.Local).AddTicks(1373), null, new DateTime(2022, 12, 25, 6, 0, 29, 352, DateTimeKind.Local).AddTicks(8268), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 6, 19, 22, 45, 5, DateTimeKind.Local).AddTicks(5046), null, new DateTime(2022, 4, 18, 15, 40, 17, 506, DateTimeKind.Local).AddTicks(195), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 23, 3, 52, 26, 403, DateTimeKind.Local).AddTicks(9219), null, new DateTime(2023, 2, 18, 17, 4, 25, 854, DateTimeKind.Local).AddTicks(1426), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 17, 3, 48, 7, 7, DateTimeKind.Local).AddTicks(239), null, new DateTime(2022, 5, 31, 17, 7, 51, 933, DateTimeKind.Local).AddTicks(1352), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 24, 11, 59, 32, 638, DateTimeKind.Local).AddTicks(233), null, new DateTime(2022, 10, 27, 0, 7, 9, 533, DateTimeKind.Local).AddTicks(9365), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 1, 18, 10, 33, 669, DateTimeKind.Local).AddTicks(2552), null, new DateTime(2022, 10, 24, 12, 52, 25, 411, DateTimeKind.Local).AddTicks(4869), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 15, 13, 4, 55, 745, DateTimeKind.Local).AddTicks(6641), null, new DateTime(2023, 2, 11, 7, 33, 9, 241, DateTimeKind.Local).AddTicks(5994), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 9, 7, 45, 46, 288, DateTimeKind.Local).AddTicks(4439), null, new DateTime(2023, 4, 8, 4, 45, 2, 180, DateTimeKind.Local).AddTicks(9740), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 18, 10, 24, 58, 181, DateTimeKind.Local).AddTicks(6050), null, new DateTime(2023, 3, 27, 14, 37, 18, 715, DateTimeKind.Local).AddTicks(6231), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 1, 10, 59, 40, 878, DateTimeKind.Local).AddTicks(1396), null, new DateTime(2022, 9, 8, 22, 57, 19, 500, DateTimeKind.Local).AddTicks(2103), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 3, 6, 17, 54, 992, DateTimeKind.Local).AddTicks(845), null, new DateTime(2022, 12, 23, 10, 29, 12, 759, DateTimeKind.Local).AddTicks(4746), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 26, 10, 45, 7, 697, DateTimeKind.Local).AddTicks(5304), null, new DateTime(2022, 5, 25, 4, 59, 7, 696, DateTimeKind.Local).AddTicks(8676), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 5, 30, 8, 32, 10, 99, DateTimeKind.Local).AddTicks(2816), null, new DateTime(2022, 12, 18, 22, 23, 19, 95, DateTimeKind.Local).AddTicks(1983), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 25, 23, 26, 42, 241, DateTimeKind.Local).AddTicks(5041), null, new DateTime(2022, 11, 6, 6, 3, 14, 651, DateTimeKind.Local).AddTicks(4706), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 15, 16, 34, 58, 639, DateTimeKind.Local).AddTicks(4620), null, new DateTime(2022, 11, 4, 23, 52, 47, 260, DateTimeKind.Local).AddTicks(9433), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 11, 19, 34, 59, 835, DateTimeKind.Local).AddTicks(6083), null, new DateTime(2022, 5, 27, 0, 57, 53, 925, DateTimeKind.Local).AddTicks(7037), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 11, 30, 13, 8, 22, 408, DateTimeKind.Local).AddTicks(170), null, new DateTime(2023, 2, 10, 15, 20, 35, 273, DateTimeKind.Local).AddTicks(999), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 5, 10, 54, 52, 497, DateTimeKind.Local).AddTicks(486), null, new DateTime(2022, 8, 11, 20, 25, 18, 963, DateTimeKind.Local).AddTicks(3602), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 19, 16, 14, 16, 59, DateTimeKind.Local).AddTicks(3827), null, new DateTime(2023, 2, 12, 12, 31, 18, 919, DateTimeKind.Local).AddTicks(6641), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 13, 12, 59, 4, 343, DateTimeKind.Local).AddTicks(8686), null, new DateTime(2022, 10, 25, 22, 22, 10, 140, DateTimeKind.Local).AddTicks(1903), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 20, 1, 44, 42, 707, DateTimeKind.Local).AddTicks(1147), null, new DateTime(2022, 10, 16, 18, 43, 19, 632, DateTimeKind.Local).AddTicks(9748), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 19, 6, 55, 28, 842, DateTimeKind.Local).AddTicks(5225), null, new DateTime(2023, 2, 27, 9, 59, 30, 715, DateTimeKind.Local).AddTicks(8088), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 22, 14, 40, 36, 849, DateTimeKind.Local).AddTicks(69), null, new DateTime(2022, 7, 12, 3, 24, 9, 111, DateTimeKind.Local).AddTicks(2226), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 4, 30, 22, 55, 17, 543, DateTimeKind.Local).AddTicks(2767), null, new DateTime(2022, 9, 6, 4, 52, 52, 529, DateTimeKind.Local).AddTicks(8713), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 17, 2, 16, 45, 883, DateTimeKind.Local).AddTicks(8752), null, new DateTime(2022, 12, 8, 2, 4, 28, 608, DateTimeKind.Local).AddTicks(9768), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 21, 6, 43, 49, 724, DateTimeKind.Local).AddTicks(7544), null, new DateTime(2022, 5, 10, 9, 33, 30, 284, DateTimeKind.Local).AddTicks(1846), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 1, 30, 6, 36, 25, 179, DateTimeKind.Local).AddTicks(4736), null, new DateTime(2022, 8, 7, 12, 18, 33, 957, DateTimeKind.Local).AddTicks(9755), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 22, 21, 44, 1, 865, DateTimeKind.Local).AddTicks(7814), null, new DateTime(2023, 1, 6, 7, 6, 39, 305, DateTimeKind.Local).AddTicks(3469), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 10, 14, 23, 2, 893, DateTimeKind.Local).AddTicks(1754), null, new DateTime(2022, 7, 4, 11, 30, 23, 484, DateTimeKind.Local).AddTicks(9474), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 6, 15, 28, 58, 783, DateTimeKind.Local).AddTicks(9359), null, new DateTime(2023, 1, 12, 20, 47, 27, 119, DateTimeKind.Local).AddTicks(6541), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 19, 10, 19, 33, 828, DateTimeKind.Local).AddTicks(7912), null, new DateTime(2022, 10, 2, 5, 26, 30, 234, DateTimeKind.Local).AddTicks(4374), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 25, 4, 10, 7, 108, DateTimeKind.Local).AddTicks(5445), null, new DateTime(2022, 8, 5, 6, 6, 7, 997, DateTimeKind.Local).AddTicks(6879), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 15, 5, 17, 42, 6, DateTimeKind.Local).AddTicks(9755), null, new DateTime(2022, 6, 24, 10, 9, 51, 536, DateTimeKind.Local).AddTicks(9281), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 19, 22, 17, 31, 16, DateTimeKind.Local).AddTicks(7780), null, new DateTime(2022, 6, 18, 15, 48, 7, 894, DateTimeKind.Local).AddTicks(6471), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 4, 14, 5, 39, 531, DateTimeKind.Local).AddTicks(5381), null, new DateTime(2022, 9, 17, 7, 47, 55, 100, DateTimeKind.Local).AddTicks(1259), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 7, 12, 43, 27, 646, DateTimeKind.Local).AddTicks(8049), null, new DateTime(2022, 12, 12, 3, 45, 59, 525, DateTimeKind.Local).AddTicks(5883), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 20, 5, 0, 19, 505, DateTimeKind.Local).AddTicks(6279), null, new DateTime(2022, 11, 24, 7, 27, 49, 289, DateTimeKind.Local).AddTicks(4955), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 23, 12, 39, 0, 157, DateTimeKind.Local).AddTicks(7857), null, new DateTime(2023, 3, 29, 21, 29, 58, 641, DateTimeKind.Local).AddTicks(2854), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 4, 4, 21, 17, 399, DateTimeKind.Local).AddTicks(1746), null, new DateTime(2022, 6, 27, 20, 48, 56, 366, DateTimeKind.Local).AddTicks(5740), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 21, 3, 54, 36, 54, DateTimeKind.Local).AddTicks(1730), null, new DateTime(2023, 2, 20, 13, 38, 16, 90, DateTimeKind.Local).AddTicks(692), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 12, 13, 25, 22, 750, DateTimeKind.Local).AddTicks(8358), null, new DateTime(2022, 10, 25, 11, 42, 22, 114, DateTimeKind.Local).AddTicks(1503), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 8, 19, 20, 59, 400, DateTimeKind.Local).AddTicks(7198), null, new DateTime(2022, 6, 10, 13, 36, 31, 921, DateTimeKind.Local).AddTicks(599), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 4, 4, 58, 52, 996, DateTimeKind.Local).AddTicks(8176), null, new DateTime(2022, 10, 31, 17, 53, 18, 930, DateTimeKind.Local).AddTicks(6036), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 21, 22, 41, 54, 90, DateTimeKind.Local).AddTicks(7711), null, new DateTime(2023, 1, 12, 9, 51, 30, 538, DateTimeKind.Local).AddTicks(1699), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 17, 8, 49, 42, 510, DateTimeKind.Local).AddTicks(2867), null, new DateTime(2022, 8, 14, 16, 57, 8, 93, DateTimeKind.Local).AddTicks(5742), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 20, 23, 1, 40, 155, DateTimeKind.Local).AddTicks(9692), null, new DateTime(2022, 12, 1, 14, 45, 33, 802, DateTimeKind.Local).AddTicks(7451), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 12, 18, 23, 51, 468, DateTimeKind.Local).AddTicks(5871), null, new DateTime(2022, 12, 30, 23, 56, 24, 701, DateTimeKind.Local).AddTicks(8299), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 28, 14, 16, 47, 887, DateTimeKind.Local).AddTicks(697), null, new DateTime(2023, 4, 5, 13, 3, 44, 258, DateTimeKind.Local).AddTicks(1395), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 25, 16, 40, 57, 817, DateTimeKind.Local).AddTicks(4289), null, new DateTime(2023, 2, 7, 8, 27, 51, 28, DateTimeKind.Local).AddTicks(267), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 13, 12, 35, 5, 475, DateTimeKind.Local).AddTicks(7989), null, new DateTime(2022, 6, 19, 15, 58, 5, 565, DateTimeKind.Local).AddTicks(7242), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 26, 16, 43, 0, 595, DateTimeKind.Local).AddTicks(868), null, new DateTime(2022, 10, 29, 23, 58, 51, 980, DateTimeKind.Local).AddTicks(8329), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 29, 10, 37, 27, 969, DateTimeKind.Local).AddTicks(7682), null, new DateTime(2023, 2, 11, 20, 8, 10, 525, DateTimeKind.Local).AddTicks(8336), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 11, 17, 52, 58, 129, DateTimeKind.Local).AddTicks(4507), null, new DateTime(2022, 8, 18, 15, 36, 0, 420, DateTimeKind.Local).AddTicks(476), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 7, 3, 48, 28, 52, DateTimeKind.Local).AddTicks(5897), null, new DateTime(2022, 5, 13, 11, 26, 50, 106, DateTimeKind.Local).AddTicks(8099), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 5, 31, 6, 43, 32, 607, DateTimeKind.Local).AddTicks(3299), null, new DateTime(2023, 3, 8, 19, 44, 46, 586, DateTimeKind.Local).AddTicks(3782), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 3, 18, 2, 47, 457, DateTimeKind.Local).AddTicks(5102), null, new DateTime(2023, 1, 21, 11, 6, 31, 570, DateTimeKind.Local).AddTicks(365), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 23, 19, 4, 5, 831, DateTimeKind.Local).AddTicks(1276), null, new DateTime(2022, 12, 2, 22, 35, 42, 314, DateTimeKind.Local).AddTicks(7923), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 3, 30, 19, 41, 32, 251, DateTimeKind.Local).AddTicks(1355), null, new DateTime(2022, 8, 3, 22, 9, 12, 914, DateTimeKind.Local).AddTicks(3246), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 15, 11, 46, 58, 464, DateTimeKind.Local).AddTicks(3111), null, new DateTime(2023, 1, 19, 21, 13, 41, 995, DateTimeKind.Local).AddTicks(382), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 29, 15, 10, 3, 19, DateTimeKind.Local).AddTicks(1532), null, new DateTime(2022, 6, 2, 3, 42, 26, 728, DateTimeKind.Local).AddTicks(8946), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 3, 9, 7, 42, 272, DateTimeKind.Local).AddTicks(7836), null, new DateTime(2022, 12, 31, 16, 36, 37, 557, DateTimeKind.Local).AddTicks(4767), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 12, 1, 0, 54, 936, DateTimeKind.Local).AddTicks(8096), null, new DateTime(2023, 1, 11, 15, 3, 5, 204, DateTimeKind.Local).AddTicks(4164), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 16, 11, 18, 41, 113, DateTimeKind.Local).AddTicks(8154), null, new DateTime(2023, 1, 10, 11, 37, 35, 655, DateTimeKind.Local).AddTicks(6005), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 26, 0, 17, 49, 268, DateTimeKind.Local).AddTicks(8875), null, new DateTime(2022, 11, 27, 5, 28, 3, 879, DateTimeKind.Local).AddTicks(9798), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 24, 22, 55, 3, 609, DateTimeKind.Local).AddTicks(1212), null, new DateTime(2022, 8, 21, 3, 48, 39, 843, DateTimeKind.Local).AddTicks(5724), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 6, 3, 48, 36, 396, DateTimeKind.Local).AddTicks(396), null, new DateTime(2023, 2, 1, 15, 29, 19, 818, DateTimeKind.Local).AddTicks(6275), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 11, 29, 9, 57, 58, 782, DateTimeKind.Local).AddTicks(9460), null, new DateTime(2022, 6, 7, 2, 58, 52, 441, DateTimeKind.Local).AddTicks(3576), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 12, 20, 36, 48, 415, DateTimeKind.Local).AddTicks(3885), null, new DateTime(2022, 7, 28, 15, 56, 43, 919, DateTimeKind.Local).AddTicks(6055), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 24, 22, 40, 56, 230, DateTimeKind.Local).AddTicks(6431), null, new DateTime(2022, 11, 29, 21, 2, 10, 634, DateTimeKind.Local).AddTicks(146), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 10, 10, 19, 57, 548, DateTimeKind.Local).AddTicks(2168), null, new DateTime(2023, 4, 11, 4, 24, 33, 897, DateTimeKind.Local).AddTicks(6639), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 17, 12, 46, 7, 996, DateTimeKind.Local).AddTicks(6108), null, new DateTime(2023, 3, 26, 5, 44, 53, 802, DateTimeKind.Local).AddTicks(42), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 3, 14, 12, 21, 307, DateTimeKind.Local).AddTicks(9259), null, new DateTime(2023, 2, 3, 22, 15, 12, 952, DateTimeKind.Local).AddTicks(3652), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 1, 17, 48, 28, 525, DateTimeKind.Local).AddTicks(1897), null, new DateTime(2022, 11, 4, 17, 43, 3, 796, DateTimeKind.Local).AddTicks(1930), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 28, 14, 27, 0, 264, DateTimeKind.Local).AddTicks(7453), null, new DateTime(2022, 6, 25, 10, 12, 59, 626, DateTimeKind.Local).AddTicks(1817), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 12, 1, 18, 41, 662, DateTimeKind.Local).AddTicks(1352), null, new DateTime(2022, 7, 1, 10, 42, 54, 540, DateTimeKind.Local).AddTicks(5312), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 15, 17, 8, 4, 74, DateTimeKind.Local).AddTicks(6690), null, new DateTime(2022, 7, 17, 22, 47, 31, 650, DateTimeKind.Local).AddTicks(622), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 19, 6, 55, 51, 874, DateTimeKind.Local).AddTicks(5781), null, new DateTime(2022, 11, 14, 18, 3, 23, 357, DateTimeKind.Local).AddTicks(8991), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 8, 17, 1, 9, 658, DateTimeKind.Local).AddTicks(5803), null, new DateTime(2022, 7, 3, 17, 32, 2, 413, DateTimeKind.Local).AddTicks(2878), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 14, 5, 44, 16, 496, DateTimeKind.Local).AddTicks(6776), null, new DateTime(2023, 1, 20, 18, 7, 42, 265, DateTimeKind.Local).AddTicks(6177), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 24, 11, 12, 0, 728, DateTimeKind.Local).AddTicks(7963), null, new DateTime(2023, 1, 1, 9, 9, 57, 233, DateTimeKind.Local).AddTicks(3323), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 13, 12, 17, 18, 647, DateTimeKind.Local).AddTicks(9259), null, new DateTime(2022, 8, 14, 11, 24, 57, 718, DateTimeKind.Local).AddTicks(6730), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 25, 18, 59, 4, 625, DateTimeKind.Local).AddTicks(4578), null, new DateTime(2022, 7, 17, 18, 43, 34, 634, DateTimeKind.Local).AddTicks(7267), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 2, 3, 1, 10, 64, DateTimeKind.Local).AddTicks(842), null, new DateTime(2022, 9, 5, 8, 15, 35, 574, DateTimeKind.Local).AddTicks(7613), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 16, 11, 56, 12, 137, DateTimeKind.Local).AddTicks(8989), null, new DateTime(2022, 6, 9, 21, 8, 31, 191, DateTimeKind.Local).AddTicks(1180), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 13, 7, 45, 21, 437, DateTimeKind.Local).AddTicks(5170), null, new DateTime(2022, 7, 7, 12, 27, 31, 815, DateTimeKind.Local).AddTicks(6599), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 10, 21, 11, 8, 127, DateTimeKind.Local).AddTicks(4719), null, new DateTime(2023, 2, 7, 6, 23, 39, 194, DateTimeKind.Local).AddTicks(5867), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 10, 3, 4, 21, 997, DateTimeKind.Local).AddTicks(8449), null, new DateTime(2023, 3, 24, 1, 42, 17, 329, DateTimeKind.Local).AddTicks(8051), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 27, 18, 15, 38, 648, DateTimeKind.Local).AddTicks(2786), null, new DateTime(2023, 3, 4, 8, 36, 31, 452, DateTimeKind.Local).AddTicks(9073), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 1, 23, 25, 0, 242, DateTimeKind.Local).AddTicks(3), null, new DateTime(2022, 11, 7, 0, 7, 14, 435, DateTimeKind.Local).AddTicks(5385), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 20, 3, 37, 6, 890, DateTimeKind.Local).AddTicks(1648), null, new DateTime(2022, 10, 9, 0, 8, 19, 378, DateTimeKind.Local).AddTicks(7891), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 7, 22, 11, 40, 165, DateTimeKind.Local).AddTicks(6986), null, new DateTime(2023, 2, 10, 5, 28, 43, 440, DateTimeKind.Local).AddTicks(5740), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 2, 19, 19, 19, 562, DateTimeKind.Local).AddTicks(3217), null, new DateTime(2022, 6, 24, 22, 19, 30, 975, DateTimeKind.Local).AddTicks(5422), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 19, 17, 8, 59, 200, DateTimeKind.Local).AddTicks(7577), null, new DateTime(2023, 3, 13, 19, 37, 32, 462, DateTimeKind.Local).AddTicks(8167), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 22, 10, 1, 12, 3, DateTimeKind.Local).AddTicks(3384), null, new DateTime(2022, 11, 7, 18, 12, 15, 44, DateTimeKind.Local).AddTicks(8712), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 9, 6, 13, 31, 169, DateTimeKind.Local).AddTicks(6488), null, new DateTime(2022, 5, 12, 12, 34, 15, 980, DateTimeKind.Local).AddTicks(3692), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 21, 1, 43, 15, 637, DateTimeKind.Local).AddTicks(3625), null, new DateTime(2022, 12, 12, 8, 34, 35, 308, DateTimeKind.Local).AddTicks(973), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 11, 15, 31, 12, 28, DateTimeKind.Local).AddTicks(2529), null, new DateTime(2022, 9, 1, 5, 18, 36, 39, DateTimeKind.Local).AddTicks(5117), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 2, 0, 54, 16, 802, DateTimeKind.Local).AddTicks(9444), null, new DateTime(2022, 6, 15, 18, 38, 4, 542, DateTimeKind.Local).AddTicks(241), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 13, 0, 14, 38, 460, DateTimeKind.Local).AddTicks(1052), null, new DateTime(2022, 5, 11, 13, 4, 43, 38, DateTimeKind.Local).AddTicks(7608), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "ContactId", "CreateDate", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 3, 6, 23, 12, 37, 138, DateTimeKind.Local).AddTicks(242), new DateTime(2022, 10, 27, 22, 18, 50, 401, DateTimeKind.Local).AddTicks(9664) },
                    { 2, 8, new DateTime(2022, 8, 19, 9, 27, 43, 367, DateTimeKind.Local).AddTicks(9732), new DateTime(2022, 11, 9, 10, 9, 7, 87, DateTimeKind.Local).AddTicks(7963) },
                    { 3, 4, new DateTime(2022, 5, 6, 21, 5, 38, 462, DateTimeKind.Local).AddTicks(5275), new DateTime(2023, 3, 10, 10, 14, 0, 323, DateTimeKind.Local).AddTicks(1014) },
                    { 4, 7, new DateTime(2023, 4, 5, 22, 28, 8, 676, DateTimeKind.Local).AddTicks(7590), new DateTime(2023, 1, 15, 20, 35, 32, 69, DateTimeKind.Local).AddTicks(673) },
                    { 5, 4, new DateTime(2022, 4, 20, 2, 58, 2, 432, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 8, 10, 9, 55, 44, 525, DateTimeKind.Local).AddTicks(9489) },
                    { 6, 7, new DateTime(2023, 1, 3, 4, 37, 10, 395, DateTimeKind.Local).AddTicks(3783), new DateTime(2022, 9, 3, 18, 53, 34, 871, DateTimeKind.Local).AddTicks(2267) },
                    { 7, 8, new DateTime(2022, 8, 3, 5, 35, 19, 246, DateTimeKind.Local).AddTicks(1414), new DateTime(2022, 5, 4, 17, 16, 6, 100, DateTimeKind.Local).AddTicks(8570) },
                    { 8, 1, new DateTime(2023, 2, 16, 15, 46, 50, 193, DateTimeKind.Local).AddTicks(8368), new DateTime(2022, 11, 27, 23, 15, 39, 295, DateTimeKind.Local).AddTicks(9039) },
                    { 9, 8, new DateTime(2023, 2, 13, 12, 47, 43, 62, DateTimeKind.Local).AddTicks(635), new DateTime(2022, 6, 30, 15, 46, 58, 877, DateTimeKind.Local).AddTicks(340) },
                    { 10, 4, new DateTime(2022, 6, 19, 23, 35, 54, 625, DateTimeKind.Local).AddTicks(7456), new DateTime(2022, 5, 27, 19, 51, 15, 770, DateTimeKind.Local).AddTicks(1030) },
                    { 11, 6, new DateTime(2022, 7, 28, 18, 44, 15, 547, DateTimeKind.Local).AddTicks(1281), new DateTime(2022, 8, 4, 3, 29, 45, 839, DateTimeKind.Local).AddTicks(1266) },
                    { 12, 1, new DateTime(2022, 4, 19, 8, 29, 34, 624, DateTimeKind.Local).AddTicks(4443), new DateTime(2022, 6, 26, 2, 7, 31, 791, DateTimeKind.Local).AddTicks(3757) },
                    { 13, 9, new DateTime(2023, 3, 24, 13, 47, 54, 349, DateTimeKind.Local).AddTicks(9452), new DateTime(2022, 10, 10, 15, 14, 17, 788, DateTimeKind.Local).AddTicks(5396) },
                    { 14, 6, new DateTime(2023, 1, 6, 19, 22, 45, 9, DateTimeKind.Local).AddTicks(3996), new DateTime(2022, 4, 18, 15, 40, 17, 509, DateTimeKind.Local).AddTicks(9144) },
                    { 15, 7, new DateTime(2022, 11, 26, 6, 34, 33, 292, DateTimeKind.Local).AddTicks(6561), new DateTime(2022, 11, 8, 20, 33, 44, 459, DateTimeKind.Local).AddTicks(5645) },
                    { 16, 7, new DateTime(2022, 8, 12, 3, 27, 50, 741, DateTimeKind.Local).AddTicks(3451), new DateTime(2022, 10, 25, 18, 56, 43, 211, DateTimeKind.Local).AddTicks(4353) },
                    { 17, 3, new DateTime(2022, 12, 8, 8, 48, 24, 290, DateTimeKind.Local).AddTicks(3808), new DateTime(2022, 10, 6, 7, 21, 15, 750, DateTimeKind.Local).AddTicks(4827) },
                    { 18, 2, new DateTime(2022, 12, 10, 21, 13, 5, 956, DateTimeKind.Local).AddTicks(1541), new DateTime(2022, 8, 6, 22, 4, 46, 801, DateTimeKind.Local).AddTicks(6180) },
                    { 19, 4, new DateTime(2023, 2, 18, 17, 4, 25, 858, DateTimeKind.Local).AddTicks(372), new DateTime(2022, 5, 4, 16, 45, 26, 146, DateTimeKind.Local).AddTicks(6570) },
                    { 20, 1, new DateTime(2022, 4, 26, 0, 5, 50, 190, DateTimeKind.Local).AddTicks(7516), new DateTime(2022, 10, 20, 5, 59, 39, 508, DateTimeKind.Local).AddTicks(3628) },
                    { 21, 7, new DateTime(2023, 3, 30, 6, 52, 23, 479, DateTimeKind.Local).AddTicks(2542), new DateTime(2023, 3, 3, 6, 49, 23, 39, DateTimeKind.Local).AddTicks(2354) },
                    { 22, 3, new DateTime(2023, 3, 15, 22, 37, 30, 641, DateTimeKind.Local).AddTicks(211), new DateTime(2022, 12, 23, 13, 3, 32, 332, DateTimeKind.Local).AddTicks(854) },
                    { 23, 6, new DateTime(2022, 12, 25, 12, 25, 29, 891, DateTimeKind.Local).AddTicks(2767), new DateTime(2022, 4, 17, 3, 48, 7, 10, DateTimeKind.Local).AddTicks(9182) },
                    { 24, 9, new DateTime(2022, 6, 29, 19, 6, 12, 938, DateTimeKind.Local).AddTicks(257), new DateTime(2023, 1, 26, 0, 8, 55, 247, DateTimeKind.Local).AddTicks(8896) },
                    { 25, 2, new DateTime(2023, 2, 10, 1, 20, 46, 767, DateTimeKind.Local).AddTicks(8579), new DateTime(2022, 11, 10, 19, 32, 13, 439, DateTimeKind.Local).AddTicks(1994) },
                    { 26, 10, new DateTime(2022, 11, 20, 13, 19, 9, 310, DateTimeKind.Local).AddTicks(9544), new DateTime(2022, 7, 7, 18, 31, 56, 103, DateTimeKind.Local).AddTicks(6394) },
                    { 27, 10, new DateTime(2023, 3, 2, 15, 51, 29, 419, DateTimeKind.Local).AddTicks(5407), new DateTime(2022, 10, 18, 18, 39, 31, 523, DateTimeKind.Local).AddTicks(1782) },
                    { 28, 4, new DateTime(2023, 3, 24, 11, 59, 32, 641, DateTimeKind.Local).AddTicks(9126), new DateTime(2022, 10, 27, 0, 7, 9, 537, DateTimeKind.Local).AddTicks(8255) },
                    { 29, 4, new DateTime(2022, 11, 26, 4, 18, 8, 290, DateTimeKind.Local).AddTicks(9959), new DateTime(2022, 12, 2, 6, 50, 48, 793, DateTimeKind.Local).AddTicks(4357) },
                    { 30, 1, new DateTime(2022, 9, 2, 15, 31, 8, 195, DateTimeKind.Local).AddTicks(9117), new DateTime(2022, 6, 15, 0, 44, 47, 968, DateTimeKind.Local).AddTicks(8699) },
                    { 31, 9, new DateTime(2022, 7, 7, 23, 40, 49, 955, DateTimeKind.Local).AddTicks(6490), new DateTime(2023, 3, 14, 23, 1, 43, 361, DateTimeKind.Local).AddTicks(6573) },
                    { 32, 1, new DateTime(2022, 5, 27, 21, 41, 47, 0, DateTimeKind.Local).AddTicks(7071), new DateTime(2023, 1, 23, 21, 50, 0, 732, DateTimeKind.Local).AddTicks(6103) },
                    { 33, 9, new DateTime(2022, 10, 24, 12, 52, 25, 415, DateTimeKind.Local).AddTicks(3757), new DateTime(2022, 12, 27, 17, 16, 41, 854, DateTimeKind.Local).AddTicks(1008) },
                    { 34, 2, new DateTime(2023, 3, 1, 3, 40, 44, 175, DateTimeKind.Local).AddTicks(290), new DateTime(2022, 12, 2, 0, 22, 0, 52, DateTimeKind.Local).AddTicks(5353) },
                    { 35, 5, new DateTime(2022, 12, 2, 19, 32, 23, 182, DateTimeKind.Local).AddTicks(7094), new DateTime(2022, 9, 24, 23, 1, 50, 554, DateTimeKind.Local).AddTicks(8232) },
                    { 36, 4, new DateTime(2023, 3, 22, 9, 29, 23, 199, DateTimeKind.Local).AddTicks(6962), new DateTime(2023, 2, 14, 5, 11, 58, 390, DateTimeKind.Local).AddTicks(7651) },
                    { 37, 3, new DateTime(2022, 11, 7, 2, 16, 37, 816, DateTimeKind.Local).AddTicks(8856), new DateTime(2022, 7, 15, 13, 4, 55, 749, DateTimeKind.Local).AddTicks(5528) },
                    { 38, 2, new DateTime(2023, 2, 25, 5, 40, 55, 472, DateTimeKind.Local).AddTicks(1926), new DateTime(2022, 6, 9, 17, 33, 59, 973, DateTimeKind.Local).AddTicks(6899) },
                    { 39, 10, new DateTime(2022, 12, 21, 6, 51, 31, 747, DateTimeKind.Local).AddTicks(6369), new DateTime(2022, 4, 22, 4, 12, 30, 39, DateTimeKind.Local).AddTicks(8221) },
                    { 40, 7, new DateTime(2022, 6, 8, 11, 12, 23, 735, DateTimeKind.Local).AddTicks(8521), new DateTime(2022, 8, 4, 3, 39, 1, 552, DateTimeKind.Local).AddTicks(5066) },
                    { 41, 10, new DateTime(2022, 9, 30, 21, 0, 26, 394, DateTimeKind.Local).AddTicks(9069), new DateTime(2022, 8, 8, 6, 14, 0, 897, DateTimeKind.Local).AddTicks(8474) },
                    { 42, 2, new DateTime(2023, 4, 9, 7, 45, 46, 292, DateTimeKind.Local).AddTicks(3303), new DateTime(2023, 4, 8, 4, 45, 2, 184, DateTimeKind.Local).AddTicks(8601) },
                    { 43, 2, new DateTime(2023, 3, 20, 3, 44, 18, 4, DateTimeKind.Local).AddTicks(9875), new DateTime(2022, 12, 30, 12, 58, 38, 969, DateTimeKind.Local).AddTicks(6353) },
                    { 44, 3, new DateTime(2023, 3, 17, 2, 4, 33, 322, DateTimeKind.Local).AddTicks(7416), new DateTime(2022, 5, 13, 9, 46, 23, 98, DateTimeKind.Local).AddTicks(641) },
                    { 45, 5, new DateTime(2022, 6, 19, 4, 31, 21, 911, DateTimeKind.Local).AddTicks(3394), new DateTime(2022, 4, 17, 21, 30, 24, 446, DateTimeKind.Local).AddTicks(9981) },
                    { 46, 2, new DateTime(2022, 6, 11, 15, 1, 18, 667, DateTimeKind.Local).AddTicks(5614), new DateTime(2022, 8, 6, 1, 46, 48, 661, DateTimeKind.Local).AddTicks(6906) },
                    { 47, 10, new DateTime(2023, 3, 27, 14, 37, 18, 719, DateTimeKind.Local).AddTicks(5082), new DateTime(2022, 12, 21, 4, 8, 24, 293, DateTimeKind.Local).AddTicks(7882) },
                    { 48, 3, new DateTime(2022, 7, 18, 12, 12, 4, 877, DateTimeKind.Local).AddTicks(5720), new DateTime(2023, 2, 9, 22, 34, 9, 581, DateTimeKind.Local).AddTicks(5155) },
                    { 49, 1, new DateTime(2022, 8, 10, 20, 28, 14, 804, DateTimeKind.Local).AddTicks(1840), new DateTime(2022, 8, 27, 3, 19, 33, 685, DateTimeKind.Local).AddTicks(9469) },
                    { 50, 3, new DateTime(2023, 4, 5, 7, 14, 9, 497, DateTimeKind.Local).AddTicks(4759), new DateTime(2022, 9, 21, 0, 9, 54, 455, DateTimeKind.Local).AddTicks(5700) },
                    { 51, 3, new DateTime(2023, 1, 25, 11, 28, 20, 171, DateTimeKind.Local).AddTicks(7541), new DateTime(2022, 9, 1, 10, 59, 40, 882, DateTimeKind.Local).AddTicks(246) },
                    { 52, 7, new DateTime(2023, 2, 9, 10, 37, 7, 791, DateTimeKind.Local).AddTicks(3152), new DateTime(2022, 9, 14, 15, 59, 56, 982, DateTimeKind.Local).AddTicks(6239) },
                    { 53, 7, new DateTime(2022, 12, 22, 21, 24, 56, 360, DateTimeKind.Local).AddTicks(9558), new DateTime(2022, 12, 9, 21, 6, 16, 92, DateTimeKind.Local).AddTicks(8819) },
                    { 54, 6, new DateTime(2023, 2, 11, 15, 24, 47, 818, DateTimeKind.Local).AddTicks(8486), new DateTime(2022, 4, 18, 15, 4, 44, 397, DateTimeKind.Local).AddTicks(2124) },
                    { 55, 9, new DateTime(2023, 3, 25, 14, 9, 59, 858, DateTimeKind.Local).AddTicks(3182), new DateTime(2022, 12, 7, 9, 31, 43, 696, DateTimeKind.Local).AddTicks(6487) },
                    { 56, 9, new DateTime(2022, 8, 3, 6, 17, 54, 995, DateTimeKind.Local).AddTicks(9688), new DateTime(2022, 12, 23, 10, 29, 12, 763, DateTimeKind.Local).AddTicks(3588) },
                    { 57, 9, new DateTime(2022, 6, 1, 2, 22, 15, 717, DateTimeKind.Local).AddTicks(329), new DateTime(2022, 10, 26, 1, 9, 52, 282, DateTimeKind.Local).AddTicks(5737) },
                    { 58, 3, new DateTime(2022, 7, 20, 14, 56, 33, 720, DateTimeKind.Local).AddTicks(8993), new DateTime(2022, 6, 28, 5, 54, 44, 218, DateTimeKind.Local).AddTicks(8431) },
                    { 59, 4, new DateTime(2022, 7, 20, 13, 53, 32, 338, DateTimeKind.Local).AddTicks(4719), new DateTime(2022, 6, 29, 18, 8, 0, 719, DateTimeKind.Local).AddTicks(8350) },
                    { 60, 6, new DateTime(2023, 3, 19, 0, 43, 6, 25, DateTimeKind.Local).AddTicks(2248), new DateTime(2022, 12, 13, 20, 37, 10, 690, DateTimeKind.Local).AddTicks(6473) },
                    { 61, 4, new DateTime(2022, 5, 25, 4, 59, 7, 700, DateTimeKind.Local).AddTicks(7518), new DateTime(2023, 3, 31, 5, 49, 47, 710, DateTimeKind.Local).AddTicks(137) },
                    { 62, 8, new DateTime(2022, 4, 30, 13, 24, 21, 216, DateTimeKind.Local).AddTicks(2885), new DateTime(2022, 6, 5, 23, 55, 52, 353, DateTimeKind.Local).AddTicks(4906) },
                    { 63, 4, new DateTime(2022, 6, 1, 20, 57, 13, 150, DateTimeKind.Local).AddTicks(4329), new DateTime(2022, 8, 24, 3, 13, 53, 322, DateTimeKind.Local).AddTicks(5283) },
                    { 64, 5, new DateTime(2022, 11, 7, 9, 29, 11, 518, DateTimeKind.Local).AddTicks(4443), new DateTime(2022, 10, 4, 2, 56, 1, 509, DateTimeKind.Local).AddTicks(1108) },
                    { 65, 4, new DateTime(2022, 11, 29, 16, 8, 9, 815, DateTimeKind.Local).AddTicks(5300), new DateTime(2022, 5, 30, 8, 32, 10, 103, DateTimeKind.Local).AddTicks(1657) },
                    { 66, 4, new DateTime(2022, 12, 17, 18, 45, 10, 184, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 8, 9, 7, 21, 44, 221, DateTimeKind.Local).AddTicks(7610) },
                    { 67, 9, new DateTime(2023, 1, 12, 17, 40, 58, 770, DateTimeKind.Local).AddTicks(3212), new DateTime(2022, 4, 23, 23, 29, 59, 10, DateTimeKind.Local).AddTicks(7234) },
                    { 68, 4, new DateTime(2022, 11, 27, 18, 43, 47, 63, DateTimeKind.Local).AddTicks(7853), new DateTime(2023, 2, 18, 14, 11, 32, 982, DateTimeKind.Local).AddTicks(9522) },
                    { 69, 1, new DateTime(2022, 5, 4, 0, 31, 28, 517, DateTimeKind.Local).AddTicks(1682), new DateTime(2022, 10, 22, 5, 51, 25, 653, DateTimeKind.Local).AddTicks(3650) },
                    { 70, 9, new DateTime(2023, 1, 25, 23, 26, 42, 245, DateTimeKind.Local).AddTicks(3882), new DateTime(2022, 11, 6, 6, 3, 14, 655, DateTimeKind.Local).AddTicks(3545) },
                    { 71, 8, new DateTime(2023, 2, 11, 19, 47, 47, 40, DateTimeKind.Local).AddTicks(8697), new DateTime(2023, 1, 20, 6, 1, 29, 538, DateTimeKind.Local).AddTicks(2431) },
                    { 72, 1, new DateTime(2023, 2, 21, 2, 10, 59, 73, DateTimeKind.Local).AddTicks(5642), new DateTime(2023, 1, 3, 19, 45, 19, 320, DateTimeKind.Local).AddTicks(6100) },
                    { 73, 10, new DateTime(2023, 2, 20, 12, 44, 14, 109, DateTimeKind.Local).AddTicks(5799), new DateTime(2023, 3, 11, 10, 5, 17, 844, DateTimeKind.Local).AddTicks(5438) },
                    { 74, 5, new DateTime(2022, 10, 7, 13, 51, 29, 637, DateTimeKind.Local).AddTicks(9655), new DateTime(2022, 6, 17, 18, 40, 21, 48, DateTimeKind.Local).AddTicks(512) },
                    { 75, 7, new DateTime(2022, 11, 4, 23, 52, 47, 264, DateTimeKind.Local).AddTicks(8271), new DateTime(2022, 11, 8, 2, 12, 43, 401, DateTimeKind.Local).AddTicks(1048) },
                    { 76, 10, new DateTime(2022, 5, 6, 7, 4, 48, 11, DateTimeKind.Local).AddTicks(8327), new DateTime(2022, 12, 5, 8, 8, 3, 107, DateTimeKind.Local).AddTicks(8865) },
                    { 77, 10, new DateTime(2023, 3, 26, 19, 46, 36, 564, DateTimeKind.Local).AddTicks(6536), new DateTime(2022, 11, 17, 4, 28, 1, 356, DateTimeKind.Local).AddTicks(9576) },
                    { 78, 2, new DateTime(2022, 8, 9, 3, 57, 4, 633, DateTimeKind.Local).AddTicks(9767), new DateTime(2022, 6, 20, 16, 21, 46, 457, DateTimeKind.Local).AddTicks(4228) },
                    { 79, 4, new DateTime(2023, 3, 24, 17, 54, 46, 778, DateTimeKind.Local).AddTicks(8379), new DateTime(2022, 10, 11, 19, 34, 59, 839, DateTimeKind.Local).AddTicks(4869) },
                    { 80, 9, new DateTime(2022, 8, 29, 23, 8, 21, 543, DateTimeKind.Local).AddTicks(5828), new DateTime(2023, 4, 12, 22, 12, 31, 901, DateTimeKind.Local).AddTicks(6415) },
                    { 81, 4, new DateTime(2022, 10, 22, 3, 1, 24, 755, DateTimeKind.Local).AddTicks(3729), new DateTime(2022, 8, 21, 6, 50, 10, 107, DateTimeKind.Local).AddTicks(5671) },
                    { 82, 3, new DateTime(2022, 9, 1, 16, 58, 10, 404, DateTimeKind.Local).AddTicks(1011), new DateTime(2023, 1, 9, 23, 1, 3, 680, DateTimeKind.Local).AddTicks(980) },
                    { 83, 3, new DateTime(2022, 12, 15, 13, 31, 6, 369, DateTimeKind.Local).AddTicks(912), new DateTime(2023, 1, 22, 23, 16, 49, 944, DateTimeKind.Local).AddTicks(4901) },
                    { 84, 6, new DateTime(2022, 11, 30, 13, 8, 22, 411, DateTimeKind.Local).AddTicks(8951), new DateTime(2023, 2, 10, 15, 20, 35, 276, DateTimeKind.Local).AddTicks(9778) },
                    { 85, 6, new DateTime(2022, 12, 17, 12, 46, 13, 744, DateTimeKind.Local).AddTicks(2279), new DateTime(2022, 7, 22, 13, 9, 8, 334, DateTimeKind.Local).AddTicks(8821) },
                    { 86, 2, new DateTime(2022, 8, 19, 18, 54, 40, 684, DateTimeKind.Local).AddTicks(2776), new DateTime(2022, 5, 9, 4, 10, 39, 1, DateTimeKind.Local).AddTicks(4855) },
                    { 87, 8, new DateTime(2023, 2, 18, 10, 5, 50, 602, DateTimeKind.Local).AddTicks(544), new DateTime(2023, 4, 14, 2, 46, 19, 707, DateTimeKind.Local).AddTicks(8638) },
                    { 88, 2, new DateTime(2022, 5, 22, 17, 2, 1, 750, DateTimeKind.Local).AddTicks(260), new DateTime(2023, 2, 15, 12, 59, 44, 883, DateTimeKind.Local).AddTicks(2639) },
                    { 89, 1, new DateTime(2022, 8, 11, 20, 25, 18, 967, DateTimeKind.Local).AddTicks(2379), new DateTime(2022, 10, 20, 1, 10, 21, 609, DateTimeKind.Local).AddTicks(4232) },
                    { 90, 5, new DateTime(2022, 8, 21, 12, 41, 32, 924, DateTimeKind.Local).AddTicks(8345), new DateTime(2023, 3, 15, 17, 35, 51, 497, DateTimeKind.Local).AddTicks(2577) },
                    { 91, 8, new DateTime(2023, 3, 25, 2, 56, 21, 162, DateTimeKind.Local).AddTicks(6622), new DateTime(2022, 10, 7, 22, 55, 31, 768, DateTimeKind.Local).AddTicks(5295) },
                    { 92, 1, new DateTime(2023, 3, 5, 0, 51, 3, 845, DateTimeKind.Local).AddTicks(5631), new DateTime(2023, 4, 1, 20, 9, 44, 85, DateTimeKind.Local).AddTicks(1309) },
                    { 93, 2, new DateTime(2022, 10, 28, 19, 24, 19, 976, DateTimeKind.Local).AddTicks(1885), new DateTime(2022, 6, 19, 16, 14, 16, 63, DateTimeKind.Local).AddTicks(2653) },
                    { 94, 2, new DateTime(2022, 8, 24, 10, 38, 58, 5, DateTimeKind.Local).AddTicks(1280), new DateTime(2022, 9, 5, 2, 53, 20, 845, DateTimeKind.Local).AddTicks(2819) },
                    { 95, 2, new DateTime(2022, 12, 19, 17, 55, 22, 535, DateTimeKind.Local).AddTicks(6556), new DateTime(2022, 8, 10, 15, 57, 53, 355, DateTimeKind.Local).AddTicks(3000) },
                    { 96, 3, new DateTime(2022, 10, 6, 22, 49, 29, 323, DateTimeKind.Local).AddTicks(3917), new DateTime(2022, 12, 7, 0, 30, 30, 92, DateTimeKind.Local).AddTicks(2912) },
                    { 97, 1, new DateTime(2023, 1, 30, 1, 37, 12, 919, DateTimeKind.Local).AddTicks(7876), new DateTime(2022, 11, 19, 8, 19, 45, 297, DateTimeKind.Local).AddTicks(1036) },
                    { 98, 6, new DateTime(2023, 2, 13, 12, 59, 4, 347, DateTimeKind.Local).AddTicks(7511), new DateTime(2022, 10, 25, 22, 22, 10, 144, DateTimeKind.Local).AddTicks(726) },
                    { 99, 1, new DateTime(2023, 1, 12, 5, 40, 43, 357, DateTimeKind.Local).AddTicks(1851), new DateTime(2022, 9, 15, 19, 19, 2, 207, DateTimeKind.Local).AddTicks(8922) },
                    { 100, 5, new DateTime(2023, 2, 12, 4, 55, 4, 571, DateTimeKind.Local).AddTicks(3160), new DateTime(2022, 5, 7, 5, 52, 30, 639, DateTimeKind.Local).AddTicks(4096) },
                    { 101, 8, new DateTime(2022, 5, 29, 16, 34, 28, 92, DateTimeKind.Local).AddTicks(5876), new DateTime(2022, 8, 10, 10, 9, 12, 646, DateTimeKind.Local).AddTicks(8038) },
                    { 102, 2, new DateTime(2022, 6, 17, 21, 56, 10, 503, DateTimeKind.Local).AddTicks(9735), new DateTime(2022, 12, 22, 19, 31, 40, 451, DateTimeKind.Local).AddTicks(7812) },
                    { 103, 7, new DateTime(2022, 10, 16, 18, 43, 19, 636, DateTimeKind.Local).AddTicks(8569), new DateTime(2023, 1, 28, 21, 14, 49, 101, DateTimeKind.Local).AddTicks(2189) },
                    { 104, 7, new DateTime(2022, 4, 26, 2, 19, 6, 224, DateTimeKind.Local).AddTicks(7312), new DateTime(2023, 2, 5, 8, 49, 59, 910, DateTimeKind.Local).AddTicks(6445) },
                    { 105, 2, new DateTime(2022, 9, 28, 18, 6, 49, 63, DateTimeKind.Local).AddTicks(3846), new DateTime(2022, 10, 11, 8, 46, 31, 799, DateTimeKind.Local).AddTicks(4829) },
                    { 106, 4, new DateTime(2022, 4, 20, 22, 11, 48, 584, DateTimeKind.Local).AddTicks(6271), new DateTime(2022, 9, 17, 8, 26, 18, 416, DateTimeKind.Local).AddTicks(9279) },
                    { 107, 5, new DateTime(2022, 6, 29, 21, 47, 26, 420, DateTimeKind.Local).AddTicks(9631), new DateTime(2023, 2, 19, 6, 55, 28, 846, DateTimeKind.Local).AddTicks(4046) },
                    { 108, 2, new DateTime(2022, 12, 17, 19, 46, 44, 160, DateTimeKind.Local).AddTicks(8265), new DateTime(2022, 11, 5, 20, 23, 59, 207, DateTimeKind.Local).AddTicks(6064) },
                    { 109, 7, new DateTime(2023, 2, 3, 18, 5, 37, 845, DateTimeKind.Local).AddTicks(6699), new DateTime(2022, 5, 25, 23, 16, 56, 17, DateTimeKind.Local).AddTicks(4715) },
                    { 110, 1, new DateTime(2023, 3, 16, 1, 46, 12, 951, DateTimeKind.Local).AddTicks(6737), new DateTime(2022, 6, 7, 4, 29, 59, 690, DateTimeKind.Local).AddTicks(9346) },
                    { 111, 5, new DateTime(2022, 8, 8, 3, 19, 24, 918, DateTimeKind.Local).AddTicks(7310), new DateTime(2022, 12, 30, 23, 48, 54, 607, DateTimeKind.Local).AddTicks(4301) },
                    { 112, 9, new DateTime(2022, 11, 22, 14, 40, 36, 852, DateTimeKind.Local).AddTicks(8833), new DateTime(2022, 7, 12, 3, 24, 9, 115, DateTimeKind.Local).AddTicks(989) },
                    { 113, 10, new DateTime(2022, 4, 19, 12, 29, 53, 918, DateTimeKind.Local).AddTicks(7163), new DateTime(2022, 10, 18, 5, 18, 51, 234, DateTimeKind.Local).AddTicks(2416) },
                    { 114, 4, new DateTime(2022, 9, 17, 6, 2, 1, 774, DateTimeKind.Local).AddTicks(849), new DateTime(2023, 4, 6, 13, 25, 48, 889, DateTimeKind.Local).AddTicks(956) },
                    { 115, 2, new DateTime(2022, 11, 23, 19, 32, 53, 75, DateTimeKind.Local).AddTicks(3391), new DateTime(2023, 1, 20, 8, 37, 45, 897, DateTimeKind.Local).AddTicks(6181) },
                    { 116, 3, new DateTime(2022, 10, 30, 12, 47, 37, 102, DateTimeKind.Local).AddTicks(3364), new DateTime(2022, 9, 1, 4, 11, 54, 486, DateTimeKind.Local).AddTicks(9340) },
                    { 117, 10, new DateTime(2022, 9, 6, 4, 52, 52, 533, DateTimeKind.Local).AddTicks(7522), new DateTime(2023, 1, 7, 16, 48, 33, 975, DateTimeKind.Local).AddTicks(1267) },
                    { 118, 1, new DateTime(2023, 4, 14, 6, 8, 12, 898, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 11, 29, 16, 27, 17, 352, DateTimeKind.Local).AddTicks(9226) },
                    { 119, 8, new DateTime(2022, 8, 24, 6, 30, 29, 756, DateTimeKind.Local).AddTicks(1008), new DateTime(2022, 9, 26, 6, 7, 23, 134, DateTimeKind.Local).AddTicks(3318) },
                    { 120, 3, new DateTime(2022, 10, 30, 5, 44, 31, 449, DateTimeKind.Local).AddTicks(6375), new DateTime(2022, 8, 28, 13, 10, 11, 860, DateTimeKind.Local).AddTicks(8753) },
                    { 121, 5, new DateTime(2022, 9, 7, 1, 11, 21, 86, DateTimeKind.Local).AddTicks(5517), new DateTime(2022, 11, 17, 2, 16, 45, 887, DateTimeKind.Local).AddTicks(7559) },
                    { 122, 4, new DateTime(2023, 1, 20, 1, 28, 21, 575, DateTimeKind.Local).AddTicks(835), new DateTime(2023, 1, 2, 8, 19, 20, 508, DateTimeKind.Local).AddTicks(5739) },
                    { 123, 10, new DateTime(2023, 1, 21, 10, 54, 16, 716, DateTimeKind.Local).AddTicks(9367), new DateTime(2023, 2, 20, 12, 45, 51, 413, DateTimeKind.Local).AddTicks(760) },
                    { 124, 8, new DateTime(2022, 10, 28, 16, 28, 29, 866, DateTimeKind.Local).AddTicks(6771), new DateTime(2022, 4, 17, 19, 1, 33, 868, DateTimeKind.Local).AddTicks(4865) },
                    { 125, 1, new DateTime(2023, 3, 5, 9, 55, 17, 827, DateTimeKind.Local).AddTicks(193), new DateTime(2023, 1, 27, 1, 5, 3, 849, DateTimeKind.Local).AddTicks(4548) },
                    { 126, 2, new DateTime(2022, 4, 21, 6, 43, 49, 728, DateTimeKind.Local).AddTicks(6350), new DateTime(2022, 5, 10, 9, 33, 30, 288, DateTimeKind.Local).AddTicks(650) },
                    { 127, 3, new DateTime(2022, 10, 27, 19, 6, 0, 16, DateTimeKind.Local).AddTicks(2712), new DateTime(2022, 7, 21, 14, 37, 39, 945, DateTimeKind.Local).AddTicks(9171) },
                    { 128, 3, new DateTime(2023, 3, 14, 20, 17, 22, 482, DateTimeKind.Local).AddTicks(4443), new DateTime(2022, 10, 24, 6, 12, 59, 620, DateTimeKind.Local).AddTicks(5061) },
                    { 129, 6, new DateTime(2022, 11, 1, 23, 17, 37, 288, DateTimeKind.Local).AddTicks(8475), new DateTime(2022, 8, 10, 6, 30, 51, 222, DateTimeKind.Local).AddTicks(4199) },
                    { 130, 10, new DateTime(2023, 3, 13, 20, 44, 22, 833, DateTimeKind.Local).AddTicks(4248), new DateTime(2022, 7, 15, 17, 29, 46, 299, DateTimeKind.Local).AddTicks(3690) },
                    { 131, 3, new DateTime(2022, 8, 7, 12, 18, 33, 961, DateTimeKind.Local).AddTicks(8557), new DateTime(2022, 10, 4, 16, 5, 1, 671, DateTimeKind.Local).AddTicks(6662) },
                    { 132, 9, new DateTime(2022, 5, 6, 9, 31, 7, 671, DateTimeKind.Local).AddTicks(7852), new DateTime(2022, 4, 26, 14, 10, 19, 890, DateTimeKind.Local).AddTicks(1217) },
                    { 133, 7, new DateTime(2022, 7, 1, 19, 50, 30, 783, DateTimeKind.Local).AddTicks(3650), new DateTime(2023, 2, 18, 3, 24, 10, 702, DateTimeKind.Local).AddTicks(8450) },
                    { 134, 10, new DateTime(2022, 12, 22, 23, 48, 19, 285, DateTimeKind.Local).AddTicks(8227), new DateTime(2023, 1, 23, 11, 12, 59, 587, DateTimeKind.Local).AddTicks(9852) },
                    { 135, 5, new DateTime(2023, 1, 29, 17, 32, 54, 862, DateTimeKind.Local).AddTicks(7847), new DateTime(2023, 2, 22, 21, 44, 1, 869, DateTimeKind.Local).AddTicks(6616) },
                    { 136, 3, new DateTime(2022, 5, 15, 17, 4, 55, 810, DateTimeKind.Local).AddTicks(8581), new DateTime(2022, 5, 26, 5, 32, 34, 274, DateTimeKind.Local).AddTicks(4647) },
                    { 137, 2, new DateTime(2022, 8, 17, 14, 47, 1, 38, DateTimeKind.Local).AddTicks(2768), new DateTime(2022, 8, 19, 9, 6, 19, 230, DateTimeKind.Local).AddTicks(543) },
                    { 138, 7, new DateTime(2023, 4, 4, 11, 18, 39, 331, DateTimeKind.Local).AddTicks(7910), new DateTime(2022, 4, 18, 19, 58, 10, 635, DateTimeKind.Local).AddTicks(9558) },
                    { 139, 9, new DateTime(2023, 2, 19, 10, 29, 22, 106, DateTimeKind.Local).AddTicks(3502), new DateTime(2022, 10, 9, 14, 13, 37, 806, DateTimeKind.Local).AddTicks(6976) },
                    { 140, 10, new DateTime(2022, 7, 10, 14, 23, 2, 897, DateTimeKind.Local).AddTicks(554), new DateTime(2022, 7, 4, 11, 30, 23, 488, DateTimeKind.Local).AddTicks(8272) },
                    { 141, 7, new DateTime(2022, 4, 21, 10, 59, 7, 251, DateTimeKind.Local).AddTicks(2871), new DateTime(2023, 2, 23, 23, 29, 33, 86, DateTimeKind.Local).AddTicks(1042) },
                    { 142, 4, new DateTime(2022, 9, 30, 17, 25, 15, 906, DateTimeKind.Local).AddTicks(1981), new DateTime(2022, 7, 7, 13, 29, 35, 107, DateTimeKind.Local).AddTicks(4144) },
                    { 143, 5, new DateTime(2023, 1, 24, 20, 18, 27, 11, DateTimeKind.Local).AddTicks(9020), new DateTime(2023, 2, 13, 9, 43, 49, 357, DateTimeKind.Local).AddTicks(8283) },
                    { 144, 3, new DateTime(2022, 10, 11, 15, 40, 16, 158, DateTimeKind.Local).AddTicks(5528), new DateTime(2023, 2, 3, 20, 12, 58, 147, DateTimeKind.Local).AddTicks(8651) },
                    { 145, 8, new DateTime(2023, 1, 12, 20, 47, 27, 123, DateTimeKind.Local).AddTicks(5285), new DateTime(2023, 2, 19, 4, 37, 19, 933, DateTimeKind.Local).AddTicks(448) },
                    { 146, 6, new DateTime(2022, 6, 29, 12, 58, 37, 659, DateTimeKind.Local).AddTicks(2791), new DateTime(2022, 5, 30, 12, 4, 6, 822, DateTimeKind.Local).AddTicks(2617) },
                    { 147, 4, new DateTime(2022, 12, 22, 23, 14, 4, 811, DateTimeKind.Local).AddTicks(7688), new DateTime(2022, 10, 3, 15, 32, 20, 680, DateTimeKind.Local).AddTicks(5926) },
                    { 148, 8, new DateTime(2022, 7, 15, 1, 19, 2, 953, DateTimeKind.Local).AddTicks(6418), new DateTime(2022, 11, 10, 15, 17, 0, 997, DateTimeKind.Local).AddTicks(7522) },
                    { 149, 1, new DateTime(2022, 9, 13, 10, 2, 32, 337, DateTimeKind.Local).AddTicks(1034), new DateTime(2022, 8, 19, 10, 19, 33, 832, DateTimeKind.Local).AddTicks(6699) },
                    { 150, 6, new DateTime(2022, 4, 29, 2, 55, 46, 661, DateTimeKind.Local).AddTicks(122), new DateTime(2022, 7, 1, 8, 21, 24, 768, DateTimeKind.Local).AddTicks(413) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 14, 59, 26, 739, DateTimeKind.Local).AddTicks(9568), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 145, DateTimeKind.Local).AddTicks(5686), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 15, 14, 59, 26, 743, DateTimeKind.Local).AddTicks(4181), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 149, DateTimeKind.Local).AddTicks(292), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 15, 14, 59, 26, 746, DateTimeKind.Local).AddTicks(3281), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 151, DateTimeKind.Local).AddTicks(9398), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 15, 14, 59, 26, 749, DateTimeKind.Local).AddTicks(5676), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 155, DateTimeKind.Local).AddTicks(1838), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 15, 14, 59, 26, 753, DateTimeKind.Local).AddTicks(1771), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 158, DateTimeKind.Local).AddTicks(7882), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 15, 14, 59, 26, 756, DateTimeKind.Local).AddTicks(6441), "Metal_Chicken.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 162, DateTimeKind.Local).AddTicks(2546), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 15, 14, 59, 26, 759, DateTimeKind.Local).AddTicks(8320), "Metal_Shoes.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 165, DateTimeKind.Local).AddTicks(4424), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 15, 14, 59, 26, 763, DateTimeKind.Local).AddTicks(789), "Metal_Shoes2.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 168, DateTimeKind.Local).AddTicks(6889), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 15, 14, 59, 26, 766, DateTimeKind.Local).AddTicks(4054), "Steel_Computer.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 172, DateTimeKind.Local).AddTicks(153), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 15, 14, 59, 26, 769, DateTimeKind.Local).AddTicks(7150), "Cotton_Cheese.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 175, DateTimeKind.Local).AddTicks(3329), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 15, 14, 59, 26, 773, DateTimeKind.Local).AddTicks(21), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 178, DateTimeKind.Local).AddTicks(6136), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 15, 14, 59, 26, 776, DateTimeKind.Local).AddTicks(2255), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 181, DateTimeKind.Local).AddTicks(8350), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 15, 14, 59, 26, 779, DateTimeKind.Local).AddTicks(4739), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 6, 23, 12, 37, 185, DateTimeKind.Local).AddTicks(843), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 1, 2 },
                    { 7, 3 },
                    { 4, 4 },
                    { 8, 5 },
                    { 9, 6 },
                    { 9, 7 },
                    { 5, 8 },
                    { 2, 9 },
                    { 8, 10 },
                    { 7, 11 },
                    { 7, 12 },
                    { 5, 13 },
                    { 6, 14 },
                    { 4, 15 },
                    { 3, 16 },
                    { 9, 17 },
                    { 6, 18 },
                    { 1, 19 },
                    { 4, 20 },
                    { 8, 21 },
                    { 6, 22 },
                    { 8, 23 },
                    { 3, 24 },
                    { 8, 25 },
                    { 5, 26 },
                    { 9, 27 },
                    { 5, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 5, 31 },
                    { 4, 32 },
                    { 9, 33 },
                    { 4, 34 },
                    { 2, 35 },
                    { 6, 36 },
                    { 4, 37 },
                    { 6, 38 },
                    { 1, 39 },
                    { 4, 40 },
                    { 4, 41 },
                    { 9, 42 },
                    { 5, 43 },
                    { 9, 44 },
                    { 7, 45 },
                    { 6, 46 },
                    { 1, 47 },
                    { 8, 48 },
                    { 8, 49 },
                    { 8, 50 },
                    { 5, 51 },
                    { 6, 52 },
                    { 8, 53 },
                    { 7, 54 },
                    { 4, 55 },
                    { 7, 56 },
                    { 3, 57 },
                    { 2, 58 },
                    { 2, 59 },
                    { 2, 60 },
                    { 2, 61 },
                    { 9, 62 },
                    { 5, 63 },
                    { 7, 64 },
                    { 9, 65 },
                    { 9, 66 },
                    { 6, 67 },
                    { 5, 68 },
                    { 7, 69 },
                    { 7, 70 },
                    { 7, 71 },
                    { 1, 72 },
                    { 8, 73 },
                    { 7, 74 },
                    { 2, 75 },
                    { 5, 76 },
                    { 5, 77 },
                    { 7, 78 },
                    { 2, 79 },
                    { 1, 80 },
                    { 5, 81 },
                    { 1, 82 },
                    { 2, 83 },
                    { 6, 84 },
                    { 3, 85 },
                    { 4, 86 },
                    { 6, 87 },
                    { 4, 88 },
                    { 9, 89 },
                    { 2, 90 },
                    { 6, 91 },
                    { 3, 92 },
                    { 1, 93 },
                    { 6, 94 },
                    { 5, 95 },
                    { 1, 96 },
                    { 1, 97 },
                    { 9, 98 },
                    { 7, 99 },
                    { 6, 100 }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 27, 22, 18, 50, 405, DateTimeKind.Local).AddTicks(3650), new DateTime(2022, 7, 8, 18, 4, 31, 613, DateTimeKind.Local).AddTicks(7499), 25, 1.26161413752505m },
                    { 2, 65, new DateTime(2022, 12, 8, 3, 33, 13, 636, DateTimeKind.Local).AddTicks(9451), new DateTime(2022, 5, 6, 21, 5, 38, 465, DateTimeKind.Local).AddTicks(9489), 66, 2.85910900243169m },
                    { 3, 97, new DateTime(2023, 4, 5, 22, 28, 8, 680, DateTimeKind.Local).AddTicks(1808), new DateTime(2023, 1, 15, 20, 35, 32, 72, DateTimeKind.Local).AddTicks(4891), 11, 17.4624099854027m },
                    { 4, 149, new DateTime(2022, 8, 10, 9, 55, 44, 529, DateTimeKind.Local).AddTicks(3723), new DateTime(2022, 8, 20, 8, 30, 34, 800, DateTimeKind.Local).AddTicks(6986), 33, 11.0761671589884m },
                    { 5, 93, new DateTime(2022, 8, 2, 8, 5, 2, 780, DateTimeKind.Local).AddTicks(2826), new DateTime(2022, 8, 3, 5, 35, 19, 249, DateTimeKind.Local).AddTicks(5651), 29, 21.0737148506677m },
                    { 6, 15, new DateTime(2023, 2, 16, 15, 46, 50, 197, DateTimeKind.Local).AddTicks(2607), new DateTime(2022, 11, 27, 23, 15, 39, 299, DateTimeKind.Local).AddTicks(3279), 95, 21.1722487395797m },
                    { 7, 26, new DateTime(2022, 6, 30, 15, 46, 58, 880, DateTimeKind.Local).AddTicks(4583), new DateTime(2022, 12, 25, 6, 0, 29, 360, DateTimeKind.Local).AddTicks(1472), 80, 7.91514763481676m },
                    { 8, 133, new DateTime(2022, 9, 25, 8, 7, 9, 374, DateTimeKind.Local).AddTicks(3306), new DateTime(2022, 7, 28, 18, 44, 15, 550, DateTimeKind.Local).AddTicks(5525), 83, 13.7081948960488m },
                    { 9, 3, new DateTime(2022, 4, 19, 8, 29, 34, 627, DateTimeKind.Local).AddTicks(8688), new DateTime(2022, 6, 26, 2, 7, 31, 794, DateTimeKind.Local).AddTicks(8003), 70, 29.9459485963626m },
                    { 10, 10, new DateTime(2022, 10, 10, 15, 14, 17, 791, DateTimeKind.Local).AddTicks(9642), new DateTime(2022, 10, 6, 16, 3, 55, 214, DateTimeKind.Local).AddTicks(8828), 86, 13.7844844814748m },
                    { 11, 150, new DateTime(2022, 8, 7, 3, 15, 9, 971, DateTimeKind.Local).AddTicks(7872), new DateTime(2022, 11, 26, 6, 34, 33, 296, DateTimeKind.Local).AddTicks(807), 28, 19.9270704808005m },
                    { 12, 102, new DateTime(2022, 8, 12, 3, 27, 50, 744, DateTimeKind.Local).AddTicks(7699), new DateTime(2022, 10, 25, 18, 56, 43, 214, DateTimeKind.Local).AddTicks(8600), 44, 10.0330966801045m },
                    { 13, 54, new DateTime(2022, 10, 6, 7, 21, 15, 753, DateTimeKind.Local).AddTicks(9077), new DateTime(2023, 2, 13, 13, 8, 40, 285, DateTimeKind.Local).AddTicks(7965), 25, 13.211468405738m },
                    { 14, 104, new DateTime(2022, 11, 23, 3, 52, 26, 411, DateTimeKind.Local).AddTicks(2415), new DateTime(2023, 2, 18, 17, 4, 25, 861, DateTimeKind.Local).AddTicks(4622), 35, 24.4223951530811m },
                    { 15, 13, new DateTime(2022, 4, 26, 0, 5, 50, 194, DateTimeKind.Local).AddTicks(1766), new DateTime(2022, 10, 20, 5, 59, 39, 511, DateTimeKind.Local).AddTicks(7878), 95, 11.2865315807729m },
                    { 16, 8, new DateTime(2023, 3, 3, 6, 49, 23, 42, DateTimeKind.Local).AddTicks(6605), new DateTime(2023, 1, 27, 23, 42, 23, 758, DateTimeKind.Local).AddTicks(8774), 64, 24.8029967924341m },
                    { 17, 47, new DateTime(2022, 9, 28, 2, 25, 25, 435, DateTimeKind.Local).AddTicks(8209), new DateTime(2022, 12, 25, 12, 25, 29, 894, DateTimeKind.Local).AddTicks(7019), 9, 14.0383926965422m },
                    { 18, 132, new DateTime(2022, 6, 29, 19, 6, 12, 941, DateTimeKind.Local).AddTicks(4511), new DateTime(2023, 1, 26, 0, 8, 55, 251, DateTimeKind.Local).AddTicks(3150), 100, 4.35849823997644m },
                    { 19, 27, new DateTime(2022, 11, 10, 19, 32, 13, 442, DateTimeKind.Local).AddTicks(6248), new DateTime(2022, 5, 2, 10, 55, 27, 796, DateTimeKind.Local).AddTicks(8260), 11, 26.9869606955711m },
                    { 20, 117, new DateTime(2022, 5, 5, 12, 1, 34, 42, DateTimeKind.Local).AddTicks(2240), new DateTime(2023, 3, 2, 15, 51, 29, 422, DateTimeKind.Local).AddTicks(9662), 41, 13.9904811025601m },
                    { 21, 49, new DateTime(2023, 3, 24, 11, 59, 32, 645, DateTimeKind.Local).AddTicks(3382), new DateTime(2022, 10, 27, 0, 7, 9, 541, DateTimeKind.Local).AddTicks(2511), 50, 13.1221445959328m },
                    { 22, 59, new DateTime(2022, 12, 2, 6, 50, 48, 796, DateTimeKind.Local).AddTicks(8615), new DateTime(2023, 4, 13, 14, 44, 38, 243, DateTimeKind.Local).AddTicks(3965), 37, 28.4731681630728m },
                    { 23, 126, new DateTime(2022, 6, 7, 18, 41, 44, 850, DateTimeKind.Local).AddTicks(6079), new DateTime(2022, 7, 7, 23, 40, 49, 959, DateTimeKind.Local).AddTicks(750), 62, 17.0624924853168m },
                    { 24, 4, new DateTime(2022, 5, 27, 21, 41, 47, 4, DateTimeKind.Local).AddTicks(1331), new DateTime(2023, 1, 23, 21, 50, 0, 736, DateTimeKind.Local).AddTicks(362), 9, 5.03710972978719m },
                    { 25, 72, new DateTime(2022, 12, 27, 17, 16, 41, 857, DateTimeKind.Local).AddTicks(5269), new DateTime(2023, 3, 2, 16, 49, 51, 333, DateTimeKind.Local).AddTicks(3712), 88, 10.5792338820075m },
                    { 26, 56, new DateTime(2022, 10, 25, 0, 28, 15, 406, DateTimeKind.Local).AddTicks(4104), new DateTime(2022, 12, 2, 19, 32, 23, 186, DateTimeKind.Local).AddTicks(1354), 13, 21.3395499263464m },
                    { 27, 46, new DateTime(2023, 3, 22, 9, 29, 23, 203, DateTimeKind.Local).AddTicks(1224), new DateTime(2023, 2, 14, 5, 11, 58, 394, DateTimeKind.Local).AddTicks(1913), 56, 6.65068274673888m },
                    { 28, 66, new DateTime(2022, 7, 15, 13, 4, 55, 752, DateTimeKind.Local).AddTicks(9791), new DateTime(2023, 2, 11, 7, 33, 9, 248, DateTimeKind.Local).AddTicks(9143), 27, 28.573465211691m },
                    { 29, 128, new DateTime(2022, 4, 17, 20, 39, 47, 191, DateTimeKind.Local).AddTicks(826), new DateTime(2022, 12, 21, 6, 51, 31, 751, DateTimeKind.Local).AddTicks(551), 14, 28.4920314874807m },
                    { 30, 98, new DateTime(2022, 6, 8, 11, 12, 23, 739, DateTimeKind.Local).AddTicks(2704), new DateTime(2022, 8, 4, 3, 39, 1, 555, DateTimeKind.Local).AddTicks(9249), 99, 12.580979423904m },
                    { 31, 82, new DateTime(2022, 8, 8, 6, 14, 0, 901, DateTimeKind.Local).AddTicks(2657), new DateTime(2023, 2, 16, 12, 22, 58, 247, DateTimeKind.Local).AddTicks(9494), 95, 15.4028746507069m },
                    { 32, 4, new DateTime(2023, 2, 27, 10, 26, 51, 92, DateTimeKind.Local).AddTicks(1346), new DateTime(2023, 3, 20, 3, 44, 18, 8, DateTimeKind.Local).AddTicks(4059), 2, 27.2001548481409m },
                    { 33, 31, new DateTime(2023, 3, 17, 2, 4, 33, 326, DateTimeKind.Local).AddTicks(1602), new DateTime(2022, 5, 13, 9, 46, 23, 101, DateTimeKind.Local).AddTicks(4827), 30, 2.34860936573487m },
                    { 34, 124, new DateTime(2022, 4, 17, 21, 30, 24, 450, DateTimeKind.Local).AddTicks(4168), new DateTime(2023, 3, 3, 3, 37, 10, 676, DateTimeKind.Local).AddTicks(5482), 48, 1.4553219613915m },
                    { 35, 105, new DateTime(2022, 5, 18, 10, 24, 58, 188, DateTimeKind.Local).AddTicks(9090), new DateTime(2023, 3, 27, 14, 37, 18, 722, DateTimeKind.Local).AddTicks(9269), 85, 4.26284156251397m },
                    { 36, 31, new DateTime(2022, 7, 18, 12, 12, 4, 880, DateTimeKind.Local).AddTicks(9909), new DateTime(2023, 2, 9, 22, 34, 9, 584, DateTimeKind.Local).AddTicks(9345), 32, 15.2903769052278m },
                    { 37, 103, new DateTime(2022, 8, 27, 3, 19, 33, 689, DateTimeKind.Local).AddTicks(3658), new DateTime(2023, 1, 19, 14, 47, 22, 593, DateTimeKind.Local).AddTicks(8851), 9, 25.8391928308035m },
                    { 38, 86, new DateTime(2023, 1, 18, 2, 57, 9, 898, DateTimeKind.Local).AddTicks(7073), new DateTime(2023, 1, 25, 11, 28, 20, 175, DateTimeKind.Local).AddTicks(1730), 4, 19.0609124576678m },
                    { 39, 91, new DateTime(2023, 2, 9, 10, 37, 7, 794, DateTimeKind.Local).AddTicks(7351), new DateTime(2022, 9, 14, 15, 59, 56, 986, DateTimeKind.Local).AddTicks(438), 63, 2.06273806012539m },
                    { 40, 48, new DateTime(2022, 12, 9, 21, 6, 16, 96, DateTimeKind.Local).AddTicks(3020), new DateTime(2022, 10, 3, 3, 36, 27, 575, DateTimeKind.Local).AddTicks(8861), 69, 1.35798173170258m },
                    { 41, 150, new DateTime(2022, 6, 1, 1, 32, 58, 627, DateTimeKind.Local).AddTicks(541), new DateTime(2023, 3, 25, 14, 9, 59, 861, DateTimeKind.Local).AddTicks(7385), 18, 13.1600971388184m },
                    { 42, 125, new DateTime(2022, 8, 3, 6, 17, 54, 999, DateTimeKind.Local).AddTicks(3892), new DateTime(2022, 12, 23, 10, 29, 12, 766, DateTimeKind.Local).AddTicks(7792), 36, 12.5895378682194m },
                    { 43, 132, new DateTime(2022, 10, 26, 1, 9, 52, 285, DateTimeKind.Local).AddTicks(9941), new DateTime(2022, 12, 31, 11, 45, 20, 584, DateTimeKind.Local).AddTicks(504), 86, 24.6991620273737m },
                    { 44, 121, new DateTime(2022, 11, 28, 8, 50, 16, 464, DateTimeKind.Local).AddTicks(6384), new DateTime(2022, 7, 20, 13, 53, 32, 341, DateTimeKind.Local).AddTicks(8923), 74, 24.6245887887318m },
                    { 45, 77, new DateTime(2023, 3, 19, 0, 43, 6, 28, DateTimeKind.Local).AddTicks(6454), new DateTime(2022, 12, 13, 20, 37, 10, 694, DateTimeKind.Local).AddTicks(678), 80, 21.6774540837525m },
                    { 46, 135, new DateTime(2023, 3, 31, 5, 49, 47, 713, DateTimeKind.Local).AddTicks(4343), new DateTime(2022, 7, 25, 22, 8, 23, 719, DateTimeKind.Local).AddTicks(9883), 39, 15.1075277452429m },
                    { 47, 130, new DateTime(2022, 12, 26, 8, 6, 21, 421, DateTimeKind.Local).AddTicks(9636), new DateTime(2022, 6, 1, 20, 57, 13, 153, DateTimeKind.Local).AddTicks(8535), 97, 17.4094447080251m },
                    { 48, 62, new DateTime(2022, 11, 7, 9, 29, 11, 521, DateTimeKind.Local).AddTicks(8652), new DateTime(2022, 10, 4, 2, 56, 1, 512, DateTimeKind.Local).AddTicks(5317), 65, 18.6936617621104m },
                    { 49, 57, new DateTime(2022, 5, 30, 8, 32, 10, 106, DateTimeKind.Local).AddTicks(5867), new DateTime(2022, 12, 18, 22, 23, 19, 102, DateTimeKind.Local).AddTicks(5032), 35, 14.1125092664561m },
                    { 50, 103, new DateTime(2022, 6, 19, 22, 22, 5, 90, DateTimeKind.Local).AddTicks(7956), new DateTime(2023, 1, 12, 17, 40, 58, 773, DateTimeKind.Local).AddTicks(7423), 33, 10.4709077121344m },
                    { 51, 49, new DateTime(2022, 11, 27, 18, 43, 47, 67, DateTimeKind.Local).AddTicks(2452), new DateTime(2023, 2, 18, 14, 11, 32, 986, DateTimeKind.Local).AddTicks(4190), 98, 7.8583716261593m },
                    { 52, 143, new DateTime(2022, 10, 22, 5, 51, 25, 656, DateTimeKind.Local).AddTicks(8375), new DateTime(2022, 6, 20, 14, 24, 35, 869, DateTimeKind.Local).AddTicks(1646), 10, 6.14744410004498m },
                    { 53, 67, new DateTime(2022, 7, 2, 7, 11, 35, 468, DateTimeKind.Local).AddTicks(7736), new DateTime(2023, 2, 11, 19, 47, 47, 44, DateTimeKind.Local).AddTicks(3428), 23, 2.19113256860935m },
                    { 54, 2, new DateTime(2023, 2, 21, 2, 10, 59, 77, DateTimeKind.Local).AddTicks(377), new DateTime(2023, 1, 3, 19, 45, 19, 324, DateTimeKind.Local).AddTicks(834), 24, 9.65121697060023m },
                    { 55, 23, new DateTime(2023, 3, 11, 10, 5, 17, 848, DateTimeKind.Local).AddTicks(175), new DateTime(2022, 10, 17, 18, 55, 30, 549, DateTimeKind.Local).AddTicks(1461), 95, 10.9876343566225m },
                    { 56, 125, new DateTime(2022, 8, 15, 16, 34, 58, 646, DateTimeKind.Local).AddTicks(8198), new DateTime(2022, 11, 4, 23, 52, 47, 268, DateTimeKind.Local).AddTicks(3009), 53, 17.2906560486599m },
                    { 57, 141, new DateTime(2022, 5, 6, 7, 4, 48, 15, DateTimeKind.Local).AddTicks(3067), new DateTime(2022, 12, 5, 8, 8, 3, 111, DateTimeKind.Local).AddTicks(3605), 44, 16.5542572812543m },
                    { 58, 9, new DateTime(2022, 11, 17, 4, 28, 1, 360, DateTimeKind.Local).AddTicks(4318), new DateTime(2023, 3, 6, 20, 5, 55, 704, DateTimeKind.Local).AddTicks(668), 93, 9.99167949361255m },
                    { 59, 124, new DateTime(2022, 12, 6, 6, 26, 50, 885, DateTimeKind.Local).AddTicks(9178), new DateTime(2023, 3, 24, 17, 54, 46, 782, DateTimeKind.Local).AddTicks(3122), 69, 10.4682351843723m },
                    { 60, 134, new DateTime(2022, 8, 29, 23, 8, 21, 547, DateTimeKind.Local).AddTicks(573), new DateTime(2023, 4, 12, 22, 12, 31, 905, DateTimeKind.Local).AddTicks(1161), 52, 26.6880454325994m },
                    { 61, 73, new DateTime(2022, 8, 21, 6, 50, 10, 111, DateTimeKind.Local).AddTicks(417), new DateTime(2023, 2, 1, 6, 30, 17, 873, DateTimeKind.Local).AddTicks(1711), 38, 26.7694582040746m },
                    { 62, 40, new DateTime(2022, 12, 29, 6, 14, 11, 176, DateTimeKind.Local).AddTicks(8661), new DateTime(2022, 12, 15, 13, 31, 6, 372, DateTimeKind.Local).AddTicks(5659), 63, 4.6389051159595m },
                    { 63, 90, new DateTime(2022, 11, 30, 13, 8, 22, 415, DateTimeKind.Local).AddTicks(3699), new DateTime(2023, 2, 10, 15, 20, 35, 280, DateTimeKind.Local).AddTicks(4527), 23, 6.75108394021103m },
                    { 64, 50, new DateTime(2022, 7, 22, 13, 9, 8, 338, DateTimeKind.Local).AddTicks(3572), new DateTime(2023, 2, 20, 14, 9, 17, 168, DateTimeKind.Local).AddTicks(6741), 59, 12.1752243456458m },
                    { 65, 141, new DateTime(2022, 7, 27, 21, 18, 28, 787, DateTimeKind.Local).AddTicks(8503), new DateTime(2023, 2, 18, 10, 5, 50, 605, DateTimeKind.Local).AddTicks(5297), 66, 2.8276125888098m },
                    { 66, 19, new DateTime(2022, 5, 22, 17, 2, 1, 753, DateTimeKind.Local).AddTicks(5015), new DateTime(2023, 2, 15, 12, 59, 44, 886, DateTimeKind.Local).AddTicks(7393), 1, 14.5649531216828m },
                    { 67, 102, new DateTime(2022, 10, 20, 1, 10, 21, 612, DateTimeKind.Local).AddTicks(8989), new DateTime(2022, 11, 15, 22, 59, 22, 286, DateTimeKind.Local).AddTicks(8266), 3, 25.66301305945m },
                    { 68, 14, new DateTime(2022, 7, 9, 9, 29, 58, 687, DateTimeKind.Local).AddTicks(1306), new DateTime(2023, 3, 25, 2, 56, 21, 166, DateTimeKind.Local).AddTicks(1379), 66, 6.74847685341334m },
                    { 69, 14, new DateTime(2023, 3, 5, 0, 51, 3, 849, DateTimeKind.Local).AddTicks(341), new DateTime(2023, 4, 1, 20, 9, 44, 88, DateTimeKind.Local).AddTicks(6018), 53, 26.300378573618m },
                    { 70, 70, new DateTime(2022, 6, 19, 16, 14, 16, 66, DateTimeKind.Local).AddTicks(7363), new DateTime(2023, 2, 12, 12, 31, 18, 927, DateTimeKind.Local).AddTicks(175), 18, 10.2303842082292m },
                    { 71, 92, new DateTime(2023, 2, 26, 18, 10, 52, 369, DateTimeKind.Local).AddTicks(4082), new DateTime(2022, 12, 19, 17, 55, 22, 539, DateTimeKind.Local).AddTicks(1266), 65, 11.0124474063221m },
                    { 72, 36, new DateTime(2022, 10, 6, 22, 49, 29, 326, DateTimeKind.Local).AddTicks(8630), new DateTime(2022, 12, 7, 0, 30, 30, 95, DateTimeKind.Local).AddTicks(7625), 69, 7.32295421769936m },
                    { 73, 32, new DateTime(2022, 11, 19, 8, 19, 45, 300, DateTimeKind.Local).AddTicks(5750), new DateTime(2022, 9, 19, 0, 44, 0, 44, DateTimeKind.Local).AddTicks(164), 9, 11.1712961443808m },
                    { 74, 71, new DateTime(2023, 4, 15, 4, 45, 51, 399, DateTimeKind.Local).AddTicks(7954), new DateTime(2023, 1, 12, 5, 40, 43, 360, DateTimeKind.Local).AddTicks(6580), 17, 18.7657198799515m },
                    { 75, 74, new DateTime(2023, 2, 12, 4, 55, 4, 574, DateTimeKind.Local).AddTicks(7889), new DateTime(2022, 5, 7, 5, 52, 30, 642, DateTimeKind.Local).AddTicks(8826), 59, 12.9057666645398m },
                    { 76, 133, new DateTime(2022, 8, 10, 10, 9, 12, 650, DateTimeKind.Local).AddTicks(2769), new DateTime(2023, 2, 23, 15, 0, 37, 653, DateTimeKind.Local).AddTicks(2531), 78, 16.4054124774422m },
                    { 77, 48, new DateTime(2022, 8, 20, 1, 44, 42, 714, DateTimeKind.Local).AddTicks(4701), new DateTime(2022, 10, 16, 18, 43, 19, 640, DateTimeKind.Local).AddTicks(3300), 83, 23.8727552164999m },
                    { 78, 105, new DateTime(2022, 4, 26, 2, 19, 6, 228, DateTimeKind.Local).AddTicks(2044), new DateTime(2023, 2, 5, 8, 49, 59, 914, DateTimeKind.Local).AddTicks(1178), 22, 14.4067797631781m },
                    { 79, 83, new DateTime(2022, 10, 11, 8, 46, 31, 802, DateTimeKind.Local).AddTicks(9563), new DateTime(2022, 11, 23, 9, 12, 38, 68, DateTimeKind.Local).AddTicks(6120), 12, 8.56948643128021m },
                    { 80, 87, new DateTime(2022, 10, 22, 6, 21, 30, 733, DateTimeKind.Local).AddTicks(9950), new DateTime(2022, 6, 29, 21, 47, 26, 424, DateTimeKind.Local).AddTicks(4364), 99, 5.40865706963734m },
                    { 81, 20, new DateTime(2022, 12, 17, 19, 46, 44, 164, DateTimeKind.Local).AddTicks(3002), new DateTime(2022, 11, 5, 20, 23, 59, 211, DateTimeKind.Local).AddTicks(801), 16, 8.36690974710743m },
                    { 82, 30, new DateTime(2022, 5, 25, 23, 16, 56, 20, DateTimeKind.Local).AddTicks(9456), new DateTime(2023, 3, 29, 9, 53, 0, 830, DateTimeKind.Local).AddTicks(4917), 69, 19.5402597814868m },
                    { 83, 129, new DateTime(2022, 10, 31, 10, 10, 21, 83, DateTimeKind.Local).AddTicks(2697), new DateTime(2022, 8, 8, 3, 19, 24, 922, DateTimeKind.Local).AddTicks(2051), 9, 6.87948312117593m },
                    { 84, 133, new DateTime(2022, 11, 22, 14, 40, 36, 856, DateTimeKind.Local).AddTicks(3575), new DateTime(2022, 7, 12, 3, 24, 9, 118, DateTimeKind.Local).AddTicks(5730), 30, 22.3356911834284m },
                    { 85, 149, new DateTime(2022, 10, 18, 5, 18, 51, 237, DateTimeKind.Local).AddTicks(7158), new DateTime(2022, 12, 3, 5, 45, 52, 109, DateTimeKind.Local).AddTicks(5528), 93, 19.9320126225359m },
                    { 86, 5, new DateTime(2023, 2, 22, 12, 35, 20, 197, DateTimeKind.Local).AddTicks(1077), new DateTime(2022, 11, 23, 19, 32, 53, 78, DateTimeKind.Local).AddTicks(8135), 58, 27.2547606079363m },
                    { 87, 33, new DateTime(2022, 10, 30, 12, 47, 37, 105, DateTimeKind.Local).AddTicks(8060), new DateTime(2022, 9, 1, 4, 11, 54, 490, DateTimeKind.Local).AddTicks(4036), 24, 18.1943315490206m },
                    { 88, 92, new DateTime(2023, 1, 7, 16, 48, 33, 978, DateTimeKind.Local).AddTicks(5962), new DateTime(2023, 4, 14, 20, 12, 22, 997, DateTimeKind.Local).AddTicks(28), 97, 23.7727538793196m },
                    { 89, 57, new DateTime(2022, 7, 2, 8, 16, 40, 999, DateTimeKind.Local).AddTicks(445), new DateTime(2022, 8, 24, 6, 30, 29, 759, DateTimeKind.Local).AddTicks(5704), 1, 27.9129422028044m },
                    { 90, 36, new DateTime(2022, 10, 30, 5, 44, 31, 453, DateTimeKind.Local).AddTicks(1072), new DateTime(2022, 8, 28, 13, 10, 11, 864, DateTimeKind.Local).AddTicks(3449), 56, 9.44390268165278m },
                    { 91, 91, new DateTime(2022, 11, 17, 2, 16, 45, 891, DateTimeKind.Local).AddTicks(2256), new DateTime(2022, 12, 8, 2, 4, 28, 616, DateTimeKind.Local).AddTicks(3270), 43, 6.75036813374524m },
                    { 92, 43, new DateTime(2022, 5, 22, 18, 20, 44, 509, DateTimeKind.Local).AddTicks(2583), new DateTime(2023, 1, 21, 10, 54, 16, 720, DateTimeKind.Local).AddTicks(4064), 24, 1.39363001283606m },
                    { 93, 113, new DateTime(2022, 10, 28, 16, 28, 29, 870, DateTimeKind.Local).AddTicks(1469), new DateTime(2022, 4, 17, 19, 1, 33, 871, DateTimeKind.Local).AddTicks(9563), 16, 14.0500748352008m },
                    { 94, 18, new DateTime(2023, 1, 27, 1, 5, 3, 852, DateTimeKind.Local).AddTicks(9248), new DateTime(2023, 3, 1, 2, 49, 19, 163, DateTimeKind.Local).AddTicks(3561), 9, 5.42853885012923m },
                    { 95, 141, new DateTime(2023, 1, 30, 21, 5, 52, 516, DateTimeKind.Local).AddTicks(365), new DateTime(2022, 10, 27, 19, 6, 0, 19, DateTimeKind.Local).AddTicks(7412), 99, 13.1538126475183m },
                    { 96, 41, new DateTime(2023, 3, 14, 20, 17, 22, 485, DateTimeKind.Local).AddTicks(9144), new DateTime(2022, 10, 24, 6, 12, 59, 623, DateTimeKind.Local).AddTicks(9762), 74, 12.5733522064906m },
                    { 97, 68, new DateTime(2022, 8, 10, 6, 30, 51, 225, DateTimeKind.Local).AddTicks(8902), new DateTime(2022, 5, 17, 16, 41, 16, 460, DateTimeKind.Local).AddTicks(5635), 59, 10.3690540137614m },
                    { 98, 113, new DateTime(2023, 1, 30, 6, 36, 25, 186, DateTimeKind.Local).AddTicks(8241), new DateTime(2022, 8, 7, 12, 18, 33, 965, DateTimeKind.Local).AddTicks(3259), 10, 12.4265048170312m },
                    { 99, 130, new DateTime(2022, 5, 6, 9, 31, 7, 675, DateTimeKind.Local).AddTicks(2555), new DateTime(2022, 4, 26, 14, 10, 19, 893, DateTimeKind.Local).AddTicks(5920), 54, 22.9646664000316m },
                    { 100, 119, new DateTime(2023, 2, 18, 3, 24, 10, 706, DateTimeKind.Local).AddTicks(3154), new DateTime(2022, 5, 4, 9, 38, 4, 595, DateTimeKind.Local).AddTicks(1042), 62, 14.8061045162957m },
                    { 101, 35, new DateTime(2022, 10, 26, 0, 45, 42, 279, DateTimeKind.Local).AddTicks(9143), new DateTime(2023, 1, 29, 17, 32, 54, 866, DateTimeKind.Local).AddTicks(2551), 32, 12.5672920518864m },
                    { 102, 42, new DateTime(2022, 5, 15, 17, 4, 55, 814, DateTimeKind.Local).AddTicks(3286), new DateTime(2022, 5, 26, 5, 32, 34, 277, DateTimeKind.Local).AddTicks(9352), 15, 11.2057622683159m },
                    { 103, 100, new DateTime(2022, 8, 19, 9, 6, 19, 233, DateTimeKind.Local).AddTicks(5249), new DateTime(2022, 9, 2, 5, 53, 32, 52, DateTimeKind.Local).AddTicks(3260), 16, 2.4614604032118m },
                    { 104, 149, new DateTime(2022, 5, 24, 7, 52, 11, 121, DateTimeKind.Local).AddTicks(186), new DateTime(2023, 2, 19, 10, 29, 22, 109, DateTimeKind.Local).AddTicks(8208), 4, 7.09398214154851m },
                    { 105, 141, new DateTime(2022, 7, 10, 14, 23, 2, 900, DateTimeKind.Local).AddTicks(5261), new DateTime(2022, 7, 4, 11, 30, 23, 492, DateTimeKind.Local).AddTicks(2979), 52, 8.44212423664834m },
                    { 106, 148, new DateTime(2023, 2, 23, 23, 29, 33, 89, DateTimeKind.Local).AddTicks(5750), new DateTime(2022, 11, 22, 4, 35, 44, 319, DateTimeKind.Local).AddTicks(7705), 61, 1.57986757202169m },
                    { 107, 117, new DateTime(2022, 10, 28, 12, 16, 11, 402, DateTimeKind.Local).AddTicks(8848), new DateTime(2023, 1, 24, 20, 18, 27, 15, DateTimeKind.Local).AddTicks(3730), 55, 2.760396255151m },
                    { 108, 37, new DateTime(2022, 10, 11, 15, 40, 16, 162, DateTimeKind.Local).AddTicks(239), new DateTime(2023, 2, 3, 20, 12, 58, 151, DateTimeKind.Local).AddTicks(3362), 17, 2.37823626137349m },
                    { 109, 39, new DateTime(2023, 2, 19, 4, 37, 19, 936, DateTimeKind.Local).AddTicks(5167), new DateTime(2022, 10, 12, 12, 44, 19, 564, DateTimeKind.Local).AddTicks(4), 78, 21.5791021883039m },
                    { 110, 132, new DateTime(2022, 12, 15, 17, 48, 36, 956, DateTimeKind.Local).AddTicks(9141), new DateTime(2022, 12, 22, 23, 14, 4, 815, DateTimeKind.Local).AddTicks(2359), 80, 23.3681166866809m },
                    { 111, 119, new DateTime(2022, 7, 15, 1, 19, 2, 957, DateTimeKind.Local).AddTicks(1089), new DateTime(2022, 11, 10, 15, 17, 1, 1, DateTimeKind.Local).AddTicks(2193), 54, 7.59505954680898m },
                    { 112, 89, new DateTime(2022, 8, 19, 10, 19, 33, 836, DateTimeKind.Local).AddTicks(1372), new DateTime(2022, 10, 2, 5, 26, 30, 241, DateTimeKind.Local).AddTicks(7833), 10, 18.9348443375711m },
                    { 113, 119, new DateTime(2022, 11, 1, 9, 16, 21, 289, DateTimeKind.Local).AddTicks(4979), new DateTime(2022, 8, 11, 0, 24, 55, 940, DateTimeKind.Local).AddTicks(1620), 97, 12.7382242914675m },
                    { 114, 57, new DateTime(2022, 12, 10, 7, 49, 35, 308, DateTimeKind.Local).AddTicks(9634), new DateTime(2022, 12, 17, 22, 8, 51, 240, DateTimeKind.Local).AddTicks(6110), 3, 3.8742686335108m },
                    { 115, 12, new DateTime(2022, 8, 15, 9, 27, 18, 162, DateTimeKind.Local).AddTicks(6630), new DateTime(2022, 12, 2, 17, 34, 5, 968, DateTimeKind.Local).AddTicks(3238), 9, 26.6757499959084m },
                    { 116, 105, new DateTime(2022, 7, 27, 5, 8, 24, 122, DateTimeKind.Local).AddTicks(7143), new DateTime(2022, 5, 17, 13, 47, 8, 750, DateTimeKind.Local).AddTicks(2061), 81, 2.82440610514562m },
                    { 117, 70, new DateTime(2022, 6, 12, 23, 44, 12, 467, DateTimeKind.Local).AddTicks(1190), new DateTime(2022, 7, 6, 23, 50, 51, 414, DateTimeKind.Local).AddTicks(3420), 16, 23.7432725649106m },
                    { 118, 59, new DateTime(2022, 12, 7, 6, 50, 23, 653, DateTimeKind.Local).AddTicks(1562), new DateTime(2022, 8, 26, 11, 29, 10, 190, DateTimeKind.Local).AddTicks(5215), 84, 18.9272380186384m },
                    { 119, 68, new DateTime(2023, 1, 15, 5, 17, 42, 14, DateTimeKind.Local).AddTicks(3213), new DateTime(2022, 6, 24, 10, 9, 51, 544, DateTimeKind.Local).AddTicks(2739), 61, 4.17826194613218m },
                    { 120, 107, new DateTime(2022, 12, 26, 20, 12, 17, 250, DateTimeKind.Local).AddTicks(4685), new DateTime(2022, 5, 3, 16, 42, 22, 775, DateTimeKind.Local).AddTicks(1833), 24, 28.2490990859946m },
                    { 121, 140, new DateTime(2023, 1, 12, 2, 42, 19, 556, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 11, 29, 10, 42, 3, 795, DateTimeKind.Local).AddTicks(8770), 12, 18.3746848477364m },
                    { 122, 125, new DateTime(2023, 2, 12, 14, 45, 30, 265, DateTimeKind.Local).AddTicks(392), new DateTime(2022, 11, 19, 23, 35, 11, 577, DateTimeKind.Local).AddTicks(2816), 80, 13.1376883230463m },
                    { 123, 124, new DateTime(2022, 11, 13, 1, 0, 53, 62, DateTimeKind.Local).AddTicks(1311), new DateTime(2022, 7, 26, 16, 48, 39, 702, DateTimeKind.Local).AddTicks(6139), 91, 17.7614273866951m },
                    { 124, 145, new DateTime(2022, 10, 14, 4, 23, 36, 905, DateTimeKind.Local).AddTicks(4347), new DateTime(2022, 6, 14, 18, 45, 51, 885, DateTimeKind.Local).AddTicks(1154), 22, 19.2849565681109m },
                    { 125, 126, new DateTime(2023, 1, 4, 16, 10, 16, 121, DateTimeKind.Local).AddTicks(5072), new DateTime(2022, 8, 28, 4, 49, 45, 193, DateTimeKind.Local).AddTicks(2090), 8, 6.03316413583789m },
                    { 126, 133, new DateTime(2022, 8, 4, 14, 5, 39, 538, DateTimeKind.Local).AddTicks(8841), new DateTime(2022, 9, 17, 7, 47, 55, 107, DateTimeKind.Local).AddTicks(4718), 75, 6.79885253670993m },
                    { 127, 123, new DateTime(2023, 3, 18, 12, 50, 7, 423, DateTimeKind.Local).AddTicks(7755), new DateTime(2022, 9, 19, 23, 38, 9, 7, DateTimeKind.Local).AddTicks(1046), 44, 1.89665120632654m },
                    { 128, 81, new DateTime(2023, 3, 12, 12, 28, 46, 942, DateTimeKind.Local).AddTicks(9728), new DateTime(2022, 11, 30, 12, 50, 33, 619, DateTimeKind.Local).AddTicks(6118), 13, 9.14999552314913m },
                    { 129, 108, new DateTime(2023, 1, 14, 14, 24, 4, 693, DateTimeKind.Local).AddTicks(5862), new DateTime(2022, 5, 29, 21, 20, 25, 954, DateTimeKind.Local).AddTicks(7993), 78, 5.63114442978614m },
                    { 130, 52, new DateTime(2023, 3, 2, 2, 49, 6, 874, DateTimeKind.Local).AddTicks(3159), new DateTime(2022, 12, 20, 17, 11, 3, 863, DateTimeKind.Local).AddTicks(9514), 44, 3.40987983773704m },
                    { 131, 66, new DateTime(2022, 6, 3, 10, 52, 59, 596, DateTimeKind.Local).AddTicks(3166), new DateTime(2023, 4, 11, 18, 12, 1, 213, DateTimeKind.Local).AddTicks(968), 29, 14.2088401763175m },
                    { 132, 96, new DateTime(2022, 11, 11, 8, 52, 21, 527, DateTimeKind.Local).AddTicks(4673), new DateTime(2022, 8, 26, 20, 39, 56, 733, DateTimeKind.Local).AddTicks(9010), 97, 25.121625740017m },
                    { 133, 62, new DateTime(2022, 7, 20, 5, 0, 19, 512, DateTimeKind.Local).AddTicks(9740), new DateTime(2022, 11, 24, 7, 27, 49, 296, DateTimeKind.Local).AddTicks(8414), 95, 18.4947169031785m },
                    { 134, 101, new DateTime(2023, 1, 31, 6, 24, 2, 901, DateTimeKind.Local).AddTicks(7434), new DateTime(2023, 1, 20, 2, 0, 58, 59, DateTimeKind.Local).AddTicks(500), 44, 11.1164003927727m },
                    { 135, 103, new DateTime(2022, 5, 7, 9, 11, 2, 677, DateTimeKind.Local).AddTicks(5363), new DateTime(2022, 4, 25, 22, 30, 29, 983, DateTimeKind.Local).AddTicks(225), 23, 6.62679712131124m },
                    { 136, 91, new DateTime(2023, 1, 4, 3, 39, 27, 171, DateTimeKind.Local).AddTicks(5220), new DateTime(2022, 12, 2, 0, 37, 47, 259, DateTimeKind.Local).AddTicks(4462), 76, 25.7711390496969m },
                    { 137, 8, new DateTime(2022, 5, 4, 7, 31, 19, 786, DateTimeKind.Local).AddTicks(8739), new DateTime(2022, 10, 17, 19, 11, 32, 481, DateTimeKind.Local).AddTicks(6862), 74, 5.46532309962216m },
                    { 138, 94, new DateTime(2022, 11, 21, 15, 22, 3, 437, DateTimeKind.Local).AddTicks(730), new DateTime(2022, 7, 24, 20, 2, 50, 910, DateTimeKind.Local).AddTicks(5759), 72, 21.1570538428117m },
                    { 139, 144, new DateTime(2022, 12, 11, 21, 22, 15, 169, DateTimeKind.Local).AddTicks(9921), new DateTime(2022, 12, 24, 19, 28, 58, 189, DateTimeKind.Local).AddTicks(7170), 72, 21.6421501310598m },
                    { 140, 103, new DateTime(2022, 9, 4, 4, 21, 17, 406, DateTimeKind.Local).AddTicks(5150), new DateTime(2022, 6, 27, 20, 48, 56, 373, DateTimeKind.Local).AddTicks(9142), 2, 23.2446680246557m },
                    { 141, 67, new DateTime(2022, 9, 1, 3, 33, 8, 621, DateTimeKind.Local).AddTicks(1781), new DateTime(2022, 7, 30, 18, 43, 33, 482, DateTimeKind.Local).AddTicks(6707), 39, 25.5591571420724m },
                    { 142, 106, new DateTime(2022, 5, 7, 11, 28, 38, 446, DateTimeKind.Local).AddTicks(6908), new DateTime(2023, 3, 10, 3, 14, 27, 64, DateTimeKind.Local).AddTicks(5991), 80, 22.0523755931697m },
                    { 143, 3, new DateTime(2022, 8, 21, 19, 16, 45, 126, DateTimeKind.Local).AddTicks(5080), new DateTime(2022, 7, 13, 17, 49, 3, 204, DateTimeKind.Local).AddTicks(6545), 52, 4.94570425601159m },
                    { 144, 23, new DateTime(2022, 9, 21, 5, 26, 11, 859, DateTimeKind.Local).AddTicks(7906), new DateTime(2022, 8, 8, 1, 39, 47, 971, DateTimeKind.Local).AddTicks(4044), 41, 25.5032950403522m },
                    { 145, 75, new DateTime(2023, 1, 3, 14, 52, 40, 254, DateTimeKind.Local).AddTicks(892), new DateTime(2022, 5, 17, 0, 35, 57, 464, DateTimeKind.Local).AddTicks(5607), 16, 3.69561274613612m },
                    { 146, 140, new DateTime(2022, 5, 14, 1, 29, 51, 232, DateTimeKind.Local).AddTicks(8207), new DateTime(2022, 12, 18, 22, 21, 28, 641, DateTimeKind.Local).AddTicks(4159), 69, 12.7375048955597m },
                    { 147, 2, new DateTime(2022, 8, 12, 13, 25, 22, 758, DateTimeKind.Local).AddTicks(1767), new DateTime(2022, 10, 25, 11, 42, 22, 121, DateTimeKind.Local).AddTicks(4910), 2, 2.97778336734959m },
                    { 148, 135, new DateTime(2023, 1, 24, 17, 5, 36, 27, DateTimeKind.Local).AddTicks(4925), new DateTime(2022, 9, 29, 15, 29, 41, 708, DateTimeKind.Local).AddTicks(6314), 33, 24.9215988593158m },
                    { 149, 22, new DateTime(2022, 9, 15, 0, 16, 1, 205, DateTimeKind.Local).AddTicks(4333), new DateTime(2022, 12, 24, 4, 54, 20, 520, DateTimeKind.Local).AddTicks(4158), 7, 9.34440614793034m },
                    { 150, 86, new DateTime(2022, 9, 18, 22, 38, 43, 801, DateTimeKind.Local).AddTicks(6490), new DateTime(2023, 4, 6, 7, 38, 2, 519, DateTimeKind.Local).AddTicks(76), 98, 15.6122396483718m },
                    { 151, 128, new DateTime(2022, 4, 21, 23, 31, 0, 789, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 8, 4, 16, 6, 38, 72, DateTimeKind.Local).AddTicks(6764), 11, 24.4495439403132m },
                    { 152, 97, new DateTime(2022, 12, 18, 1, 27, 54, 55, DateTimeKind.Local).AddTicks(1908), new DateTime(2022, 9, 21, 23, 3, 28, 853, DateTimeKind.Local).AddTicks(5053), 98, 18.0948404144594m },
                    { 153, 99, new DateTime(2023, 2, 20, 13, 39, 45, 265, DateTimeKind.Local).AddTicks(3160), new DateTime(2022, 10, 10, 7, 59, 48, 900, DateTimeKind.Local).AddTicks(8221), 40, 20.7220391408461m },
                    { 154, 105, new DateTime(2023, 3, 4, 4, 58, 53, 4, DateTimeKind.Local).AddTicks(1589), new DateTime(2022, 10, 31, 17, 53, 18, 937, DateTimeKind.Local).AddTicks(9448), 41, 4.20005118448508m },
                    { 155, 45, new DateTime(2022, 8, 4, 14, 14, 7, 584, DateTimeKind.Local).AddTicks(4495), new DateTime(2022, 7, 4, 2, 21, 14, 61, DateTimeKind.Local).AddTicks(5373), 52, 20.787108493789m },
                    { 156, 71, new DateTime(2022, 7, 6, 23, 54, 30, 971, DateTimeKind.Local).AddTicks(2420), new DateTime(2022, 9, 4, 18, 5, 6, 185, DateTimeKind.Local).AddTicks(9323), 3, 15.6000729710439m },
                    { 157, 16, new DateTime(2022, 8, 6, 17, 56, 16, 955, DateTimeKind.Local).AddTicks(5710), new DateTime(2023, 1, 11, 15, 32, 29, 757, DateTimeKind.Local).AddTicks(9038), 80, 22.1285004452225m },
                    { 158, 39, new DateTime(2022, 7, 31, 4, 45, 56, 128, DateTimeKind.Local).AddTicks(5548), new DateTime(2022, 9, 13, 6, 12, 58, 441, DateTimeKind.Local).AddTicks(6919), 57, 27.0626501371861m },
                    { 159, 39, new DateTime(2022, 6, 24, 14, 34, 37, 262, DateTimeKind.Local).AddTicks(6377), new DateTime(2022, 6, 15, 20, 52, 49, 853, DateTimeKind.Local).AddTicks(6243), 93, 16.5447724431923m },
                    { 160, 34, new DateTime(2022, 12, 9, 1, 15, 23, 611, DateTimeKind.Local).AddTicks(1930), new DateTime(2022, 12, 1, 16, 16, 4, 871, DateTimeKind.Local).AddTicks(9482), 95, 7.46298826329527m },
                    { 161, 17, new DateTime(2023, 3, 17, 8, 49, 42, 517, DateTimeKind.Local).AddTicks(6280), new DateTime(2022, 8, 14, 16, 57, 8, 100, DateTimeKind.Local).AddTicks(9154), 69, 26.7768324253654m },
                    { 162, 107, new DateTime(2023, 2, 24, 1, 9, 4, 430, DateTimeKind.Local).AddTicks(8342), new DateTime(2022, 12, 3, 5, 27, 5, 513, DateTimeKind.Local).AddTicks(2766), 75, 7.25688189224988m },
                    { 163, 20, new DateTime(2022, 7, 1, 4, 54, 21, 857, DateTimeKind.Local).AddTicks(2610), new DateTime(2022, 8, 11, 1, 1, 51, 69, DateTimeKind.Local).AddTicks(2352), 3, 18.3834957163614m },
                    { 164, 119, new DateTime(2023, 4, 16, 6, 42, 48, 424, DateTimeKind.Local).AddTicks(9512), new DateTime(2022, 8, 26, 19, 34, 43, 82, DateTimeKind.Local).AddTicks(8728), 88, 11.6297881645142m },
                    { 165, 56, new DateTime(2022, 5, 20, 11, 29, 28, 259, DateTimeKind.Local).AddTicks(5293), new DateTime(2022, 6, 4, 2, 38, 40, 818, DateTimeKind.Local).AddTicks(4971), 8, 21.691163259809m },
                    { 166, 11, new DateTime(2022, 4, 16, 9, 41, 13, 961, DateTimeKind.Local).AddTicks(5403), new DateTime(2023, 2, 26, 11, 40, 27, 470, DateTimeKind.Local).AddTicks(6408), 95, 15.7174483589109m },
                    { 167, 85, new DateTime(2022, 9, 12, 11, 3, 41, 159, DateTimeKind.Local).AddTicks(4940), new DateTime(2023, 2, 20, 16, 25, 38, 748, DateTimeKind.Local).AddTicks(8698), 95, 15.4739517477208m },
                    { 168, 43, new DateTime(2022, 10, 12, 18, 23, 51, 475, DateTimeKind.Local).AddTicks(9228), new DateTime(2022, 12, 30, 23, 56, 24, 709, DateTimeKind.Local).AddTicks(1655), 89, 5.15495466544776m },
                    { 169, 49, new DateTime(2023, 3, 11, 9, 32, 0, 308, DateTimeKind.Local).AddTicks(2206), new DateTime(2022, 5, 16, 19, 52, 59, 395, DateTimeKind.Local).AddTicks(5416), 95, 25.9606676929816m },
                    { 170, 16, new DateTime(2022, 6, 4, 11, 30, 7, 533, DateTimeKind.Local).AddTicks(1110), new DateTime(2023, 3, 17, 4, 51, 1, 892, DateTimeKind.Local).AddTicks(6346), 39, 9.30629077158549m },
                    { 171, 49, new DateTime(2023, 1, 19, 22, 49, 37, 252, DateTimeKind.Local).AddTicks(3282), new DateTime(2022, 11, 7, 16, 19, 11, 830, DateTimeKind.Local).AddTicks(6356), 97, 22.5703236283578m },
                    { 172, 5, new DateTime(2022, 7, 28, 2, 11, 33, 131, DateTimeKind.Local).AddTicks(1765), new DateTime(2023, 2, 26, 9, 58, 17, 207, DateTimeKind.Local).AddTicks(3772), 47, 23.2062456344064m },
                    { 173, 26, new DateTime(2022, 7, 12, 7, 10, 48, 896, DateTimeKind.Local).AddTicks(4768), new DateTime(2022, 9, 18, 3, 23, 12, 64, DateTimeKind.Local).AddTicks(2496), 26, 27.3333972707483m },
                    { 174, 73, new DateTime(2022, 11, 13, 3, 19, 42, 388, DateTimeKind.Local).AddTicks(9847), new DateTime(2022, 9, 2, 16, 13, 28, 662, DateTimeKind.Local).AddTicks(1931), 32, 11.9519187328642m },
                    { 175, 143, new DateTime(2022, 7, 25, 16, 40, 57, 824, DateTimeKind.Local).AddTicks(7646), new DateTime(2023, 2, 7, 8, 27, 51, 35, DateTimeKind.Local).AddTicks(3622), 12, 21.1653753918451m },
                    { 176, 149, new DateTime(2022, 10, 23, 6, 56, 43, 627, DateTimeKind.Local).AddTicks(8405), new DateTime(2022, 7, 20, 17, 56, 28, 561, DateTimeKind.Local).AddTicks(2072), 12, 15.4322802585335m },
                    { 177, 76, new DateTime(2022, 7, 22, 11, 45, 55, 494, DateTimeKind.Local).AddTicks(5453), new DateTime(2022, 9, 29, 15, 23, 1, 804, DateTimeKind.Local).AddTicks(1819), 62, 10.7264199779366m },
                    { 178, 13, new DateTime(2023, 1, 14, 19, 18, 30, 69, DateTimeKind.Local).AddTicks(1787), new DateTime(2022, 4, 28, 16, 4, 17, 292, DateTimeKind.Local).AddTicks(9903), 70, 4.62492610962149m },
                    { 179, 124, new DateTime(2022, 5, 22, 14, 41, 2, 625, DateTimeKind.Local).AddTicks(3309), new DateTime(2022, 8, 31, 9, 46, 50, 246, DateTimeKind.Local).AddTicks(8400), 51, 21.1384874846548m },
                    { 180, 85, new DateTime(2022, 8, 15, 6, 43, 18, 782, DateTimeKind.Local).AddTicks(4036), new DateTime(2022, 5, 17, 5, 51, 44, 423, DateTimeKind.Local).AddTicks(45), 84, 26.2716284743007m },
                    { 181, 69, new DateTime(2022, 5, 24, 6, 34, 10, 232, DateTimeKind.Local).AddTicks(6140), new DateTime(2022, 7, 29, 12, 50, 6, 911, DateTimeKind.Local).AddTicks(8453), 85, 7.98404073879586m },
                    { 182, 140, new DateTime(2022, 4, 26, 16, 43, 0, 602, DateTimeKind.Local).AddTicks(4238), new DateTime(2022, 10, 29, 23, 58, 51, 988, DateTimeKind.Local).AddTicks(1698), 53, 19.02241464752m },
                    { 183, 73, new DateTime(2022, 6, 26, 5, 52, 40, 246, DateTimeKind.Local).AddTicks(2824), new DateTime(2022, 11, 7, 12, 26, 37, 172, DateTimeKind.Local).AddTicks(8836), 91, 25.3001734574796m },
                    { 184, 102, new DateTime(2022, 4, 28, 21, 29, 16, 719, DateTimeKind.Local).AddTicks(3287), new DateTime(2022, 4, 25, 12, 33, 51, 717, DateTimeKind.Local).AddTicks(3799), 39, 11.7848828401874m },
                    { 185, 75, new DateTime(2022, 6, 21, 19, 0, 41, 832, DateTimeKind.Local).AddTicks(9392), new DateTime(2022, 4, 29, 9, 18, 50, 746, DateTimeKind.Local).AddTicks(3222), 85, 21.9088771776329m },
                    { 186, 27, new DateTime(2022, 11, 5, 13, 53, 8, 569, DateTimeKind.Local).AddTicks(3541), new DateTime(2023, 2, 13, 8, 21, 18, 693, DateTimeKind.Local).AddTicks(283), 30, 18.0839081201569m },
                    { 187, 120, new DateTime(2023, 3, 22, 0, 7, 45, 787, DateTimeKind.Local).AddTicks(2928), new DateTime(2022, 10, 17, 9, 54, 36, 946, DateTimeKind.Local).AddTicks(306), 93, 20.105691676567m },
                    { 188, 120, new DateTime(2022, 7, 2, 19, 48, 2, 411, DateTimeKind.Local).AddTicks(997), new DateTime(2022, 9, 28, 5, 57, 56, 224, DateTimeKind.Local).AddTicks(5394), 59, 26.1523859958361m },
                    { 189, 122, new DateTime(2022, 12, 11, 17, 52, 58, 136, DateTimeKind.Local).AddTicks(7787), new DateTime(2022, 8, 18, 15, 36, 0, 427, DateTimeKind.Local).AddTicks(3754), 28, 4.52639331766241m },
                    { 190, 115, new DateTime(2023, 1, 27, 7, 41, 35, 101, DateTimeKind.Local).AddTicks(123), new DateTime(2022, 8, 8, 15, 37, 29, 792, DateTimeKind.Local).AddTicks(2110), 10, 19.4128250012231m },
                    { 191, 41, new DateTime(2022, 8, 25, 11, 25, 2, 274, DateTimeKind.Local).AddTicks(5269), new DateTime(2023, 1, 29, 12, 6, 16, 198, DateTimeKind.Local).AddTicks(1847), 53, 13.0838288916902m },
                    { 192, 122, new DateTime(2022, 9, 14, 16, 28, 13, 41, DateTimeKind.Local).AddTicks(2884), new DateTime(2022, 6, 18, 9, 32, 48, 985, DateTimeKind.Local).AddTicks(3983), 28, 3.42396693353085m },
                    { 193, 139, new DateTime(2022, 7, 5, 18, 54, 43, 226, DateTimeKind.Local).AddTicks(2447), new DateTime(2022, 12, 16, 0, 51, 56, 766, DateTimeKind.Local).AddTicks(1641), 86, 1.82395028531996m },
                    { 194, 106, new DateTime(2022, 9, 2, 4, 33, 55, 652, DateTimeKind.Local).AddTicks(864), new DateTime(2022, 8, 15, 13, 6, 0, 777, DateTimeKind.Local).AddTicks(7819), 75, 9.68697445682213m },
                    { 195, 109, new DateTime(2022, 7, 1, 3, 49, 3, 595, DateTimeKind.Local).AddTicks(1132), new DateTime(2022, 7, 25, 4, 28, 1, 62, DateTimeKind.Local).AddTicks(9028), 2, 14.8999419528077m },
                    { 196, 72, new DateTime(2022, 5, 31, 6, 43, 32, 614, DateTimeKind.Local).AddTicks(6576), new DateTime(2023, 3, 8, 19, 44, 46, 593, DateTimeKind.Local).AddTicks(7058), 87, 6.89765845665226m },
                    { 197, 39, new DateTime(2023, 2, 17, 12, 41, 1, 702, DateTimeKind.Local).AddTicks(1502), new DateTime(2022, 9, 19, 22, 6, 30, 56, DateTimeKind.Local).AddTicks(1376), 70, 5.45661523684442m },
                    { 198, 46, new DateTime(2022, 5, 30, 1, 4, 57, 61, DateTimeKind.Local).AddTicks(8784), new DateTime(2023, 3, 18, 6, 5, 9, 510, DateTimeKind.Local).AddTicks(7970), 34, 5.53431050309825m },
                    { 199, 20, new DateTime(2022, 11, 8, 11, 44, 14, 994, DateTimeKind.Local).AddTicks(4979), new DateTime(2023, 4, 7, 22, 50, 24, 470, DateTimeKind.Local).AddTicks(7397), 29, 16.9227729768622m },
                    { 200, 35, new DateTime(2022, 5, 25, 18, 4, 30, 703, DateTimeKind.Local).AddTicks(7476), new DateTime(2023, 3, 7, 11, 28, 49, 626, DateTimeKind.Local).AddTicks(6356), 54, 4.79869653169004m },
                    { 201, 37, new DateTime(2022, 8, 26, 15, 25, 48, 92, DateTimeKind.Local).AddTicks(3097), new DateTime(2022, 8, 19, 0, 27, 47, 671, DateTimeKind.Local).AddTicks(7610), 22, 5.85938065431104m },
                    { 202, 69, new DateTime(2022, 6, 26, 22, 16, 56, 720, DateTimeKind.Local).AddTicks(4176), new DateTime(2022, 9, 18, 11, 40, 46, 640, DateTimeKind.Local).AddTicks(8544), 2, 8.72823878911369m },
                    { 203, 102, new DateTime(2022, 8, 23, 19, 4, 5, 838, DateTimeKind.Local).AddTicks(4553), new DateTime(2022, 12, 2, 22, 35, 42, 322, DateTimeKind.Local).AddTicks(1198), 20, 2.58138709453215m },
                    { 204, 74, new DateTime(2022, 6, 19, 15, 24, 56, 961, DateTimeKind.Local).AddTicks(6718), new DateTime(2023, 3, 28, 0, 5, 51, 301, DateTimeKind.Local).AddTicks(6364), 98, 18.9970430643317m },
                    { 205, 81, new DateTime(2022, 10, 9, 5, 16, 7, 757, DateTimeKind.Local).AddTicks(968), new DateTime(2023, 4, 8, 23, 41, 43, 173, DateTimeKind.Local).AddTicks(7444), 40, 15.7830245609344m },
                    { 206, 3, new DateTime(2022, 10, 18, 15, 3, 51, 418, DateTimeKind.Local).AddTicks(2667), new DateTime(2022, 9, 26, 21, 55, 11, 767, DateTimeKind.Local).AddTicks(9757), 66, 21.5093779043803m },
                    { 207, 105, new DateTime(2023, 3, 28, 18, 20, 43, 969, DateTimeKind.Local).AddTicks(8926), new DateTime(2022, 9, 4, 13, 37, 26, 669, DateTimeKind.Local).AddTicks(6029), 5, 22.9039829073259m },
                    { 208, 90, new DateTime(2023, 2, 26, 4, 22, 52, 519, DateTimeKind.Local).AddTicks(1498), new DateTime(2022, 7, 5, 4, 4, 41, 423, DateTimeKind.Local).AddTicks(9613), 27, 18.8241690968124m },
                    { 209, 103, new DateTime(2022, 10, 9, 20, 30, 3, 294, DateTimeKind.Local).AddTicks(5390), new DateTime(2022, 9, 1, 18, 57, 15, 234, DateTimeKind.Local).AddTicks(8568), 84, 8.01050089989952m },
                    { 210, 33, new DateTime(2023, 3, 15, 11, 46, 58, 471, DateTimeKind.Local).AddTicks(6384), new DateTime(2023, 1, 19, 21, 13, 42, 2, DateTimeKind.Local).AddTicks(3655), 84, 23.9661971992543m },
                    { 211, 88, new DateTime(2022, 11, 28, 6, 31, 33, 100, DateTimeKind.Local).AddTicks(2942), new DateTime(2022, 8, 18, 23, 1, 39, 414, DateTimeKind.Local).AddTicks(3494), 46, 4.85405180846502m },
                    { 212, 77, new DateTime(2023, 3, 8, 6, 27, 57, 183, DateTimeKind.Local).AddTicks(7438), new DateTime(2022, 7, 1, 12, 37, 17, 964, DateTimeKind.Local).AddTicks(3779), 67, 21.8335628696499m },
                    { 213, 58, new DateTime(2022, 8, 30, 8, 27, 14, 372, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 4, 17, 2, 22, 31, 784, DateTimeKind.Local).AddTicks(283), 31, 21.6743236772981m },
                    { 214, 131, new DateTime(2022, 11, 1, 7, 58, 19, 226, DateTimeKind.Local).AddTicks(3173), new DateTime(2023, 2, 3, 22, 55, 53, 989, DateTimeKind.Local).AddTicks(4318), 72, 24.4722693289671m },
                    { 215, 13, new DateTime(2022, 9, 4, 14, 5, 54, 619, DateTimeKind.Local).AddTicks(5145), new DateTime(2022, 12, 21, 4, 27, 53, 612, DateTimeKind.Local).AddTicks(8406), 75, 26.8415006793034m },
                    { 216, 29, new DateTime(2022, 12, 25, 16, 40, 54, 393, DateTimeKind.Local).AddTicks(972), new DateTime(2022, 9, 11, 19, 11, 4, 980, DateTimeKind.Local).AddTicks(7195), 41, 1.40616777996146m },
                    { 217, 130, new DateTime(2022, 10, 3, 9, 7, 42, 280, DateTimeKind.Local).AddTicks(1066), new DateTime(2022, 12, 31, 16, 36, 37, 564, DateTimeKind.Local).AddTicks(7996), 55, 9.60003751929409m },
                    { 218, 31, new DateTime(2023, 1, 27, 23, 23, 36, 531, DateTimeKind.Local).AddTicks(3766), new DateTime(2023, 2, 10, 17, 27, 4, 361, DateTimeKind.Local).AddTicks(2194), 98, 7.87094060037052m },
                    { 219, 43, new DateTime(2022, 9, 21, 12, 44, 16, 666, DateTimeKind.Local).AddTicks(2416), new DateTime(2023, 3, 21, 11, 49, 54, 545, DateTimeKind.Local).AddTicks(2499), 45, 22.7840315421998m },
                    { 220, 126, new DateTime(2022, 5, 26, 1, 46, 22, 108, DateTimeKind.Local).AddTicks(2988), new DateTime(2022, 10, 3, 17, 12, 17, 518, DateTimeKind.Local).AddTicks(7175), 64, 3.89190068846177m },
                    { 221, 39, new DateTime(2022, 12, 25, 16, 19, 32, 384, DateTimeKind.Local).AddTicks(3662), new DateTime(2022, 5, 27, 16, 41, 7, 761, DateTimeKind.Local).AddTicks(1269), 60, 3.70474905494231m },
                    { 222, 21, new DateTime(2023, 3, 22, 22, 14, 17, 603, DateTimeKind.Local).AddTicks(7071), new DateTime(2022, 4, 30, 4, 24, 51, 718, DateTimeKind.Local).AddTicks(2425), 97, 21.9054349147765m },
                    { 223, 49, new DateTime(2022, 6, 2, 10, 6, 30, 645, DateTimeKind.Local).AddTicks(461), new DateTime(2022, 7, 15, 16, 31, 17, 652, DateTimeKind.Local).AddTicks(1596), 23, 19.6153478691475m },
                    { 224, 116, new DateTime(2022, 6, 16, 11, 18, 41, 121, DateTimeKind.Local).AddTicks(1383), new DateTime(2023, 1, 10, 11, 37, 35, 662, DateTimeKind.Local).AddTicks(9233), 61, 29.1982295016472m },
                    { 225, 119, new DateTime(2023, 3, 4, 13, 17, 55, 368, DateTimeKind.Local).AddTicks(3166), new DateTime(2022, 6, 29, 14, 29, 4, 451, DateTimeKind.Local).AddTicks(4194), 28, 26.9001809097727m },
                    { 226, 123, new DateTime(2022, 6, 21, 20, 34, 8, 14, DateTimeKind.Local).AddTicks(6202), new DateTime(2023, 3, 9, 10, 9, 51, 764, DateTimeKind.Local).AddTicks(6597), 98, 2.82924049523196m },
                    { 227, 68, new DateTime(2022, 9, 27, 13, 9, 35, 368, DateTimeKind.Local).AddTicks(6574), new DateTime(2022, 11, 9, 7, 7, 37, 271, DateTimeKind.Local).AddTicks(7625), 17, 8.24039817047794m },
                    { 228, 58, new DateTime(2022, 9, 23, 1, 46, 4, 898, DateTimeKind.Local).AddTicks(3849), new DateTime(2022, 5, 17, 2, 8, 11, 792, DateTimeKind.Local).AddTicks(1342), 31, 26.298733412186m },
                    { 229, 12, new DateTime(2022, 7, 25, 12, 46, 37, 874, DateTimeKind.Local).AddTicks(9441), new DateTime(2023, 2, 22, 13, 31, 14, 81, DateTimeKind.Local).AddTicks(9546), 20, 29.5759344438446m },
                    { 230, 63, new DateTime(2022, 8, 31, 12, 35, 8, 966, DateTimeKind.Local).AddTicks(284), new DateTime(2022, 11, 19, 17, 3, 2, 517, DateTimeKind.Local).AddTicks(1546), 89, 18.344161678345m },
                    { 231, 86, new DateTime(2023, 3, 24, 22, 55, 3, 616, DateTimeKind.Local).AddTicks(4439), new DateTime(2022, 8, 21, 3, 48, 39, 850, DateTimeKind.Local).AddTicks(8950), 80, 27.7157806230256m },
                    { 232, 70, new DateTime(2022, 9, 19, 15, 57, 34, 831, DateTimeKind.Local).AddTicks(6396), new DateTime(2022, 8, 11, 15, 13, 30, 762, DateTimeKind.Local).AddTicks(8180), 34, 27.4235234810966m },
                    { 233, 46, new DateTime(2022, 6, 30, 18, 10, 54, 670, DateTimeKind.Local).AddTicks(8524), new DateTime(2022, 6, 11, 19, 9, 0, 177, DateTimeKind.Local).AddTicks(7182), 45, 27.1661293595548m },
                    { 234, 15, new DateTime(2022, 9, 25, 14, 31, 5, 852, DateTimeKind.Local).AddTicks(8651), new DateTime(2022, 7, 7, 11, 9, 35, 325, DateTimeKind.Local).AddTicks(1987), 72, 7.28782795253223m },
                    { 235, 31, new DateTime(2022, 7, 27, 19, 6, 41, 393, DateTimeKind.Local).AddTicks(4400), new DateTime(2022, 10, 9, 0, 55, 25, 209, DateTimeKind.Local).AddTicks(3084), 45, 19.5550482602632m },
                    { 236, 96, new DateTime(2022, 8, 19, 13, 26, 41, 648, DateTimeKind.Local).AddTicks(2774), new DateTime(2022, 6, 12, 6, 52, 48, 473, DateTimeKind.Local).AddTicks(5373), 59, 18.6878705277205m },
                    { 237, 144, new DateTime(2022, 9, 24, 15, 27, 24, 229, DateTimeKind.Local).AddTicks(9194), new DateTime(2022, 10, 6, 13, 55, 31, 635, DateTimeKind.Local).AddTicks(340), 76, 14.1229915376394m },
                    { 238, 104, new DateTime(2022, 11, 29, 9, 57, 58, 790, DateTimeKind.Local).AddTicks(2686), new DateTime(2022, 6, 7, 2, 58, 52, 448, DateTimeKind.Local).AddTicks(6800), 5, 8.14350448757365m },
                    { 239, 107, new DateTime(2022, 4, 16, 12, 24, 18, 434, DateTimeKind.Local).AddTicks(4251), new DateTime(2022, 11, 19, 7, 18, 0, 310, DateTimeKind.Local).AddTicks(2424), 17, 1.253965953402m },
                    { 240, 25, new DateTime(2022, 7, 8, 14, 29, 1, 476, DateTimeKind.Local).AddTicks(6820), new DateTime(2022, 8, 2, 0, 1, 46, 694, DateTimeKind.Local).AddTicks(7253), 76, 17.2613554103334m },
                    { 241, 131, new DateTime(2022, 4, 22, 1, 4, 13, 431, DateTimeKind.Local).AddTicks(9595), new DateTime(2023, 4, 15, 23, 11, 8, 272, DateTimeKind.Local).AddTicks(9037), 88, 9.8624205635981m },
                    { 242, 108, new DateTime(2023, 2, 2, 14, 4, 15, 950, DateTimeKind.Local).AddTicks(3221), new DateTime(2023, 3, 10, 23, 6, 14, 971, DateTimeKind.Local).AddTicks(6192), 60, 20.8073536511626m },
                    { 243, 143, new DateTime(2022, 8, 2, 19, 2, 16, 884, DateTimeKind.Local).AddTicks(8474), new DateTime(2022, 8, 10, 4, 49, 35, 459, DateTimeKind.Local).AddTicks(2081), 53, 15.7001885038217m },
                    { 244, 16, new DateTime(2022, 6, 21, 18, 52, 37, 944, DateTimeKind.Local).AddTicks(4764), new DateTime(2023, 2, 15, 20, 17, 44, 891, DateTimeKind.Local).AddTicks(3110), 70, 12.1879350037425m },
                    { 245, 33, new DateTime(2022, 5, 24, 22, 40, 56, 237, DateTimeKind.Local).AddTicks(9570), new DateTime(2022, 11, 29, 21, 2, 10, 641, DateTimeKind.Local).AddTicks(3284), 92, 26.7600949983979m },
                    { 246, 7, new DateTime(2022, 8, 27, 11, 21, 24, 572, DateTimeKind.Local).AddTicks(7463), new DateTime(2022, 7, 12, 17, 35, 36, 6, DateTimeKind.Local).AddTicks(8835), 91, 10.392263714559m },
                    { 247, 141, new DateTime(2022, 8, 10, 11, 4, 1, 817, DateTimeKind.Local).AddTicks(9524), new DateTime(2023, 4, 15, 1, 8, 42, 196, DateTimeKind.Local).AddTicks(9156), 93, 14.686449060503m },
                    { 248, 23, new DateTime(2023, 4, 9, 10, 53, 40, 116, DateTimeKind.Local).AddTicks(4775), new DateTime(2023, 1, 5, 11, 3, 8, 239, DateTimeKind.Local).AddTicks(6488), 10, 4.50383360374524m },
                    { 249, 3, new DateTime(2022, 8, 25, 16, 33, 10, 823, DateTimeKind.Local).AddTicks(957), new DateTime(2022, 7, 29, 9, 33, 59, 173, DateTimeKind.Local).AddTicks(1070), 44, 19.2785127767861m },
                    { 250, 99, new DateTime(2023, 1, 13, 19, 35, 39, 257, DateTimeKind.Local).AddTicks(996), new DateTime(2023, 4, 1, 7, 50, 18, 98, DateTimeKind.Local).AddTicks(5414), 65, 1.65771706402605m },
                    { 251, 69, new DateTime(2023, 4, 15, 22, 13, 21, 180, DateTimeKind.Local).AddTicks(8789), new DateTime(2023, 3, 13, 11, 34, 42, 846, DateTimeKind.Local).AddTicks(5978), 76, 25.3250555694497m },
                    { 252, 105, new DateTime(2023, 2, 17, 12, 46, 8, 3, DateTimeKind.Local).AddTicks(9253), new DateTime(2023, 3, 26, 5, 44, 53, 809, DateTimeKind.Local).AddTicks(3186), 99, 24.1374116308514m },
                    { 253, 126, new DateTime(2022, 10, 19, 6, 42, 12, 190, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 10, 1, 17, 33, 19, 272, DateTimeKind.Local).AddTicks(890), 90, 29.3971775457797m },
                    { 254, 60, new DateTime(2022, 6, 27, 23, 17, 12, 839, DateTimeKind.Local).AddTicks(2003), new DateTime(2022, 6, 16, 15, 39, 50, 395, DateTimeKind.Local).AddTicks(8827), 28, 16.4123034885485m },
                    { 255, 34, new DateTime(2023, 3, 19, 22, 42, 46, 853, DateTimeKind.Local).AddTicks(6255), new DateTime(2022, 8, 20, 5, 24, 46, 200, DateTimeKind.Local).AddTicks(5432), 24, 23.0101980970492m },
                    { 256, 30, new DateTime(2023, 4, 14, 14, 53, 36, 542, DateTimeKind.Local).AddTicks(9350), new DateTime(2022, 11, 30, 17, 48, 44, 117, DateTimeKind.Local).AddTicks(8114), 4, 23.4358177835802m },
                    { 257, 64, new DateTime(2023, 1, 14, 3, 49, 17, 109, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 8, 9, 4, 27, 28, 952, DateTimeKind.Local).AddTicks(3204), 94, 10.5259822499334m },
                    { 258, 16, new DateTime(2022, 10, 10, 20, 55, 38, 785, DateTimeKind.Local).AddTicks(930), new DateTime(2023, 1, 11, 19, 39, 53, 950, DateTimeKind.Local).AddTicks(7203), 47, 15.6172020785356m },
                    { 259, 128, new DateTime(2022, 9, 1, 17, 48, 28, 532, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 11, 4, 17, 43, 3, 803, DateTimeKind.Local).AddTicks(5074), 97, 29.887287907408m },
                    { 260, 82, new DateTime(2022, 7, 7, 5, 30, 46, 646, DateTimeKind.Local).AddTicks(3116), new DateTime(2023, 1, 22, 4, 39, 37, 294, DateTimeKind.Local).AddTicks(5017), 5, 29.9361402356087m },
                    { 261, 94, new DateTime(2023, 3, 7, 14, 26, 48, 83, DateTimeKind.Local).AddTicks(9928), new DateTime(2023, 1, 12, 1, 25, 44, 91, DateTimeKind.Local).AddTicks(8555), 78, 14.3813324032127m },
                    { 262, 73, new DateTime(2023, 4, 14, 7, 38, 57, 107, DateTimeKind.Local).AddTicks(6420), new DateTime(2023, 4, 3, 16, 53, 6, 720, DateTimeKind.Local).AddTicks(1889), 66, 28.3229268185612m },
                    { 263, 122, new DateTime(2022, 10, 23, 13, 39, 39, 933, DateTimeKind.Local).AddTicks(7739), new DateTime(2022, 11, 12, 1, 13, 7, 887, DateTimeKind.Local).AddTicks(4301), 22, 23.2130324375799m },
                    { 264, 90, new DateTime(2023, 4, 14, 2, 57, 35, 989, DateTimeKind.Local).AddTicks(5853), new DateTime(2022, 9, 23, 23, 37, 47, 561, DateTimeKind.Local).AddTicks(7070), 59, 26.5674290645011m },
                    { 265, 95, new DateTime(2023, 2, 16, 11, 31, 41, 207, DateTimeKind.Local).AddTicks(867), new DateTime(2022, 9, 24, 13, 25, 19, 921, DateTimeKind.Local).AddTicks(6642), 46, 27.3490916781538m },
                    { 266, 71, new DateTime(2022, 9, 12, 1, 18, 41, 669, DateTimeKind.Local).AddTicks(4498), new DateTime(2022, 7, 1, 10, 42, 54, 547, DateTimeKind.Local).AddTicks(8457), 45, 20.8732177494098m },
                    { 267, 35, new DateTime(2022, 9, 18, 11, 47, 4, 180, DateTimeKind.Local).AddTicks(357), new DateTime(2022, 11, 14, 21, 53, 12, 198, DateTimeKind.Local).AddTicks(8843), 33, 15.5406981637185m },
                    { 268, 54, new DateTime(2022, 7, 3, 2, 31, 29, 173, DateTimeKind.Local).AddTicks(9083), new DateTime(2022, 8, 6, 5, 27, 16, 719, DateTimeKind.Local).AddTicks(4791), 78, 26.317496015384m },
                    { 269, 127, new DateTime(2022, 5, 30, 17, 39, 12, 776, DateTimeKind.Local).AddTicks(472), new DateTime(2022, 11, 17, 8, 53, 13, 306, DateTimeKind.Local).AddTicks(6175), 45, 20.3029425671088m },
                    { 270, 112, new DateTime(2022, 7, 29, 7, 58, 11, 559, DateTimeKind.Local).AddTicks(3680), new DateTime(2022, 11, 2, 16, 2, 20, 1, DateTimeKind.Local).AddTicks(4192), 9, 16.0548302426425m },
                    { 271, 33, new DateTime(2022, 10, 25, 23, 20, 7, 886, DateTimeKind.Local).AddTicks(5544), new DateTime(2022, 8, 19, 12, 52, 30, 918, DateTimeKind.Local).AddTicks(9538), 43, 8.33968251932154m },
                    { 272, 14, new DateTime(2022, 8, 11, 18, 47, 28, 222, DateTimeKind.Local).AddTicks(7189), new DateTime(2022, 12, 4, 0, 55, 1, 241, DateTimeKind.Local).AddTicks(7972), 63, 26.7362787162013m },
                    { 273, 10, new DateTime(2022, 4, 19, 6, 55, 51, 881, DateTimeKind.Local).AddTicks(8877), new DateTime(2022, 11, 14, 18, 3, 23, 365, DateTimeKind.Local).AddTicks(2085), 85, 8.32906048844642m },
                    { 274, 33, new DateTime(2022, 7, 2, 18, 0, 51, 867, DateTimeKind.Local).AddTicks(1378), new DateTime(2022, 12, 26, 12, 46, 33, 579, DateTimeKind.Local).AddTicks(1943), 39, 25.6965917726904m },
                    { 275, 48, new DateTime(2022, 5, 9, 20, 55, 10, 127, DateTimeKind.Local).AddTicks(5774), new DateTime(2022, 11, 11, 8, 7, 53, 525, DateTimeKind.Local).AddTicks(383), 4, 5.0623802635281m },
                    { 276, 89, new DateTime(2023, 1, 11, 7, 55, 5, 211, DateTimeKind.Local).AddTicks(812), new DateTime(2022, 6, 7, 8, 52, 51, 236, DateTimeKind.Local).AddTicks(3790), 91, 1.47446949037478m },
                    { 277, 118, new DateTime(2022, 4, 24, 13, 55, 37, 902, DateTimeKind.Local).AddTicks(4060), new DateTime(2022, 7, 21, 16, 8, 55, 375, DateTimeKind.Local).AddTicks(1850), 3, 9.61505912849348m },
                    { 278, 90, new DateTime(2022, 10, 25, 15, 49, 22, 686, DateTimeKind.Local).AddTicks(322), new DateTime(2022, 8, 1, 6, 38, 58, 676, DateTimeKind.Local).AddTicks(8490), 72, 8.05368575216329m },
                    { 279, 107, new DateTime(2023, 2, 25, 3, 45, 29, 177, DateTimeKind.Local).AddTicks(8451), new DateTime(2023, 1, 24, 9, 2, 14, 243, DateTimeKind.Local).AddTicks(9108), 92, 7.46240738536756m },
                    { 280, 141, new DateTime(2023, 2, 14, 5, 44, 16, 503, DateTimeKind.Local).AddTicks(9866), new DateTime(2023, 1, 20, 18, 7, 42, 272, DateTimeKind.Local).AddTicks(9266), 1, 25.4724205185583m },
                    { 281, 32, new DateTime(2022, 9, 20, 0, 40, 30, 842, DateTimeKind.Local).AddTicks(7881), new DateTime(2022, 7, 30, 0, 6, 59, 744, DateTimeKind.Local).AddTicks(6233), 56, 20.3139333240987m },
                    { 282, 56, new DateTime(2022, 12, 23, 7, 52, 36, 994, DateTimeKind.Local).AddTicks(1504), new DateTime(2023, 1, 22, 4, 31, 42, 466, DateTimeKind.Local).AddTicks(6910), 37, 7.41659006884613m },
                    { 283, 87, new DateTime(2022, 11, 28, 19, 33, 7, 761, DateTimeKind.Local).AddTicks(1652), new DateTime(2022, 7, 9, 13, 24, 10, 545, DateTimeKind.Local).AddTicks(8434), 6, 7.44338447919526m },
                    { 284, 44, new DateTime(2022, 9, 29, 1, 9, 24, 130, DateTimeKind.Local).AddTicks(7969), new DateTime(2022, 6, 16, 9, 13, 45, 41, DateTimeKind.Local).AddTicks(3783), 82, 23.1303284200472m },
                    { 285, 93, new DateTime(2022, 8, 27, 5, 11, 0, 459, DateTimeKind.Local).AddTicks(3791), new DateTime(2022, 6, 14, 6, 5, 54, 35, DateTimeKind.Local).AddTicks(8838), 96, 23.8939243969361m },
                    { 286, 142, new DateTime(2022, 8, 23, 19, 3, 41, 755, DateTimeKind.Local).AddTicks(175), new DateTime(2023, 1, 14, 12, 27, 57, 879, DateTimeKind.Local).AddTicks(4496), 12, 1.9412870188416m },
                    { 287, 43, new DateTime(2022, 10, 13, 12, 17, 18, 655, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 8, 14, 11, 24, 57, 725, DateTimeKind.Local).AddTicks(9840), 59, 25.8845687439041m },
                    { 288, 85, new DateTime(2022, 12, 26, 18, 28, 23, 207, DateTimeKind.Local).AddTicks(8705), new DateTime(2023, 3, 12, 10, 13, 34, 1, DateTimeKind.Local).AddTicks(2807), 8, 1.25635555835824m },
                    { 289, 106, new DateTime(2022, 6, 1, 6, 33, 24, 301, DateTimeKind.Local).AddTicks(7729), new DateTime(2022, 8, 5, 13, 20, 32, 138, DateTimeKind.Local).AddTicks(7094), 15, 20.6190250632698m },
                    { 290, 83, new DateTime(2022, 10, 18, 0, 54, 54, 876, DateTimeKind.Local).AddTicks(2976), new DateTime(2022, 8, 21, 8, 33, 3, 857, DateTimeKind.Local).AddTicks(2030), 2, 5.31048412901342m },
                    { 291, 113, new DateTime(2022, 8, 11, 6, 46, 58, 476, DateTimeKind.Local).AddTicks(9216), new DateTime(2023, 2, 22, 10, 18, 19, 496, DateTimeKind.Local).AddTicks(2563), 48, 8.82589433737816m },
                    { 292, 106, new DateTime(2022, 5, 24, 4, 46, 37, 147, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 8, 31, 15, 15, 25, 881, DateTimeKind.Local).AddTicks(9727), 22, 9.29516974563334m },
                    { 293, 46, new DateTime(2023, 1, 8, 20, 41, 29, 858, DateTimeKind.Local).AddTicks(9487), new DateTime(2022, 11, 26, 13, 10, 32, 927, DateTimeKind.Local).AddTicks(4810), 17, 7.64024305229284m },
                    { 294, 50, new DateTime(2023, 3, 2, 3, 1, 10, 71, DateTimeKind.Local).AddTicks(3883), new DateTime(2022, 9, 5, 8, 15, 35, 582, DateTimeKind.Local).AddTicks(652), 30, 22.9554076615422m },
                    { 295, 48, new DateTime(2023, 3, 1, 12, 26, 2, 253, DateTimeKind.Local).AddTicks(5753), new DateTime(2023, 3, 18, 17, 0, 42, 361, DateTimeKind.Local).AddTicks(3780), 57, 9.9750679781944m },
                    { 296, 97, new DateTime(2023, 2, 20, 6, 52, 5, 713, DateTimeKind.Local).AddTicks(6047), new DateTime(2022, 10, 18, 9, 42, 58, 481, DateTimeKind.Local).AddTicks(3738), 87, 11.38089918304m },
                    { 297, 43, new DateTime(2022, 9, 2, 6, 4, 54, 307, DateTimeKind.Local).AddTicks(3974), new DateTime(2023, 3, 7, 8, 24, 32, 881, DateTimeKind.Local).AddTicks(4690), 28, 8.34324749972624m },
                    { 298, 128, new DateTime(2022, 6, 22, 14, 48, 51, 769, DateTimeKind.Local).AddTicks(1219), new DateTime(2022, 11, 17, 13, 52, 18, 124, DateTimeKind.Local).AddTicks(8448), 42, 3.88274686303585m },
                    { 299, 148, new DateTime(2022, 12, 3, 20, 26, 28, 609, DateTimeKind.Local).AddTicks(4500), new DateTime(2022, 12, 4, 15, 2, 15, 972, DateTimeKind.Local).AddTicks(1652), 13, 18.4114237508723m },
                    { 300, 76, new DateTime(2023, 4, 3, 4, 37, 3, 751, DateTimeKind.Local).AddTicks(3563), new DateTime(2022, 5, 28, 18, 35, 24, 557, DateTimeKind.Local).AddTicks(2022), 27, 24.5699461976854m },
                    { 301, 133, new DateTime(2022, 10, 13, 7, 45, 21, 444, DateTimeKind.Local).AddTicks(8213), new DateTime(2022, 7, 7, 12, 27, 31, 822, DateTimeKind.Local).AddTicks(9641), 39, 15.5088783410077m },
                    { 302, 138, new DateTime(2022, 6, 29, 17, 38, 44, 503, DateTimeKind.Local).AddTicks(8768), new DateTime(2022, 6, 20, 17, 0, 32, 976, DateTimeKind.Local).AddTicks(6974), 30, 19.2094494177454m },
                    { 303, 40, new DateTime(2023, 2, 27, 12, 12, 31, 749, DateTimeKind.Local).AddTicks(2036), new DateTime(2022, 8, 4, 15, 31, 59, 515, DateTimeKind.Local).AddTicks(2755), 58, 15.5400967185659m },
                    { 304, 63, new DateTime(2022, 7, 2, 3, 2, 37, 497, DateTimeKind.Local).AddTicks(4542), new DateTime(2022, 6, 16, 22, 31, 25, 364, DateTimeKind.Local).AddTicks(6256), 43, 24.6164814283579m },
                    { 305, 28, new DateTime(2022, 6, 1, 14, 34, 24, 300, DateTimeKind.Local).AddTicks(9859), new DateTime(2022, 5, 11, 7, 50, 59, 574, DateTimeKind.Local).AddTicks(5680), 60, 24.5451688840913m },
                    { 306, 119, new DateTime(2023, 1, 29, 12, 38, 52, 943, DateTimeKind.Local).AddTicks(1265), new DateTime(2022, 12, 23, 1, 10, 23, 495, DateTimeKind.Local).AddTicks(4518), 9, 7.46763933234927m },
                    { 307, 129, new DateTime(2023, 1, 9, 14, 18, 31, 947, DateTimeKind.Local).AddTicks(3302), new DateTime(2022, 12, 22, 5, 16, 32, 101, DateTimeKind.Local).AddTicks(6167), 49, 20.205203418779m },
                    { 308, 115, new DateTime(2022, 12, 10, 3, 4, 22, 5, DateTimeKind.Local).AddTicks(1786), new DateTime(2023, 3, 24, 1, 42, 17, 337, DateTimeKind.Local).AddTicks(1387), 97, 26.585009208266m },
                    { 309, 37, new DateTime(2022, 8, 7, 12, 10, 47, 97, DateTimeKind.Local).AddTicks(1318), new DateTime(2022, 4, 23, 17, 48, 12, 792, DateTimeKind.Local).AddTicks(8800), 29, 5.59398047475794m },
                    { 310, 57, new DateTime(2023, 2, 3, 12, 6, 11, 510, DateTimeKind.Local).AddTicks(8186), new DateTime(2022, 12, 7, 23, 45, 44, 121, DateTimeKind.Local).AddTicks(2779), 14, 15.1545583618054m },
                    { 311, 120, new DateTime(2022, 10, 3, 23, 18, 35, 891, DateTimeKind.Local).AddTicks(9283), new DateTime(2023, 2, 20, 13, 38, 23, 425, DateTimeKind.Local).AddTicks(5368), 49, 14.1056118100513m },
                    { 312, 18, new DateTime(2022, 4, 20, 9, 10, 35, 705, DateTimeKind.Local).AddTicks(6895), new DateTime(2022, 8, 2, 0, 17, 27, 671, DateTimeKind.Local).AddTicks(6564), 72, 4.86647912124193m },
                    { 313, 81, new DateTime(2022, 7, 10, 3, 10, 47, 43, DateTimeKind.Local).AddTicks(7820), new DateTime(2023, 3, 19, 17, 26, 52, 787, DateTimeKind.Local).AddTicks(7667), 20, 2.48254691815281m },
                    { 314, 16, new DateTime(2022, 6, 28, 12, 55, 27, 518, DateTimeKind.Local).AddTicks(1363), new DateTime(2022, 9, 8, 17, 47, 30, 205, DateTimeKind.Local).AddTicks(763), 63, 2.66278640309831m },
                    { 315, 30, new DateTime(2023, 1, 1, 23, 25, 0, 249, DateTimeKind.Local).AddTicks(3584), new DateTime(2022, 11, 7, 0, 7, 14, 442, DateTimeKind.Local).AddTicks(8966), 68, 15.6207595723566m },
                    { 316, 73, new DateTime(2022, 6, 7, 4, 28, 59, 911, DateTimeKind.Local).AddTicks(7714), new DateTime(2022, 6, 22, 6, 26, 42, 96, DateTimeKind.Local).AddTicks(7645), 66, 10.7895352005658m },
                    { 317, 11, new DateTime(2022, 11, 15, 22, 36, 51, 97, DateTimeKind.Local).AddTicks(165), new DateTime(2023, 2, 9, 20, 10, 43, 929, DateTimeKind.Local).AddTicks(2375), 92, 24.1847791150368m },
                    { 318, 122, new DateTime(2022, 8, 5, 0, 29, 28, 335, DateTimeKind.Local).AddTicks(23), new DateTime(2023, 1, 26, 2, 46, 34, 244, DateTimeKind.Local).AddTicks(2009), 73, 25.7943071754664m },
                    { 319, 78, new DateTime(2022, 11, 5, 6, 50, 31, 112, DateTimeKind.Local).AddTicks(2728), new DateTime(2023, 1, 2, 1, 55, 14, 914, DateTimeKind.Local).AddTicks(8159), 99, 14.3780217882723m },
                    { 320, 10, new DateTime(2022, 9, 11, 16, 14, 24, 46, DateTimeKind.Local).AddTicks(2612), new DateTime(2022, 12, 1, 23, 5, 18, 526, DateTimeKind.Local).AddTicks(2253), 26, 29.8197675825249m },
                    { 321, 85, new DateTime(2023, 3, 3, 2, 21, 33, 790, DateTimeKind.Local).AddTicks(5859), new DateTime(2022, 11, 10, 23, 56, 9, 26, DateTimeKind.Local).AddTicks(5599), 87, 4.5521807481164m },
                    { 322, 41, new DateTime(2022, 11, 7, 22, 11, 40, 173, DateTimeKind.Local).AddTicks(531), new DateTime(2023, 2, 10, 5, 28, 43, 447, DateTimeKind.Local).AddTicks(9284), 100, 8.38878265404073m },
                    { 323, 14, new DateTime(2022, 12, 25, 0, 5, 33, 756, DateTimeKind.Local).AddTicks(4306), new DateTime(2022, 5, 8, 0, 46, 38, 286, DateTimeKind.Local).AddTicks(6973), 45, 9.92522889431756m },
                    { 324, 114, new DateTime(2022, 8, 2, 23, 26, 46, 581, DateTimeKind.Local).AddTicks(8880), new DateTime(2023, 4, 13, 21, 57, 55, 266, DateTimeKind.Local).AddTicks(4862), 9, 2.28528859223666m },
                    { 325, 108, new DateTime(2023, 1, 20, 9, 5, 17, 504, DateTimeKind.Local).AddTicks(6759), new DateTime(2022, 8, 21, 7, 45, 24, 243, DateTimeKind.Local).AddTicks(5677), 95, 14.0007902129966m },
                    { 326, 122, new DateTime(2022, 4, 23, 19, 14, 23, 47, DateTimeKind.Local).AddTicks(5274), new DateTime(2022, 11, 27, 3, 0, 12, 812, DateTimeKind.Local).AddTicks(8982), 71, 8.92730174519834m },
                    { 327, 83, new DateTime(2023, 3, 15, 23, 9, 25, 96, DateTimeKind.Local).AddTicks(6939), new DateTime(2023, 3, 7, 22, 1, 36, 190, DateTimeKind.Local).AddTicks(8202), 84, 22.8486662616433m },
                    { 328, 78, new DateTime(2022, 12, 10, 11, 24, 22, 625, DateTimeKind.Local).AddTicks(601), new DateTime(2022, 9, 5, 4, 1, 48, 725, DateTimeKind.Local).AddTicks(3039), 67, 17.0467324527444m },
                    { 329, 138, new DateTime(2022, 9, 19, 17, 8, 59, 208, DateTimeKind.Local).AddTicks(1123), new DateTime(2023, 3, 13, 19, 37, 32, 470, DateTimeKind.Local).AddTicks(1712), 61, 5.03928612695284m },
                    { 330, 65, new DateTime(2022, 6, 19, 12, 18, 55, 834, DateTimeKind.Local).AddTicks(9506), new DateTime(2022, 8, 25, 4, 15, 15, 909, DateTimeKind.Local).AddTicks(9049), 36, 24.2123718445357m },
                    { 331, 36, new DateTime(2022, 7, 21, 5, 55, 54, 544, DateTimeKind.Local).AddTicks(6262), new DateTime(2022, 8, 26, 19, 59, 26, 938, DateTimeKind.Local).AddTicks(5225), 64, 12.5774326960856m },
                    { 332, 114, new DateTime(2023, 2, 27, 22, 27, 21, 396, DateTimeKind.Local).AddTicks(5349), new DateTime(2023, 1, 21, 15, 38, 9, 829, DateTimeKind.Local).AddTicks(5927), 51, 16.3277054659888m },
                    { 333, 66, new DateTime(2022, 12, 11, 8, 0, 14, 289, DateTimeKind.Local).AddTicks(4937), new DateTime(2022, 10, 1, 22, 50, 52, 991, DateTimeKind.Local).AddTicks(2960), 82, 29.8156710784645m },
                    { 334, 142, new DateTime(2022, 8, 15, 13, 5, 38, 162, DateTimeKind.Local).AddTicks(9969), new DateTime(2023, 3, 26, 3, 18, 2, 664, DateTimeKind.Local).AddTicks(7698), 83, 12.9539078273944m },
                    { 335, 111, new DateTime(2022, 9, 12, 17, 10, 54, 910, DateTimeKind.Local).AddTicks(3384), new DateTime(2022, 11, 5, 3, 3, 12, 668, DateTimeKind.Local).AddTicks(6729), 59, 23.6570572069574m },
                    { 336, 50, new DateTime(2022, 10, 9, 6, 13, 31, 177, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 5, 12, 12, 34, 15, 987, DateTimeKind.Local).AddTicks(7460), 19, 21.0417475426296m },
                    { 337, 105, new DateTime(2022, 12, 13, 1, 6, 25, 177, DateTimeKind.Local).AddTicks(1856), new DateTime(2023, 2, 11, 13, 19, 10, 331, DateTimeKind.Local).AddTicks(123), 75, 7.72476322387051m },
                    { 338, 92, new DateTime(2022, 8, 23, 2, 37, 37, 448, DateTimeKind.Local).AddTicks(4130), new DateTime(2022, 10, 11, 22, 41, 48, 946, DateTimeKind.Local).AddTicks(5933), 19, 2.8851682849864m },
                    { 339, 90, new DateTime(2023, 4, 8, 10, 7, 10, 798, DateTimeKind.Local).AddTicks(1591), new DateTime(2022, 10, 28, 2, 11, 11, 920, DateTimeKind.Local).AddTicks(6228), 90, 6.97569927668522m },
                    { 340, 52, new DateTime(2022, 5, 29, 8, 31, 42, 658, DateTimeKind.Local).AddTicks(3565), new DateTime(2023, 3, 17, 16, 22, 3, 274, DateTimeKind.Local).AddTicks(4006), 8, 27.1096479492931m },
                    { 341, 129, new DateTime(2022, 12, 30, 21, 20, 3, 386, DateTimeKind.Local).AddTicks(6005), new DateTime(2023, 1, 24, 23, 42, 15, 631, DateTimeKind.Local).AddTicks(6149), 42, 13.3358973554564m },
                    { 342, 122, new DateTime(2022, 7, 3, 4, 46, 57, 505, DateTimeKind.Local).AddTicks(9891), new DateTime(2022, 8, 19, 0, 30, 52, 513, DateTimeKind.Local).AddTicks(3220), 17, 16.8972651233204m },
                    { 343, 78, new DateTime(2022, 10, 11, 15, 31, 12, 35, DateTimeKind.Local).AddTicks(6530), new DateTime(2022, 9, 1, 5, 18, 36, 46, DateTimeKind.Local).AddTicks(9122), 25, 8.00127692511893m },
                    { 344, 57, new DateTime(2022, 11, 1, 8, 27, 32, 582, DateTimeKind.Local).AddTicks(8143), new DateTime(2022, 12, 27, 6, 47, 48, 669, DateTimeKind.Local).AddTicks(7046), 84, 9.69538174522246m },
                    { 345, 122, new DateTime(2022, 5, 24, 3, 40, 53, 465, DateTimeKind.Local).AddTicks(1532), new DateTime(2022, 6, 26, 7, 44, 24, 329, DateTimeKind.Local).AddTicks(9457), 72, 6.88115883063537m },
                    { 346, 144, new DateTime(2023, 3, 30, 11, 28, 32, 763, DateTimeKind.Local).AddTicks(3850), new DateTime(2023, 1, 31, 6, 11, 57, 899, DateTimeKind.Local).AddTicks(349), 42, 28.9891677135655m },
                    { 347, 126, new DateTime(2022, 8, 23, 8, 58, 15, 824, DateTimeKind.Local).AddTicks(6824), new DateTime(2023, 1, 22, 3, 44, 28, 831, DateTimeKind.Local).AddTicks(775), 80, 11.8370394271408m },
                    { 348, 31, new DateTime(2022, 4, 21, 10, 54, 26, 226, DateTimeKind.Local).AddTicks(5494), new DateTime(2023, 1, 19, 14, 11, 3, 532, DateTimeKind.Local).AddTicks(691), 92, 24.6245217739238m },
                    { 349, 77, new DateTime(2023, 4, 6, 15, 46, 42, 59, DateTimeKind.Local).AddTicks(2248), new DateTime(2022, 12, 15, 21, 36, 7, 266, DateTimeKind.Local).AddTicks(5404), 86, 23.1859135669486m },
                    { 350, 45, new DateTime(2022, 7, 13, 0, 14, 38, 467, DateTimeKind.Local).AddTicks(5014), new DateTime(2022, 5, 11, 13, 4, 43, 46, DateTimeKind.Local).AddTicks(1569), 4, 25.6382355140266m },
                    { 351, 103, new DateTime(2022, 5, 12, 16, 45, 27, 564, DateTimeKind.Local).AddTicks(4680), new DateTime(2022, 8, 13, 23, 38, 19, 729, DateTimeKind.Local).AddTicks(4103), 91, 1.7535939309175m },
                    { 352, 4, new DateTime(2022, 8, 14, 2, 0, 13, 765, DateTimeKind.Local).AddTicks(3110), new DateTime(2022, 10, 11, 13, 56, 33, 206, DateTimeKind.Local).AddTicks(8816), 10, 12.993491722738m },
                    { 353, 109, new DateTime(2022, 7, 17, 5, 56, 56, 242, DateTimeKind.Local).AddTicks(1363), new DateTime(2023, 1, 10, 8, 21, 37, 87, DateTimeKind.Local).AddTicks(8737), 14, 28.5603191332917m },
                    { 354, 12, new DateTime(2022, 8, 16, 8, 25, 59, 196, DateTimeKind.Local).AddTicks(8535), new DateTime(2022, 10, 29, 11, 27, 58, 750, DateTimeKind.Local).AddTicks(4651), 45, 18.6896391706724m },
                    { 355, 13, new DateTime(2022, 11, 9, 8, 7, 38, 27, DateTimeKind.Local).AddTicks(8121), new DateTime(2022, 12, 15, 12, 20, 51, 383, DateTimeKind.Local).AddTicks(8730), 81, 7.04583632683633m },
                    { 356, 84, new DateTime(2022, 7, 20, 16, 49, 24, 302, DateTimeKind.Local).AddTicks(3595), new DateTime(2023, 3, 30, 18, 58, 55, 730, DateTimeKind.Local).AddTicks(6996), 17, 28.5930129596116m },
                    { 357, 42, new DateTime(2022, 7, 10, 5, 9, 18, 521, DateTimeKind.Local).AddTicks(1305), new DateTime(2022, 12, 17, 5, 12, 22, 751, DateTimeKind.Local).AddTicks(8757), 53, 6.8148837153154m },
                    { 358, 19, new DateTime(2023, 1, 9, 18, 38, 8, 867, DateTimeKind.Local).AddTicks(6196), new DateTime(2022, 11, 12, 23, 2, 39, 339, DateTimeKind.Local).AddTicks(6218), 36, 11.97146784774m },
                    { 359, 145, new DateTime(2022, 5, 24, 7, 7, 57, 598, DateTimeKind.Local).AddTicks(3542), new DateTime(2022, 7, 22, 16, 40, 10, 620, DateTimeKind.Local).AddTicks(2334), 5, 23.2049443341586m },
                    { 360, 57, new DateTime(2023, 3, 8, 8, 34, 16, 616, DateTimeKind.Local).AddTicks(4948), new DateTime(2022, 7, 11, 3, 35, 15, 408, DateTimeKind.Local).AddTicks(8320), 3, 3.29674133850263m },
                    { 361, 21, new DateTime(2023, 3, 13, 22, 2, 20, 612, DateTimeKind.Local).AddTicks(6419), new DateTime(2023, 2, 2, 13, 41, 45, 289, DateTimeKind.Local).AddTicks(396), 17, 7.61769162318709m },
                    { 362, 109, new DateTime(2022, 7, 1, 9, 17, 21, 681, DateTimeKind.Local).AddTicks(7370), new DateTime(2022, 7, 6, 8, 41, 38, 403, DateTimeKind.Local).AddTicks(8826), 46, 26.2106506118071m },
                    { 363, 85, new DateTime(2022, 10, 6, 16, 13, 45, 556, DateTimeKind.Local).AddTicks(3347), new DateTime(2022, 5, 4, 6, 21, 13, 521, DateTimeKind.Local).AddTicks(314), 85, 16.4812296957843m },
                    { 364, 64, new DateTime(2022, 7, 10, 0, 9, 50, 30, DateTimeKind.Local).AddTicks(5833), new DateTime(2022, 12, 8, 8, 53, 37, 263, DateTimeKind.Local).AddTicks(1930), 87, 26.7106711843182m },
                    { 365, 133, new DateTime(2023, 2, 22, 11, 22, 10, 206, DateTimeKind.Local).AddTicks(1231), new DateTime(2022, 6, 19, 5, 37, 11, 985, DateTimeKind.Local).AddTicks(4914), 95, 12.1427942093145m },
                    { 366, 52, new DateTime(2023, 2, 17, 11, 7, 52, 893, DateTimeKind.Local).AddTicks(3331), new DateTime(2023, 4, 10, 4, 10, 22, 108, DateTimeKind.Local).AddTicks(6995), 26, 3.85684588996788m },
                    { 367, 49, new DateTime(2023, 1, 28, 5, 54, 57, 791, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 10, 22, 23, 37, 10, 637, DateTimeKind.Local).AddTicks(8749), 46, 25.6478748646447m },
                    { 368, 140, new DateTime(2022, 11, 8, 9, 45, 36, 42, DateTimeKind.Local).AddTicks(9033), new DateTime(2022, 11, 9, 2, 51, 47, 882, DateTimeKind.Local).AddTicks(7715), 19, 17.3419122828023m },
                    { 369, 101, new DateTime(2023, 2, 12, 19, 43, 0, 599, DateTimeKind.Local).AddTicks(7762), new DateTime(2023, 4, 6, 3, 12, 49, 604, DateTimeKind.Local).AddTicks(3146), 98, 18.9536805182476m },
                    { 370, 81, new DateTime(2022, 9, 12, 4, 41, 46, 523, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 6, 26, 19, 2, 59, 591, DateTimeKind.Local).AddTicks(1545), 47, 16.5526819844364m },
                    { 371, 149, new DateTime(2022, 10, 21, 3, 29, 51, 106, DateTimeKind.Local).AddTicks(2805), new DateTime(2022, 7, 2, 7, 49, 36, 211, DateTimeKind.Local).AddTicks(3332), 49, 14.7832302687112m },
                    { 372, 48, new DateTime(2022, 9, 23, 15, 19, 22, 615, DateTimeKind.Local).AddTicks(5245), new DateTime(2022, 8, 31, 23, 52, 31, 418, DateTimeKind.Local).AddTicks(8066), 60, 29.0718155004005m },
                    { 373, 82, new DateTime(2022, 7, 1, 23, 34, 23, 52, DateTimeKind.Local).AddTicks(2301), new DateTime(2023, 2, 22, 13, 15, 30, 80, DateTimeKind.Local).AddTicks(3392), 20, 7.86218927516284m },
                    { 374, 43, new DateTime(2022, 10, 13, 2, 5, 53, 321, DateTimeKind.Local).AddTicks(9400), new DateTime(2022, 6, 21, 5, 9, 38, 977, DateTimeKind.Local).AddTicks(2091), 23, 18.7728969380061m },
                    { 375, 12, new DateTime(2022, 7, 18, 19, 40, 52, 821, DateTimeKind.Local).AddTicks(6807), new DateTime(2023, 2, 28, 16, 42, 31, 510, DateTimeKind.Local).AddTicks(7806), 98, 29.616595976839m },
                    { 376, 47, new DateTime(2022, 9, 10, 5, 42, 38, 467, DateTimeKind.Local).AddTicks(3004), new DateTime(2022, 5, 18, 19, 16, 22, 275, DateTimeKind.Local).AddTicks(5240), 51, 6.95856011526853m },
                    { 377, 14, new DateTime(2022, 4, 26, 14, 27, 45, 443, DateTimeKind.Local).AddTicks(4336), new DateTime(2023, 2, 4, 12, 30, 33, 311, DateTimeKind.Local).AddTicks(6678), 13, 11.6437923137802m },
                    { 378, 112, new DateTime(2022, 5, 26, 20, 33, 49, 994, DateTimeKind.Local).AddTicks(3949), new DateTime(2022, 11, 19, 23, 17, 47, 761, DateTimeKind.Local).AddTicks(2363), 26, 9.42130083528741m },
                    { 379, 52, new DateTime(2022, 12, 12, 4, 14, 45, 957, DateTimeKind.Local).AddTicks(1355), new DateTime(2023, 1, 8, 14, 21, 21, 176, DateTimeKind.Local).AddTicks(1987), 30, 17.0430877378443m },
                    { 380, 56, new DateTime(2022, 11, 14, 0, 13, 3, 142, DateTimeKind.Local).AddTicks(2516), new DateTime(2023, 2, 23, 15, 3, 36, 327, DateTimeKind.Local).AddTicks(3267), 86, 6.90744574157634m },
                    { 381, 89, new DateTime(2023, 1, 2, 23, 51, 11, 42, DateTimeKind.Local).AddTicks(9521), new DateTime(2022, 8, 26, 14, 4, 18, 807, DateTimeKind.Local).AddTicks(9785), 77, 18.1996505793321m },
                    { 382, 44, new DateTime(2023, 1, 31, 17, 4, 5, 848, DateTimeKind.Local).AddTicks(4089), new DateTime(2022, 8, 4, 22, 16, 2, 653, DateTimeKind.Local).AddTicks(1532), 15, 16.740971384378m },
                    { 383, 53, new DateTime(2023, 3, 28, 9, 59, 20, 673, DateTimeKind.Local).AddTicks(3342), new DateTime(2022, 11, 25, 3, 47, 27, 971, DateTimeKind.Local).AddTicks(4163), 17, 29.9026707652126m },
                    { 384, 70, new DateTime(2022, 12, 29, 13, 5, 29, 37, DateTimeKind.Local).AddTicks(9490), new DateTime(2023, 2, 13, 1, 1, 54, 191, DateTimeKind.Local).AddTicks(558), 80, 22.5836885554766m },
                    { 385, 87, new DateTime(2022, 8, 18, 3, 56, 49, 738, DateTimeKind.Local).AddTicks(9614), new DateTime(2022, 10, 13, 23, 55, 0, 499, DateTimeKind.Local).AddTicks(4482), 40, 6.3694465388444m },
                    { 386, 56, new DateTime(2022, 12, 2, 22, 22, 5, 728, DateTimeKind.Local).AddTicks(4373), new DateTime(2022, 10, 31, 12, 8, 38, 375, DateTimeKind.Local).AddTicks(2190), 35, 21.9742932012014m },
                    { 387, 58, new DateTime(2022, 6, 8, 10, 51, 5, 564, DateTimeKind.Local).AddTicks(35), new DateTime(2022, 5, 27, 2, 48, 10, 625, DateTimeKind.Local).AddTicks(9597), 66, 11.0373109226959m },
                    { 388, 36, new DateTime(2022, 4, 30, 2, 31, 59, 863, DateTimeKind.Local).AddTicks(5331), new DateTime(2022, 9, 6, 23, 14, 51, 455, DateTimeKind.Local).AddTicks(5476), 94, 9.13184357394215m },
                    { 389, 91, new DateTime(2022, 12, 4, 15, 47, 58, 17, DateTimeKind.Local).AddTicks(2681), new DateTime(2022, 5, 16, 9, 14, 43, 386, DateTimeKind.Local).AddTicks(5958), 66, 23.5137835432556m },
                    { 390, 144, new DateTime(2022, 7, 9, 17, 45, 17, 544, DateTimeKind.Local).AddTicks(6135), new DateTime(2022, 6, 14, 16, 42, 19, 716, DateTimeKind.Local).AddTicks(3806), 3, 4.32183396382948m },
                    { 391, 42, new DateTime(2023, 4, 4, 0, 44, 24, 808, DateTimeKind.Local).AddTicks(1067), new DateTime(2022, 5, 21, 20, 16, 43, 274, DateTimeKind.Local).AddTicks(3772), 89, 15.8306476740075m },
                    { 392, 75, new DateTime(2022, 9, 6, 6, 31, 22, 363, DateTimeKind.Local).AddTicks(760), new DateTime(2022, 6, 18, 23, 44, 48, 709, DateTimeKind.Local).AddTicks(7406), 69, 22.8400782944327m },
                    { 393, 26, new DateTime(2022, 5, 31, 14, 16, 40, 319, DateTimeKind.Local).AddTicks(7286), new DateTime(2023, 1, 3, 3, 43, 49, 489, DateTimeKind.Local).AddTicks(4972), 5, 10.0544245824456m },
                    { 394, 138, new DateTime(2022, 6, 28, 7, 54, 47, 217, DateTimeKind.Local).AddTicks(6483), new DateTime(2022, 11, 22, 7, 25, 23, 396, DateTimeKind.Local).AddTicks(2352), 71, 12.5361509810694m },
                    { 395, 124, new DateTime(2022, 4, 22, 3, 4, 9, 260, DateTimeKind.Local).AddTicks(6871), new DateTime(2022, 7, 14, 10, 34, 8, 646, DateTimeKind.Local).AddTicks(5009), 23, 1.23613962033763m },
                    { 396, 48, new DateTime(2022, 7, 13, 14, 14, 4, 772, DateTimeKind.Local).AddTicks(7591), new DateTime(2022, 5, 15, 9, 21, 15, 564, DateTimeKind.Local).AddTicks(4064), 44, 7.77596898801033m },
                    { 397, 67, new DateTime(2022, 7, 22, 0, 48, 53, 403, DateTimeKind.Local).AddTicks(1982), new DateTime(2023, 2, 4, 21, 28, 48, 110, DateTimeKind.Local).AddTicks(3943), 39, 1.7861334343666m },
                    { 398, 57, new DateTime(2023, 2, 23, 5, 53, 14, 983, DateTimeKind.Local).AddTicks(6171), new DateTime(2022, 11, 9, 17, 46, 0, 403, DateTimeKind.Local).AddTicks(7374), 11, 6.54268161393489m },
                    { 399, 124, new DateTime(2022, 9, 2, 18, 17, 29, 467, DateTimeKind.Local).AddTicks(7638), new DateTime(2023, 3, 23, 0, 16, 45, 525, DateTimeKind.Local).AddTicks(9886), 81, 12.1333708060856m },
                    { 400, 70, new DateTime(2022, 7, 9, 15, 51, 19, 415, DateTimeKind.Local).AddTicks(7527), new DateTime(2023, 2, 19, 3, 33, 26, 730, DateTimeKind.Local).AddTicks(9049), 34, 25.4036751317458m },
                    { 401, 5, new DateTime(2022, 6, 12, 14, 14, 49, 842, DateTimeKind.Local).AddTicks(4068), new DateTime(2022, 7, 10, 14, 8, 45, 320, DateTimeKind.Local).AddTicks(9079), 78, 22.1773196749999m },
                    { 402, 102, new DateTime(2022, 5, 23, 14, 33, 45, 305, DateTimeKind.Local).AddTicks(9742), new DateTime(2022, 7, 20, 12, 0, 11, 132, DateTimeKind.Local).AddTicks(95), 37, 3.25360481330777m },
                    { 403, 145, new DateTime(2022, 8, 5, 16, 14, 43, 535, DateTimeKind.Local).AddTicks(3190), new DateTime(2023, 2, 1, 16, 45, 45, 746, DateTimeKind.Local).AddTicks(3017), 81, 1.74041839343066m },
                    { 404, 2, new DateTime(2022, 11, 20, 21, 43, 40, 111, DateTimeKind.Local).AddTicks(2787), new DateTime(2022, 9, 20, 0, 41, 15, 15, DateTimeKind.Local).AddTicks(8328), 98, 3.92242073208151m },
                    { 405, 17, new DateTime(2022, 10, 10, 22, 55, 42, 308, DateTimeKind.Local).AddTicks(8000), new DateTime(2023, 1, 17, 18, 52, 28, 948, DateTimeKind.Local).AddTicks(2785), 52, 8.63952241088356m },
                    { 406, 63, new DateTime(2022, 7, 25, 18, 13, 52, 507, DateTimeKind.Local).AddTicks(2924), new DateTime(2022, 8, 15, 18, 2, 14, 338, DateTimeKind.Local).AddTicks(8000), 77, 23.0088992536168m },
                    { 407, 67, new DateTime(2022, 10, 24, 3, 55, 58, 996, DateTimeKind.Local).AddTicks(8047), new DateTime(2022, 5, 28, 6, 46, 15, 333, DateTimeKind.Local).AddTicks(5905), 3, 29.3899851933272m },
                    { 408, 111, new DateTime(2023, 3, 23, 20, 1, 19, 693, DateTimeKind.Local).AddTicks(9335), new DateTime(2022, 7, 14, 0, 14, 16, 603, DateTimeKind.Local).AddTicks(8152), 30, 23.4983830561307m },
                    { 409, 125, new DateTime(2022, 4, 24, 7, 29, 16, 512, DateTimeKind.Local).AddTicks(299), new DateTime(2022, 11, 18, 17, 12, 1, 957, DateTimeKind.Local).AddTicks(4353), 6, 5.03198458792148m },
                    { 410, 149, new DateTime(2022, 9, 25, 2, 33, 44, 531, DateTimeKind.Local).AddTicks(8393), new DateTime(2022, 7, 31, 7, 52, 29, 798, DateTimeKind.Local).AddTicks(1382), 48, 8.53205091691728m },
                    { 411, 150, new DateTime(2022, 11, 24, 15, 26, 39, 627, DateTimeKind.Local).AddTicks(1329), new DateTime(2023, 2, 26, 6, 28, 0, 788, DateTimeKind.Local).AddTicks(137), 55, 14.5259207370098m },
                    { 412, 142, new DateTime(2022, 10, 31, 19, 52, 10, 798, DateTimeKind.Local).AddTicks(5455), new DateTime(2022, 7, 1, 1, 56, 20, 801, DateTimeKind.Local).AddTicks(1831), 69, 29.5671525338932m },
                    { 413, 8, new DateTime(2022, 9, 27, 12, 59, 28, 301, DateTimeKind.Local).AddTicks(9089), new DateTime(2023, 1, 26, 5, 20, 33, 665, DateTimeKind.Local).AddTicks(2067), 43, 1.13173169752773m },
                    { 414, 79, new DateTime(2022, 11, 25, 2, 16, 18, 904, DateTimeKind.Local).AddTicks(5647), new DateTime(2022, 12, 5, 3, 21, 57, 88, DateTimeKind.Local).AddTicks(3961), 96, 7.47193159593437m },
                    { 415, 27, new DateTime(2022, 7, 21, 7, 29, 29, 331, DateTimeKind.Local).AddTicks(8840), new DateTime(2022, 5, 15, 19, 36, 30, 323, DateTimeKind.Local).AddTicks(1838), 31, 14.8369966903847m },
                    { 416, 2, new DateTime(2022, 11, 5, 20, 39, 58, 750, DateTimeKind.Local).AddTicks(4072), new DateTime(2023, 3, 22, 7, 43, 45, 998, DateTimeKind.Local).AddTicks(2111), 21, 14.6384349008719m },
                    { 417, 141, new DateTime(2023, 2, 22, 11, 34, 53, 287, DateTimeKind.Local).AddTicks(7572), new DateTime(2023, 2, 22, 7, 42, 46, 282, DateTimeKind.Local).AddTicks(205), 91, 19.591131538452m },
                    { 418, 150, new DateTime(2023, 3, 11, 15, 20, 30, 429, DateTimeKind.Local).AddTicks(2250), new DateTime(2022, 10, 6, 20, 31, 36, 978, DateTimeKind.Local).AddTicks(8406), 4, 4.49734675611119m },
                    { 419, 121, new DateTime(2022, 8, 5, 13, 22, 5, 829, DateTimeKind.Local).AddTicks(8995), new DateTime(2022, 7, 9, 21, 48, 4, 761, DateTimeKind.Local).AddTicks(7654), 56, 10.9671583381495m },
                    { 420, 89, new DateTime(2022, 4, 21, 21, 6, 33, 16, DateTimeKind.Local).AddTicks(1979), new DateTime(2023, 3, 15, 2, 51, 25, 958, DateTimeKind.Local).AddTicks(3235), 3, 16.9077883824921m },
                    { 421, 103, new DateTime(2022, 10, 29, 7, 55, 46, 215, DateTimeKind.Local).AddTicks(7158), new DateTime(2023, 1, 15, 7, 3, 37, 136, DateTimeKind.Local).AddTicks(2878), 99, 10.2298499365483m },
                    { 422, 127, new DateTime(2022, 6, 26, 11, 44, 57, 251, DateTimeKind.Local).AddTicks(9801), new DateTime(2022, 10, 4, 17, 31, 41, 197, DateTimeKind.Local).AddTicks(6880), 19, 7.26277312547516m },
                    { 423, 93, new DateTime(2023, 3, 9, 14, 59, 58, 403, DateTimeKind.Local).AddTicks(8885), new DateTime(2022, 12, 28, 22, 27, 48, 289, DateTimeKind.Local).AddTicks(6201), 45, 5.32534499334125m },
                    { 424, 96, new DateTime(2022, 10, 13, 3, 40, 39, 214, DateTimeKind.Local).AddTicks(3293), new DateTime(2022, 10, 3, 7, 2, 32, 352, DateTimeKind.Local).AddTicks(6160), 26, 27.1841572848702m },
                    { 425, 49, new DateTime(2023, 1, 21, 8, 47, 6, 654, DateTimeKind.Local).AddTicks(3351), new DateTime(2022, 7, 18, 14, 14, 53, 597, DateTimeKind.Local).AddTicks(7203), 56, 17.1295344507382m },
                    { 426, 47, new DateTime(2022, 7, 13, 16, 54, 49, 208, DateTimeKind.Local).AddTicks(5246), new DateTime(2022, 11, 11, 3, 38, 30, 170, DateTimeKind.Local).AddTicks(6560), 80, 4.4896349751662m },
                    { 427, 4, new DateTime(2022, 8, 17, 7, 11, 29, 746, DateTimeKind.Local).AddTicks(7695), new DateTime(2023, 2, 21, 6, 45, 46, 47, DateTimeKind.Local).AddTicks(7996), 95, 28.6185830891356m },
                    { 428, 94, new DateTime(2022, 12, 14, 0, 26, 23, 256, DateTimeKind.Local).AddTicks(2697), new DateTime(2022, 7, 29, 23, 45, 51, 40, DateTimeKind.Local).AddTicks(8957), 84, 27.1404636731097m },
                    { 429, 98, new DateTime(2022, 5, 11, 9, 38, 21, 999, DateTimeKind.Local).AddTicks(1593), new DateTime(2022, 10, 9, 11, 31, 51, 594, DateTimeKind.Local).AddTicks(8162), 20, 1.19149812019166m },
                    { 430, 29, new DateTime(2022, 5, 28, 3, 45, 33, 401, DateTimeKind.Local).AddTicks(8802), new DateTime(2023, 3, 26, 16, 19, 47, 311, DateTimeKind.Local).AddTicks(5818), 55, 3.22036177775526m },
                    { 431, 93, new DateTime(2022, 8, 2, 1, 8, 43, 450, DateTimeKind.Local).AddTicks(2216), new DateTime(2022, 11, 14, 14, 13, 51, 375, DateTimeKind.Local).AddTicks(6573), 14, 4.60231742862278m },
                    { 432, 121, new DateTime(2023, 1, 7, 18, 36, 7, 652, DateTimeKind.Local).AddTicks(2908), new DateTime(2022, 5, 16, 0, 31, 28, 916, DateTimeKind.Local).AddTicks(4161), 90, 10.1106520806931m },
                    { 433, 25, new DateTime(2023, 1, 27, 20, 19, 42, 34, DateTimeKind.Local).AddTicks(3996), new DateTime(2022, 8, 3, 4, 32, 19, 409, DateTimeKind.Local).AddTicks(8403), 30, 28.7710464141766m },
                    { 434, 37, new DateTime(2022, 12, 30, 15, 59, 10, 802, DateTimeKind.Local).AddTicks(1798), new DateTime(2022, 8, 12, 7, 8, 23, 14, DateTimeKind.Local).AddTicks(1368), 36, 20.7788641052792m },
                    { 435, 6, new DateTime(2022, 12, 27, 19, 28, 13, 906, DateTimeKind.Local).AddTicks(9949), new DateTime(2023, 2, 17, 20, 50, 0, 479, DateTimeKind.Local).AddTicks(9012), 93, 21.1633416996958m },
                    { 436, 99, new DateTime(2022, 8, 4, 0, 35, 17, 353, DateTimeKind.Local).AddTicks(5246), new DateTime(2022, 6, 21, 11, 25, 27, 895, DateTimeKind.Local).AddTicks(6393), 19, 18.8401162831168m },
                    { 437, 59, new DateTime(2023, 3, 8, 14, 2, 6, 595, DateTimeKind.Local).AddTicks(6211), new DateTime(2022, 9, 7, 6, 37, 5, 159, DateTimeKind.Local).AddTicks(6303), 28, 20.3429618792471m },
                    { 438, 149, new DateTime(2022, 4, 21, 21, 51, 9, 389, DateTimeKind.Local).AddTicks(3566), new DateTime(2022, 12, 5, 21, 11, 40, 319, DateTimeKind.Local).AddTicks(8883), 71, 20.309395100129m },
                    { 439, 27, new DateTime(2022, 9, 5, 0, 39, 44, 711, DateTimeKind.Local).AddTicks(6038), new DateTime(2023, 2, 9, 2, 8, 42, 272, DateTimeKind.Local).AddTicks(7177), 44, 22.0539620792016m },
                    { 440, 51, new DateTime(2022, 10, 2, 4, 47, 11, 214, DateTimeKind.Local).AddTicks(1055), new DateTime(2023, 2, 21, 4, 2, 20, 296, DateTimeKind.Local).AddTicks(3325), 61, 23.5791758387857m },
                    { 441, 112, new DateTime(2022, 6, 9, 10, 3, 33, 544, DateTimeKind.Local).AddTicks(8701), new DateTime(2022, 8, 14, 19, 56, 29, 573, DateTimeKind.Local).AddTicks(5260), 76, 20.6509639068274m },
                    { 442, 96, new DateTime(2022, 12, 7, 11, 27, 26, 769, DateTimeKind.Local).AddTicks(3537), new DateTime(2022, 5, 4, 10, 53, 41, 482, DateTimeKind.Local).AddTicks(1689), 41, 8.4355729069326m },
                    { 443, 39, new DateTime(2022, 9, 12, 17, 7, 23, 401, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 10, 10, 14, 13, 46, 124, DateTimeKind.Local).AddTicks(8473), 36, 7.32525665130175m },
                    { 444, 110, new DateTime(2022, 5, 31, 23, 30, 51, 823, DateTimeKind.Local).AddTicks(221), new DateTime(2022, 10, 24, 17, 55, 36, 888, DateTimeKind.Local).AddTicks(5850), 90, 14.2201846039289m },
                    { 445, 133, new DateTime(2023, 2, 24, 1, 13, 16, 1, DateTimeKind.Local).AddTicks(6895), new DateTime(2022, 10, 15, 16, 56, 50, 800, DateTimeKind.Local).AddTicks(2069), 92, 28.6575708950049m },
                    { 446, 100, new DateTime(2023, 1, 28, 17, 52, 57, 500, DateTimeKind.Local).AddTicks(3149), new DateTime(2022, 12, 25, 13, 53, 4, 90, DateTimeKind.Local).AddTicks(669), 70, 24.2876066086802m },
                    { 447, 129, new DateTime(2023, 1, 9, 15, 15, 19, 976, DateTimeKind.Local).AddTicks(1925), new DateTime(2023, 2, 9, 5, 10, 44, 135, DateTimeKind.Local).AddTicks(4405), 18, 1.8762466139964m },
                    { 448, 17, new DateTime(2023, 3, 21, 10, 48, 2, 741, DateTimeKind.Local).AddTicks(2258), new DateTime(2022, 9, 14, 1, 3, 9, 567, DateTimeKind.Local).AddTicks(4855), 63, 16.6719405863023m },
                    { 449, 23, new DateTime(2022, 11, 20, 13, 38, 37, 602, DateTimeKind.Local).AddTicks(5150), new DateTime(2022, 11, 7, 19, 28, 33, 864, DateTimeKind.Local).AddTicks(8625), 50, 19.5977882960452m },
                    { 450, 5, new DateTime(2022, 11, 16, 17, 57, 16, 580, DateTimeKind.Local).AddTicks(6290), new DateTime(2022, 8, 25, 2, 26, 10, 734, DateTimeKind.Local).AddTicks(1959), 81, 21.2453331574108m },
                    { 451, 24, new DateTime(2023, 1, 15, 8, 38, 33, 381, DateTimeKind.Local).AddTicks(6377), new DateTime(2022, 11, 2, 13, 28, 11, 637, DateTimeKind.Local).AddTicks(7376), 4, 11.1822908298145m },
                    { 452, 71, new DateTime(2022, 10, 27, 17, 43, 53, 406, DateTimeKind.Local).AddTicks(1508), new DateTime(2022, 7, 31, 15, 41, 5, 718, DateTimeKind.Local).AddTicks(3292), 40, 3.58469097663523m },
                    { 453, 21, new DateTime(2023, 1, 8, 23, 21, 8, 329, DateTimeKind.Local).AddTicks(5585), new DateTime(2022, 7, 27, 15, 56, 43, 924, DateTimeKind.Local).AddTicks(9902), 31, 1.30049130415891m },
                    { 454, 6, new DateTime(2022, 11, 1, 15, 52, 5, 545, DateTimeKind.Local).AddTicks(7325), new DateTime(2023, 3, 14, 4, 31, 59, 591, DateTimeKind.Local).AddTicks(3886), 20, 13.7915107032934m },
                    { 455, 82, new DateTime(2022, 10, 18, 2, 8, 26, 278, DateTimeKind.Local).AddTicks(9817), new DateTime(2022, 9, 27, 3, 39, 48, 807, DateTimeKind.Local).AddTicks(1629), 54, 11.5903143773585m },
                    { 456, 27, new DateTime(2022, 12, 19, 19, 22, 7, 568, DateTimeKind.Local).AddTicks(6765), new DateTime(2023, 1, 16, 17, 27, 42, 455, DateTimeKind.Local).AddTicks(1962), 38, 17.3022143077599m },
                    { 457, 1, new DateTime(2023, 4, 10, 5, 24, 2, 87, DateTimeKind.Local).AddTicks(2715), new DateTime(2022, 7, 19, 21, 21, 32, 509, DateTimeKind.Local).AddTicks(7419), 19, 6.38881893404372m },
                    { 458, 66, new DateTime(2022, 8, 14, 13, 40, 20, 22, DateTimeKind.Local).AddTicks(6515), new DateTime(2022, 5, 28, 7, 28, 25, 369, DateTimeKind.Local).AddTicks(8289), 33, 29.2182382636604m },
                    { 459, 75, new DateTime(2022, 10, 28, 3, 50, 30, 999, DateTimeKind.Local).AddTicks(9433), new DateTime(2022, 10, 1, 18, 21, 28, 843, DateTimeKind.Local).AddTicks(8169), 48, 2.22151435414754m },
                    { 460, 115, new DateTime(2022, 5, 20, 5, 32, 0, 665, DateTimeKind.Local).AddTicks(460), new DateTime(2022, 8, 1, 19, 30, 19, 236, DateTimeKind.Local).AddTicks(7055), 42, 22.9129280964696m },
                    { 461, 84, new DateTime(2022, 5, 30, 2, 54, 37, 409, DateTimeKind.Local).AddTicks(826), new DateTime(2022, 10, 18, 18, 7, 5, 297, DateTimeKind.Local).AddTicks(1460), 39, 11.1364327369268m },
                    { 462, 53, new DateTime(2022, 11, 25, 14, 15, 48, 529, DateTimeKind.Local).AddTicks(6811), new DateTime(2022, 10, 30, 6, 19, 2, 830, DateTimeKind.Local).AddTicks(3508), 85, 16.2177329698675m },
                    { 463, 47, new DateTime(2022, 5, 20, 21, 21, 51, 328, DateTimeKind.Local).AddTicks(1960), new DateTime(2023, 1, 11, 17, 24, 26, 617, DateTimeKind.Local).AddTicks(8053), 70, 13.0962724844644m },
                    { 464, 130, new DateTime(2023, 1, 7, 12, 27, 47, 657, DateTimeKind.Local).AddTicks(3299), new DateTime(2022, 6, 6, 16, 9, 16, 373, DateTimeKind.Local).AddTicks(267), 54, 18.5467360301675m },
                    { 465, 1, new DateTime(2023, 1, 8, 12, 26, 36, 187, DateTimeKind.Local).AddTicks(3105), new DateTime(2022, 11, 23, 1, 36, 28, 798, DateTimeKind.Local).AddTicks(661), 84, 18.0200593666943m },
                    { 466, 109, new DateTime(2022, 11, 27, 13, 4, 31, 192, DateTimeKind.Local).AddTicks(2332), new DateTime(2022, 6, 5, 7, 33, 27, 974, DateTimeKind.Local).AddTicks(8779), 46, 2.93742063533065m },
                    { 467, 58, new DateTime(2023, 1, 16, 10, 51, 5, 744, DateTimeKind.Local).AddTicks(4035), new DateTime(2022, 8, 3, 21, 19, 54, 976, DateTimeKind.Local).AddTicks(9919), 47, 21.3080766315995m },
                    { 468, 138, new DateTime(2022, 8, 12, 15, 51, 51, 273, DateTimeKind.Local).AddTicks(7311), new DateTime(2022, 7, 9, 3, 1, 35, 880, DateTimeKind.Local).AddTicks(7717), 58, 28.5889409755821m },
                    { 469, 119, new DateTime(2023, 2, 15, 12, 56, 1, 292, DateTimeKind.Local).AddTicks(1663), new DateTime(2022, 6, 22, 23, 43, 48, 25, DateTimeKind.Local).AddTicks(6865), 64, 3.86005553541624m },
                    { 470, 125, new DateTime(2022, 11, 20, 17, 38, 43, 48, DateTimeKind.Local).AddTicks(6552), new DateTime(2022, 6, 16, 15, 29, 55, 840, DateTimeKind.Local).AddTicks(8765), 30, 2.08965986046052m },
                    { 471, 84, new DateTime(2023, 3, 31, 12, 28, 5, 238, DateTimeKind.Local).AddTicks(1733), new DateTime(2023, 4, 11, 2, 49, 35, 721, DateTimeKind.Local).AddTicks(6560), 62, 27.2542344326049m },
                    { 472, 62, new DateTime(2022, 12, 9, 19, 38, 24, 662, DateTimeKind.Local).AddTicks(1721), new DateTime(2022, 9, 5, 0, 7, 49, 613, DateTimeKind.Local).AddTicks(8084), 54, 13.9391858568358m },
                    { 473, 92, new DateTime(2022, 8, 2, 1, 15, 32, 92, DateTimeKind.Local).AddTicks(3998), new DateTime(2022, 11, 17, 6, 48, 56, 597, DateTimeKind.Local).AddTicks(9051), 23, 1.68813932695937m },
                    { 474, 77, new DateTime(2023, 1, 14, 7, 57, 18, 852, DateTimeKind.Local).AddTicks(8248), new DateTime(2022, 8, 18, 3, 41, 5, 825, DateTimeKind.Local).AddTicks(2787), 50, 18.5330604304368m },
                    { 475, 3, new DateTime(2023, 4, 6, 15, 43, 38, 290, DateTimeKind.Local).AddTicks(1337), new DateTime(2022, 10, 29, 17, 15, 55, 653, DateTimeKind.Local).AddTicks(5034), 18, 4.55721908888147m },
                    { 476, 104, new DateTime(2022, 5, 26, 12, 59, 34, 209, DateTimeKind.Local).AddTicks(7493), new DateTime(2022, 7, 4, 20, 42, 29, 776, DateTimeKind.Local).AddTicks(3465), 11, 27.4092409300956m },
                    { 477, 21, new DateTime(2022, 9, 1, 17, 26, 18, 621, DateTimeKind.Local).AddTicks(4005), new DateTime(2022, 7, 17, 14, 31, 32, 872, DateTimeKind.Local).AddTicks(753), 64, 9.64703060903165m },
                    { 478, 69, new DateTime(2022, 9, 22, 3, 27, 31, 941, DateTimeKind.Local).AddTicks(5468), new DateTime(2023, 4, 15, 1, 10, 33, 686, DateTimeKind.Local).AddTicks(5822), 70, 9.2457625819795m },
                    { 479, 66, new DateTime(2022, 7, 5, 14, 28, 24, 287, DateTimeKind.Local).AddTicks(4638), new DateTime(2022, 5, 23, 21, 47, 40, 333, DateTimeKind.Local).AddTicks(6568), 61, 4.62227455594864m },
                    { 480, 56, new DateTime(2022, 12, 16, 15, 33, 22, 138, DateTimeKind.Local).AddTicks(2620), new DateTime(2023, 3, 27, 15, 27, 12, 808, DateTimeKind.Local).AddTicks(8632), 69, 17.9048481985219m },
                    { 481, 96, new DateTime(2022, 10, 26, 1, 40, 58, 160, DateTimeKind.Local).AddTicks(1748), new DateTime(2022, 4, 29, 14, 57, 53, 200, DateTimeKind.Local).AddTicks(3833), 4, 3.59415387653519m },
                    { 482, 40, new DateTime(2023, 1, 5, 1, 43, 46, 998, DateTimeKind.Local).AddTicks(8504), new DateTime(2023, 3, 1, 5, 22, 15, 336, DateTimeKind.Local).AddTicks(1250), 22, 13.4476989838832m },
                    { 483, 76, new DateTime(2022, 8, 25, 3, 54, 25, 753, DateTimeKind.Local).AddTicks(4005), new DateTime(2023, 1, 5, 2, 40, 14, 203, DateTimeKind.Local).AddTicks(9774), 54, 11.3872202904962m },
                    { 484, 141, new DateTime(2022, 7, 24, 22, 10, 3, 562, DateTimeKind.Local).AddTicks(3871), new DateTime(2022, 5, 13, 3, 31, 50, 164, DateTimeKind.Local).AddTicks(6166), 81, 12.3000309468114m },
                    { 485, 40, new DateTime(2022, 11, 29, 0, 15, 9, 777, DateTimeKind.Local).AddTicks(6023), new DateTime(2022, 11, 22, 6, 59, 29, 595, DateTimeKind.Local).AddTicks(8966), 67, 28.8042731588436m },
                    { 486, 91, new DateTime(2022, 5, 17, 13, 26, 43, 925, DateTimeKind.Local).AddTicks(8488), new DateTime(2022, 7, 8, 16, 14, 36, 391, DateTimeKind.Local).AddTicks(8800), 80, 2.84638725280926m },
                    { 487, 106, new DateTime(2022, 6, 24, 23, 57, 9, 513, DateTimeKind.Local).AddTicks(4578), new DateTime(2023, 3, 26, 13, 40, 47, 742, DateTimeKind.Local).AddTicks(1953), 5, 20.5839156111495m },
                    { 488, 54, new DateTime(2022, 4, 24, 10, 27, 10, 960, DateTimeKind.Local).AddTicks(3812), new DateTime(2022, 6, 26, 18, 54, 6, 8, DateTimeKind.Local).AddTicks(4182), 74, 19.2030400274606m },
                    { 489, 146, new DateTime(2022, 11, 10, 11, 41, 58, 149, DateTimeKind.Local).AddTicks(2826), new DateTime(2022, 10, 26, 15, 56, 15, 354, DateTimeKind.Local).AddTicks(6049), 69, 11.318257327175m },
                    { 490, 139, new DateTime(2022, 9, 19, 15, 7, 45, 960, DateTimeKind.Local).AddTicks(1660), new DateTime(2022, 12, 2, 2, 51, 10, 474, DateTimeKind.Local).AddTicks(9399), 22, 11.1169814268423m },
                    { 491, 75, new DateTime(2023, 1, 29, 6, 31, 5, 475, DateTimeKind.Local).AddTicks(9576), new DateTime(2023, 2, 4, 10, 45, 49, 427, DateTimeKind.Local).AddTicks(7855), 86, 25.1004176005367m },
                    { 492, 44, new DateTime(2023, 2, 2, 6, 19, 30, 498, DateTimeKind.Local).AddTicks(5172), new DateTime(2022, 8, 17, 15, 48, 38, 896, DateTimeKind.Local).AddTicks(104), 82, 19.1796402680099m },
                    { 493, 129, new DateTime(2023, 1, 22, 2, 22, 36, 79, DateTimeKind.Local).AddTicks(8161), new DateTime(2022, 11, 13, 10, 47, 58, 609, DateTimeKind.Local).AddTicks(7872), 71, 13.5058311108096m },
                    { 494, 140, new DateTime(2023, 1, 10, 3, 17, 58, 818, DateTimeKind.Local).AddTicks(7464), new DateTime(2022, 11, 10, 9, 46, 44, 920, DateTimeKind.Local).AddTicks(8416), 99, 7.37576229682992m },
                    { 495, 106, new DateTime(2022, 5, 14, 21, 24, 31, 308, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 10, 12, 14, 49, 24, 617, DateTimeKind.Local).AddTicks(817), 72, 2.5478952728408m },
                    { 496, 34, new DateTime(2022, 11, 23, 6, 35, 28, 549, DateTimeKind.Local).AddTicks(9348), new DateTime(2023, 2, 9, 7, 10, 28, 83, DateTimeKind.Local).AddTicks(6705), 46, 20.3469340876399m },
                    { 497, 126, new DateTime(2022, 9, 12, 13, 32, 47, 701, DateTimeKind.Local).AddTicks(3608), new DateTime(2022, 6, 17, 3, 54, 16, 913, DateTimeKind.Local).AddTicks(5168), 53, 29.5683308966539m },
                    { 498, 39, new DateTime(2022, 7, 31, 2, 57, 15, 565, DateTimeKind.Local).AddTicks(4272), new DateTime(2022, 7, 20, 6, 43, 2, 451, DateTimeKind.Local).AddTicks(1984), 51, 11.1158438265198m },
                    { 499, 2, new DateTime(2022, 10, 1, 5, 3, 21, 940, DateTimeKind.Local).AddTicks(6460), new DateTime(2022, 12, 29, 9, 24, 49, 911, DateTimeKind.Local).AddTicks(5661), 69, 20.7193757306244m },
                    { 500, 109, new DateTime(2022, 5, 1, 22, 5, 23, 306, DateTimeKind.Local).AddTicks(9593), new DateTime(2022, 7, 15, 2, 5, 43, 361, DateTimeKind.Local).AddTicks(1994), 40, 18.5562473400931m }
                });

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
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ContactId",
                table: "Baskets",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CountryId",
                table: "Contacts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
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
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
