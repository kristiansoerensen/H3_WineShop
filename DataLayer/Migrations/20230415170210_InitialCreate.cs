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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { 1, new DateTime(2023, 3, 6, 8, 55, 8, 345, DateTimeKind.Local).AddTicks(7996), new DateTime(2022, 10, 27, 8, 1, 21, 609, DateTimeKind.Local).AddTicks(7462), "Chrysler" },
                    { 2, new DateTime(2022, 8, 18, 19, 10, 14, 575, DateTimeKind.Local).AddTicks(7574), new DateTime(2022, 11, 8, 19, 51, 38, 295, DateTimeKind.Local).AddTicks(5805), "Polestar" },
                    { 3, new DateTime(2022, 5, 6, 6, 48, 9, 670, DateTimeKind.Local).AddTicks(3120), new DateTime(2023, 3, 9, 19, 56, 31, 530, DateTimeKind.Local).AddTicks(8859), "Ford" },
                    { 4, new DateTime(2023, 4, 5, 8, 10, 39, 884, DateTimeKind.Local).AddTicks(5438), new DateTime(2023, 1, 15, 6, 18, 3, 276, DateTimeKind.Local).AddTicks(8520), "Mazda" },
                    { 5, new DateTime(2022, 4, 19, 12, 40, 33, 640, DateTimeKind.Local).AddTicks(7466), new DateTime(2022, 8, 9, 19, 38, 15, 733, DateTimeKind.Local).AddTicks(7887), "Fiat" },
                    { 6, new DateTime(2023, 1, 2, 14, 19, 41, 603, DateTimeKind.Local).AddTicks(2186), new DateTime(2022, 9, 3, 4, 36, 6, 79, DateTimeKind.Local).AddTicks(671), "Mazda" },
                    { 7, new DateTime(2022, 8, 2, 15, 17, 50, 453, DateTimeKind.Local).AddTicks(9822), new DateTime(2022, 5, 4, 2, 58, 37, 308, DateTimeKind.Local).AddTicks(6978), "Mini" },
                    { 8, new DateTime(2023, 2, 16, 1, 29, 21, 401, DateTimeKind.Local).AddTicks(6778), new DateTime(2022, 11, 27, 8, 58, 10, 503, DateTimeKind.Local).AddTicks(7449), "Bentley" },
                    { 9, new DateTime(2023, 2, 12, 22, 30, 14, 269, DateTimeKind.Local).AddTicks(9048), new DateTime(2022, 6, 30, 1, 29, 30, 84, DateTimeKind.Local).AddTicks(8753), "Porsche" },
                    { 10, new DateTime(2022, 6, 19, 9, 18, 25, 833, DateTimeKind.Local).AddTicks(5872), new DateTime(2022, 5, 27, 5, 33, 46, 977, DateTimeKind.Local).AddTicks(9445), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 8, 55, 8, 349, DateTimeKind.Local).AddTicks(1637), null, new DateTime(2022, 10, 27, 8, 1, 21, 613, DateTimeKind.Local).AddTicks(1095), "Computers" },
                    { 2, new DateTime(2022, 8, 18, 19, 10, 14, 579, DateTimeKind.Local).AddTicks(1211), null, new DateTime(2022, 11, 8, 19, 51, 38, 298, DateTimeKind.Local).AddTicks(9442), "Shoes" },
                    { 3, new DateTime(2022, 5, 6, 6, 48, 9, 673, DateTimeKind.Local).AddTicks(6758), null, new DateTime(2023, 3, 9, 19, 56, 31, 534, DateTimeKind.Local).AddTicks(2497), "Garden" },
                    { 4, new DateTime(2023, 4, 5, 8, 10, 39, 887, DateTimeKind.Local).AddTicks(9076), null, new DateTime(2023, 1, 15, 6, 18, 3, 280, DateTimeKind.Local).AddTicks(2159), "Baby" },
                    { 5, new DateTime(2022, 4, 19, 12, 40, 33, 644, DateTimeKind.Local).AddTicks(558), null, new DateTime(2022, 8, 9, 19, 38, 15, 737, DateTimeKind.Local).AddTicks(977), "Garden" },
                    { 6, new DateTime(2023, 1, 2, 14, 19, 41, 606, DateTimeKind.Local).AddTicks(5274), null, new DateTime(2022, 9, 3, 4, 36, 6, 82, DateTimeKind.Local).AddTicks(3758), "Baby" },
                    { 7, new DateTime(2022, 8, 2, 15, 17, 50, 457, DateTimeKind.Local).AddTicks(2908), null, new DateTime(2022, 5, 4, 2, 58, 37, 312, DateTimeKind.Local).AddTicks(63), "Clothing" },
                    { 8, new DateTime(2023, 2, 16, 1, 29, 21, 404, DateTimeKind.Local).AddTicks(9866), null, new DateTime(2022, 11, 27, 8, 58, 10, 507, DateTimeKind.Local).AddTicks(537), "Music" },
                    { 9, new DateTime(2023, 2, 12, 22, 30, 14, 273, DateTimeKind.Local).AddTicks(2137), null, new DateTime(2022, 6, 30, 1, 29, 30, 88, DateTimeKind.Local).AddTicks(1842), "Jewelery" },
                    { 10, new DateTime(2022, 6, 19, 9, 18, 25, 836, DateTimeKind.Local).AddTicks(8962), null, new DateTime(2022, 5, 27, 5, 33, 46, 981, DateTimeKind.Local).AddTicks(2535), "Home" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 8, 55, 8, 335, DateTimeKind.Local).AddTicks(2203), new DateTime(2022, 10, 27, 8, 1, 21, 599, DateTimeKind.Local).AddTicks(1677), "Ecuador" },
                    { 2, new DateTime(2022, 8, 18, 19, 10, 14, 565, DateTimeKind.Local).AddTicks(1811), new DateTime(2022, 11, 8, 19, 51, 38, 285, DateTimeKind.Local).AddTicks(42), "Samoa" },
                    { 3, new DateTime(2022, 5, 6, 6, 48, 9, 659, DateTimeKind.Local).AddTicks(7359), new DateTime(2023, 3, 9, 19, 56, 31, 520, DateTimeKind.Local).AddTicks(3097), "Guatemala" },
                    { 4, new DateTime(2023, 4, 5, 8, 10, 39, 873, DateTimeKind.Local).AddTicks(9677), new DateTime(2023, 1, 15, 6, 18, 3, 266, DateTimeKind.Local).AddTicks(2759), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 19, 12, 40, 33, 630, DateTimeKind.Local).AddTicks(1159), new DateTime(2022, 8, 9, 19, 38, 15, 723, DateTimeKind.Local).AddTicks(1579), "Germany" },
                    { 6, new DateTime(2023, 1, 2, 14, 19, 41, 592, DateTimeKind.Local).AddTicks(5874), new DateTime(2022, 9, 3, 4, 36, 6, 68, DateTimeKind.Local).AddTicks(4359), "Niue" },
                    { 7, new DateTime(2022, 8, 2, 15, 17, 50, 443, DateTimeKind.Local).AddTicks(3509), new DateTime(2022, 5, 4, 2, 58, 37, 298, DateTimeKind.Local).AddTicks(664), "Philippines" },
                    { 8, new DateTime(2023, 2, 16, 1, 29, 21, 391, DateTimeKind.Local).AddTicks(466), new DateTime(2022, 11, 27, 8, 58, 10, 493, DateTimeKind.Local).AddTicks(1137), "Benin" },
                    { 9, new DateTime(2023, 2, 12, 22, 30, 14, 259, DateTimeKind.Local).AddTicks(2737), new DateTime(2022, 6, 30, 1, 29, 30, 74, DateTimeKind.Local).AddTicks(2441), "Seychelles" },
                    { 10, new DateTime(2022, 6, 19, 9, 18, 25, 822, DateTimeKind.Local).AddTicks(9560), new DateTime(2022, 5, 27, 5, 33, 46, 967, DateTimeKind.Local).AddTicks(3133), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "CountryId", "CreateDate", "Mobile", "ModifiedDate", "Name", "Phone", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Okunevaview", 3, new DateTime(2022, 6, 28, 13, 0, 51, 824, DateTimeKind.Local).AddTicks(3772), "(252) 696-3466 x42351", new DateTime(2022, 12, 10, 6, 55, 37, 158, DateTimeKind.Local).AddTicks(5057), "Bernita Konopelski", "888.457.6098", "239 Lucy Burg", "62677-9013" },
                    { 2, "Boganshire", 7, new DateTime(2022, 5, 4, 21, 44, 5, 241, DateTimeKind.Local).AddTicks(1698), "(808) 228-4311 x34353", new DateTime(2023, 3, 21, 19, 11, 54, 402, DateTimeKind.Local).AddTicks(715), "Golda Crist", "1-504-433-3068", "0353 Bo Field", "87211-4947" },
                    { 3, "Dareland", 2, new DateTime(2022, 5, 12, 19, 28, 54, 300, DateTimeKind.Local).AddTicks(4419), "352-226-6156 x3351", new DateTime(2022, 4, 18, 0, 47, 15, 599, DateTimeKind.Local).AddTicks(5854), "Dexter Kessler", "(818) 969-0327 x106", "869 Wilton Ports", "61001-0220" },
                    { 4, "Prohaskaburgh", 9, new DateTime(2022, 12, 25, 17, 48, 52, 620, DateTimeKind.Local).AddTicks(9260), "248.924.7120", new DateTime(2023, 2, 20, 11, 53, 30, 275, DateTimeKind.Local).AddTicks(9424), "Andrew Hermiston", "(745) 533-8336 x82933", "837 Efrain Run", "50338-0798" },
                    { 5, "South Joycefort", 3, new DateTime(2022, 5, 26, 10, 40, 25, 131, DateTimeKind.Local).AddTicks(9784), "1-769-371-0191", new DateTime(2023, 4, 4, 20, 37, 23, 703, DateTimeKind.Local).AddTicks(3187), "Vada Corwin", "246-526-2232 x5315", "3904 Trisha Village", "68305" },
                    { 6, "Ashamouth", 7, new DateTime(2022, 11, 18, 18, 2, 16, 499, DateTimeKind.Local).AddTicks(5009), "1-726-591-1553", new DateTime(2022, 4, 20, 7, 54, 19, 787, DateTimeKind.Local).AddTicks(247), "Jeffery Johns", "302.554.1978 x618", "1481 Betty Bypass", "61362-5302" },
                    { 7, "North Erinview", 6, new DateTime(2022, 9, 16, 15, 44, 32, 976, DateTimeKind.Local).AddTicks(4941), "565-824-6464", new DateTime(2022, 12, 7, 11, 46, 59, 815, DateTimeKind.Local).AddTicks(2574), "Jaylen Schinner", "322-546-9620", "84628 Beatty Club", "79943" },
                    { 8, "East Nelsonview", 3, new DateTime(2022, 5, 17, 2, 23, 47, 659, DateTimeKind.Local).AddTicks(5042), "442.312.9816 x66098", new DateTime(2023, 2, 18, 20, 11, 53, 308, DateTimeKind.Local).AddTicks(7560), "Eden Tromp", "(865) 389-9671", "99247 Cydney Creek", "04546" },
                    { 9, "Millsshire", 6, new DateTime(2022, 5, 29, 21, 46, 38, 24, DateTimeKind.Local).AddTicks(6755), "503.733.0063 x8679", new DateTime(2023, 2, 19, 18, 8, 55, 284, DateTimeKind.Local).AddTicks(7443), "Tracy Runolfsson", "1-477-640-5659", "2125 Ryan Lodge", "72157" },
                    { 10, "Howeborough", 5, new DateTime(2023, 2, 12, 0, 28, 1, 463, DateTimeKind.Local).AddTicks(9909), "(748) 605-1503 x77284", new DateTime(2022, 12, 11, 13, 28, 30, 731, DateTimeKind.Local).AddTicks(8876), "Ronny Sanford", "947-829-5808 x267", "2739 Delta Station", "92378" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 19, 22, 52, 17, 305, DateTimeKind.Local).AddTicks(8326), null, new DateTime(2022, 4, 19, 12, 40, 33, 648, DateTimeKind.Local).AddTicks(6667), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 6, 30, 1, 29, 30, 92, DateTimeKind.Local).AddTicks(8078), null, new DateTime(2022, 12, 24, 15, 43, 0, 572, DateTimeKind.Local).AddTicks(4972), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 6, 5, 5, 16, 225, DateTimeKind.Local).AddTicks(1809), null, new DateTime(2022, 4, 18, 1, 22, 48, 725, DateTimeKind.Local).AddTicks(6958), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 22, 13, 34, 57, 623, DateTimeKind.Local).AddTicks(5983), null, new DateTime(2023, 2, 18, 2, 46, 57, 73, DateTimeKind.Local).AddTicks(8190), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 16, 13, 30, 38, 226, DateTimeKind.Local).AddTicks(6999), null, new DateTime(2022, 5, 31, 2, 50, 23, 152, DateTimeKind.Local).AddTicks(8108), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 23, 21, 42, 3, 857, DateTimeKind.Local).AddTicks(6940), null, new DateTime(2022, 10, 26, 9, 49, 40, 753, DateTimeKind.Local).AddTicks(6070), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 1, 3, 53, 4, 888, DateTimeKind.Local).AddTicks(9254), null, new DateTime(2022, 10, 23, 22, 34, 56, 631, DateTimeKind.Local).AddTicks(1570), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 14, 22, 47, 26, 965, DateTimeKind.Local).AddTicks(3337), null, new DateTime(2023, 2, 10, 17, 15, 40, 461, DateTimeKind.Local).AddTicks(2690), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 8, 17, 28, 17, 508, DateTimeKind.Local).AddTicks(1025), null, new DateTime(2023, 4, 7, 14, 27, 33, 400, DateTimeKind.Local).AddTicks(6324), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 17, 20, 7, 29, 401, DateTimeKind.Local).AddTicks(2705), null, new DateTime(2023, 3, 27, 0, 19, 49, 935, DateTimeKind.Local).AddTicks(2886), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 8, 31, 20, 42, 12, 97, DateTimeKind.Local).AddTicks(8053), null, new DateTime(2022, 9, 8, 8, 39, 50, 719, DateTimeKind.Local).AddTicks(8760), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 2, 16, 0, 26, 211, DateTimeKind.Local).AddTicks(7498), null, new DateTime(2022, 12, 22, 20, 11, 43, 979, DateTimeKind.Local).AddTicks(1398), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 25, 20, 27, 38, 917, DateTimeKind.Local).AddTicks(1954), null, new DateTime(2022, 5, 24, 14, 41, 38, 916, DateTimeKind.Local).AddTicks(5326), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 5, 29, 18, 14, 41, 318, DateTimeKind.Local).AddTicks(9907), null, new DateTime(2022, 12, 18, 8, 5, 50, 314, DateTimeKind.Local).AddTicks(9152), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 25, 9, 9, 13, 461, DateTimeKind.Local).AddTicks(2503), null, new DateTime(2022, 11, 5, 15, 45, 45, 871, DateTimeKind.Local).AddTicks(2168), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 15, 2, 17, 29, 859, DateTimeKind.Local).AddTicks(2095), null, new DateTime(2022, 11, 4, 9, 35, 18, 480, DateTimeKind.Local).AddTicks(6907), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 11, 5, 17, 31, 55, DateTimeKind.Local).AddTicks(3509), null, new DateTime(2022, 5, 26, 10, 40, 25, 145, DateTimeKind.Local).AddTicks(4461), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 11, 29, 22, 50, 53, 627, DateTimeKind.Local).AddTicks(7692), null, new DateTime(2023, 2, 10, 1, 3, 6, 492, DateTimeKind.Local).AddTicks(8522), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 4, 20, 37, 23, 716, DateTimeKind.Local).AddTicks(8013), null, new DateTime(2022, 8, 11, 6, 7, 50, 183, DateTimeKind.Local).AddTicks(1127), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 19, 1, 56, 47, 279, DateTimeKind.Local).AddTicks(1351), null, new DateTime(2023, 2, 11, 22, 13, 50, 139, DateTimeKind.Local).AddTicks(4164), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 12, 22, 41, 35, 563, DateTimeKind.Local).AddTicks(6208), null, new DateTime(2022, 10, 25, 8, 4, 41, 359, DateTimeKind.Local).AddTicks(9424), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 19, 11, 27, 13, 926, DateTimeKind.Local).AddTicks(8666), null, new DateTime(2022, 10, 16, 4, 25, 50, 852, DateTimeKind.Local).AddTicks(7266), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 18, 16, 38, 0, 62, DateTimeKind.Local).AddTicks(2740), null, new DateTime(2023, 2, 26, 19, 42, 1, 935, DateTimeKind.Local).AddTicks(5603), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 22, 0, 23, 8, 68, DateTimeKind.Local).AddTicks(7524), null, new DateTime(2022, 7, 11, 13, 6, 40, 330, DateTimeKind.Local).AddTicks(9679), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 4, 30, 8, 37, 48, 763, DateTimeKind.Local).AddTicks(261), null, new DateTime(2022, 9, 5, 14, 35, 23, 749, DateTimeKind.Local).AddTicks(6206), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 16, 11, 59, 17, 103, DateTimeKind.Local).AddTicks(6244), null, new DateTime(2022, 12, 7, 11, 46, 59, 828, DateTimeKind.Local).AddTicks(7259), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 20, 16, 26, 20, 944, DateTimeKind.Local).AddTicks(5035), null, new DateTime(2022, 5, 9, 19, 16, 1, 503, DateTimeKind.Local).AddTicks(9336), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 1, 29, 16, 18, 56, 399, DateTimeKind.Local).AddTicks(2222), null, new DateTime(2022, 8, 6, 22, 1, 5, 177, DateTimeKind.Local).AddTicks(7241), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 22, 7, 26, 33, 85, DateTimeKind.Local).AddTicks(5298), null, new DateTime(2023, 1, 5, 16, 49, 10, 525, DateTimeKind.Local).AddTicks(951), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 10, 0, 5, 34, 112, DateTimeKind.Local).AddTicks(9234), null, new DateTime(2022, 7, 3, 21, 12, 54, 704, DateTimeKind.Local).AddTicks(6952), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 6, 1, 11, 30, 3, DateTimeKind.Local).AddTicks(6837), null, new DateTime(2023, 1, 12, 6, 29, 58, 339, DateTimeKind.Local).AddTicks(3966), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 18, 20, 2, 5, 48, DateTimeKind.Local).AddTicks(5329), null, new DateTime(2022, 10, 1, 15, 9, 1, 454, DateTimeKind.Local).AddTicks(1791), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 24, 13, 52, 38, 328, DateTimeKind.Local).AddTicks(2904), null, new DateTime(2022, 8, 4, 15, 48, 39, 217, DateTimeKind.Local).AddTicks(4338), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 14, 15, 0, 13, 226, DateTimeKind.Local).AddTicks(7213), null, new DateTime(2022, 6, 23, 19, 52, 22, 756, DateTimeKind.Local).AddTicks(6739), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 19, 8, 0, 2, 236, DateTimeKind.Local).AddTicks(5236), null, new DateTime(2022, 6, 18, 1, 30, 39, 114, DateTimeKind.Local).AddTicks(3926), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 3, 23, 48, 10, 751, DateTimeKind.Local).AddTicks(2834), null, new DateTime(2022, 9, 16, 17, 30, 26, 319, DateTimeKind.Local).AddTicks(8712), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 6, 22, 25, 58, 866, DateTimeKind.Local).AddTicks(5500), null, new DateTime(2022, 12, 11, 13, 28, 30, 745, DateTimeKind.Local).AddTicks(3333), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 19, 14, 42, 50, 725, DateTimeKind.Local).AddTicks(3728), null, new DateTime(2022, 11, 23, 17, 10, 20, 509, DateTimeKind.Local).AddTicks(2404), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 22, 22, 21, 31, 377, DateTimeKind.Local).AddTicks(5249), null, new DateTime(2023, 3, 29, 7, 12, 29, 861, DateTimeKind.Local).AddTicks(245), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 3, 14, 3, 48, 618, DateTimeKind.Local).AddTicks(9176), null, new DateTime(2022, 6, 27, 6, 31, 27, 586, DateTimeKind.Local).AddTicks(3169), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 20, 13, 37, 7, 273, DateTimeKind.Local).AddTicks(9160), null, new DateTime(2023, 2, 19, 23, 20, 47, 309, DateTimeKind.Local).AddTicks(8121), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 11, 23, 7, 53, 970, DateTimeKind.Local).AddTicks(5786), null, new DateTime(2022, 10, 24, 21, 24, 53, 333, DateTimeKind.Local).AddTicks(8929), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 8, 5, 3, 30, 620, DateTimeKind.Local).AddTicks(4623), null, new DateTime(2022, 6, 9, 23, 19, 3, 140, DateTimeKind.Local).AddTicks(8024), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 3, 14, 41, 24, 216, DateTimeKind.Local).AddTicks(5597), null, new DateTime(2022, 10, 31, 3, 35, 50, 150, DateTimeKind.Local).AddTicks(3457), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 21, 8, 24, 25, 310, DateTimeKind.Local).AddTicks(5131), null, new DateTime(2023, 1, 11, 19, 34, 1, 757, DateTimeKind.Local).AddTicks(9118), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 16, 18, 32, 13, 730, DateTimeKind.Local).AddTicks(282), null, new DateTime(2022, 8, 14, 2, 39, 39, 313, DateTimeKind.Local).AddTicks(3157), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 20, 8, 44, 11, 375, DateTimeKind.Local).AddTicks(7045), null, new DateTime(2022, 12, 1, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(4802), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 12, 4, 6, 22, 688, DateTimeKind.Local).AddTicks(3262), null, new DateTime(2022, 12, 30, 9, 38, 55, 921, DateTimeKind.Local).AddTicks(5690), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 27, 23, 59, 19, 106, DateTimeKind.Local).AddTicks(8087), null, new DateTime(2023, 4, 4, 22, 46, 15, 477, DateTimeKind.Local).AddTicks(8784), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 25, 2, 23, 29, 37, DateTimeKind.Local).AddTicks(1677), null, new DateTime(2023, 2, 6, 18, 10, 22, 247, DateTimeKind.Local).AddTicks(7654), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 12, 22, 17, 36, 695, DateTimeKind.Local).AddTicks(5373), null, new DateTime(2022, 6, 19, 1, 40, 36, 785, DateTimeKind.Local).AddTicks(4626), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 26, 2, 25, 31, 814, DateTimeKind.Local).AddTicks(8249), null, new DateTime(2022, 10, 29, 9, 41, 23, 200, DateTimeKind.Local).AddTicks(5710), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 28, 20, 19, 59, 189, DateTimeKind.Local).AddTicks(5060), null, new DateTime(2023, 2, 11, 5, 50, 41, 745, DateTimeKind.Local).AddTicks(5713), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 11, 3, 35, 29, 349, DateTimeKind.Local).AddTicks(1793), null, new DateTime(2022, 8, 18, 1, 18, 31, 639, DateTimeKind.Local).AddTicks(7761), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 6, 13, 30, 59, 272, DateTimeKind.Local).AddTicks(3222), null, new DateTime(2022, 5, 12, 21, 9, 21, 326, DateTimeKind.Local).AddTicks(5423), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 5, 30, 16, 26, 3, 827, DateTimeKind.Local).AddTicks(624), null, new DateTime(2023, 3, 8, 5, 27, 17, 806, DateTimeKind.Local).AddTicks(1107), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 3, 3, 45, 18, 677, DateTimeKind.Local).AddTicks(2424), null, new DateTime(2023, 1, 20, 20, 49, 2, 789, DateTimeKind.Local).AddTicks(7687), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 23, 4, 46, 37, 50, DateTimeKind.Local).AddTicks(8595), null, new DateTime(2022, 12, 2, 8, 18, 13, 534, DateTimeKind.Local).AddTicks(5241), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 3, 30, 5, 24, 3, 470, DateTimeKind.Local).AddTicks(8669), null, new DateTime(2022, 8, 3, 7, 51, 44, 134, DateTimeKind.Local).AddTicks(560), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 14, 21, 29, 29, 684, DateTimeKind.Local).AddTicks(422), null, new DateTime(2023, 1, 19, 6, 56, 13, 214, DateTimeKind.Local).AddTicks(7693), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 29, 0, 52, 34, 238, DateTimeKind.Local).AddTicks(8840), null, new DateTime(2022, 6, 1, 13, 24, 57, 948, DateTimeKind.Local).AddTicks(6202), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 2, 18, 50, 13, 492, DateTimeKind.Local).AddTicks(5084), null, new DateTime(2022, 12, 31, 2, 19, 8, 777, DateTimeKind.Local).AddTicks(2015), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 11, 10, 43, 26, 156, DateTimeKind.Local).AddTicks(5367), null, new DateTime(2023, 1, 11, 0, 45, 36, 424, DateTimeKind.Local).AddTicks(1435), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 15, 21, 1, 12, 333, DateTimeKind.Local).AddTicks(5423), null, new DateTime(2023, 1, 9, 21, 20, 6, 875, DateTimeKind.Local).AddTicks(3273), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 25, 10, 0, 20, 488, DateTimeKind.Local).AddTicks(6140), null, new DateTime(2022, 11, 26, 15, 10, 35, 99, DateTimeKind.Local).AddTicks(7063), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 24, 8, 37, 34, 828, DateTimeKind.Local).AddTicks(8474), null, new DateTime(2022, 8, 20, 13, 31, 11, 63, DateTimeKind.Local).AddTicks(2985), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 5, 13, 31, 7, 615, DateTimeKind.Local).AddTicks(7654), null, new DateTime(2023, 2, 1, 1, 11, 51, 38, DateTimeKind.Local).AddTicks(3533), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 11, 28, 19, 40, 30, 2, DateTimeKind.Local).AddTicks(6716), null, new DateTime(2022, 6, 6, 12, 41, 23, 661, DateTimeKind.Local).AddTicks(830), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 12, 6, 19, 19, 635, DateTimeKind.Local).AddTicks(1056), null, new DateTime(2022, 7, 28, 1, 39, 15, 139, DateTimeKind.Local).AddTicks(3225), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 24, 8, 23, 27, 450, DateTimeKind.Local).AddTicks(3675), null, new DateTime(2022, 11, 29, 6, 44, 41, 853, DateTimeKind.Local).AddTicks(7390), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 9, 20, 2, 28, 767, DateTimeKind.Local).AddTicks(9414), null, new DateTime(2023, 4, 10, 14, 7, 5, 117, DateTimeKind.Local).AddTicks(3884), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 16, 22, 28, 39, 216, DateTimeKind.Local).AddTicks(3352), null, new DateTime(2023, 3, 25, 15, 27, 25, 21, DateTimeKind.Local).AddTicks(7286), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 2, 23, 54, 52, 527, DateTimeKind.Local).AddTicks(6501), null, new DateTime(2023, 2, 3, 7, 57, 44, 172, DateTimeKind.Local).AddTicks(894), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 1, 3, 30, 59, 744, DateTimeKind.Local).AddTicks(9139), null, new DateTime(2022, 11, 4, 3, 25, 35, 15, DateTimeKind.Local).AddTicks(9171), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 28, 0, 9, 31, 484, DateTimeKind.Local).AddTicks(4691), null, new DateTime(2022, 6, 24, 19, 55, 30, 845, DateTimeKind.Local).AddTicks(9054), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 11, 11, 1, 12, 881, DateTimeKind.Local).AddTicks(8586), null, new DateTime(2022, 6, 30, 20, 25, 25, 760, DateTimeKind.Local).AddTicks(2545), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 15, 2, 50, 35, 294, DateTimeKind.Local).AddTicks(3869), null, new DateTime(2022, 7, 17, 8, 30, 2, 869, DateTimeKind.Local).AddTicks(7841), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 18, 16, 38, 23, 94, DateTimeKind.Local).AddTicks(3000), null, new DateTime(2022, 11, 14, 3, 45, 54, 577, DateTimeKind.Local).AddTicks(6209), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 8, 2, 43, 40, 878, DateTimeKind.Local).AddTicks(3014), null, new DateTime(2022, 7, 3, 3, 14, 33, 633, DateTimeKind.Local).AddTicks(87), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 13, 15, 26, 47, 716, DateTimeKind.Local).AddTicks(3982), null, new DateTime(2023, 1, 20, 3, 50, 13, 485, DateTimeKind.Local).AddTicks(3383), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 23, 20, 54, 31, 948, DateTimeKind.Local).AddTicks(5167), null, new DateTime(2022, 12, 31, 18, 52, 28, 453, DateTimeKind.Local).AddTicks(527), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 12, 21, 59, 49, 867, DateTimeKind.Local).AddTicks(6462), null, new DateTime(2022, 8, 13, 21, 7, 28, 938, DateTimeKind.Local).AddTicks(3932), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 25, 4, 41, 35, 845, DateTimeKind.Local).AddTicks(1779), null, new DateTime(2022, 7, 17, 4, 26, 5, 854, DateTimeKind.Local).AddTicks(4467), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 1, 12, 43, 41, 283, DateTimeKind.Local).AddTicks(7966), null, new DateTime(2022, 9, 4, 17, 58, 6, 794, DateTimeKind.Local).AddTicks(4736), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 15, 21, 38, 43, 357, DateTimeKind.Local).AddTicks(6149), null, new DateTime(2022, 6, 9, 6, 51, 2, 410, DateTimeKind.Local).AddTicks(8340), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 12, 17, 27, 52, 657, DateTimeKind.Local).AddTicks(2326), null, new DateTime(2022, 7, 6, 22, 10, 3, 35, DateTimeKind.Local).AddTicks(3755), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 10, 6, 53, 39, 347, DateTimeKind.Local).AddTicks(1872), null, new DateTime(2023, 2, 6, 16, 6, 10, 414, DateTimeKind.Local).AddTicks(3020), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 9, 12, 46, 53, 217, DateTimeKind.Local).AddTicks(5597), null, new DateTime(2023, 3, 23, 11, 24, 48, 549, DateTimeKind.Local).AddTicks(5198), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 27, 3, 58, 9, 867, DateTimeKind.Local).AddTicks(9929), null, new DateTime(2023, 3, 3, 18, 19, 2, 672, DateTimeKind.Local).AddTicks(6215), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 1, 9, 7, 31, 461, DateTimeKind.Local).AddTicks(7143), null, new DateTime(2022, 11, 6, 9, 49, 45, 655, DateTimeKind.Local).AddTicks(2525), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 19, 13, 19, 38, 109, DateTimeKind.Local).AddTicks(8731), null, new DateTime(2022, 10, 8, 9, 50, 50, 598, DateTimeKind.Local).AddTicks(4974), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 7, 7, 54, 11, 385, DateTimeKind.Local).AddTicks(4104), null, new DateTime(2023, 2, 9, 15, 11, 14, 660, DateTimeKind.Local).AddTicks(2858), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 2, 5, 1, 50, 782, DateTimeKind.Local).AddTicks(334), null, new DateTime(2022, 6, 24, 8, 2, 2, 195, DateTimeKind.Local).AddTicks(2539), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 19, 2, 51, 30, 420, DateTimeKind.Local).AddTicks(4691), null, new DateTime(2023, 3, 13, 5, 20, 3, 682, DateTimeKind.Local).AddTicks(5280), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 21, 19, 43, 43, 223, DateTimeKind.Local).AddTicks(492), null, new DateTime(2022, 11, 7, 3, 54, 46, 264, DateTimeKind.Local).AddTicks(5820), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 8, 15, 56, 2, 389, DateTimeKind.Local).AddTicks(3592), null, new DateTime(2022, 5, 11, 22, 16, 47, 200, DateTimeKind.Local).AddTicks(796), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 20, 11, 25, 46, 857, DateTimeKind.Local).AddTicks(726), null, new DateTime(2022, 12, 11, 18, 17, 6, 527, DateTimeKind.Local).AddTicks(8073), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 11, 1, 13, 43, 247, DateTimeKind.Local).AddTicks(9626), null, new DateTime(2022, 8, 31, 15, 1, 7, 259, DateTimeKind.Local).AddTicks(2214), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 1, 10, 36, 48, 22, DateTimeKind.Local).AddTicks(6483), null, new DateTime(2022, 6, 15, 4, 20, 35, 761, DateTimeKind.Local).AddTicks(7279), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 12, 9, 57, 9, 679, DateTimeKind.Local).AddTicks(8133), null, new DateTime(2022, 5, 10, 22, 47, 14, 258, DateTimeKind.Local).AddTicks(4689), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "ContactId", "CreateDate", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 3, 6, 8, 55, 8, 357, DateTimeKind.Local).AddTicks(9519), new DateTime(2022, 10, 27, 8, 1, 21, 621, DateTimeKind.Local).AddTicks(8922) },
                    { 2, 8, new DateTime(2022, 8, 18, 19, 10, 14, 587, DateTimeKind.Local).AddTicks(8992), new DateTime(2022, 11, 8, 19, 51, 38, 307, DateTimeKind.Local).AddTicks(7222) },
                    { 3, 4, new DateTime(2022, 5, 6, 6, 48, 9, 682, DateTimeKind.Local).AddTicks(4533), new DateTime(2023, 3, 9, 19, 56, 31, 543, DateTimeKind.Local).AddTicks(272) },
                    { 4, 7, new DateTime(2023, 4, 5, 8, 10, 39, 896, DateTimeKind.Local).AddTicks(6849), new DateTime(2023, 1, 15, 6, 18, 3, 288, DateTimeKind.Local).AddTicks(9931) },
                    { 5, 4, new DateTime(2022, 4, 19, 12, 40, 33, 652, DateTimeKind.Local).AddTicks(8327), new DateTime(2022, 8, 9, 19, 38, 15, 745, DateTimeKind.Local).AddTicks(8746) },
                    { 6, 7, new DateTime(2023, 1, 2, 14, 19, 41, 615, DateTimeKind.Local).AddTicks(3039), new DateTime(2022, 9, 3, 4, 36, 6, 91, DateTimeKind.Local).AddTicks(1523) },
                    { 7, 8, new DateTime(2022, 8, 2, 15, 17, 50, 466, DateTimeKind.Local).AddTicks(670), new DateTime(2022, 5, 4, 2, 58, 37, 320, DateTimeKind.Local).AddTicks(7825) },
                    { 8, 1, new DateTime(2023, 2, 16, 1, 29, 21, 413, DateTimeKind.Local).AddTicks(7622), new DateTime(2022, 11, 27, 8, 58, 10, 515, DateTimeKind.Local).AddTicks(8293) },
                    { 9, 8, new DateTime(2023, 2, 12, 22, 30, 14, 281, DateTimeKind.Local).AddTicks(9889), new DateTime(2022, 6, 30, 1, 29, 30, 96, DateTimeKind.Local).AddTicks(9593) },
                    { 10, 4, new DateTime(2022, 6, 19, 9, 18, 25, 845, DateTimeKind.Local).AddTicks(6709), new DateTime(2022, 5, 27, 5, 33, 46, 990, DateTimeKind.Local).AddTicks(282) },
                    { 11, 6, new DateTime(2022, 7, 28, 4, 26, 46, 767, DateTimeKind.Local).AddTicks(533), new DateTime(2022, 8, 3, 13, 12, 17, 59, DateTimeKind.Local).AddTicks(518) },
                    { 12, 1, new DateTime(2022, 4, 18, 18, 12, 5, 844, DateTimeKind.Local).AddTicks(3693), new DateTime(2022, 6, 25, 11, 50, 3, 11, DateTimeKind.Local).AddTicks(3008) },
                    { 13, 9, new DateTime(2023, 3, 23, 23, 30, 25, 569, DateTimeKind.Local).AddTicks(8702), new DateTime(2022, 10, 10, 0, 56, 49, 8, DateTimeKind.Local).AddTicks(4646) },
                    { 14, 6, new DateTime(2023, 1, 6, 5, 5, 16, 229, DateTimeKind.Local).AddTicks(3246), new DateTime(2022, 4, 18, 1, 22, 48, 729, DateTimeKind.Local).AddTicks(8393) },
                    { 15, 7, new DateTime(2022, 11, 25, 16, 17, 4, 512, DateTimeKind.Local).AddTicks(5810), new DateTime(2022, 11, 8, 6, 16, 15, 679, DateTimeKind.Local).AddTicks(4894) },
                    { 16, 7, new DateTime(2022, 8, 11, 13, 10, 21, 961, DateTimeKind.Local).AddTicks(2700), new DateTime(2022, 10, 25, 4, 39, 14, 431, DateTimeKind.Local).AddTicks(3601) },
                    { 17, 3, new DateTime(2022, 12, 7, 18, 30, 55, 510, DateTimeKind.Local).AddTicks(3056), new DateTime(2022, 10, 5, 17, 3, 46, 970, DateTimeKind.Local).AddTicks(4075) },
                    { 18, 2, new DateTime(2022, 12, 10, 6, 55, 37, 176, DateTimeKind.Local).AddTicks(792), new DateTime(2022, 8, 6, 7, 47, 18, 21, DateTimeKind.Local).AddTicks(5430) },
                    { 19, 4, new DateTime(2023, 2, 18, 2, 46, 57, 77, DateTimeKind.Local).AddTicks(9622), new DateTime(2022, 5, 4, 2, 27, 57, 366, DateTimeKind.Local).AddTicks(5819) },
                    { 20, 1, new DateTime(2022, 4, 25, 9, 48, 21, 410, DateTimeKind.Local).AddTicks(6765), new DateTime(2022, 10, 19, 15, 42, 10, 728, DateTimeKind.Local).AddTicks(2877) },
                    { 21, 7, new DateTime(2023, 3, 29, 16, 34, 54, 699, DateTimeKind.Local).AddTicks(1792), new DateTime(2023, 3, 2, 16, 31, 54, 259, DateTimeKind.Local).AddTicks(1603) },
                    { 22, 3, new DateTime(2023, 3, 15, 8, 20, 1, 860, DateTimeKind.Local).AddTicks(9460), new DateTime(2022, 12, 22, 22, 46, 3, 552, DateTimeKind.Local).AddTicks(103) },
                    { 23, 6, new DateTime(2022, 12, 24, 22, 8, 1, 111, DateTimeKind.Local).AddTicks(2014), new DateTime(2022, 4, 16, 13, 30, 38, 230, DateTimeKind.Local).AddTicks(8429) },
                    { 24, 9, new DateTime(2022, 6, 29, 4, 48, 44, 157, DateTimeKind.Local).AddTicks(9505), new DateTime(2023, 1, 25, 9, 51, 26, 467, DateTimeKind.Local).AddTicks(8144) },
                    { 25, 2, new DateTime(2023, 2, 9, 11, 3, 17, 987, DateTimeKind.Local).AddTicks(7827), new DateTime(2022, 11, 10, 5, 14, 44, 659, DateTimeKind.Local).AddTicks(1241) },
                    { 26, 10, new DateTime(2022, 11, 19, 23, 1, 40, 530, DateTimeKind.Local).AddTicks(8791), new DateTime(2022, 7, 7, 4, 14, 27, 323, DateTimeKind.Local).AddTicks(5640) },
                    { 27, 10, new DateTime(2023, 3, 2, 1, 34, 0, 639, DateTimeKind.Local).AddTicks(4654), new DateTime(2022, 10, 18, 4, 22, 2, 743, DateTimeKind.Local).AddTicks(1028) },
                    { 28, 4, new DateTime(2023, 3, 23, 21, 42, 3, 861, DateTimeKind.Local).AddTicks(8372), new DateTime(2022, 10, 26, 9, 49, 40, 757, DateTimeKind.Local).AddTicks(7501) },
                    { 29, 4, new DateTime(2022, 11, 25, 14, 0, 39, 510, DateTimeKind.Local).AddTicks(9205), new DateTime(2022, 12, 1, 16, 33, 20, 13, DateTimeKind.Local).AddTicks(3603) },
                    { 30, 1, new DateTime(2022, 9, 2, 1, 13, 39, 415, DateTimeKind.Local).AddTicks(8363), new DateTime(2022, 6, 14, 10, 27, 19, 188, DateTimeKind.Local).AddTicks(7944) },
                    { 31, 9, new DateTime(2022, 7, 7, 9, 23, 21, 175, DateTimeKind.Local).AddTicks(5735), new DateTime(2023, 3, 14, 8, 44, 14, 581, DateTimeKind.Local).AddTicks(5818) },
                    { 32, 1, new DateTime(2022, 5, 27, 7, 24, 18, 220, DateTimeKind.Local).AddTicks(6317), new DateTime(2023, 1, 23, 7, 32, 31, 952, DateTimeKind.Local).AddTicks(5348) },
                    { 33, 9, new DateTime(2022, 10, 23, 22, 34, 56, 635, DateTimeKind.Local).AddTicks(3003), new DateTime(2022, 12, 27, 2, 59, 13, 74, DateTimeKind.Local).AddTicks(253) },
                    { 34, 2, new DateTime(2023, 2, 28, 13, 23, 15, 394, DateTimeKind.Local).AddTicks(9534), new DateTime(2022, 12, 1, 10, 4, 31, 272, DateTimeKind.Local).AddTicks(4597) },
                    { 35, 5, new DateTime(2022, 12, 2, 5, 14, 54, 402, DateTimeKind.Local).AddTicks(6386), new DateTime(2022, 9, 24, 8, 44, 21, 774, DateTimeKind.Local).AddTicks(7524) },
                    { 36, 4, new DateTime(2023, 3, 21, 19, 11, 54, 419, DateTimeKind.Local).AddTicks(6255), new DateTime(2023, 2, 13, 14, 54, 29, 610, DateTimeKind.Local).AddTicks(6944) },
                    { 37, 3, new DateTime(2022, 11, 6, 11, 59, 9, 36, DateTimeKind.Local).AddTicks(8149), new DateTime(2022, 7, 14, 22, 47, 26, 969, DateTimeKind.Local).AddTicks(4820) },
                    { 38, 2, new DateTime(2023, 2, 24, 15, 23, 26, 692, DateTimeKind.Local).AddTicks(1217), new DateTime(2022, 6, 9, 3, 16, 31, 193, DateTimeKind.Local).AddTicks(6111) },
                    { 39, 10, new DateTime(2022, 12, 20, 16, 34, 2, 967, DateTimeKind.Local).AddTicks(5578), new DateTime(2022, 4, 21, 13, 55, 1, 259, DateTimeKind.Local).AddTicks(7428) },
                    { 40, 7, new DateTime(2022, 6, 7, 20, 54, 54, 955, DateTimeKind.Local).AddTicks(7729), new DateTime(2022, 8, 3, 13, 21, 32, 772, DateTimeKind.Local).AddTicks(4274) },
                    { 41, 10, new DateTime(2022, 9, 30, 6, 42, 57, 614, DateTimeKind.Local).AddTicks(8277), new DateTime(2022, 8, 7, 15, 56, 32, 117, DateTimeKind.Local).AddTicks(7681) },
                    { 42, 2, new DateTime(2023, 4, 8, 17, 28, 17, 512, DateTimeKind.Local).AddTicks(2509), new DateTime(2023, 4, 7, 14, 27, 33, 404, DateTimeKind.Local).AddTicks(7807) },
                    { 43, 2, new DateTime(2023, 3, 19, 13, 26, 49, 224, DateTimeKind.Local).AddTicks(9081), new DateTime(2022, 12, 29, 22, 41, 10, 189, DateTimeKind.Local).AddTicks(5558) },
                    { 44, 3, new DateTime(2023, 3, 16, 11, 47, 4, 542, DateTimeKind.Local).AddTicks(6622), new DateTime(2022, 5, 12, 19, 28, 54, 317, DateTimeKind.Local).AddTicks(9847) },
                    { 45, 5, new DateTime(2022, 6, 18, 14, 13, 53, 131, DateTimeKind.Local).AddTicks(2599), new DateTime(2022, 4, 17, 7, 12, 55, 666, DateTimeKind.Local).AddTicks(9186) },
                    { 46, 2, new DateTime(2022, 6, 11, 0, 43, 49, 887, DateTimeKind.Local).AddTicks(4820), new DateTime(2022, 8, 5, 11, 29, 19, 881, DateTimeKind.Local).AddTicks(6111) },
                    { 47, 10, new DateTime(2023, 3, 27, 0, 19, 49, 939, DateTimeKind.Local).AddTicks(4287), new DateTime(2022, 12, 20, 13, 50, 55, 513, DateTimeKind.Local).AddTicks(7087) },
                    { 48, 3, new DateTime(2022, 7, 17, 21, 54, 36, 97, DateTimeKind.Local).AddTicks(4926), new DateTime(2023, 2, 9, 8, 16, 40, 801, DateTimeKind.Local).AddTicks(4361) },
                    { 49, 1, new DateTime(2022, 8, 10, 6, 10, 46, 24, DateTimeKind.Local).AddTicks(1046), new DateTime(2022, 8, 26, 13, 2, 4, 905, DateTimeKind.Local).AddTicks(8674) },
                    { 50, 3, new DateTime(2023, 4, 4, 16, 56, 40, 717, DateTimeKind.Local).AddTicks(3964), new DateTime(2022, 9, 20, 9, 52, 25, 675, DateTimeKind.Local).AddTicks(4905) },
                    { 51, 3, new DateTime(2023, 1, 24, 21, 10, 51, 391, DateTimeKind.Local).AddTicks(6746), new DateTime(2022, 8, 31, 20, 42, 12, 101, DateTimeKind.Local).AddTicks(9451) },
                    { 52, 7, new DateTime(2023, 2, 8, 20, 19, 39, 11, DateTimeKind.Local).AddTicks(2357), new DateTime(2022, 9, 14, 1, 42, 28, 202, DateTimeKind.Local).AddTicks(5444) },
                    { 53, 7, new DateTime(2022, 12, 22, 7, 7, 27, 580, DateTimeKind.Local).AddTicks(8763), new DateTime(2022, 12, 9, 6, 48, 47, 312, DateTimeKind.Local).AddTicks(8024) },
                    { 54, 6, new DateTime(2023, 2, 11, 1, 7, 19, 38, DateTimeKind.Local).AddTicks(7691), new DateTime(2022, 4, 18, 0, 47, 15, 617, DateTimeKind.Local).AddTicks(1329) },
                    { 55, 9, new DateTime(2023, 3, 24, 23, 52, 31, 78, DateTimeKind.Local).AddTicks(2387), new DateTime(2022, 12, 6, 19, 14, 14, 916, DateTimeKind.Local).AddTicks(5692) },
                    { 56, 9, new DateTime(2022, 8, 2, 16, 0, 26, 215, DateTimeKind.Local).AddTicks(8894), new DateTime(2022, 12, 22, 20, 11, 43, 983, DateTimeKind.Local).AddTicks(2793) },
                    { 57, 9, new DateTime(2022, 5, 31, 12, 4, 46, 936, DateTimeKind.Local).AddTicks(9534), new DateTime(2022, 10, 25, 10, 52, 23, 502, DateTimeKind.Local).AddTicks(4942) },
                    { 58, 3, new DateTime(2022, 7, 20, 0, 39, 4, 940, DateTimeKind.Local).AddTicks(8198), new DateTime(2022, 6, 27, 15, 37, 15, 438, DateTimeKind.Local).AddTicks(7636) },
                    { 59, 4, new DateTime(2022, 7, 19, 23, 36, 3, 558, DateTimeKind.Local).AddTicks(3924), new DateTime(2022, 6, 29, 3, 50, 31, 939, DateTimeKind.Local).AddTicks(7555) },
                    { 60, 6, new DateTime(2023, 3, 18, 10, 25, 37, 245, DateTimeKind.Local).AddTicks(1454), new DateTime(2022, 12, 13, 6, 19, 41, 910, DateTimeKind.Local).AddTicks(5678) },
                    { 61, 4, new DateTime(2022, 5, 24, 14, 41, 38, 920, DateTimeKind.Local).AddTicks(6723), new DateTime(2023, 3, 30, 15, 32, 18, 929, DateTimeKind.Local).AddTicks(9342) },
                    { 62, 8, new DateTime(2022, 4, 29, 23, 6, 52, 436, DateTimeKind.Local).AddTicks(2090), new DateTime(2022, 6, 5, 9, 38, 23, 573, DateTimeKind.Local).AddTicks(4111) },
                    { 63, 4, new DateTime(2022, 6, 1, 6, 39, 44, 370, DateTimeKind.Local).AddTicks(3534), new DateTime(2022, 8, 23, 12, 56, 24, 542, DateTimeKind.Local).AddTicks(4488) },
                    { 64, 5, new DateTime(2022, 11, 6, 19, 11, 42, 738, DateTimeKind.Local).AddTicks(3648), new DateTime(2022, 10, 3, 12, 38, 32, 729, DateTimeKind.Local).AddTicks(313) },
                    { 65, 4, new DateTime(2022, 11, 29, 1, 50, 41, 35, DateTimeKind.Local).AddTicks(4505), new DateTime(2022, 5, 29, 18, 14, 41, 323, DateTimeKind.Local).AddTicks(862) },
                    { 66, 4, new DateTime(2022, 12, 17, 4, 27, 41, 403, DateTimeKind.Local).AddTicks(9529), new DateTime(2022, 8, 8, 17, 4, 15, 441, DateTimeKind.Local).AddTicks(6815) },
                    { 67, 9, new DateTime(2023, 1, 12, 3, 23, 29, 990, DateTimeKind.Local).AddTicks(2417), new DateTime(2022, 4, 23, 9, 12, 30, 230, DateTimeKind.Local).AddTicks(6439) },
                    { 68, 4, new DateTime(2022, 11, 27, 4, 26, 18, 283, DateTimeKind.Local).AddTicks(7057), new DateTime(2023, 2, 17, 23, 54, 4, 202, DateTimeKind.Local).AddTicks(8726) },
                    { 69, 1, new DateTime(2022, 5, 3, 10, 13, 59, 737, DateTimeKind.Local).AddTicks(886), new DateTime(2022, 10, 21, 15, 33, 56, 873, DateTimeKind.Local).AddTicks(2854) },
                    { 70, 9, new DateTime(2023, 1, 25, 9, 9, 13, 465, DateTimeKind.Local).AddTicks(3085), new DateTime(2022, 11, 5, 15, 45, 45, 875, DateTimeKind.Local).AddTicks(2749) },
                    { 71, 8, new DateTime(2023, 2, 11, 5, 30, 18, 260, DateTimeKind.Local).AddTicks(7901), new DateTime(2023, 1, 19, 15, 44, 0, 758, DateTimeKind.Local).AddTicks(1635) },
                    { 72, 1, new DateTime(2023, 2, 20, 11, 53, 30, 293, DateTimeKind.Local).AddTicks(4846), new DateTime(2023, 1, 3, 5, 27, 50, 540, DateTimeKind.Local).AddTicks(5303) },
                    { 73, 10, new DateTime(2023, 2, 19, 22, 26, 45, 329, DateTimeKind.Local).AddTicks(5003), new DateTime(2023, 3, 10, 19, 47, 49, 64, DateTimeKind.Local).AddTicks(4642) },
                    { 74, 5, new DateTime(2022, 10, 6, 23, 34, 0, 857, DateTimeKind.Local).AddTicks(8859), new DateTime(2022, 6, 17, 4, 22, 52, 267, DateTimeKind.Local).AddTicks(9715) },
                    { 75, 7, new DateTime(2022, 11, 4, 9, 35, 18, 484, DateTimeKind.Local).AddTicks(7474), new DateTime(2022, 11, 7, 11, 55, 14, 621, DateTimeKind.Local).AddTicks(251) },
                    { 76, 10, new DateTime(2022, 5, 5, 16, 47, 19, 231, DateTimeKind.Local).AddTicks(7530), new DateTime(2022, 12, 4, 17, 50, 34, 327, DateTimeKind.Local).AddTicks(8068) },
                    { 77, 10, new DateTime(2023, 3, 26, 5, 29, 7, 784, DateTimeKind.Local).AddTicks(5739), new DateTime(2022, 11, 16, 14, 10, 32, 576, DateTimeKind.Local).AddTicks(8779) },
                    { 78, 2, new DateTime(2022, 8, 8, 13, 39, 35, 853, DateTimeKind.Local).AddTicks(8970), new DateTime(2022, 6, 20, 2, 4, 17, 677, DateTimeKind.Local).AddTicks(3431) },
                    { 79, 4, new DateTime(2023, 3, 24, 3, 37, 17, 998, DateTimeKind.Local).AddTicks(7582), new DateTime(2022, 10, 11, 5, 17, 31, 59, DateTimeKind.Local).AddTicks(4071) },
                    { 80, 9, new DateTime(2022, 8, 29, 8, 50, 52, 763, DateTimeKind.Local).AddTicks(5031), new DateTime(2023, 4, 12, 7, 55, 3, 121, DateTimeKind.Local).AddTicks(5617) },
                    { 81, 4, new DateTime(2022, 10, 21, 12, 43, 55, 975, DateTimeKind.Local).AddTicks(2931), new DateTime(2022, 8, 20, 16, 32, 41, 327, DateTimeKind.Local).AddTicks(4872) },
                    { 82, 3, new DateTime(2022, 9, 1, 2, 40, 41, 624, DateTimeKind.Local).AddTicks(213), new DateTime(2023, 1, 9, 8, 43, 34, 900, DateTimeKind.Local).AddTicks(181) },
                    { 83, 3, new DateTime(2022, 12, 14, 23, 13, 37, 589, DateTimeKind.Local).AddTicks(113), new DateTime(2023, 1, 22, 8, 59, 21, 164, DateTimeKind.Local).AddTicks(4103) },
                    { 84, 6, new DateTime(2022, 11, 29, 22, 50, 53, 631, DateTimeKind.Local).AddTicks(8152), new DateTime(2023, 2, 10, 1, 3, 6, 496, DateTimeKind.Local).AddTicks(8979) },
                    { 85, 6, new DateTime(2022, 12, 16, 22, 28, 44, 964, DateTimeKind.Local).AddTicks(1480), new DateTime(2022, 7, 21, 22, 51, 39, 554, DateTimeKind.Local).AddTicks(8022) },
                    { 86, 2, new DateTime(2022, 8, 19, 4, 37, 11, 904, DateTimeKind.Local).AddTicks(1978), new DateTime(2022, 5, 8, 13, 53, 10, 221, DateTimeKind.Local).AddTicks(4056) },
                    { 87, 8, new DateTime(2023, 2, 17, 19, 48, 21, 821, DateTimeKind.Local).AddTicks(9746), new DateTime(2023, 4, 13, 12, 28, 50, 927, DateTimeKind.Local).AddTicks(7839) },
                    { 88, 2, new DateTime(2022, 5, 22, 2, 44, 32, 969, DateTimeKind.Local).AddTicks(9461), new DateTime(2023, 2, 14, 22, 42, 16, 103, DateTimeKind.Local).AddTicks(1881) },
                    { 89, 1, new DateTime(2022, 8, 11, 6, 7, 50, 187, DateTimeKind.Local).AddTicks(1623), new DateTime(2022, 10, 19, 10, 52, 52, 829, DateTimeKind.Local).AddTicks(3477) },
                    { 90, 5, new DateTime(2022, 8, 20, 22, 24, 4, 144, DateTimeKind.Local).AddTicks(7827), new DateTime(2023, 3, 15, 3, 18, 22, 717, DateTimeKind.Local).AddTicks(2058) },
                    { 91, 8, new DateTime(2023, 3, 24, 12, 38, 52, 382, DateTimeKind.Local).AddTicks(6104), new DateTime(2022, 10, 7, 8, 38, 2, 988, DateTimeKind.Local).AddTicks(4777) },
                    { 92, 1, new DateTime(2023, 3, 4, 10, 33, 35, 65, DateTimeKind.Local).AddTicks(5065), new DateTime(2023, 4, 1, 5, 52, 15, 305, DateTimeKind.Local).AddTicks(742) },
                    { 93, 2, new DateTime(2022, 10, 28, 5, 6, 51, 196, DateTimeKind.Local).AddTicks(1319), new DateTime(2022, 6, 19, 1, 56, 47, 283, DateTimeKind.Local).AddTicks(2086) },
                    { 94, 2, new DateTime(2022, 8, 23, 20, 21, 29, 225, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 9, 4, 12, 35, 52, 65, DateTimeKind.Local).AddTicks(2252) },
                    { 95, 2, new DateTime(2022, 12, 19, 3, 37, 53, 755, DateTimeKind.Local).AddTicks(5988), new DateTime(2022, 8, 10, 1, 40, 24, 575, DateTimeKind.Local).AddTicks(2432) },
                    { 96, 3, new DateTime(2022, 10, 6, 8, 32, 0, 543, DateTimeKind.Local).AddTicks(3350), new DateTime(2022, 12, 6, 10, 13, 1, 312, DateTimeKind.Local).AddTicks(2345) },
                    { 97, 1, new DateTime(2023, 1, 29, 11, 19, 44, 139, DateTimeKind.Local).AddTicks(7309), new DateTime(2022, 11, 18, 18, 2, 16, 517, DateTimeKind.Local).AddTicks(469) },
                    { 98, 6, new DateTime(2023, 2, 12, 22, 41, 35, 567, DateTimeKind.Local).AddTicks(6944), new DateTime(2022, 10, 25, 8, 4, 41, 364, DateTimeKind.Local).AddTicks(159) },
                    { 99, 1, new DateTime(2023, 1, 11, 15, 23, 14, 577, DateTimeKind.Local).AddTicks(1284), new DateTime(2022, 9, 15, 5, 1, 33, 427, DateTimeKind.Local).AddTicks(8355) },
                    { 100, 5, new DateTime(2023, 2, 11, 14, 37, 35, 791, DateTimeKind.Local).AddTicks(2593), new DateTime(2022, 5, 6, 15, 35, 1, 859, DateTimeKind.Local).AddTicks(3529) },
                    { 101, 8, new DateTime(2022, 5, 29, 2, 16, 59, 312, DateTimeKind.Local).AddTicks(5309), new DateTime(2022, 8, 9, 19, 51, 43, 866, DateTimeKind.Local).AddTicks(7471) },
                    { 102, 2, new DateTime(2022, 6, 17, 7, 38, 41, 723, DateTimeKind.Local).AddTicks(9169), new DateTime(2022, 12, 22, 5, 14, 11, 671, DateTimeKind.Local).AddTicks(7246) },
                    { 103, 7, new DateTime(2022, 10, 16, 4, 25, 50, 856, DateTimeKind.Local).AddTicks(8003), new DateTime(2023, 1, 28, 6, 57, 20, 321, DateTimeKind.Local).AddTicks(1623) },
                    { 104, 7, new DateTime(2022, 4, 25, 12, 1, 37, 444, DateTimeKind.Local).AddTicks(6746), new DateTime(2023, 2, 4, 18, 32, 31, 130, DateTimeKind.Local).AddTicks(5879) },
                    { 105, 2, new DateTime(2022, 9, 28, 3, 49, 20, 283, DateTimeKind.Local).AddTicks(3281), new DateTime(2022, 10, 10, 18, 29, 3, 19, DateTimeKind.Local).AddTicks(4264) },
                    { 106, 4, new DateTime(2022, 4, 20, 7, 54, 19, 804, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 9, 16, 18, 8, 49, 636, DateTimeKind.Local).AddTicks(8713) },
                    { 107, 5, new DateTime(2022, 6, 29, 7, 29, 57, 640, DateTimeKind.Local).AddTicks(9065), new DateTime(2023, 2, 18, 16, 38, 0, 66, DateTimeKind.Local).AddTicks(3480) },
                    { 108, 2, new DateTime(2022, 12, 17, 5, 29, 15, 380, DateTimeKind.Local).AddTicks(7699), new DateTime(2022, 11, 5, 6, 6, 30, 427, DateTimeKind.Local).AddTicks(5498) },
                    { 109, 7, new DateTime(2023, 2, 3, 3, 48, 9, 65, DateTimeKind.Local).AddTicks(6134), new DateTime(2022, 5, 25, 8, 59, 27, 237, DateTimeKind.Local).AddTicks(4150) },
                    { 110, 1, new DateTime(2023, 3, 15, 11, 28, 44, 171, DateTimeKind.Local).AddTicks(6172), new DateTime(2022, 6, 6, 14, 12, 30, 910, DateTimeKind.Local).AddTicks(8781) },
                    { 111, 5, new DateTime(2022, 8, 7, 13, 1, 56, 138, DateTimeKind.Local).AddTicks(6746), new DateTime(2022, 12, 30, 9, 31, 25, 827, DateTimeKind.Local).AddTicks(3736) },
                    { 112, 9, new DateTime(2022, 11, 22, 0, 23, 8, 72, DateTimeKind.Local).AddTicks(8269), new DateTime(2022, 7, 11, 13, 6, 40, 335, DateTimeKind.Local).AddTicks(424) },
                    { 113, 10, new DateTime(2022, 4, 18, 22, 12, 25, 138, DateTimeKind.Local).AddTicks(6598), new DateTime(2022, 10, 17, 15, 1, 22, 454, DateTimeKind.Local).AddTicks(1851) },
                    { 114, 4, new DateTime(2022, 9, 16, 15, 44, 32, 994, DateTimeKind.Local).AddTicks(284), new DateTime(2023, 4, 5, 23, 8, 20, 109, DateTimeKind.Local).AddTicks(389) },
                    { 115, 2, new DateTime(2022, 11, 23, 5, 15, 24, 295, DateTimeKind.Local).AddTicks(2826), new DateTime(2023, 1, 19, 18, 20, 17, 117, DateTimeKind.Local).AddTicks(5615) },
                    { 116, 3, new DateTime(2022, 10, 29, 22, 30, 8, 322, DateTimeKind.Local).AddTicks(2750), new DateTime(2022, 8, 31, 13, 54, 25, 706, DateTimeKind.Local).AddTicks(8726) },
                    { 117, 10, new DateTime(2022, 9, 5, 14, 35, 23, 753, DateTimeKind.Local).AddTicks(6907), new DateTime(2023, 1, 7, 2, 31, 5, 195, DateTimeKind.Local).AddTicks(652) },
                    { 118, 1, new DateTime(2023, 4, 13, 15, 50, 44, 118, DateTimeKind.Local).AddTicks(8352), new DateTime(2022, 11, 29, 2, 9, 48, 572, DateTimeKind.Local).AddTicks(8611) },
                    { 119, 8, new DateTime(2022, 8, 23, 16, 13, 0, 976, DateTimeKind.Local).AddTicks(394), new DateTime(2022, 9, 25, 15, 49, 54, 354, DateTimeKind.Local).AddTicks(2703) },
                    { 120, 3, new DateTime(2022, 10, 29, 15, 27, 2, 669, DateTimeKind.Local).AddTicks(5761), new DateTime(2022, 8, 27, 22, 52, 43, 80, DateTimeKind.Local).AddTicks(8138) },
                    { 121, 5, new DateTime(2022, 9, 6, 10, 53, 52, 306, DateTimeKind.Local).AddTicks(4902), new DateTime(2022, 11, 16, 11, 59, 17, 107, DateTimeKind.Local).AddTicks(6944) },
                    { 122, 4, new DateTime(2023, 1, 19, 11, 10, 52, 795, DateTimeKind.Local).AddTicks(221), new DateTime(2023, 1, 1, 18, 1, 51, 728, DateTimeKind.Local).AddTicks(5125) },
                    { 123, 10, new DateTime(2023, 1, 20, 20, 36, 47, 936, DateTimeKind.Local).AddTicks(8878), new DateTime(2023, 2, 19, 22, 28, 22, 633, DateTimeKind.Local).AddTicks(272) },
                    { 124, 8, new DateTime(2022, 10, 28, 2, 11, 1, 86, DateTimeKind.Local).AddTicks(6282), new DateTime(2022, 4, 17, 4, 44, 5, 88, DateTimeKind.Local).AddTicks(4376) },
                    { 125, 1, new DateTime(2023, 3, 4, 19, 37, 49, 46, DateTimeKind.Local).AddTicks(9705), new DateTime(2023, 1, 26, 10, 47, 35, 69, DateTimeKind.Local).AddTicks(4060) },
                    { 126, 2, new DateTime(2022, 4, 20, 16, 26, 20, 948, DateTimeKind.Local).AddTicks(5861), new DateTime(2022, 5, 9, 19, 16, 1, 508, DateTimeKind.Local).AddTicks(161) },
                    { 127, 3, new DateTime(2022, 10, 27, 4, 48, 31, 236, DateTimeKind.Local).AddTicks(2223), new DateTime(2022, 7, 21, 0, 20, 11, 165, DateTimeKind.Local).AddTicks(8682) },
                    { 128, 3, new DateTime(2023, 3, 14, 5, 59, 53, 702, DateTimeKind.Local).AddTicks(3954), new DateTime(2022, 10, 23, 15, 55, 30, 840, DateTimeKind.Local).AddTicks(4572) },
                    { 129, 6, new DateTime(2022, 11, 1, 9, 0, 8, 508, DateTimeKind.Local).AddTicks(7987), new DateTime(2022, 8, 9, 16, 13, 22, 442, DateTimeKind.Local).AddTicks(3711) },
                    { 130, 10, new DateTime(2023, 3, 13, 6, 26, 54, 53, DateTimeKind.Local).AddTicks(3760), new DateTime(2022, 7, 15, 3, 12, 17, 519, DateTimeKind.Local).AddTicks(3201) },
                    { 131, 3, new DateTime(2022, 8, 6, 22, 1, 5, 181, DateTimeKind.Local).AddTicks(8069), new DateTime(2022, 10, 4, 1, 47, 32, 891, DateTimeKind.Local).AddTicks(6174) },
                    { 132, 9, new DateTime(2022, 5, 5, 19, 13, 38, 891, DateTimeKind.Local).AddTicks(7364), new DateTime(2022, 4, 25, 23, 52, 51, 110, DateTimeKind.Local).AddTicks(729) },
                    { 133, 7, new DateTime(2022, 7, 1, 5, 33, 2, 3, DateTimeKind.Local).AddTicks(3163), new DateTime(2023, 2, 17, 13, 6, 41, 922, DateTimeKind.Local).AddTicks(7963) },
                    { 134, 10, new DateTime(2022, 12, 22, 9, 30, 50, 505, DateTimeKind.Local).AddTicks(7740), new DateTime(2023, 1, 22, 20, 55, 30, 807, DateTimeKind.Local).AddTicks(9365) },
                    { 135, 5, new DateTime(2023, 1, 29, 3, 15, 26, 82, DateTimeKind.Local).AddTicks(7360), new DateTime(2023, 2, 22, 7, 26, 33, 89, DateTimeKind.Local).AddTicks(6129) },
                    { 136, 3, new DateTime(2022, 5, 15, 2, 47, 27, 30, DateTimeKind.Local).AddTicks(8094), new DateTime(2022, 5, 25, 15, 15, 5, 494, DateTimeKind.Local).AddTicks(4160) },
                    { 137, 2, new DateTime(2022, 8, 17, 0, 29, 32, 258, DateTimeKind.Local).AddTicks(2281), new DateTime(2022, 8, 18, 18, 48, 50, 450, DateTimeKind.Local).AddTicks(56) },
                    { 138, 7, new DateTime(2023, 4, 3, 21, 1, 10, 551, DateTimeKind.Local).AddTicks(7422), new DateTime(2022, 4, 18, 5, 40, 41, 855, DateTimeKind.Local).AddTicks(9070) },
                    { 139, 9, new DateTime(2023, 2, 18, 20, 11, 53, 326, DateTimeKind.Local).AddTicks(3014), new DateTime(2022, 10, 8, 23, 56, 9, 26, DateTimeKind.Local).AddTicks(6488) },
                    { 140, 10, new DateTime(2022, 7, 10, 0, 5, 34, 117, DateTimeKind.Local).AddTicks(66), new DateTime(2022, 7, 3, 21, 12, 54, 708, DateTimeKind.Local).AddTicks(7784) },
                    { 141, 7, new DateTime(2022, 4, 20, 20, 41, 38, 471, DateTimeKind.Local).AddTicks(2383), new DateTime(2023, 2, 23, 9, 12, 4, 306, DateTimeKind.Local).AddTicks(554) },
                    { 142, 4, new DateTime(2022, 9, 30, 3, 7, 47, 126, DateTimeKind.Local).AddTicks(1536), new DateTime(2022, 7, 6, 23, 12, 6, 327, DateTimeKind.Local).AddTicks(3700) },
                    { 143, 5, new DateTime(2023, 1, 24, 6, 0, 58, 231, DateTimeKind.Local).AddTicks(8577), new DateTime(2023, 2, 12, 19, 26, 20, 577, DateTimeKind.Local).AddTicks(7840) },
                    { 144, 3, new DateTime(2022, 10, 11, 1, 22, 47, 378, DateTimeKind.Local).AddTicks(5085), new DateTime(2023, 2, 3, 5, 55, 29, 367, DateTimeKind.Local).AddTicks(8208) },
                    { 145, 8, new DateTime(2023, 1, 12, 6, 29, 58, 343, DateTimeKind.Local).AddTicks(4841), new DateTime(2023, 2, 18, 14, 19, 51, 153, DateTimeKind.Local).AddTicks(3) },
                    { 146, 6, new DateTime(2022, 6, 28, 22, 41, 8, 879, DateTimeKind.Local).AddTicks(2301), new DateTime(2022, 5, 29, 21, 46, 38, 42, DateTimeKind.Local).AddTicks(2126) },
                    { 147, 4, new DateTime(2022, 12, 22, 8, 56, 36, 31, DateTimeKind.Local).AddTicks(7195), new DateTime(2022, 10, 3, 1, 14, 51, 900, DateTimeKind.Local).AddTicks(5433) },
                    { 148, 8, new DateTime(2022, 7, 14, 11, 1, 34, 173, DateTimeKind.Local).AddTicks(5925), new DateTime(2022, 11, 10, 0, 59, 32, 217, DateTimeKind.Local).AddTicks(7030) },
                    { 149, 1, new DateTime(2022, 9, 12, 19, 45, 3, 557, DateTimeKind.Local).AddTicks(541), new DateTime(2022, 8, 18, 20, 2, 5, 52, DateTimeKind.Local).AddTicks(6206) },
                    { 150, 6, new DateTime(2022, 4, 28, 12, 38, 17, 880, DateTimeKind.Local).AddTicks(9628), new DateTime(2022, 6, 30, 18, 3, 55, 987, DateTimeKind.Local).AddTicks(9919) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 41, 57, 960, DateTimeKind.Local).AddTicks(1888), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 365, DateTimeKind.Local).AddTicks(7978), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 15, 0, 41, 57, 964, DateTimeKind.Local).AddTicks(8428), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 370, DateTimeKind.Local).AddTicks(4534), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 15, 0, 41, 57, 968, DateTimeKind.Local).AddTicks(4134), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 374, DateTimeKind.Local).AddTicks(229), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 15, 0, 41, 57, 971, DateTimeKind.Local).AddTicks(4328), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 377, DateTimeKind.Local).AddTicks(451), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 15, 0, 41, 57, 974, DateTimeKind.Local).AddTicks(7655), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 380, DateTimeKind.Local).AddTicks(3776), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 15, 0, 41, 57, 978, DateTimeKind.Local).AddTicks(406), "Metal_Chicken.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 383, DateTimeKind.Local).AddTicks(6499), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 15, 0, 41, 57, 982, DateTimeKind.Local).AddTicks(1909), "Metal_Shoes.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 387, DateTimeKind.Local).AddTicks(8010), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 15, 0, 41, 57, 985, DateTimeKind.Local).AddTicks(981), "Metal_Shoes2.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 390, DateTimeKind.Local).AddTicks(7080), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 15, 0, 41, 57, 988, DateTimeKind.Local).AddTicks(5278), "Steel_Computer.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 394, DateTimeKind.Local).AddTicks(1385), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 15, 0, 41, 57, 991, DateTimeKind.Local).AddTicks(3138), "Cotton_Cheese.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 396, DateTimeKind.Local).AddTicks(9212), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 15, 0, 41, 57, 993, DateTimeKind.Local).AddTicks(9086), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 399, DateTimeKind.Local).AddTicks(5174), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 15, 0, 41, 57, 997, DateTimeKind.Local).AddTicks(6853), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 403, DateTimeKind.Local).AddTicks(3051), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 15, 0, 41, 58, 0, DateTimeKind.Local).AddTicks(5929), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 6, 8, 55, 8, 406, DateTimeKind.Local).AddTicks(2015), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 2, 2 },
                    { 9, 3 },
                    { 8, 4 },
                    { 2, 5 },
                    { 5, 6 },
                    { 6, 7 },
                    { 9, 8 },
                    { 6, 9 },
                    { 7, 10 },
                    { 7, 11 },
                    { 9, 12 },
                    { 5, 13 },
                    { 8, 14 },
                    { 4, 15 },
                    { 2, 16 },
                    { 9, 17 },
                    { 4, 18 },
                    { 5, 19 },
                    { 3, 20 },
                    { 5, 21 },
                    { 2, 22 },
                    { 1, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 6, 26 },
                    { 2, 27 },
                    { 7, 28 },
                    { 3, 29 },
                    { 8, 30 },
                    { 2, 31 },
                    { 3, 32 },
                    { 4, 33 },
                    { 3, 34 },
                    { 2, 35 },
                    { 2, 36 },
                    { 4, 37 },
                    { 4, 38 },
                    { 8, 39 },
                    { 8, 40 },
                    { 9, 41 },
                    { 9, 42 },
                    { 5, 43 },
                    { 5, 44 },
                    { 3, 45 },
                    { 3, 46 },
                    { 1, 47 },
                    { 3, 48 },
                    { 5, 49 },
                    { 7, 50 },
                    { 2, 51 },
                    { 6, 52 },
                    { 4, 53 },
                    { 3, 54 },
                    { 4, 55 },
                    { 2, 56 },
                    { 6, 57 },
                    { 7, 58 },
                    { 3, 59 },
                    { 9, 60 },
                    { 5, 61 },
                    { 4, 62 },
                    { 1, 63 },
                    { 5, 64 },
                    { 4, 65 },
                    { 8, 66 },
                    { 5, 67 },
                    { 3, 68 },
                    { 3, 69 },
                    { 7, 70 },
                    { 6, 71 },
                    { 6, 72 },
                    { 1, 73 },
                    { 1, 74 },
                    { 3, 75 },
                    { 8, 76 },
                    { 8, 77 },
                    { 2, 78 },
                    { 2, 79 },
                    { 2, 80 },
                    { 9, 81 },
                    { 8, 82 },
                    { 4, 83 },
                    { 5, 84 },
                    { 4, 85 },
                    { 9, 86 },
                    { 2, 87 },
                    { 5, 88 },
                    { 5, 89 },
                    { 3, 90 },
                    { 9, 91 },
                    { 5, 92 },
                    { 3, 93 },
                    { 3, 94 },
                    { 1, 95 },
                    { 8, 96 },
                    { 8, 97 },
                    { 6, 98 },
                    { 1, 99 },
                    { 1, 100 }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 27, 8, 1, 21, 625, DateTimeKind.Local).AddTicks(6964), new DateTime(2022, 7, 8, 3, 47, 2, 834, DateTimeKind.Local).AddTicks(769), 25, 25.4129114383076m },
                    { 2, 65, new DateTime(2022, 12, 7, 13, 15, 44, 857, DateTimeKind.Local).AddTicks(2754), new DateTime(2022, 5, 6, 6, 48, 9, 686, DateTimeKind.Local).AddTicks(2792), 66, 22.7051721039019m },
                    { 3, 97, new DateTime(2023, 4, 5, 8, 10, 39, 900, DateTimeKind.Local).AddTicks(5113), new DateTime(2023, 1, 15, 6, 18, 3, 292, DateTimeKind.Local).AddTicks(8195), 11, 1.80897601147438m },
                    { 4, 149, new DateTime(2022, 8, 9, 19, 38, 15, 749, DateTimeKind.Local).AddTicks(7014), new DateTime(2022, 8, 19, 18, 13, 6, 21, DateTimeKind.Local).AddTicks(277), 33, 19.8324322125767m },
                    { 5, 93, new DateTime(2022, 8, 1, 17, 47, 34, 0, DateTimeKind.Local).AddTicks(6114), new DateTime(2022, 8, 2, 15, 17, 50, 469, DateTimeKind.Local).AddTicks(8939), 29, 20.6206935952908m },
                    { 6, 15, new DateTime(2023, 2, 16, 1, 29, 21, 417, DateTimeKind.Local).AddTicks(5897), new DateTime(2022, 11, 27, 8, 58, 10, 519, DateTimeKind.Local).AddTicks(6568), 95, 3.27372784021027m },
                    { 7, 26, new DateTime(2022, 6, 30, 1, 29, 30, 100, DateTimeKind.Local).AddTicks(7870), new DateTime(2022, 12, 24, 15, 43, 0, 580, DateTimeKind.Local).AddTicks(4759), 80, 23.2960462445584m },
                    { 8, 133, new DateTime(2022, 9, 24, 17, 49, 40, 594, DateTimeKind.Local).AddTicks(6591), new DateTime(2022, 7, 28, 4, 26, 46, 770, DateTimeKind.Local).AddTicks(8810), 83, 21.9001098433712m },
                    { 9, 3, new DateTime(2022, 4, 18, 18, 12, 5, 848, DateTimeKind.Local).AddTicks(1973), new DateTime(2022, 6, 25, 11, 50, 3, 15, DateTimeKind.Local).AddTicks(1287), 70, 28.2446081678222m },
                    { 10, 10, new DateTime(2022, 10, 10, 0, 56, 49, 12, DateTimeKind.Local).AddTicks(2925), new DateTime(2022, 10, 6, 1, 46, 26, 435, DateTimeKind.Local).AddTicks(2111), 86, 18.9071859502507m },
                    { 11, 150, new DateTime(2022, 8, 6, 12, 57, 41, 192, DateTimeKind.Local).AddTicks(1154), new DateTime(2022, 11, 25, 16, 17, 4, 516, DateTimeKind.Local).AddTicks(4088), 28, 16.9920141503915m },
                    { 12, 102, new DateTime(2022, 8, 11, 13, 10, 21, 965, DateTimeKind.Local).AddTicks(979), new DateTime(2022, 10, 25, 4, 39, 14, 435, DateTimeKind.Local).AddTicks(1880), 44, 3.52125673163873m },
                    { 13, 54, new DateTime(2022, 10, 5, 17, 3, 46, 974, DateTimeKind.Local).AddTicks(2356), new DateTime(2023, 2, 12, 22, 51, 11, 506, DateTimeKind.Local).AddTicks(1244), 25, 5.75808331593054m },
                    { 14, 104, new DateTime(2022, 11, 22, 13, 34, 57, 631, DateTimeKind.Local).AddTicks(5693), new DateTime(2023, 2, 18, 2, 46, 57, 81, DateTimeKind.Local).AddTicks(7899), 35, 3.94153923422408m },
                    { 15, 13, new DateTime(2022, 4, 25, 9, 48, 21, 414, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 10, 19, 15, 42, 10, 732, DateTimeKind.Local).AddTicks(1155), 95, 9.7896229435275m },
                    { 16, 8, new DateTime(2023, 3, 2, 16, 31, 54, 262, DateTimeKind.Local).AddTicks(9882), new DateTime(2023, 1, 27, 9, 24, 54, 979, DateTimeKind.Local).AddTicks(2051), 64, 28.0238217598912m },
                    { 17, 47, new DateTime(2022, 9, 27, 12, 7, 56, 656, DateTimeKind.Local).AddTicks(1484), new DateTime(2022, 12, 24, 22, 8, 1, 115, DateTimeKind.Local).AddTicks(294), 9, 13.3677462223103m },
                    { 18, 132, new DateTime(2022, 6, 29, 4, 48, 44, 161, DateTimeKind.Local).AddTicks(7785), new DateTime(2023, 1, 25, 9, 51, 26, 471, DateTimeKind.Local).AddTicks(6424), 100, 5.45234338447922m },
                    { 19, 27, new DateTime(2022, 11, 10, 5, 14, 44, 662, DateTimeKind.Local).AddTicks(9522), new DateTime(2022, 5, 1, 20, 37, 59, 17, DateTimeKind.Local).AddTicks(1534), 11, 15.3707966847284m },
                    { 20, 117, new DateTime(2022, 5, 4, 21, 44, 5, 262, DateTimeKind.Local).AddTicks(5513), new DateTime(2023, 3, 2, 1, 34, 0, 643, DateTimeKind.Local).AddTicks(2934), 41, 25.3207815501005m },
                    { 21, 49, new DateTime(2023, 3, 23, 21, 42, 3, 865, DateTimeKind.Local).AddTicks(6653), new DateTime(2022, 10, 26, 9, 49, 40, 761, DateTimeKind.Local).AddTicks(5782), 50, 19.5800956400662m },
                    { 22, 59, new DateTime(2022, 12, 1, 16, 33, 20, 17, DateTimeKind.Local).AddTicks(1887), new DateTime(2023, 4, 13, 0, 27, 9, 463, DateTimeKind.Local).AddTicks(7237), 37, 15.3225465382128m },
                    { 23, 126, new DateTime(2022, 6, 7, 4, 24, 16, 70, DateTimeKind.Local).AddTicks(9349), new DateTime(2022, 7, 7, 9, 23, 21, 179, DateTimeKind.Local).AddTicks(4019), 62, 16.177846904872m },
                    { 24, 4, new DateTime(2022, 5, 27, 7, 24, 18, 224, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 1, 23, 7, 32, 31, 956, DateTimeKind.Local).AddTicks(3631), 9, 21.1526538156895m },
                    { 25, 72, new DateTime(2022, 12, 27, 2, 59, 13, 77, DateTimeKind.Local).AddTicks(8537), new DateTime(2023, 3, 2, 2, 32, 22, 553, DateTimeKind.Local).AddTicks(6980), 88, 9.32950789784184m },
                    { 26, 56, new DateTime(2022, 10, 24, 10, 10, 46, 626, DateTimeKind.Local).AddTicks(7371), new DateTime(2022, 12, 2, 5, 14, 54, 406, DateTimeKind.Local).AddTicks(4621), 13, 1.21726056891705m },
                    { 27, 46, new DateTime(2023, 3, 21, 19, 11, 54, 423, DateTimeKind.Local).AddTicks(4489), new DateTime(2023, 2, 13, 14, 54, 29, 614, DateTimeKind.Local).AddTicks(5178), 56, 21.9427123193105m },
                    { 28, 66, new DateTime(2022, 7, 14, 22, 47, 26, 973, DateTimeKind.Local).AddTicks(3055), new DateTime(2023, 2, 10, 17, 15, 40, 469, DateTimeKind.Local).AddTicks(2406), 27, 6.52106357980334m },
                    { 29, 128, new DateTime(2022, 4, 17, 6, 22, 18, 411, DateTimeKind.Local).AddTicks(4088), new DateTime(2022, 12, 20, 16, 34, 2, 971, DateTimeKind.Local).AddTicks(3812), 14, 29.6273162175101m },
                    { 30, 98, new DateTime(2022, 6, 7, 20, 54, 54, 959, DateTimeKind.Local).AddTicks(5964), new DateTime(2022, 8, 3, 13, 21, 32, 776, DateTimeKind.Local).AddTicks(2509), 99, 16.1383597917956m },
                    { 31, 82, new DateTime(2022, 8, 7, 15, 56, 32, 121, DateTimeKind.Local).AddTicks(5916), new DateTime(2023, 2, 15, 22, 5, 29, 468, DateTimeKind.Local).AddTicks(2753), 95, 27.7198683556646m },
                    { 32, 4, new DateTime(2023, 2, 26, 20, 9, 22, 312, DateTimeKind.Local).AddTicks(4603), new DateTime(2023, 3, 19, 13, 26, 49, 228, DateTimeKind.Local).AddTicks(7316), 2, 7.27184845123774m },
                    { 33, 31, new DateTime(2023, 3, 16, 11, 47, 4, 546, DateTimeKind.Local).AddTicks(4858), new DateTime(2022, 5, 12, 19, 28, 54, 321, DateTimeKind.Local).AddTicks(8083), 30, 1.79453316195838m },
                    { 34, 124, new DateTime(2022, 4, 17, 7, 12, 55, 670, DateTimeKind.Local).AddTicks(7424), new DateTime(2023, 3, 2, 13, 19, 41, 896, DateTimeKind.Local).AddTicks(8739), 48, 27.2064603546581m },
                    { 35, 105, new DateTime(2022, 5, 17, 20, 7, 29, 409, DateTimeKind.Local).AddTicks(2346), new DateTime(2023, 3, 27, 0, 19, 49, 943, DateTimeKind.Local).AddTicks(2525), 85, 29.1657667514345m },
                    { 36, 31, new DateTime(2022, 7, 17, 21, 54, 36, 101, DateTimeKind.Local).AddTicks(3164), new DateTime(2023, 2, 9, 8, 16, 40, 805, DateTimeKind.Local).AddTicks(2599), 32, 14.7492443884398m },
                    { 37, 103, new DateTime(2022, 8, 26, 13, 2, 4, 909, DateTimeKind.Local).AddTicks(6955), new DateTime(2023, 1, 19, 0, 29, 53, 814, DateTimeKind.Local).AddTicks(2149), 9, 3.25045582172094m },
                    { 38, 86, new DateTime(2023, 1, 17, 12, 39, 41, 119, DateTimeKind.Local).AddTicks(371), new DateTime(2023, 1, 24, 21, 10, 51, 395, DateTimeKind.Local).AddTicks(5028), 4, 5.14607182369939m },
                    { 39, 91, new DateTime(2023, 2, 8, 20, 19, 39, 15, DateTimeKind.Local).AddTicks(643), new DateTime(2022, 9, 14, 1, 42, 28, 206, DateTimeKind.Local).AddTicks(3730), 63, 14.5545449550228m },
                    { 40, 48, new DateTime(2022, 12, 9, 6, 48, 47, 316, DateTimeKind.Local).AddTicks(6312), new DateTime(2022, 10, 2, 13, 18, 58, 796, DateTimeKind.Local).AddTicks(2153), 69, 18.2625250925152m },
                    { 41, 150, new DateTime(2022, 5, 31, 11, 15, 29, 847, DateTimeKind.Local).AddTicks(3832), new DateTime(2023, 3, 24, 23, 52, 31, 82, DateTimeKind.Local).AddTicks(675), 18, 10.9984667194275m },
                    { 42, 125, new DateTime(2022, 8, 2, 16, 0, 26, 219, DateTimeKind.Local).AddTicks(7183), new DateTime(2022, 12, 22, 20, 11, 43, 987, DateTimeKind.Local).AddTicks(1082), 36, 6.15586495165663m },
                    { 43, 132, new DateTime(2022, 10, 25, 10, 52, 23, 506, DateTimeKind.Local).AddTicks(3232), new DateTime(2022, 12, 30, 21, 27, 51, 804, DateTimeKind.Local).AddTicks(3795), 86, 17.7325112380002m },
                    { 44, 121, new DateTime(2022, 11, 27, 18, 32, 47, 684, DateTimeKind.Local).AddTicks(9677), new DateTime(2022, 7, 19, 23, 36, 3, 562, DateTimeKind.Local).AddTicks(2216), 74, 13.6553882661891m },
                    { 45, 77, new DateTime(2023, 3, 18, 10, 25, 37, 248, DateTimeKind.Local).AddTicks(9746), new DateTime(2022, 12, 13, 6, 19, 41, 914, DateTimeKind.Local).AddTicks(3970), 80, 28.2621208549917m },
                    { 46, 135, new DateTime(2023, 3, 30, 15, 32, 18, 933, DateTimeKind.Local).AddTicks(7635), new DateTime(2022, 7, 25, 7, 50, 54, 940, DateTimeKind.Local).AddTicks(3175), 39, 16.2193862537228m },
                    { 47, 130, new DateTime(2022, 12, 25, 17, 48, 52, 642, DateTimeKind.Local).AddTicks(2928), new DateTime(2022, 6, 1, 6, 39, 44, 374, DateTimeKind.Local).AddTicks(1827), 97, 10.1121366661333m },
                    { 48, 62, new DateTime(2022, 11, 6, 19, 11, 42, 742, DateTimeKind.Local).AddTicks(1942), new DateTime(2022, 10, 3, 12, 38, 32, 732, DateTimeKind.Local).AddTicks(8607), 65, 4.68939283405427m },
                    { 49, 57, new DateTime(2022, 5, 29, 18, 14, 41, 326, DateTimeKind.Local).AddTicks(9156), new DateTime(2022, 12, 18, 8, 5, 50, 322, DateTimeKind.Local).AddTicks(8321), 35, 26.5684646576377m },
                    { 50, 103, new DateTime(2022, 6, 19, 8, 4, 36, 311, DateTimeKind.Local).AddTicks(1243), new DateTime(2023, 1, 12, 3, 23, 29, 994, DateTimeKind.Local).AddTicks(710), 33, 7.36120598149009m },
                    { 51, 49, new DateTime(2022, 11, 27, 4, 26, 18, 287, DateTimeKind.Local).AddTicks(5349), new DateTime(2023, 2, 17, 23, 54, 4, 206, DateTimeKind.Local).AddTicks(7018), 98, 1.07849973924136m },
                    { 52, 143, new DateTime(2022, 10, 21, 15, 33, 56, 877, DateTimeKind.Local).AddTicks(1148), new DateTime(2022, 6, 20, 0, 7, 7, 89, DateTimeKind.Local).AddTicks(4418), 10, 3.15657555608517m },
                    { 53, 67, new DateTime(2022, 7, 1, 16, 54, 6, 689, DateTimeKind.Local).AddTicks(503), new DateTime(2023, 2, 11, 5, 30, 18, 264, DateTimeKind.Local).AddTicks(6195), 23, 19.1586656254683m },
                    { 54, 2, new DateTime(2023, 2, 20, 11, 53, 30, 297, DateTimeKind.Local).AddTicks(3141), new DateTime(2023, 1, 3, 5, 27, 50, 544, DateTimeKind.Local).AddTicks(3598), 24, 2.68532561499336m },
                    { 55, 23, new DateTime(2023, 3, 10, 19, 47, 49, 68, DateTimeKind.Local).AddTicks(2937), new DateTime(2022, 10, 17, 4, 38, 1, 769, DateTimeKind.Local).AddTicks(4223), 95, 12.1470638952508m },
                    { 56, 125, new DateTime(2022, 8, 15, 2, 17, 29, 867, DateTimeKind.Local).AddTicks(958), new DateTime(2022, 11, 4, 9, 35, 18, 488, DateTimeKind.Local).AddTicks(5769), 53, 4.76849910891438m },
                    { 57, 141, new DateTime(2022, 5, 5, 16, 47, 19, 235, DateTimeKind.Local).AddTicks(5825), new DateTime(2022, 12, 4, 17, 50, 34, 331, DateTimeKind.Local).AddTicks(6363), 44, 15.1580458695068m },
                    { 58, 9, new DateTime(2022, 11, 16, 14, 10, 32, 580, DateTimeKind.Local).AddTicks(7075), new DateTime(2023, 3, 6, 5, 48, 26, 924, DateTimeKind.Local).AddTicks(3424), 93, 6.50410623869881m },
                    { 59, 124, new DateTime(2022, 12, 5, 16, 9, 22, 106, DateTimeKind.Local).AddTicks(1933), new DateTime(2023, 3, 24, 3, 37, 18, 2, DateTimeKind.Local).AddTicks(5877), 69, 22.4334815894795m },
                    { 60, 134, new DateTime(2022, 8, 29, 8, 50, 52, 767, DateTimeKind.Local).AddTicks(3326), new DateTime(2023, 4, 12, 7, 55, 3, 125, DateTimeKind.Local).AddTicks(3914), 52, 17.2830243562086m },
                    { 61, 73, new DateTime(2022, 8, 20, 16, 32, 41, 331, DateTimeKind.Local).AddTicks(3170), new DateTime(2023, 1, 31, 16, 12, 49, 93, DateTimeKind.Local).AddTicks(4464), 38, 26.4124049982059m },
                    { 62, 40, new DateTime(2022, 12, 28, 15, 56, 42, 397, DateTimeKind.Local).AddTicks(1413), new DateTime(2022, 12, 14, 23, 13, 37, 592, DateTimeKind.Local).AddTicks(8410), 63, 24.1326857577897m },
                    { 63, 90, new DateTime(2022, 11, 29, 22, 50, 53, 635, DateTimeKind.Local).AddTicks(6449), new DateTime(2023, 2, 10, 1, 3, 6, 500, DateTimeKind.Local).AddTicks(7276), 23, 21.6994653583365m },
                    { 64, 50, new DateTime(2022, 7, 21, 22, 51, 39, 558, DateTimeKind.Local).AddTicks(6319), new DateTime(2023, 2, 19, 23, 51, 48, 388, DateTimeKind.Local).AddTicks(9487), 59, 26.7805833193018m },
                    { 65, 141, new DateTime(2022, 7, 27, 7, 1, 0, 8, DateTimeKind.Local).AddTicks(1249), new DateTime(2023, 2, 17, 19, 48, 21, 825, DateTimeKind.Local).AddTicks(8042), 66, 21.1880014048142m },
                    { 66, 19, new DateTime(2022, 5, 22, 2, 44, 32, 973, DateTimeKind.Local).AddTicks(7758), new DateTime(2023, 2, 14, 22, 42, 16, 107, DateTimeKind.Local).AddTicks(136), 1, 7.4011395690262m },
                    { 67, 102, new DateTime(2022, 10, 19, 10, 52, 52, 833, DateTimeKind.Local).AddTicks(1730), new DateTime(2022, 11, 15, 8, 41, 53, 507, DateTimeKind.Local).AddTicks(1006), 3, 6.29342599635244m },
                    { 68, 14, new DateTime(2022, 7, 8, 19, 12, 29, 907, DateTimeKind.Local).AddTicks(4045), new DateTime(2023, 3, 24, 12, 38, 52, 386, DateTimeKind.Local).AddTicks(4118), 66, 18.2935984886435m },
                    { 69, 14, new DateTime(2023, 3, 4, 10, 33, 35, 69, DateTimeKind.Local).AddTicks(3079), new DateTime(2023, 4, 1, 5, 52, 15, 308, DateTimeKind.Local).AddTicks(8756), 53, 10.4960359810795m },
                    { 70, 70, new DateTime(2022, 6, 19, 1, 56, 47, 287, DateTimeKind.Local).AddTicks(101), new DateTime(2023, 2, 11, 22, 13, 50, 147, DateTimeKind.Local).AddTicks(2913), 18, 29.8033109158206m },
                    { 71, 92, new DateTime(2023, 2, 26, 3, 53, 23, 589, DateTimeKind.Local).AddTicks(6820), new DateTime(2022, 12, 19, 3, 37, 53, 759, DateTimeKind.Local).AddTicks(4004), 65, 25.0586951692941m },
                    { 72, 36, new DateTime(2022, 10, 6, 8, 32, 0, 547, DateTimeKind.Local).AddTicks(1407), new DateTime(2022, 12, 6, 10, 13, 1, 316, DateTimeKind.Local).AddTicks(402), 69, 11.6832565409904m },
                    { 73, 32, new DateTime(2022, 11, 18, 18, 2, 16, 520, DateTimeKind.Local).AddTicks(8528), new DateTime(2022, 9, 18, 10, 26, 31, 264, DateTimeKind.Local).AddTicks(2942), 9, 3.38947139034483m },
                    { 74, 71, new DateTime(2023, 4, 14, 14, 28, 22, 620, DateTimeKind.Local).AddTicks(718), new DateTime(2023, 1, 11, 15, 23, 14, 580, DateTimeKind.Local).AddTicks(9345), 17, 9.18719670936982m },
                    { 75, 74, new DateTime(2023, 2, 11, 14, 37, 35, 795, DateTimeKind.Local).AddTicks(654), new DateTime(2022, 5, 6, 15, 35, 1, 863, DateTimeKind.Local).AddTicks(1590), 59, 6.66939427269191m },
                    { 76, 133, new DateTime(2022, 8, 9, 19, 51, 43, 870, DateTimeKind.Local).AddTicks(5533), new DateTime(2023, 2, 23, 0, 43, 8, 873, DateTimeKind.Local).AddTicks(5295), 78, 21.8112516568499m },
                    { 77, 48, new DateTime(2022, 8, 19, 11, 27, 13, 934, DateTimeKind.Local).AddTicks(7464), new DateTime(2022, 10, 16, 4, 25, 50, 860, DateTimeKind.Local).AddTicks(6063), 83, 21.9217025877459m },
                    { 78, 105, new DateTime(2022, 4, 25, 12, 1, 37, 448, DateTimeKind.Local).AddTicks(4807), new DateTime(2023, 2, 4, 18, 32, 31, 134, DateTimeKind.Local).AddTicks(3940), 22, 11.9095773829228m },
                    { 79, 83, new DateTime(2022, 10, 10, 18, 29, 3, 23, DateTimeKind.Local).AddTicks(2325), new DateTime(2022, 11, 22, 18, 55, 9, 288, DateTimeKind.Local).AddTicks(8881), 12, 17.0592689080393m },
                    { 80, 87, new DateTime(2022, 10, 21, 16, 4, 1, 954, DateTimeKind.Local).AddTicks(2711), new DateTime(2022, 6, 29, 7, 29, 57, 644, DateTimeKind.Local).AddTicks(7125), 99, 23.0871996412327m },
                    { 81, 20, new DateTime(2022, 12, 17, 5, 29, 15, 384, DateTimeKind.Local).AddTicks(5762), new DateTime(2022, 11, 5, 6, 6, 30, 431, DateTimeKind.Local).AddTicks(3561), 16, 16.0586922096704m },
                    { 82, 30, new DateTime(2022, 5, 25, 8, 59, 27, 241, DateTimeKind.Local).AddTicks(2212), new DateTime(2023, 3, 28, 19, 35, 32, 50, DateTimeKind.Local).AddTicks(7673), 69, 9.21098774292454m },
                    { 83, 129, new DateTime(2022, 10, 30, 19, 52, 52, 303, DateTimeKind.Local).AddTicks(5452), new DateTime(2022, 8, 7, 13, 1, 56, 142, DateTimeKind.Local).AddTicks(4806), 9, 24.0894100480675m },
                    { 84, 133, new DateTime(2022, 11, 22, 0, 23, 8, 76, DateTimeKind.Local).AddTicks(6329), new DateTime(2022, 7, 11, 13, 6, 40, 338, DateTimeKind.Local).AddTicks(8484), 30, 24.4434107090699m },
                    { 85, 149, new DateTime(2022, 10, 17, 15, 1, 22, 457, DateTimeKind.Local).AddTicks(9911), new DateTime(2022, 12, 2, 15, 28, 23, 329, DateTimeKind.Local).AddTicks(8281), 93, 4.43945736877896m },
                    { 86, 5, new DateTime(2023, 2, 21, 22, 17, 51, 417, DateTimeKind.Local).AddTicks(3826), new DateTime(2022, 11, 23, 5, 15, 24, 299, DateTimeKind.Local).AddTicks(884), 58, 8.9195234989831m },
                    { 87, 33, new DateTime(2022, 10, 29, 22, 30, 8, 326, DateTimeKind.Local).AddTicks(808), new DateTime(2022, 8, 31, 13, 54, 25, 710, DateTimeKind.Local).AddTicks(6784), 24, 2.44306424540179m },
                    { 88, 92, new DateTime(2023, 1, 7, 2, 31, 5, 198, DateTimeKind.Local).AddTicks(8709), new DateTime(2023, 4, 14, 5, 54, 54, 217, DateTimeKind.Local).AddTicks(2776), 97, 26.3701052509295m },
                    { 89, 57, new DateTime(2022, 7, 1, 17, 59, 12, 219, DateTimeKind.Local).AddTicks(3192), new DateTime(2022, 8, 23, 16, 13, 0, 979, DateTimeKind.Local).AddTicks(8451), 1, 25.6362357078272m },
                    { 90, 36, new DateTime(2022, 10, 29, 15, 27, 2, 673, DateTimeKind.Local).AddTicks(3818), new DateTime(2022, 8, 27, 22, 52, 43, 84, DateTimeKind.Local).AddTicks(6195), 56, 26.5112205730217m },
                    { 91, 91, new DateTime(2022, 11, 16, 11, 59, 17, 111, DateTimeKind.Local).AddTicks(5001), new DateTime(2022, 12, 7, 11, 46, 59, 836, DateTimeKind.Local).AddTicks(6015), 43, 27.0504390981631m },
                    { 92, 43, new DateTime(2022, 5, 22, 4, 3, 15, 729, DateTimeKind.Local).AddTicks(5327), new DateTime(2023, 1, 20, 20, 36, 47, 940, DateTimeKind.Local).AddTicks(6809), 24, 18.4474718079907m },
                    { 93, 113, new DateTime(2022, 10, 28, 2, 11, 1, 90, DateTimeKind.Local).AddTicks(4214), new DateTime(2022, 4, 17, 4, 44, 5, 92, DateTimeKind.Local).AddTicks(2308), 16, 16.7984619096944m },
                    { 94, 18, new DateTime(2023, 1, 26, 10, 47, 35, 73, DateTimeKind.Local).AddTicks(1992), new DateTime(2023, 2, 28, 12, 31, 50, 383, DateTimeKind.Local).AddTicks(6305), 9, 15.676772339607m },
                    { 95, 141, new DateTime(2023, 1, 30, 6, 48, 23, 736, DateTimeKind.Local).AddTicks(3108), new DateTime(2022, 10, 27, 4, 48, 31, 240, DateTimeKind.Local).AddTicks(155), 99, 3.24951084976504m },
                    { 96, 41, new DateTime(2023, 3, 14, 5, 59, 53, 706, DateTimeKind.Local).AddTicks(1886), new DateTime(2022, 10, 23, 15, 55, 30, 844, DateTimeKind.Local).AddTicks(2505), 74, 14.451412882233m },
                    { 97, 68, new DateTime(2022, 8, 9, 16, 13, 22, 446, DateTimeKind.Local).AddTicks(1644), new DateTime(2022, 5, 17, 2, 23, 47, 680, DateTimeKind.Local).AddTicks(8378), 59, 18.4437715576937m },
                    { 98, 113, new DateTime(2023, 1, 29, 16, 18, 56, 407, DateTimeKind.Local).AddTicks(984), new DateTime(2022, 8, 6, 22, 1, 5, 185, DateTimeKind.Local).AddTicks(6001), 10, 16.3461409722149m },
                    { 99, 130, new DateTime(2022, 5, 5, 19, 13, 38, 895, DateTimeKind.Local).AddTicks(5388), new DateTime(2022, 4, 25, 23, 52, 51, 113, DateTimeKind.Local).AddTicks(8754), 54, 24.9541909078605m },
                    { 100, 119, new DateTime(2023, 2, 17, 13, 6, 41, 926, DateTimeKind.Local).AddTicks(5989), new DateTime(2022, 5, 3, 19, 20, 35, 815, DateTimeKind.Local).AddTicks(3877), 62, 26.8701977127847m },
                    { 101, 35, new DateTime(2022, 10, 25, 10, 28, 13, 500, DateTimeKind.Local).AddTicks(1977), new DateTime(2023, 1, 29, 3, 15, 26, 86, DateTimeKind.Local).AddTicks(5385), 32, 21.1827151797721m },
                    { 102, 42, new DateTime(2022, 5, 15, 2, 47, 27, 34, DateTimeKind.Local).AddTicks(6120), new DateTime(2022, 5, 25, 15, 15, 5, 498, DateTimeKind.Local).AddTicks(2186), 15, 11.5853212180893m },
                    { 103, 100, new DateTime(2022, 8, 18, 18, 48, 50, 453, DateTimeKind.Local).AddTicks(8082), new DateTime(2022, 9, 1, 15, 36, 3, 272, DateTimeKind.Local).AddTicks(6093), 16, 13.5284640150014m },
                    { 104, 149, new DateTime(2022, 5, 23, 17, 34, 42, 341, DateTimeKind.Local).AddTicks(3018), new DateTime(2023, 2, 18, 20, 11, 53, 330, DateTimeKind.Local).AddTicks(1040), 4, 20.9982805479655m },
                    { 105, 141, new DateTime(2022, 7, 10, 0, 5, 34, 120, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 7, 3, 21, 12, 54, 712, DateTimeKind.Local).AddTicks(5810), 52, 21.7230826849714m },
                    { 106, 148, new DateTime(2023, 2, 23, 9, 12, 4, 309, DateTimeKind.Local).AddTicks(8582), new DateTime(2022, 11, 21, 14, 18, 15, 540, DateTimeKind.Local).AddTicks(536), 61, 28.6952064618386m },
                    { 107, 117, new DateTime(2022, 10, 27, 21, 58, 42, 623, DateTimeKind.Local).AddTicks(1678), new DateTime(2023, 1, 24, 6, 0, 58, 235, DateTimeKind.Local).AddTicks(6584), 55, 8.69716791905309m },
                    { 108, 37, new DateTime(2022, 10, 11, 1, 22, 47, 382, DateTimeKind.Local).AddTicks(3095), new DateTime(2023, 2, 3, 5, 55, 29, 371, DateTimeKind.Local).AddTicks(6218), 17, 21.4742364040466m },
                    { 109, 39, new DateTime(2023, 2, 18, 14, 19, 51, 156, DateTimeKind.Local).AddTicks(8014), new DateTime(2022, 10, 11, 22, 26, 50, 784, DateTimeKind.Local).AddTicks(2851), 78, 22.2228883556838m },
                    { 110, 132, new DateTime(2022, 12, 15, 3, 31, 8, 177, DateTimeKind.Local).AddTicks(1987), new DateTime(2022, 12, 22, 8, 56, 36, 35, DateTimeKind.Local).AddTicks(5205), 80, 22.6241809845569m },
                    { 111, 119, new DateTime(2022, 7, 14, 11, 1, 34, 177, DateTimeKind.Local).AddTicks(3935), new DateTime(2022, 11, 10, 0, 59, 32, 221, DateTimeKind.Local).AddTicks(5039), 54, 25.1669030686787m },
                    { 112, 89, new DateTime(2022, 8, 18, 20, 2, 5, 56, DateTimeKind.Local).AddTicks(4216), new DateTime(2022, 10, 1, 15, 9, 1, 462, DateTimeKind.Local).AddTicks(677), 10, 26.2656713272674m },
                    { 113, 119, new DateTime(2022, 10, 31, 18, 58, 52, 509, DateTimeKind.Local).AddTicks(7823), new DateTime(2022, 8, 10, 10, 7, 27, 160, DateTimeKind.Local).AddTicks(4464), 97, 3.41141139218006m },
                    { 114, 57, new DateTime(2022, 12, 9, 17, 32, 6, 529, DateTimeKind.Local).AddTicks(2478), new DateTime(2022, 12, 17, 7, 51, 22, 460, DateTimeKind.Local).AddTicks(8954), 3, 4.45849705796043m },
                    { 115, 12, new DateTime(2022, 8, 14, 19, 9, 49, 382, DateTimeKind.Local).AddTicks(9474), new DateTime(2022, 12, 2, 3, 16, 37, 188, DateTimeKind.Local).AddTicks(6082), 9, 1.35678769021832m },
                    { 116, 105, new DateTime(2022, 7, 26, 14, 50, 55, 342, DateTimeKind.Local).AddTicks(9986), new DateTime(2022, 5, 16, 23, 29, 39, 970, DateTimeKind.Local).AddTicks(4904), 81, 22.605690213388m },
                    { 117, 70, new DateTime(2022, 6, 12, 9, 26, 43, 687, DateTimeKind.Local).AddTicks(4032), new DateTime(2022, 7, 6, 9, 33, 22, 634, DateTimeKind.Local).AddTicks(6262), 16, 2.12885159120503m },
                    { 118, 59, new DateTime(2022, 12, 6, 16, 32, 54, 873, DateTimeKind.Local).AddTicks(4405), new DateTime(2022, 8, 25, 21, 11, 41, 410, DateTimeKind.Local).AddTicks(8058), 84, 10.8011945971127m },
                    { 119, 68, new DateTime(2023, 1, 14, 15, 0, 13, 234, DateTimeKind.Local).AddTicks(6056), new DateTime(2022, 6, 23, 19, 52, 22, 764, DateTimeKind.Local).AddTicks(5581), 61, 14.3053788006831m },
                    { 120, 107, new DateTime(2022, 12, 26, 5, 54, 48, 470, DateTimeKind.Local).AddTicks(7526), new DateTime(2022, 5, 3, 2, 24, 53, 995, DateTimeKind.Local).AddTicks(4674), 24, 22.0863431011686m },
                    { 121, 140, new DateTime(2023, 1, 11, 12, 24, 50, 777, DateTimeKind.Local).AddTicks(2635), new DateTime(2022, 11, 28, 20, 24, 35, 16, DateTimeKind.Local).AddTicks(1611), 12, 9.23540709198864m },
                    { 122, 125, new DateTime(2023, 2, 12, 0, 28, 1, 485, DateTimeKind.Local).AddTicks(3232), new DateTime(2022, 11, 19, 9, 17, 42, 797, DateTimeKind.Local).AddTicks(5656), 80, 13.6576084768157m },
                    { 123, 124, new DateTime(2022, 11, 12, 10, 43, 24, 282, DateTimeKind.Local).AddTicks(4152), new DateTime(2022, 7, 26, 2, 31, 10, 922, DateTimeKind.Local).AddTicks(8980), 91, 18.7844977102269m },
                    { 124, 145, new DateTime(2022, 10, 13, 14, 6, 8, 125, DateTimeKind.Local).AddTicks(7187), new DateTime(2022, 6, 14, 4, 28, 23, 105, DateTimeKind.Local).AddTicks(3994), 22, 4.58072688452787m },
                    { 125, 126, new DateTime(2023, 1, 4, 1, 52, 47, 341, DateTimeKind.Local).AddTicks(8032), new DateTime(2022, 8, 27, 14, 32, 16, 413, DateTimeKind.Local).AddTicks(5051), 8, 6.17003090167647m },
                    { 126, 133, new DateTime(2022, 8, 3, 23, 48, 10, 759, DateTimeKind.Local).AddTicks(1803), new DateTime(2022, 9, 16, 17, 30, 26, 327, DateTimeKind.Local).AddTicks(7680), 75, 16.7189146097759m },
                    { 127, 123, new DateTime(2023, 3, 17, 22, 32, 38, 644, DateTimeKind.Local).AddTicks(718), new DateTime(2022, 9, 19, 9, 20, 40, 227, DateTimeKind.Local).AddTicks(4009), 44, 12.9955929072402m },
                    { 128, 81, new DateTime(2023, 3, 11, 22, 11, 18, 163, DateTimeKind.Local).AddTicks(2690), new DateTime(2022, 11, 29, 22, 33, 4, 839, DateTimeKind.Local).AddTicks(9080), 13, 4.07755255779491m },
                    { 129, 108, new DateTime(2023, 1, 14, 0, 6, 35, 913, DateTimeKind.Local).AddTicks(8824), new DateTime(2022, 5, 29, 7, 2, 57, 175, DateTimeKind.Local).AddTicks(955), 78, 25.8728011825926m },
                    { 130, 52, new DateTime(2023, 3, 1, 12, 31, 38, 94, DateTimeKind.Local).AddTicks(6120), new DateTime(2022, 12, 20, 2, 53, 35, 84, DateTimeKind.Local).AddTicks(2475), 44, 16.3022637959415m },
                    { 131, 66, new DateTime(2022, 6, 2, 20, 35, 30, 816, DateTimeKind.Local).AddTicks(6127), new DateTime(2023, 4, 11, 3, 54, 32, 433, DateTimeKind.Local).AddTicks(3929), 29, 1.26287820758647m },
                    { 132, 96, new DateTime(2022, 11, 10, 18, 34, 52, 747, DateTimeKind.Local).AddTicks(7633), new DateTime(2022, 8, 26, 6, 22, 27, 954, DateTimeKind.Local).AddTicks(1970), 97, 21.1655316855436m },
                    { 133, 62, new DateTime(2022, 7, 19, 14, 42, 50, 733, DateTimeKind.Local).AddTicks(2699), new DateTime(2022, 11, 23, 17, 10, 20, 517, DateTimeKind.Local).AddTicks(1374), 95, 22.4106238445218m },
                    { 134, 101, new DateTime(2023, 1, 30, 16, 6, 34, 122, DateTimeKind.Local).AddTicks(393), new DateTime(2023, 1, 19, 11, 43, 29, 279, DateTimeKind.Local).AddTicks(3459), 44, 10.9319055829329m },
                    { 135, 103, new DateTime(2022, 5, 6, 18, 53, 33, 897, DateTimeKind.Local).AddTicks(8322), new DateTime(2022, 4, 25, 8, 13, 1, 203, DateTimeKind.Local).AddTicks(3184), 23, 18.8893402758146m },
                    { 136, 91, new DateTime(2023, 1, 3, 13, 21, 58, 391, DateTimeKind.Local).AddTicks(8178), new DateTime(2022, 12, 1, 10, 20, 18, 479, DateTimeKind.Local).AddTicks(7418), 76, 23.9758096428316m },
                    { 137, 8, new DateTime(2022, 5, 3, 17, 13, 51, 7, DateTimeKind.Local).AddTicks(1695), new DateTime(2022, 10, 17, 4, 54, 3, 701, DateTimeKind.Local).AddTicks(9818), 74, 1.45351592266264m },
                    { 138, 94, new DateTime(2022, 11, 21, 1, 4, 34, 657, DateTimeKind.Local).AddTicks(3686), new DateTime(2022, 7, 24, 5, 45, 22, 130, DateTimeKind.Local).AddTicks(8715), 72, 4.56366376357536m },
                    { 139, 144, new DateTime(2022, 12, 11, 7, 4, 46, 390, DateTimeKind.Local).AddTicks(2877), new DateTime(2022, 12, 24, 5, 11, 29, 410, DateTimeKind.Local).AddTicks(126), 72, 3.91243596227496m },
                    { 140, 103, new DateTime(2022, 9, 3, 14, 3, 48, 626, DateTimeKind.Local).AddTicks(8105), new DateTime(2022, 6, 27, 6, 31, 27, 594, DateTimeKind.Local).AddTicks(2098), 2, 24.0414929751034m },
                    { 141, 67, new DateTime(2022, 8, 31, 13, 15, 39, 841, DateTimeKind.Local).AddTicks(4736), new DateTime(2022, 7, 30, 4, 26, 4, 702, DateTimeKind.Local).AddTicks(9662), 39, 24.3728524195107m },
                    { 142, 106, new DateTime(2022, 5, 6, 21, 11, 9, 666, DateTimeKind.Local).AddTicks(9925), new DateTime(2023, 3, 9, 12, 56, 58, 284, DateTimeKind.Local).AddTicks(9009), 80, 10.1294449442823m },
                    { 143, 3, new DateTime(2022, 8, 21, 4, 59, 16, 346, DateTimeKind.Local).AddTicks(8099), new DateTime(2022, 7, 13, 3, 31, 34, 424, DateTimeKind.Local).AddTicks(9564), 52, 21.2805571477942m },
                    { 144, 23, new DateTime(2022, 9, 20, 15, 8, 43, 80, DateTimeKind.Local).AddTicks(917), new DateTime(2022, 8, 7, 11, 22, 19, 191, DateTimeKind.Local).AddTicks(7054), 41, 8.38653748944454m },
                    { 145, 75, new DateTime(2023, 1, 3, 0, 35, 11, 474, DateTimeKind.Local).AddTicks(3901), new DateTime(2022, 5, 16, 10, 18, 28, 684, DateTimeKind.Local).AddTicks(8616), 16, 5.5544632007279m },
                    { 146, 140, new DateTime(2022, 5, 13, 11, 12, 22, 453, DateTimeKind.Local).AddTicks(1216), new DateTime(2022, 12, 18, 8, 3, 59, 861, DateTimeKind.Local).AddTicks(7168), 69, 25.5799847673141m },
                    { 147, 2, new DateTime(2022, 8, 11, 23, 7, 53, 978, DateTimeKind.Local).AddTicks(4776), new DateTime(2022, 10, 24, 21, 24, 53, 341, DateTimeKind.Local).AddTicks(7919), 2, 1.72049445938745m },
                    { 148, 135, new DateTime(2023, 1, 24, 2, 48, 7, 247, DateTimeKind.Local).AddTicks(7933), new DateTime(2022, 9, 29, 1, 12, 12, 928, DateTimeKind.Local).AddTicks(9322), 33, 1.41542399203702m },
                    { 149, 22, new DateTime(2022, 9, 14, 9, 58, 32, 425, DateTimeKind.Local).AddTicks(7341), new DateTime(2022, 12, 23, 14, 36, 51, 740, DateTimeKind.Local).AddTicks(7166), 7, 1.61156989195369m },
                    { 150, 86, new DateTime(2022, 9, 18, 8, 21, 15, 21, DateTimeKind.Local).AddTicks(9495), new DateTime(2023, 4, 5, 17, 20, 33, 739, DateTimeKind.Local).AddTicks(3082), 98, 25.8917530649375m },
                    { 151, 128, new DateTime(2022, 4, 21, 9, 13, 32, 10, DateTimeKind.Local).AddTicks(1676), new DateTime(2022, 8, 4, 1, 49, 9, 292, DateTimeKind.Local).AddTicks(9770), 11, 27.2559294464744m },
                    { 152, 97, new DateTime(2022, 12, 17, 11, 10, 25, 275, DateTimeKind.Local).AddTicks(4913), new DateTime(2022, 9, 21, 8, 46, 0, 73, DateTimeKind.Local).AddTicks(8059), 98, 19.5279767362964m },
                    { 153, 99, new DateTime(2023, 2, 19, 23, 22, 16, 485, DateTimeKind.Local).AddTicks(6165), new DateTime(2022, 10, 9, 17, 42, 20, 121, DateTimeKind.Local).AddTicks(1226), 40, 19.3216497600514m },
                    { 154, 105, new DateTime(2023, 3, 3, 14, 41, 24, 224, DateTimeKind.Local).AddTicks(4594), new DateTime(2022, 10, 31, 3, 35, 50, 158, DateTimeKind.Local).AddTicks(2453), 41, 10.372543598945m },
                    { 155, 45, new DateTime(2022, 8, 3, 23, 56, 38, 804, DateTimeKind.Local).AddTicks(7498), new DateTime(2022, 7, 3, 12, 3, 45, 281, DateTimeKind.Local).AddTicks(8377), 52, 29.6981978975024m },
                    { 156, 71, new DateTime(2022, 7, 6, 9, 37, 2, 191, DateTimeKind.Local).AddTicks(5423), new DateTime(2022, 9, 4, 3, 47, 37, 406, DateTimeKind.Local).AddTicks(2326), 3, 25.802462287863m },
                    { 157, 16, new DateTime(2022, 8, 6, 3, 38, 48, 175, DateTimeKind.Local).AddTicks(8713), new DateTime(2023, 1, 11, 1, 15, 0, 978, DateTimeKind.Local).AddTicks(2041), 80, 5.84308197406384m },
                    { 158, 39, new DateTime(2022, 7, 30, 14, 28, 27, 348, DateTimeKind.Local).AddTicks(8551), new DateTime(2022, 9, 12, 15, 55, 29, 661, DateTimeKind.Local).AddTicks(9922), 57, 18.8103349763117m },
                    { 159, 39, new DateTime(2022, 6, 24, 0, 17, 8, 482, DateTimeKind.Local).AddTicks(9380), new DateTime(2022, 6, 15, 6, 35, 21, 73, DateTimeKind.Local).AddTicks(9246), 93, 4.38023020550286m },
                    { 160, 34, new DateTime(2022, 12, 8, 10, 57, 54, 831, DateTimeKind.Local).AddTicks(4932), new DateTime(2022, 12, 1, 1, 58, 36, 92, DateTimeKind.Local).AddTicks(2484), 95, 14.6541040263608m },
                    { 161, 17, new DateTime(2023, 3, 16, 18, 32, 13, 737, DateTimeKind.Local).AddTicks(9282), new DateTime(2022, 8, 14, 2, 39, 39, 321, DateTimeKind.Local).AddTicks(2156), 69, 7.23906803478884m },
                    { 162, 107, new DateTime(2023, 2, 23, 10, 51, 35, 651, DateTimeKind.Local).AddTicks(1343), new DateTime(2022, 12, 2, 15, 9, 36, 733, DateTimeKind.Local).AddTicks(5767), 75, 5.62971970106009m },
                    { 163, 20, new DateTime(2022, 6, 30, 14, 36, 53, 77, DateTimeKind.Local).AddTicks(5611), new DateTime(2022, 8, 10, 10, 44, 22, 289, DateTimeKind.Local).AddTicks(5353), 3, 20.2958687035652m },
                    { 164, 119, new DateTime(2023, 4, 15, 16, 25, 19, 645, DateTimeKind.Local).AddTicks(2508), new DateTime(2022, 8, 26, 5, 17, 14, 303, DateTimeKind.Local).AddTicks(1724), 88, 2.3163598632484m },
                    { 165, 56, new DateTime(2022, 5, 19, 21, 11, 59, 479, DateTimeKind.Local).AddTicks(8289), new DateTime(2022, 6, 3, 12, 21, 12, 38, DateTimeKind.Local).AddTicks(7967), 8, 15.8897891635495m },
                    { 166, 11, new DateTime(2022, 4, 15, 19, 23, 45, 181, DateTimeKind.Local).AddTicks(8399), new DateTime(2023, 2, 25, 21, 22, 58, 690, DateTimeKind.Local).AddTicks(9404), 95, 23.9516389085475m },
                    { 167, 85, new DateTime(2022, 9, 11, 20, 46, 12, 379, DateTimeKind.Local).AddTicks(7935), new DateTime(2023, 2, 20, 2, 8, 9, 969, DateTimeKind.Local).AddTicks(1693), 95, 27.3468088191276m },
                    { 168, 43, new DateTime(2022, 10, 12, 4, 6, 22, 696, DateTimeKind.Local).AddTicks(2224), new DateTime(2022, 12, 30, 9, 38, 55, 929, DateTimeKind.Local).AddTicks(4651), 89, 1.09809077724064m },
                    { 169, 49, new DateTime(2023, 3, 10, 19, 14, 31, 528, DateTimeKind.Local).AddTicks(5202), new DateTime(2022, 5, 16, 5, 35, 30, 615, DateTimeKind.Local).AddTicks(8412), 95, 13.7030077204548m },
                    { 170, 16, new DateTime(2022, 6, 3, 21, 12, 38, 753, DateTimeKind.Local).AddTicks(4106), new DateTime(2023, 3, 16, 14, 33, 33, 112, DateTimeKind.Local).AddTicks(9342), 39, 8.25383094502144m },
                    { 171, 49, new DateTime(2023, 1, 19, 8, 32, 8, 472, DateTimeKind.Local).AddTicks(6277), new DateTime(2022, 11, 7, 2, 1, 43, 50, DateTimeKind.Local).AddTicks(9351), 97, 7.54591391804268m },
                    { 172, 5, new DateTime(2022, 7, 27, 11, 54, 4, 351, DateTimeKind.Local).AddTicks(4759), new DateTime(2023, 2, 25, 19, 40, 48, 427, DateTimeKind.Local).AddTicks(6766), 47, 2.73332955980703m },
                    { 173, 26, new DateTime(2022, 7, 11, 16, 53, 20, 116, DateTimeKind.Local).AddTicks(7761), new DateTime(2022, 9, 17, 13, 5, 43, 284, DateTimeKind.Local).AddTicks(5490), 26, 23.5949023455247m },
                    { 174, 73, new DateTime(2022, 11, 12, 13, 2, 13, 609, DateTimeKind.Local).AddTicks(2840), new DateTime(2022, 9, 2, 1, 55, 59, 882, DateTimeKind.Local).AddTicks(4925), 32, 24.5707739478549m },
                    { 175, 143, new DateTime(2022, 7, 25, 2, 23, 29, 45, DateTimeKind.Local).AddTicks(639), new DateTime(2023, 2, 6, 18, 10, 22, 255, DateTimeKind.Local).AddTicks(6615), 12, 1.6911693855335m },
                    { 176, 149, new DateTime(2022, 10, 22, 16, 39, 14, 848, DateTimeKind.Local).AddTicks(1398), new DateTime(2022, 7, 20, 3, 38, 59, 781, DateTimeKind.Local).AddTicks(5065), 12, 10.5152536628812m },
                    { 177, 76, new DateTime(2022, 7, 21, 21, 28, 26, 714, DateTimeKind.Local).AddTicks(8445), new DateTime(2022, 9, 29, 1, 5, 33, 24, DateTimeKind.Local).AddTicks(4852), 62, 21.6059397805691m },
                    { 178, 13, new DateTime(2023, 1, 14, 5, 1, 1, 289, DateTimeKind.Local).AddTicks(4820), new DateTime(2022, 4, 28, 1, 46, 48, 513, DateTimeKind.Local).AddTicks(2937), 70, 6.87956019859586m },
                    { 179, 124, new DateTime(2022, 5, 22, 0, 23, 33, 845, DateTimeKind.Local).AddTicks(6342), new DateTime(2022, 8, 30, 19, 29, 21, 467, DateTimeKind.Local).AddTicks(1432), 51, 9.0910478478405m },
                    { 180, 85, new DateTime(2022, 8, 14, 16, 25, 50, 2, DateTimeKind.Local).AddTicks(7056), new DateTime(2022, 5, 16, 15, 34, 15, 643, DateTimeKind.Local).AddTicks(3066), 84, 10.3298370202896m },
                    { 181, 69, new DateTime(2022, 5, 23, 16, 16, 41, 452, DateTimeKind.Local).AddTicks(9160), new DateTime(2022, 7, 28, 22, 32, 38, 132, DateTimeKind.Local).AddTicks(1473), 85, 12.9576954849649m },
                    { 182, 140, new DateTime(2022, 4, 26, 2, 25, 31, 822, DateTimeKind.Local).AddTicks(7257), new DateTime(2022, 10, 29, 9, 41, 23, 208, DateTimeKind.Local).AddTicks(4717), 53, 11.8941056589033m },
                    { 183, 73, new DateTime(2022, 6, 25, 15, 35, 11, 466, DateTimeKind.Local).AddTicks(5842), new DateTime(2022, 11, 6, 22, 9, 8, 393, DateTimeKind.Local).AddTicks(1854), 91, 16.111495971222m },
                    { 184, 102, new DateTime(2022, 4, 28, 7, 11, 47, 939, DateTimeKind.Local).AddTicks(6305), new DateTime(2022, 4, 24, 22, 16, 22, 937, DateTimeKind.Local).AddTicks(6817), 39, 28.0598505055638m },
                    { 185, 75, new DateTime(2022, 6, 21, 4, 43, 13, 53, DateTimeKind.Local).AddTicks(2410), new DateTime(2022, 4, 28, 19, 1, 21, 966, DateTimeKind.Local).AddTicks(6241), 85, 17.9811572698512m },
                    { 186, 27, new DateTime(2022, 11, 4, 23, 35, 39, 789, DateTimeKind.Local).AddTicks(6559), new DateTime(2023, 2, 12, 18, 3, 49, 913, DateTimeKind.Local).AddTicks(3301), 30, 29.5469327044083m },
                    { 187, 120, new DateTime(2023, 3, 21, 9, 50, 17, 7, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 10, 16, 19, 37, 8, 166, DateTimeKind.Local).AddTicks(3323), 93, 13.9262807199095m },
                    { 188, 120, new DateTime(2022, 7, 2, 5, 30, 33, 631, DateTimeKind.Local).AddTicks(4015), new DateTime(2022, 9, 27, 15, 40, 27, 444, DateTimeKind.Local).AddTicks(8412), 59, 15.9986297944256m },
                    { 189, 122, new DateTime(2022, 12, 11, 3, 35, 29, 357, DateTimeKind.Local).AddTicks(805), new DateTime(2022, 8, 18, 1, 18, 31, 647, DateTimeKind.Local).AddTicks(6772), 28, 1.44949672796524m },
                    { 190, 115, new DateTime(2023, 1, 26, 17, 24, 6, 321, DateTimeKind.Local).AddTicks(3141), new DateTime(2022, 8, 8, 1, 20, 1, 12, DateTimeKind.Local).AddTicks(5128), 10, 23.6271865199939m },
                    { 191, 41, new DateTime(2022, 8, 24, 21, 7, 33, 494, DateTimeKind.Local).AddTicks(8285), new DateTime(2023, 1, 28, 21, 48, 47, 418, DateTimeKind.Local).AddTicks(4863), 53, 5.02125792627687m },
                    { 192, 122, new DateTime(2022, 9, 14, 2, 10, 44, 261, DateTimeKind.Local).AddTicks(5901), new DateTime(2022, 6, 17, 19, 15, 20, 205, DateTimeKind.Local).AddTicks(7000), 28, 10.3611936918467m },
                    { 193, 139, new DateTime(2022, 7, 5, 4, 37, 14, 446, DateTimeKind.Local).AddTicks(5462), new DateTime(2022, 12, 15, 10, 34, 27, 986, DateTimeKind.Local).AddTicks(4657), 86, 22.7174123259193m },
                    { 194, 106, new DateTime(2022, 9, 1, 14, 16, 26, 872, DateTimeKind.Local).AddTicks(3878), new DateTime(2022, 8, 14, 22, 48, 31, 998, DateTimeKind.Local).AddTicks(833), 75, 12.4035916137161m },
                    { 195, 109, new DateTime(2022, 6, 30, 13, 31, 34, 815, DateTimeKind.Local).AddTicks(4146), new DateTime(2022, 7, 24, 14, 10, 32, 283, DateTimeKind.Local).AddTicks(2041), 2, 19.4558918854603m },
                    { 196, 72, new DateTime(2022, 5, 30, 16, 26, 3, 834, DateTimeKind.Local).AddTicks(9589), new DateTime(2023, 3, 8, 5, 27, 17, 814, DateTimeKind.Local).AddTicks(71), 87, 16.8062098961315m },
                    { 197, 39, new DateTime(2023, 2, 16, 22, 23, 32, 922, DateTimeKind.Local).AddTicks(4514), new DateTime(2022, 9, 19, 7, 49, 1, 276, DateTimeKind.Local).AddTicks(4388), 70, 28.9771403579788m },
                    { 198, 46, new DateTime(2022, 5, 29, 10, 47, 28, 282, DateTimeKind.Local).AddTicks(1796), new DateTime(2023, 3, 17, 15, 47, 40, 731, DateTimeKind.Local).AddTicks(982), 34, 27.2381314192816m },
                    { 199, 20, new DateTime(2022, 11, 7, 21, 26, 46, 214, DateTimeKind.Local).AddTicks(7990), new DateTime(2023, 4, 7, 8, 32, 55, 691, DateTimeKind.Local).AddTicks(409), 29, 16.5459837412225m },
                    { 200, 35, new DateTime(2022, 5, 25, 3, 47, 1, 924, DateTimeKind.Local).AddTicks(487), new DateTime(2023, 3, 6, 21, 11, 20, 846, DateTimeKind.Local).AddTicks(9368), 54, 21.2639081376984m },
                    { 201, 37, new DateTime(2022, 8, 26, 1, 8, 19, 312, DateTimeKind.Local).AddTicks(6109), new DateTime(2022, 8, 18, 10, 10, 18, 892, DateTimeKind.Local).AddTicks(622), 22, 14.2021409074017m },
                    { 202, 69, new DateTime(2022, 6, 26, 7, 59, 27, 940, DateTimeKind.Local).AddTicks(7187), new DateTime(2022, 9, 17, 21, 23, 17, 861, DateTimeKind.Local).AddTicks(1555), 2, 16.6175960818843m },
                    { 203, 102, new DateTime(2022, 8, 23, 4, 46, 37, 58, DateTimeKind.Local).AddTicks(7564), new DateTime(2022, 12, 2, 8, 18, 13, 542, DateTimeKind.Local).AddTicks(4209), 20, 8.58412200035028m },
                    { 204, 74, new DateTime(2022, 6, 19, 1, 7, 28, 181, DateTimeKind.Local).AddTicks(9728), new DateTime(2023, 3, 27, 9, 48, 22, 521, DateTimeKind.Local).AddTicks(9374), 98, 11.6483992640085m },
                    { 205, 81, new DateTime(2022, 10, 8, 14, 58, 38, 977, DateTimeKind.Local).AddTicks(3977), new DateTime(2023, 4, 8, 9, 24, 14, 394, DateTimeKind.Local).AddTicks(453), 40, 24.3811416454605m },
                    { 206, 3, new DateTime(2022, 10, 18, 0, 46, 22, 638, DateTimeKind.Local).AddTicks(5676), new DateTime(2022, 9, 26, 7, 37, 42, 988, DateTimeKind.Local).AddTicks(2766), 66, 21.1388208802717m },
                    { 207, 105, new DateTime(2023, 3, 28, 4, 3, 15, 190, DateTimeKind.Local).AddTicks(1936), new DateTime(2022, 9, 3, 23, 19, 57, 889, DateTimeKind.Local).AddTicks(9039), 5, 5.56441073109988m },
                    { 208, 90, new DateTime(2023, 2, 25, 14, 5, 23, 739, DateTimeKind.Local).AddTicks(4509), new DateTime(2022, 7, 4, 13, 47, 12, 644, DateTimeKind.Local).AddTicks(2624), 27, 27.4083557419916m },
                    { 209, 103, new DateTime(2022, 10, 9, 6, 12, 34, 514, DateTimeKind.Local).AddTicks(8399), new DateTime(2022, 9, 1, 4, 39, 46, 455, DateTimeKind.Local).AddTicks(1578), 84, 21.190879670543m },
                    { 210, 33, new DateTime(2023, 3, 14, 21, 29, 29, 691, DateTimeKind.Local).AddTicks(9394), new DateTime(2023, 1, 19, 6, 56, 13, 222, DateTimeKind.Local).AddTicks(6664), 84, 6.75188540231731m },
                    { 211, 88, new DateTime(2022, 11, 27, 16, 14, 4, 320, DateTimeKind.Local).AddTicks(5949), new DateTime(2022, 8, 18, 8, 44, 10, 634, DateTimeKind.Local).AddTicks(6502), 46, 27.6332235847847m },
                    { 212, 77, new DateTime(2023, 3, 7, 16, 10, 28, 404, DateTimeKind.Local).AddTicks(445), new DateTime(2022, 6, 30, 22, 19, 49, 184, DateTimeKind.Local).AddTicks(6786), 67, 28.3892622453223m },
                    { 213, 58, new DateTime(2022, 8, 29, 18, 9, 45, 593, DateTimeKind.Local).AddTicks(1546), new DateTime(2022, 4, 16, 12, 5, 3, 4, DateTimeKind.Local).AddTicks(3336), 31, 18.7722352623059m },
                    { 214, 131, new DateTime(2022, 10, 31, 17, 40, 50, 446, DateTimeKind.Local).AddTicks(6223), new DateTime(2023, 2, 3, 8, 38, 25, 209, DateTimeKind.Local).AddTicks(7368), 72, 5.14999176461656m },
                    { 215, 13, new DateTime(2022, 9, 3, 23, 48, 25, 839, DateTimeKind.Local).AddTicks(8185), new DateTime(2022, 12, 20, 14, 10, 24, 833, DateTimeKind.Local).AddTicks(1446), 75, 26.6781328084182m },
                    { 216, 29, new DateTime(2022, 12, 25, 2, 23, 25, 613, DateTimeKind.Local).AddTicks(4010), new DateTime(2022, 9, 11, 4, 53, 36, 201, DateTimeKind.Local).AddTicks(233), 41, 14.2130827648524m },
                    { 217, 130, new DateTime(2022, 10, 2, 18, 50, 13, 500, DateTimeKind.Local).AddTicks(4103), new DateTime(2022, 12, 31, 2, 19, 8, 785, DateTimeKind.Local).AddTicks(1033), 55, 5.57284249747884m },
                    { 218, 31, new DateTime(2023, 1, 27, 9, 6, 7, 751, DateTimeKind.Local).AddTicks(6802), new DateTime(2023, 2, 10, 3, 9, 35, 581, DateTimeKind.Local).AddTicks(5230), 98, 19.4464966324685m },
                    { 219, 43, new DateTime(2022, 9, 20, 22, 26, 47, 886, DateTimeKind.Local).AddTicks(5452), new DateTime(2023, 3, 20, 21, 32, 25, 765, DateTimeKind.Local).AddTicks(5535), 45, 11.7458539602019m },
                    { 220, 126, new DateTime(2022, 5, 25, 11, 28, 53, 328, DateTimeKind.Local).AddTicks(6023), new DateTime(2022, 10, 3, 2, 54, 48, 739, DateTimeKind.Local).AddTicks(210), 64, 3.65438301664683m },
                    { 221, 39, new DateTime(2022, 12, 25, 2, 2, 3, 604, DateTimeKind.Local).AddTicks(6697), new DateTime(2022, 5, 27, 2, 23, 38, 981, DateTimeKind.Local).AddTicks(4304), 60, 27.408524679998m },
                    { 222, 21, new DateTime(2023, 3, 22, 7, 56, 48, 824, DateTimeKind.Local).AddTicks(105), new DateTime(2022, 4, 29, 14, 7, 22, 938, DateTimeKind.Local).AddTicks(5459), 97, 23.2985794902191m },
                    { 223, 49, new DateTime(2022, 6, 1, 19, 49, 1, 865, DateTimeKind.Local).AddTicks(3494), new DateTime(2022, 7, 15, 2, 13, 48, 872, DateTimeKind.Local).AddTicks(4629), 23, 12.8253128416347m },
                    { 224, 116, new DateTime(2022, 6, 15, 21, 1, 12, 341, DateTimeKind.Local).AddTicks(4417), new DateTime(2023, 1, 9, 21, 20, 6, 883, DateTimeKind.Local).AddTicks(2267), 61, 29.0627074140621m },
                    { 225, 119, new DateTime(2023, 3, 3, 23, 0, 26, 588, DateTimeKind.Local).AddTicks(6199), new DateTime(2022, 6, 29, 0, 11, 35, 671, DateTimeKind.Local).AddTicks(7227), 28, 2.24772345262711m },
                    { 226, 123, new DateTime(2022, 6, 21, 6, 16, 39, 234, DateTimeKind.Local).AddTicks(9234), new DateTime(2023, 3, 8, 19, 52, 22, 984, DateTimeKind.Local).AddTicks(9629), 98, 27.0267084577814m },
                    { 227, 68, new DateTime(2022, 9, 26, 22, 52, 6, 588, DateTimeKind.Local).AddTicks(9605), new DateTime(2022, 11, 8, 16, 50, 8, 492, DateTimeKind.Local).AddTicks(656), 17, 20.6797561981712m },
                    { 228, 58, new DateTime(2022, 9, 22, 11, 28, 36, 118, DateTimeKind.Local).AddTicks(6880), new DateTime(2022, 5, 16, 11, 50, 43, 12, DateTimeKind.Local).AddTicks(4373), 31, 23.1504437451578m },
                    { 229, 12, new DateTime(2022, 7, 24, 22, 29, 9, 95, DateTimeKind.Local).AddTicks(2472), new DateTime(2023, 2, 21, 23, 13, 45, 302, DateTimeKind.Local).AddTicks(2577), 20, 23.1727196617684m },
                    { 230, 63, new DateTime(2022, 8, 30, 22, 17, 40, 186, DateTimeKind.Local).AddTicks(3314), new DateTime(2022, 11, 19, 2, 45, 33, 737, DateTimeKind.Local).AddTicks(4576), 89, 11.8026672514567m },
                    { 231, 86, new DateTime(2023, 3, 24, 8, 37, 34, 836, DateTimeKind.Local).AddTicks(7468), new DateTime(2022, 8, 20, 13, 31, 11, 71, DateTimeKind.Local).AddTicks(1979), 80, 24.6289514331332m },
                    { 232, 70, new DateTime(2022, 9, 19, 1, 40, 6, 51, DateTimeKind.Local).AddTicks(9425), new DateTime(2022, 8, 11, 0, 56, 1, 983, DateTimeKind.Local).AddTicks(1208), 34, 6.54629958852798m },
                    { 233, 46, new DateTime(2022, 6, 30, 3, 53, 25, 891, DateTimeKind.Local).AddTicks(1551), new DateTime(2022, 6, 11, 4, 51, 31, 398, DateTimeKind.Local).AddTicks(209), 45, 3.75289144506178m },
                    { 234, 15, new DateTime(2022, 9, 25, 0, 13, 37, 73, DateTimeKind.Local).AddTicks(1678), new DateTime(2022, 7, 6, 20, 52, 6, 545, DateTimeKind.Local).AddTicks(5014), 72, 6.98295862320476m },
                    { 235, 31, new DateTime(2022, 7, 27, 4, 49, 12, 613, DateTimeKind.Local).AddTicks(7426), new DateTime(2022, 10, 8, 10, 37, 56, 429, DateTimeKind.Local).AddTicks(6110), 45, 27.5082973185449m },
                    { 236, 96, new DateTime(2022, 8, 18, 23, 9, 12, 868, DateTimeKind.Local).AddTicks(5800), new DateTime(2022, 6, 11, 16, 35, 19, 693, DateTimeKind.Local).AddTicks(8399), 59, 16.9422364018073m },
                    { 237, 144, new DateTime(2022, 9, 24, 1, 9, 55, 450, DateTimeKind.Local).AddTicks(2218), new DateTime(2022, 10, 5, 23, 38, 2, 855, DateTimeKind.Local).AddTicks(3364), 76, 20.4434497987102m },
                    { 238, 104, new DateTime(2022, 11, 28, 19, 40, 30, 10, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 6, 6, 12, 41, 23, 668, DateTimeKind.Local).AddTicks(9823), 5, 11.7528549140619m },
                    { 239, 107, new DateTime(2022, 4, 15, 22, 6, 49, 654, DateTimeKind.Local).AddTicks(7272), new DateTime(2022, 11, 18, 17, 0, 31, 530, DateTimeKind.Local).AddTicks(5445), 17, 5.85156879332333m },
                    { 240, 25, new DateTime(2022, 7, 8, 0, 11, 32, 696, DateTimeKind.Local).AddTicks(9841), new DateTime(2022, 8, 1, 9, 44, 17, 915, DateTimeKind.Local).AddTicks(273), 76, 27.1351320560138m },
                    { 241, 131, new DateTime(2022, 4, 21, 10, 46, 44, 652, DateTimeKind.Local).AddTicks(2614), new DateTime(2023, 4, 15, 8, 53, 39, 493, DateTimeKind.Local).AddTicks(2056), 88, 15.3391787481239m },
                    { 242, 108, new DateTime(2023, 2, 1, 23, 46, 47, 170, DateTimeKind.Local).AddTicks(6238), new DateTime(2023, 3, 10, 8, 48, 46, 191, DateTimeKind.Local).AddTicks(9209), 60, 5.73885991206079m },
                    { 243, 143, new DateTime(2022, 8, 2, 4, 44, 48, 105, DateTimeKind.Local).AddTicks(1490), new DateTime(2022, 8, 9, 14, 32, 6, 679, DateTimeKind.Local).AddTicks(5097), 53, 27.758723640436m },
                    { 244, 16, new DateTime(2022, 6, 21, 4, 35, 9, 164, DateTimeKind.Local).AddTicks(7778), new DateTime(2023, 2, 15, 6, 0, 16, 111, DateTimeKind.Local).AddTicks(6124), 70, 24.3543798077856m },
                    { 245, 33, new DateTime(2022, 5, 24, 8, 23, 27, 458, DateTimeKind.Local).AddTicks(2584), new DateTime(2022, 11, 29, 6, 44, 41, 861, DateTimeKind.Local).AddTicks(6298), 92, 21.6063044327106m },
                    { 246, 7, new DateTime(2022, 8, 26, 21, 3, 55, 793, DateTimeKind.Local).AddTicks(475), new DateTime(2022, 7, 12, 3, 18, 7, 227, DateTimeKind.Local).AddTicks(1847), 91, 5.30467643638963m },
                    { 247, 141, new DateTime(2022, 8, 9, 20, 46, 33, 38, DateTimeKind.Local).AddTicks(2536), new DateTime(2023, 4, 14, 10, 51, 13, 417, DateTimeKind.Local).AddTicks(2168), 93, 29.7518697730097m },
                    { 248, 23, new DateTime(2023, 4, 8, 20, 36, 11, 336, DateTimeKind.Local).AddTicks(7831), new DateTime(2023, 1, 4, 20, 45, 39, 459, DateTimeKind.Local).AddTicks(9544), 10, 11.6469289630133m },
                    { 249, 3, new DateTime(2022, 8, 25, 2, 15, 42, 43, DateTimeKind.Local).AddTicks(4013), new DateTime(2022, 7, 28, 19, 16, 30, 393, DateTimeKind.Local).AddTicks(4126), 44, 22.3446366624624m },
                    { 250, 99, new DateTime(2023, 1, 13, 5, 18, 10, 477, DateTimeKind.Local).AddTicks(4045), new DateTime(2023, 3, 31, 17, 32, 49, 318, DateTimeKind.Local).AddTicks(8463), 65, 26.6972650508204m },
                    { 251, 69, new DateTime(2023, 4, 15, 7, 55, 52, 401, DateTimeKind.Local).AddTicks(1837), new DateTime(2023, 3, 12, 21, 17, 14, 66, DateTimeKind.Local).AddTicks(9026), 76, 26.8910299373853m },
                    { 252, 105, new DateTime(2023, 2, 16, 22, 28, 39, 224, DateTimeKind.Local).AddTicks(2300), new DateTime(2023, 3, 25, 15, 27, 25, 29, DateTimeKind.Local).AddTicks(6233), 99, 26.4720886678508m },
                    { 253, 126, new DateTime(2022, 10, 18, 16, 24, 43, 410, DateTimeKind.Local).AddTicks(7345), new DateTime(2022, 10, 1, 3, 15, 50, 492, DateTimeKind.Local).AddTicks(3937), 90, 27.1669078432982m },
                    { 254, 60, new DateTime(2022, 6, 27, 8, 59, 44, 59, DateTimeKind.Local).AddTicks(5049), new DateTime(2022, 6, 16, 1, 22, 21, 616, DateTimeKind.Local).AddTicks(1872), 28, 14.2361457686761m },
                    { 255, 34, new DateTime(2023, 3, 19, 8, 25, 18, 73, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 8, 19, 15, 7, 17, 420, DateTimeKind.Local).AddTicks(8478), 24, 10.5974644205623m },
                    { 256, 30, new DateTime(2023, 4, 14, 0, 36, 7, 763, DateTimeKind.Local).AddTicks(2394), new DateTime(2022, 11, 30, 3, 31, 15, 338, DateTimeKind.Local).AddTicks(1158), 4, 5.57758321092293m },
                    { 257, 64, new DateTime(2023, 1, 13, 13, 31, 48, 330, DateTimeKind.Local).AddTicks(2567), new DateTime(2022, 8, 8, 14, 10, 0, 172, DateTimeKind.Local).AddTicks(6248), 94, 5.929768419393m },
                    { 258, 16, new DateTime(2022, 10, 10, 6, 38, 10, 5, DateTimeKind.Local).AddTicks(3973), new DateTime(2023, 1, 11, 5, 22, 25, 171, DateTimeKind.Local).AddTicks(246), 47, 2.21681211018857m },
                    { 259, 128, new DateTime(2022, 9, 1, 3, 30, 59, 752, DateTimeKind.Local).AddTicks(8085), new DateTime(2022, 11, 4, 3, 25, 35, 23, DateTimeKind.Local).AddTicks(8116), 97, 6.71165967426343m },
                    { 260, 82, new DateTime(2022, 7, 6, 15, 13, 17, 866, DateTimeKind.Local).AddTicks(6156), new DateTime(2023, 1, 21, 14, 22, 8, 514, DateTimeKind.Local).AddTicks(8057), 5, 22.6907770968763m },
                    { 261, 94, new DateTime(2023, 3, 7, 0, 9, 19, 304, DateTimeKind.Local).AddTicks(2968), new DateTime(2023, 1, 11, 11, 8, 15, 312, DateTimeKind.Local).AddTicks(1594), 78, 24.4939659146867m },
                    { 262, 73, new DateTime(2023, 4, 13, 17, 21, 28, 327, DateTimeKind.Local).AddTicks(9459), new DateTime(2023, 4, 3, 2, 35, 37, 940, DateTimeKind.Local).AddTicks(4928), 66, 20.7917921266119m },
                    { 263, 122, new DateTime(2022, 10, 22, 23, 22, 11, 154, DateTimeKind.Local).AddTicks(777), new DateTime(2022, 11, 11, 10, 55, 39, 107, DateTimeKind.Local).AddTicks(7338), 22, 13.0774310164823m },
                    { 264, 90, new DateTime(2023, 4, 13, 12, 40, 7, 209, DateTimeKind.Local).AddTicks(8888), new DateTime(2022, 9, 23, 9, 20, 18, 782, DateTimeKind.Local).AddTicks(106), 59, 17.0753592821666m },
                    { 265, 95, new DateTime(2023, 2, 15, 21, 14, 12, 427, DateTimeKind.Local).AddTicks(3902), new DateTime(2022, 9, 23, 23, 7, 51, 141, DateTimeKind.Local).AddTicks(9677), 46, 12.5046304859926m },
                    { 266, 71, new DateTime(2022, 9, 11, 11, 1, 12, 889, DateTimeKind.Local).AddTicks(7532), new DateTime(2022, 6, 30, 20, 25, 25, 768, DateTimeKind.Local).AddTicks(1491), 45, 22.0404524815542m },
                    { 267, 35, new DateTime(2022, 9, 17, 21, 29, 35, 400, DateTimeKind.Local).AddTicks(3390), new DateTime(2022, 11, 14, 7, 35, 43, 419, DateTimeKind.Local).AddTicks(1876), 33, 17.6628421983962m },
                    { 268, 54, new DateTime(2022, 7, 2, 12, 14, 0, 394, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 8, 5, 15, 9, 47, 939, DateTimeKind.Local).AddTicks(7823), 78, 16.1268393762037m },
                    { 269, 127, new DateTime(2022, 5, 30, 3, 21, 43, 996, DateTimeKind.Local).AddTicks(3504), new DateTime(2022, 11, 16, 18, 35, 44, 526, DateTimeKind.Local).AddTicks(9207), 45, 9.63638747170439m },
                    { 270, 112, new DateTime(2022, 7, 28, 17, 40, 42, 779, DateTimeKind.Local).AddTicks(6712), new DateTime(2022, 11, 2, 1, 44, 51, 221, DateTimeKind.Local).AddTicks(7224), 9, 12.564132644585m },
                    { 271, 33, new DateTime(2022, 10, 25, 9, 2, 39, 106, DateTimeKind.Local).AddTicks(8573), new DateTime(2022, 8, 18, 22, 35, 2, 139, DateTimeKind.Local).AddTicks(2567), 43, 26.5103883217365m },
                    { 272, 14, new DateTime(2022, 8, 11, 4, 29, 59, 443, DateTimeKind.Local).AddTicks(217), new DateTime(2022, 12, 3, 10, 37, 32, 462, DateTimeKind.Local).AddTicks(1000), 63, 28.6470621983371m },
                    { 273, 10, new DateTime(2022, 4, 18, 16, 38, 23, 102, DateTimeKind.Local).AddTicks(1904), new DateTime(2022, 11, 14, 3, 45, 54, 585, DateTimeKind.Local).AddTicks(5112), 85, 10.61396658321m },
                    { 274, 33, new DateTime(2022, 7, 2, 3, 43, 23, 87, DateTimeKind.Local).AddTicks(4403), new DateTime(2022, 12, 25, 22, 29, 4, 799, DateTimeKind.Local).AddTicks(4968), 39, 29.3923524077625m },
                    { 275, 48, new DateTime(2022, 5, 9, 6, 37, 41, 347, DateTimeKind.Local).AddTicks(8797), new DateTime(2022, 11, 10, 17, 50, 24, 745, DateTimeKind.Local).AddTicks(3406), 4, 3.01607098692369m },
                    { 276, 89, new DateTime(2023, 1, 10, 17, 37, 36, 431, DateTimeKind.Local).AddTicks(3835), new DateTime(2022, 6, 6, 18, 35, 22, 456, DateTimeKind.Local).AddTicks(6813), 91, 23.9233026097763m },
                    { 277, 118, new DateTime(2022, 4, 23, 23, 38, 9, 122, DateTimeKind.Local).AddTicks(7082), new DateTime(2022, 7, 21, 1, 51, 26, 595, DateTimeKind.Local).AddTicks(4872), 3, 19.3050818954011m },
                    { 278, 90, new DateTime(2022, 10, 25, 1, 31, 53, 906, DateTimeKind.Local).AddTicks(3344), new DateTime(2022, 7, 31, 16, 21, 29, 897, DateTimeKind.Local).AddTicks(1512), 72, 19.2590580868724m },
                    { 279, 107, new DateTime(2023, 2, 24, 13, 28, 0, 398, DateTimeKind.Local).AddTicks(1473), new DateTime(2023, 1, 23, 18, 44, 45, 464, DateTimeKind.Local).AddTicks(2130), 92, 21.61795343641m },
                    { 280, 141, new DateTime(2023, 2, 13, 15, 26, 47, 724, DateTimeKind.Local).AddTicks(2888), new DateTime(2023, 1, 20, 3, 50, 13, 493, DateTimeKind.Local).AddTicks(2288), 1, 15.9666112152612m },
                    { 281, 32, new DateTime(2022, 9, 19, 10, 23, 2, 63, DateTimeKind.Local).AddTicks(902), new DateTime(2022, 7, 29, 9, 49, 30, 964, DateTimeKind.Local).AddTicks(9253), 56, 2.80408671671055m },
                    { 282, 56, new DateTime(2022, 12, 22, 17, 35, 8, 214, DateTimeKind.Local).AddTicks(4523), new DateTime(2023, 1, 21, 14, 14, 13, 686, DateTimeKind.Local).AddTicks(9929), 37, 3.33179974571903m },
                    { 283, 87, new DateTime(2022, 11, 28, 5, 15, 38, 981, DateTimeKind.Local).AddTicks(4714), new DateTime(2022, 7, 8, 23, 6, 41, 766, DateTimeKind.Local).AddTicks(1497), 6, 6.66328974776485m },
                    { 284, 44, new DateTime(2022, 9, 28, 10, 51, 55, 351, DateTimeKind.Local).AddTicks(1032), new DateTime(2022, 6, 15, 18, 56, 16, 261, DateTimeKind.Local).AddTicks(6846), 82, 29.6149179715811m },
                    { 285, 93, new DateTime(2022, 8, 26, 14, 53, 31, 679, DateTimeKind.Local).AddTicks(6842), new DateTime(2022, 6, 13, 15, 48, 25, 256, DateTimeKind.Local).AddTicks(1889), 96, 11.6437784944616m },
                    { 286, 142, new DateTime(2022, 8, 23, 4, 46, 12, 975, DateTimeKind.Local).AddTicks(3224), new DateTime(2023, 1, 13, 22, 10, 29, 99, DateTimeKind.Local).AddTicks(7545), 12, 3.78715442075007m },
                    { 287, 43, new DateTime(2022, 10, 12, 21, 59, 49, 875, DateTimeKind.Local).AddTicks(5417), new DateTime(2022, 8, 13, 21, 7, 28, 946, DateTimeKind.Local).AddTicks(2887), 59, 29.9833903203857m },
                    { 288, 85, new DateTime(2022, 12, 26, 4, 10, 54, 428, DateTimeKind.Local).AddTicks(1750), new DateTime(2023, 3, 11, 19, 56, 5, 221, DateTimeKind.Local).AddTicks(5851), 8, 26.5958693845709m },
                    { 289, 106, new DateTime(2022, 5, 31, 16, 15, 55, 522, DateTimeKind.Local).AddTicks(772), new DateTime(2022, 8, 4, 23, 3, 3, 359, DateTimeKind.Local).AddTicks(137), 15, 20.2373114797893m },
                    { 290, 83, new DateTime(2022, 10, 17, 10, 37, 26, 96, DateTimeKind.Local).AddTicks(6018), new DateTime(2022, 8, 20, 18, 15, 35, 77, DateTimeKind.Local).AddTicks(5072), 2, 28.6621029627167m },
                    { 291, 113, new DateTime(2022, 8, 10, 16, 29, 29, 697, DateTimeKind.Local).AddTicks(2257), new DateTime(2023, 2, 21, 20, 0, 50, 716, DateTimeKind.Local).AddTicks(5604), 48, 14.321103609819m },
                    { 292, 106, new DateTime(2022, 5, 23, 14, 29, 8, 367, DateTimeKind.Local).AddTicks(3720), new DateTime(2022, 8, 31, 0, 57, 57, 102, DateTimeKind.Local).AddTicks(2766), 22, 27.1909963512478m },
                    { 293, 46, new DateTime(2023, 1, 8, 6, 24, 1, 79, DateTimeKind.Local).AddTicks(2525), new DateTime(2022, 11, 25, 22, 53, 4, 147, DateTimeKind.Local).AddTicks(7848), 17, 12.4192097765162m },
                    { 294, 50, new DateTime(2023, 3, 1, 12, 43, 41, 291, DateTimeKind.Local).AddTicks(6921), new DateTime(2022, 9, 4, 17, 58, 6, 802, DateTimeKind.Local).AddTicks(3690), 30, 17.6014754916845m },
                    { 295, 48, new DateTime(2023, 2, 28, 22, 8, 33, 473, DateTimeKind.Local).AddTicks(8790), new DateTime(2023, 3, 18, 2, 43, 13, 581, DateTimeKind.Local).AddTicks(6817), 57, 7.91310532815177m },
                    { 296, 97, new DateTime(2023, 2, 19, 16, 34, 36, 933, DateTimeKind.Local).AddTicks(9080), new DateTime(2022, 10, 17, 19, 25, 29, 701, DateTimeKind.Local).AddTicks(6771), 87, 18.062930251938m },
                    { 297, 43, new DateTime(2022, 9, 1, 15, 47, 25, 527, DateTimeKind.Local).AddTicks(7006), new DateTime(2023, 3, 6, 18, 7, 4, 101, DateTimeKind.Local).AddTicks(7722), 28, 24.4001846656193m },
                    { 298, 128, new DateTime(2022, 6, 22, 0, 31, 22, 989, DateTimeKind.Local).AddTicks(4251), new DateTime(2022, 11, 16, 23, 34, 49, 345, DateTimeKind.Local).AddTicks(1476), 42, 15.619038341993m },
                    { 299, 148, new DateTime(2022, 12, 3, 6, 8, 59, 829, DateTimeKind.Local).AddTicks(7528), new DateTime(2022, 12, 4, 0, 44, 47, 192, DateTimeKind.Local).AddTicks(4680), 13, 15.3105943935359m },
                    { 300, 76, new DateTime(2023, 4, 2, 14, 19, 34, 971, DateTimeKind.Local).AddTicks(6591), new DateTime(2022, 5, 28, 4, 17, 55, 777, DateTimeKind.Local).AddTicks(5047), 27, 4.15193309714873m },
                    { 301, 133, new DateTime(2022, 10, 12, 17, 27, 52, 665, DateTimeKind.Local).AddTicks(1237), new DateTime(2022, 7, 6, 22, 10, 3, 43, DateTimeKind.Local).AddTicks(2665), 39, 3.9811933966904m },
                    { 302, 138, new DateTime(2022, 6, 29, 3, 21, 15, 724, DateTimeKind.Local).AddTicks(1712), new DateTime(2022, 6, 20, 2, 43, 4, 196, DateTimeKind.Local).AddTicks(9900), 30, 11.933320223703m },
                    { 303, 40, new DateTime(2023, 2, 26, 21, 55, 2, 969, DateTimeKind.Local).AddTicks(4942), new DateTime(2022, 8, 4, 1, 14, 30, 735, DateTimeKind.Local).AddTicks(5660), 58, 25.0570397769944m },
                    { 304, 63, new DateTime(2022, 7, 1, 12, 45, 8, 717, DateTimeKind.Local).AddTicks(7446), new DateTime(2022, 6, 16, 8, 13, 56, 584, DateTimeKind.Local).AddTicks(9160), 43, 2.76982180371324m },
                    { 305, 28, new DateTime(2022, 6, 1, 0, 16, 55, 521, DateTimeKind.Local).AddTicks(2762), new DateTime(2022, 5, 10, 17, 33, 30, 794, DateTimeKind.Local).AddTicks(8583), 60, 16.7521762600411m },
                    { 306, 119, new DateTime(2023, 1, 28, 22, 21, 24, 163, DateTimeKind.Local).AddTicks(4167), new DateTime(2022, 12, 22, 10, 52, 54, 715, DateTimeKind.Local).AddTicks(7263), 9, 23.483989943554m },
                    { 307, 129, new DateTime(2023, 1, 9, 0, 1, 3, 167, DateTimeKind.Local).AddTicks(6027), new DateTime(2022, 12, 21, 14, 59, 3, 321, DateTimeKind.Local).AddTicks(8891), 49, 7.09611521098057m },
                    { 308, 115, new DateTime(2022, 12, 9, 12, 46, 53, 225, DateTimeKind.Local).AddTicks(4509), new DateTime(2023, 3, 23, 11, 24, 48, 557, DateTimeKind.Local).AddTicks(4110), 97, 19.4402021591266m },
                    { 309, 37, new DateTime(2022, 8, 6, 21, 53, 18, 317, DateTimeKind.Local).AddTicks(4040), new DateTime(2022, 4, 23, 3, 30, 44, 13, DateTimeKind.Local).AddTicks(1521), 29, 16.8149251182035m },
                    { 310, 57, new DateTime(2023, 2, 2, 21, 48, 42, 731, DateTimeKind.Local).AddTicks(906), new DateTime(2022, 12, 7, 9, 28, 15, 341, DateTimeKind.Local).AddTicks(5498), 14, 19.3596435747364m },
                    { 311, 120, new DateTime(2022, 10, 3, 9, 1, 7, 112, DateTimeKind.Local).AddTicks(2002), new DateTime(2023, 2, 19, 23, 20, 54, 645, DateTimeKind.Local).AddTicks(8087), 49, 12.9497059878204m },
                    { 312, 18, new DateTime(2022, 4, 19, 18, 53, 6, 925, DateTimeKind.Local).AddTicks(9537), new DateTime(2022, 8, 1, 9, 59, 58, 891, DateTimeKind.Local).AddTicks(9202), 72, 28.9667754008521m },
                    { 313, 81, new DateTime(2022, 7, 9, 12, 53, 18, 264, DateTimeKind.Local).AddTicks(448), new DateTime(2023, 3, 19, 3, 9, 24, 8, DateTimeKind.Local).AddTicks(294), 20, 8.54406239707715m },
                    { 314, 16, new DateTime(2022, 6, 27, 22, 37, 58, 738, DateTimeKind.Local).AddTicks(3988), new DateTime(2022, 9, 8, 3, 30, 1, 425, DateTimeKind.Local).AddTicks(3387), 63, 20.0727831041387m },
                    { 315, 30, new DateTime(2023, 1, 1, 9, 7, 31, 469, DateTimeKind.Local).AddTicks(6057), new DateTime(2022, 11, 6, 9, 49, 45, 663, DateTimeKind.Local).AddTicks(1438), 68, 4.7084935870128m },
                    { 316, 73, new DateTime(2022, 6, 6, 14, 11, 31, 132, DateTimeKind.Local).AddTicks(183), new DateTime(2022, 6, 21, 16, 9, 13, 317, DateTimeKind.Local).AddTicks(113), 66, 3.32855194119978m },
                    { 317, 11, new DateTime(2022, 11, 15, 8, 19, 22, 317, DateTimeKind.Local).AddTicks(2633), new DateTime(2023, 2, 9, 5, 53, 15, 149, DateTimeKind.Local).AddTicks(4842), 92, 1.76678541987757m },
                    { 318, 122, new DateTime(2022, 8, 4, 10, 11, 59, 555, DateTimeKind.Local).AddTicks(2533), new DateTime(2023, 1, 25, 12, 29, 5, 464, DateTimeKind.Local).AddTicks(4519), 73, 26.5051383083525m },
                    { 319, 78, new DateTime(2022, 11, 4, 16, 33, 2, 332, DateTimeKind.Local).AddTicks(5239), new DateTime(2023, 1, 1, 11, 37, 46, 135, DateTimeKind.Local).AddTicks(670), 99, 22.3983434014094m },
                    { 320, 10, new DateTime(2022, 9, 11, 1, 56, 55, 266, DateTimeKind.Local).AddTicks(5107), new DateTime(2022, 12, 1, 8, 47, 49, 746, DateTimeKind.Local).AddTicks(4747), 26, 21.7938143336379m },
                    { 321, 85, new DateTime(2023, 3, 2, 12, 4, 5, 10, DateTimeKind.Local).AddTicks(8352), new DateTime(2022, 11, 10, 9, 38, 40, 246, DateTimeKind.Local).AddTicks(8092), 87, 6.11121112009914m },
                    { 322, 41, new DateTime(2022, 11, 7, 7, 54, 11, 393, DateTimeKind.Local).AddTicks(3024), new DateTime(2023, 2, 9, 15, 11, 14, 668, DateTimeKind.Local).AddTicks(1777), 100, 20.4355406941742m },
                    { 323, 14, new DateTime(2022, 12, 24, 9, 48, 4, 976, DateTimeKind.Local).AddTicks(6797), new DateTime(2022, 5, 7, 10, 29, 9, 506, DateTimeKind.Local).AddTicks(9465), 45, 4.85001900902836m },
                    { 324, 114, new DateTime(2022, 8, 2, 9, 9, 17, 802, DateTimeKind.Local).AddTicks(1371), new DateTime(2023, 4, 13, 7, 40, 26, 486, DateTimeKind.Local).AddTicks(7352), 9, 11.7110045004053m },
                    { 325, 108, new DateTime(2023, 1, 19, 18, 47, 48, 724, DateTimeKind.Local).AddTicks(9248), new DateTime(2022, 8, 20, 17, 27, 55, 463, DateTimeKind.Local).AddTicks(8166), 95, 6.5341051462899m },
                    { 326, 122, new DateTime(2022, 4, 23, 4, 56, 54, 267, DateTimeKind.Local).AddTicks(7764), new DateTime(2022, 11, 26, 12, 42, 44, 33, DateTimeKind.Local).AddTicks(1471), 71, 2.08499551621363m },
                    { 327, 83, new DateTime(2023, 3, 15, 8, 51, 56, 316, DateTimeKind.Local).AddTicks(9427), new DateTime(2023, 3, 7, 7, 44, 7, 411, DateTimeKind.Local).AddTicks(690), 84, 8.01571314528573m },
                    { 328, 78, new DateTime(2022, 12, 9, 21, 6, 53, 845, DateTimeKind.Local).AddTicks(3089), new DateTime(2022, 9, 4, 13, 44, 19, 945, DateTimeKind.Local).AddTicks(5527), 67, 28.243303836265m },
                    { 329, 138, new DateTime(2022, 9, 19, 2, 51, 30, 428, DateTimeKind.Local).AddTicks(3611), new DateTime(2023, 3, 13, 5, 20, 3, 690, DateTimeKind.Local).AddTicks(4199), 61, 27.7997960490144m },
                    { 330, 65, new DateTime(2022, 6, 18, 22, 1, 27, 55, DateTimeKind.Local).AddTicks(1993), new DateTime(2022, 8, 24, 13, 57, 47, 130, DateTimeKind.Local).AddTicks(1535), 36, 17.8104861582452m },
                    { 331, 36, new DateTime(2022, 7, 20, 15, 38, 25, 764, DateTimeKind.Local).AddTicks(8748), new DateTime(2022, 8, 26, 5, 41, 58, 158, DateTimeKind.Local).AddTicks(7711), 64, 22.7005540464877m },
                    { 332, 114, new DateTime(2023, 2, 27, 8, 9, 52, 616, DateTimeKind.Local).AddTicks(7762), new DateTime(2023, 1, 21, 1, 20, 41, 49, DateTimeKind.Local).AddTicks(8335), 51, 24.7619380050041m },
                    { 333, 66, new DateTime(2022, 12, 10, 17, 42, 45, 509, DateTimeKind.Local).AddTicks(7336), new DateTime(2022, 10, 1, 8, 33, 24, 211, DateTimeKind.Local).AddTicks(5359), 82, 17.489915592593m },
                    { 334, 142, new DateTime(2022, 8, 14, 22, 48, 9, 383, DateTimeKind.Local).AddTicks(2365), new DateTime(2023, 3, 25, 13, 0, 33, 885, DateTimeKind.Local).AddTicks(93), 83, 19.764837038542m },
                    { 335, 111, new DateTime(2022, 9, 12, 2, 53, 26, 130, DateTimeKind.Local).AddTicks(5778), new DateTime(2022, 11, 4, 12, 45, 43, 888, DateTimeKind.Local).AddTicks(9123), 59, 1.96026658605856m },
                    { 336, 50, new DateTime(2022, 10, 8, 15, 56, 2, 397, DateTimeKind.Local).AddTicks(2516), new DateTime(2022, 5, 11, 22, 16, 47, 207, DateTimeKind.Local).AddTicks(9719), 19, 20.8288218841969m },
                    { 337, 105, new DateTime(2022, 12, 12, 10, 48, 56, 397, DateTimeKind.Local).AddTicks(4091), new DateTime(2023, 2, 10, 23, 1, 41, 551, DateTimeKind.Local).AddTicks(2358), 75, 4.42595635320115m },
                    { 338, 92, new DateTime(2022, 8, 22, 12, 20, 8, 668, DateTimeKind.Local).AddTicks(6366), new DateTime(2022, 10, 11, 8, 24, 20, 166, DateTimeKind.Local).AddTicks(8169), 19, 3.02930997489513m },
                    { 339, 90, new DateTime(2023, 4, 7, 19, 49, 42, 18, DateTimeKind.Local).AddTicks(3825), new DateTime(2022, 10, 27, 11, 53, 43, 140, DateTimeKind.Local).AddTicks(8463), 90, 2.32440107704324m },
                    { 340, 52, new DateTime(2022, 5, 28, 18, 14, 13, 878, DateTimeKind.Local).AddTicks(5799), new DateTime(2023, 3, 17, 2, 4, 34, 494, DateTimeKind.Local).AddTicks(6240), 8, 18.7552004693104m },
                    { 341, 129, new DateTime(2022, 12, 30, 7, 2, 34, 606, DateTimeKind.Local).AddTicks(8239), new DateTime(2023, 1, 24, 9, 24, 46, 851, DateTimeKind.Local).AddTicks(8383), 42, 18.9799420290412m },
                    { 342, 122, new DateTime(2022, 7, 2, 14, 29, 28, 726, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 8, 18, 10, 13, 23, 733, DateTimeKind.Local).AddTicks(5452), 17, 7.95369073396108m },
                    { 343, 78, new DateTime(2022, 10, 11, 1, 13, 43, 255, DateTimeKind.Local).AddTicks(8553), new DateTime(2022, 8, 31, 15, 1, 7, 267, DateTimeKind.Local).AddTicks(1140), 25, 21.4225446323143m },
                    { 344, 57, new DateTime(2022, 10, 31, 18, 10, 3, 803, DateTimeKind.Local).AddTicks(150), new DateTime(2022, 12, 26, 16, 30, 19, 889, DateTimeKind.Local).AddTicks(9053), 84, 22.7287573259997m },
                    { 345, 122, new DateTime(2022, 5, 23, 13, 23, 24, 685, DateTimeKind.Local).AddTicks(3538), new DateTime(2022, 6, 25, 17, 26, 55, 550, DateTimeKind.Local).AddTicks(1462), 72, 12.5866662339574m },
                    { 346, 144, new DateTime(2023, 3, 29, 21, 11, 3, 983, DateTimeKind.Local).AddTicks(5854), new DateTime(2023, 1, 30, 15, 54, 29, 119, DateTimeKind.Local).AddTicks(2353), 42, 4.74269325222439m },
                    { 347, 126, new DateTime(2022, 8, 22, 18, 40, 47, 44, DateTimeKind.Local).AddTicks(8827), new DateTime(2023, 1, 21, 13, 27, 0, 51, DateTimeKind.Local).AddTicks(2777), 80, 26.32851946877m },
                    { 348, 31, new DateTime(2022, 4, 20, 20, 36, 57, 446, DateTimeKind.Local).AddTicks(7496), new DateTime(2023, 1, 18, 23, 53, 34, 752, DateTimeKind.Local).AddTicks(2693), 92, 7.14267672740344m },
                    { 349, 77, new DateTime(2023, 4, 6, 1, 29, 13, 279, DateTimeKind.Local).AddTicks(4249), new DateTime(2022, 12, 15, 7, 18, 38, 486, DateTimeKind.Local).AddTicks(7405), 86, 9.76466226018162m },
                    { 350, 45, new DateTime(2022, 7, 12, 9, 57, 9, 687, DateTimeKind.Local).AddTicks(7014), new DateTime(2022, 5, 10, 22, 47, 14, 266, DateTimeKind.Local).AddTicks(3569), 4, 21.8645403960042m },
                    { 351, 103, new DateTime(2022, 5, 12, 2, 27, 58, 784, DateTimeKind.Local).AddTicks(6679), new DateTime(2022, 8, 13, 9, 20, 50, 949, DateTimeKind.Local).AddTicks(6101), 91, 6.89616638724196m },
                    { 352, 4, new DateTime(2022, 8, 13, 11, 42, 44, 985, DateTimeKind.Local).AddTicks(5106), new DateTime(2022, 10, 10, 23, 39, 4, 427, DateTimeKind.Local).AddTicks(812), 10, 2.39732992589758m },
                    { 353, 109, new DateTime(2022, 7, 16, 15, 39, 27, 462, DateTimeKind.Local).AddTicks(3358), new DateTime(2023, 1, 9, 18, 4, 8, 308, DateTimeKind.Local).AddTicks(732), 14, 20.2577057315401m },
                    { 354, 12, new DateTime(2022, 8, 15, 18, 8, 30, 417, DateTimeKind.Local).AddTicks(573), new DateTime(2022, 10, 28, 21, 10, 29, 970, DateTimeKind.Local).AddTicks(6689), 45, 5.12609100413959m },
                    { 355, 13, new DateTime(2022, 11, 8, 17, 50, 9, 248, DateTimeKind.Local).AddTicks(158), new DateTime(2022, 12, 14, 22, 3, 22, 604, DateTimeKind.Local).AddTicks(768), 81, 6.07194208898593m },
                    { 356, 84, new DateTime(2022, 7, 20, 2, 31, 55, 522, DateTimeKind.Local).AddTicks(5621), new DateTime(2023, 3, 30, 4, 41, 26, 950, DateTimeKind.Local).AddTicks(9022), 17, 22.978599072888m },
                    { 357, 42, new DateTime(2022, 7, 9, 14, 51, 49, 741, DateTimeKind.Local).AddTicks(3329), new DateTime(2022, 12, 16, 14, 54, 53, 972, DateTimeKind.Local).AddTicks(781), 53, 5.56297273740858m },
                    { 358, 19, new DateTime(2023, 1, 9, 4, 20, 40, 87, DateTimeKind.Local).AddTicks(8219), new DateTime(2022, 11, 12, 8, 45, 10, 559, DateTimeKind.Local).AddTicks(8241), 36, 7.04586940425654m },
                    { 359, 145, new DateTime(2022, 5, 23, 16, 50, 28, 818, DateTimeKind.Local).AddTicks(5564), new DateTime(2022, 7, 22, 2, 22, 41, 840, DateTimeKind.Local).AddTicks(4355), 5, 10.1865650914524m },
                    { 360, 57, new DateTime(2023, 3, 7, 18, 16, 47, 836, DateTimeKind.Local).AddTicks(6969), new DateTime(2022, 7, 10, 13, 17, 46, 629, DateTimeKind.Local).AddTicks(341), 3, 27.7198738299323m },
                    { 361, 21, new DateTime(2023, 3, 13, 7, 44, 51, 832, DateTimeKind.Local).AddTicks(8439), new DateTime(2023, 2, 1, 23, 24, 16, 509, DateTimeKind.Local).AddTicks(2416), 17, 2.39937215436574m },
                    { 362, 109, new DateTime(2022, 6, 30, 18, 59, 52, 901, DateTimeKind.Local).AddTicks(9390), new DateTime(2022, 7, 5, 18, 24, 9, 624, DateTimeKind.Local).AddTicks(846), 46, 9.80777371005204m },
                    { 363, 85, new DateTime(2022, 10, 6, 1, 56, 16, 776, DateTimeKind.Local).AddTicks(5366), new DateTime(2022, 5, 3, 16, 3, 44, 741, DateTimeKind.Local).AddTicks(2333), 85, 3.50367618703284m },
                    { 364, 64, new DateTime(2022, 7, 9, 9, 52, 21, 250, DateTimeKind.Local).AddTicks(7852), new DateTime(2022, 12, 7, 18, 36, 8, 483, DateTimeKind.Local).AddTicks(3949), 87, 23.8769884814583m },
                    { 365, 133, new DateTime(2023, 2, 21, 21, 4, 41, 426, DateTimeKind.Local).AddTicks(3251), new DateTime(2022, 6, 18, 15, 19, 43, 205, DateTimeKind.Local).AddTicks(6933), 95, 4.47250352821296m },
                    { 366, 52, new DateTime(2023, 2, 16, 20, 50, 24, 113, DateTimeKind.Local).AddTicks(5349), new DateTime(2023, 4, 9, 13, 52, 53, 328, DateTimeKind.Local).AddTicks(9014), 26, 15.2544761657155m },
                    { 367, 49, new DateTime(2023, 1, 27, 15, 37, 29, 12, DateTimeKind.Local).AddTicks(1861), new DateTime(2022, 10, 22, 9, 19, 41, 858, DateTimeKind.Local).AddTicks(768), 46, 17.3171623101364m },
                    { 368, 140, new DateTime(2022, 11, 7, 19, 28, 7, 263, DateTimeKind.Local).AddTicks(1050), new DateTime(2022, 11, 8, 12, 34, 19, 102, DateTimeKind.Local).AddTicks(9732), 19, 5.77452521079445m },
                    { 369, 101, new DateTime(2023, 2, 12, 5, 25, 31, 819, DateTimeKind.Local).AddTicks(9777), new DateTime(2023, 4, 5, 12, 55, 20, 824, DateTimeKind.Local).AddTicks(5161), 98, 24.5474127520929m },
                    { 370, 81, new DateTime(2022, 9, 11, 14, 24, 17, 744, DateTimeKind.Local).AddTicks(1535), new DateTime(2022, 6, 26, 4, 45, 30, 811, DateTimeKind.Local).AddTicks(3557), 47, 2.72436550764039m },
                    { 371, 149, new DateTime(2022, 10, 20, 13, 12, 22, 326, DateTimeKind.Local).AddTicks(4816), new DateTime(2022, 7, 1, 17, 32, 7, 431, DateTimeKind.Local).AddTicks(5343), 49, 1.59091938600805m },
                    { 372, 48, new DateTime(2022, 9, 23, 1, 1, 53, 835, DateTimeKind.Local).AddTicks(7254), new DateTime(2022, 8, 31, 9, 35, 2, 639, DateTimeKind.Local).AddTicks(75), 60, 1.07817503284049m },
                    { 373, 82, new DateTime(2022, 7, 1, 9, 16, 54, 272, DateTimeKind.Local).AddTicks(4310), new DateTime(2023, 2, 21, 22, 58, 1, 300, DateTimeKind.Local).AddTicks(5401), 20, 25.9887276582652m },
                    { 374, 43, new DateTime(2022, 10, 12, 11, 48, 24, 542, DateTimeKind.Local).AddTicks(1406), new DateTime(2022, 6, 20, 14, 52, 10, 197, DateTimeKind.Local).AddTicks(4097), 23, 15.527945859582m },
                    { 375, 12, new DateTime(2022, 7, 18, 5, 23, 24, 41, DateTimeKind.Local).AddTicks(8813), new DateTime(2023, 2, 28, 2, 25, 2, 730, DateTimeKind.Local).AddTicks(9812), 98, 13.0025183400851m },
                    { 376, 47, new DateTime(2022, 9, 9, 15, 25, 9, 687, DateTimeKind.Local).AddTicks(5007), new DateTime(2022, 5, 18, 4, 58, 53, 495, DateTimeKind.Local).AddTicks(7244), 51, 3.63375793677156m },
                    { 377, 14, new DateTime(2022, 4, 26, 0, 10, 16, 663, DateTimeKind.Local).AddTicks(6339), new DateTime(2023, 2, 3, 22, 13, 4, 531, DateTimeKind.Local).AddTicks(8681), 13, 15.8252159146809m },
                    { 378, 112, new DateTime(2022, 5, 26, 6, 16, 21, 214, DateTimeKind.Local).AddTicks(5951), new DateTime(2022, 11, 19, 9, 0, 18, 981, DateTimeKind.Local).AddTicks(4365), 26, 20.1998592289285m },
                    { 379, 52, new DateTime(2022, 12, 11, 13, 57, 17, 177, DateTimeKind.Local).AddTicks(3357), new DateTime(2023, 1, 8, 0, 3, 52, 396, DateTimeKind.Local).AddTicks(3988), 30, 7.94135171720973m },
                    { 380, 56, new DateTime(2022, 11, 13, 9, 55, 34, 362, DateTimeKind.Local).AddTicks(4517), new DateTime(2023, 2, 23, 0, 46, 7, 547, DateTimeKind.Local).AddTicks(5268), 86, 10.0227475637398m },
                    { 381, 89, new DateTime(2023, 1, 2, 9, 33, 42, 263, DateTimeKind.Local).AddTicks(1521), new DateTime(2022, 8, 25, 23, 46, 50, 28, DateTimeKind.Local).AddTicks(1785), 77, 13.3156739048931m },
                    { 382, 44, new DateTime(2023, 1, 31, 2, 46, 37, 68, DateTimeKind.Local).AddTicks(6089), new DateTime(2022, 8, 4, 7, 58, 33, 873, DateTimeKind.Local).AddTicks(3532), 15, 4.53234228175897m },
                    { 383, 53, new DateTime(2023, 3, 27, 19, 41, 51, 893, DateTimeKind.Local).AddTicks(5340), new DateTime(2022, 11, 24, 13, 29, 59, 191, DateTimeKind.Local).AddTicks(6161), 17, 23.0878772757276m },
                    { 384, 70, new DateTime(2022, 12, 28, 22, 48, 0, 258, DateTimeKind.Local).AddTicks(1488), new DateTime(2023, 2, 12, 10, 44, 25, 411, DateTimeKind.Local).AddTicks(2556), 80, 6.65895111405736m },
                    { 385, 87, new DateTime(2022, 8, 17, 13, 39, 20, 959, DateTimeKind.Local).AddTicks(1611), new DateTime(2022, 10, 13, 9, 37, 31, 719, DateTimeKind.Local).AddTicks(6479), 40, 7.02159824837327m },
                    { 386, 56, new DateTime(2022, 12, 2, 8, 4, 36, 948, DateTimeKind.Local).AddTicks(6368), new DateTime(2022, 10, 30, 21, 51, 9, 595, DateTimeKind.Local).AddTicks(4185), 35, 15.4742769285052m },
                    { 387, 58, new DateTime(2022, 6, 7, 20, 33, 36, 784, DateTimeKind.Local).AddTicks(2030), new DateTime(2022, 5, 26, 12, 30, 41, 846, DateTimeKind.Local).AddTicks(1592), 66, 22.0677429785964m },
                    { 388, 36, new DateTime(2022, 4, 29, 12, 14, 31, 83, DateTimeKind.Local).AddTicks(7326), new DateTime(2022, 9, 6, 8, 57, 22, 675, DateTimeKind.Local).AddTicks(7469), 94, 23.1371004712149m },
                    { 389, 91, new DateTime(2022, 12, 4, 1, 30, 29, 237, DateTimeKind.Local).AddTicks(4715), new DateTime(2022, 5, 15, 18, 57, 14, 606, DateTimeKind.Local).AddTicks(7993), 66, 10.2707389770389m },
                    { 390, 144, new DateTime(2022, 7, 9, 3, 27, 48, 764, DateTimeKind.Local).AddTicks(8134), new DateTime(2022, 6, 14, 2, 24, 50, 936, DateTimeKind.Local).AddTicks(5805), 3, 26.4055241186329m },
                    { 391, 42, new DateTime(2023, 4, 3, 10, 26, 56, 28, DateTimeKind.Local).AddTicks(3057), new DateTime(2022, 5, 21, 5, 59, 14, 494, DateTimeKind.Local).AddTicks(5762), 89, 15.1820319383744m },
                    { 392, 75, new DateTime(2022, 9, 5, 16, 13, 53, 583, DateTimeKind.Local).AddTicks(2749), new DateTime(2022, 6, 18, 9, 27, 19, 929, DateTimeKind.Local).AddTicks(9395), 69, 6.69704670547054m },
                    { 393, 26, new DateTime(2022, 5, 30, 23, 59, 11, 539, DateTimeKind.Local).AddTicks(9274), new DateTime(2023, 1, 2, 13, 26, 20, 709, DateTimeKind.Local).AddTicks(6961), 5, 12.3995226107544m },
                    { 394, 138, new DateTime(2022, 6, 27, 17, 37, 18, 437, DateTimeKind.Local).AddTicks(8471), new DateTime(2022, 11, 21, 17, 7, 54, 616, DateTimeKind.Local).AddTicks(4340), 71, 14.55481043305m },
                    { 395, 124, new DateTime(2022, 4, 21, 12, 46, 40, 480, DateTimeKind.Local).AddTicks(8857), new DateTime(2022, 7, 13, 20, 16, 39, 866, DateTimeKind.Local).AddTicks(6995), 23, 24.7504316315133m },
                    { 396, 48, new DateTime(2022, 7, 12, 23, 56, 35, 992, DateTimeKind.Local).AddTicks(9577), new DateTime(2022, 5, 14, 19, 3, 46, 784, DateTimeKind.Local).AddTicks(6049), 44, 5.31683063437981m },
                    { 397, 67, new DateTime(2022, 7, 21, 10, 31, 24, 623, DateTimeKind.Local).AddTicks(3967), new DateTime(2023, 2, 4, 7, 11, 19, 330, DateTimeKind.Local).AddTicks(5928), 39, 24.2044654774323m },
                    { 398, 57, new DateTime(2023, 2, 22, 15, 35, 46, 203, DateTimeKind.Local).AddTicks(8156), new DateTime(2022, 11, 9, 3, 28, 31, 623, DateTimeKind.Local).AddTicks(9359), 11, 17.175662786636m },
                    { 399, 124, new DateTime(2022, 9, 2, 4, 0, 0, 687, DateTimeKind.Local).AddTicks(9621), new DateTime(2023, 3, 22, 9, 59, 16, 746, DateTimeKind.Local).AddTicks(1870), 81, 5.40444709592229m },
                    { 400, 70, new DateTime(2022, 7, 9, 1, 33, 50, 635, DateTimeKind.Local).AddTicks(9510), new DateTime(2023, 2, 18, 13, 15, 57, 951, DateTimeKind.Local).AddTicks(1033), 34, 2.11934059238969m },
                    { 401, 5, new DateTime(2022, 6, 11, 23, 57, 21, 62, DateTimeKind.Local).AddTicks(6051), new DateTime(2022, 7, 9, 23, 51, 16, 541, DateTimeKind.Local).AddTicks(1062), 78, 22.0251317433368m },
                    { 402, 102, new DateTime(2022, 5, 23, 0, 16, 16, 526, DateTimeKind.Local).AddTicks(1724), new DateTime(2022, 7, 19, 21, 42, 42, 352, DateTimeKind.Local).AddTicks(2077), 37, 15.9117377954608m },
                    { 403, 145, new DateTime(2022, 8, 5, 1, 57, 14, 755, DateTimeKind.Local).AddTicks(5171), new DateTime(2023, 2, 1, 2, 28, 16, 966, DateTimeKind.Local).AddTicks(4998), 81, 22.8437643530334m },
                    { 404, 2, new DateTime(2022, 11, 20, 7, 26, 11, 331, DateTimeKind.Local).AddTicks(4769), new DateTime(2022, 9, 19, 10, 23, 46, 236, DateTimeKind.Local).AddTicks(310), 98, 1.02470290167891m },
                    { 405, 17, new DateTime(2022, 10, 10, 8, 38, 13, 528, DateTimeKind.Local).AddTicks(9980), new DateTime(2023, 1, 17, 4, 35, 0, 168, DateTimeKind.Local).AddTicks(4765), 52, 13.1541676678876m },
                    { 406, 63, new DateTime(2022, 7, 25, 3, 56, 23, 727, DateTimeKind.Local).AddTicks(4903), new DateTime(2022, 8, 15, 3, 44, 45, 558, DateTimeKind.Local).AddTicks(9979), 77, 14.7259352772821m },
                    { 407, 67, new DateTime(2022, 10, 23, 13, 38, 30, 217, DateTimeKind.Local).AddTicks(26), new DateTime(2022, 5, 27, 16, 28, 46, 553, DateTimeKind.Local).AddTicks(7884), 3, 9.66743987927194m },
                    { 408, 111, new DateTime(2023, 3, 23, 5, 43, 50, 914, DateTimeKind.Local).AddTicks(1313), new DateTime(2022, 7, 13, 9, 56, 47, 824, DateTimeKind.Local).AddTicks(130), 30, 2.26649193216508m },
                    { 409, 125, new DateTime(2022, 4, 23, 17, 11, 47, 732, DateTimeKind.Local).AddTicks(2276), new DateTime(2022, 11, 18, 2, 54, 33, 177, DateTimeKind.Local).AddTicks(6330), 6, 13.6034386810382m },
                    { 410, 149, new DateTime(2022, 9, 24, 12, 16, 15, 752, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 7, 30, 17, 35, 1, 18, DateTimeKind.Local).AddTicks(3358), 48, 17.0298042605207m },
                    { 411, 150, new DateTime(2022, 11, 24, 1, 9, 10, 847, DateTimeKind.Local).AddTicks(3303), new DateTime(2023, 2, 25, 16, 10, 32, 8, DateTimeKind.Local).AddTicks(2111), 55, 29.6350609201821m },
                    { 412, 142, new DateTime(2022, 10, 31, 5, 34, 42, 18, DateTimeKind.Local).AddTicks(7428), new DateTime(2022, 6, 30, 11, 38, 52, 21, DateTimeKind.Local).AddTicks(3804), 69, 22.262272287603m },
                    { 413, 8, new DateTime(2022, 9, 26, 22, 41, 59, 522, DateTimeKind.Local).AddTicks(1063), new DateTime(2023, 1, 25, 15, 3, 4, 885, DateTimeKind.Local).AddTicks(4041), 43, 24.1957287657876m },
                    { 414, 79, new DateTime(2022, 11, 24, 11, 58, 50, 124, DateTimeKind.Local).AddTicks(7620), new DateTime(2022, 12, 4, 13, 4, 28, 308, DateTimeKind.Local).AddTicks(5934), 96, 29.9359144423949m },
                    { 415, 27, new DateTime(2022, 7, 20, 17, 12, 0, 552, DateTimeKind.Local).AddTicks(813), new DateTime(2022, 5, 15, 5, 19, 1, 543, DateTimeKind.Local).AddTicks(3811), 31, 1.22794162425388m },
                    { 416, 2, new DateTime(2022, 11, 5, 6, 22, 29, 970, DateTimeKind.Local).AddTicks(6045), new DateTime(2023, 3, 21, 17, 26, 17, 218, DateTimeKind.Local).AddTicks(4084), 21, 3.43702860037672m },
                    { 417, 141, new DateTime(2023, 2, 21, 21, 17, 24, 507, DateTimeKind.Local).AddTicks(9545), new DateTime(2023, 2, 21, 17, 25, 17, 502, DateTimeKind.Local).AddTicks(2178), 91, 19.4435669824562m },
                    { 418, 150, new DateTime(2023, 3, 11, 1, 3, 1, 649, DateTimeKind.Local).AddTicks(4223), new DateTime(2022, 10, 6, 6, 14, 8, 199, DateTimeKind.Local).AddTicks(379), 4, 6.54900110544672m },
                    { 419, 121, new DateTime(2022, 8, 4, 23, 4, 37, 50, DateTimeKind.Local).AddTicks(964), new DateTime(2022, 7, 9, 7, 30, 35, 981, DateTimeKind.Local).AddTicks(9623), 56, 9.37411042400214m },
                    { 420, 89, new DateTime(2022, 4, 21, 6, 49, 4, 236, DateTimeKind.Local).AddTicks(3948), new DateTime(2023, 3, 14, 12, 33, 57, 178, DateTimeKind.Local).AddTicks(5204), 3, 29.0111732398255m },
                    { 421, 103, new DateTime(2022, 10, 28, 17, 38, 17, 435, DateTimeKind.Local).AddTicks(9126), new DateTime(2023, 1, 14, 16, 46, 8, 356, DateTimeKind.Local).AddTicks(4846), 99, 12.0264789338476m },
                    { 422, 127, new DateTime(2022, 6, 25, 21, 27, 28, 472, DateTimeKind.Local).AddTicks(1767), new DateTime(2022, 10, 4, 3, 14, 12, 417, DateTimeKind.Local).AddTicks(8846), 19, 1.46082549442192m },
                    { 423, 93, new DateTime(2023, 3, 9, 0, 42, 29, 624, DateTimeKind.Local).AddTicks(850), new DateTime(2022, 12, 28, 8, 10, 19, 509, DateTimeKind.Local).AddTicks(8166), 45, 29.1471020521391m },
                    { 424, 96, new DateTime(2022, 10, 12, 13, 23, 10, 434, DateTimeKind.Local).AddTicks(5318), new DateTime(2022, 10, 2, 16, 45, 3, 572, DateTimeKind.Local).AddTicks(8185), 26, 13.2829782142504m },
                    { 425, 49, new DateTime(2023, 1, 20, 18, 29, 37, 874, DateTimeKind.Local).AddTicks(5377), new DateTime(2022, 7, 17, 23, 57, 24, 817, DateTimeKind.Local).AddTicks(9229), 56, 29.3404873535633m },
                    { 426, 47, new DateTime(2022, 7, 13, 2, 37, 20, 428, DateTimeKind.Local).AddTicks(7258), new DateTime(2022, 11, 10, 13, 21, 1, 390, DateTimeKind.Local).AddTicks(8572), 80, 29.1010378548222m },
                    { 427, 4, new DateTime(2022, 8, 16, 16, 54, 0, 966, DateTimeKind.Local).AddTicks(9707), new DateTime(2023, 2, 20, 16, 28, 17, 268, DateTimeKind.Local).AddTicks(8), 95, 18.7284462262359m },
                    { 428, 94, new DateTime(2022, 12, 13, 10, 8, 54, 476, DateTimeKind.Local).AddTicks(4709), new DateTime(2022, 7, 29, 9, 28, 22, 261, DateTimeKind.Local).AddTicks(969), 84, 27.8876698604747m },
                    { 429, 98, new DateTime(2022, 5, 10, 19, 20, 53, 219, DateTimeKind.Local).AddTicks(3603), new DateTime(2022, 10, 8, 21, 14, 22, 815, DateTimeKind.Local).AddTicks(172), 20, 21.5016577212659m },
                    { 430, 29, new DateTime(2022, 5, 27, 13, 28, 4, 622, DateTimeKind.Local).AddTicks(812), new DateTime(2023, 3, 26, 2, 2, 18, 531, DateTimeKind.Local).AddTicks(7828), 55, 12.9117019231259m },
                    { 431, 93, new DateTime(2022, 8, 1, 10, 51, 14, 670, DateTimeKind.Local).AddTicks(4225), new DateTime(2022, 11, 13, 23, 56, 22, 595, DateTimeKind.Local).AddTicks(8582), 14, 24.1713940815369m },
                    { 432, 121, new DateTime(2023, 1, 7, 4, 18, 38, 872, DateTimeKind.Local).AddTicks(4917), new DateTime(2022, 5, 15, 10, 14, 0, 136, DateTimeKind.Local).AddTicks(6169), 90, 4.46333685528616m },
                    { 433, 25, new DateTime(2023, 1, 27, 6, 2, 13, 254, DateTimeKind.Local).AddTicks(6004), new DateTime(2022, 8, 2, 14, 14, 50, 630, DateTimeKind.Local).AddTicks(411), 30, 8.13344636942112m },
                    { 434, 37, new DateTime(2022, 12, 30, 1, 41, 42, 22, DateTimeKind.Local).AddTicks(3804), new DateTime(2022, 8, 11, 16, 50, 54, 234, DateTimeKind.Local).AddTicks(3374), 36, 20.2316377467154m },
                    { 435, 6, new DateTime(2022, 12, 27, 5, 10, 45, 127, DateTimeKind.Local).AddTicks(1955), new DateTime(2023, 2, 17, 6, 32, 31, 700, DateTimeKind.Local).AddTicks(1018), 93, 20.7060779797961m },
                    { 436, 99, new DateTime(2022, 8, 3, 10, 17, 48, 573, DateTimeKind.Local).AddTicks(7252), new DateTime(2022, 6, 20, 21, 7, 59, 115, DateTimeKind.Local).AddTicks(8399), 19, 9.79255653178115m },
                    { 437, 59, new DateTime(2023, 3, 7, 23, 44, 37, 815, DateTimeKind.Local).AddTicks(8216), new DateTime(2022, 9, 6, 16, 19, 36, 379, DateTimeKind.Local).AddTicks(8308), 28, 12.13067701187m },
                    { 438, 149, new DateTime(2022, 4, 21, 7, 33, 40, 609, DateTimeKind.Local).AddTicks(5571), new DateTime(2022, 12, 5, 6, 54, 11, 540, DateTimeKind.Local).AddTicks(888), 71, 8.43031659420333m },
                    { 439, 27, new DateTime(2022, 9, 4, 10, 22, 15, 931, DateTimeKind.Local).AddTicks(8043), new DateTime(2023, 2, 8, 11, 51, 13, 492, DateTimeKind.Local).AddTicks(9182), 44, 25.1848035567474m },
                    { 440, 51, new DateTime(2022, 10, 1, 14, 29, 42, 434, DateTimeKind.Local).AddTicks(3059), new DateTime(2023, 2, 20, 13, 44, 51, 516, DateTimeKind.Local).AddTicks(5329), 61, 1.0768734608215m },
                    { 441, 112, new DateTime(2022, 6, 8, 19, 46, 4, 765, DateTimeKind.Local).AddTicks(704), new DateTime(2022, 8, 14, 5, 39, 0, 793, DateTimeKind.Local).AddTicks(7263), 76, 23.5504946760236m },
                    { 442, 96, new DateTime(2022, 12, 6, 21, 9, 57, 989, DateTimeKind.Local).AddTicks(5539), new DateTime(2022, 5, 3, 20, 36, 12, 702, DateTimeKind.Local).AddTicks(3691), 41, 25.0770685916007m },
                    { 443, 39, new DateTime(2022, 9, 12, 2, 49, 54, 621, DateTimeKind.Local).AddTicks(3181), new DateTime(2022, 10, 9, 23, 56, 17, 345, DateTimeKind.Local).AddTicks(473), 36, 13.2887557321738m },
                    { 444, 110, new DateTime(2022, 5, 31, 9, 13, 23, 43, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 10, 24, 3, 38, 8, 108, DateTimeKind.Local).AddTicks(7849), 90, 1.56697416701988m },
                    { 445, 133, new DateTime(2023, 2, 23, 10, 55, 47, 221, DateTimeKind.Local).AddTicks(8892), new DateTime(2022, 10, 15, 2, 39, 22, 20, DateTimeKind.Local).AddTicks(4066), 92, 14.1961278456213m },
                    { 446, 100, new DateTime(2023, 1, 28, 3, 35, 28, 720, DateTimeKind.Local).AddTicks(5145), new DateTime(2022, 12, 24, 23, 35, 35, 310, DateTimeKind.Local).AddTicks(2665), 70, 17.0205087488696m },
                    { 447, 129, new DateTime(2023, 1, 9, 0, 57, 51, 196, DateTimeKind.Local).AddTicks(3922), new DateTime(2023, 2, 8, 14, 53, 15, 355, DateTimeKind.Local).AddTicks(6402), 18, 8.71708298932563m },
                    { 448, 17, new DateTime(2023, 3, 20, 20, 30, 33, 961, DateTimeKind.Local).AddTicks(4254), new DateTime(2022, 9, 13, 10, 45, 40, 787, DateTimeKind.Local).AddTicks(6850), 63, 13.8006379959629m },
                    { 449, 23, new DateTime(2022, 11, 19, 23, 21, 8, 822, DateTimeKind.Local).AddTicks(7145), new DateTime(2022, 11, 7, 5, 11, 5, 85, DateTimeKind.Local).AddTicks(619), 50, 19.7464858401994m },
                    { 450, 5, new DateTime(2022, 11, 16, 3, 39, 47, 800, DateTimeKind.Local).AddTicks(8284), new DateTime(2022, 8, 24, 12, 8, 41, 954, DateTimeKind.Local).AddTicks(3953), 81, 7.85286657371635m },
                    { 451, 24, new DateTime(2023, 1, 14, 18, 21, 4, 601, DateTimeKind.Local).AddTicks(8370), new DateTime(2022, 11, 1, 23, 10, 42, 857, DateTimeKind.Local).AddTicks(9369), 4, 22.4209538387976m },
                    { 452, 71, new DateTime(2022, 10, 27, 3, 26, 24, 626, DateTimeKind.Local).AddTicks(3499), new DateTime(2022, 7, 31, 1, 23, 36, 938, DateTimeKind.Local).AddTicks(5283), 40, 19.8503241620105m },
                    { 453, 21, new DateTime(2023, 1, 8, 9, 3, 39, 549, DateTimeKind.Local).AddTicks(7575), new DateTime(2022, 7, 27, 1, 39, 15, 145, DateTimeKind.Local).AddTicks(1892), 31, 26.0238607796666m },
                    { 454, 6, new DateTime(2022, 11, 1, 1, 34, 36, 765, DateTimeKind.Local).AddTicks(9316), new DateTime(2023, 3, 13, 14, 14, 30, 811, DateTimeKind.Local).AddTicks(5877), 20, 15.7694231509018m },
                    { 455, 82, new DateTime(2022, 10, 17, 11, 50, 57, 499, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 9, 26, 13, 22, 20, 27, DateTimeKind.Local).AddTicks(3619), 54, 5.7994634370555m },
                    { 456, 27, new DateTime(2022, 12, 19, 5, 4, 38, 788, DateTimeKind.Local).AddTicks(8754), new DateTime(2023, 1, 16, 3, 10, 13, 675, DateTimeKind.Local).AddTicks(3951), 38, 9.80414129521895m },
                    { 457, 1, new DateTime(2023, 4, 9, 15, 6, 33, 307, DateTimeKind.Local).AddTicks(4703), new DateTime(2022, 7, 19, 7, 4, 3, 729, DateTimeKind.Local).AddTicks(9408), 19, 21.2342791767276m },
                    { 458, 66, new DateTime(2022, 8, 13, 23, 22, 51, 242, DateTimeKind.Local).AddTicks(8503), new DateTime(2022, 5, 27, 17, 10, 56, 590, DateTimeKind.Local).AddTicks(277), 33, 8.67612162863817m },
                    { 459, 75, new DateTime(2022, 10, 27, 13, 33, 2, 220, DateTimeKind.Local).AddTicks(1464), new DateTime(2022, 10, 1, 4, 4, 0, 64, DateTimeKind.Local).AddTicks(200), 48, 17.2789650692551m },
                    { 460, 115, new DateTime(2022, 5, 19, 15, 14, 31, 885, DateTimeKind.Local).AddTicks(2493), new DateTime(2022, 8, 1, 5, 12, 50, 456, DateTimeKind.Local).AddTicks(9088), 42, 24.5012201906662m },
                    { 461, 84, new DateTime(2022, 5, 29, 12, 37, 8, 629, DateTimeKind.Local).AddTicks(2853), new DateTime(2022, 10, 18, 3, 49, 36, 517, DateTimeKind.Local).AddTicks(3487), 39, 18.6252488427576m },
                    { 462, 53, new DateTime(2022, 11, 24, 23, 58, 19, 749, DateTimeKind.Local).AddTicks(8837), new DateTime(2022, 10, 29, 16, 1, 34, 50, DateTimeKind.Local).AddTicks(5535), 85, 19.6408985472172m },
                    { 463, 47, new DateTime(2022, 5, 20, 7, 4, 22, 548, DateTimeKind.Local).AddTicks(3985), new DateTime(2023, 1, 11, 3, 6, 57, 838, DateTimeKind.Local).AddTicks(78), 70, 16.3055064538171m },
                    { 464, 130, new DateTime(2023, 1, 6, 22, 10, 18, 877, DateTimeKind.Local).AddTicks(5325), new DateTime(2022, 6, 6, 1, 51, 47, 593, DateTimeKind.Local).AddTicks(2293), 54, 5.4609500695958m },
                    { 465, 1, new DateTime(2023, 1, 7, 22, 9, 7, 407, DateTimeKind.Local).AddTicks(5130), new DateTime(2022, 11, 22, 11, 19, 0, 18, DateTimeKind.Local).AddTicks(2686), 84, 29.1627353272038m },
                    { 466, 109, new DateTime(2022, 11, 26, 22, 47, 2, 412, DateTimeKind.Local).AddTicks(4357), new DateTime(2022, 6, 4, 17, 15, 59, 195, DateTimeKind.Local).AddTicks(804), 46, 4.63552471849965m },
                    { 467, 58, new DateTime(2023, 1, 15, 20, 33, 36, 964, DateTimeKind.Local).AddTicks(6059), new DateTime(2022, 8, 3, 7, 2, 26, 197, DateTimeKind.Local).AddTicks(1943), 47, 5.31343747192153m },
                    { 468, 138, new DateTime(2022, 8, 12, 1, 34, 22, 493, DateTimeKind.Local).AddTicks(9335), new DateTime(2022, 7, 8, 12, 44, 7, 100, DateTimeKind.Local).AddTicks(9741), 58, 3.10251182026982m },
                    { 469, 119, new DateTime(2023, 2, 14, 22, 38, 32, 512, DateTimeKind.Local).AddTicks(3686), new DateTime(2022, 6, 22, 9, 26, 19, 245, DateTimeKind.Local).AddTicks(8888), 64, 11.1510656231394m },
                    { 470, 125, new DateTime(2022, 11, 20, 3, 21, 14, 268, DateTimeKind.Local).AddTicks(8575), new DateTime(2022, 6, 16, 1, 12, 27, 61, DateTimeKind.Local).AddTicks(788), 30, 2.96828926746497m },
                    { 471, 84, new DateTime(2023, 3, 30, 22, 10, 36, 458, DateTimeKind.Local).AddTicks(3755), new DateTime(2023, 4, 10, 12, 32, 6, 941, DateTimeKind.Local).AddTicks(8582), 62, 13.2038796672937m },
                    { 472, 62, new DateTime(2022, 12, 9, 5, 20, 55, 882, DateTimeKind.Local).AddTicks(3743), new DateTime(2022, 9, 4, 9, 50, 20, 834, DateTimeKind.Local).AddTicks(106), 54, 4.56222461446555m },
                    { 473, 92, new DateTime(2022, 8, 1, 10, 58, 3, 312, DateTimeKind.Local).AddTicks(6019), new DateTime(2022, 11, 16, 16, 31, 27, 818, DateTimeKind.Local).AddTicks(1072), 23, 21.0046727102936m },
                    { 474, 77, new DateTime(2023, 1, 13, 17, 39, 50, 73, DateTimeKind.Local).AddTicks(270), new DateTime(2022, 8, 17, 13, 23, 37, 45, DateTimeKind.Local).AddTicks(4809), 50, 15.0127688626835m },
                    { 475, 3, new DateTime(2023, 4, 6, 1, 26, 9, 510, DateTimeKind.Local).AddTicks(3359), new DateTime(2022, 10, 29, 2, 58, 26, 873, DateTimeKind.Local).AddTicks(7056), 18, 23.6503383926494m },
                    { 476, 104, new DateTime(2022, 5, 25, 22, 42, 5, 429, DateTimeKind.Local).AddTicks(9514), new DateTime(2022, 7, 4, 6, 25, 0, 996, DateTimeKind.Local).AddTicks(5485), 11, 15.8072500653744m },
                    { 477, 21, new DateTime(2022, 9, 1, 3, 8, 49, 841, DateTimeKind.Local).AddTicks(6024), new DateTime(2022, 7, 17, 0, 14, 4, 92, DateTimeKind.Local).AddTicks(2772), 64, 1.1302709407124m },
                    { 478, 69, new DateTime(2022, 9, 21, 13, 10, 3, 161, DateTimeKind.Local).AddTicks(7486), new DateTime(2023, 4, 14, 10, 53, 4, 906, DateTimeKind.Local).AddTicks(7840), 70, 4.13737922648299m },
                    { 479, 66, new DateTime(2022, 7, 5, 0, 10, 55, 507, DateTimeKind.Local).AddTicks(6656), new DateTime(2022, 5, 23, 7, 30, 11, 553, DateTimeKind.Local).AddTicks(8586), 61, 16.8604307957781m },
                    { 480, 56, new DateTime(2022, 12, 16, 1, 15, 53, 358, DateTimeKind.Local).AddTicks(4638), new DateTime(2023, 3, 27, 1, 9, 44, 29, DateTimeKind.Local).AddTicks(649), 69, 9.17846292758792m },
                    { 481, 96, new DateTime(2022, 10, 25, 11, 23, 29, 380, DateTimeKind.Local).AddTicks(3765), new DateTime(2022, 4, 29, 0, 40, 24, 420, DateTimeKind.Local).AddTicks(5851), 4, 16.6192454758104m },
                    { 482, 40, new DateTime(2023, 1, 4, 11, 26, 18, 219, DateTimeKind.Local).AddTicks(516), new DateTime(2023, 2, 28, 15, 4, 46, 556, DateTimeKind.Local).AddTicks(3262), 22, 14.5286717433601m },
                    { 483, 76, new DateTime(2022, 8, 24, 13, 36, 56, 973, DateTimeKind.Local).AddTicks(6017), new DateTime(2023, 1, 4, 12, 22, 45, 424, DateTimeKind.Local).AddTicks(1786), 54, 10.0395343532306m },
                    { 484, 141, new DateTime(2022, 7, 24, 7, 52, 34, 782, DateTimeKind.Local).AddTicks(5882), new DateTime(2022, 5, 12, 13, 14, 21, 384, DateTimeKind.Local).AddTicks(8177), 81, 19.5880350395131m },
                    { 485, 40, new DateTime(2022, 11, 28, 9, 57, 40, 997, DateTimeKind.Local).AddTicks(8032), new DateTime(2022, 11, 21, 16, 42, 0, 816, DateTimeKind.Local).AddTicks(975), 67, 4.63293787165287m },
                    { 486, 91, new DateTime(2022, 5, 16, 23, 9, 15, 146, DateTimeKind.Local).AddTicks(497), new DateTime(2022, 7, 8, 1, 57, 7, 612, DateTimeKind.Local).AddTicks(809), 80, 27.4995148678311m },
                    { 487, 106, new DateTime(2022, 6, 24, 9, 39, 40, 733, DateTimeKind.Local).AddTicks(6586), new DateTime(2023, 3, 25, 23, 23, 18, 962, DateTimeKind.Local).AddTicks(3961), 5, 28.1054027680516m },
                    { 488, 54, new DateTime(2022, 4, 23, 20, 9, 42, 180, DateTimeKind.Local).AddTicks(5819), new DateTime(2022, 6, 26, 4, 36, 37, 228, DateTimeKind.Local).AddTicks(6188), 74, 27.7507772358146m },
                    { 489, 146, new DateTime(2022, 11, 9, 21, 24, 29, 369, DateTimeKind.Local).AddTicks(4833), new DateTime(2022, 10, 26, 1, 38, 46, 574, DateTimeKind.Local).AddTicks(8056), 69, 3.92767465919909m },
                    { 490, 139, new DateTime(2022, 9, 19, 0, 50, 17, 180, DateTimeKind.Local).AddTicks(3666), new DateTime(2022, 12, 1, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(1404), 22, 15.8664582237242m },
                    { 491, 75, new DateTime(2023, 1, 28, 16, 13, 36, 696, DateTimeKind.Local).AddTicks(1583), new DateTime(2023, 2, 3, 20, 28, 20, 647, DateTimeKind.Local).AddTicks(9861), 86, 9.69111036196326m },
                    { 492, 44, new DateTime(2023, 2, 1, 16, 2, 1, 718, DateTimeKind.Local).AddTicks(7179), new DateTime(2022, 8, 17, 1, 31, 10, 116, DateTimeKind.Local).AddTicks(2111), 82, 5.2237713080799m },
                    { 493, 129, new DateTime(2023, 1, 21, 12, 5, 7, 300, DateTimeKind.Local).AddTicks(166), new DateTime(2022, 11, 12, 20, 30, 29, 829, DateTimeKind.Local).AddTicks(9877), 71, 1.01471985236971m },
                    { 494, 140, new DateTime(2023, 1, 9, 13, 0, 30, 38, DateTimeKind.Local).AddTicks(9510), new DateTime(2022, 11, 9, 19, 29, 16, 141, DateTimeKind.Local).AddTicks(462), 99, 11.56485151024m },
                    { 495, 106, new DateTime(2022, 5, 14, 7, 7, 2, 528, DateTimeKind.Local).AddTicks(5457), new DateTime(2022, 10, 12, 0, 31, 55, 837, DateTimeKind.Local).AddTicks(2864), 72, 10.8028938429179m },
                    { 496, 34, new DateTime(2022, 11, 22, 16, 17, 59, 770, DateTimeKind.Local).AddTicks(1393), new DateTime(2023, 2, 8, 16, 52, 59, 303, DateTimeKind.Local).AddTicks(8743), 46, 20.0254524596911m },
                    { 497, 126, new DateTime(2022, 9, 11, 23, 15, 18, 921, DateTimeKind.Local).AddTicks(5645), new DateTime(2022, 6, 16, 13, 36, 48, 133, DateTimeKind.Local).AddTicks(7204), 53, 18.1746383394064m },
                    { 498, 39, new DateTime(2022, 7, 30, 12, 39, 46, 785, DateTimeKind.Local).AddTicks(6307), new DateTime(2022, 7, 19, 16, 25, 33, 671, DateTimeKind.Local).AddTicks(4019), 51, 17.9513100540113m },
                    { 499, 2, new DateTime(2022, 9, 30, 14, 45, 53, 160, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 12, 28, 19, 7, 21, 131, DateTimeKind.Local).AddTicks(7695), 69, 22.7060448469372m },
                    { 500, 109, new DateTime(2022, 5, 1, 7, 47, 54, 527, DateTimeKind.Local).AddTicks(1625), new DateTime(2022, 7, 14, 11, 48, 14, 581, DateTimeKind.Local).AddTicks(4026), 40, 7.51765102963102m }
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
