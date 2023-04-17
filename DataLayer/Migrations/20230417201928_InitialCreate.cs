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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "PaymentProvider",
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
                    table.PrimaryKey("PK_PaymentProvider", x => x.Id);
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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Countries_CountryId",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    PaymentProviderId = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_PaymentProvider_PaymentProviderId",
                        column: x => x.PaymentProviderId,
                        principalTable: "PaymentProvider",
                        principalColumn: "Id");
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
                    QTY = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
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
                table: "Baskets",
                columns: new[] { "Id", "BillingAddressId", "CreateDate", "ModifiedDate", "PaymentProviderId", "ShippingAddressId", "Total", "UserId", "state" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 17, 3, 59, 15, 279, DateTimeKind.Local).AddTicks(3854), new DateTime(2023, 3, 8, 12, 12, 25, 685, DateTimeKind.Local).AddTicks(4), null, null, null, null, "draft" },
                    { 2, null, new DateTime(2022, 10, 29, 11, 18, 38, 948, DateTimeKind.Local).AddTicks(9372), new DateTime(2022, 7, 10, 7, 4, 20, 157, DateTimeKind.Local).AddTicks(3036), null, null, null, null, "draft" },
                    { 3, null, new DateTime(2022, 8, 20, 22, 27, 31, 914, DateTimeKind.Local).AddTicks(9391), new DateTime(2022, 11, 10, 23, 8, 55, 634, DateTimeKind.Local).AddTicks(7618), null, null, null, null, "draft" },
                    { 4, null, new DateTime(2022, 12, 9, 16, 33, 2, 180, DateTimeKind.Local).AddTicks(4895), new DateTime(2022, 5, 8, 10, 5, 27, 9, DateTimeKind.Local).AddTicks(4929), null, null, null, null, "draft" },
                    { 5, null, new DateTime(2023, 3, 11, 23, 13, 48, 870, DateTimeKind.Local).AddTicks(670), new DateTime(2022, 8, 26, 10, 24, 49, 356, DateTimeKind.Local).AddTicks(4385), null, null, null, null, "draft" },
                    { 6, null, new DateTime(2023, 4, 7, 11, 27, 57, 223, DateTimeKind.Local).AddTicks(7247), new DateTime(2023, 1, 17, 9, 35, 20, 616, DateTimeKind.Local).AddTicks(329), null, null, null, null, "draft" },
                    { 7, null, new DateTime(2022, 12, 22, 2, 9, 34, 637, DateTimeKind.Local).AddTicks(532), new DateTime(2022, 4, 21, 15, 57, 50, 979, DateTimeKind.Local).AddTicks(8727), null, null, null, null, "draft" },
                    { 8, null, new DateTime(2022, 8, 11, 22, 55, 33, 72, DateTimeKind.Local).AddTicks(9149), new DateTime(2022, 8, 21, 21, 30, 23, 344, DateTimeKind.Local).AddTicks(2412), null, null, null, null, "draft" },
                    { 9, null, new DateTime(2023, 1, 4, 17, 36, 58, 942, DateTimeKind.Local).AddTicks(3444), new DateTime(2022, 9, 5, 7, 53, 23, 418, DateTimeKind.Local).AddTicks(1928), null, null, null, null, "draft" },
                    { 10, null, new DateTime(2022, 8, 3, 21, 4, 51, 323, DateTimeKind.Local).AddTicks(8252), new DateTime(2022, 8, 4, 18, 35, 7, 793, DateTimeKind.Local).AddTicks(1077), null, null, null, null, "draft" },
                    { 11, null, new DateTime(2022, 5, 6, 6, 15, 54, 647, DateTimeKind.Local).AddTicks(8235), new DateTime(2023, 3, 14, 20, 14, 28, 623, DateTimeKind.Local).AddTicks(8251), null, null, null, null, "draft" },
                    { 12, null, new DateTime(2023, 2, 18, 4, 46, 38, 740, DateTimeKind.Local).AddTicks(8034), new DateTime(2022, 11, 29, 12, 15, 27, 842, DateTimeKind.Local).AddTicks(8705), null, null, null, null, "draft" },
                    { 13, null, new DateTime(2022, 6, 30, 16, 18, 9, 169, DateTimeKind.Local).AddTicks(61), new DateTime(2023, 2, 15, 1, 47, 31, 609, DateTimeKind.Local).AddTicks(303), null, null, null, null, "draft" },
                    { 14, null, new DateTime(2022, 7, 2, 4, 46, 47, 424, DateTimeKind.Local).AddTicks(10), new DateTime(2022, 12, 26, 19, 0, 17, 903, DateTimeKind.Local).AddTicks(6899), null, null, null, null, "draft" },
                    { 15, null, new DateTime(2022, 6, 21, 12, 35, 43, 172, DateTimeKind.Local).AddTicks(7128), new DateTime(2022, 5, 29, 8, 51, 4, 317, DateTimeKind.Local).AddTicks(701), null, null, null, null, "draft" },
                    { 16, null, new DateTime(2022, 9, 26, 21, 6, 57, 917, DateTimeKind.Local).AddTicks(8734), new DateTime(2022, 7, 30, 7, 44, 4, 94, DateTimeKind.Local).AddTicks(954), null, null, null, null, "draft" },
                    { 17, null, new DateTime(2022, 8, 5, 16, 29, 34, 386, DateTimeKind.Local).AddTicks(942), new DateTime(2023, 4, 12, 23, 3, 43, 948, DateTimeKind.Local).AddTicks(2333), null, null, null, null, "draft" },
                    { 18, null, new DateTime(2022, 4, 20, 21, 29, 23, 171, DateTimeKind.Local).AddTicks(4120), new DateTime(2022, 6, 27, 15, 7, 20, 338, DateTimeKind.Local).AddTicks(3434), null, null, null, null, "draft" },
                    { 19, null, new DateTime(2022, 6, 8, 11, 43, 49, 608, DateTimeKind.Local).AddTicks(6738), new DateTime(2023, 3, 26, 2, 47, 42, 896, DateTimeKind.Local).AddTicks(9129), null, null, null, null, "draft" },
                    { 20, null, new DateTime(2022, 10, 12, 4, 14, 6, 335, DateTimeKind.Local).AddTicks(5076), new DateTime(2022, 10, 8, 5, 3, 43, 758, DateTimeKind.Local).AddTicks(4262), null, null, null, null, "draft" },
                    { 21, null, new DateTime(2023, 1, 8, 8, 22, 33, 556, DateTimeKind.Local).AddTicks(3678), new DateTime(2022, 4, 20, 4, 40, 6, 56, DateTimeKind.Local).AddTicks(8825), null, null, null, null, "draft" },
                    { 22, null, new DateTime(2022, 8, 8, 16, 14, 58, 515, DateTimeKind.Local).AddTicks(3310), new DateTime(2022, 11, 27, 19, 34, 21, 839, DateTimeKind.Local).AddTicks(6244), null, null, null, null, "draft" },
                    { 23, null, new DateTime(2022, 11, 10, 9, 33, 33, 6, DateTimeKind.Local).AddTicks(5331), new DateTime(2022, 8, 14, 9, 46, 18, 951, DateTimeKind.Local).AddTicks(9266), null, null, null, null, "draft" },
                    { 24, null, new DateTime(2022, 8, 13, 16, 27, 39, 288, DateTimeKind.Local).AddTicks(3139), new DateTime(2022, 10, 27, 7, 56, 31, 758, DateTimeKind.Local).AddTicks(4041), null, null, null, null, "draft" },
                    { 25, null, new DateTime(2023, 1, 18, 16, 20, 24, 464, DateTimeKind.Local).AddTicks(2399), new DateTime(2022, 12, 9, 21, 48, 12, 837, DateTimeKind.Local).AddTicks(3498), null, null, null, null, "draft" },
                    { 26, null, new DateTime(2022, 10, 7, 20, 21, 4, 297, DateTimeKind.Local).AddTicks(4520), new DateTime(2023, 2, 15, 2, 8, 28, 829, DateTimeKind.Local).AddTicks(3408), null, null, null, null, "draft" },
                    { 27, null, new DateTime(2022, 12, 12, 10, 12, 54, 503, DateTimeKind.Local).AddTicks(1235), new DateTime(2022, 8, 8, 11, 4, 35, 348, DateTimeKind.Local).AddTicks(5873), null, null, null, null, "draft" },
                    { 28, null, new DateTime(2022, 11, 24, 16, 52, 14, 954, DateTimeKind.Local).AddTicks(7861), new DateTime(2023, 2, 20, 6, 4, 14, 405, DateTimeKind.Local).AddTicks(67), null, null, null, null, "draft" },
                    { 29, null, new DateTime(2022, 5, 6, 5, 45, 14, 693, DateTimeKind.Local).AddTicks(6267), new DateTime(2023, 3, 17, 21, 22, 38, 855, DateTimeKind.Local).AddTicks(4900), null, null, null, null, "draft" },
                    { 30, null, new DateTime(2022, 4, 27, 13, 5, 38, 737, DateTimeKind.Local).AddTicks(7215), new DateTime(2022, 10, 21, 18, 59, 28, 55, DateTimeKind.Local).AddTicks(3327), null, null, null, null, "draft" },
                    { 31, null, new DateTime(2022, 8, 27, 16, 41, 35, 960, DateTimeKind.Local).AddTicks(1857), new DateTime(2023, 3, 31, 19, 52, 12, 26, DateTimeKind.Local).AddTicks(2243), null, null, null, null, "draft" },
                    { 32, null, new DateTime(2023, 3, 4, 19, 49, 11, 586, DateTimeKind.Local).AddTicks(2057), new DateTime(2023, 1, 29, 12, 42, 12, 302, DateTimeKind.Local).AddTicks(4226), null, null, null, null, "draft" },
                    { 33, null, new DateTime(2023, 3, 17, 11, 37, 19, 187, DateTimeKind.Local).AddTicks(9916), new DateTime(2022, 12, 25, 2, 3, 20, 879, DateTimeKind.Local).AddTicks(559), null, null, null, null, "draft" },
                    { 34, null, new DateTime(2022, 9, 29, 15, 25, 13, 979, DateTimeKind.Local).AddTicks(3663), new DateTime(2022, 12, 27, 1, 25, 18, 438, DateTimeKind.Local).AddTicks(2473), null, null, null, null, "draft" },
                    { 35, null, new DateTime(2022, 4, 18, 16, 47, 55, 557, DateTimeKind.Local).AddTicks(8938), new DateTime(2022, 6, 2, 6, 7, 40, 484, DateTimeKind.Local).AddTicks(47), null, null, null, null, "draft" },
                    { 36, null, new DateTime(2022, 7, 1, 8, 6, 1, 485, DateTimeKind.Local).AddTicks(17), new DateTime(2023, 1, 27, 13, 8, 43, 794, DateTimeKind.Local).AddTicks(8656), null, null, null, null, "draft" },
                    { 37, null, new DateTime(2023, 3, 12, 1, 58, 44, 832, DateTimeKind.Local).AddTicks(1203), new DateTime(2023, 2, 11, 14, 20, 35, 314, DateTimeKind.Local).AddTicks(8342), null, null, null, null, "draft" },
                    { 38, null, new DateTime(2022, 11, 12, 8, 32, 1, 986, DateTimeKind.Local).AddTicks(1758), new DateTime(2022, 5, 3, 23, 55, 16, 340, DateTimeKind.Local).AddTicks(3770), null, null, null, null, "draft" },
                    { 39, null, new DateTime(2022, 11, 22, 2, 18, 57, 857, DateTimeKind.Local).AddTicks(9310), new DateTime(2022, 7, 9, 7, 31, 44, 650, DateTimeKind.Local).AddTicks(6160), null, null, null, null, "draft" },
                    { 40, null, new DateTime(2022, 5, 7, 1, 1, 22, 585, DateTimeKind.Local).AddTicks(7753), new DateTime(2023, 3, 4, 4, 51, 17, 966, DateTimeKind.Local).AddTicks(5175), null, null, null, null, "draft" },
                    { 41, null, new DateTime(2022, 10, 20, 7, 39, 20, 70, DateTimeKind.Local).AddTicks(1552), new DateTime(2022, 12, 21, 19, 9, 43, 415, DateTimeKind.Local).AddTicks(357), null, null, null, null, "draft" },
                    { 42, null, new DateTime(2023, 3, 26, 0, 59, 21, 188, DateTimeKind.Local).AddTicks(8898), new DateTime(2022, 10, 28, 13, 6, 58, 84, DateTimeKind.Local).AddTicks(8027), null, null, null, null, "draft" },
                    { 43, null, new DateTime(2022, 12, 7, 10, 49, 27, 769, DateTimeKind.Local).AddTicks(587), new DateTime(2022, 11, 27, 17, 17, 56, 837, DateTimeKind.Local).AddTicks(9732), null, null, null, null, "draft" },
                    { 44, null, new DateTime(2022, 12, 3, 19, 50, 37, 340, DateTimeKind.Local).AddTicks(4133), new DateTime(2023, 4, 15, 3, 44, 26, 786, DateTimeKind.Local).AddTicks(9483), null, null, null, null, "draft" },
                    { 45, null, new DateTime(2022, 9, 4, 4, 30, 56, 742, DateTimeKind.Local).AddTicks(8895), new DateTime(2022, 6, 16, 13, 44, 36, 515, DateTimeKind.Local).AddTicks(8476), null, null, null, null, "draft" },
                    { 46, null, new DateTime(2022, 6, 9, 7, 41, 33, 394, DateTimeKind.Local).AddTicks(1599), new DateTime(2022, 7, 9, 12, 40, 38, 502, DateTimeKind.Local).AddTicks(6269), null, null, null, null, "draft" },
                    { 47, null, new DateTime(2023, 3, 16, 12, 1, 31, 908, DateTimeKind.Local).AddTicks(6355), new DateTime(2023, 4, 8, 7, 34, 6, 29, DateTimeKind.Local).AddTicks(6190), null, null, null, null, "draft" },
                    { 48, null, new DateTime(2022, 5, 29, 10, 41, 35, 547, DateTimeKind.Local).AddTicks(6855), new DateTime(2023, 1, 25, 10, 49, 49, 279, DateTimeKind.Local).AddTicks(5886), null, null, null, null, "draft" },
                    { 49, null, new DateTime(2022, 6, 3, 7, 10, 22, 220, DateTimeKind.Local).AddTicks(1227), new DateTime(2022, 10, 26, 1, 52, 13, 962, DateTimeKind.Local).AddTicks(3542), null, null, null, null, "draft" },
                    { 50, null, new DateTime(2022, 12, 29, 6, 16, 30, 401, DateTimeKind.Local).AddTicks(795), new DateTime(2023, 3, 4, 5, 49, 39, 876, DateTimeKind.Local).AddTicks(9238), null, null, null, null, "draft" },
                    { 51, null, new DateTime(2023, 3, 2, 16, 40, 32, 722, DateTimeKind.Local).AddTicks(79), new DateTime(2022, 12, 3, 13, 21, 48, 599, DateTimeKind.Local).AddTicks(5142), null, null, null, null, "draft" },
                    { 52, null, new DateTime(2022, 10, 26, 13, 28, 3, 949, DateTimeKind.Local).AddTicks(9634), new DateTime(2022, 12, 4, 8, 32, 11, 729, DateTimeKind.Local).AddTicks(6884), null, null, null, null, "draft" },
                    { 53, null, new DateTime(2022, 9, 26, 12, 1, 39, 101, DateTimeKind.Local).AddTicks(8024), new DateTime(2022, 12, 27, 5, 31, 48, 252, DateTimeKind.Local).AddTicks(405), null, null, null, null, "draft" },
                    { 54, null, new DateTime(2023, 3, 23, 22, 29, 11, 746, DateTimeKind.Local).AddTicks(6756), new DateTime(2023, 2, 15, 18, 11, 46, 937, DateTimeKind.Local).AddTicks(7445), null, null, null, null, "draft" },
                    { 55, null, new DateTime(2023, 1, 12, 0, 52, 1, 111, DateTimeKind.Local).AddTicks(8675), new DateTime(2022, 11, 8, 15, 16, 26, 363, DateTimeKind.Local).AddTicks(8652), null, null, null, null, "draft" },
                    { 56, null, new DateTime(2022, 7, 17, 2, 4, 44, 296, DateTimeKind.Local).AddTicks(5326), new DateTime(2023, 2, 12, 20, 32, 57, 792, DateTimeKind.Local).AddTicks(4677), null, null, null, null, "draft" },
                    { 57, null, new DateTime(2023, 2, 26, 18, 40, 44, 19, DateTimeKind.Local).AddTicks(1726), new DateTime(2022, 6, 11, 6, 33, 48, 520, DateTimeKind.Local).AddTicks(6619), null, null, null, null, "draft" },
                    { 58, null, new DateTime(2022, 4, 19, 9, 39, 35, 734, DateTimeKind.Local).AddTicks(6364), new DateTime(2022, 12, 22, 19, 51, 20, 294, DateTimeKind.Local).AddTicks(6088), null, null, null, null, "draft" },
                    { 59, null, new DateTime(2022, 4, 23, 17, 12, 18, 586, DateTimeKind.Local).AddTicks(7942), new DateTime(2022, 8, 23, 5, 1, 41, 250, DateTimeKind.Local).AddTicks(8627), null, null, null, null, "draft" },
                    { 60, null, new DateTime(2022, 6, 10, 0, 12, 12, 282, DateTimeKind.Local).AddTicks(8244), new DateTime(2022, 8, 5, 16, 38, 50, 99, DateTimeKind.Local).AddTicks(4789), null, null, null, null, "draft" },
                    { 61, null, new DateTime(2022, 5, 9, 4, 32, 11, 288, DateTimeKind.Local).AddTicks(1040), new DateTime(2022, 10, 2, 10, 0, 14, 941, DateTimeKind.Local).AddTicks(8794), null, null, null, null, "draft" },
                    { 62, null, new DateTime(2022, 8, 9, 19, 13, 49, 444, DateTimeKind.Local).AddTicks(8201), new DateTime(2023, 2, 18, 1, 22, 46, 791, DateTimeKind.Local).AddTicks(5038), null, null, null, null, "draft" },
                    { 63, null, new DateTime(2023, 4, 10, 20, 45, 34, 839, DateTimeKind.Local).AddTicks(3032), new DateTime(2023, 4, 9, 17, 44, 50, 731, DateTimeKind.Local).AddTicks(8330), null, null, null, null, "draft" },
                    { 64, null, new DateTime(2023, 2, 28, 23, 26, 39, 635, DateTimeKind.Local).AddTicks(6893), new DateTime(2023, 3, 21, 16, 44, 6, 551, DateTimeKind.Local).AddTicks(9606), null, null, null, null, "draft" },
                    { 65, null, new DateTime(2023, 1, 1, 1, 58, 27, 516, DateTimeKind.Local).AddTicks(6087), new DateTime(2023, 2, 2, 20, 1, 40, 456, DateTimeKind.Local).AddTicks(474), null, null, null, null, "draft" },
                    { 66, null, new DateTime(2023, 3, 18, 15, 4, 21, 869, DateTimeKind.Local).AddTicks(7152), new DateTime(2022, 5, 14, 22, 46, 11, 645, DateTimeKind.Local).AddTicks(377), null, null, null, null, "draft" },
                    { 67, null, new DateTime(2022, 10, 26, 23, 34, 41, 998, DateTimeKind.Local).AddTicks(9982), new DateTime(2022, 6, 20, 17, 31, 10, 458, DateTimeKind.Local).AddTicks(3132), null, null, null, null, "draft" },
                    { 68, null, new DateTime(2022, 4, 19, 10, 30, 12, 993, DateTimeKind.Local).AddTicks(9721), new DateTime(2023, 3, 4, 16, 36, 59, 220, DateTimeKind.Local).AddTicks(1145), null, null, null, null, "draft" },
                    { 69, null, new DateTime(2022, 6, 13, 4, 1, 7, 214, DateTimeKind.Local).AddTicks(5474), new DateTime(2022, 8, 7, 14, 46, 37, 208, DateTimeKind.Local).AddTicks(6765), null, null, null, null, "draft" },
                    { 70, null, new DateTime(2022, 5, 19, 23, 24, 46, 732, DateTimeKind.Local).AddTicks(4765), new DateTime(2023, 3, 29, 3, 37, 7, 266, DateTimeKind.Local).AddTicks(4944), null, null, null, null, "draft" },
                    { 71, null, new DateTime(2022, 12, 22, 17, 8, 12, 840, DateTimeKind.Local).AddTicks(7747), new DateTime(2023, 2, 2, 23, 58, 18, 152, DateTimeKind.Local).AddTicks(1459), null, null, null, null, "draft" },
                    { 72, null, new DateTime(2022, 7, 20, 1, 11, 53, 424, DateTimeKind.Local).AddTicks(5587), new DateTime(2023, 2, 11, 11, 33, 58, 128, DateTimeKind.Local).AddTicks(5023), null, null, null, null, "draft" },
                    { 73, null, new DateTime(2023, 3, 18, 9, 59, 19, 968, DateTimeKind.Local).AddTicks(8024), new DateTime(2022, 8, 12, 9, 28, 3, 351, DateTimeKind.Local).AddTicks(1796), null, null, null, null, "draft" },
                    { 74, null, new DateTime(2022, 8, 28, 16, 19, 22, 232, DateTimeKind.Local).AddTicks(9428), new DateTime(2023, 1, 21, 3, 47, 11, 137, DateTimeKind.Local).AddTicks(4621), null, null, null, null, "draft" },
                    { 75, null, new DateTime(2023, 4, 6, 20, 13, 58, 44, DateTimeKind.Local).AddTicks(4720), new DateTime(2022, 9, 22, 13, 9, 43, 2, DateTimeKind.Local).AddTicks(5661), null, null, null, null, "draft" },
                    { 76, null, new DateTime(2023, 1, 19, 15, 56, 58, 442, DateTimeKind.Local).AddTicks(2847), new DateTime(2023, 1, 27, 0, 28, 8, 718, DateTimeKind.Local).AddTicks(7504), null, null, null, null, "draft" },
                    { 77, null, new DateTime(2022, 9, 2, 23, 59, 29, 429, DateTimeKind.Local).AddTicks(212), new DateTime(2022, 9, 10, 11, 57, 8, 51, DateTimeKind.Local).AddTicks(918), null, null, null, null, "draft" },
                    { 78, null, new DateTime(2023, 2, 10, 23, 36, 56, 338, DateTimeKind.Local).AddTicks(3120), new DateTime(2022, 9, 16, 4, 59, 45, 529, DateTimeKind.Local).AddTicks(6207), null, null, null, null, "draft" },
                    { 79, null, new DateTime(2022, 8, 11, 16, 27, 26, 904, DateTimeKind.Local).AddTicks(1871), new DateTime(2022, 12, 24, 10, 24, 44, 907, DateTimeKind.Local).AddTicks(9528), null, null, null, null, "draft" },
                    { 80, null, new DateTime(2022, 12, 11, 10, 6, 4, 639, DateTimeKind.Local).AddTicks(8792), new DateTime(2022, 10, 4, 16, 36, 16, 119, DateTimeKind.Local).AddTicks(4633), null, null, null, null, "draft" },
                    { 81, null, new DateTime(2023, 2, 13, 4, 24, 36, 365, DateTimeKind.Local).AddTicks(8461), new DateTime(2022, 4, 20, 4, 4, 32, 944, DateTimeKind.Local).AddTicks(2099), null, null, null, null, "draft" },
                    { 82, null, new DateTime(2022, 6, 2, 14, 32, 47, 170, DateTimeKind.Local).AddTicks(6315), new DateTime(2023, 3, 27, 3, 9, 48, 405, DateTimeKind.Local).AddTicks(3159), null, null, null, null, "draft" },
                    { 83, null, new DateTime(2022, 12, 8, 22, 31, 32, 243, DateTimeKind.Local).AddTicks(6466), new DateTime(2022, 6, 20, 1, 38, 0, 400, DateTimeKind.Local).AddTicks(9915), null, null, null, null, "draft" },
                    { 84, null, new DateTime(2022, 8, 4, 19, 17, 43, 542, DateTimeKind.Local).AddTicks(9670), new DateTime(2022, 12, 24, 23, 29, 1, 310, DateTimeKind.Local).AddTicks(3569), null, null, null, null, "draft" },
                    { 85, null, new DateTime(2022, 6, 9, 18, 23, 3, 276, DateTimeKind.Local).AddTicks(1882), new DateTime(2022, 6, 2, 15, 22, 4, 264, DateTimeKind.Local).AddTicks(312), null, null, null, null, "draft" },
                    { 86, null, new DateTime(2022, 10, 27, 14, 9, 40, 829, DateTimeKind.Local).AddTicks(5723), new DateTime(2023, 1, 2, 0, 45, 9, 127, DateTimeKind.Local).AddTicks(6287), null, null, null, null, "draft" },
                    { 87, null, new DateTime(2022, 7, 22, 3, 56, 22, 267, DateTimeKind.Local).AddTicks(8982), new DateTime(2022, 6, 29, 18, 54, 32, 765, DateTimeKind.Local).AddTicks(8420), null, null, null, null, "draft" },
                    { 88, null, new DateTime(2022, 11, 29, 21, 50, 5, 8, DateTimeKind.Local).AddTicks(2170), new DateTime(2022, 7, 22, 2, 53, 20, 885, DateTimeKind.Local).AddTicks(4710), null, null, null, null, "draft" },
                    { 89, null, new DateTime(2022, 7, 1, 7, 7, 49, 266, DateTimeKind.Local).AddTicks(8344), new DateTime(2022, 10, 14, 5, 59, 19, 65, DateTimeKind.Local).AddTicks(8316), null, null, null, null, "draft" },
                    { 90, null, new DateTime(2023, 3, 20, 13, 42, 54, 572, DateTimeKind.Local).AddTicks(2245), new DateTime(2022, 12, 15, 9, 36, 59, 237, DateTimeKind.Local).AddTicks(6469), null, null, null, null, "draft" },
                    { 91, null, new DateTime(2022, 11, 27, 23, 44, 56, 248, DateTimeKind.Local).AddTicks(4145), new DateTime(2022, 5, 26, 17, 58, 56, 247, DateTimeKind.Local).AddTicks(7516), null, null, null, null, "draft" },
                    { 92, null, new DateTime(2023, 4, 1, 18, 49, 36, 257, DateTimeKind.Local).AddTicks(138), new DateTime(2022, 7, 27, 11, 8, 12, 263, DateTimeKind.Local).AddTicks(5678), null, null, null, null, "draft" },
                    { 93, null, new DateTime(2022, 5, 2, 2, 24, 9, 763, DateTimeKind.Local).AddTicks(2888), new DateTime(2022, 6, 7, 12, 55, 40, 900, DateTimeKind.Local).AddTicks(4909), null, null, null, null, "draft" },
                    { 94, null, new DateTime(2022, 12, 27, 21, 6, 9, 965, DateTimeKind.Local).AddTicks(5434), new DateTime(2022, 6, 3, 9, 57, 1, 697, DateTimeKind.Local).AddTicks(4333), null, null, null, null, "draft" },
                    { 95, null, new DateTime(2022, 8, 25, 16, 13, 41, 869, DateTimeKind.Local).AddTicks(5290), new DateTime(2022, 11, 19, 3, 49, 55, 213, DateTimeKind.Local).AddTicks(8794), null, null, null, null, "draft" },
                    { 96, null, new DateTime(2022, 11, 8, 22, 29, 0, 65, DateTimeKind.Local).AddTicks(4452), new DateTime(2022, 10, 5, 15, 55, 50, 56, DateTimeKind.Local).AddTicks(1117), null, null, null, null, "draft" },
                    { 97, null, new DateTime(2022, 12, 13, 3, 0, 0, 318, DateTimeKind.Local).AddTicks(3154), new DateTime(2022, 12, 1, 5, 7, 58, 362, DateTimeKind.Local).AddTicks(5312), null, null, null, null, "draft" },
                    { 98, null, new DateTime(2022, 5, 31, 21, 31, 58, 650, DateTimeKind.Local).AddTicks(1671), new DateTime(2022, 12, 20, 11, 23, 7, 646, DateTimeKind.Local).AddTicks(836), null, null, null, null, "draft" },
                    { 99, null, new DateTime(2022, 12, 19, 7, 44, 58, 731, DateTimeKind.Local).AddTicks(340), new DateTime(2022, 8, 10, 20, 21, 32, 768, DateTimeKind.Local).AddTicks(7626), null, null, null, null, "draft" },
                    { 100, null, new DateTime(2022, 6, 21, 11, 21, 53, 634, DateTimeKind.Local).AddTicks(3764), new DateTime(2023, 1, 14, 6, 40, 47, 317, DateTimeKind.Local).AddTicks(3231), null, null, null, null, "draft" },
                    { 101, null, new DateTime(2022, 4, 25, 12, 29, 47, 557, DateTimeKind.Local).AddTicks(7256), new DateTime(2022, 12, 20, 15, 9, 48, 672, DateTimeKind.Local).AddTicks(988), null, null, null, null, "draft" },
                    { 102, null, new DateTime(2022, 11, 29, 7, 43, 35, 610, DateTimeKind.Local).AddTicks(7876), new DateTime(2023, 2, 20, 3, 11, 21, 529, DateTimeKind.Local).AddTicks(9545), null, null, null, null, "draft" },
                    { 103, null, new DateTime(2023, 3, 13, 21, 19, 29, 922, DateTimeKind.Local).AddTicks(5085), new DateTime(2022, 5, 5, 13, 31, 17, 64, DateTimeKind.Local).AddTicks(1707), null, null, null, null, "draft" },
                    { 104, null, new DateTime(2022, 10, 23, 18, 51, 14, 200, DateTimeKind.Local).AddTicks(3678), new DateTime(2022, 6, 22, 3, 24, 24, 412, DateTimeKind.Local).AddTicks(6948), null, null, null, null, "draft" },
                    { 105, null, new DateTime(2023, 1, 27, 12, 26, 30, 792, DateTimeKind.Local).AddTicks(3911), new DateTime(2022, 11, 7, 19, 3, 3, 202, DateTimeKind.Local).AddTicks(3574), null, null, null, null, "draft" },
                    { 106, null, new DateTime(2022, 7, 3, 20, 11, 24, 12, DateTimeKind.Local).AddTicks(3036), new DateTime(2023, 2, 13, 8, 47, 35, 587, DateTimeKind.Local).AddTicks(8728), null, null, null, null, "draft" },
                    { 107, null, new DateTime(2023, 1, 21, 19, 1, 18, 85, DateTimeKind.Local).AddTicks(2465), new DateTime(2023, 4, 13, 22, 48, 33, 151, DateTimeKind.Local).AddTicks(7505), null, null, null, null, "draft" },
                    { 108, null, new DateTime(2023, 2, 22, 15, 10, 47, 620, DateTimeKind.Local).AddTicks(5679), new DateTime(2023, 1, 5, 8, 45, 7, 867, DateTimeKind.Local).AddTicks(6136), null, null, null, null, "draft" },
                    { 109, null, new DateTime(2022, 5, 6, 7, 34, 24, 436, DateTimeKind.Local).AddTicks(7161), new DateTime(2023, 2, 22, 1, 44, 2, 656, DateTimeKind.Local).AddTicks(5838), null, null, null, null, "draft" },
                    { 110, null, new DateTime(2023, 3, 12, 23, 5, 6, 391, DateTimeKind.Local).AddTicks(5522), new DateTime(2022, 10, 19, 7, 55, 19, 92, DateTimeKind.Local).AddTicks(6809), null, null, null, null, "draft" },
                    { 111, null, new DateTime(2022, 10, 9, 2, 51, 18, 184, DateTimeKind.Local).AddTicks(9743), new DateTime(2022, 6, 19, 7, 40, 9, 595, DateTimeKind.Local).AddTicks(599), null, null, null, null, "draft" },
                    { 112, null, new DateTime(2022, 8, 17, 5, 34, 47, 190, DateTimeKind.Local).AddTicks(3549), new DateTime(2022, 11, 6, 12, 52, 35, 811, DateTimeKind.Local).AddTicks(8360), null, null, null, null, "draft" },
                    { 113, null, new DateTime(2022, 11, 9, 15, 12, 31, 948, DateTimeKind.Local).AddTicks(1140), new DateTime(2022, 5, 9, 20, 33, 18, 522, DateTimeKind.Local).AddTicks(9886), null, null, null, null, "draft" },
                    { 114, null, new DateTime(2022, 5, 7, 20, 4, 36, 558, DateTimeKind.Local).AddTicks(8422), new DateTime(2022, 12, 6, 21, 7, 51, 654, DateTimeKind.Local).AddTicks(8960), null, null, null, null, "draft" },
                    { 115, null, new DateTime(2022, 5, 16, 19, 42, 1, 865, DateTimeKind.Local).AddTicks(2047), new DateTime(2023, 3, 28, 8, 46, 25, 111, DateTimeKind.Local).AddTicks(6633), null, null, null, null, "draft" },
                    { 116, null, new DateTime(2022, 11, 18, 17, 27, 49, 903, DateTimeKind.Local).AddTicks(9676), new DateTime(2023, 3, 8, 9, 5, 44, 247, DateTimeKind.Local).AddTicks(6025), null, null, null, null, "draft" },
                    { 117, null, new DateTime(2022, 8, 10, 16, 56, 53, 180, DateTimeKind.Local).AddTicks(9869), new DateTime(2022, 6, 22, 5, 21, 35, 4, DateTimeKind.Local).AddTicks(4330), null, null, null, null, "draft" },
                    { 118, null, new DateTime(2022, 12, 7, 19, 26, 39, 429, DateTimeKind.Local).AddTicks(4539), new DateTime(2023, 3, 26, 6, 54, 35, 325, DateTimeKind.Local).AddTicks(8484), null, null, null, null, "draft" },
                    { 119, null, new DateTime(2022, 10, 13, 8, 34, 48, 386, DateTimeKind.Local).AddTicks(4976), new DateTime(2022, 5, 28, 13, 57, 42, 476, DateTimeKind.Local).AddTicks(5928), null, null, null, null, "draft" },
                    { 120, null, new DateTime(2022, 8, 31, 12, 8, 10, 90, DateTimeKind.Local).AddTicks(5938), new DateTime(2023, 4, 14, 11, 12, 20, 448, DateTimeKind.Local).AddTicks(6525), null, null, null, null, "draft" },
                    { 121, null, new DateTime(2022, 11, 30, 16, 23, 54, 449, DateTimeKind.Local).AddTicks(6585), new DateTime(2022, 10, 23, 16, 1, 13, 302, DateTimeKind.Local).AddTicks(3841), null, null, null, null, "draft" },
                    { 122, null, new DateTime(2022, 8, 22, 19, 49, 58, 654, DateTimeKind.Local).AddTicks(5785), new DateTime(2023, 2, 2, 19, 30, 6, 416, DateTimeKind.Local).AddTicks(7079), null, null, null, null, "draft" },
                    { 123, null, new DateTime(2022, 9, 3, 5, 57, 58, 951, DateTimeKind.Local).AddTicks(1128), new DateTime(2023, 1, 11, 12, 0, 52, 227, DateTimeKind.Local).AddTicks(1097), null, null, null, null, "draft" },
                    { 124, null, new DateTime(2022, 12, 30, 19, 13, 59, 720, DateTimeKind.Local).AddTicks(4034), new DateTime(2022, 12, 17, 2, 30, 54, 916, DateTimeKind.Local).AddTicks(1031), null, null, null, null, "draft" },
                    { 125, null, new DateTime(2023, 1, 24, 12, 16, 38, 491, DateTimeKind.Local).AddTicks(5023), new DateTime(2022, 9, 11, 11, 6, 18, 532, DateTimeKind.Local).AddTicks(926), null, null, null, null, "draft" },
                    { 126, null, new DateTime(2022, 12, 2, 2, 8, 10, 958, DateTimeKind.Local).AddTicks(9075), new DateTime(2023, 2, 12, 4, 20, 23, 823, DateTimeKind.Local).AddTicks(9902), null, null, null, null, "draft" },
                    { 127, null, new DateTime(2022, 9, 15, 19, 35, 54, 126, DateTimeKind.Local).AddTicks(7555), new DateTime(2022, 12, 19, 1, 46, 2, 291, DateTimeKind.Local).AddTicks(2405), null, null, null, null, "draft" },
                    { 128, null, new DateTime(2022, 7, 24, 2, 8, 56, 881, DateTimeKind.Local).AddTicks(8950), new DateTime(2023, 2, 22, 3, 9, 5, 712, DateTimeKind.Local).AddTicks(2118), null, null, null, null, "draft" },
                    { 129, null, new DateTime(2022, 8, 21, 7, 54, 29, 231, DateTimeKind.Local).AddTicks(2908), new DateTime(2022, 5, 10, 17, 10, 27, 548, DateTimeKind.Local).AddTicks(4986), null, null, null, null, "draft" },
                    { 130, null, new DateTime(2022, 7, 29, 10, 18, 17, 331, DateTimeKind.Local).AddTicks(3885), new DateTime(2023, 2, 19, 23, 5, 39, 149, DateTimeKind.Local).AddTicks(678), null, null, null, null, "draft" },
                    { 131, null, new DateTime(2023, 4, 15, 15, 46, 8, 254, DateTimeKind.Local).AddTicks(8774), new DateTime(2023, 3, 4, 20, 2, 50, 295, DateTimeKind.Local).AddTicks(208), null, null, null, null, "draft" },
                    { 132, null, new DateTime(2022, 5, 24, 6, 1, 50, 297, DateTimeKind.Local).AddTicks(399), new DateTime(2023, 2, 17, 1, 59, 33, 430, DateTimeKind.Local).AddTicks(2777), null, null, null, null, "draft" },
                    { 133, null, new DateTime(2023, 4, 6, 23, 54, 41, 47, DateTimeKind.Local).AddTicks(9406), new DateTime(2022, 8, 13, 9, 25, 7, 514, DateTimeKind.Local).AddTicks(2520), null, null, null, null, "draft" },
                    { 134, null, new DateTime(2022, 10, 21, 14, 10, 10, 156, DateTimeKind.Local).AddTicks(4376), new DateTime(2022, 11, 17, 11, 59, 10, 830, DateTimeKind.Local).AddTicks(3653), null, null, null, null, "draft" },
                    { 135, null, new DateTime(2022, 8, 23, 1, 41, 21, 471, DateTimeKind.Local).AddTicks(8492), new DateTime(2023, 3, 17, 6, 35, 40, 44, DateTimeKind.Local).AddTicks(2723), null, null, null, null, "draft" },
                    { 136, null, new DateTime(2022, 7, 10, 22, 29, 47, 230, DateTimeKind.Local).AddTicks(6697), new DateTime(2023, 3, 26, 15, 56, 9, 709, DateTimeKind.Local).AddTicks(6770), null, null, null, null, "draft" },
                    { 137, null, new DateTime(2022, 10, 9, 11, 55, 20, 315, DateTimeKind.Local).AddTicks(5446), new DateTime(2023, 3, 16, 10, 12, 13, 692, DateTimeKind.Local).AddTicks(4502), null, null, null, null, "draft" },
                    { 138, null, new DateTime(2023, 3, 6, 13, 50, 52, 392, DateTimeKind.Local).AddTicks(5737), new DateTime(2023, 4, 3, 9, 9, 32, 632, DateTimeKind.Local).AddTicks(1414), null, null, null, null, "draft" },
                    { 139, null, new DateTime(2023, 2, 12, 10, 9, 38, 690, DateTimeKind.Local).AddTicks(334), new DateTime(2022, 10, 30, 8, 24, 8, 523, DateTimeKind.Local).AddTicks(1992), null, null, null, null, "draft" },
                    { 140, null, new DateTime(2022, 6, 21, 5, 14, 4, 610, DateTimeKind.Local).AddTicks(2762), new DateTime(2023, 2, 14, 1, 31, 7, 470, DateTimeKind.Local).AddTicks(5575), null, null, null, null, "draft" },
                    { 141, null, new DateTime(2022, 8, 25, 23, 38, 46, 552, DateTimeKind.Local).AddTicks(1391), new DateTime(2022, 9, 6, 15, 53, 9, 392, DateTimeKind.Local).AddTicks(2931), null, null, null, null, "draft" },
                    { 142, null, new DateTime(2023, 2, 28, 7, 10, 40, 912, DateTimeKind.Local).AddTicks(9485), new DateTime(2022, 12, 21, 6, 55, 11, 82, DateTimeKind.Local).AddTicks(6670), null, null, null, null, "draft" },
                    { 143, null, new DateTime(2022, 8, 12, 4, 57, 41, 902, DateTimeKind.Local).AddTicks(3116), new DateTime(2023, 1, 22, 11, 26, 53, 829, DateTimeKind.Local).AddTicks(5332), null, null, null, null, "draft" },
                    { 144, null, new DateTime(2022, 10, 8, 11, 49, 17, 870, DateTimeKind.Local).AddTicks(4035), new DateTime(2022, 12, 8, 13, 30, 18, 639, DateTimeKind.Local).AddTicks(3031), null, null, null, null, "draft" },
                    { 145, null, new DateTime(2023, 3, 17, 1, 32, 5, 872, DateTimeKind.Local).AddTicks(956), new DateTime(2023, 1, 31, 14, 37, 1, 466, DateTimeKind.Local).AddTicks(7997), null, null, null, null, "draft" },
                    { 146, null, new DateTime(2022, 11, 20, 21, 19, 33, 844, DateTimeKind.Local).AddTicks(1159), new DateTime(2022, 9, 20, 13, 43, 48, 587, DateTimeKind.Local).AddTicks(5574), null, null, null, null, "draft" },
                    { 147, null, new DateTime(2023, 2, 15, 1, 58, 52, 894, DateTimeKind.Local).AddTicks(7637), new DateTime(2022, 10, 27, 11, 21, 58, 691, DateTimeKind.Local).AddTicks(852), null, null, null, null, "draft" },
                    { 148, null, new DateTime(2023, 4, 16, 17, 45, 39, 943, DateTimeKind.Local).AddTicks(3395), new DateTime(2023, 1, 13, 18, 40, 31, 904, DateTimeKind.Local).AddTicks(2021), null, null, null, null, "draft" },
                    { 149, null, new DateTime(2022, 9, 17, 8, 18, 50, 754, DateTimeKind.Local).AddTicks(9095), new DateTime(2022, 10, 21, 16, 9, 52, 973, DateTimeKind.Local).AddTicks(8662), null, null, null, null, "draft" },
                    { 150, null, new DateTime(2023, 2, 13, 17, 54, 53, 118, DateTimeKind.Local).AddTicks(3335), new DateTime(2022, 5, 8, 18, 52, 19, 186, DateTimeKind.Local).AddTicks(4271), null, null, null, null, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 12, 12, 25, 673, DateTimeKind.Local).AddTicks(9658), new DateTime(2022, 10, 29, 11, 18, 38, 937, DateTimeKind.Local).AddTicks(9359), "Chrysler" },
                    { 2, new DateTime(2022, 8, 20, 22, 27, 31, 903, DateTimeKind.Local).AddTicks(9631), new DateTime(2022, 11, 10, 23, 8, 55, 623, DateTimeKind.Local).AddTicks(7953), "Polestar" },
                    { 3, new DateTime(2022, 5, 8, 10, 5, 26, 998, DateTimeKind.Local).AddTicks(5330), new DateTime(2023, 3, 11, 23, 13, 48, 859, DateTimeKind.Local).AddTicks(1070), "Ford" },
                    { 4, new DateTime(2023, 4, 7, 11, 27, 57, 212, DateTimeKind.Local).AddTicks(7827), new DateTime(2023, 1, 17, 9, 35, 20, 605, DateTimeKind.Local).AddTicks(914), "Mazda" },
                    { 5, new DateTime(2022, 4, 21, 15, 57, 50, 968, DateTimeKind.Local).AddTicks(9323), new DateTime(2022, 8, 11, 22, 55, 33, 61, DateTimeKind.Local).AddTicks(9744), "Fiat" },
                    { 6, new DateTime(2023, 1, 4, 17, 36, 58, 931, DateTimeKind.Local).AddTicks(4043), new DateTime(2022, 9, 5, 7, 53, 23, 407, DateTimeKind.Local).AddTicks(2528), "Mazda" },
                    { 7, new DateTime(2022, 8, 4, 18, 35, 7, 782, DateTimeKind.Local).AddTicks(1682), new DateTime(2022, 5, 6, 6, 15, 54, 636, DateTimeKind.Local).AddTicks(8838), "Mini" },
                    { 8, new DateTime(2023, 2, 18, 4, 46, 38, 729, DateTimeKind.Local).AddTicks(8640), new DateTime(2022, 11, 29, 12, 15, 27, 831, DateTimeKind.Local).AddTicks(9312), "Bentley" },
                    { 9, new DateTime(2023, 2, 15, 1, 47, 31, 598, DateTimeKind.Local).AddTicks(914), new DateTime(2022, 7, 2, 4, 46, 47, 413, DateTimeKind.Local).AddTicks(619), "Porsche" },
                    { 10, new DateTime(2022, 6, 21, 12, 35, 43, 161, DateTimeKind.Local).AddTicks(7742), new DateTime(2022, 5, 29, 8, 51, 4, 306, DateTimeKind.Local).AddTicks(1315), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 12, 12, 25, 677, DateTimeKind.Local).AddTicks(7724), null, new DateTime(2022, 10, 29, 11, 18, 38, 941, DateTimeKind.Local).AddTicks(7320), "Computers" },
                    { 2, new DateTime(2022, 8, 20, 22, 27, 31, 907, DateTimeKind.Local).AddTicks(7602), null, new DateTime(2022, 11, 10, 23, 8, 55, 627, DateTimeKind.Local).AddTicks(5835), "Shoes" },
                    { 3, new DateTime(2022, 5, 8, 10, 5, 27, 2, DateTimeKind.Local).AddTicks(3152), null, new DateTime(2023, 3, 11, 23, 13, 48, 862, DateTimeKind.Local).AddTicks(8892), "Garden" },
                    { 4, new DateTime(2023, 4, 7, 11, 27, 57, 216, DateTimeKind.Local).AddTicks(5471), null, new DateTime(2023, 1, 17, 9, 35, 20, 608, DateTimeKind.Local).AddTicks(8554), "Baby" },
                    { 5, new DateTime(2022, 4, 21, 15, 57, 50, 972, DateTimeKind.Local).AddTicks(6954), null, new DateTime(2022, 8, 11, 22, 55, 33, 65, DateTimeKind.Local).AddTicks(7373), "Garden" },
                    { 6, new DateTime(2023, 1, 4, 17, 36, 58, 935, DateTimeKind.Local).AddTicks(1670), null, new DateTime(2022, 9, 5, 7, 53, 23, 411, DateTimeKind.Local).AddTicks(154), "Baby" },
                    { 7, new DateTime(2022, 8, 4, 18, 35, 7, 785, DateTimeKind.Local).AddTicks(9307), null, new DateTime(2022, 5, 6, 6, 15, 54, 640, DateTimeKind.Local).AddTicks(6463), "Clothing" },
                    { 8, new DateTime(2023, 2, 18, 4, 46, 38, 733, DateTimeKind.Local).AddTicks(6264), null, new DateTime(2022, 11, 29, 12, 15, 27, 835, DateTimeKind.Local).AddTicks(6935), "Music" },
                    { 9, new DateTime(2023, 2, 15, 1, 47, 31, 601, DateTimeKind.Local).AddTicks(8536), null, new DateTime(2022, 7, 2, 4, 46, 47, 416, DateTimeKind.Local).AddTicks(8240), "Jewelery" },
                    { 10, new DateTime(2022, 6, 21, 12, 35, 43, 165, DateTimeKind.Local).AddTicks(5361), null, new DateTime(2022, 5, 29, 8, 51, 4, 309, DateTimeKind.Local).AddTicks(8934), "Home" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 12, 12, 25, 670, DateTimeKind.Local).AddTicks(1698), new DateTime(2022, 10, 29, 11, 18, 38, 934, DateTimeKind.Local).AddTicks(1431), "Ecuador" },
                    { 2, new DateTime(2022, 8, 20, 22, 27, 31, 900, DateTimeKind.Local).AddTicks(1806), new DateTime(2022, 11, 10, 23, 8, 55, 620, DateTimeKind.Local).AddTicks(54), "Samoa" },
                    { 3, new DateTime(2022, 5, 8, 10, 5, 26, 994, DateTimeKind.Local).AddTicks(7374), new DateTime(2023, 3, 11, 23, 13, 48, 855, DateTimeKind.Local).AddTicks(3112), "Guatemala" },
                    { 4, new DateTime(2023, 4, 7, 11, 27, 57, 208, DateTimeKind.Local).AddTicks(9693), new DateTime(2023, 1, 17, 9, 35, 20, 601, DateTimeKind.Local).AddTicks(2775), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 21, 15, 57, 50, 965, DateTimeKind.Local).AddTicks(1176), new DateTime(2022, 8, 11, 22, 55, 33, 58, DateTimeKind.Local).AddTicks(1595), "Germany" },
                    { 6, new DateTime(2023, 1, 4, 17, 36, 58, 927, DateTimeKind.Local).AddTicks(5891), new DateTime(2022, 9, 5, 7, 53, 23, 403, DateTimeKind.Local).AddTicks(4375), "Niue" },
                    { 7, new DateTime(2022, 8, 4, 18, 35, 7, 778, DateTimeKind.Local).AddTicks(3527), new DateTime(2022, 5, 6, 6, 15, 54, 633, DateTimeKind.Local).AddTicks(682), "Philippines" },
                    { 8, new DateTime(2023, 2, 18, 4, 46, 38, 726, DateTimeKind.Local).AddTicks(483), new DateTime(2022, 11, 29, 12, 15, 27, 828, DateTimeKind.Local).AddTicks(1155), "Benin" },
                    { 9, new DateTime(2023, 2, 15, 1, 47, 31, 594, DateTimeKind.Local).AddTicks(2754), new DateTime(2022, 7, 2, 4, 46, 47, 409, DateTimeKind.Local).AddTicks(2458), "Seychelles" },
                    { 10, new DateTime(2022, 6, 21, 12, 35, 43, 157, DateTimeKind.Local).AddTicks(9578), new DateTime(2022, 5, 29, 8, 51, 4, 302, DateTimeKind.Local).AddTicks(3151), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "PaymentProvider",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 17, 22, 19, 27, 730, DateTimeKind.Local).AddTicks(7111), new DateTime(2023, 4, 17, 22, 19, 27, 730, DateTimeKind.Local).AddTicks(7061), "PayPal" },
                    { 2, new DateTime(2023, 4, 17, 22, 19, 27, 730, DateTimeKind.Local).AddTicks(7120), new DateTime(2023, 4, 17, 22, 19, 27, 730, DateTimeKind.Local).AddTicks(7118), "Bank Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 22, 2, 9, 34, 633, DateTimeKind.Local).AddTicks(490), null, new DateTime(2022, 4, 21, 15, 57, 50, 975, DateTimeKind.Local).AddTicks(8834), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 7, 2, 4, 46, 47, 420, DateTimeKind.Local).AddTicks(272), null, new DateTime(2022, 12, 26, 19, 0, 17, 899, DateTimeKind.Local).AddTicks(7165), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 8, 8, 22, 33, 552, DateTimeKind.Local).AddTicks(3982), null, new DateTime(2022, 4, 20, 4, 40, 6, 52, DateTimeKind.Local).AddTicks(9131), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 24, 16, 52, 14, 950, DateTimeKind.Local).AddTicks(8155), null, new DateTime(2023, 2, 20, 6, 4, 14, 401, DateTimeKind.Local).AddTicks(362), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 18, 16, 47, 55, 553, DateTimeKind.Local).AddTicks(9169), null, new DateTime(2022, 6, 2, 6, 7, 40, 480, DateTimeKind.Local).AddTicks(278), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 26, 0, 59, 21, 184, DateTimeKind.Local).AddTicks(9109), null, new DateTime(2022, 10, 28, 13, 6, 58, 80, DateTimeKind.Local).AddTicks(8239), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 3, 7, 10, 22, 216, DateTimeKind.Local).AddTicks(1423), null, new DateTime(2022, 10, 26, 1, 52, 13, 958, DateTimeKind.Local).AddTicks(3740), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 17, 2, 4, 44, 292, DateTimeKind.Local).AddTicks(5508), null, new DateTime(2023, 2, 12, 20, 32, 57, 788, DateTimeKind.Local).AddTicks(4860), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 10, 20, 45, 34, 835, DateTimeKind.Local).AddTicks(3194), null, new DateTime(2023, 4, 9, 17, 44, 50, 727, DateTimeKind.Local).AddTicks(8493), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 19, 23, 24, 46, 728, DateTimeKind.Local).AddTicks(4791), null, new DateTime(2023, 3, 29, 3, 37, 7, 262, DateTimeKind.Local).AddTicks(4971), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 2, 23, 59, 29, 425, DateTimeKind.Local).AddTicks(142), null, new DateTime(2022, 9, 10, 11, 57, 8, 47, DateTimeKind.Local).AddTicks(849), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 4, 19, 17, 43, 538, DateTimeKind.Local).AddTicks(9586), null, new DateTime(2022, 12, 24, 23, 29, 1, 306, DateTimeKind.Local).AddTicks(3486), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 27, 23, 44, 56, 244, DateTimeKind.Local).AddTicks(4042), null, new DateTime(2022, 5, 26, 17, 58, 56, 243, DateTimeKind.Local).AddTicks(7414), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 5, 31, 21, 31, 58, 646, DateTimeKind.Local).AddTicks(1550), null, new DateTime(2022, 12, 20, 11, 23, 7, 642, DateTimeKind.Local).AddTicks(716), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 27, 12, 26, 30, 788, DateTimeKind.Local).AddTicks(3771), null, new DateTime(2022, 11, 7, 19, 3, 3, 198, DateTimeKind.Local).AddTicks(3435), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 17, 5, 34, 47, 186, DateTimeKind.Local).AddTicks(3346), null, new DateTime(2022, 11, 6, 12, 52, 35, 807, DateTimeKind.Local).AddTicks(8157), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 13, 8, 34, 48, 382, DateTimeKind.Local).AddTicks(4751), null, new DateTime(2022, 5, 28, 13, 57, 42, 472, DateTimeKind.Local).AddTicks(5704), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 12, 2, 2, 8, 10, 954, DateTimeKind.Local).AddTicks(8838), null, new DateTime(2023, 2, 12, 4, 20, 23, 819, DateTimeKind.Local).AddTicks(9666), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 6, 23, 54, 41, 43, DateTimeKind.Local).AddTicks(9151), null, new DateTime(2022, 8, 13, 9, 25, 7, 510, DateTimeKind.Local).AddTicks(2266), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 21, 5, 14, 4, 606, DateTimeKind.Local).AddTicks(2488), null, new DateTime(2023, 2, 14, 1, 31, 7, 466, DateTimeKind.Local).AddTicks(5301), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 15, 1, 58, 52, 890, DateTimeKind.Local).AddTicks(7343), null, new DateTime(2022, 10, 27, 11, 21, 58, 687, DateTimeKind.Local).AddTicks(559), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 21, 14, 44, 31, 253, DateTimeKind.Local).AddTicks(9798), null, new DateTime(2022, 10, 18, 7, 43, 8, 179, DateTimeKind.Local).AddTicks(8398), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 20, 19, 55, 17, 389, DateTimeKind.Local).AddTicks(3870), null, new DateTime(2023, 2, 28, 22, 59, 19, 262, DateTimeKind.Local).AddTicks(6733), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 24, 3, 40, 25, 395, DateTimeKind.Local).AddTicks(8654), null, new DateTime(2022, 7, 13, 16, 23, 57, 658, DateTimeKind.Local).AddTicks(810), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 5, 2, 11, 55, 6, 90, DateTimeKind.Local).AddTicks(1344), null, new DateTime(2022, 9, 7, 17, 52, 41, 76, DateTimeKind.Local).AddTicks(7289), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 18, 15, 16, 34, 430, DateTimeKind.Local).AddTicks(7330), null, new DateTime(2022, 12, 9, 15, 4, 17, 155, DateTimeKind.Local).AddTicks(8345), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 22, 19, 43, 38, 271, DateTimeKind.Local).AddTicks(6121), null, new DateTime(2022, 5, 11, 22, 33, 18, 831, DateTimeKind.Local).AddTicks(422), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 1, 31, 19, 36, 13, 726, DateTimeKind.Local).AddTicks(3308), null, new DateTime(2022, 8, 9, 1, 18, 22, 504, DateTimeKind.Local).AddTicks(8327), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 24, 10, 43, 50, 412, DateTimeKind.Local).AddTicks(6626), null, new DateTime(2023, 1, 7, 20, 6, 27, 852, DateTimeKind.Local).AddTicks(2302), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 12, 3, 22, 51, 440, DateTimeKind.Local).AddTicks(634), null, new DateTime(2022, 7, 6, 0, 30, 12, 31, DateTimeKind.Local).AddTicks(8355), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 8, 4, 28, 47, 330, DateTimeKind.Local).AddTicks(8243), null, new DateTime(2023, 1, 14, 9, 47, 15, 666, DateTimeKind.Local).AddTicks(5373), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 20, 23, 19, 22, 375, DateTimeKind.Local).AddTicks(6738), null, new DateTime(2022, 10, 3, 18, 26, 18, 781, DateTimeKind.Local).AddTicks(3200), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 26, 17, 9, 55, 655, DateTimeKind.Local).AddTicks(4358), null, new DateTime(2022, 8, 6, 19, 5, 56, 544, DateTimeKind.Local).AddTicks(5793), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 16, 18, 17, 30, 553, DateTimeKind.Local).AddTicks(8672), null, new DateTime(2022, 6, 25, 23, 9, 40, 83, DateTimeKind.Local).AddTicks(8199), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 21, 11, 17, 19, 563, DateTimeKind.Local).AddTicks(6698), null, new DateTime(2022, 6, 20, 4, 47, 56, 441, DateTimeKind.Local).AddTicks(5387), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 6, 3, 5, 28, 78, DateTimeKind.Local).AddTicks(4295), null, new DateTime(2022, 9, 18, 20, 47, 43, 647, DateTimeKind.Local).AddTicks(173), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 9, 1, 43, 16, 193, DateTimeKind.Local).AddTicks(6961), null, new DateTime(2022, 12, 13, 16, 45, 48, 72, DateTimeKind.Local).AddTicks(4795), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 21, 18, 0, 8, 52, DateTimeKind.Local).AddTicks(5189), null, new DateTime(2022, 11, 25, 20, 27, 37, 836, DateTimeKind.Local).AddTicks(3865), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 25, 1, 38, 48, 704, DateTimeKind.Local).AddTicks(6709), null, new DateTime(2023, 3, 31, 10, 29, 47, 188, DateTimeKind.Local).AddTicks(1705), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 5, 17, 21, 5, 946, DateTimeKind.Local).AddTicks(592), null, new DateTime(2022, 6, 29, 9, 48, 44, 913, DateTimeKind.Local).AddTicks(4669), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 22, 16, 54, 24, 601, DateTimeKind.Local).AddTicks(671), null, new DateTime(2023, 2, 22, 2, 38, 4, 636, DateTimeKind.Local).AddTicks(9633), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 14, 2, 25, 11, 297, DateTimeKind.Local).AddTicks(7296), null, new DateTime(2022, 10, 27, 0, 42, 10, 661, DateTimeKind.Local).AddTicks(440), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 10, 8, 20, 47, 947, DateTimeKind.Local).AddTicks(6133), null, new DateTime(2022, 6, 12, 2, 36, 20, 467, DateTimeKind.Local).AddTicks(9534), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 5, 17, 58, 41, 543, DateTimeKind.Local).AddTicks(7106), null, new DateTime(2022, 11, 2, 6, 53, 7, 477, DateTimeKind.Local).AddTicks(4966), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 23, 11, 41, 42, 637, DateTimeKind.Local).AddTicks(6638), null, new DateTime(2023, 1, 13, 22, 51, 19, 85, DateTimeKind.Local).AddTicks(625), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 18, 21, 49, 31, 57, DateTimeKind.Local).AddTicks(1790), null, new DateTime(2022, 8, 16, 5, 56, 56, 640, DateTimeKind.Local).AddTicks(4665), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 22, 12, 1, 28, 702, DateTimeKind.Local).AddTicks(8554), null, new DateTime(2022, 12, 3, 3, 45, 22, 349, DateTimeKind.Local).AddTicks(6312), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 14, 7, 23, 40, 15, DateTimeKind.Local).AddTicks(4775), null, new DateTime(2023, 1, 1, 12, 56, 13, 248, DateTimeKind.Local).AddTicks(7204), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 30, 3, 16, 36, 433, DateTimeKind.Local).AddTicks(9601), null, new DateTime(2023, 4, 7, 2, 3, 32, 805, DateTimeKind.Local).AddTicks(298), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 27, 5, 40, 46, 364, DateTimeKind.Local).AddTicks(3190), null, new DateTime(2023, 2, 8, 21, 27, 39, 574, DateTimeKind.Local).AddTicks(9168), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 15, 1, 34, 54, 22, DateTimeKind.Local).AddTicks(6885), null, new DateTime(2022, 6, 21, 4, 57, 54, 112, DateTimeKind.Local).AddTicks(6139), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 28, 5, 42, 49, 141, DateTimeKind.Local).AddTicks(9761), null, new DateTime(2022, 10, 31, 12, 58, 40, 527, DateTimeKind.Local).AddTicks(7222), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 30, 23, 37, 16, 516, DateTimeKind.Local).AddTicks(6572), null, new DateTime(2023, 2, 13, 9, 7, 59, 72, DateTimeKind.Local).AddTicks(7225), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 13, 6, 52, 46, 676, DateTimeKind.Local).AddTicks(3305), null, new DateTime(2022, 8, 20, 4, 35, 48, 966, DateTimeKind.Local).AddTicks(9273), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 8, 16, 48, 16, 599, DateTimeKind.Local).AddTicks(4733), null, new DateTime(2022, 5, 15, 0, 26, 38, 653, DateTimeKind.Local).AddTicks(6935), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 6, 1, 19, 43, 21, 154, DateTimeKind.Local).AddTicks(2294), null, new DateTime(2023, 3, 10, 8, 44, 35, 133, DateTimeKind.Local).AddTicks(2798), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 5, 7, 2, 36, 4, DateTimeKind.Local).AddTicks(4205), null, new DateTime(2023, 1, 23, 0, 6, 20, 116, DateTimeKind.Local).AddTicks(9468), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 25, 8, 3, 54, 378, DateTimeKind.Local).AddTicks(385), null, new DateTime(2022, 12, 4, 11, 35, 30, 861, DateTimeKind.Local).AddTicks(7031), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 4, 1, 8, 41, 20, 798, DateTimeKind.Local).AddTicks(462), null, new DateTime(2022, 8, 5, 11, 9, 1, 461, DateTimeKind.Local).AddTicks(2353), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 17, 0, 46, 47, 11, DateTimeKind.Local).AddTicks(2215), null, new DateTime(2023, 1, 21, 10, 13, 30, 541, DateTimeKind.Local).AddTicks(9487), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 31, 4, 9, 51, 566, DateTimeKind.Local).AddTicks(633), null, new DateTime(2022, 6, 3, 16, 42, 15, 275, DateTimeKind.Local).AddTicks(7995), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 4, 22, 7, 30, 819, DateTimeKind.Local).AddTicks(6877), null, new DateTime(2023, 1, 2, 5, 36, 26, 104, DateTimeKind.Local).AddTicks(3809), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 13, 14, 0, 43, 483, DateTimeKind.Local).AddTicks(7173), null, new DateTime(2023, 1, 13, 4, 2, 53, 751, DateTimeKind.Local).AddTicks(3243), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 18, 0, 18, 29, 660, DateTimeKind.Local).AddTicks(7232), null, new DateTime(2023, 1, 12, 0, 37, 24, 202, DateTimeKind.Local).AddTicks(5083), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 27, 13, 17, 37, 815, DateTimeKind.Local).AddTicks(7950), null, new DateTime(2022, 11, 28, 18, 27, 52, 426, DateTimeKind.Local).AddTicks(8873), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 26, 11, 54, 52, 156, DateTimeKind.Local).AddTicks(283), null, new DateTime(2022, 8, 22, 16, 48, 28, 390, DateTimeKind.Local).AddTicks(4795), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 7, 16, 48, 24, 942, DateTimeKind.Local).AddTicks(9466), null, new DateTime(2023, 2, 3, 4, 29, 8, 365, DateTimeKind.Local).AddTicks(5345), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 11, 30, 22, 57, 47, 329, DateTimeKind.Local).AddTicks(8528), null, new DateTime(2022, 6, 8, 15, 58, 40, 988, DateTimeKind.Local).AddTicks(2643), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 14, 9, 36, 36, 962, DateTimeKind.Local).AddTicks(2870), null, new DateTime(2022, 7, 30, 4, 56, 32, 466, DateTimeKind.Local).AddTicks(5039), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 26, 11, 40, 44, 777, DateTimeKind.Local).AddTicks(5413), null, new DateTime(2022, 12, 1, 10, 1, 59, 180, DateTimeKind.Local).AddTicks(9128), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 11, 23, 19, 46, 95, DateTimeKind.Local).AddTicks(1148), null, new DateTime(2023, 4, 12, 17, 24, 22, 444, DateTimeKind.Local).AddTicks(5619), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 19, 1, 45, 56, 543, DateTimeKind.Local).AddTicks(5085), null, new DateTime(2023, 3, 27, 18, 44, 42, 348, DateTimeKind.Local).AddTicks(9019), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 5, 3, 12, 9, 854, DateTimeKind.Local).AddTicks(8233), null, new DateTime(2023, 2, 5, 11, 15, 1, 499, DateTimeKind.Local).AddTicks(2627), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 3, 6, 48, 17, 72, DateTimeKind.Local).AddTicks(869), null, new DateTime(2022, 11, 6, 6, 42, 52, 343, DateTimeKind.Local).AddTicks(901), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 30, 3, 26, 48, 811, DateTimeKind.Local).AddTicks(6422), null, new DateTime(2022, 6, 26, 23, 12, 48, 173, DateTimeKind.Local).AddTicks(785), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 13, 14, 18, 30, 209, DateTimeKind.Local).AddTicks(317), null, new DateTime(2022, 7, 2, 23, 42, 43, 87, DateTimeKind.Local).AddTicks(4277), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 17, 6, 7, 52, 621, DateTimeKind.Local).AddTicks(5601), null, new DateTime(2022, 7, 19, 11, 47, 20, 196, DateTimeKind.Local).AddTicks(9532), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 20, 19, 55, 40, 421, DateTimeKind.Local).AddTicks(4695), null, new DateTime(2022, 11, 16, 7, 3, 11, 904, DateTimeKind.Local).AddTicks(7904), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 10, 6, 0, 58, 205, DateTimeKind.Local).AddTicks(4710), null, new DateTime(2022, 7, 5, 6, 31, 50, 960, DateTimeKind.Local).AddTicks(1784), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 15, 18, 44, 5, 43, DateTimeKind.Local).AddTicks(5679), null, new DateTime(2023, 1, 22, 7, 7, 30, 812, DateTimeKind.Local).AddTicks(5080), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 26, 0, 11, 49, 275, DateTimeKind.Local).AddTicks(6864), null, new DateTime(2023, 1, 2, 22, 9, 45, 780, DateTimeKind.Local).AddTicks(2224), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 15, 1, 17, 7, 194, DateTimeKind.Local).AddTicks(8158), null, new DateTime(2022, 8, 16, 0, 24, 46, 265, DateTimeKind.Local).AddTicks(5629), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 27, 7, 58, 53, 172, DateTimeKind.Local).AddTicks(3474), null, new DateTime(2022, 7, 19, 7, 43, 23, 181, DateTimeKind.Local).AddTicks(6162), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 3, 16, 0, 58, 610, DateTimeKind.Local).AddTicks(9661), null, new DateTime(2022, 9, 6, 21, 15, 24, 121, DateTimeKind.Local).AddTicks(6430), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 18, 0, 56, 0, 684, DateTimeKind.Local).AddTicks(7807), null, new DateTime(2022, 6, 11, 10, 8, 19, 737, DateTimeKind.Local).AddTicks(9997), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 14, 20, 45, 9, 984, DateTimeKind.Local).AddTicks(3984), null, new DateTime(2022, 7, 9, 1, 27, 20, 362, DateTimeKind.Local).AddTicks(5413), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 12, 10, 10, 56, 674, DateTimeKind.Local).AddTicks(3529), null, new DateTime(2023, 2, 8, 19, 23, 27, 741, DateTimeKind.Local).AddTicks(4677), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 11, 16, 4, 10, 544, DateTimeKind.Local).AddTicks(7254), null, new DateTime(2023, 3, 25, 14, 42, 5, 876, DateTimeKind.Local).AddTicks(6856), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 29, 7, 15, 27, 195, DateTimeKind.Local).AddTicks(1587), null, new DateTime(2023, 3, 5, 21, 36, 19, 999, DateTimeKind.Local).AddTicks(7873), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 3, 12, 24, 48, 788, DateTimeKind.Local).AddTicks(9054), null, new DateTime(2022, 11, 8, 13, 7, 2, 982, DateTimeKind.Local).AddTicks(4447), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 21, 16, 36, 55, 437, DateTimeKind.Local).AddTicks(666), null, new DateTime(2022, 10, 10, 13, 8, 7, 925, DateTimeKind.Local).AddTicks(6910), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 9, 11, 11, 28, 712, DateTimeKind.Local).AddTicks(5999), null, new DateTime(2023, 2, 11, 18, 28, 31, 987, DateTimeKind.Local).AddTicks(4754), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 4, 8, 19, 8, 109, DateTimeKind.Local).AddTicks(2316), null, new DateTime(2022, 6, 26, 11, 19, 19, 522, DateTimeKind.Local).AddTicks(4522), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 21, 6, 8, 47, 747, DateTimeKind.Local).AddTicks(6678), null, new DateTime(2023, 3, 15, 8, 37, 21, 9, DateTimeKind.Local).AddTicks(7267), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 23, 23, 1, 0, 550, DateTimeKind.Local).AddTicks(2480), null, new DateTime(2022, 11, 9, 7, 12, 3, 591, DateTimeKind.Local).AddTicks(7809), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 10, 19, 13, 19, 716, DateTimeKind.Local).AddTicks(5581), null, new DateTime(2022, 5, 14, 1, 34, 4, 527, DateTimeKind.Local).AddTicks(2785), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 22, 14, 43, 4, 184, DateTimeKind.Local).AddTicks(2713), null, new DateTime(2022, 12, 13, 21, 34, 23, 855, DateTimeKind.Local).AddTicks(60), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 13, 4, 31, 0, 575, DateTimeKind.Local).AddTicks(1613), null, new DateTime(2022, 9, 2, 18, 18, 24, 586, DateTimeKind.Local).AddTicks(4201), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 3, 13, 54, 5, 349, DateTimeKind.Local).AddTicks(8470), null, new DateTime(2022, 6, 17, 7, 37, 53, 88, DateTimeKind.Local).AddTicks(9267), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 14, 13, 14, 27, 7, DateTimeKind.Local).AddTicks(125), null, new DateTime(2022, 5, 13, 2, 4, 31, 585, DateTimeKind.Local).AddTicks(6682), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY", "Total" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 29, 11, 18, 38, 951, DateTimeKind.Local).AddTicks(7916), new DateTime(2022, 7, 10, 7, 4, 20, 160, DateTimeKind.Local).AddTicks(1785), 25, 1561151674, null },
                    { 2, 65, new DateTime(2022, 12, 9, 16, 33, 2, 183, DateTimeKind.Local).AddTicks(3722), new DateTime(2022, 5, 8, 10, 5, 27, 12, DateTimeKind.Local).AddTicks(3759), 66, 477524474, null },
                    { 3, 97, new DateTime(2023, 4, 7, 11, 27, 57, 226, DateTimeKind.Local).AddTicks(6076), new DateTime(2023, 1, 17, 9, 35, 20, 618, DateTimeKind.Local).AddTicks(9159), 11, -1900923967, null },
                    { 4, 149, new DateTime(2022, 8, 11, 22, 55, 33, 75, DateTimeKind.Local).AddTicks(7977), new DateTime(2022, 8, 21, 21, 30, 23, 347, DateTimeKind.Local).AddTicks(1240), 33, -861766147, null },
                    { 5, 93, new DateTime(2022, 8, 3, 21, 4, 51, 326, DateTimeKind.Local).AddTicks(7076), new DateTime(2022, 8, 4, 18, 35, 7, 795, DateTimeKind.Local).AddTicks(9901), 29, 1077175293, null },
                    { 6, 15, new DateTime(2023, 2, 18, 4, 46, 38, 743, DateTimeKind.Local).AddTicks(6859), new DateTime(2022, 11, 29, 12, 15, 27, 845, DateTimeKind.Local).AddTicks(7530), 95, 358022260, null },
                    { 7, 26, new DateTime(2022, 7, 2, 4, 46, 47, 426, DateTimeKind.Local).AddTicks(8831), new DateTime(2022, 12, 26, 19, 0, 17, 906, DateTimeKind.Local).AddTicks(5720), 80, -311515450, null },
                    { 8, 133, new DateTime(2022, 9, 26, 21, 6, 57, 920, DateTimeKind.Local).AddTicks(7552), new DateTime(2022, 7, 30, 7, 44, 4, 96, DateTimeKind.Local).AddTicks(9771), 83, -829766990, null },
                    { 9, 3, new DateTime(2022, 4, 20, 21, 29, 23, 174, DateTimeKind.Local).AddTicks(2933), new DateTime(2022, 6, 27, 15, 7, 20, 341, DateTimeKind.Local).AddTicks(2247), 70, -1351120826, null },
                    { 10, 10, new DateTime(2022, 10, 12, 4, 14, 6, 338, DateTimeKind.Local).AddTicks(3885), new DateTime(2022, 10, 8, 5, 3, 43, 761, DateTimeKind.Local).AddTicks(3072), 86, -2123376578, null },
                    { 11, 150, new DateTime(2022, 8, 8, 16, 14, 58, 518, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 11, 27, 19, 34, 21, 842, DateTimeKind.Local).AddTicks(5050), 28, 818779940, null },
                    { 12, 102, new DateTime(2022, 8, 13, 16, 27, 39, 291, DateTimeKind.Local).AddTicks(1940), new DateTime(2022, 10, 27, 7, 56, 31, 761, DateTimeKind.Local).AddTicks(2841), 44, -708976113, null },
                    { 13, 54, new DateTime(2022, 10, 7, 20, 21, 4, 300, DateTimeKind.Local).AddTicks(3317), new DateTime(2023, 2, 15, 2, 8, 28, 832, DateTimeKind.Local).AddTicks(2205), 25, -162003267, null },
                    { 14, 104, new DateTime(2022, 11, 24, 16, 52, 14, 957, DateTimeKind.Local).AddTicks(6738), new DateTime(2023, 2, 20, 6, 4, 14, 407, DateTimeKind.Local).AddTicks(8945), 35, -2132388694, null },
                    { 15, 13, new DateTime(2022, 4, 27, 13, 5, 38, 740, DateTimeKind.Local).AddTicks(6090), new DateTime(2022, 10, 21, 18, 59, 28, 58, DateTimeKind.Local).AddTicks(2202), 95, 399030996, null },
                    { 16, 8, new DateTime(2023, 3, 4, 19, 49, 11, 589, DateTimeKind.Local).AddTicks(928), new DateTime(2023, 1, 29, 12, 42, 12, 305, DateTimeKind.Local).AddTicks(3097), 64, -1620445671, null },
                    { 17, 47, new DateTime(2022, 9, 29, 15, 25, 13, 982, DateTimeKind.Local).AddTicks(2531), new DateTime(2022, 12, 27, 1, 25, 18, 441, DateTimeKind.Local).AddTicks(1341), 9, -1404613794, null },
                    { 18, 132, new DateTime(2022, 7, 1, 8, 6, 1, 487, DateTimeKind.Local).AddTicks(8832), new DateTime(2023, 1, 27, 13, 8, 43, 797, DateTimeKind.Local).AddTicks(7471), 100, 27374846, null },
                    { 19, 27, new DateTime(2022, 11, 12, 8, 32, 1, 989, DateTimeKind.Local).AddTicks(569), new DateTime(2022, 5, 3, 23, 55, 16, 343, DateTimeKind.Local).AddTicks(2581), 11, 939983866, null },
                    { 20, 117, new DateTime(2022, 5, 7, 1, 1, 22, 588, DateTimeKind.Local).AddTicks(6560), new DateTime(2023, 3, 4, 4, 51, 17, 969, DateTimeKind.Local).AddTicks(3981), 41, 1115003167, null },
                    { 21, 49, new DateTime(2023, 3, 26, 0, 59, 21, 191, DateTimeKind.Local).AddTicks(7700), new DateTime(2022, 10, 28, 13, 6, 58, 87, DateTimeKind.Local).AddTicks(6830), 50, 1457343204, null },
                    { 22, 59, new DateTime(2022, 12, 3, 19, 50, 37, 343, DateTimeKind.Local).AddTicks(2933), new DateTime(2023, 4, 15, 3, 44, 26, 789, DateTimeKind.Local).AddTicks(8283), 37, -44120040, null },
                    { 23, 126, new DateTime(2022, 6, 9, 7, 41, 33, 397, DateTimeKind.Local).AddTicks(395), new DateTime(2022, 7, 9, 12, 40, 38, 505, DateTimeKind.Local).AddTicks(5065), 62, 1349221112, null },
                    { 24, 4, new DateTime(2022, 5, 29, 10, 41, 35, 550, DateTimeKind.Local).AddTicks(5645), new DateTime(2023, 1, 25, 10, 49, 49, 282, DateTimeKind.Local).AddTicks(4677), 9, 1534340876, null },
                    { 25, 72, new DateTime(2022, 12, 29, 6, 16, 30, 403, DateTimeKind.Local).AddTicks(9583), new DateTime(2023, 3, 4, 5, 49, 39, 879, DateTimeKind.Local).AddTicks(8026), 88, -1702243012, null },
                    { 26, 56, new DateTime(2022, 10, 26, 13, 28, 3, 952, DateTimeKind.Local).AddTicks(8416), new DateTime(2022, 12, 4, 8, 32, 11, 732, DateTimeKind.Local).AddTicks(5667), 13, 351706632, null },
                    { 27, 46, new DateTime(2023, 3, 23, 22, 29, 11, 749, DateTimeKind.Local).AddTicks(5535), new DateTime(2023, 2, 15, 18, 11, 46, 940, DateTimeKind.Local).AddTicks(6224), 56, 304230361, null },
                    { 28, 66, new DateTime(2022, 7, 17, 2, 4, 44, 299, DateTimeKind.Local).AddTicks(4101), new DateTime(2023, 2, 12, 20, 32, 57, 795, DateTimeKind.Local).AddTicks(3453), 27, -1873525384, null },
                    { 29, 128, new DateTime(2022, 4, 19, 9, 39, 35, 737, DateTimeKind.Local).AddTicks(5135), new DateTime(2022, 12, 22, 19, 51, 20, 297, DateTimeKind.Local).AddTicks(4859), 14, 1100941483, null },
                    { 30, 98, new DateTime(2022, 6, 10, 0, 12, 12, 285, DateTimeKind.Local).AddTicks(7011), new DateTime(2022, 8, 5, 16, 38, 50, 102, DateTimeKind.Local).AddTicks(3556), 99, -1223235506, null },
                    { 31, 82, new DateTime(2022, 8, 9, 19, 13, 49, 447, DateTimeKind.Local).AddTicks(6963), new DateTime(2023, 2, 18, 1, 22, 46, 794, DateTimeKind.Local).AddTicks(3800), 95, -1257908160, null },
                    { 32, 4, new DateTime(2023, 2, 28, 23, 26, 39, 638, DateTimeKind.Local).AddTicks(5650), new DateTime(2023, 3, 21, 16, 44, 6, 554, DateTimeKind.Local).AddTicks(8363), 2, 170444261, null },
                    { 33, 31, new DateTime(2023, 3, 18, 15, 4, 21, 872, DateTimeKind.Local).AddTicks(5905), new DateTime(2022, 5, 14, 22, 46, 11, 647, DateTimeKind.Local).AddTicks(9130), 30, -1751524903, null },
                    { 34, 124, new DateTime(2022, 4, 19, 10, 30, 12, 996, DateTimeKind.Local).AddTicks(8471), new DateTime(2023, 3, 4, 16, 36, 59, 222, DateTimeKind.Local).AddTicks(9785), 48, 581899163, null },
                    { 35, 105, new DateTime(2022, 5, 19, 23, 24, 46, 735, DateTimeKind.Local).AddTicks(3393), new DateTime(2023, 3, 29, 3, 37, 7, 269, DateTimeKind.Local).AddTicks(3572), 85, 888258858, null },
                    { 36, 31, new DateTime(2022, 7, 20, 1, 11, 53, 427, DateTimeKind.Local).AddTicks(4211), new DateTime(2023, 2, 11, 11, 33, 58, 131, DateTimeKind.Local).AddTicks(3647), 32, -2004861024, null },
                    { 37, 103, new DateTime(2022, 8, 28, 16, 19, 22, 235, DateTimeKind.Local).AddTicks(7960), new DateTime(2023, 1, 21, 3, 47, 11, 140, DateTimeKind.Local).AddTicks(3153), 9, -8299363, null },
                    { 38, 86, new DateTime(2023, 1, 19, 15, 56, 58, 445, DateTimeKind.Local).AddTicks(1375), new DateTime(2023, 1, 27, 0, 28, 8, 721, DateTimeKind.Local).AddTicks(6032), 4, 392653345, null },
                    { 39, 91, new DateTime(2023, 2, 10, 23, 36, 56, 341, DateTimeKind.Local).AddTicks(1644), new DateTime(2022, 9, 16, 4, 59, 45, 532, DateTimeKind.Local).AddTicks(4731), 63, -1642579477, null },
                    { 40, 48, new DateTime(2022, 12, 11, 10, 6, 4, 642, DateTimeKind.Local).AddTicks(7312), new DateTime(2022, 10, 4, 16, 36, 16, 122, DateTimeKind.Local).AddTicks(3153), 69, 1524627241, null },
                    { 41, 150, new DateTime(2022, 6, 2, 14, 32, 47, 173, DateTimeKind.Local).AddTicks(4832), new DateTime(2023, 3, 27, 3, 9, 48, 408, DateTimeKind.Local).AddTicks(1675), 18, -1546014382, null },
                    { 42, 125, new DateTime(2022, 8, 4, 19, 17, 43, 545, DateTimeKind.Local).AddTicks(8183), new DateTime(2022, 12, 24, 23, 29, 1, 313, DateTimeKind.Local).AddTicks(2082), 36, 1164144347, null },
                    { 43, 132, new DateTime(2022, 10, 27, 14, 9, 40, 832, DateTimeKind.Local).AddTicks(4231), new DateTime(2023, 1, 2, 0, 45, 9, 130, DateTimeKind.Local).AddTicks(4794), 86, 390049012, null },
                    { 44, 121, new DateTime(2022, 11, 29, 21, 50, 5, 11, DateTimeKind.Local).AddTicks(674), new DateTime(2022, 7, 22, 2, 53, 20, 888, DateTimeKind.Local).AddTicks(3213), 74, 1161863500, null },
                    { 45, 77, new DateTime(2023, 3, 20, 13, 42, 54, 575, DateTimeKind.Local).AddTicks(743), new DateTime(2022, 12, 15, 9, 36, 59, 240, DateTimeKind.Local).AddTicks(4967), 80, 1241913044, null },
                    { 46, 135, new DateTime(2023, 4, 1, 18, 49, 36, 259, DateTimeKind.Local).AddTicks(8634), new DateTime(2022, 7, 27, 11, 8, 12, 266, DateTimeKind.Local).AddTicks(4174), 39, -1416701570, null },
                    { 47, 130, new DateTime(2022, 12, 27, 21, 6, 9, 968, DateTimeKind.Local).AddTicks(3930), new DateTime(2022, 6, 3, 9, 57, 1, 700, DateTimeKind.Local).AddTicks(2829), 97, -1660338323, null },
                    { 48, 62, new DateTime(2022, 11, 8, 22, 29, 0, 68, DateTimeKind.Local).AddTicks(2944), new DateTime(2022, 10, 5, 15, 55, 50, 58, DateTimeKind.Local).AddTicks(9609), 65, -1939784560, null },
                    { 49, 57, new DateTime(2022, 5, 31, 21, 31, 58, 653, DateTimeKind.Local).AddTicks(203), new DateTime(2022, 12, 20, 11, 23, 7, 648, DateTimeKind.Local).AddTicks(9369), 35, -340553138, null },
                    { 50, 103, new DateTime(2022, 6, 21, 11, 21, 53, 637, DateTimeKind.Local).AddTicks(2291), new DateTime(2023, 1, 14, 6, 40, 47, 320, DateTimeKind.Local).AddTicks(1758), 33, 373480222, null },
                    { 51, 49, new DateTime(2022, 11, 29, 7, 43, 35, 613, DateTimeKind.Local).AddTicks(6398), new DateTime(2023, 2, 20, 3, 11, 21, 532, DateTimeKind.Local).AddTicks(8067), 98, -458191703, null },
                    { 52, 143, new DateTime(2022, 10, 23, 18, 51, 14, 203, DateTimeKind.Local).AddTicks(2196), new DateTime(2022, 6, 22, 3, 24, 24, 415, DateTimeKind.Local).AddTicks(5466), 10, -650305318, null },
                    { 53, 67, new DateTime(2022, 7, 3, 20, 11, 24, 15, DateTimeKind.Local).AddTicks(1551), new DateTime(2023, 2, 13, 8, 47, 35, 590, DateTimeKind.Local).AddTicks(7243), 23, 1379611817, null },
                    { 54, 2, new DateTime(2023, 2, 22, 15, 10, 47, 623, DateTimeKind.Local).AddTicks(4189), new DateTime(2023, 1, 5, 8, 45, 7, 870, DateTimeKind.Local).AddTicks(4647), 24, 1390918394, null },
                    { 55, 23, new DateTime(2023, 3, 12, 23, 5, 6, 394, DateTimeKind.Local).AddTicks(3985), new DateTime(2022, 10, 19, 7, 55, 19, 95, DateTimeKind.Local).AddTicks(5272), 95, 1308896747, null },
                    { 56, 125, new DateTime(2022, 8, 17, 5, 34, 47, 193, DateTimeKind.Local).AddTicks(2007), new DateTime(2022, 11, 6, 12, 52, 35, 814, DateTimeKind.Local).AddTicks(6818), 53, 1051688934, null },
                    { 57, 141, new DateTime(2022, 5, 7, 20, 4, 36, 561, DateTimeKind.Local).AddTicks(6874), new DateTime(2022, 12, 6, 21, 7, 51, 657, DateTimeKind.Local).AddTicks(7412), 44, -1630259195, null },
                    { 58, 9, new DateTime(2022, 11, 18, 17, 27, 49, 906, DateTimeKind.Local).AddTicks(8125), new DateTime(2023, 3, 8, 9, 5, 44, 250, DateTimeKind.Local).AddTicks(4474), 93, -246516649, null },
                    { 59, 124, new DateTime(2022, 12, 7, 19, 26, 39, 432, DateTimeKind.Local).AddTicks(2983), new DateTime(2023, 3, 26, 6, 54, 35, 328, DateTimeKind.Local).AddTicks(6927), 69, 1255840142, null },
                    { 60, 134, new DateTime(2022, 8, 31, 12, 8, 10, 93, DateTimeKind.Local).AddTicks(4376), new DateTime(2023, 4, 14, 11, 12, 20, 451, DateTimeKind.Local).AddTicks(4963), 52, -1991592927, null },
                    { 61, 73, new DateTime(2022, 8, 22, 19, 49, 58, 657, DateTimeKind.Local).AddTicks(4218), new DateTime(2023, 2, 2, 19, 30, 6, 419, DateTimeKind.Local).AddTicks(5512), 38, 1101188806, null },
                    { 62, 40, new DateTime(2022, 12, 30, 19, 13, 59, 723, DateTimeKind.Local).AddTicks(2461), new DateTime(2022, 12, 17, 2, 30, 54, 918, DateTimeKind.Local).AddTicks(9458), 63, -1111339147, null },
                    { 63, 90, new DateTime(2022, 12, 2, 2, 8, 10, 961, DateTimeKind.Local).AddTicks(7498), new DateTime(2023, 2, 12, 4, 20, 23, 826, DateTimeKind.Local).AddTicks(8325), 23, -1126099627, null },
                    { 64, 50, new DateTime(2022, 7, 24, 2, 8, 56, 884, DateTimeKind.Local).AddTicks(7369), new DateTime(2023, 2, 22, 3, 9, 5, 715, DateTimeKind.Local).AddTicks(537), 59, 370017687, null },
                    { 65, 141, new DateTime(2022, 7, 29, 10, 18, 17, 334, DateTimeKind.Local).AddTicks(2299), new DateTime(2023, 2, 19, 23, 5, 39, 151, DateTimeKind.Local).AddTicks(9092), 66, -924270339, null },
                    { 66, 19, new DateTime(2022, 5, 24, 6, 1, 50, 299, DateTimeKind.Local).AddTicks(8808), new DateTime(2023, 2, 17, 1, 59, 33, 433, DateTimeKind.Local).AddTicks(1186), 1, 1445683391, null },
                    { 67, 102, new DateTime(2022, 10, 21, 14, 10, 10, 159, DateTimeKind.Local).AddTicks(2780), new DateTime(2022, 11, 17, 11, 59, 10, 833, DateTimeKind.Local).AddTicks(2056), 3, 239415433, null },
                    { 68, 14, new DateTime(2022, 7, 10, 22, 29, 47, 233, DateTimeKind.Local).AddTicks(5095), new DateTime(2023, 3, 26, 15, 56, 9, 712, DateTimeKind.Local).AddTicks(5168), 66, -970272110, null },
                    { 69, 14, new DateTime(2023, 3, 6, 13, 50, 52, 395, DateTimeKind.Local).AddTicks(4128), new DateTime(2023, 4, 3, 9, 9, 32, 634, DateTimeKind.Local).AddTicks(9805), 53, 825846061, null },
                    { 70, 70, new DateTime(2022, 6, 21, 5, 14, 4, 613, DateTimeKind.Local).AddTicks(1149), new DateTime(2023, 2, 14, 1, 31, 7, 473, DateTimeKind.Local).AddTicks(3961), 18, 540808053, null },
                    { 71, 92, new DateTime(2023, 2, 28, 7, 10, 40, 915, DateTimeKind.Local).AddTicks(7867), new DateTime(2022, 12, 21, 6, 55, 11, 85, DateTimeKind.Local).AddTicks(5051), 65, -1801731213, null },
                    { 72, 36, new DateTime(2022, 10, 8, 11, 49, 17, 873, DateTimeKind.Local).AddTicks(2411), new DateTime(2022, 12, 8, 13, 30, 18, 642, DateTimeKind.Local).AddTicks(1407), 69, 935052841, null },
                    { 73, 32, new DateTime(2022, 11, 20, 21, 19, 33, 846, DateTimeKind.Local).AddTicks(9530), new DateTime(2022, 9, 20, 13, 43, 48, 590, DateTimeKind.Local).AddTicks(3944), 9, 742859839, null },
                    { 74, 71, new DateTime(2023, 4, 16, 17, 45, 39, 946, DateTimeKind.Local).AddTicks(1719), new DateTime(2023, 1, 13, 18, 40, 31, 907, DateTimeKind.Local).AddTicks(345), 17, 1153154010, null },
                    { 75, 74, new DateTime(2023, 2, 13, 17, 54, 53, 121, DateTimeKind.Local).AddTicks(1653), new DateTime(2022, 5, 8, 18, 52, 19, 189, DateTimeKind.Local).AddTicks(2589), 59, 351536077, null },
                    { 76, 133, new DateTime(2022, 8, 11, 23, 9, 1, 196, DateTimeKind.Local).AddTicks(6532), new DateTime(2023, 2, 25, 4, 0, 26, 199, DateTimeKind.Local).AddTicks(6294), 78, -1203536804, null },
                    { 77, 48, new DateTime(2022, 8, 21, 14, 44, 31, 260, DateTimeKind.Local).AddTicks(8462), new DateTime(2022, 10, 18, 7, 43, 8, 186, DateTimeKind.Local).AddTicks(7061), 83, -1397030949, null },
                    { 78, 105, new DateTime(2022, 4, 27, 15, 18, 54, 774, DateTimeKind.Local).AddTicks(5805), new DateTime(2023, 2, 6, 21, 49, 48, 460, DateTimeKind.Local).AddTicks(4938), 22, 1034594887, null },
                    { 79, 83, new DateTime(2022, 10, 12, 21, 46, 20, 349, DateTimeKind.Local).AddTicks(3322), new DateTime(2022, 11, 24, 22, 12, 26, 614, DateTimeKind.Local).AddTicks(9878), 12, -429633403, null },
                    { 80, 87, new DateTime(2022, 10, 23, 19, 21, 19, 280, DateTimeKind.Local).AddTicks(3708), new DateTime(2022, 7, 1, 10, 47, 14, 970, DateTimeKind.Local).AddTicks(8122), 99, 1697766591, null },
                    { 81, 20, new DateTime(2022, 12, 19, 8, 46, 32, 710, DateTimeKind.Local).AddTicks(6757), new DateTime(2022, 11, 7, 9, 23, 47, 757, DateTimeKind.Local).AddTicks(4556), 16, 175750933, null },
                    { 82, 30, new DateTime(2022, 5, 27, 12, 16, 44, 567, DateTimeKind.Local).AddTicks(3207), new DateTime(2023, 3, 30, 22, 52, 49, 376, DateTimeKind.Local).AddTicks(8668), 69, -594194442, null },
                    { 83, 129, new DateTime(2022, 11, 1, 23, 10, 9, 629, DateTimeKind.Local).AddTicks(6446), new DateTime(2022, 8, 9, 16, 19, 13, 468, DateTimeKind.Local).AddTicks(5801), 9, -969559657, null },
                    { 84, 133, new DateTime(2022, 11, 24, 3, 40, 25, 402, DateTimeKind.Local).AddTicks(7327), new DateTime(2022, 7, 13, 16, 23, 57, 664, DateTimeKind.Local).AddTicks(9483), 30, -1041114583, null },
                    { 85, 149, new DateTime(2022, 10, 19, 18, 18, 39, 784, DateTimeKind.Local).AddTicks(909), new DateTime(2022, 12, 4, 18, 45, 40, 655, DateTimeKind.Local).AddTicks(9280), 93, -1893666979, null },
                    { 86, 5, new DateTime(2023, 2, 24, 1, 35, 8, 743, DateTimeKind.Local).AddTicks(4825), new DateTime(2022, 11, 25, 8, 32, 41, 625, DateTimeKind.Local).AddTicks(1883), 58, 212914788, null },
                    { 87, 33, new DateTime(2022, 11, 1, 1, 47, 25, 652, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 9, 2, 17, 11, 43, 36, DateTimeKind.Local).AddTicks(7783), 24, 951720828, null },
                    { 88, 92, new DateTime(2023, 1, 9, 5, 48, 22, 524, DateTimeKind.Local).AddTicks(9709), new DateTime(2023, 4, 16, 9, 12, 11, 543, DateTimeKind.Local).AddTicks(3775), 97, 2049630696, null },
                    { 89, 57, new DateTime(2022, 7, 3, 21, 16, 29, 545, DateTimeKind.Local).AddTicks(4190), new DateTime(2022, 8, 25, 19, 30, 18, 305, DateTimeKind.Local).AddTicks(9449), 1, 1448270756, null },
                    { 90, 36, new DateTime(2022, 10, 31, 18, 44, 19, 999, DateTimeKind.Local).AddTicks(4815), new DateTime(2022, 8, 30, 2, 10, 0, 410, DateTimeKind.Local).AddTicks(7193), 56, 1067583264, null },
                    { 91, 91, new DateTime(2022, 11, 18, 15, 16, 34, 437, DateTimeKind.Local).AddTicks(5999), new DateTime(2022, 12, 9, 15, 4, 17, 162, DateTimeKind.Local).AddTicks(7013), 43, 1262335565, null },
                    { 92, 43, new DateTime(2022, 5, 24, 7, 20, 33, 55, DateTimeKind.Local).AddTicks(6325), new DateTime(2023, 1, 22, 23, 54, 5, 266, DateTimeKind.Local).AddTicks(7806), 24, -1085646360, null },
                    { 93, 113, new DateTime(2022, 10, 30, 5, 28, 18, 416, DateTimeKind.Local).AddTicks(5210), new DateTime(2022, 4, 19, 8, 1, 22, 418, DateTimeKind.Local).AddTicks(3304), 16, -20361253, null },
                    { 94, 18, new DateTime(2023, 1, 28, 14, 4, 52, 399, DateTimeKind.Local).AddTicks(2988), new DateTime(2023, 3, 2, 15, 49, 7, 709, DateTimeKind.Local).AddTicks(7301), 9, 1468574351, null },
                    { 95, 141, new DateTime(2023, 2, 1, 10, 5, 41, 62, DateTimeKind.Local).AddTicks(4104), new DateTime(2022, 10, 29, 8, 5, 48, 566, DateTimeKind.Local).AddTicks(1151), 99, 1073175478, null },
                    { 96, 41, new DateTime(2023, 3, 16, 9, 17, 11, 32, DateTimeKind.Local).AddTicks(3102), new DateTime(2022, 10, 25, 19, 12, 48, 170, DateTimeKind.Local).AddTicks(3747), 74, 1756449278, null },
                    { 97, 68, new DateTime(2022, 8, 11, 19, 30, 39, 772, DateTimeKind.Local).AddTicks(2915), new DateTime(2022, 5, 19, 5, 41, 5, 6, DateTimeKind.Local).AddTicks(9651), 59, -1080800074, null },
                    { 98, 113, new DateTime(2023, 1, 31, 19, 36, 13, 733, DateTimeKind.Local).AddTicks(2258), new DateTime(2022, 8, 9, 1, 18, 22, 511, DateTimeKind.Local).AddTicks(7277), 10, 2121756006, null },
                    { 99, 130, new DateTime(2022, 5, 7, 22, 30, 56, 221, DateTimeKind.Local).AddTicks(6573), new DateTime(2022, 4, 28, 3, 10, 8, 439, DateTimeKind.Local).AddTicks(9938), 54, 302006953, null },
                    { 100, 119, new DateTime(2023, 2, 19, 16, 23, 59, 252, DateTimeKind.Local).AddTicks(7172), new DateTime(2022, 5, 5, 22, 37, 53, 141, DateTimeKind.Local).AddTicks(5061), 62, 666535263, null },
                    { 101, 35, new DateTime(2022, 10, 27, 13, 45, 30, 826, DateTimeKind.Local).AddTicks(3162), new DateTime(2023, 1, 31, 6, 32, 43, 412, DateTimeKind.Local).AddTicks(6570), 32, -1692898319, null },
                    { 102, 42, new DateTime(2022, 5, 17, 6, 4, 44, 360, DateTimeKind.Local).AddTicks(7306), new DateTime(2022, 5, 27, 18, 32, 22, 824, DateTimeKind.Local).AddTicks(3372), 15, -1465435008, null },
                    { 103, 100, new DateTime(2022, 8, 20, 22, 6, 7, 779, DateTimeKind.Local).AddTicks(9269), new DateTime(2022, 9, 3, 18, 53, 20, 598, DateTimeKind.Local).AddTicks(7280), 16, 222927204, null },
                    { 104, 149, new DateTime(2022, 5, 25, 20, 51, 59, 667, DateTimeKind.Local).AddTicks(4206), new DateTime(2023, 2, 20, 23, 29, 10, 656, DateTimeKind.Local).AddTicks(2228), 4, -1172973833, null },
                    { 105, 141, new DateTime(2022, 7, 12, 3, 22, 51, 446, DateTimeKind.Local).AddTicks(9280), new DateTime(2022, 7, 6, 0, 30, 12, 38, DateTimeKind.Local).AddTicks(6998), 52, -233339897, null },
                    { 106, 148, new DateTime(2023, 2, 25, 12, 29, 21, 635, DateTimeKind.Local).AddTicks(9769), new DateTime(2022, 11, 23, 17, 35, 32, 866, DateTimeKind.Local).AddTicks(1723), 61, -389649704, null },
                    { 107, 117, new DateTime(2022, 10, 30, 1, 15, 59, 949, DateTimeKind.Local).AddTicks(2866), new DateTime(2023, 1, 26, 9, 18, 15, 561, DateTimeKind.Local).AddTicks(7748), 55, 24887556, null },
                    { 108, 37, new DateTime(2022, 10, 13, 4, 40, 4, 708, DateTimeKind.Local).AddTicks(4257), new DateTime(2023, 2, 5, 9, 12, 46, 697, DateTimeKind.Local).AddTicks(7380), 17, 2079420441, null },
                    { 109, 39, new DateTime(2023, 2, 20, 17, 37, 8, 482, DateTimeKind.Local).AddTicks(9176), new DateTime(2022, 10, 14, 1, 44, 8, 110, DateTimeKind.Local).AddTicks(4014), 78, -2012824542, null },
                    { 110, 132, new DateTime(2022, 12, 17, 6, 48, 25, 503, DateTimeKind.Local).AddTicks(3149), new DateTime(2022, 12, 24, 12, 13, 53, 361, DateTimeKind.Local).AddTicks(6367), 80, -346296980, null },
                    { 111, 119, new DateTime(2022, 7, 16, 14, 18, 51, 503, DateTimeKind.Local).AddTicks(5097), new DateTime(2022, 11, 12, 4, 16, 49, 547, DateTimeKind.Local).AddTicks(6201), 54, -1489718447, null },
                    { 112, 89, new DateTime(2022, 8, 20, 23, 19, 22, 382, DateTimeKind.Local).AddTicks(5378), new DateTime(2022, 10, 3, 18, 26, 18, 788, DateTimeKind.Local).AddTicks(1839), 10, -595802781, null },
                    { 113, 119, new DateTime(2022, 11, 2, 22, 16, 9, 835, DateTimeKind.Local).AddTicks(8985), new DateTime(2022, 8, 12, 13, 24, 44, 486, DateTimeKind.Local).AddTicks(5626), 97, 459373910, null },
                    { 114, 57, new DateTime(2022, 12, 11, 20, 49, 23, 855, DateTimeKind.Local).AddTicks(3640), new DateTime(2022, 12, 19, 11, 8, 39, 787, DateTimeKind.Local).AddTicks(116), 3, 154055536, null },
                    { 115, 12, new DateTime(2022, 8, 16, 22, 27, 6, 709, DateTimeKind.Local).AddTicks(636), new DateTime(2022, 12, 4, 6, 33, 54, 514, DateTimeKind.Local).AddTicks(7244), 9, 475763221, null },
                    { 116, 105, new DateTime(2022, 7, 28, 18, 8, 12, 669, DateTimeKind.Local).AddTicks(1147), new DateTime(2022, 5, 19, 2, 46, 57, 296, DateTimeKind.Local).AddTicks(6065), 81, 55581988, null },
                    { 117, 70, new DateTime(2022, 6, 14, 12, 44, 1, 13, DateTimeKind.Local).AddTicks(5194), new DateTime(2022, 7, 8, 12, 50, 39, 960, DateTimeKind.Local).AddTicks(7424), 16, 629042583, null },
                    { 118, 59, new DateTime(2022, 12, 8, 19, 50, 12, 199, DateTimeKind.Local).AddTicks(5566), new DateTime(2022, 8, 28, 0, 28, 58, 736, DateTimeKind.Local).AddTicks(9219), 84, 1165044375, null },
                    { 119, 68, new DateTime(2023, 1, 16, 18, 17, 30, 560, DateTimeKind.Local).AddTicks(7216), new DateTime(2022, 6, 25, 23, 9, 40, 90, DateTimeKind.Local).AddTicks(6742), 61, 124179576, null },
                    { 120, 107, new DateTime(2022, 12, 28, 9, 12, 5, 796, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 5, 5, 5, 42, 11, 321, DateTimeKind.Local).AddTicks(5834), 24, -1889563501, null },
                    { 121, 140, new DateTime(2023, 1, 13, 15, 42, 8, 103, DateTimeKind.Local).AddTicks(3795), new DateTime(2022, 11, 30, 23, 41, 52, 342, DateTimeKind.Local).AddTicks(2771), 12, 610192904, null },
                    { 122, 125, new DateTime(2023, 2, 14, 3, 45, 18, 811, DateTimeKind.Local).AddTicks(4392), new DateTime(2022, 11, 21, 12, 35, 0, 123, DateTimeKind.Local).AddTicks(6816), 80, 922085776, null },
                    { 123, 124, new DateTime(2022, 11, 14, 14, 0, 41, 608, DateTimeKind.Local).AddTicks(5312), new DateTime(2022, 7, 28, 5, 48, 28, 249, DateTimeKind.Local).AddTicks(140), 91, -1975144322, null },
                    { 124, 145, new DateTime(2022, 10, 15, 17, 23, 25, 451, DateTimeKind.Local).AddTicks(8347), new DateTime(2022, 6, 16, 7, 45, 40, 431, DateTimeKind.Local).AddTicks(5154), 22, 1267851954, null },
                    { 125, 126, new DateTime(2023, 1, 6, 5, 10, 4, 667, DateTimeKind.Local).AddTicks(9071), new DateTime(2022, 8, 29, 17, 49, 33, 739, DateTimeKind.Local).AddTicks(6089), 8, -1283968247, null },
                    { 126, 133, new DateTime(2022, 8, 6, 3, 5, 28, 85, DateTimeKind.Local).AddTicks(2839), new DateTime(2022, 9, 18, 20, 47, 43, 653, DateTimeKind.Local).AddTicks(8716), 75, 1202444677, null },
                    { 127, 123, new DateTime(2023, 3, 20, 1, 49, 55, 970, DateTimeKind.Local).AddTicks(1753), new DateTime(2022, 9, 21, 12, 37, 57, 553, DateTimeKind.Local).AddTicks(5044), 44, -611200452, null },
                    { 128, 81, new DateTime(2023, 3, 14, 1, 28, 35, 489, DateTimeKind.Local).AddTicks(3725), new DateTime(2022, 12, 2, 1, 50, 22, 166, DateTimeKind.Local).AddTicks(115), 13, -565151978, null },
                    { 129, 108, new DateTime(2023, 1, 16, 3, 23, 53, 239, DateTimeKind.Local).AddTicks(9859), new DateTime(2022, 5, 31, 10, 20, 14, 501, DateTimeKind.Local).AddTicks(1990), 78, -1226759173, null },
                    { 130, 52, new DateTime(2023, 3, 3, 15, 48, 55, 420, DateTimeKind.Local).AddTicks(7155), new DateTime(2022, 12, 22, 6, 10, 52, 410, DateTimeKind.Local).AddTicks(3510), 44, -754209018, null },
                    { 131, 66, new DateTime(2022, 6, 4, 23, 52, 48, 142, DateTimeKind.Local).AddTicks(7231), new DateTime(2023, 4, 13, 7, 11, 49, 759, DateTimeKind.Local).AddTicks(5035), 29, -1992455130, null },
                    { 132, 96, new DateTime(2022, 11, 12, 21, 52, 10, 73, DateTimeKind.Local).AddTicks(8740), new DateTime(2022, 8, 28, 9, 39, 45, 280, DateTimeKind.Local).AddTicks(3078), 97, 1003203007, null },
                    { 133, 62, new DateTime(2022, 7, 21, 18, 0, 8, 59, DateTimeKind.Local).AddTicks(3807), new DateTime(2022, 11, 25, 20, 27, 37, 843, DateTimeKind.Local).AddTicks(2482), 95, 515317126, null },
                    { 134, 101, new DateTime(2023, 2, 1, 19, 23, 51, 448, DateTimeKind.Local).AddTicks(1504), new DateTime(2023, 1, 21, 15, 0, 46, 605, DateTimeKind.Local).AddTicks(4570), 44, -1589305737, null },
                    { 135, 103, new DateTime(2022, 5, 8, 22, 10, 51, 223, DateTimeKind.Local).AddTicks(9433), new DateTime(2022, 4, 27, 11, 30, 18, 529, DateTimeKind.Local).AddTicks(4295), 23, -239205209, null },
                    { 136, 91, new DateTime(2023, 1, 5, 16, 39, 15, 717, DateTimeKind.Local).AddTicks(9289), new DateTime(2022, 12, 3, 13, 37, 35, 805, DateTimeKind.Local).AddTicks(8529), 76, -306336294, null },
                    { 137, 8, new DateTime(2022, 5, 5, 20, 31, 8, 333, DateTimeKind.Local).AddTicks(2806), new DateTime(2022, 10, 19, 8, 11, 21, 28, DateTimeKind.Local).AddTicks(929), 74, -772265972, null },
                    { 138, 94, new DateTime(2022, 11, 23, 4, 21, 51, 983, DateTimeKind.Local).AddTicks(4797), new DateTime(2022, 7, 26, 9, 2, 39, 456, DateTimeKind.Local).AddTicks(9826), 72, 1624332752, null },
                    { 139, 144, new DateTime(2022, 12, 13, 10, 22, 3, 716, DateTimeKind.Local).AddTicks(3986), new DateTime(2022, 12, 26, 8, 28, 46, 736, DateTimeKind.Local).AddTicks(1236), 72, 975483047, null },
                    { 140, 103, new DateTime(2022, 9, 5, 17, 21, 5, 952, DateTimeKind.Local).AddTicks(9215), new DateTime(2022, 6, 29, 9, 48, 44, 920, DateTimeKind.Local).AddTicks(3208), 2, -391363456, null },
                    { 141, 67, new DateTime(2022, 9, 2, 16, 32, 57, 167, DateTimeKind.Local).AddTicks(5846), new DateTime(2022, 8, 1, 7, 43, 22, 29, DateTimeKind.Local).AddTicks(773), 39, 1031166032, null },
                    { 142, 106, new DateTime(2022, 5, 9, 0, 28, 26, 993, DateTimeKind.Local).AddTicks(973), new DateTime(2023, 3, 11, 16, 14, 15, 611, DateTimeKind.Local).AddTicks(56), 80, 1376971594, null },
                    { 143, 3, new DateTime(2022, 8, 23, 8, 16, 33, 672, DateTimeKind.Local).AddTicks(9144), new DateTime(2022, 7, 15, 6, 48, 51, 751, DateTimeKind.Local).AddTicks(610), 52, 957890093, null },
                    { 144, 23, new DateTime(2022, 9, 22, 18, 26, 0, 406, DateTimeKind.Local).AddTicks(1963), new DateTime(2022, 8, 9, 14, 39, 36, 517, DateTimeKind.Local).AddTicks(8100), 41, -1458831214, null },
                    { 145, 75, new DateTime(2023, 1, 5, 3, 52, 28, 800, DateTimeKind.Local).AddTicks(4946), new DateTime(2022, 5, 18, 13, 35, 46, 10, DateTimeKind.Local).AddTicks(9662), 16, -1646194563, null },
                    { 146, 140, new DateTime(2022, 5, 15, 14, 29, 39, 779, DateTimeKind.Local).AddTicks(2262), new DateTime(2022, 12, 20, 11, 21, 17, 187, DateTimeKind.Local).AddTicks(8214), 69, -200110780, null },
                    { 147, 2, new DateTime(2022, 8, 14, 2, 25, 11, 304, DateTimeKind.Local).AddTicks(5822), new DateTime(2022, 10, 27, 0, 42, 10, 667, DateTimeKind.Local).AddTicks(8965), 2, 1662718046, null },
                    { 148, 135, new DateTime(2023, 1, 26, 6, 5, 24, 573, DateTimeKind.Local).AddTicks(8979), new DateTime(2022, 10, 1, 4, 29, 30, 255, DateTimeKind.Local).AddTicks(368), 33, -324117766, null },
                    { 149, 22, new DateTime(2022, 9, 16, 13, 15, 49, 751, DateTimeKind.Local).AddTicks(8386), new DateTime(2022, 12, 25, 17, 54, 9, 66, DateTimeKind.Local).AddTicks(8210), 7, 2047515754, null },
                    { 150, 86, new DateTime(2022, 9, 20, 11, 38, 32, 348, DateTimeKind.Local).AddTicks(540), new DateTime(2023, 4, 7, 20, 37, 51, 65, DateTimeKind.Local).AddTicks(4127), 98, 166707639, null },
                    { 151, 128, new DateTime(2022, 4, 23, 12, 30, 49, 336, DateTimeKind.Local).AddTicks(2720), new DateTime(2022, 8, 6, 5, 6, 26, 619, DateTimeKind.Local).AddTicks(814), 11, 143371318, null },
                    { 152, 97, new DateTime(2022, 12, 19, 14, 27, 42, 601, DateTimeKind.Local).AddTicks(5957), new DateTime(2022, 9, 23, 12, 3, 17, 399, DateTimeKind.Local).AddTicks(9102), 98, -54545116, null },
                    { 153, 99, new DateTime(2023, 2, 22, 2, 39, 33, 811, DateTimeKind.Local).AddTicks(7209), new DateTime(2022, 10, 11, 20, 59, 37, 447, DateTimeKind.Local).AddTicks(2270), 40, -1987573137, null },
                    { 154, 105, new DateTime(2023, 3, 5, 17, 58, 41, 550, DateTimeKind.Local).AddTicks(5638), new DateTime(2022, 11, 2, 6, 53, 7, 484, DateTimeKind.Local).AddTicks(3497), 41, -1904312632, null },
                    { 155, 45, new DateTime(2022, 8, 6, 3, 13, 56, 130, DateTimeKind.Local).AddTicks(8541), new DateTime(2022, 7, 5, 15, 21, 2, 607, DateTimeKind.Local).AddTicks(9420), 52, 430057922, null },
                    { 156, 71, new DateTime(2022, 7, 8, 12, 54, 19, 517, DateTimeKind.Local).AddTicks(6466), new DateTime(2022, 9, 6, 7, 4, 54, 732, DateTimeKind.Local).AddTicks(3369), 3, 260386487, null },
                    { 157, 16, new DateTime(2022, 8, 8, 6, 56, 5, 501, DateTimeKind.Local).AddTicks(9755), new DateTime(2023, 1, 13, 4, 32, 18, 304, DateTimeKind.Local).AddTicks(3083), 80, 13835741, null },
                    { 158, 39, new DateTime(2022, 8, 1, 17, 45, 44, 674, DateTimeKind.Local).AddTicks(9593), new DateTime(2022, 9, 14, 19, 12, 46, 988, DateTimeKind.Local).AddTicks(965), 57, -1280566667, null },
                    { 159, 39, new DateTime(2022, 6, 26, 3, 34, 25, 809, DateTimeKind.Local).AddTicks(422), new DateTime(2022, 6, 17, 9, 52, 38, 400, DateTimeKind.Local).AddTicks(289), 93, -1159381743, null },
                    { 160, 34, new DateTime(2022, 12, 10, 14, 15, 12, 157, DateTimeKind.Local).AddTicks(5974), new DateTime(2022, 12, 3, 5, 15, 53, 418, DateTimeKind.Local).AddTicks(3527), 95, 84321905, null },
                    { 161, 17, new DateTime(2023, 3, 18, 21, 49, 31, 64, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 8, 16, 5, 56, 56, 647, DateTimeKind.Local).AddTicks(3198), 69, -1261631322, null },
                    { 162, 107, new DateTime(2023, 2, 25, 14, 8, 52, 977, DateTimeKind.Local).AddTicks(2385), new DateTime(2022, 12, 4, 18, 26, 54, 59, DateTimeKind.Local).AddTicks(6809), 75, 375495240, null },
                    { 163, 20, new DateTime(2022, 7, 2, 17, 54, 10, 403, DateTimeKind.Local).AddTicks(6652), new DateTime(2022, 8, 12, 14, 1, 39, 615, DateTimeKind.Local).AddTicks(6394), 3, 773595677, null },
                    { 164, 119, new DateTime(2023, 4, 17, 19, 42, 36, 971, DateTimeKind.Local).AddTicks(3549), new DateTime(2022, 8, 28, 8, 34, 31, 629, DateTimeKind.Local).AddTicks(2765), 88, -419595815, null },
                    { 165, 56, new DateTime(2022, 5, 22, 0, 29, 16, 805, DateTimeKind.Local).AddTicks(9330), new DateTime(2022, 6, 5, 15, 38, 29, 364, DateTimeKind.Local).AddTicks(9008), 8, -1696587337, null },
                    { 166, 11, new DateTime(2022, 4, 17, 22, 41, 2, 507, DateTimeKind.Local).AddTicks(9440), new DateTime(2023, 2, 28, 0, 40, 16, 17, DateTimeKind.Local).AddTicks(445), 95, 762474319, null },
                    { 167, 85, new DateTime(2022, 9, 14, 0, 3, 29, 705, DateTimeKind.Local).AddTicks(9052), new DateTime(2023, 2, 22, 5, 25, 27, 295, DateTimeKind.Local).AddTicks(2812), 95, 1680057857, null },
                    { 168, 43, new DateTime(2022, 10, 14, 7, 23, 40, 22, DateTimeKind.Local).AddTicks(3342), new DateTime(2023, 1, 1, 12, 56, 13, 255, DateTimeKind.Local).AddTicks(5769), 89, -398926864, null },
                    { 169, 49, new DateTime(2023, 3, 12, 22, 31, 48, 854, DateTimeKind.Local).AddTicks(6320), new DateTime(2022, 5, 18, 8, 52, 47, 941, DateTimeKind.Local).AddTicks(9530), 95, 2072023262, null },
                    { 170, 16, new DateTime(2022, 6, 6, 0, 29, 56, 79, DateTimeKind.Local).AddTicks(5224), new DateTime(2023, 3, 18, 17, 50, 50, 439, DateTimeKind.Local).AddTicks(460), 39, -1464170306, null },
                    { 171, 49, new DateTime(2023, 1, 21, 11, 49, 25, 798, DateTimeKind.Local).AddTicks(7395), new DateTime(2022, 11, 9, 5, 19, 0, 377, DateTimeKind.Local).AddTicks(469), 97, 453501851, null },
                    { 172, 5, new DateTime(2022, 7, 29, 15, 11, 21, 677, DateTimeKind.Local).AddTicks(5877), new DateTime(2023, 2, 27, 22, 58, 5, 753, DateTimeKind.Local).AddTicks(7885), 47, 1196716653, null },
                    { 173, 26, new DateTime(2022, 7, 13, 20, 10, 37, 442, DateTimeKind.Local).AddTicks(8880), new DateTime(2022, 9, 19, 16, 23, 0, 610, DateTimeKind.Local).AddTicks(6608), 26, 487787028, null },
                    { 174, 73, new DateTime(2022, 11, 14, 16, 19, 30, 935, DateTimeKind.Local).AddTicks(3959), new DateTime(2022, 9, 4, 5, 13, 17, 208, DateTimeKind.Local).AddTicks(6043), 32, 80082415, null },
                    { 175, 143, new DateTime(2022, 7, 27, 5, 40, 46, 371, DateTimeKind.Local).AddTicks(1756), new DateTime(2023, 2, 8, 21, 27, 39, 581, DateTimeKind.Local).AddTicks(7733), 12, 507040663, null },
                    { 176, 149, new DateTime(2022, 10, 24, 19, 56, 32, 174, DateTimeKind.Local).AddTicks(2516), new DateTime(2022, 7, 22, 6, 56, 17, 107, DateTimeKind.Local).AddTicks(6183), 12, -1139461795, null },
                    { 177, 76, new DateTime(2022, 7, 24, 0, 45, 44, 40, DateTimeKind.Local).AddTicks(9563), new DateTime(2022, 10, 1, 4, 22, 50, 350, DateTimeKind.Local).AddTicks(5929), 62, 1002866586, null },
                    { 178, 13, new DateTime(2023, 1, 16, 8, 18, 18, 615, DateTimeKind.Local).AddTicks(5895), new DateTime(2022, 4, 30, 5, 4, 5, 839, DateTimeKind.Local).AddTicks(4011), 70, -1192918634, null },
                    { 179, 124, new DateTime(2022, 5, 24, 3, 40, 51, 171, DateTimeKind.Local).AddTicks(7416), new DateTime(2022, 9, 1, 22, 46, 38, 793, DateTimeKind.Local).AddTicks(2506), 51, 2117400358, null },
                    { 180, 85, new DateTime(2022, 8, 16, 19, 43, 7, 328, DateTimeKind.Local).AddTicks(8131), new DateTime(2022, 5, 18, 18, 51, 32, 969, DateTimeKind.Local).AddTicks(4141), 84, -1693017522, null },
                    { 181, 69, new DateTime(2022, 5, 25, 19, 33, 58, 779, DateTimeKind.Local).AddTicks(234), new DateTime(2022, 7, 31, 1, 49, 55, 458, DateTimeKind.Local).AddTicks(2547), 85, 2025133187, null },
                    { 182, 140, new DateTime(2022, 4, 28, 5, 42, 49, 148, DateTimeKind.Local).AddTicks(8331), new DateTime(2022, 10, 31, 12, 58, 40, 534, DateTimeKind.Local).AddTicks(5791), 53, 1497519734, null },
                    { 183, 73, new DateTime(2022, 6, 27, 18, 52, 28, 792, DateTimeKind.Local).AddTicks(6916), new DateTime(2022, 11, 9, 1, 26, 25, 719, DateTimeKind.Local).AddTicks(2928), 91, -1892899847, null },
                    { 184, 102, new DateTime(2022, 4, 30, 10, 29, 5, 265, DateTimeKind.Local).AddTicks(7379), new DateTime(2022, 4, 27, 1, 33, 40, 263, DateTimeKind.Local).AddTicks(7891), 39, 1627095216, null },
                    { 185, 75, new DateTime(2022, 6, 23, 8, 0, 30, 379, DateTimeKind.Local).AddTicks(3484), new DateTime(2022, 4, 30, 22, 18, 39, 292, DateTimeKind.Local).AddTicks(7314), 85, -784789804, null },
                    { 186, 27, new DateTime(2022, 11, 7, 2, 52, 57, 115, DateTimeKind.Local).AddTicks(7632), new DateTime(2023, 2, 14, 21, 21, 7, 239, DateTimeKind.Local).AddTicks(4374), 30, 373606743, null },
                    { 187, 120, new DateTime(2023, 3, 23, 13, 7, 34, 333, DateTimeKind.Local).AddTicks(7018), new DateTime(2022, 10, 18, 22, 54, 25, 492, DateTimeKind.Local).AddTicks(4397), 93, -1587165784, null },
                    { 188, 120, new DateTime(2022, 7, 4, 8, 47, 50, 957, DateTimeKind.Local).AddTicks(5087), new DateTime(2022, 9, 29, 18, 57, 44, 770, DateTimeKind.Local).AddTicks(9484), 59, 505382274, null },
                    { 189, 122, new DateTime(2022, 12, 13, 6, 52, 46, 683, DateTimeKind.Local).AddTicks(1877), new DateTime(2022, 8, 20, 4, 35, 48, 973, DateTimeKind.Local).AddTicks(7844), 28, -1582512504, null },
                    { 190, 115, new DateTime(2023, 1, 28, 20, 41, 23, 647, DateTimeKind.Local).AddTicks(4212), new DateTime(2022, 8, 10, 4, 37, 18, 338, DateTimeKind.Local).AddTicks(6200), 10, -1912239048, null },
                    { 191, 41, new DateTime(2022, 8, 27, 0, 24, 50, 820, DateTimeKind.Local).AddTicks(9357), new DateTime(2023, 1, 31, 1, 6, 4, 744, DateTimeKind.Local).AddTicks(5935), 53, 713403189, null },
                    { 192, 122, new DateTime(2022, 9, 16, 5, 28, 1, 587, DateTimeKind.Local).AddTicks(6971), new DateTime(2022, 6, 19, 22, 32, 37, 531, DateTimeKind.Local).AddTicks(8071), 28, -2132908024, null },
                    { 193, 139, new DateTime(2022, 7, 7, 7, 54, 31, 772, DateTimeKind.Local).AddTicks(6534), new DateTime(2022, 12, 17, 13, 51, 45, 312, DateTimeKind.Local).AddTicks(5728), 86, -414810181, null },
                    { 194, 106, new DateTime(2022, 9, 3, 17, 33, 44, 198, DateTimeKind.Local).AddTicks(4949), new DateTime(2022, 8, 17, 2, 5, 49, 324, DateTimeKind.Local).AddTicks(1905), 75, 2005372614, null },
                    { 195, 109, new DateTime(2022, 7, 2, 16, 48, 52, 141, DateTimeKind.Local).AddTicks(5217), new DateTime(2022, 7, 26, 17, 27, 49, 609, DateTimeKind.Local).AddTicks(3112), 2, 1455637358, null },
                    { 196, 72, new DateTime(2022, 6, 1, 19, 43, 21, 161, DateTimeKind.Local).AddTicks(661), new DateTime(2023, 3, 10, 8, 44, 35, 140, DateTimeKind.Local).AddTicks(1143), 87, -1420232488, null },
                    { 197, 39, new DateTime(2023, 2, 19, 1, 40, 50, 248, DateTimeKind.Local).AddTicks(5585), new DateTime(2022, 9, 21, 11, 6, 18, 602, DateTimeKind.Local).AddTicks(5460), 70, -699116730, null },
                    { 198, 46, new DateTime(2022, 5, 31, 14, 4, 45, 608, DateTimeKind.Local).AddTicks(2867), new DateTime(2023, 3, 19, 19, 4, 58, 57, DateTimeKind.Local).AddTicks(2053), 34, 1308784474, null },
                    { 199, 20, new DateTime(2022, 11, 10, 0, 44, 3, 540, DateTimeKind.Local).AddTicks(9061), new DateTime(2023, 4, 9, 11, 50, 13, 17, DateTimeKind.Local).AddTicks(1481), 29, 1682672446, null },
                    { 200, 35, new DateTime(2022, 5, 27, 7, 4, 19, 250, DateTimeKind.Local).AddTicks(1558), new DateTime(2023, 3, 9, 0, 28, 38, 173, DateTimeKind.Local).AddTicks(438), 54, 1783820386, null },
                    { 201, 37, new DateTime(2022, 8, 28, 4, 25, 36, 638, DateTimeKind.Local).AddTicks(7178), new DateTime(2022, 8, 20, 13, 27, 36, 218, DateTimeKind.Local).AddTicks(1691), 22, 2080471207, null },
                    { 202, 69, new DateTime(2022, 6, 28, 11, 16, 45, 266, DateTimeKind.Local).AddTicks(8301), new DateTime(2022, 9, 20, 0, 40, 35, 187, DateTimeKind.Local).AddTicks(2670), 2, 1862045574, null },
                    { 203, 102, new DateTime(2022, 8, 25, 8, 3, 54, 384, DateTimeKind.Local).AddTicks(8808), new DateTime(2022, 12, 4, 11, 35, 30, 868, DateTimeKind.Local).AddTicks(5476), 20, 1305307222, null },
                    { 204, 74, new DateTime(2022, 6, 21, 4, 24, 45, 508, DateTimeKind.Local).AddTicks(1020), new DateTime(2023, 3, 29, 13, 5, 39, 848, DateTimeKind.Local).AddTicks(667), 98, 667939023, null },
                    { 205, 81, new DateTime(2022, 10, 10, 18, 15, 56, 303, DateTimeKind.Local).AddTicks(5273), new DateTime(2023, 4, 10, 12, 41, 31, 720, DateTimeKind.Local).AddTicks(1750), 40, -908208128, null },
                    { 206, 3, new DateTime(2022, 10, 20, 4, 3, 39, 964, DateTimeKind.Local).AddTicks(6972), new DateTime(2022, 9, 28, 10, 55, 0, 314, DateTimeKind.Local).AddTicks(4062), 66, -1481473883, null },
                    { 207, 105, new DateTime(2023, 3, 30, 7, 20, 32, 516, DateTimeKind.Local).AddTicks(3231), new DateTime(2022, 9, 6, 2, 37, 15, 216, DateTimeKind.Local).AddTicks(334), 5, 1344027644, null },
                    { 208, 90, new DateTime(2023, 2, 27, 17, 22, 41, 65, DateTimeKind.Local).AddTicks(5803), new DateTime(2022, 7, 6, 17, 4, 29, 970, DateTimeKind.Local).AddTicks(3918), 27, -1485863580, null },
                    { 209, 103, new DateTime(2022, 10, 11, 9, 29, 51, 840, DateTimeKind.Local).AddTicks(9694), new DateTime(2022, 9, 3, 7, 57, 3, 781, DateTimeKind.Local).AddTicks(2872), 84, 698660804, null },
                    { 210, 33, new DateTime(2023, 3, 17, 0, 46, 47, 18, DateTimeKind.Local).AddTicks(689), new DateTime(2023, 1, 21, 10, 13, 30, 548, DateTimeKind.Local).AddTicks(7959), 84, -227547652, null },
                    { 211, 88, new DateTime(2022, 11, 29, 19, 31, 21, 646, DateTimeKind.Local).AddTicks(7247), new DateTime(2022, 8, 20, 12, 1, 27, 960, DateTimeKind.Local).AddTicks(7800), 46, -109526940, null },
                    { 212, 77, new DateTime(2023, 3, 9, 19, 27, 45, 730, DateTimeKind.Local).AddTicks(1743), new DateTime(2022, 7, 3, 1, 37, 6, 510, DateTimeKind.Local).AddTicks(8084), 67, -219633443, null },
                    { 213, 58, new DateTime(2022, 8, 31, 21, 27, 2, 919, DateTimeKind.Local).AddTicks(2800), new DateTime(2022, 4, 18, 15, 22, 20, 330, DateTimeKind.Local).AddTicks(4589), 31, 1382441139, null },
                    { 214, 131, new DateTime(2022, 11, 2, 20, 58, 7, 772, DateTimeKind.Local).AddTicks(7475), new DateTime(2023, 2, 5, 11, 55, 42, 535, DateTimeKind.Local).AddTicks(8620), 72, -1312549664, null },
                    { 215, 13, new DateTime(2022, 9, 6, 3, 5, 43, 165, DateTimeKind.Local).AddTicks(9438), new DateTime(2022, 12, 22, 17, 27, 42, 159, DateTimeKind.Local).AddTicks(2699), 75, 9581923, null },
                    { 216, 29, new DateTime(2022, 12, 27, 5, 40, 42, 939, DateTimeKind.Local).AddTicks(5263), new DateTime(2022, 9, 13, 8, 10, 53, 527, DateTimeKind.Local).AddTicks(1486), 41, 1521927434, null },
                    { 217, 130, new DateTime(2022, 10, 4, 22, 7, 30, 826, DateTimeKind.Local).AddTicks(5356), new DateTime(2023, 1, 2, 5, 36, 26, 111, DateTimeKind.Local).AddTicks(2286), 55, -1828368273, null },
                    { 218, 31, new DateTime(2023, 1, 29, 12, 23, 25, 77, DateTimeKind.Local).AddTicks(8055), new DateTime(2023, 2, 12, 6, 26, 52, 907, DateTimeKind.Local).AddTicks(6483), 98, 434397791, null },
                    { 219, 43, new DateTime(2022, 9, 23, 1, 44, 5, 212, DateTimeKind.Local).AddTicks(6704), new DateTime(2023, 3, 23, 0, 49, 43, 91, DateTimeKind.Local).AddTicks(6788), 45, 1257054382, null },
                    { 220, 126, new DateTime(2022, 5, 27, 14, 46, 10, 654, DateTimeKind.Local).AddTicks(7277), new DateTime(2022, 10, 5, 6, 12, 6, 65, DateTimeKind.Local).AddTicks(1464), 64, 105182693, null },
                    { 221, 39, new DateTime(2022, 12, 27, 5, 19, 20, 930, DateTimeKind.Local).AddTicks(7951), new DateTime(2022, 5, 29, 5, 40, 56, 307, DateTimeKind.Local).AddTicks(5558), 60, 403123000, null },
                    { 222, 21, new DateTime(2023, 3, 24, 11, 14, 6, 150, DateTimeKind.Local).AddTicks(1360), new DateTime(2022, 5, 1, 17, 24, 40, 264, DateTimeKind.Local).AddTicks(6714), 97, 1806028681, null },
                    { 223, 49, new DateTime(2022, 6, 3, 23, 6, 19, 191, DateTimeKind.Local).AddTicks(4749), new DateTime(2022, 7, 17, 5, 31, 6, 198, DateTimeKind.Local).AddTicks(5884), 23, 407923535, null },
                    { 224, 116, new DateTime(2022, 6, 18, 0, 18, 29, 667, DateTimeKind.Local).AddTicks(5671), new DateTime(2023, 1, 12, 0, 37, 24, 209, DateTimeKind.Local).AddTicks(3522), 61, 1052729912, null },
                    { 225, 119, new DateTime(2023, 3, 6, 2, 17, 43, 914, DateTimeKind.Local).AddTicks(7455), new DateTime(2022, 7, 1, 3, 28, 52, 997, DateTimeKind.Local).AddTicks(8483), 28, 1584613470, null },
                    { 226, 123, new DateTime(2022, 6, 23, 9, 33, 56, 561, DateTimeKind.Local).AddTicks(490), new DateTime(2023, 3, 10, 23, 9, 40, 311, DateTimeKind.Local).AddTicks(885), 98, 134521113, null },
                    { 227, 68, new DateTime(2022, 9, 29, 2, 9, 23, 915, DateTimeKind.Local).AddTicks(860), new DateTime(2022, 11, 10, 20, 7, 25, 818, DateTimeKind.Local).AddTicks(1911), 17, 419285393, null },
                    { 228, 58, new DateTime(2022, 9, 24, 14, 45, 53, 444, DateTimeKind.Local).AddTicks(8135), new DateTime(2022, 5, 18, 15, 8, 0, 338, DateTimeKind.Local).AddTicks(5628), 31, 1293250257, null },
                    { 229, 12, new DateTime(2022, 7, 27, 1, 46, 26, 421, DateTimeKind.Local).AddTicks(3727), new DateTime(2023, 2, 24, 2, 31, 2, 628, DateTimeKind.Local).AddTicks(3832), 20, 2075949881, null },
                    { 230, 63, new DateTime(2022, 9, 2, 1, 34, 57, 512, DateTimeKind.Local).AddTicks(4569), new DateTime(2022, 11, 21, 6, 2, 51, 63, DateTimeKind.Local).AddTicks(5832), 89, -1023929617, null },
                    { 231, 86, new DateTime(2023, 3, 26, 11, 54, 52, 162, DateTimeKind.Local).AddTicks(8723), new DateTime(2022, 8, 22, 16, 48, 28, 397, DateTimeKind.Local).AddTicks(3234), 80, 1112059763, null },
                    { 232, 70, new DateTime(2022, 9, 21, 4, 57, 23, 378, DateTimeKind.Local).AddTicks(681), new DateTime(2022, 8, 13, 4, 13, 19, 309, DateTimeKind.Local).AddTicks(2464), 34, 157267779, null },
                    { 233, 46, new DateTime(2022, 7, 2, 7, 10, 43, 217, DateTimeKind.Local).AddTicks(2807), new DateTime(2022, 6, 13, 8, 8, 48, 724, DateTimeKind.Local).AddTicks(1465), 45, 1307458041, null },
                    { 234, 15, new DateTime(2022, 9, 27, 3, 30, 54, 399, DateTimeKind.Local).AddTicks(2933), new DateTime(2022, 7, 9, 0, 9, 23, 871, DateTimeKind.Local).AddTicks(6269), 72, 1791933542, null },
                    { 235, 31, new DateTime(2022, 7, 29, 8, 6, 29, 939, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 10, 10, 13, 55, 13, 755, DateTimeKind.Local).AddTicks(7366), 45, 1952838322, null },
                    { 236, 96, new DateTime(2022, 8, 21, 2, 26, 30, 194, DateTimeKind.Local).AddTicks(7056), new DateTime(2022, 6, 13, 19, 52, 37, 19, DateTimeKind.Local).AddTicks(9655), 59, 1606223560, null },
                    { 237, 144, new DateTime(2022, 9, 26, 4, 27, 12, 776, DateTimeKind.Local).AddTicks(3512), new DateTime(2022, 10, 8, 2, 55, 20, 181, DateTimeKind.Local).AddTicks(4660), 76, -2144785105, null },
                    { 238, 104, new DateTime(2022, 11, 30, 22, 57, 47, 336, DateTimeKind.Local).AddTicks(7005), new DateTime(2022, 6, 8, 15, 58, 40, 995, DateTimeKind.Local).AddTicks(1119), 5, 2041500853, null },
                    { 239, 107, new DateTime(2022, 4, 18, 1, 24, 6, 980, DateTimeKind.Local).AddTicks(8569), new DateTime(2022, 11, 20, 20, 17, 48, 856, DateTimeKind.Local).AddTicks(6742), 17, 1545469731, null },
                    { 240, 25, new DateTime(2022, 7, 10, 3, 28, 50, 23, DateTimeKind.Local).AddTicks(1138), new DateTime(2022, 8, 3, 13, 1, 35, 241, DateTimeKind.Local).AddTicks(1570), 76, 1700911331, null },
                    { 241, 131, new DateTime(2022, 4, 23, 14, 4, 1, 978, DateTimeKind.Local).AddTicks(3911), new DateTime(2023, 4, 17, 12, 10, 56, 819, DateTimeKind.Local).AddTicks(3353), 88, -1630180167, null },
                    { 242, 108, new DateTime(2023, 2, 4, 3, 4, 4, 496, DateTimeKind.Local).AddTicks(7536), new DateTime(2023, 3, 12, 12, 6, 3, 518, DateTimeKind.Local).AddTicks(508), 60, -135468786, null },
                    { 243, 143, new DateTime(2022, 8, 4, 8, 2, 5, 431, DateTimeKind.Local).AddTicks(2789), new DateTime(2022, 8, 11, 17, 49, 24, 5, DateTimeKind.Local).AddTicks(6396), 53, -562681620, null },
                    { 244, 16, new DateTime(2022, 6, 23, 7, 52, 26, 490, DateTimeKind.Local).AddTicks(9077), new DateTime(2023, 2, 17, 9, 17, 33, 437, DateTimeKind.Local).AddTicks(7423), 70, 1582832181, null },
                    { 245, 33, new DateTime(2022, 5, 26, 11, 40, 44, 784, DateTimeKind.Local).AddTicks(3883), new DateTime(2022, 12, 1, 10, 1, 59, 187, DateTimeKind.Local).AddTicks(7597), 92, 1508535674, null },
                    { 246, 7, new DateTime(2022, 8, 29, 0, 21, 13, 119, DateTimeKind.Local).AddTicks(1775), new DateTime(2022, 7, 14, 6, 35, 24, 553, DateTimeKind.Local).AddTicks(3147), 91, -2097163639, null },
                    { 247, 141, new DateTime(2022, 8, 12, 0, 3, 50, 364, DateTimeKind.Local).AddTicks(3835), new DateTime(2023, 4, 16, 14, 8, 30, 743, DateTimeKind.Local).AddTicks(3468), 93, -470194051, null },
                    { 248, 23, new DateTime(2023, 4, 10, 23, 53, 28, 662, DateTimeKind.Local).AddTicks(9086), new DateTime(2023, 1, 7, 0, 2, 56, 786, DateTimeKind.Local).AddTicks(800), 10, 509476697, null },
                    { 249, 3, new DateTime(2022, 8, 27, 5, 32, 59, 369, DateTimeKind.Local).AddTicks(5268), new DateTime(2022, 7, 30, 22, 33, 47, 719, DateTimeKind.Local).AddTicks(5381), 44, 1787152474, null },
                    { 250, 99, new DateTime(2023, 1, 15, 8, 35, 27, 803, DateTimeKind.Local).AddTicks(5299), new DateTime(2023, 4, 2, 20, 50, 6, 644, DateTimeKind.Local).AddTicks(9717), 65, 1587339549, null },
                    { 251, 69, new DateTime(2023, 4, 17, 11, 13, 9, 727, DateTimeKind.Local).AddTicks(3091), new DateTime(2023, 3, 15, 0, 34, 31, 393, DateTimeKind.Local).AddTicks(280), 76, 1649450696, null },
                    { 252, 105, new DateTime(2023, 2, 19, 1, 45, 56, 550, DateTimeKind.Local).AddTicks(3554), new DateTime(2023, 3, 27, 18, 44, 42, 355, DateTimeKind.Local).AddTicks(7488), 99, -1662719853, null },
                    { 253, 126, new DateTime(2022, 10, 20, 19, 42, 0, 736, DateTimeKind.Local).AddTicks(8599), new DateTime(2022, 10, 3, 6, 33, 7, 818, DateTimeKind.Local).AddTicks(5192), 90, 1043861393, null },
                    { 254, 60, new DateTime(2022, 6, 29, 12, 17, 1, 385, DateTimeKind.Local).AddTicks(6305), new DateTime(2022, 6, 18, 4, 39, 38, 942, DateTimeKind.Local).AddTicks(3128), 28, 341467515, null },
                    { 255, 34, new DateTime(2023, 3, 21, 11, 42, 35, 400, DateTimeKind.Local).AddTicks(555), new DateTime(2022, 8, 21, 18, 24, 34, 746, DateTimeKind.Local).AddTicks(9732), 24, -1908965363, null },
                    { 256, 30, new DateTime(2023, 4, 16, 3, 53, 25, 89, DateTimeKind.Local).AddTicks(3649), new DateTime(2022, 12, 2, 6, 48, 32, 664, DateTimeKind.Local).AddTicks(2412), 4, 1964634396, null },
                    { 257, 64, new DateTime(2023, 1, 15, 16, 49, 5, 656, DateTimeKind.Local).AddTicks(3822), new DateTime(2022, 8, 10, 17, 27, 17, 498, DateTimeKind.Local).AddTicks(7503), 94, -842388425, null },
                    { 258, 16, new DateTime(2022, 10, 12, 9, 55, 27, 331, DateTimeKind.Local).AddTicks(5228), new DateTime(2023, 1, 13, 8, 39, 42, 497, DateTimeKind.Local).AddTicks(1502), 47, -2033657865, null },
                    { 259, 128, new DateTime(2022, 9, 3, 6, 48, 17, 78, DateTimeKind.Local).AddTicks(9341), new DateTime(2022, 11, 6, 6, 42, 52, 349, DateTimeKind.Local).AddTicks(9372), 97, 47587803, null },
                    { 260, 82, new DateTime(2022, 7, 8, 18, 30, 35, 192, DateTimeKind.Local).AddTicks(7413), new DateTime(2023, 1, 23, 17, 39, 25, 840, DateTimeKind.Local).AddTicks(9314), 5, -2084133233, null },
                    { 261, 94, new DateTime(2023, 3, 9, 3, 26, 36, 630, DateTimeKind.Local).AddTicks(4224), new DateTime(2023, 1, 13, 14, 25, 32, 638, DateTimeKind.Local).AddTicks(2851), 78, 1887192371, null },
                    { 262, 73, new DateTime(2023, 4, 15, 20, 38, 45, 654, DateTimeKind.Local).AddTicks(715), new DateTime(2023, 4, 5, 5, 52, 55, 266, DateTimeKind.Local).AddTicks(6184), 66, -1411276545, null },
                    { 263, 122, new DateTime(2022, 10, 25, 2, 39, 28, 480, DateTimeKind.Local).AddTicks(2034), new DateTime(2022, 11, 13, 14, 12, 56, 433, DateTimeKind.Local).AddTicks(8595), 22, -779318261, null },
                    { 264, 90, new DateTime(2023, 4, 15, 15, 57, 24, 536, DateTimeKind.Local).AddTicks(145), new DateTime(2022, 9, 25, 12, 37, 36, 108, DateTimeKind.Local).AddTicks(1363), 59, -366372905, null },
                    { 265, 95, new DateTime(2023, 2, 18, 0, 31, 29, 753, DateTimeKind.Local).AddTicks(5159), new DateTime(2022, 9, 26, 2, 25, 8, 468, DateTimeKind.Local).AddTicks(935), 46, -252976280, null },
                    { 266, 71, new DateTime(2022, 9, 13, 14, 18, 30, 215, DateTimeKind.Local).AddTicks(8790), new DateTime(2022, 7, 2, 23, 42, 43, 94, DateTimeKind.Local).AddTicks(2749), 45, -172899324, null },
                    { 267, 35, new DateTime(2022, 9, 20, 0, 46, 52, 726, DateTimeKind.Local).AddTicks(4648), new DateTime(2022, 11, 16, 10, 53, 0, 745, DateTimeKind.Local).AddTicks(3134), 33, 949354641, null },
                    { 268, 54, new DateTime(2022, 7, 4, 15, 31, 17, 720, DateTimeKind.Local).AddTicks(3373), new DateTime(2022, 8, 7, 18, 27, 5, 265, DateTimeKind.Local).AddTicks(9081), 78, -1599162340, null },
                    { 269, 127, new DateTime(2022, 6, 1, 6, 39, 1, 322, DateTimeKind.Local).AddTicks(4762), new DateTime(2022, 11, 18, 21, 53, 1, 853, DateTimeKind.Local).AddTicks(465), 45, 1032655133, null },
                    { 270, 112, new DateTime(2022, 7, 30, 20, 58, 0, 105, DateTimeKind.Local).AddTicks(7969), new DateTime(2022, 11, 4, 5, 2, 8, 547, DateTimeKind.Local).AddTicks(8482), 9, 2102369794, null },
                    { 271, 33, new DateTime(2022, 10, 27, 12, 19, 56, 432, DateTimeKind.Local).AddTicks(9831), new DateTime(2022, 8, 21, 1, 52, 19, 465, DateTimeKind.Local).AddTicks(3826), 43, 1187160340, null },
                    { 272, 14, new DateTime(2022, 8, 13, 7, 47, 16, 769, DateTimeKind.Local).AddTicks(1482), new DateTime(2022, 12, 5, 13, 54, 49, 788, DateTimeKind.Local).AddTicks(2265), 63, -547676936, null },
                    { 273, 10, new DateTime(2022, 4, 20, 19, 55, 40, 428, DateTimeKind.Local).AddTicks(3169), new DateTime(2022, 11, 16, 7, 3, 11, 911, DateTimeKind.Local).AddTicks(6377), 85, 268426377, null },
                    { 274, 33, new DateTime(2022, 7, 4, 7, 0, 40, 413, DateTimeKind.Local).AddTicks(5668), new DateTime(2022, 12, 28, 1, 46, 22, 125, DateTimeKind.Local).AddTicks(6233), 39, -114235592, null },
                    { 275, 48, new DateTime(2022, 5, 11, 9, 54, 58, 674, DateTimeKind.Local).AddTicks(63), new DateTime(2022, 11, 12, 21, 7, 42, 71, DateTimeKind.Local).AddTicks(4672), 4, 1868210223, null },
                    { 276, 89, new DateTime(2023, 1, 12, 20, 54, 53, 757, DateTimeKind.Local).AddTicks(5101), new DateTime(2022, 6, 8, 21, 52, 39, 782, DateTimeKind.Local).AddTicks(8079), 91, 155799701, null },
                    { 277, 118, new DateTime(2022, 4, 26, 2, 55, 26, 448, DateTimeKind.Local).AddTicks(8348), new DateTime(2022, 7, 23, 5, 8, 43, 921, DateTimeKind.Local).AddTicks(6138), 3, 1110512970, null },
                    { 278, 90, new DateTime(2022, 10, 27, 4, 49, 11, 232, DateTimeKind.Local).AddTicks(4609), new DateTime(2022, 8, 2, 19, 38, 47, 223, DateTimeKind.Local).AddTicks(2778), 72, -1528253087, null },
                    { 279, 107, new DateTime(2023, 2, 26, 16, 45, 17, 724, DateTimeKind.Local).AddTicks(2738), new DateTime(2023, 1, 25, 22, 2, 2, 790, DateTimeKind.Local).AddTicks(3395), 92, -143424787, null },
                    { 280, 141, new DateTime(2023, 2, 15, 18, 44, 5, 50, DateTimeKind.Local).AddTicks(4152), new DateTime(2023, 1, 22, 7, 7, 30, 819, DateTimeKind.Local).AddTicks(3553), 1, -1623237783, null },
                    { 281, 32, new DateTime(2022, 9, 21, 13, 40, 19, 389, DateTimeKind.Local).AddTicks(2166), new DateTime(2022, 7, 31, 13, 6, 48, 291, DateTimeKind.Local).AddTicks(517), 56, 698302828, null },
                    { 282, 56, new DateTime(2022, 12, 24, 20, 52, 25, 540, DateTimeKind.Local).AddTicks(5787), new DateTime(2023, 1, 23, 17, 31, 31, 13, DateTimeKind.Local).AddTicks(1193), 37, 944888905, null },
                    { 283, 87, new DateTime(2022, 11, 30, 8, 32, 56, 307, DateTimeKind.Local).AddTicks(5933), new DateTime(2022, 7, 11, 2, 23, 59, 92, DateTimeKind.Local).AddTicks(2715), 6, 613596935, null },
                    { 284, 44, new DateTime(2022, 9, 30, 14, 9, 12, 677, DateTimeKind.Local).AddTicks(2249), new DateTime(2022, 6, 17, 22, 13, 33, 587, DateTimeKind.Local).AddTicks(8064), 82, -558807020, null },
                    { 285, 93, new DateTime(2022, 8, 28, 18, 10, 49, 5, DateTimeKind.Local).AddTicks(8061), new DateTime(2022, 6, 15, 19, 5, 42, 582, DateTimeKind.Local).AddTicks(3109), 96, -155389191, null },
                    { 286, 142, new DateTime(2022, 8, 25, 8, 3, 30, 301, DateTimeKind.Local).AddTicks(4444), new DateTime(2023, 1, 16, 1, 27, 46, 425, DateTimeKind.Local).AddTicks(8766), 12, 1649966717, null },
                    { 287, 43, new DateTime(2022, 10, 15, 1, 17, 7, 201, DateTimeKind.Local).AddTicks(6638), new DateTime(2022, 8, 16, 0, 24, 46, 272, DateTimeKind.Local).AddTicks(4108), 59, 999924332, null },
                    { 288, 85, new DateTime(2022, 12, 28, 7, 28, 11, 754, DateTimeKind.Local).AddTicks(2972), new DateTime(2023, 3, 13, 23, 13, 22, 547, DateTimeKind.Local).AddTicks(7073), 8, -144240926, null },
                    { 289, 106, new DateTime(2022, 6, 2, 19, 33, 12, 848, DateTimeKind.Local).AddTicks(1995), new DateTime(2022, 8, 7, 2, 20, 20, 685, DateTimeKind.Local).AddTicks(1360), 15, -225360031, null },
                    { 290, 83, new DateTime(2022, 10, 19, 13, 54, 43, 422, DateTimeKind.Local).AddTicks(7240), new DateTime(2022, 8, 22, 21, 32, 52, 403, DateTimeKind.Local).AddTicks(6294), 2, -1867244415, null },
                    { 291, 113, new DateTime(2022, 8, 12, 19, 46, 47, 23, DateTimeKind.Local).AddTicks(3478), new DateTime(2023, 2, 23, 23, 18, 8, 42, DateTimeKind.Local).AddTicks(6825), 48, 1358037245, null },
                    { 292, 106, new DateTime(2022, 5, 25, 17, 46, 25, 693, DateTimeKind.Local).AddTicks(4941), new DateTime(2022, 9, 2, 4, 15, 14, 428, DateTimeKind.Local).AddTicks(3988), 22, 1086591029, null },
                    { 293, 46, new DateTime(2023, 1, 10, 9, 41, 18, 405, DateTimeKind.Local).AddTicks(3746), new DateTime(2022, 11, 28, 2, 10, 21, 473, DateTimeKind.Local).AddTicks(9070), 17, -248773659, null },
                    { 294, 50, new DateTime(2023, 3, 3, 16, 0, 58, 617, DateTimeKind.Local).AddTicks(8141), new DateTime(2022, 9, 6, 21, 15, 24, 128, DateTimeKind.Local).AddTicks(4911), 30, -109320287, null },
                    { 295, 48, new DateTime(2023, 3, 3, 1, 25, 50, 800, DateTimeKind.Local).AddTicks(11), new DateTime(2023, 3, 20, 6, 0, 30, 907, DateTimeKind.Local).AddTicks(8039), 57, 728817437, null },
                    { 296, 97, new DateTime(2023, 2, 21, 19, 51, 54, 260, DateTimeKind.Local).AddTicks(302), new DateTime(2022, 10, 19, 22, 42, 47, 27, DateTimeKind.Local).AddTicks(7993), 87, -1249096574, null },
                    { 297, 43, new DateTime(2022, 9, 3, 19, 4, 42, 853, DateTimeKind.Local).AddTicks(8227), new DateTime(2023, 3, 8, 21, 24, 21, 427, DateTimeKind.Local).AddTicks(8943), 28, 849160927, null },
                    { 298, 128, new DateTime(2022, 6, 24, 3, 48, 40, 315, DateTimeKind.Local).AddTicks(5472), new DateTime(2022, 11, 19, 2, 52, 6, 671, DateTimeKind.Local).AddTicks(2697), 42, 2013877781, null },
                    { 299, 148, new DateTime(2022, 12, 5, 9, 26, 17, 155, DateTimeKind.Local).AddTicks(8748), new DateTime(2022, 12, 6, 4, 2, 4, 518, DateTimeKind.Local).AddTicks(5900), 13, 1426747771, null },
                    { 300, 76, new DateTime(2023, 4, 4, 17, 36, 52, 297, DateTimeKind.Local).AddTicks(7810), new DateTime(2022, 5, 30, 7, 35, 13, 103, DateTimeKind.Local).AddTicks(6268), 27, -380950004, null },
                    { 301, 133, new DateTime(2022, 10, 14, 20, 45, 9, 991, DateTimeKind.Local).AddTicks(2457), new DateTime(2022, 7, 9, 1, 27, 20, 369, DateTimeKind.Local).AddTicks(3885), 39, -1818709895, null },
                    { 302, 138, new DateTime(2022, 7, 1, 6, 38, 33, 50, DateTimeKind.Local).AddTicks(2932), new DateTime(2022, 6, 22, 6, 0, 21, 523, DateTimeKind.Local).AddTicks(1121), 30, -836284406, null },
                    { 303, 40, new DateTime(2023, 3, 1, 1, 12, 20, 295, DateTimeKind.Local).AddTicks(6162), new DateTime(2022, 8, 6, 4, 31, 48, 61, DateTimeKind.Local).AddTicks(6880), 58, -494510217, null },
                    { 304, 63, new DateTime(2022, 7, 3, 16, 2, 26, 43, DateTimeKind.Local).AddTicks(8666), new DateTime(2022, 6, 18, 11, 31, 13, 911, DateTimeKind.Local).AddTicks(380), 43, -1382110938, null },
                    { 305, 28, new DateTime(2022, 6, 3, 3, 34, 12, 847, DateTimeKind.Local).AddTicks(3983), new DateTime(2022, 5, 12, 20, 50, 48, 120, DateTimeKind.Local).AddTicks(9804), 60, 462016955, null },
                    { 306, 119, new DateTime(2023, 1, 31, 1, 38, 41, 489, DateTimeKind.Local).AddTicks(5387), new DateTime(2022, 12, 24, 14, 10, 12, 41, DateTimeKind.Local).AddTicks(8484), 9, -888628503, null },
                    { 307, 129, new DateTime(2023, 1, 11, 3, 18, 20, 493, DateTimeKind.Local).AddTicks(7255), new DateTime(2022, 12, 23, 18, 16, 20, 648, DateTimeKind.Local).AddTicks(120), 49, 476545640, null },
                    { 308, 115, new DateTime(2022, 12, 11, 16, 4, 10, 551, DateTimeKind.Local).AddTicks(5738), new DateTime(2023, 3, 25, 14, 42, 5, 883, DateTimeKind.Local).AddTicks(5339), 97, 421276242, null },
                    { 309, 37, new DateTime(2022, 8, 9, 1, 10, 35, 643, DateTimeKind.Local).AddTicks(5269), new DateTime(2022, 4, 25, 6, 48, 1, 339, DateTimeKind.Local).AddTicks(2751), 29, -2001345585, null },
                    { 310, 57, new DateTime(2023, 2, 5, 1, 6, 0, 57, DateTimeKind.Local).AddTicks(2136), new DateTime(2022, 12, 9, 12, 45, 32, 667, DateTimeKind.Local).AddTicks(6729), 14, 1202985195, null },
                    { 311, 120, new DateTime(2022, 10, 5, 12, 18, 24, 438, DateTimeKind.Local).AddTicks(3232), new DateTime(2023, 2, 22, 2, 38, 11, 971, DateTimeKind.Local).AddTicks(9317), 49, 99321669, null },
                    { 312, 18, new DateTime(2022, 4, 21, 22, 10, 24, 252, DateTimeKind.Local).AddTicks(768), new DateTime(2022, 8, 3, 13, 17, 16, 218, DateTimeKind.Local).AddTicks(434), 72, 698221758, null },
                    { 313, 81, new DateTime(2022, 7, 11, 16, 10, 35, 590, DateTimeKind.Local).AddTicks(1679), new DateTime(2023, 3, 21, 6, 26, 41, 334, DateTimeKind.Local).AddTicks(1525), 20, -639301082, null },
                    { 314, 16, new DateTime(2022, 6, 30, 1, 55, 16, 64, DateTimeKind.Local).AddTicks(5220), new DateTime(2022, 9, 10, 6, 47, 18, 751, DateTimeKind.Local).AddTicks(4619), 63, 2008683413, null },
                    { 315, 30, new DateTime(2023, 1, 3, 12, 24, 48, 795, DateTimeKind.Local).AddTicks(7288), new DateTime(2022, 11, 8, 13, 7, 2, 989, DateTimeKind.Local).AddTicks(2670), 68, -788161476, null },
                    { 316, 73, new DateTime(2022, 6, 8, 17, 28, 48, 458, DateTimeKind.Local).AddTicks(1415), new DateTime(2022, 6, 23, 19, 26, 30, 643, DateTimeKind.Local).AddTicks(1346), 66, -167186286, null },
                    { 317, 11, new DateTime(2022, 11, 17, 11, 36, 39, 643, DateTimeKind.Local).AddTicks(3866), new DateTime(2023, 2, 11, 9, 10, 32, 475, DateTimeKind.Local).AddTicks(6075), 92, 1505367369, null },
                    { 318, 122, new DateTime(2022, 8, 6, 13, 29, 16, 881, DateTimeKind.Local).AddTicks(3723), new DateTime(2023, 1, 27, 15, 46, 22, 790, DateTimeKind.Local).AddTicks(5709), 73, -864105041, null },
                    { 319, 78, new DateTime(2022, 11, 6, 19, 50, 19, 658, DateTimeKind.Local).AddTicks(6427), new DateTime(2023, 1, 3, 14, 55, 3, 461, DateTimeKind.Local).AddTicks(1859), 99, -1277032698, null },
                    { 320, 10, new DateTime(2022, 9, 13, 5, 14, 12, 592, DateTimeKind.Local).AddTicks(6296), new DateTime(2022, 12, 3, 12, 5, 7, 72, DateTimeKind.Local).AddTicks(5936), 26, 1024845871, null },
                    { 321, 85, new DateTime(2023, 3, 4, 15, 21, 22, 336, DateTimeKind.Local).AddTicks(9540), new DateTime(2022, 11, 12, 12, 55, 57, 572, DateTimeKind.Local).AddTicks(9281), 87, -1065011870, null },
                    { 322, 41, new DateTime(2022, 11, 9, 11, 11, 28, 719, DateTimeKind.Local).AddTicks(4212), new DateTime(2023, 2, 11, 18, 28, 31, 994, DateTimeKind.Local).AddTicks(2965), 100, -2075422273, null },
                    { 323, 14, new DateTime(2022, 12, 26, 13, 5, 22, 302, DateTimeKind.Local).AddTicks(7985), new DateTime(2022, 5, 9, 13, 46, 26, 833, DateTimeKind.Local).AddTicks(653), 45, 1466156797, null },
                    { 324, 114, new DateTime(2022, 8, 4, 12, 26, 35, 128, DateTimeKind.Local).AddTicks(2559), new DateTime(2023, 4, 15, 10, 57, 43, 812, DateTimeKind.Local).AddTicks(8540), 9, 1966916620, null },
                    { 325, 108, new DateTime(2023, 1, 21, 22, 5, 6, 51, DateTimeKind.Local).AddTicks(436), new DateTime(2022, 8, 22, 20, 45, 12, 789, DateTimeKind.Local).AddTicks(9354), 95, 1020844115, null },
                    { 326, 122, new DateTime(2022, 4, 25, 8, 14, 11, 593, DateTimeKind.Local).AddTicks(9097), new DateTime(2022, 11, 28, 16, 0, 1, 359, DateTimeKind.Local).AddTicks(2827), 71, -2078430356, null },
                    { 327, 83, new DateTime(2023, 3, 17, 12, 9, 13, 643, DateTimeKind.Local).AddTicks(795), new DateTime(2023, 3, 9, 11, 1, 24, 737, DateTimeKind.Local).AddTicks(2058), 84, -1871809596, null },
                    { 328, 78, new DateTime(2022, 12, 12, 0, 24, 11, 171, DateTimeKind.Local).AddTicks(4458), new DateTime(2022, 9, 6, 17, 1, 37, 271, DateTimeKind.Local).AddTicks(6896), 67, -868029892, null },
                    { 329, 138, new DateTime(2022, 9, 21, 6, 8, 47, 754, DateTimeKind.Local).AddTicks(4981), new DateTime(2023, 3, 15, 8, 37, 21, 16, DateTimeKind.Local).AddTicks(5570), 61, 1659669437, null },
                    { 330, 65, new DateTime(2022, 6, 21, 1, 18, 44, 381, DateTimeKind.Local).AddTicks(3365), new DateTime(2022, 8, 26, 17, 15, 4, 456, DateTimeKind.Local).AddTicks(2907), 36, 1379923253, null },
                    { 331, 36, new DateTime(2022, 7, 22, 18, 55, 43, 91, DateTimeKind.Local).AddTicks(120), new DateTime(2022, 8, 28, 8, 59, 15, 484, DateTimeKind.Local).AddTicks(9083), 64, 1673008564, null },
                    { 332, 114, new DateTime(2023, 3, 1, 11, 27, 9, 942, DateTimeKind.Local).AddTicks(9136), new DateTime(2023, 1, 23, 4, 37, 58, 375, DateTimeKind.Local).AddTicks(9709), 51, 1649614427, null },
                    { 333, 66, new DateTime(2022, 12, 12, 21, 0, 2, 835, DateTimeKind.Local).AddTicks(8709), new DateTime(2022, 10, 3, 11, 50, 41, 537, DateTimeKind.Local).AddTicks(6733), 82, -1470406973, null },
                    { 334, 142, new DateTime(2022, 8, 17, 2, 5, 26, 709, DateTimeKind.Local).AddTicks(3739), new DateTime(2023, 3, 27, 16, 17, 51, 211, DateTimeKind.Local).AddTicks(1468), 83, 1978778641, null },
                    { 335, 111, new DateTime(2022, 9, 14, 6, 10, 43, 456, DateTimeKind.Local).AddTicks(7151), new DateTime(2022, 11, 6, 16, 3, 1, 215, DateTimeKind.Local).AddTicks(497), 59, -1552697510, null },
                    { 336, 50, new DateTime(2022, 10, 10, 19, 13, 19, 723, DateTimeKind.Local).AddTicks(3890), new DateTime(2022, 5, 14, 1, 34, 4, 534, DateTimeKind.Local).AddTicks(1093), 19, -72638277, null },
                    { 337, 105, new DateTime(2022, 12, 14, 14, 6, 13, 723, DateTimeKind.Local).AddTicks(5465), new DateTime(2023, 2, 13, 2, 18, 58, 877, DateTimeKind.Local).AddTicks(3733), 75, -338248321, null },
                    { 338, 92, new DateTime(2022, 8, 24, 15, 37, 25, 994, DateTimeKind.Local).AddTicks(7739), new DateTime(2022, 10, 13, 11, 41, 37, 492, DateTimeKind.Local).AddTicks(9542), 19, 719662832, null },
                    { 339, 90, new DateTime(2023, 4, 9, 23, 6, 59, 344, DateTimeKind.Local).AddTicks(5199), new DateTime(2022, 10, 29, 15, 11, 0, 466, DateTimeKind.Local).AddTicks(9836), 90, -1774916844, null },
                    { 340, 52, new DateTime(2022, 5, 30, 21, 31, 31, 204, DateTimeKind.Local).AddTicks(7172), new DateTime(2023, 3, 19, 5, 21, 51, 820, DateTimeKind.Local).AddTicks(7613), 8, 774637850, null },
                    { 341, 129, new DateTime(2023, 1, 1, 10, 19, 51, 932, DateTimeKind.Local).AddTicks(9612), new DateTime(2023, 1, 26, 12, 42, 4, 177, DateTimeKind.Local).AddTicks(9757), 42, 433931557, null },
                    { 342, 122, new DateTime(2022, 7, 4, 17, 46, 46, 52, DateTimeKind.Local).AddTicks(3497), new DateTime(2022, 8, 20, 13, 30, 41, 59, DateTimeKind.Local).AddTicks(6826), 17, -105541888, null },
                    { 343, 78, new DateTime(2022, 10, 13, 4, 31, 0, 581, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 9, 2, 18, 18, 24, 593, DateTimeKind.Local).AddTicks(2531), 25, 1469352663, null },
                    { 344, 57, new DateTime(2022, 11, 2, 21, 27, 21, 129, DateTimeKind.Local).AddTicks(1541), new DateTime(2022, 12, 28, 19, 47, 37, 216, DateTimeKind.Local).AddTicks(445), 84, 369805157, null },
                    { 345, 122, new DateTime(2022, 5, 25, 16, 40, 42, 11, DateTimeKind.Local).AddTicks(4931), new DateTime(2022, 6, 27, 20, 44, 12, 876, DateTimeKind.Local).AddTicks(2855), 72, 440008961, null },
                    { 346, 144, new DateTime(2023, 4, 1, 0, 28, 21, 309, DateTimeKind.Local).AddTicks(7246), new DateTime(2023, 2, 1, 19, 11, 46, 445, DateTimeKind.Local).AddTicks(3745), 42, 1684543274, null },
                    { 347, 126, new DateTime(2022, 8, 24, 21, 58, 4, 371, DateTimeKind.Local).AddTicks(219), new DateTime(2023, 1, 23, 16, 44, 17, 377, DateTimeKind.Local).AddTicks(4170), 80, -498607270, null },
                    { 348, 31, new DateTime(2022, 4, 22, 23, 54, 14, 772, DateTimeKind.Local).AddTicks(8888), new DateTime(2023, 1, 21, 3, 10, 52, 78, DateTimeKind.Local).AddTicks(4086), 92, 328377419, null },
                    { 349, 77, new DateTime(2023, 4, 8, 4, 46, 30, 605, DateTimeKind.Local).AddTicks(5642), new DateTime(2022, 12, 17, 10, 35, 55, 812, DateTimeKind.Local).AddTicks(8798), 86, 1307829994, null },
                    { 350, 45, new DateTime(2022, 7, 14, 13, 14, 27, 13, DateTimeKind.Local).AddTicks(8406), new DateTime(2022, 5, 13, 2, 4, 31, 592, DateTimeKind.Local).AddTicks(4961), 4, 296524004, null },
                    { 351, 103, new DateTime(2022, 5, 14, 5, 45, 16, 110, DateTimeKind.Local).AddTicks(8071), new DateTime(2022, 8, 15, 12, 38, 8, 275, DateTimeKind.Local).AddTicks(7493), 91, -217140423, null },
                    { 352, 4, new DateTime(2022, 8, 15, 15, 0, 2, 311, DateTimeKind.Local).AddTicks(6499), new DateTime(2022, 10, 13, 2, 56, 21, 753, DateTimeKind.Local).AddTicks(2205), 10, -919458376, null },
                    { 353, 109, new DateTime(2022, 7, 18, 18, 56, 44, 788, DateTimeKind.Local).AddTicks(4750), new DateTime(2023, 1, 11, 21, 21, 25, 634, DateTimeKind.Local).AddTicks(2125), 14, 2106759985, null },
                    { 354, 12, new DateTime(2022, 8, 17, 21, 25, 47, 743, DateTimeKind.Local).AddTicks(1924), new DateTime(2022, 10, 31, 0, 27, 47, 296, DateTimeKind.Local).AddTicks(8040), 45, -200127376, null },
                    { 355, 13, new DateTime(2022, 11, 10, 21, 7, 26, 574, DateTimeKind.Local).AddTicks(1508), new DateTime(2022, 12, 17, 1, 20, 39, 930, DateTimeKind.Local).AddTicks(2118), 81, -585604828, null },
                    { 356, 84, new DateTime(2022, 7, 22, 5, 49, 12, 848, DateTimeKind.Local).AddTicks(6970), new DateTime(2023, 4, 1, 7, 58, 44, 277, DateTimeKind.Local).AddTicks(371), 17, -853457354, null },
                    { 357, 42, new DateTime(2022, 7, 11, 18, 9, 7, 67, DateTimeKind.Local).AddTicks(4678), new DateTime(2022, 12, 18, 18, 12, 11, 298, DateTimeKind.Local).AddTicks(2130), 53, 654792316, null },
                    { 358, 19, new DateTime(2023, 1, 11, 7, 37, 57, 413, DateTimeKind.Local).AddTicks(9567), new DateTime(2022, 11, 14, 12, 2, 27, 885, DateTimeKind.Local).AddTicks(9590), 36, -1273129968, null },
                    { 359, 145, new DateTime(2022, 5, 25, 20, 7, 46, 144, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 7, 24, 5, 39, 59, 166, DateTimeKind.Local).AddTicks(5704), 5, -1796494920, null },
                    { 360, 57, new DateTime(2023, 3, 9, 21, 34, 5, 162, DateTimeKind.Local).AddTicks(8318), new DateTime(2022, 7, 12, 16, 35, 3, 955, DateTimeKind.Local).AddTicks(1690), 3, -1516141593, null },
                    { 361, 21, new DateTime(2023, 3, 15, 11, 2, 9, 158, DateTimeKind.Local).AddTicks(9787), new DateTime(2023, 2, 4, 2, 41, 33, 835, DateTimeKind.Local).AddTicks(3764), 17, -1819853743, null },
                    { 362, 109, new DateTime(2022, 7, 2, 22, 17, 10, 228, DateTimeKind.Local).AddTicks(737), new DateTime(2022, 7, 7, 21, 41, 26, 950, DateTimeKind.Local).AddTicks(2193), 46, -1207081806, null },
                    { 363, 85, new DateTime(2022, 10, 8, 5, 13, 34, 102, DateTimeKind.Local).AddTicks(6714), new DateTime(2022, 5, 5, 19, 21, 2, 67, DateTimeKind.Local).AddTicks(3681), 85, -1233218713, null },
                    { 364, 64, new DateTime(2022, 7, 11, 13, 9, 38, 576, DateTimeKind.Local).AddTicks(9200), new DateTime(2022, 12, 9, 21, 53, 25, 809, DateTimeKind.Local).AddTicks(5297), 87, 763463199, null },
                    { 365, 133, new DateTime(2023, 2, 24, 0, 21, 58, 752, DateTimeKind.Local).AddTicks(4598), new DateTime(2022, 6, 20, 18, 37, 0, 531, DateTimeKind.Local).AddTicks(8281), 95, 981946863, null },
                    { 366, 52, new DateTime(2023, 2, 19, 0, 7, 41, 439, DateTimeKind.Local).AddTicks(6697), new DateTime(2023, 4, 11, 17, 10, 10, 655, DateTimeKind.Local).AddTicks(362), 26, -2072344740, null },
                    { 367, 49, new DateTime(2023, 1, 29, 18, 54, 46, 338, DateTimeKind.Local).AddTicks(3209), new DateTime(2022, 10, 24, 12, 36, 59, 184, DateTimeKind.Local).AddTicks(2116), 46, 1697445717, null },
                    { 368, 140, new DateTime(2022, 11, 9, 22, 45, 24, 589, DateTimeKind.Local).AddTicks(2399), new DateTime(2022, 11, 10, 15, 51, 36, 429, DateTimeKind.Local).AddTicks(1081), 19, -1279808532, null },
                    { 369, 101, new DateTime(2023, 2, 14, 8, 42, 49, 146, DateTimeKind.Local).AddTicks(1126), new DateTime(2023, 4, 7, 16, 12, 38, 150, DateTimeKind.Local).AddTicks(6510), 98, 1693881815, null },
                    { 370, 81, new DateTime(2022, 9, 13, 17, 41, 35, 70, DateTimeKind.Local).AddTicks(2885), new DateTime(2022, 6, 28, 8, 2, 48, 137, DateTimeKind.Local).AddTicks(4907), 47, 1503312246, null },
                    { 371, 149, new DateTime(2022, 10, 22, 16, 29, 39, 652, DateTimeKind.Local).AddTicks(6166), new DateTime(2022, 7, 3, 20, 49, 24, 757, DateTimeKind.Local).AddTicks(6693), 49, -1381650699, null },
                    { 372, 48, new DateTime(2022, 9, 25, 4, 19, 11, 161, DateTimeKind.Local).AddTicks(8604), new DateTime(2022, 9, 2, 12, 52, 19, 965, DateTimeKind.Local).AddTicks(1425), 60, -1578700948, null },
                    { 373, 82, new DateTime(2022, 7, 3, 12, 34, 11, 598, DateTimeKind.Local).AddTicks(5660), new DateTime(2023, 2, 24, 2, 15, 18, 626, DateTimeKind.Local).AddTicks(6751), 20, 2127238383, null },
                    { 374, 43, new DateTime(2022, 10, 14, 15, 5, 41, 868, DateTimeKind.Local).AddTicks(2756), new DateTime(2022, 6, 22, 18, 9, 27, 523, DateTimeKind.Local).AddTicks(5448), 23, 548092790, null },
                    { 375, 12, new DateTime(2022, 7, 20, 8, 40, 41, 368, DateTimeKind.Local).AddTicks(163), new DateTime(2023, 3, 2, 5, 42, 20, 57, DateTimeKind.Local).AddTicks(1162), 98, -1572658817, null },
                    { 376, 47, new DateTime(2022, 9, 11, 18, 42, 27, 13, DateTimeKind.Local).AddTicks(6357), new DateTime(2022, 5, 20, 8, 16, 10, 821, DateTimeKind.Local).AddTicks(8595), 51, -193943312, null },
                    { 377, 14, new DateTime(2022, 4, 28, 3, 27, 33, 989, DateTimeKind.Local).AddTicks(7689), new DateTime(2023, 2, 6, 1, 30, 21, 858, DateTimeKind.Local).AddTicks(31), 13, -1320398428, null },
                    { 378, 112, new DateTime(2022, 5, 28, 9, 33, 38, 540, DateTimeKind.Local).AddTicks(7309), new DateTime(2022, 11, 21, 12, 17, 36, 307, DateTimeKind.Local).AddTicks(5724), 26, 571372334, null },
                    { 379, 52, new DateTime(2022, 12, 13, 17, 14, 34, 503, DateTimeKind.Local).AddTicks(4716), new DateTime(2023, 1, 10, 3, 21, 9, 722, DateTimeKind.Local).AddTicks(5347), 30, -1844119791, null },
                    { 380, 56, new DateTime(2022, 11, 15, 13, 12, 51, 688, DateTimeKind.Local).AddTicks(5876), new DateTime(2023, 2, 25, 4, 3, 24, 873, DateTimeKind.Local).AddTicks(6627), 86, -1739813718, null },
                    { 381, 89, new DateTime(2023, 1, 4, 12, 50, 59, 589, DateTimeKind.Local).AddTicks(2881), new DateTime(2022, 8, 28, 3, 4, 7, 354, DateTimeKind.Local).AddTicks(3145), 77, -1860456134, null },
                    { 382, 44, new DateTime(2023, 2, 2, 6, 3, 54, 394, DateTimeKind.Local).AddTicks(7448), new DateTime(2022, 8, 6, 11, 15, 51, 199, DateTimeKind.Local).AddTicks(4892), 15, -1441465532, null },
                    { 383, 53, new DateTime(2023, 3, 29, 22, 59, 9, 219, DateTimeKind.Local).AddTicks(6700), new DateTime(2022, 11, 26, 16, 47, 16, 517, DateTimeKind.Local).AddTicks(7521), 17, -1820284286, null },
                    { 384, 70, new DateTime(2022, 12, 31, 2, 5, 17, 584, DateTimeKind.Local).AddTicks(2848), new DateTime(2023, 2, 14, 14, 1, 42, 737, DateTimeKind.Local).AddTicks(3916), 80, -671741085, null },
                    { 385, 87, new DateTime(2022, 8, 19, 16, 56, 38, 285, DateTimeKind.Local).AddTicks(2971), new DateTime(2022, 10, 15, 12, 54, 49, 45, DateTimeKind.Local).AddTicks(7839), 40, 537772497, null },
                    { 386, 56, new DateTime(2022, 12, 4, 11, 21, 54, 274, DateTimeKind.Local).AddTicks(7728), new DateTime(2022, 11, 2, 1, 8, 26, 921, DateTimeKind.Local).AddTicks(5546), 35, -1397929287, null },
                    { 387, 58, new DateTime(2022, 6, 9, 23, 50, 54, 110, DateTimeKind.Local).AddTicks(3390), new DateTime(2022, 5, 28, 15, 47, 59, 172, DateTimeKind.Local).AddTicks(2952), 66, 281443544, null },
                    { 388, 36, new DateTime(2022, 5, 1, 15, 31, 48, 409, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 9, 8, 12, 14, 40, 1, DateTimeKind.Local).AddTicks(8830), 94, 464402077, null },
                    { 389, 91, new DateTime(2022, 12, 6, 4, 47, 46, 563, DateTimeKind.Local).AddTicks(6034), new DateTime(2022, 5, 17, 22, 14, 31, 932, DateTimeKind.Local).AddTicks(9311), 66, -1530312897, null },
                    { 390, 144, new DateTime(2022, 7, 11, 6, 45, 6, 90, DateTimeKind.Local).AddTicks(9453), new DateTime(2022, 6, 16, 5, 42, 8, 262, DateTimeKind.Local).AddTicks(7124), 3, -31302201, null },
                    { 391, 42, new DateTime(2023, 4, 5, 13, 44, 13, 354, DateTimeKind.Local).AddTicks(4376), new DateTime(2022, 5, 23, 9, 16, 31, 820, DateTimeKind.Local).AddTicks(7081), 89, -1311593787, null },
                    { 392, 75, new DateTime(2022, 9, 7, 19, 31, 10, 909, DateTimeKind.Local).AddTicks(4068), new DateTime(2022, 6, 20, 12, 44, 37, 256, DateTimeKind.Local).AddTicks(714), 69, 713461867, null },
                    { 393, 26, new DateTime(2022, 6, 2, 3, 16, 28, 866, DateTimeKind.Local).AddTicks(593), new DateTime(2023, 1, 4, 16, 43, 38, 35, DateTimeKind.Local).AddTicks(8279), 5, -663739863, null },
                    { 394, 138, new DateTime(2022, 6, 29, 20, 54, 35, 763, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 11, 23, 20, 25, 11, 942, DateTimeKind.Local).AddTicks(5658), 71, -534740220, null },
                    { 395, 124, new DateTime(2022, 4, 23, 16, 3, 57, 807, DateTimeKind.Local).AddTicks(176), new DateTime(2022, 7, 15, 23, 33, 57, 192, DateTimeKind.Local).AddTicks(8314), 23, -1706105652, null },
                    { 396, 48, new DateTime(2022, 7, 15, 3, 13, 53, 319, DateTimeKind.Local).AddTicks(895), new DateTime(2022, 5, 16, 22, 21, 4, 110, DateTimeKind.Local).AddTicks(7368), 44, 1616222659, null },
                    { 397, 67, new DateTime(2022, 7, 23, 13, 48, 41, 949, DateTimeKind.Local).AddTicks(5284), new DateTime(2023, 2, 6, 10, 28, 36, 656, DateTimeKind.Local).AddTicks(7245), 39, -518625811, null },
                    { 398, 57, new DateTime(2023, 2, 24, 18, 53, 3, 529, DateTimeKind.Local).AddTicks(9473), new DateTime(2022, 11, 11, 6, 45, 48, 950, DateTimeKind.Local).AddTicks(676), 11, 1886023997, null },
                    { 399, 124, new DateTime(2022, 9, 4, 7, 17, 18, 14, DateTimeKind.Local).AddTicks(938), new DateTime(2023, 3, 24, 13, 16, 34, 72, DateTimeKind.Local).AddTicks(3187), 81, -1418637419, null },
                    { 400, 70, new DateTime(2022, 7, 11, 4, 51, 7, 962, DateTimeKind.Local).AddTicks(827), new DateTime(2023, 2, 20, 16, 33, 15, 277, DateTimeKind.Local).AddTicks(2350), 34, -2022586493, null },
                    { 401, 5, new DateTime(2022, 6, 14, 3, 14, 38, 388, DateTimeKind.Local).AddTicks(7368), new DateTime(2022, 7, 12, 3, 8, 33, 867, DateTimeKind.Local).AddTicks(2379), 78, -1302164842, null },
                    { 402, 102, new DateTime(2022, 5, 25, 3, 33, 33, 852, DateTimeKind.Local).AddTicks(3042), new DateTime(2022, 7, 22, 0, 59, 59, 678, DateTimeKind.Local).AddTicks(3395), 37, -447102484, null },
                    { 403, 145, new DateTime(2022, 8, 7, 5, 14, 32, 81, DateTimeKind.Local).AddTicks(6489), new DateTime(2023, 2, 3, 5, 45, 34, 292, DateTimeKind.Local).AddTicks(6316), 81, -2060051523, null },
                    { 404, 2, new DateTime(2022, 11, 22, 10, 43, 28, 657, DateTimeKind.Local).AddTicks(6085), new DateTime(2022, 9, 21, 13, 41, 3, 562, DateTimeKind.Local).AddTicks(1626), 98, 1972918002, null },
                    { 405, 17, new DateTime(2022, 10, 12, 11, 55, 30, 855, DateTimeKind.Local).AddTicks(1296), new DateTime(2023, 1, 19, 7, 52, 17, 494, DateTimeKind.Local).AddTicks(6081), 52, -1753056495, null },
                    { 406, 63, new DateTime(2022, 7, 27, 7, 13, 41, 53, DateTimeKind.Local).AddTicks(6219), new DateTime(2022, 8, 17, 7, 2, 2, 885, DateTimeKind.Local).AddTicks(1295), 77, -566729565, null },
                    { 407, 67, new DateTime(2022, 10, 25, 16, 55, 47, 543, DateTimeKind.Local).AddTicks(1342), new DateTime(2022, 5, 29, 19, 46, 3, 879, DateTimeKind.Local).AddTicks(9200), 3, 1326534613, null },
                    { 408, 111, new DateTime(2023, 3, 25, 9, 1, 8, 240, DateTimeKind.Local).AddTicks(2629), new DateTime(2022, 7, 15, 13, 14, 5, 150, DateTimeKind.Local).AddTicks(1446), 30, -1837625435, null },
                    { 409, 125, new DateTime(2022, 4, 25, 20, 29, 5, 58, DateTimeKind.Local).AddTicks(3591), new DateTime(2022, 11, 20, 6, 11, 50, 503, DateTimeKind.Local).AddTicks(7645), 6, -1175261115, null },
                    { 410, 149, new DateTime(2022, 9, 26, 15, 33, 33, 78, DateTimeKind.Local).AddTicks(1684), new DateTime(2022, 8, 1, 20, 52, 18, 344, DateTimeKind.Local).AddTicks(4674), 48, -14781012, null },
                    { 411, 150, new DateTime(2022, 11, 26, 4, 26, 28, 173, DateTimeKind.Local).AddTicks(4619), new DateTime(2023, 2, 27, 19, 27, 49, 334, DateTimeKind.Local).AddTicks(3427), 55, -1646527241, null },
                    { 412, 142, new DateTime(2022, 11, 2, 8, 51, 59, 344, DateTimeKind.Local).AddTicks(8743), new DateTime(2022, 7, 2, 14, 56, 9, 347, DateTimeKind.Local).AddTicks(5119), 69, -1106583848, null },
                    { 413, 8, new DateTime(2022, 9, 29, 1, 59, 16, 848, DateTimeKind.Local).AddTicks(2384), new DateTime(2023, 1, 27, 18, 20, 22, 211, DateTimeKind.Local).AddTicks(5362), 43, -1473007204, null },
                    { 414, 79, new DateTime(2022, 11, 26, 15, 16, 7, 450, DateTimeKind.Local).AddTicks(8941), new DateTime(2022, 12, 6, 16, 21, 45, 634, DateTimeKind.Local).AddTicks(7255), 96, 2106674809, null },
                    { 415, 27, new DateTime(2022, 7, 22, 20, 29, 17, 878, DateTimeKind.Local).AddTicks(2135), new DateTime(2022, 5, 17, 8, 36, 18, 869, DateTimeKind.Local).AddTicks(5133), 31, 707259900, null },
                    { 416, 2, new DateTime(2022, 11, 7, 9, 39, 47, 296, DateTimeKind.Local).AddTicks(7366), new DateTime(2023, 3, 23, 20, 43, 34, 544, DateTimeKind.Local).AddTicks(5405), 21, 1137474255, null },
                    { 417, 141, new DateTime(2023, 2, 24, 0, 34, 41, 834, DateTimeKind.Local).AddTicks(865), new DateTime(2023, 2, 23, 20, 42, 34, 828, DateTimeKind.Local).AddTicks(3499), 91, -1897319371, null },
                    { 418, 150, new DateTime(2023, 3, 13, 4, 20, 18, 975, DateTimeKind.Local).AddTicks(5543), new DateTime(2022, 10, 8, 9, 31, 25, 525, DateTimeKind.Local).AddTicks(1699), 4, 424394659, null },
                    { 419, 121, new DateTime(2022, 8, 7, 2, 21, 54, 376, DateTimeKind.Local).AddTicks(2284), new DateTime(2022, 7, 11, 10, 47, 53, 308, DateTimeKind.Local).AddTicks(943), 56, -1926698112, null },
                    { 420, 89, new DateTime(2022, 4, 23, 10, 6, 21, 562, DateTimeKind.Local).AddTicks(5268), new DateTime(2023, 3, 16, 15, 51, 14, 504, DateTimeKind.Local).AddTicks(6524), 3, 272139719, null },
                    { 421, 103, new DateTime(2022, 10, 30, 20, 55, 34, 762, DateTimeKind.Local).AddTicks(445), new DateTime(2023, 1, 16, 20, 3, 25, 682, DateTimeKind.Local).AddTicks(6166), 99, -1498963365, null },
                    { 422, 127, new DateTime(2022, 6, 28, 0, 44, 45, 798, DateTimeKind.Local).AddTicks(3088), new DateTime(2022, 10, 6, 6, 31, 29, 744, DateTimeKind.Local).AddTicks(167), 19, 175312157, null },
                    { 423, 93, new DateTime(2023, 3, 11, 3, 59, 46, 950, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 12, 30, 11, 27, 36, 835, DateTimeKind.Local).AddTicks(9487), 45, 323128064, null },
                    { 424, 96, new DateTime(2022, 10, 14, 16, 40, 27, 760, DateTimeKind.Local).AddTicks(6577), new DateTime(2022, 10, 4, 20, 2, 20, 898, DateTimeKind.Local).AddTicks(9444), 26, 1647076529, null },
                    { 425, 49, new DateTime(2023, 1, 22, 21, 46, 55, 200, DateTimeKind.Local).AddTicks(6635), new DateTime(2022, 7, 20, 3, 14, 42, 144, DateTimeKind.Local).AddTicks(487), 56, 412075817, null },
                    { 426, 47, new DateTime(2022, 7, 15, 5, 54, 37, 754, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 11, 12, 16, 38, 18, 716, DateTimeKind.Local).AddTicks(9829), 80, 874824727, null },
                    { 427, 4, new DateTime(2022, 8, 18, 20, 11, 18, 293, DateTimeKind.Local).AddTicks(963), new DateTime(2023, 2, 22, 19, 45, 34, 594, DateTimeKind.Local).AddTicks(1265), 95, -523806632, null },
                    { 428, 94, new DateTime(2022, 12, 15, 13, 26, 11, 802, DateTimeKind.Local).AddTicks(5965), new DateTime(2022, 7, 31, 12, 45, 39, 587, DateTimeKind.Local).AddTicks(2225), 84, -1533636773, null },
                    { 429, 98, new DateTime(2022, 5, 12, 22, 38, 10, 545, DateTimeKind.Local).AddTicks(4860), new DateTime(2022, 10, 11, 0, 31, 40, 141, DateTimeKind.Local).AddTicks(1429), 20, 867260279, null },
                    { 430, 29, new DateTime(2022, 5, 29, 16, 45, 21, 948, DateTimeKind.Local).AddTicks(2068), new DateTime(2023, 3, 28, 5, 19, 35, 857, DateTimeKind.Local).AddTicks(9084), 55, -2014150849, null },
                    { 431, 93, new DateTime(2022, 8, 3, 14, 8, 31, 996, DateTimeKind.Local).AddTicks(5482), new DateTime(2022, 11, 16, 3, 13, 39, 921, DateTimeKind.Local).AddTicks(9839), 14, -754998618, null },
                    { 432, 121, new DateTime(2023, 1, 9, 7, 35, 56, 198, DateTimeKind.Local).AddTicks(6173), new DateTime(2022, 5, 17, 13, 31, 17, 462, DateTimeKind.Local).AddTicks(7425), 90, -1040665022, null },
                    { 433, 25, new DateTime(2023, 1, 29, 9, 19, 30, 580, DateTimeKind.Local).AddTicks(7260), new DateTime(2022, 8, 4, 17, 32, 7, 956, DateTimeKind.Local).AddTicks(1667), 30, 2084911874, null },
                    { 434, 37, new DateTime(2023, 1, 1, 4, 58, 59, 348, DateTimeKind.Local).AddTicks(5060), new DateTime(2022, 8, 13, 20, 8, 11, 560, DateTimeKind.Local).AddTicks(4630), 36, 777270792, null },
                    { 435, 6, new DateTime(2022, 12, 29, 8, 28, 2, 453, DateTimeKind.Local).AddTicks(3211), new DateTime(2023, 2, 19, 9, 49, 49, 26, DateTimeKind.Local).AddTicks(2274), 93, 721226870, null },
                    { 436, 99, new DateTime(2022, 8, 5, 13, 35, 5, 899, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 6, 23, 0, 25, 16, 441, DateTimeKind.Local).AddTicks(9654), 19, -950450273, null },
                    { 437, 59, new DateTime(2023, 3, 10, 3, 1, 55, 141, DateTimeKind.Local).AddTicks(9471), new DateTime(2022, 9, 8, 19, 36, 53, 705, DateTimeKind.Local).AddTicks(9563), 28, -820539885, null },
                    { 438, 149, new DateTime(2022, 4, 23, 10, 50, 57, 935, DateTimeKind.Local).AddTicks(6825), new DateTime(2022, 12, 7, 10, 11, 28, 866, DateTimeKind.Local).AddTicks(2142), 71, -1570599290, null },
                    { 439, 27, new DateTime(2022, 9, 6, 13, 39, 33, 257, DateTimeKind.Local).AddTicks(9296), new DateTime(2023, 2, 10, 15, 8, 30, 819, DateTimeKind.Local).AddTicks(436), 44, -1204642033, null },
                    { 440, 51, new DateTime(2022, 10, 3, 17, 46, 59, 760, DateTimeKind.Local).AddTicks(4311), new DateTime(2023, 2, 22, 17, 2, 8, 842, DateTimeKind.Local).AddTicks(6581), 61, -1578046645, null },
                    { 441, 112, new DateTime(2022, 6, 10, 23, 3, 22, 91, DateTimeKind.Local).AddTicks(1957), new DateTime(2022, 8, 16, 8, 56, 18, 119, DateTimeKind.Local).AddTicks(8516), 76, 1099053374, null },
                    { 442, 96, new DateTime(2022, 12, 9, 0, 27, 15, 315, DateTimeKind.Local).AddTicks(6792), new DateTime(2022, 5, 5, 23, 53, 30, 28, DateTimeKind.Local).AddTicks(4944), 41, 1015686596, null },
                    { 443, 39, new DateTime(2022, 9, 14, 6, 7, 11, 947, DateTimeKind.Local).AddTicks(4433), new DateTime(2022, 10, 12, 3, 13, 34, 671, DateTimeKind.Local).AddTicks(1727), 36, -60645264, null },
                    { 444, 110, new DateTime(2022, 6, 2, 12, 30, 40, 369, DateTimeKind.Local).AddTicks(3473), new DateTime(2022, 10, 26, 6, 55, 25, 434, DateTimeKind.Local).AddTicks(9102), 90, -1216499781, null },
                    { 445, 133, new DateTime(2023, 2, 25, 14, 13, 4, 548, DateTimeKind.Local).AddTicks(145), new DateTime(2022, 10, 17, 5, 56, 39, 346, DateTimeKind.Local).AddTicks(5319), 92, 59930291, null },
                    { 446, 100, new DateTime(2023, 1, 30, 6, 52, 46, 46, DateTimeKind.Local).AddTicks(6398), new DateTime(2022, 12, 27, 2, 52, 52, 636, DateTimeKind.Local).AddTicks(3918), 70, 745862346, null },
                    { 447, 129, new DateTime(2023, 1, 11, 4, 15, 8, 522, DateTimeKind.Local).AddTicks(5174), new DateTime(2023, 2, 10, 18, 10, 32, 681, DateTimeKind.Local).AddTicks(7654), 18, 1071346921, null },
                    { 448, 17, new DateTime(2023, 3, 22, 23, 47, 51, 287, DateTimeKind.Local).AddTicks(5513), new DateTime(2022, 9, 15, 14, 2, 58, 113, DateTimeKind.Local).AddTicks(8110), 63, -167284115, null },
                    { 449, 23, new DateTime(2022, 11, 22, 2, 38, 26, 148, DateTimeKind.Local).AddTicks(8405), new DateTime(2022, 11, 9, 8, 28, 22, 411, DateTimeKind.Local).AddTicks(1879), 50, -1242271314, null },
                    { 450, 5, new DateTime(2022, 11, 18, 6, 57, 5, 126, DateTimeKind.Local).AddTicks(9544), new DateTime(2022, 8, 26, 15, 25, 59, 280, DateTimeKind.Local).AddTicks(5213), 81, 1923556628, null },
                    { 451, 24, new DateTime(2023, 1, 16, 21, 38, 21, 927, DateTimeKind.Local).AddTicks(9788), new DateTime(2022, 11, 4, 2, 28, 0, 184, DateTimeKind.Local).AddTicks(804), 4, -1267641762, null },
                    { 452, 71, new DateTime(2022, 10, 29, 6, 43, 41, 952, DateTimeKind.Local).AddTicks(4938), new DateTime(2022, 8, 2, 4, 40, 54, 264, DateTimeKind.Local).AddTicks(6722), 40, 1860906796, null },
                    { 453, 21, new DateTime(2023, 1, 10, 12, 20, 56, 875, DateTimeKind.Local).AddTicks(9015), new DateTime(2022, 7, 29, 4, 56, 32, 471, DateTimeKind.Local).AddTicks(3333), 31, -1458992185, null },
                    { 454, 6, new DateTime(2022, 11, 3, 4, 51, 54, 92, DateTimeKind.Local).AddTicks(757), new DateTime(2023, 3, 15, 17, 31, 48, 137, DateTimeKind.Local).AddTicks(7318), 20, -1412383641, null },
                    { 455, 82, new DateTime(2022, 10, 19, 15, 8, 14, 825, DateTimeKind.Local).AddTicks(3249), new DateTime(2022, 9, 28, 16, 39, 37, 353, DateTimeKind.Local).AddTicks(5061), 54, -752939517, null },
                    { 456, 27, new DateTime(2022, 12, 21, 8, 21, 56, 115, DateTimeKind.Local).AddTicks(196), new DateTime(2023, 1, 18, 6, 27, 31, 1, DateTimeKind.Local).AddTicks(5393), 38, 1413658013, null },
                    { 457, 1, new DateTime(2023, 4, 11, 18, 23, 50, 633, DateTimeKind.Local).AddTicks(6145), new DateTime(2022, 7, 21, 10, 21, 21, 56, DateTimeKind.Local).AddTicks(851), 19, -1866309137, null },
                    { 458, 66, new DateTime(2022, 8, 16, 2, 40, 8, 568, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 5, 29, 20, 28, 13, 916, DateTimeKind.Local).AddTicks(1720), 33, 1460603406, null },
                    { 459, 75, new DateTime(2022, 10, 29, 16, 50, 19, 546, DateTimeKind.Local).AddTicks(2864), new DateTime(2022, 10, 3, 7, 21, 17, 390, DateTimeKind.Local).AddTicks(1600), 48, -1788896575, null },
                    { 460, 115, new DateTime(2022, 5, 21, 18, 31, 49, 211, DateTimeKind.Local).AddTicks(3890), new DateTime(2022, 8, 3, 8, 30, 7, 783, DateTimeKind.Local).AddTicks(485), 42, -1230205484, null },
                    { 461, 84, new DateTime(2022, 5, 31, 15, 54, 25, 955, DateTimeKind.Local).AddTicks(4249), new DateTime(2022, 10, 20, 7, 6, 53, 843, DateTimeKind.Local).AddTicks(4883), 39, 1503110009, null },
                    { 462, 53, new DateTime(2022, 11, 27, 3, 15, 37, 76, DateTimeKind.Local).AddTicks(232), new DateTime(2022, 10, 31, 19, 18, 51, 376, DateTimeKind.Local).AddTicks(6930), 85, 904628655, null },
                    { 463, 47, new DateTime(2022, 5, 22, 10, 21, 39, 874, DateTimeKind.Local).AddTicks(5380), new DateTime(2023, 1, 13, 6, 24, 15, 164, DateTimeKind.Local).AddTicks(1473), 70, -456038943, null },
                    { 464, 130, new DateTime(2023, 1, 9, 1, 27, 36, 203, DateTimeKind.Local).AddTicks(6719), new DateTime(2022, 6, 8, 5, 9, 4, 919, DateTimeKind.Local).AddTicks(3687), 54, -1693491531, null },
                    { 465, 1, new DateTime(2023, 1, 10, 1, 26, 24, 733, DateTimeKind.Local).AddTicks(6524), new DateTime(2022, 11, 24, 14, 36, 17, 344, DateTimeKind.Local).AddTicks(4080), 84, -967259649, null },
                    { 466, 109, new DateTime(2022, 11, 29, 2, 4, 19, 738, DateTimeKind.Local).AddTicks(5751), new DateTime(2022, 6, 6, 20, 33, 16, 521, DateTimeKind.Local).AddTicks(2198), 46, -1823242908, null },
                    { 467, 58, new DateTime(2023, 1, 17, 23, 50, 54, 290, DateTimeKind.Local).AddTicks(7454), new DateTime(2022, 8, 5, 10, 19, 43, 523, DateTimeKind.Local).AddTicks(3338), 47, 96304590, null },
                    { 468, 138, new DateTime(2022, 8, 14, 4, 51, 39, 820, DateTimeKind.Local).AddTicks(729), new DateTime(2022, 7, 10, 16, 1, 24, 427, DateTimeKind.Local).AddTicks(1135), 58, 1302498074, null },
                    { 469, 119, new DateTime(2023, 2, 17, 1, 55, 49, 838, DateTimeKind.Local).AddTicks(5081), new DateTime(2022, 6, 24, 12, 43, 36, 572, DateTimeKind.Local).AddTicks(283), 64, 1790463702, null },
                    { 470, 125, new DateTime(2022, 11, 22, 6, 38, 31, 594, DateTimeKind.Local).AddTicks(9970), new DateTime(2022, 6, 18, 4, 29, 44, 387, DateTimeKind.Local).AddTicks(2183), 30, -1941982513, null },
                    { 471, 84, new DateTime(2023, 4, 2, 1, 27, 53, 784, DateTimeKind.Local).AddTicks(5149), new DateTime(2023, 4, 12, 15, 49, 24, 267, DateTimeKind.Local).AddTicks(9977), 62, 1147512235, null },
                    { 472, 62, new DateTime(2022, 12, 11, 8, 38, 13, 208, DateTimeKind.Local).AddTicks(5137), new DateTime(2022, 9, 6, 13, 7, 38, 160, DateTimeKind.Local).AddTicks(1500), 54, 1177956194, null },
                    { 473, 92, new DateTime(2022, 8, 3, 14, 15, 20, 638, DateTimeKind.Local).AddTicks(7414), new DateTime(2022, 11, 18, 19, 48, 45, 144, DateTimeKind.Local).AddTicks(2467), 23, -705507848, null },
                    { 474, 77, new DateTime(2023, 1, 15, 20, 57, 7, 399, DateTimeKind.Local).AddTicks(1664), new DateTime(2022, 8, 19, 16, 40, 54, 371, DateTimeKind.Local).AddTicks(6203), 50, -1941683786, null },
                    { 475, 3, new DateTime(2023, 4, 8, 4, 43, 26, 836, DateTimeKind.Local).AddTicks(4753), new DateTime(2022, 10, 31, 6, 15, 44, 199, DateTimeKind.Local).AddTicks(8450), 18, -870171152, null },
                    { 476, 104, new DateTime(2022, 5, 28, 1, 59, 22, 756, DateTimeKind.Local).AddTicks(908), new DateTime(2022, 7, 6, 9, 42, 18, 322, DateTimeKind.Local).AddTicks(6880), 11, 2142362668, null },
                    { 477, 21, new DateTime(2022, 9, 3, 6, 26, 7, 167, DateTimeKind.Local).AddTicks(7419), new DateTime(2022, 7, 19, 3, 31, 21, 418, DateTimeKind.Local).AddTicks(4167), 64, 1099709871, null },
                    { 478, 69, new DateTime(2022, 9, 23, 16, 27, 20, 487, DateTimeKind.Local).AddTicks(8880), new DateTime(2023, 4, 16, 14, 10, 22, 232, DateTimeKind.Local).AddTicks(9234), 70, 551394647, null },
                    { 479, 66, new DateTime(2022, 7, 7, 3, 28, 12, 833, DateTimeKind.Local).AddTicks(8050), new DateTime(2022, 5, 25, 10, 47, 28, 879, DateTimeKind.Local).AddTicks(9980), 61, 1486311316, null },
                    { 480, 56, new DateTime(2022, 12, 18, 4, 33, 10, 684, DateTimeKind.Local).AddTicks(6031), new DateTime(2023, 3, 29, 4, 27, 1, 355, DateTimeKind.Local).AddTicks(2044), 69, 1687003653, null },
                    { 481, 96, new DateTime(2022, 10, 27, 14, 40, 46, 706, DateTimeKind.Local).AddTicks(5159), new DateTime(2022, 5, 1, 3, 57, 41, 746, DateTimeKind.Local).AddTicks(7245), 4, -586460839, null },
                    { 482, 40, new DateTime(2023, 1, 6, 14, 43, 35, 545, DateTimeKind.Local).AddTicks(1911), new DateTime(2023, 3, 2, 18, 22, 3, 882, DateTimeKind.Local).AddTicks(4657), 22, 2066940675, null },
                    { 483, 76, new DateTime(2022, 8, 26, 16, 54, 14, 299, DateTimeKind.Local).AddTicks(7427), new DateTime(2023, 1, 6, 15, 40, 2, 750, DateTimeKind.Local).AddTicks(3198), 54, -126550874, null },
                    { 484, 141, new DateTime(2022, 7, 26, 11, 9, 52, 108, DateTimeKind.Local).AddTicks(7295), new DateTime(2022, 5, 14, 16, 31, 38, 710, DateTimeKind.Local).AddTicks(9590), 81, 418174444, null },
                    { 485, 40, new DateTime(2022, 11, 30, 13, 14, 58, 323, DateTimeKind.Local).AddTicks(9445), new DateTime(2022, 11, 23, 19, 59, 18, 142, DateTimeKind.Local).AddTicks(2389), 67, 867198375, null },
                    { 486, 91, new DateTime(2022, 5, 19, 2, 26, 32, 472, DateTimeKind.Local).AddTicks(1910), new DateTime(2022, 7, 10, 5, 14, 24, 938, DateTimeKind.Local).AddTicks(2222), 80, -359583053, null },
                    { 487, 106, new DateTime(2022, 6, 26, 12, 56, 58, 59, DateTimeKind.Local).AddTicks(7999), new DateTime(2023, 3, 28, 2, 40, 36, 288, DateTimeKind.Local).AddTicks(5374), 5, 2087545977, null },
                    { 488, 54, new DateTime(2022, 4, 25, 23, 26, 59, 506, DateTimeKind.Local).AddTicks(7231), new DateTime(2022, 6, 28, 7, 53, 54, 554, DateTimeKind.Local).AddTicks(7601), 74, -94399696, null },
                    { 489, 146, new DateTime(2022, 11, 12, 0, 41, 46, 695, DateTimeKind.Local).AddTicks(6245), new DateTime(2022, 10, 28, 4, 56, 3, 900, DateTimeKind.Local).AddTicks(9469), 69, 2058969564, null },
                    { 490, 139, new DateTime(2022, 9, 21, 4, 7, 34, 506, DateTimeKind.Local).AddTicks(5079), new DateTime(2022, 12, 3, 15, 50, 59, 21, DateTimeKind.Local).AddTicks(2817), 22, 2121165752, null },
                    { 491, 75, new DateTime(2023, 1, 30, 19, 30, 54, 22, DateTimeKind.Local).AddTicks(2995), new DateTime(2023, 2, 5, 23, 45, 37, 974, DateTimeKind.Local).AddTicks(1274), 86, -1251223178, null },
                    { 492, 44, new DateTime(2023, 2, 3, 19, 19, 19, 44, DateTimeKind.Local).AddTicks(8590), new DateTime(2022, 8, 19, 4, 48, 27, 442, DateTimeKind.Local).AddTicks(3522), 82, -1154544605, null },
                    { 493, 129, new DateTime(2023, 1, 23, 15, 22, 24, 626, DateTimeKind.Local).AddTicks(1578), new DateTime(2022, 11, 14, 23, 47, 47, 156, DateTimeKind.Local).AddTicks(1289), 71, -1625612116, null },
                    { 494, 140, new DateTime(2023, 1, 11, 16, 17, 47, 365, DateTimeKind.Local).AddTicks(882), new DateTime(2022, 11, 11, 22, 46, 33, 467, DateTimeKind.Local).AddTicks(1833), 99, -285425340, null },
                    { 495, 106, new DateTime(2022, 5, 16, 10, 24, 19, 854, DateTimeKind.Local).AddTicks(6828), new DateTime(2022, 10, 14, 3, 49, 13, 163, DateTimeKind.Local).AddTicks(4234), 72, 1398825995, null },
                    { 496, 34, new DateTime(2022, 11, 24, 19, 35, 17, 96, DateTimeKind.Local).AddTicks(2763), new DateTime(2023, 2, 10, 20, 10, 16, 630, DateTimeKind.Local).AddTicks(113), 46, -1144701321, null },
                    { 497, 126, new DateTime(2022, 9, 14, 2, 32, 36, 247, DateTimeKind.Local).AddTicks(7015), new DateTime(2022, 6, 18, 16, 54, 5, 459, DateTimeKind.Local).AddTicks(8574), 53, -1528711575, null },
                    { 498, 39, new DateTime(2022, 8, 1, 15, 57, 4, 111, DateTimeKind.Local).AddTicks(7678), new DateTime(2022, 7, 21, 19, 42, 50, 997, DateTimeKind.Local).AddTicks(5390), 51, 670949634, null },
                    { 499, 2, new DateTime(2022, 10, 2, 18, 3, 10, 486, DateTimeKind.Local).AddTicks(9864), new DateTime(2022, 12, 30, 22, 24, 38, 457, DateTimeKind.Local).AddTicks(9065), 69, 342634520, null },
                    { 500, 109, new DateTime(2022, 5, 3, 11, 5, 11, 853, DateTimeKind.Local).AddTicks(2996), new DateTime(2022, 7, 16, 15, 5, 31, 907, DateTimeKind.Local).AddTicks(5397), 40, 532447995, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 3, 59, 15, 287, DateTimeKind.Local).AddTicks(8154), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 693, DateTimeKind.Local).AddTicks(4369), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 17, 3, 59, 15, 291, DateTimeKind.Local).AddTicks(1974), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 696, DateTimeKind.Local).AddTicks(8083), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 17, 3, 59, 15, 294, DateTimeKind.Local).AddTicks(4554), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 700, DateTimeKind.Local).AddTicks(673), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 17, 3, 59, 15, 298, DateTimeKind.Local).AddTicks(4681), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 704, DateTimeKind.Local).AddTicks(1154), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 17, 3, 59, 15, 302, DateTimeKind.Local).AddTicks(8787), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 708, DateTimeKind.Local).AddTicks(4902), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 17, 3, 59, 15, 306, DateTimeKind.Local).AddTicks(3468), "Metal_Chicken.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 711, DateTimeKind.Local).AddTicks(9603), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 17, 3, 59, 15, 309, DateTimeKind.Local).AddTicks(7004), "Metal_Shoes.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 715, DateTimeKind.Local).AddTicks(3139), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 17, 3, 59, 15, 313, DateTimeKind.Local).AddTicks(962), "Metal_Shoes2.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 718, DateTimeKind.Local).AddTicks(7133), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 17, 3, 59, 15, 317, DateTimeKind.Local).AddTicks(749), "Steel_Computer.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 722, DateTimeKind.Local).AddTicks(6869), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 17, 3, 59, 15, 320, DateTimeKind.Local).AddTicks(3789), "Cotton_Cheese.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 725, DateTimeKind.Local).AddTicks(9882), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 17, 3, 59, 15, 323, DateTimeKind.Local).AddTicks(7622), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 729, DateTimeKind.Local).AddTicks(3724), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 17, 3, 59, 15, 326, DateTimeKind.Local).AddTicks(9930), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 732, DateTimeKind.Local).AddTicks(6030), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 17, 3, 59, 15, 330, DateTimeKind.Local).AddTicks(1758), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 8, 12, 12, 25, 735, DateTimeKind.Local).AddTicks(8042), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 4, 4 },
                    { 2, 5 },
                    { 1, 6 },
                    { 4, 7 },
                    { 3, 8 },
                    { 8, 9 },
                    { 7, 10 },
                    { 7, 11 },
                    { 1, 12 },
                    { 6, 13 },
                    { 9, 14 },
                    { 2, 15 },
                    { 8, 16 },
                    { 8, 17 },
                    { 6, 18 },
                    { 3, 19 },
                    { 4, 20 },
                    { 3, 21 },
                    { 4, 22 },
                    { 9, 23 },
                    { 9, 24 },
                    { 1, 25 },
                    { 6, 26 },
                    { 5, 27 },
                    { 2, 28 },
                    { 4, 29 },
                    { 6, 30 },
                    { 6, 31 },
                    { 1, 32 },
                    { 8, 33 },
                    { 6, 34 },
                    { 6, 35 },
                    { 9, 36 },
                    { 6, 37 },
                    { 9, 38 },
                    { 1, 39 },
                    { 2, 40 },
                    { 1, 41 },
                    { 9, 42 },
                    { 2, 43 },
                    { 9, 44 },
                    { 8, 45 },
                    { 2, 46 },
                    { 8, 47 },
                    { 2, 48 },
                    { 6, 49 },
                    { 6, 50 },
                    { 6, 51 },
                    { 7, 52 },
                    { 3, 53 },
                    { 8, 54 },
                    { 6, 55 },
                    { 1, 56 },
                    { 3, 57 },
                    { 4, 58 },
                    { 1, 59 },
                    { 6, 60 },
                    { 1, 61 },
                    { 3, 62 },
                    { 7, 63 },
                    { 3, 64 },
                    { 5, 65 },
                    { 9, 66 },
                    { 5, 67 },
                    { 9, 68 },
                    { 4, 69 },
                    { 8, 70 },
                    { 7, 71 },
                    { 2, 72 },
                    { 5, 73 },
                    { 4, 74 },
                    { 5, 75 },
                    { 1, 76 },
                    { 9, 77 },
                    { 9, 78 },
                    { 4, 79 },
                    { 9, 80 },
                    { 3, 81 },
                    { 2, 82 },
                    { 8, 83 },
                    { 9, 84 },
                    { 8, 85 },
                    { 9, 86 },
                    { 9, 87 },
                    { 7, 88 },
                    { 1, 89 },
                    { 5, 90 },
                    { 8, 91 },
                    { 3, 92 },
                    { 4, 93 },
                    { 7, 94 },
                    { 2, 95 },
                    { 3, 96 },
                    { 1, 97 },
                    { 8, 98 },
                    { 8, 99 },
                    { 3, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
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
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BillingAddressId",
                table: "Baskets",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_PaymentProviderId",
                table: "Baskets",
                column: "PaymentProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ShippingAddressId",
                table: "Baskets",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

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
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentProvider");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
