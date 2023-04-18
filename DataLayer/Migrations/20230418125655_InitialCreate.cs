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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "c0d85480-6a1d-4882-88f6-d8408ff36b23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", false, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "1234567890", false, "ca402c2f-e7f2-4768-800f-0866a2708bc8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "BillingAddressId", "CreateDate", "ModifiedDate", "PaymentProviderId", "ShippingAddressId", "Total", "UserId", "state" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 17, 20, 36, 42, 497, DateTimeKind.Local).AddTicks(1525), new DateTime(2023, 3, 9, 4, 49, 52, 902, DateTimeKind.Local).AddTicks(7681), null, null, null, null, "draft" },
                    { 2, null, new DateTime(2022, 10, 30, 3, 56, 6, 166, DateTimeKind.Local).AddTicks(7047), new DateTime(2022, 7, 10, 23, 41, 47, 375, DateTimeKind.Local).AddTicks(711), null, null, null, null, "draft" },
                    { 3, null, new DateTime(2022, 8, 21, 15, 4, 59, 132, DateTimeKind.Local).AddTicks(7066), new DateTime(2022, 11, 11, 15, 46, 22, 852, DateTimeKind.Local).AddTicks(5293), null, null, null, null, "draft" },
                    { 4, null, new DateTime(2022, 12, 10, 9, 10, 29, 398, DateTimeKind.Local).AddTicks(2569), new DateTime(2022, 5, 9, 2, 42, 54, 227, DateTimeKind.Local).AddTicks(2603), null, null, null, null, "draft" },
                    { 5, null, new DateTime(2023, 3, 12, 15, 51, 16, 87, DateTimeKind.Local).AddTicks(8344), new DateTime(2022, 8, 27, 3, 2, 16, 574, DateTimeKind.Local).AddTicks(2059), null, null, null, null, "draft" },
                    { 6, null, new DateTime(2023, 4, 8, 4, 5, 24, 441, DateTimeKind.Local).AddTicks(4921), new DateTime(2023, 1, 18, 2, 12, 47, 833, DateTimeKind.Local).AddTicks(8002), null, null, null, null, "draft" },
                    { 7, null, new DateTime(2022, 12, 22, 18, 47, 1, 854, DateTimeKind.Local).AddTicks(8205), new DateTime(2022, 4, 22, 8, 35, 18, 197, DateTimeKind.Local).AddTicks(6400), null, null, null, null, "draft" },
                    { 8, null, new DateTime(2022, 8, 12, 15, 33, 0, 290, DateTimeKind.Local).AddTicks(6822), new DateTime(2022, 8, 22, 14, 7, 50, 562, DateTimeKind.Local).AddTicks(85), null, null, null, null, "draft" },
                    { 9, null, new DateTime(2023, 1, 5, 10, 14, 26, 160, DateTimeKind.Local).AddTicks(1116), new DateTime(2022, 9, 6, 0, 30, 50, 635, DateTimeKind.Local).AddTicks(9600), null, null, null, null, "draft" },
                    { 10, null, new DateTime(2022, 8, 4, 13, 42, 18, 541, DateTimeKind.Local).AddTicks(5924), new DateTime(2022, 8, 5, 11, 12, 35, 10, DateTimeKind.Local).AddTicks(8749), null, null, null, null, "draft" },
                    { 11, null, new DateTime(2022, 5, 6, 22, 53, 21, 865, DateTimeKind.Local).AddTicks(5907), new DateTime(2023, 3, 15, 12, 51, 55, 841, DateTimeKind.Local).AddTicks(5923), null, null, null, null, "draft" },
                    { 12, null, new DateTime(2023, 2, 18, 21, 24, 5, 958, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 11, 30, 4, 52, 55, 60, DateTimeKind.Local).AddTicks(6376), null, null, null, null, "draft" },
                    { 13, null, new DateTime(2022, 7, 1, 8, 55, 36, 386, DateTimeKind.Local).AddTicks(7732), new DateTime(2023, 2, 15, 18, 24, 58, 826, DateTimeKind.Local).AddTicks(7974), null, null, null, null, "draft" },
                    { 14, null, new DateTime(2022, 7, 2, 21, 24, 14, 641, DateTimeKind.Local).AddTicks(7681), new DateTime(2022, 12, 27, 11, 37, 45, 121, DateTimeKind.Local).AddTicks(4570), null, null, null, null, "draft" },
                    { 15, null, new DateTime(2022, 6, 22, 5, 13, 10, 390, DateTimeKind.Local).AddTicks(4799), new DateTime(2022, 5, 30, 1, 28, 31, 534, DateTimeKind.Local).AddTicks(8372), null, null, null, null, "draft" },
                    { 16, null, new DateTime(2022, 9, 27, 13, 44, 25, 135, DateTimeKind.Local).AddTicks(6404), new DateTime(2022, 7, 31, 0, 21, 31, 311, DateTimeKind.Local).AddTicks(8623), null, null, null, null, "draft" },
                    { 17, null, new DateTime(2022, 8, 6, 9, 7, 1, 603, DateTimeKind.Local).AddTicks(8611), new DateTime(2023, 4, 13, 15, 41, 11, 166, DateTimeKind.Local).AddTicks(2), null, null, null, null, "draft" },
                    { 18, null, new DateTime(2022, 4, 21, 14, 6, 50, 389, DateTimeKind.Local).AddTicks(1789), new DateTime(2022, 6, 28, 7, 44, 47, 556, DateTimeKind.Local).AddTicks(1103), null, null, null, null, "draft" },
                    { 19, null, new DateTime(2022, 6, 9, 4, 21, 16, 826, DateTimeKind.Local).AddTicks(4407), new DateTime(2023, 3, 26, 19, 25, 10, 114, DateTimeKind.Local).AddTicks(6797), null, null, null, null, "draft" },
                    { 20, null, new DateTime(2022, 10, 12, 20, 51, 33, 553, DateTimeKind.Local).AddTicks(2744), new DateTime(2022, 10, 8, 21, 41, 10, 976, DateTimeKind.Local).AddTicks(1930), null, null, null, null, "draft" },
                    { 21, null, new DateTime(2023, 1, 9, 1, 0, 0, 774, DateTimeKind.Local).AddTicks(1346), new DateTime(2022, 4, 20, 21, 17, 33, 274, DateTimeKind.Local).AddTicks(6492), null, null, null, null, "draft" },
                    { 22, null, new DateTime(2022, 8, 9, 8, 52, 25, 733, DateTimeKind.Local).AddTicks(977), new DateTime(2022, 11, 28, 12, 11, 49, 57, DateTimeKind.Local).AddTicks(3911), null, null, null, null, "draft" },
                    { 23, null, new DateTime(2022, 11, 11, 2, 11, 0, 224, DateTimeKind.Local).AddTicks(2998), new DateTime(2022, 8, 15, 2, 23, 46, 169, DateTimeKind.Local).AddTicks(6933), null, null, null, null, "draft" },
                    { 24, null, new DateTime(2022, 8, 14, 9, 5, 6, 506, DateTimeKind.Local).AddTicks(805), new DateTime(2022, 10, 28, 0, 33, 58, 976, DateTimeKind.Local).AddTicks(1706), null, null, null, null, "draft" },
                    { 25, null, new DateTime(2023, 1, 19, 8, 57, 51, 682, DateTimeKind.Local).AddTicks(63), new DateTime(2022, 12, 10, 14, 25, 40, 55, DateTimeKind.Local).AddTicks(1162), null, null, null, null, "draft" },
                    { 26, null, new DateTime(2022, 10, 8, 12, 58, 31, 515, DateTimeKind.Local).AddTicks(2184), new DateTime(2023, 2, 15, 18, 45, 56, 47, DateTimeKind.Local).AddTicks(1072), null, null, null, null, "draft" },
                    { 27, null, new DateTime(2022, 12, 13, 2, 50, 21, 720, DateTimeKind.Local).AddTicks(8898), new DateTime(2022, 8, 9, 3, 42, 2, 566, DateTimeKind.Local).AddTicks(3536), null, null, null, null, "draft" },
                    { 28, null, new DateTime(2022, 11, 25, 9, 29, 42, 172, DateTimeKind.Local).AddTicks(5524), new DateTime(2023, 2, 20, 22, 41, 41, 622, DateTimeKind.Local).AddTicks(7730), null, null, null, null, "draft" },
                    { 29, null, new DateTime(2022, 5, 6, 22, 22, 41, 911, DateTimeKind.Local).AddTicks(3929), new DateTime(2023, 3, 18, 14, 0, 6, 73, DateTimeKind.Local).AddTicks(2562), null, null, null, null, "draft" },
                    { 30, null, new DateTime(2022, 4, 28, 5, 43, 5, 955, DateTimeKind.Local).AddTicks(4877), new DateTime(2022, 10, 22, 11, 36, 55, 273, DateTimeKind.Local).AddTicks(989), null, null, null, null, "draft" },
                    { 31, null, new DateTime(2022, 8, 28, 9, 19, 3, 177, DateTimeKind.Local).AddTicks(9519), new DateTime(2023, 4, 1, 12, 29, 39, 243, DateTimeKind.Local).AddTicks(9904), null, null, null, null, "draft" },
                    { 32, null, new DateTime(2023, 3, 5, 12, 26, 38, 803, DateTimeKind.Local).AddTicks(9718), new DateTime(2023, 1, 30, 5, 19, 39, 520, DateTimeKind.Local).AddTicks(1887), null, null, null, null, "draft" },
                    { 33, null, new DateTime(2023, 3, 18, 4, 14, 46, 405, DateTimeKind.Local).AddTicks(7577), new DateTime(2022, 12, 25, 18, 40, 48, 96, DateTimeKind.Local).AddTicks(8219), null, null, null, null, "draft" },
                    { 34, null, new DateTime(2022, 9, 30, 8, 2, 41, 197, DateTimeKind.Local).AddTicks(1323), new DateTime(2022, 12, 27, 18, 2, 45, 656, DateTimeKind.Local).AddTicks(133), null, null, null, null, "draft" },
                    { 35, null, new DateTime(2022, 4, 19, 9, 25, 22, 775, DateTimeKind.Local).AddTicks(6551), new DateTime(2022, 6, 2, 22, 45, 7, 701, DateTimeKind.Local).AddTicks(7659), null, null, null, null, "draft" },
                    { 36, null, new DateTime(2022, 7, 2, 0, 43, 28, 702, DateTimeKind.Local).AddTicks(7667), new DateTime(2023, 1, 28, 5, 46, 11, 12, DateTimeKind.Local).AddTicks(6306), null, null, null, null, "draft" },
                    { 37, null, new DateTime(2023, 3, 12, 18, 36, 12, 49, DateTimeKind.Local).AddTicks(8854), new DateTime(2023, 2, 12, 6, 58, 2, 532, DateTimeKind.Local).AddTicks(5992), null, null, null, null, "draft" },
                    { 38, null, new DateTime(2022, 11, 13, 1, 9, 29, 203, DateTimeKind.Local).AddTicks(9409), new DateTime(2022, 5, 4, 16, 32, 43, 558, DateTimeKind.Local).AddTicks(1420), null, null, null, null, "draft" },
                    { 39, null, new DateTime(2022, 11, 22, 18, 56, 25, 75, DateTimeKind.Local).AddTicks(6960), new DateTime(2022, 7, 10, 0, 9, 11, 868, DateTimeKind.Local).AddTicks(3809), null, null, null, null, "draft" },
                    { 40, null, new DateTime(2022, 5, 7, 17, 38, 49, 803, DateTimeKind.Local).AddTicks(5403), new DateTime(2023, 3, 4, 21, 28, 45, 184, DateTimeKind.Local).AddTicks(2823), null, null, null, null, "draft" },
                    { 41, null, new DateTime(2022, 10, 21, 0, 16, 47, 287, DateTimeKind.Local).AddTicks(9200), new DateTime(2022, 12, 22, 11, 47, 10, 632, DateTimeKind.Local).AddTicks(8005), null, null, null, null, "draft" },
                    { 42, null, new DateTime(2023, 3, 26, 17, 36, 48, 406, DateTimeKind.Local).AddTicks(6545), new DateTime(2022, 10, 29, 5, 44, 25, 302, DateTimeKind.Local).AddTicks(5674), null, null, null, null, "draft" },
                    { 43, null, new DateTime(2022, 12, 8, 3, 26, 54, 986, DateTimeKind.Local).AddTicks(8235), new DateTime(2022, 11, 28, 9, 55, 24, 55, DateTimeKind.Local).AddTicks(7379), null, null, null, null, "draft" },
                    { 44, null, new DateTime(2022, 12, 4, 12, 28, 4, 558, DateTimeKind.Local).AddTicks(1780), new DateTime(2023, 4, 15, 20, 21, 54, 4, DateTimeKind.Local).AddTicks(7130), null, null, null, null, "draft" },
                    { 45, null, new DateTime(2022, 9, 4, 21, 8, 23, 960, DateTimeKind.Local).AddTicks(6541), new DateTime(2022, 6, 17, 6, 22, 3, 733, DateTimeKind.Local).AddTicks(6122), null, null, null, null, "draft" },
                    { 46, null, new DateTime(2022, 6, 10, 0, 19, 0, 611, DateTimeKind.Local).AddTicks(9245), new DateTime(2022, 7, 10, 5, 18, 5, 720, DateTimeKind.Local).AddTicks(3915), null, null, null, null, "draft" },
                    { 47, null, new DateTime(2023, 3, 17, 4, 38, 59, 126, DateTimeKind.Local).AddTicks(4001), new DateTime(2023, 4, 9, 0, 11, 33, 247, DateTimeKind.Local).AddTicks(3836), null, null, null, null, "draft" },
                    { 48, null, new DateTime(2022, 5, 30, 3, 19, 2, 765, DateTimeKind.Local).AddTicks(4501), new DateTime(2023, 1, 26, 3, 27, 16, 497, DateTimeKind.Local).AddTicks(3531), null, null, null, null, "draft" },
                    { 49, null, new DateTime(2022, 6, 3, 23, 47, 49, 437, DateTimeKind.Local).AddTicks(8872), new DateTime(2022, 10, 26, 18, 29, 41, 180, DateTimeKind.Local).AddTicks(1188), null, null, null, null, "draft" },
                    { 50, null, new DateTime(2022, 12, 29, 22, 53, 57, 618, DateTimeKind.Local).AddTicks(8441), new DateTime(2023, 3, 4, 22, 27, 7, 94, DateTimeKind.Local).AddTicks(6884), null, null, null, null, "draft" },
                    { 51, null, new DateTime(2023, 3, 3, 9, 17, 59, 939, DateTimeKind.Local).AddTicks(7724), new DateTime(2022, 12, 4, 5, 59, 15, 817, DateTimeKind.Local).AddTicks(2787), null, null, null, null, "draft" },
                    { 52, null, new DateTime(2022, 10, 27, 6, 5, 31, 167, DateTimeKind.Local).AddTicks(7278), new DateTime(2022, 12, 5, 1, 9, 38, 947, DateTimeKind.Local).AddTicks(4528), null, null, null, null, "draft" },
                    { 53, null, new DateTime(2022, 9, 27, 4, 39, 6, 319, DateTimeKind.Local).AddTicks(5668), new DateTime(2022, 12, 27, 22, 9, 15, 469, DateTimeKind.Local).AddTicks(8049), null, null, null, null, "draft" },
                    { 54, null, new DateTime(2023, 3, 24, 15, 6, 38, 964, DateTimeKind.Local).AddTicks(4399), new DateTime(2023, 2, 16, 10, 49, 14, 155, DateTimeKind.Local).AddTicks(5088), null, null, null, null, "draft" },
                    { 55, null, new DateTime(2023, 1, 12, 17, 29, 28, 329, DateTimeKind.Local).AddTicks(6317), new DateTime(2022, 11, 9, 7, 53, 53, 581, DateTimeKind.Local).AddTicks(6294), null, null, null, null, "draft" },
                    { 56, null, new DateTime(2022, 7, 17, 18, 42, 11, 514, DateTimeKind.Local).AddTicks(2968), new DateTime(2023, 2, 13, 13, 10, 25, 10, DateTimeKind.Local).AddTicks(2320), null, null, null, null, "draft" },
                    { 57, null, new DateTime(2023, 2, 27, 11, 18, 11, 236, DateTimeKind.Local).AddTicks(9368), new DateTime(2022, 6, 11, 23, 11, 15, 738, DateTimeKind.Local).AddTicks(4261), null, null, null, null, "draft" },
                    { 58, null, new DateTime(2022, 4, 20, 2, 17, 2, 952, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 12, 23, 12, 28, 47, 512, DateTimeKind.Local).AddTicks(3730), null, null, null, null, "draft" },
                    { 59, null, new DateTime(2022, 4, 24, 9, 49, 45, 804, DateTimeKind.Local).AddTicks(5584), new DateTime(2022, 8, 23, 21, 39, 8, 468, DateTimeKind.Local).AddTicks(6268), null, null, null, null, "draft" },
                    { 60, null, new DateTime(2022, 6, 10, 16, 49, 39, 500, DateTimeKind.Local).AddTicks(5885), new DateTime(2022, 8, 6, 9, 16, 17, 317, DateTimeKind.Local).AddTicks(2430), null, null, null, null, "draft" },
                    { 61, null, new DateTime(2022, 5, 9, 21, 9, 38, 505, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 10, 3, 2, 37, 42, 159, DateTimeKind.Local).AddTicks(6434), null, null, null, null, "draft" },
                    { 62, null, new DateTime(2022, 8, 10, 11, 51, 16, 662, DateTimeKind.Local).AddTicks(5841), new DateTime(2023, 2, 18, 18, 0, 14, 9, DateTimeKind.Local).AddTicks(2678), null, null, null, null, "draft" },
                    { 63, null, new DateTime(2023, 4, 11, 13, 23, 2, 57, DateTimeKind.Local).AddTicks(671), new DateTime(2023, 4, 10, 10, 22, 17, 949, DateTimeKind.Local).AddTicks(5969), null, null, null, null, "draft" },
                    { 64, null, new DateTime(2023, 3, 1, 16, 4, 6, 853, DateTimeKind.Local).AddTicks(4531), new DateTime(2023, 3, 22, 9, 21, 33, 769, DateTimeKind.Local).AddTicks(7244), null, null, null, null, "draft" },
                    { 65, null, new DateTime(2023, 1, 1, 18, 35, 54, 734, DateTimeKind.Local).AddTicks(3725), new DateTime(2023, 2, 3, 12, 39, 7, 673, DateTimeKind.Local).AddTicks(8112), null, null, null, null, "draft" },
                    { 66, null, new DateTime(2023, 3, 19, 7, 41, 49, 87, DateTimeKind.Local).AddTicks(4789), new DateTime(2022, 5, 15, 15, 23, 38, 862, DateTimeKind.Local).AddTicks(8014), null, null, null, null, "draft" },
                    { 67, null, new DateTime(2022, 10, 27, 16, 12, 9, 216, DateTimeKind.Local).AddTicks(7618), new DateTime(2022, 6, 21, 10, 8, 37, 676, DateTimeKind.Local).AddTicks(768), null, null, null, null, "draft" },
                    { 68, null, new DateTime(2022, 4, 20, 3, 7, 40, 211, DateTimeKind.Local).AddTicks(7357), new DateTime(2023, 3, 5, 9, 14, 26, 437, DateTimeKind.Local).AddTicks(8671), null, null, null, null, "draft" },
                    { 69, null, new DateTime(2022, 6, 13, 20, 38, 34, 432, DateTimeKind.Local).AddTicks(2993), new DateTime(2022, 8, 8, 7, 24, 4, 426, DateTimeKind.Local).AddTicks(4284), null, null, null, null, "draft" },
                    { 70, null, new DateTime(2022, 5, 20, 16, 2, 13, 950, DateTimeKind.Local).AddTicks(2282), new DateTime(2023, 3, 29, 20, 14, 34, 484, DateTimeKind.Local).AddTicks(2461), null, null, null, null, "draft" },
                    { 71, null, new DateTime(2022, 12, 23, 9, 45, 40, 58, DateTimeKind.Local).AddTicks(5264), new DateTime(2023, 2, 3, 16, 35, 45, 369, DateTimeKind.Local).AddTicks(8975), null, null, null, null, "draft" },
                    { 72, null, new DateTime(2022, 7, 20, 17, 49, 20, 642, DateTimeKind.Local).AddTicks(3104), new DateTime(2023, 2, 12, 4, 11, 25, 346, DateTimeKind.Local).AddTicks(2539), null, null, null, null, "draft" },
                    { 73, null, new DateTime(2023, 3, 19, 2, 36, 47, 186, DateTimeKind.Local).AddTicks(5455), new DateTime(2022, 8, 13, 2, 5, 30, 568, DateTimeKind.Local).AddTicks(9225), null, null, null, null, "draft" },
                    { 74, null, new DateTime(2022, 8, 29, 8, 56, 49, 450, DateTimeKind.Local).AddTicks(6890), new DateTime(2023, 1, 21, 20, 24, 38, 355, DateTimeKind.Local).AddTicks(2083), null, null, null, null, "draft" },
                    { 75, null, new DateTime(2023, 4, 7, 12, 51, 25, 262, DateTimeKind.Local).AddTicks(2182), new DateTime(2022, 9, 23, 5, 47, 10, 220, DateTimeKind.Local).AddTicks(3123), null, null, null, null, "draft" },
                    { 76, null, new DateTime(2023, 1, 20, 8, 34, 25, 660, DateTimeKind.Local).AddTicks(308), new DateTime(2023, 1, 27, 17, 5, 35, 936, DateTimeKind.Local).AddTicks(4965), null, null, null, null, "draft" },
                    { 77, null, new DateTime(2022, 9, 3, 16, 36, 56, 646, DateTimeKind.Local).AddTicks(7673), new DateTime(2022, 9, 11, 4, 34, 35, 268, DateTimeKind.Local).AddTicks(8379), null, null, null, null, "draft" },
                    { 78, null, new DateTime(2023, 2, 11, 16, 14, 23, 556, DateTimeKind.Local).AddTicks(580), new DateTime(2022, 9, 16, 21, 37, 12, 747, DateTimeKind.Local).AddTicks(3667), null, null, null, null, "draft" },
                    { 79, null, new DateTime(2022, 8, 12, 9, 4, 54, 121, DateTimeKind.Local).AddTicks(9331), new DateTime(2022, 12, 25, 3, 2, 12, 125, DateTimeKind.Local).AddTicks(6988), null, null, null, null, "draft" },
                    { 80, null, new DateTime(2022, 12, 12, 2, 43, 31, 857, DateTimeKind.Local).AddTicks(6251), new DateTime(2022, 10, 5, 9, 13, 43, 337, DateTimeKind.Local).AddTicks(2092), null, null, null, null, "draft" },
                    { 81, null, new DateTime(2023, 2, 13, 21, 2, 3, 583, DateTimeKind.Local).AddTicks(5919), new DateTime(2022, 4, 20, 20, 42, 0, 161, DateTimeKind.Local).AddTicks(9557), null, null, null, null, "draft" },
                    { 82, null, new DateTime(2022, 6, 3, 7, 10, 14, 388, DateTimeKind.Local).AddTicks(3774), new DateTime(2023, 3, 27, 19, 47, 15, 623, DateTimeKind.Local).AddTicks(617), null, null, null, null, "draft" },
                    { 83, null, new DateTime(2022, 12, 9, 15, 8, 59, 461, DateTimeKind.Local).AddTicks(3924), new DateTime(2022, 6, 20, 18, 15, 27, 618, DateTimeKind.Local).AddTicks(7373), null, null, null, null, "draft" },
                    { 84, null, new DateTime(2022, 8, 5, 11, 55, 10, 760, DateTimeKind.Local).AddTicks(7128), new DateTime(2022, 12, 25, 16, 6, 28, 528, DateTimeKind.Local).AddTicks(1027), null, null, null, null, "draft" },
                    { 85, null, new DateTime(2022, 6, 10, 11, 0, 30, 493, DateTimeKind.Local).AddTicks(9339), new DateTime(2022, 6, 3, 7, 59, 31, 481, DateTimeKind.Local).AddTicks(7769), null, null, null, null, "draft" },
                    { 86, null, new DateTime(2022, 10, 28, 6, 47, 8, 47, DateTimeKind.Local).AddTicks(3180), new DateTime(2023, 1, 2, 17, 22, 36, 345, DateTimeKind.Local).AddTicks(3743), null, null, null, null, "draft" },
                    { 87, null, new DateTime(2022, 7, 22, 20, 33, 49, 485, DateTimeKind.Local).AddTicks(6437), new DateTime(2022, 6, 30, 11, 31, 59, 983, DateTimeKind.Local).AddTicks(5875), null, null, null, null, "draft" },
                    { 88, null, new DateTime(2022, 11, 30, 14, 27, 32, 225, DateTimeKind.Local).AddTicks(9626), new DateTime(2022, 7, 22, 19, 30, 48, 103, DateTimeKind.Local).AddTicks(2164), null, null, null, null, "draft" },
                    { 89, null, new DateTime(2022, 7, 1, 23, 45, 16, 484, DateTimeKind.Local).AddTicks(5798), new DateTime(2022, 10, 14, 22, 36, 46, 283, DateTimeKind.Local).AddTicks(5770), null, null, null, null, "draft" },
                    { 90, null, new DateTime(2023, 3, 21, 6, 20, 21, 789, DateTimeKind.Local).AddTicks(9698), new DateTime(2022, 12, 16, 2, 14, 26, 455, DateTimeKind.Local).AddTicks(3922), null, null, null, null, "draft" },
                    { 91, null, new DateTime(2022, 11, 28, 16, 22, 23, 466, DateTimeKind.Local).AddTicks(1598), new DateTime(2022, 5, 27, 10, 36, 23, 465, DateTimeKind.Local).AddTicks(4969), null, null, null, null, "draft" },
                    { 92, null, new DateTime(2023, 4, 2, 11, 27, 3, 474, DateTimeKind.Local).AddTicks(7590), new DateTime(2022, 7, 28, 3, 45, 39, 481, DateTimeKind.Local).AddTicks(3130), null, null, null, null, "draft" },
                    { 93, null, new DateTime(2022, 5, 2, 19, 1, 36, 981, DateTimeKind.Local).AddTicks(340), new DateTime(2022, 6, 8, 5, 33, 8, 118, DateTimeKind.Local).AddTicks(2361), null, null, null, null, "draft" },
                    { 94, null, new DateTime(2022, 12, 28, 13, 43, 37, 183, DateTimeKind.Local).AddTicks(2886), new DateTime(2022, 6, 4, 2, 34, 28, 915, DateTimeKind.Local).AddTicks(1785), null, null, null, null, "draft" },
                    { 95, null, new DateTime(2022, 8, 26, 8, 51, 9, 87, DateTimeKind.Local).AddTicks(2741), new DateTime(2022, 11, 19, 20, 27, 22, 431, DateTimeKind.Local).AddTicks(6245), null, null, null, null, "draft" },
                    { 96, null, new DateTime(2022, 11, 9, 15, 6, 27, 283, DateTimeKind.Local).AddTicks(1903), new DateTime(2022, 10, 6, 8, 33, 17, 273, DateTimeKind.Local).AddTicks(8568), null, null, null, null, "draft" },
                    { 97, null, new DateTime(2022, 12, 13, 19, 37, 27, 536, DateTimeKind.Local).AddTicks(603), new DateTime(2022, 12, 1, 21, 45, 25, 580, DateTimeKind.Local).AddTicks(2761), null, null, null, null, "draft" },
                    { 98, null, new DateTime(2022, 6, 1, 14, 9, 25, 867, DateTimeKind.Local).AddTicks(9120), new DateTime(2022, 12, 21, 4, 0, 34, 863, DateTimeKind.Local).AddTicks(8285), null, null, null, null, "draft" },
                    { 99, null, new DateTime(2022, 12, 20, 0, 22, 25, 948, DateTimeKind.Local).AddTicks(7789), new DateTime(2022, 8, 11, 12, 58, 59, 986, DateTimeKind.Local).AddTicks(5075), null, null, null, null, "draft" },
                    { 100, null, new DateTime(2022, 6, 22, 3, 59, 20, 852, DateTimeKind.Local).AddTicks(1211), new DateTime(2023, 1, 14, 23, 18, 14, 535, DateTimeKind.Local).AddTicks(678), null, null, null, null, "draft" },
                    { 101, null, new DateTime(2022, 4, 26, 5, 7, 14, 775, DateTimeKind.Local).AddTicks(4702), new DateTime(2022, 12, 21, 7, 47, 15, 889, DateTimeKind.Local).AddTicks(8434), null, null, null, null, "draft" },
                    { 102, null, new DateTime(2022, 11, 30, 0, 21, 2, 828, DateTimeKind.Local).AddTicks(5322), new DateTime(2023, 2, 20, 19, 48, 48, 747, DateTimeKind.Local).AddTicks(6990), null, null, null, null, "draft" },
                    { 103, null, new DateTime(2023, 3, 14, 13, 56, 57, 140, DateTimeKind.Local).AddTicks(2530), new DateTime(2022, 5, 6, 6, 8, 44, 281, DateTimeKind.Local).AddTicks(9152), null, null, null, null, "draft" },
                    { 104, null, new DateTime(2022, 10, 24, 11, 28, 41, 418, DateTimeKind.Local).AddTicks(1122), new DateTime(2022, 6, 22, 20, 1, 51, 630, DateTimeKind.Local).AddTicks(4392), null, null, null, null, "draft" },
                    { 105, null, new DateTime(2023, 1, 28, 5, 3, 58, 10, DateTimeKind.Local).AddTicks(1355), new DateTime(2022, 11, 8, 11, 40, 30, 420, DateTimeKind.Local).AddTicks(1018), null, null, null, null, "draft" },
                    { 106, null, new DateTime(2022, 7, 4, 12, 48, 51, 230, DateTimeKind.Local).AddTicks(480), new DateTime(2023, 2, 14, 1, 25, 2, 805, DateTimeKind.Local).AddTicks(6171), null, null, null, null, "draft" },
                    { 107, null, new DateTime(2023, 1, 22, 11, 38, 45, 302, DateTimeKind.Local).AddTicks(9908), new DateTime(2023, 4, 14, 15, 26, 0, 369, DateTimeKind.Local).AddTicks(4948), null, null, null, null, "draft" },
                    { 108, null, new DateTime(2023, 2, 23, 7, 48, 14, 838, DateTimeKind.Local).AddTicks(3122), new DateTime(2023, 1, 6, 1, 22, 35, 85, DateTimeKind.Local).AddTicks(3579), null, null, null, null, "draft" },
                    { 109, null, new DateTime(2022, 5, 7, 0, 11, 51, 654, DateTimeKind.Local).AddTicks(4603), new DateTime(2023, 2, 22, 18, 21, 29, 874, DateTimeKind.Local).AddTicks(3280), null, null, null, null, "draft" },
                    { 110, null, new DateTime(2023, 3, 13, 15, 42, 33, 609, DateTimeKind.Local).AddTicks(2921), new DateTime(2022, 10, 20, 0, 32, 46, 310, DateTimeKind.Local).AddTicks(4207), null, null, null, null, "draft" },
                    { 111, null, new DateTime(2022, 10, 9, 19, 28, 45, 402, DateTimeKind.Local).AddTicks(7140), new DateTime(2022, 6, 20, 0, 17, 36, 812, DateTimeKind.Local).AddTicks(7996), null, null, null, null, "draft" },
                    { 112, null, new DateTime(2022, 8, 17, 22, 12, 14, 408, DateTimeKind.Local).AddTicks(1003), new DateTime(2022, 11, 7, 5, 30, 3, 29, DateTimeKind.Local).AddTicks(5815), null, null, null, null, "draft" },
                    { 113, null, new DateTime(2022, 11, 10, 7, 49, 59, 165, DateTimeKind.Local).AddTicks(8595), new DateTime(2022, 5, 10, 13, 10, 45, 740, DateTimeKind.Local).AddTicks(7340), null, null, null, null, "draft" },
                    { 114, null, new DateTime(2022, 5, 8, 12, 42, 3, 776, DateTimeKind.Local).AddTicks(5876), new DateTime(2022, 12, 7, 13, 45, 18, 872, DateTimeKind.Local).AddTicks(6414), null, null, null, null, "draft" },
                    { 115, null, new DateTime(2022, 5, 17, 12, 19, 29, 82, DateTimeKind.Local).AddTicks(9500), new DateTime(2023, 3, 29, 1, 23, 52, 329, DateTimeKind.Local).AddTicks(4086), null, null, null, null, "draft" },
                    { 116, null, new DateTime(2022, 11, 19, 10, 5, 17, 121, DateTimeKind.Local).AddTicks(7129), new DateTime(2023, 3, 9, 1, 43, 11, 465, DateTimeKind.Local).AddTicks(3478), null, null, null, null, "draft" },
                    { 117, null, new DateTime(2022, 8, 11, 9, 34, 20, 398, DateTimeKind.Local).AddTicks(7321), new DateTime(2022, 6, 22, 21, 59, 2, 222, DateTimeKind.Local).AddTicks(1782), null, null, null, null, "draft" },
                    { 118, null, new DateTime(2022, 12, 8, 12, 4, 6, 647, DateTimeKind.Local).AddTicks(1991), new DateTime(2023, 3, 26, 23, 32, 2, 543, DateTimeKind.Local).AddTicks(5935), null, null, null, null, "draft" },
                    { 119, null, new DateTime(2022, 10, 14, 1, 12, 15, 604, DateTimeKind.Local).AddTicks(2426), new DateTime(2022, 5, 29, 6, 35, 9, 694, DateTimeKind.Local).AddTicks(3378), null, null, null, null, "draft" },
                    { 120, null, new DateTime(2022, 9, 1, 4, 45, 37, 308, DateTimeKind.Local).AddTicks(3388), new DateTime(2023, 4, 15, 3, 49, 47, 666, DateTimeKind.Local).AddTicks(3975), null, null, null, null, "draft" },
                    { 121, null, new DateTime(2022, 12, 1, 9, 1, 21, 667, DateTimeKind.Local).AddTicks(4034), new DateTime(2022, 10, 24, 8, 38, 40, 520, DateTimeKind.Local).AddTicks(1290), null, null, null, null, "draft" },
                    { 122, null, new DateTime(2022, 8, 23, 12, 27, 25, 872, DateTimeKind.Local).AddTicks(3233), new DateTime(2023, 2, 3, 12, 7, 33, 634, DateTimeKind.Local).AddTicks(4527), null, null, null, null, "draft" },
                    { 123, null, new DateTime(2022, 9, 3, 22, 35, 26, 168, DateTimeKind.Local).AddTicks(8576), new DateTime(2023, 1, 12, 4, 38, 19, 444, DateTimeKind.Local).AddTicks(8544), null, null, null, null, "draft" },
                    { 124, null, new DateTime(2022, 12, 31, 11, 51, 26, 938, DateTimeKind.Local).AddTicks(1480), new DateTime(2022, 12, 17, 19, 8, 22, 133, DateTimeKind.Local).AddTicks(8477), null, null, null, null, "draft" },
                    { 125, null, new DateTime(2023, 1, 25, 4, 54, 5, 709, DateTimeKind.Local).AddTicks(2468), new DateTime(2022, 9, 12, 3, 43, 45, 749, DateTimeKind.Local).AddTicks(8371), null, null, null, null, "draft" },
                    { 126, null, new DateTime(2022, 12, 2, 18, 45, 38, 176, DateTimeKind.Local).AddTicks(6520), new DateTime(2023, 2, 12, 20, 57, 51, 41, DateTimeKind.Local).AddTicks(7347), null, null, null, null, "draft" },
                    { 127, null, new DateTime(2022, 9, 16, 12, 13, 21, 344, DateTimeKind.Local).AddTicks(4999), new DateTime(2022, 12, 19, 18, 23, 29, 508, DateTimeKind.Local).AddTicks(9849), null, null, null, null, "draft" },
                    { 128, null, new DateTime(2022, 7, 24, 18, 46, 24, 99, DateTimeKind.Local).AddTicks(6393), new DateTime(2023, 2, 22, 19, 46, 32, 929, DateTimeKind.Local).AddTicks(9561), null, null, null, null, "draft" },
                    { 129, null, new DateTime(2022, 8, 22, 0, 31, 56, 449, DateTimeKind.Local).AddTicks(351), new DateTime(2022, 5, 11, 9, 47, 54, 766, DateTimeKind.Local).AddTicks(2429), null, null, null, null, "draft" },
                    { 130, null, new DateTime(2022, 7, 30, 2, 55, 44, 549, DateTimeKind.Local).AddTicks(1327), new DateTime(2023, 2, 20, 15, 43, 6, 366, DateTimeKind.Local).AddTicks(8120), null, null, null, null, "draft" },
                    { 131, null, new DateTime(2023, 4, 16, 8, 23, 35, 472, DateTimeKind.Local).AddTicks(6216), new DateTime(2023, 3, 5, 12, 40, 17, 512, DateTimeKind.Local).AddTicks(7650), null, null, null, null, "draft" },
                    { 132, null, new DateTime(2022, 5, 24, 22, 39, 17, 514, DateTimeKind.Local).AddTicks(7840), new DateTime(2023, 2, 17, 18, 37, 0, 648, DateTimeKind.Local).AddTicks(218), null, null, null, null, "draft" },
                    { 133, null, new DateTime(2023, 4, 7, 16, 32, 8, 265, DateTimeKind.Local).AddTicks(6846), new DateTime(2022, 8, 14, 2, 2, 34, 731, DateTimeKind.Local).AddTicks(9960), null, null, null, null, "draft" },
                    { 134, null, new DateTime(2022, 10, 22, 6, 47, 37, 374, DateTimeKind.Local).AddTicks(1816), new DateTime(2022, 11, 18, 4, 36, 38, 48, DateTimeKind.Local).AddTicks(1092), null, null, null, null, "draft" },
                    { 135, null, new DateTime(2022, 8, 23, 18, 18, 48, 689, DateTimeKind.Local).AddTicks(5930), new DateTime(2023, 3, 17, 23, 13, 7, 262, DateTimeKind.Local).AddTicks(161), null, null, null, null, "draft" },
                    { 136, null, new DateTime(2022, 7, 11, 15, 7, 14, 448, DateTimeKind.Local).AddTicks(4135), new DateTime(2023, 3, 27, 8, 33, 36, 927, DateTimeKind.Local).AddTicks(4208), null, null, null, null, "draft" },
                    { 137, null, new DateTime(2022, 10, 10, 4, 32, 47, 533, DateTimeKind.Local).AddTicks(2883), new DateTime(2023, 3, 17, 2, 49, 40, 910, DateTimeKind.Local).AddTicks(1938), null, null, null, null, "draft" },
                    { 138, null, new DateTime(2023, 3, 7, 6, 28, 19, 610, DateTimeKind.Local).AddTicks(3173), new DateTime(2023, 4, 4, 1, 46, 59, 849, DateTimeKind.Local).AddTicks(8849), null, null, null, null, "draft" },
                    { 139, null, new DateTime(2023, 2, 13, 2, 47, 5, 907, DateTimeKind.Local).AddTicks(7769), new DateTime(2022, 10, 31, 1, 1, 35, 740, DateTimeKind.Local).AddTicks(9427), null, null, null, null, "draft" },
                    { 140, null, new DateTime(2022, 6, 21, 21, 51, 31, 828, DateTimeKind.Local).AddTicks(196), new DateTime(2023, 2, 14, 18, 8, 34, 688, DateTimeKind.Local).AddTicks(3008), null, null, null, null, "draft" },
                    { 141, null, new DateTime(2022, 8, 26, 16, 16, 13, 769, DateTimeKind.Local).AddTicks(8824), new DateTime(2022, 9, 7, 8, 30, 36, 610, DateTimeKind.Local).AddTicks(363), null, null, null, null, "draft" },
                    { 142, null, new DateTime(2023, 2, 28, 23, 48, 8, 130, DateTimeKind.Local).AddTicks(6917), new DateTime(2022, 12, 21, 23, 32, 38, 300, DateTimeKind.Local).AddTicks(4101), null, null, null, null, "draft" },
                    { 143, null, new DateTime(2022, 8, 12, 21, 35, 9, 120, DateTimeKind.Local).AddTicks(548), new DateTime(2023, 1, 23, 4, 4, 21, 47, DateTimeKind.Local).AddTicks(2763), null, null, null, null, "draft" },
                    { 144, null, new DateTime(2022, 10, 9, 4, 26, 45, 88, DateTimeKind.Local).AddTicks(1466), new DateTime(2022, 12, 9, 6, 7, 45, 857, DateTimeKind.Local).AddTicks(461), null, null, null, null, "draft" },
                    { 145, null, new DateTime(2023, 3, 17, 18, 9, 33, 89, DateTimeKind.Local).AddTicks(8386), new DateTime(2023, 2, 1, 7, 14, 28, 684, DateTimeKind.Local).AddTicks(5426), null, null, null, null, "draft" },
                    { 146, null, new DateTime(2022, 11, 21, 13, 57, 1, 61, DateTimeKind.Local).AddTicks(8589), new DateTime(2022, 9, 21, 6, 21, 15, 805, DateTimeKind.Local).AddTicks(3003), null, null, null, null, "draft" },
                    { 147, null, new DateTime(2023, 2, 15, 18, 36, 20, 112, DateTimeKind.Local).AddTicks(5065), new DateTime(2022, 10, 28, 3, 59, 25, 908, DateTimeKind.Local).AddTicks(8280), null, null, null, null, "draft" },
                    { 148, null, new DateTime(2023, 4, 17, 10, 23, 7, 161, DateTimeKind.Local).AddTicks(781), new DateTime(2023, 1, 14, 11, 17, 59, 121, DateTimeKind.Local).AddTicks(9407), null, null, null, null, "draft" },
                    { 149, null, new DateTime(2022, 9, 18, 0, 56, 17, 972, DateTimeKind.Local).AddTicks(6514), new DateTime(2022, 10, 22, 8, 47, 20, 191, DateTimeKind.Local).AddTicks(6082), null, null, null, null, "draft" },
                    { 150, null, new DateTime(2023, 2, 14, 10, 32, 20, 336, DateTimeKind.Local).AddTicks(755), new DateTime(2022, 5, 9, 11, 29, 46, 404, DateTimeKind.Local).AddTicks(1691), null, null, null, null, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 4, 49, 52, 894, DateTimeKind.Local).AddTicks(3566), new DateTime(2022, 10, 30, 3, 56, 6, 158, DateTimeKind.Local).AddTicks(3051), "Chrysler" },
                    { 2, new DateTime(2022, 8, 21, 15, 4, 59, 124, DateTimeKind.Local).AddTicks(3161), new DateTime(2022, 11, 11, 15, 46, 22, 844, DateTimeKind.Local).AddTicks(1391), "Polestar" },
                    { 3, new DateTime(2022, 5, 9, 2, 42, 54, 218, DateTimeKind.Local).AddTicks(8707), new DateTime(2023, 3, 12, 15, 51, 16, 79, DateTimeKind.Local).AddTicks(4446), "Ford" },
                    { 4, new DateTime(2023, 4, 8, 4, 5, 24, 433, DateTimeKind.Local).AddTicks(1026), new DateTime(2023, 1, 18, 2, 12, 47, 825, DateTimeKind.Local).AddTicks(4108), "Mazda" },
                    { 5, new DateTime(2022, 4, 22, 8, 35, 18, 189, DateTimeKind.Local).AddTicks(2509), new DateTime(2022, 8, 12, 15, 33, 0, 282, DateTimeKind.Local).AddTicks(2928), "Fiat" },
                    { 6, new DateTime(2023, 1, 5, 10, 14, 26, 151, DateTimeKind.Local).AddTicks(7224), new DateTime(2022, 9, 6, 0, 30, 50, 627, DateTimeKind.Local).AddTicks(5708), "Mazda" },
                    { 7, new DateTime(2022, 8, 5, 11, 12, 35, 2, DateTimeKind.Local).AddTicks(4859), new DateTime(2022, 5, 6, 22, 53, 21, 857, DateTimeKind.Local).AddTicks(2014), "Mini" },
                    { 8, new DateTime(2023, 2, 18, 21, 24, 5, 950, DateTimeKind.Local).AddTicks(1814), new DateTime(2022, 11, 30, 4, 52, 55, 52, DateTimeKind.Local).AddTicks(2485), "Bentley" },
                    { 9, new DateTime(2023, 2, 15, 18, 24, 58, 818, DateTimeKind.Local).AddTicks(4085), new DateTime(2022, 7, 2, 21, 24, 14, 633, DateTimeKind.Local).AddTicks(3789), "Porsche" },
                    { 10, new DateTime(2022, 6, 22, 5, 13, 10, 382, DateTimeKind.Local).AddTicks(908), new DateTime(2022, 5, 30, 1, 28, 31, 526, DateTimeKind.Local).AddTicks(4482), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[] { 10, new DateTime(2022, 6, 22, 5, 13, 10, 384, DateTimeKind.Local).AddTicks(6150), null, null, new DateTime(2022, 5, 30, 1, 28, 31, 528, DateTimeKind.Local).AddTicks(9724), "Home" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 4, 49, 52, 891, DateTimeKind.Local).AddTicks(5491), new DateTime(2022, 10, 30, 3, 56, 6, 155, DateTimeKind.Local).AddTicks(4937), "Ecuador" },
                    { 2, new DateTime(2022, 8, 21, 15, 4, 59, 121, DateTimeKind.Local).AddTicks(5049), new DateTime(2022, 11, 11, 15, 46, 22, 841, DateTimeKind.Local).AddTicks(3279), "Samoa" },
                    { 3, new DateTime(2022, 5, 9, 2, 42, 54, 216, DateTimeKind.Local).AddTicks(597), new DateTime(2023, 3, 12, 15, 51, 16, 76, DateTimeKind.Local).AddTicks(6336), "Guatemala" },
                    { 4, new DateTime(2023, 4, 8, 4, 5, 24, 430, DateTimeKind.Local).AddTicks(2916), new DateTime(2023, 1, 18, 2, 12, 47, 822, DateTimeKind.Local).AddTicks(5998), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 22, 8, 35, 18, 186, DateTimeKind.Local).AddTicks(4399), new DateTime(2022, 8, 12, 15, 33, 0, 279, DateTimeKind.Local).AddTicks(4817), "Germany" },
                    { 6, new DateTime(2023, 1, 5, 10, 14, 26, 148, DateTimeKind.Local).AddTicks(9114), new DateTime(2022, 9, 6, 0, 30, 50, 624, DateTimeKind.Local).AddTicks(7598), "Niue" },
                    { 7, new DateTime(2022, 8, 5, 11, 12, 34, 999, DateTimeKind.Local).AddTicks(6749), new DateTime(2022, 5, 6, 22, 53, 21, 854, DateTimeKind.Local).AddTicks(3904), "Philippines" },
                    { 8, new DateTime(2023, 2, 18, 21, 24, 5, 947, DateTimeKind.Local).AddTicks(3705), new DateTime(2022, 11, 30, 4, 52, 55, 49, DateTimeKind.Local).AddTicks(4376), "Benin" },
                    { 9, new DateTime(2023, 2, 15, 18, 24, 58, 815, DateTimeKind.Local).AddTicks(5976), new DateTime(2022, 7, 2, 21, 24, 14, 630, DateTimeKind.Local).AddTicks(5680), "Seychelles" },
                    { 10, new DateTime(2022, 6, 22, 5, 13, 10, 379, DateTimeKind.Local).AddTicks(2800), new DateTime(2022, 5, 30, 1, 28, 31, 523, DateTimeKind.Local).AddTicks(6373), "French Southern Territories" }
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
                    { 1, 3, new DateTime(2022, 12, 22, 18, 47, 1, 851, DateTimeKind.Local).AddTicks(4363), null, false, new DateTime(2022, 4, 22, 8, 35, 18, 194, DateTimeKind.Local).AddTicks(2668), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 7, 2, 21, 24, 14, 638, DateTimeKind.Local).AddTicks(4074), null, false, new DateTime(2022, 12, 27, 11, 37, 45, 118, DateTimeKind.Local).AddTicks(968), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 9, 1, 0, 0, 770, DateTimeKind.Local).AddTicks(7791), null, false, new DateTime(2022, 4, 20, 21, 17, 33, 271, DateTimeKind.Local).AddTicks(2941), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 25, 9, 29, 42, 169, DateTimeKind.Local).AddTicks(1967), null, false, new DateTime(2023, 2, 20, 22, 41, 41, 619, DateTimeKind.Local).AddTicks(4174), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 19, 9, 25, 22, 772, DateTimeKind.Local).AddTicks(2983), null, false, new DateTime(2022, 6, 2, 22, 45, 7, 698, DateTimeKind.Local).AddTicks(4092), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 26, 17, 36, 48, 403, DateTimeKind.Local).AddTicks(2924), null, false, new DateTime(2022, 10, 29, 5, 44, 25, 299, DateTimeKind.Local).AddTicks(2054), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 3, 23, 47, 49, 434, DateTimeKind.Local).AddTicks(5237), null, false, new DateTime(2022, 10, 26, 18, 29, 41, 176, DateTimeKind.Local).AddTicks(7554), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 17, 18, 42, 11, 510, DateTimeKind.Local).AddTicks(9320), null, false, new DateTime(2023, 2, 13, 13, 10, 25, 6, DateTimeKind.Local).AddTicks(8672), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 11, 13, 23, 2, 53, DateTimeKind.Local).AddTicks(7008), null, false, new DateTime(2023, 4, 10, 10, 22, 17, 946, DateTimeKind.Local).AddTicks(2307), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 20, 16, 2, 13, 946, DateTimeKind.Local).AddTicks(8607), null, false, new DateTime(2023, 3, 29, 20, 14, 34, 480, DateTimeKind.Local).AddTicks(8787), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 3, 16, 36, 56, 643, DateTimeKind.Local).AddTicks(3985), null, false, new DateTime(2022, 9, 11, 4, 34, 35, 265, DateTimeKind.Local).AddTicks(4693), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 5, 11, 55, 10, 757, DateTimeKind.Local).AddTicks(3430), null, false, new DateTime(2022, 12, 25, 16, 6, 28, 524, DateTimeKind.Local).AddTicks(7331), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 28, 16, 22, 23, 462, DateTimeKind.Local).AddTicks(7888), null, true, new DateTime(2022, 5, 27, 10, 36, 23, 462, DateTimeKind.Local).AddTicks(1260), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 6, 1, 14, 9, 25, 864, DateTimeKind.Local).AddTicks(5397), null, false, new DateTime(2022, 12, 21, 4, 0, 34, 860, DateTimeKind.Local).AddTicks(4563), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 28, 5, 3, 58, 6, DateTimeKind.Local).AddTicks(7619), null, false, new DateTime(2022, 11, 8, 11, 40, 30, 416, DateTimeKind.Local).AddTicks(7284), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 17, 22, 12, 14, 404, DateTimeKind.Local).AddTicks(7197), null, false, new DateTime(2022, 11, 7, 5, 30, 3, 26, DateTimeKind.Local).AddTicks(2009), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 14, 1, 12, 15, 600, DateTimeKind.Local).AddTicks(8605), null, false, new DateTime(2022, 5, 29, 6, 35, 9, 690, DateTimeKind.Local).AddTicks(9558), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 12, 2, 18, 45, 38, 173, DateTimeKind.Local).AddTicks(2718), null, false, new DateTime(2023, 2, 12, 20, 57, 51, 38, DateTimeKind.Local).AddTicks(3547), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 7, 16, 32, 8, 262, DateTimeKind.Local).AddTicks(3034), null, false, new DateTime(2022, 8, 14, 2, 2, 34, 728, DateTimeKind.Local).AddTicks(6149), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 21, 21, 51, 31, 824, DateTimeKind.Local).AddTicks(6371), null, false, new DateTime(2023, 2, 14, 18, 8, 34, 684, DateTimeKind.Local).AddTicks(9184), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 15, 18, 36, 20, 109, DateTimeKind.Local).AddTicks(1225), null, false, new DateTime(2022, 10, 28, 3, 59, 25, 905, DateTimeKind.Local).AddTicks(4441), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 22, 7, 21, 58, 472, DateTimeKind.Local).AddTicks(3681), null, false, new DateTime(2022, 10, 19, 0, 20, 35, 398, DateTimeKind.Local).AddTicks(2281), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 21, 12, 32, 44, 607, DateTimeKind.Local).AddTicks(7755), null, false, new DateTime(2023, 3, 1, 15, 36, 46, 481, DateTimeKind.Local).AddTicks(618), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 24, 20, 17, 52, 614, DateTimeKind.Local).AddTicks(2539), null, false, new DateTime(2022, 7, 14, 9, 1, 24, 876, DateTimeKind.Local).AddTicks(4695), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 5, 3, 4, 32, 33, 308, DateTimeKind.Local).AddTicks(5227), null, false, new DateTime(2022, 9, 8, 10, 30, 8, 295, DateTimeKind.Local).AddTicks(1172), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 19, 7, 54, 1, 649, DateTimeKind.Local).AddTicks(1243), null, false, new DateTime(2022, 12, 10, 7, 41, 44, 374, DateTimeKind.Local).AddTicks(2259), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 23, 12, 21, 5, 490, DateTimeKind.Local).AddTicks(35), null, false, new DateTime(2022, 5, 12, 15, 10, 46, 49, DateTimeKind.Local).AddTicks(4336), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 2, 1, 12, 13, 40, 944, DateTimeKind.Local).AddTicks(7222), null, false, new DateTime(2022, 8, 9, 17, 55, 49, 723, DateTimeKind.Local).AddTicks(2241), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 25, 3, 21, 17, 631, DateTimeKind.Local).AddTicks(296), null, false, new DateTime(2023, 1, 8, 12, 43, 55, 70, DateTimeKind.Local).AddTicks(5950), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 12, 20, 0, 18, 658, DateTimeKind.Local).AddTicks(4232), null, false, new DateTime(2022, 7, 6, 17, 7, 39, 250, DateTimeKind.Local).AddTicks(1951), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 8, 21, 6, 14, 549, DateTimeKind.Local).AddTicks(1832), null, false, new DateTime(2023, 1, 15, 2, 24, 42, 884, DateTimeKind.Local).AddTicks(8961), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 21, 15, 56, 49, 594, DateTimeKind.Local).AddTicks(322), null, false, new DateTime(2022, 10, 4, 11, 3, 45, 999, DateTimeKind.Local).AddTicks(6784), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 27, 9, 47, 22, 873, DateTimeKind.Local).AddTicks(7887), null, false, new DateTime(2022, 8, 7, 11, 43, 23, 762, DateTimeKind.Local).AddTicks(9322), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 17, 10, 54, 57, 772, DateTimeKind.Local).AddTicks(2197), null, false, new DateTime(2022, 6, 26, 15, 47, 7, 302, DateTimeKind.Local).AddTicks(1723), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 22, 3, 54, 46, 782, DateTimeKind.Local).AddTicks(220), null, false, new DateTime(2022, 6, 20, 21, 25, 23, 659, DateTimeKind.Local).AddTicks(8910), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 6, 19, 42, 55, 296, DateTimeKind.Local).AddTicks(7816), null, false, new DateTime(2022, 9, 19, 13, 25, 10, 865, DateTimeKind.Local).AddTicks(3694), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 9, 18, 20, 43, 412, DateTimeKind.Local).AddTicks(479), null, false, new DateTime(2022, 12, 14, 9, 23, 15, 290, DateTimeKind.Local).AddTicks(8313), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 22, 10, 37, 35, 270, DateTimeKind.Local).AddTicks(8707), null, false, new DateTime(2022, 11, 26, 13, 5, 5, 54, DateTimeKind.Local).AddTicks(7382), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 25, 18, 16, 15, 923, DateTimeKind.Local).AddTicks(226), null, false, new DateTime(2023, 4, 1, 3, 7, 14, 406, DateTimeKind.Local).AddTicks(5221), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 6, 9, 58, 33, 164, DateTimeKind.Local).AddTicks(4108), null, false, new DateTime(2022, 6, 30, 2, 26, 12, 131, DateTimeKind.Local).AddTicks(8101), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 23, 9, 31, 51, 819, DateTimeKind.Local).AddTicks(4150), null, false, new DateTime(2023, 2, 22, 19, 15, 31, 855, DateTimeKind.Local).AddTicks(3112), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 14, 19, 2, 38, 516, DateTimeKind.Local).AddTicks(776), null, false, new DateTime(2022, 10, 27, 17, 19, 37, 879, DateTimeKind.Local).AddTicks(3920), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 11, 0, 58, 15, 165, DateTimeKind.Local).AddTicks(9613), null, false, new DateTime(2022, 6, 12, 19, 13, 47, 686, DateTimeKind.Local).AddTicks(3013), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 6, 10, 36, 8, 762, DateTimeKind.Local).AddTicks(585), null, false, new DateTime(2022, 11, 2, 23, 30, 34, 695, DateTimeKind.Local).AddTicks(8445), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 24, 4, 19, 9, 856, DateTimeKind.Local).AddTicks(118), null, false, new DateTime(2023, 1, 14, 15, 28, 46, 303, DateTimeKind.Local).AddTicks(4105), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 19, 14, 26, 58, 275, DateTimeKind.Local).AddTicks(5270), null, false, new DateTime(2022, 8, 16, 22, 34, 23, 858, DateTimeKind.Local).AddTicks(8145), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 23, 4, 38, 55, 921, DateTimeKind.Local).AddTicks(2035), null, false, new DateTime(2022, 12, 3, 20, 22, 49, 567, DateTimeKind.Local).AddTicks(9792), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 15, 0, 1, 7, 233, DateTimeKind.Local).AddTicks(8240), null, false, new DateTime(2023, 1, 2, 5, 33, 40, 467, DateTimeKind.Local).AddTicks(669), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 30, 19, 54, 3, 652, DateTimeKind.Local).AddTicks(3065), null, false, new DateTime(2023, 4, 7, 18, 41, 0, 23, DateTimeKind.Local).AddTicks(3762), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 27, 22, 18, 13, 582, DateTimeKind.Local).AddTicks(6654), null, false, new DateTime(2023, 2, 9, 14, 5, 6, 793, DateTimeKind.Local).AddTicks(2631), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 15, 18, 12, 21, 241, DateTimeKind.Local).AddTicks(350), null, false, new DateTime(2022, 6, 21, 21, 35, 21, 330, DateTimeKind.Local).AddTicks(9603), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 28, 22, 20, 16, 360, DateTimeKind.Local).AddTicks(3227), null, false, new DateTime(2022, 11, 1, 5, 36, 7, 746, DateTimeKind.Local).AddTicks(688), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 31, 16, 14, 43, 735, DateTimeKind.Local).AddTicks(38), null, false, new DateTime(2023, 2, 14, 1, 45, 26, 291, DateTimeKind.Local).AddTicks(691), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 13, 23, 30, 13, 894, DateTimeKind.Local).AddTicks(6772), null, false, new DateTime(2022, 8, 20, 21, 13, 16, 185, DateTimeKind.Local).AddTicks(2740), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 9, 9, 25, 43, 817, DateTimeKind.Local).AddTicks(8186), null, false, new DateTime(2022, 5, 15, 17, 4, 5, 872, DateTimeKind.Local).AddTicks(389), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 6, 2, 12, 20, 48, 372, DateTimeKind.Local).AddTicks(5592), null, false, new DateTime(2023, 3, 11, 1, 22, 2, 351, DateTimeKind.Local).AddTicks(6075), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 5, 23, 40, 3, 222, DateTimeKind.Local).AddTicks(7392), null, false, new DateTime(2023, 1, 23, 16, 43, 47, 335, DateTimeKind.Local).AddTicks(2655), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 26, 0, 41, 21, 596, DateTimeKind.Local).AddTicks(3563), null, false, new DateTime(2022, 12, 5, 4, 12, 58, 80, DateTimeKind.Local).AddTicks(209), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 4, 2, 1, 18, 48, 16, DateTimeKind.Local).AddTicks(3654), null, false, new DateTime(2022, 8, 6, 3, 46, 28, 679, DateTimeKind.Local).AddTicks(5545), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 17, 17, 24, 14, 229, DateTimeKind.Local).AddTicks(5407), null, false, new DateTime(2023, 1, 22, 2, 50, 57, 760, DateTimeKind.Local).AddTicks(2678), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 31, 20, 47, 18, 784, DateTimeKind.Local).AddTicks(3824), null, false, new DateTime(2022, 6, 4, 9, 19, 42, 494, DateTimeKind.Local).AddTicks(1186), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 5, 14, 44, 58, 38, DateTimeKind.Local).AddTicks(67), null, false, new DateTime(2023, 1, 2, 22, 13, 53, 322, DateTimeKind.Local).AddTicks(6998), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 14, 6, 38, 10, 702, DateTimeKind.Local).AddTicks(384), null, false, new DateTime(2023, 1, 13, 20, 40, 20, 969, DateTimeKind.Local).AddTicks(6454), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 18, 16, 55, 56, 879, DateTimeKind.Local).AddTicks(444), null, false, new DateTime(2023, 1, 12, 17, 14, 51, 420, DateTimeKind.Local).AddTicks(8295), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 28, 5, 55, 5, 34, DateTimeKind.Local).AddTicks(1161), null, false, new DateTime(2022, 11, 29, 11, 5, 19, 645, DateTimeKind.Local).AddTicks(2084), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 27, 4, 32, 19, 374, DateTimeKind.Local).AddTicks(3493), null, false, new DateTime(2022, 8, 23, 9, 25, 55, 608, DateTimeKind.Local).AddTicks(8005), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 8, 9, 25, 52, 161, DateTimeKind.Local).AddTicks(2672), null, false, new DateTime(2023, 2, 3, 21, 6, 35, 583, DateTimeKind.Local).AddTicks(8551), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 12, 1, 15, 35, 14, 548, DateTimeKind.Local).AddTicks(1732), null, false, new DateTime(2022, 6, 9, 8, 36, 8, 206, DateTimeKind.Local).AddTicks(5847), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 15, 2, 14, 4, 180, DateTimeKind.Local).AddTicks(6073), null, false, new DateTime(2022, 7, 30, 21, 33, 59, 684, DateTimeKind.Local).AddTicks(8241), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 27, 4, 18, 11, 995, DateTimeKind.Local).AddTicks(8642), null, false, new DateTime(2022, 12, 2, 2, 39, 26, 399, DateTimeKind.Local).AddTicks(2358), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 12, 15, 57, 13, 313, DateTimeKind.Local).AddTicks(4382), null, false, new DateTime(2023, 4, 13, 10, 1, 49, 662, DateTimeKind.Local).AddTicks(8853), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 19, 18, 23, 23, 761, DateTimeKind.Local).AddTicks(8318), null, false, new DateTime(2023, 3, 28, 11, 22, 9, 567, DateTimeKind.Local).AddTicks(2252), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 5, 19, 49, 37, 73, DateTimeKind.Local).AddTicks(1467), null, false, new DateTime(2023, 2, 6, 3, 52, 28, 717, DateTimeKind.Local).AddTicks(5860), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 3, 23, 25, 44, 290, DateTimeKind.Local).AddTicks(4104), null, false, new DateTime(2022, 11, 6, 23, 20, 19, 561, DateTimeKind.Local).AddTicks(4136), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 30, 20, 4, 16, 29, DateTimeKind.Local).AddTicks(9656), null, false, new DateTime(2022, 6, 27, 15, 50, 15, 391, DateTimeKind.Local).AddTicks(4019), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 14, 6, 55, 57, 427, DateTimeKind.Local).AddTicks(3551), null, false, new DateTime(2022, 7, 3, 16, 20, 10, 305, DateTimeKind.Local).AddTicks(7511), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 17, 22, 45, 19, 839, DateTimeKind.Local).AddTicks(8834), null, false, new DateTime(2022, 7, 20, 4, 24, 47, 415, DateTimeKind.Local).AddTicks(2765), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 21, 12, 33, 7, 639, DateTimeKind.Local).AddTicks(7964), null, false, new DateTime(2022, 11, 16, 23, 40, 39, 123, DateTimeKind.Local).AddTicks(1174), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 10, 22, 38, 25, 423, DateTimeKind.Local).AddTicks(7981), null, false, new DateTime(2022, 7, 5, 23, 9, 18, 178, DateTimeKind.Local).AddTicks(5056), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 16, 11, 21, 32, 261, DateTimeKind.Local).AddTicks(8949), null, false, new DateTime(2023, 1, 22, 23, 44, 58, 30, DateTimeKind.Local).AddTicks(8350), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 26, 16, 49, 16, 494, DateTimeKind.Local).AddTicks(137), null, false, new DateTime(2023, 1, 3, 14, 47, 12, 998, DateTimeKind.Local).AddTicks(5497), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 15, 17, 54, 34, 413, DateTimeKind.Local).AddTicks(1431), null, false, new DateTime(2022, 8, 16, 17, 2, 13, 483, DateTimeKind.Local).AddTicks(8902), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 28, 0, 36, 20, 390, DateTimeKind.Local).AddTicks(6746), null, false, new DateTime(2022, 7, 20, 0, 20, 50, 399, DateTimeKind.Local).AddTicks(9434), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 4, 8, 38, 25, 829, DateTimeKind.Local).AddTicks(2934), null, false, new DateTime(2022, 9, 7, 13, 52, 51, 339, DateTimeKind.Local).AddTicks(9704), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 18, 17, 33, 27, 903, DateTimeKind.Local).AddTicks(1126), null, false, new DateTime(2022, 6, 12, 2, 45, 46, 956, DateTimeKind.Local).AddTicks(3318), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 15, 13, 22, 37, 202, DateTimeKind.Local).AddTicks(7309), null, false, new DateTime(2022, 7, 9, 18, 4, 47, 580, DateTimeKind.Local).AddTicks(8738), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 13, 2, 48, 23, 892, DateTimeKind.Local).AddTicks(6855), null, false, new DateTime(2023, 2, 9, 12, 0, 54, 959, DateTimeKind.Local).AddTicks(8003), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 12, 8, 41, 37, 763, DateTimeKind.Local).AddTicks(580), null, true, new DateTime(2023, 3, 26, 7, 19, 33, 95, DateTimeKind.Local).AddTicks(182), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 29, 23, 52, 54, 413, DateTimeKind.Local).AddTicks(4913), null, false, new DateTime(2023, 3, 6, 14, 13, 47, 218, DateTimeKind.Local).AddTicks(1199), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 4, 5, 2, 16, 7, DateTimeKind.Local).AddTicks(2127), null, false, new DateTime(2022, 11, 9, 5, 44, 30, 200, DateTimeKind.Local).AddTicks(7509), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 22, 9, 14, 22, 655, DateTimeKind.Local).AddTicks(3717), null, false, new DateTime(2022, 10, 11, 5, 45, 35, 143, DateTimeKind.Local).AddTicks(9960), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 10, 3, 48, 55, 930, DateTimeKind.Local).AddTicks(9046), null, false, new DateTime(2023, 2, 12, 11, 5, 59, 205, DateTimeKind.Local).AddTicks(7800), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 5, 0, 56, 35, 327, DateTimeKind.Local).AddTicks(5315), null, false, new DateTime(2022, 6, 27, 3, 56, 46, 740, DateTimeKind.Local).AddTicks(7520), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 21, 22, 46, 14, 965, DateTimeKind.Local).AddTicks(9673), null, false, new DateTime(2023, 3, 16, 1, 14, 48, 228, DateTimeKind.Local).AddTicks(262), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 24, 15, 38, 27, 768, DateTimeKind.Local).AddTicks(5476), null, false, new DateTime(2022, 11, 9, 23, 49, 30, 810, DateTimeKind.Local).AddTicks(804), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 11, 11, 50, 46, 934, DateTimeKind.Local).AddTicks(8576), null, false, new DateTime(2022, 5, 14, 18, 11, 31, 745, DateTimeKind.Local).AddTicks(5780), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 23, 7, 20, 31, 402, DateTimeKind.Local).AddTicks(5709), null, false, new DateTime(2022, 12, 14, 14, 11, 51, 73, DateTimeKind.Local).AddTicks(3055), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 13, 21, 8, 27, 793, DateTimeKind.Local).AddTicks(4607), null, true, new DateTime(2022, 9, 3, 10, 55, 51, 804, DateTimeKind.Local).AddTicks(7195), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 4, 6, 31, 32, 568, DateTimeKind.Local).AddTicks(1464), null, true, new DateTime(2022, 6, 18, 0, 15, 20, 307, DateTimeKind.Local).AddTicks(2260), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 15, 5, 51, 54, 225, DateTimeKind.Local).AddTicks(3101), null, false, new DateTime(2022, 5, 13, 18, 41, 58, 803, DateTimeKind.Local).AddTicks(9658), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY", "Total" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 30, 3, 56, 6, 169, DateTimeKind.Local).AddTicks(14), new DateTime(2022, 7, 10, 23, 41, 47, 377, DateTimeKind.Local).AddTicks(3754), 25, -1337272733, null },
                    { 2, 65, new DateTime(2022, 12, 10, 9, 10, 29, 400, DateTimeKind.Local).AddTicks(5649), new DateTime(2022, 5, 9, 2, 42, 54, 229, DateTimeKind.Local).AddTicks(5685), 66, 1389080346, null },
                    { 3, 97, new DateTime(2023, 4, 8, 4, 5, 24, 443, DateTimeKind.Local).AddTicks(8003), new DateTime(2023, 1, 18, 2, 12, 47, 836, DateTimeKind.Local).AddTicks(1085), 11, -1764101450, null },
                    { 4, 149, new DateTime(2022, 8, 12, 15, 33, 0, 292, DateTimeKind.Local).AddTicks(9902), new DateTime(2022, 8, 22, 14, 7, 50, 564, DateTimeKind.Local).AddTicks(3165), 33, 1373200915, null },
                    { 5, 93, new DateTime(2022, 8, 4, 13, 42, 18, 543, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 8, 5, 11, 12, 35, 13, DateTimeKind.Local).AddTicks(1827), 29, -2137135493, null },
                    { 6, 15, new DateTime(2023, 2, 18, 21, 24, 5, 960, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 11, 30, 4, 52, 55, 62, DateTimeKind.Local).AddTicks(9452), 95, -355409670, null },
                    { 7, 26, new DateTime(2022, 7, 2, 21, 24, 14, 644, DateTimeKind.Local).AddTicks(754), new DateTime(2022, 12, 27, 11, 37, 45, 123, DateTimeKind.Local).AddTicks(7642), 80, -1452856077, null },
                    { 8, 133, new DateTime(2022, 9, 27, 13, 44, 25, 137, DateTimeKind.Local).AddTicks(9474), new DateTime(2022, 7, 31, 0, 21, 31, 314, DateTimeKind.Local).AddTicks(1693), 83, -1608881218, null },
                    { 9, 3, new DateTime(2022, 4, 21, 14, 6, 50, 391, DateTimeKind.Local).AddTicks(4855), new DateTime(2022, 6, 28, 7, 44, 47, 558, DateTimeKind.Local).AddTicks(4168), 70, 141688913, null },
                    { 10, 10, new DateTime(2022, 10, 12, 20, 51, 33, 555, DateTimeKind.Local).AddTicks(5809), new DateTime(2022, 10, 8, 21, 41, 10, 978, DateTimeKind.Local).AddTicks(4995), 86, -846084430, null },
                    { 11, 150, new DateTime(2022, 8, 9, 8, 52, 25, 735, DateTimeKind.Local).AddTicks(4038), new DateTime(2022, 11, 28, 12, 11, 49, 59, DateTimeKind.Local).AddTicks(6972), 28, -1703184439, null },
                    { 12, 102, new DateTime(2022, 8, 14, 9, 5, 6, 508, DateTimeKind.Local).AddTicks(3906), new DateTime(2022, 10, 28, 0, 33, 58, 978, DateTimeKind.Local).AddTicks(4808), 44, 530525523, null },
                    { 13, 54, new DateTime(2022, 10, 8, 12, 58, 31, 517, DateTimeKind.Local).AddTicks(5285), new DateTime(2023, 2, 15, 18, 45, 56, 49, DateTimeKind.Local).AddTicks(4173), 25, -59573067, null },
                    { 14, 104, new DateTime(2022, 11, 25, 9, 29, 42, 174, DateTimeKind.Local).AddTicks(8622), new DateTime(2023, 2, 20, 22, 41, 41, 625, DateTimeKind.Local).AddTicks(828), 35, 1696681132, null },
                    { 15, 13, new DateTime(2022, 4, 28, 5, 43, 5, 957, DateTimeKind.Local).AddTicks(7972), new DateTime(2022, 10, 22, 11, 36, 55, 275, DateTimeKind.Local).AddTicks(4084), 95, 1449428124, null },
                    { 16, 8, new DateTime(2023, 3, 5, 12, 26, 38, 806, DateTimeKind.Local).AddTicks(2810), new DateTime(2023, 1, 30, 5, 19, 39, 522, DateTimeKind.Local).AddTicks(4978), 64, 803978739, null },
                    { 17, 47, new DateTime(2022, 9, 30, 8, 2, 41, 199, DateTimeKind.Local).AddTicks(4411), new DateTime(2022, 12, 27, 18, 2, 45, 658, DateTimeKind.Local).AddTicks(3221), 9, -528110470, null },
                    { 18, 132, new DateTime(2022, 7, 2, 0, 43, 28, 705, DateTimeKind.Local).AddTicks(714), new DateTime(2023, 1, 28, 5, 46, 11, 14, DateTimeKind.Local).AddTicks(9353), 100, -1898326498, null },
                    { 19, 27, new DateTime(2022, 11, 13, 1, 9, 29, 206, DateTimeKind.Local).AddTicks(2450), new DateTime(2022, 5, 4, 16, 32, 43, 560, DateTimeKind.Local).AddTicks(4462), 11, -630109864, null },
                    { 20, 117, new DateTime(2022, 5, 7, 17, 38, 49, 805, DateTimeKind.Local).AddTicks(8441), new DateTime(2023, 3, 4, 21, 28, 45, 186, DateTimeKind.Local).AddTicks(5862), 41, -630091847, null },
                    { 21, 49, new DateTime(2023, 3, 26, 17, 36, 48, 408, DateTimeKind.Local).AddTicks(9581), new DateTime(2022, 10, 29, 5, 44, 25, 304, DateTimeKind.Local).AddTicks(8709), 50, 502251148, null },
                    { 22, 59, new DateTime(2022, 12, 4, 12, 28, 4, 560, DateTimeKind.Local).AddTicks(4812), new DateTime(2023, 4, 15, 20, 21, 54, 7, DateTimeKind.Local).AddTicks(161), 37, 1719647288, null },
                    { 23, 126, new DateTime(2022, 6, 10, 0, 19, 0, 614, DateTimeKind.Local).AddTicks(2274), new DateTime(2022, 7, 10, 5, 18, 5, 722, DateTimeKind.Local).AddTicks(6944), 62, 2114081724, null },
                    { 24, 4, new DateTime(2022, 5, 30, 3, 19, 2, 767, DateTimeKind.Local).AddTicks(7525), new DateTime(2023, 1, 26, 3, 27, 16, 499, DateTimeKind.Local).AddTicks(6555), 9, 143225969, null },
                    { 25, 72, new DateTime(2022, 12, 29, 22, 53, 57, 621, DateTimeKind.Local).AddTicks(1460), new DateTime(2023, 3, 4, 22, 27, 7, 96, DateTimeKind.Local).AddTicks(9903), 88, -165493103, null },
                    { 26, 56, new DateTime(2022, 10, 27, 6, 5, 31, 170, DateTimeKind.Local).AddTicks(294), new DateTime(2022, 12, 5, 1, 9, 38, 949, DateTimeKind.Local).AddTicks(7544), 13, -678191729, null },
                    { 27, 46, new DateTime(2023, 3, 24, 15, 6, 38, 966, DateTimeKind.Local).AddTicks(7412), new DateTime(2023, 2, 16, 10, 49, 14, 157, DateTimeKind.Local).AddTicks(8100), 56, -1723187146, null },
                    { 28, 66, new DateTime(2022, 7, 17, 18, 42, 11, 516, DateTimeKind.Local).AddTicks(5978), new DateTime(2023, 2, 13, 13, 10, 25, 12, DateTimeKind.Local).AddTicks(5329), 27, 1818365903, null },
                    { 29, 128, new DateTime(2022, 4, 20, 2, 17, 2, 954, DateTimeKind.Local).AddTicks(7011), new DateTime(2022, 12, 23, 12, 28, 47, 514, DateTimeKind.Local).AddTicks(6735), 14, 804730158, null },
                    { 30, 98, new DateTime(2022, 6, 10, 16, 49, 39, 502, DateTimeKind.Local).AddTicks(8886), new DateTime(2022, 8, 6, 9, 16, 17, 319, DateTimeKind.Local).AddTicks(5431), 99, -744448570, null },
                    { 31, 82, new DateTime(2022, 8, 10, 11, 51, 16, 664, DateTimeKind.Local).AddTicks(8838), new DateTime(2023, 2, 18, 18, 0, 14, 11, DateTimeKind.Local).AddTicks(5675), 95, 1010195859, null },
                    { 32, 4, new DateTime(2023, 3, 1, 16, 4, 6, 855, DateTimeKind.Local).AddTicks(7524), new DateTime(2023, 3, 22, 9, 21, 33, 772, DateTimeKind.Local).AddTicks(237), 2, 1249591921, null },
                    { 33, 31, new DateTime(2023, 3, 19, 7, 41, 49, 89, DateTimeKind.Local).AddTicks(7778), new DateTime(2022, 5, 15, 15, 23, 38, 865, DateTimeKind.Local).AddTicks(1003), 30, -880112326, null },
                    { 34, 124, new DateTime(2022, 4, 20, 3, 7, 40, 214, DateTimeKind.Local).AddTicks(344), new DateTime(2023, 3, 5, 9, 14, 26, 440, DateTimeKind.Local).AddTicks(1658), 48, 837858802, null },
                    { 35, 105, new DateTime(2022, 5, 20, 16, 2, 13, 952, DateTimeKind.Local).AddTicks(5265), new DateTime(2023, 3, 29, 20, 14, 34, 486, DateTimeKind.Local).AddTicks(5444), 85, -1379602796, null },
                    { 36, 31, new DateTime(2022, 7, 20, 17, 49, 20, 644, DateTimeKind.Local).AddTicks(6083), new DateTime(2023, 2, 12, 4, 11, 25, 348, DateTimeKind.Local).AddTicks(5518), 32, -1073917011, null },
                    { 37, 103, new DateTime(2022, 8, 29, 8, 56, 49, 452, DateTimeKind.Local).AddTicks(9830), new DateTime(2023, 1, 21, 20, 24, 38, 357, DateTimeKind.Local).AddTicks(5022), 9, -69851984, null },
                    { 38, 86, new DateTime(2023, 1, 20, 8, 34, 25, 662, DateTimeKind.Local).AddTicks(3244), new DateTime(2023, 1, 27, 17, 5, 35, 938, DateTimeKind.Local).AddTicks(7900), 4, 107055918, null },
                    { 39, 91, new DateTime(2023, 2, 11, 16, 14, 23, 558, DateTimeKind.Local).AddTicks(3512), new DateTime(2022, 9, 16, 21, 37, 12, 749, DateTimeKind.Local).AddTicks(6599), 63, 477802140, null },
                    { 40, 48, new DateTime(2022, 12, 12, 2, 43, 31, 859, DateTimeKind.Local).AddTicks(9180), new DateTime(2022, 10, 5, 9, 13, 43, 339, DateTimeKind.Local).AddTicks(5021), 69, -1537447450, null },
                    { 41, 150, new DateTime(2022, 6, 3, 7, 10, 14, 390, DateTimeKind.Local).AddTicks(6699), new DateTime(2023, 3, 27, 19, 47, 15, 625, DateTimeKind.Local).AddTicks(3541), 18, 1198649752, null },
                    { 42, 125, new DateTime(2022, 8, 5, 11, 55, 10, 763, DateTimeKind.Local).AddTicks(49), new DateTime(2022, 12, 25, 16, 6, 28, 530, DateTimeKind.Local).AddTicks(3948), 36, 1073486245, null },
                    { 43, 132, new DateTime(2022, 10, 28, 6, 47, 8, 49, DateTimeKind.Local).AddTicks(6096), new DateTime(2023, 1, 2, 17, 22, 36, 347, DateTimeKind.Local).AddTicks(6659), 86, 280938381, null },
                    { 44, 121, new DateTime(2022, 11, 30, 14, 27, 32, 228, DateTimeKind.Local).AddTicks(2539), new DateTime(2022, 7, 22, 19, 30, 48, 105, DateTimeKind.Local).AddTicks(5077), 74, -1712618255, null },
                    { 45, 77, new DateTime(2023, 3, 21, 6, 20, 21, 792, DateTimeKind.Local).AddTicks(2607), new DateTime(2022, 12, 16, 2, 14, 26, 457, DateTimeKind.Local).AddTicks(6831), 80, 1590315826, null },
                    { 46, 135, new DateTime(2023, 4, 2, 11, 27, 3, 477, DateTimeKind.Local).AddTicks(495), new DateTime(2022, 7, 28, 3, 45, 39, 483, DateTimeKind.Local).AddTicks(6035), 39, 1298578173, null },
                    { 47, 130, new DateTime(2022, 12, 28, 13, 43, 37, 185, DateTimeKind.Local).AddTicks(5788), new DateTime(2022, 6, 4, 2, 34, 28, 917, DateTimeKind.Local).AddTicks(4686), 97, -1110831119, null },
                    { 48, 62, new DateTime(2022, 11, 9, 15, 6, 27, 285, DateTimeKind.Local).AddTicks(4837), new DateTime(2022, 10, 6, 8, 33, 17, 276, DateTimeKind.Local).AddTicks(1503), 65, 836985327, null },
                    { 49, 57, new DateTime(2022, 6, 1, 14, 9, 25, 870, DateTimeKind.Local).AddTicks(2053), new DateTime(2022, 12, 21, 4, 0, 34, 866, DateTimeKind.Local).AddTicks(1217), 35, 1039002661, null },
                    { 50, 103, new DateTime(2022, 6, 22, 3, 59, 20, 854, DateTimeKind.Local).AddTicks(4139), new DateTime(2023, 1, 14, 23, 18, 14, 537, DateTimeKind.Local).AddTicks(3606), 33, -940048352, null },
                    { 51, 49, new DateTime(2022, 11, 30, 0, 21, 2, 830, DateTimeKind.Local).AddTicks(8246), new DateTime(2023, 2, 20, 19, 48, 48, 749, DateTimeKind.Local).AddTicks(9915), 98, -728332894, null },
                    { 52, 143, new DateTime(2022, 10, 24, 11, 28, 41, 420, DateTimeKind.Local).AddTicks(4044), new DateTime(2022, 6, 22, 20, 1, 51, 632, DateTimeKind.Local).AddTicks(7313), 10, -986989588, null },
                    { 53, 67, new DateTime(2022, 7, 4, 12, 48, 51, 232, DateTimeKind.Local).AddTicks(3398), new DateTime(2023, 2, 14, 1, 25, 2, 807, DateTimeKind.Local).AddTicks(9090), 23, -2061893690, null },
                    { 54, 2, new DateTime(2023, 2, 23, 7, 48, 14, 840, DateTimeKind.Local).AddTicks(6037), new DateTime(2023, 1, 6, 1, 22, 35, 87, DateTimeKind.Local).AddTicks(6494), 24, 44038267, null },
                    { 55, 23, new DateTime(2023, 3, 13, 15, 42, 33, 611, DateTimeKind.Local).AddTicks(5833), new DateTime(2022, 10, 20, 0, 32, 46, 312, DateTimeKind.Local).AddTicks(7119), 95, -1734569507, null },
                    { 56, 125, new DateTime(2022, 8, 17, 22, 12, 14, 410, DateTimeKind.Local).AddTicks(3853), new DateTime(2022, 11, 7, 5, 30, 3, 31, DateTimeKind.Local).AddTicks(8664), 53, -138009315, null },
                    { 57, 141, new DateTime(2022, 5, 8, 12, 42, 3, 778, DateTimeKind.Local).AddTicks(8720), new DateTime(2022, 12, 7, 13, 45, 18, 874, DateTimeKind.Local).AddTicks(9258), 44, 372534904, null },
                    { 58, 9, new DateTime(2022, 11, 19, 10, 5, 17, 123, DateTimeKind.Local).AddTicks(9970), new DateTime(2023, 3, 9, 1, 43, 11, 467, DateTimeKind.Local).AddTicks(6319), 93, 1909599698, null },
                    { 59, 124, new DateTime(2022, 12, 8, 12, 4, 6, 649, DateTimeKind.Local).AddTicks(4828), new DateTime(2023, 3, 26, 23, 32, 2, 545, DateTimeKind.Local).AddTicks(8771), 69, 79532390, null },
                    { 60, 134, new DateTime(2022, 9, 1, 4, 45, 37, 310, DateTimeKind.Local).AddTicks(6220), new DateTime(2023, 4, 15, 3, 49, 47, 668, DateTimeKind.Local).AddTicks(6807), 52, 1604605885, null },
                    { 61, 73, new DateTime(2022, 8, 23, 12, 27, 25, 874, DateTimeKind.Local).AddTicks(6062), new DateTime(2023, 2, 3, 12, 7, 33, 636, DateTimeKind.Local).AddTicks(7356), 38, -1676722438, null },
                    { 62, 40, new DateTime(2022, 12, 31, 11, 51, 26, 940, DateTimeKind.Local).AddTicks(4305), new DateTime(2022, 12, 17, 19, 8, 22, 136, DateTimeKind.Local).AddTicks(1302), 63, 621380446, null },
                    { 63, 90, new DateTime(2022, 12, 2, 18, 45, 38, 178, DateTimeKind.Local).AddTicks(9341), new DateTime(2023, 2, 12, 20, 57, 51, 44, DateTimeKind.Local).AddTicks(168), 23, 311456010, null },
                    { 64, 50, new DateTime(2022, 7, 24, 18, 46, 24, 101, DateTimeKind.Local).AddTicks(9212), new DateTime(2023, 2, 22, 19, 46, 32, 932, DateTimeKind.Local).AddTicks(2379), 59, -1053387962, null },
                    { 65, 141, new DateTime(2022, 7, 30, 2, 55, 44, 551, DateTimeKind.Local).AddTicks(4141), new DateTime(2023, 2, 20, 15, 43, 6, 369, DateTimeKind.Local).AddTicks(934), 66, 986634324, null },
                    { 66, 19, new DateTime(2022, 5, 24, 22, 39, 17, 517, DateTimeKind.Local).AddTicks(651), new DateTime(2023, 2, 17, 18, 37, 0, 650, DateTimeKind.Local).AddTicks(3029), 1, -1542007635, null },
                    { 67, 102, new DateTime(2022, 10, 22, 6, 47, 37, 376, DateTimeKind.Local).AddTicks(4624), new DateTime(2022, 11, 18, 4, 36, 38, 50, DateTimeKind.Local).AddTicks(3900), 3, 408278181, null },
                    { 68, 14, new DateTime(2022, 7, 11, 15, 7, 14, 450, DateTimeKind.Local).AddTicks(6938), new DateTime(2023, 3, 27, 8, 33, 36, 929, DateTimeKind.Local).AddTicks(7011), 66, -309710895, null },
                    { 69, 14, new DateTime(2023, 3, 7, 6, 28, 19, 612, DateTimeKind.Local).AddTicks(5971), new DateTime(2023, 4, 4, 1, 46, 59, 852, DateTimeKind.Local).AddTicks(1648), 53, -1853067144, null },
                    { 70, 70, new DateTime(2022, 6, 21, 21, 51, 31, 830, DateTimeKind.Local).AddTicks(2990), new DateTime(2023, 2, 14, 18, 8, 34, 690, DateTimeKind.Local).AddTicks(5802), 18, 112712641, null },
                    { 71, 92, new DateTime(2023, 2, 28, 23, 48, 8, 132, DateTimeKind.Local).AddTicks(9708), new DateTime(2022, 12, 21, 23, 32, 38, 302, DateTimeKind.Local).AddTicks(6892), 65, -1832007297, null },
                    { 72, 36, new DateTime(2022, 10, 9, 4, 26, 45, 90, DateTimeKind.Local).AddTicks(4252), new DateTime(2022, 12, 9, 6, 7, 45, 859, DateTimeKind.Local).AddTicks(3247), 69, 851853832, null },
                    { 73, 32, new DateTime(2022, 11, 21, 13, 57, 1, 64, DateTimeKind.Local).AddTicks(1371), new DateTime(2022, 9, 21, 6, 21, 15, 807, DateTimeKind.Local).AddTicks(5785), 9, 1600283062, null },
                    { 74, 71, new DateTime(2023, 4, 17, 10, 23, 7, 163, DateTimeKind.Local).AddTicks(3558), new DateTime(2023, 1, 14, 11, 17, 59, 124, DateTimeKind.Local).AddTicks(2184), 17, 1727277631, null },
                    { 75, 74, new DateTime(2023, 2, 14, 10, 32, 20, 338, DateTimeKind.Local).AddTicks(3493), new DateTime(2022, 5, 9, 11, 29, 46, 406, DateTimeKind.Local).AddTicks(4429), 59, -442477273, null },
                    { 76, 133, new DateTime(2022, 8, 12, 15, 46, 28, 413, DateTimeKind.Local).AddTicks(8371), new DateTime(2023, 2, 25, 20, 37, 53, 416, DateTimeKind.Local).AddTicks(8133), 78, -1985772486, null },
                    { 77, 48, new DateTime(2022, 8, 22, 7, 21, 58, 478, DateTimeKind.Local).AddTicks(301), new DateTime(2022, 10, 19, 0, 20, 35, 403, DateTimeKind.Local).AddTicks(8900), 83, 832518537, null },
                    { 78, 105, new DateTime(2022, 4, 28, 7, 56, 21, 991, DateTimeKind.Local).AddTicks(7643), new DateTime(2023, 2, 7, 14, 27, 15, 677, DateTimeKind.Local).AddTicks(6776), 22, -526221446, null },
                    { 79, 83, new DateTime(2022, 10, 13, 14, 23, 47, 566, DateTimeKind.Local).AddTicks(5160), new DateTime(2022, 11, 25, 14, 49, 53, 832, DateTimeKind.Local).AddTicks(1716), 12, -1415988118, null },
                    { 80, 87, new DateTime(2022, 10, 24, 11, 58, 46, 497, DateTimeKind.Local).AddTicks(5545), new DateTime(2022, 7, 2, 3, 24, 42, 187, DateTimeKind.Local).AddTicks(9959), 99, 225944964, null },
                    { 81, 20, new DateTime(2022, 12, 20, 1, 23, 59, 927, DateTimeKind.Local).AddTicks(8594), new DateTime(2022, 11, 8, 2, 1, 14, 974, DateTimeKind.Local).AddTicks(6393), 16, -6781757, null },
                    { 82, 30, new DateTime(2022, 5, 28, 4, 54, 11, 784, DateTimeKind.Local).AddTicks(5043), new DateTime(2023, 3, 31, 15, 30, 16, 594, DateTimeKind.Local).AddTicks(504), 69, -1136407769, null },
                    { 83, 129, new DateTime(2022, 11, 2, 15, 47, 36, 846, DateTimeKind.Local).AddTicks(8317), new DateTime(2022, 8, 10, 8, 56, 40, 685, DateTimeKind.Local).AddTicks(7672), 9, 1608728079, null },
                    { 84, 133, new DateTime(2022, 11, 24, 20, 17, 52, 619, DateTimeKind.Local).AddTicks(9196), new DateTime(2022, 7, 14, 9, 1, 24, 882, DateTimeKind.Local).AddTicks(1351), 30, 388271281, null },
                    { 85, 149, new DateTime(2022, 10, 20, 10, 56, 7, 1, DateTimeKind.Local).AddTicks(2778), new DateTime(2022, 12, 5, 11, 23, 7, 873, DateTimeKind.Local).AddTicks(1147), 93, 382806028, null },
                    { 86, 5, new DateTime(2023, 2, 24, 18, 12, 35, 960, DateTimeKind.Local).AddTicks(6693), new DateTime(2022, 11, 26, 1, 10, 8, 842, DateTimeKind.Local).AddTicks(3750), 58, -1753429261, null },
                    { 87, 33, new DateTime(2022, 11, 1, 18, 24, 52, 869, DateTimeKind.Local).AddTicks(3674), new DateTime(2022, 9, 3, 9, 49, 10, 253, DateTimeKind.Local).AddTicks(9650), 24, -1274761148, null },
                    { 88, 92, new DateTime(2023, 1, 9, 22, 25, 49, 742, DateTimeKind.Local).AddTicks(1576), new DateTime(2023, 4, 17, 1, 49, 38, 760, DateTimeKind.Local).AddTicks(5641), 97, -981975056, null },
                    { 89, 57, new DateTime(2022, 7, 4, 13, 53, 56, 762, DateTimeKind.Local).AddTicks(6057), new DateTime(2022, 8, 26, 12, 7, 45, 523, DateTimeKind.Local).AddTicks(1316), 1, -654309673, null },
                    { 90, 36, new DateTime(2022, 11, 1, 11, 21, 47, 216, DateTimeKind.Local).AddTicks(6683), new DateTime(2022, 8, 30, 18, 47, 27, 627, DateTimeKind.Local).AddTicks(9060), 56, -69778839, null },
                    { 91, 91, new DateTime(2022, 11, 19, 7, 54, 1, 654, DateTimeKind.Local).AddTicks(7866), new DateTime(2022, 12, 10, 7, 41, 44, 379, DateTimeKind.Local).AddTicks(8880), 43, 1486006419, null },
                    { 92, 43, new DateTime(2022, 5, 24, 23, 58, 0, 272, DateTimeKind.Local).AddTicks(8192), new DateTime(2023, 1, 23, 16, 31, 32, 483, DateTimeKind.Local).AddTicks(9672), 24, -1988336947, null },
                    { 93, 113, new DateTime(2022, 10, 30, 22, 5, 45, 633, DateTimeKind.Local).AddTicks(7076), new DateTime(2022, 4, 20, 0, 38, 49, 635, DateTimeKind.Local).AddTicks(5170), 16, -162616148, null },
                    { 94, 18, new DateTime(2023, 1, 29, 6, 42, 19, 616, DateTimeKind.Local).AddTicks(4854), new DateTime(2023, 3, 3, 8, 26, 34, 926, DateTimeKind.Local).AddTicks(9167), 9, 1708620453, null },
                    { 95, 141, new DateTime(2023, 2, 2, 2, 43, 8, 279, DateTimeKind.Local).AddTicks(5970), new DateTime(2022, 10, 30, 0, 43, 15, 783, DateTimeKind.Local).AddTicks(3016), 99, 1976118365, null },
                    { 96, 41, new DateTime(2023, 3, 17, 1, 54, 38, 249, DateTimeKind.Local).AddTicks(4747), new DateTime(2022, 10, 26, 11, 50, 15, 387, DateTimeKind.Local).AddTicks(5365), 74, -605196516, null },
                    { 97, 68, new DateTime(2022, 8, 12, 12, 8, 6, 989, DateTimeKind.Local).AddTicks(4504), new DateTime(2022, 5, 19, 22, 18, 32, 224, DateTimeKind.Local).AddTicks(1238), 59, 478281589, null },
                    { 98, 113, new DateTime(2023, 2, 1, 12, 13, 40, 950, DateTimeKind.Local).AddTicks(3842), new DateTime(2022, 8, 9, 17, 55, 49, 728, DateTimeKind.Local).AddTicks(8860), 10, -1773308872, null },
                    { 99, 130, new DateTime(2022, 5, 8, 15, 8, 23, 438, DateTimeKind.Local).AddTicks(8155), new DateTime(2022, 4, 28, 19, 47, 35, 657, DateTimeKind.Local).AddTicks(1520), 54, -1831083364, null },
                    { 100, 119, new DateTime(2023, 2, 20, 9, 1, 26, 469, DateTimeKind.Local).AddTicks(8753), new DateTime(2022, 5, 6, 15, 15, 20, 358, DateTimeKind.Local).AddTicks(6641), 62, -1205884399, null },
                    { 101, 35, new DateTime(2022, 10, 28, 6, 22, 58, 43, DateTimeKind.Local).AddTicks(4741), new DateTime(2023, 1, 31, 23, 10, 10, 629, DateTimeKind.Local).AddTicks(8149), 32, -1999162121, null },
                    { 102, 42, new DateTime(2022, 5, 17, 22, 42, 11, 577, DateTimeKind.Local).AddTicks(8883), new DateTime(2022, 5, 28, 11, 9, 50, 41, DateTimeKind.Local).AddTicks(4949), 15, 2086987625, null },
                    { 103, 100, new DateTime(2022, 8, 21, 14, 43, 34, 997, DateTimeKind.Local).AddTicks(845), new DateTime(2022, 9, 4, 11, 30, 47, 815, DateTimeKind.Local).AddTicks(8856), 16, 892669723, null },
                    { 104, 149, new DateTime(2022, 5, 26, 13, 29, 26, 884, DateTimeKind.Local).AddTicks(5780), new DateTime(2023, 2, 21, 16, 6, 37, 873, DateTimeKind.Local).AddTicks(3802), 4, -1179503519, null },
                    { 105, 141, new DateTime(2022, 7, 12, 20, 0, 18, 664, DateTimeKind.Local).AddTicks(853), new DateTime(2022, 7, 6, 17, 7, 39, 255, DateTimeKind.Local).AddTicks(8570), 52, 1183511533, null },
                    { 106, 148, new DateTime(2023, 2, 26, 5, 6, 48, 853, DateTimeKind.Local).AddTicks(1341), new DateTime(2022, 11, 24, 10, 13, 0, 83, DateTimeKind.Local).AddTicks(3295), 61, -865562271, null },
                    { 107, 117, new DateTime(2022, 10, 30, 17, 53, 27, 166, DateTimeKind.Local).AddTicks(4437), new DateTime(2023, 1, 27, 1, 55, 42, 778, DateTimeKind.Local).AddTicks(9319), 55, -2044643161, null },
                    { 108, 37, new DateTime(2022, 10, 13, 21, 17, 31, 925, DateTimeKind.Local).AddTicks(5827), new DateTime(2023, 2, 6, 1, 50, 13, 914, DateTimeKind.Local).AddTicks(8950), 17, 2003660847, null },
                    { 109, 39, new DateTime(2023, 2, 21, 10, 14, 35, 700, DateTimeKind.Local).AddTicks(745), new DateTime(2022, 10, 14, 18, 21, 35, 327, DateTimeKind.Local).AddTicks(5582), 78, 1983332400, null },
                    { 110, 132, new DateTime(2022, 12, 17, 23, 25, 52, 720, DateTimeKind.Local).AddTicks(4717), new DateTime(2022, 12, 25, 4, 51, 20, 578, DateTimeKind.Local).AddTicks(7935), 80, 882634759, null },
                    { 111, 119, new DateTime(2022, 7, 17, 6, 56, 18, 720, DateTimeKind.Local).AddTicks(6664), new DateTime(2022, 11, 12, 20, 54, 16, 764, DateTimeKind.Local).AddTicks(7768), 54, 284135042, null },
                    { 112, 89, new DateTime(2022, 8, 21, 15, 56, 49, 599, DateTimeKind.Local).AddTicks(6945), new DateTime(2022, 10, 4, 11, 3, 46, 5, DateTimeKind.Local).AddTicks(3406), 10, -1891885805, null },
                    { 113, 119, new DateTime(2022, 11, 3, 14, 53, 37, 53, DateTimeKind.Local).AddTicks(552), new DateTime(2022, 8, 13, 6, 2, 11, 703, DateTimeKind.Local).AddTicks(7192), 97, -704601078, null },
                    { 114, 57, new DateTime(2022, 12, 12, 13, 26, 51, 72, DateTimeKind.Local).AddTicks(5205), new DateTime(2022, 12, 20, 3, 46, 7, 4, DateTimeKind.Local).AddTicks(1681), 3, 323261471, null },
                    { 115, 12, new DateTime(2022, 8, 17, 15, 4, 33, 926, DateTimeKind.Local).AddTicks(2201), new DateTime(2022, 12, 4, 23, 11, 21, 731, DateTimeKind.Local).AddTicks(8809), 9, -474430538, null },
                    { 116, 105, new DateTime(2022, 7, 29, 10, 45, 39, 886, DateTimeKind.Local).AddTicks(2713), new DateTime(2022, 5, 19, 19, 24, 24, 513, DateTimeKind.Local).AddTicks(7630), 81, 1694194762, null },
                    { 117, 70, new DateTime(2022, 6, 15, 5, 21, 28, 230, DateTimeKind.Local).AddTicks(6759), new DateTime(2022, 7, 9, 5, 28, 7, 177, DateTimeKind.Local).AddTicks(8988), 16, -818830841, null },
                    { 118, 59, new DateTime(2022, 12, 9, 12, 27, 39, 416, DateTimeKind.Local).AddTicks(7165), new DateTime(2022, 8, 28, 17, 6, 25, 954, DateTimeKind.Local).AddTicks(818), 84, 1697476685, null },
                    { 119, 68, new DateTime(2023, 1, 17, 10, 54, 57, 777, DateTimeKind.Local).AddTicks(8817), new DateTime(2022, 6, 26, 15, 47, 7, 307, DateTimeKind.Local).AddTicks(8342), 61, -2002192684, null },
                    { 120, 107, new DateTime(2022, 12, 29, 1, 49, 33, 14, DateTimeKind.Local).AddTicks(288), new DateTime(2022, 5, 5, 22, 19, 38, 538, DateTimeKind.Local).AddTicks(7435), 24, -372284776, null },
                    { 121, 140, new DateTime(2023, 1, 14, 8, 19, 35, 320, DateTimeKind.Local).AddTicks(5395), new DateTime(2022, 12, 1, 16, 19, 19, 559, DateTimeKind.Local).AddTicks(4371), 12, -1820663864, null },
                    { 122, 125, new DateTime(2023, 2, 14, 20, 22, 46, 28, DateTimeKind.Local).AddTicks(5991), new DateTime(2022, 11, 22, 5, 12, 27, 340, DateTimeKind.Local).AddTicks(8415), 80, 1496096118, null },
                    { 123, 124, new DateTime(2022, 11, 15, 6, 38, 8, 825, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 7, 28, 22, 25, 55, 466, DateTimeKind.Local).AddTicks(1738), 91, -176590715, null },
                    { 124, 145, new DateTime(2022, 10, 16, 10, 0, 52, 668, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 6, 17, 0, 23, 7, 648, DateTimeKind.Local).AddTicks(6752), 22, 1605378695, null },
                    { 125, 126, new DateTime(2023, 1, 6, 21, 47, 31, 885, DateTimeKind.Local).AddTicks(669), new DateTime(2022, 8, 30, 10, 27, 0, 956, DateTimeKind.Local).AddTicks(7687), 8, 437761179, null },
                    { 126, 133, new DateTime(2022, 8, 6, 19, 42, 55, 302, DateTimeKind.Local).AddTicks(4437), new DateTime(2022, 9, 19, 13, 25, 10, 871, DateTimeKind.Local).AddTicks(314), 75, -1947436685, null },
                    { 127, 123, new DateTime(2023, 3, 20, 18, 27, 23, 187, DateTimeKind.Local).AddTicks(3350), new DateTime(2022, 9, 22, 5, 15, 24, 770, DateTimeKind.Local).AddTicks(6641), 44, -286774052, null },
                    { 128, 81, new DateTime(2023, 3, 14, 18, 6, 2, 706, DateTimeKind.Local).AddTicks(5322), new DateTime(2022, 12, 2, 18, 27, 49, 383, DateTimeKind.Local).AddTicks(1712), 13, -522626206, null },
                    { 129, 108, new DateTime(2023, 1, 16, 20, 1, 20, 457, DateTimeKind.Local).AddTicks(1456), new DateTime(2022, 6, 1, 2, 57, 41, 718, DateTimeKind.Local).AddTicks(3587), 78, -2074907726, null },
                    { 130, 52, new DateTime(2023, 3, 4, 8, 26, 22, 637, DateTimeKind.Local).AddTicks(8752), new DateTime(2022, 12, 22, 22, 48, 19, 627, DateTimeKind.Local).AddTicks(5107), 44, -907300075, null },
                    { 131, 66, new DateTime(2022, 6, 5, 16, 30, 15, 359, DateTimeKind.Local).AddTicks(8759), new DateTime(2023, 4, 13, 23, 49, 16, 976, DateTimeKind.Local).AddTicks(6561), 29, -12776570, null },
                    { 132, 96, new DateTime(2022, 11, 13, 14, 29, 37, 291, DateTimeKind.Local).AddTicks(264), new DateTime(2022, 8, 29, 2, 17, 12, 497, DateTimeKind.Local).AddTicks(4601), 97, -1943155951, null },
                    { 133, 62, new DateTime(2022, 7, 22, 10, 37, 35, 276, DateTimeKind.Local).AddTicks(5329), new DateTime(2022, 11, 26, 13, 5, 5, 60, DateTimeKind.Local).AddTicks(4004), 95, -772606742, null },
                    { 134, 101, new DateTime(2023, 2, 2, 12, 1, 18, 665, DateTimeKind.Local).AddTicks(3022), new DateTime(2023, 1, 22, 7, 38, 13, 822, DateTimeKind.Local).AddTicks(6088), 44, -156509778, null },
                    { 135, 103, new DateTime(2022, 5, 9, 14, 48, 18, 441, DateTimeKind.Local).AddTicks(950), new DateTime(2022, 4, 28, 4, 7, 45, 746, DateTimeKind.Local).AddTicks(5812), 23, -682971515, null },
                    { 136, 91, new DateTime(2023, 1, 6, 9, 16, 42, 935, DateTimeKind.Local).AddTicks(806), new DateTime(2022, 12, 4, 6, 15, 3, 23, DateTimeKind.Local).AddTicks(46), 76, -766860158, null },
                    { 137, 8, new DateTime(2022, 5, 6, 13, 8, 35, 550, DateTimeKind.Local).AddTicks(4322), new DateTime(2022, 10, 20, 0, 48, 48, 245, DateTimeKind.Local).AddTicks(2445), 74, -1612578299, null },
                    { 138, 94, new DateTime(2022, 11, 23, 20, 59, 19, 200, DateTimeKind.Local).AddTicks(6313), new DateTime(2022, 7, 27, 1, 40, 6, 674, DateTimeKind.Local).AddTicks(1342), 72, 1792408536, null },
                    { 139, 144, new DateTime(2022, 12, 14, 2, 59, 30, 933, DateTimeKind.Local).AddTicks(5502), new DateTime(2022, 12, 27, 1, 6, 13, 953, DateTimeKind.Local).AddTicks(2751), 72, 1481322988, null },
                    { 140, 103, new DateTime(2022, 9, 6, 9, 58, 33, 170, DateTimeKind.Local).AddTicks(730), new DateTime(2022, 6, 30, 2, 26, 12, 137, DateTimeKind.Local).AddTicks(4722), 2, 1073064746, null },
                    { 141, 67, new DateTime(2022, 9, 3, 9, 10, 24, 384, DateTimeKind.Local).AddTicks(7360), new DateTime(2022, 8, 2, 0, 20, 49, 246, DateTimeKind.Local).AddTicks(2286), 39, 615371552, null },
                    { 142, 106, new DateTime(2022, 5, 9, 17, 5, 54, 210, DateTimeKind.Local).AddTicks(2486), new DateTime(2023, 3, 12, 8, 51, 42, 828, DateTimeKind.Local).AddTicks(1569), 80, -1345922917, null },
                    { 143, 3, new DateTime(2022, 8, 24, 0, 54, 0, 890, DateTimeKind.Local).AddTicks(657), new DateTime(2022, 7, 15, 23, 26, 18, 968, DateTimeKind.Local).AddTicks(2122), 52, 1259710836, null },
                    { 144, 23, new DateTime(2022, 9, 23, 11, 3, 27, 623, DateTimeKind.Local).AddTicks(3475), new DateTime(2022, 8, 10, 7, 17, 3, 734, DateTimeKind.Local).AddTicks(9611), 41, 1281089482, null },
                    { 145, 75, new DateTime(2023, 1, 5, 20, 29, 56, 17, DateTimeKind.Local).AddTicks(6458), new DateTime(2022, 5, 19, 6, 13, 13, 228, DateTimeKind.Local).AddTicks(1173), 16, 1099948510, null },
                    { 146, 140, new DateTime(2022, 5, 16, 7, 7, 6, 996, DateTimeKind.Local).AddTicks(3773), new DateTime(2022, 12, 21, 3, 58, 44, 404, DateTimeKind.Local).AddTicks(9724), 69, -1322602411, null },
                    { 147, 2, new DateTime(2022, 8, 14, 19, 2, 38, 521, DateTimeKind.Local).AddTicks(7332), new DateTime(2022, 10, 27, 17, 19, 37, 885, DateTimeKind.Local).AddTicks(475), 2, 1347383630, null },
                    { 148, 135, new DateTime(2023, 1, 26, 22, 42, 51, 791, DateTimeKind.Local).AddTicks(488), new DateTime(2022, 10, 1, 21, 6, 57, 472, DateTimeKind.Local).AddTicks(1877), 33, -776088451, null },
                    { 149, 22, new DateTime(2022, 9, 17, 5, 53, 16, 968, DateTimeKind.Local).AddTicks(9894), new DateTime(2022, 12, 26, 10, 31, 36, 283, DateTimeKind.Local).AddTicks(9718), 7, 859053680, null },
                    { 150, 86, new DateTime(2022, 9, 21, 4, 15, 59, 565, DateTimeKind.Local).AddTicks(2047), new DateTime(2023, 4, 8, 13, 15, 18, 282, DateTimeKind.Local).AddTicks(5633), 98, -1856981795, null },
                    { 151, 128, new DateTime(2022, 4, 24, 5, 8, 16, 553, DateTimeKind.Local).AddTicks(4226), new DateTime(2022, 8, 6, 21, 43, 53, 836, DateTimeKind.Local).AddTicks(2319), 11, 2139279515, null },
                    { 152, 97, new DateTime(2022, 12, 20, 7, 5, 9, 818, DateTimeKind.Local).AddTicks(7462), new DateTime(2022, 9, 24, 4, 40, 44, 617, DateTimeKind.Local).AddTicks(607), 98, -1508231789, null },
                    { 153, 99, new DateTime(2023, 2, 22, 19, 17, 1, 28, DateTimeKind.Local).AddTicks(8771), new DateTime(2022, 10, 12, 13, 37, 4, 664, DateTimeKind.Local).AddTicks(3833), 40, -1785140375, null },
                    { 154, 105, new DateTime(2023, 3, 6, 10, 36, 8, 767, DateTimeKind.Local).AddTicks(7202), new DateTime(2022, 11, 2, 23, 30, 34, 701, DateTimeKind.Local).AddTicks(5061), 41, 230419495, null },
                    { 155, 45, new DateTime(2022, 8, 6, 19, 51, 23, 348, DateTimeKind.Local).AddTicks(106), new DateTime(2022, 7, 6, 7, 58, 29, 825, DateTimeKind.Local).AddTicks(984), 52, -1851182007, null },
                    { 156, 71, new DateTime(2022, 7, 9, 5, 31, 46, 734, DateTimeKind.Local).AddTicks(8030), new DateTime(2022, 9, 6, 23, 42, 21, 949, DateTimeKind.Local).AddTicks(4933), 3, 1671918995, null },
                    { 157, 16, new DateTime(2022, 8, 8, 23, 33, 32, 719, DateTimeKind.Local).AddTicks(1321), new DateTime(2023, 1, 13, 21, 9, 45, 521, DateTimeKind.Local).AddTicks(4649), 80, -2023453923, null },
                    { 158, 39, new DateTime(2022, 8, 2, 10, 23, 11, 892, DateTimeKind.Local).AddTicks(1159), new DateTime(2022, 9, 15, 11, 50, 14, 205, DateTimeKind.Local).AddTicks(2530), 57, -2030199808, null },
                    { 159, 39, new DateTime(2022, 6, 26, 20, 11, 53, 26, DateTimeKind.Local).AddTicks(1987), new DateTime(2022, 6, 18, 2, 30, 5, 617, DateTimeKind.Local).AddTicks(1853), 93, 192504379, null },
                    { 160, 34, new DateTime(2022, 12, 11, 6, 52, 39, 374, DateTimeKind.Local).AddTicks(7539), new DateTime(2022, 12, 3, 21, 53, 20, 635, DateTimeKind.Local).AddTicks(5090), 95, -2109728845, null },
                    { 161, 17, new DateTime(2023, 3, 19, 14, 26, 58, 281, DateTimeKind.Local).AddTicks(1888), new DateTime(2022, 8, 16, 22, 34, 23, 864, DateTimeKind.Local).AddTicks(4762), 69, 1715452911, null },
                    { 162, 107, new DateTime(2023, 2, 26, 6, 46, 20, 194, DateTimeKind.Local).AddTicks(3948), new DateTime(2022, 12, 5, 11, 4, 21, 276, DateTimeKind.Local).AddTicks(8372), 75, 2103597803, null },
                    { 163, 20, new DateTime(2022, 7, 3, 10, 31, 37, 620, DateTimeKind.Local).AddTicks(8215), new DateTime(2022, 8, 13, 6, 39, 6, 832, DateTimeKind.Local).AddTicks(7957), 3, -546355785, null },
                    { 164, 119, new DateTime(2023, 4, 18, 12, 20, 4, 188, DateTimeKind.Local).AddTicks(5112), new DateTime(2022, 8, 29, 1, 11, 58, 846, DateTimeKind.Local).AddTicks(4327), 88, 546817010, null },
                    { 165, 56, new DateTime(2022, 5, 22, 17, 6, 44, 23, DateTimeKind.Local).AddTicks(892), new DateTime(2022, 6, 6, 8, 15, 56, 582, DateTimeKind.Local).AddTicks(570), 8, -1354205967, null },
                    { 166, 11, new DateTime(2022, 4, 18, 15, 18, 29, 725, DateTimeKind.Local).AddTicks(1002), new DateTime(2023, 2, 28, 17, 17, 43, 234, DateTimeKind.Local).AddTicks(2007), 95, -439366080, null },
                    { 167, 85, new DateTime(2022, 9, 14, 16, 40, 56, 923, DateTimeKind.Local).AddTicks(537), new DateTime(2023, 2, 22, 22, 2, 54, 512, DateTimeKind.Local).AddTicks(4294), 95, 778751154, null },
                    { 168, 43, new DateTime(2022, 10, 15, 0, 1, 7, 239, DateTimeKind.Local).AddTicks(4824), new DateTime(2023, 1, 2, 5, 33, 40, 472, DateTimeKind.Local).AddTicks(7250), 89, 2133310295, null },
                    { 169, 49, new DateTime(2023, 3, 13, 15, 9, 16, 71, DateTimeKind.Local).AddTicks(7801), new DateTime(2022, 5, 19, 1, 30, 15, 159, DateTimeKind.Local).AddTicks(1010), 95, -1447606230, null },
                    { 170, 16, new DateTime(2022, 6, 6, 17, 7, 23, 296, DateTimeKind.Local).AddTicks(6704), new DateTime(2023, 3, 19, 10, 28, 17, 656, DateTimeKind.Local).AddTicks(1940), 39, 343869198, null },
                    { 171, 49, new DateTime(2023, 1, 22, 4, 26, 53, 15, DateTimeKind.Local).AddTicks(8876), new DateTime(2022, 11, 9, 21, 56, 27, 594, DateTimeKind.Local).AddTicks(1950), 97, 214439580, null },
                    { 172, 5, new DateTime(2022, 7, 30, 7, 48, 48, 894, DateTimeKind.Local).AddTicks(7357), new DateTime(2023, 2, 28, 15, 35, 32, 970, DateTimeKind.Local).AddTicks(9364), 47, -1167957284, null },
                    { 173, 26, new DateTime(2022, 7, 14, 12, 48, 4, 660, DateTimeKind.Local).AddTicks(359), new DateTime(2022, 9, 20, 9, 0, 27, 827, DateTimeKind.Local).AddTicks(8087), 26, -301146334, null },
                    { 174, 73, new DateTime(2022, 11, 15, 8, 56, 58, 152, DateTimeKind.Local).AddTicks(5437), new DateTime(2022, 9, 4, 21, 50, 44, 425, DateTimeKind.Local).AddTicks(7521), 32, 1208453453, null },
                    { 175, 143, new DateTime(2022, 7, 27, 22, 18, 13, 588, DateTimeKind.Local).AddTicks(3234), new DateTime(2023, 2, 9, 14, 5, 6, 798, DateTimeKind.Local).AddTicks(9210), 12, -240048288, null },
                    { 176, 149, new DateTime(2022, 10, 25, 12, 33, 59, 391, DateTimeKind.Local).AddTicks(3992), new DateTime(2022, 7, 22, 23, 33, 44, 324, DateTimeKind.Local).AddTicks(7659), 12, 628764721, null },
                    { 177, 76, new DateTime(2022, 7, 24, 17, 23, 11, 258, DateTimeKind.Local).AddTicks(1038), new DateTime(2022, 10, 1, 21, 0, 17, 567, DateTimeKind.Local).AddTicks(7404), 62, -958354739, null },
                    { 178, 13, new DateTime(2023, 1, 17, 0, 55, 45, 832, DateTimeKind.Local).AddTicks(7369), new DateTime(2022, 4, 30, 21, 41, 33, 56, DateTimeKind.Local).AddTicks(5485), 70, 820951023, null },
                    { 179, 124, new DateTime(2022, 5, 24, 20, 18, 18, 388, DateTimeKind.Local).AddTicks(8890), new DateTime(2022, 9, 2, 15, 24, 6, 10, DateTimeKind.Local).AddTicks(3980), 51, -1611710076, null },
                    { 180, 85, new DateTime(2022, 8, 17, 12, 20, 34, 545, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 5, 19, 11, 29, 0, 186, DateTimeKind.Local).AddTicks(5613), 84, -1990095754, null },
                    { 181, 69, new DateTime(2022, 5, 26, 12, 11, 25, 996, DateTimeKind.Local).AddTicks(1706), new DateTime(2022, 7, 31, 18, 27, 22, 675, DateTimeKind.Local).AddTicks(4019), 85, 1474642631, null },
                    { 182, 140, new DateTime(2022, 4, 28, 22, 20, 16, 365, DateTimeKind.Local).AddTicks(9803), new DateTime(2022, 11, 1, 5, 36, 7, 751, DateTimeKind.Local).AddTicks(7263), 53, 1636267179, null },
                    { 183, 73, new DateTime(2022, 6, 28, 11, 29, 56, 9, DateTimeKind.Local).AddTicks(8387), new DateTime(2022, 11, 9, 18, 3, 52, 936, DateTimeKind.Local).AddTicks(4399), 91, 1102354563, null },
                    { 184, 102, new DateTime(2022, 5, 1, 3, 6, 32, 482, DateTimeKind.Local).AddTicks(8849), new DateTime(2022, 4, 27, 18, 11, 7, 480, DateTimeKind.Local).AddTicks(9361), 39, -980312475, null },
                    { 185, 75, new DateTime(2022, 6, 24, 0, 37, 57, 596, DateTimeKind.Local).AddTicks(4953), new DateTime(2022, 5, 1, 14, 56, 6, 509, DateTimeKind.Local).AddTicks(8783), 85, 538953473, null },
                    { 186, 27, new DateTime(2022, 11, 7, 19, 30, 24, 332, DateTimeKind.Local).AddTicks(9100), new DateTime(2023, 2, 15, 13, 58, 34, 456, DateTimeKind.Local).AddTicks(5842), 30, 763332644, null },
                    { 187, 120, new DateTime(2023, 3, 24, 5, 45, 1, 550, DateTimeKind.Local).AddTicks(8485), new DateTime(2022, 10, 19, 15, 31, 52, 709, DateTimeKind.Local).AddTicks(5863), 93, 1296736098, null },
                    { 188, 120, new DateTime(2022, 7, 5, 1, 25, 18, 174, DateTimeKind.Local).AddTicks(6587), new DateTime(2022, 9, 30, 11, 35, 11, 988, DateTimeKind.Local).AddTicks(985), 59, 1514476187, null },
                    { 189, 122, new DateTime(2022, 12, 13, 23, 30, 13, 900, DateTimeKind.Local).AddTicks(3380), new DateTime(2022, 8, 20, 21, 13, 16, 190, DateTimeKind.Local).AddTicks(9347), 28, 1038498176, null },
                    { 190, 115, new DateTime(2023, 1, 29, 13, 18, 50, 864, DateTimeKind.Local).AddTicks(5715), new DateTime(2022, 8, 10, 21, 14, 45, 555, DateTimeKind.Local).AddTicks(7702), 10, -269806954, null },
                    { 191, 41, new DateTime(2022, 8, 27, 17, 2, 18, 38, DateTimeKind.Local).AddTicks(860), new DateTime(2023, 1, 31, 17, 43, 31, 961, DateTimeKind.Local).AddTicks(7437), 53, 461647572, null },
                    { 192, 122, new DateTime(2022, 9, 16, 22, 5, 28, 804, DateTimeKind.Local).AddTicks(8474), new DateTime(2022, 6, 20, 15, 10, 4, 748, DateTimeKind.Local).AddTicks(9574), 28, 416446996, null },
                    { 193, 139, new DateTime(2022, 7, 8, 0, 31, 58, 989, DateTimeKind.Local).AddTicks(8037), new DateTime(2022, 12, 18, 6, 29, 12, 529, DateTimeKind.Local).AddTicks(7231), 86, 142204306, null },
                    { 194, 106, new DateTime(2022, 9, 4, 10, 11, 11, 415, DateTimeKind.Local).AddTicks(6452), new DateTime(2022, 8, 17, 18, 43, 16, 541, DateTimeKind.Local).AddTicks(3407), 75, -745230758, null },
                    { 195, 109, new DateTime(2022, 7, 3, 9, 26, 19, 358, DateTimeKind.Local).AddTicks(6719), new DateTime(2022, 7, 27, 10, 5, 16, 826, DateTimeKind.Local).AddTicks(4614), 2, 2006500283, null },
                    { 196, 72, new DateTime(2022, 6, 2, 12, 20, 48, 378, DateTimeKind.Local).AddTicks(2162), new DateTime(2023, 3, 11, 1, 22, 2, 357, DateTimeKind.Local).AddTicks(2644), 87, 1453909643, null },
                    { 197, 39, new DateTime(2023, 2, 19, 18, 18, 17, 465, DateTimeKind.Local).AddTicks(7086), new DateTime(2022, 9, 22, 3, 43, 45, 819, DateTimeKind.Local).AddTicks(6960), 70, -1230809862, null },
                    { 198, 46, new DateTime(2022, 6, 1, 6, 42, 12, 825, DateTimeKind.Local).AddTicks(4367), new DateTime(2023, 3, 20, 11, 42, 25, 274, DateTimeKind.Local).AddTicks(3553), 34, -1792286952, null },
                    { 199, 20, new DateTime(2022, 11, 10, 17, 21, 30, 758, DateTimeKind.Local).AddTicks(561), new DateTime(2023, 4, 10, 4, 27, 40, 234, DateTimeKind.Local).AddTicks(2980), 29, 2104270351, null },
                    { 200, 35, new DateTime(2022, 5, 27, 23, 41, 46, 467, DateTimeKind.Local).AddTicks(3057), new DateTime(2023, 3, 9, 17, 6, 5, 390, DateTimeKind.Local).AddTicks(1937), 54, -1855887578, null },
                    { 201, 37, new DateTime(2022, 8, 28, 21, 3, 3, 855, DateTimeKind.Local).AddTicks(8677), new DateTime(2022, 8, 21, 6, 5, 3, 435, DateTimeKind.Local).AddTicks(3190), 22, 1465922020, null },
                    { 202, 69, new DateTime(2022, 6, 29, 3, 54, 12, 483, DateTimeKind.Local).AddTicks(9755), new DateTime(2022, 9, 20, 17, 18, 2, 404, DateTimeKind.Local).AddTicks(4123), 2, 1758253996, null },
                    { 203, 102, new DateTime(2022, 8, 26, 0, 41, 21, 602, DateTimeKind.Local).AddTicks(131), new DateTime(2022, 12, 5, 4, 12, 58, 85, DateTimeKind.Local).AddTicks(6776), 20, -495643935, null },
                    { 204, 74, new DateTime(2022, 6, 21, 21, 2, 12, 725, DateTimeKind.Local).AddTicks(2295), new DateTime(2023, 3, 30, 5, 43, 7, 65, DateTimeKind.Local).AddTicks(1940), 98, -1116660569, null },
                    { 205, 81, new DateTime(2022, 10, 11, 10, 53, 23, 520, DateTimeKind.Local).AddTicks(6543), new DateTime(2023, 4, 11, 5, 18, 58, 937, DateTimeKind.Local).AddTicks(3019), 40, -205125606, null },
                    { 206, 3, new DateTime(2022, 10, 20, 20, 41, 7, 181, DateTimeKind.Local).AddTicks(8241), new DateTime(2022, 9, 29, 3, 32, 27, 531, DateTimeKind.Local).AddTicks(5331), 66, 2042818471, null },
                    { 207, 105, new DateTime(2023, 3, 30, 23, 57, 59, 733, DateTimeKind.Local).AddTicks(4500), new DateTime(2022, 9, 6, 19, 14, 42, 433, DateTimeKind.Local).AddTicks(1602), 5, 1372582624, null },
                    { 208, 90, new DateTime(2023, 2, 28, 10, 0, 8, 282, DateTimeKind.Local).AddTicks(7071), new DateTime(2022, 7, 7, 9, 41, 57, 187, DateTimeKind.Local).AddTicks(5185), 27, 1925339530, null },
                    { 209, 103, new DateTime(2022, 10, 12, 2, 7, 19, 58, DateTimeKind.Local).AddTicks(961), new DateTime(2022, 9, 4, 0, 34, 30, 998, DateTimeKind.Local).AddTicks(4139), 84, -838223755, null },
                    { 210, 33, new DateTime(2023, 3, 17, 17, 24, 14, 235, DateTimeKind.Local).AddTicks(1955), new DateTime(2023, 1, 22, 2, 50, 57, 765, DateTimeKind.Local).AddTicks(9224), 84, -437540636, null },
                    { 211, 88, new DateTime(2022, 11, 30, 12, 8, 48, 863, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 8, 21, 4, 38, 55, 177, DateTimeKind.Local).AddTicks(9063), 46, 969016559, null },
                    { 212, 77, new DateTime(2023, 3, 10, 12, 5, 12, 947, DateTimeKind.Local).AddTicks(3006), new DateTime(2022, 7, 3, 18, 14, 33, 727, DateTimeKind.Local).AddTicks(9347), 67, -2015719979, null },
                    { 213, 58, new DateTime(2022, 9, 1, 14, 4, 30, 136, DateTimeKind.Local).AddTicks(4062), new DateTime(2022, 4, 19, 7, 59, 47, 547, DateTimeKind.Local).AddTicks(5851), 31, 1537277839, null },
                    { 214, 131, new DateTime(2022, 11, 3, 13, 35, 34, 989, DateTimeKind.Local).AddTicks(8737), new DateTime(2023, 2, 6, 4, 33, 9, 752, DateTimeKind.Local).AddTicks(9881), 72, 517000785, null },
                    { 215, 13, new DateTime(2022, 9, 6, 19, 43, 10, 383, DateTimeKind.Local).AddTicks(698), new DateTime(2022, 12, 23, 10, 5, 9, 376, DateTimeKind.Local).AddTicks(3959), 75, 187877361, null },
                    { 216, 29, new DateTime(2022, 12, 27, 22, 18, 10, 156, DateTimeKind.Local).AddTicks(6523), new DateTime(2022, 9, 14, 0, 48, 20, 744, DateTimeKind.Local).AddTicks(2746), 41, 1916267657, null },
                    { 217, 130, new DateTime(2022, 10, 5, 14, 44, 58, 43, DateTimeKind.Local).AddTicks(6615), new DateTime(2023, 1, 2, 22, 13, 53, 328, DateTimeKind.Local).AddTicks(3545), 55, -2057383988, null },
                    { 218, 31, new DateTime(2023, 1, 30, 5, 0, 52, 294, DateTimeKind.Local).AddTicks(9313), new DateTime(2023, 2, 12, 23, 4, 20, 124, DateTimeKind.Local).AddTicks(7741), 98, -967426901, null },
                    { 219, 43, new DateTime(2022, 9, 23, 18, 21, 32, 429, DateTimeKind.Local).AddTicks(7962), new DateTime(2023, 3, 23, 17, 27, 10, 308, DateTimeKind.Local).AddTicks(8045), 45, 637803691, null },
                    { 220, 126, new DateTime(2022, 5, 28, 7, 23, 37, 871, DateTimeKind.Local).AddTicks(8533), new DateTime(2022, 10, 5, 22, 49, 33, 282, DateTimeKind.Local).AddTicks(2720), 64, 1002740502, null },
                    { 221, 39, new DateTime(2022, 12, 27, 21, 56, 48, 147, DateTimeKind.Local).AddTicks(9206), new DateTime(2022, 5, 29, 22, 18, 23, 524, DateTimeKind.Local).AddTicks(6813), 60, -1649066623, null },
                    { 222, 21, new DateTime(2023, 3, 25, 3, 51, 33, 367, DateTimeKind.Local).AddTicks(2613), new DateTime(2022, 5, 2, 10, 2, 7, 481, DateTimeKind.Local).AddTicks(7967), 97, 1205042689, null },
                    { 223, 49, new DateTime(2022, 6, 4, 15, 43, 46, 408, DateTimeKind.Local).AddTicks(6001), new DateTime(2022, 7, 17, 22, 8, 33, 415, DateTimeKind.Local).AddTicks(7136), 23, -332189426, null },
                    { 224, 116, new DateTime(2022, 6, 18, 16, 55, 56, 884, DateTimeKind.Local).AddTicks(6957), new DateTime(2023, 1, 12, 17, 14, 51, 426, DateTimeKind.Local).AddTicks(4807), 61, 1531886734, null },
                    { 225, 119, new DateTime(2023, 3, 6, 18, 55, 11, 131, DateTimeKind.Local).AddTicks(8741), new DateTime(2022, 7, 1, 20, 6, 20, 214, DateTimeKind.Local).AddTicks(9768), 28, -2003953420, null },
                    { 226, 123, new DateTime(2022, 6, 24, 2, 11, 23, 778, DateTimeKind.Local).AddTicks(1774), new DateTime(2023, 3, 11, 15, 47, 7, 528, DateTimeKind.Local).AddTicks(2169), 98, 1681421111, null },
                    { 227, 68, new DateTime(2022, 9, 29, 18, 46, 51, 132, DateTimeKind.Local).AddTicks(2145), new DateTime(2022, 11, 11, 12, 44, 53, 35, DateTimeKind.Local).AddTicks(3195), 17, 803309271, null },
                    { 228, 58, new DateTime(2022, 9, 25, 7, 23, 20, 661, DateTimeKind.Local).AddTicks(9418), new DateTime(2022, 5, 19, 7, 45, 27, 555, DateTimeKind.Local).AddTicks(6911), 31, -972795645, null },
                    { 229, 12, new DateTime(2022, 7, 27, 18, 23, 53, 638, DateTimeKind.Local).AddTicks(5010), new DateTime(2023, 2, 24, 19, 8, 29, 845, DateTimeKind.Local).AddTicks(5114), 20, -447304869, null },
                    { 230, 63, new DateTime(2022, 9, 2, 18, 12, 24, 729, DateTimeKind.Local).AddTicks(5851), new DateTime(2022, 11, 21, 22, 40, 18, 280, DateTimeKind.Local).AddTicks(7113), 89, -878564274, null },
                    { 231, 86, new DateTime(2023, 3, 27, 4, 32, 19, 380, DateTimeKind.Local).AddTicks(5), new DateTime(2022, 8, 23, 9, 25, 55, 614, DateTimeKind.Local).AddTicks(4515), 80, -501240761, null },
                    { 232, 70, new DateTime(2022, 9, 21, 21, 34, 50, 595, DateTimeKind.Local).AddTicks(1961), new DateTime(2022, 8, 13, 20, 50, 46, 526, DateTimeKind.Local).AddTicks(3744), 34, -1008790249, null },
                    { 233, 46, new DateTime(2022, 7, 2, 23, 48, 10, 434, DateTimeKind.Local).AddTicks(4086), new DateTime(2022, 6, 14, 0, 46, 15, 941, DateTimeKind.Local).AddTicks(2744), 45, 1234704546, null },
                    { 234, 15, new DateTime(2022, 9, 27, 20, 8, 21, 616, DateTimeKind.Local).AddTicks(4212), new DateTime(2022, 7, 9, 16, 46, 51, 88, DateTimeKind.Local).AddTicks(7548), 72, -1138450232, null },
                    { 235, 31, new DateTime(2022, 7, 30, 0, 43, 57, 156, DateTimeKind.Local).AddTicks(9960), new DateTime(2022, 10, 11, 6, 32, 40, 972, DateTimeKind.Local).AddTicks(8644), 45, 1857114213, null },
                    { 236, 96, new DateTime(2022, 8, 21, 19, 3, 57, 411, DateTimeKind.Local).AddTicks(8333), new DateTime(2022, 6, 14, 12, 30, 4, 237, DateTimeKind.Local).AddTicks(932), 59, 1539308954, null },
                    { 237, 144, new DateTime(2022, 9, 26, 21, 4, 39, 993, DateTimeKind.Local).AddTicks(4751), new DateTime(2022, 10, 8, 19, 32, 47, 398, DateTimeKind.Local).AddTicks(5896), 76, -1117376682, null },
                    { 238, 104, new DateTime(2022, 12, 1, 15, 35, 14, 553, DateTimeKind.Local).AddTicks(8241), new DateTime(2022, 6, 9, 8, 36, 8, 212, DateTimeKind.Local).AddTicks(2355), 5, 1636239249, null },
                    { 239, 107, new DateTime(2022, 4, 18, 18, 1, 34, 197, DateTimeKind.Local).AddTicks(9804), new DateTime(2022, 11, 21, 12, 55, 16, 73, DateTimeKind.Local).AddTicks(7977), 17, 479498583, null },
                    { 240, 25, new DateTime(2022, 7, 10, 20, 6, 17, 240, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 8, 4, 5, 39, 2, 458, DateTimeKind.Local).AddTicks(2805), 76, -1382251655, null },
                    { 241, 131, new DateTime(2022, 4, 24, 6, 41, 29, 195, DateTimeKind.Local).AddTicks(5145), new DateTime(2023, 4, 18, 4, 48, 24, 36, DateTimeKind.Local).AddTicks(4587), 88, 831320477, null },
                    { 242, 108, new DateTime(2023, 2, 4, 19, 41, 31, 713, DateTimeKind.Local).AddTicks(8769), new DateTime(2023, 3, 13, 4, 43, 30, 735, DateTimeKind.Local).AddTicks(1740), 60, 2022335566, null },
                    { 243, 143, new DateTime(2022, 8, 5, 0, 39, 32, 648, DateTimeKind.Local).AddTicks(4020), new DateTime(2022, 8, 12, 10, 26, 51, 222, DateTimeKind.Local).AddTicks(7627), 53, -2041075643, null },
                    { 244, 16, new DateTime(2022, 6, 24, 0, 29, 53, 708, DateTimeKind.Local).AddTicks(308), new DateTime(2023, 2, 18, 1, 55, 0, 654, DateTimeKind.Local).AddTicks(8654), 70, 657622173, null },
                    { 245, 33, new DateTime(2022, 5, 27, 4, 18, 12, 1, DateTimeKind.Local).AddTicks(5113), new DateTime(2022, 12, 2, 2, 39, 26, 404, DateTimeKind.Local).AddTicks(8827), 92, 1435051757, null },
                    { 246, 7, new DateTime(2022, 8, 29, 16, 58, 40, 336, DateTimeKind.Local).AddTicks(3006), new DateTime(2022, 7, 14, 23, 12, 51, 770, DateTimeKind.Local).AddTicks(4378), 91, 1607870550, null },
                    { 247, 141, new DateTime(2022, 8, 12, 16, 41, 17, 581, DateTimeKind.Local).AddTicks(5067), new DateTime(2023, 4, 17, 6, 45, 57, 960, DateTimeKind.Local).AddTicks(4698), 93, -1420824628, null },
                    { 248, 23, new DateTime(2023, 4, 11, 16, 30, 55, 880, DateTimeKind.Local).AddTicks(316), new DateTime(2023, 1, 7, 16, 40, 24, 3, DateTimeKind.Local).AddTicks(2029), 10, 572143182, null },
                    { 249, 3, new DateTime(2022, 8, 27, 22, 10, 26, 586, DateTimeKind.Local).AddTicks(6497), new DateTime(2022, 7, 31, 15, 11, 14, 936, DateTimeKind.Local).AddTicks(6610), 44, -293950042, null },
                    { 250, 99, new DateTime(2023, 1, 16, 1, 12, 55, 20, DateTimeKind.Local).AddTicks(6527), new DateTime(2023, 4, 3, 13, 27, 33, 862, DateTimeKind.Local).AddTicks(945), 65, 876133470, null },
                    { 251, 69, new DateTime(2023, 4, 18, 3, 50, 36, 944, DateTimeKind.Local).AddTicks(4319), new DateTime(2023, 3, 15, 17, 11, 58, 610, DateTimeKind.Local).AddTicks(1508), 76, -1922238012, null },
                    { 252, 105, new DateTime(2023, 2, 19, 18, 23, 23, 767, DateTimeKind.Local).AddTicks(4781), new DateTime(2023, 3, 28, 11, 22, 9, 572, DateTimeKind.Local).AddTicks(8714), 99, 675335820, null },
                    { 253, 126, new DateTime(2022, 10, 21, 12, 19, 27, 953, DateTimeKind.Local).AddTicks(9826), new DateTime(2022, 10, 3, 23, 10, 35, 35, DateTimeKind.Local).AddTicks(6417), 90, -1921479490, null },
                    { 254, 60, new DateTime(2022, 6, 30, 4, 54, 28, 602, DateTimeKind.Local).AddTicks(7530), new DateTime(2022, 6, 18, 21, 17, 6, 159, DateTimeKind.Local).AddTicks(4353), 28, -664281878, null },
                    { 255, 34, new DateTime(2023, 3, 22, 4, 20, 2, 617, DateTimeKind.Local).AddTicks(1780), new DateTime(2022, 8, 22, 11, 2, 1, 964, DateTimeKind.Local).AddTicks(956), 24, 198085181, null },
                    { 256, 30, new DateTime(2023, 4, 16, 20, 30, 52, 306, DateTimeKind.Local).AddTicks(4873), new DateTime(2022, 12, 2, 23, 25, 59, 881, DateTimeKind.Local).AddTicks(3635), 4, 732056015, null },
                    { 257, 64, new DateTime(2023, 1, 16, 9, 26, 32, 873, DateTimeKind.Local).AddTicks(5044), new DateTime(2022, 8, 11, 10, 4, 44, 715, DateTimeKind.Local).AddTicks(8724), 94, -1399350447, null },
                    { 258, 16, new DateTime(2022, 10, 13, 2, 32, 54, 548, DateTimeKind.Local).AddTicks(6449), new DateTime(2023, 1, 14, 1, 17, 9, 714, DateTimeKind.Local).AddTicks(2722), 47, 1759976346, null },
                    { 259, 128, new DateTime(2022, 9, 3, 23, 25, 44, 296, DateTimeKind.Local).AddTicks(595), new DateTime(2022, 11, 6, 23, 20, 19, 567, DateTimeKind.Local).AddTicks(627), 97, -2079820648, null },
                    { 260, 82, new DateTime(2022, 7, 9, 11, 8, 2, 409, DateTimeKind.Local).AddTicks(8668), new DateTime(2023, 1, 24, 10, 16, 53, 58, DateTimeKind.Local).AddTicks(568), 5, -1928658467, null },
                    { 261, 94, new DateTime(2023, 3, 9, 20, 4, 3, 847, DateTimeKind.Local).AddTicks(5479), new DateTime(2023, 1, 14, 7, 2, 59, 855, DateTimeKind.Local).AddTicks(4105), 78, -2076330200, null },
                    { 262, 73, new DateTime(2023, 4, 16, 13, 16, 12, 871, DateTimeKind.Local).AddTicks(1969), new DateTime(2023, 4, 5, 22, 30, 22, 483, DateTimeKind.Local).AddTicks(7438), 66, 351345344, null },
                    { 263, 122, new DateTime(2022, 10, 25, 19, 16, 55, 697, DateTimeKind.Local).AddTicks(3288), new DateTime(2022, 11, 14, 6, 50, 23, 650, DateTimeKind.Local).AddTicks(9849), 22, 1884863602, null },
                    { 264, 90, new DateTime(2023, 4, 16, 8, 34, 51, 753, DateTimeKind.Local).AddTicks(1399), new DateTime(2022, 9, 26, 5, 15, 3, 325, DateTimeKind.Local).AddTicks(2616), 59, 1561754969, null },
                    { 265, 95, new DateTime(2023, 2, 18, 17, 8, 56, 970, DateTimeKind.Local).AddTicks(6413), new DateTime(2022, 9, 26, 19, 2, 35, 685, DateTimeKind.Local).AddTicks(2188), 46, 1051822231, null },
                    { 266, 71, new DateTime(2022, 9, 14, 6, 55, 57, 433, DateTimeKind.Local).AddTicks(43), new DateTime(2022, 7, 3, 16, 20, 10, 311, DateTimeKind.Local).AddTicks(4001), 45, -732060615, null },
                    { 267, 35, new DateTime(2022, 9, 20, 17, 24, 19, 943, DateTimeKind.Local).AddTicks(5900), new DateTime(2022, 11, 17, 3, 30, 27, 962, DateTimeKind.Local).AddTicks(4385), 33, -717995039, null },
                    { 268, 54, new DateTime(2022, 7, 5, 8, 8, 44, 937, DateTimeKind.Local).AddTicks(4624), new DateTime(2022, 8, 8, 11, 4, 32, 483, DateTimeKind.Local).AddTicks(332), 78, 985030783, null },
                    { 269, 127, new DateTime(2022, 6, 1, 23, 16, 28, 539, DateTimeKind.Local).AddTicks(6013), new DateTime(2022, 11, 19, 14, 30, 29, 70, DateTimeKind.Local).AddTicks(1716), 45, 873146595, null },
                    { 270, 112, new DateTime(2022, 7, 31, 13, 35, 27, 322, DateTimeKind.Local).AddTicks(9220), new DateTime(2022, 11, 4, 21, 39, 35, 764, DateTimeKind.Local).AddTicks(9731), 9, -1116075194, null },
                    { 271, 33, new DateTime(2022, 10, 28, 4, 57, 23, 650, DateTimeKind.Local).AddTicks(1081), new DateTime(2022, 8, 21, 18, 29, 46, 682, DateTimeKind.Local).AddTicks(5075), 43, 431468655, null },
                    { 272, 14, new DateTime(2022, 8, 14, 0, 24, 43, 986, DateTimeKind.Local).AddTicks(2724), new DateTime(2022, 12, 6, 6, 32, 17, 5, DateTimeKind.Local).AddTicks(3507), 63, -631474695, null },
                    { 273, 10, new DateTime(2022, 4, 21, 12, 33, 7, 645, DateTimeKind.Local).AddTicks(4410), new DateTime(2022, 11, 16, 23, 40, 39, 128, DateTimeKind.Local).AddTicks(7618), 85, 1869312478, null },
                    { 274, 33, new DateTime(2022, 7, 4, 23, 38, 7, 630, DateTimeKind.Local).AddTicks(6909), new DateTime(2022, 12, 28, 18, 23, 49, 342, DateTimeKind.Local).AddTicks(7473), 39, 642834988, null },
                    { 275, 48, new DateTime(2022, 5, 12, 2, 32, 25, 891, DateTimeKind.Local).AddTicks(1305), new DateTime(2022, 11, 13, 13, 45, 9, 288, DateTimeKind.Local).AddTicks(5913), 4, -1946267095, null },
                    { 276, 89, new DateTime(2023, 1, 13, 13, 32, 20, 974, DateTimeKind.Local).AddTicks(6342), new DateTime(2022, 6, 9, 14, 30, 6, 999, DateTimeKind.Local).AddTicks(9320), 91, 1608924057, null },
                    { 277, 118, new DateTime(2022, 4, 26, 19, 32, 53, 665, DateTimeKind.Local).AddTicks(9588), new DateTime(2022, 7, 23, 21, 46, 11, 138, DateTimeKind.Local).AddTicks(7378), 3, 1804398841, null },
                    { 278, 90, new DateTime(2022, 10, 27, 21, 26, 38, 449, DateTimeKind.Local).AddTicks(5849), new DateTime(2022, 8, 3, 12, 16, 14, 440, DateTimeKind.Local).AddTicks(4017), 72, -697149150, null },
                    { 279, 107, new DateTime(2023, 2, 27, 9, 22, 44, 941, DateTimeKind.Local).AddTicks(3978), new DateTime(2023, 1, 26, 14, 39, 30, 7, DateTimeKind.Local).AddTicks(4634), 92, 1144971373, null },
                    { 280, 141, new DateTime(2023, 2, 16, 11, 21, 32, 267, DateTimeKind.Local).AddTicks(5392), new DateTime(2023, 1, 22, 23, 44, 58, 36, DateTimeKind.Local).AddTicks(4792), 1, 47027392, null },
                    { 281, 32, new DateTime(2022, 9, 22, 6, 17, 46, 606, DateTimeKind.Local).AddTicks(3405), new DateTime(2022, 8, 1, 5, 44, 15, 508, DateTimeKind.Local).AddTicks(1756), 56, -163485403, null },
                    { 282, 56, new DateTime(2022, 12, 25, 13, 29, 52, 757, DateTimeKind.Local).AddTicks(7026), new DateTime(2023, 1, 24, 10, 8, 58, 230, DateTimeKind.Local).AddTicks(2431), 37, 795094522, null },
                    { 283, 87, new DateTime(2022, 12, 1, 1, 10, 23, 524, DateTimeKind.Local).AddTicks(7171), new DateTime(2022, 7, 11, 19, 1, 26, 309, DateTimeKind.Local).AddTicks(3952), 6, -1603814250, null },
                    { 284, 44, new DateTime(2022, 10, 1, 6, 46, 39, 894, DateTimeKind.Local).AddTicks(3487), new DateTime(2022, 6, 18, 14, 51, 0, 804, DateTimeKind.Local).AddTicks(9301), 82, 1288796020, null },
                    { 285, 93, new DateTime(2022, 8, 29, 10, 48, 16, 222, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 6, 16, 11, 43, 9, 799, DateTimeKind.Local).AddTicks(4343), 96, 193383001, null },
                    { 286, 142, new DateTime(2022, 8, 26, 0, 40, 57, 518, DateTimeKind.Local).AddTicks(5678), new DateTime(2023, 1, 16, 18, 5, 13, 642, DateTimeKind.Local).AddTicks(9999), 12, 898950947, null },
                    { 287, 43, new DateTime(2022, 10, 15, 17, 54, 34, 418, DateTimeKind.Local).AddTicks(7871), new DateTime(2022, 8, 16, 17, 2, 13, 489, DateTimeKind.Local).AddTicks(5341), 59, 1794239276, null },
                    { 288, 85, new DateTime(2022, 12, 29, 0, 5, 38, 971, DateTimeKind.Local).AddTicks(4203), new DateTime(2023, 3, 14, 15, 50, 49, 764, DateTimeKind.Local).AddTicks(8304), 8, -1315611967, null },
                    { 289, 106, new DateTime(2022, 6, 3, 12, 10, 40, 65, DateTimeKind.Local).AddTicks(3226), new DateTime(2022, 8, 7, 18, 57, 47, 902, DateTimeKind.Local).AddTicks(2591), 15, -1959883397, null },
                    { 290, 83, new DateTime(2022, 10, 20, 6, 32, 10, 639, DateTimeKind.Local).AddTicks(8472), new DateTime(2022, 8, 23, 14, 10, 19, 620, DateTimeKind.Local).AddTicks(7526), 2, -1866894778, null },
                    { 291, 113, new DateTime(2022, 8, 13, 12, 24, 14, 240, DateTimeKind.Local).AddTicks(4709), new DateTime(2023, 2, 24, 15, 55, 35, 259, DateTimeKind.Local).AddTicks(8056), 48, 799938224, null },
                    { 292, 106, new DateTime(2022, 5, 26, 10, 23, 52, 910, DateTimeKind.Local).AddTicks(6172), new DateTime(2022, 9, 2, 20, 52, 41, 645, DateTimeKind.Local).AddTicks(5218), 22, 1957762630, null },
                    { 293, 46, new DateTime(2023, 1, 11, 2, 18, 45, 622, DateTimeKind.Local).AddTicks(4976), new DateTime(2022, 11, 28, 18, 47, 48, 691, DateTimeKind.Local).AddTicks(299), 17, -1702825623, null },
                    { 294, 50, new DateTime(2023, 3, 4, 8, 38, 25, 834, DateTimeKind.Local).AddTicks(9405), new DateTime(2022, 9, 7, 13, 52, 51, 345, DateTimeKind.Local).AddTicks(6174), 30, -1457944877, null },
                    { 295, 48, new DateTime(2023, 3, 3, 18, 3, 18, 17, DateTimeKind.Local).AddTicks(1275), new DateTime(2023, 3, 20, 22, 37, 58, 124, DateTimeKind.Local).AddTicks(9302), 57, 617891637, null },
                    { 296, 97, new DateTime(2023, 2, 22, 12, 29, 21, 477, DateTimeKind.Local).AddTicks(1565), new DateTime(2022, 10, 20, 15, 20, 14, 244, DateTimeKind.Local).AddTicks(9256), 87, -67363939, null },
                    { 297, 43, new DateTime(2022, 9, 4, 11, 42, 10, 70, DateTimeKind.Local).AddTicks(9491), new DateTime(2023, 3, 9, 14, 1, 48, 645, DateTimeKind.Local).AddTicks(207), 28, -1350184387, null },
                    { 298, 128, new DateTime(2022, 6, 24, 20, 26, 7, 532, DateTimeKind.Local).AddTicks(6735), new DateTime(2022, 11, 19, 19, 29, 33, 888, DateTimeKind.Local).AddTicks(3960), 42, 782606777, null },
                    { 299, 148, new DateTime(2022, 12, 6, 2, 3, 44, 373, DateTimeKind.Local).AddTicks(12), new DateTime(2022, 12, 6, 20, 39, 31, 735, DateTimeKind.Local).AddTicks(7163), 13, -2063127704, null },
                    { 300, 76, new DateTime(2023, 4, 5, 10, 14, 19, 514, DateTimeKind.Local).AddTicks(9074), new DateTime(2022, 5, 31, 0, 12, 40, 320, DateTimeKind.Local).AddTicks(7531), 27, -545079135, null },
                    { 301, 133, new DateTime(2022, 10, 15, 13, 22, 37, 208, DateTimeKind.Local).AddTicks(3720), new DateTime(2022, 7, 9, 18, 4, 47, 586, DateTimeKind.Local).AddTicks(5148), 39, 332349656, null },
                    { 302, 138, new DateTime(2022, 7, 1, 23, 16, 0, 267, DateTimeKind.Local).AddTicks(4195), new DateTime(2022, 6, 22, 22, 37, 48, 740, DateTimeKind.Local).AddTicks(2383), 30, 982925011, null },
                    { 303, 40, new DateTime(2023, 3, 1, 17, 49, 47, 512, DateTimeKind.Local).AddTicks(7424), new DateTime(2022, 8, 6, 21, 9, 15, 278, DateTimeKind.Local).AddTicks(8142), 58, 1944685023, null },
                    { 304, 63, new DateTime(2022, 7, 4, 8, 39, 53, 260, DateTimeKind.Local).AddTicks(9927), new DateTime(2022, 6, 19, 4, 8, 41, 128, DateTimeKind.Local).AddTicks(1641), 43, -1484457429, null },
                    { 305, 28, new DateTime(2022, 6, 3, 20, 11, 40, 64, DateTimeKind.Local).AddTicks(5244), new DateTime(2022, 5, 13, 13, 28, 15, 338, DateTimeKind.Local).AddTicks(1065), 60, 661066945, null },
                    { 306, 119, new DateTime(2023, 1, 31, 18, 16, 8, 706, DateTimeKind.Local).AddTicks(6648), new DateTime(2022, 12, 25, 6, 47, 39, 258, DateTimeKind.Local).AddTicks(9744), 9, -1992947621, null },
                    { 307, 129, new DateTime(2023, 1, 11, 19, 55, 47, 710, DateTimeKind.Local).AddTicks(8508), new DateTime(2022, 12, 24, 10, 53, 47, 865, DateTimeKind.Local).AddTicks(1372), 49, -557430129, null },
                    { 308, 115, new DateTime(2022, 12, 12, 8, 41, 37, 768, DateTimeKind.Local).AddTicks(6989), new DateTime(2023, 3, 26, 7, 19, 33, 100, DateTimeKind.Local).AddTicks(6590), 97, 343508411, null },
                    { 309, 37, new DateTime(2022, 8, 9, 17, 48, 2, 860, DateTimeKind.Local).AddTicks(6519), new DateTime(2022, 4, 25, 23, 25, 28, 556, DateTimeKind.Local).AddTicks(4001), 29, -1153221990, null },
                    { 310, 57, new DateTime(2023, 2, 5, 17, 43, 27, 274, DateTimeKind.Local).AddTicks(3385), new DateTime(2022, 12, 10, 5, 22, 59, 884, DateTimeKind.Local).AddTicks(7977), 14, -1908732660, null },
                    { 311, 120, new DateTime(2022, 10, 6, 4, 55, 51, 655, DateTimeKind.Local).AddTicks(4481), new DateTime(2023, 2, 22, 19, 15, 39, 189, DateTimeKind.Local).AddTicks(566), 49, 804568500, null },
                    { 312, 18, new DateTime(2022, 4, 22, 14, 47, 51, 469, DateTimeKind.Local).AddTicks(2016), new DateTime(2022, 8, 4, 5, 54, 43, 435, DateTimeKind.Local).AddTicks(1681), 72, 537437222, null },
                    { 313, 81, new DateTime(2022, 7, 12, 8, 48, 2, 807, DateTimeKind.Local).AddTicks(2926), new DateTime(2023, 3, 21, 23, 4, 8, 551, DateTimeKind.Local).AddTicks(2772), 20, -536481493, null },
                    { 314, 16, new DateTime(2022, 6, 30, 18, 32, 43, 281, DateTimeKind.Local).AddTicks(6467), new DateTime(2022, 9, 10, 23, 24, 45, 968, DateTimeKind.Local).AddTicks(5865), 63, -1696524661, null },
                    { 315, 30, new DateTime(2023, 1, 4, 5, 2, 16, 12, DateTimeKind.Local).AddTicks(8535), new DateTime(2022, 11, 9, 5, 44, 30, 206, DateTimeKind.Local).AddTicks(3916), 68, -1734462092, null },
                    { 316, 73, new DateTime(2022, 6, 9, 10, 6, 15, 675, DateTimeKind.Local).AddTicks(2661), new DateTime(2022, 6, 24, 12, 3, 57, 860, DateTimeKind.Local).AddTicks(2591), 66, 1959375410, null },
                    { 317, 11, new DateTime(2022, 11, 18, 4, 14, 6, 860, DateTimeKind.Local).AddTicks(5111), new DateTime(2023, 2, 12, 1, 47, 59, 692, DateTimeKind.Local).AddTicks(7320), 92, 550560972, null },
                    { 318, 122, new DateTime(2022, 8, 7, 6, 6, 44, 98, DateTimeKind.Local).AddTicks(4968), new DateTime(2023, 1, 28, 8, 23, 50, 7, DateTimeKind.Local).AddTicks(6953), 73, -1003712680, null },
                    { 319, 78, new DateTime(2022, 11, 7, 12, 27, 46, 875, DateTimeKind.Local).AddTicks(7671), new DateTime(2023, 1, 4, 7, 32, 30, 678, DateTimeKind.Local).AddTicks(3102), 99, 2145750873, null },
                    { 320, 10, new DateTime(2022, 9, 13, 21, 51, 39, 809, DateTimeKind.Local).AddTicks(7539), new DateTime(2022, 12, 4, 4, 42, 34, 289, DateTimeKind.Local).AddTicks(7179), 26, 1419285877, null },
                    { 321, 85, new DateTime(2023, 3, 5, 7, 58, 49, 554, DateTimeKind.Local).AddTicks(783), new DateTime(2022, 11, 13, 5, 33, 24, 790, DateTimeKind.Local).AddTicks(523), 87, 629273282, null },
                    { 322, 41, new DateTime(2022, 11, 10, 3, 48, 55, 936, DateTimeKind.Local).AddTicks(5454), new DateTime(2023, 2, 12, 11, 5, 59, 211, DateTimeKind.Local).AddTicks(4206), 100, -1991925618, null },
                    { 323, 14, new DateTime(2022, 12, 27, 5, 42, 49, 519, DateTimeKind.Local).AddTicks(9226), new DateTime(2022, 5, 10, 6, 23, 54, 50, DateTimeKind.Local).AddTicks(1893), 45, -1639828601, null },
                    { 324, 114, new DateTime(2022, 8, 5, 5, 4, 2, 345, DateTimeKind.Local).AddTicks(3799), new DateTime(2023, 4, 16, 3, 35, 11, 29, DateTimeKind.Local).AddTicks(9780), 9, -431836368, null },
                    { 325, 108, new DateTime(2023, 1, 22, 14, 42, 33, 268, DateTimeKind.Local).AddTicks(1675), new DateTime(2022, 8, 23, 13, 22, 40, 7, DateTimeKind.Local).AddTicks(593), 95, -670638038, null },
                    { 326, 122, new DateTime(2022, 4, 26, 0, 51, 38, 811, DateTimeKind.Local).AddTicks(189), new DateTime(2022, 11, 29, 8, 37, 28, 576, DateTimeKind.Local).AddTicks(3896), 71, 487022870, null },
                    { 327, 83, new DateTime(2023, 3, 18, 4, 46, 40, 860, DateTimeKind.Local).AddTicks(1852), new DateTime(2023, 3, 10, 3, 38, 51, 954, DateTimeKind.Local).AddTicks(3115), 84, -1778768623, null },
                    { 328, 78, new DateTime(2022, 12, 12, 17, 1, 38, 388, DateTimeKind.Local).AddTicks(5513), new DateTime(2022, 9, 7, 9, 39, 4, 488, DateTimeKind.Local).AddTicks(7951), 67, -705192167, null },
                    { 329, 138, new DateTime(2022, 9, 21, 22, 46, 14, 971, DateTimeKind.Local).AddTicks(6069), new DateTime(2023, 3, 16, 1, 14, 48, 233, DateTimeKind.Local).AddTicks(6657), 61, -560949504, null },
                    { 330, 65, new DateTime(2022, 6, 21, 17, 56, 11, 598, DateTimeKind.Local).AddTicks(4452), new DateTime(2022, 8, 27, 9, 52, 31, 673, DateTimeKind.Local).AddTicks(3994), 36, 1726130776, null },
                    { 331, 36, new DateTime(2022, 7, 23, 11, 33, 10, 308, DateTimeKind.Local).AddTicks(1207), new DateTime(2022, 8, 29, 1, 36, 42, 702, DateTimeKind.Local).AddTicks(170), 64, -1182496202, null },
                    { 332, 114, new DateTime(2023, 3, 2, 4, 4, 37, 160, DateTimeKind.Local).AddTicks(221), new DateTime(2023, 1, 23, 21, 15, 25, 593, DateTimeKind.Local).AddTicks(794), 51, 1261629927, null },
                    { 333, 66, new DateTime(2022, 12, 13, 13, 37, 30, 52, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 10, 4, 4, 28, 8, 754, DateTimeKind.Local).AddTicks(7817), 82, 1502805036, null },
                    { 334, 142, new DateTime(2022, 8, 17, 18, 42, 53, 926, DateTimeKind.Local).AddTicks(4823), new DateTime(2023, 3, 28, 8, 55, 18, 428, DateTimeKind.Local).AddTicks(2550), 83, 501136187, null },
                    { 335, 111, new DateTime(2022, 9, 14, 22, 48, 10, 673, DateTimeKind.Local).AddTicks(8234), new DateTime(2022, 11, 7, 8, 40, 28, 432, DateTimeKind.Local).AddTicks(1579), 59, -603879850, null },
                    { 336, 50, new DateTime(2022, 10, 11, 11, 50, 46, 940, DateTimeKind.Local).AddTicks(4973), new DateTime(2022, 5, 14, 18, 11, 31, 751, DateTimeKind.Local).AddTicks(2176), 19, 2050625675, null },
                    { 337, 105, new DateTime(2022, 12, 15, 6, 43, 40, 940, DateTimeKind.Local).AddTicks(6547), new DateTime(2023, 2, 13, 18, 56, 26, 94, DateTimeKind.Local).AddTicks(4814), 75, -415825052, null },
                    { 338, 92, new DateTime(2022, 8, 25, 8, 14, 53, 211, DateTimeKind.Local).AddTicks(8820), new DateTime(2022, 10, 14, 4, 19, 4, 710, DateTimeKind.Local).AddTicks(623), 19, 1342344096, null },
                    { 339, 90, new DateTime(2023, 4, 10, 15, 44, 26, 561, DateTimeKind.Local).AddTicks(6279), new DateTime(2022, 10, 30, 7, 48, 27, 684, DateTimeKind.Local).AddTicks(916), 90, 626506131, null },
                    { 340, 52, new DateTime(2022, 5, 31, 14, 8, 58, 421, DateTimeKind.Local).AddTicks(8252), new DateTime(2023, 3, 19, 21, 59, 19, 37, DateTimeKind.Local).AddTicks(8693), 8, -641425652, null },
                    { 341, 129, new DateTime(2023, 1, 2, 2, 57, 19, 150, DateTimeKind.Local).AddTicks(691), new DateTime(2023, 1, 27, 5, 19, 31, 395, DateTimeKind.Local).AddTicks(835), 42, -1938799763, null },
                    { 342, 122, new DateTime(2022, 7, 5, 10, 24, 13, 269, DateTimeKind.Local).AddTicks(4576), new DateTime(2022, 8, 21, 6, 8, 8, 276, DateTimeKind.Local).AddTicks(7904), 17, -1859532788, null },
                    { 343, 78, new DateTime(2022, 10, 13, 21, 8, 27, 799, DateTimeKind.Local).AddTicks(1005), new DateTime(2022, 9, 3, 10, 55, 51, 810, DateTimeKind.Local).AddTicks(3592), 25, 1030541386, null },
                    { 344, 57, new DateTime(2022, 11, 3, 14, 4, 48, 346, DateTimeKind.Local).AddTicks(2602), new DateTime(2022, 12, 29, 12, 25, 4, 433, DateTimeKind.Local).AddTicks(1505), 84, -1502319137, null },
                    { 345, 122, new DateTime(2022, 5, 26, 9, 18, 9, 228, DateTimeKind.Local).AddTicks(5990), new DateTime(2022, 6, 28, 13, 21, 40, 93, DateTimeKind.Local).AddTicks(3914), 72, -531985481, null },
                    { 346, 144, new DateTime(2023, 4, 1, 17, 5, 48, 526, DateTimeKind.Local).AddTicks(8305), new DateTime(2023, 2, 2, 11, 49, 13, 662, DateTimeKind.Local).AddTicks(4804), 42, -131852723, null },
                    { 347, 126, new DateTime(2022, 8, 25, 14, 35, 31, 588, DateTimeKind.Local).AddTicks(1277), new DateTime(2023, 1, 24, 9, 21, 44, 594, DateTimeKind.Local).AddTicks(5227), 80, 1420131154, null },
                    { 348, 31, new DateTime(2022, 4, 23, 16, 31, 41, 989, DateTimeKind.Local).AddTicks(9946), new DateTime(2023, 1, 21, 19, 48, 19, 295, DateTimeKind.Local).AddTicks(5143), 92, 1839645009, null },
                    { 349, 77, new DateTime(2023, 4, 8, 21, 23, 57, 822, DateTimeKind.Local).AddTicks(6698), new DateTime(2022, 12, 18, 3, 13, 23, 29, DateTimeKind.Local).AddTicks(9854), 86, -1601152270, null },
                    { 350, 45, new DateTime(2022, 7, 15, 5, 51, 54, 230, DateTimeKind.Local).AddTicks(9463), new DateTime(2022, 5, 13, 18, 41, 58, 809, DateTimeKind.Local).AddTicks(6017), 4, -1018807230, null },
                    { 351, 103, new DateTime(2022, 5, 14, 22, 22, 43, 327, DateTimeKind.Local).AddTicks(9126), new DateTime(2022, 8, 16, 5, 15, 35, 492, DateTimeKind.Local).AddTicks(8548), 91, 1472497674, null },
                    { 352, 4, new DateTime(2022, 8, 16, 7, 37, 29, 528, DateTimeKind.Local).AddTicks(7553), new DateTime(2022, 10, 13, 19, 33, 48, 970, DateTimeKind.Local).AddTicks(3258), 10, 1054902161, null },
                    { 353, 109, new DateTime(2022, 7, 19, 11, 34, 12, 5, DateTimeKind.Local).AddTicks(5804), new DateTime(2023, 1, 12, 13, 58, 52, 851, DateTimeKind.Local).AddTicks(3178), 14, -665719854, null },
                    { 354, 12, new DateTime(2022, 8, 18, 14, 3, 14, 960, DateTimeKind.Local).AddTicks(2974), new DateTime(2022, 10, 31, 17, 5, 14, 513, DateTimeKind.Local).AddTicks(9090), 45, -222938579, null },
                    { 355, 13, new DateTime(2022, 11, 11, 13, 44, 53, 791, DateTimeKind.Local).AddTicks(2558), new DateTime(2022, 12, 17, 17, 58, 7, 147, DateTimeKind.Local).AddTicks(3167), 81, 147738425, null },
                    { 356, 84, new DateTime(2022, 7, 22, 22, 26, 40, 65, DateTimeKind.Local).AddTicks(8019), new DateTime(2023, 4, 2, 0, 36, 11, 494, DateTimeKind.Local).AddTicks(1420), 17, 65150967, null },
                    { 357, 42, new DateTime(2022, 7, 12, 10, 46, 34, 284, DateTimeKind.Local).AddTicks(5726), new DateTime(2022, 12, 19, 10, 49, 38, 515, DateTimeKind.Local).AddTicks(3178), 53, -25634885, null },
                    { 358, 19, new DateTime(2023, 1, 12, 0, 15, 24, 631, DateTimeKind.Local).AddTicks(615), new DateTime(2022, 11, 15, 4, 39, 55, 103, DateTimeKind.Local).AddTicks(637), 36, -1377396255, null },
                    { 359, 145, new DateTime(2022, 5, 26, 12, 45, 13, 361, DateTimeKind.Local).AddTicks(7960), new DateTime(2022, 7, 24, 22, 17, 26, 383, DateTimeKind.Local).AddTicks(6751), 5, -1065295077, null },
                    { 360, 57, new DateTime(2023, 3, 10, 14, 11, 32, 379, DateTimeKind.Local).AddTicks(9364), new DateTime(2022, 7, 13, 9, 12, 31, 172, DateTimeKind.Local).AddTicks(2736), 3, 137766098, null },
                    { 361, 21, new DateTime(2023, 3, 16, 3, 39, 36, 376, DateTimeKind.Local).AddTicks(833), new DateTime(2023, 2, 4, 19, 19, 1, 52, DateTimeKind.Local).AddTicks(4810), 17, -1384920485, null },
                    { 362, 109, new DateTime(2022, 7, 3, 14, 54, 37, 445, DateTimeKind.Local).AddTicks(1783), new DateTime(2022, 7, 8, 14, 18, 54, 167, DateTimeKind.Local).AddTicks(3239), 46, -839802334, null },
                    { 363, 85, new DateTime(2022, 10, 8, 21, 51, 1, 319, DateTimeKind.Local).AddTicks(7760), new DateTime(2022, 5, 6, 11, 58, 29, 284, DateTimeKind.Local).AddTicks(4727), 85, 1111705375, null },
                    { 364, 64, new DateTime(2022, 7, 12, 5, 47, 5, 794, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 12, 10, 14, 30, 53, 26, DateTimeKind.Local).AddTicks(6375), 87, -1027243752, null },
                    { 365, 133, new DateTime(2023, 2, 24, 16, 59, 25, 969, DateTimeKind.Local).AddTicks(5679), new DateTime(2022, 6, 21, 11, 14, 27, 748, DateTimeKind.Local).AddTicks(9361), 95, 1344831031, null },
                    { 366, 52, new DateTime(2023, 2, 19, 16, 45, 8, 656, DateTimeKind.Local).AddTicks(7777), new DateTime(2023, 4, 12, 9, 47, 37, 872, DateTimeKind.Local).AddTicks(1442), 26, -1119441491, null },
                    { 367, 49, new DateTime(2023, 1, 30, 11, 32, 13, 555, DateTimeKind.Local).AddTicks(4288), new DateTime(2022, 10, 25, 5, 14, 26, 401, DateTimeKind.Local).AddTicks(3195), 46, 444414260, null },
                    { 368, 140, new DateTime(2022, 11, 10, 15, 22, 51, 806, DateTimeKind.Local).AddTicks(3478), new DateTime(2022, 11, 11, 8, 29, 3, 646, DateTimeKind.Local).AddTicks(2159), 19, -1010254676, null },
                    { 369, 101, new DateTime(2023, 2, 15, 1, 20, 16, 363, DateTimeKind.Local).AddTicks(2203), new DateTime(2023, 4, 8, 8, 50, 5, 367, DateTimeKind.Local).AddTicks(7587), 98, 767866109, null },
                    { 370, 81, new DateTime(2022, 9, 14, 10, 19, 2, 287, DateTimeKind.Local).AddTicks(3962), new DateTime(2022, 6, 29, 0, 40, 15, 354, DateTimeKind.Local).AddTicks(5984), 47, 1241144405, null },
                    { 371, 149, new DateTime(2022, 10, 23, 9, 7, 6, 869, DateTimeKind.Local).AddTicks(7242), new DateTime(2022, 7, 4, 13, 26, 51, 974, DateTimeKind.Local).AddTicks(7769), 49, 1967988453, null },
                    { 372, 48, new DateTime(2022, 9, 25, 20, 56, 38, 378, DateTimeKind.Local).AddTicks(9679), new DateTime(2022, 9, 3, 5, 29, 47, 182, DateTimeKind.Local).AddTicks(2500), 60, -1429783986, null },
                    { 373, 82, new DateTime(2022, 7, 4, 5, 11, 38, 815, DateTimeKind.Local).AddTicks(6735), new DateTime(2023, 2, 24, 18, 52, 45, 843, DateTimeKind.Local).AddTicks(7826), 20, -318328032, null },
                    { 374, 43, new DateTime(2022, 10, 15, 7, 43, 9, 85, DateTimeKind.Local).AddTicks(3831), new DateTime(2022, 6, 23, 10, 46, 54, 740, DateTimeKind.Local).AddTicks(6522), 23, -1914252870, null },
                    { 375, 12, new DateTime(2022, 7, 21, 1, 18, 8, 585, DateTimeKind.Local).AddTicks(1238), new DateTime(2023, 3, 2, 22, 19, 47, 274, DateTimeKind.Local).AddTicks(2236), 98, -174837025, null },
                    { 376, 47, new DateTime(2022, 9, 12, 11, 19, 54, 230, DateTimeKind.Local).AddTicks(7433), new DateTime(2022, 5, 21, 0, 53, 38, 38, DateTimeKind.Local).AddTicks(9670), 51, -1888615280, null },
                    { 377, 14, new DateTime(2022, 4, 28, 20, 5, 1, 206, DateTimeKind.Local).AddTicks(8764), new DateTime(2023, 2, 6, 18, 7, 49, 75, DateTimeKind.Local).AddTicks(1106), 13, 544135589, null },
                    { 378, 112, new DateTime(2022, 5, 29, 2, 11, 5, 757, DateTimeKind.Local).AddTicks(8376), new DateTime(2022, 11, 22, 4, 55, 3, 524, DateTimeKind.Local).AddTicks(6790), 26, -1004232229, null },
                    { 379, 52, new DateTime(2022, 12, 14, 9, 52, 1, 720, DateTimeKind.Local).AddTicks(5781), new DateTime(2023, 1, 10, 19, 58, 36, 939, DateTimeKind.Local).AddTicks(6412), 30, 260429518, null },
                    { 380, 56, new DateTime(2022, 11, 16, 5, 50, 18, 905, DateTimeKind.Local).AddTicks(6940), new DateTime(2023, 2, 25, 20, 40, 52, 90, DateTimeKind.Local).AddTicks(7691), 86, 596348028, null },
                    { 381, 89, new DateTime(2023, 1, 5, 5, 28, 26, 806, DateTimeKind.Local).AddTicks(3944), new DateTime(2022, 8, 28, 19, 41, 34, 571, DateTimeKind.Local).AddTicks(4208), 77, -1495193728, null },
                    { 382, 44, new DateTime(2023, 2, 2, 22, 41, 21, 611, DateTimeKind.Local).AddTicks(8512), new DateTime(2022, 8, 7, 3, 53, 18, 416, DateTimeKind.Local).AddTicks(5955), 15, -1007156674, null },
                    { 383, 53, new DateTime(2023, 3, 30, 15, 36, 36, 436, DateTimeKind.Local).AddTicks(7763), new DateTime(2022, 11, 27, 9, 24, 43, 734, DateTimeKind.Local).AddTicks(8584), 17, -1353884174, null },
                    { 384, 70, new DateTime(2022, 12, 31, 18, 42, 44, 801, DateTimeKind.Local).AddTicks(3911), new DateTime(2023, 2, 15, 6, 39, 9, 954, DateTimeKind.Local).AddTicks(4979), 80, 426142727, null },
                    { 385, 87, new DateTime(2022, 8, 20, 9, 34, 5, 502, DateTimeKind.Local).AddTicks(4033), new DateTime(2022, 10, 16, 5, 32, 16, 262, DateTimeKind.Local).AddTicks(8901), 40, -1840151156, null },
                    { 386, 56, new DateTime(2022, 12, 5, 3, 59, 21, 491, DateTimeKind.Local).AddTicks(8790), new DateTime(2022, 11, 2, 17, 45, 54, 138, DateTimeKind.Local).AddTicks(6607), 35, 2016918245, null },
                    { 387, 58, new DateTime(2022, 6, 10, 16, 28, 21, 327, DateTimeKind.Local).AddTicks(4451), new DateTime(2022, 5, 29, 8, 25, 26, 389, DateTimeKind.Local).AddTicks(4013), 66, -1989010732, null },
                    { 388, 36, new DateTime(2022, 5, 2, 8, 9, 15, 626, DateTimeKind.Local).AddTicks(9747), new DateTime(2022, 9, 9, 4, 52, 7, 218, DateTimeKind.Local).AddTicks(9890), 94, -172941701, null },
                    { 389, 91, new DateTime(2022, 12, 6, 21, 25, 13, 780, DateTimeKind.Local).AddTicks(7094), new DateTime(2022, 5, 18, 14, 51, 59, 150, DateTimeKind.Local).AddTicks(371), 66, 549802315, null },
                    { 390, 144, new DateTime(2022, 7, 11, 23, 22, 33, 308, DateTimeKind.Local).AddTicks(512), new DateTime(2022, 6, 16, 22, 19, 35, 479, DateTimeKind.Local).AddTicks(8183), 3, -283646404, null },
                    { 391, 42, new DateTime(2023, 4, 6, 6, 21, 40, 571, DateTimeKind.Local).AddTicks(5434), new DateTime(2022, 5, 24, 1, 53, 59, 37, DateTimeKind.Local).AddTicks(8139), 89, 1797238846, null },
                    { 392, 75, new DateTime(2022, 9, 8, 12, 8, 38, 126, DateTimeKind.Local).AddTicks(5126), new DateTime(2022, 6, 21, 5, 22, 4, 473, DateTimeKind.Local).AddTicks(1771), 69, 2032743182, null },
                    { 393, 26, new DateTime(2022, 6, 2, 19, 53, 56, 83, DateTimeKind.Local).AddTicks(1650), new DateTime(2023, 1, 5, 9, 21, 5, 252, DateTimeKind.Local).AddTicks(9336), 5, -1483131620, null },
                    { 394, 138, new DateTime(2022, 6, 30, 13, 32, 2, 981, DateTimeKind.Local).AddTicks(846), new DateTime(2022, 11, 24, 13, 2, 39, 159, DateTimeKind.Local).AddTicks(6715), 71, -927163395, null },
                    { 395, 124, new DateTime(2022, 4, 24, 8, 41, 25, 24, DateTimeKind.Local).AddTicks(1232), new DateTime(2022, 7, 16, 16, 11, 24, 409, DateTimeKind.Local).AddTicks(9370), 23, -412336096, null },
                    { 396, 48, new DateTime(2022, 7, 15, 19, 51, 20, 536, DateTimeKind.Local).AddTicks(1951), new DateTime(2022, 5, 17, 14, 58, 31, 327, DateTimeKind.Local).AddTicks(8424), 44, -431038732, null },
                    { 397, 67, new DateTime(2022, 7, 24, 6, 26, 9, 166, DateTimeKind.Local).AddTicks(6341), new DateTime(2023, 2, 7, 3, 6, 3, 873, DateTimeKind.Local).AddTicks(8301), 39, -1449283375, null },
                    { 398, 57, new DateTime(2023, 2, 25, 11, 30, 30, 747, DateTimeKind.Local).AddTicks(528), new DateTime(2022, 11, 11, 23, 23, 16, 167, DateTimeKind.Local).AddTicks(1731), 11, 2028942411, null },
                    { 399, 124, new DateTime(2022, 9, 4, 23, 54, 45, 231, DateTimeKind.Local).AddTicks(1994), new DateTime(2023, 3, 25, 5, 54, 1, 289, DateTimeKind.Local).AddTicks(4243), 81, -477051922, null },
                    { 400, 70, new DateTime(2022, 7, 11, 21, 28, 35, 179, DateTimeKind.Local).AddTicks(1916), new DateTime(2023, 2, 21, 9, 10, 42, 494, DateTimeKind.Local).AddTicks(3439), 34, 2082120729, null },
                    { 401, 5, new DateTime(2022, 6, 14, 19, 52, 5, 605, DateTimeKind.Local).AddTicks(8457), new DateTime(2022, 7, 12, 19, 46, 1, 84, DateTimeKind.Local).AddTicks(3468), 78, -2057675101, null },
                    { 402, 102, new DateTime(2022, 5, 25, 20, 11, 1, 69, DateTimeKind.Local).AddTicks(4131), new DateTime(2022, 7, 22, 17, 37, 26, 895, DateTimeKind.Local).AddTicks(4484), 37, -324736074, null },
                    { 403, 145, new DateTime(2022, 8, 7, 21, 51, 59, 298, DateTimeKind.Local).AddTicks(7577), new DateTime(2023, 2, 3, 22, 23, 1, 509, DateTimeKind.Local).AddTicks(7404), 81, -1364949865, null },
                    { 404, 2, new DateTime(2022, 11, 23, 3, 20, 55, 874, DateTimeKind.Local).AddTicks(7174), new DateTime(2022, 9, 22, 6, 18, 30, 779, DateTimeKind.Local).AddTicks(2715), 98, -749046398, null },
                    { 405, 17, new DateTime(2022, 10, 13, 4, 32, 58, 72, DateTimeKind.Local).AddTicks(2385), new DateTime(2023, 1, 20, 0, 29, 44, 711, DateTimeKind.Local).AddTicks(7169), 52, -1039137330, null },
                    { 406, 63, new DateTime(2022, 7, 27, 23, 51, 8, 270, DateTimeKind.Local).AddTicks(7308), new DateTime(2022, 8, 17, 23, 39, 30, 102, DateTimeKind.Local).AddTicks(2384), 77, -1901731002, null },
                    { 407, 67, new DateTime(2022, 10, 26, 9, 33, 14, 760, DateTimeKind.Local).AddTicks(2430), new DateTime(2022, 5, 30, 12, 23, 31, 97, DateTimeKind.Local).AddTicks(288), 3, 1975821695, null },
                    { 408, 111, new DateTime(2023, 3, 26, 1, 38, 35, 457, DateTimeKind.Local).AddTicks(3717), new DateTime(2022, 7, 16, 5, 51, 32, 367, DateTimeKind.Local).AddTicks(2534), 30, -1409168214, null },
                    { 409, 125, new DateTime(2022, 4, 26, 13, 6, 32, 275, DateTimeKind.Local).AddTicks(4680), new DateTime(2022, 11, 20, 22, 49, 17, 720, DateTimeKind.Local).AddTicks(8734), 6, -2117687655, null },
                    { 410, 149, new DateTime(2022, 9, 27, 8, 11, 0, 295, DateTimeKind.Local).AddTicks(2772), new DateTime(2022, 8, 2, 13, 29, 45, 561, DateTimeKind.Local).AddTicks(5761), 48, 620382670, null },
                    { 411, 150, new DateTime(2022, 11, 26, 21, 3, 55, 390, DateTimeKind.Local).AddTicks(5707), new DateTime(2023, 2, 28, 12, 5, 16, 551, DateTimeKind.Local).AddTicks(4514), 55, -1222892283, null },
                    { 412, 142, new DateTime(2022, 11, 3, 1, 29, 26, 561, DateTimeKind.Local).AddTicks(9831), new DateTime(2022, 7, 3, 7, 33, 36, 564, DateTimeKind.Local).AddTicks(6207), 69, 622329661, null },
                    { 413, 8, new DateTime(2022, 9, 29, 18, 36, 44, 65, DateTimeKind.Local).AddTicks(3465), new DateTime(2023, 1, 28, 10, 57, 49, 428, DateTimeKind.Local).AddTicks(6443), 43, -2143053455, null },
                    { 414, 79, new DateTime(2022, 11, 27, 7, 53, 34, 668, DateTimeKind.Local).AddTicks(21), new DateTime(2022, 12, 7, 8, 59, 12, 851, DateTimeKind.Local).AddTicks(8335), 96, -298171040, null },
                    { 415, 27, new DateTime(2022, 7, 23, 13, 6, 45, 95, DateTimeKind.Local).AddTicks(3214), new DateTime(2022, 5, 18, 1, 13, 46, 86, DateTimeKind.Local).AddTicks(6212), 31, 1997679072, null },
                    { 416, 2, new DateTime(2022, 11, 8, 2, 17, 14, 513, DateTimeKind.Local).AddTicks(8445), new DateTime(2023, 3, 24, 13, 21, 1, 761, DateTimeKind.Local).AddTicks(6484), 21, -728553114, null },
                    { 417, 141, new DateTime(2023, 2, 24, 17, 12, 9, 51, DateTimeKind.Local).AddTicks(1945), new DateTime(2023, 2, 24, 13, 20, 2, 45, DateTimeKind.Local).AddTicks(4578), 91, 962530628, null },
                    { 418, 150, new DateTime(2023, 3, 13, 20, 57, 46, 192, DateTimeKind.Local).AddTicks(6622), new DateTime(2022, 10, 9, 2, 8, 52, 742, DateTimeKind.Local).AddTicks(2778), 4, -335627744, null },
                    { 419, 121, new DateTime(2022, 8, 7, 18, 59, 21, 593, DateTimeKind.Local).AddTicks(3363), new DateTime(2022, 7, 12, 3, 25, 20, 525, DateTimeKind.Local).AddTicks(2022), 56, -15012502, null },
                    { 420, 89, new DateTime(2022, 4, 24, 2, 43, 48, 779, DateTimeKind.Local).AddTicks(6346), new DateTime(2023, 3, 17, 8, 28, 41, 721, DateTimeKind.Local).AddTicks(7602), 3, -12287438, null },
                    { 421, 103, new DateTime(2022, 10, 31, 13, 33, 1, 979, DateTimeKind.Local).AddTicks(1523), new DateTime(2023, 1, 17, 12, 40, 52, 899, DateTimeKind.Local).AddTicks(7243), 99, 131739807, null },
                    { 422, 127, new DateTime(2022, 6, 28, 17, 22, 13, 15, DateTimeKind.Local).AddTicks(4164), new DateTime(2022, 10, 6, 23, 8, 56, 961, DateTimeKind.Local).AddTicks(1243), 19, 1211650838, null },
                    { 423, 93, new DateTime(2023, 3, 11, 20, 37, 14, 167, DateTimeKind.Local).AddTicks(3247), new DateTime(2022, 12, 31, 4, 5, 4, 53, DateTimeKind.Local).AddTicks(563), 45, 393478014, null },
                    { 424, 96, new DateTime(2022, 10, 15, 9, 17, 54, 977, DateTimeKind.Local).AddTicks(7653), new DateTime(2022, 10, 5, 12, 39, 48, 116, DateTimeKind.Local).AddTicks(520), 26, 1385182508, null },
                    { 425, 49, new DateTime(2023, 1, 23, 14, 24, 22, 417, DateTimeKind.Local).AddTicks(7710), new DateTime(2022, 7, 20, 19, 52, 9, 361, DateTimeKind.Local).AddTicks(1562), 56, -2102133030, null },
                    { 426, 47, new DateTime(2022, 7, 15, 22, 32, 4, 971, DateTimeKind.Local).AddTicks(9590), new DateTime(2022, 11, 13, 9, 15, 45, 934, DateTimeKind.Local).AddTicks(904), 80, 900732748, null },
                    { 427, 4, new DateTime(2022, 8, 19, 12, 48, 45, 510, DateTimeKind.Local).AddTicks(2037), new DateTime(2023, 2, 23, 12, 23, 1, 811, DateTimeKind.Local).AddTicks(2338), 95, -204780652, null },
                    { 428, 94, new DateTime(2022, 12, 16, 6, 3, 39, 19, DateTimeKind.Local).AddTicks(7038), new DateTime(2022, 8, 1, 5, 23, 6, 804, DateTimeKind.Local).AddTicks(3298), 84, 217258691, null },
                    { 429, 98, new DateTime(2022, 5, 13, 15, 15, 37, 762, DateTimeKind.Local).AddTicks(5932), new DateTime(2022, 10, 11, 17, 9, 7, 358, DateTimeKind.Local).AddTicks(2501), 20, 969608359, null },
                    { 430, 29, new DateTime(2022, 5, 30, 9, 22, 49, 165, DateTimeKind.Local).AddTicks(3140), new DateTime(2023, 3, 28, 21, 57, 3, 75, DateTimeKind.Local).AddTicks(156), 55, -1887427075, null },
                    { 431, 93, new DateTime(2022, 8, 4, 6, 45, 59, 213, DateTimeKind.Local).AddTicks(6554), new DateTime(2022, 11, 16, 19, 51, 7, 139, DateTimeKind.Local).AddTicks(911), 14, 1476278395, null },
                    { 432, 121, new DateTime(2023, 1, 10, 0, 13, 23, 415, DateTimeKind.Local).AddTicks(7245), new DateTime(2022, 5, 18, 6, 8, 44, 679, DateTimeKind.Local).AddTicks(8497), 90, 302989290, null },
                    { 433, 25, new DateTime(2023, 1, 30, 1, 56, 57, 797, DateTimeKind.Local).AddTicks(8331), new DateTime(2022, 8, 5, 10, 9, 35, 173, DateTimeKind.Local).AddTicks(2738), 30, 1417581695, null },
                    { 434, 37, new DateTime(2023, 1, 1, 21, 36, 26, 565, DateTimeKind.Local).AddTicks(6132), new DateTime(2022, 8, 14, 12, 45, 38, 777, DateTimeKind.Local).AddTicks(5702), 36, 1685904185, null },
                    { 435, 6, new DateTime(2022, 12, 30, 1, 5, 29, 670, DateTimeKind.Local).AddTicks(4331), new DateTime(2023, 2, 20, 2, 27, 16, 243, DateTimeKind.Local).AddTicks(3394), 93, -358061447, null },
                    { 436, 99, new DateTime(2022, 8, 6, 6, 12, 33, 116, DateTimeKind.Local).AddTicks(9627), new DateTime(2022, 6, 23, 17, 2, 43, 659, DateTimeKind.Local).AddTicks(774), 19, 49537326, null },
                    { 437, 59, new DateTime(2023, 3, 10, 19, 39, 22, 359, DateTimeKind.Local).AddTicks(592), new DateTime(2022, 9, 9, 12, 14, 20, 923, DateTimeKind.Local).AddTicks(683), 28, 2019090302, null },
                    { 438, 149, new DateTime(2022, 4, 24, 3, 28, 25, 152, DateTimeKind.Local).AddTicks(7945), new DateTime(2022, 12, 8, 2, 48, 56, 83, DateTimeKind.Local).AddTicks(3262), 71, -1135835256, null },
                    { 439, 27, new DateTime(2022, 9, 7, 6, 17, 0, 475, DateTimeKind.Local).AddTicks(417), new DateTime(2023, 2, 11, 7, 45, 58, 36, DateTimeKind.Local).AddTicks(1556), 44, 699857832, null },
                    { 440, 51, new DateTime(2022, 10, 4, 10, 24, 26, 977, DateTimeKind.Local).AddTicks(5431), new DateTime(2023, 2, 23, 9, 39, 36, 59, DateTimeKind.Local).AddTicks(7701), 61, -43389081, null },
                    { 441, 112, new DateTime(2022, 6, 11, 15, 40, 49, 308, DateTimeKind.Local).AddTicks(3077), new DateTime(2022, 8, 17, 1, 33, 45, 336, DateTimeKind.Local).AddTicks(9636), 76, 2140527610, null },
                    { 442, 96, new DateTime(2022, 12, 9, 17, 4, 42, 532, DateTimeKind.Local).AddTicks(7912), new DateTime(2022, 5, 6, 16, 30, 57, 245, DateTimeKind.Local).AddTicks(6063), 41, -1231092358, null },
                    { 443, 39, new DateTime(2022, 9, 14, 22, 44, 39, 164, DateTimeKind.Local).AddTicks(5552), new DateTime(2022, 10, 12, 19, 51, 1, 888, DateTimeKind.Local).AddTicks(2845), 36, -1295294698, null },
                    { 444, 110, new DateTime(2022, 6, 3, 5, 8, 7, 586, DateTimeKind.Local).AddTicks(4592), new DateTime(2022, 10, 26, 23, 32, 52, 652, DateTimeKind.Local).AddTicks(221), 90, 1917579902, null },
                    { 445, 133, new DateTime(2023, 2, 26, 6, 50, 31, 765, DateTimeKind.Local).AddTicks(1264), new DateTime(2022, 10, 17, 22, 34, 6, 563, DateTimeKind.Local).AddTicks(6438), 92, 78184389, null },
                    { 446, 100, new DateTime(2023, 1, 30, 23, 30, 13, 263, DateTimeKind.Local).AddTicks(7517), new DateTime(2022, 12, 27, 19, 30, 19, 853, DateTimeKind.Local).AddTicks(5037), 70, -265807741, null },
                    { 447, 129, new DateTime(2023, 1, 11, 20, 52, 35, 739, DateTimeKind.Local).AddTicks(6292), new DateTime(2023, 2, 11, 10, 47, 59, 898, DateTimeKind.Local).AddTicks(8772), 18, 533497437, null },
                    { 448, 17, new DateTime(2023, 3, 23, 16, 25, 18, 504, DateTimeKind.Local).AddTicks(6625), new DateTime(2022, 9, 16, 6, 40, 25, 330, DateTimeKind.Local).AddTicks(9221), 63, -438081776, null },
                    { 449, 23, new DateTime(2022, 11, 22, 19, 15, 53, 365, DateTimeKind.Local).AddTicks(9529), new DateTime(2022, 11, 10, 1, 5, 49, 628, DateTimeKind.Local).AddTicks(3004), 50, 1998535800, null },
                    { 450, 5, new DateTime(2022, 11, 18, 23, 34, 32, 344, DateTimeKind.Local).AddTicks(670), new DateTime(2022, 8, 27, 8, 3, 26, 497, DateTimeKind.Local).AddTicks(6339), 81, -105100608, null },
                    { 451, 24, new DateTime(2023, 1, 17, 14, 15, 49, 145, DateTimeKind.Local).AddTicks(756), new DateTime(2022, 11, 4, 19, 5, 27, 401, DateTimeKind.Local).AddTicks(1755), 4, -465726019, null },
                    { 452, 71, new DateTime(2022, 10, 29, 23, 21, 9, 169, DateTimeKind.Local).AddTicks(5884), new DateTime(2022, 8, 2, 21, 18, 21, 481, DateTimeKind.Local).AddTicks(7668), 40, 1191374367, null },
                    { 453, 21, new DateTime(2023, 1, 11, 4, 58, 24, 92, DateTimeKind.Local).AddTicks(9960), new DateTime(2022, 7, 29, 21, 33, 59, 688, DateTimeKind.Local).AddTicks(4277), 31, -1372463730, null },
                    { 454, 6, new DateTime(2022, 11, 3, 21, 29, 21, 309, DateTimeKind.Local).AddTicks(1700), new DateTime(2023, 3, 16, 10, 9, 15, 354, DateTimeKind.Local).AddTicks(8262), 20, 1363359549, null },
                    { 455, 82, new DateTime(2022, 10, 20, 7, 45, 42, 42, DateTimeKind.Local).AddTicks(4193), new DateTime(2022, 9, 29, 9, 17, 4, 570, DateTimeKind.Local).AddTicks(6005), 54, -35593275, null },
                    { 456, 27, new DateTime(2022, 12, 22, 0, 59, 23, 332, DateTimeKind.Local).AddTicks(1139), new DateTime(2023, 1, 18, 23, 4, 58, 218, DateTimeKind.Local).AddTicks(6336), 38, -685184637, null },
                    { 457, 1, new DateTime(2023, 4, 12, 11, 1, 17, 850, DateTimeKind.Local).AddTicks(7089), new DateTime(2022, 7, 22, 2, 58, 48, 273, DateTimeKind.Local).AddTicks(1794), 19, 297421333, null },
                    { 458, 66, new DateTime(2022, 8, 16, 19, 17, 35, 786, DateTimeKind.Local).AddTicks(888), new DateTime(2022, 5, 30, 13, 5, 41, 133, DateTimeKind.Local).AddTicks(2662), 33, 26523055, null },
                    { 459, 75, new DateTime(2022, 10, 30, 9, 27, 46, 763, DateTimeKind.Local).AddTicks(3806), new DateTime(2022, 10, 3, 23, 58, 44, 607, DateTimeKind.Local).AddTicks(2542), 48, -1609844361, null },
                    { 460, 115, new DateTime(2022, 5, 22, 11, 9, 16, 428, DateTimeKind.Local).AddTicks(4831), new DateTime(2022, 8, 4, 1, 7, 35, 0, DateTimeKind.Local).AddTicks(1426), 42, -876667996, null },
                    { 461, 84, new DateTime(2022, 6, 1, 8, 31, 53, 172, DateTimeKind.Local).AddTicks(5189), new DateTime(2022, 10, 20, 23, 44, 21, 60, DateTimeKind.Local).AddTicks(5823), 39, 1752134275, null },
                    { 462, 53, new DateTime(2022, 11, 27, 19, 53, 4, 293, DateTimeKind.Local).AddTicks(1172), new DateTime(2022, 11, 1, 11, 56, 18, 593, DateTimeKind.Local).AddTicks(7870), 85, -2108213250, null },
                    { 463, 47, new DateTime(2022, 5, 23, 2, 59, 7, 91, DateTimeKind.Local).AddTicks(6320), new DateTime(2023, 1, 13, 23, 1, 42, 381, DateTimeKind.Local).AddTicks(2413), 70, -1775425866, null },
                    { 464, 130, new DateTime(2023, 1, 9, 18, 5, 3, 420, DateTimeKind.Local).AddTicks(7658), new DateTime(2022, 6, 8, 21, 46, 32, 136, DateTimeKind.Local).AddTicks(4626), 54, -1244743372, null },
                    { 465, 1, new DateTime(2023, 1, 10, 18, 3, 51, 950, DateTimeKind.Local).AddTicks(7463), new DateTime(2022, 11, 25, 7, 13, 44, 561, DateTimeKind.Local).AddTicks(5019), 84, -679586372, null },
                    { 466, 109, new DateTime(2022, 11, 29, 18, 41, 46, 955, DateTimeKind.Local).AddTicks(6690), new DateTime(2022, 6, 7, 13, 10, 43, 738, DateTimeKind.Local).AddTicks(3137), 46, 1954046189, null },
                    { 467, 58, new DateTime(2023, 1, 18, 16, 28, 21, 507, DateTimeKind.Local).AddTicks(8392), new DateTime(2022, 8, 6, 2, 57, 10, 740, DateTimeKind.Local).AddTicks(4276), 47, -1206601644, null },
                    { 468, 138, new DateTime(2022, 8, 14, 21, 29, 7, 37, DateTimeKind.Local).AddTicks(1667), new DateTime(2022, 7, 11, 8, 38, 51, 644, DateTimeKind.Local).AddTicks(2072), 58, 120536348, null },
                    { 469, 119, new DateTime(2023, 2, 17, 18, 33, 17, 55, DateTimeKind.Local).AddTicks(6018), new DateTime(2022, 6, 25, 5, 21, 3, 789, DateTimeKind.Local).AddTicks(1220), 64, -1422530042, null },
                    { 470, 125, new DateTime(2022, 11, 22, 23, 15, 58, 812, DateTimeKind.Local).AddTicks(942), new DateTime(2022, 6, 18, 21, 7, 11, 604, DateTimeKind.Local).AddTicks(3156), 30, 66803958, null },
                    { 471, 84, new DateTime(2023, 4, 2, 18, 5, 21, 1, DateTimeKind.Local).AddTicks(6123), new DateTime(2023, 4, 13, 8, 26, 51, 485, DateTimeKind.Local).AddTicks(950), 62, -1048031110, null },
                    { 472, 62, new DateTime(2022, 12, 12, 1, 15, 40, 425, DateTimeKind.Local).AddTicks(6110), new DateTime(2022, 9, 7, 5, 45, 5, 377, DateTimeKind.Local).AddTicks(2473), 54, -2099811757, null },
                    { 473, 92, new DateTime(2022, 8, 4, 6, 52, 47, 855, DateTimeKind.Local).AddTicks(8386), new DateTime(2022, 11, 19, 12, 26, 12, 361, DateTimeKind.Local).AddTicks(3439), 23, -681484474, null },
                    { 474, 77, new DateTime(2023, 1, 16, 13, 34, 34, 616, DateTimeKind.Local).AddTicks(2636), new DateTime(2022, 8, 20, 9, 18, 21, 588, DateTimeKind.Local).AddTicks(7175), 50, 1320109994, null },
                    { 475, 3, new DateTime(2023, 4, 8, 21, 20, 54, 53, DateTimeKind.Local).AddTicks(5724), new DateTime(2022, 10, 31, 22, 53, 11, 416, DateTimeKind.Local).AddTicks(9422), 18, -506826605, null },
                    { 476, 104, new DateTime(2022, 5, 28, 18, 36, 49, 973, DateTimeKind.Local).AddTicks(1880), new DateTime(2022, 7, 7, 2, 19, 45, 539, DateTimeKind.Local).AddTicks(7851), 11, -613320275, null },
                    { 477, 21, new DateTime(2022, 9, 3, 23, 3, 34, 384, DateTimeKind.Local).AddTicks(8390), new DateTime(2022, 7, 19, 20, 8, 48, 635, DateTimeKind.Local).AddTicks(5138), 64, -1867529407, null },
                    { 478, 69, new DateTime(2022, 9, 24, 9, 4, 47, 704, DateTimeKind.Local).AddTicks(9851), new DateTime(2023, 4, 17, 6, 47, 49, 450, DateTimeKind.Local).AddTicks(205), 70, 590365265, null },
                    { 479, 66, new DateTime(2022, 7, 7, 20, 5, 40, 50, DateTimeKind.Local).AddTicks(9020), new DateTime(2022, 5, 26, 3, 24, 56, 97, DateTimeKind.Local).AddTicks(950), 61, 1399050136, null },
                    { 480, 56, new DateTime(2022, 12, 18, 21, 10, 37, 901, DateTimeKind.Local).AddTicks(7002), new DateTime(2023, 3, 29, 21, 4, 28, 572, DateTimeKind.Local).AddTicks(3014), 69, -1091837849, null },
                    { 481, 96, new DateTime(2022, 10, 28, 7, 18, 13, 923, DateTimeKind.Local).AddTicks(6129), new DateTime(2022, 5, 1, 20, 35, 8, 963, DateTimeKind.Local).AddTicks(8215), 4, 455441543, null },
                    { 482, 40, new DateTime(2023, 1, 7, 7, 21, 2, 762, DateTimeKind.Local).AddTicks(2880), new DateTime(2023, 3, 3, 10, 59, 31, 99, DateTimeKind.Local).AddTicks(5626), 22, 1580355705, null },
                    { 483, 76, new DateTime(2022, 8, 27, 9, 31, 41, 516, DateTimeKind.Local).AddTicks(8381), new DateTime(2023, 1, 7, 8, 17, 29, 967, DateTimeKind.Local).AddTicks(4151), 54, -165615392, null },
                    { 484, 141, new DateTime(2022, 7, 27, 3, 47, 19, 325, DateTimeKind.Local).AddTicks(8246), new DateTime(2022, 5, 15, 9, 9, 5, 928, DateTimeKind.Local).AddTicks(540), 81, -494422732, null },
                    { 485, 40, new DateTime(2022, 12, 1, 5, 52, 25, 541, DateTimeKind.Local).AddTicks(396), new DateTime(2022, 11, 24, 12, 36, 45, 359, DateTimeKind.Local).AddTicks(3339), 67, -2020131501, null },
                    { 486, 91, new DateTime(2022, 5, 19, 19, 3, 59, 689, DateTimeKind.Local).AddTicks(2860), new DateTime(2022, 7, 10, 21, 51, 52, 155, DateTimeKind.Local).AddTicks(3172), 80, -673092489, null },
                    { 487, 106, new DateTime(2022, 6, 27, 5, 34, 25, 276, DateTimeKind.Local).AddTicks(8949), new DateTime(2023, 3, 28, 19, 18, 3, 505, DateTimeKind.Local).AddTicks(6324), 5, -511782949, null },
                    { 488, 54, new DateTime(2022, 4, 26, 16, 4, 26, 723, DateTimeKind.Local).AddTicks(8180), new DateTime(2022, 6, 29, 0, 31, 21, 771, DateTimeKind.Local).AddTicks(8550), 74, -930849784, null },
                    { 489, 146, new DateTime(2022, 11, 12, 17, 19, 13, 912, DateTimeKind.Local).AddTicks(7193), new DateTime(2022, 10, 28, 21, 33, 31, 118, DateTimeKind.Local).AddTicks(417), 69, -626883753, null },
                    { 490, 139, new DateTime(2022, 9, 21, 20, 45, 1, 723, DateTimeKind.Local).AddTicks(6026), new DateTime(2022, 12, 4, 8, 28, 26, 238, DateTimeKind.Local).AddTicks(3764), 22, 245558254, null },
                    { 491, 75, new DateTime(2023, 1, 31, 12, 8, 21, 239, DateTimeKind.Local).AddTicks(3941), new DateTime(2023, 2, 6, 16, 23, 5, 191, DateTimeKind.Local).AddTicks(2220), 86, -1386223305, null },
                    { 492, 44, new DateTime(2023, 2, 4, 11, 56, 46, 261, DateTimeKind.Local).AddTicks(9537), new DateTime(2022, 8, 19, 21, 25, 54, 659, DateTimeKind.Local).AddTicks(4469), 82, -399671470, null },
                    { 493, 129, new DateTime(2023, 1, 24, 7, 59, 51, 843, DateTimeKind.Local).AddTicks(2524), new DateTime(2022, 11, 15, 16, 25, 14, 373, DateTimeKind.Local).AddTicks(2235), 71, 1642364398, null },
                    { 494, 140, new DateTime(2023, 1, 12, 8, 55, 14, 582, DateTimeKind.Local).AddTicks(1827), new DateTime(2022, 11, 12, 15, 24, 0, 684, DateTimeKind.Local).AddTicks(2778), 99, 1808642757, null },
                    { 495, 106, new DateTime(2022, 5, 17, 3, 1, 47, 71, DateTimeKind.Local).AddTicks(7772), new DateTime(2022, 10, 14, 20, 26, 40, 380, DateTimeKind.Local).AddTicks(5178), 72, -369438671, null },
                    { 496, 34, new DateTime(2022, 11, 25, 12, 12, 44, 313, DateTimeKind.Local).AddTicks(3708), new DateTime(2023, 2, 11, 12, 47, 43, 847, DateTimeKind.Local).AddTicks(1058), 46, -784464108, null },
                    { 497, 126, new DateTime(2022, 9, 14, 19, 10, 3, 464, DateTimeKind.Local).AddTicks(7959), new DateTime(2022, 6, 19, 9, 31, 32, 676, DateTimeKind.Local).AddTicks(9518), 53, -176401214, null },
                    { 498, 39, new DateTime(2022, 8, 2, 8, 34, 31, 328, DateTimeKind.Local).AddTicks(8622), new DateTime(2022, 7, 22, 12, 20, 18, 214, DateTimeKind.Local).AddTicks(6334), 51, -1213119803, null },
                    { 499, 2, new DateTime(2022, 10, 3, 10, 40, 37, 704, DateTimeKind.Local).AddTicks(808), new DateTime(2022, 12, 31, 15, 2, 5, 675, DateTimeKind.Local).AddTicks(9), 69, 506665965, null },
                    { 500, 109, new DateTime(2022, 5, 4, 3, 42, 39, 70, DateTimeKind.Local).AddTicks(3939), new DateTime(2022, 7, 17, 7, 42, 59, 124, DateTimeKind.Local).AddTicks(6340), 40, 212772350, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 20, 36, 42, 502, DateTimeKind.Local).AddTicks(9081), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 908, DateTimeKind.Local).AddTicks(5175), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 17, 20, 36, 42, 505, DateTimeKind.Local).AddTicks(4289), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 911, DateTimeKind.Local).AddTicks(353), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 17, 20, 36, 42, 507, DateTimeKind.Local).AddTicks(5778), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 913, DateTimeKind.Local).AddTicks(1831), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 17, 20, 36, 42, 509, DateTimeKind.Local).AddTicks(5636), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 915, DateTimeKind.Local).AddTicks(1682), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 17, 20, 36, 42, 511, DateTimeKind.Local).AddTicks(4425), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 917, DateTimeKind.Local).AddTicks(467), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 17, 20, 36, 42, 513, DateTimeKind.Local).AddTicks(2716), "Metal_Chicken.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 918, DateTimeKind.Local).AddTicks(8752), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 17, 20, 36, 42, 515, DateTimeKind.Local).AddTicks(4339), "Metal_Shoes.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 921, DateTimeKind.Local).AddTicks(405), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 17, 20, 36, 42, 517, DateTimeKind.Local).AddTicks(5598), "Metal_Shoes2.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 923, DateTimeKind.Local).AddTicks(1651), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 17, 20, 36, 42, 519, DateTimeKind.Local).AddTicks(5744), "Steel_Computer.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 925, DateTimeKind.Local).AddTicks(1792), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 17, 20, 36, 42, 521, DateTimeKind.Local).AddTicks(7241), "Cotton_Cheese.jpg", new DateTime(2023, 3, 9, 4, 49, 52, 927, DateTimeKind.Local).AddTicks(3303), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 17, 20, 36, 42, 608, DateTimeKind.Local).AddTicks(9965), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 9, 4, 49, 53, 14, DateTimeKind.Local).AddTicks(6081), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 17, 20, 36, 42, 611, DateTimeKind.Local).AddTicks(1415), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 9, 4, 49, 53, 16, DateTimeKind.Local).AddTicks(7491), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 17, 20, 36, 42, 612, DateTimeKind.Local).AddTicks(8491), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 9, 4, 49, 53, 18, DateTimeKind.Local).AddTicks(4555), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 4, 49, 52, 896, DateTimeKind.Local).AddTicks(8797), null, 1, new DateTime(2022, 10, 30, 3, 56, 6, 160, DateTimeKind.Local).AddTicks(8226), "Computers" },
                    { 2, new DateTime(2022, 8, 21, 15, 4, 59, 126, DateTimeKind.Local).AddTicks(8392), null, 2, new DateTime(2022, 11, 11, 15, 46, 22, 846, DateTimeKind.Local).AddTicks(6624), "Shoes" },
                    { 3, new DateTime(2022, 5, 9, 2, 42, 54, 221, DateTimeKind.Local).AddTicks(3942), null, 3, new DateTime(2023, 3, 12, 15, 51, 16, 81, DateTimeKind.Local).AddTicks(9681), "Garden" },
                    { 4, new DateTime(2023, 4, 8, 4, 5, 24, 435, DateTimeKind.Local).AddTicks(6261), null, 4, new DateTime(2023, 1, 18, 2, 12, 47, 827, DateTimeKind.Local).AddTicks(9343), "Baby" },
                    { 5, new DateTime(2022, 4, 22, 8, 35, 18, 191, DateTimeKind.Local).AddTicks(7743), null, 5, new DateTime(2022, 8, 12, 15, 33, 0, 284, DateTimeKind.Local).AddTicks(8163), "Garden" },
                    { 6, new DateTime(2023, 1, 5, 10, 14, 26, 154, DateTimeKind.Local).AddTicks(2461), null, 6, new DateTime(2022, 9, 6, 0, 30, 50, 630, DateTimeKind.Local).AddTicks(945), "Baby" },
                    { 7, new DateTime(2022, 8, 5, 11, 12, 35, 5, DateTimeKind.Local).AddTicks(96), null, 7, new DateTime(2022, 5, 6, 22, 53, 21, 859, DateTimeKind.Local).AddTicks(7251), "Clothing" },
                    { 8, new DateTime(2023, 2, 18, 21, 24, 5, 952, DateTimeKind.Local).AddTicks(7053), null, 8, new DateTime(2022, 11, 30, 4, 52, 55, 54, DateTimeKind.Local).AddTicks(7724), "Music" },
                    { 9, new DateTime(2023, 2, 15, 18, 24, 58, 820, DateTimeKind.Local).AddTicks(9325), null, 9, new DateTime(2022, 7, 2, 21, 24, 14, 635, DateTimeKind.Local).AddTicks(9029), "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 3, 5 },
                    { 6, 6 },
                    { 1, 7 },
                    { 2, 8 },
                    { 5, 9 },
                    { 2, 10 },
                    { 7, 11 },
                    { 4, 12 },
                    { 6, 13 },
                    { 7, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 3, 18 },
                    { 7, 19 },
                    { 5, 20 },
                    { 3, 21 },
                    { 5, 22 },
                    { 1, 23 },
                    { 2, 24 },
                    { 7, 25 },
                    { 6, 26 },
                    { 5, 27 },
                    { 5, 28 },
                    { 2, 29 },
                    { 7, 30 },
                    { 2, 31 },
                    { 2, 32 },
                    { 4, 33 },
                    { 1, 34 },
                    { 6, 35 },
                    { 1, 36 },
                    { 7, 37 },
                    { 9, 38 },
                    { 1, 39 },
                    { 1, 40 },
                    { 7, 41 },
                    { 1, 42 },
                    { 5, 43 },
                    { 8, 44 },
                    { 2, 45 },
                    { 7, 46 },
                    { 8, 47 },
                    { 9, 48 },
                    { 7, 49 },
                    { 9, 50 },
                    { 9, 51 },
                    { 6, 52 },
                    { 8, 53 },
                    { 5, 54 },
                    { 2, 55 },
                    { 1, 56 },
                    { 1, 57 },
                    { 1, 58 },
                    { 7, 59 },
                    { 5, 60 },
                    { 4, 61 },
                    { 3, 62 },
                    { 3, 63 },
                    { 9, 64 },
                    { 2, 65 },
                    { 6, 66 },
                    { 8, 67 },
                    { 3, 68 },
                    { 1, 69 },
                    { 9, 70 },
                    { 9, 71 },
                    { 4, 72 },
                    { 1, 73 },
                    { 7, 74 },
                    { 9, 75 },
                    { 1, 76 },
                    { 9, 77 },
                    { 7, 78 },
                    { 2, 79 },
                    { 1, 80 },
                    { 2, 81 },
                    { 9, 82 },
                    { 7, 83 },
                    { 6, 84 },
                    { 6, 85 },
                    { 3, 86 },
                    { 6, 87 },
                    { 8, 88 },
                    { 6, 89 },
                    { 7, 90 },
                    { 5, 91 },
                    { 2, 92 },
                    { 4, 93 },
                    { 6, 94 },
                    { 8, 95 },
                    { 8, 96 },
                    { 7, 97 },
                    { 7, 98 },
                    { 5, 99 },
                    { 7, 100 }
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
