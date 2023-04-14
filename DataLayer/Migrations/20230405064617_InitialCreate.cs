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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
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
                    Price = table.Column<decimal>(type: "decimal(10,4)", precision: 10, scale: 4, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                    { 1, new DateTime(2023, 2, 23, 22, 39, 15, 337, DateTimeKind.Local).AddTicks(9521), new DateTime(2022, 10, 16, 21, 45, 28, 601, DateTimeKind.Local).AddTicks(8907), "Chrysler" },
                    { 2, new DateTime(2022, 8, 8, 8, 54, 21, 567, DateTimeKind.Local).AddTicks(8990), new DateTime(2022, 10, 29, 9, 35, 45, 287, DateTimeKind.Local).AddTicks(7219), "Polestar" },
                    { 3, new DateTime(2022, 4, 25, 20, 32, 16, 662, DateTimeKind.Local).AddTicks(4534), new DateTime(2023, 2, 27, 9, 40, 38, 523, DateTimeKind.Local).AddTicks(272), "Ford" },
                    { 4, new DateTime(2023, 3, 25, 21, 54, 46, 876, DateTimeKind.Local).AddTicks(6849), new DateTime(2023, 1, 4, 20, 2, 10, 268, DateTimeKind.Local).AddTicks(9930), "Mazda" },
                    { 5, new DateTime(2022, 4, 9, 2, 24, 40, 632, DateTimeKind.Local).AddTicks(8329), new DateTime(2022, 7, 30, 9, 22, 22, 725, DateTimeKind.Local).AddTicks(8747), "Fiat" },
                    { 6, new DateTime(2022, 12, 23, 4, 3, 48, 595, DateTimeKind.Local).AddTicks(3042), new DateTime(2022, 8, 23, 18, 20, 13, 71, DateTimeKind.Local).AddTicks(1525), "Mazda" },
                    { 7, new DateTime(2022, 7, 23, 5, 1, 57, 446, DateTimeKind.Local).AddTicks(674), new DateTime(2022, 4, 23, 16, 42, 44, 300, DateTimeKind.Local).AddTicks(7829), "Mini" },
                    { 8, new DateTime(2023, 2, 5, 15, 13, 28, 393, DateTimeKind.Local).AddTicks(7627), new DateTime(2022, 11, 16, 22, 42, 17, 495, DateTimeKind.Local).AddTicks(8298), "Bentley" },
                    { 9, new DateTime(2023, 2, 2, 12, 14, 21, 261, DateTimeKind.Local).AddTicks(9895), new DateTime(2022, 6, 19, 15, 13, 37, 76, DateTimeKind.Local).AddTicks(9599), "Porsche" },
                    { 10, new DateTime(2022, 6, 8, 23, 2, 32, 825, DateTimeKind.Local).AddTicks(6717), new DateTime(2022, 5, 16, 19, 17, 53, 970, DateTimeKind.Local).AddTicks(290), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ModifiedDate", "Name", "active" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 23, 22, 39, 15, 339, DateTimeKind.Local).AddTicks(5266), null, new DateTime(2022, 10, 16, 21, 45, 28, 603, DateTimeKind.Local).AddTicks(4653), "Computers", false },
                    { 2, new DateTime(2022, 8, 8, 8, 54, 21, 569, DateTimeKind.Local).AddTicks(4746), null, new DateTime(2022, 10, 29, 9, 35, 45, 289, DateTimeKind.Local).AddTicks(2975), "Shoes", false },
                    { 3, new DateTime(2022, 4, 25, 20, 32, 16, 664, DateTimeKind.Local).AddTicks(290), null, new DateTime(2023, 2, 27, 9, 40, 38, 524, DateTimeKind.Local).AddTicks(6028), "Garden", false },
                    { 4, new DateTime(2023, 3, 25, 21, 54, 46, 878, DateTimeKind.Local).AddTicks(2606), null, new DateTime(2023, 1, 4, 20, 2, 10, 270, DateTimeKind.Local).AddTicks(5687), "Baby", false },
                    { 5, new DateTime(2022, 4, 9, 2, 24, 40, 634, DateTimeKind.Local).AddTicks(4085), null, new DateTime(2022, 7, 30, 9, 22, 22, 727, DateTimeKind.Local).AddTicks(4504), "Garden", false },
                    { 6, new DateTime(2022, 12, 23, 4, 3, 48, 596, DateTimeKind.Local).AddTicks(8799), null, new DateTime(2022, 8, 23, 18, 20, 13, 72, DateTimeKind.Local).AddTicks(7283), "Baby", false },
                    { 7, new DateTime(2022, 7, 23, 5, 1, 57, 447, DateTimeKind.Local).AddTicks(6432), null, new DateTime(2022, 4, 23, 16, 42, 44, 302, DateTimeKind.Local).AddTicks(3587), "Clothing", false },
                    { 8, new DateTime(2023, 2, 5, 15, 13, 28, 395, DateTimeKind.Local).AddTicks(3386), null, new DateTime(2022, 11, 16, 22, 42, 17, 497, DateTimeKind.Local).AddTicks(4057), "Music", false },
                    { 9, new DateTime(2023, 2, 2, 12, 14, 21, 263, DateTimeKind.Local).AddTicks(5655), null, new DateTime(2022, 6, 19, 15, 13, 37, 78, DateTimeKind.Local).AddTicks(5359), "Jewelery", false },
                    { 10, new DateTime(2022, 6, 8, 23, 2, 32, 827, DateTimeKind.Local).AddTicks(2519), null, new DateTime(2022, 5, 16, 19, 17, 53, 971, DateTimeKind.Local).AddTicks(6093), "Home", false }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 23, 22, 39, 15, 334, DateTimeKind.Local).AddTicks(2317), new DateTime(2022, 10, 16, 21, 45, 28, 598, DateTimeKind.Local).AddTicks(1750), "Ecuador" },
                    { 2, new DateTime(2022, 8, 8, 8, 54, 21, 564, DateTimeKind.Local).AddTicks(1880), new DateTime(2022, 10, 29, 9, 35, 45, 284, DateTimeKind.Local).AddTicks(110), "Samoa" },
                    { 3, new DateTime(2022, 4, 25, 20, 32, 16, 658, DateTimeKind.Local).AddTicks(7424), new DateTime(2023, 2, 27, 9, 40, 38, 519, DateTimeKind.Local).AddTicks(3162), "Guatemala" },
                    { 4, new DateTime(2023, 3, 25, 21, 54, 46, 872, DateTimeKind.Local).AddTicks(9740), new DateTime(2023, 1, 4, 20, 2, 10, 265, DateTimeKind.Local).AddTicks(2821), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 9, 2, 24, 40, 629, DateTimeKind.Local).AddTicks(1219), new DateTime(2022, 7, 30, 9, 22, 22, 722, DateTimeKind.Local).AddTicks(1638), "Germany" },
                    { 6, new DateTime(2022, 12, 23, 4, 3, 48, 591, DateTimeKind.Local).AddTicks(5933), new DateTime(2022, 8, 23, 18, 20, 13, 67, DateTimeKind.Local).AddTicks(4416), "Niue" },
                    { 7, new DateTime(2022, 7, 23, 5, 1, 57, 442, DateTimeKind.Local).AddTicks(3565), new DateTime(2022, 4, 23, 16, 42, 44, 297, DateTimeKind.Local).AddTicks(720), "Philippines" },
                    { 8, new DateTime(2023, 2, 5, 15, 13, 28, 390, DateTimeKind.Local).AddTicks(522), new DateTime(2022, 11, 16, 22, 42, 17, 492, DateTimeKind.Local).AddTicks(1193), "Benin" },
                    { 9, new DateTime(2023, 2, 2, 12, 14, 21, 258, DateTimeKind.Local).AddTicks(2791), new DateTime(2022, 6, 19, 15, 13, 37, 73, DateTimeKind.Local).AddTicks(2494), "Seychelles" },
                    { 10, new DateTime(2022, 6, 8, 23, 2, 32, 821, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 5, 16, 19, 17, 53, 966, DateTimeKind.Local).AddTicks(3185), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "CountryId", "CreateDate", "Mobile", "ModifiedDate", "Name", "Phone", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Okunevaview", 3, new DateTime(2022, 6, 18, 2, 44, 58, 820, DateTimeKind.Local).AddTicks(1095), "(252) 696-3466 x42351", new DateTime(2022, 11, 29, 20, 39, 44, 154, DateTimeKind.Local).AddTicks(2343), "Bernita Konopelski", "888.457.6098", "239 Lucy Burg", "62677-9013" },
                    { 2, "Boganshire", 7, new DateTime(2022, 4, 24, 11, 28, 12, 236, DateTimeKind.Local).AddTicks(8944), "(808) 228-4311 x34353", new DateTime(2023, 3, 11, 8, 56, 1, 397, DateTimeKind.Local).AddTicks(7871), "Golda Crist", "1-504-433-3068", "0353 Bo Field", "87211-4947" },
                    { 3, "Dareland", 2, new DateTime(2022, 5, 2, 9, 13, 1, 296, DateTimeKind.Local).AddTicks(1547), "352-226-6156 x3351", new DateTime(2022, 4, 7, 14, 31, 22, 595, DateTimeKind.Local).AddTicks(2978), "Dexter Kessler", "(818) 969-0327 x106", "869 Wilton Ports", "61001-0220" },
                    { 4, "Prohaskaburgh", 9, new DateTime(2022, 12, 15, 7, 32, 59, 616, DateTimeKind.Local).AddTicks(6346), "248.924.7120", new DateTime(2023, 2, 10, 1, 37, 37, 271, DateTimeKind.Local).AddTicks(6538), "Andrew Hermiston", "(745) 533-8336 x82933", "837 Efrain Run", "50338-0798" },
                    { 5, "South Joycefort", 3, new DateTime(2022, 5, 16, 0, 24, 32, 127, DateTimeKind.Local).AddTicks(6829), "1-769-371-0191", new DateTime(2023, 3, 25, 10, 21, 30, 699, DateTimeKind.Local).AddTicks(225), "Vada Corwin", "246-526-2232 x5315", "3904 Trisha Village", "68305" },
                    { 6, "Ashamouth", 7, new DateTime(2022, 11, 8, 7, 46, 23, 495, DateTimeKind.Local).AddTicks(2015), "1-726-591-1553", new DateTime(2022, 4, 9, 21, 38, 26, 782, DateTimeKind.Local).AddTicks(7201), "Jeffery Johns", "302.554.1978 x618", "1481 Betty Bypass", "61362-5302" },
                    { 7, "North Erinview", 6, new DateTime(2022, 9, 6, 5, 28, 39, 972, DateTimeKind.Local).AddTicks(1851), "565-824-6464", new DateTime(2022, 11, 27, 1, 31, 6, 810, DateTimeKind.Local).AddTicks(9479), "Jaylen Schinner", "322-546-9620", "84628 Beatty Club", "79943" },
                    { 8, "East Nelsonview", 3, new DateTime(2022, 5, 6, 16, 7, 54, 655, DateTimeKind.Local).AddTicks(1955), "442.312.9816 x66098", new DateTime(2023, 2, 8, 9, 56, 0, 304, DateTimeKind.Local).AddTicks(4471), "Eden Tromp", "(865) 389-9671", "99247 Cydney Creek", "04546" },
                    { 9, "Millsshire", 6, new DateTime(2022, 5, 19, 11, 30, 45, 20, DateTimeKind.Local).AddTicks(3608), "503.733.0063 x8679", new DateTime(2023, 2, 9, 7, 53, 2, 280, DateTimeKind.Local).AddTicks(4290), "Tracy Runolfsson", "1-477-640-5659", "2125 Ryan Lodge", "72157" },
                    { 10, "Howeborough", 5, new DateTime(2023, 2, 1, 14, 12, 8, 459, DateTimeKind.Local).AddTicks(6720), "(748) 605-1503 x77284", new DateTime(2022, 12, 1, 3, 12, 37, 727, DateTimeKind.Local).AddTicks(5607), "Ronny Sanford", "947-829-5808 x267", "2739 Delta Station", "92378" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreateDate", "Description", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 4, 3, new DateTime(2022, 4, 9, 2, 24, 40, 636, DateTimeKind.Local).AddTicks(601), null, new DateTime(2022, 7, 30, 9, 22, 22, 729, DateTimeKind.Local).AddTicks(1070), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 4, 8, new DateTime(2022, 6, 8, 23, 2, 32, 828, DateTimeKind.Local).AddTicks(9119), null, new DateTime(2022, 5, 16, 19, 17, 53, 973, DateTimeKind.Local).AddTicks(2696), "Handcrafted Plastic Soap", 55m, "79013710", true },
                    { 3, 7, 10, new DateTime(2022, 11, 15, 6, 1, 11, 495, DateTimeKind.Local).AddTicks(8222), null, new DateTime(2022, 10, 28, 20, 0, 22, 662, DateTimeKind.Local).AddTicks(7307), "Awesome Metal Chicken", 49m, "98805525", true },
                    { 4, 1, 10, new DateTime(2022, 4, 14, 23, 32, 28, 393, DateTimeKind.Local).AddTicks(9164), null, new DateTime(2022, 10, 9, 5, 26, 17, 711, DateTimeKind.Local).AddTicks(5276), "Handcrafted Metal Shoes", 50m, "35136316", true },
                    { 5, 2, 3, new DateTime(2023, 1, 30, 0, 47, 24, 971, DateTimeKind.Local).AddTicks(217), null, new DateTime(2022, 10, 30, 18, 58, 51, 642, DateTimeKind.Local).AddTicks(3631), "Generic Steel Computer", 50m, "03539873", true },
                    { 6, 1, 4, new DateTime(2022, 8, 22, 14, 57, 46, 399, DateTimeKind.Local).AddTicks(743), null, new DateTime(2022, 6, 4, 0, 11, 26, 172, DateTimeKind.Local).AddTicks(324), "Tasty Cotton Cheese", 57m, "14304330", true },
                    { 7, 5, 4, new DateTime(2022, 11, 21, 18, 59, 1, 385, DateTimeKind.Local).AddTicks(8744), null, new DateTime(2022, 9, 13, 22, 28, 28, 757, DateTimeKind.Local).AddTicks(9882), "Refined Soft Computer", 50m, "82843113", true },
                    { 8, 7, 10, new DateTime(2022, 5, 28, 10, 39, 1, 939, DateTimeKind.Local).AddTicks(76), null, new DateTime(2022, 7, 24, 3, 5, 39, 755, DateTimeKind.Local).AddTicks(6621), "Incredible Steel Mouse", 50m, "47118935", true },
                    { 9, 5, 10, new DateTime(2022, 6, 8, 3, 58, 0, 114, DateTimeKind.Local).AddTicks(4937), null, new DateTime(2022, 4, 6, 20, 57, 2, 650, DateTimeKind.Local).AddTicks(1524), "Tasty Granite Chicken", 49m, "00102209", true },
                    { 10, 3, 7, new DateTime(2023, 3, 25, 6, 40, 47, 700, DateTimeKind.Local).AddTicks(6293), null, new DateTime(2022, 9, 9, 23, 36, 32, 658, DateTimeKind.Local).AddTicks(7234), "Rustic Fresh Chicken", 57m, "03271063", true },
                    { 11, 9, 10, new DateTime(2023, 3, 14, 13, 36, 38, 61, DateTimeKind.Local).AddTicks(4706), null, new DateTime(2022, 11, 26, 8, 58, 21, 899, DateTimeKind.Local).AddTicks(8011), "Gorgeous Concrete Soap", 54m, "15633514", true },
                    { 12, 6, 8, new DateTime(2023, 3, 8, 0, 9, 44, 228, DateTimeKind.Local).AddTicks(3760), null, new DateTime(2022, 12, 2, 20, 3, 48, 893, DateTimeKind.Local).AddTicks(7984), "Refined Metal Gloves", 56m, "84278371", true },
                    { 13, 4, 6, new DateTime(2022, 11, 18, 15, 34, 48, 18, DateTimeKind.Local).AddTicks(6802), null, new DateTime(2022, 5, 19, 7, 58, 48, 306, DateTimeKind.Local).AddTicks(3159), "Fantastic Fresh Car", 55m, "98386444", true },
                    { 14, 9, 5, new DateTime(2023, 1, 14, 22, 53, 20, 448, DateTimeKind.Local).AddTicks(5403), null, new DateTime(2022, 10, 26, 5, 29, 52, 858, DateTimeKind.Local).AddTicks(5067), "Incredible Plastic Chicken", 56m, "29331093", true },
                    { 15, 7, 9, new DateTime(2022, 10, 24, 23, 19, 25, 467, DateTimeKind.Local).AddTicks(9783), null, new DateTime(2022, 10, 28, 1, 39, 21, 604, DateTimeKind.Local).AddTicks(2560), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 16, 9, 6, new DateTime(2022, 8, 18, 22, 34, 59, 746, DateTimeKind.Local).AddTicks(7332), null, new DateTime(2023, 4, 1, 21, 39, 10, 104, DateTimeKind.Local).AddTicks(7918), "Unbranded Frozen Pants", 57m, "04168300", true },
                    { 17, 6, 2, new DateTime(2022, 12, 6, 12, 12, 51, 947, DateTimeKind.Local).AddTicks(3769), null, new DateTime(2022, 7, 11, 12, 35, 46, 538, DateTimeKind.Local).AddTicks(311), "Fantastic Granite Tuna", 50m, "62232531", true },
                    { 18, 5, 5, new DateTime(2022, 8, 10, 12, 8, 11, 127, DateTimeKind.Local).AddTicks(9826), null, new DateTime(2023, 3, 4, 17, 2, 29, 700, DateTimeKind.Local).AddTicks(4057), "Rustic Metal Sausages", 55m, "10191064", true },
                    { 19, 2, 7, new DateTime(2022, 12, 8, 17, 22, 0, 738, DateTimeKind.Local).AddTicks(7975), null, new DateTime(2022, 7, 30, 15, 24, 31, 558, DateTimeKind.Local).AddTicks(4419), "Licensed Steel Hat", 56m, "10148167", true },
                    { 20, 5, 6, new DateTime(2023, 2, 1, 4, 21, 42, 774, DateTimeKind.Local).AddTicks(4568), null, new DateTime(2022, 4, 26, 5, 19, 8, 842, DateTimeKind.Local).AddTicks(5504), "Intelligent Granite Pants", 56m, "24514026", true },
                    { 21, 2, 2, new DateTime(2022, 9, 17, 17, 33, 27, 266, DateTimeKind.Local).AddTicks(5273), null, new DateTime(2022, 9, 30, 8, 13, 10, 2, DateTimeKind.Local).AddTicks(6257), "Licensed Fresh Chicken", 49m, "83642692", true },
                    { 22, 1, 9, new DateTime(2023, 3, 5, 1, 12, 51, 154, DateTimeKind.Local).AddTicks(8156), null, new DateTime(2022, 5, 27, 3, 56, 37, 894, DateTimeKind.Local).AddTicks(765), "Fantastic Frozen Towels", 52m, "71134611", true },
                    { 23, 2, 1, new DateTime(2022, 11, 12, 18, 59, 31, 278, DateTimeKind.Local).AddTicks(4799), null, new DateTime(2023, 1, 9, 8, 4, 24, 100, DateTimeKind.Local).AddTicks(7588), "Practical Metal Ball", 56m, "37994358", true },
                    { 24, 3, 6, new DateTime(2022, 10, 19, 5, 11, 9, 652, DateTimeKind.Local).AddTicks(7721), null, new DateTime(2022, 8, 17, 12, 36, 50, 64, DateTimeKind.Local).AddTicks(99), "Intelligent Granite Soap", 57m, "62003766", true },
                    { 25, 1, 10, new DateTime(2023, 2, 22, 9, 21, 56, 30, DateTimeKind.Local).AddTicks(1530), null, new DateTime(2023, 1, 16, 0, 31, 42, 52, DateTimeKind.Local).AddTicks(5885), "Practical Rubber Shirt", 51m, "22921741", true },
                    { 26, 10, 7, new DateTime(2023, 3, 2, 20, 11, 1, 36, DateTimeKind.Local).AddTicks(5574), null, new DateTime(2022, 7, 4, 16, 56, 24, 502, DateTimeKind.Local).AddTicks(5015), "Rustic Frozen Sausages", 50m, "47204546", true },
                    { 27, 5, 3, new DateTime(2023, 1, 18, 16, 59, 33, 65, DateTimeKind.Local).AddTicks(9162), null, new DateTime(2023, 2, 11, 21, 10, 40, 72, DateTimeKind.Local).AddTicks(7931), "Intelligent Metal Hat", 56m, "99671938", true },
                    { 28, 10, 6, new DateTime(2022, 6, 29, 13, 49, 41, 100, DateTimeKind.Local).AddTicks(1857), null, new DateTime(2022, 6, 23, 10, 57, 1, 691, DateTimeKind.Local).AddTicks(9575), "Gorgeous Frozen Salad", 49m, "66609810", true },
                    { 29, 8, 2, new DateTime(2023, 1, 1, 20, 14, 5, 326, DateTimeKind.Local).AddTicks(6608), null, new DateTime(2023, 2, 8, 4, 3, 58, 136, DateTimeKind.Local).AddTicks(1771), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 30, 6, 7, new DateTime(2022, 4, 18, 2, 22, 24, 864, DateTimeKind.Local).AddTicks(1386), null, new DateTime(2022, 6, 20, 7, 48, 2, 971, DateTimeKind.Local).AddTicks(1677), "Sleek Soft Salad", 51m, "35774051", true },
                    { 31, 8, 7, new DateTime(2022, 5, 6, 13, 13, 46, 949, DateTimeKind.Local).AddTicks(8642), null, new DateTime(2023, 2, 9, 7, 53, 2, 285, DateTimeKind.Local).AddTicks(4606), "Practical Metal Chair", 51m, "33006383", true },
                    { 32, 8, 3, new DateTime(2022, 12, 15, 19, 38, 55, 450, DateTimeKind.Local).AddTicks(1254), null, new DateTime(2022, 4, 22, 16, 9, 0, 974, DateTimeKind.Local).AddTicks(8401), "Practical Fresh Cheese", 56m, "33664286", true },
                    { 33, 3, 8, new DateTime(2022, 4, 18, 9, 0, 48, 394, DateTimeKind.Local).AddTicks(3345), null, new DateTime(2022, 10, 3, 3, 50, 15, 105, DateTimeKind.Local).AddTicks(903), "Ergonomic Frozen Ball", 51m, "78149847", true },
                    { 34, 6, 1, new DateTime(2023, 2, 19, 4, 42, 1, 811, DateTimeKind.Local).AddTicks(5193), null, new DateTime(2022, 9, 21, 6, 26, 1, 170, DateTimeKind.Local).AddTicks(4379), "Refined Steel Pizza", 50m, "67865482", true },
                    { 35, 9, 5, new DateTime(2023, 3, 31, 17, 38, 39, 412, DateTimeKind.Local).AddTicks(7498), null, new DateTime(2022, 4, 18, 12, 12, 55, 106, DateTimeKind.Local).AddTicks(7205), "Ergonomic Cotton Cheese", 55m, "28431329", true },
                    { 36, 7, 3, new DateTime(2022, 4, 26, 8, 37, 40, 877, DateTimeKind.Local).AddTicks(1912), null, new DateTime(2022, 4, 14, 21, 57, 8, 182, DateTimeKind.Local).AddTicks(6774), "Generic Cotton Tuna", 57m, "47346222", true },
                    { 37, 8, 8, new DateTime(2022, 4, 20, 7, 45, 29, 663, DateTimeKind.Local).AddTicks(3187), null, new DateTime(2022, 11, 30, 20, 48, 53, 369, DateTimeKind.Local).AddTicks(6456), "Handmade Rubber Ball", 51m, "70947632", true },
                    { 38, 2, 10, new DateTime(2022, 10, 1, 4, 26, 49, 97, DateTimeKind.Local).AddTicks(5986), null, new DateTime(2023, 3, 30, 21, 9, 24, 40, DateTimeKind.Local).AddTicks(3033), "Incredible Steel Chicken", 54m, "83467776", true },
                    { 39, 10, 10, new DateTime(2022, 12, 7, 21, 48, 6, 841, DateTimeKind.Local).AddTicks(664), null, new DateTime(2023, 3, 31, 13, 15, 43, 304, DateTimeKind.Local).AddTicks(49), "Handcrafted Soft Shirt", 49m, "56142969", true },
                    { 40, 6, 10, new DateTime(2022, 9, 7, 22, 5, 22, 1, DateTimeKind.Local).AddTicks(2980), null, new DateTime(2023, 3, 26, 7, 4, 40, 718, DateTimeKind.Local).AddTicks(6566), "Small Metal Shoes", 51m, "82501532", true },
                    { 41, 5, 6, new DateTime(2022, 7, 24, 12, 31, 37, 347, DateTimeKind.Local).AddTicks(7334), null, new DateTime(2023, 2, 21, 4, 25, 31, 203, DateTimeKind.Local).AddTicks(8066), "Ergonomic Fresh Chips", 54m, "96353615", true },
                    { 42, 3, 7, new DateTime(2022, 9, 10, 22, 8, 32, 297, DateTimeKind.Local).AddTicks(7590), null, new DateTime(2023, 1, 1, 9, 18, 8, 745, DateTimeKind.Local).AddTicks(1576), "Practical Granite Gloves", 54m, "70476712", true },
                    { 43, 1, 2, new DateTime(2022, 8, 3, 16, 23, 46, 300, DateTimeKind.Local).AddTicks(5637), null, new DateTime(2022, 7, 6, 15, 21, 16, 58, DateTimeKind.Local).AddTicks(6226), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 44, 4, 1, new DateTime(2022, 5, 9, 10, 56, 6, 459, DateTimeKind.Local).AddTicks(1762), null, new DateTime(2022, 5, 24, 2, 5, 19, 18, DateTimeKind.Local).AddTicks(1440), "Handmade Wooden Pants", 50m, "17687065", true },
                    { 45, 10, 3, new DateTime(2022, 12, 7, 6, 44, 20, 118, DateTimeKind.Local).AddTicks(2981), null, new DateTime(2023, 2, 28, 8, 58, 38, 507, DateTimeKind.Local).AddTicks(8660), "Tasty Steel Chips", 49m, "95518251", true },
                    { 46, 2, 8, new DateTime(2023, 1, 2, 18, 37, 45, 922, DateTimeKind.Local).AddTicks(693), null, new DateTime(2023, 2, 1, 3, 46, 11, 585, DateTimeKind.Local).AddTicks(5663), "Unbranded Cotton Computer", 56m, "09324404", true },
                    { 47, 5, 10, new DateTime(2022, 7, 9, 17, 23, 6, 760, DateTimeKind.Local).AddTicks(8502), null, new DateTime(2022, 8, 22, 6, 4, 47, 403, DateTimeKind.Local).AddTicks(5142), "Handmade Rubber Gloves", 52m, "46197115", true },
                    { 48, 6, 9, new DateTime(2022, 8, 4, 6, 9, 56, 982, DateTimeKind.Local).AddTicks(440), null, new DateTime(2022, 5, 6, 5, 18, 22, 622, DateTimeKind.Local).AddTicks(6449), "Sleek Soft Towels", 54m, "02958965", true },
                    { 49, 4, 5, new DateTime(2022, 7, 31, 11, 48, 33, 903, DateTimeKind.Local).AddTicks(5611), null, new DateTime(2022, 4, 17, 20, 55, 54, 918, DateTimeKind.Local).AddTicks(9677), "Refined Granite Salad", 55m, "59949480", true },
                    { 50, 5, 1, new DateTime(2022, 9, 4, 2, 1, 36, 779, DateTimeKind.Local).AddTicks(3427), null, new DateTime(2022, 6, 18, 2, 19, 9, 547, DateTimeKind.Local).AddTicks(9643), "Tasty Fresh Shoes", 56m, "92141971", true },
                    { 51, 7, 3, new DateTime(2023, 1, 18, 11, 32, 54, 397, DateTimeKind.Local).AddTicks(8246), null, new DateTime(2022, 12, 24, 23, 3, 5, 395, DateTimeKind.Local).AddTicks(1157), "Licensed Rubber Ball", 56m, "36072651", true },
                    { 52, 8, 1, new DateTime(2022, 6, 20, 3, 15, 41, 794, DateTimeKind.Local).AddTicks(7519), null, new DateTime(2022, 7, 14, 3, 54, 39, 262, DateTimeKind.Local).AddTicks(5414), "Licensed Rubber Bacon", 56m, "97377665", true },
                    { 53, 3, 1, new DateTime(2023, 2, 16, 12, 9, 29, 446, DateTimeKind.Local).AddTicks(5588), null, new DateTime(2022, 10, 28, 11, 10, 53, 194, DateTimeKind.Local).AddTicks(1352), "Refined Granite Salad", 49m, "62153386", true },
                    { 54, 6, 9, new DateTime(2023, 1, 26, 0, 21, 14, 361, DateTimeKind.Local).AddTicks(6895), null, new DateTime(2022, 8, 1, 13, 33, 14, 764, DateTimeKind.Local).AddTicks(8318), "Small Granite Bike", 56m, "12266043", true },
                    { 55, 5, 1, new DateTime(2022, 9, 15, 21, 21, 49, 967, DateTimeKind.Local).AddTicks(6105), null, new DateTime(2023, 3, 19, 19, 8, 10, 458, DateTimeKind.Local).AddTicks(978), "Generic Cotton Chips", 52m, "80355069", true },
                    { 56, 3, 9, new DateTime(2023, 3, 4, 11, 13, 36, 671, DateTimeKind.Local).AddTicks(2720), null, new DateTime(2023, 1, 8, 20, 40, 20, 201, DateTimeKind.Local).AddTicks(9990), "Handcrafted Steel Soap", 50m, "51786564", true },
                    { 57, 8, 10, new DateTime(2022, 5, 22, 3, 9, 4, 935, DateTimeKind.Local).AddTicks(8489), null, new DateTime(2022, 10, 21, 7, 24, 57, 425, DateTimeKind.Local).AddTicks(9490), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 58, 3, 6, new DateTime(2022, 4, 15, 0, 49, 27, 355, DateTimeKind.Local).AddTicks(6254), null, new DateTime(2023, 1, 21, 5, 13, 59, 132, DateTimeKind.Local).AddTicks(6700), "Intelligent Soft Computer", 54m, "34135587", true },
                    { 59, 4, 3, new DateTime(2022, 5, 16, 16, 7, 45, 960, DateTimeKind.Local).AddTicks(7606), null, new DateTime(2022, 4, 16, 15, 22, 13, 420, DateTimeKind.Local).AddTicks(5619), "Intelligent Wooden Table", 50m, "50688555", true },
                    { 60, 8, 3, new DateTime(2023, 2, 21, 12, 44, 33, 567, DateTimeKind.Local).AddTicks(9490), null, new DateTime(2022, 6, 18, 13, 55, 42, 651, DateTimeKind.Local).AddTicks(518), "Rustic Steel Chips", 50m, "38767821", true },
                    { 61, 2, 10, new DateTime(2023, 3, 7, 5, 39, 54, 506, DateTimeKind.Local).AddTicks(6637), null, new DateTime(2022, 7, 14, 12, 13, 16, 74, DateTimeKind.Local).AddTicks(5752), "Tasty Soft Bacon", 49m, "14543357", true },
                    { 62, 7, 6, new DateTime(2022, 10, 23, 14, 49, 41, 245, DateTimeKind.Local).AddTicks(6850), null, new DateTime(2022, 12, 15, 9, 52, 58, 409, DateTimeKind.Local).AddTicks(1889), "Rustic Fresh Table", 54m, "47506343", true },
                    { 63, 7, 7, new DateTime(2022, 6, 1, 6, 19, 26, 673, DateTimeKind.Local).AddTicks(1659), null, new DateTime(2022, 7, 2, 13, 54, 1, 18, DateTimeKind.Local).AddTicks(8243), "Licensed Fresh Fish", 57m, "57427553", true },
                    { 64, 2, 8, new DateTime(2022, 6, 27, 13, 55, 39, 676, DateTimeKind.Local).AddTicks(3092), null, new DateTime(2022, 7, 21, 23, 28, 24, 894, DateTimeKind.Local).AddTicks(3524), "Tasty Rubber Hat", 52m, "63817942", true },
                    { 65, 7, 7, new DateTime(2023, 2, 25, 20, 26, 1, 162, DateTimeKind.Local).AddTicks(6052), null, new DateTime(2022, 6, 10, 18, 19, 16, 144, DateTimeKind.Local).AddTicks(1054), "Refined Fresh Chips", 50m, "57105970", true },
                    { 66, 1, 7, new DateTime(2023, 3, 1, 16, 58, 55, 834, DateTimeKind.Local).AddTicks(5856), null, new DateTime(2023, 2, 9, 15, 59, 22, 948, DateTimeKind.Local).AddTicks(5121), "Rustic Frozen Bike", 56m, "39067999", true },
                    { 67, 1, 5, new DateTime(2023, 3, 2, 11, 1, 21, 46, DateTimeKind.Local).AddTicks(2239), null, new DateTime(2022, 4, 10, 20, 51, 6, 766, DateTimeKind.Local).AddTicks(4773), "Small Plastic Table", 49m, "67662074", true },
                    { 68, 3, 3, new DateTime(2023, 3, 8, 22, 9, 25, 53, DateTimeKind.Local).AddTicks(2502), null, new DateTime(2022, 8, 9, 4, 51, 24, 400, DateTimeKind.Local).AddTicks(1679), "Handcrafted Wooden Car", 56m, "84523884", true },
                    { 69, 10, 3, new DateTime(2022, 5, 28, 23, 36, 55, 545, DateTimeKind.Local).AddTicks(3166), null, new DateTime(2022, 8, 21, 17, 15, 6, 732, DateTimeKind.Local).AddTicks(1277), "Small Concrete Chair", 51m, "94264159", true },
                    { 70, 1, 1, new DateTime(2023, 1, 17, 13, 53, 38, 471, DateTimeKind.Local).AddTicks(6819), null, new DateTime(2022, 6, 14, 9, 39, 37, 833, DateTimeKind.Local).AddTicks(1181), "Practical Steel Towels", 55m, "27612644", true },
                    { 71, 6, 5, new DateTime(2022, 6, 20, 10, 9, 32, 747, DateTimeKind.Local).AddTicks(4663), null, new DateTime(2022, 12, 8, 13, 16, 51, 370, DateTimeKind.Local).AddTicks(1983), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 72, 8, 1, new DateTime(2022, 7, 18, 7, 24, 49, 758, DateTimeKind.Local).AddTicks(9903), null, new DateTime(2022, 10, 22, 15, 28, 58, 201, DateTimeKind.Local).AddTicks(416), "Intelligent Rubber Table", 55m, "37648848", true },
                    { 73, 4, 5, new DateTime(2023, 1, 16, 0, 51, 44, 130, DateTimeKind.Local).AddTicks(5663), null, new DateTime(2022, 6, 21, 17, 27, 30, 66, DateTimeKind.Local).AddTicks(7587), "Practical Concrete Shoes", 54m, "60638090", true },
                    { 74, 8, 10, new DateTime(2022, 7, 16, 14, 37, 36, 892, DateTimeKind.Local).AddTicks(7157), null, new DateTime(2022, 8, 31, 2, 50, 40, 88, DateTimeKind.Local).AddTicks(8907), "Incredible Steel Gloves", 57m, "49528077", true },
                    { 75, 6, 3, new DateTime(2022, 7, 18, 23, 33, 37, 944, DateTimeKind.Local).AddTicks(2416), null, new DateTime(2022, 11, 23, 16, 44, 13, 766, DateTimeKind.Local).AddTicks(214), "Sleek Metal Salad", 55m, "12091256", true },
                    { 76, 7, 10, new DateTime(2022, 8, 16, 4, 37, 38, 658, DateTimeKind.Local).AddTicks(9946), null, new DateTime(2022, 6, 3, 5, 32, 32, 235, DateTimeKind.Local).AddTicks(4993), "Fantastic Plastic Bike", 53m, "53782588", true },
                    { 77, 2, 1, new DateTime(2022, 7, 23, 11, 33, 45, 260, DateTimeKind.Local).AddTicks(5844), null, new DateTime(2022, 5, 21, 6, 0, 2, 501, DateTimeKind.Local).AddTicks(3866), "Ergonomic Frozen Tuna", 50m, "52560538", true },
                    { 78, 7, 9, new DateTime(2023, 2, 4, 12, 25, 53, 687, DateTimeKind.Local).AddTicks(1131), null, new DateTime(2022, 12, 15, 3, 18, 1, 542, DateTimeKind.Local).AddTicks(4050), "Handcrafted Steel Towels", 52m, "64761275", true },
                    { 79, 2, 7, new DateTime(2022, 10, 7, 9, 9, 36, 680, DateTimeKind.Local).AddTicks(9844), null, new DateTime(2022, 12, 27, 4, 30, 12, 601, DateTimeKind.Local).AddTicks(2363), "Gorgeous Cotton Gloves", 51m, "16531086", true },
                    { 80, 6, 3, new DateTime(2023, 3, 23, 4, 3, 41, 950, DateTimeKind.Local).AddTicks(9682), null, new DateTime(2022, 5, 17, 18, 2, 2, 756, DateTimeKind.Local).AddTicks(8139), "Gorgeous Rubber Computer", 52m, "88419336", true },
                    { 81, 5, 7, new DateTime(2022, 11, 4, 16, 40, 29, 920, DateTimeKind.Local).AddTicks(8718), null, new DateTime(2022, 6, 21, 2, 29, 15, 697, DateTimeKind.Local).AddTicks(528), "Fantastic Fresh Hat", 55m, "29785216", true },
                    { 82, 4, 3, new DateTime(2022, 4, 18, 21, 17, 50, 470, DateTimeKind.Local).AddTicks(9379), null, new DateTime(2022, 7, 1, 20, 45, 11, 505, DateTimeKind.Local).AddTicks(1798), "Refined Rubber Mouse", 56m, "90723483", true },
                    { 83, 6, 8, new DateTime(2023, 2, 9, 13, 5, 1, 625, DateTimeKind.Local).AddTicks(1148), null, new DateTime(2022, 7, 16, 17, 42, 16, 855, DateTimeKind.Local).AddTicks(1903), "Incredible Steel Ball", 50m, "69131349", true },
                    { 84, 2, 7, new DateTime(2022, 12, 21, 22, 51, 38, 448, DateTimeKind.Local).AddTicks(9107), null, new DateTime(2022, 10, 26, 23, 33, 52, 642, DateTimeKind.Local).AddTicks(4488), "Rustic Frozen Chicken", 49m, "57061764", true },
                    { 85, 10, 3, new DateTime(2022, 9, 27, 23, 34, 57, 585, DateTimeKind.Local).AddTicks(6928), null, new DateTime(2022, 10, 25, 6, 17, 9, 311, DateTimeKind.Local).AddTicks(8233), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 86, 2, 5, new DateTime(2022, 10, 25, 23, 1, 6, 790, DateTimeKind.Local).AddTicks(5954), null, new DateTime(2023, 3, 4, 3, 9, 34, 298, DateTimeKind.Local).AddTicks(356), "Gorgeous Concrete Car", 53m, "38514920", true },
                    { 87, 10, 9, new DateTime(2022, 11, 16, 2, 26, 51, 12, DateTimeKind.Local).AddTicks(4474), null, new DateTime(2022, 6, 3, 15, 31, 31, 522, DateTimeKind.Local).AddTicks(2203), "Incredible Frozen Computer", 55m, "70972672", true },
                    { 88, 5, 4, new DateTime(2022, 6, 8, 11, 45, 34, 34, DateTimeKind.Local).AddTicks(4987), null, new DateTime(2022, 8, 14, 3, 41, 54, 109, DateTimeKind.Local).AddTicks(4529), "Awesome Steel Computer", 54m, "53669506", true },
                    { 89, 9, 6, new DateTime(2022, 4, 26, 17, 15, 17, 208, DateTimeKind.Local).AddTicks(6795), null, new DateTime(2022, 8, 4, 12, 32, 16, 362, DateTimeKind.Local).AddTicks(5350), "Generic Concrete Fish", 54m, "57128436", true },
                    { 90, 2, 4, new DateTime(2023, 1, 27, 12, 55, 54, 472, DateTimeKind.Local).AddTicks(2482), null, new DateTime(2022, 8, 25, 12, 35, 31, 517, DateTimeKind.Local).AddTicks(7064), "Small Rubber Fish", 53m, "41359761", true },
                    { 91, 3, 9, new DateTime(2023, 1, 13, 23, 8, 53, 831, DateTimeKind.Local).AddTicks(1344), null, new DateTime(2023, 2, 2, 21, 5, 54, 926, DateTimeKind.Local).AddTicks(2745), "Handcrafted Granite Salad", 53m, "04038047", true },
                    { 92, 9, 8, new DateTime(2022, 5, 13, 3, 7, 31, 664, DateTimeKind.Local).AddTicks(6489), null, new DateTime(2022, 6, 15, 7, 11, 2, 529, DateTimeKind.Local).AddTicks(4413), "Licensed Soft Tuna", 50m, "55683432", true },
                    { 93, 9, 3, new DateTime(2022, 10, 1, 9, 35, 9, 41, DateTimeKind.Local).AddTicks(9541), null, new DateTime(2023, 3, 26, 15, 13, 20, 258, DateTimeKind.Local).AddTicks(7188), "Practical Frozen Car", 50m, "78629295", true },
                    { 94, 6, 7, new DateTime(2023, 2, 13, 14, 28, 25, 624, DateTimeKind.Local).AddTicks(4562), null, new DateTime(2022, 7, 16, 12, 5, 39, 534, DateTimeKind.Local).AddTicks(4843), "Incredible Steel Gloves", 55m, "99696009", true },
                    { 95, 8, 6, new DateTime(2023, 3, 19, 18, 25, 33, 930, DateTimeKind.Local).AddTicks(1927), null, new DateTime(2022, 9, 24, 21, 2, 26, 929, DateTimeKind.Local).AddTicks(3118), "Handmade Concrete Table", 55m, "64804316", true },
                    { 96, 4, 1, new DateTime(2023, 2, 25, 8, 0, 54, 815, DateTimeKind.Local).AddTicks(9862), null, new DateTime(2022, 6, 30, 3, 1, 53, 608, DateTimeKind.Local).AddTicks(3234), "Gorgeous Soft Gloves", 51m, "12409877", true },
                    { 97, 9, 10, new DateTime(2022, 10, 31, 20, 40, 4, 489, DateTimeKind.Local).AddTicks(6474), null, new DateTime(2022, 6, 28, 23, 36, 28, 230, DateTimeKind.Local).AddTicks(733), "Rustic Wooden Computer", 50m, "47778559", true },
                    { 98, 5, 3, new DateTime(2023, 1, 29, 11, 45, 17, 342, DateTimeKind.Local).AddTicks(6164), null, new DateTime(2022, 4, 30, 0, 32, 5, 982, DateTimeKind.Local).AddTicks(6443), "Fantastic Frozen Salad", 49m, "82310431", true },
                    { 99, 5, 10, new DateTime(2022, 6, 21, 7, 16, 14, 410, DateTimeKind.Local).AddTicks(8204), null, new DateTime(2022, 8, 30, 12, 43, 36, 372, DateTimeKind.Local).AddTicks(4864), "Practical Cotton Chips", 54m, "10455845", true },
                    { 100, 1, 10, new DateTime(2022, 7, 7, 19, 7, 31, 21, DateTimeKind.Local).AddTicks(1665), null, new DateTime(2023, 2, 17, 16, 9, 9, 710, DateTimeKind.Local).AddTicks(2664), "Incredible Rubber Soap", 49m, "57122588", true }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "ContactId", "CreateDate", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 2, 23, 22, 39, 15, 344, DateTimeKind.Local).AddTicks(6594), new DateTime(2022, 10, 16, 21, 45, 28, 608, DateTimeKind.Local).AddTicks(5981) },
                    { 2, 8, new DateTime(2022, 8, 8, 8, 54, 21, 574, DateTimeKind.Local).AddTicks(6033), new DateTime(2022, 10, 29, 9, 35, 45, 294, DateTimeKind.Local).AddTicks(4261) },
                    { 3, 4, new DateTime(2022, 4, 25, 20, 32, 16, 669, DateTimeKind.Local).AddTicks(1571), new DateTime(2023, 2, 27, 9, 40, 38, 529, DateTimeKind.Local).AddTicks(7308) },
                    { 4, 7, new DateTime(2023, 3, 25, 21, 54, 46, 883, DateTimeKind.Local).AddTicks(3883), new DateTime(2023, 1, 4, 20, 2, 10, 275, DateTimeKind.Local).AddTicks(6964) },
                    { 5, 4, new DateTime(2022, 4, 9, 2, 24, 40, 639, DateTimeKind.Local).AddTicks(5359), new DateTime(2022, 7, 30, 9, 22, 22, 732, DateTimeKind.Local).AddTicks(5778) },
                    { 6, 7, new DateTime(2022, 12, 23, 4, 3, 48, 602, DateTimeKind.Local).AddTicks(69), new DateTime(2022, 8, 23, 18, 20, 13, 77, DateTimeKind.Local).AddTicks(8553) },
                    { 7, 8, new DateTime(2022, 7, 23, 5, 1, 57, 452, DateTimeKind.Local).AddTicks(7699), new DateTime(2022, 4, 23, 16, 42, 44, 307, DateTimeKind.Local).AddTicks(4853) },
                    { 8, 1, new DateTime(2023, 2, 5, 15, 13, 28, 400, DateTimeKind.Local).AddTicks(4649), new DateTime(2022, 11, 16, 22, 42, 17, 502, DateTimeKind.Local).AddTicks(5319) },
                    { 9, 8, new DateTime(2023, 2, 2, 12, 14, 21, 268, DateTimeKind.Local).AddTicks(6914), new DateTime(2022, 6, 19, 15, 13, 37, 83, DateTimeKind.Local).AddTicks(6618) },
                    { 10, 4, new DateTime(2022, 6, 8, 23, 2, 32, 832, DateTimeKind.Local).AddTicks(3732), new DateTime(2022, 5, 16, 19, 17, 53, 976, DateTimeKind.Local).AddTicks(7305) },
                    { 11, 6, new DateTime(2022, 7, 17, 18, 10, 53, 753, DateTimeKind.Local).AddTicks(7554), new DateTime(2022, 7, 24, 2, 56, 24, 45, DateTimeKind.Local).AddTicks(7538) },
                    { 12, 1, new DateTime(2022, 4, 8, 7, 56, 12, 831, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 6, 15, 1, 34, 9, 998, DateTimeKind.Local).AddTicks(26) },
                    { 13, 9, new DateTime(2023, 3, 13, 13, 14, 32, 556, DateTimeKind.Local).AddTicks(5718), new DateTime(2022, 9, 29, 14, 40, 55, 995, DateTimeKind.Local).AddTicks(1662) },
                    { 14, 6, new DateTime(2022, 12, 26, 18, 49, 23, 216, DateTimeKind.Local).AddTicks(261), new DateTime(2022, 4, 7, 15, 6, 55, 716, DateTimeKind.Local).AddTicks(5407) },
                    { 15, 7, new DateTime(2022, 11, 15, 6, 1, 11, 499, DateTimeKind.Local).AddTicks(2823), new DateTime(2022, 10, 28, 20, 0, 22, 666, DateTimeKind.Local).AddTicks(1906) },
                    { 16, 7, new DateTime(2022, 8, 1, 2, 54, 28, 947, DateTimeKind.Local).AddTicks(9711), new DateTime(2022, 10, 14, 18, 23, 21, 418, DateTimeKind.Local).AddTicks(611) },
                    { 17, 3, new DateTime(2022, 11, 27, 8, 15, 2, 497, DateTimeKind.Local).AddTicks(65), new DateTime(2022, 9, 25, 6, 47, 53, 957, DateTimeKind.Local).AddTicks(1083) },
                    { 18, 2, new DateTime(2022, 11, 29, 20, 39, 44, 162, DateTimeKind.Local).AddTicks(7795), new DateTime(2022, 7, 26, 21, 31, 25, 8, DateTimeKind.Local).AddTicks(2433) },
                    { 19, 4, new DateTime(2023, 2, 7, 16, 31, 4, 64, DateTimeKind.Local).AddTicks(6623), new DateTime(2022, 4, 23, 16, 12, 4, 353, DateTimeKind.Local).AddTicks(2820) },
                    { 20, 1, new DateTime(2022, 4, 14, 23, 32, 28, 397, DateTimeKind.Local).AddTicks(3764), new DateTime(2022, 10, 9, 5, 26, 17, 714, DateTimeKind.Local).AddTicks(9876) },
                    { 21, 7, new DateTime(2023, 3, 19, 6, 19, 1, 685, DateTimeKind.Local).AddTicks(8789), new DateTime(2023, 2, 20, 6, 16, 1, 245, DateTimeKind.Local).AddTicks(8599) },
                    { 22, 3, new DateTime(2023, 3, 4, 22, 4, 8, 847, DateTimeKind.Local).AddTicks(6455), new DateTime(2022, 12, 12, 12, 30, 10, 538, DateTimeKind.Local).AddTicks(7097) },
                    { 23, 6, new DateTime(2022, 12, 14, 11, 52, 8, 97, DateTimeKind.Local).AddTicks(9008), new DateTime(2022, 4, 6, 3, 14, 45, 217, DateTimeKind.Local).AddTicks(5422) },
                    { 24, 9, new DateTime(2022, 6, 18, 18, 32, 51, 144, DateTimeKind.Local).AddTicks(6496), new DateTime(2023, 1, 14, 23, 35, 33, 454, DateTimeKind.Local).AddTicks(5135) },
                    { 25, 2, new DateTime(2023, 1, 30, 0, 47, 24, 974, DateTimeKind.Local).AddTicks(4816), new DateTime(2022, 10, 30, 18, 58, 51, 645, DateTimeKind.Local).AddTicks(8229) },
                    { 26, 10, new DateTime(2022, 11, 9, 12, 45, 47, 517, DateTimeKind.Local).AddTicks(5779), new DateTime(2022, 6, 26, 17, 58, 34, 310, DateTimeKind.Local).AddTicks(2627) },
                    { 27, 10, new DateTime(2023, 2, 19, 15, 18, 7, 626, DateTimeKind.Local).AddTicks(1639), new DateTime(2022, 10, 7, 18, 6, 9, 729, DateTimeKind.Local).AddTicks(8012) },
                    { 28, 4, new DateTime(2023, 3, 13, 11, 26, 10, 848, DateTimeKind.Local).AddTicks(5355), new DateTime(2022, 10, 15, 23, 33, 47, 744, DateTimeKind.Local).AddTicks(4483) },
                    { 29, 4, new DateTime(2022, 11, 15, 3, 44, 46, 497, DateTimeKind.Local).AddTicks(6186), new DateTime(2022, 11, 21, 6, 17, 27, 0, DateTimeKind.Local).AddTicks(583) },
                    { 30, 1, new DateTime(2022, 8, 22, 14, 57, 46, 402, DateTimeKind.Local).AddTicks(5342), new DateTime(2022, 6, 4, 0, 11, 26, 175, DateTimeKind.Local).AddTicks(4922) },
                    { 31, 9, new DateTime(2022, 6, 26, 23, 7, 28, 162, DateTimeKind.Local).AddTicks(2712), new DateTime(2023, 3, 3, 22, 28, 21, 568, DateTimeKind.Local).AddTicks(2794) },
                    { 32, 1, new DateTime(2022, 5, 16, 21, 8, 25, 207, DateTimeKind.Local).AddTicks(3291), new DateTime(2023, 1, 12, 21, 16, 38, 939, DateTimeKind.Local).AddTicks(2321) },
                    { 33, 9, new DateTime(2022, 10, 13, 12, 19, 3, 621, DateTimeKind.Local).AddTicks(9975), new DateTime(2022, 12, 16, 16, 43, 20, 60, DateTimeKind.Local).AddTicks(7224) },
                    { 34, 2, new DateTime(2023, 2, 18, 3, 7, 22, 381, DateTimeKind.Local).AddTicks(6505), new DateTime(2022, 11, 20, 23, 48, 38, 259, DateTimeKind.Local).AddTicks(1567) },
                    { 35, 5, new DateTime(2022, 11, 21, 18, 59, 1, 389, DateTimeKind.Local).AddTicks(3306), new DateTime(2022, 9, 13, 22, 28, 28, 761, DateTimeKind.Local).AddTicks(4443) },
                    { 36, 4, new DateTime(2023, 3, 11, 8, 56, 1, 406, DateTimeKind.Local).AddTicks(3171), new DateTime(2023, 2, 3, 4, 38, 36, 597, DateTimeKind.Local).AddTicks(3860) },
                    { 37, 3, new DateTime(2022, 10, 27, 1, 43, 16, 23, DateTimeKind.Local).AddTicks(5064), new DateTime(2022, 7, 4, 12, 31, 33, 956, DateTimeKind.Local).AddTicks(1734) },
                    { 38, 2, new DateTime(2023, 2, 14, 5, 7, 33, 678, DateTimeKind.Local).AddTicks(8131), new DateTime(2022, 5, 29, 17, 0, 38, 180, DateTimeKind.Local).AddTicks(3023) },
                    { 39, 10, new DateTime(2022, 12, 10, 6, 18, 9, 954, DateTimeKind.Local).AddTicks(2489), new DateTime(2022, 4, 11, 3, 39, 8, 246, DateTimeKind.Local).AddTicks(4339) },
                    { 40, 7, new DateTime(2022, 5, 28, 10, 39, 1, 942, DateTimeKind.Local).AddTicks(4638), new DateTime(2022, 7, 24, 3, 5, 39, 759, DateTimeKind.Local).AddTicks(1182) },
                    { 41, 10, new DateTime(2022, 9, 19, 20, 27, 4, 601, DateTimeKind.Local).AddTicks(5184), new DateTime(2022, 7, 28, 5, 40, 39, 104, DateTimeKind.Local).AddTicks(4588) },
                    { 42, 2, new DateTime(2023, 3, 29, 7, 12, 24, 498, DateTimeKind.Local).AddTicks(9415), new DateTime(2023, 3, 28, 4, 11, 40, 391, DateTimeKind.Local).AddTicks(4713) },
                    { 43, 2, new DateTime(2023, 3, 9, 3, 10, 56, 211, DateTimeKind.Local).AddTicks(5985), new DateTime(2022, 12, 19, 12, 25, 17, 176, DateTimeKind.Local).AddTicks(2462) },
                    { 44, 3, new DateTime(2023, 3, 6, 1, 31, 11, 529, DateTimeKind.Local).AddTicks(3524), new DateTime(2022, 5, 2, 9, 13, 1, 304, DateTimeKind.Local).AddTicks(6748) },
                    { 45, 5, new DateTime(2022, 6, 8, 3, 58, 0, 117, DateTimeKind.Local).AddTicks(9500), new DateTime(2022, 4, 6, 20, 57, 2, 653, DateTimeKind.Local).AddTicks(6086) },
                    { 46, 2, new DateTime(2022, 5, 31, 14, 27, 56, 874, DateTimeKind.Local).AddTicks(1719), new DateTime(2022, 7, 26, 1, 13, 26, 868, DateTimeKind.Local).AddTicks(3009) },
                    { 47, 10, new DateTime(2023, 3, 16, 14, 3, 56, 926, DateTimeKind.Local).AddTicks(1184), new DateTime(2022, 12, 10, 3, 35, 2, 500, DateTimeKind.Local).AddTicks(3983) },
                    { 48, 3, new DateTime(2022, 7, 7, 11, 38, 43, 84, DateTimeKind.Local).AddTicks(1821), new DateTime(2023, 1, 29, 22, 0, 47, 788, DateTimeKind.Local).AddTicks(1256) },
                    { 49, 1, new DateTime(2022, 7, 30, 19, 54, 53, 10, DateTimeKind.Local).AddTicks(7971), new DateTime(2022, 8, 16, 2, 46, 11, 892, DateTimeKind.Local).AddTicks(5599) },
                    { 50, 3, new DateTime(2023, 3, 25, 6, 40, 47, 704, DateTimeKind.Local).AddTicks(889), new DateTime(2022, 9, 9, 23, 36, 32, 662, DateTimeKind.Local).AddTicks(1829) },
                    { 51, 3, new DateTime(2023, 1, 14, 10, 54, 58, 378, DateTimeKind.Local).AddTicks(3669), new DateTime(2022, 8, 21, 10, 26, 19, 88, DateTimeKind.Local).AddTicks(6373) },
                    { 52, 7, new DateTime(2023, 1, 29, 10, 3, 45, 997, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 9, 3, 15, 26, 35, 189, DateTimeKind.Local).AddTicks(2364) },
                    { 53, 7, new DateTime(2022, 12, 11, 20, 51, 34, 567, DateTimeKind.Local).AddTicks(5682), new DateTime(2022, 11, 28, 20, 32, 54, 299, DateTimeKind.Local).AddTicks(4942) },
                    { 54, 6, new DateTime(2023, 1, 31, 14, 51, 26, 25, DateTimeKind.Local).AddTicks(4608), new DateTime(2022, 4, 7, 14, 31, 22, 603, DateTimeKind.Local).AddTicks(8245) },
                    { 55, 9, new DateTime(2023, 3, 14, 13, 36, 38, 64, DateTimeKind.Local).AddTicks(9302), new DateTime(2022, 11, 26, 8, 58, 21, 903, DateTimeKind.Local).AddTicks(2607) },
                    { 56, 9, new DateTime(2022, 7, 23, 5, 44, 33, 202, DateTimeKind.Local).AddTicks(5808), new DateTime(2022, 12, 12, 9, 55, 50, 969, DateTimeKind.Local).AddTicks(9706) },
                    { 57, 9, new DateTime(2022, 5, 21, 1, 48, 53, 923, DateTimeKind.Local).AddTicks(6447), new DateTime(2022, 10, 15, 0, 36, 30, 489, DateTimeKind.Local).AddTicks(1854) },
                    { 58, 3, new DateTime(2022, 7, 9, 14, 23, 11, 927, DateTimeKind.Local).AddTicks(5109), new DateTime(2022, 6, 17, 5, 21, 22, 425, DateTimeKind.Local).AddTicks(4547) },
                    { 59, 4, new DateTime(2022, 7, 9, 13, 20, 10, 545, DateTimeKind.Local).AddTicks(833), new DateTime(2022, 6, 18, 17, 34, 38, 926, DateTimeKind.Local).AddTicks(4464) },
                    { 60, 6, new DateTime(2023, 3, 8, 0, 9, 44, 231, DateTimeKind.Local).AddTicks(8361), new DateTime(2022, 12, 2, 20, 3, 48, 897, DateTimeKind.Local).AddTicks(2585) },
                    { 61, 4, new DateTime(2022, 5, 14, 4, 25, 45, 907, DateTimeKind.Local).AddTicks(3628), new DateTime(2023, 3, 20, 5, 16, 25, 916, DateTimeKind.Local).AddTicks(6247) },
                    { 62, 8, new DateTime(2022, 4, 19, 12, 50, 59, 422, DateTimeKind.Local).AddTicks(8993), new DateTime(2022, 5, 25, 23, 22, 30, 560, DateTimeKind.Local).AddTicks(1014) },
                    { 63, 4, new DateTime(2022, 5, 21, 20, 23, 51, 357, DateTimeKind.Local).AddTicks(435), new DateTime(2022, 8, 13, 2, 40, 31, 529, DateTimeKind.Local).AddTicks(1389) },
                    { 64, 5, new DateTime(2022, 10, 27, 8, 55, 49, 725, DateTimeKind.Local).AddTicks(547), new DateTime(2022, 9, 23, 2, 22, 39, 715, DateTimeKind.Local).AddTicks(7212) },
                    { 65, 4, new DateTime(2022, 11, 18, 15, 34, 48, 22, DateTimeKind.Local).AddTicks(1402), new DateTime(2022, 5, 19, 7, 58, 48, 309, DateTimeKind.Local).AddTicks(7759) },
                    { 66, 4, new DateTime(2022, 12, 6, 18, 11, 48, 390, DateTimeKind.Local).AddTicks(6425), new DateTime(2022, 7, 29, 6, 48, 22, 428, DateTimeKind.Local).AddTicks(3710) },
                    { 67, 9, new DateTime(2023, 1, 1, 17, 7, 36, 976, DateTimeKind.Local).AddTicks(9311), new DateTime(2022, 4, 12, 22, 56, 37, 217, DateTimeKind.Local).AddTicks(3332) },
                    { 68, 4, new DateTime(2022, 11, 16, 18, 10, 25, 270, DateTimeKind.Local).AddTicks(3949), new DateTime(2023, 2, 7, 13, 38, 11, 189, DateTimeKind.Local).AddTicks(5617) },
                    { 69, 1, new DateTime(2022, 4, 22, 23, 58, 6, 723, DateTimeKind.Local).AddTicks(7775), new DateTime(2022, 10, 11, 5, 18, 3, 859, DateTimeKind.Local).AddTicks(9743) },
                    { 70, 9, new DateTime(2023, 1, 14, 22, 53, 20, 451, DateTimeKind.Local).AddTicks(9973), new DateTime(2022, 10, 26, 5, 29, 52, 861, DateTimeKind.Local).AddTicks(9636) },
                    { 71, 8, new DateTime(2023, 1, 31, 19, 14, 25, 247, DateTimeKind.Local).AddTicks(4786), new DateTime(2023, 1, 9, 5, 28, 7, 744, DateTimeKind.Local).AddTicks(8520) },
                    { 72, 1, new DateTime(2023, 2, 10, 1, 37, 37, 280, DateTimeKind.Local).AddTicks(1730), new DateTime(2022, 12, 23, 19, 11, 57, 527, DateTimeKind.Local).AddTicks(2186) },
                    { 73, 10, new DateTime(2023, 2, 9, 12, 10, 52, 316, DateTimeKind.Local).AddTicks(1885), new DateTime(2023, 2, 28, 9, 31, 56, 51, DateTimeKind.Local).AddTicks(1523) },
                    { 74, 5, new DateTime(2022, 9, 26, 13, 18, 7, 844, DateTimeKind.Local).AddTicks(5739), new DateTime(2022, 6, 6, 18, 6, 59, 254, DateTimeKind.Local).AddTicks(6594) },
                    { 75, 7, new DateTime(2022, 10, 24, 23, 19, 25, 471, DateTimeKind.Local).AddTicks(4352), new DateTime(2022, 10, 28, 1, 39, 21, 607, DateTimeKind.Local).AddTicks(7129) },
                    { 76, 10, new DateTime(2022, 4, 25, 6, 31, 26, 218, DateTimeKind.Local).AddTicks(4406), new DateTime(2022, 11, 24, 7, 34, 41, 314, DateTimeKind.Local).AddTicks(4944) },
                    { 77, 10, new DateTime(2023, 3, 15, 19, 13, 14, 771, DateTimeKind.Local).AddTicks(2613), new DateTime(2022, 11, 6, 3, 54, 39, 563, DateTimeKind.Local).AddTicks(5653) },
                    { 78, 2, new DateTime(2022, 7, 29, 3, 23, 42, 840, DateTimeKind.Local).AddTicks(5842), new DateTime(2022, 6, 9, 15, 48, 24, 664, DateTimeKind.Local).AddTicks(303) },
                    { 79, 4, new DateTime(2023, 3, 13, 17, 21, 24, 985, DateTimeKind.Local).AddTicks(4452), new DateTime(2022, 9, 30, 19, 1, 38, 46, DateTimeKind.Local).AddTicks(941) },
                    { 80, 9, new DateTime(2022, 8, 18, 22, 34, 59, 750, DateTimeKind.Local).AddTicks(1899), new DateTime(2023, 4, 1, 21, 39, 10, 108, DateTimeKind.Local).AddTicks(2486) },
                    { 81, 4, new DateTime(2022, 10, 11, 2, 28, 2, 961, DateTimeKind.Local).AddTicks(9798), new DateTime(2022, 8, 10, 6, 16, 48, 314, DateTimeKind.Local).AddTicks(1739) },
                    { 82, 3, new DateTime(2022, 8, 21, 16, 24, 48, 610, DateTimeKind.Local).AddTicks(7078), new DateTime(2022, 12, 29, 22, 27, 41, 886, DateTimeKind.Local).AddTicks(7046) },
                    { 83, 3, new DateTime(2022, 12, 4, 12, 57, 44, 575, DateTimeKind.Local).AddTicks(6976), new DateTime(2023, 1, 11, 22, 43, 28, 151, DateTimeKind.Local).AddTicks(965) },
                    { 84, 6, new DateTime(2022, 11, 19, 12, 35, 0, 618, DateTimeKind.Local).AddTicks(5013), new DateTime(2023, 1, 30, 14, 47, 13, 483, DateTimeKind.Local).AddTicks(5840) },
                    { 85, 6, new DateTime(2022, 12, 6, 12, 12, 51, 950, DateTimeKind.Local).AddTicks(8339), new DateTime(2022, 7, 11, 12, 35, 46, 541, DateTimeKind.Local).AddTicks(4881) },
                    { 86, 2, new DateTime(2022, 8, 8, 18, 21, 18, 890, DateTimeKind.Local).AddTicks(8835), new DateTime(2022, 4, 28, 3, 37, 17, 208, DateTimeKind.Local).AddTicks(913) },
                    { 87, 8, new DateTime(2023, 2, 7, 9, 32, 28, 808, DateTimeKind.Local).AddTicks(6601), new DateTime(2023, 4, 3, 2, 12, 57, 914, DateTimeKind.Local).AddTicks(4694) },
                    { 88, 2, new DateTime(2022, 5, 11, 16, 28, 39, 956, DateTimeKind.Local).AddTicks(6316), new DateTime(2023, 2, 4, 12, 26, 23, 89, DateTimeKind.Local).AddTicks(8693) },
                    { 89, 1, new DateTime(2022, 7, 31, 19, 51, 57, 173, DateTimeKind.Local).AddTicks(8433), new DateTime(2022, 10, 9, 0, 36, 59, 816, DateTimeKind.Local).AddTicks(285) },
                    { 90, 5, new DateTime(2022, 8, 10, 12, 8, 11, 131, DateTimeKind.Local).AddTicks(4397), new DateTime(2023, 3, 4, 17, 2, 29, 703, DateTimeKind.Local).AddTicks(8627) },
                    { 91, 8, new DateTime(2023, 3, 14, 2, 22, 59, 369, DateTimeKind.Local).AddTicks(2671), new DateTime(2022, 9, 26, 22, 22, 9, 975, DateTimeKind.Local).AddTicks(1343) },
                    { 92, 1, new DateTime(2023, 2, 22, 0, 17, 42, 52, DateTimeKind.Local).AddTicks(1630), new DateTime(2023, 3, 21, 19, 36, 22, 291, DateTimeKind.Local).AddTicks(7306) },
                    { 93, 2, new DateTime(2022, 10, 17, 18, 50, 58, 182, DateTimeKind.Local).AddTicks(7881), new DateTime(2022, 6, 8, 15, 40, 54, 269, DateTimeKind.Local).AddTicks(8647) },
                    { 94, 2, new DateTime(2022, 8, 13, 10, 5, 36, 211, DateTimeKind.Local).AddTicks(7273), new DateTime(2022, 8, 25, 2, 19, 59, 51, DateTimeKind.Local).AddTicks(8811) },
                    { 95, 2, new DateTime(2022, 12, 8, 17, 22, 0, 742, DateTimeKind.Local).AddTicks(2547), new DateTime(2022, 7, 30, 15, 24, 31, 561, DateTimeKind.Local).AddTicks(8990) },
                    { 96, 3, new DateTime(2022, 9, 25, 22, 16, 7, 529, DateTimeKind.Local).AddTicks(9906), new DateTime(2022, 11, 25, 23, 57, 8, 298, DateTimeKind.Local).AddTicks(8900) },
                    { 97, 1, new DateTime(2023, 1, 19, 1, 3, 51, 126, DateTimeKind.Local).AddTicks(3863), new DateTime(2022, 11, 8, 7, 46, 23, 503, DateTimeKind.Local).AddTicks(7022) },
                    { 98, 6, new DateTime(2023, 2, 2, 12, 25, 42, 554, DateTimeKind.Local).AddTicks(3496), new DateTime(2022, 10, 14, 21, 48, 48, 350, DateTimeKind.Local).AddTicks(6710) },
                    { 99, 1, new DateTime(2023, 1, 1, 5, 7, 21, 563, DateTimeKind.Local).AddTicks(7834), new DateTime(2022, 9, 4, 18, 45, 40, 414, DateTimeKind.Local).AddTicks(4904) },
                    { 100, 5, new DateTime(2023, 2, 1, 4, 21, 42, 777, DateTimeKind.Local).AddTicks(9141), new DateTime(2022, 4, 26, 5, 19, 8, 846, DateTimeKind.Local).AddTicks(76) },
                    { 101, 8, new DateTime(2022, 5, 18, 16, 1, 6, 299, DateTimeKind.Local).AddTicks(1855), new DateTime(2022, 7, 30, 9, 35, 50, 853, DateTimeKind.Local).AddTicks(4016) },
                    { 102, 2, new DateTime(2022, 6, 6, 21, 22, 48, 710, DateTimeKind.Local).AddTicks(5712), new DateTime(2022, 12, 11, 18, 58, 18, 658, DateTimeKind.Local).AddTicks(3815) },
                    { 103, 7, new DateTime(2022, 10, 5, 18, 9, 57, 843, DateTimeKind.Local).AddTicks(4573), new DateTime(2023, 1, 17, 20, 41, 27, 307, DateTimeKind.Local).AddTicks(8192) },
                    { 104, 7, new DateTime(2022, 4, 15, 1, 45, 44, 431, DateTimeKind.Local).AddTicks(3314), new DateTime(2023, 1, 25, 8, 16, 38, 117, DateTimeKind.Local).AddTicks(2446) },
                    { 105, 2, new DateTime(2022, 9, 17, 17, 33, 27, 269, DateTimeKind.Local).AddTicks(9846), new DateTime(2022, 9, 30, 8, 13, 10, 6, DateTimeKind.Local).AddTicks(828) },
                    { 106, 4, new DateTime(2022, 4, 9, 21, 38, 26, 791, DateTimeKind.Local).AddTicks(2268), new DateTime(2022, 9, 6, 7, 52, 56, 623, DateTimeKind.Local).AddTicks(5275) },
                    { 107, 5, new DateTime(2022, 6, 18, 21, 14, 4, 627, DateTimeKind.Local).AddTicks(5626), new DateTime(2023, 2, 8, 6, 22, 7, 53, DateTimeKind.Local).AddTicks(40) },
                    { 108, 2, new DateTime(2022, 12, 6, 19, 13, 22, 367, DateTimeKind.Local).AddTicks(4258), new DateTime(2022, 10, 25, 19, 50, 37, 414, DateTimeKind.Local).AddTicks(2056) },
                    { 109, 7, new DateTime(2023, 1, 23, 17, 32, 16, 52, DateTimeKind.Local).AddTicks(2690), new DateTime(2022, 5, 14, 22, 43, 34, 224, DateTimeKind.Local).AddTicks(705) },
                    { 110, 1, new DateTime(2023, 3, 5, 1, 12, 51, 158, DateTimeKind.Local).AddTicks(2726), new DateTime(2022, 5, 27, 3, 56, 37, 897, DateTimeKind.Local).AddTicks(5334) },
                    { 111, 5, new DateTime(2022, 7, 28, 2, 46, 3, 125, DateTimeKind.Local).AddTicks(3297), new DateTime(2022, 12, 19, 23, 15, 32, 814, DateTimeKind.Local).AddTicks(286) },
                    { 112, 9, new DateTime(2022, 11, 11, 14, 7, 15, 59, DateTimeKind.Local).AddTicks(4818), new DateTime(2022, 7, 1, 2, 50, 47, 321, DateTimeKind.Local).AddTicks(6972) },
                    { 113, 10, new DateTime(2022, 4, 8, 11, 56, 32, 125, DateTimeKind.Local).AddTicks(3145), new DateTime(2022, 10, 7, 4, 45, 29, 440, DateTimeKind.Local).AddTicks(8398) },
                    { 114, 4, new DateTime(2022, 9, 6, 5, 28, 39, 980, DateTimeKind.Local).AddTicks(6829), new DateTime(2023, 3, 26, 12, 52, 27, 95, DateTimeKind.Local).AddTicks(6934) },
                    { 115, 2, new DateTime(2022, 11, 12, 18, 59, 31, 281, DateTimeKind.Local).AddTicks(9368), new DateTime(2023, 1, 9, 8, 4, 24, 104, DateTimeKind.Local).AddTicks(2156) },
                    { 116, 3, new DateTime(2022, 10, 19, 12, 14, 15, 308, DateTimeKind.Local).AddTicks(9290), new DateTime(2022, 8, 21, 3, 38, 32, 693, DateTimeKind.Local).AddTicks(5265) },
                    { 117, 10, new DateTime(2022, 8, 26, 4, 19, 30, 740, DateTimeKind.Local).AddTicks(3445), new DateTime(2022, 12, 27, 16, 15, 12, 181, DateTimeKind.Local).AddTicks(7189) },
                    { 118, 1, new DateTime(2023, 4, 3, 5, 34, 51, 105, DateTimeKind.Local).AddTicks(4888), new DateTime(2022, 11, 18, 15, 53, 55, 559, DateTimeKind.Local).AddTicks(5146) },
                    { 119, 8, new DateTime(2022, 8, 13, 5, 57, 7, 962, DateTimeKind.Local).AddTicks(6928), new DateTime(2022, 9, 15, 5, 34, 1, 340, DateTimeKind.Local).AddTicks(9236) },
                    { 120, 3, new DateTime(2022, 10, 19, 5, 11, 9, 656, DateTimeKind.Local).AddTicks(2293), new DateTime(2022, 8, 17, 12, 36, 50, 67, DateTimeKind.Local).AddTicks(4669) },
                    { 121, 5, new DateTime(2022, 8, 27, 0, 37, 59, 293, DateTimeKind.Local).AddTicks(1432), new DateTime(2022, 11, 6, 1, 43, 24, 94, DateTimeKind.Local).AddTicks(3473) },
                    { 122, 4, new DateTime(2023, 1, 9, 0, 54, 59, 781, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 12, 22, 7, 45, 58, 715, DateTimeKind.Local).AddTicks(1651) },
                    { 123, 10, new DateTime(2023, 1, 10, 10, 20, 54, 923, DateTimeKind.Local).AddTicks(5277), new DateTime(2023, 2, 9, 12, 12, 29, 619, DateTimeKind.Local).AddTicks(6670) },
                    { 124, 8, new DateTime(2022, 10, 17, 15, 55, 8, 73, DateTimeKind.Local).AddTicks(2679), new DateTime(2022, 4, 6, 18, 28, 12, 75, DateTimeKind.Local).AddTicks(773) },
                    { 125, 1, new DateTime(2023, 2, 22, 9, 21, 56, 33, DateTimeKind.Local).AddTicks(6100), new DateTime(2023, 1, 16, 0, 31, 42, 56, DateTimeKind.Local).AddTicks(455) },
                    { 126, 2, new DateTime(2022, 4, 10, 6, 10, 27, 935, DateTimeKind.Local).AddTicks(2255), new DateTime(2022, 4, 29, 9, 0, 8, 494, DateTimeKind.Local).AddTicks(6554) },
                    { 127, 3, new DateTime(2022, 10, 16, 18, 32, 38, 222, DateTimeKind.Local).AddTicks(8615), new DateTime(2022, 7, 10, 14, 4, 18, 152, DateTimeKind.Local).AddTicks(5073) },
                    { 128, 3, new DateTime(2023, 3, 3, 19, 44, 0, 689, DateTimeKind.Local).AddTicks(344), new DateTime(2022, 10, 13, 5, 39, 37, 827, DateTimeKind.Local).AddTicks(961) },
                    { 129, 6, new DateTime(2022, 10, 21, 22, 44, 15, 495, DateTimeKind.Local).AddTicks(4375), new DateTime(2022, 7, 30, 5, 57, 29, 429, DateTimeKind.Local).AddTicks(98) },
                    { 130, 10, new DateTime(2023, 3, 2, 20, 11, 1, 40, DateTimeKind.Local).AddTicks(146), new DateTime(2022, 7, 4, 16, 56, 24, 505, DateTimeKind.Local).AddTicks(9586) },
                    { 131, 3, new DateTime(2022, 7, 27, 11, 45, 12, 168, DateTimeKind.Local).AddTicks(4453), new DateTime(2022, 9, 23, 15, 31, 39, 878, DateTimeKind.Local).AddTicks(2557) },
                    { 132, 9, new DateTime(2022, 4, 25, 8, 57, 45, 878, DateTimeKind.Local).AddTicks(3746), new DateTime(2022, 4, 15, 13, 36, 58, 96, DateTimeKind.Local).AddTicks(7110) },
                    { 133, 7, new DateTime(2022, 6, 20, 19, 17, 8, 989, DateTimeKind.Local).AddTicks(9542), new DateTime(2023, 2, 7, 2, 50, 48, 909, DateTimeKind.Local).AddTicks(4341) },
                    { 134, 10, new DateTime(2022, 12, 11, 23, 14, 57, 492, DateTimeKind.Local).AddTicks(4116), new DateTime(2023, 1, 12, 10, 39, 37, 794, DateTimeKind.Local).AddTicks(5741) },
                    { 135, 5, new DateTime(2023, 1, 18, 16, 59, 33, 69, DateTimeKind.Local).AddTicks(3735), new DateTime(2023, 2, 11, 21, 10, 40, 76, DateTimeKind.Local).AddTicks(2503) },
                    { 136, 3, new DateTime(2022, 5, 4, 16, 31, 34, 17, DateTimeKind.Local).AddTicks(4467), new DateTime(2022, 5, 15, 4, 59, 12, 481, DateTimeKind.Local).AddTicks(532) },
                    { 137, 2, new DateTime(2022, 8, 6, 14, 13, 39, 244, DateTimeKind.Local).AddTicks(8652), new DateTime(2022, 8, 8, 8, 32, 57, 436, DateTimeKind.Local).AddTicks(6426) },
                    { 138, 7, new DateTime(2023, 3, 24, 10, 45, 17, 538, DateTimeKind.Local).AddTicks(3792), new DateTime(2022, 4, 7, 19, 24, 48, 842, DateTimeKind.Local).AddTicks(5439) },
                    { 139, 9, new DateTime(2023, 2, 8, 9, 56, 0, 312, DateTimeKind.Local).AddTicks(9382), new DateTime(2022, 9, 28, 13, 40, 16, 13, DateTimeKind.Local).AddTicks(2855) },
                    { 140, 10, new DateTime(2022, 6, 29, 13, 49, 41, 103, DateTimeKind.Local).AddTicks(6432), new DateTime(2022, 6, 23, 10, 57, 1, 695, DateTimeKind.Local).AddTicks(4149) },
                    { 141, 7, new DateTime(2022, 4, 10, 10, 25, 45, 457, DateTimeKind.Local).AddTicks(8747), new DateTime(2023, 2, 12, 22, 56, 11, 292, DateTimeKind.Local).AddTicks(6917) },
                    { 142, 4, new DateTime(2022, 9, 19, 16, 51, 54, 112, DateTimeKind.Local).AddTicks(7856), new DateTime(2022, 6, 26, 12, 56, 13, 314, DateTimeKind.Local).AddTicks(18) },
                    { 143, 5, new DateTime(2023, 1, 13, 19, 45, 5, 218, DateTimeKind.Local).AddTicks(4893), new DateTime(2023, 2, 2, 9, 10, 27, 564, DateTimeKind.Local).AddTicks(4155) },
                    { 144, 3, new DateTime(2022, 9, 30, 15, 6, 54, 365, DateTimeKind.Local).AddTicks(1399), new DateTime(2023, 1, 23, 19, 39, 36, 354, DateTimeKind.Local).AddTicks(4521) },
                    { 145, 8, new DateTime(2023, 1, 1, 20, 14, 5, 330, DateTimeKind.Local).AddTicks(1154), new DateTime(2023, 2, 8, 4, 3, 58, 139, DateTimeKind.Local).AddTicks(6315) },
                    { 146, 6, new DateTime(2022, 6, 18, 12, 25, 15, 865, DateTimeKind.Local).AddTicks(8612), new DateTime(2022, 5, 19, 11, 30, 45, 28, DateTimeKind.Local).AddTicks(8435) },
                    { 147, 4, new DateTime(2022, 12, 11, 22, 40, 43, 18, DateTimeKind.Local).AddTicks(3504), new DateTime(2022, 9, 22, 14, 58, 58, 887, DateTimeKind.Local).AddTicks(1741) },
                    { 148, 8, new DateTime(2022, 7, 4, 0, 45, 41, 160, DateTimeKind.Local).AddTicks(2232), new DateTime(2022, 10, 30, 14, 43, 39, 204, DateTimeKind.Local).AddTicks(3335) },
                    { 149, 1, new DateTime(2022, 9, 2, 9, 29, 10, 543, DateTimeKind.Local).AddTicks(6846), new DateTime(2022, 8, 8, 9, 46, 12, 39, DateTimeKind.Local).AddTicks(2511) },
                    { 150, 6, new DateTime(2022, 4, 18, 2, 22, 24, 867, DateTimeKind.Local).AddTicks(5931), new DateTime(2022, 6, 20, 7, 48, 2, 974, DateTimeKind.Local).AddTicks(6222) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Href", "ModifiedDate", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 23, 22, 39, 15, 343, DateTimeKind.Local).AddTicks(1194), "https://solkaersvin.dk", new DateTime(2022, 10, 16, 21, 45, 28, 607, DateTimeKind.Local).AddTicks(583), 25 },
                    { 2, new DateTime(2022, 8, 8, 8, 54, 21, 573, DateTimeKind.Local).AddTicks(650), "https://solkaersvin.dk", new DateTime(2022, 10, 29, 9, 35, 45, 292, DateTimeKind.Local).AddTicks(8878), 78 },
                    { 3, new DateTime(2022, 4, 25, 20, 32, 16, 667, DateTimeKind.Local).AddTicks(6189), "https://solkaersvin.dk", new DateTime(2023, 2, 27, 9, 40, 38, 528, DateTimeKind.Local).AddTicks(1927), 36 },
                    { 4, new DateTime(2023, 3, 25, 21, 54, 46, 881, DateTimeKind.Local).AddTicks(8503), "https://solkaersvin.dk", new DateTime(2023, 1, 4, 20, 2, 10, 274, DateTimeKind.Local).AddTicks(1585), 65 },
                    { 5, new DateTime(2022, 4, 9, 2, 24, 40, 637, DateTimeKind.Local).AddTicks(9981), "https://solkaersvin.dk", new DateTime(2022, 7, 30, 9, 22, 22, 731, DateTimeKind.Local).AddTicks(399), 33 },
                    { 6, new DateTime(2022, 12, 23, 4, 3, 48, 600, DateTimeKind.Local).AddTicks(4695), "https://solkaersvin.dk", new DateTime(2022, 8, 23, 18, 20, 13, 76, DateTimeKind.Local).AddTicks(3178), 66 },
                    { 7, new DateTime(2022, 7, 23, 5, 1, 57, 451, DateTimeKind.Local).AddTicks(2325), "https://solkaersvin.dk", new DateTime(2022, 4, 23, 16, 42, 44, 305, DateTimeKind.Local).AddTicks(9480), 71 },
                    { 8, new DateTime(2023, 2, 5, 15, 13, 28, 398, DateTimeKind.Local).AddTicks(9276), "https://solkaersvin.dk", new DateTime(2022, 11, 16, 22, 42, 17, 500, DateTimeKind.Local).AddTicks(9947), 10 },
                    { 9, new DateTime(2023, 2, 2, 12, 14, 21, 267, DateTimeKind.Local).AddTicks(1543), "https://solkaersvin.dk", new DateTime(2022, 6, 19, 15, 13, 37, 82, DateTimeKind.Local).AddTicks(1246), 80 },
                    { 10, new DateTime(2022, 6, 8, 23, 2, 32, 830, DateTimeKind.Local).AddTicks(8362), "https://solkaersvin.dk", new DateTime(2022, 5, 16, 19, 17, 53, 975, DateTimeKind.Local).AddTicks(1934), 31 },
                    { 11, new DateTime(2022, 7, 17, 18, 10, 53, 752, DateTimeKind.Local).AddTicks(2224), "https://solkaersvin.dk", new DateTime(2022, 7, 24, 2, 56, 24, 44, DateTimeKind.Local).AddTicks(2210), 56 },
                    { 12, new DateTime(2022, 4, 8, 7, 56, 12, 829, DateTimeKind.Local).AddTicks(5387), "https://solkaersvin.dk", new DateTime(2022, 6, 15, 1, 34, 9, 996, DateTimeKind.Local).AddTicks(4700), 2 },
                    { 13, new DateTime(2023, 3, 13, 13, 14, 32, 555, DateTimeKind.Local).AddTicks(394), "https://solkaersvin.dk", new DateTime(2022, 9, 29, 14, 40, 55, 993, DateTimeKind.Local).AddTicks(6338), 86 },
                    { 14, new DateTime(2022, 12, 26, 18, 49, 23, 214, DateTimeKind.Local).AddTicks(4938), "https://solkaersvin.dk", new DateTime(2022, 4, 7, 15, 6, 55, 715, DateTimeKind.Local).AddTicks(84), 53 },
                    { 15, new DateTime(2022, 11, 15, 6, 1, 11, 497, DateTimeKind.Local).AddTicks(7502), "https://solkaersvin.dk", new DateTime(2022, 10, 28, 20, 0, 22, 664, DateTimeKind.Local).AddTicks(6585), 70 },
                    { 16, new DateTime(2022, 8, 1, 2, 54, 28, 946, DateTimeKind.Local).AddTicks(4390), "https://solkaersvin.dk", new DateTime(2022, 10, 14, 18, 23, 21, 416, DateTimeKind.Local).AddTicks(5291), 68 },
                    { 17, new DateTime(2022, 11, 27, 8, 15, 2, 495, DateTimeKind.Local).AddTicks(4745), "https://solkaersvin.dk", new DateTime(2022, 9, 25, 6, 47, 53, 955, DateTimeKind.Local).AddTicks(5763), 25 },
                    { 18, new DateTime(2022, 11, 29, 20, 39, 44, 161, DateTimeKind.Local).AddTicks(2476), "https://solkaersvin.dk", new DateTime(2022, 7, 26, 21, 31, 25, 6, DateTimeKind.Local).AddTicks(7113), 17 },
                    { 19, new DateTime(2023, 2, 7, 16, 31, 4, 63, DateTimeKind.Local).AddTicks(1305), "https://solkaersvin.dk", new DateTime(2022, 4, 23, 16, 12, 4, 351, DateTimeKind.Local).AddTicks(7502), 40 },
                    { 20, new DateTime(2022, 4, 14, 23, 32, 28, 395, DateTimeKind.Local).AddTicks(8447), "https://solkaersvin.dk", new DateTime(2022, 10, 9, 5, 26, 17, 713, DateTimeKind.Local).AddTicks(4559), 9 },
                    { 21, new DateTime(2023, 3, 19, 6, 19, 1, 684, DateTimeKind.Local).AddTicks(3473), "https://solkaersvin.dk", new DateTime(2023, 2, 20, 6, 16, 1, 244, DateTimeKind.Local).AddTicks(3283), 64 },
                    { 22, new DateTime(2023, 3, 4, 22, 4, 8, 846, DateTimeKind.Local).AddTicks(1140), "https://solkaersvin.dk", new DateTime(2022, 12, 12, 12, 30, 10, 537, DateTimeKind.Local).AddTicks(1782), 22 },
                    { 23, new DateTime(2022, 12, 14, 11, 52, 8, 96, DateTimeKind.Local).AddTicks(3694), "https://solkaersvin.dk", new DateTime(2022, 4, 6, 3, 14, 45, 216, DateTimeKind.Local).AddTicks(108), 55 },
                    { 24, new DateTime(2022, 6, 18, 18, 32, 51, 143, DateTimeKind.Local).AddTicks(1183), "https://solkaersvin.dk", new DateTime(2023, 1, 14, 23, 35, 33, 452, DateTimeKind.Local).AddTicks(9822), 88 },
                    { 25, new DateTime(2023, 1, 30, 0, 47, 24, 972, DateTimeKind.Local).AddTicks(9505), "https://solkaersvin.dk", new DateTime(2022, 10, 30, 18, 58, 51, 644, DateTimeKind.Local).AddTicks(2918), 11 },
                    { 26, new DateTime(2022, 11, 9, 12, 45, 47, 516, DateTimeKind.Local).AddTicks(468), "https://solkaersvin.dk", new DateTime(2022, 6, 26, 17, 58, 34, 308, DateTimeKind.Local).AddTicks(7316), 96 },
                    { 27, new DateTime(2023, 2, 19, 15, 18, 7, 624, DateTimeKind.Local).AddTicks(6329), "https://solkaersvin.dk", new DateTime(2022, 10, 7, 18, 6, 9, 728, DateTimeKind.Local).AddTicks(2702), 95 },
                    { 28, new DateTime(2023, 3, 13, 11, 26, 10, 847, DateTimeKind.Local).AddTicks(45), "https://solkaersvin.dk", new DateTime(2022, 10, 15, 23, 33, 47, 742, DateTimeKind.Local).AddTicks(9174), 33 },
                    { 29, new DateTime(2022, 11, 15, 3, 44, 46, 496, DateTimeKind.Local).AddTicks(877), "https://solkaersvin.dk", new DateTime(2022, 11, 21, 6, 17, 26, 998, DateTimeKind.Local).AddTicks(5274), 37 },
                    { 30, new DateTime(2022, 8, 22, 14, 57, 46, 401, DateTimeKind.Local).AddTicks(33), "https://solkaersvin.dk", new DateTime(2022, 6, 4, 0, 11, 26, 173, DateTimeKind.Local).AddTicks(9614), 1 },
                    { 31, new DateTime(2022, 6, 26, 23, 7, 28, 160, DateTimeKind.Local).AddTicks(7404), "https://solkaersvin.dk", new DateTime(2023, 3, 3, 22, 28, 21, 566, DateTimeKind.Local).AddTicks(7486), 86 },
                    { 32, new DateTime(2022, 5, 16, 21, 8, 25, 205, DateTimeKind.Local).AddTicks(7984), "https://solkaersvin.dk", new DateTime(2023, 1, 12, 21, 16, 38, 937, DateTimeKind.Local).AddTicks(7014), 3 },
                    { 33, new DateTime(2022, 10, 13, 12, 19, 3, 620, DateTimeKind.Local).AddTicks(4668), "https://solkaersvin.dk", new DateTime(2022, 12, 16, 16, 43, 20, 59, DateTimeKind.Local).AddTicks(1917), 88 },
                    { 34, new DateTime(2023, 2, 18, 3, 7, 22, 380, DateTimeKind.Local).AddTicks(1199), "https://solkaersvin.dk", new DateTime(2022, 11, 20, 23, 48, 38, 257, DateTimeKind.Local).AddTicks(6261), 13 },
                    { 35, new DateTime(2022, 11, 21, 18, 59, 1, 387, DateTimeKind.Local).AddTicks(8001), "https://solkaersvin.dk", new DateTime(2022, 9, 13, 22, 28, 28, 759, DateTimeKind.Local).AddTicks(9137), 48 },
                    { 36, new DateTime(2023, 3, 11, 8, 56, 1, 404, DateTimeKind.Local).AddTicks(7866), "https://solkaersvin.dk", new DateTime(2023, 2, 3, 4, 38, 36, 595, DateTimeKind.Local).AddTicks(8554), 31 },
                    { 37, new DateTime(2022, 10, 27, 1, 43, 16, 21, DateTimeKind.Local).AddTicks(9759), "https://solkaersvin.dk", new DateTime(2022, 7, 4, 12, 31, 33, 954, DateTimeKind.Local).AddTicks(6429), 27 },
                    { 38, new DateTime(2023, 2, 14, 5, 7, 33, 677, DateTimeKind.Local).AddTicks(2827), "https://solkaersvin.dk", new DateTime(2022, 5, 29, 17, 0, 38, 178, DateTimeKind.Local).AddTicks(7720), 18 },
                    { 39, new DateTime(2022, 12, 10, 6, 18, 9, 952, DateTimeKind.Local).AddTicks(7186), "https://solkaersvin.dk", new DateTime(2022, 4, 11, 3, 39, 8, 244, DateTimeKind.Local).AddTicks(9036), 100 },
                    { 40, new DateTime(2022, 5, 28, 10, 39, 1, 940, DateTimeKind.Local).AddTicks(9335), "https://solkaersvin.dk", new DateTime(2022, 7, 24, 3, 5, 39, 757, DateTimeKind.Local).AddTicks(5880), 66 },
                    { 41, new DateTime(2022, 9, 19, 20, 27, 4, 599, DateTimeKind.Local).AddTicks(9882), "https://solkaersvin.dk", new DateTime(2022, 7, 28, 5, 40, 39, 102, DateTimeKind.Local).AddTicks(9285), 95 },
                    { 42, new DateTime(2023, 3, 29, 7, 12, 24, 497, DateTimeKind.Local).AddTicks(4114), "https://solkaersvin.dk", new DateTime(2023, 3, 28, 4, 11, 40, 389, DateTimeKind.Local).AddTicks(9411), 17 },
                    { 43, new DateTime(2023, 3, 9, 3, 10, 56, 210, DateTimeKind.Local).AddTicks(685), "https://solkaersvin.dk", new DateTime(2022, 12, 19, 12, 25, 17, 174, DateTimeKind.Local).AddTicks(7162), 14 },
                    { 44, new DateTime(2023, 3, 6, 1, 31, 11, 527, DateTimeKind.Local).AddTicks(8225), "https://solkaersvin.dk", new DateTime(2022, 5, 2, 9, 13, 1, 303, DateTimeKind.Local).AddTicks(1449), 21 },
                    { 45, new DateTime(2022, 6, 8, 3, 58, 0, 116, DateTimeKind.Local).AddTicks(4201), "https://solkaersvin.dk", new DateTime(2022, 4, 6, 20, 57, 2, 652, DateTimeKind.Local).AddTicks(788), 48 },
                    { 46, new DateTime(2022, 5, 31, 14, 27, 56, 872, DateTimeKind.Local).AddTicks(6421), "https://solkaersvin.dk", new DateTime(2022, 7, 26, 1, 13, 26, 866, DateTimeKind.Local).AddTicks(7711), 13 },
                    { 47, new DateTime(2023, 3, 16, 14, 3, 56, 924, DateTimeKind.Local).AddTicks(5887), "https://solkaersvin.dk", new DateTime(2022, 12, 10, 3, 35, 2, 498, DateTimeKind.Local).AddTicks(8687), 92 },
                    { 48, new DateTime(2022, 7, 7, 11, 38, 43, 82, DateTimeKind.Local).AddTicks(6525), "https://solkaersvin.dk", new DateTime(2023, 1, 29, 22, 0, 47, 786, DateTimeKind.Local).AddTicks(5960), 21 },
                    { 49, new DateTime(2022, 7, 30, 19, 54, 53, 9, DateTimeKind.Local).AddTicks(2644), "https://solkaersvin.dk", new DateTime(2022, 8, 16, 2, 46, 11, 891, DateTimeKind.Local).AddTicks(271), 9 },
                    { 50, new DateTime(2023, 3, 25, 6, 40, 47, 702, DateTimeKind.Local).AddTicks(5561), "https://solkaersvin.dk", new DateTime(2022, 9, 9, 23, 36, 32, 660, DateTimeKind.Local).AddTicks(6502), 24 },
                    { 51, new DateTime(2023, 1, 14, 10, 54, 58, 376, DateTimeKind.Local).AddTicks(8342), "https://solkaersvin.dk", new DateTime(2022, 8, 21, 10, 26, 19, 87, DateTimeKind.Local).AddTicks(1046), 25 },
                    { 52, new DateTime(2023, 1, 29, 10, 3, 45, 996, DateTimeKind.Local).AddTicks(3952), "https://solkaersvin.dk", new DateTime(2022, 9, 3, 15, 26, 35, 187, DateTimeKind.Local).AddTicks(7039), 61 },
                    { 53, new DateTime(2022, 12, 11, 20, 51, 34, 566, DateTimeKind.Local).AddTicks(357), "https://solkaersvin.dk", new DateTime(2022, 11, 28, 20, 32, 54, 297, DateTimeKind.Local).AddTicks(9617), 69 },
                    { 54, new DateTime(2023, 1, 31, 14, 51, 26, 23, DateTimeKind.Local).AddTicks(9284), "https://solkaersvin.dk", new DateTime(2022, 4, 7, 14, 31, 22, 602, DateTimeKind.Local).AddTicks(2922), 54 },
                    { 55, new DateTime(2023, 3, 14, 13, 36, 38, 63, DateTimeKind.Local).AddTicks(3979), "https://solkaersvin.dk", new DateTime(2022, 11, 26, 8, 58, 21, 901, DateTimeKind.Local).AddTicks(7284), 88 },
                    { 56, new DateTime(2022, 7, 23, 5, 44, 33, 201, DateTimeKind.Local).AddTicks(485), "https://solkaersvin.dk", new DateTime(2022, 12, 12, 9, 55, 50, 968, DateTimeKind.Local).AddTicks(4384), 83 },
                    { 57, new DateTime(2022, 5, 21, 1, 48, 53, 922, DateTimeKind.Local).AddTicks(1125), "https://solkaersvin.dk", new DateTime(2022, 10, 15, 0, 36, 30, 487, DateTimeKind.Local).AddTicks(6532), 86 },
                    { 58, new DateTime(2022, 7, 9, 14, 23, 11, 925, DateTimeKind.Local).AddTicks(9788), "https://solkaersvin.dk", new DateTime(2022, 6, 17, 5, 21, 22, 423, DateTimeKind.Local).AddTicks(9225), 30 },
                    { 59, new DateTime(2022, 7, 9, 13, 20, 10, 543, DateTimeKind.Local).AddTicks(5513), "https://solkaersvin.dk", new DateTime(2022, 6, 18, 17, 34, 38, 924, DateTimeKind.Local).AddTicks(9143), 39 },
                    { 60, new DateTime(2023, 3, 8, 0, 9, 44, 230, DateTimeKind.Local).AddTicks(3042), "https://solkaersvin.dk", new DateTime(2022, 12, 2, 20, 3, 48, 895, DateTimeKind.Local).AddTicks(7265), 51 },
                    { 61, new DateTime(2022, 5, 14, 4, 25, 45, 905, DateTimeKind.Local).AddTicks(8309), "https://solkaersvin.dk", new DateTime(2023, 3, 20, 5, 16, 25, 915, DateTimeKind.Local).AddTicks(928), 39 },
                    { 62, new DateTime(2022, 4, 19, 12, 50, 59, 421, DateTimeKind.Local).AddTicks(3676), "https://solkaersvin.dk", new DateTime(2022, 5, 25, 23, 22, 30, 558, DateTimeKind.Local).AddTicks(5697), 73 },
                    { 63, new DateTime(2022, 5, 21, 20, 23, 51, 355, DateTimeKind.Local).AddTicks(5119), "https://solkaersvin.dk", new DateTime(2022, 8, 13, 2, 40, 31, 527, DateTimeKind.Local).AddTicks(6072), 31 },
                    { 64, new DateTime(2022, 10, 27, 8, 55, 49, 723, DateTimeKind.Local).AddTicks(5232), "https://solkaersvin.dk", new DateTime(2022, 9, 23, 2, 22, 39, 714, DateTimeKind.Local).AddTicks(1896), 42 },
                    { 65, new DateTime(2022, 11, 18, 15, 34, 48, 20, DateTimeKind.Local).AddTicks(6119), "https://solkaersvin.dk", new DateTime(2022, 5, 19, 7, 58, 48, 308, DateTimeKind.Local).AddTicks(2476), 35 },
                    { 66, new DateTime(2022, 12, 6, 18, 11, 48, 389, DateTimeKind.Local).AddTicks(1143), "https://solkaersvin.dk", new DateTime(2022, 7, 29, 6, 48, 22, 426, DateTimeKind.Local).AddTicks(8429), 33 },
                    { 67, new DateTime(2023, 1, 1, 17, 7, 36, 975, DateTimeKind.Local).AddTicks(4031), "https://solkaersvin.dk", new DateTime(2022, 4, 12, 22, 56, 37, 215, DateTimeKind.Local).AddTicks(8052), 83 },
                    { 68, new DateTime(2022, 11, 16, 18, 10, 25, 268, DateTimeKind.Local).AddTicks(8669), "https://solkaersvin.dk", new DateTime(2023, 2, 7, 13, 38, 11, 188, DateTimeKind.Local).AddTicks(337), 33 },
                    { 69, new DateTime(2022, 4, 22, 23, 58, 6, 722, DateTimeKind.Local).AddTicks(2497), "https://solkaersvin.dk", new DateTime(2022, 10, 11, 5, 18, 3, 858, DateTimeKind.Local).AddTicks(4464), 10 },
                    { 70, new DateTime(2023, 1, 14, 22, 53, 20, 450, DateTimeKind.Local).AddTicks(4695), "https://solkaersvin.dk", new DateTime(2022, 10, 26, 5, 29, 52, 860, DateTimeKind.Local).AddTicks(4358), 83 },
                    { 71, new DateTime(2023, 1, 31, 19, 14, 25, 245, DateTimeKind.Local).AddTicks(9509), "https://solkaersvin.dk", new DateTime(2023, 1, 9, 5, 28, 7, 743, DateTimeKind.Local).AddTicks(3243), 79 },
                    { 72, new DateTime(2023, 2, 10, 1, 37, 37, 278, DateTimeKind.Local).AddTicks(6454), "https://solkaersvin.dk", new DateTime(2022, 12, 23, 19, 11, 57, 525, DateTimeKind.Local).AddTicks(6910), 2 },
                    { 73, new DateTime(2023, 2, 9, 12, 10, 52, 314, DateTimeKind.Local).AddTicks(6609), "https://solkaersvin.dk", new DateTime(2023, 2, 28, 9, 31, 56, 49, DateTimeKind.Local).AddTicks(6248), 95 },
                    { 74, new DateTime(2022, 9, 26, 13, 18, 7, 843, DateTimeKind.Local).AddTicks(464), "https://solkaersvin.dk", new DateTime(2022, 6, 6, 18, 6, 59, 253, DateTimeKind.Local).AddTicks(1319), 50 },
                    { 75, new DateTime(2022, 10, 24, 23, 19, 25, 469, DateTimeKind.Local).AddTicks(9078), "https://solkaersvin.dk", new DateTime(2022, 10, 28, 1, 39, 21, 606, DateTimeKind.Local).AddTicks(1855), 67 },
                    { 76, new DateTime(2022, 4, 25, 6, 31, 26, 216, DateTimeKind.Local).AddTicks(9133), "https://solkaersvin.dk", new DateTime(2022, 11, 24, 7, 34, 41, 312, DateTimeKind.Local).AddTicks(9671), 94 },
                    { 77, new DateTime(2023, 3, 15, 19, 13, 14, 769, DateTimeKind.Local).AddTicks(7341), "https://solkaersvin.dk", new DateTime(2022, 11, 6, 3, 54, 39, 562, DateTimeKind.Local).AddTicks(381), 93 },
                    { 78, new DateTime(2022, 7, 29, 3, 23, 42, 839, DateTimeKind.Local).AddTicks(571), "https://solkaersvin.dk", new DateTime(2022, 6, 9, 15, 48, 24, 662, DateTimeKind.Local).AddTicks(5032), 12 },
                    { 79, new DateTime(2023, 3, 13, 17, 21, 24, 983, DateTimeKind.Local).AddTicks(9183), "https://solkaersvin.dk", new DateTime(2022, 9, 30, 19, 1, 38, 44, DateTimeKind.Local).AddTicks(5671), 36 },
                    { 80, new DateTime(2022, 8, 18, 22, 34, 59, 748, DateTimeKind.Local).AddTicks(6630), "https://solkaersvin.dk", new DateTime(2023, 4, 1, 21, 39, 10, 106, DateTimeKind.Local).AddTicks(7217), 89 },
                    { 81, new DateTime(2022, 10, 11, 2, 28, 2, 960, DateTimeKind.Local).AddTicks(4530), "https://solkaersvin.dk", new DateTime(2022, 8, 10, 6, 16, 48, 312, DateTimeKind.Local).AddTicks(6471), 38 },
                    { 82, new DateTime(2022, 8, 21, 16, 24, 48, 609, DateTimeKind.Local).AddTicks(1811), "https://solkaersvin.dk", new DateTime(2022, 12, 29, 22, 27, 41, 885, DateTimeKind.Local).AddTicks(1779), 21 },
                    { 83, new DateTime(2022, 12, 4, 12, 57, 44, 574, DateTimeKind.Local).AddTicks(1710), "https://solkaersvin.dk", new DateTime(2023, 1, 11, 22, 43, 28, 149, DateTimeKind.Local).AddTicks(5699), 30 },
                    { 84, new DateTime(2022, 11, 19, 12, 35, 0, 616, DateTimeKind.Local).AddTicks(9748), "https://solkaersvin.dk", new DateTime(2023, 1, 30, 14, 47, 13, 482, DateTimeKind.Local).AddTicks(574), 60 },
                    { 85, new DateTime(2022, 12, 6, 12, 12, 51, 949, DateTimeKind.Local).AddTicks(3075), "https://solkaersvin.dk", new DateTime(2022, 7, 11, 12, 35, 46, 539, DateTimeKind.Local).AddTicks(9616), 59 },
                    { 86, new DateTime(2022, 8, 8, 18, 21, 18, 889, DateTimeKind.Local).AddTicks(3572), "https://solkaersvin.dk", new DateTime(2022, 4, 28, 3, 37, 17, 206, DateTimeKind.Local).AddTicks(5649), 16 },
                    { 87, new DateTime(2023, 2, 7, 9, 32, 28, 807, DateTimeKind.Local).AddTicks(1339), "https://solkaersvin.dk", new DateTime(2023, 4, 3, 2, 12, 57, 912, DateTimeKind.Local).AddTicks(9432), 72 },
                    { 88, new DateTime(2022, 5, 11, 16, 28, 39, 955, DateTimeKind.Local).AddTicks(1054), "https://solkaersvin.dk", new DateTime(2023, 2, 4, 12, 26, 23, 88, DateTimeKind.Local).AddTicks(3432), 13 },
                    { 89, new DateTime(2022, 7, 31, 19, 51, 57, 172, DateTimeKind.Local).AddTicks(3172), "https://solkaersvin.dk", new DateTime(2022, 10, 9, 0, 36, 59, 814, DateTimeKind.Local).AddTicks(5024), 3 },
                    { 90, new DateTime(2022, 8, 10, 12, 8, 11, 129, DateTimeKind.Local).AddTicks(9137), "https://solkaersvin.dk", new DateTime(2023, 3, 4, 17, 2, 29, 702, DateTimeKind.Local).AddTicks(3367), 42 },
                    { 91, new DateTime(2023, 3, 14, 2, 22, 59, 367, DateTimeKind.Local).AddTicks(7412), "https://solkaersvin.dk", new DateTime(2022, 9, 26, 22, 22, 9, 973, DateTimeKind.Local).AddTicks(6085), 77 },
                    { 92, new DateTime(2023, 2, 22, 0, 17, 42, 50, DateTimeKind.Local).AddTicks(6372), "https://solkaersvin.dk", new DateTime(2023, 3, 21, 19, 36, 22, 290, DateTimeKind.Local).AddTicks(2048), 9 },
                    { 93, new DateTime(2022, 10, 17, 18, 50, 58, 181, DateTimeKind.Local).AddTicks(2623), "https://solkaersvin.dk", new DateTime(2022, 6, 8, 15, 40, 54, 268, DateTimeKind.Local).AddTicks(3390), 18 },
                    { 94, new DateTime(2022, 8, 13, 10, 5, 36, 210, DateTimeKind.Local).AddTicks(2016), "https://solkaersvin.dk", new DateTime(2022, 8, 25, 2, 19, 59, 50, DateTimeKind.Local).AddTicks(3554), 18 },
                    { 95, new DateTime(2022, 12, 8, 17, 22, 0, 740, DateTimeKind.Local).AddTicks(7290), "https://solkaersvin.dk", new DateTime(2022, 7, 30, 15, 24, 31, 560, DateTimeKind.Local).AddTicks(3734), 14 },
                    { 96, new DateTime(2022, 9, 25, 22, 16, 7, 528, DateTimeKind.Local).AddTicks(4650), "https://solkaersvin.dk", new DateTime(2022, 11, 25, 23, 57, 8, 297, DateTimeKind.Local).AddTicks(3644), 24 },
                    { 97, new DateTime(2023, 1, 19, 1, 3, 51, 124, DateTimeKind.Local).AddTicks(8607), "https://solkaersvin.dk", new DateTime(2022, 11, 8, 7, 46, 23, 502, DateTimeKind.Local).AddTicks(1767), 9 },
                    { 98, new DateTime(2023, 2, 2, 12, 25, 42, 552, DateTimeKind.Local).AddTicks(8241), "https://solkaersvin.dk", new DateTime(2022, 10, 14, 21, 48, 48, 349, DateTimeKind.Local).AddTicks(1456), 58 },
                    { 99, new DateTime(2023, 1, 1, 5, 7, 21, 562, DateTimeKind.Local).AddTicks(2580), "https://solkaersvin.dk", new DateTime(2022, 9, 4, 18, 45, 40, 412, DateTimeKind.Local).AddTicks(9650), 1 },
                    { 100, new DateTime(2023, 2, 1, 4, 21, 42, 776, DateTimeKind.Local).AddTicks(3888), "https://solkaersvin.dk", new DateTime(2022, 4, 26, 5, 19, 8, 844, DateTimeKind.Local).AddTicks(4823), 49 },
                    { 101, new DateTime(2022, 5, 18, 16, 1, 6, 297, DateTimeKind.Local).AddTicks(6602), "https://solkaersvin.dk", new DateTime(2022, 7, 30, 9, 35, 50, 851, DateTimeKind.Local).AddTicks(8764), 78 },
                    { 102, new DateTime(2022, 6, 6, 21, 22, 48, 709, DateTimeKind.Local).AddTicks(461), "https://solkaersvin.dk", new DateTime(2022, 12, 11, 18, 58, 18, 656, DateTimeKind.Local).AddTicks(8537), 15 },
                    { 103, new DateTime(2022, 10, 5, 18, 9, 57, 841, DateTimeKind.Local).AddTicks(9293), "https://solkaersvin.dk", new DateTime(2023, 1, 17, 20, 41, 27, 306, DateTimeKind.Local).AddTicks(2913), 66 },
                    { 104, new DateTime(2022, 4, 15, 1, 45, 44, 429, DateTimeKind.Local).AddTicks(8035), "https://solkaersvin.dk", new DateTime(2023, 1, 25, 8, 16, 38, 115, DateTimeKind.Local).AddTicks(7167), 70 },
                    { 105, new DateTime(2022, 9, 17, 17, 33, 27, 268, DateTimeKind.Local).AddTicks(4568), "https://solkaersvin.dk", new DateTime(2022, 9, 30, 8, 13, 10, 4, DateTimeKind.Local).AddTicks(5550), 12 },
                    { 106, new DateTime(2022, 4, 9, 21, 38, 26, 789, DateTimeKind.Local).AddTicks(6990), "https://solkaersvin.dk", new DateTime(2022, 9, 6, 7, 52, 56, 621, DateTimeKind.Local).AddTicks(9998), 40 },
                    { 107, new DateTime(2022, 6, 18, 21, 14, 4, 626, DateTimeKind.Local).AddTicks(349), "https://solkaersvin.dk", new DateTime(2023, 2, 8, 6, 22, 7, 51, DateTimeKind.Local).AddTicks(4763), 49 },
                    { 108, new DateTime(2022, 12, 6, 19, 13, 22, 365, DateTimeKind.Local).AddTicks(8981), "https://solkaersvin.dk", new DateTime(2022, 10, 25, 19, 50, 37, 412, DateTimeKind.Local).AddTicks(6780), 14 },
                    { 109, new DateTime(2023, 1, 23, 17, 32, 16, 50, DateTimeKind.Local).AddTicks(7414), "https://solkaersvin.dk", new DateTime(2022, 5, 14, 22, 43, 34, 222, DateTimeKind.Local).AddTicks(5429), 69 },
                    { 110, new DateTime(2023, 3, 5, 1, 12, 51, 156, DateTimeKind.Local).AddTicks(7451), "https://solkaersvin.dk", new DateTime(2022, 5, 27, 3, 56, 37, 896, DateTimeKind.Local).AddTicks(59), 5 },
                    { 111, new DateTime(2022, 7, 28, 2, 46, 3, 123, DateTimeKind.Local).AddTicks(8022), "https://solkaersvin.dk", new DateTime(2022, 12, 19, 23, 15, 32, 812, DateTimeKind.Local).AddTicks(5012), 46 },
                    { 112, new DateTime(2022, 11, 11, 14, 7, 15, 57, DateTimeKind.Local).AddTicks(9544), "https://solkaersvin.dk", new DateTime(2022, 7, 1, 2, 50, 47, 320, DateTimeKind.Local).AddTicks(1698), 89 },
                    { 113, new DateTime(2022, 4, 8, 11, 56, 32, 123, DateTimeKind.Local).AddTicks(7872), "https://solkaersvin.dk", new DateTime(2022, 10, 7, 4, 45, 29, 439, DateTimeKind.Local).AddTicks(3124), 93 },
                    { 114, new DateTime(2022, 9, 6, 5, 28, 39, 979, DateTimeKind.Local).AddTicks(1557), "https://solkaersvin.dk", new DateTime(2023, 3, 26, 12, 52, 27, 94, DateTimeKind.Local).AddTicks(1661), 37 },
                    { 115, new DateTime(2022, 11, 12, 18, 59, 31, 280, DateTimeKind.Local).AddTicks(4096), "https://solkaersvin.dk", new DateTime(2023, 1, 9, 8, 4, 24, 102, DateTimeKind.Local).AddTicks(6885), 15 },
                    { 116, new DateTime(2022, 10, 19, 12, 14, 15, 307, DateTimeKind.Local).AddTicks(4019), "https://solkaersvin.dk", new DateTime(2022, 8, 21, 3, 38, 32, 691, DateTimeKind.Local).AddTicks(9994), 22 },
                    { 117, new DateTime(2022, 8, 26, 4, 19, 30, 738, DateTimeKind.Local).AddTicks(8174), "https://solkaersvin.dk", new DateTime(2022, 12, 27, 16, 15, 12, 180, DateTimeKind.Local).AddTicks(1918), 97 },
                    { 118, new DateTime(2023, 4, 3, 5, 34, 51, 103, DateTimeKind.Local).AddTicks(9618), "https://solkaersvin.dk", new DateTime(2022, 11, 18, 15, 53, 55, 557, DateTimeKind.Local).AddTicks(9876), 1 },
                    { 119, new DateTime(2022, 8, 13, 5, 57, 7, 961, DateTimeKind.Local).AddTicks(1690), "https://solkaersvin.dk", new DateTime(2022, 9, 15, 5, 34, 1, 339, DateTimeKind.Local).AddTicks(3999), 79 },
                    { 120, new DateTime(2022, 10, 19, 5, 11, 9, 654, DateTimeKind.Local).AddTicks(7056), "https://solkaersvin.dk", new DateTime(2022, 8, 17, 12, 36, 50, 65, DateTimeKind.Local).AddTicks(9433), 24 },
                    { 121, new DateTime(2022, 8, 27, 0, 37, 59, 291, DateTimeKind.Local).AddTicks(6196), "https://solkaersvin.dk", new DateTime(2022, 11, 6, 1, 43, 24, 92, DateTimeKind.Local).AddTicks(8237), 43 },
                    { 122, new DateTime(2023, 1, 9, 0, 54, 59, 780, DateTimeKind.Local).AddTicks(1513), "https://solkaersvin.dk", new DateTime(2022, 12, 22, 7, 45, 58, 713, DateTimeKind.Local).AddTicks(6416), 36 },
                    { 123, new DateTime(2023, 1, 10, 10, 20, 54, 922, DateTimeKind.Local).AddTicks(44), "https://solkaersvin.dk", new DateTime(2023, 2, 9, 12, 12, 29, 618, DateTimeKind.Local).AddTicks(1436), 91 },
                    { 124, new DateTime(2022, 10, 17, 15, 55, 8, 71, DateTimeKind.Local).AddTicks(7447), "https://solkaersvin.dk", new DateTime(2022, 4, 6, 18, 28, 12, 73, DateTimeKind.Local).AddTicks(5541), 76 },
                    { 125, new DateTime(2023, 2, 22, 9, 21, 56, 32, DateTimeKind.Local).AddTicks(869), "https://solkaersvin.dk", new DateTime(2023, 1, 16, 0, 31, 42, 54, DateTimeKind.Local).AddTicks(5223), 9 },
                    { 126, new DateTime(2022, 4, 10, 6, 10, 27, 933, DateTimeKind.Local).AddTicks(7025), "https://solkaersvin.dk", new DateTime(2022, 4, 29, 9, 0, 8, 493, DateTimeKind.Local).AddTicks(1324), 13 },
                    { 127, new DateTime(2022, 10, 16, 18, 32, 38, 221, DateTimeKind.Local).AddTicks(3385), "https://solkaersvin.dk", new DateTime(2022, 7, 10, 14, 4, 18, 150, DateTimeKind.Local).AddTicks(9844), 21 },
                    { 128, new DateTime(2023, 3, 3, 19, 44, 0, 687, DateTimeKind.Local).AddTicks(5115), "https://solkaersvin.dk", new DateTime(2022, 10, 13, 5, 39, 37, 825, DateTimeKind.Local).AddTicks(5732), 27 },
                    { 129, new DateTime(2022, 10, 21, 22, 44, 15, 493, DateTimeKind.Local).AddTicks(9146), "https://solkaersvin.dk", new DateTime(2022, 7, 30, 5, 57, 29, 427, DateTimeKind.Local).AddTicks(4870), 59 },
                    { 130, new DateTime(2023, 3, 2, 20, 11, 1, 38, DateTimeKind.Local).AddTicks(4918), "https://solkaersvin.dk", new DateTime(2022, 7, 4, 16, 56, 24, 504, DateTimeKind.Local).AddTicks(4358), 92 },
                    { 131, new DateTime(2022, 7, 27, 11, 45, 12, 166, DateTimeKind.Local).AddTicks(9225), "https://solkaersvin.dk", new DateTime(2022, 9, 23, 15, 31, 39, 876, DateTimeKind.Local).AddTicks(7330), 21 },
                    { 132, new DateTime(2022, 4, 25, 8, 57, 45, 876, DateTimeKind.Local).AddTicks(8519), "https://solkaersvin.dk", new DateTime(2022, 4, 15, 13, 36, 58, 95, DateTimeKind.Local).AddTicks(1884), 87 },
                    { 133, new DateTime(2022, 6, 20, 19, 17, 8, 988, DateTimeKind.Local).AddTicks(4317), "https://solkaersvin.dk", new DateTime(2023, 2, 7, 2, 50, 48, 907, DateTimeKind.Local).AddTicks(9116), 62 },
                    { 134, new DateTime(2022, 12, 11, 23, 14, 57, 490, DateTimeKind.Local).AddTicks(8893), "https://solkaersvin.dk", new DateTime(2023, 1, 12, 10, 39, 37, 793, DateTimeKind.Local).AddTicks(517), 96 },
                    { 135, new DateTime(2023, 1, 18, 16, 59, 33, 67, DateTimeKind.Local).AddTicks(8511), "https://solkaersvin.dk", new DateTime(2023, 2, 11, 21, 10, 40, 74, DateTimeKind.Local).AddTicks(7280), 48 },
                    { 136, new DateTime(2022, 5, 4, 16, 31, 34, 15, DateTimeKind.Local).AddTicks(9244), "https://solkaersvin.dk", new DateTime(2022, 5, 15, 4, 59, 12, 479, DateTimeKind.Local).AddTicks(5309), 28 },
                    { 137, new DateTime(2022, 8, 6, 14, 13, 39, 243, DateTimeKind.Local).AddTicks(3429), "https://solkaersvin.dk", new DateTime(2022, 8, 8, 8, 32, 57, 435, DateTimeKind.Local).AddTicks(1204), 16 },
                    { 138, new DateTime(2023, 3, 24, 10, 45, 17, 536, DateTimeKind.Local).AddTicks(8570), "https://solkaersvin.dk", new DateTime(2022, 4, 7, 19, 24, 48, 841, DateTimeKind.Local).AddTicks(218), 62 },
                    { 139, new DateTime(2023, 2, 8, 9, 56, 0, 311, DateTimeKind.Local).AddTicks(4161), "https://solkaersvin.dk", new DateTime(2022, 9, 28, 13, 40, 16, 11, DateTimeKind.Local).AddTicks(7634), 90 },
                    { 140, new DateTime(2022, 6, 29, 13, 49, 41, 102, DateTimeKind.Local).AddTicks(1211), "https://solkaersvin.dk", new DateTime(2022, 6, 23, 10, 57, 1, 693, DateTimeKind.Local).AddTicks(8929), 94 },
                    { 141, new DateTime(2022, 4, 10, 10, 25, 45, 456, DateTimeKind.Local).AddTicks(3527), "https://solkaersvin.dk", new DateTime(2023, 2, 12, 22, 56, 11, 291, DateTimeKind.Local).AddTicks(1698), 61 },
                    { 142, new DateTime(2022, 9, 19, 16, 51, 54, 111, DateTimeKind.Local).AddTicks(2637), "https://solkaersvin.dk", new DateTime(2022, 6, 26, 12, 56, 13, 312, DateTimeKind.Local).AddTicks(4799), 40 },
                    { 143, new DateTime(2023, 1, 13, 19, 45, 5, 216, DateTimeKind.Local).AddTicks(9675), "https://solkaersvin.dk", new DateTime(2023, 2, 2, 9, 10, 27, 562, DateTimeKind.Local).AddTicks(8937), 47 },
                    { 144, new DateTime(2022, 9, 30, 15, 6, 54, 363, DateTimeKind.Local).AddTicks(6181), "https://solkaersvin.dk", new DateTime(2023, 1, 23, 19, 39, 36, 352, DateTimeKind.Local).AddTicks(9304), 25 },
                    { 145, new DateTime(2023, 1, 1, 20, 14, 5, 328, DateTimeKind.Local).AddTicks(5937), "https://solkaersvin.dk", new DateTime(2023, 2, 8, 4, 3, 58, 138, DateTimeKind.Local).AddTicks(1098), 78 },
                    { 146, new DateTime(2022, 6, 18, 12, 25, 15, 864, DateTimeKind.Local).AddTicks(3395), "https://solkaersvin.dk", new DateTime(2022, 5, 19, 11, 30, 45, 27, DateTimeKind.Local).AddTicks(3219), 51 },
                    { 147, new DateTime(2022, 12, 11, 22, 40, 43, 16, DateTimeKind.Local).AddTicks(8288), "https://solkaersvin.dk", new DateTime(2022, 9, 22, 14, 58, 58, 885, DateTimeKind.Local).AddTicks(6526), 34 },
                    { 148, new DateTime(2022, 7, 4, 0, 45, 41, 158, DateTimeKind.Local).AddTicks(7017), "https://solkaersvin.dk", new DateTime(2022, 10, 30, 14, 43, 39, 202, DateTimeKind.Local).AddTicks(8121), 80 },
                    { 149, new DateTime(2022, 9, 2, 9, 29, 10, 542, DateTimeKind.Local).AddTicks(1632), "https://solkaersvin.dk", new DateTime(2022, 8, 8, 9, 46, 12, 37, DateTimeKind.Local).AddTicks(7296), 10 },
                    { 150, new DateTime(2022, 4, 18, 2, 22, 24, 866, DateTimeKind.Local).AddTicks(718), "https://solkaersvin.dk", new DateTime(2022, 6, 20, 7, 48, 2, 973, DateTimeKind.Local).AddTicks(1008), 54 }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 16, 21, 45, 28, 610, DateTimeKind.Local).AddTicks(2481), new DateTime(2022, 6, 27, 17, 31, 9, 818, DateTimeKind.Local).AddTicks(6227), 25, 19.7528387233579m },
                    { 2, 65, new DateTime(2022, 11, 27, 2, 59, 51, 841, DateTimeKind.Local).AddTicks(8131), new DateTime(2022, 4, 25, 20, 32, 16, 670, DateTimeKind.Local).AddTicks(8167), 66, 19.7580705487989m },
                    { 3, 97, new DateTime(2023, 3, 25, 21, 54, 46, 885, DateTimeKind.Local).AddTicks(481), new DateTime(2023, 1, 4, 20, 2, 10, 277, DateTimeKind.Local).AddTicks(3563), 11, 29.513802848346m },
                    { 4, 149, new DateTime(2022, 7, 30, 9, 22, 22, 734, DateTimeKind.Local).AddTicks(2377), new DateTime(2022, 8, 9, 7, 57, 13, 5, DateTimeKind.Local).AddTicks(5640), 33, 6.32935092610675m },
                    { 5, 93, new DateTime(2022, 7, 22, 7, 31, 40, 985, DateTimeKind.Local).AddTicks(1474), new DateTime(2022, 7, 23, 5, 1, 57, 454, DateTimeKind.Local).AddTicks(4299), 29, 2.81276381233292m },
                    { 6, 15, new DateTime(2023, 2, 5, 15, 13, 28, 402, DateTimeKind.Local).AddTicks(1249), new DateTime(2022, 11, 16, 22, 42, 17, 504, DateTimeKind.Local).AddTicks(1919), 95, 10.6522375254053m },
                    { 7, 26, new DateTime(2022, 6, 19, 15, 13, 37, 85, DateTimeKind.Local).AddTicks(3219), new DateTime(2022, 12, 14, 5, 27, 7, 565, DateTimeKind.Local).AddTicks(107), 80, 20.5626385469876m },
                    { 8, 133, new DateTime(2022, 9, 14, 7, 33, 47, 579, DateTimeKind.Local).AddTicks(1936), new DateTime(2022, 7, 17, 18, 10, 53, 755, DateTimeKind.Local).AddTicks(4154), 83, 25.7902808566784m },
                    { 9, 3, new DateTime(2022, 4, 8, 7, 56, 12, 832, DateTimeKind.Local).AddTicks(7314), new DateTime(2022, 6, 15, 1, 34, 9, 999, DateTimeKind.Local).AddTicks(6627), 70, 25.4513530932678m },
                    { 10, 10, new DateTime(2022, 9, 29, 14, 40, 55, 996, DateTimeKind.Local).AddTicks(8262), new DateTime(2022, 9, 25, 15, 30, 33, 419, DateTimeKind.Local).AddTicks(7447), 86, 13.7275400161014m },
                    { 11, 150, new DateTime(2022, 7, 27, 2, 41, 48, 176, DateTimeKind.Local).AddTicks(6488), new DateTime(2022, 11, 15, 6, 1, 11, 500, DateTimeKind.Local).AddTicks(9422), 28, 15.1984402034339m },
                    { 12, 102, new DateTime(2022, 8, 1, 2, 54, 28, 949, DateTimeKind.Local).AddTicks(6311), new DateTime(2022, 10, 14, 18, 23, 21, 419, DateTimeKind.Local).AddTicks(7212), 44, 11.909011157623m },
                    { 13, 54, new DateTime(2022, 9, 25, 6, 47, 53, 958, DateTimeKind.Local).AddTicks(7726), new DateTime(2023, 2, 2, 12, 35, 18, 490, DateTimeKind.Local).AddTicks(6614), 25, 22.6960630168862m },
                    { 14, 104, new DateTime(2022, 11, 12, 3, 19, 4, 616, DateTimeKind.Local).AddTicks(1062), new DateTime(2023, 2, 7, 16, 31, 4, 66, DateTimeKind.Local).AddTicks(3267), 35, 11.2431628710101m },
                    { 15, 13, new DateTime(2022, 4, 14, 23, 32, 28, 399, DateTimeKind.Local).AddTicks(409), new DateTime(2022, 10, 9, 5, 26, 17, 716, DateTimeKind.Local).AddTicks(6521), 95, 6.07960981146377m },
                    { 16, 8, new DateTime(2023, 2, 20, 6, 16, 1, 247, DateTimeKind.Local).AddTicks(5244), new DateTime(2023, 1, 16, 23, 9, 1, 963, DateTimeKind.Local).AddTicks(7413), 64, 7.56787441699534m },
                    { 17, 47, new DateTime(2022, 9, 17, 1, 52, 3, 640, DateTimeKind.Local).AddTicks(6844), new DateTime(2022, 12, 14, 11, 52, 8, 99, DateTimeKind.Local).AddTicks(5653), 9, 14.6900963069872m },
                    { 18, 132, new DateTime(2022, 6, 18, 18, 32, 51, 146, DateTimeKind.Local).AddTicks(3141), new DateTime(2023, 1, 14, 23, 35, 33, 456, DateTimeKind.Local).AddTicks(1780), 100, 20.6421357994295m },
                    { 19, 27, new DateTime(2022, 10, 30, 18, 58, 51, 647, DateTimeKind.Local).AddTicks(4875), new DateTime(2022, 4, 21, 10, 22, 6, 1, DateTimeKind.Local).AddTicks(6886), 11, 3.73922454463786m },
                    { 20, 117, new DateTime(2022, 4, 24, 11, 28, 12, 247, DateTimeKind.Local).AddTicks(863), new DateTime(2023, 2, 19, 15, 18, 7, 627, DateTimeKind.Local).AddTicks(8284), 41, 5.51736552640338m },
                    { 21, 49, new DateTime(2023, 3, 13, 11, 26, 10, 850, DateTimeKind.Local).AddTicks(1999), new DateTime(2022, 10, 15, 23, 33, 47, 746, DateTimeKind.Local).AddTicks(1128), 50, 26.9085271934438m },
                    { 22, 59, new DateTime(2022, 11, 21, 6, 17, 27, 1, DateTimeKind.Local).AddTicks(7228), new DateTime(2023, 4, 2, 14, 11, 16, 448, DateTimeKind.Local).AddTicks(2577), 37, 28.976600716365m },
                    { 23, 126, new DateTime(2022, 5, 27, 18, 8, 23, 55, DateTimeKind.Local).AddTicks(4689), new DateTime(2022, 6, 26, 23, 7, 28, 163, DateTimeKind.Local).AddTicks(9358), 62, 3.80206195618489m },
                    { 24, 4, new DateTime(2022, 5, 16, 21, 8, 25, 208, DateTimeKind.Local).AddTicks(9937), new DateTime(2023, 1, 12, 21, 16, 38, 940, DateTimeKind.Local).AddTicks(8968), 9, 3.96788418708033m },
                    { 25, 72, new DateTime(2022, 12, 16, 16, 43, 20, 62, DateTimeKind.Local).AddTicks(3871), new DateTime(2023, 2, 19, 16, 16, 29, 538, DateTimeKind.Local).AddTicks(2313), 88, 24.2252164778906m },
                    { 26, 56, new DateTime(2022, 10, 13, 23, 54, 53, 611, DateTimeKind.Local).AddTicks(2703), new DateTime(2022, 11, 21, 18, 59, 1, 390, DateTimeKind.Local).AddTicks(9952), 13, 10.9433322766705m },
                    { 27, 46, new DateTime(2023, 3, 11, 8, 56, 1, 407, DateTimeKind.Local).AddTicks(9818), new DateTime(2023, 2, 3, 4, 38, 36, 599, DateTimeKind.Local).AddTicks(506), 56, 12.4813177327032m },
                    { 28, 66, new DateTime(2022, 7, 4, 12, 31, 33, 957, DateTimeKind.Local).AddTicks(8380), new DateTime(2023, 1, 31, 6, 59, 47, 453, DateTimeKind.Local).AddTicks(7731), 27, 11.0331726692693m },
                    { 29, 128, new DateTime(2022, 4, 6, 20, 6, 25, 395, DateTimeKind.Local).AddTicks(9414), new DateTime(2022, 12, 10, 6, 18, 9, 955, DateTimeKind.Local).AddTicks(9138), 14, 14.9018431883248m },
                    { 30, 98, new DateTime(2022, 5, 28, 10, 39, 1, 944, DateTimeKind.Local).AddTicks(1288), new DateTime(2022, 7, 24, 3, 5, 39, 760, DateTimeKind.Local).AddTicks(7832), 99, 25.6706061191976m },
                    { 31, 82, new DateTime(2022, 7, 28, 5, 40, 39, 106, DateTimeKind.Local).AddTicks(1237), new DateTime(2023, 2, 5, 11, 49, 36, 452, DateTimeKind.Local).AddTicks(8073), 95, 5.3207898319005m },
                    { 32, 4, new DateTime(2023, 2, 16, 9, 53, 29, 296, DateTimeKind.Local).AddTicks(9921), new DateTime(2023, 3, 9, 3, 10, 56, 213, DateTimeKind.Local).AddTicks(2634), 2, 22.1079397799858m },
                    { 33, 31, new DateTime(2023, 3, 6, 1, 31, 11, 531, DateTimeKind.Local).AddTicks(174), new DateTime(2022, 5, 2, 9, 13, 1, 306, DateTimeKind.Local).AddTicks(3398), 30, 1.5918091295199m },
                    { 34, 124, new DateTime(2022, 4, 6, 20, 57, 2, 655, DateTimeKind.Local).AddTicks(2736), new DateTime(2023, 2, 20, 3, 3, 48, 881, DateTimeKind.Local).AddTicks(4049), 48, 24.6652081156416m },
                    { 35, 105, new DateTime(2022, 5, 7, 9, 51, 36, 393, DateTimeKind.Local).AddTicks(7655), new DateTime(2023, 3, 16, 14, 3, 56, 927, DateTimeKind.Local).AddTicks(7834), 85, 23.3735645614097m },
                    { 36, 31, new DateTime(2022, 7, 7, 11, 38, 43, 85, DateTimeKind.Local).AddTicks(8474), new DateTime(2023, 1, 29, 22, 0, 47, 789, DateTimeKind.Local).AddTicks(7908), 32, 20.3568592027715m },
                    { 37, 103, new DateTime(2022, 8, 16, 2, 46, 11, 894, DateTimeKind.Local).AddTicks(2219), new DateTime(2023, 1, 8, 14, 14, 0, 798, DateTimeKind.Local).AddTicks(7411), 9, 27.7841194844987m },
                    { 38, 86, new DateTime(2023, 1, 7, 2, 23, 48, 103, DateTimeKind.Local).AddTicks(5630), new DateTime(2023, 1, 14, 10, 54, 58, 380, DateTimeKind.Local).AddTicks(287), 4, 12.4869726257281m },
                    { 39, 91, new DateTime(2023, 1, 29, 10, 3, 45, 999, DateTimeKind.Local).AddTicks(5896), new DateTime(2022, 9, 3, 15, 26, 35, 190, DateTimeKind.Local).AddTicks(8983), 63, 18.1168978312394m },
                    { 40, 48, new DateTime(2022, 11, 28, 20, 32, 54, 301, DateTimeKind.Local).AddTicks(1561), new DateTime(2022, 9, 22, 3, 3, 5, 780, DateTimeKind.Local).AddTicks(7401), 69, 17.3739100716464m },
                    { 41, 150, new DateTime(2022, 5, 21, 0, 59, 36, 831, DateTimeKind.Local).AddTicks(9077), new DateTime(2023, 3, 14, 13, 36, 38, 66, DateTimeKind.Local).AddTicks(5920), 18, 19.3636312772779m },
                    { 42, 125, new DateTime(2022, 7, 23, 5, 44, 33, 204, DateTimeKind.Local).AddTicks(2426), new DateTime(2022, 12, 12, 9, 55, 50, 971, DateTimeKind.Local).AddTicks(6325), 36, 18.0900497584299m },
                    { 43, 132, new DateTime(2022, 10, 15, 0, 36, 30, 490, DateTimeKind.Local).AddTicks(8472), new DateTime(2022, 12, 20, 11, 11, 58, 788, DateTimeKind.Local).AddTicks(9034), 86, 15.7629742851296m },
                    { 44, 121, new DateTime(2022, 11, 17, 8, 16, 54, 669, DateTimeKind.Local).AddTicks(4912), new DateTime(2022, 7, 9, 13, 20, 10, 546, DateTimeKind.Local).AddTicks(7450), 74, 1.69942224556351m },
                    { 45, 77, new DateTime(2023, 3, 8, 0, 9, 44, 233, DateTimeKind.Local).AddTicks(4978), new DateTime(2022, 12, 2, 20, 3, 48, 898, DateTimeKind.Local).AddTicks(9201), 80, 1.0365229841651m },
                    { 46, 135, new DateTime(2023, 3, 20, 5, 16, 25, 918, DateTimeKind.Local).AddTicks(2864), new DateTime(2022, 7, 14, 21, 35, 1, 924, DateTimeKind.Local).AddTicks(8404), 39, 17.2065014172946m },
                    { 47, 130, new DateTime(2022, 12, 15, 7, 32, 59, 626, DateTimeKind.Local).AddTicks(8154), new DateTime(2022, 5, 21, 20, 23, 51, 358, DateTimeKind.Local).AddTicks(7053), 97, 22.4152645268845m },
                    { 48, 62, new DateTime(2022, 10, 27, 8, 55, 49, 726, DateTimeKind.Local).AddTicks(7196), new DateTime(2022, 9, 23, 2, 22, 39, 717, DateTimeKind.Local).AddTicks(3861), 65, 17.2017241048354m },
                    { 49, 57, new DateTime(2022, 5, 19, 7, 58, 48, 311, DateTimeKind.Local).AddTicks(4409), new DateTime(2022, 12, 7, 21, 49, 57, 307, DateTimeKind.Local).AddTicks(3573), 35, 29.442622723741m },
                    { 50, 103, new DateTime(2022, 6, 8, 21, 48, 43, 295, DateTimeKind.Local).AddTicks(6493), new DateTime(2023, 1, 1, 17, 7, 36, 978, DateTimeKind.Local).AddTicks(5960), 33, 28.2722691315729m },
                    { 51, 49, new DateTime(2022, 11, 16, 18, 10, 25, 272, DateTimeKind.Local).AddTicks(598), new DateTime(2023, 2, 7, 13, 38, 11, 191, DateTimeKind.Local).AddTicks(2266), 98, 13.6720141674817m },
                    { 52, 143, new DateTime(2022, 10, 11, 5, 18, 3, 861, DateTimeKind.Local).AddTicks(6393), new DateTime(2022, 6, 9, 13, 51, 14, 73, DateTimeKind.Local).AddTicks(9662), 10, 1.61325315097025m },
                    { 53, 67, new DateTime(2022, 6, 21, 6, 38, 13, 673, DateTimeKind.Local).AddTicks(5745), new DateTime(2023, 1, 31, 19, 14, 25, 249, DateTimeKind.Local).AddTicks(1436), 23, 9.80924099732451m },
                    { 54, 2, new DateTime(2023, 2, 10, 1, 37, 37, 281, DateTimeKind.Local).AddTicks(8380), new DateTime(2022, 12, 23, 19, 11, 57, 528, DateTimeKind.Local).AddTicks(8837), 24, 9.07350800326054m },
                    { 55, 23, new DateTime(2023, 2, 28, 9, 31, 56, 52, DateTimeKind.Local).AddTicks(8174), new DateTime(2022, 10, 6, 18, 22, 8, 753, DateTimeKind.Local).AddTicks(9459), 95, 20.7598672958728m },
                    { 56, 125, new DateTime(2022, 8, 4, 16, 1, 36, 851, DateTimeKind.Local).AddTicks(6193), new DateTime(2022, 10, 24, 23, 19, 25, 473, DateTimeKind.Local).AddTicks(1003), 53, 2.00875873825301m },
                    { 57, 141, new DateTime(2022, 4, 25, 6, 31, 26, 220, DateTimeKind.Local).AddTicks(1057), new DateTime(2022, 11, 24, 7, 34, 41, 316, DateTimeKind.Local).AddTicks(1594), 44, 12.7838789232357m },
                    { 58, 9, new DateTime(2022, 11, 6, 3, 54, 39, 565, DateTimeKind.Local).AddTicks(2304), new DateTime(2023, 2, 23, 19, 32, 33, 908, DateTimeKind.Local).AddTicks(8652), 93, 9.1437765617846m },
                    { 59, 124, new DateTime(2022, 11, 25, 5, 53, 29, 90, DateTimeKind.Local).AddTicks(7160), new DateTime(2023, 3, 13, 17, 21, 24, 987, DateTimeKind.Local).AddTicks(1103), 69, 7.07148974325216m },
                    { 60, 134, new DateTime(2022, 8, 18, 22, 34, 59, 751, DateTimeKind.Local).AddTicks(8550), new DateTime(2023, 4, 1, 21, 39, 10, 109, DateTimeKind.Local).AddTicks(9136), 52, 27.9254098518099m },
                    { 61, 73, new DateTime(2022, 8, 10, 6, 16, 48, 315, DateTimeKind.Local).AddTicks(8389), new DateTime(2023, 1, 21, 5, 56, 56, 77, DateTimeKind.Local).AddTicks(9682), 38, 13.4208363052262m },
                    { 62, 40, new DateTime(2022, 12, 18, 5, 40, 49, 381, DateTimeKind.Local).AddTicks(6630), new DateTime(2022, 12, 4, 12, 57, 44, 577, DateTimeKind.Local).AddTicks(3626), 63, 8.45737511583233m },
                    { 63, 90, new DateTime(2022, 11, 19, 12, 35, 0, 620, DateTimeKind.Local).AddTicks(1664), new DateTime(2023, 1, 30, 14, 47, 13, 485, DateTimeKind.Local).AddTicks(2490), 23, 26.3875439307829m },
                    { 64, 50, new DateTime(2022, 7, 11, 12, 35, 46, 543, DateTimeKind.Local).AddTicks(1531), new DateTime(2023, 2, 9, 13, 35, 55, 373, DateTimeKind.Local).AddTicks(4699), 59, 14.0450667430347m },
                    { 65, 141, new DateTime(2022, 7, 16, 20, 45, 6, 992, DateTimeKind.Local).AddTicks(6459), new DateTime(2023, 2, 7, 9, 32, 28, 810, DateTimeKind.Local).AddTicks(3252), 66, 3.57535757432621m },
                    { 66, 19, new DateTime(2022, 5, 11, 16, 28, 39, 958, DateTimeKind.Local).AddTicks(2966), new DateTime(2023, 2, 4, 12, 26, 23, 91, DateTimeKind.Local).AddTicks(5343), 1, 3.49832625572924m },
                    { 67, 102, new DateTime(2022, 10, 9, 0, 36, 59, 817, DateTimeKind.Local).AddTicks(6935), new DateTime(2022, 11, 4, 22, 26, 0, 491, DateTimeKind.Local).AddTicks(6211), 3, 14.0246341813582m },
                    { 68, 14, new DateTime(2022, 6, 28, 8, 56, 36, 891, DateTimeKind.Local).AddTicks(9248), new DateTime(2023, 3, 14, 2, 22, 59, 370, DateTimeKind.Local).AddTicks(9321), 66, 22.8802754466235m },
                    { 69, 14, new DateTime(2023, 2, 22, 0, 17, 42, 53, DateTimeKind.Local).AddTicks(8280), new DateTime(2023, 3, 21, 19, 36, 22, 293, DateTimeKind.Local).AddTicks(3956), 53, 24.0673265572233m },
                    { 70, 70, new DateTime(2022, 6, 8, 15, 40, 54, 271, DateTimeKind.Local).AddTicks(5297), new DateTime(2023, 2, 1, 11, 57, 57, 131, DateTimeKind.Local).AddTicks(8108), 18, 7.78259399788263m },
                    { 71, 92, new DateTime(2023, 2, 15, 17, 37, 30, 574, DateTimeKind.Local).AddTicks(2012), new DateTime(2022, 12, 8, 17, 22, 0, 743, DateTimeKind.Local).AddTicks(9196), 65, 24.824123514396m },
                    { 72, 36, new DateTime(2022, 9, 25, 22, 16, 7, 531, DateTimeKind.Local).AddTicks(6555), new DateTime(2022, 11, 25, 23, 57, 8, 300, DateTimeKind.Local).AddTicks(5550), 69, 10.9573512958118m },
                    { 73, 32, new DateTime(2022, 11, 8, 7, 46, 23, 505, DateTimeKind.Local).AddTicks(3671), new DateTime(2022, 9, 8, 0, 10, 38, 248, DateTimeKind.Local).AddTicks(8085), 9, 6.00649009699926m },
                    { 74, 71, new DateTime(2023, 4, 4, 4, 12, 29, 604, DateTimeKind.Local).AddTicks(5857), new DateTime(2023, 1, 1, 5, 7, 21, 565, DateTimeKind.Local).AddTicks(4482), 17, 21.0999091123846m },
                    { 75, 74, new DateTime(2023, 2, 1, 4, 21, 42, 779, DateTimeKind.Local).AddTicks(5789), new DateTime(2022, 4, 26, 5, 19, 8, 847, DateTimeKind.Local).AddTicks(6725), 59, 29.0768250621356m },
                    { 76, 133, new DateTime(2022, 7, 30, 9, 35, 50, 855, DateTimeKind.Local).AddTicks(665), new DateTime(2023, 2, 12, 14, 27, 15, 858, DateTimeKind.Local).AddTicks(427), 78, 14.7956476862401m },
                    { 77, 48, new DateTime(2022, 8, 9, 1, 11, 20, 919, DateTimeKind.Local).AddTicks(2594), new DateTime(2022, 10, 5, 18, 9, 57, 845, DateTimeKind.Local).AddTicks(1192), 83, 23.6510965348682m },
                    { 78, 105, new DateTime(2022, 4, 15, 1, 45, 44, 432, DateTimeKind.Local).AddTicks(9933), new DateTime(2023, 1, 25, 8, 16, 38, 118, DateTimeKind.Local).AddTicks(9066), 22, 29.0965958600368m },
                    { 79, 83, new DateTime(2022, 9, 30, 8, 13, 10, 7, DateTimeKind.Local).AddTicks(7448), new DateTime(2022, 11, 12, 8, 39, 16, 273, DateTimeKind.Local).AddTicks(4003), 12, 7.76407846448049m },
                    { 80, 87, new DateTime(2022, 10, 11, 5, 48, 8, 938, DateTimeKind.Local).AddTicks(7831), new DateTime(2022, 6, 18, 21, 14, 4, 629, DateTimeKind.Local).AddTicks(2244), 99, 12.8483239172626m },
                    { 81, 20, new DateTime(2022, 12, 6, 19, 13, 22, 369, DateTimeKind.Local).AddTicks(876), new DateTime(2022, 10, 25, 19, 50, 37, 415, DateTimeKind.Local).AddTicks(8675), 16, 10.9663715645144m },
                    { 82, 30, new DateTime(2022, 5, 14, 22, 43, 34, 225, DateTimeKind.Local).AddTicks(7323), new DateTime(2023, 3, 18, 9, 19, 39, 35, DateTimeKind.Local).AddTicks(2784), 69, 17.8780326720114m },
                    { 83, 129, new DateTime(2022, 10, 20, 9, 36, 59, 288, DateTimeKind.Local).AddTicks(561), new DateTime(2022, 7, 28, 2, 46, 3, 126, DateTimeKind.Local).AddTicks(9947), 9, 19.3392458062195m },
                    { 84, 133, new DateTime(2022, 11, 11, 14, 7, 15, 61, DateTimeKind.Local).AddTicks(1470), new DateTime(2022, 7, 1, 2, 50, 47, 323, DateTimeKind.Local).AddTicks(3625), 30, 25.5637838200747m },
                    { 85, 149, new DateTime(2022, 10, 7, 4, 45, 29, 442, DateTimeKind.Local).AddTicks(5050), new DateTime(2022, 11, 22, 5, 12, 30, 314, DateTimeKind.Local).AddTicks(3419), 93, 18.449623843057m },
                    { 86, 5, new DateTime(2023, 2, 11, 12, 1, 58, 401, DateTimeKind.Local).AddTicks(8963), new DateTime(2022, 11, 12, 18, 59, 31, 283, DateTimeKind.Local).AddTicks(6020), 58, 21.9191514009926m },
                    { 87, 33, new DateTime(2022, 10, 19, 12, 14, 15, 310, DateTimeKind.Local).AddTicks(5943), new DateTime(2022, 8, 21, 3, 38, 32, 695, DateTimeKind.Local).AddTicks(1918), 24, 8.83236906455881m },
                    { 88, 92, new DateTime(2022, 12, 27, 16, 15, 12, 183, DateTimeKind.Local).AddTicks(3843), new DateTime(2023, 4, 3, 19, 39, 1, 201, DateTimeKind.Local).AddTicks(7908), 97, 21.463560800829m },
                    { 89, 57, new DateTime(2022, 6, 21, 7, 43, 19, 203, DateTimeKind.Local).AddTicks(8322), new DateTime(2022, 8, 13, 5, 57, 7, 964, DateTimeKind.Local).AddTicks(3580), 1, 11.7177471443643m },
                    { 90, 36, new DateTime(2022, 10, 19, 5, 11, 9, 657, DateTimeKind.Local).AddTicks(8946), new DateTime(2022, 8, 17, 12, 36, 50, 69, DateTimeKind.Local).AddTicks(1322), 56, 17.3214447065985m },
                    { 91, 91, new DateTime(2022, 11, 6, 1, 43, 24, 96, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 11, 27, 1, 31, 6, 821, DateTimeKind.Local).AddTicks(1139), 43, 7.92202690970509m },
                    { 92, 43, new DateTime(2022, 5, 11, 17, 47, 22, 714, DateTimeKind.Local).AddTicks(449), new DateTime(2023, 1, 10, 10, 20, 54, 925, DateTimeKind.Local).AddTicks(1930), 24, 5.11558787563745m },
                    { 93, 113, new DateTime(2022, 10, 17, 15, 55, 8, 74, DateTimeKind.Local).AddTicks(9333), new DateTime(2022, 4, 6, 18, 28, 12, 76, DateTimeKind.Local).AddTicks(7426), 16, 15.470427201756m },
                    { 94, 18, new DateTime(2023, 1, 16, 0, 31, 42, 57, DateTimeKind.Local).AddTicks(7108), new DateTime(2023, 2, 18, 2, 15, 57, 368, DateTimeKind.Local).AddTicks(1420), 9, 16.9805046824081m },
                    { 95, 141, new DateTime(2023, 1, 19, 20, 32, 30, 720, DateTimeKind.Local).AddTicks(8222), new DateTime(2022, 10, 16, 18, 32, 38, 224, DateTimeKind.Local).AddTicks(5268), 99, 8.19466554390338m },
                    { 96, 41, new DateTime(2023, 3, 3, 19, 44, 0, 690, DateTimeKind.Local).AddTicks(6997), new DateTime(2022, 10, 13, 5, 39, 37, 828, DateTimeKind.Local).AddTicks(7615), 74, 6.50406908740653m },
                    { 97, 68, new DateTime(2022, 7, 30, 5, 57, 29, 430, DateTimeKind.Local).AddTicks(6752), new DateTime(2022, 5, 6, 16, 7, 54, 665, DateTimeKind.Local).AddTicks(3485), 59, 19.6585390934441m },
                    { 98, 113, new DateTime(2023, 1, 19, 6, 3, 3, 391, DateTimeKind.Local).AddTicks(6088), new DateTime(2022, 7, 27, 11, 45, 12, 170, DateTimeKind.Local).AddTicks(1106), 10, 6.61218039780834m },
                    { 99, 130, new DateTime(2022, 4, 25, 8, 57, 45, 880, DateTimeKind.Local).AddTicks(399), new DateTime(2022, 4, 15, 13, 36, 58, 98, DateTimeKind.Local).AddTicks(3763), 54, 12.9135228118002m },
                    { 100, 119, new DateTime(2023, 2, 7, 2, 50, 48, 911, DateTimeKind.Local).AddTicks(994), new DateTime(2022, 4, 23, 9, 4, 42, 799, DateTimeKind.Local).AddTicks(8882), 62, 24.0573769058728m },
                    { 101, 35, new DateTime(2022, 10, 15, 0, 12, 20, 484, DateTimeKind.Local).AddTicks(6980), new DateTime(2023, 1, 18, 16, 59, 33, 71, DateTimeKind.Local).AddTicks(387), 32, 2.02972133471692m },
                    { 102, 42, new DateTime(2022, 5, 4, 16, 31, 34, 19, DateTimeKind.Local).AddTicks(1120), new DateTime(2022, 5, 15, 4, 59, 12, 482, DateTimeKind.Local).AddTicks(7185), 15, 9.42444375453206m },
                    { 103, 100, new DateTime(2022, 8, 8, 8, 32, 57, 438, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 8, 22, 5, 20, 10, 257, DateTimeKind.Local).AddTicks(1089), 16, 6.44321966645953m },
                    { 104, 149, new DateTime(2022, 5, 13, 7, 18, 49, 325, DateTimeKind.Local).AddTicks(8012), new DateTime(2023, 2, 8, 9, 56, 0, 314, DateTimeKind.Local).AddTicks(6033), 4, 20.5933594283277m },
                    { 105, 141, new DateTime(2022, 6, 29, 13, 49, 41, 105, DateTimeKind.Local).AddTicks(3083), new DateTime(2022, 6, 23, 10, 57, 1, 697, DateTimeKind.Local).AddTicks(801), 52, 22.1699292948013m },
                    { 106, 148, new DateTime(2023, 2, 12, 22, 56, 11, 294, DateTimeKind.Local).AddTicks(3569), new DateTime(2022, 11, 11, 4, 2, 22, 524, DateTimeKind.Local).AddTicks(5522), 61, 24.9945912788917m },
                    { 107, 117, new DateTime(2022, 10, 17, 11, 42, 49, 607, DateTimeKind.Local).AddTicks(6662), new DateTime(2023, 1, 13, 19, 45, 5, 220, DateTimeKind.Local).AddTicks(1544), 55, 15.8052646240736m },
                    { 108, 37, new DateTime(2022, 9, 30, 15, 6, 54, 366, DateTimeKind.Local).AddTicks(8050), new DateTime(2023, 1, 23, 19, 39, 36, 356, DateTimeKind.Local).AddTicks(1172), 17, 2.49235885263784m },
                    { 109, 39, new DateTime(2023, 2, 8, 4, 3, 58, 141, DateTimeKind.Local).AddTicks(2966), new DateTime(2022, 10, 1, 12, 10, 57, 768, DateTimeKind.Local).AddTicks(7802), 78, 15.2586647762733m },
                    { 110, 132, new DateTime(2022, 12, 4, 17, 15, 15, 161, DateTimeKind.Local).AddTicks(6936), new DateTime(2022, 12, 11, 22, 40, 43, 20, DateTimeKind.Local).AddTicks(154), 80, 9.92309161474704m },
                    { 111, 119, new DateTime(2022, 7, 4, 0, 45, 41, 161, DateTimeKind.Local).AddTicks(8882), new DateTime(2022, 10, 30, 14, 43, 39, 205, DateTimeKind.Local).AddTicks(9985), 54, 3.3653193373199m },
                    { 112, 89, new DateTime(2022, 8, 8, 9, 46, 12, 40, DateTimeKind.Local).AddTicks(9161), new DateTime(2022, 9, 21, 4, 53, 8, 446, DateTimeKind.Local).AddTicks(5621), 10, 21.7183289523783m },
                    { 113, 119, new DateTime(2022, 10, 21, 8, 42, 59, 494, DateTimeKind.Local).AddTicks(2765), new DateTime(2022, 7, 30, 23, 51, 34, 144, DateTimeKind.Local).AddTicks(9405), 97, 29.7478429225073m },
                    { 114, 57, new DateTime(2022, 11, 29, 7, 16, 13, 513, DateTimeKind.Local).AddTicks(7417), new DateTime(2022, 12, 6, 21, 35, 29, 445, DateTimeKind.Local).AddTicks(3893), 3, 7.77267369374978m },
                    { 115, 12, new DateTime(2022, 8, 4, 8, 53, 56, 367, DateTimeKind.Local).AddTicks(4409), new DateTime(2022, 11, 21, 17, 0, 44, 173, DateTimeKind.Local).AddTicks(1017), 9, 15.8848361708221m },
                    { 116, 105, new DateTime(2022, 7, 16, 4, 35, 2, 327, DateTimeKind.Local).AddTicks(4918), new DateTime(2022, 5, 6, 13, 13, 46, 954, DateTimeKind.Local).AddTicks(9836), 81, 2.84950295905207m },
                    { 117, 70, new DateTime(2022, 6, 1, 23, 10, 50, 671, DateTimeKind.Local).AddTicks(8963), new DateTime(2022, 6, 25, 23, 17, 29, 619, DateTimeKind.Local).AddTicks(1193), 16, 4.06718753997181m },
                    { 118, 59, new DateTime(2022, 11, 26, 6, 17, 1, 857, DateTimeKind.Local).AddTicks(9335), new DateTime(2022, 8, 15, 10, 55, 48, 395, DateTimeKind.Local).AddTicks(2987), 84, 5.56615144915912m },
                    { 119, 68, new DateTime(2023, 1, 4, 4, 44, 20, 219, DateTimeKind.Local).AddTicks(1013), new DateTime(2022, 6, 13, 9, 36, 29, 749, DateTimeKind.Local).AddTicks(538), 61, 27.3075746660107m },
                    { 120, 107, new DateTime(2022, 12, 15, 19, 38, 55, 455, DateTimeKind.Local).AddTicks(2483), new DateTime(2022, 4, 22, 16, 9, 0, 979, DateTimeKind.Local).AddTicks(9629), 24, 5.2508867694671m },
                    { 121, 140, new DateTime(2023, 1, 1, 2, 8, 57, 761, DateTimeKind.Local).AddTicks(7588), new DateTime(2022, 11, 18, 10, 8, 42, 0, DateTimeKind.Local).AddTicks(6564), 12, 23.6460390377651m },
                    { 122, 125, new DateTime(2023, 2, 1, 14, 12, 8, 469, DateTimeKind.Local).AddTicks(8183), new DateTime(2022, 11, 8, 23, 1, 49, 782, DateTimeKind.Local).AddTicks(606), 80, 24.5494505200315m },
                    { 123, 124, new DateTime(2022, 11, 2, 0, 27, 31, 266, DateTimeKind.Local).AddTicks(9100), new DateTime(2022, 7, 15, 16, 15, 17, 907, DateTimeKind.Local).AddTicks(3927), 91, 14.9285161000852m },
                    { 124, 145, new DateTime(2022, 10, 3, 3, 50, 15, 110, DateTimeKind.Local).AddTicks(2132), new DateTime(2022, 6, 3, 18, 12, 30, 89, DateTimeKind.Local).AddTicks(8938), 22, 23.819706656357m },
                    { 125, 126, new DateTime(2022, 12, 24, 15, 36, 54, 326, DateTimeKind.Local).AddTicks(2854), new DateTime(2022, 8, 17, 4, 16, 23, 397, DateTimeKind.Local).AddTicks(9871), 8, 12.5924541314833m },
                    { 126, 133, new DateTime(2022, 7, 24, 13, 32, 17, 743, DateTimeKind.Local).AddTicks(6620), new DateTime(2022, 9, 6, 7, 14, 33, 312, DateTimeKind.Local).AddTicks(2496), 75, 23.2845491581775m },
                    { 127, 123, new DateTime(2023, 3, 7, 12, 16, 45, 628, DateTimeKind.Local).AddTicks(5531), new DateTime(2022, 9, 8, 23, 4, 47, 211, DateTimeKind.Local).AddTicks(8821), 44, 26.7555695678453m },
                    { 128, 81, new DateTime(2023, 3, 1, 11, 55, 25, 147, DateTimeKind.Local).AddTicks(7500), new DateTime(2022, 11, 19, 12, 17, 11, 824, DateTimeKind.Local).AddTicks(3890), 13, 14.9030746635909m },
                    { 129, 108, new DateTime(2023, 1, 3, 13, 50, 42, 898, DateTimeKind.Local).AddTicks(3632), new DateTime(2022, 5, 18, 20, 47, 4, 159, DateTimeKind.Local).AddTicks(5762), 78, 20.2835075296515m },
                    { 130, 52, new DateTime(2023, 2, 19, 2, 15, 45, 79, DateTimeKind.Local).AddTicks(925), new DateTime(2022, 12, 9, 16, 37, 42, 68, DateTimeKind.Local).AddTicks(7279), 44, 17.4144447448641m },
                    { 131, 66, new DateTime(2022, 5, 23, 10, 19, 37, 801, DateTimeKind.Local).AddTicks(930), new DateTime(2023, 3, 31, 17, 38, 39, 417, DateTimeKind.Local).AddTicks(8731), 29, 28.0085192399802m },
                    { 132, 96, new DateTime(2022, 10, 31, 8, 18, 59, 732, DateTimeKind.Local).AddTicks(2432), new DateTime(2022, 8, 15, 20, 6, 34, 938, DateTimeKind.Local).AddTicks(6768), 97, 4.83094118905307m },
                    { 133, 62, new DateTime(2022, 7, 9, 4, 26, 57, 717, DateTimeKind.Local).AddTicks(7495), new DateTime(2022, 11, 13, 6, 54, 27, 501, DateTimeKind.Local).AddTicks(6170), 95, 7.67481128419343m },
                    { 134, 101, new DateTime(2023, 1, 20, 5, 50, 41, 106, DateTimeKind.Local).AddTicks(5187), new DateTime(2023, 1, 9, 1, 27, 36, 263, DateTimeKind.Local).AddTicks(8252), 44, 1.0945748731314m },
                    { 135, 103, new DateTime(2022, 4, 26, 8, 37, 40, 882, DateTimeKind.Local).AddTicks(3113), new DateTime(2022, 4, 14, 21, 57, 8, 187, DateTimeKind.Local).AddTicks(7975), 23, 21.831403743983m },
                    { 136, 91, new DateTime(2022, 12, 24, 3, 6, 5, 376, DateTimeKind.Local).AddTicks(2967), new DateTime(2022, 11, 21, 0, 4, 25, 464, DateTimeKind.Local).AddTicks(2207), 76, 18.4904212913142m },
                    { 137, 8, new DateTime(2022, 4, 23, 6, 57, 57, 991, DateTimeKind.Local).AddTicks(6482), new DateTime(2022, 10, 6, 18, 38, 10, 686, DateTimeKind.Local).AddTicks(4604), 74, 8.49825912001308m },
                    { 138, 94, new DateTime(2022, 11, 10, 14, 48, 41, 641, DateTimeKind.Local).AddTicks(8470), new DateTime(2022, 7, 13, 19, 29, 29, 115, DateTimeKind.Local).AddTicks(3498), 72, 12.7002843665782m },
                    { 139, 144, new DateTime(2022, 11, 30, 20, 48, 53, 374, DateTimeKind.Local).AddTicks(7657), new DateTime(2022, 12, 13, 18, 55, 36, 394, DateTimeKind.Local).AddTicks(4905), 72, 3.56757100496559m },
                    { 140, 103, new DateTime(2022, 8, 24, 3, 47, 55, 611, DateTimeKind.Local).AddTicks(2884), new DateTime(2022, 6, 16, 20, 15, 34, 578, DateTimeKind.Local).AddTicks(6875), 2, 9.30286136269077m },
                    { 141, 67, new DateTime(2022, 8, 21, 2, 59, 46, 825, DateTimeKind.Local).AddTicks(9512), new DateTime(2022, 7, 19, 18, 10, 11, 687, DateTimeKind.Local).AddTicks(4437), 39, 6.58555498633957m },
                    { 142, 106, new DateTime(2022, 4, 26, 10, 55, 16, 651, DateTimeKind.Local).AddTicks(4636), new DateTime(2023, 2, 27, 2, 41, 5, 269, DateTimeKind.Local).AddTicks(3718), 80, 23.3531611273365m },
                    { 143, 3, new DateTime(2022, 8, 10, 18, 43, 23, 331, DateTimeKind.Local).AddTicks(2805), new DateTime(2022, 7, 2, 17, 15, 41, 409, DateTimeKind.Local).AddTicks(4270), 52, 29.8755928778639m },
                    { 144, 23, new DateTime(2022, 9, 10, 4, 52, 50, 64, DateTimeKind.Local).AddTicks(5621), new DateTime(2022, 7, 28, 1, 6, 26, 176, DateTimeKind.Local).AddTicks(1757), 41, 12.6650151718669m },
                    { 145, 75, new DateTime(2022, 12, 23, 14, 19, 18, 458, DateTimeKind.Local).AddTicks(8602), new DateTime(2022, 5, 6, 0, 2, 35, 669, DateTimeKind.Local).AddTicks(3317), 16, 13.7595847749527m },
                    { 146, 140, new DateTime(2022, 5, 3, 0, 56, 29, 437, DateTimeKind.Local).AddTicks(5915), new DateTime(2022, 12, 7, 21, 48, 6, 846, DateTimeKind.Local).AddTicks(1866), 69, 5.26380310054824m },
                    { 147, 2, new DateTime(2022, 8, 1, 12, 52, 0, 962, DateTimeKind.Local).AddTicks(9472), new DateTime(2022, 10, 14, 11, 9, 0, 326, DateTimeKind.Local).AddTicks(2615), 2, 12.4611636334439m },
                    { 148, 135, new DateTime(2023, 1, 13, 16, 32, 14, 232, DateTimeKind.Local).AddTicks(2627), new DateTime(2022, 9, 18, 14, 56, 19, 913, DateTimeKind.Local).AddTicks(4015), 33, 3.66241280920129m },
                    { 149, 22, new DateTime(2022, 9, 3, 23, 42, 39, 410, DateTimeKind.Local).AddTicks(2031), new DateTime(2022, 12, 13, 4, 20, 58, 725, DateTimeKind.Local).AddTicks(1854), 7, 21.6071485157827m },
                    { 150, 86, new DateTime(2022, 9, 7, 22, 5, 22, 6, DateTimeKind.Local).AddTicks(4182), new DateTime(2023, 3, 26, 7, 4, 40, 723, DateTimeKind.Local).AddTicks(7768), 98, 5.74330189925128m },
                    { 151, 128, new DateTime(2022, 4, 10, 22, 57, 38, 994, DateTimeKind.Local).AddTicks(6359), new DateTime(2022, 7, 24, 15, 33, 16, 277, DateTimeKind.Local).AddTicks(4452), 11, 7.86655928548321m },
                    { 152, 97, new DateTime(2022, 12, 7, 0, 54, 32, 259, DateTimeKind.Local).AddTicks(9594), new DateTime(2022, 9, 10, 22, 30, 7, 58, DateTimeKind.Local).AddTicks(2738), 98, 19.0145188467442m },
                    { 153, 99, new DateTime(2023, 2, 9, 13, 6, 23, 470, DateTimeKind.Local).AddTicks(842), new DateTime(2022, 9, 29, 7, 26, 27, 105, DateTimeKind.Local).AddTicks(5903), 40, 15.0676263021071m },
                    { 154, 105, new DateTime(2023, 2, 21, 4, 25, 31, 208, DateTimeKind.Local).AddTicks(9298), new DateTime(2022, 10, 20, 17, 19, 57, 142, DateTimeKind.Local).AddTicks(7157), 41, 2.66391326546166m },
                    { 155, 45, new DateTime(2022, 7, 24, 13, 40, 45, 789, DateTimeKind.Local).AddTicks(2201), new DateTime(2022, 6, 23, 1, 47, 52, 266, DateTimeKind.Local).AddTicks(3079), 52, 14.8905634387099m },
                    { 156, 71, new DateTime(2022, 6, 25, 23, 21, 9, 176, DateTimeKind.Local).AddTicks(124), new DateTime(2022, 8, 24, 17, 31, 44, 390, DateTimeKind.Local).AddTicks(7026), 3, 14.0604950134029m },
                    { 157, 16, new DateTime(2022, 7, 26, 17, 22, 55, 160, DateTimeKind.Local).AddTicks(3410), new DateTime(2022, 12, 31, 14, 59, 7, 962, DateTimeKind.Local).AddTicks(6738), 80, 27.0376813150442m },
                    { 158, 39, new DateTime(2022, 7, 20, 4, 12, 34, 333, DateTimeKind.Local).AddTicks(3246), new DateTime(2022, 9, 2, 5, 39, 36, 646, DateTimeKind.Local).AddTicks(4617), 57, 21.109312191564m },
                    { 159, 39, new DateTime(2022, 6, 13, 14, 1, 15, 467, DateTimeKind.Local).AddTicks(4073), new DateTime(2022, 6, 4, 20, 19, 28, 58, DateTimeKind.Local).AddTicks(3938), 93, 6.34595764250738m },
                    { 160, 34, new DateTime(2022, 11, 28, 0, 42, 1, 815, DateTimeKind.Local).AddTicks(9622), new DateTime(2022, 11, 20, 15, 42, 43, 76, DateTimeKind.Local).AddTicks(7173), 95, 6.55306087631809m },
                    { 161, 17, new DateTime(2023, 3, 6, 8, 16, 20, 722, DateTimeKind.Local).AddTicks(3969), new DateTime(2022, 8, 3, 16, 23, 46, 305, DateTimeKind.Local).AddTicks(6843), 69, 15.8939298244733m },
                    { 162, 107, new DateTime(2023, 2, 13, 0, 35, 42, 635, DateTimeKind.Local).AddTicks(6028), new DateTime(2022, 11, 22, 4, 53, 43, 718, DateTimeKind.Local).AddTicks(452), 75, 29.757887788415m },
                    { 163, 20, new DateTime(2022, 6, 20, 4, 21, 0, 62, DateTimeKind.Local).AddTicks(294), new DateTime(2022, 7, 31, 0, 28, 29, 274, DateTimeKind.Local).AddTicks(36), 3, 4.26271128071932m },
                    { 164, 119, new DateTime(2023, 4, 5, 6, 9, 26, 629, DateTimeKind.Local).AddTicks(7189), new DateTime(2022, 8, 15, 19, 1, 21, 287, DateTimeKind.Local).AddTicks(6405), 88, 22.488090450362m },
                    { 165, 56, new DateTime(2022, 5, 9, 10, 56, 6, 464, DateTimeKind.Local).AddTicks(2968), new DateTime(2022, 5, 24, 2, 5, 19, 23, DateTimeKind.Local).AddTicks(2645), 8, 14.4179275541958m },
                    { 166, 11, new DateTime(2022, 4, 5, 9, 7, 52, 166, DateTimeKind.Local).AddTicks(3076), new DateTime(2023, 2, 15, 11, 7, 5, 675, DateTimeKind.Local).AddTicks(4080), 95, 1.29838562216658m },
                    { 167, 85, new DateTime(2022, 9, 1, 10, 30, 19, 364, DateTimeKind.Local).AddTicks(2608), new DateTime(2023, 2, 9, 15, 52, 16, 953, DateTimeKind.Local).AddTicks(6366), 95, 8.03581291225398m },
                    { 168, 43, new DateTime(2022, 10, 1, 17, 50, 29, 680, DateTimeKind.Local).AddTicks(6893), new DateTime(2022, 12, 19, 23, 23, 2, 913, DateTimeKind.Local).AddTicks(9319), 89, 15.6362872917296m },
                    { 169, 49, new DateTime(2023, 2, 28, 8, 58, 38, 512, DateTimeKind.Local).AddTicks(9868), new DateTime(2022, 5, 5, 19, 19, 37, 600, DateTimeKind.Local).AddTicks(3077), 95, 29.9199028488362m },
                    { 170, 16, new DateTime(2022, 5, 24, 10, 56, 45, 737, DateTimeKind.Local).AddTicks(8769), new DateTime(2023, 3, 6, 4, 17, 40, 97, DateTimeKind.Local).AddTicks(4005), 39, 15.4206497539004m },
                    { 171, 49, new DateTime(2023, 1, 8, 22, 16, 15, 457, DateTimeKind.Local).AddTicks(939), new DateTime(2022, 10, 27, 15, 45, 50, 35, DateTimeKind.Local).AddTicks(4012), 97, 22.8610129017356m },
                    { 172, 5, new DateTime(2022, 7, 17, 1, 38, 11, 335, DateTimeKind.Local).AddTicks(9418), new DateTime(2023, 2, 15, 9, 24, 55, 412, DateTimeKind.Local).AddTicks(1425), 47, 4.8288789765365m },
                    { 173, 26, new DateTime(2022, 7, 1, 6, 37, 27, 101, DateTimeKind.Local).AddTicks(2419), new DateTime(2022, 9, 7, 2, 49, 50, 269, DateTimeKind.Local).AddTicks(146), 26, 16.5053473999295m },
                    { 174, 73, new DateTime(2022, 11, 2, 2, 46, 20, 593, DateTimeKind.Local).AddTicks(7495), new DateTime(2022, 8, 22, 15, 40, 6, 866, DateTimeKind.Local).AddTicks(9578), 32, 28.5496641581687m },
                    { 175, 143, new DateTime(2022, 7, 14, 16, 7, 36, 29, DateTimeKind.Local).AddTicks(5290), new DateTime(2023, 1, 27, 7, 54, 29, 240, DateTimeKind.Local).AddTicks(1266), 12, 20.9701379797707m },
                    { 176, 149, new DateTime(2022, 10, 12, 6, 23, 21, 832, DateTimeKind.Local).AddTicks(6047), new DateTime(2022, 7, 9, 17, 23, 6, 765, DateTimeKind.Local).AddTicks(9713), 12, 9.71462842648969m },
                    { 177, 76, new DateTime(2022, 7, 11, 11, 12, 33, 699, DateTimeKind.Local).AddTicks(3091), new DateTime(2022, 9, 18, 14, 49, 40, 8, DateTimeKind.Local).AddTicks(9457), 62, 19.592233300251m },
                    { 178, 13, new DateTime(2023, 1, 3, 18, 45, 8, 273, DateTimeKind.Local).AddTicks(9422), new DateTime(2022, 4, 17, 15, 30, 55, 497, DateTimeKind.Local).AddTicks(7537), 70, 6.6430029751352m },
                    { 179, 124, new DateTime(2022, 5, 11, 14, 7, 40, 830, DateTimeKind.Local).AddTicks(940), new DateTime(2022, 8, 20, 9, 13, 28, 451, DateTimeKind.Local).AddTicks(6030), 51, 21.5973837827166m },
                    { 180, 85, new DateTime(2022, 8, 4, 6, 9, 56, 987, DateTimeKind.Local).AddTicks(1653), new DateTime(2022, 5, 6, 5, 18, 22, 627, DateTimeKind.Local).AddTicks(7661), 84, 16.5041942739793m },
                    { 181, 69, new DateTime(2022, 5, 13, 6, 0, 48, 437, DateTimeKind.Local).AddTicks(3753), new DateTime(2022, 7, 18, 12, 16, 45, 116, DateTimeKind.Local).AddTicks(6066), 85, 9.51968350309813m },
                    { 182, 140, new DateTime(2022, 4, 15, 16, 9, 38, 807, DateTimeKind.Local).AddTicks(1848), new DateTime(2022, 10, 18, 23, 25, 30, 192, DateTimeKind.Local).AddTicks(9307), 53, 23.6842695908989m },
                    { 183, 73, new DateTime(2022, 6, 15, 5, 19, 18, 451, DateTimeKind.Local).AddTicks(430), new DateTime(2022, 10, 27, 11, 53, 15, 377, DateTimeKind.Local).AddTicks(6442), 91, 6.01427900783993m },
                    { 184, 102, new DateTime(2022, 4, 17, 20, 55, 54, 924, DateTimeKind.Local).AddTicks(890), new DateTime(2022, 4, 14, 12, 0, 29, 922, DateTimeKind.Local).AddTicks(1402), 39, 1.476558046462m },
                    { 185, 75, new DateTime(2022, 6, 10, 18, 27, 20, 37, DateTimeKind.Local).AddTicks(6993), new DateTime(2022, 4, 18, 8, 45, 28, 951, DateTimeKind.Local).AddTicks(822), 85, 23.5078166444281m },
                    { 186, 27, new DateTime(2022, 10, 25, 13, 19, 46, 774, DateTimeKind.Local).AddTicks(1139), new DateTime(2023, 2, 2, 7, 47, 56, 897, DateTimeKind.Local).AddTicks(7880), 30, 15.8877459352195m },
                    { 187, 120, new DateTime(2023, 3, 10, 23, 34, 23, 992, DateTimeKind.Local).AddTicks(522), new DateTime(2022, 10, 6, 9, 21, 15, 150, DateTimeKind.Local).AddTicks(7900), 93, 5.40996440941099m },
                    { 188, 120, new DateTime(2022, 6, 21, 19, 14, 40, 615, DateTimeKind.Local).AddTicks(8589), new DateTime(2022, 9, 17, 5, 24, 34, 429, DateTimeKind.Local).AddTicks(2985), 59, 18.5138089862683m },
                    { 189, 122, new DateTime(2022, 11, 30, 17, 19, 36, 341, DateTimeKind.Local).AddTicks(5408), new DateTime(2022, 8, 7, 15, 2, 38, 632, DateTimeKind.Local).AddTicks(1375), 28, 18.7804067219663m },
                    { 190, 115, new DateTime(2023, 1, 16, 7, 8, 13, 305, DateTimeKind.Local).AddTicks(7742), new DateTime(2022, 7, 28, 15, 4, 7, 996, DateTimeKind.Local).AddTicks(9729), 10, 8.46493880430943m },
                    { 191, 41, new DateTime(2022, 8, 14, 10, 51, 40, 479, DateTimeKind.Local).AddTicks(2885), new DateTime(2023, 1, 18, 11, 32, 54, 402, DateTimeKind.Local).AddTicks(9462), 53, 13.0364619442116m },
                    { 192, 122, new DateTime(2022, 9, 3, 15, 54, 51, 246, DateTimeKind.Local).AddTicks(497), new DateTime(2022, 6, 7, 8, 59, 27, 190, DateTimeKind.Local).AddTicks(1596), 28, 12.3736255929563m },
                    { 193, 139, new DateTime(2022, 6, 24, 18, 21, 21, 431, DateTimeKind.Local).AddTicks(57), new DateTime(2022, 12, 5, 0, 18, 34, 970, DateTimeKind.Local).AddTicks(9250), 86, 19.6641547943515m },
                    { 194, 106, new DateTime(2022, 8, 22, 4, 0, 33, 856, DateTimeKind.Local).AddTicks(8470), new DateTime(2022, 8, 4, 12, 32, 38, 982, DateTimeKind.Local).AddTicks(5424), 75, 12.7033480709629m },
                    { 195, 109, new DateTime(2022, 6, 20, 3, 15, 41, 799, DateTimeKind.Local).AddTicks(8735), new DateTime(2022, 7, 14, 3, 54, 39, 267, DateTimeKind.Local).AddTicks(6630), 2, 14.2906366250525m },
                    { 196, 72, new DateTime(2022, 5, 20, 6, 10, 10, 819, DateTimeKind.Local).AddTicks(4176), new DateTime(2023, 2, 25, 19, 11, 24, 798, DateTimeKind.Local).AddTicks(4658), 87, 1.52025415792467m },
                    { 197, 39, new DateTime(2023, 2, 6, 12, 7, 39, 906, DateTimeKind.Local).AddTicks(9099), new DateTime(2022, 9, 8, 21, 33, 8, 260, DateTimeKind.Local).AddTicks(8972), 70, 9.26099054970461m },
                    { 198, 46, new DateTime(2022, 5, 19, 0, 31, 35, 266, DateTimeKind.Local).AddTicks(6378), new DateTime(2023, 3, 7, 5, 31, 47, 715, DateTimeKind.Local).AddTicks(5564), 34, 27.7991320349828m },
                    { 199, 20, new DateTime(2022, 10, 28, 11, 10, 53, 199, DateTimeKind.Local).AddTicks(2571), new DateTime(2023, 3, 27, 22, 17, 2, 675, DateTimeKind.Local).AddTicks(4989), 29, 21.5196026949943m },
                    { 200, 35, new DateTime(2022, 5, 14, 17, 31, 8, 908, DateTimeKind.Local).AddTicks(5065), new DateTime(2023, 2, 24, 10, 55, 27, 831, DateTimeKind.Local).AddTicks(3944), 54, 7.92641570730072m },
                    { 201, 37, new DateTime(2022, 8, 15, 14, 52, 26, 297, DateTimeKind.Local).AddTicks(683), new DateTime(2022, 8, 7, 23, 54, 25, 876, DateTimeKind.Local).AddTicks(5196), 22, 5.43159009596341m },
                    { 202, 69, new DateTime(2022, 6, 15, 21, 43, 34, 925, DateTimeKind.Local).AddTicks(1760), new DateTime(2022, 9, 7, 11, 7, 24, 845, DateTimeKind.Local).AddTicks(6127), 2, 1.11452601593291m },
                    { 203, 102, new DateTime(2022, 8, 12, 18, 30, 44, 43, DateTimeKind.Local).AddTicks(2134), new DateTime(2022, 11, 21, 22, 2, 20, 526, DateTimeKind.Local).AddTicks(8779), 20, 23.6198175595366m },
                    { 204, 74, new DateTime(2022, 6, 8, 14, 51, 35, 166, DateTimeKind.Local).AddTicks(4296), new DateTime(2023, 3, 16, 23, 32, 29, 506, DateTimeKind.Local).AddTicks(3942), 98, 2.8629237629445m },
                    { 205, 81, new DateTime(2022, 9, 28, 4, 42, 45, 961, DateTimeKind.Local).AddTicks(8544), new DateTime(2023, 3, 28, 23, 8, 21, 378, DateTimeKind.Local).AddTicks(5019), 40, 1.65221102512814m },
                    { 206, 3, new DateTime(2022, 10, 7, 14, 30, 29, 623, DateTimeKind.Local).AddTicks(239), new DateTime(2022, 9, 15, 21, 21, 49, 972, DateTimeKind.Local).AddTicks(7328), 66, 11.7448648370693m },
                    { 207, 105, new DateTime(2023, 3, 17, 17, 47, 22, 174, DateTimeKind.Local).AddTicks(6496), new DateTime(2022, 8, 24, 13, 4, 4, 874, DateTimeKind.Local).AddTicks(3598), 5, 19.2548547488032m },
                    { 208, 90, new DateTime(2023, 2, 15, 3, 49, 30, 723, DateTimeKind.Local).AddTicks(9065), new DateTime(2022, 6, 24, 3, 31, 19, 628, DateTimeKind.Local).AddTicks(7180), 27, 23.0779152618008m },
                    { 209, 103, new DateTime(2022, 9, 28, 19, 56, 41, 499, DateTimeKind.Local).AddTicks(2954), new DateTime(2022, 8, 21, 18, 23, 53, 439, DateTimeKind.Local).AddTicks(6131), 84, 14.2160686652401m },
                    { 210, 33, new DateTime(2023, 3, 4, 11, 13, 36, 676, DateTimeKind.Local).AddTicks(3946), new DateTime(2023, 1, 8, 20, 40, 20, 207, DateTimeKind.Local).AddTicks(1215), 84, 9.94133921137604m },
                    { 211, 88, new DateTime(2022, 11, 17, 5, 58, 11, 305, DateTimeKind.Local).AddTicks(498), new DateTime(2022, 8, 7, 22, 28, 17, 619, DateTimeKind.Local).AddTicks(1051), 46, 25.3381731178413m },
                    { 212, 77, new DateTime(2023, 2, 25, 5, 54, 35, 388, DateTimeKind.Local).AddTicks(4992), new DateTime(2022, 6, 20, 12, 3, 56, 169, DateTimeKind.Local).AddTicks(1332), 67, 9.41030722415118m },
                    { 213, 58, new DateTime(2022, 8, 19, 7, 53, 52, 577, DateTimeKind.Local).AddTicks(6046), new DateTime(2022, 4, 6, 1, 49, 9, 988, DateTimeKind.Local).AddTicks(7834), 31, 25.4332892950503m },
                    { 214, 131, new DateTime(2022, 10, 21, 7, 24, 57, 431, DateTimeKind.Local).AddTicks(718), new DateTime(2023, 1, 23, 22, 22, 32, 194, DateTimeKind.Local).AddTicks(1862), 72, 7.99008837346936m },
                    { 215, 13, new DateTime(2022, 8, 24, 13, 32, 32, 824, DateTimeKind.Local).AddTicks(2678), new DateTime(2022, 12, 10, 3, 54, 31, 817, DateTimeKind.Local).AddTicks(5939), 75, 1.14644863109815m },
                    { 216, 29, new DateTime(2022, 12, 14, 16, 7, 32, 597, DateTimeKind.Local).AddTicks(8500), new DateTime(2022, 8, 31, 18, 37, 43, 185, DateTimeKind.Local).AddTicks(4723), 41, 5.70150999460521m },
                    { 217, 130, new DateTime(2022, 9, 22, 8, 34, 20, 484, DateTimeKind.Local).AddTicks(8591), new DateTime(2022, 12, 20, 16, 3, 15, 769, DateTimeKind.Local).AddTicks(5520), 55, 20.7451177079541m },
                    { 218, 31, new DateTime(2023, 1, 16, 22, 50, 14, 736, DateTimeKind.Local).AddTicks(1287), new DateTime(2023, 1, 30, 16, 53, 42, 565, DateTimeKind.Local).AddTicks(9714), 98, 21.3539164176531m },
                    { 219, 43, new DateTime(2022, 9, 10, 12, 10, 54, 870, DateTimeKind.Local).AddTicks(9934), new DateTime(2023, 3, 10, 11, 16, 32, 750, DateTimeKind.Local).AddTicks(16), 45, 29.2538318915998m },
                    { 220, 126, new DateTime(2022, 5, 15, 1, 13, 0, 313, DateTimeKind.Local).AddTicks(503), new DateTime(2022, 9, 22, 16, 38, 55, 723, DateTimeKind.Local).AddTicks(4690), 64, 20.7933006770664m },
                    { 221, 39, new DateTime(2022, 12, 14, 15, 46, 10, 589, DateTimeKind.Local).AddTicks(1174), new DateTime(2022, 5, 16, 16, 7, 45, 965, DateTimeKind.Local).AddTicks(8781), 60, 19.2829297893311m },
                    { 222, 21, new DateTime(2023, 3, 11, 21, 40, 55, 808, DateTimeKind.Local).AddTicks(4580), new DateTime(2022, 4, 19, 3, 51, 29, 922, DateTimeKind.Local).AddTicks(9933), 97, 24.0013180183772m },
                    { 223, 49, new DateTime(2022, 5, 22, 9, 33, 8, 849, DateTimeKind.Local).AddTicks(7966), new DateTime(2022, 7, 4, 15, 57, 55, 856, DateTimeKind.Local).AddTicks(9100), 23, 6.03379313882751m },
                    { 224, 116, new DateTime(2022, 6, 5, 10, 45, 19, 325, DateTimeKind.Local).AddTicks(8936), new DateTime(2022, 12, 30, 11, 4, 13, 867, DateTimeKind.Local).AddTicks(6787), 61, 1.10809890954233m },
                    { 225, 119, new DateTime(2023, 2, 21, 12, 44, 33, 573, DateTimeKind.Local).AddTicks(720), new DateTime(2022, 6, 18, 13, 55, 42, 656, DateTimeKind.Local).AddTicks(1747), 28, 10.7236897225304m },
                    { 226, 123, new DateTime(2022, 6, 10, 20, 0, 46, 219, DateTimeKind.Local).AddTicks(3753), new DateTime(2023, 2, 26, 9, 36, 29, 969, DateTimeKind.Local).AddTicks(4147), 98, 20.8683582924237m },
                    { 227, 68, new DateTime(2022, 9, 16, 12, 36, 13, 573, DateTimeKind.Local).AddTicks(4122), new DateTime(2022, 10, 29, 6, 34, 15, 476, DateTimeKind.Local).AddTicks(5172), 17, 27.8347662902362m },
                    { 228, 58, new DateTime(2022, 9, 12, 1, 12, 43, 103, DateTimeKind.Local).AddTicks(1394), new DateTime(2022, 5, 6, 1, 34, 49, 996, DateTimeKind.Local).AddTicks(8887), 31, 20.1543907669493m },
                    { 229, 12, new DateTime(2022, 7, 14, 12, 13, 16, 79, DateTimeKind.Local).AddTicks(6984), new DateTime(2023, 2, 11, 12, 57, 52, 286, DateTimeKind.Local).AddTicks(7088), 20, 29.0162020184356m },
                    { 230, 63, new DateTime(2022, 8, 20, 12, 1, 47, 170, DateTimeKind.Local).AddTicks(7823), new DateTime(2022, 11, 8, 16, 29, 40, 721, DateTimeKind.Local).AddTicks(9085), 89, 21.861226034159m },
                    { 231, 86, new DateTime(2023, 3, 13, 22, 21, 41, 821, DateTimeKind.Local).AddTicks(1975), new DateTime(2022, 8, 10, 3, 15, 18, 55, DateTimeKind.Local).AddTicks(6486), 80, 29.686977606892m },
                    { 232, 70, new DateTime(2022, 9, 8, 15, 24, 13, 36, DateTimeKind.Local).AddTicks(3930), new DateTime(2022, 7, 31, 14, 40, 8, 967, DateTimeKind.Local).AddTicks(5713), 34, 20.6314876299045m },
                    { 233, 46, new DateTime(2022, 6, 19, 17, 37, 32, 875, DateTimeKind.Local).AddTicks(6054), new DateTime(2022, 5, 31, 18, 35, 38, 382, DateTimeKind.Local).AddTicks(4711), 45, 18.0314123558027m },
                    { 234, 15, new DateTime(2022, 9, 14, 13, 57, 44, 57, DateTimeKind.Local).AddTicks(6179), new DateTime(2022, 6, 26, 10, 36, 13, 529, DateTimeKind.Local).AddTicks(9514), 72, 8.09999755483219m },
                    { 235, 31, new DateTime(2022, 7, 16, 18, 33, 19, 598, DateTimeKind.Local).AddTicks(1925), new DateTime(2022, 9, 28, 0, 22, 3, 414, DateTimeKind.Local).AddTicks(609), 45, 18.7784578039608m },
                    { 236, 96, new DateTime(2022, 8, 8, 12, 53, 19, 853, DateTimeKind.Local).AddTicks(297), new DateTime(2022, 6, 1, 6, 19, 26, 678, DateTimeKind.Local).AddTicks(2895), 59, 4.37231335065884m },
                    { 237, 144, new DateTime(2022, 9, 13, 14, 54, 2, 434, DateTimeKind.Local).AddTicks(6713), new DateTime(2022, 9, 25, 13, 22, 9, 839, DateTimeKind.Local).AddTicks(7859), 76, 3.7331741298495m },
                    { 238, 104, new DateTime(2022, 11, 18, 9, 24, 36, 995, DateTimeKind.Local).AddTicks(202), new DateTime(2022, 5, 27, 2, 25, 30, 653, DateTimeKind.Local).AddTicks(4316), 5, 15.8289376796764m },
                    { 239, 107, new DateTime(2022, 4, 5, 11, 50, 56, 639, DateTimeKind.Local).AddTicks(1764), new DateTime(2022, 11, 8, 6, 44, 38, 514, DateTimeKind.Local).AddTicks(9937), 17, 22.7704920677609m },
                    { 240, 25, new DateTime(2022, 6, 27, 13, 55, 39, 681, DateTimeKind.Local).AddTicks(4331), new DateTime(2022, 7, 21, 23, 28, 24, 899, DateTimeKind.Local).AddTicks(4762), 76, 21.0831815577414m },
                    { 241, 131, new DateTime(2022, 4, 11, 0, 30, 51, 636, DateTimeKind.Local).AddTicks(7102), new DateTime(2023, 4, 4, 22, 37, 46, 477, DateTimeKind.Local).AddTicks(6543), 88, 9.7054233440546m },
                    { 242, 108, new DateTime(2023, 1, 22, 13, 30, 54, 155, DateTimeKind.Local).AddTicks(725), new DateTime(2023, 2, 27, 22, 32, 53, 176, DateTimeKind.Local).AddTicks(3695), 60, 26.2198590195076m },
                    { 243, 143, new DateTime(2022, 7, 22, 18, 28, 55, 89, DateTimeKind.Local).AddTicks(5974), new DateTime(2022, 7, 30, 4, 16, 13, 663, DateTimeKind.Local).AddTicks(9581), 53, 15.9136651179872m },
                    { 244, 16, new DateTime(2022, 6, 10, 18, 19, 16, 149, DateTimeKind.Local).AddTicks(2261), new DateTime(2023, 2, 4, 19, 44, 23, 96, DateTimeKind.Local).AddTicks(606), 70, 5.80026001271455m },
                    { 245, 33, new DateTime(2022, 5, 13, 22, 7, 34, 442, DateTimeKind.Local).AddTicks(7063), new DateTime(2022, 11, 18, 20, 28, 48, 846, DateTimeKind.Local).AddTicks(777), 92, 24.593895333223m },
                    { 246, 7, new DateTime(2022, 8, 16, 10, 48, 2, 777, DateTimeKind.Local).AddTicks(4953), new DateTime(2022, 7, 1, 17, 2, 14, 211, DateTimeKind.Local).AddTicks(6324), 91, 7.98872304066832m },
                    { 247, 141, new DateTime(2022, 7, 30, 10, 30, 40, 22, DateTimeKind.Local).AddTicks(7011), new DateTime(2023, 4, 4, 0, 35, 20, 401, DateTimeKind.Local).AddTicks(6643), 93, 19.2554225036572m },
                    { 248, 23, new DateTime(2023, 3, 29, 10, 20, 18, 321, DateTimeKind.Local).AddTicks(2259), new DateTime(2022, 12, 25, 10, 29, 46, 444, DateTimeKind.Local).AddTicks(3972), 10, 5.37794067728807m },
                    { 249, 3, new DateTime(2022, 8, 14, 15, 59, 49, 27, DateTimeKind.Local).AddTicks(8439), new DateTime(2022, 7, 18, 9, 0, 37, 377, DateTimeKind.Local).AddTicks(8552), 44, 14.6827711910199m },
                    { 250, 99, new DateTime(2023, 1, 2, 19, 2, 17, 461, DateTimeKind.Local).AddTicks(8468), new DateTime(2023, 3, 21, 7, 16, 56, 303, DateTimeKind.Local).AddTicks(2885), 65, 15.9084952046164m },
                    { 251, 69, new DateTime(2023, 4, 4, 21, 39, 59, 385, DateTimeKind.Local).AddTicks(6258), new DateTime(2023, 3, 2, 11, 1, 21, 51, DateTimeKind.Local).AddTicks(3446), 76, 22.240041355037m },
                    { 252, 105, new DateTime(2023, 2, 6, 12, 12, 46, 208, DateTimeKind.Local).AddTicks(6718), new DateTime(2023, 3, 15, 5, 11, 32, 14, DateTimeKind.Local).AddTicks(651), 99, 12.3923753388626m },
                    { 253, 126, new DateTime(2022, 10, 8, 6, 8, 50, 395, DateTimeKind.Local).AddTicks(1761), new DateTime(2022, 9, 20, 16, 59, 57, 476, DateTimeKind.Local).AddTicks(8352), 90, 23.419760245515m },
                    { 254, 60, new DateTime(2022, 6, 16, 22, 43, 51, 43, DateTimeKind.Local).AddTicks(9463), new DateTime(2022, 6, 5, 15, 6, 28, 600, DateTimeKind.Local).AddTicks(6286), 28, 13.7771984760219m },
                    { 255, 34, new DateTime(2023, 3, 8, 22, 9, 25, 58, DateTimeKind.Local).AddTicks(3712), new DateTime(2022, 8, 9, 4, 51, 24, 405, DateTimeKind.Local).AddTicks(2888), 24, 27.6006732887552m },
                    { 256, 30, new DateTime(2023, 4, 3, 14, 20, 14, 747, DateTimeKind.Local).AddTicks(6803), new DateTime(2022, 11, 19, 17, 15, 22, 322, DateTimeKind.Local).AddTicks(5566), 4, 8.19272240758901m },
                    { 257, 64, new DateTime(2023, 1, 3, 3, 15, 55, 314, DateTimeKind.Local).AddTicks(6973), new DateTime(2022, 7, 29, 3, 54, 7, 157, DateTimeKind.Local).AddTicks(653), 94, 14.6821444701122m },
                    { 258, 16, new DateTime(2022, 9, 29, 20, 22, 16, 989, DateTimeKind.Local).AddTicks(8377), new DateTime(2022, 12, 31, 19, 6, 32, 155, DateTimeKind.Local).AddTicks(4650), 47, 27.0715385632948m },
                    { 259, 128, new DateTime(2022, 8, 21, 17, 15, 6, 737, DateTimeKind.Local).AddTicks(2487), new DateTime(2022, 10, 24, 17, 9, 42, 8, DateTimeKind.Local).AddTicks(2518), 97, 11.2910845854773m },
                    { 260, 82, new DateTime(2022, 6, 26, 4, 57, 24, 851, DateTimeKind.Local).AddTicks(587), new DateTime(2023, 1, 11, 4, 6, 15, 499, DateTimeKind.Local).AddTicks(2488), 5, 24.5270622013094m },
                    { 261, 94, new DateTime(2023, 2, 24, 13, 53, 26, 288, DateTimeKind.Local).AddTicks(7397), new DateTime(2023, 1, 1, 0, 52, 22, 296, DateTimeKind.Local).AddTicks(6023), 78, 14.8128696425381m },
                    { 262, 73, new DateTime(2023, 4, 3, 7, 5, 35, 312, DateTimeKind.Local).AddTicks(3886), new DateTime(2023, 3, 23, 16, 19, 44, 924, DateTimeKind.Local).AddTicks(9355), 66, 22.3892911207089m },
                    { 263, 122, new DateTime(2022, 10, 12, 13, 6, 18, 138, DateTimeKind.Local).AddTicks(5203), new DateTime(2022, 11, 1, 0, 39, 46, 92, DateTimeKind.Local).AddTicks(1763), 22, 7.74453387392569m },
                    { 264, 90, new DateTime(2023, 4, 3, 2, 24, 14, 194, DateTimeKind.Local).AddTicks(3311), new DateTime(2022, 9, 12, 23, 4, 25, 766, DateTimeKind.Local).AddTicks(4529), 59, 7.38165303410251m },
                    { 265, 95, new DateTime(2023, 2, 5, 10, 58, 19, 411, DateTimeKind.Local).AddTicks(8323), new DateTime(2022, 9, 13, 12, 51, 58, 126, DateTimeKind.Local).AddTicks(4098), 46, 8.98915226198356m },
                    { 266, 71, new DateTime(2022, 9, 1, 0, 45, 19, 874, DateTimeKind.Local).AddTicks(1952), new DateTime(2022, 6, 20, 10, 9, 32, 752, DateTimeKind.Local).AddTicks(5910), 45, 4.70209669605404m },
                    { 267, 35, new DateTime(2022, 9, 7, 11, 13, 42, 384, DateTimeKind.Local).AddTicks(7807), new DateTime(2022, 11, 3, 21, 19, 50, 403, DateTimeKind.Local).AddTicks(6293), 33, 2.59839026087295m },
                    { 268, 54, new DateTime(2022, 6, 22, 1, 58, 7, 378, DateTimeKind.Local).AddTicks(6531), new DateTime(2022, 7, 26, 4, 53, 54, 924, DateTimeKind.Local).AddTicks(2238), 78, 16.8915857396933m },
                    { 269, 127, new DateTime(2022, 5, 19, 17, 5, 50, 980, DateTimeKind.Local).AddTicks(7917), new DateTime(2022, 11, 6, 8, 19, 51, 511, DateTimeKind.Local).AddTicks(3620), 45, 2.00323538337686m },
                    { 270, 112, new DateTime(2022, 7, 18, 7, 24, 49, 764, DateTimeKind.Local).AddTicks(1122), new DateTime(2022, 10, 22, 15, 28, 58, 206, DateTimeKind.Local).AddTicks(1633), 9, 3.0861658581953m },
                    { 271, 33, new DateTime(2022, 10, 14, 22, 46, 46, 91, DateTimeKind.Local).AddTicks(2982), new DateTime(2022, 8, 8, 12, 19, 9, 123, DateTimeKind.Local).AddTicks(6975), 43, 24.5877238457724m },
                    { 272, 14, new DateTime(2022, 7, 31, 18, 14, 6, 427, DateTimeKind.Local).AddTicks(4624), new DateTime(2022, 11, 23, 0, 21, 39, 446, DateTimeKind.Local).AddTicks(5406), 63, 18.1798200324017m },
                    { 273, 10, new DateTime(2022, 4, 8, 6, 22, 30, 86, DateTimeKind.Local).AddTicks(6308), new DateTime(2022, 11, 3, 17, 30, 1, 569, DateTimeKind.Local).AddTicks(9516), 85, 9.88907977059824m },
                    { 274, 33, new DateTime(2022, 6, 21, 17, 27, 30, 71, DateTimeKind.Local).AddTicks(8805), new DateTime(2022, 12, 15, 12, 13, 11, 783, DateTimeKind.Local).AddTicks(9370), 39, 6.8487937625935m },
                    { 275, 48, new DateTime(2022, 4, 28, 20, 21, 48, 332, DateTimeKind.Local).AddTicks(3198), new DateTime(2022, 10, 31, 7, 34, 31, 729, DateTimeKind.Local).AddTicks(7806), 4, 12.7966880519954m },
                    { 276, 89, new DateTime(2022, 12, 31, 7, 21, 43, 415, DateTimeKind.Local).AddTicks(8233), new DateTime(2022, 5, 27, 8, 19, 29, 441, DateTimeKind.Local).AddTicks(1211), 91, 10.7469687554365m },
                    { 277, 118, new DateTime(2022, 4, 13, 13, 22, 16, 107, DateTimeKind.Local).AddTicks(1478), new DateTime(2022, 7, 10, 15, 35, 33, 579, DateTimeKind.Local).AddTicks(9267), 3, 22.1972727633893m },
                    { 278, 90, new DateTime(2022, 10, 14, 15, 16, 0, 890, DateTimeKind.Local).AddTicks(7737), new DateTime(2022, 7, 21, 6, 5, 36, 881, DateTimeKind.Local).AddTicks(5904), 72, 17.7028838875547m },
                    { 279, 107, new DateTime(2023, 2, 14, 3, 12, 7, 382, DateTimeKind.Local).AddTicks(5863), new DateTime(2023, 1, 13, 8, 28, 52, 448, DateTimeKind.Local).AddTicks(6520), 92, 19.0477146698949m },
                    { 280, 141, new DateTime(2023, 2, 3, 5, 10, 54, 708, DateTimeKind.Local).AddTicks(7275), new DateTime(2023, 1, 9, 17, 34, 20, 477, DateTimeKind.Local).AddTicks(6675), 1, 4.47898281536227m },
                    { 281, 32, new DateTime(2022, 9, 9, 0, 7, 9, 47, DateTimeKind.Local).AddTicks(5287), new DateTime(2022, 7, 18, 23, 33, 37, 949, DateTimeKind.Local).AddTicks(3637), 56, 11.332258912772m },
                    { 282, 56, new DateTime(2022, 12, 12, 7, 19, 15, 198, DateTimeKind.Local).AddTicks(8906), new DateTime(2023, 1, 11, 3, 58, 20, 671, DateTimeKind.Local).AddTicks(4311), 37, 21.3586402491222m },
                    { 283, 87, new DateTime(2022, 11, 17, 18, 59, 45, 965, DateTimeKind.Local).AddTicks(9049), new DateTime(2022, 6, 28, 12, 50, 48, 750, DateTimeKind.Local).AddTicks(5830), 6, 28.3626208563372m },
                    { 284, 44, new DateTime(2022, 9, 18, 0, 36, 2, 335, DateTimeKind.Local).AddTicks(5363), new DateTime(2022, 6, 5, 8, 40, 23, 246, DateTimeKind.Local).AddTicks(1176), 82, 16.1447831690831m },
                    { 285, 93, new DateTime(2022, 8, 16, 4, 37, 38, 664, DateTimeKind.Local).AddTicks(1170), new DateTime(2022, 6, 3, 5, 32, 32, 240, DateTimeKind.Local).AddTicks(6216), 96, 22.2974626380335m },
                    { 286, 142, new DateTime(2022, 8, 12, 18, 30, 19, 959, DateTimeKind.Local).AddTicks(7549), new DateTime(2023, 1, 3, 11, 54, 36, 84, DateTimeKind.Local).AddTicks(1869), 12, 23.1727140366873m },
                    { 287, 43, new DateTime(2022, 10, 2, 11, 43, 56, 859, DateTimeKind.Local).AddTicks(9741), new DateTime(2022, 8, 3, 10, 51, 35, 930, DateTimeKind.Local).AddTicks(7210), 59, 17.6043012323808m },
                    { 288, 85, new DateTime(2022, 12, 15, 17, 55, 1, 412, DateTimeKind.Local).AddTicks(6071), new DateTime(2023, 3, 1, 9, 40, 12, 206, DateTimeKind.Local).AddTicks(172), 8, 11.5243598657191m },
                    { 289, 106, new DateTime(2022, 5, 21, 6, 0, 2, 506, DateTimeKind.Local).AddTicks(5092), new DateTime(2022, 7, 25, 12, 47, 10, 343, DateTimeKind.Local).AddTicks(4456), 15, 18.8245993228978m },
                    { 290, 83, new DateTime(2022, 10, 7, 0, 21, 33, 81, DateTimeKind.Local).AddTicks(336), new DateTime(2022, 8, 10, 7, 59, 42, 61, DateTimeKind.Local).AddTicks(9389), 2, 25.149939447247m },
                    { 291, 113, new DateTime(2022, 7, 31, 6, 13, 36, 681, DateTimeKind.Local).AddTicks(6571), new DateTime(2023, 2, 11, 9, 44, 57, 700, DateTimeKind.Local).AddTicks(9917), 48, 18.8967058980829m },
                    { 292, 106, new DateTime(2022, 5, 13, 4, 13, 15, 351, DateTimeKind.Local).AddTicks(8032), new DateTime(2022, 8, 20, 14, 42, 4, 86, DateTimeKind.Local).AddTicks(7078), 22, 8.65792518035023m },
                    { 293, 46, new DateTime(2022, 12, 28, 20, 8, 8, 63, DateTimeKind.Local).AddTicks(6835), new DateTime(2022, 11, 15, 12, 37, 11, 132, DateTimeKind.Local).AddTicks(2157), 17, 20.5706203614627m },
                    { 294, 50, new DateTime(2023, 2, 19, 2, 27, 48, 276, DateTimeKind.Local).AddTicks(1228), new DateTime(2022, 8, 25, 7, 42, 13, 786, DateTimeKind.Local).AddTicks(7996), 30, 6.06221927066509m },
                    { 295, 48, new DateTime(2023, 2, 18, 11, 52, 40, 458, DateTimeKind.Local).AddTicks(3124), new DateTime(2023, 3, 7, 16, 27, 20, 566, DateTimeKind.Local).AddTicks(1151), 57, 25.478293919876m },
                    { 296, 97, new DateTime(2023, 2, 9, 6, 18, 43, 918, DateTimeKind.Local).AddTicks(3413), new DateTime(2022, 10, 7, 9, 9, 36, 686, DateTimeKind.Local).AddTicks(1104), 87, 6.15261819476285m },
                    { 297, 43, new DateTime(2022, 8, 22, 5, 31, 32, 512, DateTimeKind.Local).AddTicks(1337), new DateTime(2023, 2, 24, 7, 51, 11, 86, DateTimeKind.Local).AddTicks(2052), 28, 6.82370359917156m },
                    { 298, 128, new DateTime(2022, 6, 11, 14, 15, 29, 973, DateTimeKind.Local).AddTicks(8579), new DateTime(2022, 11, 6, 13, 18, 56, 329, DateTimeKind.Local).AddTicks(5804), 42, 8.57306707685808m },
                    { 299, 148, new DateTime(2022, 11, 22, 19, 53, 6, 814, DateTimeKind.Local).AddTicks(1854), new DateTime(2022, 11, 23, 14, 28, 54, 176, DateTimeKind.Local).AddTicks(9005), 13, 3.11929357925738m },
                    { 300, 76, new DateTime(2023, 3, 23, 4, 3, 41, 956, DateTimeKind.Local).AddTicks(914), new DateTime(2022, 5, 17, 18, 2, 2, 761, DateTimeKind.Local).AddTicks(9371), 27, 20.5544762362512m },
                    { 301, 133, new DateTime(2022, 10, 2, 7, 11, 59, 649, DateTimeKind.Local).AddTicks(5560), new DateTime(2022, 6, 26, 11, 54, 10, 27, DateTimeKind.Local).AddTicks(6987), 39, 20.6660495155629m },
                    { 302, 138, new DateTime(2022, 6, 18, 17, 5, 22, 708, DateTimeKind.Local).AddTicks(6033), new DateTime(2022, 6, 9, 16, 27, 11, 181, DateTimeKind.Local).AddTicks(4220), 30, 21.1876538439179m },
                    { 303, 40, new DateTime(2023, 2, 16, 11, 39, 9, 953, DateTimeKind.Local).AddTicks(9261), new DateTime(2022, 7, 24, 14, 58, 37, 719, DateTimeKind.Local).AddTicks(9978), 58, 14.4656213780738m },
                    { 304, 63, new DateTime(2022, 6, 21, 2, 29, 15, 702, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 6, 5, 21, 58, 3, 569, DateTimeKind.Local).AddTicks(3476), 43, 19.4033359440222m },
                    { 305, 28, new DateTime(2022, 5, 21, 14, 1, 2, 505, DateTimeKind.Local).AddTicks(7077), new DateTime(2022, 4, 30, 7, 17, 37, 779, DateTimeKind.Local).AddTicks(2897), 60, 7.01053165453348m },
                    { 306, 119, new DateTime(2023, 1, 18, 12, 5, 31, 147, DateTimeKind.Local).AddTicks(8479), new DateTime(2022, 12, 12, 0, 37, 1, 700, DateTimeKind.Local).AddTicks(1574), 9, 15.1743327606154m },
                    { 307, 129, new DateTime(2022, 12, 29, 13, 45, 10, 152, DateTimeKind.Local).AddTicks(337), new DateTime(2022, 12, 11, 4, 43, 10, 306, DateTimeKind.Local).AddTicks(3200), 49, 16.9130624126548m },
                    { 308, 115, new DateTime(2022, 11, 29, 2, 31, 0, 209, DateTimeKind.Local).AddTicks(8817), new DateTime(2023, 3, 13, 1, 8, 55, 541, DateTimeKind.Local).AddTicks(8418), 97, 3.55158605875461m },
                    { 309, 37, new DateTime(2022, 7, 27, 11, 37, 25, 301, DateTimeKind.Local).AddTicks(8346), new DateTime(2022, 4, 12, 17, 14, 50, 997, DateTimeKind.Local).AddTicks(5827), 29, 3.60409580562192m },
                    { 310, 57, new DateTime(2023, 1, 23, 11, 32, 49, 715, DateTimeKind.Local).AddTicks(5210), new DateTime(2022, 11, 26, 23, 12, 22, 325, DateTimeKind.Local).AddTicks(9802), 14, 15.6578765258844m },
                    { 311, 120, new DateTime(2022, 9, 22, 22, 45, 14, 96, DateTimeKind.Local).AddTicks(6304), new DateTime(2023, 2, 9, 13, 5, 1, 630, DateTimeKind.Local).AddTicks(2388), 49, 26.6832796608391m },
                    { 312, 18, new DateTime(2022, 4, 9, 8, 37, 13, 910, DateTimeKind.Local).AddTicks(3837), new DateTime(2022, 7, 21, 23, 44, 5, 876, DateTimeKind.Local).AddTicks(3502), 72, 22.191495273478m },
                    { 313, 81, new DateTime(2022, 6, 29, 2, 37, 25, 248, DateTimeKind.Local).AddTicks(4746), new DateTime(2023, 3, 8, 16, 53, 30, 992, DateTimeKind.Local).AddTicks(4591), 20, 28.4937346996466m },
                    { 314, 16, new DateTime(2022, 6, 17, 12, 22, 5, 722, DateTimeKind.Local).AddTicks(8284), new DateTime(2022, 8, 28, 17, 14, 8, 409, DateTimeKind.Local).AddTicks(7683), 63, 1.29871997010641m },
                    { 315, 30, new DateTime(2022, 12, 21, 22, 51, 38, 454, DateTimeKind.Local).AddTicks(350), new DateTime(2022, 10, 26, 23, 33, 52, 647, DateTimeKind.Local).AddTicks(5731), 68, 8.58016695150007m },
                    { 316, 73, new DateTime(2022, 5, 27, 3, 55, 38, 116, DateTimeKind.Local).AddTicks(4475), new DateTime(2022, 6, 11, 5, 53, 20, 301, DateTimeKind.Local).AddTicks(4404), 66, 29.2800842823619m },
                    { 317, 11, new DateTime(2022, 11, 4, 22, 3, 29, 301, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 1, 29, 19, 37, 22, 133, DateTimeKind.Local).AddTicks(9131), 92, 5.35161147245877m },
                    { 318, 122, new DateTime(2022, 7, 24, 23, 56, 6, 539, DateTimeKind.Local).AddTicks(6777), new DateTime(2023, 1, 15, 2, 13, 12, 448, DateTimeKind.Local).AddTicks(8761), 73, 21.4871898824855m },
                    { 319, 78, new DateTime(2022, 10, 25, 6, 17, 9, 316, DateTimeKind.Local).AddTicks(9479), new DateTime(2022, 12, 22, 1, 21, 53, 119, DateTimeKind.Local).AddTicks(4909), 99, 29.816569069756m },
                    { 320, 10, new DateTime(2022, 8, 31, 15, 41, 2, 250, DateTimeKind.Local).AddTicks(9344), new DateTime(2022, 11, 20, 22, 31, 56, 730, DateTimeKind.Local).AddTicks(8984), 26, 4.73092196544937m },
                    { 321, 85, new DateTime(2023, 2, 20, 1, 48, 11, 995, DateTimeKind.Local).AddTicks(2587), new DateTime(2022, 10, 30, 23, 22, 47, 231, DateTimeKind.Local).AddTicks(2326), 87, 21.8984712418144m },
                    { 322, 41, new DateTime(2022, 10, 27, 21, 38, 18, 377, DateTimeKind.Local).AddTicks(7255), new DateTime(2023, 1, 30, 4, 55, 21, 652, DateTimeKind.Local).AddTicks(6008), 100, 21.3040828417939m },
                    { 323, 14, new DateTime(2022, 12, 13, 23, 32, 11, 961, DateTimeKind.Local).AddTicks(1027), new DateTime(2022, 4, 27, 0, 13, 16, 491, DateTimeKind.Local).AddTicks(3694), 45, 19.4417588051653m },
                    { 324, 114, new DateTime(2022, 7, 22, 22, 53, 24, 786, DateTimeKind.Local).AddTicks(5598), new DateTime(2023, 4, 2, 21, 24, 33, 471, DateTimeKind.Local).AddTicks(1578), 9, 11.7209020431565m },
                    { 325, 108, new DateTime(2023, 1, 9, 8, 31, 55, 709, DateTimeKind.Local).AddTicks(3472), new DateTime(2022, 8, 10, 7, 12, 2, 448, DateTimeKind.Local).AddTicks(2390), 95, 16.4182604042491m },
                    { 326, 122, new DateTime(2022, 4, 12, 18, 41, 1, 252, DateTimeKind.Local).AddTicks(1985), new DateTime(2022, 11, 16, 2, 26, 51, 17, DateTimeKind.Local).AddTicks(5692), 71, 29.5107279191791m },
                    { 327, 83, new DateTime(2023, 3, 4, 22, 36, 3, 301, DateTimeKind.Local).AddTicks(3647), new DateTime(2023, 2, 24, 21, 28, 14, 395, DateTimeKind.Local).AddTicks(4909), 84, 17.2696630901117m },
                    { 328, 78, new DateTime(2022, 11, 29, 10, 51, 0, 829, DateTimeKind.Local).AddTicks(7306), new DateTime(2022, 8, 25, 3, 28, 26, 929, DateTimeKind.Local).AddTicks(9744), 67, 23.0818994375536m },
                    { 329, 138, new DateTime(2022, 9, 8, 16, 35, 37, 412, DateTimeKind.Local).AddTicks(7826), new DateTime(2023, 3, 2, 19, 4, 10, 674, DateTimeKind.Local).AddTicks(8413), 61, 24.0934537408113m },
                    { 330, 65, new DateTime(2022, 6, 8, 11, 45, 34, 39, DateTimeKind.Local).AddTicks(6235), new DateTime(2022, 8, 14, 3, 41, 54, 114, DateTimeKind.Local).AddTicks(5777), 36, 6.67400194841815m },
                    { 331, 36, new DateTime(2022, 7, 10, 5, 22, 32, 749, DateTimeKind.Local).AddTicks(2989), new DateTime(2022, 8, 15, 19, 26, 5, 143, DateTimeKind.Local).AddTicks(1951), 64, 29.3513153902566m },
                    { 332, 114, new DateTime(2023, 2, 16, 21, 53, 59, 601, DateTimeKind.Local).AddTicks(2001), new DateTime(2023, 1, 10, 15, 4, 48, 34, DateTimeKind.Local).AddTicks(2574), 51, 18.7646316500211m },
                    { 333, 66, new DateTime(2022, 11, 30, 7, 26, 52, 494, DateTimeKind.Local).AddTicks(1573), new DateTime(2022, 9, 20, 22, 17, 31, 195, DateTimeKind.Local).AddTicks(9595), 82, 4.77538919585778m },
                    { 334, 142, new DateTime(2022, 8, 4, 12, 32, 16, 367, DateTimeKind.Local).AddTicks(6599), new DateTime(2023, 3, 15, 2, 44, 40, 869, DateTimeKind.Local).AddTicks(4326), 83, 18.1382675107499m },
                    { 335, 111, new DateTime(2022, 9, 1, 16, 37, 33, 115, DateTimeKind.Local).AddTicks(9), new DateTime(2022, 10, 25, 2, 29, 50, 873, DateTimeKind.Local).AddTicks(3353), 59, 9.04661152590046m },
                    { 336, 50, new DateTime(2022, 9, 28, 5, 40, 9, 381, DateTimeKind.Local).AddTicks(6745), new DateTime(2022, 5, 1, 12, 0, 54, 192, DateTimeKind.Local).AddTicks(3947), 19, 2.82698063701181m },
                    { 337, 105, new DateTime(2022, 12, 2, 0, 33, 3, 381, DateTimeKind.Local).AddTicks(8317), new DateTime(2023, 1, 31, 12, 45, 48, 535, DateTimeKind.Local).AddTicks(6583), 75, 15.9342653256365m },
                    { 338, 92, new DateTime(2022, 8, 12, 2, 4, 15, 653, DateTimeKind.Local).AddTicks(588), new DateTime(2022, 9, 30, 22, 8, 27, 151, DateTimeKind.Local).AddTicks(2390), 19, 21.1323206226566m },
                    { 339, 90, new DateTime(2023, 3, 28, 9, 33, 49, 2, DateTimeKind.Local).AddTicks(8045), new DateTime(2022, 10, 17, 1, 37, 50, 125, DateTimeKind.Local).AddTicks(2682), 90, 3.09167801709268m },
                    { 340, 52, new DateTime(2022, 5, 18, 7, 58, 20, 863, DateTimeKind.Local).AddTicks(16), new DateTime(2023, 3, 6, 15, 48, 41, 479, DateTimeKind.Local).AddTicks(456), 8, 20.0288467554139m },
                    { 341, 129, new DateTime(2022, 12, 19, 20, 46, 41, 591, DateTimeKind.Local).AddTicks(2453), new DateTime(2023, 1, 13, 23, 8, 53, 836, DateTimeKind.Local).AddTicks(2597), 42, 14.4642819066913m },
                    { 342, 122, new DateTime(2022, 6, 22, 4, 13, 35, 710, DateTimeKind.Local).AddTicks(6336), new DateTime(2022, 8, 7, 23, 57, 30, 717, DateTimeKind.Local).AddTicks(9665), 17, 27.7880365142784m },
                    { 343, 78, new DateTime(2022, 9, 30, 14, 57, 50, 240, DateTimeKind.Local).AddTicks(2764), new DateTime(2022, 8, 21, 4, 45, 14, 251, DateTimeKind.Local).AddTicks(5350), 25, 27.6580143993247m },
                    { 344, 57, new DateTime(2022, 10, 21, 7, 54, 10, 787, DateTimeKind.Local).AddTicks(4360), new DateTime(2022, 12, 16, 6, 14, 26, 874, DateTimeKind.Local).AddTicks(3262), 84, 19.9897489327718m },
                    { 345, 122, new DateTime(2022, 5, 13, 3, 7, 31, 669, DateTimeKind.Local).AddTicks(7746), new DateTime(2022, 6, 15, 7, 11, 2, 534, DateTimeKind.Local).AddTicks(5669), 72, 17.7196453344741m },
                    { 346, 144, new DateTime(2023, 3, 19, 10, 55, 10, 968, DateTimeKind.Local).AddTicks(59), new DateTime(2023, 1, 20, 5, 38, 36, 103, DateTimeKind.Local).AddTicks(6557), 42, 22.7228511063924m },
                    { 347, 126, new DateTime(2022, 8, 12, 8, 24, 54, 29, DateTimeKind.Local).AddTicks(3029), new DateTime(2023, 1, 11, 3, 11, 7, 35, DateTimeKind.Local).AddTicks(6979), 80, 13.7569988941595m },
                    { 348, 31, new DateTime(2022, 4, 10, 10, 21, 4, 431, DateTimeKind.Local).AddTicks(1696), new DateTime(2023, 1, 8, 13, 37, 41, 736, DateTimeKind.Local).AddTicks(6892), 92, 22.7088054523541m },
                    { 349, 77, new DateTime(2023, 3, 26, 15, 13, 20, 263, DateTimeKind.Local).AddTicks(8446), new DateTime(2022, 12, 4, 21, 2, 45, 471, DateTimeKind.Local).AddTicks(1602), 86, 23.2974591329895m },
                    { 350, 45, new DateTime(2022, 7, 1, 23, 41, 16, 672, DateTimeKind.Local).AddTicks(1209), new DateTime(2022, 4, 30, 12, 31, 21, 250, DateTimeKind.Local).AddTicks(7763), 4, 21.9946858632338m },
                    { 351, 103, new DateTime(2022, 5, 1, 16, 12, 5, 769, DateTimeKind.Local).AddTicks(872), new DateTime(2022, 8, 2, 23, 4, 57, 934, DateTimeKind.Local).AddTicks(293), 91, 6.06950561121025m },
                    { 352, 4, new DateTime(2022, 8, 3, 1, 26, 51, 969, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 9, 30, 13, 23, 11, 411, DateTimeKind.Local).AddTicks(5002), 10, 14.6312744251527m },
                    { 353, 109, new DateTime(2022, 7, 6, 5, 23, 34, 446, DateTimeKind.Local).AddTicks(7546), new DateTime(2022, 12, 30, 7, 48, 15, 292, DateTimeKind.Local).AddTicks(4919), 14, 23.1784004538361m },
                    { 354, 12, new DateTime(2022, 8, 5, 7, 52, 37, 401, DateTimeKind.Local).AddTicks(4714), new DateTime(2022, 10, 18, 10, 54, 36, 955, DateTimeKind.Local).AddTicks(830), 45, 8.74476841054885m },
                    { 355, 13, new DateTime(2022, 10, 29, 7, 34, 16, 232, DateTimeKind.Local).AddTicks(4297), new DateTime(2022, 12, 4, 11, 47, 29, 588, DateTimeKind.Local).AddTicks(4905), 81, 22.9610027730055m },
                    { 356, 84, new DateTime(2022, 7, 9, 16, 16, 2, 506, DateTimeKind.Local).AddTicks(9756), new DateTime(2023, 3, 19, 18, 25, 33, 935, DateTimeKind.Local).AddTicks(3157), 17, 8.30300888055784m },
                    { 357, 42, new DateTime(2022, 6, 29, 4, 35, 56, 725, DateTimeKind.Local).AddTicks(7462), new DateTime(2022, 12, 6, 4, 39, 0, 956, DateTimeKind.Local).AddTicks(4913), 53, 28.3063814064459m },
                    { 358, 19, new DateTime(2022, 12, 29, 18, 4, 47, 72, DateTimeKind.Local).AddTicks(2349), new DateTime(2022, 11, 1, 22, 29, 17, 544, DateTimeKind.Local).AddTicks(2370), 36, 6.85837772319854m },
                    { 359, 145, new DateTime(2022, 5, 13, 6, 34, 35, 802, DateTimeKind.Local).AddTicks(9691), new DateTime(2022, 7, 11, 16, 6, 48, 824, DateTimeKind.Local).AddTicks(8482), 5, 16.8477464794492m },
                    { 360, 57, new DateTime(2023, 2, 25, 8, 0, 54, 821, DateTimeKind.Local).AddTicks(1094), new DateTime(2022, 6, 30, 3, 1, 53, 613, DateTimeKind.Local).AddTicks(4465), 3, 10.4085882499307m },
                    { 361, 21, new DateTime(2023, 3, 2, 21, 28, 58, 817, DateTimeKind.Local).AddTicks(2561), new DateTime(2023, 1, 22, 13, 8, 23, 493, DateTimeKind.Local).AddTicks(6538), 17, 16.9700378647394m },
                    { 362, 109, new DateTime(2022, 6, 20, 8, 43, 59, 886, DateTimeKind.Local).AddTicks(3509), new DateTime(2022, 6, 25, 8, 8, 16, 608, DateTimeKind.Local).AddTicks(4964), 46, 2.97580574908362m },
                    { 363, 85, new DateTime(2022, 9, 25, 15, 40, 23, 760, DateTimeKind.Local).AddTicks(9483), new DateTime(2022, 4, 23, 5, 47, 51, 725, DateTimeKind.Local).AddTicks(6450), 85, 23.9788543809998m },
                    { 364, 64, new DateTime(2022, 6, 28, 23, 36, 28, 235, DateTimeKind.Local).AddTicks(1967), new DateTime(2022, 11, 27, 8, 20, 15, 467, DateTimeKind.Local).AddTicks(8063), 87, 20.0495215300472m },
                    { 365, 133, new DateTime(2023, 2, 11, 10, 48, 48, 410, DateTimeKind.Local).AddTicks(7394), new DateTime(2022, 6, 8, 5, 3, 50, 190, DateTimeKind.Local).AddTicks(1075), 95, 19.0615289352763m },
                    { 366, 52, new DateTime(2023, 2, 6, 10, 34, 31, 97, DateTimeKind.Local).AddTicks(9491), new DateTime(2023, 3, 30, 3, 37, 0, 313, DateTimeKind.Local).AddTicks(3155), 26, 28.4820281803636m },
                    { 367, 49, new DateTime(2023, 1, 17, 5, 21, 35, 996, DateTimeKind.Local).AddTicks(6000), new DateTime(2022, 10, 11, 23, 3, 48, 842, DateTimeKind.Local).AddTicks(4907), 46, 29.2419176404787m },
                    { 368, 140, new DateTime(2022, 10, 28, 9, 12, 14, 247, DateTimeKind.Local).AddTicks(5188), new DateTime(2022, 10, 29, 2, 18, 26, 87, DateTimeKind.Local).AddTicks(3869), 19, 17.8692644152336m },
                    { 369, 101, new DateTime(2023, 2, 1, 19, 9, 38, 804, DateTimeKind.Local).AddTicks(3912), new DateTime(2023, 3, 26, 2, 39, 27, 808, DateTimeKind.Local).AddTicks(9295), 98, 29.1130328825455m },
                    { 370, 81, new DateTime(2022, 9, 1, 4, 8, 24, 728, DateTimeKind.Local).AddTicks(5668), new DateTime(2022, 6, 15, 18, 29, 37, 795, DateTimeKind.Local).AddTicks(7690), 47, 21.8648531059057m },
                    { 371, 149, new DateTime(2022, 10, 10, 2, 56, 29, 310, DateTimeKind.Local).AddTicks(8947), new DateTime(2022, 6, 21, 7, 16, 14, 415, DateTimeKind.Local).AddTicks(9474), 49, 26.8443968216272m },
                    { 372, 48, new DateTime(2022, 9, 12, 14, 46, 0, 820, DateTimeKind.Local).AddTicks(1382), new DateTime(2022, 8, 20, 23, 19, 9, 623, DateTimeKind.Local).AddTicks(4203), 60, 14.1895977166433m },
                    { 373, 82, new DateTime(2022, 6, 20, 23, 1, 1, 256, DateTimeKind.Local).AddTicks(8436), new DateTime(2023, 2, 11, 12, 42, 8, 284, DateTimeKind.Local).AddTicks(9526), 20, 4.69390357555699m },
                    { 374, 43, new DateTime(2022, 10, 2, 1, 32, 31, 526, DateTimeKind.Local).AddTicks(5530), new DateTime(2022, 6, 10, 4, 36, 17, 181, DateTimeKind.Local).AddTicks(8221), 23, 19.7065291753615m },
                    { 375, 12, new DateTime(2022, 7, 7, 19, 7, 31, 26, DateTimeKind.Local).AddTicks(2934), new DateTime(2023, 2, 17, 16, 9, 9, 715, DateTimeKind.Local).AddTicks(3933), 98, 19.1082696474673m },
                    { 376, 47, new DateTime(2022, 8, 30, 5, 9, 16, 671, DateTimeKind.Local).AddTicks(9127), new DateTime(2022, 5, 7, 18, 43, 0, 480, DateTimeKind.Local).AddTicks(1363), 51, 6.09329460979908m },
                    { 377, 14, new DateTime(2022, 4, 15, 13, 54, 23, 648, DateTimeKind.Local).AddTicks(457), new DateTime(2023, 1, 24, 11, 57, 11, 516, DateTimeKind.Local).AddTicks(2798), 13, 21.181832014959m },
                    { 378, 112, new DateTime(2022, 5, 15, 20, 0, 28, 199, DateTimeKind.Local).AddTicks(66), new DateTime(2022, 11, 8, 22, 44, 25, 965, DateTimeKind.Local).AddTicks(8480), 26, 16.2914473613807m },
                    { 379, 52, new DateTime(2022, 12, 1, 3, 41, 24, 161, DateTimeKind.Local).AddTicks(7470), new DateTime(2022, 12, 28, 13, 47, 59, 380, DateTimeKind.Local).AddTicks(8100), 30, 29.5350943822518m },
                    { 380, 56, new DateTime(2022, 11, 2, 23, 39, 41, 346, DateTimeKind.Local).AddTicks(8627), new DateTime(2023, 2, 12, 14, 30, 14, 531, DateTimeKind.Local).AddTicks(9378), 86, 14.7920211494317m },
                    { 381, 89, new DateTime(2022, 12, 22, 23, 17, 49, 247, DateTimeKind.Local).AddTicks(5630), new DateTime(2022, 8, 15, 13, 30, 57, 12, DateTimeKind.Local).AddTicks(5893), 77, 28.8936185122651m },
                    { 382, 44, new DateTime(2023, 1, 20, 16, 30, 44, 53, DateTimeKind.Local).AddTicks(195), new DateTime(2022, 7, 24, 21, 42, 40, 857, DateTimeKind.Local).AddTicks(7638), 15, 17.3459832113357m },
                    { 383, 53, new DateTime(2023, 3, 17, 9, 25, 58, 877, DateTimeKind.Local).AddTicks(9445), new DateTime(2022, 11, 14, 3, 14, 6, 176, DateTimeKind.Local).AddTicks(265), 17, 17.8791119046006m },
                    { 384, 70, new DateTime(2022, 12, 18, 12, 32, 7, 242, DateTimeKind.Local).AddTicks(5590), new DateTime(2023, 2, 2, 0, 28, 32, 395, DateTimeKind.Local).AddTicks(6658), 80, 10.9772734636077m },
                    { 385, 87, new DateTime(2022, 8, 7, 3, 23, 27, 943, DateTimeKind.Local).AddTicks(5710), new DateTime(2022, 10, 2, 23, 21, 38, 704, DateTimeKind.Local).AddTicks(578), 40, 26.2300741076686m },
                    { 386, 56, new DateTime(2022, 11, 21, 21, 48, 43, 933, DateTimeKind.Local).AddTicks(466), new DateTime(2022, 10, 20, 11, 35, 16, 579, DateTimeKind.Local).AddTicks(8283), 35, 29.030437173361m },
                    { 387, 58, new DateTime(2022, 5, 28, 10, 17, 43, 768, DateTimeKind.Local).AddTicks(6126), new DateTime(2022, 5, 16, 2, 14, 48, 830, DateTimeKind.Local).AddTicks(5687), 66, 15.0901263724008m },
                    { 388, 36, new DateTime(2022, 4, 19, 1, 58, 38, 68, DateTimeKind.Local).AddTicks(1420), new DateTime(2022, 8, 26, 22, 41, 29, 660, DateTimeKind.Local).AddTicks(1562), 94, 24.4864546667057m },
                    { 389, 91, new DateTime(2022, 11, 23, 15, 14, 36, 221, DateTimeKind.Local).AddTicks(8765), new DateTime(2022, 5, 5, 8, 41, 21, 591, DateTimeKind.Local).AddTicks(2042), 66, 15.8992891263024m },
                    { 390, 144, new DateTime(2022, 6, 28, 17, 11, 55, 749, DateTimeKind.Local).AddTicks(2181), new DateTime(2022, 6, 3, 16, 8, 57, 920, DateTimeKind.Local).AddTicks(9852), 3, 19.867035971398m },
                    { 391, 42, new DateTime(2023, 3, 24, 0, 11, 3, 12, DateTimeKind.Local).AddTicks(7102), new DateTime(2022, 5, 10, 19, 43, 21, 478, DateTimeKind.Local).AddTicks(9806), 89, 23.2756515954358m },
                    { 392, 75, new DateTime(2022, 8, 26, 5, 58, 0, 567, DateTimeKind.Local).AddTicks(6792), new DateTime(2022, 6, 7, 23, 11, 26, 914, DateTimeKind.Local).AddTicks(3437), 69, 25.4451604719431m },
                    { 393, 26, new DateTime(2022, 5, 20, 13, 43, 18, 524, DateTimeKind.Local).AddTicks(3315), new DateTime(2022, 12, 23, 3, 10, 27, 694, DateTimeKind.Local).AddTicks(1001), 5, 24.7206481369739m },
                    { 394, 138, new DateTime(2022, 6, 17, 7, 21, 25, 422, DateTimeKind.Local).AddTicks(2509), new DateTime(2022, 11, 11, 6, 52, 1, 600, DateTimeKind.Local).AddTicks(8378), 71, 3.67521265527359m },
                    { 395, 124, new DateTime(2022, 4, 11, 2, 30, 47, 465, DateTimeKind.Local).AddTicks(2894), new DateTime(2022, 7, 3, 10, 0, 46, 851, DateTimeKind.Local).AddTicks(1031), 23, 9.29315770349289m },
                    { 396, 48, new DateTime(2022, 7, 2, 13, 40, 42, 977, DateTimeKind.Local).AddTicks(3610), new DateTime(2022, 5, 4, 8, 47, 53, 769, DateTimeKind.Local).AddTicks(83), 44, 19.2688154660778m },
                    { 397, 67, new DateTime(2022, 7, 11, 0, 15, 31, 607, DateTimeKind.Local).AddTicks(7998), new DateTime(2023, 1, 24, 20, 55, 26, 314, DateTimeKind.Local).AddTicks(9958), 39, 24.9148463250624m },
                    { 398, 57, new DateTime(2023, 2, 12, 5, 19, 53, 188, DateTimeKind.Local).AddTicks(2185), new DateTime(2022, 10, 29, 17, 12, 38, 608, DateTimeKind.Local).AddTicks(3387), 11, 17.888043769218m },
                    { 399, 124, new DateTime(2022, 8, 22, 17, 44, 7, 672, DateTimeKind.Local).AddTicks(3648), new DateTime(2023, 3, 11, 23, 43, 23, 730, DateTimeKind.Local).AddTicks(5897), 81, 15.4908527261591m },
                    { 400, 70, new DateTime(2022, 6, 28, 15, 17, 57, 620, DateTimeKind.Local).AddTicks(3563), new DateTime(2023, 2, 8, 3, 0, 4, 935, DateTimeKind.Local).AddTicks(5085), 34, 19.1319447407817m },
                    { 401, 5, new DateTime(2022, 6, 1, 13, 41, 28, 47, DateTimeKind.Local).AddTicks(103), new DateTime(2022, 6, 29, 13, 35, 23, 525, DateTimeKind.Local).AddTicks(5113), 78, 8.47996038157368m },
                    { 402, 102, new DateTime(2022, 5, 12, 14, 0, 23, 510, DateTimeKind.Local).AddTicks(5774), new DateTime(2022, 7, 9, 11, 26, 49, 336, DateTimeKind.Local).AddTicks(6126), 37, 11.0868465458709m },
                    { 403, 145, new DateTime(2022, 7, 25, 15, 41, 21, 739, DateTimeKind.Local).AddTicks(9218), new DateTime(2023, 1, 21, 16, 12, 23, 950, DateTimeKind.Local).AddTicks(9045), 81, 7.52842387459896m },
                    { 404, 2, new DateTime(2022, 11, 9, 21, 10, 18, 315, DateTimeKind.Local).AddTicks(8813), new DateTime(2022, 9, 9, 0, 7, 53, 220, DateTimeKind.Local).AddTicks(4353), 98, 26.5372287393336m },
                    { 405, 17, new DateTime(2022, 9, 29, 22, 22, 20, 513, DateTimeKind.Local).AddTicks(4022), new DateTime(2023, 1, 6, 18, 19, 7, 152, DateTimeKind.Local).AddTicks(8806), 52, 11.3195355714836m },
                    { 406, 63, new DateTime(2022, 7, 14, 17, 40, 30, 711, DateTimeKind.Local).AddTicks(8943), new DateTime(2022, 8, 4, 17, 28, 52, 543, DateTimeKind.Local).AddTicks(4018), 77, 27.2504729403054m },
                    { 407, 67, new DateTime(2022, 10, 13, 3, 22, 37, 201, DateTimeKind.Local).AddTicks(4064), new DateTime(2022, 5, 17, 6, 12, 53, 538, DateTimeKind.Local).AddTicks(1921), 3, 6.17289361749753m },
                    { 408, 111, new DateTime(2023, 3, 12, 19, 27, 57, 898, DateTimeKind.Local).AddTicks(5348), new DateTime(2022, 7, 2, 23, 40, 54, 808, DateTimeKind.Local).AddTicks(4165), 30, 2.0628131046387m },
                    { 409, 125, new DateTime(2022, 4, 13, 6, 55, 54, 716, DateTimeKind.Local).AddTicks(6309), new DateTime(2022, 11, 7, 16, 38, 40, 162, DateTimeKind.Local).AddTicks(362), 6, 7.43962255238286m },
                    { 410, 149, new DateTime(2022, 9, 14, 2, 0, 22, 736, DateTimeKind.Local).AddTicks(4400), new DateTime(2022, 7, 20, 7, 19, 8, 2, DateTimeKind.Local).AddTicks(7388), 48, 24.3755495973909m },
                    { 411, 150, new DateTime(2022, 11, 13, 14, 53, 17, 831, DateTimeKind.Local).AddTicks(7332), new DateTime(2023, 2, 15, 5, 54, 38, 992, DateTimeKind.Local).AddTicks(6139), 55, 8.37150798414567m },
                    { 412, 142, new DateTime(2022, 10, 20, 19, 18, 49, 3, DateTimeKind.Local).AddTicks(1454), new DateTime(2022, 6, 20, 1, 22, 59, 5, DateTimeKind.Local).AddTicks(7830), 69, 21.8366845907637m },
                    { 413, 8, new DateTime(2022, 9, 16, 12, 26, 6, 506, DateTimeKind.Local).AddTicks(5085), new DateTime(2023, 1, 15, 4, 47, 11, 869, DateTimeKind.Local).AddTicks(8063), 43, 13.2731401789331m },
                    { 414, 79, new DateTime(2022, 11, 14, 1, 42, 57, 109, DateTimeKind.Local).AddTicks(1640), new DateTime(2022, 11, 24, 2, 48, 35, 292, DateTimeKind.Local).AddTicks(9953), 96, 10.7071247010987m },
                    { 415, 27, new DateTime(2022, 7, 10, 6, 56, 7, 536, DateTimeKind.Local).AddTicks(4832), new DateTime(2022, 5, 4, 19, 3, 8, 527, DateTimeKind.Local).AddTicks(7829), 31, 8.06695749279066m },
                    { 416, 2, new DateTime(2022, 10, 25, 20, 6, 36, 955, DateTimeKind.Local).AddTicks(61), new DateTime(2023, 3, 11, 7, 10, 24, 202, DateTimeKind.Local).AddTicks(8099), 21, 12.110610743713m },
                    { 417, 141, new DateTime(2023, 2, 11, 11, 1, 31, 492, DateTimeKind.Local).AddTicks(3558), new DateTime(2023, 2, 11, 7, 9, 24, 486, DateTimeKind.Local).AddTicks(6190), 91, 22.7381109734486m },
                    { 418, 150, new DateTime(2023, 2, 28, 14, 47, 8, 633, DateTimeKind.Local).AddTicks(8233), new DateTime(2022, 9, 25, 19, 58, 15, 183, DateTimeKind.Local).AddTicks(4389), 4, 21.9707683247367m },
                    { 419, 121, new DateTime(2022, 7, 25, 12, 48, 44, 34, DateTimeKind.Local).AddTicks(4972), new DateTime(2022, 6, 28, 21, 14, 42, 966, DateTimeKind.Local).AddTicks(3630), 56, 18.8027149194015m },
                    { 420, 89, new DateTime(2022, 4, 10, 20, 33, 11, 220, DateTimeKind.Local).AddTicks(7953), new DateTime(2023, 3, 4, 2, 18, 4, 162, DateTimeKind.Local).AddTicks(9209), 3, 26.3516406425521m },
                    { 421, 103, new DateTime(2022, 10, 18, 7, 22, 24, 420, DateTimeKind.Local).AddTicks(3129), new DateTime(2023, 1, 4, 6, 30, 15, 340, DateTimeKind.Local).AddTicks(8849), 99, 19.8819987409727m },
                    { 422, 127, new DateTime(2022, 6, 15, 11, 11, 35, 456, DateTimeKind.Local).AddTicks(5769), new DateTime(2022, 9, 23, 16, 58, 19, 402, DateTimeKind.Local).AddTicks(2847), 19, 5.08085997533127m },
                    { 423, 93, new DateTime(2023, 2, 26, 14, 26, 36, 608, DateTimeKind.Local).AddTicks(4849), new DateTime(2022, 12, 17, 21, 54, 26, 494, DateTimeKind.Local).AddTicks(2165), 45, 25.832049210461m },
                    { 424, 96, new DateTime(2022, 10, 2, 3, 7, 17, 418, DateTimeKind.Local).AddTicks(9254), new DateTime(2022, 9, 22, 6, 29, 10, 557, DateTimeKind.Local).AddTicks(2120), 26, 12.1916478822252m },
                    { 425, 49, new DateTime(2023, 1, 10, 8, 13, 44, 858, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 7, 7, 13, 41, 31, 802, DateTimeKind.Local).AddTicks(3160), 56, 26.8090810109612m },
                    { 426, 47, new DateTime(2022, 7, 2, 16, 21, 27, 413, DateTimeKind.Local).AddTicks(1187), new DateTime(2022, 10, 31, 3, 5, 8, 375, DateTimeKind.Local).AddTicks(2501), 80, 29.3655528490613m },
                    { 427, 4, new DateTime(2022, 8, 6, 6, 38, 7, 951, DateTimeKind.Local).AddTicks(3633), new DateTime(2023, 2, 10, 6, 12, 24, 252, DateTimeKind.Local).AddTicks(3933), 95, 28.3241024735034m },
                    { 428, 94, new DateTime(2022, 12, 2, 23, 53, 1, 460, DateTimeKind.Local).AddTicks(8632), new DateTime(2022, 7, 18, 23, 12, 29, 245, DateTimeKind.Local).AddTicks(4891), 84, 1.03849052956388m },
                    { 429, 98, new DateTime(2022, 4, 30, 9, 5, 0, 203, DateTimeKind.Local).AddTicks(7524), new DateTime(2022, 9, 28, 10, 58, 29, 799, DateTimeKind.Local).AddTicks(4093), 20, 28.8969529339572m },
                    { 430, 29, new DateTime(2022, 5, 17, 3, 12, 11, 606, DateTimeKind.Local).AddTicks(4731), new DateTime(2023, 3, 15, 15, 46, 25, 516, DateTimeKind.Local).AddTicks(1746), 55, 29.1603439512577m },
                    { 431, 93, new DateTime(2022, 7, 22, 0, 35, 21, 654, DateTimeKind.Local).AddTicks(8143), new DateTime(2022, 11, 3, 13, 40, 29, 580, DateTimeKind.Local).AddTicks(2499), 14, 10.3887214496296m },
                    { 432, 121, new DateTime(2022, 12, 27, 18, 2, 45, 856, DateTimeKind.Local).AddTicks(8832), new DateTime(2022, 5, 4, 23, 58, 7, 121, DateTimeKind.Local).AddTicks(84), 90, 15.7892816171293m },
                    { 433, 25, new DateTime(2023, 1, 16, 19, 46, 20, 238, DateTimeKind.Local).AddTicks(9916), new DateTime(2022, 7, 23, 3, 58, 57, 614, DateTimeKind.Local).AddTicks(4323), 30, 2.70818447957091m },
                    { 434, 37, new DateTime(2022, 12, 19, 15, 25, 49, 6, DateTimeKind.Local).AddTicks(7715), new DateTime(2022, 8, 1, 6, 35, 1, 218, DateTimeKind.Local).AddTicks(7284), 36, 29.9581676446426m },
                    { 435, 6, new DateTime(2022, 12, 16, 18, 54, 52, 111, DateTimeKind.Local).AddTicks(5863), new DateTime(2023, 2, 6, 20, 16, 38, 684, DateTimeKind.Local).AddTicks(4926), 93, 20.1535972127127m },
                    { 436, 99, new DateTime(2022, 7, 24, 0, 1, 55, 558, DateTimeKind.Local).AddTicks(1187), new DateTime(2022, 6, 10, 10, 52, 6, 100, DateTimeKind.Local).AddTicks(2334), 19, 22.1567683233996m },
                    { 437, 59, new DateTime(2023, 2, 25, 13, 28, 44, 800, DateTimeKind.Local).AddTicks(2151), new DateTime(2022, 8, 27, 6, 3, 43, 364, DateTimeKind.Local).AddTicks(2242), 28, 13.4078131075599m },
                    { 438, 149, new DateTime(2022, 4, 10, 21, 17, 47, 593, DateTimeKind.Local).AddTicks(9502), new DateTime(2022, 11, 24, 20, 38, 18, 524, DateTimeKind.Local).AddTicks(4819), 71, 14.1400414777981m },
                    { 439, 27, new DateTime(2022, 8, 25, 0, 6, 22, 916, DateTimeKind.Local).AddTicks(1972), new DateTime(2023, 1, 29, 1, 35, 20, 477, DateTimeKind.Local).AddTicks(3110), 44, 14.9530388849147m },
                    { 440, 51, new DateTime(2022, 9, 21, 4, 13, 49, 418, DateTimeKind.Local).AddTicks(6984), new DateTime(2023, 2, 10, 3, 28, 58, 500, DateTimeKind.Local).AddTicks(9254), 61, 14.137059986836m },
                    { 441, 112, new DateTime(2022, 5, 29, 9, 30, 11, 749, DateTimeKind.Local).AddTicks(4628), new DateTime(2022, 8, 3, 19, 23, 7, 778, DateTimeKind.Local).AddTicks(1186), 76, 22.4996756225002m },
                    { 442, 96, new DateTime(2022, 11, 26, 10, 54, 4, 973, DateTimeKind.Local).AddTicks(9461), new DateTime(2022, 4, 23, 10, 20, 19, 686, DateTimeKind.Local).AddTicks(7612), 41, 17.5279400353851m },
                    { 443, 39, new DateTime(2022, 9, 1, 16, 34, 1, 605, DateTimeKind.Local).AddTicks(7100), new DateTime(2022, 9, 29, 13, 40, 24, 329, DateTimeKind.Local).AddTicks(4393), 36, 25.7270454623658m },
                    { 444, 110, new DateTime(2022, 5, 20, 22, 57, 30, 27, DateTimeKind.Local).AddTicks(6138), new DateTime(2022, 10, 13, 17, 22, 15, 93, DateTimeKind.Local).AddTicks(1766), 90, 8.89721128688734m },
                    { 445, 133, new DateTime(2023, 2, 13, 0, 39, 54, 206, DateTimeKind.Local).AddTicks(2808), new DateTime(2022, 10, 4, 16, 23, 29, 4, DateTimeKind.Local).AddTicks(7982), 92, 29.0830968975967m },
                    { 446, 100, new DateTime(2023, 1, 17, 17, 19, 35, 704, DateTimeKind.Local).AddTicks(9059), new DateTime(2022, 12, 14, 13, 19, 42, 294, DateTimeKind.Local).AddTicks(6579), 70, 13.018229729848m },
                    { 447, 129, new DateTime(2022, 12, 29, 14, 41, 58, 180, DateTimeKind.Local).AddTicks(7833), new DateTime(2023, 1, 29, 4, 37, 22, 340, DateTimeKind.Local).AddTicks(313), 18, 1.92489679907259m },
                    { 448, 17, new DateTime(2023, 3, 10, 10, 14, 40, 945, DateTimeKind.Local).AddTicks(8164), new DateTime(2022, 9, 3, 0, 29, 47, 772, DateTimeKind.Local).AddTicks(759), 63, 28.0438486797502m },
                    { 449, 23, new DateTime(2022, 11, 9, 13, 5, 15, 807, DateTimeKind.Local).AddTicks(1052), new DateTime(2022, 10, 27, 18, 55, 12, 69, DateTimeKind.Local).AddTicks(4526), 50, 26.9093075841849m },
                    { 450, 5, new DateTime(2022, 11, 5, 17, 23, 54, 785, DateTimeKind.Local).AddTicks(2189), new DateTime(2022, 8, 14, 1, 52, 48, 938, DateTimeKind.Local).AddTicks(7858), 81, 25.7331302524999m },
                    { 451, 24, new DateTime(2023, 1, 4, 8, 5, 11, 586, DateTimeKind.Local).AddTicks(2273), new DateTime(2022, 10, 22, 12, 54, 49, 842, DateTimeKind.Local).AddTicks(3272), 4, 27.8890161208654m },
                    { 452, 71, new DateTime(2022, 10, 16, 17, 10, 31, 610, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 7, 20, 15, 7, 43, 922, DateTimeKind.Local).AddTicks(9183), 40, 11.6100349419887m },
                    { 453, 21, new DateTime(2022, 12, 28, 22, 47, 46, 534, DateTimeKind.Local).AddTicks(1474), new DateTime(2022, 7, 16, 15, 23, 22, 129, DateTimeKind.Local).AddTicks(5790), 31, 9.89818421410092m },
                    { 454, 6, new DateTime(2022, 10, 21, 15, 18, 43, 750, DateTimeKind.Local).AddTicks(3212), new DateTime(2023, 3, 3, 3, 58, 37, 795, DateTimeKind.Local).AddTicks(9773), 20, 27.2969329987917m },
                    { 455, 82, new DateTime(2022, 10, 7, 1, 35, 4, 483, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 9, 16, 3, 6, 27, 11, DateTimeKind.Local).AddTicks(7513), 54, 5.47126333513513m },
                    { 456, 27, new DateTime(2022, 12, 8, 18, 48, 45, 773, DateTimeKind.Local).AddTicks(2646), new DateTime(2023, 1, 5, 16, 54, 20, 659, DateTimeKind.Local).AddTicks(7842), 38, 10.1925728584261m },
                    { 457, 1, new DateTime(2023, 3, 30, 4, 50, 40, 291, DateTimeKind.Local).AddTicks(8593), new DateTime(2022, 7, 8, 20, 48, 10, 714, DateTimeKind.Local).AddTicks(3298), 19, 28.5451432874484m },
                    { 458, 66, new DateTime(2022, 8, 3, 13, 6, 58, 227, DateTimeKind.Local).AddTicks(2390), new DateTime(2022, 5, 17, 6, 55, 3, 574, DateTimeKind.Local).AddTicks(4164), 33, 29.7028334844602m },
                    { 459, 75, new DateTime(2022, 10, 17, 3, 17, 9, 204, DateTimeKind.Local).AddTicks(5307), new DateTime(2022, 9, 20, 17, 48, 7, 48, DateTimeKind.Local).AddTicks(4042), 48, 27.3544223108524m },
                    { 460, 115, new DateTime(2022, 5, 9, 4, 58, 38, 869, DateTimeKind.Local).AddTicks(6330), new DateTime(2022, 7, 21, 18, 56, 57, 441, DateTimeKind.Local).AddTicks(2924), 42, 10.636433249202m },
                    { 461, 84, new DateTime(2022, 5, 19, 2, 21, 15, 613, DateTimeKind.Local).AddTicks(6686), new DateTime(2022, 10, 7, 17, 33, 43, 501, DateTimeKind.Local).AddTicks(7320), 39, 12.9560349994942m },
                    { 462, 53, new DateTime(2022, 11, 14, 13, 42, 26, 734, DateTimeKind.Local).AddTicks(2668), new DateTime(2022, 10, 19, 5, 45, 41, 34, DateTimeKind.Local).AddTicks(9365), 85, 14.9643683668937m },
                    { 463, 47, new DateTime(2022, 5, 9, 20, 48, 29, 532, DateTimeKind.Local).AddTicks(7814), new DateTime(2022, 12, 31, 16, 51, 4, 822, DateTimeKind.Local).AddTicks(3907), 70, 1.62622942716952m },
                    { 464, 130, new DateTime(2022, 12, 27, 11, 54, 25, 861, DateTimeKind.Local).AddTicks(9151), new DateTime(2022, 5, 26, 15, 35, 54, 577, DateTimeKind.Local).AddTicks(6118), 54, 25.863512224297m },
                    { 465, 1, new DateTime(2022, 12, 28, 11, 53, 14, 391, DateTimeKind.Local).AddTicks(8953), new DateTime(2022, 11, 12, 1, 3, 7, 2, DateTimeKind.Local).AddTicks(6509), 84, 26.9384301431804m },
                    { 466, 109, new DateTime(2022, 11, 16, 12, 31, 9, 396, DateTimeKind.Local).AddTicks(8178), new DateTime(2022, 5, 25, 7, 0, 6, 179, DateTimeKind.Local).AddTicks(4624), 46, 9.76723003413301m },
                    { 467, 58, new DateTime(2023, 1, 5, 10, 17, 43, 948, DateTimeKind.Local).AddTicks(9879), new DateTime(2022, 7, 23, 20, 46, 33, 181, DateTimeKind.Local).AddTicks(5762), 47, 23.1117466516494m },
                    { 468, 138, new DateTime(2022, 8, 1, 15, 18, 29, 478, DateTimeKind.Local).AddTicks(3152), new DateTime(2022, 6, 28, 2, 28, 14, 85, DateTimeKind.Local).AddTicks(3556), 58, 15.2989434964358m },
                    { 469, 119, new DateTime(2023, 2, 4, 12, 22, 39, 496, DateTimeKind.Local).AddTicks(7501), new DateTime(2022, 6, 11, 23, 10, 26, 230, DateTimeKind.Local).AddTicks(2702), 64, 11.1183039349405m },
                    { 470, 125, new DateTime(2022, 11, 9, 17, 5, 21, 253, DateTimeKind.Local).AddTicks(2387), new DateTime(2022, 6, 5, 14, 56, 34, 45, DateTimeKind.Local).AddTicks(4599), 30, 15.4223413017508m },
                    { 471, 84, new DateTime(2023, 3, 20, 11, 54, 43, 442, DateTimeKind.Local).AddTicks(7595), new DateTime(2023, 3, 31, 2, 16, 13, 926, DateTimeKind.Local).AddTicks(2422), 62, 13.1501518874239m },
                    { 472, 62, new DateTime(2022, 11, 28, 19, 5, 2, 866, DateTimeKind.Local).AddTicks(7581), new DateTime(2022, 8, 24, 23, 34, 27, 818, DateTimeKind.Local).AddTicks(3944), 54, 28.5675902025594m },
                    { 473, 92, new DateTime(2022, 7, 22, 0, 42, 10, 296, DateTimeKind.Local).AddTicks(9856), new DateTime(2022, 11, 6, 6, 15, 34, 802, DateTimeKind.Local).AddTicks(4908), 23, 12.552881451367m },
                    { 474, 77, new DateTime(2023, 1, 3, 7, 23, 57, 57, DateTimeKind.Local).AddTicks(4103), new DateTime(2022, 8, 7, 3, 7, 44, 29, DateTimeKind.Local).AddTicks(8642), 50, 22.6420528582136m },
                    { 475, 3, new DateTime(2023, 3, 26, 15, 10, 16, 494, DateTimeKind.Local).AddTicks(7190), new DateTime(2022, 10, 18, 16, 42, 33, 858, DateTimeKind.Local).AddTicks(886), 18, 23.1637986436184m },
                    { 476, 104, new DateTime(2022, 5, 15, 12, 26, 12, 414, DateTimeKind.Local).AddTicks(3343), new DateTime(2022, 6, 23, 20, 9, 7, 980, DateTimeKind.Local).AddTicks(9314), 11, 27.461897876559m },
                    { 477, 21, new DateTime(2022, 8, 21, 16, 52, 56, 825, DateTimeKind.Local).AddTicks(9852), new DateTime(2022, 7, 6, 13, 58, 11, 76, DateTimeKind.Local).AddTicks(6599), 64, 8.52149532270153m },
                    { 478, 69, new DateTime(2022, 9, 11, 2, 54, 10, 146, DateTimeKind.Local).AddTicks(1311), new DateTime(2023, 4, 4, 0, 37, 11, 891, DateTimeKind.Local).AddTicks(1665), 70, 19.3656186681838m },
                    { 479, 66, new DateTime(2022, 6, 24, 13, 55, 2, 492, DateTimeKind.Local).AddTicks(479), new DateTime(2022, 5, 12, 21, 14, 18, 538, DateTimeKind.Local).AddTicks(2408), 61, 14.331074966943m },
                    { 480, 56, new DateTime(2022, 12, 5, 15, 0, 0, 342, DateTimeKind.Local).AddTicks(8458), new DateTime(2023, 3, 16, 14, 53, 51, 13, DateTimeKind.Local).AddTicks(4469), 69, 4.83302086063181m },
                    { 481, 96, new DateTime(2022, 10, 15, 1, 7, 36, 364, DateTimeKind.Local).AddTicks(7583), new DateTime(2022, 4, 18, 14, 24, 31, 404, DateTimeKind.Local).AddTicks(9669), 4, 1.16111387237793m },
                    { 482, 40, new DateTime(2022, 12, 25, 1, 10, 25, 203, DateTimeKind.Local).AddTicks(4333), new DateTime(2023, 2, 18, 4, 48, 53, 540, DateTimeKind.Local).AddTicks(7078), 22, 13.749319076508m },
                    { 483, 76, new DateTime(2022, 8, 14, 3, 21, 3, 957, DateTimeKind.Local).AddTicks(9831), new DateTime(2022, 12, 25, 2, 6, 52, 408, DateTimeKind.Local).AddTicks(5601), 54, 26.441145975778m },
                    { 484, 141, new DateTime(2022, 7, 13, 21, 36, 41, 766, DateTimeKind.Local).AddTicks(9694), new DateTime(2022, 5, 2, 2, 58, 28, 369, DateTimeKind.Local).AddTicks(1989), 81, 15.3055615745518m },
                    { 485, 40, new DateTime(2022, 11, 17, 23, 41, 47, 982, DateTimeKind.Local).AddTicks(1843), new DateTime(2022, 11, 11, 6, 26, 7, 800, DateTimeKind.Local).AddTicks(4785), 67, 3.57646595167291m },
                    { 486, 91, new DateTime(2022, 5, 6, 12, 53, 22, 130, DateTimeKind.Local).AddTicks(4306), new DateTime(2022, 6, 27, 15, 41, 14, 596, DateTimeKind.Local).AddTicks(4617), 80, 4.34085840461676m },
                    { 487, 106, new DateTime(2022, 6, 13, 23, 23, 47, 718, DateTimeKind.Local).AddTicks(392), new DateTime(2023, 3, 15, 13, 7, 25, 946, DateTimeKind.Local).AddTicks(7767), 5, 8.57585223067005m },
                    { 488, 54, new DateTime(2022, 4, 13, 9, 53, 49, 164, DateTimeKind.Local).AddTicks(9622), new DateTime(2022, 6, 15, 18, 20, 44, 212, DateTimeKind.Local).AddTicks(9991), 74, 6.80091288433471m },
                    { 489, 146, new DateTime(2022, 10, 30, 11, 8, 36, 353, DateTimeKind.Local).AddTicks(8633), new DateTime(2022, 10, 15, 15, 22, 53, 559, DateTimeKind.Local).AddTicks(1856), 69, 18.5764878384641m },
                    { 490, 139, new DateTime(2022, 9, 8, 14, 34, 24, 164, DateTimeKind.Local).AddTicks(7465), new DateTime(2022, 11, 21, 2, 17, 48, 679, DateTimeKind.Local).AddTicks(5203), 22, 6.03251929723258m },
                    { 491, 75, new DateTime(2023, 1, 18, 5, 57, 43, 680, DateTimeKind.Local).AddTicks(5378), new DateTime(2023, 1, 24, 10, 12, 27, 632, DateTimeKind.Local).AddTicks(3656), 86, 10.674180684729m },
                    { 492, 44, new DateTime(2023, 1, 22, 5, 46, 8, 703, DateTimeKind.Local).AddTicks(972), new DateTime(2022, 8, 6, 15, 15, 17, 100, DateTimeKind.Local).AddTicks(5903), 82, 11.35769857907m },
                    { 493, 129, new DateTime(2023, 1, 11, 1, 49, 14, 284, DateTimeKind.Local).AddTicks(3957), new DateTime(2022, 11, 2, 10, 14, 36, 814, DateTimeKind.Local).AddTicks(3668), 71, 9.83214940895556m },
                    { 494, 140, new DateTime(2022, 12, 30, 2, 44, 37, 23, DateTimeKind.Local).AddTicks(3259), new DateTime(2022, 10, 30, 9, 13, 23, 125, DateTimeKind.Local).AddTicks(4210), 99, 1.74068834336424m },
                    { 495, 106, new DateTime(2022, 5, 3, 20, 51, 9, 512, DateTimeKind.Local).AddTicks(9203), new DateTime(2022, 10, 1, 14, 16, 2, 821, DateTimeKind.Local).AddTicks(6608), 72, 14.4482740598814m },
                    { 496, 34, new DateTime(2022, 11, 12, 6, 2, 6, 754, DateTimeKind.Local).AddTicks(5137), new DateTime(2023, 1, 29, 6, 37, 6, 288, DateTimeKind.Local).AddTicks(2486), 46, 29.4044857888244m },
                    { 497, 126, new DateTime(2022, 9, 1, 12, 59, 25, 905, DateTimeKind.Local).AddTicks(9386), new DateTime(2022, 6, 6, 3, 20, 55, 118, DateTimeKind.Local).AddTicks(945), 53, 4.79972587424759m },
                    { 498, 39, new DateTime(2022, 7, 20, 2, 23, 53, 770, DateTimeKind.Local).AddTicks(47), new DateTime(2022, 7, 9, 6, 9, 40, 655, DateTimeKind.Local).AddTicks(7758), 51, 4.37061387946187m },
                    { 499, 2, new DateTime(2022, 9, 20, 4, 30, 0, 145, DateTimeKind.Local).AddTicks(2231), new DateTime(2022, 12, 18, 8, 51, 28, 116, DateTimeKind.Local).AddTicks(1432), 69, 20.8986391480819m },
                    { 500, 109, new DateTime(2022, 4, 20, 21, 32, 1, 511, DateTimeKind.Local).AddTicks(5361), new DateTime(2022, 7, 4, 1, 32, 21, 565, DateTimeKind.Local).AddTicks(7761), 40, 3.34533452939149m }
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
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
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
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
