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
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "HR", "Human Resource" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "7e5ae683-453e-4b09-9bf5-f72fff107648", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", false, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "1234567890", false, "7c9b0e40-0552-463f-b5a9-cf57f0b555dc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "BillingAddressId", "CreateDate", "ModifiedDate", "PaymentProviderId", "ShippingAddressId", "Total", "UserId", "state" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 17, 21, 27, 54, 35, DateTimeKind.Local).AddTicks(8992), new DateTime(2023, 3, 9, 5, 41, 4, 441, DateTimeKind.Local).AddTicks(5133), null, null, null, null, "draft" },
                    { 2, null, new DateTime(2022, 10, 30, 4, 47, 17, 705, DateTimeKind.Local).AddTicks(4496), new DateTime(2022, 7, 11, 0, 32, 58, 913, DateTimeKind.Local).AddTicks(8160), null, null, null, null, "draft" },
                    { 3, null, new DateTime(2022, 8, 21, 15, 56, 10, 671, DateTimeKind.Local).AddTicks(4515), new DateTime(2022, 11, 11, 16, 37, 34, 391, DateTimeKind.Local).AddTicks(2743), null, null, null, null, "draft" },
                    { 4, null, new DateTime(2022, 12, 10, 10, 1, 40, 937, DateTimeKind.Local).AddTicks(20), new DateTime(2022, 5, 9, 3, 34, 5, 766, DateTimeKind.Local).AddTicks(54), null, null, null, null, "draft" },
                    { 5, null, new DateTime(2023, 3, 12, 16, 42, 27, 626, DateTimeKind.Local).AddTicks(5795), new DateTime(2022, 8, 27, 3, 53, 28, 112, DateTimeKind.Local).AddTicks(9510), null, null, null, null, "draft" },
                    { 6, null, new DateTime(2023, 4, 8, 4, 56, 35, 980, DateTimeKind.Local).AddTicks(2371), new DateTime(2023, 1, 18, 3, 3, 59, 372, DateTimeKind.Local).AddTicks(5453), null, null, null, null, "draft" },
                    { 7, null, new DateTime(2022, 12, 22, 19, 38, 13, 393, DateTimeKind.Local).AddTicks(5656), new DateTime(2022, 4, 22, 9, 26, 29, 736, DateTimeKind.Local).AddTicks(3851), null, null, null, null, "draft" },
                    { 8, null, new DateTime(2022, 8, 12, 16, 24, 11, 829, DateTimeKind.Local).AddTicks(4273), new DateTime(2022, 8, 22, 14, 59, 2, 100, DateTimeKind.Local).AddTicks(7536), null, null, null, null, "draft" },
                    { 9, null, new DateTime(2023, 1, 5, 11, 5, 37, 698, DateTimeKind.Local).AddTicks(8567), new DateTime(2022, 9, 6, 1, 22, 2, 174, DateTimeKind.Local).AddTicks(7051), null, null, null, null, "draft" },
                    { 10, null, new DateTime(2022, 8, 4, 14, 33, 30, 80, DateTimeKind.Local).AddTicks(3375), new DateTime(2022, 8, 5, 12, 3, 46, 549, DateTimeKind.Local).AddTicks(6200), null, null, null, null, "draft" },
                    { 11, null, new DateTime(2022, 5, 6, 23, 44, 33, 404, DateTimeKind.Local).AddTicks(3358), new DateTime(2023, 3, 15, 13, 43, 7, 380, DateTimeKind.Local).AddTicks(3374), null, null, null, null, "draft" },
                    { 12, null, new DateTime(2023, 2, 18, 22, 15, 17, 497, DateTimeKind.Local).AddTicks(3157), new DateTime(2022, 11, 30, 5, 44, 6, 599, DateTimeKind.Local).AddTicks(3828), null, null, null, null, "draft" },
                    { 13, null, new DateTime(2022, 7, 1, 9, 46, 47, 925, DateTimeKind.Local).AddTicks(5184), new DateTime(2023, 2, 15, 19, 16, 10, 365, DateTimeKind.Local).AddTicks(5426), null, null, null, null, "draft" },
                    { 14, null, new DateTime(2022, 7, 2, 22, 15, 26, 180, DateTimeKind.Local).AddTicks(5132), new DateTime(2022, 12, 27, 12, 28, 56, 660, DateTimeKind.Local).AddTicks(2021), null, null, null, null, "draft" },
                    { 15, null, new DateTime(2022, 6, 22, 6, 4, 21, 929, DateTimeKind.Local).AddTicks(2250), new DateTime(2022, 5, 30, 2, 19, 43, 73, DateTimeKind.Local).AddTicks(5823), null, null, null, null, "draft" },
                    { 16, null, new DateTime(2022, 9, 27, 14, 35, 36, 674, DateTimeKind.Local).AddTicks(3855), new DateTime(2022, 7, 31, 1, 12, 42, 850, DateTimeKind.Local).AddTicks(6074), null, null, null, null, "draft" },
                    { 17, null, new DateTime(2022, 8, 6, 9, 58, 13, 142, DateTimeKind.Local).AddTicks(6062), new DateTime(2023, 4, 13, 16, 32, 22, 704, DateTimeKind.Local).AddTicks(7453), null, null, null, null, "draft" },
                    { 18, null, new DateTime(2022, 4, 21, 14, 58, 1, 927, DateTimeKind.Local).AddTicks(9240), new DateTime(2022, 6, 28, 8, 35, 59, 94, DateTimeKind.Local).AddTicks(8554), null, null, null, null, "draft" },
                    { 19, null, new DateTime(2022, 6, 9, 5, 12, 28, 365, DateTimeKind.Local).AddTicks(1858), new DateTime(2023, 3, 26, 20, 16, 21, 653, DateTimeKind.Local).AddTicks(4249), null, null, null, null, "draft" },
                    { 20, null, new DateTime(2022, 10, 12, 21, 42, 45, 92, DateTimeKind.Local).AddTicks(196), new DateTime(2022, 10, 8, 22, 32, 22, 514, DateTimeKind.Local).AddTicks(9382), null, null, null, null, "draft" },
                    { 21, null, new DateTime(2023, 1, 9, 1, 51, 12, 312, DateTimeKind.Local).AddTicks(8797), new DateTime(2022, 4, 20, 22, 8, 44, 813, DateTimeKind.Local).AddTicks(3944), null, null, null, null, "draft" },
                    { 22, null, new DateTime(2022, 8, 9, 9, 43, 37, 271, DateTimeKind.Local).AddTicks(8429), new DateTime(2022, 11, 28, 13, 3, 0, 596, DateTimeKind.Local).AddTicks(1363), null, null, null, null, "draft" },
                    { 23, null, new DateTime(2022, 11, 11, 3, 2, 11, 763, DateTimeKind.Local).AddTicks(450), new DateTime(2022, 8, 15, 3, 14, 57, 708, DateTimeKind.Local).AddTicks(4385), null, null, null, null, "draft" },
                    { 24, null, new DateTime(2022, 8, 14, 9, 56, 18, 44, DateTimeKind.Local).AddTicks(8258), new DateTime(2022, 10, 28, 1, 25, 10, 514, DateTimeKind.Local).AddTicks(9159), null, null, null, null, "draft" },
                    { 25, null, new DateTime(2023, 1, 19, 9, 49, 3, 220, DateTimeKind.Local).AddTicks(7516), new DateTime(2022, 12, 10, 15, 16, 51, 593, DateTimeKind.Local).AddTicks(8615), null, null, null, null, "draft" },
                    { 26, null, new DateTime(2022, 10, 8, 13, 49, 43, 53, DateTimeKind.Local).AddTicks(9637), new DateTime(2023, 2, 15, 19, 37, 7, 585, DateTimeKind.Local).AddTicks(8525), null, null, null, null, "draft" },
                    { 27, null, new DateTime(2022, 12, 13, 3, 41, 33, 259, DateTimeKind.Local).AddTicks(6352), new DateTime(2022, 8, 9, 4, 33, 14, 105, DateTimeKind.Local).AddTicks(990), null, null, null, null, "draft" },
                    { 28, null, new DateTime(2022, 11, 25, 10, 20, 53, 711, DateTimeKind.Local).AddTicks(3035), new DateTime(2023, 2, 20, 23, 32, 53, 161, DateTimeKind.Local).AddTicks(5242), null, null, null, null, "draft" },
                    { 29, null, new DateTime(2022, 5, 6, 23, 13, 53, 450, DateTimeKind.Local).AddTicks(1442), new DateTime(2023, 3, 18, 14, 51, 17, 612, DateTimeKind.Local).AddTicks(76), null, null, null, null, "draft" },
                    { 30, null, new DateTime(2022, 4, 28, 6, 34, 17, 494, DateTimeKind.Local).AddTicks(2390), new DateTime(2022, 10, 22, 12, 28, 6, 811, DateTimeKind.Local).AddTicks(8502), null, null, null, null, "draft" },
                    { 31, null, new DateTime(2022, 8, 28, 10, 10, 14, 716, DateTimeKind.Local).AddTicks(7032), new DateTime(2023, 4, 1, 13, 20, 50, 782, DateTimeKind.Local).AddTicks(7418), null, null, null, null, "draft" },
                    { 32, null, new DateTime(2023, 3, 5, 13, 17, 50, 342, DateTimeKind.Local).AddTicks(7232), new DateTime(2023, 1, 30, 6, 10, 51, 58, DateTimeKind.Local).AddTicks(9401), null, null, null, null, "draft" },
                    { 33, null, new DateTime(2023, 3, 18, 5, 5, 57, 944, DateTimeKind.Local).AddTicks(5090), new DateTime(2022, 12, 25, 19, 31, 59, 635, DateTimeKind.Local).AddTicks(5733), null, null, null, null, "draft" },
                    { 34, null, new DateTime(2022, 9, 30, 8, 53, 52, 735, DateTimeKind.Local).AddTicks(8837), new DateTime(2022, 12, 27, 18, 53, 57, 194, DateTimeKind.Local).AddTicks(7647), null, null, null, null, "draft" },
                    { 35, null, new DateTime(2022, 4, 19, 10, 16, 34, 314, DateTimeKind.Local).AddTicks(4065), new DateTime(2022, 6, 2, 23, 36, 19, 240, DateTimeKind.Local).AddTicks(5173), null, null, null, null, "draft" },
                    { 36, null, new DateTime(2022, 7, 2, 1, 34, 40, 241, DateTimeKind.Local).AddTicks(5141), new DateTime(2023, 1, 28, 6, 37, 22, 551, DateTimeKind.Local).AddTicks(3780), null, null, null, null, "draft" },
                    { 37, null, new DateTime(2023, 3, 12, 19, 27, 23, 588, DateTimeKind.Local).AddTicks(6327), new DateTime(2023, 2, 12, 7, 49, 14, 71, DateTimeKind.Local).AddTicks(3465), null, null, null, null, "draft" },
                    { 38, null, new DateTime(2022, 11, 13, 2, 0, 40, 742, DateTimeKind.Local).AddTicks(6881), new DateTime(2022, 5, 4, 17, 23, 55, 96, DateTimeKind.Local).AddTicks(8893), null, null, null, null, "draft" },
                    { 39, null, new DateTime(2022, 11, 22, 19, 47, 36, 614, DateTimeKind.Local).AddTicks(4433), new DateTime(2022, 7, 10, 1, 0, 23, 407, DateTimeKind.Local).AddTicks(1282), null, null, null, null, "draft" },
                    { 40, null, new DateTime(2022, 5, 7, 18, 30, 1, 342, DateTimeKind.Local).AddTicks(2876), new DateTime(2023, 3, 4, 22, 19, 56, 723, DateTimeKind.Local).AddTicks(297), null, null, null, null, "draft" },
                    { 41, null, new DateTime(2022, 10, 21, 1, 7, 58, 826, DateTimeKind.Local).AddTicks(6673), new DateTime(2022, 12, 22, 12, 38, 22, 171, DateTimeKind.Local).AddTicks(5478), null, null, null, null, "draft" },
                    { 42, null, new DateTime(2023, 3, 26, 18, 27, 59, 945, DateTimeKind.Local).AddTicks(4019), new DateTime(2022, 10, 29, 6, 35, 36, 841, DateTimeKind.Local).AddTicks(3148), null, null, null, null, "draft" },
                    { 43, null, new DateTime(2022, 12, 8, 4, 18, 6, 525, DateTimeKind.Local).AddTicks(5708), new DateTime(2022, 11, 28, 10, 46, 35, 594, DateTimeKind.Local).AddTicks(4853), null, null, null, null, "draft" },
                    { 44, null, new DateTime(2022, 12, 4, 13, 19, 16, 96, DateTimeKind.Local).AddTicks(9254), new DateTime(2023, 4, 15, 21, 13, 5, 543, DateTimeKind.Local).AddTicks(4604), null, null, null, null, "draft" },
                    { 45, null, new DateTime(2022, 9, 4, 21, 59, 35, 499, DateTimeKind.Local).AddTicks(4015), new DateTime(2022, 6, 17, 7, 13, 15, 272, DateTimeKind.Local).AddTicks(3597), null, null, null, null, "draft" },
                    { 46, null, new DateTime(2022, 6, 10, 1, 10, 12, 150, DateTimeKind.Local).AddTicks(6720), new DateTime(2022, 7, 10, 6, 9, 17, 259, DateTimeKind.Local).AddTicks(1390), null, null, null, null, "draft" },
                    { 47, null, new DateTime(2023, 3, 17, 5, 30, 10, 665, DateTimeKind.Local).AddTicks(1475), new DateTime(2023, 4, 9, 1, 2, 44, 786, DateTimeKind.Local).AddTicks(1310), null, null, null, null, "draft" },
                    { 48, null, new DateTime(2022, 5, 30, 4, 10, 14, 304, DateTimeKind.Local).AddTicks(1975), new DateTime(2023, 1, 26, 4, 18, 28, 36, DateTimeKind.Local).AddTicks(1006), null, null, null, null, "draft" },
                    { 49, null, new DateTime(2022, 6, 4, 0, 39, 0, 976, DateTimeKind.Local).AddTicks(6346), new DateTime(2022, 10, 26, 19, 20, 52, 718, DateTimeKind.Local).AddTicks(8662), null, null, null, null, "draft" },
                    { 50, null, new DateTime(2022, 12, 29, 23, 45, 9, 157, DateTimeKind.Local).AddTicks(5915), new DateTime(2023, 3, 4, 23, 18, 18, 633, DateTimeKind.Local).AddTicks(4358), null, null, null, null, "draft" },
                    { 51, null, new DateTime(2023, 3, 3, 10, 9, 11, 478, DateTimeKind.Local).AddTicks(5198), new DateTime(2022, 12, 4, 6, 50, 27, 356, DateTimeKind.Local).AddTicks(261), null, null, null, null, "draft" },
                    { 52, null, new DateTime(2022, 10, 27, 6, 56, 42, 706, DateTimeKind.Local).AddTicks(4753), new DateTime(2022, 12, 5, 2, 0, 50, 486, DateTimeKind.Local).AddTicks(2003), null, null, null, null, "draft" },
                    { 53, null, new DateTime(2022, 9, 27, 5, 30, 17, 858, DateTimeKind.Local).AddTicks(3143), new DateTime(2022, 12, 27, 23, 0, 27, 8, DateTimeKind.Local).AddTicks(5524), null, null, null, null, "draft" },
                    { 54, null, new DateTime(2023, 3, 24, 15, 57, 50, 503, DateTimeKind.Local).AddTicks(1875), new DateTime(2023, 2, 16, 11, 40, 25, 694, DateTimeKind.Local).AddTicks(2563), null, null, null, null, "draft" },
                    { 55, null, new DateTime(2023, 1, 12, 18, 20, 39, 868, DateTimeKind.Local).AddTicks(3793), new DateTime(2022, 11, 9, 8, 45, 5, 120, DateTimeKind.Local).AddTicks(3770), null, null, null, null, "draft" },
                    { 56, null, new DateTime(2022, 7, 17, 19, 33, 23, 53, DateTimeKind.Local).AddTicks(443), new DateTime(2023, 2, 13, 14, 1, 36, 548, DateTimeKind.Local).AddTicks(9795), null, null, null, null, "draft" },
                    { 57, null, new DateTime(2023, 2, 27, 12, 9, 22, 775, DateTimeKind.Local).AddTicks(6843), new DateTime(2022, 6, 12, 0, 2, 27, 277, DateTimeKind.Local).AddTicks(1736), null, null, null, null, "draft" },
                    { 58, null, new DateTime(2022, 4, 20, 3, 8, 14, 491, DateTimeKind.Local).AddTicks(1481), new DateTime(2022, 12, 23, 13, 19, 59, 51, DateTimeKind.Local).AddTicks(1205), null, null, null, null, "draft" },
                    { 59, null, new DateTime(2022, 4, 24, 10, 40, 57, 343, DateTimeKind.Local).AddTicks(3058), new DateTime(2022, 8, 23, 22, 30, 20, 7, DateTimeKind.Local).AddTicks(3743), null, null, null, null, "draft" },
                    { 60, null, new DateTime(2022, 6, 10, 17, 40, 51, 39, DateTimeKind.Local).AddTicks(3360), new DateTime(2022, 8, 6, 10, 7, 28, 855, DateTimeKind.Local).AddTicks(9905), null, null, null, null, "draft" },
                    { 61, null, new DateTime(2022, 5, 9, 22, 0, 50, 44, DateTimeKind.Local).AddTicks(6155), new DateTime(2022, 10, 3, 3, 28, 53, 698, DateTimeKind.Local).AddTicks(3909), null, null, null, null, "draft" },
                    { 62, null, new DateTime(2022, 8, 10, 12, 42, 28, 201, DateTimeKind.Local).AddTicks(3316), new DateTime(2023, 2, 18, 18, 51, 25, 548, DateTimeKind.Local).AddTicks(153), null, null, null, null, "draft" },
                    { 63, null, new DateTime(2023, 4, 11, 14, 14, 13, 595, DateTimeKind.Local).AddTicks(8147), new DateTime(2023, 4, 10, 11, 13, 29, 488, DateTimeKind.Local).AddTicks(3445), null, null, null, null, "draft" },
                    { 64, null, new DateTime(2023, 3, 1, 16, 55, 18, 392, DateTimeKind.Local).AddTicks(2007), new DateTime(2023, 3, 22, 10, 12, 45, 308, DateTimeKind.Local).AddTicks(4720), null, null, null, null, "draft" },
                    { 65, null, new DateTime(2023, 1, 1, 19, 27, 6, 273, DateTimeKind.Local).AddTicks(1200), new DateTime(2023, 2, 3, 13, 30, 19, 212, DateTimeKind.Local).AddTicks(5588), null, null, null, null, "draft" },
                    { 66, null, new DateTime(2023, 3, 19, 8, 33, 0, 626, DateTimeKind.Local).AddTicks(2307), new DateTime(2022, 5, 15, 16, 14, 50, 401, DateTimeKind.Local).AddTicks(5532), null, null, null, null, "draft" },
                    { 67, null, new DateTime(2022, 10, 27, 17, 3, 20, 755, DateTimeKind.Local).AddTicks(5138), new DateTime(2022, 6, 21, 10, 59, 49, 214, DateTimeKind.Local).AddTicks(8288), null, null, null, null, "draft" },
                    { 68, null, new DateTime(2022, 4, 20, 3, 58, 51, 750, DateTimeKind.Local).AddTicks(4878), new DateTime(2023, 3, 5, 10, 5, 37, 976, DateTimeKind.Local).AddTicks(6192), null, null, null, null, "draft" },
                    { 69, null, new DateTime(2022, 6, 13, 21, 29, 45, 971, DateTimeKind.Local).AddTicks(513), new DateTime(2022, 8, 8, 8, 15, 15, 965, DateTimeKind.Local).AddTicks(1804), null, null, null, null, "draft" },
                    { 70, null, new DateTime(2022, 5, 20, 16, 53, 25, 488, DateTimeKind.Local).AddTicks(9803), new DateTime(2023, 3, 29, 21, 5, 46, 22, DateTimeKind.Local).AddTicks(9982), null, null, null, null, "draft" },
                    { 71, null, new DateTime(2022, 12, 23, 10, 36, 51, 597, DateTimeKind.Local).AddTicks(2785), new DateTime(2023, 2, 3, 17, 26, 56, 908, DateTimeKind.Local).AddTicks(6497), null, null, null, null, "draft" },
                    { 72, null, new DateTime(2022, 7, 20, 18, 40, 32, 181, DateTimeKind.Local).AddTicks(625), new DateTime(2023, 2, 12, 5, 2, 36, 885, DateTimeKind.Local).AddTicks(60), null, null, null, null, "draft" },
                    { 73, null, new DateTime(2023, 3, 19, 3, 27, 58, 725, DateTimeKind.Local).AddTicks(2977), new DateTime(2022, 8, 13, 2, 56, 42, 107, DateTimeKind.Local).AddTicks(6747), null, null, null, null, "draft" },
                    { 74, null, new DateTime(2022, 8, 29, 9, 48, 0, 989, DateTimeKind.Local).AddTicks(4378), new DateTime(2023, 1, 21, 21, 15, 49, 893, DateTimeKind.Local).AddTicks(9571), null, null, null, null, "draft" },
                    { 75, null, new DateTime(2023, 4, 7, 13, 42, 36, 800, DateTimeKind.Local).AddTicks(9670), new DateTime(2022, 9, 23, 6, 38, 21, 759, DateTimeKind.Local).AddTicks(611), null, null, null, null, "draft" },
                    { 76, null, new DateTime(2023, 1, 20, 9, 25, 37, 198, DateTimeKind.Local).AddTicks(7796), new DateTime(2023, 1, 27, 17, 56, 47, 475, DateTimeKind.Local).AddTicks(2453), null, null, null, null, "draft" },
                    { 77, null, new DateTime(2022, 9, 3, 17, 28, 8, 185, DateTimeKind.Local).AddTicks(5160), new DateTime(2022, 9, 11, 5, 25, 46, 807, DateTimeKind.Local).AddTicks(5867), null, null, null, null, "draft" },
                    { 78, null, new DateTime(2023, 2, 11, 17, 5, 35, 94, DateTimeKind.Local).AddTicks(8068), new DateTime(2022, 9, 16, 22, 28, 24, 286, DateTimeKind.Local).AddTicks(1155), null, null, null, null, "draft" },
                    { 79, null, new DateTime(2022, 8, 12, 9, 56, 5, 660, DateTimeKind.Local).AddTicks(6819), new DateTime(2022, 12, 25, 3, 53, 23, 664, DateTimeKind.Local).AddTicks(4476), null, null, null, null, "draft" },
                    { 80, null, new DateTime(2022, 12, 12, 3, 34, 43, 396, DateTimeKind.Local).AddTicks(3739), new DateTime(2022, 10, 5, 10, 4, 54, 875, DateTimeKind.Local).AddTicks(9581), null, null, null, null, "draft" },
                    { 81, null, new DateTime(2023, 2, 13, 21, 53, 15, 122, DateTimeKind.Local).AddTicks(3408), new DateTime(2022, 4, 20, 21, 33, 11, 700, DateTimeKind.Local).AddTicks(7046), null, null, null, null, "draft" },
                    { 82, null, new DateTime(2022, 6, 3, 8, 1, 25, 927, DateTimeKind.Local).AddTicks(1263), new DateTime(2023, 3, 27, 20, 38, 27, 161, DateTimeKind.Local).AddTicks(8106), null, null, null, null, "draft" },
                    { 83, null, new DateTime(2022, 12, 9, 16, 0, 11, 0, DateTimeKind.Local).AddTicks(1413), new DateTime(2022, 6, 20, 19, 6, 39, 157, DateTimeKind.Local).AddTicks(4862), null, null, null, null, "draft" },
                    { 84, null, new DateTime(2022, 8, 5, 12, 46, 22, 299, DateTimeKind.Local).AddTicks(4616), new DateTime(2022, 12, 25, 16, 57, 40, 66, DateTimeKind.Local).AddTicks(8516), null, null, null, null, "draft" },
                    { 85, null, new DateTime(2022, 6, 10, 11, 51, 42, 32, DateTimeKind.Local).AddTicks(6828), new DateTime(2022, 6, 3, 8, 50, 43, 20, DateTimeKind.Local).AddTicks(5258), null, null, null, null, "draft" },
                    { 86, null, new DateTime(2022, 10, 28, 7, 38, 19, 586, DateTimeKind.Local).AddTicks(669), new DateTime(2023, 1, 2, 18, 13, 47, 884, DateTimeKind.Local).AddTicks(1232), null, null, null, null, "draft" },
                    { 87, null, new DateTime(2022, 7, 22, 21, 25, 1, 24, DateTimeKind.Local).AddTicks(3927), new DateTime(2022, 6, 30, 12, 23, 11, 522, DateTimeKind.Local).AddTicks(3365), null, null, null, null, "draft" },
                    { 88, null, new DateTime(2022, 11, 30, 15, 18, 43, 764, DateTimeKind.Local).AddTicks(7116), new DateTime(2022, 7, 22, 20, 21, 59, 641, DateTimeKind.Local).AddTicks(9655), null, null, null, null, "draft" },
                    { 89, null, new DateTime(2022, 7, 2, 0, 36, 28, 23, DateTimeKind.Local).AddTicks(3288), new DateTime(2022, 10, 14, 23, 27, 57, 822, DateTimeKind.Local).AddTicks(3260), null, null, null, null, "draft" },
                    { 90, null, new DateTime(2023, 3, 21, 7, 11, 33, 328, DateTimeKind.Local).AddTicks(7189), new DateTime(2022, 12, 16, 3, 5, 37, 994, DateTimeKind.Local).AddTicks(1413), null, null, null, null, "draft" },
                    { 91, null, new DateTime(2022, 11, 28, 17, 13, 35, 4, DateTimeKind.Local).AddTicks(9089), new DateTime(2022, 5, 27, 11, 27, 35, 4, DateTimeKind.Local).AddTicks(2460), null, null, null, null, "draft" },
                    { 92, null, new DateTime(2023, 4, 2, 12, 18, 15, 13, DateTimeKind.Local).AddTicks(5082), new DateTime(2022, 7, 28, 4, 36, 51, 20, DateTimeKind.Local).AddTicks(621), null, null, null, null, "draft" },
                    { 93, null, new DateTime(2022, 5, 2, 19, 52, 48, 519, DateTimeKind.Local).AddTicks(7831), new DateTime(2022, 6, 8, 6, 24, 19, 656, DateTimeKind.Local).AddTicks(9852), null, null, null, null, "draft" },
                    { 94, null, new DateTime(2022, 12, 28, 14, 34, 48, 722, DateTimeKind.Local).AddTicks(378), new DateTime(2022, 6, 4, 3, 25, 40, 453, DateTimeKind.Local).AddTicks(9277), null, null, null, null, "draft" },
                    { 95, null, new DateTime(2022, 8, 26, 9, 42, 20, 626, DateTimeKind.Local).AddTicks(234), new DateTime(2022, 11, 19, 21, 18, 33, 970, DateTimeKind.Local).AddTicks(3737), null, null, null, null, "draft" },
                    { 96, null, new DateTime(2022, 11, 9, 15, 57, 38, 821, DateTimeKind.Local).AddTicks(9395), new DateTime(2022, 10, 6, 9, 24, 28, 812, DateTimeKind.Local).AddTicks(6060), null, null, null, null, "draft" },
                    { 97, null, new DateTime(2022, 12, 13, 20, 28, 39, 74, DateTimeKind.Local).AddTicks(8096), new DateTime(2022, 12, 1, 22, 36, 37, 119, DateTimeKind.Local).AddTicks(254), null, null, null, null, "draft" },
                    { 98, null, new DateTime(2022, 6, 1, 15, 0, 37, 406, DateTimeKind.Local).AddTicks(6614), new DateTime(2022, 12, 21, 4, 51, 46, 402, DateTimeKind.Local).AddTicks(5779), null, null, null, null, "draft" },
                    { 99, null, new DateTime(2022, 12, 20, 1, 13, 37, 487, DateTimeKind.Local).AddTicks(5282), new DateTime(2022, 8, 11, 13, 50, 11, 525, DateTimeKind.Local).AddTicks(2568), null, null, null, null, "draft" },
                    { 100, null, new DateTime(2022, 6, 22, 4, 50, 32, 390, DateTimeKind.Local).AddTicks(8705), new DateTime(2023, 1, 15, 0, 9, 26, 73, DateTimeKind.Local).AddTicks(8172), null, null, null, null, "draft" },
                    { 101, null, new DateTime(2022, 4, 26, 5, 58, 26, 314, DateTimeKind.Local).AddTicks(2197), new DateTime(2022, 12, 21, 8, 38, 27, 428, DateTimeKind.Local).AddTicks(5929), null, null, null, null, "draft" },
                    { 102, null, new DateTime(2022, 11, 30, 1, 12, 14, 367, DateTimeKind.Local).AddTicks(2817), new DateTime(2023, 2, 20, 20, 40, 0, 286, DateTimeKind.Local).AddTicks(4486), null, null, null, null, "draft" },
                    { 103, null, new DateTime(2023, 3, 14, 14, 48, 8, 679, DateTimeKind.Local).AddTicks(25), new DateTime(2022, 5, 6, 6, 59, 55, 820, DateTimeKind.Local).AddTicks(6647), null, null, null, null, "draft" },
                    { 104, null, new DateTime(2022, 10, 24, 12, 19, 52, 956, DateTimeKind.Local).AddTicks(8660), new DateTime(2022, 6, 22, 20, 53, 3, 169, DateTimeKind.Local).AddTicks(1931), null, null, null, null, "draft" },
                    { 105, null, new DateTime(2023, 1, 28, 5, 55, 9, 548, DateTimeKind.Local).AddTicks(8895), new DateTime(2022, 11, 8, 12, 31, 41, 958, DateTimeKind.Local).AddTicks(8558), null, null, null, null, "draft" },
                    { 106, null, new DateTime(2022, 7, 4, 13, 40, 2, 768, DateTimeKind.Local).AddTicks(8019), new DateTime(2023, 2, 14, 2, 16, 14, 344, DateTimeKind.Local).AddTicks(3711), null, null, null, null, "draft" },
                    { 107, null, new DateTime(2023, 1, 22, 12, 29, 56, 841, DateTimeKind.Local).AddTicks(7448), new DateTime(2023, 4, 14, 16, 17, 11, 908, DateTimeKind.Local).AddTicks(2488), null, null, null, null, "draft" },
                    { 108, null, new DateTime(2023, 2, 23, 8, 39, 26, 377, DateTimeKind.Local).AddTicks(662), new DateTime(2023, 1, 6, 2, 13, 46, 624, DateTimeKind.Local).AddTicks(1119), null, null, null, null, "draft" },
                    { 109, null, new DateTime(2022, 5, 7, 1, 3, 3, 193, DateTimeKind.Local).AddTicks(2143), new DateTime(2023, 2, 22, 19, 12, 41, 413, DateTimeKind.Local).AddTicks(820), null, null, null, null, "draft" },
                    { 110, null, new DateTime(2023, 3, 13, 16, 33, 45, 148, DateTimeKind.Local).AddTicks(462), new DateTime(2022, 10, 20, 1, 23, 57, 849, DateTimeKind.Local).AddTicks(1748), null, null, null, null, "draft" },
                    { 111, null, new DateTime(2022, 10, 9, 20, 19, 56, 941, DateTimeKind.Local).AddTicks(4680), new DateTime(2022, 6, 20, 1, 8, 48, 351, DateTimeKind.Local).AddTicks(5537), null, null, null, null, "draft" },
                    { 112, null, new DateTime(2022, 8, 17, 23, 3, 25, 946, DateTimeKind.Local).AddTicks(8486), new DateTime(2022, 11, 7, 6, 21, 14, 568, DateTimeKind.Local).AddTicks(3297), null, null, null, null, "draft" },
                    { 113, null, new DateTime(2022, 11, 10, 8, 41, 10, 704, DateTimeKind.Local).AddTicks(6077), new DateTime(2022, 5, 10, 14, 1, 57, 279, DateTimeKind.Local).AddTicks(4822), null, null, null, null, "draft" },
                    { 114, null, new DateTime(2022, 5, 8, 13, 33, 15, 315, DateTimeKind.Local).AddTicks(3358), new DateTime(2022, 12, 7, 14, 36, 30, 411, DateTimeKind.Local).AddTicks(3896), null, null, null, null, "draft" },
                    { 115, null, new DateTime(2022, 5, 17, 13, 10, 40, 621, DateTimeKind.Local).AddTicks(6982), new DateTime(2023, 3, 29, 2, 15, 3, 868, DateTimeKind.Local).AddTicks(1568), null, null, null, null, "draft" },
                    { 116, null, new DateTime(2022, 11, 19, 10, 56, 28, 660, DateTimeKind.Local).AddTicks(4611), new DateTime(2023, 3, 9, 2, 34, 23, 4, DateTimeKind.Local).AddTicks(960), null, null, null, null, "draft" },
                    { 117, null, new DateTime(2022, 8, 11, 10, 25, 31, 937, DateTimeKind.Local).AddTicks(4803), new DateTime(2022, 6, 22, 22, 50, 13, 760, DateTimeKind.Local).AddTicks(9264), null, null, null, null, "draft" },
                    { 118, null, new DateTime(2022, 12, 8, 12, 55, 18, 185, DateTimeKind.Local).AddTicks(9473), new DateTime(2023, 3, 27, 0, 23, 14, 82, DateTimeKind.Local).AddTicks(3417), null, null, null, null, "draft" },
                    { 119, null, new DateTime(2022, 10, 14, 2, 3, 27, 142, DateTimeKind.Local).AddTicks(9908), new DateTime(2022, 5, 29, 7, 26, 21, 233, DateTimeKind.Local).AddTicks(860), null, null, null, null, "draft" },
                    { 120, null, new DateTime(2022, 9, 1, 5, 36, 48, 847, DateTimeKind.Local).AddTicks(870), new DateTime(2023, 4, 15, 4, 40, 59, 205, DateTimeKind.Local).AddTicks(1457), null, null, null, null, "draft" },
                    { 121, null, new DateTime(2022, 12, 1, 9, 52, 33, 206, DateTimeKind.Local).AddTicks(1517), new DateTime(2022, 10, 24, 9, 29, 52, 58, DateTimeKind.Local).AddTicks(8773), null, null, null, null, "draft" },
                    { 122, null, new DateTime(2022, 8, 23, 13, 18, 37, 411, DateTimeKind.Local).AddTicks(716), new DateTime(2023, 2, 3, 12, 58, 45, 173, DateTimeKind.Local).AddTicks(2010), null, null, null, null, "draft" },
                    { 123, null, new DateTime(2022, 9, 3, 23, 26, 37, 707, DateTimeKind.Local).AddTicks(6059), new DateTime(2023, 1, 12, 5, 29, 30, 983, DateTimeKind.Local).AddTicks(6027), null, null, null, null, "draft" },
                    { 124, null, new DateTime(2022, 12, 31, 12, 42, 38, 476, DateTimeKind.Local).AddTicks(8963), new DateTime(2022, 12, 17, 19, 59, 33, 672, DateTimeKind.Local).AddTicks(5960), null, null, null, null, "draft" },
                    { 125, null, new DateTime(2023, 1, 25, 5, 45, 17, 247, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 9, 12, 4, 34, 57, 288, DateTimeKind.Local).AddTicks(5855), null, null, null, null, "draft" },
                    { 126, null, new DateTime(2022, 12, 2, 19, 36, 49, 715, DateTimeKind.Local).AddTicks(4004), new DateTime(2023, 2, 12, 21, 49, 2, 580, DateTimeKind.Local).AddTicks(4831), null, null, null, null, "draft" },
                    { 127, null, new DateTime(2022, 9, 16, 13, 4, 32, 883, DateTimeKind.Local).AddTicks(2483), new DateTime(2022, 12, 19, 19, 14, 41, 47, DateTimeKind.Local).AddTicks(7333), null, null, null, null, "draft" },
                    { 128, null, new DateTime(2022, 7, 24, 19, 37, 35, 638, DateTimeKind.Local).AddTicks(3877), new DateTime(2023, 2, 22, 20, 37, 44, 468, DateTimeKind.Local).AddTicks(7045), null, null, null, null, "draft" },
                    { 129, null, new DateTime(2022, 8, 22, 1, 23, 7, 987, DateTimeKind.Local).AddTicks(7835), new DateTime(2022, 5, 11, 10, 39, 6, 304, DateTimeKind.Local).AddTicks(9913), null, null, null, null, "draft" },
                    { 130, null, new DateTime(2022, 7, 30, 3, 46, 56, 87, DateTimeKind.Local).AddTicks(8811), new DateTime(2023, 2, 20, 16, 34, 17, 905, DateTimeKind.Local).AddTicks(5605), null, null, null, null, "draft" },
                    { 131, null, new DateTime(2023, 4, 16, 9, 14, 47, 11, DateTimeKind.Local).AddTicks(3700), new DateTime(2023, 3, 5, 13, 31, 29, 51, DateTimeKind.Local).AddTicks(5134), null, null, null, null, "draft" },
                    { 132, null, new DateTime(2022, 5, 24, 23, 30, 29, 53, DateTimeKind.Local).AddTicks(5325), new DateTime(2023, 2, 17, 19, 28, 12, 186, DateTimeKind.Local).AddTicks(7703), null, null, null, null, "draft" },
                    { 133, null, new DateTime(2023, 4, 7, 17, 23, 19, 804, DateTimeKind.Local).AddTicks(4331), new DateTime(2022, 8, 14, 2, 53, 46, 270, DateTimeKind.Local).AddTicks(7445), null, null, null, null, "draft" },
                    { 134, null, new DateTime(2022, 10, 22, 7, 38, 48, 912, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 11, 18, 5, 27, 49, 586, DateTimeKind.Local).AddTicks(8577), null, null, null, null, "draft" },
                    { 135, null, new DateTime(2022, 8, 23, 19, 10, 0, 228, DateTimeKind.Local).AddTicks(3416), new DateTime(2023, 3, 18, 0, 4, 18, 800, DateTimeKind.Local).AddTicks(7647), null, null, null, null, "draft" },
                    { 136, null, new DateTime(2022, 7, 11, 15, 58, 25, 987, DateTimeKind.Local).AddTicks(1620), new DateTime(2023, 3, 27, 9, 24, 48, 466, DateTimeKind.Local).AddTicks(1693), null, null, null, null, "draft" },
                    { 137, null, new DateTime(2022, 10, 10, 5, 23, 59, 72, DateTimeKind.Local).AddTicks(369), new DateTime(2023, 3, 17, 3, 40, 52, 448, DateTimeKind.Local).AddTicks(9424), null, null, null, null, "draft" },
                    { 138, null, new DateTime(2023, 3, 7, 7, 19, 31, 149, DateTimeKind.Local).AddTicks(659), new DateTime(2023, 4, 4, 2, 38, 11, 388, DateTimeKind.Local).AddTicks(6335), null, null, null, null, "draft" },
                    { 139, null, new DateTime(2023, 2, 13, 3, 38, 17, 446, DateTimeKind.Local).AddTicks(5255), new DateTime(2022, 10, 31, 1, 52, 47, 279, DateTimeKind.Local).AddTicks(6913), null, null, null, null, "draft" },
                    { 140, null, new DateTime(2022, 6, 21, 22, 42, 43, 366, DateTimeKind.Local).AddTicks(7683), new DateTime(2023, 2, 14, 18, 59, 46, 227, DateTimeKind.Local).AddTicks(495), null, null, null, null, "draft" },
                    { 141, null, new DateTime(2022, 8, 26, 17, 7, 25, 308, DateTimeKind.Local).AddTicks(6311), new DateTime(2022, 9, 7, 9, 21, 48, 148, DateTimeKind.Local).AddTicks(7850), null, null, null, null, "draft" },
                    { 142, null, new DateTime(2023, 3, 1, 0, 39, 19, 669, DateTimeKind.Local).AddTicks(4446), new DateTime(2022, 12, 22, 0, 23, 49, 839, DateTimeKind.Local).AddTicks(1630), null, null, null, null, "draft" },
                    { 143, null, new DateTime(2022, 8, 12, 22, 26, 20, 658, DateTimeKind.Local).AddTicks(8077), new DateTime(2023, 1, 23, 4, 55, 32, 586, DateTimeKind.Local).AddTicks(292), null, null, null, null, "draft" },
                    { 144, null, new DateTime(2022, 10, 9, 5, 17, 56, 626, DateTimeKind.Local).AddTicks(8996), new DateTime(2022, 12, 9, 6, 58, 57, 395, DateTimeKind.Local).AddTicks(7991), null, null, null, null, "draft" },
                    { 145, null, new DateTime(2023, 3, 17, 19, 0, 44, 628, DateTimeKind.Local).AddTicks(5916), new DateTime(2023, 2, 1, 8, 5, 40, 223, DateTimeKind.Local).AddTicks(2956), null, null, null, null, "draft" },
                    { 146, null, new DateTime(2022, 11, 21, 14, 48, 12, 600, DateTimeKind.Local).AddTicks(6119), new DateTime(2022, 9, 21, 7, 12, 27, 344, DateTimeKind.Local).AddTicks(533), null, null, null, null, "draft" },
                    { 147, null, new DateTime(2023, 2, 15, 19, 27, 31, 651, DateTimeKind.Local).AddTicks(2596), new DateTime(2022, 10, 28, 4, 50, 37, 447, DateTimeKind.Local).AddTicks(5811), null, null, null, null, "draft" },
                    { 148, null, new DateTime(2023, 4, 17, 11, 14, 18, 699, DateTimeKind.Local).AddTicks(8311), new DateTime(2023, 1, 14, 12, 9, 10, 660, DateTimeKind.Local).AddTicks(6938), null, null, null, null, "draft" },
                    { 149, null, new DateTime(2022, 9, 18, 1, 47, 29, 511, DateTimeKind.Local).AddTicks(4011), new DateTime(2022, 10, 22, 9, 38, 31, 730, DateTimeKind.Local).AddTicks(3579), null, null, null, null, "draft" },
                    { 150, null, new DateTime(2023, 2, 14, 11, 23, 31, 874, DateTimeKind.Local).AddTicks(8251), new DateTime(2022, 5, 9, 12, 20, 57, 942, DateTimeKind.Local).AddTicks(9187), null, null, null, null, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 5, 41, 4, 430, DateTimeKind.Local).AddTicks(4304), new DateTime(2022, 10, 30, 4, 47, 17, 694, DateTimeKind.Local).AddTicks(3757), "Chrysler" },
                    { 2, new DateTime(2022, 8, 21, 15, 56, 10, 660, DateTimeKind.Local).AddTicks(3862), new DateTime(2022, 11, 11, 16, 37, 34, 380, DateTimeKind.Local).AddTicks(2092), "Polestar" },
                    { 3, new DateTime(2022, 5, 9, 3, 34, 5, 754, DateTimeKind.Local).AddTicks(9407), new DateTime(2023, 3, 12, 16, 42, 27, 615, DateTimeKind.Local).AddTicks(5146), "Ford" },
                    { 4, new DateTime(2023, 4, 8, 4, 56, 35, 969, DateTimeKind.Local).AddTicks(1725), new DateTime(2023, 1, 18, 3, 3, 59, 361, DateTimeKind.Local).AddTicks(4807), "Mazda" },
                    { 5, new DateTime(2022, 4, 22, 9, 26, 29, 725, DateTimeKind.Local).AddTicks(3206), new DateTime(2022, 8, 12, 16, 24, 11, 818, DateTimeKind.Local).AddTicks(3625), "Fiat" },
                    { 6, new DateTime(2023, 1, 5, 11, 5, 37, 687, DateTimeKind.Local).AddTicks(7920), new DateTime(2022, 9, 6, 1, 22, 2, 163, DateTimeKind.Local).AddTicks(6404), "Mazda" },
                    { 7, new DateTime(2022, 8, 5, 12, 3, 46, 538, DateTimeKind.Local).AddTicks(5554), new DateTime(2022, 5, 6, 23, 44, 33, 393, DateTimeKind.Local).AddTicks(2709), "Mini" },
                    { 8, new DateTime(2023, 2, 18, 22, 15, 17, 486, DateTimeKind.Local).AddTicks(2509), new DateTime(2022, 11, 30, 5, 44, 6, 588, DateTimeKind.Local).AddTicks(3180), "Bentley" },
                    { 9, new DateTime(2023, 2, 15, 19, 16, 10, 354, DateTimeKind.Local).AddTicks(4779), new DateTime(2022, 7, 2, 22, 15, 26, 169, DateTimeKind.Local).AddTicks(4483), "Porsche" },
                    { 10, new DateTime(2022, 6, 22, 6, 4, 21, 918, DateTimeKind.Local).AddTicks(1602), new DateTime(2022, 5, 30, 2, 19, 43, 62, DateTimeKind.Local).AddTicks(5175), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[] { 10, new DateTime(2022, 6, 22, 6, 4, 21, 921, DateTimeKind.Local).AddTicks(7899), null, null, new DateTime(2022, 5, 30, 2, 19, 43, 66, DateTimeKind.Local).AddTicks(1472), "Home" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 5, 41, 4, 426, DateTimeKind.Local).AddTicks(6955), new DateTime(2022, 10, 30, 4, 47, 17, 690, DateTimeKind.Local).AddTicks(6420), "Ecuador" },
                    { 2, new DateTime(2022, 8, 21, 15, 56, 10, 656, DateTimeKind.Local).AddTicks(6529), new DateTime(2022, 11, 11, 16, 37, 34, 376, DateTimeKind.Local).AddTicks(4760), "Samoa" },
                    { 3, new DateTime(2022, 5, 9, 3, 34, 5, 751, DateTimeKind.Local).AddTicks(2077), new DateTime(2023, 3, 12, 16, 42, 27, 611, DateTimeKind.Local).AddTicks(7816), "Guatemala" },
                    { 4, new DateTime(2023, 4, 8, 4, 56, 35, 965, DateTimeKind.Local).AddTicks(4397), new DateTime(2023, 1, 18, 3, 3, 59, 357, DateTimeKind.Local).AddTicks(7479), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 22, 9, 26, 29, 721, DateTimeKind.Local).AddTicks(5879), new DateTime(2022, 8, 12, 16, 24, 11, 814, DateTimeKind.Local).AddTicks(6298), "Germany" },
                    { 6, new DateTime(2023, 1, 5, 11, 5, 37, 684, DateTimeKind.Local).AddTicks(594), new DateTime(2022, 9, 6, 1, 22, 2, 159, DateTimeKind.Local).AddTicks(9078), "Niue" },
                    { 7, new DateTime(2022, 8, 5, 12, 3, 46, 534, DateTimeKind.Local).AddTicks(8229), new DateTime(2022, 5, 6, 23, 44, 33, 389, DateTimeKind.Local).AddTicks(5384), "Philippines" },
                    { 8, new DateTime(2023, 2, 18, 22, 15, 17, 482, DateTimeKind.Local).AddTicks(5184), new DateTime(2022, 11, 30, 5, 44, 6, 584, DateTimeKind.Local).AddTicks(5856), "Benin" },
                    { 9, new DateTime(2023, 2, 15, 19, 16, 10, 350, DateTimeKind.Local).AddTicks(7455), new DateTime(2022, 7, 2, 22, 15, 26, 165, DateTimeKind.Local).AddTicks(7159), "Seychelles" },
                    { 10, new DateTime(2022, 6, 22, 6, 4, 21, 914, DateTimeKind.Local).AddTicks(4279), new DateTime(2022, 5, 30, 2, 19, 43, 58, DateTimeKind.Local).AddTicks(7852), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "Featured", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 22, 19, 38, 13, 389, DateTimeKind.Local).AddTicks(6803), null, false, new DateTime(2022, 4, 22, 9, 26, 29, 732, DateTimeKind.Local).AddTicks(5185), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 7, 2, 22, 15, 26, 176, DateTimeKind.Local).AddTicks(6763), null, false, new DateTime(2022, 12, 27, 12, 28, 56, 656, DateTimeKind.Local).AddTicks(3661), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 9, 1, 51, 12, 309, DateTimeKind.Local).AddTicks(434), null, false, new DateTime(2022, 4, 20, 22, 8, 44, 809, DateTimeKind.Local).AddTicks(5583), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 25, 10, 20, 53, 707, DateTimeKind.Local).AddTicks(4601), null, false, new DateTime(2023, 2, 20, 23, 32, 53, 157, DateTimeKind.Local).AddTicks(6807), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 19, 10, 16, 34, 310, DateTimeKind.Local).AddTicks(5613), null, false, new DateTime(2022, 6, 2, 23, 36, 19, 236, DateTimeKind.Local).AddTicks(6722), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 26, 18, 27, 59, 941, DateTimeKind.Local).AddTicks(5551), null, false, new DateTime(2022, 10, 29, 6, 35, 36, 837, DateTimeKind.Local).AddTicks(4681), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 4, 0, 39, 0, 972, DateTimeKind.Local).AddTicks(7867), null, false, new DateTime(2022, 10, 26, 19, 20, 52, 715, DateTimeKind.Local).AddTicks(185), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 17, 19, 33, 23, 49, DateTimeKind.Local).AddTicks(1948), null, false, new DateTime(2023, 2, 13, 14, 1, 36, 545, DateTimeKind.Local).AddTicks(1301), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 11, 14, 14, 13, 591, DateTimeKind.Local).AddTicks(9689), null, false, new DateTime(2023, 4, 10, 11, 13, 29, 484, DateTimeKind.Local).AddTicks(4988), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 20, 16, 53, 25, 485, DateTimeKind.Local).AddTicks(1288), null, false, new DateTime(2023, 3, 29, 21, 5, 46, 19, DateTimeKind.Local).AddTicks(1468), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 3, 17, 28, 8, 181, DateTimeKind.Local).AddTicks(6628), null, false, new DateTime(2022, 9, 11, 5, 25, 46, 803, DateTimeKind.Local).AddTicks(7335), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 5, 12, 46, 22, 295, DateTimeKind.Local).AddTicks(6068), null, false, new DateTime(2022, 12, 25, 16, 57, 40, 62, DateTimeKind.Local).AddTicks(9968), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 28, 17, 13, 35, 1, DateTimeKind.Local).AddTicks(523), null, true, new DateTime(2022, 5, 27, 11, 27, 35, 0, DateTimeKind.Local).AddTicks(3895), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 6, 1, 15, 0, 37, 402, DateTimeKind.Local).AddTicks(8030), null, false, new DateTime(2022, 12, 21, 4, 51, 46, 398, DateTimeKind.Local).AddTicks(7195), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 28, 5, 55, 9, 545, DateTimeKind.Local).AddTicks(250), null, false, new DateTime(2022, 11, 8, 12, 31, 41, 954, DateTimeKind.Local).AddTicks(9914), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 17, 23, 3, 25, 942, DateTimeKind.Local).AddTicks(9870), null, false, new DateTime(2022, 11, 7, 6, 21, 14, 564, DateTimeKind.Local).AddTicks(4683), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 14, 2, 3, 27, 139, DateTimeKind.Local).AddTicks(1280), null, false, new DateTime(2022, 5, 29, 7, 26, 21, 229, DateTimeKind.Local).AddTicks(2233), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 12, 2, 19, 36, 49, 711, DateTimeKind.Local).AddTicks(5359), null, false, new DateTime(2023, 2, 12, 21, 49, 2, 576, DateTimeKind.Local).AddTicks(6186), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 7, 17, 23, 19, 800, DateTimeKind.Local).AddTicks(5669), null, false, new DateTime(2022, 8, 14, 2, 53, 46, 266, DateTimeKind.Local).AddTicks(8784), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 21, 22, 42, 43, 362, DateTimeKind.Local).AddTicks(9003), null, false, new DateTime(2023, 2, 14, 18, 59, 46, 223, DateTimeKind.Local).AddTicks(1816), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 15, 19, 27, 31, 647, DateTimeKind.Local).AddTicks(3857), null, false, new DateTime(2022, 10, 28, 4, 50, 37, 443, DateTimeKind.Local).AddTicks(7073), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 22, 8, 13, 10, 10, DateTimeKind.Local).AddTicks(6312), null, false, new DateTime(2022, 10, 19, 1, 11, 46, 936, DateTimeKind.Local).AddTicks(4912), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 21, 13, 23, 56, 146, DateTimeKind.Local).AddTicks(384), null, false, new DateTime(2023, 3, 1, 16, 27, 58, 19, DateTimeKind.Local).AddTicks(3246), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 24, 21, 9, 4, 152, DateTimeKind.Local).AddTicks(5213), null, false, new DateTime(2022, 7, 14, 9, 52, 36, 414, DateTimeKind.Local).AddTicks(7370), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 5, 3, 5, 23, 44, 846, DateTimeKind.Local).AddTicks(7904), null, false, new DateTime(2022, 9, 8, 11, 21, 19, 833, DateTimeKind.Local).AddTicks(3849), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 19, 8, 45, 13, 187, DateTimeKind.Local).AddTicks(3883), null, false, new DateTime(2022, 12, 10, 8, 32, 55, 912, DateTimeKind.Local).AddTicks(4898), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 23, 13, 12, 17, 28, DateTimeKind.Local).AddTicks(2670), null, false, new DateTime(2022, 5, 12, 16, 1, 57, 587, DateTimeKind.Local).AddTicks(6971), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 2, 1, 13, 4, 52, 482, DateTimeKind.Local).AddTicks(9856), null, false, new DateTime(2022, 8, 9, 18, 47, 1, 261, DateTimeKind.Local).AddTicks(4875), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 25, 4, 12, 29, 169, DateTimeKind.Local).AddTicks(2930), null, false, new DateTime(2023, 1, 8, 13, 35, 6, 608, DateTimeKind.Local).AddTicks(8584), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 12, 20, 51, 30, 196, DateTimeKind.Local).AddTicks(6865), null, false, new DateTime(2022, 7, 6, 17, 58, 50, 788, DateTimeKind.Local).AddTicks(4584), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 8, 21, 57, 26, 87, DateTimeKind.Local).AddTicks(4613), null, false, new DateTime(2023, 1, 15, 3, 15, 54, 423, DateTimeKind.Local).AddTicks(1745), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 21, 16, 48, 1, 132, DateTimeKind.Local).AddTicks(3119), null, false, new DateTime(2022, 10, 4, 11, 54, 57, 537, DateTimeKind.Local).AddTicks(9581), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 27, 10, 38, 34, 412, DateTimeKind.Local).AddTicks(648), null, false, new DateTime(2022, 8, 7, 12, 34, 35, 301, DateTimeKind.Local).AddTicks(2082), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 17, 11, 46, 9, 310, DateTimeKind.Local).AddTicks(4954), null, false, new DateTime(2022, 6, 26, 16, 38, 18, 840, DateTimeKind.Local).AddTicks(4480), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 22, 4, 45, 58, 320, DateTimeKind.Local).AddTicks(2975), null, false, new DateTime(2022, 6, 20, 22, 16, 35, 198, DateTimeKind.Local).AddTicks(1664), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 6, 20, 34, 6, 835, DateTimeKind.Local).AddTicks(571), null, false, new DateTime(2022, 9, 19, 14, 16, 22, 403, DateTimeKind.Local).AddTicks(6449), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 9, 19, 11, 54, 950, DateTimeKind.Local).AddTicks(3234), null, false, new DateTime(2022, 12, 14, 10, 14, 26, 829, DateTimeKind.Local).AddTicks(1068), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 22, 11, 28, 46, 809, DateTimeKind.Local).AddTicks(1460), null, false, new DateTime(2022, 11, 26, 13, 56, 16, 593, DateTimeKind.Local).AddTicks(136), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 25, 19, 7, 27, 461, DateTimeKind.Local).AddTicks(3210), null, false, new DateTime(2023, 4, 1, 3, 58, 25, 944, DateTimeKind.Local).AddTicks(8207), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 6, 10, 49, 44, 702, DateTimeKind.Local).AddTicks(7097), null, false, new DateTime(2022, 6, 30, 3, 17, 23, 670, DateTimeKind.Local).AddTicks(1090), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 23, 10, 23, 3, 357, DateTimeKind.Local).AddTicks(7077), null, false, new DateTime(2023, 2, 22, 20, 6, 43, 393, DateTimeKind.Local).AddTicks(6038), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 14, 19, 53, 50, 54, DateTimeKind.Local).AddTicks(3701), null, false, new DateTime(2022, 10, 27, 18, 10, 49, 417, DateTimeKind.Local).AddTicks(6845), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 11, 1, 49, 26, 704, DateTimeKind.Local).AddTicks(2538), null, false, new DateTime(2022, 6, 12, 20, 4, 59, 224, DateTimeKind.Local).AddTicks(5939), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 6, 11, 27, 20, 300, DateTimeKind.Local).AddTicks(3511), null, false, new DateTime(2022, 11, 3, 0, 21, 46, 234, DateTimeKind.Local).AddTicks(1371), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 24, 5, 10, 21, 394, DateTimeKind.Local).AddTicks(3045), null, false, new DateTime(2023, 1, 14, 16, 19, 57, 841, DateTimeKind.Local).AddTicks(7032), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 19, 15, 18, 9, 813, DateTimeKind.Local).AddTicks(8376), null, false, new DateTime(2022, 8, 16, 23, 25, 35, 397, DateTimeKind.Local).AddTicks(1252), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 23, 5, 30, 7, 459, DateTimeKind.Local).AddTicks(5144), null, false, new DateTime(2022, 12, 3, 21, 14, 1, 106, DateTimeKind.Local).AddTicks(2901), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 15, 0, 52, 18, 772, DateTimeKind.Local).AddTicks(1318), null, false, new DateTime(2023, 1, 2, 6, 24, 52, 5, DateTimeKind.Local).AddTicks(3746), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 30, 20, 45, 15, 190, DateTimeKind.Local).AddTicks(6141), null, false, new DateTime(2023, 4, 7, 19, 32, 11, 561, DateTimeKind.Local).AddTicks(6838), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 27, 23, 9, 25, 120, DateTimeKind.Local).AddTicks(9731), null, false, new DateTime(2023, 2, 9, 14, 56, 18, 331, DateTimeKind.Local).AddTicks(5708), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 15, 19, 3, 32, 779, DateTimeKind.Local).AddTicks(3426), null, false, new DateTime(2022, 6, 21, 22, 26, 32, 869, DateTimeKind.Local).AddTicks(2679), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 28, 23, 11, 27, 898, DateTimeKind.Local).AddTicks(6303), null, false, new DateTime(2022, 11, 1, 6, 27, 19, 284, DateTimeKind.Local).AddTicks(3764), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 31, 17, 5, 55, 273, DateTimeKind.Local).AddTicks(3113), null, false, new DateTime(2023, 2, 14, 2, 36, 37, 829, DateTimeKind.Local).AddTicks(3766), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 14, 0, 21, 25, 432, DateTimeKind.Local).AddTicks(9896), null, false, new DateTime(2022, 8, 20, 22, 4, 27, 723, DateTimeKind.Local).AddTicks(5865), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 9, 10, 16, 55, 356, DateTimeKind.Local).AddTicks(1283), null, false, new DateTime(2022, 5, 15, 17, 55, 17, 410, DateTimeKind.Local).AddTicks(3484), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 6, 2, 13, 11, 59, 910, DateTimeKind.Local).AddTicks(8682), null, false, new DateTime(2023, 3, 11, 2, 13, 13, 889, DateTimeKind.Local).AddTicks(9165), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 6, 0, 31, 14, 761, DateTimeKind.Local).AddTicks(482), null, false, new DateTime(2023, 1, 23, 17, 34, 58, 873, DateTimeKind.Local).AddTicks(5745), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 26, 1, 32, 33, 134, DateTimeKind.Local).AddTicks(6653), null, false, new DateTime(2022, 12, 5, 5, 4, 9, 618, DateTimeKind.Local).AddTicks(3299), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 4, 2, 2, 9, 59, 554, DateTimeKind.Local).AddTicks(6727), null, false, new DateTime(2022, 8, 6, 4, 37, 40, 217, DateTimeKind.Local).AddTicks(8619), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 17, 18, 15, 25, 767, DateTimeKind.Local).AddTicks(8481), null, false, new DateTime(2023, 1, 22, 3, 42, 9, 298, DateTimeKind.Local).AddTicks(5752), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 31, 21, 38, 30, 322, DateTimeKind.Local).AddTicks(6946), null, false, new DateTime(2022, 6, 4, 10, 10, 54, 32, DateTimeKind.Local).AddTicks(4309), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 5, 15, 36, 9, 576, DateTimeKind.Local).AddTicks(3194), null, false, new DateTime(2023, 1, 2, 23, 5, 4, 861, DateTimeKind.Local).AddTicks(124), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 14, 7, 29, 22, 240, DateTimeKind.Local).AddTicks(3448), null, false, new DateTime(2023, 1, 13, 21, 31, 32, 507, DateTimeKind.Local).AddTicks(9516), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 18, 17, 47, 8, 417, DateTimeKind.Local).AddTicks(3502), null, false, new DateTime(2023, 1, 12, 18, 6, 2, 959, DateTimeKind.Local).AddTicks(1353), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 28, 6, 46, 16, 572, DateTimeKind.Local).AddTicks(4220), null, false, new DateTime(2022, 11, 29, 11, 56, 31, 183, DateTimeKind.Local).AddTicks(5143), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 27, 5, 23, 30, 912, DateTimeKind.Local).AddTicks(6551), null, false, new DateTime(2022, 8, 23, 10, 17, 7, 147, DateTimeKind.Local).AddTicks(1063), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 8, 10, 17, 3, 699, DateTimeKind.Local).AddTicks(5731), null, false, new DateTime(2023, 2, 3, 21, 57, 47, 122, DateTimeKind.Local).AddTicks(1610), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 12, 1, 16, 26, 26, 86, DateTimeKind.Local).AddTicks(4792), null, false, new DateTime(2022, 6, 9, 9, 27, 19, 744, DateTimeKind.Local).AddTicks(8907), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 15, 3, 5, 15, 718, DateTimeKind.Local).AddTicks(9180), null, false, new DateTime(2022, 7, 30, 22, 25, 11, 223, DateTimeKind.Local).AddTicks(1350), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 27, 5, 9, 23, 534, DateTimeKind.Local).AddTicks(1716), null, false, new DateTime(2022, 12, 2, 3, 30, 37, 937, DateTimeKind.Local).AddTicks(5431), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 12, 16, 48, 24, 851, DateTimeKind.Local).AddTicks(7449), null, false, new DateTime(2023, 4, 13, 10, 53, 1, 201, DateTimeKind.Local).AddTicks(1920), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 19, 19, 14, 35, 300, DateTimeKind.Local).AddTicks(1386), null, false, new DateTime(2023, 3, 28, 12, 13, 21, 105, DateTimeKind.Local).AddTicks(5320), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 5, 20, 40, 48, 611, DateTimeKind.Local).AddTicks(4533), null, false, new DateTime(2023, 2, 6, 4, 43, 40, 255, DateTimeKind.Local).AddTicks(8926), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 4, 0, 16, 55, 828, DateTimeKind.Local).AddTicks(7170), null, false, new DateTime(2022, 11, 7, 0, 11, 31, 99, DateTimeKind.Local).AddTicks(7202), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 30, 20, 55, 27, 568, DateTimeKind.Local).AddTicks(2722), null, false, new DateTime(2022, 6, 27, 16, 41, 26, 929, DateTimeKind.Local).AddTicks(7085), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 14, 7, 47, 8, 965, DateTimeKind.Local).AddTicks(6662), null, false, new DateTime(2022, 7, 3, 17, 11, 21, 844, DateTimeKind.Local).AddTicks(623), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 17, 23, 36, 31, 378, DateTimeKind.Local).AddTicks(1950), null, false, new DateTime(2022, 7, 20, 5, 15, 58, 953, DateTimeKind.Local).AddTicks(5881), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 21, 13, 24, 19, 178, DateTimeKind.Local).AddTicks(1037), null, false, new DateTime(2022, 11, 17, 0, 31, 50, 661, DateTimeKind.Local).AddTicks(4246), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 10, 23, 29, 36, 962, DateTimeKind.Local).AddTicks(1052), null, false, new DateTime(2022, 7, 6, 0, 0, 29, 716, DateTimeKind.Local).AddTicks(8126), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 16, 12, 12, 43, 800, DateTimeKind.Local).AddTicks(2020), null, false, new DateTime(2023, 1, 23, 0, 36, 9, 569, DateTimeKind.Local).AddTicks(1421), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 26, 17, 40, 28, 32, DateTimeKind.Local).AddTicks(3206), null, false, new DateTime(2023, 1, 3, 15, 38, 24, 536, DateTimeKind.Local).AddTicks(8566), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 15, 18, 45, 45, 951, DateTimeKind.Local).AddTicks(4501), null, false, new DateTime(2022, 8, 16, 17, 53, 25, 22, DateTimeKind.Local).AddTicks(1972), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 28, 1, 27, 31, 928, DateTimeKind.Local).AddTicks(9817), null, false, new DateTime(2022, 7, 20, 1, 12, 1, 938, DateTimeKind.Local).AddTicks(2505), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 4, 9, 29, 37, 367, DateTimeKind.Local).AddTicks(6052), null, false, new DateTime(2022, 9, 7, 14, 44, 2, 878, DateTimeKind.Local).AddTicks(2823), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 18, 18, 24, 39, 441, DateTimeKind.Local).AddTicks(4195), null, false, new DateTime(2022, 6, 12, 3, 36, 58, 494, DateTimeKind.Local).AddTicks(6385), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 15, 14, 13, 48, 741, DateTimeKind.Local).AddTicks(370), null, false, new DateTime(2022, 7, 9, 18, 55, 59, 119, DateTimeKind.Local).AddTicks(1799), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 13, 3, 39, 35, 430, DateTimeKind.Local).AddTicks(9917), null, false, new DateTime(2023, 2, 9, 12, 52, 6, 498, DateTimeKind.Local).AddTicks(1064), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 12, 9, 32, 49, 301, DateTimeKind.Local).AddTicks(3642), null, true, new DateTime(2023, 3, 26, 8, 10, 44, 633, DateTimeKind.Local).AddTicks(3244), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 30, 0, 44, 5, 951, DateTimeKind.Local).AddTicks(7977), null, false, new DateTime(2023, 3, 6, 15, 4, 58, 756, DateTimeKind.Local).AddTicks(4263), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 4, 5, 53, 27, 545, DateTimeKind.Local).AddTicks(5192), null, false, new DateTime(2022, 11, 9, 6, 35, 41, 739, DateTimeKind.Local).AddTicks(574), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 22, 10, 5, 34, 193, DateTimeKind.Local).AddTicks(6827), null, false, new DateTime(2022, 10, 11, 6, 36, 46, 682, DateTimeKind.Local).AddTicks(3071), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 10, 4, 40, 7, 469, DateTimeKind.Local).AddTicks(2162), null, false, new DateTime(2023, 2, 12, 11, 57, 10, 744, DateTimeKind.Local).AddTicks(916), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 5, 1, 47, 46, 865, DateTimeKind.Local).AddTicks(8390), null, false, new DateTime(2022, 6, 27, 4, 47, 58, 279, DateTimeKind.Local).AddTicks(595), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 21, 23, 37, 26, 504, DateTimeKind.Local).AddTicks(2747), null, false, new DateTime(2023, 3, 16, 2, 5, 59, 766, DateTimeKind.Local).AddTicks(3336), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 24, 16, 29, 39, 306, DateTimeKind.Local).AddTicks(8549), null, false, new DateTime(2022, 11, 10, 0, 40, 42, 348, DateTimeKind.Local).AddTicks(3877), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 11, 12, 41, 58, 473, DateTimeKind.Local).AddTicks(1650), null, false, new DateTime(2022, 5, 14, 19, 2, 43, 283, DateTimeKind.Local).AddTicks(8854), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 23, 8, 11, 42, 940, DateTimeKind.Local).AddTicks(8784), null, false, new DateTime(2022, 12, 14, 15, 3, 2, 611, DateTimeKind.Local).AddTicks(6131), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 13, 21, 59, 39, 331, DateTimeKind.Local).AddTicks(7684), null, true, new DateTime(2022, 9, 3, 11, 47, 3, 343, DateTimeKind.Local).AddTicks(271), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 4, 7, 22, 44, 106, DateTimeKind.Local).AddTicks(4610), null, true, new DateTime(2022, 6, 18, 1, 6, 31, 845, DateTimeKind.Local).AddTicks(5407), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 15, 6, 43, 5, 763, DateTimeKind.Local).AddTicks(6216), null, false, new DateTime(2022, 5, 13, 19, 33, 10, 342, DateTimeKind.Local).AddTicks(2772), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY", "Total" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 30, 4, 47, 17, 708, DateTimeKind.Local).AddTicks(9029), new DateTime(2022, 7, 11, 0, 32, 58, 917, DateTimeKind.Local).AddTicks(2808), 25, -1250915742, null },
                    { 2, 65, new DateTime(2022, 12, 10, 10, 1, 40, 940, DateTimeKind.Local).AddTicks(4714), new DateTime(2022, 5, 9, 3, 34, 5, 769, DateTimeKind.Local).AddTicks(4751), 66, 1076792265, null },
                    { 3, 97, new DateTime(2023, 4, 8, 4, 56, 35, 983, DateTimeKind.Local).AddTicks(7069), new DateTime(2023, 1, 18, 3, 3, 59, 376, DateTimeKind.Local).AddTicks(152), 11, 448736987, null },
                    { 4, 149, new DateTime(2022, 8, 12, 16, 24, 11, 832, DateTimeKind.Local).AddTicks(8969), new DateTime(2022, 8, 22, 14, 59, 2, 104, DateTimeKind.Local).AddTicks(2232), 33, -650508614, null },
                    { 5, 93, new DateTime(2022, 8, 4, 14, 33, 30, 83, DateTimeKind.Local).AddTicks(8068), new DateTime(2022, 8, 5, 12, 3, 46, 553, DateTimeKind.Local).AddTicks(894), 29, 1004713085, null },
                    { 6, 15, new DateTime(2023, 2, 18, 22, 15, 17, 500, DateTimeKind.Local).AddTicks(7846), new DateTime(2022, 11, 30, 5, 44, 6, 602, DateTimeKind.Local).AddTicks(8518), 95, -925485396, null },
                    { 7, 26, new DateTime(2022, 7, 2, 22, 15, 26, 183, DateTimeKind.Local).AddTicks(9819), new DateTime(2022, 12, 27, 12, 28, 56, 663, DateTimeKind.Local).AddTicks(6708), 80, 394713240, null },
                    { 8, 133, new DateTime(2022, 9, 27, 14, 35, 36, 677, DateTimeKind.Local).AddTicks(8540), new DateTime(2022, 7, 31, 1, 12, 42, 854, DateTimeKind.Local).AddTicks(759), 83, -1117427269, null },
                    { 9, 3, new DateTime(2022, 4, 21, 14, 58, 1, 931, DateTimeKind.Local).AddTicks(3921), new DateTime(2022, 6, 28, 8, 35, 59, 98, DateTimeKind.Local).AddTicks(3236), 70, -362968140, null },
                    { 10, 10, new DateTime(2022, 10, 12, 21, 42, 45, 95, DateTimeKind.Local).AddTicks(4873), new DateTime(2022, 10, 8, 22, 32, 22, 518, DateTimeKind.Local).AddTicks(4060), 86, 1676838767, null },
                    { 11, 150, new DateTime(2022, 8, 9, 9, 43, 37, 275, DateTimeKind.Local).AddTicks(3103), new DateTime(2022, 11, 28, 13, 3, 0, 599, DateTimeKind.Local).AddTicks(6115), 28, -1740720405, null },
                    { 12, 102, new DateTime(2022, 8, 14, 9, 56, 18, 48, DateTimeKind.Local).AddTicks(3011), new DateTime(2022, 10, 28, 1, 25, 10, 518, DateTimeKind.Local).AddTicks(3912), 44, -350832494, null },
                    { 13, 54, new DateTime(2022, 10, 8, 13, 49, 43, 57, DateTimeKind.Local).AddTicks(4387), new DateTime(2023, 2, 15, 19, 37, 7, 589, DateTimeKind.Local).AddTicks(3275), 25, 185406887, null },
                    { 14, 104, new DateTime(2022, 11, 25, 10, 20, 53, 714, DateTimeKind.Local).AddTicks(7724), new DateTime(2023, 2, 20, 23, 32, 53, 164, DateTimeKind.Local).AddTicks(9930), 35, 985224501, null },
                    { 15, 13, new DateTime(2022, 4, 28, 6, 34, 17, 497, DateTimeKind.Local).AddTicks(7074), new DateTime(2022, 10, 22, 12, 28, 6, 815, DateTimeKind.Local).AddTicks(3186), 95, -2097158511, null },
                    { 16, 8, new DateTime(2023, 3, 5, 13, 17, 50, 346, DateTimeKind.Local).AddTicks(1912), new DateTime(2023, 1, 30, 6, 10, 51, 62, DateTimeKind.Local).AddTicks(4081), 64, -1536679927, null },
                    { 17, 47, new DateTime(2022, 9, 30, 8, 53, 52, 739, DateTimeKind.Local).AddTicks(3514), new DateTime(2022, 12, 27, 18, 53, 57, 198, DateTimeKind.Local).AddTicks(2325), 9, -1687707062, null },
                    { 18, 132, new DateTime(2022, 7, 2, 1, 34, 40, 244, DateTimeKind.Local).AddTicks(9820), new DateTime(2023, 1, 28, 6, 37, 22, 554, DateTimeKind.Local).AddTicks(8459), 100, -1370818213, null },
                    { 19, 27, new DateTime(2022, 11, 13, 2, 0, 40, 746, DateTimeKind.Local).AddTicks(1556), new DateTime(2022, 5, 4, 17, 23, 55, 100, DateTimeKind.Local).AddTicks(3568), 11, -889606430, null },
                    { 20, 117, new DateTime(2022, 5, 7, 18, 30, 1, 345, DateTimeKind.Local).AddTicks(7548), new DateTime(2023, 3, 4, 22, 19, 56, 726, DateTimeKind.Local).AddTicks(4969), 41, -1675455985, null },
                    { 21, 49, new DateTime(2023, 3, 26, 18, 27, 59, 948, DateTimeKind.Local).AddTicks(8688), new DateTime(2022, 10, 29, 6, 35, 36, 844, DateTimeKind.Local).AddTicks(7817), 50, -1348107742, null },
                    { 22, 59, new DateTime(2022, 12, 4, 13, 19, 16, 100, DateTimeKind.Local).AddTicks(3921), new DateTime(2023, 4, 15, 21, 13, 5, 546, DateTimeKind.Local).AddTicks(9271), 37, -1745167045, null },
                    { 23, 126, new DateTime(2022, 6, 10, 1, 10, 12, 154, DateTimeKind.Local).AddTicks(1382), new DateTime(2022, 7, 10, 6, 9, 17, 262, DateTimeKind.Local).AddTicks(6053), 62, -914583777, null },
                    { 24, 4, new DateTime(2022, 5, 30, 4, 10, 14, 307, DateTimeKind.Local).AddTicks(6633), new DateTime(2023, 1, 26, 4, 18, 28, 39, DateTimeKind.Local).AddTicks(5665), 9, 598991610, null },
                    { 25, 72, new DateTime(2022, 12, 29, 23, 45, 9, 161, DateTimeKind.Local).AddTicks(571), new DateTime(2023, 3, 4, 23, 18, 18, 636, DateTimeKind.Local).AddTicks(9014), 88, -1110187610, null },
                    { 26, 56, new DateTime(2022, 10, 27, 6, 56, 42, 709, DateTimeKind.Local).AddTicks(9409), new DateTime(2022, 12, 5, 2, 0, 50, 489, DateTimeKind.Local).AddTicks(6659), 13, -1410684997, null },
                    { 27, 46, new DateTime(2023, 3, 24, 15, 57, 50, 506, DateTimeKind.Local).AddTicks(6527), new DateTime(2023, 2, 16, 11, 40, 25, 697, DateTimeKind.Local).AddTicks(7216), 56, -875090068, null },
                    { 28, 66, new DateTime(2022, 7, 17, 19, 33, 23, 56, DateTimeKind.Local).AddTicks(5093), new DateTime(2023, 2, 13, 14, 1, 36, 552, DateTimeKind.Local).AddTicks(4444), 27, 49384959, null },
                    { 29, 128, new DateTime(2022, 4, 20, 3, 8, 14, 494, DateTimeKind.Local).AddTicks(6127), new DateTime(2022, 12, 23, 13, 19, 59, 54, DateTimeKind.Local).AddTicks(5851), 14, -1463487942, null },
                    { 30, 98, new DateTime(2022, 6, 10, 17, 40, 51, 42, DateTimeKind.Local).AddTicks(8006), new DateTime(2022, 8, 6, 10, 7, 28, 859, DateTimeKind.Local).AddTicks(4551), 99, 1580155063, null },
                    { 31, 82, new DateTime(2022, 8, 10, 12, 42, 28, 204, DateTimeKind.Local).AddTicks(7958), new DateTime(2023, 2, 18, 18, 51, 25, 551, DateTimeKind.Local).AddTicks(4795), 95, -756647284, null },
                    { 32, 4, new DateTime(2023, 3, 1, 16, 55, 18, 395, DateTimeKind.Local).AddTicks(6645), new DateTime(2023, 3, 22, 10, 12, 45, 311, DateTimeKind.Local).AddTicks(9359), 2, -1000610766, null },
                    { 33, 31, new DateTime(2023, 3, 19, 8, 33, 0, 629, DateTimeKind.Local).AddTicks(6900), new DateTime(2022, 5, 15, 16, 14, 50, 405, DateTimeKind.Local).AddTicks(125), 30, -277317102, null },
                    { 34, 124, new DateTime(2022, 4, 20, 3, 58, 51, 753, DateTimeKind.Local).AddTicks(9465), new DateTime(2023, 3, 5, 10, 5, 37, 980, DateTimeKind.Local).AddTicks(780), 48, 676055353, null },
                    { 35, 105, new DateTime(2022, 5, 20, 16, 53, 25, 492, DateTimeKind.Local).AddTicks(4388), new DateTime(2023, 3, 29, 21, 5, 46, 26, DateTimeKind.Local).AddTicks(4567), 85, 691042198, null },
                    { 36, 31, new DateTime(2022, 7, 20, 18, 40, 32, 184, DateTimeKind.Local).AddTicks(5206), new DateTime(2023, 2, 12, 5, 2, 36, 888, DateTimeKind.Local).AddTicks(4641), 32, -1575442742, null },
                    { 37, 103, new DateTime(2022, 8, 29, 9, 48, 0, 992, DateTimeKind.Local).AddTicks(8955), new DateTime(2023, 1, 21, 21, 15, 49, 897, DateTimeKind.Local).AddTicks(4148), 9, 93155705, null },
                    { 38, 86, new DateTime(2023, 1, 20, 9, 25, 37, 202, DateTimeKind.Local).AddTicks(2370), new DateTime(2023, 1, 27, 17, 56, 47, 478, DateTimeKind.Local).AddTicks(7028), 4, -628136364, null },
                    { 39, 91, new DateTime(2023, 2, 11, 17, 5, 35, 98, DateTimeKind.Local).AddTicks(2640), new DateTime(2022, 9, 16, 22, 28, 24, 289, DateTimeKind.Local).AddTicks(5727), 63, 695469990, null },
                    { 40, 48, new DateTime(2022, 12, 12, 3, 34, 43, 399, DateTimeKind.Local).AddTicks(8307), new DateTime(2022, 10, 5, 10, 4, 54, 879, DateTimeKind.Local).AddTicks(4149), 69, 1394462008, null },
                    { 41, 150, new DateTime(2022, 6, 3, 8, 1, 25, 930, DateTimeKind.Local).AddTicks(5827), new DateTime(2023, 3, 27, 20, 38, 27, 165, DateTimeKind.Local).AddTicks(2670), 18, 1093217936, null },
                    { 42, 125, new DateTime(2022, 8, 5, 12, 46, 22, 302, DateTimeKind.Local).AddTicks(9178), new DateTime(2022, 12, 25, 16, 57, 40, 70, DateTimeKind.Local).AddTicks(3077), 36, -1120965855, null },
                    { 43, 132, new DateTime(2022, 10, 28, 7, 38, 19, 589, DateTimeKind.Local).AddTicks(5226), new DateTime(2023, 1, 2, 18, 13, 47, 887, DateTimeKind.Local).AddTicks(5790), 86, 324977661, null },
                    { 44, 121, new DateTime(2022, 11, 30, 15, 18, 43, 768, DateTimeKind.Local).AddTicks(1669), new DateTime(2022, 7, 22, 20, 21, 59, 645, DateTimeKind.Local).AddTicks(4209), 74, -647262534, null },
                    { 45, 77, new DateTime(2023, 3, 21, 7, 11, 33, 332, DateTimeKind.Local).AddTicks(1738), new DateTime(2022, 12, 16, 3, 5, 37, 997, DateTimeKind.Local).AddTicks(5962), 80, -1833836428, null },
                    { 46, 135, new DateTime(2023, 4, 2, 12, 18, 15, 16, DateTimeKind.Local).AddTicks(9627), new DateTime(2022, 7, 28, 4, 36, 51, 23, DateTimeKind.Local).AddTicks(5167), 39, 645095851, null },
                    { 47, 130, new DateTime(2022, 12, 28, 14, 34, 48, 725, DateTimeKind.Local).AddTicks(4968), new DateTime(2022, 6, 4, 3, 25, 40, 457, DateTimeKind.Local).AddTicks(3868), 97, 1927754101, null },
                    { 48, 62, new DateTime(2022, 11, 9, 15, 57, 38, 825, DateTimeKind.Local).AddTicks(3984), new DateTime(2022, 10, 6, 9, 24, 28, 816, DateTimeKind.Local).AddTicks(649), 65, 1592782879, null },
                    { 49, 57, new DateTime(2022, 6, 1, 15, 0, 37, 410, DateTimeKind.Local).AddTicks(1198), new DateTime(2022, 12, 21, 4, 51, 46, 406, DateTimeKind.Local).AddTicks(364), 35, 1942898262, null },
                    { 50, 103, new DateTime(2022, 6, 22, 4, 50, 32, 394, DateTimeKind.Local).AddTicks(3285), new DateTime(2023, 1, 15, 0, 9, 26, 77, DateTimeKind.Local).AddTicks(2752), 33, -1218247667, null },
                    { 51, 49, new DateTime(2022, 11, 30, 1, 12, 14, 370, DateTimeKind.Local).AddTicks(7392), new DateTime(2023, 2, 20, 20, 40, 0, 289, DateTimeKind.Local).AddTicks(9061), 98, -819028078, null },
                    { 52, 143, new DateTime(2022, 10, 24, 12, 19, 52, 960, DateTimeKind.Local).AddTicks(3190), new DateTime(2022, 6, 22, 20, 53, 3, 172, DateTimeKind.Local).AddTicks(6460), 10, 1167768463, null },
                    { 53, 67, new DateTime(2022, 7, 4, 13, 40, 2, 772, DateTimeKind.Local).AddTicks(2545), new DateTime(2023, 2, 14, 2, 16, 14, 347, DateTimeKind.Local).AddTicks(8238), 23, -2125314161, null },
                    { 54, 2, new DateTime(2023, 2, 23, 8, 39, 26, 380, DateTimeKind.Local).AddTicks(5184), new DateTime(2023, 1, 6, 2, 13, 46, 627, DateTimeKind.Local).AddTicks(5642), 24, 716392428, null },
                    { 55, 23, new DateTime(2023, 3, 13, 16, 33, 45, 151, DateTimeKind.Local).AddTicks(4980), new DateTime(2022, 10, 20, 1, 23, 57, 852, DateTimeKind.Local).AddTicks(6267), 95, -181153395, null },
                    { 56, 125, new DateTime(2022, 8, 17, 23, 3, 25, 950, DateTimeKind.Local).AddTicks(3001), new DateTime(2022, 11, 7, 6, 21, 14, 571, DateTimeKind.Local).AddTicks(7812), 53, -1084893664, null },
                    { 57, 141, new DateTime(2022, 5, 8, 13, 33, 15, 318, DateTimeKind.Local).AddTicks(7868), new DateTime(2022, 12, 7, 14, 36, 30, 414, DateTimeKind.Local).AddTicks(8407), 44, -2089645501, null },
                    { 58, 9, new DateTime(2022, 11, 19, 10, 56, 28, 663, DateTimeKind.Local).AddTicks(9119), new DateTime(2023, 3, 9, 2, 34, 23, 7, DateTimeKind.Local).AddTicks(5468), 93, -1393368662, null },
                    { 59, 124, new DateTime(2022, 12, 8, 12, 55, 18, 189, DateTimeKind.Local).AddTicks(3977), new DateTime(2023, 3, 27, 0, 23, 14, 85, DateTimeKind.Local).AddTicks(7922), 69, -100293343, null },
                    { 60, 134, new DateTime(2022, 9, 1, 5, 36, 48, 850, DateTimeKind.Local).AddTicks(5371), new DateTime(2023, 4, 15, 4, 40, 59, 208, DateTimeKind.Local).AddTicks(5958), 52, -1666548154, null },
                    { 61, 73, new DateTime(2022, 8, 23, 13, 18, 37, 414, DateTimeKind.Local).AddTicks(5213), new DateTime(2023, 2, 3, 12, 58, 45, 176, DateTimeKind.Local).AddTicks(6508), 38, -265571196, null },
                    { 62, 40, new DateTime(2022, 12, 31, 12, 42, 38, 480, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 12, 17, 19, 59, 33, 676, DateTimeKind.Local).AddTicks(455), 63, -720260763, null },
                    { 63, 90, new DateTime(2022, 12, 2, 19, 36, 49, 718, DateTimeKind.Local).AddTicks(8493), new DateTime(2023, 2, 12, 21, 49, 2, 583, DateTimeKind.Local).AddTicks(9320), 23, -607896921, null },
                    { 64, 50, new DateTime(2022, 7, 24, 19, 37, 35, 641, DateTimeKind.Local).AddTicks(8364), new DateTime(2023, 2, 22, 20, 37, 44, 472, DateTimeKind.Local).AddTicks(1533), 59, -1823950750, null },
                    { 65, 141, new DateTime(2022, 7, 30, 3, 46, 56, 91, DateTimeKind.Local).AddTicks(3294), new DateTime(2023, 2, 20, 16, 34, 17, 909, DateTimeKind.Local).AddTicks(87), 66, -1618268223, null },
                    { 66, 19, new DateTime(2022, 5, 24, 23, 30, 29, 56, DateTimeKind.Local).AddTicks(9803), new DateTime(2023, 2, 17, 19, 28, 12, 190, DateTimeKind.Local).AddTicks(2181), 1, -1901350418, null },
                    { 67, 102, new DateTime(2022, 10, 22, 7, 38, 48, 916, DateTimeKind.Local).AddTicks(3775), new DateTime(2022, 11, 18, 5, 27, 49, 590, DateTimeKind.Local).AddTicks(3051), 3, 873574535, null },
                    { 68, 14, new DateTime(2022, 7, 11, 15, 58, 25, 990, DateTimeKind.Local).AddTicks(6091), new DateTime(2023, 3, 27, 9, 24, 48, 469, DateTimeKind.Local).AddTicks(6164), 66, -681325629, null },
                    { 69, 14, new DateTime(2023, 3, 7, 7, 19, 31, 152, DateTimeKind.Local).AddTicks(5124), new DateTime(2023, 4, 4, 2, 38, 11, 392, DateTimeKind.Local).AddTicks(801), 53, -1727151165, null },
                    { 70, 70, new DateTime(2022, 6, 21, 22, 42, 43, 370, DateTimeKind.Local).AddTicks(2144), new DateTime(2023, 2, 14, 18, 59, 46, 230, DateTimeKind.Local).AddTicks(4956), 18, -1889193047, null },
                    { 71, 92, new DateTime(2023, 3, 1, 0, 39, 19, 672, DateTimeKind.Local).AddTicks(8862), new DateTime(2022, 12, 22, 0, 23, 49, 842, DateTimeKind.Local).AddTicks(6046), 65, -931759922, null },
                    { 72, 36, new DateTime(2022, 10, 9, 5, 17, 56, 630, DateTimeKind.Local).AddTicks(3407), new DateTime(2022, 12, 9, 6, 58, 57, 399, DateTimeKind.Local).AddTicks(2402), 69, -966043571, null },
                    { 73, 32, new DateTime(2022, 11, 21, 14, 48, 12, 604, DateTimeKind.Local).AddTicks(526), new DateTime(2022, 9, 21, 7, 12, 27, 347, DateTimeKind.Local).AddTicks(4940), 9, 748401682, null },
                    { 74, 71, new DateTime(2023, 4, 17, 11, 14, 18, 703, DateTimeKind.Local).AddTicks(2715), new DateTime(2023, 1, 14, 12, 9, 10, 664, DateTimeKind.Local).AddTicks(1341), 17, -211676272, null },
                    { 75, 74, new DateTime(2023, 2, 14, 11, 23, 31, 878, DateTimeKind.Local).AddTicks(2649), new DateTime(2022, 5, 9, 12, 20, 57, 946, DateTimeKind.Local).AddTicks(3585), 59, 1403118051, null },
                    { 76, 133, new DateTime(2022, 8, 12, 16, 37, 39, 953, DateTimeKind.Local).AddTicks(7527), new DateTime(2023, 2, 25, 21, 29, 4, 956, DateTimeKind.Local).AddTicks(7290), 78, 1541692206, null },
                    { 77, 48, new DateTime(2022, 8, 22, 8, 13, 10, 17, DateTimeKind.Local).AddTicks(9458), new DateTime(2022, 10, 19, 1, 11, 46, 943, DateTimeKind.Local).AddTicks(8057), 83, -873508900, null },
                    { 78, 105, new DateTime(2022, 4, 28, 8, 47, 33, 531, DateTimeKind.Local).AddTicks(6800), new DateTime(2023, 2, 7, 15, 18, 27, 217, DateTimeKind.Local).AddTicks(5933), 22, 273649683, null },
                    { 79, 83, new DateTime(2022, 10, 13, 15, 14, 59, 106, DateTimeKind.Local).AddTicks(4317), new DateTime(2022, 11, 25, 15, 41, 5, 372, DateTimeKind.Local).AddTicks(874), 12, -1017472286, null },
                    { 80, 87, new DateTime(2022, 10, 24, 12, 49, 58, 37, DateTimeKind.Local).AddTicks(4703), new DateTime(2022, 7, 2, 4, 15, 53, 727, DateTimeKind.Local).AddTicks(9117), 99, 1743361810, null },
                    { 81, 20, new DateTime(2022, 12, 20, 2, 15, 11, 467, DateTimeKind.Local).AddTicks(7751), new DateTime(2022, 11, 8, 2, 52, 26, 514, DateTimeKind.Local).AddTicks(5551), 16, 528617151, null },
                    { 82, 30, new DateTime(2022, 5, 28, 5, 45, 23, 324, DateTimeKind.Local).AddTicks(4246), new DateTime(2023, 3, 31, 16, 21, 28, 133, DateTimeKind.Local).AddTicks(9708), 69, -1010666115, null },
                    { 83, 129, new DateTime(2022, 11, 2, 16, 38, 48, 386, DateTimeKind.Local).AddTicks(7488), new DateTime(2022, 8, 10, 9, 47, 52, 225, DateTimeKind.Local).AddTicks(6842), 9, 1233760843, null },
                    { 84, 133, new DateTime(2022, 11, 24, 21, 9, 4, 159, DateTimeKind.Local).AddTicks(8365), new DateTime(2022, 7, 14, 9, 52, 36, 422, DateTimeKind.Local).AddTicks(520), 30, -1434128168, null },
                    { 85, 149, new DateTime(2022, 10, 20, 11, 47, 18, 541, DateTimeKind.Local).AddTicks(1947), new DateTime(2022, 12, 5, 12, 14, 19, 413, DateTimeKind.Local).AddTicks(317), 93, 2046903218, null },
                    { 86, 5, new DateTime(2023, 2, 24, 19, 3, 47, 500, DateTimeKind.Local).AddTicks(5863), new DateTime(2022, 11, 26, 2, 1, 20, 382, DateTimeKind.Local).AddTicks(2921), 58, 679616818, null },
                    { 87, 33, new DateTime(2022, 11, 1, 19, 16, 4, 409, DateTimeKind.Local).AddTicks(2845), new DateTime(2022, 9, 3, 10, 40, 21, 793, DateTimeKind.Local).AddTicks(8821), 24, 478549211, null },
                    { 88, 92, new DateTime(2023, 1, 9, 23, 17, 1, 282, DateTimeKind.Local).AddTicks(747), new DateTime(2023, 4, 17, 2, 40, 50, 300, DateTimeKind.Local).AddTicks(4813), 97, 339967770, null },
                    { 89, 57, new DateTime(2022, 7, 4, 14, 45, 8, 302, DateTimeKind.Local).AddTicks(5229), new DateTime(2022, 8, 26, 12, 58, 57, 63, DateTimeKind.Local).AddTicks(488), 1, 2121068113, null },
                    { 90, 36, new DateTime(2022, 11, 1, 12, 12, 58, 756, DateTimeKind.Local).AddTicks(5854), new DateTime(2022, 8, 30, 19, 38, 39, 167, DateTimeKind.Local).AddTicks(8232), 56, 1861008772, null },
                    { 91, 91, new DateTime(2022, 11, 19, 8, 45, 13, 194, DateTimeKind.Local).AddTicks(7038), new DateTime(2022, 12, 10, 8, 32, 55, 919, DateTimeKind.Local).AddTicks(8052), 43, 1574432732, null },
                    { 92, 43, new DateTime(2022, 5, 25, 0, 49, 11, 812, DateTimeKind.Local).AddTicks(7364), new DateTime(2023, 1, 23, 17, 22, 44, 23, DateTimeKind.Local).AddTicks(8845), 24, -170721738, null },
                    { 93, 113, new DateTime(2022, 10, 30, 22, 56, 57, 173, DateTimeKind.Local).AddTicks(6250), new DateTime(2022, 4, 20, 1, 30, 1, 175, DateTimeKind.Local).AddTicks(4344), 16, 2035990240, null },
                    { 94, 18, new DateTime(2023, 1, 29, 7, 33, 31, 156, DateTimeKind.Local).AddTicks(4029), new DateTime(2023, 3, 3, 9, 17, 46, 466, DateTimeKind.Local).AddTicks(8343), 9, 85515633, null },
                    { 95, 141, new DateTime(2023, 2, 2, 3, 34, 19, 819, DateTimeKind.Local).AddTicks(5145), new DateTime(2022, 10, 30, 1, 34, 27, 323, DateTimeKind.Local).AddTicks(2192), 99, 2018085950, null },
                    { 96, 41, new DateTime(2023, 3, 17, 2, 45, 49, 789, DateTimeKind.Local).AddTicks(3923), new DateTime(2022, 10, 26, 12, 41, 26, 927, DateTimeKind.Local).AddTicks(4541), 74, -57669829, null },
                    { 97, 68, new DateTime(2022, 8, 12, 12, 59, 18, 529, DateTimeKind.Local).AddTicks(3680), new DateTime(2022, 5, 19, 23, 9, 43, 764, DateTimeKind.Local).AddTicks(414), 59, -1734171156, null },
                    { 98, 113, new DateTime(2023, 2, 1, 13, 4, 52, 490, DateTimeKind.Local).AddTicks(3018), new DateTime(2022, 8, 9, 18, 47, 1, 268, DateTimeKind.Local).AddTicks(8037), 10, 784066961, null },
                    { 99, 130, new DateTime(2022, 5, 8, 15, 59, 34, 978, DateTimeKind.Local).AddTicks(7331), new DateTime(2022, 4, 28, 20, 38, 47, 197, DateTimeKind.Local).AddTicks(697), 54, -1763911353, null },
                    { 100, 119, new DateTime(2023, 2, 20, 9, 52, 38, 9, DateTimeKind.Local).AddTicks(7930), new DateTime(2022, 5, 6, 16, 6, 31, 898, DateTimeKind.Local).AddTicks(5819), 62, 137029961, null },
                    { 101, 35, new DateTime(2022, 10, 28, 7, 14, 9, 583, DateTimeKind.Local).AddTicks(3919), new DateTime(2023, 2, 1, 0, 1, 22, 169, DateTimeKind.Local).AddTicks(7327), 32, -1427249567, null },
                    { 102, 42, new DateTime(2022, 5, 17, 23, 33, 23, 117, DateTimeKind.Local).AddTicks(8062), new DateTime(2022, 5, 28, 12, 1, 1, 581, DateTimeKind.Local).AddTicks(4128), 15, 684126169, null },
                    { 103, 100, new DateTime(2022, 8, 21, 15, 34, 46, 537, DateTimeKind.Local).AddTicks(24), new DateTime(2022, 9, 4, 12, 21, 59, 355, DateTimeKind.Local).AddTicks(8035), 16, -58548816, null },
                    { 104, 149, new DateTime(2022, 5, 26, 14, 20, 38, 424, DateTimeKind.Local).AddTicks(4959), new DateTime(2023, 2, 21, 16, 57, 49, 413, DateTimeKind.Local).AddTicks(2982), 4, -411023012, null },
                    { 105, 141, new DateTime(2022, 7, 12, 20, 51, 30, 204, DateTimeKind.Local).AddTicks(33), new DateTime(2022, 7, 6, 17, 58, 50, 795, DateTimeKind.Local).AddTicks(7751), 52, -1315096911, null },
                    { 106, 148, new DateTime(2023, 2, 26, 5, 58, 0, 393, DateTimeKind.Local).AddTicks(522), new DateTime(2022, 11, 24, 11, 4, 11, 623, DateTimeKind.Local).AddTicks(2476), 61, 1301921478, null },
                    { 107, 117, new DateTime(2022, 10, 30, 18, 44, 38, 706, DateTimeKind.Local).AddTicks(3618), new DateTime(2023, 1, 27, 2, 46, 54, 318, DateTimeKind.Local).AddTicks(8501), 55, -1691809014, null },
                    { 108, 37, new DateTime(2022, 10, 13, 22, 8, 43, 465, DateTimeKind.Local).AddTicks(5008), new DateTime(2023, 2, 6, 2, 41, 25, 454, DateTimeKind.Local).AddTicks(8131), 17, -423108718, null },
                    { 109, 39, new DateTime(2023, 2, 21, 11, 5, 47, 239, DateTimeKind.Local).AddTicks(9927), new DateTime(2022, 10, 14, 19, 12, 46, 867, DateTimeKind.Local).AddTicks(4764), 78, -692829338, null },
                    { 110, 132, new DateTime(2022, 12, 18, 0, 17, 4, 260, DateTimeKind.Local).AddTicks(3900), new DateTime(2022, 12, 25, 5, 42, 32, 118, DateTimeKind.Local).AddTicks(7119), 80, -2029807833, null },
                    { 111, 119, new DateTime(2022, 7, 17, 7, 47, 30, 260, DateTimeKind.Local).AddTicks(5848), new DateTime(2022, 11, 12, 21, 45, 28, 304, DateTimeKind.Local).AddTicks(6952), 54, 1672637995, null },
                    { 112, 89, new DateTime(2022, 8, 21, 16, 48, 1, 139, DateTimeKind.Local).AddTicks(6129), new DateTime(2022, 10, 4, 11, 54, 57, 545, DateTimeKind.Local).AddTicks(2590), 10, 1951346400, null },
                    { 113, 119, new DateTime(2022, 11, 3, 15, 44, 48, 592, DateTimeKind.Local).AddTicks(9735), new DateTime(2022, 8, 13, 6, 53, 23, 243, DateTimeKind.Local).AddTicks(6377), 97, -4332093, null },
                    { 114, 57, new DateTime(2022, 12, 12, 14, 18, 2, 612, DateTimeKind.Local).AddTicks(4390), new DateTime(2022, 12, 20, 4, 37, 18, 544, DateTimeKind.Local).AddTicks(866), 3, 218673338, null },
                    { 115, 12, new DateTime(2022, 8, 17, 15, 55, 45, 466, DateTimeKind.Local).AddTicks(1386), new DateTime(2022, 12, 5, 0, 2, 33, 271, DateTimeKind.Local).AddTicks(7994), 9, 1404934878, null },
                    { 116, 105, new DateTime(2022, 7, 29, 11, 36, 51, 426, DateTimeKind.Local).AddTicks(1897), new DateTime(2022, 5, 19, 20, 15, 36, 53, DateTimeKind.Local).AddTicks(6815), 81, -443520684, null },
                    { 117, 70, new DateTime(2022, 6, 15, 6, 12, 39, 770, DateTimeKind.Local).AddTicks(5988), new DateTime(2022, 7, 9, 6, 19, 18, 717, DateTimeKind.Local).AddTicks(8219), 16, 105760099, null },
                    { 118, 59, new DateTime(2022, 12, 9, 13, 18, 50, 956, DateTimeKind.Local).AddTicks(6361), new DateTime(2022, 8, 28, 17, 57, 37, 494, DateTimeKind.Local).AddTicks(14), 84, -543414121, null },
                    { 119, 68, new DateTime(2023, 1, 17, 11, 46, 9, 317, DateTimeKind.Local).AddTicks(8012), new DateTime(2022, 6, 26, 16, 38, 18, 847, DateTimeKind.Local).AddTicks(7537), 61, 1289783449, null },
                    { 120, 107, new DateTime(2022, 12, 29, 2, 40, 44, 553, DateTimeKind.Local).AddTicks(9483), new DateTime(2022, 5, 5, 23, 10, 50, 78, DateTimeKind.Local).AddTicks(6631), 24, -334057685, null },
                    { 121, 140, new DateTime(2023, 1, 14, 9, 10, 46, 860, DateTimeKind.Local).AddTicks(4591), new DateTime(2022, 12, 1, 17, 10, 31, 99, DateTimeKind.Local).AddTicks(3567), 12, -1157444066, null },
                    { 122, 125, new DateTime(2023, 2, 14, 21, 13, 57, 568, DateTimeKind.Local).AddTicks(5188), new DateTime(2022, 11, 22, 6, 3, 38, 880, DateTimeKind.Local).AddTicks(7612), 80, -1771722325, null },
                    { 123, 124, new DateTime(2022, 11, 15, 7, 29, 20, 365, DateTimeKind.Local).AddTicks(6108), new DateTime(2022, 7, 28, 23, 17, 7, 6, DateTimeKind.Local).AddTicks(936), 91, -2073681669, null },
                    { 124, 145, new DateTime(2022, 10, 16, 10, 52, 4, 208, DateTimeKind.Local).AddTicks(9142), new DateTime(2022, 6, 17, 1, 14, 19, 188, DateTimeKind.Local).AddTicks(5950), 22, 1770342382, null },
                    { 125, 126, new DateTime(2023, 1, 6, 22, 38, 43, 424, DateTimeKind.Local).AddTicks(9867), new DateTime(2022, 8, 30, 11, 18, 12, 496, DateTimeKind.Local).AddTicks(6885), 8, -1140422957, null },
                    { 126, 133, new DateTime(2022, 8, 6, 20, 34, 6, 842, DateTimeKind.Local).AddTicks(3635), new DateTime(2022, 9, 19, 14, 16, 22, 410, DateTimeKind.Local).AddTicks(9512), 75, 351327451, null },
                    { 127, 123, new DateTime(2023, 3, 20, 19, 18, 34, 727, DateTimeKind.Local).AddTicks(2549), new DateTime(2022, 9, 22, 6, 6, 36, 310, DateTimeKind.Local).AddTicks(5840), 44, -1403539207, null },
                    { 128, 81, new DateTime(2023, 3, 14, 18, 57, 14, 246, DateTimeKind.Local).AddTicks(4521), new DateTime(2022, 12, 2, 19, 19, 0, 923, DateTimeKind.Local).AddTicks(911), 13, -336305909, null },
                    { 129, 108, new DateTime(2023, 1, 16, 20, 52, 31, 997, DateTimeKind.Local).AddTicks(655), new DateTime(2022, 6, 1, 3, 48, 53, 258, DateTimeKind.Local).AddTicks(2786), 78, 201306565, null },
                    { 130, 52, new DateTime(2023, 3, 4, 9, 17, 34, 177, DateTimeKind.Local).AddTicks(7951), new DateTime(2022, 12, 22, 23, 39, 31, 167, DateTimeKind.Local).AddTicks(4306), 44, 1643478052, null },
                    { 131, 66, new DateTime(2022, 6, 5, 17, 21, 26, 899, DateTimeKind.Local).AddTicks(7958), new DateTime(2023, 4, 14, 0, 40, 28, 516, DateTimeKind.Local).AddTicks(5760), 29, 115485288, null },
                    { 132, 96, new DateTime(2022, 11, 13, 15, 20, 48, 830, DateTimeKind.Local).AddTicks(9463), new DateTime(2022, 8, 29, 3, 8, 24, 37, DateTimeKind.Local).AddTicks(3800), 97, -861784599, null },
                    { 133, 62, new DateTime(2022, 7, 22, 11, 28, 46, 816, DateTimeKind.Local).AddTicks(4529), new DateTime(2022, 11, 26, 13, 56, 16, 600, DateTimeKind.Local).AddTicks(3204), 95, 2080788891, null },
                    { 134, 101, new DateTime(2023, 2, 2, 12, 52, 30, 205, DateTimeKind.Local).AddTicks(2223), new DateTime(2023, 1, 22, 8, 29, 25, 362, DateTimeKind.Local).AddTicks(5289), 44, -2132710800, null },
                    { 135, 103, new DateTime(2022, 5, 9, 15, 39, 29, 981, DateTimeKind.Local).AddTicks(151), new DateTime(2022, 4, 28, 4, 58, 57, 286, DateTimeKind.Local).AddTicks(5013), 23, 641027395, null },
                    { 136, 91, new DateTime(2023, 1, 6, 10, 7, 54, 475, DateTimeKind.Local).AddTicks(7), new DateTime(2022, 12, 4, 7, 6, 14, 562, DateTimeKind.Local).AddTicks(9247), 76, 258696705, null },
                    { 137, 8, new DateTime(2022, 5, 6, 13, 59, 47, 90, DateTimeKind.Local).AddTicks(3524), new DateTime(2022, 10, 20, 1, 39, 59, 785, DateTimeKind.Local).AddTicks(1647), 74, -76631958, null },
                    { 138, 94, new DateTime(2022, 11, 23, 21, 50, 30, 740, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 7, 27, 2, 31, 18, 214, DateTimeKind.Local).AddTicks(544), 72, 917182534, null },
                    { 139, 144, new DateTime(2022, 12, 14, 3, 50, 42, 473, DateTimeKind.Local).AddTicks(4704), new DateTime(2022, 12, 27, 1, 57, 25, 493, DateTimeKind.Local).AddTicks(1953), 72, 659033829, null },
                    { 140, 103, new DateTime(2022, 9, 6, 10, 49, 44, 709, DateTimeKind.Local).AddTicks(9933), new DateTime(2022, 6, 30, 3, 17, 23, 677, DateTimeKind.Local).AddTicks(3925), 2, -1100840081, null },
                    { 141, 67, new DateTime(2022, 9, 3, 10, 1, 35, 924, DateTimeKind.Local).AddTicks(6564), new DateTime(2022, 8, 2, 1, 12, 0, 786, DateTimeKind.Local).AddTicks(1490), 39, -1762585980, null },
                    { 142, 106, new DateTime(2022, 5, 9, 17, 57, 5, 750, DateTimeKind.Local).AddTicks(1691), new DateTime(2023, 3, 12, 9, 42, 54, 368, DateTimeKind.Local).AddTicks(775), 80, -876498360, null },
                    { 143, 3, new DateTime(2022, 8, 24, 1, 45, 12, 429, DateTimeKind.Local).AddTicks(9863), new DateTime(2022, 7, 16, 0, 17, 30, 508, DateTimeKind.Local).AddTicks(1328), 52, -1545750270, null },
                    { 144, 23, new DateTime(2022, 9, 23, 11, 54, 39, 163, DateTimeKind.Local).AddTicks(2681), new DateTime(2022, 8, 10, 8, 8, 15, 274, DateTimeKind.Local).AddTicks(8818), 41, -783190562, null },
                    { 145, 75, new DateTime(2023, 1, 5, 21, 21, 7, 557, DateTimeKind.Local).AddTicks(5664), new DateTime(2022, 5, 19, 7, 4, 24, 768, DateTimeKind.Local).AddTicks(380), 16, 2050620680, null },
                    { 146, 140, new DateTime(2022, 5, 16, 7, 58, 18, 536, DateTimeKind.Local).AddTicks(2979), new DateTime(2022, 12, 21, 4, 49, 55, 944, DateTimeKind.Local).AddTicks(8931), 69, 658206178, null },
                    { 147, 2, new DateTime(2022, 8, 14, 19, 53, 50, 61, DateTimeKind.Local).AddTicks(6539), new DateTime(2022, 10, 27, 18, 10, 49, 424, DateTimeKind.Local).AddTicks(9682), 2, 1957153808, null },
                    { 148, 135, new DateTime(2023, 1, 26, 23, 34, 3, 330, DateTimeKind.Local).AddTicks(9695), new DateTime(2022, 10, 1, 21, 58, 9, 12, DateTimeKind.Local).AddTicks(1085), 33, 1421780379, null },
                    { 149, 22, new DateTime(2022, 9, 17, 6, 44, 28, 508, DateTimeKind.Local).AddTicks(9102), new DateTime(2022, 12, 26, 11, 22, 47, 823, DateTimeKind.Local).AddTicks(8927), 7, 197859398, null },
                    { 150, 86, new DateTime(2022, 9, 21, 5, 7, 11, 105, DateTimeKind.Local).AddTicks(1257), new DateTime(2023, 4, 8, 14, 6, 29, 822, DateTimeKind.Local).AddTicks(4843), 98, -206519660, null },
                    { 151, 128, new DateTime(2022, 4, 24, 5, 59, 28, 93, DateTimeKind.Local).AddTicks(3436), new DateTime(2022, 8, 6, 22, 35, 5, 376, DateTimeKind.Local).AddTicks(1530), 11, 537167036, null },
                    { 152, 97, new DateTime(2022, 12, 20, 7, 56, 21, 358, DateTimeKind.Local).AddTicks(6714), new DateTime(2022, 9, 24, 5, 31, 56, 156, DateTimeKind.Local).AddTicks(9859), 98, -2105892589, null },
                    { 153, 99, new DateTime(2023, 2, 22, 20, 8, 12, 568, DateTimeKind.Local).AddTicks(7967), new DateTime(2022, 10, 12, 14, 28, 16, 204, DateTimeKind.Local).AddTicks(3028), 40, -889988912, null },
                    { 154, 105, new DateTime(2023, 3, 6, 11, 27, 20, 307, DateTimeKind.Local).AddTicks(6396), new DateTime(2022, 11, 3, 0, 21, 46, 241, DateTimeKind.Local).AddTicks(4255), 41, 1270048831, null },
                    { 155, 45, new DateTime(2022, 8, 6, 20, 42, 34, 887, DateTimeKind.Local).AddTicks(9300), new DateTime(2022, 7, 6, 8, 49, 41, 365, DateTimeKind.Local).AddTicks(178), 52, -1537469333, null },
                    { 156, 71, new DateTime(2022, 7, 9, 6, 22, 58, 274, DateTimeKind.Local).AddTicks(7225), new DateTime(2022, 9, 7, 0, 33, 33, 489, DateTimeKind.Local).AddTicks(4128), 3, -200740647, null },
                    { 157, 16, new DateTime(2022, 8, 9, 0, 24, 44, 259, DateTimeKind.Local).AddTicks(514), new DateTime(2023, 1, 13, 22, 0, 57, 61, DateTimeKind.Local).AddTicks(3842), 80, 1600819146, null },
                    { 158, 39, new DateTime(2022, 8, 2, 11, 14, 23, 432, DateTimeKind.Local).AddTicks(352), new DateTime(2022, 9, 15, 12, 41, 25, 745, DateTimeKind.Local).AddTicks(1723), 57, -910151577, null },
                    { 159, 39, new DateTime(2022, 6, 26, 21, 3, 4, 566, DateTimeKind.Local).AddTicks(1181), new DateTime(2022, 6, 18, 3, 21, 17, 157, DateTimeKind.Local).AddTicks(1047), 93, 1102900698, null },
                    { 160, 34, new DateTime(2022, 12, 11, 7, 43, 50, 914, DateTimeKind.Local).AddTicks(6732), new DateTime(2022, 12, 3, 22, 44, 32, 175, DateTimeKind.Local).AddTicks(4284), 95, -617432580, null },
                    { 161, 17, new DateTime(2023, 3, 19, 15, 18, 9, 821, DateTimeKind.Local).AddTicks(1081), new DateTime(2022, 8, 16, 23, 25, 35, 404, DateTimeKind.Local).AddTicks(3955), 69, -1340389319, null },
                    { 162, 107, new DateTime(2023, 2, 26, 7, 37, 31, 734, DateTimeKind.Local).AddTicks(3142), new DateTime(2022, 12, 5, 11, 55, 32, 816, DateTimeKind.Local).AddTicks(7566), 75, -973110418, null },
                    { 163, 20, new DateTime(2022, 7, 3, 11, 22, 49, 160, DateTimeKind.Local).AddTicks(7410), new DateTime(2022, 8, 13, 7, 30, 18, 372, DateTimeKind.Local).AddTicks(7152), 3, 570262808, null },
                    { 164, 119, new DateTime(2023, 4, 18, 13, 11, 15, 728, DateTimeKind.Local).AddTicks(4307), new DateTime(2022, 8, 29, 2, 3, 10, 386, DateTimeKind.Local).AddTicks(3523), 88, 966172498, null },
                    { 165, 56, new DateTime(2022, 5, 22, 17, 57, 55, 563, DateTimeKind.Local).AddTicks(87), new DateTime(2022, 6, 6, 9, 7, 8, 121, DateTimeKind.Local).AddTicks(9766), 8, -2043522247, null },
                    { 166, 11, new DateTime(2022, 4, 18, 16, 9, 41, 265, DateTimeKind.Local).AddTicks(197), new DateTime(2023, 2, 28, 18, 8, 54, 774, DateTimeKind.Local).AddTicks(1203), 95, 389426985, null },
                    { 167, 85, new DateTime(2022, 9, 14, 17, 32, 8, 462, DateTimeKind.Local).AddTicks(9733), new DateTime(2023, 2, 22, 22, 54, 6, 52, DateTimeKind.Local).AddTicks(3491), 95, -623760055, null },
                    { 168, 43, new DateTime(2022, 10, 15, 0, 52, 18, 779, DateTimeKind.Local).AddTicks(4025), new DateTime(2023, 1, 2, 6, 24, 52, 12, DateTimeKind.Local).AddTicks(6452), 89, 1283012178, null },
                    { 169, 49, new DateTime(2023, 3, 13, 16, 0, 27, 611, DateTimeKind.Local).AddTicks(7003), new DateTime(2022, 5, 19, 2, 21, 26, 699, DateTimeKind.Local).AddTicks(213), 95, -1677742607, null },
                    { 170, 16, new DateTime(2022, 6, 6, 17, 58, 34, 836, DateTimeKind.Local).AddTicks(5907), new DateTime(2023, 3, 19, 11, 19, 29, 196, DateTimeKind.Local).AddTicks(1143), 39, 1704587075, null },
                    { 171, 49, new DateTime(2023, 1, 22, 5, 18, 4, 555, DateTimeKind.Local).AddTicks(8078), new DateTime(2022, 11, 9, 22, 47, 39, 134, DateTimeKind.Local).AddTicks(1152), 97, -866479085, null },
                    { 172, 5, new DateTime(2022, 7, 30, 8, 40, 0, 434, DateTimeKind.Local).AddTicks(6560), new DateTime(2023, 2, 28, 16, 26, 44, 510, DateTimeKind.Local).AddTicks(8567), 47, -934914063, null },
                    { 173, 26, new DateTime(2022, 7, 14, 13, 39, 16, 199, DateTimeKind.Local).AddTicks(9563), new DateTime(2022, 9, 20, 9, 51, 39, 367, DateTimeKind.Local).AddTicks(7291), 26, 205854220, null },
                    { 174, 73, new DateTime(2022, 11, 15, 9, 48, 9, 692, DateTimeKind.Local).AddTicks(4641), new DateTime(2022, 9, 4, 22, 41, 55, 965, DateTimeKind.Local).AddTicks(6726), 32, 1165902056, null },
                    { 175, 143, new DateTime(2022, 7, 27, 23, 9, 25, 128, DateTimeKind.Local).AddTicks(2439), new DateTime(2023, 2, 9, 14, 56, 18, 338, DateTimeKind.Local).AddTicks(8415), 12, 1492709997, null },
                    { 176, 149, new DateTime(2022, 10, 25, 13, 25, 10, 931, DateTimeKind.Local).AddTicks(3198), new DateTime(2022, 7, 23, 0, 24, 55, 864, DateTimeKind.Local).AddTicks(6865), 12, -198177313, null },
                    { 177, 76, new DateTime(2022, 7, 24, 18, 14, 22, 798, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 10, 1, 21, 51, 29, 107, DateTimeKind.Local).AddTicks(6611), 62, -1451374573, null },
                    { 178, 13, new DateTime(2023, 1, 17, 1, 46, 57, 372, DateTimeKind.Local).AddTicks(6577), new DateTime(2022, 4, 30, 22, 32, 44, 596, DateTimeKind.Local).AddTicks(4693), 70, 1817543350, null },
                    { 179, 124, new DateTime(2022, 5, 24, 21, 9, 29, 928, DateTimeKind.Local).AddTicks(8098), new DateTime(2022, 9, 2, 16, 15, 17, 550, DateTimeKind.Local).AddTicks(3188), 51, 2079942108, null },
                    { 180, 85, new DateTime(2022, 8, 17, 13, 11, 46, 85, DateTimeKind.Local).AddTicks(8812), new DateTime(2022, 5, 19, 12, 20, 11, 726, DateTimeKind.Local).AddTicks(4822), 84, 1343957375, null },
                    { 181, 69, new DateTime(2022, 5, 26, 13, 2, 37, 536, DateTimeKind.Local).AddTicks(914), new DateTime(2022, 7, 31, 19, 18, 34, 215, DateTimeKind.Local).AddTicks(3228), 85, 2065497356, null },
                    { 182, 140, new DateTime(2022, 4, 28, 23, 11, 27, 905, DateTimeKind.Local).AddTicks(9011), new DateTime(2022, 11, 1, 6, 27, 19, 291, DateTimeKind.Local).AddTicks(6471), 53, -1688302516, null },
                    { 183, 73, new DateTime(2022, 6, 28, 12, 21, 7, 549, DateTimeKind.Local).AddTicks(7595), new DateTime(2022, 11, 9, 18, 55, 4, 476, DateTimeKind.Local).AddTicks(3608), 91, 1083884518, null },
                    { 184, 102, new DateTime(2022, 5, 1, 3, 57, 44, 22, DateTimeKind.Local).AddTicks(8058), new DateTime(2022, 4, 27, 19, 2, 19, 20, DateTimeKind.Local).AddTicks(8570), 39, -1759783002, null },
                    { 185, 75, new DateTime(2022, 6, 24, 1, 29, 9, 136, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 5, 1, 15, 47, 18, 49, DateTimeKind.Local).AddTicks(7992), 85, 1782813466, null },
                    { 186, 27, new DateTime(2022, 11, 7, 20, 21, 35, 872, DateTimeKind.Local).AddTicks(8311), new DateTime(2023, 2, 15, 14, 49, 45, 996, DateTimeKind.Local).AddTicks(5053), 30, -888966717, null },
                    { 187, 120, new DateTime(2023, 3, 24, 6, 36, 13, 90, DateTimeKind.Local).AddTicks(7696), new DateTime(2022, 10, 19, 16, 23, 4, 249, DateTimeKind.Local).AddTicks(5075), 93, -1214087315, null },
                    { 188, 120, new DateTime(2022, 7, 5, 2, 16, 29, 714, DateTimeKind.Local).AddTicks(5807), new DateTime(2022, 9, 30, 12, 26, 23, 528, DateTimeKind.Local).AddTicks(204), 59, -618870805, null },
                    { 189, 122, new DateTime(2022, 12, 14, 0, 21, 25, 440, DateTimeKind.Local).AddTicks(2597), new DateTime(2022, 8, 20, 22, 4, 27, 730, DateTimeKind.Local).AddTicks(8564), 28, 588451897, null },
                    { 190, 115, new DateTime(2023, 1, 29, 14, 10, 2, 404, DateTimeKind.Local).AddTicks(4933), new DateTime(2022, 8, 10, 22, 5, 57, 95, DateTimeKind.Local).AddTicks(6920), 10, 1524537188, null },
                    { 191, 41, new DateTime(2022, 8, 27, 17, 53, 29, 578, DateTimeKind.Local).AddTicks(77), new DateTime(2023, 1, 31, 18, 34, 43, 501, DateTimeKind.Local).AddTicks(6655), 53, 797855992, null },
                    { 192, 122, new DateTime(2022, 9, 16, 22, 56, 40, 344, DateTimeKind.Local).AddTicks(7692), new DateTime(2022, 6, 20, 16, 1, 16, 288, DateTimeKind.Local).AddTicks(8791), 28, 706457332, null },
                    { 193, 139, new DateTime(2022, 7, 8, 1, 23, 10, 529, DateTimeKind.Local).AddTicks(7254), new DateTime(2022, 12, 18, 7, 20, 24, 69, DateTimeKind.Local).AddTicks(6448), 86, -560418152, null },
                    { 194, 106, new DateTime(2022, 9, 4, 11, 2, 22, 955, DateTimeKind.Local).AddTicks(5670), new DateTime(2022, 8, 17, 19, 34, 28, 81, DateTimeKind.Local).AddTicks(2625), 75, 1838942332, null },
                    { 195, 109, new DateTime(2022, 7, 3, 10, 17, 30, 898, DateTimeKind.Local).AddTicks(5937), new DateTime(2022, 7, 27, 10, 56, 28, 366, DateTimeKind.Local).AddTicks(3833), 2, 101291550, null },
                    { 196, 72, new DateTime(2022, 6, 2, 13, 11, 59, 918, DateTimeKind.Local).AddTicks(1381), new DateTime(2023, 3, 11, 2, 13, 13, 897, DateTimeKind.Local).AddTicks(1863), 87, -237508193, null },
                    { 197, 39, new DateTime(2023, 2, 19, 19, 9, 29, 5, DateTimeKind.Local).AddTicks(6305), new DateTime(2022, 9, 22, 4, 34, 57, 359, DateTimeKind.Local).AddTicks(6179), 70, -621745055, null },
                    { 198, 46, new DateTime(2022, 6, 1, 7, 33, 24, 365, DateTimeKind.Local).AddTicks(3588), new DateTime(2023, 3, 20, 12, 33, 36, 814, DateTimeKind.Local).AddTicks(2774), 34, 1972126153, null },
                    { 199, 20, new DateTime(2022, 11, 10, 18, 12, 42, 297, DateTimeKind.Local).AddTicks(9783), new DateTime(2023, 4, 10, 5, 18, 51, 774, DateTimeKind.Local).AddTicks(2202), 29, -148240115, null },
                    { 200, 35, new DateTime(2022, 5, 28, 0, 32, 58, 7, DateTimeKind.Local).AddTicks(2279), new DateTime(2023, 3, 9, 17, 57, 16, 930, DateTimeKind.Local).AddTicks(1159), 54, 1242594483, null },
                    { 201, 37, new DateTime(2022, 8, 28, 21, 54, 15, 395, DateTimeKind.Local).AddTicks(7900), new DateTime(2022, 8, 21, 6, 56, 14, 975, DateTimeKind.Local).AddTicks(2413), 22, 890020464, null },
                    { 202, 69, new DateTime(2022, 6, 29, 4, 45, 24, 23, DateTimeKind.Local).AddTicks(8979), new DateTime(2022, 9, 20, 18, 9, 13, 944, DateTimeKind.Local).AddTicks(3347), 2, -950187579, null },
                    { 203, 102, new DateTime(2022, 8, 26, 1, 32, 33, 141, DateTimeKind.Local).AddTicks(9355), new DateTime(2022, 12, 5, 5, 4, 9, 625, DateTimeKind.Local).AddTicks(6000), 20, -1530464145, null },
                    { 204, 74, new DateTime(2022, 6, 21, 21, 53, 24, 265, DateTimeKind.Local).AddTicks(1518), new DateTime(2023, 3, 30, 6, 34, 18, 605, DateTimeKind.Local).AddTicks(1165), 98, 1368353979, null },
                    { 205, 81, new DateTime(2022, 10, 11, 11, 44, 35, 60, DateTimeKind.Local).AddTicks(5769), new DateTime(2023, 4, 11, 6, 10, 10, 477, DateTimeKind.Local).AddTicks(2245), 40, -1217632393, null },
                    { 206, 3, new DateTime(2022, 10, 20, 21, 32, 18, 721, DateTimeKind.Local).AddTicks(7466), new DateTime(2022, 9, 29, 4, 23, 39, 71, DateTimeKind.Local).AddTicks(4556), 66, 224313458, null },
                    { 207, 105, new DateTime(2023, 3, 31, 0, 49, 11, 273, DateTimeKind.Local).AddTicks(3727), new DateTime(2022, 9, 6, 20, 5, 53, 973, DateTimeKind.Local).AddTicks(830), 5, -234378420, null },
                    { 208, 90, new DateTime(2023, 2, 28, 10, 51, 19, 822, DateTimeKind.Local).AddTicks(6298), new DateTime(2022, 7, 7, 10, 33, 8, 727, DateTimeKind.Local).AddTicks(4413), 27, -2145212934, null },
                    { 209, 103, new DateTime(2022, 10, 12, 2, 58, 30, 598, DateTimeKind.Local).AddTicks(188), new DateTime(2022, 9, 4, 1, 25, 42, 538, DateTimeKind.Local).AddTicks(3366), 84, -920048541, null },
                    { 210, 33, new DateTime(2023, 3, 17, 18, 15, 25, 775, DateTimeKind.Local).AddTicks(1182), new DateTime(2023, 1, 22, 3, 42, 9, 305, DateTimeKind.Local).AddTicks(8452), 84, -200430177, null },
                    { 211, 88, new DateTime(2022, 11, 30, 13, 0, 0, 403, DateTimeKind.Local).AddTicks(7738), new DateTime(2022, 8, 21, 5, 30, 6, 717, DateTimeKind.Local).AddTicks(8291), 46, 55950464, null },
                    { 212, 77, new DateTime(2023, 3, 10, 12, 56, 24, 487, DateTimeKind.Local).AddTicks(2234), new DateTime(2022, 7, 3, 19, 5, 45, 267, DateTimeKind.Local).AddTicks(8575), 67, 509701910, null },
                    { 213, 58, new DateTime(2022, 9, 1, 14, 55, 41, 676, DateTimeKind.Local).AddTicks(3293), new DateTime(2022, 4, 19, 8, 50, 59, 87, DateTimeKind.Local).AddTicks(5082), 31, -562317842, null },
                    { 214, 131, new DateTime(2022, 11, 3, 14, 26, 46, 529, DateTimeKind.Local).AddTicks(7967), new DateTime(2023, 2, 6, 5, 24, 21, 292, DateTimeKind.Local).AddTicks(9112), 72, 85538214, null },
                    { 215, 13, new DateTime(2022, 9, 6, 20, 34, 21, 922, DateTimeKind.Local).AddTicks(9929), new DateTime(2022, 12, 23, 10, 56, 20, 916, DateTimeKind.Local).AddTicks(3190), 75, 631649336, null },
                    { 216, 29, new DateTime(2022, 12, 27, 23, 9, 21, 696, DateTimeKind.Local).AddTicks(5754), new DateTime(2022, 9, 14, 1, 39, 32, 284, DateTimeKind.Local).AddTicks(1977), 41, -2028197313, null },
                    { 217, 130, new DateTime(2022, 10, 5, 15, 36, 9, 583, DateTimeKind.Local).AddTicks(5847), new DateTime(2023, 1, 2, 23, 5, 4, 868, DateTimeKind.Local).AddTicks(2777), 55, 1579937849, null },
                    { 218, 31, new DateTime(2023, 1, 30, 5, 52, 3, 834, DateTimeKind.Local).AddTicks(8545), new DateTime(2023, 2, 12, 23, 55, 31, 664, DateTimeKind.Local).AddTicks(6974), 98, -1780014551, null },
                    { 219, 43, new DateTime(2022, 9, 23, 19, 12, 43, 969, DateTimeKind.Local).AddTicks(7194), new DateTime(2023, 3, 23, 18, 18, 21, 848, DateTimeKind.Local).AddTicks(7278), 45, 340718843, null },
                    { 220, 126, new DateTime(2022, 5, 28, 8, 14, 49, 411, DateTimeKind.Local).AddTicks(7766), new DateTime(2022, 10, 5, 23, 40, 44, 822, DateTimeKind.Local).AddTicks(1953), 64, 467728085, null },
                    { 221, 39, new DateTime(2022, 12, 27, 22, 47, 59, 687, DateTimeKind.Local).AddTicks(8440), new DateTime(2022, 5, 29, 23, 9, 35, 64, DateTimeKind.Local).AddTicks(6047), 60, -1046438767, null },
                    { 222, 21, new DateTime(2023, 3, 25, 4, 42, 44, 907, DateTimeKind.Local).AddTicks(1847), new DateTime(2022, 5, 2, 10, 53, 19, 21, DateTimeKind.Local).AddTicks(7201), 97, -785288711, null },
                    { 223, 49, new DateTime(2022, 6, 4, 16, 34, 57, 948, DateTimeKind.Local).AddTicks(5278), new DateTime(2022, 7, 17, 22, 59, 44, 955, DateTimeKind.Local).AddTicks(6414), 23, -1814026540, null },
                    { 224, 116, new DateTime(2022, 6, 18, 17, 47, 8, 424, DateTimeKind.Local).AddTicks(6202), new DateTime(2023, 1, 12, 18, 6, 2, 966, DateTimeKind.Local).AddTicks(4052), 61, 2136682027, null },
                    { 225, 119, new DateTime(2023, 3, 6, 19, 46, 22, 671, DateTimeKind.Local).AddTicks(7985), new DateTime(2022, 7, 1, 20, 57, 31, 754, DateTimeKind.Local).AddTicks(9013), 28, 1793306317, null },
                    { 226, 123, new DateTime(2022, 6, 24, 3, 2, 35, 318, DateTimeKind.Local).AddTicks(1019), new DateTime(2023, 3, 11, 16, 38, 19, 68, DateTimeKind.Local).AddTicks(1414), 98, -964089305, null },
                    { 227, 68, new DateTime(2022, 9, 29, 19, 38, 2, 672, DateTimeKind.Local).AddTicks(1390), new DateTime(2022, 11, 11, 13, 36, 4, 575, DateTimeKind.Local).AddTicks(2441), 17, -748996887, null },
                    { 228, 58, new DateTime(2022, 9, 25, 8, 14, 32, 201, DateTimeKind.Local).AddTicks(8664), new DateTime(2022, 5, 19, 8, 36, 39, 95, DateTimeKind.Local).AddTicks(6158), 31, -1333776085, null },
                    { 229, 12, new DateTime(2022, 7, 27, 19, 15, 5, 178, DateTimeKind.Local).AddTicks(4256), new DateTime(2023, 2, 24, 19, 59, 41, 385, DateTimeKind.Local).AddTicks(4361), 20, 470214256, null },
                    { 230, 63, new DateTime(2022, 9, 2, 19, 3, 36, 269, DateTimeKind.Local).AddTicks(5098), new DateTime(2022, 11, 21, 23, 31, 29, 820, DateTimeKind.Local).AddTicks(6360), 89, 1601525645, null },
                    { 231, 86, new DateTime(2023, 3, 27, 5, 23, 30, 919, DateTimeKind.Local).AddTicks(9252), new DateTime(2022, 8, 23, 10, 17, 7, 154, DateTimeKind.Local).AddTicks(3763), 80, 1249703293, null },
                    { 232, 70, new DateTime(2022, 9, 21, 22, 26, 2, 135, DateTimeKind.Local).AddTicks(1208), new DateTime(2022, 8, 13, 21, 41, 58, 66, DateTimeKind.Local).AddTicks(2991), 34, -388396480, null },
                    { 233, 46, new DateTime(2022, 7, 3, 0, 39, 21, 974, DateTimeKind.Local).AddTicks(3334), new DateTime(2022, 6, 14, 1, 37, 27, 481, DateTimeKind.Local).AddTicks(1992), 45, 1205047895, null },
                    { 234, 15, new DateTime(2022, 9, 27, 20, 59, 33, 156, DateTimeKind.Local).AddTicks(3461), new DateTime(2022, 7, 9, 17, 38, 2, 628, DateTimeKind.Local).AddTicks(6797), 72, 1305099418, null },
                    { 235, 31, new DateTime(2022, 7, 30, 1, 35, 8, 696, DateTimeKind.Local).AddTicks(9209), new DateTime(2022, 10, 11, 7, 23, 52, 512, DateTimeKind.Local).AddTicks(7894), 45, -1990433324, null },
                    { 236, 96, new DateTime(2022, 8, 21, 19, 55, 8, 951, DateTimeKind.Local).AddTicks(7583), new DateTime(2022, 6, 14, 13, 21, 15, 777, DateTimeKind.Local).AddTicks(182), 59, 183048179, null },
                    { 237, 144, new DateTime(2022, 9, 26, 21, 55, 51, 533, DateTimeKind.Local).AddTicks(4002), new DateTime(2022, 10, 8, 20, 23, 58, 938, DateTimeKind.Local).AddTicks(5148), 76, 130987087, null },
                    { 238, 104, new DateTime(2022, 12, 1, 16, 26, 26, 93, DateTimeKind.Local).AddTicks(7492), new DateTime(2022, 6, 9, 9, 27, 19, 752, DateTimeKind.Local).AddTicks(1606), 5, -997387948, null },
                    { 239, 107, new DateTime(2022, 4, 18, 18, 52, 45, 737, DateTimeKind.Local).AddTicks(9056), new DateTime(2022, 11, 21, 13, 46, 27, 613, DateTimeKind.Local).AddTicks(7229), 17, -800749543, null },
                    { 240, 25, new DateTime(2022, 7, 10, 20, 57, 28, 780, DateTimeKind.Local).AddTicks(1626), new DateTime(2022, 8, 4, 6, 30, 13, 998, DateTimeKind.Local).AddTicks(2058), 76, -1000177637, null },
                    { 241, 131, new DateTime(2022, 4, 24, 7, 32, 40, 735, DateTimeKind.Local).AddTicks(4399), new DateTime(2023, 4, 18, 5, 39, 35, 576, DateTimeKind.Local).AddTicks(3841), 88, -2131414941, null },
                    { 242, 108, new DateTime(2023, 2, 4, 20, 32, 43, 253, DateTimeKind.Local).AddTicks(8023), new DateTime(2023, 3, 13, 5, 34, 42, 275, DateTimeKind.Local).AddTicks(995), 60, 708158435, null },
                    { 243, 143, new DateTime(2022, 8, 5, 1, 30, 44, 188, DateTimeKind.Local).AddTicks(3275), new DateTime(2022, 8, 12, 11, 18, 2, 762, DateTimeKind.Local).AddTicks(6882), 53, -583940506, null },
                    { 244, 16, new DateTime(2022, 6, 24, 1, 21, 5, 247, DateTimeKind.Local).AddTicks(9564), new DateTime(2023, 2, 18, 2, 46, 12, 194, DateTimeKind.Local).AddTicks(7910), 70, 550701089, null },
                    { 245, 33, new DateTime(2022, 5, 27, 5, 9, 23, 541, DateTimeKind.Local).AddTicks(4369), new DateTime(2022, 12, 2, 3, 30, 37, 944, DateTimeKind.Local).AddTicks(8083), 92, 1430010513, null },
                    { 246, 7, new DateTime(2022, 8, 29, 17, 49, 51, 876, DateTimeKind.Local).AddTicks(2261), new DateTime(2022, 7, 15, 0, 4, 3, 310, DateTimeKind.Local).AddTicks(3633), 91, -772264662, null },
                    { 247, 141, new DateTime(2022, 8, 12, 17, 32, 29, 121, DateTimeKind.Local).AddTicks(4322), new DateTime(2023, 4, 17, 7, 37, 9, 500, DateTimeKind.Local).AddTicks(3954), 93, -784256718, null },
                    { 248, 23, new DateTime(2023, 4, 11, 17, 22, 7, 419, DateTimeKind.Local).AddTicks(9572), new DateTime(2023, 1, 7, 17, 31, 35, 543, DateTimeKind.Local).AddTicks(1285), 10, -1317406364, null },
                    { 249, 3, new DateTime(2022, 8, 27, 23, 1, 38, 126, DateTimeKind.Local).AddTicks(5753), new DateTime(2022, 7, 31, 16, 2, 26, 476, DateTimeKind.Local).AddTicks(5866), 44, -275097717, null },
                    { 250, 99, new DateTime(2023, 1, 16, 2, 4, 6, 560, DateTimeKind.Local).AddTicks(5783), new DateTime(2023, 4, 3, 14, 18, 45, 402, DateTimeKind.Local).AddTicks(202), 65, 101108107, null },
                    { 251, 69, new DateTime(2023, 4, 18, 4, 41, 48, 484, DateTimeKind.Local).AddTicks(3577), new DateTime(2023, 3, 15, 18, 3, 10, 150, DateTimeKind.Local).AddTicks(766), 76, 1836638708, null },
                    { 252, 105, new DateTime(2023, 2, 19, 19, 14, 35, 307, DateTimeKind.Local).AddTicks(4039), new DateTime(2023, 3, 28, 12, 13, 21, 112, DateTimeKind.Local).AddTicks(7972), 99, 1450138175, null },
                    { 253, 126, new DateTime(2022, 10, 21, 13, 10, 39, 493, DateTimeKind.Local).AddTicks(9084), new DateTime(2022, 10, 4, 0, 1, 46, 575, DateTimeKind.Local).AddTicks(5676), 90, -1690239443, null },
                    { 254, 60, new DateTime(2022, 6, 30, 5, 45, 40, 142, DateTimeKind.Local).AddTicks(6788), new DateTime(2022, 6, 18, 22, 8, 17, 699, DateTimeKind.Local).AddTicks(3611), 28, -955940343, null },
                    { 255, 34, new DateTime(2023, 3, 22, 5, 11, 14, 157, DateTimeKind.Local).AddTicks(1038), new DateTime(2022, 8, 22, 11, 53, 13, 504, DateTimeKind.Local).AddTicks(215), 24, 190044907, null },
                    { 256, 30, new DateTime(2023, 4, 16, 21, 22, 3, 846, DateTimeKind.Local).AddTicks(4131), new DateTime(2022, 12, 3, 0, 17, 11, 421, DateTimeKind.Local).AddTicks(2895), 4, 941709142, null },
                    { 257, 64, new DateTime(2023, 1, 16, 10, 17, 44, 413, DateTimeKind.Local).AddTicks(4303), new DateTime(2022, 8, 11, 10, 55, 56, 255, DateTimeKind.Local).AddTicks(7984), 94, -659627349, null },
                    { 258, 16, new DateTime(2022, 10, 13, 3, 24, 6, 88, DateTimeKind.Local).AddTicks(5752), new DateTime(2023, 1, 14, 2, 8, 21, 254, DateTimeKind.Local).AddTicks(2026), 47, -846117973, null },
                    { 259, 128, new DateTime(2022, 9, 4, 0, 16, 55, 835, DateTimeKind.Local).AddTicks(9865), new DateTime(2022, 11, 7, 0, 11, 31, 106, DateTimeKind.Local).AddTicks(9897), 97, -530197090, null },
                    { 260, 82, new DateTime(2022, 7, 9, 11, 59, 13, 949, DateTimeKind.Local).AddTicks(7937), new DateTime(2023, 1, 24, 11, 8, 4, 597, DateTimeKind.Local).AddTicks(9838), 5, -282546085, null },
                    { 261, 94, new DateTime(2023, 3, 9, 20, 55, 15, 387, DateTimeKind.Local).AddTicks(4748), new DateTime(2023, 1, 14, 7, 54, 11, 395, DateTimeKind.Local).AddTicks(3375), 78, 1771339397, null },
                    { 262, 73, new DateTime(2023, 4, 16, 14, 7, 24, 411, DateTimeKind.Local).AddTicks(1240), new DateTime(2023, 4, 5, 23, 21, 34, 23, DateTimeKind.Local).AddTicks(6709), 66, 1321286396, null },
                    { 263, 122, new DateTime(2022, 10, 25, 20, 8, 7, 237, DateTimeKind.Local).AddTicks(2558), new DateTime(2022, 11, 14, 7, 41, 35, 190, DateTimeKind.Local).AddTicks(9119), 22, 1803018911, null },
                    { 264, 90, new DateTime(2023, 4, 16, 9, 26, 3, 293, DateTimeKind.Local).AddTicks(669), new DateTime(2022, 9, 26, 6, 6, 14, 865, DateTimeKind.Local).AddTicks(1887), 59, 1613607989, null },
                    { 265, 95, new DateTime(2023, 2, 18, 18, 0, 8, 510, DateTimeKind.Local).AddTicks(5682), new DateTime(2022, 9, 26, 19, 53, 47, 225, DateTimeKind.Local).AddTicks(1458), 46, 94239325, null },
                    { 266, 71, new DateTime(2022, 9, 14, 7, 47, 8, 972, DateTimeKind.Local).AddTicks(9313), new DateTime(2022, 7, 3, 17, 11, 21, 851, DateTimeKind.Local).AddTicks(3272), 45, -1776676748, null },
                    { 267, 35, new DateTime(2022, 9, 20, 18, 15, 31, 483, DateTimeKind.Local).AddTicks(5170), new DateTime(2022, 11, 17, 4, 21, 39, 502, DateTimeKind.Local).AddTicks(3656), 33, 319027858, null },
                    { 268, 54, new DateTime(2022, 7, 5, 8, 59, 56, 477, DateTimeKind.Local).AddTicks(3895), new DateTime(2022, 8, 8, 11, 55, 44, 22, DateTimeKind.Local).AddTicks(9603), 78, -1205341454, null },
                    { 269, 127, new DateTime(2022, 6, 2, 0, 7, 40, 79, DateTimeKind.Local).AddTicks(5284), new DateTime(2022, 11, 19, 15, 21, 40, 610, DateTimeKind.Local).AddTicks(988), 45, -940091468, null },
                    { 270, 112, new DateTime(2022, 7, 31, 14, 26, 38, 862, DateTimeKind.Local).AddTicks(8492), new DateTime(2022, 11, 4, 22, 30, 47, 304, DateTimeKind.Local).AddTicks(9004), 9, 1243781159, null },
                    { 271, 33, new DateTime(2022, 10, 28, 5, 48, 35, 190, DateTimeKind.Local).AddTicks(353), new DateTime(2022, 8, 21, 19, 20, 58, 222, DateTimeKind.Local).AddTicks(4347), 43, -2068366754, null },
                    { 272, 14, new DateTime(2022, 8, 14, 1, 15, 55, 526, DateTimeKind.Local).AddTicks(1997), new DateTime(2022, 12, 6, 7, 23, 28, 545, DateTimeKind.Local).AddTicks(2780), 63, -2104816917, null },
                    { 273, 10, new DateTime(2022, 4, 21, 13, 24, 19, 185, DateTimeKind.Local).AddTicks(3684), new DateTime(2022, 11, 17, 0, 31, 50, 668, DateTimeKind.Local).AddTicks(6892), 85, 1669022243, null },
                    { 274, 33, new DateTime(2022, 7, 5, 0, 29, 19, 170, DateTimeKind.Local).AddTicks(6183), new DateTime(2022, 12, 28, 19, 15, 0, 882, DateTimeKind.Local).AddTicks(6748), 39, 1593435973, null },
                    { 275, 48, new DateTime(2022, 5, 12, 3, 23, 37, 431, DateTimeKind.Local).AddTicks(577), new DateTime(2022, 11, 13, 14, 36, 20, 828, DateTimeKind.Local).AddTicks(5186), 4, -1649326593, null },
                    { 276, 89, new DateTime(2023, 1, 13, 14, 23, 32, 514, DateTimeKind.Local).AddTicks(5615), new DateTime(2022, 6, 9, 15, 21, 18, 539, DateTimeKind.Local).AddTicks(8593), 91, -359497882, null },
                    { 277, 118, new DateTime(2022, 4, 26, 20, 24, 5, 205, DateTimeKind.Local).AddTicks(8862), new DateTime(2022, 7, 23, 22, 37, 22, 678, DateTimeKind.Local).AddTicks(6652), 3, -384253457, null },
                    { 278, 90, new DateTime(2022, 10, 27, 22, 17, 49, 989, DateTimeKind.Local).AddTicks(5124), new DateTime(2022, 8, 3, 13, 7, 25, 980, DateTimeKind.Local).AddTicks(3292), 72, 747136590, null },
                    { 279, 107, new DateTime(2023, 2, 27, 10, 13, 56, 481, DateTimeKind.Local).AddTicks(3253), new DateTime(2023, 1, 26, 15, 30, 41, 547, DateTimeKind.Local).AddTicks(3910), 92, 548656646, null },
                    { 280, 141, new DateTime(2023, 2, 16, 12, 12, 43, 807, DateTimeKind.Local).AddTicks(4667), new DateTime(2023, 1, 23, 0, 36, 9, 576, DateTimeKind.Local).AddTicks(4067), 1, 2011133756, null },
                    { 281, 32, new DateTime(2022, 9, 22, 7, 8, 58, 146, DateTimeKind.Local).AddTicks(2681), new DateTime(2022, 8, 1, 6, 35, 27, 48, DateTimeKind.Local).AddTicks(1032), 56, 933675424, null },
                    { 282, 56, new DateTime(2022, 12, 25, 14, 21, 4, 297, DateTimeKind.Local).AddTicks(6301), new DateTime(2023, 1, 24, 11, 0, 9, 770, DateTimeKind.Local).AddTicks(1708), 37, 231151910, null },
                    { 283, 87, new DateTime(2022, 12, 1, 2, 1, 35, 64, DateTimeKind.Local).AddTicks(6448), new DateTime(2022, 7, 11, 19, 52, 37, 849, DateTimeKind.Local).AddTicks(3230), 6, -1254999119, null },
                    { 284, 44, new DateTime(2022, 10, 1, 7, 37, 51, 434, DateTimeKind.Local).AddTicks(2764), new DateTime(2022, 6, 18, 15, 42, 12, 344, DateTimeKind.Local).AddTicks(8578), 82, -2095335300, null },
                    { 285, 93, new DateTime(2022, 8, 29, 11, 39, 27, 762, DateTimeKind.Local).AddTicks(8573), new DateTime(2022, 6, 16, 12, 34, 21, 339, DateTimeKind.Local).AddTicks(3620), 96, 1618841159, null },
                    { 286, 142, new DateTime(2022, 8, 26, 1, 32, 9, 58, DateTimeKind.Local).AddTicks(4956), new DateTime(2023, 1, 16, 18, 56, 25, 182, DateTimeKind.Local).AddTicks(9277), 12, -681383983, null },
                    { 287, 43, new DateTime(2022, 10, 15, 18, 45, 45, 958, DateTimeKind.Local).AddTicks(7149), new DateTime(2022, 8, 16, 17, 53, 25, 29, DateTimeKind.Local).AddTicks(4619), 59, -1649504219, null },
                    { 288, 85, new DateTime(2022, 12, 29, 0, 56, 50, 511, DateTimeKind.Local).AddTicks(3481), new DateTime(2023, 3, 14, 16, 42, 1, 304, DateTimeKind.Local).AddTicks(7583), 8, -1343948870, null },
                    { 289, 106, new DateTime(2022, 6, 3, 13, 1, 51, 605, DateTimeKind.Local).AddTicks(2504), new DateTime(2022, 8, 7, 19, 48, 59, 442, DateTimeKind.Local).AddTicks(1870), 15, 645245846, null },
                    { 290, 83, new DateTime(2022, 10, 20, 7, 23, 22, 179, DateTimeKind.Local).AddTicks(7750), new DateTime(2022, 8, 23, 15, 1, 31, 160, DateTimeKind.Local).AddTicks(6804), 2, 486229211, null },
                    { 291, 113, new DateTime(2022, 8, 13, 13, 15, 25, 780, DateTimeKind.Local).AddTicks(3988), new DateTime(2023, 2, 24, 16, 46, 46, 799, DateTimeKind.Local).AddTicks(7335), 48, 1184057346, null },
                    { 292, 106, new DateTime(2022, 5, 26, 11, 15, 4, 450, DateTimeKind.Local).AddTicks(5451), new DateTime(2022, 9, 2, 21, 43, 53, 185, DateTimeKind.Local).AddTicks(4497), 22, 415791052, null },
                    { 293, 46, new DateTime(2023, 1, 11, 3, 9, 57, 162, DateTimeKind.Local).AddTicks(4341), new DateTime(2022, 11, 28, 19, 39, 0, 230, DateTimeKind.Local).AddTicks(9665), 17, -1801661888, null },
                    { 294, 50, new DateTime(2023, 3, 4, 9, 29, 37, 374, DateTimeKind.Local).AddTicks(8739), new DateTime(2022, 9, 7, 14, 44, 2, 885, DateTimeKind.Local).AddTicks(5508), 30, -583918377, null },
                    { 295, 48, new DateTime(2023, 3, 3, 18, 54, 29, 557, DateTimeKind.Local).AddTicks(608), new DateTime(2023, 3, 20, 23, 29, 9, 664, DateTimeKind.Local).AddTicks(8635), 57, -433963457, null },
                    { 296, 97, new DateTime(2023, 2, 22, 13, 20, 33, 17, DateTimeKind.Local).AddTicks(899), new DateTime(2022, 10, 20, 16, 11, 25, 784, DateTimeKind.Local).AddTicks(8590), 87, -1549899972, null },
                    { 297, 43, new DateTime(2022, 9, 4, 12, 33, 21, 610, DateTimeKind.Local).AddTicks(8825), new DateTime(2023, 3, 9, 14, 53, 0, 184, DateTimeKind.Local).AddTicks(9541), 28, 1412351307, null },
                    { 298, 128, new DateTime(2022, 6, 24, 21, 17, 19, 72, DateTimeKind.Local).AddTicks(6070), new DateTime(2022, 11, 19, 20, 20, 45, 428, DateTimeKind.Local).AddTicks(3295), 42, -1718449143, null },
                    { 299, 148, new DateTime(2022, 12, 6, 2, 54, 55, 912, DateTimeKind.Local).AddTicks(9346), new DateTime(2022, 12, 6, 21, 30, 43, 275, DateTimeKind.Local).AddTicks(6498), 13, -902729824, null },
                    { 300, 76, new DateTime(2023, 4, 5, 11, 5, 31, 54, DateTimeKind.Local).AddTicks(8408), new DateTime(2022, 5, 31, 1, 3, 51, 860, DateTimeKind.Local).AddTicks(6865), 27, -1377207215, null },
                    { 301, 133, new DateTime(2022, 10, 15, 14, 13, 48, 748, DateTimeKind.Local).AddTicks(3055), new DateTime(2022, 7, 9, 18, 55, 59, 126, DateTimeKind.Local).AddTicks(4483), 39, 1531217247, null },
                    { 302, 138, new DateTime(2022, 7, 2, 0, 7, 11, 807, DateTimeKind.Local).AddTicks(3530), new DateTime(2022, 6, 22, 23, 29, 0, 280, DateTimeKind.Local).AddTicks(1718), 30, 985964765, null },
                    { 303, 40, new DateTime(2023, 3, 1, 18, 40, 59, 52, DateTimeKind.Local).AddTicks(6760), new DateTime(2022, 8, 6, 22, 0, 26, 818, DateTimeKind.Local).AddTicks(7479), 58, 1510302669, null },
                    { 304, 63, new DateTime(2022, 7, 4, 9, 31, 4, 800, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 6, 19, 4, 59, 52, 668, DateTimeKind.Local).AddTicks(978), 43, 1614792615, null },
                    { 305, 28, new DateTime(2022, 6, 3, 21, 2, 51, 604, DateTimeKind.Local).AddTicks(4581), new DateTime(2022, 5, 13, 14, 19, 26, 878, DateTimeKind.Local).AddTicks(402), 60, 839634802, null },
                    { 306, 119, new DateTime(2023, 1, 31, 19, 7, 20, 246, DateTimeKind.Local).AddTicks(5985), new DateTime(2022, 12, 25, 7, 38, 50, 798, DateTimeKind.Local).AddTicks(9082), 9, 1497183978, null },
                    { 307, 129, new DateTime(2023, 1, 11, 20, 46, 59, 250, DateTimeKind.Local).AddTicks(7846), new DateTime(2022, 12, 24, 11, 44, 59, 405, DateTimeKind.Local).AddTicks(710), 49, 1215229453, null },
                    { 308, 115, new DateTime(2022, 12, 12, 9, 32, 49, 308, DateTimeKind.Local).AddTicks(6328), new DateTime(2023, 3, 26, 8, 10, 44, 640, DateTimeKind.Local).AddTicks(5929), 97, 2089987727, null },
                    { 309, 37, new DateTime(2022, 8, 9, 18, 39, 14, 400, DateTimeKind.Local).AddTicks(5859), new DateTime(2022, 4, 26, 0, 16, 40, 96, DateTimeKind.Local).AddTicks(3341), 29, 507431003, null },
                    { 310, 57, new DateTime(2023, 2, 5, 18, 34, 38, 814, DateTimeKind.Local).AddTicks(2726), new DateTime(2022, 12, 10, 6, 14, 11, 424, DateTimeKind.Local).AddTicks(7318), 14, 463067461, null },
                    { 311, 120, new DateTime(2022, 10, 6, 5, 47, 3, 195, DateTimeKind.Local).AddTicks(3821), new DateTime(2023, 2, 22, 20, 6, 50, 728, DateTimeKind.Local).AddTicks(9906), 49, 1762384282, null },
                    { 312, 18, new DateTime(2022, 4, 22, 15, 39, 3, 9, DateTimeKind.Local).AddTicks(1357), new DateTime(2022, 8, 4, 6, 45, 54, 975, DateTimeKind.Local).AddTicks(1022), 72, -448041989, null },
                    { 313, 81, new DateTime(2022, 7, 12, 9, 39, 14, 347, DateTimeKind.Local).AddTicks(2267), new DateTime(2023, 3, 21, 23, 55, 20, 91, DateTimeKind.Local).AddTicks(2113), 20, -347229974, null },
                    { 314, 16, new DateTime(2022, 6, 30, 19, 23, 54, 821, DateTimeKind.Local).AddTicks(5808), new DateTime(2022, 9, 11, 0, 15, 57, 508, DateTimeKind.Local).AddTicks(5207), 63, -935132432, null },
                    { 315, 30, new DateTime(2023, 1, 4, 5, 53, 27, 552, DateTimeKind.Local).AddTicks(7876), new DateTime(2022, 11, 9, 6, 35, 41, 746, DateTimeKind.Local).AddTicks(3257), 68, -821541850, null },
                    { 316, 73, new DateTime(2022, 6, 9, 10, 57, 27, 215, DateTimeKind.Local).AddTicks(2002), new DateTime(2022, 6, 24, 12, 55, 9, 400, DateTimeKind.Local).AddTicks(1932), 66, 1927039197, null },
                    { 317, 11, new DateTime(2022, 11, 18, 5, 5, 18, 400, DateTimeKind.Local).AddTicks(4452), new DateTime(2023, 2, 12, 2, 39, 11, 232, DateTimeKind.Local).AddTicks(6661), 92, 983091410, null },
                    { 318, 122, new DateTime(2022, 8, 7, 6, 57, 55, 638, DateTimeKind.Local).AddTicks(4310), new DateTime(2023, 1, 28, 9, 15, 1, 547, DateTimeKind.Local).AddTicks(6295), 73, -951709744, null },
                    { 319, 78, new DateTime(2022, 11, 7, 13, 18, 58, 415, DateTimeKind.Local).AddTicks(7015), new DateTime(2023, 1, 4, 8, 23, 42, 218, DateTimeKind.Local).AddTicks(2446), 99, 1605427356, null },
                    { 320, 10, new DateTime(2022, 9, 13, 22, 42, 51, 349, DateTimeKind.Local).AddTicks(6883), new DateTime(2022, 12, 4, 5, 33, 45, 829, DateTimeKind.Local).AddTicks(6523), 26, -903379687, null },
                    { 321, 85, new DateTime(2023, 3, 5, 8, 50, 1, 94, DateTimeKind.Local).AddTicks(128), new DateTime(2022, 11, 13, 6, 24, 36, 329, DateTimeKind.Local).AddTicks(9868), 87, 28884614, null },
                    { 322, 41, new DateTime(2022, 11, 10, 4, 40, 7, 476, DateTimeKind.Local).AddTicks(4799), new DateTime(2023, 2, 12, 11, 57, 10, 751, DateTimeKind.Local).AddTicks(3552), 100, -1803290520, null },
                    { 323, 14, new DateTime(2022, 12, 27, 6, 34, 1, 59, DateTimeKind.Local).AddTicks(8573), new DateTime(2022, 5, 10, 7, 15, 5, 590, DateTimeKind.Local).AddTicks(1240), 45, 671080596, null },
                    { 324, 114, new DateTime(2022, 8, 5, 5, 55, 13, 885, DateTimeKind.Local).AddTicks(3146), new DateTime(2023, 4, 16, 4, 26, 22, 569, DateTimeKind.Local).AddTicks(9127), 9, -1212001324, null },
                    { 325, 108, new DateTime(2023, 1, 22, 15, 33, 44, 808, DateTimeKind.Local).AddTicks(1023), new DateTime(2022, 8, 23, 14, 13, 51, 546, DateTimeKind.Local).AddTicks(9941), 95, 199182812, null },
                    { 326, 122, new DateTime(2022, 4, 26, 1, 42, 50, 350, DateTimeKind.Local).AddTicks(9538), new DateTime(2022, 11, 29, 9, 28, 40, 116, DateTimeKind.Local).AddTicks(3246), 71, 237922514, null },
                    { 327, 83, new DateTime(2023, 3, 18, 5, 37, 52, 400, DateTimeKind.Local).AddTicks(1202), new DateTime(2023, 3, 10, 4, 30, 3, 494, DateTimeKind.Local).AddTicks(2465), 84, -447704509, null },
                    { 328, 78, new DateTime(2022, 12, 12, 17, 52, 49, 928, DateTimeKind.Local).AddTicks(4905), new DateTime(2022, 9, 7, 10, 30, 16, 28, DateTimeKind.Local).AddTicks(7344), 67, -2082135139, null },
                    { 329, 138, new DateTime(2022, 9, 21, 23, 37, 26, 511, DateTimeKind.Local).AddTicks(5429), new DateTime(2023, 3, 16, 2, 5, 59, 773, DateTimeKind.Local).AddTicks(6017), 61, -869193625, null },
                    { 330, 65, new DateTime(2022, 6, 21, 18, 47, 23, 138, DateTimeKind.Local).AddTicks(3810), new DateTime(2022, 8, 27, 10, 43, 43, 213, DateTimeKind.Local).AddTicks(3352), 36, 1013648925, null },
                    { 331, 36, new DateTime(2022, 7, 23, 12, 24, 21, 848, DateTimeKind.Local).AddTicks(565), new DateTime(2022, 8, 29, 2, 27, 54, 241, DateTimeKind.Local).AddTicks(9528), 64, 1916166581, null },
                    { 332, 114, new DateTime(2023, 3, 2, 4, 55, 48, 699, DateTimeKind.Local).AddTicks(9580), new DateTime(2023, 1, 23, 22, 6, 37, 133, DateTimeKind.Local).AddTicks(153), 51, 1246877999, null },
                    { 333, 66, new DateTime(2022, 12, 13, 14, 28, 41, 592, DateTimeKind.Local).AddTicks(9153), new DateTime(2022, 10, 4, 5, 19, 20, 294, DateTimeKind.Local).AddTicks(7177), 82, -144434339, null },
                    { 334, 142, new DateTime(2022, 8, 17, 19, 34, 5, 466, DateTimeKind.Local).AddTicks(4182), new DateTime(2023, 3, 28, 9, 46, 29, 968, DateTimeKind.Local).AddTicks(1911), 83, -1752018759, null },
                    { 335, 111, new DateTime(2022, 9, 14, 23, 39, 22, 213, DateTimeKind.Local).AddTicks(7594), new DateTime(2022, 11, 7, 9, 31, 39, 972, DateTimeKind.Local).AddTicks(940), 59, -1598770130, null },
                    { 336, 50, new DateTime(2022, 10, 11, 12, 41, 58, 480, DateTimeKind.Local).AddTicks(4334), new DateTime(2022, 5, 14, 19, 2, 43, 291, DateTimeKind.Local).AddTicks(1537), 19, -697935709, null },
                    { 337, 105, new DateTime(2022, 12, 15, 7, 34, 52, 480, DateTimeKind.Local).AddTicks(5909), new DateTime(2023, 2, 13, 19, 47, 37, 634, DateTimeKind.Local).AddTicks(4176), 75, 505978249, null },
                    { 338, 92, new DateTime(2022, 8, 25, 9, 6, 4, 751, DateTimeKind.Local).AddTicks(8181), new DateTime(2022, 10, 14, 5, 10, 16, 249, DateTimeKind.Local).AddTicks(9985), 19, -84108204, null },
                    { 339, 90, new DateTime(2023, 4, 10, 16, 35, 38, 101, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 10, 30, 8, 39, 39, 224, DateTimeKind.Local).AddTicks(278), 90, -1246951979, null },
                    { 340, 52, new DateTime(2022, 5, 31, 15, 0, 9, 961, DateTimeKind.Local).AddTicks(7614), new DateTime(2023, 3, 19, 22, 50, 30, 577, DateTimeKind.Local).AddTicks(8055), 8, 974742311, null },
                    { 341, 129, new DateTime(2023, 1, 2, 3, 48, 30, 690, DateTimeKind.Local).AddTicks(54), new DateTime(2023, 1, 27, 6, 10, 42, 935, DateTimeKind.Local).AddTicks(198), 42, -190296773, null },
                    { 342, 122, new DateTime(2022, 7, 5, 11, 15, 24, 809, DateTimeKind.Local).AddTicks(3939), new DateTime(2022, 8, 21, 6, 59, 19, 816, DateTimeKind.Local).AddTicks(7268), 17, 434047721, null },
                    { 343, 78, new DateTime(2022, 10, 13, 21, 59, 39, 339, DateTimeKind.Local).AddTicks(368), new DateTime(2022, 9, 3, 11, 47, 3, 350, DateTimeKind.Local).AddTicks(2955), 25, -217340532, null },
                    { 344, 57, new DateTime(2022, 11, 3, 14, 55, 59, 886, DateTimeKind.Local).AddTicks(1966), new DateTime(2022, 12, 29, 13, 16, 15, 973, DateTimeKind.Local).AddTicks(869), 84, 1490628797, null },
                    { 345, 122, new DateTime(2022, 5, 26, 10, 9, 20, 768, DateTimeKind.Local).AddTicks(5353), new DateTime(2022, 6, 28, 14, 12, 51, 633, DateTimeKind.Local).AddTicks(3277), 72, 663888237, null },
                    { 346, 144, new DateTime(2023, 4, 1, 17, 57, 0, 66, DateTimeKind.Local).AddTicks(7669), new DateTime(2023, 2, 2, 12, 40, 25, 202, DateTimeKind.Local).AddTicks(4168), 42, 2052639352, null },
                    { 347, 126, new DateTime(2022, 8, 25, 15, 26, 43, 128, DateTimeKind.Local).AddTicks(642), new DateTime(2023, 1, 24, 10, 12, 56, 134, DateTimeKind.Local).AddTicks(4592), 80, -816174205, null },
                    { 348, 31, new DateTime(2022, 4, 23, 17, 22, 53, 529, DateTimeKind.Local).AddTicks(9310), new DateTime(2023, 1, 21, 20, 39, 30, 835, DateTimeKind.Local).AddTicks(4507), 92, 1504982943, null },
                    { 349, 77, new DateTime(2023, 4, 8, 22, 15, 9, 362, DateTimeKind.Local).AddTicks(6063), new DateTime(2022, 12, 18, 4, 4, 34, 569, DateTimeKind.Local).AddTicks(9219), 86, -713358095, null },
                    { 350, 45, new DateTime(2022, 7, 15, 6, 43, 5, 770, DateTimeKind.Local).AddTicks(8828), new DateTime(2022, 5, 13, 19, 33, 10, 349, DateTimeKind.Local).AddTicks(5383), 4, 845903399, null },
                    { 351, 103, new DateTime(2022, 5, 14, 23, 13, 54, 867, DateTimeKind.Local).AddTicks(8493), new DateTime(2022, 8, 16, 6, 6, 47, 32, DateTimeKind.Local).AddTicks(7915), 91, 1999411230, null },
                    { 352, 4, new DateTime(2022, 8, 16, 8, 28, 41, 68, DateTimeKind.Local).AddTicks(6920), new DateTime(2022, 10, 13, 20, 25, 0, 510, DateTimeKind.Local).AddTicks(2626), 10, -427041568, null },
                    { 353, 109, new DateTime(2022, 7, 19, 12, 25, 23, 545, DateTimeKind.Local).AddTicks(5171), new DateTime(2023, 1, 12, 14, 50, 4, 391, DateTimeKind.Local).AddTicks(2545), 14, 1985573460, null },
                    { 354, 12, new DateTime(2022, 8, 18, 14, 54, 26, 500, DateTimeKind.Local).AddTicks(2341), new DateTime(2022, 10, 31, 17, 56, 26, 53, DateTimeKind.Local).AddTicks(8457), 45, 1042925108, null },
                    { 355, 13, new DateTime(2022, 11, 11, 14, 36, 5, 331, DateTimeKind.Local).AddTicks(1926), new DateTime(2022, 12, 17, 18, 49, 18, 687, DateTimeKind.Local).AddTicks(2535), 81, -1195138417, null },
                    { 356, 84, new DateTime(2022, 7, 22, 23, 17, 51, 605, DateTimeKind.Local).AddTicks(7388), new DateTime(2023, 4, 2, 1, 27, 23, 34, DateTimeKind.Local).AddTicks(789), 17, -565416360, null },
                    { 357, 42, new DateTime(2022, 7, 12, 11, 37, 45, 824, DateTimeKind.Local).AddTicks(5095), new DateTime(2022, 12, 19, 11, 40, 50, 55, DateTimeKind.Local).AddTicks(2547), 53, -97220450, null },
                    { 358, 19, new DateTime(2023, 1, 12, 1, 6, 36, 170, DateTimeKind.Local).AddTicks(9984), new DateTime(2022, 11, 15, 5, 31, 6, 643, DateTimeKind.Local).AddTicks(7), 36, -663441248, null },
                    { 359, 145, new DateTime(2022, 5, 26, 13, 36, 24, 901, DateTimeKind.Local).AddTicks(7329), new DateTime(2022, 7, 24, 23, 8, 37, 923, DateTimeKind.Local).AddTicks(6120), 5, -1827574851, null },
                    { 360, 57, new DateTime(2023, 3, 10, 15, 2, 43, 919, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 7, 13, 10, 3, 42, 712, DateTimeKind.Local).AddTicks(2106), 3, -1950773967, null },
                    { 361, 21, new DateTime(2023, 3, 16, 4, 30, 47, 916, DateTimeKind.Local).AddTicks(203), new DateTime(2023, 2, 4, 20, 10, 12, 592, DateTimeKind.Local).AddTicks(4181), 17, 1061325607, null },
                    { 362, 109, new DateTime(2022, 7, 3, 15, 45, 48, 985, DateTimeKind.Local).AddTicks(1153), new DateTime(2022, 7, 8, 15, 10, 5, 707, DateTimeKind.Local).AddTicks(2609), 46, -1794923345, null },
                    { 363, 85, new DateTime(2022, 10, 8, 22, 42, 12, 859, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 5, 6, 12, 49, 40, 824, DateTimeKind.Local).AddTicks(4097), 85, -955929533, null },
                    { 364, 64, new DateTime(2022, 7, 12, 6, 38, 17, 333, DateTimeKind.Local).AddTicks(9657), new DateTime(2022, 12, 10, 15, 22, 4, 566, DateTimeKind.Local).AddTicks(5754), 87, 946951551, null },
                    { 365, 133, new DateTime(2023, 2, 24, 17, 50, 37, 509, DateTimeKind.Local).AddTicks(5058), new DateTime(2022, 6, 21, 12, 5, 39, 288, DateTimeKind.Local).AddTicks(8740), 95, 1490654996, null },
                    { 366, 52, new DateTime(2023, 2, 19, 17, 36, 20, 196, DateTimeKind.Local).AddTicks(7156), new DateTime(2023, 4, 12, 10, 38, 49, 412, DateTimeKind.Local).AddTicks(821), 26, -913887941, null },
                    { 367, 49, new DateTime(2023, 1, 30, 12, 23, 25, 95, DateTimeKind.Local).AddTicks(3667), new DateTime(2022, 10, 25, 6, 5, 37, 941, DateTimeKind.Local).AddTicks(2574), 46, 1276957366, null },
                    { 368, 140, new DateTime(2022, 11, 10, 16, 14, 3, 346, DateTimeKind.Local).AddTicks(2857), new DateTime(2022, 11, 11, 9, 20, 15, 186, DateTimeKind.Local).AddTicks(1539), 19, -1976621502, null },
                    { 369, 101, new DateTime(2023, 2, 15, 2, 11, 27, 903, DateTimeKind.Local).AddTicks(1584), new DateTime(2023, 4, 8, 9, 41, 16, 907, DateTimeKind.Local).AddTicks(6968), 98, 1358424556, null },
                    { 370, 81, new DateTime(2022, 9, 14, 11, 10, 13, 827, DateTimeKind.Local).AddTicks(3342), new DateTime(2022, 6, 29, 1, 31, 26, 894, DateTimeKind.Local).AddTicks(5364), 47, -901771478, null },
                    { 371, 149, new DateTime(2022, 10, 23, 9, 58, 18, 409, DateTimeKind.Local).AddTicks(6623), new DateTime(2022, 7, 4, 14, 18, 3, 514, DateTimeKind.Local).AddTicks(7151), 49, 731626325, null },
                    { 372, 48, new DateTime(2022, 9, 25, 21, 47, 49, 918, DateTimeKind.Local).AddTicks(9061), new DateTime(2022, 9, 3, 6, 20, 58, 722, DateTimeKind.Local).AddTicks(1883), 60, -1633888111, null },
                    { 373, 82, new DateTime(2022, 7, 4, 6, 2, 50, 355, DateTimeKind.Local).AddTicks(6117), new DateTime(2023, 2, 24, 19, 43, 57, 383, DateTimeKind.Local).AddTicks(7208), 20, 132205358, null },
                    { 374, 43, new DateTime(2022, 10, 15, 8, 34, 20, 625, DateTimeKind.Local).AddTicks(3214), new DateTime(2022, 6, 23, 11, 38, 6, 280, DateTimeKind.Local).AddTicks(5905), 23, 2001368024, null },
                    { 375, 12, new DateTime(2022, 7, 21, 2, 9, 20, 125, DateTimeKind.Local).AddTicks(620), new DateTime(2023, 3, 2, 23, 10, 58, 814, DateTimeKind.Local).AddTicks(1619), 98, -1124283804, null },
                    { 376, 47, new DateTime(2022, 9, 12, 12, 11, 5, 770, DateTimeKind.Local).AddTicks(6815), new DateTime(2022, 5, 21, 1, 44, 49, 578, DateTimeKind.Local).AddTicks(9052), 51, -788399604, null },
                    { 377, 14, new DateTime(2022, 4, 28, 20, 56, 12, 746, DateTimeKind.Local).AddTicks(8146), new DateTime(2023, 2, 6, 18, 59, 0, 615, DateTimeKind.Local).AddTicks(488), 13, -198755581, null },
                    { 378, 112, new DateTime(2022, 5, 29, 3, 2, 17, 297, DateTimeKind.Local).AddTicks(7758), new DateTime(2022, 11, 22, 5, 46, 15, 64, DateTimeKind.Local).AddTicks(6172), 26, 230171267, null },
                    { 379, 52, new DateTime(2022, 12, 14, 10, 43, 13, 260, DateTimeKind.Local).AddTicks(5164), new DateTime(2023, 1, 10, 20, 49, 48, 479, DateTimeKind.Local).AddTicks(5795), 30, -878592067, null },
                    { 380, 56, new DateTime(2022, 11, 16, 6, 41, 30, 445, DateTimeKind.Local).AddTicks(6324), new DateTime(2023, 2, 25, 21, 32, 3, 630, DateTimeKind.Local).AddTicks(7075), 86, 1129714399, null },
                    { 381, 89, new DateTime(2023, 1, 5, 6, 19, 38, 346, DateTimeKind.Local).AddTicks(3329), new DateTime(2022, 8, 28, 20, 32, 46, 111, DateTimeKind.Local).AddTicks(3593), 77, 456638240, null },
                    { 382, 44, new DateTime(2023, 2, 2, 23, 32, 33, 151, DateTimeKind.Local).AddTicks(7896), new DateTime(2022, 8, 7, 4, 44, 29, 956, DateTimeKind.Local).AddTicks(5340), 15, -1744137221, null },
                    { 383, 53, new DateTime(2023, 3, 30, 16, 27, 47, 976, DateTimeKind.Local).AddTicks(7148), new DateTime(2022, 11, 27, 10, 15, 55, 274, DateTimeKind.Local).AddTicks(7969), 17, 1389709067, null },
                    { 384, 70, new DateTime(2022, 12, 31, 19, 33, 56, 341, DateTimeKind.Local).AddTicks(3295), new DateTime(2023, 2, 15, 7, 30, 21, 494, DateTimeKind.Local).AddTicks(4364), 80, -1196567979, null },
                    { 385, 87, new DateTime(2022, 8, 20, 10, 25, 17, 42, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 10, 16, 6, 23, 27, 802, DateTimeKind.Local).AddTicks(8286), 40, -648613442, null },
                    { 386, 56, new DateTime(2022, 12, 5, 4, 50, 33, 31, DateTimeKind.Local).AddTicks(8176), new DateTime(2022, 11, 2, 18, 37, 5, 678, DateTimeKind.Local).AddTicks(5993), 35, -1988380308, null },
                    { 387, 58, new DateTime(2022, 6, 10, 17, 19, 32, 867, DateTimeKind.Local).AddTicks(3837), new DateTime(2022, 5, 29, 9, 16, 37, 929, DateTimeKind.Local).AddTicks(3399), 66, 1984725414, null },
                    { 388, 36, new DateTime(2022, 5, 2, 9, 0, 27, 166, DateTimeKind.Local).AddTicks(9133), new DateTime(2022, 9, 9, 5, 43, 18, 758, DateTimeKind.Local).AddTicks(9276), 94, -143064617, null },
                    { 389, 91, new DateTime(2022, 12, 6, 22, 16, 25, 320, DateTimeKind.Local).AddTicks(6480), new DateTime(2022, 5, 18, 15, 43, 10, 689, DateTimeKind.Local).AddTicks(9758), 66, -1988838218, null },
                    { 390, 144, new DateTime(2022, 7, 12, 0, 13, 44, 847, DateTimeKind.Local).AddTicks(9898), new DateTime(2022, 6, 16, 23, 10, 47, 19, DateTimeKind.Local).AddTicks(7570), 3, 153281826, null },
                    { 391, 42, new DateTime(2023, 4, 6, 7, 12, 52, 111, DateTimeKind.Local).AddTicks(4821), new DateTime(2022, 5, 24, 2, 45, 10, 577, DateTimeKind.Local).AddTicks(7526), 89, -819823038, null },
                    { 392, 75, new DateTime(2022, 9, 8, 12, 59, 49, 666, DateTimeKind.Local).AddTicks(4513), new DateTime(2022, 6, 21, 6, 13, 16, 13, DateTimeKind.Local).AddTicks(1159), 69, 975494098, null },
                    { 393, 26, new DateTime(2022, 6, 2, 20, 45, 7, 623, DateTimeKind.Local).AddTicks(1038), new DateTime(2023, 1, 5, 10, 12, 16, 792, DateTimeKind.Local).AddTicks(8725), 5, 1648954083, null },
                    { 394, 138, new DateTime(2022, 6, 30, 14, 23, 14, 521, DateTimeKind.Local).AddTicks(234), new DateTime(2022, 11, 24, 13, 53, 50, 699, DateTimeKind.Local).AddTicks(6103), 71, 1102383972, null },
                    { 395, 124, new DateTime(2022, 4, 24, 9, 32, 36, 564, DateTimeKind.Local).AddTicks(621), new DateTime(2022, 7, 16, 17, 2, 35, 949, DateTimeKind.Local).AddTicks(8759), 23, -1239895739, null },
                    { 396, 48, new DateTime(2022, 7, 15, 20, 42, 32, 76, DateTimeKind.Local).AddTicks(1340), new DateTime(2022, 5, 17, 15, 49, 42, 867, DateTimeKind.Local).AddTicks(7813), 44, -1219221106, null },
                    { 397, 67, new DateTime(2022, 7, 24, 7, 17, 20, 706, DateTimeKind.Local).AddTicks(5730), new DateTime(2023, 2, 7, 3, 57, 15, 413, DateTimeKind.Local).AddTicks(7691), 39, 263467312, null },
                    { 398, 57, new DateTime(2023, 2, 25, 12, 21, 42, 286, DateTimeKind.Local).AddTicks(9919), new DateTime(2022, 11, 12, 0, 14, 27, 707, DateTimeKind.Local).AddTicks(1122), 11, 607050158, null },
                    { 399, 124, new DateTime(2022, 9, 5, 0, 45, 56, 771, DateTimeKind.Local).AddTicks(1426), new DateTime(2023, 3, 25, 6, 45, 12, 829, DateTimeKind.Local).AddTicks(3676), 81, -892979352, null },
                    { 400, 70, new DateTime(2022, 7, 11, 22, 19, 46, 719, DateTimeKind.Local).AddTicks(1316), new DateTime(2023, 2, 21, 10, 1, 54, 34, DateTimeKind.Local).AddTicks(2838), 34, -854060215, null },
                    { 401, 5, new DateTime(2022, 6, 14, 20, 43, 17, 145, DateTimeKind.Local).AddTicks(7855), new DateTime(2022, 7, 12, 20, 37, 12, 624, DateTimeKind.Local).AddTicks(2866), 78, 1472979132, null },
                    { 402, 102, new DateTime(2022, 5, 25, 21, 2, 12, 609, DateTimeKind.Local).AddTicks(3529), new DateTime(2022, 7, 22, 18, 28, 38, 435, DateTimeKind.Local).AddTicks(3883), 37, 1434411651, null },
                    { 403, 145, new DateTime(2022, 8, 7, 22, 43, 10, 838, DateTimeKind.Local).AddTicks(6976), new DateTime(2023, 2, 3, 23, 14, 13, 49, DateTimeKind.Local).AddTicks(6803), 81, -1329756672, null },
                    { 404, 2, new DateTime(2022, 11, 23, 4, 12, 7, 414, DateTimeKind.Local).AddTicks(6573), new DateTime(2022, 9, 22, 7, 9, 42, 319, DateTimeKind.Local).AddTicks(2114), 98, -618488105, null },
                    { 405, 17, new DateTime(2022, 10, 13, 5, 24, 9, 612, DateTimeKind.Local).AddTicks(1783), new DateTime(2023, 1, 20, 1, 20, 56, 251, DateTimeKind.Local).AddTicks(6568), 52, 510190642, null },
                    { 406, 63, new DateTime(2022, 7, 28, 0, 42, 19, 810, DateTimeKind.Local).AddTicks(6706), new DateTime(2022, 8, 18, 0, 30, 41, 642, DateTimeKind.Local).AddTicks(1782), 77, 1205386227, null },
                    { 407, 67, new DateTime(2022, 10, 26, 10, 24, 26, 300, DateTimeKind.Local).AddTicks(1829), new DateTime(2022, 5, 30, 13, 14, 42, 636, DateTimeKind.Local).AddTicks(9687), 3, -1180333227, null },
                    { 408, 111, new DateTime(2023, 3, 26, 2, 29, 46, 997, DateTimeKind.Local).AddTicks(3116), new DateTime(2022, 7, 16, 6, 42, 43, 907, DateTimeKind.Local).AddTicks(1933), 30, 1615586500, null },
                    { 409, 125, new DateTime(2022, 4, 26, 13, 57, 43, 815, DateTimeKind.Local).AddTicks(4079), new DateTime(2022, 11, 20, 23, 40, 29, 260, DateTimeKind.Local).AddTicks(8133), 6, 1862418384, null },
                    { 410, 149, new DateTime(2022, 9, 27, 9, 2, 11, 835, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 8, 2, 14, 20, 57, 101, DateTimeKind.Local).AddTicks(5160), 48, 479285873, null },
                    { 411, 150, new DateTime(2022, 11, 26, 21, 55, 6, 930, DateTimeKind.Local).AddTicks(5106), new DateTime(2023, 2, 28, 12, 56, 28, 91, DateTimeKind.Local).AddTicks(3914), 55, -1881419090, null },
                    { 412, 142, new DateTime(2022, 11, 3, 2, 20, 38, 101, DateTimeKind.Local).AddTicks(9230), new DateTime(2022, 7, 3, 8, 24, 48, 104, DateTimeKind.Local).AddTicks(5606), 69, 1628969604, null },
                    { 413, 8, new DateTime(2022, 9, 29, 19, 27, 55, 605, DateTimeKind.Local).AddTicks(2864), new DateTime(2023, 1, 28, 11, 49, 0, 968, DateTimeKind.Local).AddTicks(5843), 43, 2043538961, null },
                    { 414, 79, new DateTime(2022, 11, 27, 8, 44, 46, 207, DateTimeKind.Local).AddTicks(9421), new DateTime(2022, 12, 7, 9, 50, 24, 391, DateTimeKind.Local).AddTicks(7736), 96, 1871213227, null },
                    { 415, 27, new DateTime(2022, 7, 23, 13, 57, 56, 635, DateTimeKind.Local).AddTicks(2615), new DateTime(2022, 5, 18, 2, 4, 57, 626, DateTimeKind.Local).AddTicks(5613), 31, -1662231306, null },
                    { 416, 2, new DateTime(2022, 11, 8, 3, 8, 26, 53, DateTimeKind.Local).AddTicks(7845), new DateTime(2023, 3, 24, 14, 12, 13, 301, DateTimeKind.Local).AddTicks(5884), 21, 1115960737, null },
                    { 417, 141, new DateTime(2023, 2, 24, 18, 3, 20, 591, DateTimeKind.Local).AddTicks(1345), new DateTime(2023, 2, 24, 14, 11, 13, 585, DateTimeKind.Local).AddTicks(3978), 91, 1154325977, null },
                    { 418, 150, new DateTime(2023, 3, 13, 21, 48, 57, 732, DateTimeKind.Local).AddTicks(6022), new DateTime(2022, 10, 9, 3, 0, 4, 282, DateTimeKind.Local).AddTicks(2179), 4, -485073646, null },
                    { 419, 121, new DateTime(2022, 8, 7, 19, 50, 33, 133, DateTimeKind.Local).AddTicks(2763), new DateTime(2022, 7, 12, 4, 16, 32, 65, DateTimeKind.Local).AddTicks(1422), 56, 1587009180, null },
                    { 420, 89, new DateTime(2022, 4, 24, 3, 35, 0, 319, DateTimeKind.Local).AddTicks(5747), new DateTime(2023, 3, 17, 9, 19, 53, 261, DateTimeKind.Local).AddTicks(7003), 3, 420745563, null },
                    { 421, 103, new DateTime(2022, 10, 31, 14, 24, 13, 519, DateTimeKind.Local).AddTicks(925), new DateTime(2023, 1, 17, 13, 32, 4, 439, DateTimeKind.Local).AddTicks(6645), 99, -894213817, null },
                    { 422, 127, new DateTime(2022, 6, 28, 18, 13, 24, 555, DateTimeKind.Local).AddTicks(3567), new DateTime(2022, 10, 7, 0, 0, 8, 501, DateTimeKind.Local).AddTicks(646), 19, 1230480585, null },
                    { 423, 93, new DateTime(2023, 3, 11, 21, 28, 25, 707, DateTimeKind.Local).AddTicks(2650), new DateTime(2022, 12, 31, 4, 56, 15, 592, DateTimeKind.Local).AddTicks(9966), 45, -966013606, null },
                    { 424, 96, new DateTime(2022, 10, 15, 10, 9, 6, 517, DateTimeKind.Local).AddTicks(7056), new DateTime(2022, 10, 5, 13, 30, 59, 655, DateTimeKind.Local).AddTicks(9923), 26, 2100200555, null },
                    { 425, 49, new DateTime(2023, 1, 23, 15, 15, 33, 957, DateTimeKind.Local).AddTicks(7113), new DateTime(2022, 7, 20, 20, 43, 20, 901, DateTimeKind.Local).AddTicks(966), 56, 1067159801, null },
                    { 426, 47, new DateTime(2022, 7, 15, 23, 23, 16, 511, DateTimeKind.Local).AddTicks(8994), new DateTime(2022, 11, 13, 10, 6, 57, 474, DateTimeKind.Local).AddTicks(308), 80, -867040648, null },
                    { 427, 4, new DateTime(2022, 8, 19, 13, 39, 57, 50, DateTimeKind.Local).AddTicks(1441), new DateTime(2023, 2, 23, 13, 14, 13, 351, DateTimeKind.Local).AddTicks(1743), 95, 1216378342, null },
                    { 428, 94, new DateTime(2022, 12, 16, 6, 54, 50, 559, DateTimeKind.Local).AddTicks(6442), new DateTime(2022, 8, 1, 6, 14, 18, 344, DateTimeKind.Local).AddTicks(2703), 84, 1273826107, null },
                    { 429, 98, new DateTime(2022, 5, 13, 16, 6, 49, 302, DateTimeKind.Local).AddTicks(5337), new DateTime(2022, 10, 11, 18, 0, 18, 898, DateTimeKind.Local).AddTicks(1906), 20, -502543399, null },
                    { 430, 29, new DateTime(2022, 5, 30, 10, 14, 0, 705, DateTimeKind.Local).AddTicks(2545), new DateTime(2023, 3, 28, 22, 48, 14, 614, DateTimeKind.Local).AddTicks(9561), 55, -1268741071, null },
                    { 431, 93, new DateTime(2022, 8, 4, 7, 37, 10, 753, DateTimeKind.Local).AddTicks(5959), new DateTime(2022, 11, 16, 20, 42, 18, 679, DateTimeKind.Local).AddTicks(316), 14, 958030451, null },
                    { 432, 121, new DateTime(2023, 1, 10, 1, 4, 34, 955, DateTimeKind.Local).AddTicks(6650), new DateTime(2022, 5, 18, 6, 59, 56, 219, DateTimeKind.Local).AddTicks(7903), 90, 1062552995, null },
                    { 433, 25, new DateTime(2023, 1, 30, 2, 48, 9, 337, DateTimeKind.Local).AddTicks(7737), new DateTime(2022, 8, 5, 11, 0, 46, 713, DateTimeKind.Local).AddTicks(2144), 30, -508265018, null },
                    { 434, 37, new DateTime(2023, 1, 1, 22, 27, 38, 105, DateTimeKind.Local).AddTicks(5579), new DateTime(2022, 8, 14, 13, 36, 50, 317, DateTimeKind.Local).AddTicks(5149), 36, 1829384341, null },
                    { 435, 6, new DateTime(2022, 12, 30, 1, 56, 41, 210, DateTimeKind.Local).AddTicks(3731), new DateTime(2023, 2, 20, 3, 18, 27, 783, DateTimeKind.Local).AddTicks(2794), 93, -2126073125, null },
                    { 436, 99, new DateTime(2022, 8, 6, 7, 3, 44, 656, DateTimeKind.Local).AddTicks(9026), new DateTime(2022, 6, 23, 17, 53, 55, 199, DateTimeKind.Local).AddTicks(173), 19, -534043788, null },
                    { 437, 59, new DateTime(2023, 3, 10, 20, 30, 33, 898, DateTimeKind.Local).AddTicks(9991), new DateTime(2022, 9, 9, 13, 5, 32, 463, DateTimeKind.Local).AddTicks(83), 28, -1930480861, null },
                    { 438, 149, new DateTime(2022, 4, 24, 4, 19, 36, 692, DateTimeKind.Local).AddTicks(7344), new DateTime(2022, 12, 8, 3, 40, 7, 623, DateTimeKind.Local).AddTicks(2661), 71, -2053026252, null },
                    { 439, 27, new DateTime(2022, 9, 7, 7, 8, 12, 14, DateTimeKind.Local).AddTicks(9816), new DateTime(2023, 2, 11, 8, 37, 9, 576, DateTimeKind.Local).AddTicks(955), 44, 1259724578, null },
                    { 440, 51, new DateTime(2022, 10, 4, 11, 15, 38, 517, DateTimeKind.Local).AddTicks(4831), new DateTime(2023, 2, 23, 10, 30, 47, 599, DateTimeKind.Local).AddTicks(7101), 61, 838456024, null },
                    { 441, 112, new DateTime(2022, 6, 11, 16, 32, 0, 848, DateTimeKind.Local).AddTicks(2476), new DateTime(2022, 8, 17, 2, 24, 56, 876, DateTimeKind.Local).AddTicks(9036), 76, 739217522, null },
                    { 442, 96, new DateTime(2022, 12, 9, 17, 55, 54, 72, DateTimeKind.Local).AddTicks(7312), new DateTime(2022, 5, 6, 17, 22, 8, 785, DateTimeKind.Local).AddTicks(5464), 41, 587669504, null },
                    { 443, 39, new DateTime(2022, 9, 14, 23, 35, 50, 704, DateTimeKind.Local).AddTicks(4953), new DateTime(2022, 10, 12, 20, 42, 13, 428, DateTimeKind.Local).AddTicks(2246), 36, -767424647, null },
                    { 444, 110, new DateTime(2022, 6, 3, 5, 59, 19, 126, DateTimeKind.Local).AddTicks(3993), new DateTime(2022, 10, 27, 0, 24, 4, 191, DateTimeKind.Local).AddTicks(9622), 90, 2010489509, null },
                    { 445, 133, new DateTime(2023, 2, 26, 7, 41, 43, 305, DateTimeKind.Local).AddTicks(666), new DateTime(2022, 10, 17, 23, 25, 18, 103, DateTimeKind.Local).AddTicks(5841), 92, -282604208, null },
                    { 446, 100, new DateTime(2023, 1, 31, 0, 21, 24, 803, DateTimeKind.Local).AddTicks(6919), new DateTime(2022, 12, 27, 20, 21, 31, 393, DateTimeKind.Local).AddTicks(4440), 70, -1526596243, null },
                    { 447, 129, new DateTime(2023, 1, 11, 21, 43, 47, 279, DateTimeKind.Local).AddTicks(5695), new DateTime(2023, 2, 11, 11, 39, 11, 438, DateTimeKind.Local).AddTicks(8175), 18, 212123107, null },
                    { 448, 17, new DateTime(2023, 3, 23, 17, 16, 30, 44, DateTimeKind.Local).AddTicks(6028), new DateTime(2022, 9, 16, 7, 31, 36, 870, DateTimeKind.Local).AddTicks(8624), 63, -1413181652, null },
                    { 449, 23, new DateTime(2022, 11, 22, 20, 7, 4, 905, DateTimeKind.Local).AddTicks(8918), new DateTime(2022, 11, 10, 1, 57, 1, 168, DateTimeKind.Local).AddTicks(2392), 50, -1853302049, null },
                    { 450, 5, new DateTime(2022, 11, 19, 0, 25, 43, 884, DateTimeKind.Local).AddTicks(57), new DateTime(2022, 8, 27, 8, 54, 38, 37, DateTimeKind.Local).AddTicks(5726), 81, -1409766138, null },
                    { 451, 24, new DateTime(2023, 1, 17, 15, 7, 0, 685, DateTimeKind.Local).AddTicks(143), new DateTime(2022, 11, 4, 19, 56, 38, 941, DateTimeKind.Local).AddTicks(1142), 4, -2028385334, null },
                    { 452, 71, new DateTime(2022, 10, 30, 0, 12, 20, 709, DateTimeKind.Local).AddTicks(5271), new DateTime(2022, 8, 2, 22, 9, 33, 21, DateTimeKind.Local).AddTicks(7055), 40, 986932590, null },
                    { 453, 21, new DateTime(2023, 1, 11, 5, 49, 35, 632, DateTimeKind.Local).AddTicks(9347), new DateTime(2022, 7, 29, 22, 25, 11, 228, DateTimeKind.Local).AddTicks(3665), 31, -1008215490, null },
                    { 454, 6, new DateTime(2022, 11, 3, 22, 20, 32, 849, DateTimeKind.Local).AddTicks(1088), new DateTime(2023, 3, 16, 11, 0, 26, 894, DateTimeKind.Local).AddTicks(7649), 20, 739975511, null },
                    { 455, 82, new DateTime(2022, 10, 20, 8, 36, 53, 582, DateTimeKind.Local).AddTicks(3580), new DateTime(2022, 9, 29, 10, 8, 16, 110, DateTimeKind.Local).AddTicks(5392), 54, 2041231168, null },
                    { 456, 27, new DateTime(2022, 12, 22, 1, 50, 34, 872, DateTimeKind.Local).AddTicks(526), new DateTime(2023, 1, 18, 23, 56, 9, 758, DateTimeKind.Local).AddTicks(5723), 38, -1606492392, null },
                    { 457, 1, new DateTime(2023, 4, 12, 11, 52, 29, 390, DateTimeKind.Local).AddTicks(6476), new DateTime(2022, 7, 22, 3, 49, 59, 813, DateTimeKind.Local).AddTicks(1181), 19, 25451666, null },
                    { 458, 66, new DateTime(2022, 8, 16, 20, 8, 47, 326, DateTimeKind.Local).AddTicks(275), new DateTime(2022, 5, 30, 13, 56, 52, 673, DateTimeKind.Local).AddTicks(2049), 33, -208360385, null },
                    { 459, 75, new DateTime(2022, 10, 30, 10, 18, 58, 303, DateTimeKind.Local).AddTicks(3192), new DateTime(2022, 10, 4, 0, 49, 56, 147, DateTimeKind.Local).AddTicks(1929), 48, -725407836, null },
                    { 460, 115, new DateTime(2022, 5, 22, 12, 0, 27, 968, DateTimeKind.Local).AddTicks(4218), new DateTime(2022, 8, 4, 1, 58, 46, 540, DateTimeKind.Local).AddTicks(813), 42, 335224913, null },
                    { 461, 84, new DateTime(2022, 6, 1, 9, 23, 4, 712, DateTimeKind.Local).AddTicks(4576), new DateTime(2022, 10, 21, 0, 35, 32, 600, DateTimeKind.Local).AddTicks(5211), 39, -1890193421, null },
                    { 462, 53, new DateTime(2022, 11, 27, 20, 44, 15, 833, DateTimeKind.Local).AddTicks(560), new DateTime(2022, 11, 1, 12, 47, 30, 133, DateTimeKind.Local).AddTicks(7258), 85, 1820965405, null },
                    { 463, 47, new DateTime(2022, 5, 23, 3, 50, 18, 631, DateTimeKind.Local).AddTicks(5708), new DateTime(2023, 1, 13, 23, 52, 53, 921, DateTimeKind.Local).AddTicks(1801), 70, 794107859, null },
                    { 464, 130, new DateTime(2023, 1, 9, 18, 56, 14, 960, DateTimeKind.Local).AddTicks(7047), new DateTime(2022, 6, 8, 22, 37, 43, 676, DateTimeKind.Local).AddTicks(4015), 54, 867673041, null },
                    { 465, 1, new DateTime(2023, 1, 10, 18, 55, 3, 490, DateTimeKind.Local).AddTicks(6852), new DateTime(2022, 11, 25, 8, 4, 56, 101, DateTimeKind.Local).AddTicks(4408), 84, 1473026558, null },
                    { 466, 109, new DateTime(2022, 11, 29, 19, 32, 58, 495, DateTimeKind.Local).AddTicks(6078), new DateTime(2022, 6, 7, 14, 1, 55, 278, DateTimeKind.Local).AddTicks(2525), 46, -1612792282, null },
                    { 467, 58, new DateTime(2023, 1, 18, 17, 19, 33, 47, DateTimeKind.Local).AddTicks(7781), new DateTime(2022, 8, 6, 3, 48, 22, 280, DateTimeKind.Local).AddTicks(3665), 47, -1340888732, null },
                    { 468, 138, new DateTime(2022, 8, 14, 22, 20, 18, 577, DateTimeKind.Local).AddTicks(1056), new DateTime(2022, 7, 11, 9, 30, 3, 184, DateTimeKind.Local).AddTicks(1461), 58, 74861701, null },
                    { 469, 119, new DateTime(2023, 2, 17, 19, 24, 28, 595, DateTimeKind.Local).AddTicks(5448), new DateTime(2022, 6, 25, 6, 12, 15, 329, DateTimeKind.Local).AddTicks(651), 64, -1093880108, null },
                    { 470, 125, new DateTime(2022, 11, 23, 0, 7, 10, 352, DateTimeKind.Local).AddTicks(338), new DateTime(2022, 6, 18, 21, 58, 23, 144, DateTimeKind.Local).AddTicks(2551), 30, 440446954, null },
                    { 471, 84, new DateTime(2023, 4, 2, 18, 56, 32, 541, DateTimeKind.Local).AddTicks(5518), new DateTime(2023, 4, 13, 9, 18, 3, 25, DateTimeKind.Local).AddTicks(345), 62, 462134907, null },
                    { 472, 62, new DateTime(2022, 12, 12, 2, 6, 51, 965, DateTimeKind.Local).AddTicks(5506), new DateTime(2022, 9, 7, 6, 36, 16, 917, DateTimeKind.Local).AddTicks(1869), 54, 1844687276, null },
                    { 473, 92, new DateTime(2022, 8, 4, 7, 43, 59, 395, DateTimeKind.Local).AddTicks(7783), new DateTime(2022, 11, 19, 13, 17, 23, 901, DateTimeKind.Local).AddTicks(2836), 23, 3957728, null },
                    { 474, 77, new DateTime(2023, 1, 16, 14, 25, 46, 156, DateTimeKind.Local).AddTicks(2034), new DateTime(2022, 8, 20, 10, 9, 33, 128, DateTimeKind.Local).AddTicks(6573), 50, -1937994051, null },
                    { 475, 3, new DateTime(2023, 4, 8, 22, 12, 5, 593, DateTimeKind.Local).AddTicks(5123), new DateTime(2022, 10, 31, 23, 44, 22, 956, DateTimeKind.Local).AddTicks(8820), 18, 1199013541, null },
                    { 476, 104, new DateTime(2022, 5, 28, 19, 28, 1, 513, DateTimeKind.Local).AddTicks(1278), new DateTime(2022, 7, 7, 3, 10, 57, 79, DateTimeKind.Local).AddTicks(7249), 11, -1641198666, null },
                    { 477, 21, new DateTime(2022, 9, 3, 23, 54, 45, 924, DateTimeKind.Local).AddTicks(7788), new DateTime(2022, 7, 19, 21, 0, 0, 175, DateTimeKind.Local).AddTicks(4536), 64, 2053636929, null },
                    { 478, 69, new DateTime(2022, 9, 24, 9, 55, 59, 244, DateTimeKind.Local).AddTicks(9249), new DateTime(2023, 4, 17, 7, 39, 0, 989, DateTimeKind.Local).AddTicks(9603), 70, -1388425295, null },
                    { 479, 66, new DateTime(2022, 7, 7, 20, 56, 51, 590, DateTimeKind.Local).AddTicks(8418), new DateTime(2022, 5, 26, 4, 16, 7, 637, DateTimeKind.Local).AddTicks(348), 61, 1804278755, null },
                    { 480, 56, new DateTime(2022, 12, 18, 22, 1, 49, 441, DateTimeKind.Local).AddTicks(6400), new DateTime(2023, 3, 29, 21, 55, 40, 112, DateTimeKind.Local).AddTicks(2412), 69, 1978338886, null },
                    { 481, 96, new DateTime(2022, 10, 28, 8, 9, 25, 463, DateTimeKind.Local).AddTicks(5527), new DateTime(2022, 5, 1, 21, 26, 20, 503, DateTimeKind.Local).AddTicks(7614), 4, -1751673246, null },
                    { 482, 40, new DateTime(2023, 1, 7, 8, 12, 14, 302, DateTimeKind.Local).AddTicks(2279), new DateTime(2023, 3, 3, 11, 50, 42, 639, DateTimeKind.Local).AddTicks(5025), 22, 1361527434, null },
                    { 483, 76, new DateTime(2022, 8, 27, 10, 22, 53, 56, DateTimeKind.Local).AddTicks(7779), new DateTime(2023, 1, 7, 9, 8, 41, 507, DateTimeKind.Local).AddTicks(3549), 54, 617380905, null },
                    { 484, 141, new DateTime(2022, 7, 27, 4, 38, 30, 865, DateTimeKind.Local).AddTicks(7644), new DateTime(2022, 5, 15, 10, 0, 17, 467, DateTimeKind.Local).AddTicks(9939), 81, 1569202460, null },
                    { 485, 40, new DateTime(2022, 12, 1, 6, 43, 37, 80, DateTimeKind.Local).AddTicks(9795), new DateTime(2022, 11, 24, 13, 27, 56, 899, DateTimeKind.Local).AddTicks(2738), 67, -129947840, null },
                    { 486, 91, new DateTime(2022, 5, 19, 19, 55, 11, 229, DateTimeKind.Local).AddTicks(2260), new DateTime(2022, 7, 10, 22, 43, 3, 695, DateTimeKind.Local).AddTicks(2572), 80, 234203833, null },
                    { 487, 106, new DateTime(2022, 6, 27, 6, 25, 36, 816, DateTimeKind.Local).AddTicks(8348), new DateTime(2023, 3, 28, 20, 9, 15, 45, DateTimeKind.Local).AddTicks(5724), 5, -1918278192, null },
                    { 488, 54, new DateTime(2022, 4, 26, 16, 55, 38, 263, DateTimeKind.Local).AddTicks(7580), new DateTime(2022, 6, 29, 1, 22, 33, 311, DateTimeKind.Local).AddTicks(7950), 74, 1670383190, null },
                    { 489, 146, new DateTime(2022, 11, 12, 18, 10, 25, 452, DateTimeKind.Local).AddTicks(6594), new DateTime(2022, 10, 28, 22, 24, 42, 657, DateTimeKind.Local).AddTicks(9817), 69, -468713108, null },
                    { 490, 139, new DateTime(2022, 9, 21, 21, 36, 13, 263, DateTimeKind.Local).AddTicks(5428), new DateTime(2022, 12, 4, 9, 19, 37, 778, DateTimeKind.Local).AddTicks(3166), 22, 221268657, null },
                    { 491, 75, new DateTime(2023, 1, 31, 12, 59, 32, 779, DateTimeKind.Local).AddTicks(3343), new DateTime(2023, 2, 6, 17, 14, 16, 731, DateTimeKind.Local).AddTicks(1622), 86, -301856935, null },
                    { 492, 44, new DateTime(2023, 2, 4, 12, 47, 57, 801, DateTimeKind.Local).AddTicks(8938), new DateTime(2022, 8, 19, 22, 17, 6, 199, DateTimeKind.Local).AddTicks(3870), 82, -1246426554, null },
                    { 493, 129, new DateTime(2023, 1, 24, 8, 51, 3, 383, DateTimeKind.Local).AddTicks(1926), new DateTime(2022, 11, 15, 17, 16, 25, 913, DateTimeKind.Local).AddTicks(1637), 71, 393209188, null },
                    { 494, 140, new DateTime(2023, 1, 12, 9, 46, 26, 122, DateTimeKind.Local).AddTicks(1229), new DateTime(2022, 11, 12, 16, 15, 12, 224, DateTimeKind.Local).AddTicks(2180), 99, -418915747, null },
                    { 495, 106, new DateTime(2022, 5, 17, 3, 52, 58, 611, DateTimeKind.Local).AddTicks(7175), new DateTime(2022, 10, 14, 21, 17, 51, 920, DateTimeKind.Local).AddTicks(4581), 72, 224629422, null },
                    { 496, 34, new DateTime(2022, 11, 25, 13, 3, 55, 853, DateTimeKind.Local).AddTicks(3111), new DateTime(2023, 2, 11, 13, 38, 55, 387, DateTimeKind.Local).AddTicks(461), 46, 1796513826, null },
                    { 497, 126, new DateTime(2022, 9, 14, 20, 1, 15, 4, DateTimeKind.Local).AddTicks(7362), new DateTime(2022, 6, 19, 10, 22, 44, 216, DateTimeKind.Local).AddTicks(8922), 53, 536364970, null },
                    { 498, 39, new DateTime(2022, 8, 2, 9, 25, 42, 868, DateTimeKind.Local).AddTicks(8025), new DateTime(2022, 7, 22, 13, 11, 29, 754, DateTimeKind.Local).AddTicks(5737), 51, -1469266723, null },
                    { 499, 2, new DateTime(2022, 10, 3, 11, 31, 49, 244, DateTimeKind.Local).AddTicks(211), new DateTime(2022, 12, 31, 15, 53, 17, 214, DateTimeKind.Local).AddTicks(9412), 69, -440980971, null },
                    { 500, 109, new DateTime(2022, 5, 4, 4, 33, 50, 610, DateTimeKind.Local).AddTicks(3343), new DateTime(2022, 7, 17, 8, 34, 10, 664, DateTimeKind.Local).AddTicks(5744), 40, -1549907730, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 21, 27, 54, 43, DateTimeKind.Local).AddTicks(3568), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 448, DateTimeKind.Local).AddTicks(9667), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 17, 21, 27, 54, 46, DateTimeKind.Local).AddTicks(2237), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 451, DateTimeKind.Local).AddTicks(8322), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 17, 21, 27, 54, 49, DateTimeKind.Local).AddTicks(6242), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 455, DateTimeKind.Local).AddTicks(2340), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 17, 21, 27, 54, 52, DateTimeKind.Local).AddTicks(2593), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 457, DateTimeKind.Local).AddTicks(9015), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 17, 21, 27, 54, 54, DateTimeKind.Local).AddTicks(9570), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 460, DateTimeKind.Local).AddTicks(5669), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 17, 21, 27, 54, 57, DateTimeKind.Local).AddTicks(4621), "Metal_Chicken.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 463, DateTimeKind.Local).AddTicks(701), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 17, 21, 27, 54, 59, DateTimeKind.Local).AddTicks(7976), "Metal_Shoes.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 465, DateTimeKind.Local).AddTicks(4046), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 17, 21, 27, 54, 61, DateTimeKind.Local).AddTicks(9734), "Metal_Shoes2.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 467, DateTimeKind.Local).AddTicks(5817), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 17, 21, 27, 54, 64, DateTimeKind.Local).AddTicks(2704), "Steel_Computer.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 469, DateTimeKind.Local).AddTicks(8783), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 17, 21, 27, 54, 66, DateTimeKind.Local).AddTicks(4711), "Cotton_Cheese.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 472, DateTimeKind.Local).AddTicks(774), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 17, 21, 27, 54, 68, DateTimeKind.Local).AddTicks(9127), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 474, DateTimeKind.Local).AddTicks(5230), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 17, 21, 27, 54, 71, DateTimeKind.Local).AddTicks(6894), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 477, DateTimeKind.Local).AddTicks(2986), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 17, 21, 27, 54, 74, DateTimeKind.Local).AddTicks(3889), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 9, 5, 41, 4, 480, DateTimeKind.Local).AddTicks(140), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 5, 41, 4, 434, DateTimeKind.Local).AddTicks(394), null, 1, new DateTime(2022, 10, 30, 4, 47, 17, 698, DateTimeKind.Local).AddTicks(8), "Computers" },
                    { 2, new DateTime(2022, 8, 21, 15, 56, 10, 664, DateTimeKind.Local).AddTicks(151), null, 2, new DateTime(2022, 11, 11, 16, 37, 34, 383, DateTimeKind.Local).AddTicks(8382), "Shoes" },
                    { 3, new DateTime(2022, 5, 9, 3, 34, 5, 758, DateTimeKind.Local).AddTicks(5698), null, 3, new DateTime(2023, 3, 12, 16, 42, 27, 619, DateTimeKind.Local).AddTicks(1438), "Garden" },
                    { 4, new DateTime(2023, 4, 8, 4, 56, 35, 972, DateTimeKind.Local).AddTicks(8017), null, 4, new DateTime(2023, 1, 18, 3, 3, 59, 365, DateTimeKind.Local).AddTicks(1100), "Baby" },
                    { 5, new DateTime(2022, 4, 22, 9, 26, 29, 728, DateTimeKind.Local).AddTicks(9499), null, 5, new DateTime(2022, 8, 12, 16, 24, 11, 821, DateTimeKind.Local).AddTicks(9918), "Garden" },
                    { 6, new DateTime(2023, 1, 5, 11, 5, 37, 691, DateTimeKind.Local).AddTicks(4215), null, 6, new DateTime(2022, 9, 6, 1, 22, 2, 167, DateTimeKind.Local).AddTicks(2699), "Baby" },
                    { 7, new DateTime(2022, 8, 5, 12, 3, 46, 542, DateTimeKind.Local).AddTicks(1850), null, 7, new DateTime(2022, 5, 6, 23, 44, 33, 396, DateTimeKind.Local).AddTicks(9005), "Clothing" },
                    { 8, new DateTime(2023, 2, 18, 22, 15, 17, 489, DateTimeKind.Local).AddTicks(8806), null, 8, new DateTime(2022, 11, 30, 5, 44, 6, 591, DateTimeKind.Local).AddTicks(9477), "Music" },
                    { 9, new DateTime(2023, 2, 15, 19, 16, 10, 358, DateTimeKind.Local).AddTicks(1076), null, 9, new DateTime(2022, 7, 2, 22, 15, 26, 173, DateTimeKind.Local).AddTicks(780), "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 8, 2 },
                    { 4, 3 },
                    { 2, 4 },
                    { 9, 5 },
                    { 2, 6 },
                    { 6, 7 },
                    { 4, 8 },
                    { 6, 9 },
                    { 3, 10 },
                    { 6, 11 },
                    { 3, 12 },
                    { 5, 13 },
                    { 7, 14 },
                    { 9, 15 },
                    { 6, 16 },
                    { 2, 17 },
                    { 8, 18 },
                    { 1, 19 },
                    { 7, 20 },
                    { 3, 21 },
                    { 9, 22 },
                    { 5, 23 },
                    { 1, 24 },
                    { 2, 25 },
                    { 4, 26 },
                    { 3, 27 },
                    { 3, 28 },
                    { 1, 29 },
                    { 3, 30 },
                    { 5, 31 },
                    { 3, 32 },
                    { 4, 33 },
                    { 3, 34 },
                    { 2, 35 },
                    { 1, 36 },
                    { 9, 37 },
                    { 3, 38 },
                    { 8, 39 },
                    { 8, 40 },
                    { 7, 41 },
                    { 4, 42 },
                    { 1, 43 },
                    { 5, 44 },
                    { 9, 45 },
                    { 4, 46 },
                    { 8, 47 },
                    { 6, 48 },
                    { 8, 49 },
                    { 3, 50 },
                    { 8, 51 },
                    { 5, 52 },
                    { 8, 53 },
                    { 2, 54 },
                    { 3, 55 },
                    { 1, 56 },
                    { 9, 57 },
                    { 6, 58 },
                    { 5, 59 },
                    { 6, 60 },
                    { 6, 61 },
                    { 5, 62 },
                    { 3, 63 },
                    { 2, 64 },
                    { 6, 65 },
                    { 7, 66 },
                    { 7, 67 },
                    { 7, 68 },
                    { 7, 69 },
                    { 3, 70 },
                    { 7, 71 },
                    { 3, 72 },
                    { 2, 73 },
                    { 7, 74 },
                    { 4, 75 },
                    { 4, 76 },
                    { 5, 77 },
                    { 1, 78 },
                    { 2, 79 },
                    { 1, 80 },
                    { 5, 81 },
                    { 7, 82 },
                    { 2, 83 },
                    { 6, 84 },
                    { 7, 85 },
                    { 9, 86 },
                    { 8, 87 },
                    { 1, 88 },
                    { 2, 89 },
                    { 1, 90 },
                    { 3, 91 },
                    { 6, 92 },
                    { 8, 93 },
                    { 8, 94 },
                    { 3, 95 },
                    { 8, 96 },
                    { 1, 97 },
                    { 9, 98 },
                    { 4, 99 },
                    { 6, 100 }
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
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

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
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentProvider");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
