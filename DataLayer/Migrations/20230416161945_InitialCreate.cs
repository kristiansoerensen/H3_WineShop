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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_AspNetUsers_Countries_CountryId",
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
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                table: "Baskets",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 23, 59, 32, 716, DateTimeKind.Local).AddTicks(8396), new DateTime(2023, 3, 7, 8, 12, 43, 122, DateTimeKind.Local).AddTicks(4590), null },
                    { 2, new DateTime(2022, 10, 28, 7, 18, 56, 386, DateTimeKind.Local).AddTicks(3974), new DateTime(2022, 7, 9, 3, 4, 37, 594, DateTimeKind.Local).AddTicks(7638), null },
                    { 3, new DateTime(2022, 8, 19, 18, 27, 49, 352, DateTimeKind.Local).AddTicks(3994), new DateTime(2022, 11, 9, 19, 9, 13, 72, DateTimeKind.Local).AddTicks(2222), null },
                    { 4, new DateTime(2022, 12, 8, 12, 33, 19, 617, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 5, 7, 6, 5, 44, 446, DateTimeKind.Local).AddTicks(9534), null },
                    { 5, new DateTime(2023, 3, 10, 19, 14, 6, 307, DateTimeKind.Local).AddTicks(5275), new DateTime(2022, 8, 25, 6, 25, 6, 793, DateTimeKind.Local).AddTicks(8991), null },
                    { 6, new DateTime(2023, 4, 6, 7, 28, 14, 661, DateTimeKind.Local).AddTicks(1854), new DateTime(2023, 1, 16, 5, 35, 38, 53, DateTimeKind.Local).AddTicks(4937), null },
                    { 7, new DateTime(2022, 12, 20, 22, 9, 52, 74, DateTimeKind.Local).AddTicks(5141), new DateTime(2022, 4, 20, 11, 58, 8, 417, DateTimeKind.Local).AddTicks(3336), null },
                    { 8, new DateTime(2022, 8, 10, 18, 55, 50, 510, DateTimeKind.Local).AddTicks(3759), new DateTime(2022, 8, 20, 17, 30, 40, 781, DateTimeKind.Local).AddTicks(7023), null },
                    { 9, new DateTime(2023, 1, 3, 13, 37, 16, 379, DateTimeKind.Local).AddTicks(8056), new DateTime(2022, 9, 4, 3, 53, 40, 855, DateTimeKind.Local).AddTicks(6540), null },
                    { 10, new DateTime(2022, 8, 2, 17, 5, 8, 761, DateTimeKind.Local).AddTicks(2865), new DateTime(2022, 8, 3, 14, 35, 25, 230, DateTimeKind.Local).AddTicks(5690), null },
                    { 11, new DateTime(2022, 5, 5, 2, 16, 12, 85, DateTimeKind.Local).AddTicks(2850), new DateTime(2023, 3, 13, 16, 14, 46, 61, DateTimeKind.Local).AddTicks(2867), null },
                    { 12, new DateTime(2023, 2, 17, 0, 46, 56, 178, DateTimeKind.Local).AddTicks(2650), new DateTime(2022, 11, 28, 8, 15, 45, 280, DateTimeKind.Local).AddTicks(3322), null },
                    { 13, new DateTime(2022, 6, 29, 12, 18, 26, 606, DateTimeKind.Local).AddTicks(4678), new DateTime(2023, 2, 13, 21, 47, 49, 46, DateTimeKind.Local).AddTicks(4921), null },
                    { 14, new DateTime(2022, 7, 1, 0, 47, 4, 861, DateTimeKind.Local).AddTicks(4628), new DateTime(2022, 12, 25, 15, 0, 35, 341, DateTimeKind.Local).AddTicks(1518), null },
                    { 15, new DateTime(2022, 6, 20, 8, 36, 0, 610, DateTimeKind.Local).AddTicks(1748), new DateTime(2022, 5, 28, 4, 51, 21, 754, DateTimeKind.Local).AddTicks(5322), null },
                    { 16, new DateTime(2022, 9, 25, 17, 7, 15, 355, DateTimeKind.Local).AddTicks(3355), new DateTime(2022, 7, 29, 3, 44, 21, 531, DateTimeKind.Local).AddTicks(5575), null },
                    { 17, new DateTime(2022, 8, 4, 12, 29, 51, 823, DateTimeKind.Local).AddTicks(5563), new DateTime(2023, 4, 11, 19, 4, 1, 385, DateTimeKind.Local).AddTicks(6955), null },
                    { 18, new DateTime(2022, 4, 19, 17, 29, 40, 608, DateTimeKind.Local).AddTicks(8743), new DateTime(2022, 6, 26, 11, 7, 37, 775, DateTimeKind.Local).AddTicks(8057), null },
                    { 19, new DateTime(2022, 6, 7, 7, 44, 7, 46, DateTimeKind.Local).AddTicks(1362), new DateTime(2023, 3, 24, 22, 48, 0, 334, DateTimeKind.Local).AddTicks(3753), null },
                    { 20, new DateTime(2022, 10, 11, 0, 14, 23, 772, DateTimeKind.Local).AddTicks(9701), new DateTime(2022, 10, 7, 1, 4, 1, 195, DateTimeKind.Local).AddTicks(8887), null },
                    { 21, new DateTime(2023, 1, 7, 4, 22, 50, 993, DateTimeKind.Local).AddTicks(8304), new DateTime(2022, 4, 19, 0, 40, 23, 494, DateTimeKind.Local).AddTicks(3452), null },
                    { 22, new DateTime(2022, 8, 7, 12, 15, 15, 952, DateTimeKind.Local).AddTicks(7937), new DateTime(2022, 11, 26, 15, 34, 39, 277, DateTimeKind.Local).AddTicks(872), null },
                    { 23, new DateTime(2022, 11, 9, 5, 33, 50, 443, DateTimeKind.Local).AddTicks(9959), new DateTime(2022, 8, 13, 5, 46, 36, 389, DateTimeKind.Local).AddTicks(3895), null },
                    { 24, new DateTime(2022, 8, 12, 12, 27, 56, 725, DateTimeKind.Local).AddTicks(7768), new DateTime(2022, 10, 26, 3, 56, 49, 195, DateTimeKind.Local).AddTicks(8670), null },
                    { 25, new DateTime(2023, 1, 17, 12, 20, 41, 901, DateTimeKind.Local).AddTicks(7028), new DateTime(2022, 12, 8, 17, 48, 30, 274, DateTimeKind.Local).AddTicks(8128), null },
                    { 26, new DateTime(2022, 10, 6, 16, 21, 21, 734, DateTimeKind.Local).AddTicks(9151), new DateTime(2023, 2, 13, 22, 8, 46, 266, DateTimeKind.Local).AddTicks(8039), null },
                    { 27, new DateTime(2022, 12, 11, 6, 13, 11, 940, DateTimeKind.Local).AddTicks(5867), new DateTime(2022, 8, 7, 7, 4, 52, 786, DateTimeKind.Local).AddTicks(505), null },
                    { 28, new DateTime(2022, 11, 23, 12, 52, 32, 392, DateTimeKind.Local).AddTicks(2494), new DateTime(2023, 2, 19, 2, 4, 31, 842, DateTimeKind.Local).AddTicks(4700), null },
                    { 29, new DateTime(2022, 5, 5, 1, 45, 32, 131, DateTimeKind.Local).AddTicks(901), new DateTime(2023, 3, 16, 17, 22, 56, 292, DateTimeKind.Local).AddTicks(9535), null },
                    { 30, new DateTime(2022, 4, 26, 9, 5, 56, 175, DateTimeKind.Local).AddTicks(1850), new DateTime(2022, 10, 20, 14, 59, 45, 492, DateTimeKind.Local).AddTicks(7962), null },
                    { 31, new DateTime(2022, 8, 26, 12, 41, 53, 397, DateTimeKind.Local).AddTicks(6560), new DateTime(2023, 3, 30, 15, 52, 29, 463, DateTimeKind.Local).AddTicks(6948), null },
                    { 32, new DateTime(2023, 3, 3, 15, 49, 29, 23, DateTimeKind.Local).AddTicks(6763), new DateTime(2023, 1, 28, 8, 42, 29, 739, DateTimeKind.Local).AddTicks(8932), null },
                    { 33, new DateTime(2023, 3, 16, 7, 37, 36, 625, DateTimeKind.Local).AddTicks(4622), new DateTime(2022, 12, 23, 22, 3, 38, 316, DateTimeKind.Local).AddTicks(5265), null },
                    { 34, new DateTime(2022, 9, 28, 11, 25, 31, 416, DateTimeKind.Local).AddTicks(8369), new DateTime(2022, 12, 25, 21, 25, 35, 875, DateTimeKind.Local).AddTicks(7179), null },
                    { 35, new DateTime(2022, 4, 17, 12, 48, 12, 995, DateTimeKind.Local).AddTicks(3597), new DateTime(2022, 6, 1, 2, 7, 57, 921, DateTimeKind.Local).AddTicks(4705), null },
                    { 36, new DateTime(2022, 6, 30, 4, 6, 18, 922, DateTimeKind.Local).AddTicks(4673), new DateTime(2023, 1, 26, 9, 9, 1, 232, DateTimeKind.Local).AddTicks(3313), null },
                    { 37, new DateTime(2023, 3, 10, 21, 59, 2, 269, DateTimeKind.Local).AddTicks(5860), new DateTime(2023, 2, 10, 10, 20, 52, 752, DateTimeKind.Local).AddTicks(2998), null },
                    { 38, new DateTime(2022, 11, 11, 4, 32, 19, 423, DateTimeKind.Local).AddTicks(6414), new DateTime(2022, 5, 2, 19, 55, 33, 777, DateTimeKind.Local).AddTicks(8427), null },
                    { 39, new DateTime(2022, 11, 20, 22, 19, 15, 295, DateTimeKind.Local).AddTicks(3966), new DateTime(2022, 7, 8, 3, 32, 2, 88, DateTimeKind.Local).AddTicks(815), null },
                    { 40, new DateTime(2022, 5, 5, 21, 1, 40, 23, DateTimeKind.Local).AddTicks(2409), new DateTime(2023, 3, 3, 0, 51, 35, 403, DateTimeKind.Local).AddTicks(9830), null },
                    { 41, new DateTime(2022, 10, 19, 3, 39, 37, 507, DateTimeKind.Local).AddTicks(6207), new DateTime(2022, 12, 20, 15, 10, 0, 852, DateTimeKind.Local).AddTicks(5012), null },
                    { 42, new DateTime(2023, 3, 24, 20, 59, 38, 626, DateTimeKind.Local).AddTicks(3553), new DateTime(2022, 10, 27, 9, 7, 15, 522, DateTimeKind.Local).AddTicks(2682), null },
                    { 43, new DateTime(2022, 12, 6, 6, 49, 45, 206, DateTimeKind.Local).AddTicks(5242), new DateTime(2022, 11, 26, 13, 18, 14, 275, DateTimeKind.Local).AddTicks(4387), null },
                    { 44, new DateTime(2022, 12, 2, 15, 50, 54, 777, DateTimeKind.Local).AddTicks(8788), new DateTime(2023, 4, 13, 23, 44, 44, 224, DateTimeKind.Local).AddTicks(4138), null },
                    { 45, new DateTime(2022, 9, 3, 0, 31, 14, 180, DateTimeKind.Local).AddTicks(3550), new DateTime(2022, 6, 15, 9, 44, 53, 953, DateTimeKind.Local).AddTicks(3131), null },
                    { 46, new DateTime(2022, 6, 8, 3, 41, 50, 831, DateTimeKind.Local).AddTicks(6254), new DateTime(2022, 7, 8, 8, 40, 55, 940, DateTimeKind.Local).AddTicks(924), null },
                    { 47, new DateTime(2023, 3, 15, 8, 1, 49, 346, DateTimeKind.Local).AddTicks(1010), new DateTime(2023, 4, 7, 3, 34, 23, 467, DateTimeKind.Local).AddTicks(845), null },
                    { 48, new DateTime(2022, 5, 28, 6, 41, 52, 985, DateTimeKind.Local).AddTicks(1510), new DateTime(2023, 1, 24, 6, 50, 6, 717, DateTimeKind.Local).AddTicks(541), null },
                    { 49, new DateTime(2022, 6, 2, 3, 10, 39, 657, DateTimeKind.Local).AddTicks(5882), new DateTime(2022, 10, 24, 21, 52, 31, 399, DateTimeKind.Local).AddTicks(8198), null },
                    { 50, new DateTime(2022, 12, 28, 2, 16, 47, 838, DateTimeKind.Local).AddTicks(5450), new DateTime(2023, 3, 3, 1, 49, 57, 314, DateTimeKind.Local).AddTicks(3894), null },
                    { 51, new DateTime(2023, 3, 1, 12, 40, 50, 159, DateTimeKind.Local).AddTicks(4734), new DateTime(2022, 12, 2, 9, 22, 6, 36, DateTimeKind.Local).AddTicks(9797), null },
                    { 52, new DateTime(2022, 10, 25, 9, 28, 21, 387, DateTimeKind.Local).AddTicks(4339), new DateTime(2022, 12, 3, 4, 32, 29, 167, DateTimeKind.Local).AddTicks(1590), null },
                    { 53, new DateTime(2022, 9, 25, 8, 1, 56, 539, DateTimeKind.Local).AddTicks(2730), new DateTime(2022, 12, 26, 1, 32, 5, 689, DateTimeKind.Local).AddTicks(5111), null },
                    { 54, new DateTime(2023, 3, 22, 18, 29, 29, 184, DateTimeKind.Local).AddTicks(1462), new DateTime(2023, 2, 14, 14, 12, 4, 375, DateTimeKind.Local).AddTicks(2151), null },
                    { 55, new DateTime(2023, 1, 10, 20, 52, 18, 549, DateTimeKind.Local).AddTicks(3381), new DateTime(2022, 11, 7, 11, 16, 43, 801, DateTimeKind.Local).AddTicks(3358), null },
                    { 56, new DateTime(2022, 7, 15, 22, 5, 1, 734, DateTimeKind.Local).AddTicks(31), new DateTime(2023, 2, 11, 16, 33, 15, 229, DateTimeKind.Local).AddTicks(9383), null },
                    { 57, new DateTime(2023, 2, 25, 14, 41, 1, 456, DateTimeKind.Local).AddTicks(6431), new DateTime(2022, 6, 10, 2, 34, 5, 958, DateTimeKind.Local).AddTicks(1324), null },
                    { 58, new DateTime(2022, 4, 18, 5, 39, 53, 172, DateTimeKind.Local).AddTicks(1069), new DateTime(2022, 12, 21, 15, 51, 37, 732, DateTimeKind.Local).AddTicks(794), null },
                    { 59, new DateTime(2022, 4, 22, 13, 12, 36, 24, DateTimeKind.Local).AddTicks(2648), new DateTime(2022, 8, 22, 1, 1, 58, 688, DateTimeKind.Local).AddTicks(3333), null },
                    { 60, new DateTime(2022, 6, 8, 20, 12, 29, 720, DateTimeKind.Local).AddTicks(2949), new DateTime(2022, 8, 4, 12, 39, 7, 536, DateTimeKind.Local).AddTicks(9495), null },
                    { 61, new DateTime(2022, 5, 8, 0, 32, 28, 725, DateTimeKind.Local).AddTicks(5745), new DateTime(2022, 10, 1, 6, 0, 32, 379, DateTimeKind.Local).AddTicks(3499), null },
                    { 62, new DateTime(2022, 8, 8, 15, 14, 6, 882, DateTimeKind.Local).AddTicks(2906), new DateTime(2023, 2, 16, 21, 23, 4, 228, DateTimeKind.Local).AddTicks(9743), null },
                    { 63, new DateTime(2023, 4, 9, 16, 45, 52, 276, DateTimeKind.Local).AddTicks(7737), new DateTime(2023, 4, 8, 13, 45, 8, 169, DateTimeKind.Local).AddTicks(3035), null },
                    { 64, new DateTime(2023, 2, 27, 19, 26, 57, 73, DateTimeKind.Local).AddTicks(1598), new DateTime(2023, 3, 20, 12, 44, 23, 989, DateTimeKind.Local).AddTicks(4311), null },
                    { 65, new DateTime(2022, 12, 30, 21, 58, 44, 954, DateTimeKind.Local).AddTicks(792), new DateTime(2023, 2, 1, 16, 1, 57, 893, DateTimeKind.Local).AddTicks(5179), null },
                    { 66, new DateTime(2023, 3, 17, 11, 4, 39, 307, DateTimeKind.Local).AddTicks(1856), new DateTime(2022, 5, 13, 18, 46, 29, 82, DateTimeKind.Local).AddTicks(5082), null },
                    { 67, new DateTime(2022, 10, 25, 19, 34, 59, 436, DateTimeKind.Local).AddTicks(4688), new DateTime(2022, 6, 19, 13, 31, 27, 895, DateTimeKind.Local).AddTicks(7838), null },
                    { 68, new DateTime(2022, 4, 18, 6, 30, 30, 431, DateTimeKind.Local).AddTicks(4427), new DateTime(2023, 3, 3, 12, 37, 16, 657, DateTimeKind.Local).AddTicks(5742), null },
                    { 69, new DateTime(2022, 6, 12, 0, 1, 24, 652, DateTimeKind.Local).AddTicks(64), new DateTime(2022, 8, 6, 10, 46, 54, 646, DateTimeKind.Local).AddTicks(1355), null },
                    { 70, new DateTime(2022, 5, 18, 19, 25, 4, 169, DateTimeKind.Local).AddTicks(9353), new DateTime(2023, 3, 27, 23, 37, 24, 703, DateTimeKind.Local).AddTicks(9533), null },
                    { 71, new DateTime(2022, 12, 21, 13, 8, 30, 278, DateTimeKind.Local).AddTicks(2335), new DateTime(2023, 2, 1, 19, 58, 35, 589, DateTimeKind.Local).AddTicks(6047), null },
                    { 72, new DateTime(2022, 7, 18, 21, 12, 10, 862, DateTimeKind.Local).AddTicks(176), new DateTime(2023, 2, 10, 7, 34, 15, 565, DateTimeKind.Local).AddTicks(9611), null },
                    { 73, new DateTime(2023, 3, 17, 5, 59, 37, 406, DateTimeKind.Local).AddTicks(2528), new DateTime(2022, 8, 11, 5, 28, 20, 788, DateTimeKind.Local).AddTicks(6298), null },
                    { 74, new DateTime(2022, 8, 27, 12, 19, 39, 670, DateTimeKind.Local).AddTicks(3929), new DateTime(2023, 1, 19, 23, 47, 28, 574, DateTimeKind.Local).AddTicks(9122), null },
                    { 75, new DateTime(2023, 4, 5, 16, 14, 15, 481, DateTimeKind.Local).AddTicks(9221), new DateTime(2022, 9, 21, 9, 10, 0, 440, DateTimeKind.Local).AddTicks(162), null },
                    { 76, new DateTime(2023, 1, 18, 11, 57, 15, 879, DateTimeKind.Local).AddTicks(7347), new DateTime(2023, 1, 25, 20, 28, 26, 156, DateTimeKind.Local).AddTicks(2005), null },
                    { 77, new DateTime(2022, 9, 1, 19, 59, 46, 866, DateTimeKind.Local).AddTicks(4712), new DateTime(2022, 9, 9, 7, 57, 25, 488, DateTimeKind.Local).AddTicks(5419), null },
                    { 78, new DateTime(2023, 2, 9, 19, 37, 13, 775, DateTimeKind.Local).AddTicks(7620), new DateTime(2022, 9, 15, 1, 0, 2, 967, DateTimeKind.Local).AddTicks(708), null },
                    { 79, new DateTime(2022, 8, 10, 12, 27, 44, 341, DateTimeKind.Local).AddTicks(6371), new DateTime(2022, 12, 23, 6, 25, 2, 345, DateTimeKind.Local).AddTicks(4028), null },
                    { 80, new DateTime(2022, 12, 10, 6, 6, 22, 77, DateTimeKind.Local).AddTicks(3292), new DateTime(2022, 10, 3, 12, 36, 33, 556, DateTimeKind.Local).AddTicks(9133), null },
                    { 81, new DateTime(2023, 2, 12, 0, 24, 53, 803, DateTimeKind.Local).AddTicks(2960), new DateTime(2022, 4, 19, 0, 4, 50, 381, DateTimeKind.Local).AddTicks(6599), null },
                    { 82, new DateTime(2022, 6, 1, 10, 33, 4, 608, DateTimeKind.Local).AddTicks(815), new DateTime(2023, 3, 25, 23, 10, 5, 842, DateTimeKind.Local).AddTicks(7659), null },
                    { 83, new DateTime(2022, 12, 7, 18, 31, 49, 681, DateTimeKind.Local).AddTicks(966), new DateTime(2022, 6, 18, 21, 38, 17, 838, DateTimeKind.Local).AddTicks(4415), null },
                    { 84, new DateTime(2022, 8, 3, 15, 18, 0, 980, DateTimeKind.Local).AddTicks(4170), new DateTime(2022, 12, 23, 19, 29, 18, 747, DateTimeKind.Local).AddTicks(8127), null },
                    { 85, new DateTime(2022, 6, 8, 14, 23, 20, 713, DateTimeKind.Local).AddTicks(6529), new DateTime(2022, 6, 1, 11, 22, 21, 701, DateTimeKind.Local).AddTicks(4964), null },
                    { 86, new DateTime(2022, 10, 26, 10, 9, 58, 267, DateTimeKind.Local).AddTicks(377), new DateTime(2022, 12, 31, 20, 45, 26, 565, DateTimeKind.Local).AddTicks(941), null },
                    { 87, new DateTime(2022, 7, 20, 23, 56, 39, 705, DateTimeKind.Local).AddTicks(3638), new DateTime(2022, 6, 28, 14, 54, 50, 203, DateTimeKind.Local).AddTicks(3077), null },
                    { 88, new DateTime(2022, 11, 28, 17, 50, 22, 445, DateTimeKind.Local).AddTicks(6829), new DateTime(2022, 7, 20, 22, 53, 38, 322, DateTimeKind.Local).AddTicks(9368), null },
                    { 89, new DateTime(2022, 6, 30, 3, 8, 6, 704, DateTimeKind.Local).AddTicks(3439), new DateTime(2022, 10, 13, 1, 59, 36, 503, DateTimeKind.Local).AddTicks(3435), null },
                    { 90, new DateTime(2023, 3, 19, 9, 43, 12, 9, DateTimeKind.Local).AddTicks(7368), new DateTime(2022, 12, 14, 5, 37, 16, 675, DateTimeKind.Local).AddTicks(1593), null },
                    { 91, new DateTime(2022, 11, 26, 19, 45, 13, 685, DateTimeKind.Local).AddTicks(9373), new DateTime(2022, 5, 25, 13, 59, 13, 685, DateTimeKind.Local).AddTicks(2746), null },
                    { 92, new DateTime(2023, 3, 31, 14, 49, 53, 694, DateTimeKind.Local).AddTicks(5370), new DateTime(2022, 7, 26, 7, 8, 29, 701, DateTimeKind.Local).AddTicks(911), null },
                    { 93, new DateTime(2022, 4, 30, 22, 24, 27, 200, DateTimeKind.Local).AddTicks(8122), new DateTime(2022, 6, 6, 8, 55, 58, 338, DateTimeKind.Local).AddTicks(143), null },
                    { 94, new DateTime(2022, 12, 26, 17, 6, 27, 403, DateTimeKind.Local).AddTicks(668), new DateTime(2022, 6, 2, 5, 57, 19, 134, DateTimeKind.Local).AddTicks(9568), null },
                    { 95, new DateTime(2022, 8, 24, 12, 13, 59, 307, DateTimeKind.Local).AddTicks(524), new DateTime(2022, 11, 17, 23, 50, 12, 651, DateTimeKind.Local).AddTicks(4028), null },
                    { 96, new DateTime(2022, 11, 7, 18, 29, 17, 502, DateTimeKind.Local).AddTicks(9686), new DateTime(2022, 10, 4, 11, 56, 7, 493, DateTimeKind.Local).AddTicks(6352), null },
                    { 97, new DateTime(2022, 12, 11, 23, 0, 17, 755, DateTimeKind.Local).AddTicks(8387), new DateTime(2022, 11, 30, 1, 8, 15, 800, DateTimeKind.Local).AddTicks(546), null },
                    { 98, new DateTime(2022, 5, 30, 17, 32, 16, 87, DateTimeKind.Local).AddTicks(6905), new DateTime(2022, 12, 19, 7, 23, 25, 83, DateTimeKind.Local).AddTicks(6070), null },
                    { 99, new DateTime(2022, 12, 18, 3, 45, 16, 168, DateTimeKind.Local).AddTicks(5574), new DateTime(2022, 8, 9, 16, 21, 50, 206, DateTimeKind.Local).AddTicks(2860), null },
                    { 100, new DateTime(2022, 6, 20, 7, 22, 11, 71, DateTimeKind.Local).AddTicks(8996), new DateTime(2023, 1, 13, 2, 41, 4, 754, DateTimeKind.Local).AddTicks(8464), null },
                    { 101, new DateTime(2022, 4, 24, 8, 30, 4, 995, DateTimeKind.Local).AddTicks(2488), new DateTime(2022, 12, 19, 11, 10, 6, 109, DateTimeKind.Local).AddTicks(6221), null },
                    { 102, new DateTime(2022, 11, 28, 3, 43, 53, 48, DateTimeKind.Local).AddTicks(3108), new DateTime(2023, 2, 18, 23, 11, 38, 967, DateTimeKind.Local).AddTicks(4777), null },
                    { 103, new DateTime(2023, 3, 12, 17, 19, 47, 360, DateTimeKind.Local).AddTicks(436), new DateTime(2022, 5, 4, 9, 31, 34, 501, DateTimeKind.Local).AddTicks(7085), null },
                    { 104, new DateTime(2022, 10, 22, 14, 51, 31, 637, DateTimeKind.Local).AddTicks(9060), new DateTime(2022, 6, 20, 23, 24, 41, 850, DateTimeKind.Local).AddTicks(2331), null },
                    { 105, new DateTime(2023, 1, 26, 8, 26, 48, 229, DateTimeKind.Local).AddTicks(9436), new DateTime(2022, 11, 6, 15, 3, 20, 639, DateTimeKind.Local).AddTicks(9111), null },
                    { 106, new DateTime(2022, 7, 2, 16, 11, 41, 449, DateTimeKind.Local).AddTicks(8575), new DateTime(2023, 2, 12, 4, 47, 53, 25, DateTimeKind.Local).AddTicks(4268), null },
                    { 107, new DateTime(2023, 1, 20, 15, 1, 35, 522, DateTimeKind.Local).AddTicks(8006), new DateTime(2023, 4, 12, 18, 48, 50, 589, DateTimeKind.Local).AddTicks(3046), null },
                    { 108, new DateTime(2023, 2, 21, 11, 11, 5, 58, DateTimeKind.Local).AddTicks(1221), new DateTime(2023, 1, 4, 4, 45, 25, 305, DateTimeKind.Local).AddTicks(1744), null },
                    { 109, new DateTime(2022, 5, 5, 3, 34, 41, 874, DateTimeKind.Local).AddTicks(2914), new DateTime(2023, 2, 20, 21, 44, 20, 94, DateTimeKind.Local).AddTicks(1613), null },
                    { 110, new DateTime(2023, 3, 11, 19, 5, 23, 829, DateTimeKind.Local).AddTicks(1275), new DateTime(2022, 10, 18, 3, 55, 36, 530, DateTimeKind.Local).AddTicks(2563), null },
                    { 111, new DateTime(2022, 10, 7, 22, 51, 35, 622, DateTimeKind.Local).AddTicks(5497), new DateTime(2022, 6, 18, 3, 40, 27, 32, DateTimeKind.Local).AddTicks(6353), null },
                    { 112, new DateTime(2022, 8, 16, 1, 35, 4, 627, DateTimeKind.Local).AddTicks(9304), new DateTime(2022, 11, 5, 8, 52, 53, 249, DateTimeKind.Local).AddTicks(4116), null },
                    { 113, new DateTime(2022, 11, 8, 11, 12, 49, 385, DateTimeKind.Local).AddTicks(6897), new DateTime(2022, 5, 8, 16, 33, 35, 960, DateTimeKind.Local).AddTicks(5642), null },
                    { 114, new DateTime(2022, 5, 6, 16, 4, 53, 996, DateTimeKind.Local).AddTicks(4179), new DateTime(2022, 12, 5, 17, 8, 9, 92, DateTimeKind.Local).AddTicks(4717), null },
                    { 115, new DateTime(2022, 5, 15, 15, 42, 19, 302, DateTimeKind.Local).AddTicks(7805), new DateTime(2023, 3, 27, 4, 46, 42, 549, DateTimeKind.Local).AddTicks(2392), null },
                    { 116, new DateTime(2022, 11, 17, 13, 28, 7, 341, DateTimeKind.Local).AddTicks(5562), new DateTime(2023, 3, 7, 5, 6, 1, 685, DateTimeKind.Local).AddTicks(2065), null },
                    { 117, new DateTime(2022, 8, 9, 12, 57, 10, 618, DateTimeKind.Local).AddTicks(5917), new DateTime(2022, 6, 21, 1, 21, 52, 442, DateTimeKind.Local).AddTicks(379), null },
                    { 118, new DateTime(2022, 12, 6, 15, 26, 56, 867, DateTimeKind.Local).AddTicks(589), new DateTime(2023, 3, 25, 2, 54, 52, 763, DateTimeKind.Local).AddTicks(4534), null },
                    { 119, new DateTime(2022, 10, 12, 4, 35, 5, 824, DateTimeKind.Local).AddTicks(1026), new DateTime(2022, 5, 27, 9, 57, 59, 914, DateTimeKind.Local).AddTicks(2121), null },
                    { 120, new DateTime(2022, 8, 30, 8, 8, 27, 528, DateTimeKind.Local).AddTicks(2142), new DateTime(2023, 4, 13, 7, 12, 37, 886, DateTimeKind.Local).AddTicks(2729), null },
                    { 121, new DateTime(2022, 11, 29, 12, 24, 11, 887, DateTimeKind.Local).AddTicks(2899), new DateTime(2022, 10, 22, 12, 1, 30, 740, DateTimeKind.Local).AddTicks(160), null },
                    { 122, new DateTime(2022, 8, 21, 15, 50, 16, 92, DateTimeKind.Local).AddTicks(2110), new DateTime(2023, 2, 1, 15, 30, 23, 854, DateTimeKind.Local).AddTicks(3405), null },
                    { 123, new DateTime(2022, 9, 2, 1, 58, 16, 388, DateTimeKind.Local).AddTicks(7454), new DateTime(2023, 1, 10, 8, 1, 9, 664, DateTimeKind.Local).AddTicks(7422), null },
                    { 124, new DateTime(2022, 12, 29, 15, 14, 17, 158, DateTimeKind.Local).AddTicks(360), new DateTime(2022, 12, 15, 22, 31, 12, 353, DateTimeKind.Local).AddTicks(7357), null },
                    { 125, new DateTime(2023, 1, 23, 8, 16, 55, 929, DateTimeKind.Local).AddTicks(1349), new DateTime(2022, 9, 10, 7, 6, 35, 969, DateTimeKind.Local).AddTicks(7253), null },
                    { 126, new DateTime(2022, 11, 30, 22, 8, 28, 396, DateTimeKind.Local).AddTicks(5537), new DateTime(2023, 2, 11, 0, 20, 41, 261, DateTimeKind.Local).AddTicks(6375), null },
                    { 127, new DateTime(2022, 9, 14, 15, 36, 11, 564, DateTimeKind.Local).AddTicks(4029), new DateTime(2022, 12, 17, 21, 46, 19, 728, DateTimeKind.Local).AddTicks(8880), null },
                    { 128, new DateTime(2022, 7, 22, 22, 9, 14, 319, DateTimeKind.Local).AddTicks(5426), new DateTime(2023, 2, 20, 23, 9, 23, 149, DateTimeKind.Local).AddTicks(8594), null },
                    { 129, new DateTime(2022, 8, 20, 3, 54, 46, 668, DateTimeKind.Local).AddTicks(9385), new DateTime(2022, 5, 9, 13, 10, 44, 986, DateTimeKind.Local).AddTicks(1464), null },
                    { 130, new DateTime(2022, 7, 28, 6, 18, 34, 769, DateTimeKind.Local).AddTicks(363), new DateTime(2023, 2, 18, 19, 5, 56, 586, DateTimeKind.Local).AddTicks(7157), null },
                    { 131, new DateTime(2023, 4, 14, 11, 46, 25, 692, DateTimeKind.Local).AddTicks(5254), new DateTime(2023, 3, 3, 16, 3, 7, 732, DateTimeKind.Local).AddTicks(6688), null },
                    { 132, new DateTime(2022, 5, 23, 2, 2, 7, 734, DateTimeKind.Local).AddTicks(6880), new DateTime(2023, 2, 15, 21, 59, 50, 867, DateTimeKind.Local).AddTicks(9259), null },
                    { 133, new DateTime(2023, 4, 5, 19, 54, 58, 485, DateTimeKind.Local).AddTicks(5991), new DateTime(2022, 8, 12, 5, 25, 24, 951, DateTimeKind.Local).AddTicks(9127), null },
                    { 134, new DateTime(2022, 10, 20, 10, 10, 27, 594, DateTimeKind.Local).AddTicks(997), new DateTime(2022, 11, 16, 7, 59, 28, 268, DateTimeKind.Local).AddTicks(275), null },
                    { 135, new DateTime(2022, 8, 21, 21, 41, 38, 909, DateTimeKind.Local).AddTicks(5114), new DateTime(2023, 3, 16, 2, 35, 57, 481, DateTimeKind.Local).AddTicks(9345), null },
                    { 136, new DateTime(2022, 7, 9, 18, 30, 4, 668, DateTimeKind.Local).AddTicks(3319), new DateTime(2023, 3, 25, 11, 56, 27, 147, DateTimeKind.Local).AddTicks(3392), null },
                    { 137, new DateTime(2022, 10, 8, 7, 55, 37, 753, DateTimeKind.Local).AddTicks(2068), new DateTime(2023, 3, 15, 6, 12, 31, 130, DateTimeKind.Local).AddTicks(1124), null },
                    { 138, new DateTime(2023, 3, 5, 9, 51, 9, 830, DateTimeKind.Local).AddTicks(2359), new DateTime(2023, 4, 2, 5, 9, 50, 69, DateTimeKind.Local).AddTicks(8036), null },
                    { 139, new DateTime(2023, 2, 11, 6, 9, 56, 127, DateTimeKind.Local).AddTicks(6956), new DateTime(2022, 10, 29, 4, 24, 25, 960, DateTimeKind.Local).AddTicks(8615), null },
                    { 140, new DateTime(2022, 6, 20, 1, 14, 22, 47, DateTimeKind.Local).AddTicks(9385), new DateTime(2023, 2, 12, 21, 31, 24, 908, DateTimeKind.Local).AddTicks(2197), null },
                    { 141, new DateTime(2022, 8, 24, 19, 39, 3, 989, DateTimeKind.Local).AddTicks(8014), new DateTime(2022, 9, 5, 11, 53, 26, 829, DateTimeKind.Local).AddTicks(9553), null },
                    { 142, new DateTime(2023, 2, 27, 3, 10, 58, 350, DateTimeKind.Local).AddTicks(6108), new DateTime(2022, 12, 20, 2, 55, 28, 520, DateTimeKind.Local).AddTicks(3292), null },
                    { 143, new DateTime(2022, 8, 11, 0, 57, 59, 339, DateTimeKind.Local).AddTicks(9739), new DateTime(2023, 1, 21, 7, 27, 11, 267, DateTimeKind.Local).AddTicks(1955), null },
                    { 144, new DateTime(2022, 10, 7, 7, 49, 35, 308, DateTimeKind.Local).AddTicks(658), new DateTime(2022, 12, 7, 9, 30, 36, 76, DateTimeKind.Local).AddTicks(9654), null },
                    { 145, new DateTime(2023, 3, 15, 21, 32, 23, 309, DateTimeKind.Local).AddTicks(7735), new DateTime(2023, 1, 30, 10, 37, 18, 904, DateTimeKind.Local).AddTicks(4800), null },
                    { 146, new DateTime(2022, 11, 19, 17, 19, 51, 281, DateTimeKind.Local).AddTicks(7972), new DateTime(2022, 9, 19, 9, 44, 6, 25, DateTimeKind.Local).AddTicks(2387), null },
                    { 147, new DateTime(2023, 2, 13, 21, 59, 10, 332, DateTimeKind.Local).AddTicks(4450), new DateTime(2022, 10, 26, 7, 22, 16, 128, DateTimeKind.Local).AddTicks(7665), null },
                    { 148, new DateTime(2023, 4, 15, 13, 45, 57, 381, DateTimeKind.Local).AddTicks(166), new DateTime(2023, 1, 12, 14, 40, 49, 341, DateTimeKind.Local).AddTicks(8793), null },
                    { 149, new DateTime(2022, 9, 16, 4, 19, 8, 192, DateTimeKind.Local).AddTicks(5867), new DateTime(2022, 10, 20, 12, 10, 10, 411, DateTimeKind.Local).AddTicks(5434), null },
                    { 150, new DateTime(2023, 2, 12, 13, 55, 10, 556, DateTimeKind.Local).AddTicks(107), new DateTime(2022, 5, 7, 14, 52, 36, 624, DateTimeKind.Local).AddTicks(1043), null }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 7, 8, 12, 43, 110, DateTimeKind.Local).AddTicks(3672), new DateTime(2022, 10, 28, 7, 18, 56, 374, DateTimeKind.Local).AddTicks(3144), "Chrysler" },
                    { 2, new DateTime(2022, 8, 19, 18, 27, 49, 340, DateTimeKind.Local).AddTicks(3259), new DateTime(2022, 11, 9, 19, 9, 13, 60, DateTimeKind.Local).AddTicks(1489), "Polestar" },
                    { 3, new DateTime(2022, 5, 7, 6, 5, 44, 434, DateTimeKind.Local).AddTicks(8805), new DateTime(2023, 3, 10, 19, 14, 6, 295, DateTimeKind.Local).AddTicks(4544), "Ford" },
                    { 4, new DateTime(2023, 4, 6, 7, 28, 14, 649, DateTimeKind.Local).AddTicks(1124), new DateTime(2023, 1, 16, 5, 35, 38, 41, DateTimeKind.Local).AddTicks(4206), "Mazda" },
                    { 5, new DateTime(2022, 4, 20, 11, 58, 8, 405, DateTimeKind.Local).AddTicks(2606), new DateTime(2022, 8, 10, 18, 55, 50, 498, DateTimeKind.Local).AddTicks(3026), "Fiat" },
                    { 6, new DateTime(2023, 1, 3, 13, 37, 16, 367, DateTimeKind.Local).AddTicks(7322), new DateTime(2022, 9, 4, 3, 53, 40, 843, DateTimeKind.Local).AddTicks(5807), "Mazda" },
                    { 7, new DateTime(2022, 8, 3, 14, 35, 25, 218, DateTimeKind.Local).AddTicks(4957), new DateTime(2022, 5, 5, 2, 16, 12, 73, DateTimeKind.Local).AddTicks(2112), "Mini" },
                    { 8, new DateTime(2023, 2, 17, 0, 46, 56, 166, DateTimeKind.Local).AddTicks(1912), new DateTime(2022, 11, 28, 8, 15, 45, 268, DateTimeKind.Local).AddTicks(2584), "Bentley" },
                    { 9, new DateTime(2023, 2, 13, 21, 47, 49, 34, DateTimeKind.Local).AddTicks(4183), new DateTime(2022, 7, 1, 0, 47, 4, 849, DateTimeKind.Local).AddTicks(3888), "Porsche" },
                    { 10, new DateTime(2022, 6, 20, 8, 36, 0, 598, DateTimeKind.Local).AddTicks(1007), new DateTime(2022, 5, 28, 4, 51, 21, 742, DateTimeKind.Local).AddTicks(4581), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 7, 8, 12, 43, 113, DateTimeKind.Local).AddTicks(8945), null, new DateTime(2022, 10, 28, 7, 18, 56, 377, DateTimeKind.Local).AddTicks(8416), "Computers" },
                    { 2, new DateTime(2022, 8, 19, 18, 27, 49, 343, DateTimeKind.Local).AddTicks(8545), null, new DateTime(2022, 11, 9, 19, 9, 13, 63, DateTimeKind.Local).AddTicks(6775), "Shoes" },
                    { 3, new DateTime(2022, 5, 7, 6, 5, 44, 438, DateTimeKind.Local).AddTicks(4093), null, new DateTime(2023, 3, 10, 19, 14, 6, 298, DateTimeKind.Local).AddTicks(9832), "Garden" },
                    { 4, new DateTime(2023, 4, 6, 7, 28, 14, 652, DateTimeKind.Local).AddTicks(6412), null, new DateTime(2023, 1, 16, 5, 35, 38, 44, DateTimeKind.Local).AddTicks(9495), "Baby" },
                    { 5, new DateTime(2022, 4, 20, 11, 58, 8, 408, DateTimeKind.Local).AddTicks(7894), null, new DateTime(2022, 8, 10, 18, 55, 50, 501, DateTimeKind.Local).AddTicks(8314), "Garden" },
                    { 6, new DateTime(2023, 1, 3, 13, 37, 16, 371, DateTimeKind.Local).AddTicks(2611), null, new DateTime(2022, 9, 4, 3, 53, 40, 847, DateTimeKind.Local).AddTicks(1096), "Baby" },
                    { 7, new DateTime(2022, 8, 3, 14, 35, 25, 222, DateTimeKind.Local).AddTicks(247), null, new DateTime(2022, 5, 5, 2, 16, 12, 76, DateTimeKind.Local).AddTicks(7402), "Clothing" },
                    { 8, new DateTime(2023, 2, 17, 0, 46, 56, 169, DateTimeKind.Local).AddTicks(7204), null, new DateTime(2022, 11, 28, 8, 15, 45, 271, DateTimeKind.Local).AddTicks(7875), "Music" },
                    { 9, new DateTime(2023, 2, 13, 21, 47, 49, 37, DateTimeKind.Local).AddTicks(9475), null, new DateTime(2022, 7, 1, 0, 47, 4, 852, DateTimeKind.Local).AddTicks(9180), "Jewelery" },
                    { 10, new DateTime(2022, 6, 20, 8, 36, 0, 601, DateTimeKind.Local).AddTicks(6300), null, new DateTime(2022, 5, 28, 4, 51, 21, 745, DateTimeKind.Local).AddTicks(9874), "Home" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 7, 8, 12, 43, 105, DateTimeKind.Local).AddTicks(9391), new DateTime(2022, 10, 28, 7, 18, 56, 369, DateTimeKind.Local).AddTicks(8864), "Ecuador" },
                    { 2, new DateTime(2022, 8, 19, 18, 27, 49, 335, DateTimeKind.Local).AddTicks(9005), new DateTime(2022, 11, 9, 19, 9, 13, 55, DateTimeKind.Local).AddTicks(7236), "Samoa" },
                    { 3, new DateTime(2022, 5, 7, 6, 5, 44, 430, DateTimeKind.Local).AddTicks(4553), new DateTime(2023, 3, 10, 19, 14, 6, 291, DateTimeKind.Local).AddTicks(292), "Guatemala" },
                    { 4, new DateTime(2023, 4, 6, 7, 28, 14, 644, DateTimeKind.Local).AddTicks(6872), new DateTime(2023, 1, 16, 5, 35, 38, 36, DateTimeKind.Local).AddTicks(9954), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 20, 11, 58, 8, 400, DateTimeKind.Local).AddTicks(8354), new DateTime(2022, 8, 10, 18, 55, 50, 493, DateTimeKind.Local).AddTicks(9162), "Germany" },
                    { 6, new DateTime(2023, 1, 3, 13, 37, 16, 363, DateTimeKind.Local).AddTicks(3534), new DateTime(2022, 9, 4, 3, 53, 40, 839, DateTimeKind.Local).AddTicks(2019), "Niue" },
                    { 7, new DateTime(2022, 8, 3, 14, 35, 25, 214, DateTimeKind.Local).AddTicks(1175), new DateTime(2022, 5, 5, 2, 16, 12, 68, DateTimeKind.Local).AddTicks(8331), "Philippines" },
                    { 8, new DateTime(2023, 2, 17, 0, 46, 56, 161, DateTimeKind.Local).AddTicks(8278), new DateTime(2022, 11, 28, 8, 15, 45, 263, DateTimeKind.Local).AddTicks(8952), "Benin" },
                    { 9, new DateTime(2023, 2, 13, 21, 47, 49, 30, DateTimeKind.Local).AddTicks(557), new DateTime(2022, 7, 1, 0, 47, 4, 845, DateTimeKind.Local).AddTicks(262), "Seychelles" },
                    { 10, new DateTime(2022, 6, 20, 8, 36, 0, 593, DateTimeKind.Local).AddTicks(7382), new DateTime(2022, 5, 28, 4, 51, 21, 738, DateTimeKind.Local).AddTicks(955), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 20, 22, 9, 52, 70, DateTimeKind.Local).AddTicks(4019), null, new DateTime(2022, 4, 20, 11, 58, 8, 413, DateTimeKind.Local).AddTicks(2365), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 7, 1, 0, 47, 4, 857, DateTimeKind.Local).AddTicks(3787), null, new DateTime(2022, 12, 25, 15, 0, 35, 337, DateTimeKind.Local).AddTicks(681), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 7, 4, 22, 50, 989, DateTimeKind.Local).AddTicks(7520), null, new DateTime(2022, 4, 19, 0, 40, 23, 490, DateTimeKind.Local).AddTicks(2670), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 23, 12, 52, 32, 388, DateTimeKind.Local).AddTicks(1695), null, new DateTime(2023, 2, 19, 2, 4, 31, 838, DateTimeKind.Local).AddTicks(3902), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 17, 12, 48, 12, 991, DateTimeKind.Local).AddTicks(2712), null, new DateTime(2022, 6, 1, 2, 7, 57, 917, DateTimeKind.Local).AddTicks(3822), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 24, 20, 59, 38, 622, DateTimeKind.Local).AddTicks(2653), null, new DateTime(2022, 10, 27, 9, 7, 15, 518, DateTimeKind.Local).AddTicks(1783), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 2, 3, 10, 39, 653, DateTimeKind.Local).AddTicks(4967), null, new DateTime(2022, 10, 24, 21, 52, 31, 395, DateTimeKind.Local).AddTicks(7284), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 15, 22, 5, 1, 729, DateTimeKind.Local).AddTicks(9051), null, new DateTime(2023, 2, 11, 16, 33, 15, 225, DateTimeKind.Local).AddTicks(8404), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 9, 16, 45, 52, 272, DateTimeKind.Local).AddTicks(6739), null, new DateTime(2023, 4, 8, 13, 45, 8, 165, DateTimeKind.Local).AddTicks(2038), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 18, 19, 25, 4, 165, DateTimeKind.Local).AddTicks(8384), null, new DateTime(2023, 3, 27, 23, 37, 24, 699, DateTimeKind.Local).AddTicks(8564), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 1, 19, 59, 46, 862, DateTimeKind.Local).AddTicks(3729), null, new DateTime(2022, 9, 9, 7, 57, 25, 484, DateTimeKind.Local).AddTicks(4436), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 3, 15, 18, 0, 976, DateTimeKind.Local).AddTicks(3172), null, new DateTime(2022, 12, 23, 19, 29, 18, 743, DateTimeKind.Local).AddTicks(7072), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 26, 19, 45, 13, 681, DateTimeKind.Local).AddTicks(7627), null, new DateTime(2022, 5, 25, 13, 59, 13, 681, DateTimeKind.Local).AddTicks(999), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 5, 30, 17, 32, 16, 83, DateTimeKind.Local).AddTicks(5135), null, new DateTime(2022, 12, 19, 7, 23, 25, 79, DateTimeKind.Local).AddTicks(4301), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 26, 8, 26, 48, 225, DateTimeKind.Local).AddTicks(7356), null, new DateTime(2022, 11, 6, 15, 3, 20, 635, DateTimeKind.Local).AddTicks(7021), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 16, 1, 35, 4, 623, DateTimeKind.Local).AddTicks(6933), null, new DateTime(2022, 11, 5, 8, 52, 53, 245, DateTimeKind.Local).AddTicks(1745), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 12, 4, 35, 5, 819, DateTimeKind.Local).AddTicks(8341), null, new DateTime(2022, 5, 27, 9, 57, 59, 909, DateTimeKind.Local).AddTicks(9294), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 11, 30, 22, 8, 28, 392, DateTimeKind.Local).AddTicks(2470), null, new DateTime(2023, 2, 11, 0, 20, 41, 257, DateTimeKind.Local).AddTicks(3299), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 5, 19, 54, 58, 481, DateTimeKind.Local).AddTicks(2785), null, new DateTime(2022, 8, 12, 5, 25, 24, 947, DateTimeKind.Local).AddTicks(5900), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 20, 1, 14, 22, 43, DateTimeKind.Local).AddTicks(6124), null, new DateTime(2023, 2, 12, 21, 31, 24, 903, DateTimeKind.Local).AddTicks(8937), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 13, 21, 59, 10, 328, DateTimeKind.Local).AddTicks(978), null, new DateTime(2022, 10, 26, 7, 22, 16, 124, DateTimeKind.Local).AddTicks(4194), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 20, 10, 44, 48, 691, DateTimeKind.Local).AddTicks(3433), null, new DateTime(2022, 10, 17, 3, 43, 25, 617, DateTimeKind.Local).AddTicks(2034), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 19, 15, 55, 34, 826, DateTimeKind.Local).AddTicks(7506), null, new DateTime(2023, 2, 27, 18, 59, 36, 700, DateTimeKind.Local).AddTicks(369), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 22, 23, 40, 42, 833, DateTimeKind.Local).AddTicks(2290), null, new DateTime(2022, 7, 12, 12, 24, 15, 95, DateTimeKind.Local).AddTicks(4446), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 5, 1, 7, 55, 23, 527, DateTimeKind.Local).AddTicks(5141), null, new DateTime(2022, 9, 6, 13, 52, 58, 514, DateTimeKind.Local).AddTicks(1087), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 17, 11, 16, 51, 868, DateTimeKind.Local).AddTicks(1125), null, new DateTime(2022, 12, 8, 11, 4, 34, 593, DateTimeKind.Local).AddTicks(2140), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 21, 15, 43, 55, 708, DateTimeKind.Local).AddTicks(9915), null, new DateTime(2022, 5, 10, 18, 33, 36, 268, DateTimeKind.Local).AddTicks(4216), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 1, 30, 15, 36, 31, 163, DateTimeKind.Local).AddTicks(7103), null, new DateTime(2022, 8, 7, 21, 18, 39, 942, DateTimeKind.Local).AddTicks(2122), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 23, 6, 44, 7, 850, DateTimeKind.Local).AddTicks(178), null, new DateTime(2023, 1, 6, 16, 6, 45, 289, DateTimeKind.Local).AddTicks(5832), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 10, 23, 23, 8, 877, DateTimeKind.Local).AddTicks(4114), null, new DateTime(2022, 7, 4, 20, 30, 29, 469, DateTimeKind.Local).AddTicks(1833), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 7, 0, 29, 4, 768, DateTimeKind.Local).AddTicks(1716), null, new DateTime(2023, 1, 13, 5, 47, 33, 103, DateTimeKind.Local).AddTicks(8845), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 19, 19, 19, 39, 813, DateTimeKind.Local).AddTicks(206), null, new DateTime(2022, 10, 2, 14, 26, 36, 218, DateTimeKind.Local).AddTicks(6668), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 25, 13, 10, 13, 92, DateTimeKind.Local).AddTicks(7785), null, new DateTime(2022, 8, 5, 15, 6, 13, 981, DateTimeKind.Local).AddTicks(9220), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 15, 14, 17, 47, 991, DateTimeKind.Local).AddTicks(2094), null, new DateTime(2022, 6, 24, 19, 9, 57, 521, DateTimeKind.Local).AddTicks(1620), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 20, 7, 17, 37, 1, DateTimeKind.Local).AddTicks(115), null, new DateTime(2022, 6, 19, 0, 48, 13, 878, DateTimeKind.Local).AddTicks(8805), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 4, 23, 5, 45, 515, DateTimeKind.Local).AddTicks(7712), null, new DateTime(2022, 9, 17, 16, 48, 1, 84, DateTimeKind.Local).AddTicks(3590), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 7, 21, 43, 33, 631, DateTimeKind.Local).AddTicks(377), null, new DateTime(2022, 12, 12, 12, 46, 5, 509, DateTimeKind.Local).AddTicks(8210), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 20, 14, 0, 25, 489, DateTimeKind.Local).AddTicks(8607), null, new DateTime(2022, 11, 24, 16, 27, 55, 273, DateTimeKind.Local).AddTicks(7282), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 23, 21, 39, 6, 142, DateTimeKind.Local).AddTicks(125), null, new DateTime(2023, 3, 30, 6, 30, 4, 625, DateTimeKind.Local).AddTicks(5120), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 4, 13, 21, 23, 383, DateTimeKind.Local).AddTicks(4053), null, new DateTime(2022, 6, 28, 5, 49, 2, 350, DateTimeKind.Local).AddTicks(8046), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 21, 12, 54, 42, 38, DateTimeKind.Local).AddTicks(4038), null, new DateTime(2023, 2, 20, 22, 38, 22, 74, DateTimeKind.Local).AddTicks(2999), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 12, 22, 25, 28, 735, DateTimeKind.Local).AddTicks(662), null, new DateTime(2022, 10, 25, 20, 42, 28, 98, DateTimeKind.Local).AddTicks(3806), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 9, 4, 21, 5, 384, DateTimeKind.Local).AddTicks(9499), null, new DateTime(2022, 6, 10, 22, 36, 37, 905, DateTimeKind.Local).AddTicks(2899), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 4, 13, 58, 58, 981, DateTimeKind.Local).AddTicks(471), null, new DateTime(2022, 11, 1, 2, 53, 24, 914, DateTimeKind.Local).AddTicks(8331), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 22, 7, 42, 0, 75, DateTimeKind.Local).AddTicks(4), null, new DateTime(2023, 1, 12, 18, 51, 36, 522, DateTimeKind.Local).AddTicks(3991), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 17, 17, 49, 48, 494, DateTimeKind.Local).AddTicks(5154), null, new DateTime(2022, 8, 15, 1, 57, 14, 77, DateTimeKind.Local).AddTicks(8029), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 21, 8, 1, 46, 140, DateTimeKind.Local).AddTicks(1919), null, new DateTime(2022, 12, 1, 23, 45, 39, 786, DateTimeKind.Local).AddTicks(9676), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 13, 3, 23, 57, 452, DateTimeKind.Local).AddTicks(8180), null, new DateTime(2022, 12, 31, 8, 56, 30, 686, DateTimeKind.Local).AddTicks(609), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 28, 23, 16, 53, 871, DateTimeKind.Local).AddTicks(3008), null, new DateTime(2023, 4, 5, 22, 3, 50, 242, DateTimeKind.Local).AddTicks(3705), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 26, 1, 41, 3, 801, DateTimeKind.Local).AddTicks(6597), null, new DateTime(2023, 2, 7, 17, 27, 57, 12, DateTimeKind.Local).AddTicks(2574), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 13, 21, 35, 11, 460, DateTimeKind.Local).AddTicks(292), null, new DateTime(2022, 6, 20, 0, 58, 11, 549, DateTimeKind.Local).AddTicks(9546), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 27, 1, 43, 6, 579, DateTimeKind.Local).AddTicks(3170), null, new DateTime(2022, 10, 30, 8, 58, 57, 965, DateTimeKind.Local).AddTicks(631), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2022, 12, 29, 19, 37, 33, 953, DateTimeKind.Local).AddTicks(9980), null, new DateTime(2023, 2, 12, 5, 8, 16, 510, DateTimeKind.Local).AddTicks(633), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 12, 2, 53, 4, 113, DateTimeKind.Local).AddTicks(6713), null, new DateTime(2022, 8, 19, 0, 36, 6, 404, DateTimeKind.Local).AddTicks(2681), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 7, 12, 48, 34, 36, DateTimeKind.Local).AddTicks(8142), null, new DateTime(2022, 5, 13, 20, 26, 56, 91, DateTimeKind.Local).AddTicks(344), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 5, 31, 15, 43, 38, 591, DateTimeKind.Local).AddTicks(5545), null, new DateTime(2023, 3, 9, 4, 44, 52, 570, DateTimeKind.Local).AddTicks(6028), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 4, 3, 2, 53, 441, DateTimeKind.Local).AddTicks(7346), null, new DateTime(2023, 1, 21, 20, 6, 37, 554, DateTimeKind.Local).AddTicks(2608), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 24, 4, 4, 11, 815, DateTimeKind.Local).AddTicks(3518), null, new DateTime(2022, 12, 3, 7, 35, 48, 299, DateTimeKind.Local).AddTicks(165), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 3, 31, 4, 41, 38, 235, DateTimeKind.Local).AddTicks(3594), null, new DateTime(2022, 8, 4, 7, 9, 18, 898, DateTimeKind.Local).AddTicks(5484), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 15, 20, 47, 4, 448, DateTimeKind.Local).AddTicks(5345), null, new DateTime(2023, 1, 20, 6, 13, 47, 979, DateTimeKind.Local).AddTicks(2616), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 7, 30, 0, 10, 9, 3, DateTimeKind.Local).AddTicks(3762), null, new DateTime(2022, 6, 2, 12, 42, 32, 713, DateTimeKind.Local).AddTicks(1124), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 3, 18, 7, 48, 257, DateTimeKind.Local).AddTicks(5), null, new DateTime(2023, 1, 1, 1, 36, 43, 541, DateTimeKind.Local).AddTicks(6936), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 12, 10, 1, 0, 921, DateTimeKind.Local).AddTicks(306), null, new DateTime(2023, 1, 12, 0, 3, 11, 188, DateTimeKind.Local).AddTicks(6375), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 16, 20, 18, 47, 98, DateTimeKind.Local).AddTicks(363), null, new DateTime(2023, 1, 10, 20, 37, 41, 639, DateTimeKind.Local).AddTicks(8214), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 26, 9, 17, 55, 253, DateTimeKind.Local).AddTicks(1079), null, new DateTime(2022, 11, 27, 14, 28, 9, 864, DateTimeKind.Local).AddTicks(2002), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 25, 7, 55, 9, 593, DateTimeKind.Local).AddTicks(3410), null, new DateTime(2022, 8, 21, 12, 48, 45, 827, DateTimeKind.Local).AddTicks(7922), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 6, 12, 48, 42, 380, DateTimeKind.Local).AddTicks(2591), null, new DateTime(2023, 2, 2, 0, 29, 25, 802, DateTimeKind.Local).AddTicks(8470), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 11, 29, 18, 58, 4, 767, DateTimeKind.Local).AddTicks(1650), null, new DateTime(2022, 6, 7, 11, 58, 58, 425, DateTimeKind.Local).AddTicks(5765), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 13, 5, 36, 54, 399, DateTimeKind.Local).AddTicks(5991), null, new DateTime(2022, 7, 29, 0, 56, 49, 903, DateTimeKind.Local).AddTicks(8161), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 25, 7, 41, 2, 214, DateTimeKind.Local).AddTicks(8570), null, new DateTime(2022, 11, 30, 6, 2, 16, 618, DateTimeKind.Local).AddTicks(2286), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 10, 19, 20, 3, 532, DateTimeKind.Local).AddTicks(4309), null, new DateTime(2023, 4, 11, 13, 24, 39, 881, DateTimeKind.Local).AddTicks(8780), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 17, 21, 46, 13, 980, DateTimeKind.Local).AddTicks(8245), null, new DateTime(2023, 3, 26, 14, 44, 59, 786, DateTimeKind.Local).AddTicks(2180), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 3, 23, 12, 27, 292, DateTimeKind.Local).AddTicks(1393), null, new DateTime(2023, 2, 4, 7, 15, 18, 936, DateTimeKind.Local).AddTicks(5786), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 2, 2, 48, 34, 509, DateTimeKind.Local).AddTicks(4029), null, new DateTime(2022, 11, 5, 2, 43, 9, 780, DateTimeKind.Local).AddTicks(4061), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 28, 23, 27, 6, 248, DateTimeKind.Local).AddTicks(9582), null, new DateTime(2022, 6, 25, 19, 13, 5, 610, DateTimeKind.Local).AddTicks(3945), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 12, 10, 18, 47, 646, DateTimeKind.Local).AddTicks(3477), null, new DateTime(2022, 7, 1, 19, 43, 0, 524, DateTimeKind.Local).AddTicks(7437), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 16, 2, 8, 10, 58, DateTimeKind.Local).AddTicks(8760), null, new DateTime(2022, 7, 18, 7, 47, 37, 634, DateTimeKind.Local).AddTicks(2691), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 19, 15, 55, 57, 858, DateTimeKind.Local).AddTicks(7893), null, new DateTime(2022, 11, 15, 3, 3, 29, 342, DateTimeKind.Local).AddTicks(1103), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 9, 2, 1, 15, 642, DateTimeKind.Local).AddTicks(7907), null, new DateTime(2022, 7, 4, 2, 32, 8, 397, DateTimeKind.Local).AddTicks(4981), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 14, 14, 44, 22, 480, DateTimeKind.Local).AddTicks(8875), null, new DateTime(2023, 1, 21, 3, 7, 48, 249, DateTimeKind.Local).AddTicks(8277), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 24, 20, 12, 6, 713, DateTimeKind.Local).AddTicks(60), null, new DateTime(2023, 1, 1, 18, 10, 3, 217, DateTimeKind.Local).AddTicks(5420), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 13, 21, 17, 24, 632, DateTimeKind.Local).AddTicks(1353), null, new DateTime(2022, 8, 14, 20, 25, 3, 702, DateTimeKind.Local).AddTicks(8824), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 26, 3, 59, 10, 609, DateTimeKind.Local).AddTicks(6668), null, new DateTime(2022, 7, 18, 3, 43, 40, 618, DateTimeKind.Local).AddTicks(9356), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 2, 12, 1, 16, 48, DateTimeKind.Local).AddTicks(2855), null, new DateTime(2022, 9, 5, 17, 15, 41, 558, DateTimeKind.Local).AddTicks(9625), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 16, 20, 56, 18, 122, DateTimeKind.Local).AddTicks(1040), null, new DateTime(2022, 6, 10, 6, 8, 37, 175, DateTimeKind.Local).AddTicks(3231), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 13, 16, 45, 27, 421, DateTimeKind.Local).AddTicks(7218), null, new DateTime(2022, 7, 7, 21, 27, 37, 799, DateTimeKind.Local).AddTicks(8647), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 11, 6, 11, 14, 111, DateTimeKind.Local).AddTicks(6762), null, new DateTime(2023, 2, 7, 15, 23, 45, 178, DateTimeKind.Local).AddTicks(7910), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 10, 12, 4, 27, 982, DateTimeKind.Local).AddTicks(488), null, new DateTime(2023, 3, 24, 10, 42, 23, 314, DateTimeKind.Local).AddTicks(90), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 28, 3, 15, 44, 632, DateTimeKind.Local).AddTicks(4821), null, new DateTime(2023, 3, 4, 17, 36, 37, 437, DateTimeKind.Local).AddTicks(1107), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 2, 8, 25, 6, 226, DateTimeKind.Local).AddTicks(2034), null, new DateTime(2022, 11, 7, 9, 7, 20, 419, DateTimeKind.Local).AddTicks(7416), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 20, 12, 37, 12, 874, DateTimeKind.Local).AddTicks(3624), null, new DateTime(2022, 10, 9, 9, 8, 25, 362, DateTimeKind.Local).AddTicks(9867), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 8, 7, 11, 46, 149, DateTimeKind.Local).AddTicks(8953), null, new DateTime(2023, 2, 10, 14, 28, 49, 424, DateTimeKind.Local).AddTicks(7707), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 3, 4, 19, 25, 546, DateTimeKind.Local).AddTicks(5225), null, new DateTime(2022, 6, 25, 7, 19, 36, 959, DateTimeKind.Local).AddTicks(7430), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 20, 2, 9, 5, 184, DateTimeKind.Local).AddTicks(9583), null, new DateTime(2023, 3, 14, 4, 37, 38, 447, DateTimeKind.Local).AddTicks(173), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 22, 19, 1, 17, 987, DateTimeKind.Local).AddTicks(5385), null, new DateTime(2022, 11, 8, 3, 12, 21, 29, DateTimeKind.Local).AddTicks(713), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 9, 15, 13, 37, 153, DateTimeKind.Local).AddTicks(8486), null, new DateTime(2022, 5, 12, 21, 34, 21, 964, DateTimeKind.Local).AddTicks(5690), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 21, 10, 43, 21, 621, DateTimeKind.Local).AddTicks(5620), null, new DateTime(2022, 12, 12, 17, 34, 41, 292, DateTimeKind.Local).AddTicks(2967), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 12, 0, 31, 18, 12, DateTimeKind.Local).AddTicks(4520), null, new DateTime(2022, 9, 1, 14, 18, 42, 23, DateTimeKind.Local).AddTicks(7108), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 2, 9, 54, 22, 787, DateTimeKind.Local).AddTicks(1378), null, new DateTime(2022, 6, 16, 3, 38, 10, 526, DateTimeKind.Local).AddTicks(2174), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 13, 9, 14, 44, 444, DateTimeKind.Local).AddTicks(3024), null, new DateTime(2022, 5, 11, 22, 4, 49, 22, DateTimeKind.Local).AddTicks(9581), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 28, 7, 18, 56, 389, DateTimeKind.Local).AddTicks(8760), new DateTime(2022, 7, 9, 3, 4, 37, 598, DateTimeKind.Local).AddTicks(2573), 25, 9.95097448977155m },
                    { 2, 65, new DateTime(2022, 12, 8, 12, 33, 19, 621, DateTimeKind.Local).AddTicks(4502), new DateTime(2022, 5, 7, 6, 5, 44, 450, DateTimeKind.Local).AddTicks(4539), 66, 19.9984561555668m },
                    { 3, 97, new DateTime(2023, 4, 6, 7, 28, 14, 664, DateTimeKind.Local).AddTicks(6861), new DateTime(2023, 1, 16, 5, 35, 38, 56, DateTimeKind.Local).AddTicks(9943), 11, 12.9778307723135m },
                    { 4, 149, new DateTime(2022, 8, 10, 18, 55, 50, 513, DateTimeKind.Local).AddTicks(8762), new DateTime(2022, 8, 20, 17, 30, 40, 785, DateTimeKind.Local).AddTicks(2025), 33, 15.9291366642961m },
                    { 5, 93, new DateTime(2022, 8, 2, 17, 5, 8, 764, DateTimeKind.Local).AddTicks(7863), new DateTime(2022, 8, 3, 14, 35, 25, 234, DateTimeKind.Local).AddTicks(688), 29, 1.2915856337219m },
                    { 6, 15, new DateTime(2023, 2, 17, 0, 46, 56, 181, DateTimeKind.Local).AddTicks(7643), new DateTime(2022, 11, 28, 8, 15, 45, 283, DateTimeKind.Local).AddTicks(8315), 95, 27.388711609956m },
                    { 7, 26, new DateTime(2022, 7, 1, 0, 47, 4, 864, DateTimeKind.Local).AddTicks(9618), new DateTime(2022, 12, 25, 15, 0, 35, 344, DateTimeKind.Local).AddTicks(6507), 80, 5.7167113090536m },
                    { 8, 133, new DateTime(2022, 9, 25, 17, 7, 15, 358, DateTimeKind.Local).AddTicks(8340), new DateTime(2022, 7, 29, 3, 44, 21, 535, DateTimeKind.Local).AddTicks(560), 83, 11.6899179239743m },
                    { 9, 3, new DateTime(2022, 4, 19, 17, 29, 40, 612, DateTimeKind.Local).AddTicks(3722), new DateTime(2022, 6, 26, 11, 7, 37, 779, DateTimeKind.Local).AddTicks(3037), 70, 13.5811580283403m },
                    { 10, 10, new DateTime(2022, 10, 11, 0, 14, 23, 776, DateTimeKind.Local).AddTicks(4675), new DateTime(2022, 10, 7, 1, 4, 1, 199, DateTimeKind.Local).AddTicks(3862), 86, 28.8564010777465m },
                    { 11, 150, new DateTime(2022, 8, 7, 12, 15, 15, 956, DateTimeKind.Local).AddTicks(2907), new DateTime(2022, 11, 26, 15, 34, 39, 280, DateTimeKind.Local).AddTicks(5841), 28, 28.8939611880611m },
                    { 12, 102, new DateTime(2022, 8, 12, 12, 27, 56, 729, DateTimeKind.Local).AddTicks(2733), new DateTime(2022, 10, 26, 3, 56, 49, 199, DateTimeKind.Local).AddTicks(3634), 44, 4.43127099245005m },
                    { 13, 54, new DateTime(2022, 10, 6, 16, 21, 21, 738, DateTimeKind.Local).AddTicks(4110), new DateTime(2023, 2, 13, 22, 8, 46, 270, DateTimeKind.Local).AddTicks(2998), 25, 22.0627318229384m },
                    { 14, 104, new DateTime(2022, 11, 23, 12, 52, 32, 395, DateTimeKind.Local).AddTicks(7448), new DateTime(2023, 2, 19, 2, 4, 31, 845, DateTimeKind.Local).AddTicks(9654), 35, 26.4446447546241m },
                    { 15, 13, new DateTime(2022, 4, 26, 9, 5, 56, 178, DateTimeKind.Local).AddTicks(6799), new DateTime(2022, 10, 20, 14, 59, 45, 496, DateTimeKind.Local).AddTicks(2911), 95, 3.86987151266905m },
                    { 16, 8, new DateTime(2023, 3, 3, 15, 49, 29, 27, DateTimeKind.Local).AddTicks(1637), new DateTime(2023, 1, 28, 8, 42, 29, 743, DateTimeKind.Local).AddTicks(3807), 64, 13.7605663720428m },
                    { 17, 47, new DateTime(2022, 9, 28, 11, 25, 31, 420, DateTimeKind.Local).AddTicks(3242), new DateTime(2022, 12, 25, 21, 25, 35, 879, DateTimeKind.Local).AddTicks(2053), 9, 28.8578542706906m },
                    { 18, 132, new DateTime(2022, 6, 30, 4, 6, 18, 925, DateTimeKind.Local).AddTicks(9547), new DateTime(2023, 1, 26, 9, 9, 1, 235, DateTimeKind.Local).AddTicks(8187), 100, 7.66092301940397m },
                    { 19, 27, new DateTime(2022, 11, 11, 4, 32, 19, 427, DateTimeKind.Local).AddTicks(1284), new DateTime(2022, 5, 2, 19, 55, 33, 781, DateTimeKind.Local).AddTicks(3297), 11, 11.8173528838586m },
                    { 20, 117, new DateTime(2022, 5, 5, 21, 1, 40, 26, DateTimeKind.Local).AddTicks(7277), new DateTime(2023, 3, 3, 0, 51, 35, 407, DateTimeKind.Local).AddTicks(4699), 41, 28.2796220416194m },
                    { 21, 49, new DateTime(2023, 3, 24, 20, 59, 38, 629, DateTimeKind.Local).AddTicks(8418), new DateTime(2022, 10, 27, 9, 7, 15, 525, DateTimeKind.Local).AddTicks(7548), 50, 19.557334549424m },
                    { 22, 59, new DateTime(2022, 12, 2, 15, 50, 54, 781, DateTimeKind.Local).AddTicks(3650), new DateTime(2023, 4, 13, 23, 44, 44, 227, DateTimeKind.Local).AddTicks(9001), 37, 19.1881642353262m },
                    { 23, 126, new DateTime(2022, 6, 8, 3, 41, 50, 835, DateTimeKind.Local).AddTicks(1115), new DateTime(2022, 7, 8, 8, 40, 55, 943, DateTimeKind.Local).AddTicks(5786), 62, 9.2321823634378m },
                    { 24, 4, new DateTime(2022, 5, 28, 6, 41, 52, 988, DateTimeKind.Local).AddTicks(6367), new DateTime(2023, 1, 24, 6, 50, 6, 720, DateTimeKind.Local).AddTicks(5399), 9, 10.4265947206316m },
                    { 25, 72, new DateTime(2022, 12, 28, 2, 16, 47, 842, DateTimeKind.Local).AddTicks(306), new DateTime(2023, 3, 3, 1, 49, 57, 317, DateTimeKind.Local).AddTicks(8749), 88, 29.514816140983m },
                    { 26, 56, new DateTime(2022, 10, 25, 9, 28, 21, 390, DateTimeKind.Local).AddTicks(9142), new DateTime(2022, 12, 3, 4, 32, 29, 170, DateTimeKind.Local).AddTicks(6392), 13, 9.62618919378305m },
                    { 27, 46, new DateTime(2023, 3, 22, 18, 29, 29, 187, DateTimeKind.Local).AddTicks(6261), new DateTime(2023, 2, 14, 14, 12, 4, 378, DateTimeKind.Local).AddTicks(6950), 56, 16.7206619489067m },
                    { 28, 66, new DateTime(2022, 7, 15, 22, 5, 1, 737, DateTimeKind.Local).AddTicks(4827), new DateTime(2023, 2, 11, 16, 33, 15, 233, DateTimeKind.Local).AddTicks(4179), 27, 20.432207404926m },
                    { 29, 128, new DateTime(2022, 4, 18, 5, 39, 53, 175, DateTimeKind.Local).AddTicks(5863), new DateTime(2022, 12, 21, 15, 51, 37, 735, DateTimeKind.Local).AddTicks(5587), 14, 16.4297866412782m },
                    { 30, 98, new DateTime(2022, 6, 8, 20, 12, 29, 723, DateTimeKind.Local).AddTicks(7739), new DateTime(2022, 8, 4, 12, 39, 7, 540, DateTimeKind.Local).AddTicks(4285), 99, 28.7079862757308m },
                    { 31, 82, new DateTime(2022, 8, 8, 15, 14, 6, 885, DateTimeKind.Local).AddTicks(7692), new DateTime(2023, 2, 16, 21, 23, 4, 232, DateTimeKind.Local).AddTicks(4530), 95, 14.1875767615738m },
                    { 32, 4, new DateTime(2023, 2, 27, 19, 26, 57, 76, DateTimeKind.Local).AddTicks(6381), new DateTime(2023, 3, 20, 12, 44, 23, 992, DateTimeKind.Local).AddTicks(9094), 2, 9.3771459663145m },
                    { 33, 31, new DateTime(2023, 3, 17, 11, 4, 39, 310, DateTimeKind.Local).AddTicks(6645), new DateTime(2022, 5, 13, 18, 46, 29, 85, DateTimeKind.Local).AddTicks(9871), 30, 8.6019575696897m },
                    { 34, 124, new DateTime(2022, 4, 18, 6, 30, 30, 434, DateTimeKind.Local).AddTicks(9213), new DateTime(2023, 3, 3, 12, 37, 16, 661, DateTimeKind.Local).AddTicks(527), 48, 9.35616641270443m },
                    { 35, 105, new DateTime(2022, 5, 18, 19, 25, 4, 173, DateTimeKind.Local).AddTicks(4135), new DateTime(2023, 3, 27, 23, 37, 24, 707, DateTimeKind.Local).AddTicks(4314), 85, 12.7878514361451m },
                    { 36, 31, new DateTime(2022, 7, 18, 21, 12, 10, 865, DateTimeKind.Local).AddTicks(4954), new DateTime(2023, 2, 10, 7, 34, 15, 569, DateTimeKind.Local).AddTicks(4389), 32, 27.3447483516771m },
                    { 37, 103, new DateTime(2022, 8, 27, 12, 19, 39, 673, DateTimeKind.Local).AddTicks(8703), new DateTime(2023, 1, 19, 23, 47, 28, 578, DateTimeKind.Local).AddTicks(3896), 9, 4.24971995356886m },
                    { 38, 86, new DateTime(2023, 1, 18, 11, 57, 15, 883, DateTimeKind.Local).AddTicks(2119), new DateTime(2023, 1, 25, 20, 28, 26, 159, DateTimeKind.Local).AddTicks(6776), 4, 19.9042997476422m },
                    { 39, 91, new DateTime(2023, 2, 9, 19, 37, 13, 779, DateTimeKind.Local).AddTicks(2471), new DateTime(2022, 9, 15, 1, 0, 2, 970, DateTimeKind.Local).AddTicks(5559), 63, 25.4829108821753m },
                    { 40, 48, new DateTime(2022, 12, 10, 6, 6, 22, 80, DateTimeKind.Local).AddTicks(8142), new DateTime(2022, 10, 3, 12, 36, 33, 560, DateTimeKind.Local).AddTicks(3983), 69, 28.6135369243402m },
                    { 41, 150, new DateTime(2022, 6, 1, 10, 33, 4, 611, DateTimeKind.Local).AddTicks(5662), new DateTime(2023, 3, 25, 23, 10, 5, 846, DateTimeKind.Local).AddTicks(2506), 18, 13.6635914635162m },
                    { 42, 125, new DateTime(2022, 8, 3, 15, 18, 0, 983, DateTimeKind.Local).AddTicks(9014), new DateTime(2022, 12, 23, 19, 29, 18, 751, DateTimeKind.Local).AddTicks(2913), 36, 3.33299755516382m },
                    { 43, 132, new DateTime(2022, 10, 26, 10, 9, 58, 270, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 12, 31, 20, 45, 26, 568, DateTimeKind.Local).AddTicks(5626), 86, 4.57907594800466m },
                    { 44, 121, new DateTime(2022, 11, 28, 17, 50, 22, 449, DateTimeKind.Local).AddTicks(1507), new DateTime(2022, 7, 20, 22, 53, 38, 326, DateTimeKind.Local).AddTicks(4046), 74, 23.7769119276899m },
                    { 45, 77, new DateTime(2023, 3, 19, 9, 43, 12, 13, DateTimeKind.Local).AddTicks(1577), new DateTime(2022, 12, 14, 5, 37, 16, 678, DateTimeKind.Local).AddTicks(5801), 80, 17.4810616266173m },
                    { 46, 135, new DateTime(2023, 3, 31, 14, 49, 53, 697, DateTimeKind.Local).AddTicks(9466), new DateTime(2022, 7, 26, 7, 8, 29, 704, DateTimeKind.Local).AddTicks(5007), 39, 28.8954990969603m },
                    { 47, 130, new DateTime(2022, 12, 26, 17, 6, 27, 406, DateTimeKind.Local).AddTicks(4760), new DateTime(2022, 6, 2, 5, 57, 19, 138, DateTimeKind.Local).AddTicks(3660), 97, 18.1339658223157m },
                    { 48, 62, new DateTime(2022, 11, 7, 18, 29, 17, 506, DateTimeKind.Local).AddTicks(3775), new DateTime(2022, 10, 4, 11, 56, 7, 497, DateTimeKind.Local).AddTicks(440), 65, 14.0968422816675m },
                    { 49, 57, new DateTime(2022, 5, 30, 17, 32, 16, 91, DateTimeKind.Local).AddTicks(989), new DateTime(2022, 12, 19, 7, 23, 25, 87, DateTimeKind.Local).AddTicks(155), 35, 14.2593913497433m },
                    { 50, 103, new DateTime(2022, 6, 20, 7, 22, 11, 75, DateTimeKind.Local).AddTicks(3077), new DateTime(2023, 1, 13, 2, 41, 4, 758, DateTimeKind.Local).AddTicks(2545), 33, 21.1078219375825m },
                    { 51, 49, new DateTime(2022, 11, 28, 3, 43, 53, 51, DateTimeKind.Local).AddTicks(7186), new DateTime(2023, 2, 18, 23, 11, 38, 970, DateTimeKind.Local).AddTicks(8855), 98, 23.446671240822m },
                    { 52, 143, new DateTime(2022, 10, 22, 14, 51, 31, 641, DateTimeKind.Local).AddTicks(2985), new DateTime(2022, 6, 20, 23, 24, 41, 853, DateTimeKind.Local).AddTicks(6255), 10, 11.4092627387523m },
                    { 53, 67, new DateTime(2022, 7, 2, 16, 11, 41, 453, DateTimeKind.Local).AddTicks(2341), new DateTime(2023, 2, 12, 4, 47, 53, 28, DateTimeKind.Local).AddTicks(8033), 23, 1.77951421241599m },
                    { 54, 2, new DateTime(2023, 2, 21, 11, 11, 5, 61, DateTimeKind.Local).AddTicks(4981), new DateTime(2023, 1, 4, 4, 45, 25, 308, DateTimeKind.Local).AddTicks(5438), 24, 27.5495624154599m },
                    { 55, 23, new DateTime(2023, 3, 11, 19, 5, 23, 832, DateTimeKind.Local).AddTicks(4778), new DateTime(2022, 10, 18, 3, 55, 36, 533, DateTimeKind.Local).AddTicks(6065), 95, 14.2540360943248m },
                    { 56, 125, new DateTime(2022, 8, 16, 1, 35, 4, 631, DateTimeKind.Local).AddTicks(2800), new DateTime(2022, 11, 5, 8, 52, 53, 252, DateTimeKind.Local).AddTicks(7611), 53, 24.9560944840784m },
                    { 57, 141, new DateTime(2022, 5, 6, 16, 4, 53, 999, DateTimeKind.Local).AddTicks(7668), new DateTime(2022, 12, 5, 17, 8, 9, 95, DateTimeKind.Local).AddTicks(8207), 44, 13.3359494464686m },
                    { 58, 9, new DateTime(2022, 11, 17, 13, 28, 7, 344, DateTimeKind.Local).AddTicks(8919), new DateTime(2023, 3, 7, 5, 6, 1, 688, DateTimeKind.Local).AddTicks(5268), 93, 17.9885680731216m },
                    { 59, 124, new DateTime(2022, 12, 6, 15, 26, 56, 870, DateTimeKind.Local).AddTicks(3778), new DateTime(2023, 3, 25, 2, 54, 52, 766, DateTimeKind.Local).AddTicks(7722), 69, 17.2377326603942m },
                    { 60, 134, new DateTime(2022, 8, 30, 8, 8, 27, 531, DateTimeKind.Local).AddTicks(5172), new DateTime(2023, 4, 13, 7, 12, 37, 889, DateTimeKind.Local).AddTicks(5759), 52, 14.1651758782627m },
                    { 61, 73, new DateTime(2022, 8, 21, 15, 50, 16, 95, DateTimeKind.Local).AddTicks(5015), new DateTime(2023, 2, 1, 15, 30, 23, 857, DateTimeKind.Local).AddTicks(6309), 38, 18.6656416385945m },
                    { 62, 40, new DateTime(2022, 12, 29, 15, 14, 17, 161, DateTimeKind.Local).AddTicks(3260), new DateTime(2022, 12, 15, 22, 31, 12, 357, DateTimeKind.Local).AddTicks(258), 63, 16.5342713830636m },
                    { 63, 90, new DateTime(2022, 11, 30, 22, 8, 28, 399, DateTimeKind.Local).AddTicks(8298), new DateTime(2023, 2, 11, 0, 20, 41, 264, DateTimeKind.Local).AddTicks(9125), 23, 1.04831060372208m },
                    { 64, 50, new DateTime(2022, 7, 22, 22, 9, 14, 322, DateTimeKind.Local).AddTicks(8169), new DateTime(2023, 2, 20, 23, 9, 23, 153, DateTimeKind.Local).AddTicks(1337), 59, 13.1295261746451m },
                    { 65, 141, new DateTime(2022, 7, 28, 6, 18, 34, 772, DateTimeKind.Local).AddTicks(3100), new DateTime(2023, 2, 18, 19, 5, 56, 589, DateTimeKind.Local).AddTicks(9893), 66, 19.6960312078095m },
                    { 66, 19, new DateTime(2022, 5, 23, 2, 2, 7, 737, DateTimeKind.Local).AddTicks(9611), new DateTime(2023, 2, 15, 21, 59, 50, 871, DateTimeKind.Local).AddTicks(1989), 1, 8.67925984444329m },
                    { 67, 102, new DateTime(2022, 10, 20, 10, 10, 27, 597, DateTimeKind.Local).AddTicks(3584), new DateTime(2022, 11, 16, 7, 59, 28, 271, DateTimeKind.Local).AddTicks(2860), 3, 5.35828478394654m },
                    { 68, 14, new DateTime(2022, 7, 9, 18, 30, 4, 671, DateTimeKind.Local).AddTicks(5900), new DateTime(2023, 3, 25, 11, 56, 27, 150, DateTimeKind.Local).AddTicks(5973), 66, 9.33735535136909m },
                    { 69, 14, new DateTime(2023, 3, 5, 9, 51, 9, 833, DateTimeKind.Local).AddTicks(4935), new DateTime(2023, 4, 2, 5, 9, 50, 73, DateTimeKind.Local).AddTicks(612), 53, 7.37175155241591m },
                    { 70, 70, new DateTime(2022, 6, 20, 1, 14, 22, 51, DateTimeKind.Local).AddTicks(1956), new DateTime(2023, 2, 12, 21, 31, 24, 911, DateTimeKind.Local).AddTicks(4768), 18, 24.2599381245337m },
                    { 71, 92, new DateTime(2023, 2, 27, 3, 10, 58, 353, DateTimeKind.Local).AddTicks(8675), new DateTime(2022, 12, 20, 2, 55, 28, 523, DateTimeKind.Local).AddTicks(5860), 65, 4.04054111410565m },
                    { 72, 36, new DateTime(2022, 10, 7, 7, 49, 35, 311, DateTimeKind.Local).AddTicks(3221), new DateTime(2022, 12, 7, 9, 30, 36, 80, DateTimeKind.Local).AddTicks(2217), 69, 28.7487577751276m },
                    { 73, 32, new DateTime(2022, 11, 19, 17, 19, 51, 285, DateTimeKind.Local).AddTicks(341), new DateTime(2022, 9, 19, 9, 44, 6, 28, DateTimeKind.Local).AddTicks(4755), 9, 16.6166179619704m },
                    { 74, 71, new DateTime(2023, 4, 15, 13, 45, 57, 384, DateTimeKind.Local).AddTicks(2576), new DateTime(2023, 1, 12, 14, 40, 49, 345, DateTimeKind.Local).AddTicks(1203), 17, 7.11301559282892m },
                    { 75, 74, new DateTime(2023, 2, 12, 13, 55, 10, 559, DateTimeKind.Local).AddTicks(2514), new DateTime(2022, 5, 7, 14, 52, 36, 627, DateTimeKind.Local).AddTicks(3451), 59, 26.7993583960183m },
                    { 76, 133, new DateTime(2022, 8, 10, 19, 9, 18, 634, DateTimeKind.Local).AddTicks(7394), new DateTime(2023, 2, 24, 0, 0, 43, 637, DateTimeKind.Local).AddTicks(7156), 78, 22.1326235701793m },
                    { 77, 48, new DateTime(2022, 8, 20, 10, 44, 48, 698, DateTimeKind.Local).AddTicks(9326), new DateTime(2022, 10, 17, 3, 43, 25, 624, DateTimeKind.Local).AddTicks(7925), 83, 27.1501384017847m },
                    { 78, 105, new DateTime(2022, 4, 26, 11, 19, 12, 212, DateTimeKind.Local).AddTicks(6669), new DateTime(2023, 2, 5, 17, 50, 5, 898, DateTimeKind.Local).AddTicks(5803), 22, 11.8956712620416m },
                    { 79, 83, new DateTime(2022, 10, 11, 17, 46, 37, 787, DateTimeKind.Local).AddTicks(4188), new DateTime(2022, 11, 23, 18, 12, 44, 53, DateTimeKind.Local).AddTicks(744), 12, 25.7539374134992m },
                    { 80, 87, new DateTime(2022, 10, 22, 15, 21, 36, 718, DateTimeKind.Local).AddTicks(4575), new DateTime(2022, 6, 30, 6, 47, 32, 408, DateTimeKind.Local).AddTicks(8989), 99, 6.47154902445479m },
                    { 81, 20, new DateTime(2022, 12, 18, 4, 46, 50, 148, DateTimeKind.Local).AddTicks(7624), new DateTime(2022, 11, 6, 5, 24, 5, 195, DateTimeKind.Local).AddTicks(5424), 16, 10.6968583605403m },
                    { 82, 30, new DateTime(2022, 5, 26, 8, 17, 2, 5, DateTimeKind.Local).AddTicks(4075), new DateTime(2023, 3, 29, 18, 53, 6, 814, DateTimeKind.Local).AddTicks(9537), 69, 5.24008254763046m },
                    { 83, 129, new DateTime(2022, 10, 31, 19, 10, 27, 67, DateTimeKind.Local).AddTicks(7316), new DateTime(2022, 8, 8, 12, 19, 30, 906, DateTimeKind.Local).AddTicks(6671), 9, 16.7039712201267m },
                    { 84, 133, new DateTime(2022, 11, 22, 23, 40, 42, 840, DateTimeKind.Local).AddTicks(8194), new DateTime(2022, 7, 12, 12, 24, 15, 103, DateTimeKind.Local).AddTicks(349), 30, 2.10330967611535m },
                    { 85, 149, new DateTime(2022, 10, 18, 14, 18, 57, 222, DateTimeKind.Local).AddTicks(1776), new DateTime(2022, 12, 3, 14, 45, 58, 94, DateTimeKind.Local).AddTicks(147), 93, 6.99242581127642m },
                    { 86, 5, new DateTime(2023, 2, 22, 21, 35, 26, 181, DateTimeKind.Local).AddTicks(5693), new DateTime(2022, 11, 24, 4, 32, 59, 63, DateTimeKind.Local).AddTicks(2751), 58, 22.3769173880054m },
                    { 87, 33, new DateTime(2022, 10, 30, 21, 47, 43, 90, DateTimeKind.Local).AddTicks(2676), new DateTime(2022, 9, 1, 13, 12, 0, 474, DateTimeKind.Local).AddTicks(8652), 24, 11.5960061104992m },
                    { 88, 92, new DateTime(2023, 1, 8, 1, 48, 39, 963, DateTimeKind.Local).AddTicks(578), new DateTime(2023, 4, 15, 5, 12, 28, 981, DateTimeKind.Local).AddTicks(4645), 97, 22.4886178346442m },
                    { 89, 57, new DateTime(2022, 7, 2, 17, 16, 46, 983, DateTimeKind.Local).AddTicks(5061), new DateTime(2022, 8, 24, 15, 30, 35, 744, DateTimeKind.Local).AddTicks(321), 1, 29.1749441873153m },
                    { 90, 36, new DateTime(2022, 10, 30, 14, 44, 37, 437, DateTimeKind.Local).AddTicks(5688), new DateTime(2022, 8, 28, 22, 10, 17, 848, DateTimeKind.Local).AddTicks(8066), 56, 15.7045960571397m },
                    { 91, 91, new DateTime(2022, 11, 17, 11, 16, 51, 875, DateTimeKind.Local).AddTicks(6873), new DateTime(2022, 12, 8, 11, 4, 34, 600, DateTimeKind.Local).AddTicks(7887), 43, 22.1417657332434m },
                    { 92, 43, new DateTime(2022, 5, 23, 3, 20, 50, 493, DateTimeKind.Local).AddTicks(7200), new DateTime(2023, 1, 21, 19, 54, 22, 704, DateTimeKind.Local).AddTicks(8682), 24, 7.46076218089746m },
                    { 93, 113, new DateTime(2022, 10, 29, 1, 28, 35, 854, DateTimeKind.Local).AddTicks(6087), new DateTime(2022, 4, 18, 4, 1, 39, 856, DateTimeKind.Local).AddTicks(4181), 16, 24.251541462149m },
                    { 94, 18, new DateTime(2023, 1, 27, 10, 5, 9, 837, DateTimeKind.Local).AddTicks(3866), new DateTime(2023, 3, 1, 11, 49, 25, 147, DateTimeKind.Local).AddTicks(8179), 9, 14.3451586321456m },
                    { 95, 141, new DateTime(2023, 1, 31, 6, 5, 58, 500, DateTimeKind.Local).AddTicks(4982), new DateTime(2022, 10, 28, 4, 6, 6, 4, DateTimeKind.Local).AddTicks(2030), 99, 5.72927331514482m },
                    { 96, 41, new DateTime(2023, 3, 15, 5, 17, 28, 470, DateTimeKind.Local).AddTicks(3761), new DateTime(2022, 10, 24, 15, 13, 5, 608, DateTimeKind.Local).AddTicks(4380), 74, 20.6535561612581m },
                    { 97, 68, new DateTime(2022, 8, 10, 15, 30, 57, 210, DateTimeKind.Local).AddTicks(3519), new DateTime(2022, 5, 18, 1, 41, 22, 445, DateTimeKind.Local).AddTicks(253), 59, 2.72821651507012m },
                    { 98, 113, new DateTime(2023, 1, 30, 15, 36, 31, 171, DateTimeKind.Local).AddTicks(2859), new DateTime(2022, 8, 7, 21, 18, 39, 949, DateTimeKind.Local).AddTicks(7877), 10, 10.486596894332m },
                    { 99, 130, new DateTime(2022, 5, 6, 18, 31, 13, 659, DateTimeKind.Local).AddTicks(7173), new DateTime(2022, 4, 26, 23, 10, 25, 878, DateTimeKind.Local).AddTicks(539), 54, 2.31891510953632m },
                    { 100, 119, new DateTime(2023, 2, 18, 12, 24, 16, 690, DateTimeKind.Local).AddTicks(7774), new DateTime(2022, 5, 4, 18, 38, 10, 579, DateTimeKind.Local).AddTicks(5663), 62, 17.0473561549267m },
                    { 101, 35, new DateTime(2022, 10, 26, 9, 45, 48, 264, DateTimeKind.Local).AddTicks(3763), new DateTime(2023, 1, 30, 2, 33, 0, 850, DateTimeKind.Local).AddTicks(7172), 32, 15.5621874880094m },
                    { 102, 42, new DateTime(2022, 5, 16, 2, 5, 1, 798, DateTimeKind.Local).AddTicks(7907), new DateTime(2022, 5, 26, 14, 32, 40, 262, DateTimeKind.Local).AddTicks(3974), 15, 26.0476897486501m },
                    { 103, 100, new DateTime(2022, 8, 19, 18, 6, 25, 217, DateTimeKind.Local).AddTicks(9869), new DateTime(2022, 9, 2, 14, 53, 38, 36, DateTimeKind.Local).AddTicks(7881), 16, 14.5699252433772m },
                    { 104, 149, new DateTime(2022, 5, 24, 16, 52, 17, 105, DateTimeKind.Local).AddTicks(4806), new DateTime(2023, 2, 19, 19, 29, 28, 94, DateTimeKind.Local).AddTicks(2828), 4, 7.15830745001319m },
                    { 105, 141, new DateTime(2022, 7, 10, 23, 23, 8, 884, DateTimeKind.Local).AddTicks(9880), new DateTime(2022, 7, 4, 20, 30, 29, 476, DateTimeKind.Local).AddTicks(7599), 52, 1.21850651968852m },
                    { 106, 148, new DateTime(2023, 2, 24, 8, 29, 39, 74, DateTimeKind.Local).AddTicks(371), new DateTime(2022, 11, 22, 13, 35, 50, 304, DateTimeKind.Local).AddTicks(2325), 61, 19.905500643124m },
                    { 107, 117, new DateTime(2022, 10, 28, 21, 16, 17, 387, DateTimeKind.Local).AddTicks(3468), new DateTime(2023, 1, 25, 5, 18, 32, 999, DateTimeKind.Local).AddTicks(8351), 55, 10.4941772241324m },
                    { 108, 37, new DateTime(2022, 10, 12, 0, 40, 22, 146, DateTimeKind.Local).AddTicks(4859), new DateTime(2023, 2, 4, 5, 13, 4, 135, DateTimeKind.Local).AddTicks(7982), 17, 11.8864180979893m },
                    { 109, 39, new DateTime(2023, 2, 19, 13, 37, 25, 920, DateTimeKind.Local).AddTicks(9778), new DateTime(2022, 10, 12, 21, 44, 25, 548, DateTimeKind.Local).AddTicks(4616), 78, 22.7478183534278m },
                    { 110, 132, new DateTime(2022, 12, 16, 2, 48, 42, 941, DateTimeKind.Local).AddTicks(3795), new DateTime(2022, 12, 23, 8, 14, 10, 799, DateTimeKind.Local).AddTicks(7014), 80, 3.1980585854603m },
                    { 111, 119, new DateTime(2022, 7, 15, 10, 19, 8, 941, DateTimeKind.Local).AddTicks(5745), new DateTime(2022, 11, 11, 0, 17, 6, 985, DateTimeKind.Local).AddTicks(6850), 54, 17.5128468591567m },
                    { 112, 89, new DateTime(2022, 8, 19, 19, 19, 39, 820, DateTimeKind.Local).AddTicks(6027), new DateTime(2022, 10, 2, 14, 26, 36, 226, DateTimeKind.Local).AddTicks(2488), 10, 23.2304254914434m },
                    { 113, 119, new DateTime(2022, 11, 1, 18, 16, 27, 273, DateTimeKind.Local).AddTicks(9635), new DateTime(2022, 8, 11, 9, 25, 1, 924, DateTimeKind.Local).AddTicks(6277), 97, 19.6355650151101m },
                    { 114, 57, new DateTime(2022, 12, 10, 16, 49, 41, 293, DateTimeKind.Local).AddTicks(4291), new DateTime(2022, 12, 18, 7, 8, 57, 225, DateTimeKind.Local).AddTicks(767), 3, 24.7544894768157m },
                    { 115, 12, new DateTime(2022, 8, 15, 18, 27, 24, 147, DateTimeKind.Local).AddTicks(1287), new DateTime(2022, 12, 3, 2, 34, 11, 952, DateTimeKind.Local).AddTicks(7896), 9, 25.9381781379504m },
                    { 116, 105, new DateTime(2022, 7, 27, 14, 8, 30, 107, DateTimeKind.Local).AddTicks(1800), new DateTime(2022, 5, 17, 22, 47, 14, 734, DateTimeKind.Local).AddTicks(6718), 81, 27.6417829093898m },
                    { 117, 70, new DateTime(2022, 6, 13, 8, 44, 18, 451, DateTimeKind.Local).AddTicks(5847), new DateTime(2022, 7, 7, 8, 50, 57, 398, DateTimeKind.Local).AddTicks(8078), 16, 17.0929960318071m },
                    { 118, 59, new DateTime(2022, 12, 7, 15, 50, 29, 637, DateTimeKind.Local).AddTicks(6221), new DateTime(2022, 8, 26, 20, 29, 16, 174, DateTimeKind.Local).AddTicks(9874), 84, 13.3181415352446m },
                    { 119, 68, new DateTime(2023, 1, 15, 14, 17, 47, 998, DateTimeKind.Local).AddTicks(7872), new DateTime(2022, 6, 24, 19, 9, 57, 528, DateTimeKind.Local).AddTicks(7398), 61, 18.8315219449265m },
                    { 120, 107, new DateTime(2022, 12, 27, 5, 12, 23, 234, DateTimeKind.Local).AddTicks(9344), new DateTime(2022, 5, 4, 1, 42, 28, 759, DateTimeKind.Local).AddTicks(6492), 24, 6.81617620010631m },
                    { 121, 140, new DateTime(2023, 1, 12, 11, 42, 25, 541, DateTimeKind.Local).AddTicks(4453), new DateTime(2022, 11, 29, 19, 42, 9, 780, DateTimeKind.Local).AddTicks(3429), 12, 15.6376381840714m },
                    { 122, 125, new DateTime(2023, 2, 12, 23, 45, 36, 249, DateTimeKind.Local).AddTicks(5050), new DateTime(2022, 11, 20, 8, 35, 17, 561, DateTimeKind.Local).AddTicks(7475), 80, 22.9455118092823m },
                    { 123, 124, new DateTime(2022, 11, 13, 10, 0, 59, 46, DateTimeKind.Local).AddTicks(5971), new DateTime(2022, 7, 27, 1, 48, 45, 687, DateTimeKind.Local).AddTicks(799), 91, 8.05913825594734m },
                    { 124, 145, new DateTime(2022, 10, 14, 13, 23, 42, 889, DateTimeKind.Local).AddTicks(9007), new DateTime(2022, 6, 15, 3, 45, 57, 869, DateTimeKind.Local).AddTicks(5815), 22, 14.0078435990096m },
                    { 125, 126, new DateTime(2023, 1, 5, 1, 10, 22, 105, DateTimeKind.Local).AddTicks(9732), new DateTime(2022, 8, 28, 13, 49, 51, 177, DateTimeKind.Local).AddTicks(6751), 8, 19.2589875037197m },
                    { 126, 133, new DateTime(2022, 8, 4, 23, 5, 45, 523, DateTimeKind.Local).AddTicks(3501), new DateTime(2022, 9, 17, 16, 48, 1, 91, DateTimeKind.Local).AddTicks(9379), 75, 26.2868222754801m },
                    { 127, 123, new DateTime(2023, 3, 18, 21, 50, 13, 408, DateTimeKind.Local).AddTicks(2416), new DateTime(2022, 9, 20, 8, 38, 14, 991, DateTimeKind.Local).AddTicks(5708), 44, 7.49074260448661m },
                    { 128, 81, new DateTime(2023, 3, 12, 21, 28, 52, 927, DateTimeKind.Local).AddTicks(4389), new DateTime(2022, 11, 30, 21, 50, 39, 604, DateTimeKind.Local).AddTicks(779), 13, 15.3760291205783m },
                    { 129, 108, new DateTime(2023, 1, 14, 23, 24, 10, 678, DateTimeKind.Local).AddTicks(524), new DateTime(2022, 5, 30, 6, 20, 31, 939, DateTimeKind.Local).AddTicks(2655), 78, 4.86938521600452m },
                    { 130, 52, new DateTime(2023, 3, 2, 11, 49, 12, 858, DateTimeKind.Local).AddTicks(7821), new DateTime(2022, 12, 21, 2, 11, 9, 848, DateTimeKind.Local).AddTicks(4177), 44, 4.78771511176448m },
                    { 131, 66, new DateTime(2022, 6, 3, 19, 53, 5, 580, DateTimeKind.Local).AddTicks(7830), new DateTime(2023, 4, 12, 3, 12, 7, 197, DateTimeKind.Local).AddTicks(5632), 29, 5.65130824595432m },
                    { 132, 96, new DateTime(2022, 11, 11, 17, 52, 27, 511, DateTimeKind.Local).AddTicks(9336), new DateTime(2022, 8, 27, 5, 40, 2, 718, DateTimeKind.Local).AddTicks(3673), 97, 17.5301550936587m },
                    { 133, 62, new DateTime(2022, 7, 20, 14, 0, 25, 497, DateTimeKind.Local).AddTicks(4402), new DateTime(2022, 11, 24, 16, 27, 55, 281, DateTimeKind.Local).AddTicks(3078), 95, 16.6500888478653m },
                    { 134, 101, new DateTime(2023, 1, 31, 15, 24, 8, 886, DateTimeKind.Local).AddTicks(2097), new DateTime(2023, 1, 20, 11, 1, 4, 43, DateTimeKind.Local).AddTicks(5163), 44, 26.7006508571376m },
                    { 135, 103, new DateTime(2022, 5, 7, 18, 11, 8, 662, DateTimeKind.Local).AddTicks(26), new DateTime(2022, 4, 26, 7, 30, 35, 967, DateTimeKind.Local).AddTicks(4889), 23, 27.1167452933771m },
                    { 136, 91, new DateTime(2023, 1, 4, 12, 39, 33, 155, DateTimeKind.Local).AddTicks(9883), new DateTime(2022, 12, 2, 9, 37, 53, 243, DateTimeKind.Local).AddTicks(9124), 76, 20.1029835362871m },
                    { 137, 8, new DateTime(2022, 5, 4, 16, 31, 25, 771, DateTimeKind.Local).AddTicks(3401), new DateTime(2022, 10, 18, 4, 11, 38, 466, DateTimeKind.Local).AddTicks(1525), 74, 5.19755541204343m },
                    { 138, 94, new DateTime(2022, 11, 22, 0, 22, 9, 421, DateTimeKind.Local).AddTicks(5393), new DateTime(2022, 7, 25, 5, 2, 56, 895, DateTimeKind.Local).AddTicks(423), 72, 5.2811751583223m },
                    { 139, 144, new DateTime(2022, 12, 12, 6, 22, 21, 154, DateTimeKind.Local).AddTicks(4584), new DateTime(2022, 12, 25, 4, 29, 4, 174, DateTimeKind.Local).AddTicks(1834), 72, 6.02984960767483m },
                    { 140, 103, new DateTime(2022, 9, 4, 13, 21, 23, 390, DateTimeKind.Local).AddTicks(9814), new DateTime(2022, 6, 28, 5, 49, 2, 358, DateTimeKind.Local).AddTicks(3806), 2, 2.52805159876873m },
                    { 141, 67, new DateTime(2022, 9, 1, 12, 33, 14, 605, DateTimeKind.Local).AddTicks(6445), new DateTime(2022, 7, 31, 3, 43, 39, 467, DateTimeKind.Local).AddTicks(1372), 39, 11.8312549853269m },
                    { 142, 106, new DateTime(2022, 5, 7, 20, 28, 44, 431, DateTimeKind.Local).AddTicks(1573), new DateTime(2023, 3, 10, 12, 14, 33, 49, DateTimeKind.Local).AddTicks(656), 80, 5.47859332970691m },
                    { 143, 3, new DateTime(2022, 8, 22, 4, 16, 51, 110, DateTimeKind.Local).AddTicks(9746), new DateTime(2022, 7, 14, 2, 49, 9, 189, DateTimeKind.Local).AddTicks(1211), 52, 16.9537742848071m },
                    { 144, 23, new DateTime(2022, 9, 21, 14, 26, 17, 844, DateTimeKind.Local).AddTicks(2565), new DateTime(2022, 8, 8, 10, 39, 53, 955, DateTimeKind.Local).AddTicks(8702), 41, 3.0280111993636m },
                    { 145, 75, new DateTime(2023, 1, 3, 23, 52, 46, 238, DateTimeKind.Local).AddTicks(5592), new DateTime(2022, 5, 17, 9, 36, 3, 449, DateTimeKind.Local).AddTicks(307), 16, 14.6057363553457m },
                    { 146, 140, new DateTime(2022, 5, 14, 10, 29, 57, 217, DateTimeKind.Local).AddTicks(2908), new DateTime(2022, 12, 19, 7, 21, 34, 625, DateTimeKind.Local).AddTicks(8860), 69, 25.7354700833799m },
                    { 147, 2, new DateTime(2022, 8, 12, 22, 25, 28, 742, DateTimeKind.Local).AddTicks(6469), new DateTime(2022, 10, 25, 20, 42, 28, 105, DateTimeKind.Local).AddTicks(9612), 2, 20.6174993107501m },
                    { 148, 135, new DateTime(2023, 1, 25, 2, 5, 42, 11, DateTimeKind.Local).AddTicks(9626), new DateTime(2022, 9, 30, 0, 29, 47, 693, DateTimeKind.Local).AddTicks(1016), 33, 23.5676564887715m },
                    { 149, 22, new DateTime(2022, 9, 15, 9, 16, 7, 189, DateTimeKind.Local).AddTicks(9034), new DateTime(2022, 12, 24, 13, 54, 26, 504, DateTimeKind.Local).AddTicks(8858), 7, 13.9628747312244m },
                    { 150, 86, new DateTime(2022, 9, 19, 7, 38, 49, 786, DateTimeKind.Local).AddTicks(1189), new DateTime(2023, 4, 6, 16, 38, 8, 503, DateTimeKind.Local).AddTicks(4776), 98, 3.14975059097664m },
                    { 151, 128, new DateTime(2022, 4, 22, 8, 31, 6, 774, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 8, 5, 1, 6, 44, 57, DateTimeKind.Local).AddTicks(1464), 11, 4.46438222633688m },
                    { 152, 97, new DateTime(2022, 12, 18, 10, 28, 0, 39, DateTimeKind.Local).AddTicks(6607), new DateTime(2022, 9, 22, 8, 3, 34, 837, DateTimeKind.Local).AddTicks(9752), 98, 18.6287478548065m },
                    { 153, 99, new DateTime(2023, 2, 20, 22, 39, 51, 249, DateTimeKind.Local).AddTicks(7859), new DateTime(2022, 10, 10, 16, 59, 54, 885, DateTimeKind.Local).AddTicks(2920), 40, 16.9435521075915m },
                    { 154, 105, new DateTime(2023, 3, 4, 13, 58, 58, 988, DateTimeKind.Local).AddTicks(6288), new DateTime(2022, 11, 1, 2, 53, 24, 922, DateTimeKind.Local).AddTicks(4147), 41, 24.2534130814081m },
                    { 155, 45, new DateTime(2022, 8, 4, 23, 14, 13, 568, DateTimeKind.Local).AddTicks(9193), new DateTime(2022, 7, 4, 11, 21, 20, 46, DateTimeKind.Local).AddTicks(71), 52, 24.2148073159722m },
                    { 156, 71, new DateTime(2022, 7, 7, 8, 54, 36, 955, DateTimeKind.Local).AddTicks(7118), new DateTime(2022, 9, 5, 3, 5, 12, 170, DateTimeKind.Local).AddTicks(4022), 3, 25.791091604926m },
                    { 157, 16, new DateTime(2022, 8, 7, 2, 56, 22, 940, DateTimeKind.Local).AddTicks(408), new DateTime(2023, 1, 12, 0, 32, 35, 742, DateTimeKind.Local).AddTicks(3737), 80, 1.68246201551261m },
                    { 158, 39, new DateTime(2022, 7, 31, 13, 46, 2, 113, DateTimeKind.Local).AddTicks(250), new DateTime(2022, 9, 13, 15, 13, 4, 426, DateTimeKind.Local).AddTicks(1622), 57, 26.3259742613638m },
                    { 159, 39, new DateTime(2022, 6, 24, 23, 34, 43, 247, DateTimeKind.Local).AddTicks(1081), new DateTime(2022, 6, 16, 5, 52, 55, 838, DateTimeKind.Local).AddTicks(947), 93, 1.81204154638749m },
                    { 160, 34, new DateTime(2022, 12, 9, 10, 15, 29, 595, DateTimeKind.Local).AddTicks(6633), new DateTime(2022, 12, 2, 1, 16, 10, 856, DateTimeKind.Local).AddTicks(4186), 95, 14.3355730644944m },
                    { 161, 17, new DateTime(2023, 3, 17, 17, 49, 48, 502, DateTimeKind.Local).AddTicks(984), new DateTime(2022, 8, 15, 1, 57, 14, 85, DateTimeKind.Local).AddTicks(3858), 69, 18.6579562178779m },
                    { 162, 107, new DateTime(2023, 2, 24, 10, 9, 10, 415, DateTimeKind.Local).AddTicks(3046), new DateTime(2022, 12, 3, 14, 27, 11, 497, DateTimeKind.Local).AddTicks(7470), 75, 6.22094274283876m },
                    { 163, 20, new DateTime(2022, 7, 1, 13, 54, 27, 841, DateTimeKind.Local).AddTicks(7315), new DateTime(2022, 8, 11, 10, 1, 57, 53, DateTimeKind.Local).AddTicks(7057), 3, 8.03602869745094m },
                    { 164, 119, new DateTime(2023, 4, 16, 15, 42, 54, 409, DateTimeKind.Local).AddTicks(4213), new DateTime(2022, 8, 27, 4, 34, 49, 67, DateTimeKind.Local).AddTicks(3429), 88, 1.9314377059835m },
                    { 165, 56, new DateTime(2022, 5, 20, 20, 29, 34, 243, DateTimeKind.Local).AddTicks(9995), new DateTime(2022, 6, 4, 11, 38, 46, 802, DateTimeKind.Local).AddTicks(9673), 8, 6.16731898367897m },
                    { 166, 11, new DateTime(2022, 4, 16, 18, 41, 19, 946, DateTimeKind.Local).AddTicks(106), new DateTime(2023, 2, 26, 20, 40, 33, 455, DateTimeKind.Local).AddTicks(1111), 95, 8.537091784298m },
                    { 167, 85, new DateTime(2022, 9, 12, 20, 3, 47, 143, DateTimeKind.Local).AddTicks(9642), new DateTime(2023, 2, 21, 1, 25, 44, 733, DateTimeKind.Local).AddTicks(3401), 95, 18.8075282880504m },
                    { 168, 43, new DateTime(2022, 10, 13, 3, 23, 57, 460, DateTimeKind.Local).AddTicks(3930), new DateTime(2022, 12, 31, 8, 56, 30, 693, DateTimeKind.Local).AddTicks(6358), 89, 14.5003446205216m },
                    { 169, 49, new DateTime(2023, 3, 11, 18, 32, 6, 292, DateTimeKind.Local).AddTicks(6909), new DateTime(2022, 5, 17, 4, 53, 5, 380, DateTimeKind.Local).AddTicks(119), 95, 2.13085539893526m },
                    { 170, 16, new DateTime(2022, 6, 4, 20, 30, 13, 517, DateTimeKind.Local).AddTicks(5814), new DateTime(2023, 3, 17, 13, 51, 7, 877, DateTimeKind.Local).AddTicks(1050), 39, 25.6337922065023m },
                    { 171, 49, new DateTime(2023, 1, 20, 7, 49, 43, 236, DateTimeKind.Local).AddTicks(7987), new DateTime(2022, 11, 8, 1, 19, 17, 815, DateTimeKind.Local).AddTicks(1061), 97, 13.859067568876m },
                    { 172, 5, new DateTime(2022, 7, 28, 11, 11, 39, 115, DateTimeKind.Local).AddTicks(6469), new DateTime(2023, 2, 26, 18, 58, 23, 191, DateTimeKind.Local).AddTicks(8477), 47, 16.7562881421417m },
                    { 173, 26, new DateTime(2022, 7, 12, 16, 10, 54, 880, DateTimeKind.Local).AddTicks(9472), new DateTime(2022, 9, 18, 12, 23, 18, 48, DateTimeKind.Local).AddTicks(7201), 26, 13.3904368344062m },
                    { 174, 73, new DateTime(2022, 11, 13, 12, 19, 48, 373, DateTimeKind.Local).AddTicks(4552), new DateTime(2022, 9, 3, 1, 13, 34, 646, DateTimeKind.Local).AddTicks(6636), 32, 2.74168570910715m },
                    { 175, 143, new DateTime(2022, 7, 26, 1, 41, 3, 809, DateTimeKind.Local).AddTicks(2350), new DateTime(2023, 2, 7, 17, 27, 57, 19, DateTimeKind.Local).AddTicks(8327), 12, 21.2503651398737m },
                    { 176, 149, new DateTime(2022, 10, 23, 15, 56, 49, 612, DateTimeKind.Local).AddTicks(3110), new DateTime(2022, 7, 21, 2, 56, 34, 545, DateTimeKind.Local).AddTicks(6778), 12, 10.5839651091411m },
                    { 177, 76, new DateTime(2022, 7, 22, 20, 46, 1, 479, DateTimeKind.Local).AddTicks(158), new DateTime(2022, 9, 30, 0, 23, 7, 788, DateTimeKind.Local).AddTicks(6525), 62, 11.2182629906052m },
                    { 178, 13, new DateTime(2023, 1, 15, 4, 18, 36, 53, DateTimeKind.Local).AddTicks(6491), new DateTime(2022, 4, 29, 1, 4, 23, 277, DateTimeKind.Local).AddTicks(4607), 70, 5.92795899349038m },
                    { 179, 124, new DateTime(2022, 5, 22, 23, 41, 8, 609, DateTimeKind.Local).AddTicks(8013), new DateTime(2022, 8, 31, 18, 46, 56, 231, DateTimeKind.Local).AddTicks(3104), 51, 1.62449359865893m },
                    { 180, 85, new DateTime(2022, 8, 15, 15, 43, 24, 766, DateTimeKind.Local).AddTicks(8773), new DateTime(2022, 5, 17, 14, 51, 50, 407, DateTimeKind.Local).AddTicks(4783), 84, 6.28518292568313m },
                    { 181, 69, new DateTime(2022, 5, 24, 15, 34, 16, 217, DateTimeKind.Local).AddTicks(877), new DateTime(2022, 7, 29, 21, 50, 12, 896, DateTimeKind.Local).AddTicks(3191), 85, 16.4730260492739m },
                    { 182, 140, new DateTime(2022, 4, 27, 1, 43, 6, 586, DateTimeKind.Local).AddTicks(8975), new DateTime(2022, 10, 30, 8, 58, 57, 972, DateTimeKind.Local).AddTicks(6436), 53, 24.8962641535858m },
                    { 183, 73, new DateTime(2022, 6, 26, 14, 52, 46, 230, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 11, 7, 21, 26, 43, 157, DateTimeKind.Local).AddTicks(3573), 91, 17.3018519544789m },
                    { 184, 102, new DateTime(2022, 4, 29, 6, 29, 22, 703, DateTimeKind.Local).AddTicks(8024), new DateTime(2022, 4, 25, 21, 33, 57, 701, DateTimeKind.Local).AddTicks(8536), 39, 12.2558756830221m },
                    { 185, 75, new DateTime(2022, 6, 22, 4, 0, 47, 817, DateTimeKind.Local).AddTicks(4129), new DateTime(2022, 4, 29, 18, 18, 56, 730, DateTimeKind.Local).AddTicks(7960), 85, 4.30654503576284m },
                    { 186, 27, new DateTime(2022, 11, 5, 22, 53, 14, 553, DateTimeKind.Local).AddTicks(8279), new DateTime(2023, 2, 13, 17, 21, 24, 677, DateTimeKind.Local).AddTicks(5021), 30, 5.08721977884193m },
                    { 187, 120, new DateTime(2023, 3, 22, 9, 7, 51, 771, DateTimeKind.Local).AddTicks(7666), new DateTime(2022, 10, 17, 18, 54, 42, 930, DateTimeKind.Local).AddTicks(5044), 93, 21.080833132228m },
                    { 188, 120, new DateTime(2022, 7, 3, 4, 48, 8, 395, DateTimeKind.Local).AddTicks(5735), new DateTime(2022, 9, 28, 14, 58, 2, 209, DateTimeKind.Local).AddTicks(132), 59, 5.80108134026445m },
                    { 189, 122, new DateTime(2022, 12, 12, 2, 53, 4, 121, DateTimeKind.Local).AddTicks(2526), new DateTime(2022, 8, 19, 0, 36, 6, 411, DateTimeKind.Local).AddTicks(8493), 28, 6.2432553242341m },
                    { 190, 115, new DateTime(2023, 1, 27, 16, 41, 41, 85, DateTimeKind.Local).AddTicks(4862), new DateTime(2022, 8, 9, 0, 37, 35, 776, DateTimeKind.Local).AddTicks(6850), 10, 19.1141224807791m },
                    { 191, 41, new DateTime(2022, 8, 25, 20, 25, 8, 259, DateTimeKind.Local).AddTicks(8), new DateTime(2023, 1, 29, 21, 6, 22, 182, DateTimeKind.Local).AddTicks(6586), 53, 11.7708391733519m },
                    { 192, 122, new DateTime(2022, 9, 15, 1, 28, 19, 25, DateTimeKind.Local).AddTicks(7623), new DateTime(2022, 6, 18, 18, 32, 54, 969, DateTimeKind.Local).AddTicks(8723), 28, 15.5279253945229m },
                    { 193, 139, new DateTime(2022, 7, 6, 3, 54, 49, 210, DateTimeKind.Local).AddTicks(7187), new DateTime(2022, 12, 16, 9, 52, 2, 750, DateTimeKind.Local).AddTicks(6381), 86, 9.21927962044919m },
                    { 194, 106, new DateTime(2022, 9, 2, 13, 34, 1, 636, DateTimeKind.Local).AddTicks(5603), new DateTime(2022, 8, 15, 22, 6, 6, 762, DateTimeKind.Local).AddTicks(2559), 75, 8.81542600264942m },
                    { 195, 109, new DateTime(2022, 7, 1, 12, 49, 9, 579, DateTimeKind.Local).AddTicks(5872), new DateTime(2022, 7, 25, 13, 28, 7, 47, DateTimeKind.Local).AddTicks(3768), 2, 17.5262868353374m },
                    { 196, 72, new DateTime(2022, 5, 31, 15, 43, 38, 599, DateTimeKind.Local).AddTicks(1317), new DateTime(2023, 3, 9, 4, 44, 52, 578, DateTimeKind.Local).AddTicks(1799), 87, 14.5015353136605m },
                    { 197, 39, new DateTime(2023, 2, 17, 21, 41, 7, 686, DateTimeKind.Local).AddTicks(6242), new DateTime(2022, 9, 20, 7, 6, 36, 40, DateTimeKind.Local).AddTicks(6116), 70, 16.5473278232889m },
                    { 198, 46, new DateTime(2022, 5, 30, 10, 5, 3, 46, DateTimeKind.Local).AddTicks(3524), new DateTime(2023, 3, 18, 15, 5, 15, 495, DateTimeKind.Local).AddTicks(2711), 34, 18.7723305853968m },
                    { 199, 20, new DateTime(2022, 11, 8, 20, 44, 20, 978, DateTimeKind.Local).AddTicks(9720), new DateTime(2023, 4, 8, 7, 50, 30, 455, DateTimeKind.Local).AddTicks(2139), 29, 7.43693911803264m },
                    { 200, 35, new DateTime(2022, 5, 26, 3, 4, 36, 688, DateTimeKind.Local).AddTicks(2217), new DateTime(2023, 3, 7, 20, 28, 55, 611, DateTimeKind.Local).AddTicks(1098), 54, 19.8611484213193m },
                    { 201, 37, new DateTime(2022, 8, 27, 0, 25, 54, 76, DateTimeKind.Local).AddTicks(7839), new DateTime(2022, 8, 19, 9, 27, 53, 656, DateTimeKind.Local).AddTicks(2353), 22, 23.2070735194331m },
                    { 202, 69, new DateTime(2022, 6, 27, 7, 17, 2, 704, DateTimeKind.Local).AddTicks(8919), new DateTime(2022, 9, 18, 20, 40, 52, 625, DateTimeKind.Local).AddTicks(3287), 2, 26.3014501453167m },
                    { 203, 102, new DateTime(2022, 8, 24, 4, 4, 11, 822, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 12, 3, 7, 35, 48, 306, DateTimeKind.Local).AddTicks(5942), 20, 23.2053979094062m },
                    { 204, 74, new DateTime(2022, 6, 20, 0, 25, 2, 946, DateTimeKind.Local).AddTicks(1462), new DateTime(2023, 3, 28, 9, 5, 57, 286, DateTimeKind.Local).AddTicks(1108), 98, 23.9387366268226m },
                    { 205, 81, new DateTime(2022, 10, 9, 14, 16, 13, 741, DateTimeKind.Local).AddTicks(5712), new DateTime(2023, 4, 9, 8, 41, 49, 158, DateTimeKind.Local).AddTicks(2189), 40, 4.42385459075082m },
                    { 206, 3, new DateTime(2022, 10, 19, 0, 3, 57, 402, DateTimeKind.Local).AddTicks(7411), new DateTime(2022, 9, 27, 6, 55, 17, 752, DateTimeKind.Local).AddTicks(4501), 66, 5.69622837281346m },
                    { 207, 105, new DateTime(2023, 3, 29, 3, 20, 49, 954, DateTimeKind.Local).AddTicks(3671), new DateTime(2022, 9, 4, 22, 37, 32, 654, DateTimeKind.Local).AddTicks(774), 5, 11.8512217678397m },
                    { 208, 90, new DateTime(2023, 2, 26, 13, 22, 58, 503, DateTimeKind.Local).AddTicks(6243), new DateTime(2022, 7, 5, 13, 4, 47, 408, DateTimeKind.Local).AddTicks(4359), 27, 16.0529971671716m },
                    { 209, 103, new DateTime(2022, 10, 10, 5, 30, 9, 279, DateTimeKind.Local).AddTicks(135), new DateTime(2022, 9, 2, 3, 57, 21, 219, DateTimeKind.Local).AddTicks(3314), 84, 9.30264790758207m },
                    { 210, 33, new DateTime(2023, 3, 15, 20, 47, 4, 456, DateTimeKind.Local).AddTicks(1130), new DateTime(2023, 1, 20, 6, 13, 47, 986, DateTimeKind.Local).AddTicks(8401), 84, 16.1118205583245m },
                    { 211, 88, new DateTime(2022, 11, 28, 15, 31, 39, 84, DateTimeKind.Local).AddTicks(7690), new DateTime(2022, 8, 19, 8, 1, 45, 398, DateTimeKind.Local).AddTicks(8243), 46, 15.4000593314274m },
                    { 212, 77, new DateTime(2023, 3, 8, 15, 28, 3, 168, DateTimeKind.Local).AddTicks(2187), new DateTime(2022, 7, 1, 21, 37, 23, 948, DateTimeKind.Local).AddTicks(8528), 67, 3.41595135835872m },
                    { 213, 58, new DateTime(2022, 8, 30, 17, 27, 20, 357, DateTimeKind.Local).AddTicks(3244), new DateTime(2022, 4, 17, 11, 22, 37, 768, DateTimeKind.Local).AddTicks(5033), 31, 11.7405710130613m },
                    { 214, 131, new DateTime(2022, 11, 1, 16, 58, 25, 210, DateTimeKind.Local).AddTicks(7919), new DateTime(2023, 2, 4, 7, 55, 59, 973, DateTimeKind.Local).AddTicks(9064), 72, 1.06061088447504m },
                    { 215, 13, new DateTime(2022, 9, 4, 23, 6, 0, 603, DateTimeKind.Local).AddTicks(9925), new DateTime(2022, 12, 21, 13, 27, 59, 597, DateTimeKind.Local).AddTicks(3187), 75, 8.90529115088854m },
                    { 216, 29, new DateTime(2022, 12, 26, 1, 41, 0, 377, DateTimeKind.Local).AddTicks(5753), new DateTime(2022, 9, 12, 4, 11, 10, 965, DateTimeKind.Local).AddTicks(1976), 41, 15.5450796980658m },
                    { 217, 130, new DateTime(2022, 10, 3, 18, 7, 48, 264, DateTimeKind.Local).AddTicks(5847), new DateTime(2023, 1, 1, 1, 36, 43, 549, DateTimeKind.Local).AddTicks(2777), 55, 16.1701014660234m },
                    { 218, 31, new DateTime(2023, 1, 28, 8, 23, 42, 515, DateTimeKind.Local).AddTicks(8546), new DateTime(2023, 2, 11, 2, 27, 10, 345, DateTimeKind.Local).AddTicks(6975), 98, 1.07601736991969m },
                    { 219, 43, new DateTime(2022, 9, 21, 21, 44, 22, 650, DateTimeKind.Local).AddTicks(7197), new DateTime(2023, 3, 21, 20, 50, 0, 529, DateTimeKind.Local).AddTicks(7280), 45, 22.1091178317625m },
                    { 220, 126, new DateTime(2022, 5, 26, 10, 46, 28, 92, DateTimeKind.Local).AddTicks(7770), new DateTime(2022, 10, 4, 2, 12, 23, 503, DateTimeKind.Local).AddTicks(1957), 64, 29.3239769858548m },
                    { 221, 39, new DateTime(2022, 12, 26, 1, 19, 38, 368, DateTimeKind.Local).AddTicks(8445), new DateTime(2022, 5, 28, 1, 41, 13, 745, DateTimeKind.Local).AddTicks(6052), 60, 27.2623213371797m },
                    { 222, 21, new DateTime(2023, 3, 23, 7, 14, 23, 588, DateTimeKind.Local).AddTicks(1854), new DateTime(2022, 4, 30, 13, 24, 57, 702, DateTimeKind.Local).AddTicks(7208), 97, 5.55344561985948m },
                    { 223, 49, new DateTime(2022, 6, 2, 19, 6, 36, 629, DateTimeKind.Local).AddTicks(5244), new DateTime(2022, 7, 16, 1, 31, 23, 636, DateTimeKind.Local).AddTicks(6379), 23, 22.7254397022205m },
                    { 224, 116, new DateTime(2022, 6, 16, 20, 18, 47, 105, DateTimeKind.Local).AddTicks(6167), new DateTime(2023, 1, 10, 20, 37, 41, 647, DateTimeKind.Local).AddTicks(4017), 61, 25.7797397817446m },
                    { 225, 119, new DateTime(2023, 3, 4, 22, 18, 1, 352, DateTimeKind.Local).AddTicks(7951), new DateTime(2022, 6, 29, 23, 29, 10, 435, DateTimeKind.Local).AddTicks(8979), 28, 15.8790811586263m },
                    { 226, 123, new DateTime(2022, 6, 22, 5, 34, 13, 999, DateTimeKind.Local).AddTicks(987), new DateTime(2023, 3, 9, 19, 9, 57, 749, DateTimeKind.Local).AddTicks(1382), 98, 19.7093237097593m },
                    { 227, 68, new DateTime(2022, 9, 27, 22, 9, 41, 353, DateTimeKind.Local).AddTicks(1358), new DateTime(2022, 11, 9, 16, 7, 43, 256, DateTimeKind.Local).AddTicks(2410), 17, 13.9175757273987m },
                    { 228, 58, new DateTime(2022, 9, 23, 10, 46, 10, 882, DateTimeKind.Local).AddTicks(8634), new DateTime(2022, 5, 17, 11, 8, 17, 776, DateTimeKind.Local).AddTicks(6128), 31, 27.4087514672807m },
                    { 229, 12, new DateTime(2022, 7, 25, 21, 46, 43, 859, DateTimeKind.Local).AddTicks(4227), new DateTime(2023, 2, 22, 22, 31, 20, 66, DateTimeKind.Local).AddTicks(4332), 20, 4.53505260778291m },
                    { 230, 63, new DateTime(2022, 8, 31, 21, 35, 14, 950, DateTimeKind.Local).AddTicks(5069), new DateTime(2022, 11, 20, 2, 3, 8, 501, DateTimeKind.Local).AddTicks(6332), 89, 25.6488871559198m },
                    { 231, 86, new DateTime(2023, 3, 25, 7, 55, 9, 600, DateTimeKind.Local).AddTicks(9224), new DateTime(2022, 8, 21, 12, 48, 45, 835, DateTimeKind.Local).AddTicks(3735), 80, 2.39070657643668m },
                    { 232, 70, new DateTime(2022, 9, 20, 0, 57, 40, 816, DateTimeKind.Local).AddTicks(1182), new DateTime(2022, 8, 12, 0, 13, 36, 747, DateTimeKind.Local).AddTicks(2965), 34, 26.5370254600945m },
                    { 233, 46, new DateTime(2022, 7, 1, 3, 11, 0, 655, DateTimeKind.Local).AddTicks(3309), new DateTime(2022, 6, 12, 4, 9, 6, 162, DateTimeKind.Local).AddTicks(1967), 45, 6.9620168793196m },
                    { 234, 15, new DateTime(2022, 9, 25, 23, 31, 11, 837, DateTimeKind.Local).AddTicks(3437), new DateTime(2022, 7, 7, 20, 9, 41, 309, DateTimeKind.Local).AddTicks(6773), 72, 26.7745499568294m },
                    { 235, 31, new DateTime(2022, 7, 28, 4, 6, 47, 377, DateTimeKind.Local).AddTicks(9186), new DateTime(2022, 10, 9, 9, 55, 31, 193, DateTimeKind.Local).AddTicks(7871), 45, 23.7794201007912m },
                    { 236, 96, new DateTime(2022, 8, 19, 22, 26, 47, 632, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 6, 12, 15, 52, 54, 458, DateTimeKind.Local).AddTicks(161), 59, 20.589408155023m },
                    { 237, 144, new DateTime(2022, 9, 25, 0, 27, 30, 214, DateTimeKind.Local).AddTicks(3981), new DateTime(2022, 10, 6, 22, 55, 37, 619, DateTimeKind.Local).AddTicks(5127), 76, 27.4508563281471m },
                    { 238, 104, new DateTime(2022, 11, 29, 18, 58, 4, 774, DateTimeKind.Local).AddTicks(7472), new DateTime(2022, 6, 7, 11, 58, 58, 433, DateTimeKind.Local).AddTicks(1586), 5, 14.3068862173637m },
                    { 239, 107, new DateTime(2022, 4, 16, 21, 24, 24, 418, DateTimeKind.Local).AddTicks(9037), new DateTime(2022, 11, 19, 16, 18, 6, 294, DateTimeKind.Local).AddTicks(7211), 17, 14.6917685461192m },
                    { 240, 25, new DateTime(2022, 7, 8, 23, 29, 7, 461, DateTimeKind.Local).AddTicks(1607), new DateTime(2022, 8, 2, 9, 1, 52, 679, DateTimeKind.Local).AddTicks(2040), 76, 1.91806041195875m },
                    { 241, 131, new DateTime(2022, 4, 22, 10, 4, 19, 416, DateTimeKind.Local).AddTicks(4381), new DateTime(2023, 4, 16, 8, 11, 14, 257, DateTimeKind.Local).AddTicks(3824), 88, 29.3036470268608m },
                    { 242, 108, new DateTime(2023, 2, 2, 23, 4, 21, 934, DateTimeKind.Local).AddTicks(8006), new DateTime(2023, 3, 11, 8, 6, 20, 956, DateTimeKind.Local).AddTicks(978), 60, 25.7474174648245m },
                    { 243, 143, new DateTime(2022, 8, 3, 4, 2, 22, 869, DateTimeKind.Local).AddTicks(3259), new DateTime(2022, 8, 10, 13, 49, 41, 443, DateTimeKind.Local).AddTicks(6866), 53, 13.6359827180475m },
                    { 244, 16, new DateTime(2022, 6, 22, 3, 52, 43, 928, DateTimeKind.Local).AddTicks(9548), new DateTime(2023, 2, 16, 5, 17, 50, 875, DateTimeKind.Local).AddTicks(7895), 70, 19.1638025600864m },
                    { 245, 33, new DateTime(2022, 5, 25, 7, 41, 2, 222, DateTimeKind.Local).AddTicks(4355), new DateTime(2022, 11, 30, 6, 2, 16, 625, DateTimeKind.Local).AddTicks(8069), 92, 6.92657574472644m },
                    { 246, 7, new DateTime(2022, 8, 27, 20, 21, 30, 557, DateTimeKind.Local).AddTicks(2247), new DateTime(2022, 7, 13, 2, 35, 41, 991, DateTimeKind.Local).AddTicks(3620), 91, 11.4919603684947m },
                    { 247, 141, new DateTime(2022, 8, 10, 20, 4, 7, 802, DateTimeKind.Local).AddTicks(4309), new DateTime(2023, 4, 15, 10, 8, 48, 181, DateTimeKind.Local).AddTicks(3941), 93, 23.2717963994331m },
                    { 248, 23, new DateTime(2023, 4, 9, 19, 53, 46, 100, DateTimeKind.Local).AddTicks(9560), new DateTime(2023, 1, 5, 20, 3, 14, 224, DateTimeKind.Local).AddTicks(1274), 10, 6.8552203937586m },
                    { 249, 3, new DateTime(2022, 8, 26, 1, 33, 16, 807, DateTimeKind.Local).AddTicks(5743), new DateTime(2022, 7, 29, 18, 34, 5, 157, DateTimeKind.Local).AddTicks(5857), 44, 20.4614945408508m },
                    { 250, 99, new DateTime(2023, 1, 14, 4, 35, 45, 241, DateTimeKind.Local).AddTicks(5817), new DateTime(2023, 4, 1, 16, 50, 24, 83, DateTimeKind.Local).AddTicks(237), 65, 6.96607673861859m },
                    { 251, 69, new DateTime(2023, 4, 16, 7, 13, 27, 165, DateTimeKind.Local).AddTicks(3613), new DateTime(2023, 3, 13, 20, 34, 48, 831, DateTimeKind.Local).AddTicks(802), 76, 26.0311707532957m },
                    { 252, 105, new DateTime(2023, 2, 17, 21, 46, 13, 988, DateTimeKind.Local).AddTicks(4077), new DateTime(2023, 3, 26, 14, 44, 59, 793, DateTimeKind.Local).AddTicks(8010), 99, 25.0559281272556m },
                    { 253, 126, new DateTime(2022, 10, 19, 15, 42, 18, 174, DateTimeKind.Local).AddTicks(9123), new DateTime(2022, 10, 2, 2, 33, 25, 256, DateTimeKind.Local).AddTicks(5715), 90, 24.7357792335381m },
                    { 254, 60, new DateTime(2022, 6, 28, 8, 17, 18, 823, DateTimeKind.Local).AddTicks(6829), new DateTime(2022, 6, 17, 0, 39, 56, 380, DateTimeKind.Local).AddTicks(3652), 28, 22.9385698300474m },
                    { 255, 34, new DateTime(2023, 3, 20, 7, 42, 52, 838, DateTimeKind.Local).AddTicks(1080), new DateTime(2022, 8, 20, 14, 24, 52, 185, DateTimeKind.Local).AddTicks(258), 24, 20.8657999765921m },
                    { 256, 30, new DateTime(2023, 4, 14, 23, 53, 42, 527, DateTimeKind.Local).AddTicks(4175), new DateTime(2022, 12, 1, 2, 48, 50, 102, DateTimeKind.Local).AddTicks(2939), 4, 3.4231964947973m },
                    { 257, 64, new DateTime(2023, 1, 14, 12, 49, 23, 94, DateTimeKind.Local).AddTicks(4349), new DateTime(2022, 8, 9, 13, 27, 34, 936, DateTimeKind.Local).AddTicks(8030), 94, 21.0957084846m },
                    { 258, 16, new DateTime(2022, 10, 11, 5, 55, 44, 769, DateTimeKind.Local).AddTicks(5757), new DateTime(2023, 1, 12, 4, 39, 59, 935, DateTimeKind.Local).AddTicks(2030), 47, 18.5793583969654m },
                    { 259, 128, new DateTime(2022, 9, 2, 2, 48, 34, 516, DateTimeKind.Local).AddTicks(9870), new DateTime(2022, 11, 5, 2, 43, 9, 787, DateTimeKind.Local).AddTicks(9902), 97, 1.90431271107928m },
                    { 260, 82, new DateTime(2022, 7, 7, 14, 30, 52, 630, DateTimeKind.Local).AddTicks(7943), new DateTime(2023, 1, 22, 13, 39, 43, 278, DateTimeKind.Local).AddTicks(9844), 5, 9.15681431396985m },
                    { 261, 94, new DateTime(2023, 3, 7, 23, 26, 54, 68, DateTimeKind.Local).AddTicks(4755), new DateTime(2023, 1, 12, 10, 25, 50, 76, DateTimeKind.Local).AddTicks(3382), 78, 5.25832842536359m },
                    { 262, 73, new DateTime(2023, 4, 14, 16, 39, 3, 92, DateTimeKind.Local).AddTicks(1247), new DateTime(2023, 4, 4, 1, 53, 12, 704, DateTimeKind.Local).AddTicks(6716), 66, 18.1728886498197m },
                    { 263, 122, new DateTime(2022, 10, 23, 22, 39, 45, 918, DateTimeKind.Local).AddTicks(2566), new DateTime(2022, 11, 12, 10, 13, 13, 871, DateTimeKind.Local).AddTicks(9128), 22, 3.39037365767153m },
                    { 264, 90, new DateTime(2023, 4, 14, 11, 57, 41, 974, DateTimeKind.Local).AddTicks(678), new DateTime(2022, 9, 24, 8, 37, 53, 546, DateTimeKind.Local).AddTicks(1896), 59, 8.18946720390854m },
                    { 265, 95, new DateTime(2023, 2, 16, 20, 31, 47, 191, DateTimeKind.Local).AddTicks(5693), new DateTime(2022, 9, 24, 22, 25, 25, 906, DateTimeKind.Local).AddTicks(1469), 46, 29.9552193676716m },
                    { 266, 71, new DateTime(2022, 9, 12, 10, 18, 47, 653, DateTimeKind.Local).AddTicks(9325), new DateTime(2022, 7, 1, 19, 43, 0, 532, DateTimeKind.Local).AddTicks(3284), 45, 5.57460438907382m },
                    { 267, 35, new DateTime(2022, 9, 18, 20, 47, 10, 164, DateTimeKind.Local).AddTicks(5183), new DateTime(2022, 11, 15, 6, 53, 18, 183, DateTimeKind.Local).AddTicks(3670), 33, 5.36780047283671m },
                    { 268, 54, new DateTime(2022, 7, 3, 11, 31, 35, 158, DateTimeKind.Local).AddTicks(3909), new DateTime(2022, 8, 6, 14, 27, 22, 703, DateTimeKind.Local).AddTicks(9618), 78, 12.3412988984125m },
                    { 269, 127, new DateTime(2022, 5, 31, 2, 39, 18, 760, DateTimeKind.Local).AddTicks(5299), new DateTime(2022, 11, 17, 17, 53, 19, 291, DateTimeKind.Local).AddTicks(1003), 45, 27.2261431878668m },
                    { 270, 112, new DateTime(2022, 7, 29, 16, 58, 17, 543, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 11, 3, 1, 2, 25, 985, DateTimeKind.Local).AddTicks(9020), 9, 17.4988718175966m },
                    { 271, 33, new DateTime(2022, 10, 26, 8, 20, 13, 871, DateTimeKind.Local).AddTicks(370), new DateTime(2022, 8, 19, 21, 52, 36, 903, DateTimeKind.Local).AddTicks(4365), 43, 4.42271278648802m },
                    { 272, 14, new DateTime(2022, 8, 12, 3, 47, 34, 207, DateTimeKind.Local).AddTicks(2016), new DateTime(2022, 12, 4, 9, 55, 7, 226, DateTimeKind.Local).AddTicks(2799), 63, 17.212812046822m },
                    { 273, 10, new DateTime(2022, 4, 19, 15, 55, 57, 866, DateTimeKind.Local).AddTicks(3703), new DateTime(2022, 11, 15, 3, 3, 29, 349, DateTimeKind.Local).AddTicks(6912), 85, 18.1407295465667m },
                    { 274, 33, new DateTime(2022, 7, 3, 3, 0, 57, 851, DateTimeKind.Local).AddTicks(6203), new DateTime(2022, 12, 26, 21, 46, 39, 563, DateTimeKind.Local).AddTicks(6769), 39, 3.05092700913456m },
                    { 275, 48, new DateTime(2022, 5, 10, 5, 55, 16, 112, DateTimeKind.Local).AddTicks(599), new DateTime(2022, 11, 11, 17, 7, 59, 509, DateTimeKind.Local).AddTicks(5208), 4, 23.0263329489679m },
                    { 276, 89, new DateTime(2023, 1, 11, 16, 55, 11, 195, DateTimeKind.Local).AddTicks(5637), new DateTime(2022, 6, 7, 17, 52, 57, 220, DateTimeKind.Local).AddTicks(8616), 91, 26.6745592171243m },
                    { 277, 118, new DateTime(2022, 4, 24, 22, 55, 43, 886, DateTimeKind.Local).AddTicks(8886), new DateTime(2022, 7, 22, 1, 9, 1, 359, DateTimeKind.Local).AddTicks(6676), 3, 28.8075719840134m },
                    { 278, 90, new DateTime(2022, 10, 26, 0, 49, 28, 670, DateTimeKind.Local).AddTicks(5149), new DateTime(2022, 8, 1, 15, 39, 4, 661, DateTimeKind.Local).AddTicks(3318), 72, 14.5949820018568m },
                    { 279, 107, new DateTime(2023, 2, 25, 12, 45, 35, 162, DateTimeKind.Local).AddTicks(3279), new DateTime(2023, 1, 24, 18, 2, 20, 228, DateTimeKind.Local).AddTicks(3937), 92, 21.7063566263288m },
                    { 280, 141, new DateTime(2023, 2, 14, 14, 44, 22, 488, DateTimeKind.Local).AddTicks(4694), new DateTime(2023, 1, 21, 3, 7, 48, 257, DateTimeKind.Local).AddTicks(4095), 1, 7.96395649925765m },
                    { 281, 32, new DateTime(2022, 9, 20, 9, 40, 36, 827, DateTimeKind.Local).AddTicks(2709), new DateTime(2022, 7, 30, 9, 7, 5, 729, DateTimeKind.Local).AddTicks(1061), 56, 6.10369851398324m },
                    { 282, 56, new DateTime(2022, 12, 23, 16, 52, 42, 978, DateTimeKind.Local).AddTicks(6331), new DateTime(2023, 1, 22, 13, 31, 48, 451, DateTimeKind.Local).AddTicks(1737), 37, 21.8823798673269m },
                    { 283, 87, new DateTime(2022, 11, 29, 4, 33, 13, 745, DateTimeKind.Local).AddTicks(6478), new DateTime(2022, 7, 9, 22, 24, 16, 530, DateTimeKind.Local).AddTicks(3260), 6, 14.6306152537237m },
                    { 284, 44, new DateTime(2022, 9, 29, 10, 9, 30, 115, DateTimeKind.Local).AddTicks(2795), new DateTime(2022, 6, 16, 18, 13, 51, 25, DateTimeKind.Local).AddTicks(8610), 82, 23.5455458340211m },
                    { 285, 93, new DateTime(2022, 8, 27, 14, 11, 6, 443, DateTimeKind.Local).AddTicks(8606), new DateTime(2022, 6, 14, 15, 6, 0, 20, DateTimeKind.Local).AddTicks(3653), 96, 13.2162507677058m },
                    { 286, 142, new DateTime(2022, 8, 24, 4, 3, 47, 739, DateTimeKind.Local).AddTicks(5031), new DateTime(2023, 1, 14, 21, 28, 3, 863, DateTimeKind.Local).AddTicks(9353), 12, 9.83683451222734m },
                    { 287, 43, new DateTime(2022, 10, 13, 21, 17, 24, 639, DateTimeKind.Local).AddTicks(7227), new DateTime(2022, 8, 14, 20, 25, 3, 710, DateTimeKind.Local).AddTicks(4698), 59, 21.907747020751m },
                    { 288, 85, new DateTime(2022, 12, 27, 3, 28, 29, 192, DateTimeKind.Local).AddTicks(3561), new DateTime(2023, 3, 12, 19, 13, 39, 985, DateTimeKind.Local).AddTicks(7662), 8, 27.6799175550388m },
                    { 289, 106, new DateTime(2022, 6, 1, 15, 33, 30, 286, DateTimeKind.Local).AddTicks(2585), new DateTime(2022, 8, 5, 22, 20, 38, 123, DateTimeKind.Local).AddTicks(1951), 15, 22.75593464426m },
                    { 290, 83, new DateTime(2022, 10, 18, 9, 55, 0, 860, DateTimeKind.Local).AddTicks(7832), new DateTime(2022, 8, 21, 17, 33, 9, 841, DateTimeKind.Local).AddTicks(6887), 2, 7.0999251288424m },
                    { 291, 113, new DateTime(2022, 8, 11, 15, 47, 4, 461, DateTimeKind.Local).AddTicks(4071), new DateTime(2023, 2, 22, 19, 18, 25, 480, DateTimeKind.Local).AddTicks(7418), 48, 27.3038158006707m },
                    { 292, 106, new DateTime(2022, 5, 24, 13, 46, 43, 131, DateTimeKind.Local).AddTicks(5536), new DateTime(2022, 9, 1, 0, 15, 31, 866, DateTimeKind.Local).AddTicks(4583), 22, 3.35552348265815m },
                    { 293, 46, new DateTime(2023, 1, 9, 5, 41, 35, 843, DateTimeKind.Local).AddTicks(4341), new DateTime(2022, 11, 26, 22, 10, 38, 911, DateTimeKind.Local).AddTicks(9665), 17, 29.6803166952005m },
                    { 294, 50, new DateTime(2023, 3, 2, 12, 1, 16, 55, DateTimeKind.Local).AddTicks(8738), new DateTime(2022, 9, 5, 17, 15, 41, 566, DateTimeKind.Local).AddTicks(5507), 30, 14.5444386892979m },
                    { 295, 48, new DateTime(2023, 3, 1, 21, 26, 8, 238, DateTimeKind.Local).AddTicks(608), new DateTime(2023, 3, 19, 2, 0, 48, 345, DateTimeKind.Local).AddTicks(8635), 57, 10.4431878524498m },
                    { 296, 97, new DateTime(2023, 2, 20, 15, 52, 11, 698, DateTimeKind.Local).AddTicks(900), new DateTime(2022, 10, 18, 18, 43, 4, 465, DateTimeKind.Local).AddTicks(8591), 87, 13.8468890810858m },
                    { 297, 43, new DateTime(2022, 9, 2, 15, 5, 0, 291, DateTimeKind.Local).AddTicks(8827), new DateTime(2023, 3, 7, 17, 24, 38, 865, DateTimeKind.Local).AddTicks(9543), 28, 2.3533914825984m },
                    { 298, 128, new DateTime(2022, 6, 22, 23, 48, 57, 753, DateTimeKind.Local).AddTicks(6072), new DateTime(2022, 11, 17, 22, 52, 24, 109, DateTimeKind.Local).AddTicks(3297), 42, 17.3438686252369m },
                    { 299, 148, new DateTime(2022, 12, 4, 5, 26, 34, 593, DateTimeKind.Local).AddTicks(9349), new DateTime(2022, 12, 5, 0, 2, 21, 956, DateTimeKind.Local).AddTicks(6502), 13, 5.87040988658775m },
                    { 300, 76, new DateTime(2023, 4, 3, 13, 37, 9, 735, DateTimeKind.Local).AddTicks(8413), new DateTime(2022, 5, 29, 3, 35, 30, 541, DateTimeKind.Local).AddTicks(6870), 27, 8.66304178664877m },
                    { 301, 133, new DateTime(2022, 10, 13, 16, 45, 27, 429, DateTimeKind.Local).AddTicks(3061), new DateTime(2022, 7, 7, 21, 27, 37, 807, DateTimeKind.Local).AddTicks(4490), 39, 26.2862070577953m },
                    { 302, 138, new DateTime(2022, 6, 30, 2, 38, 50, 488, DateTimeKind.Local).AddTicks(3537), new DateTime(2022, 6, 21, 2, 0, 38, 961, DateTimeKind.Local).AddTicks(1725), 30, 19.4108472948575m },
                    { 303, 40, new DateTime(2023, 2, 27, 21, 12, 37, 733, DateTimeKind.Local).AddTicks(6767), new DateTime(2022, 8, 5, 0, 32, 5, 499, DateTimeKind.Local).AddTicks(7486), 58, 16.3897578793626m },
                    { 304, 63, new DateTime(2022, 7, 2, 12, 2, 43, 481, DateTimeKind.Local).AddTicks(9272), new DateTime(2022, 6, 17, 7, 31, 31, 349, DateTimeKind.Local).AddTicks(987), 43, 12.9094319568827m },
                    { 305, 28, new DateTime(2022, 6, 1, 23, 34, 30, 285, DateTimeKind.Local).AddTicks(4589), new DateTime(2022, 5, 11, 16, 51, 5, 559, DateTimeKind.Local).AddTicks(411), 60, 13.5686397362228m },
                    { 306, 119, new DateTime(2023, 1, 29, 21, 38, 58, 927, DateTimeKind.Local).AddTicks(5995), new DateTime(2022, 12, 23, 10, 10, 29, 479, DateTimeKind.Local).AddTicks(9092), 9, 5.40792559120453m },
                    { 307, 129, new DateTime(2023, 1, 9, 23, 18, 37, 931, DateTimeKind.Local).AddTicks(7857), new DateTime(2022, 12, 22, 14, 16, 38, 86, DateTimeKind.Local).AddTicks(722), 49, 9.25059223361562m },
                    { 308, 115, new DateTime(2022, 12, 10, 12, 4, 27, 989, DateTimeKind.Local).AddTicks(6340), new DateTime(2023, 3, 24, 10, 42, 23, 321, DateTimeKind.Local).AddTicks(5942), 97, 19.9335044879001m },
                    { 309, 37, new DateTime(2022, 8, 7, 21, 10, 53, 81, DateTimeKind.Local).AddTicks(5872), new DateTime(2022, 4, 24, 2, 48, 18, 777, DateTimeKind.Local).AddTicks(3354), 29, 26.2864901334573m },
                    { 310, 57, new DateTime(2023, 2, 3, 21, 6, 17, 495, DateTimeKind.Local).AddTicks(2739), new DateTime(2022, 12, 8, 8, 45, 50, 105, DateTimeKind.Local).AddTicks(7332), 14, 19.7746494957555m },
                    { 311, 120, new DateTime(2022, 10, 4, 8, 18, 41, 876, DateTimeKind.Local).AddTicks(3836), new DateTime(2023, 2, 20, 22, 38, 29, 409, DateTimeKind.Local).AddTicks(9921), 49, 2.31082138896311m },
                    { 312, 18, new DateTime(2022, 4, 20, 18, 10, 41, 690, DateTimeKind.Local).AddTicks(1373), new DateTime(2022, 8, 2, 9, 17, 33, 656, DateTimeKind.Local).AddTicks(1038), 72, 7.801711230638m },
                    { 313, 81, new DateTime(2022, 7, 10, 12, 10, 53, 28, DateTimeKind.Local).AddTicks(2284), new DateTime(2023, 3, 20, 2, 26, 58, 772, DateTimeKind.Local).AddTicks(2131), 20, 3.49015066476671m },
                    { 314, 16, new DateTime(2022, 6, 28, 21, 55, 33, 502, DateTimeKind.Local).AddTicks(5827), new DateTime(2022, 9, 9, 2, 47, 36, 189, DateTimeKind.Local).AddTicks(5227), 63, 14.4276059687761m },
                    { 315, 30, new DateTime(2023, 1, 2, 8, 25, 6, 233, DateTimeKind.Local).AddTicks(7897), new DateTime(2022, 11, 7, 9, 7, 20, 427, DateTimeKind.Local).AddTicks(3278), 68, 20.2805288764353m },
                    { 316, 73, new DateTime(2022, 6, 7, 13, 29, 5, 896, DateTimeKind.Local).AddTicks(2025), new DateTime(2022, 6, 22, 15, 26, 48, 81, DateTimeKind.Local).AddTicks(1955), 66, 24.4935891027827m },
                    { 317, 11, new DateTime(2022, 11, 16, 7, 36, 57, 81, DateTimeKind.Local).AddTicks(4476), new DateTime(2023, 2, 10, 5, 10, 49, 913, DateTimeKind.Local).AddTicks(6686), 92, 13.865516090566m },
                    { 318, 122, new DateTime(2022, 8, 5, 9, 29, 34, 319, DateTimeKind.Local).AddTicks(4334), new DateTime(2023, 1, 26, 11, 46, 40, 228, DateTimeKind.Local).AddTicks(6320), 73, 14.2291135202571m },
                    { 319, 78, new DateTime(2022, 11, 5, 15, 50, 37, 96, DateTimeKind.Local).AddTicks(7039), new DateTime(2023, 1, 2, 10, 55, 20, 899, DateTimeKind.Local).AddTicks(2471), 99, 9.75042162748613m },
                    { 320, 10, new DateTime(2022, 9, 12, 1, 14, 30, 30, DateTimeKind.Local).AddTicks(6908), new DateTime(2022, 12, 2, 8, 5, 24, 510, DateTimeKind.Local).AddTicks(6549), 26, 10.7664504574605m },
                    { 321, 85, new DateTime(2023, 3, 3, 11, 21, 39, 775, DateTimeKind.Local).AddTicks(216), new DateTime(2022, 11, 11, 8, 56, 15, 10, DateTimeKind.Local).AddTicks(9957), 87, 18.8990160520775m },
                    { 322, 41, new DateTime(2022, 11, 8, 7, 11, 46, 157, DateTimeKind.Local).AddTicks(4892), new DateTime(2023, 2, 10, 14, 28, 49, 432, DateTimeKind.Local).AddTicks(3645), 100, 16.698092535368m },
                    { 323, 14, new DateTime(2022, 12, 25, 9, 5, 39, 740, DateTimeKind.Local).AddTicks(8667), new DateTime(2022, 5, 8, 9, 46, 44, 271, DateTimeKind.Local).AddTicks(1334), 45, 15.7481229173739m },
                    { 324, 114, new DateTime(2022, 8, 3, 8, 26, 52, 566, DateTimeKind.Local).AddTicks(3241), new DateTime(2023, 4, 14, 6, 58, 1, 250, DateTimeKind.Local).AddTicks(9222), 9, 20.844250134985m },
                    { 325, 108, new DateTime(2023, 1, 20, 18, 5, 23, 489, DateTimeKind.Local).AddTicks(1119), new DateTime(2022, 8, 21, 16, 45, 30, 228, DateTimeKind.Local).AddTicks(37), 95, 10.1986554045019m },
                    { 326, 122, new DateTime(2022, 4, 24, 4, 14, 29, 31, DateTimeKind.Local).AddTicks(9635), new DateTime(2022, 11, 27, 12, 0, 18, 797, DateTimeKind.Local).AddTicks(3342), 71, 15.5075967643071m },
                    { 327, 83, new DateTime(2023, 3, 16, 8, 9, 31, 81, DateTimeKind.Local).AddTicks(1299), new DateTime(2023, 3, 8, 7, 1, 42, 175, DateTimeKind.Local).AddTicks(2562), 84, 1.08433973964869m },
                    { 328, 78, new DateTime(2022, 12, 10, 20, 24, 28, 609, DateTimeKind.Local).AddTicks(4962), new DateTime(2022, 9, 5, 13, 1, 54, 709, DateTimeKind.Local).AddTicks(7400), 67, 16.0293765602344m },
                    { 329, 138, new DateTime(2022, 9, 20, 2, 9, 5, 192, DateTimeKind.Local).AddTicks(5484), new DateTime(2023, 3, 14, 4, 37, 38, 454, DateTimeKind.Local).AddTicks(6073), 61, 29.8002890145515m },
                    { 330, 65, new DateTime(2022, 6, 19, 21, 19, 1, 819, DateTimeKind.Local).AddTicks(3867), new DateTime(2022, 8, 25, 13, 15, 21, 894, DateTimeKind.Local).AddTicks(3410), 36, 8.93781104553026m },
                    { 331, 36, new DateTime(2022, 7, 21, 14, 56, 0, 529, DateTimeKind.Local).AddTicks(623), new DateTime(2022, 8, 27, 4, 59, 32, 922, DateTimeKind.Local).AddTicks(9586), 64, 3.83161316049907m },
                    { 332, 114, new DateTime(2023, 2, 28, 7, 27, 27, 380, DateTimeKind.Local).AddTicks(9639), new DateTime(2023, 1, 22, 0, 38, 15, 814, DateTimeKind.Local).AddTicks(212), 51, 8.3623409715539m },
                    { 333, 66, new DateTime(2022, 12, 11, 17, 0, 20, 273, DateTimeKind.Local).AddTicks(9213), new DateTime(2022, 10, 2, 7, 50, 58, 975, DateTimeKind.Local).AddTicks(7237), 82, 21.5044393409349m },
                    { 334, 142, new DateTime(2022, 8, 15, 22, 5, 44, 147, DateTimeKind.Local).AddTicks(4243), new DateTime(2023, 3, 26, 12, 18, 8, 649, DateTimeKind.Local).AddTicks(1971), 83, 2.63779035609757m },
                    { 335, 111, new DateTime(2022, 9, 13, 2, 11, 0, 894, DateTimeKind.Local).AddTicks(7655), new DateTime(2022, 11, 5, 12, 3, 18, 653, DateTimeKind.Local).AddTicks(1001), 59, 23.3516176526625m },
                    { 336, 50, new DateTime(2022, 10, 9, 15, 13, 37, 161, DateTimeKind.Local).AddTicks(4394), new DateTime(2022, 5, 12, 21, 34, 21, 972, DateTimeKind.Local).AddTicks(1598), 19, 24.6733108472173m },
                    { 337, 105, new DateTime(2022, 12, 13, 10, 6, 31, 161, DateTimeKind.Local).AddTicks(5970), new DateTime(2023, 2, 11, 22, 19, 16, 315, DateTimeKind.Local).AddTicks(4238), 75, 14.8310592649374m },
                    { 338, 92, new DateTime(2022, 8, 23, 11, 37, 43, 432, DateTimeKind.Local).AddTicks(8244), new DateTime(2022, 10, 12, 7, 41, 54, 931, DateTimeKind.Local).AddTicks(48), 19, 21.1664620888911m },
                    { 339, 90, new DateTime(2023, 4, 8, 19, 7, 16, 782, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 10, 28, 11, 11, 17, 905, DateTimeKind.Local).AddTicks(342), 90, 4.95164072482685m },
                    { 340, 52, new DateTime(2022, 5, 29, 17, 31, 48, 642, DateTimeKind.Local).AddTicks(7679), new DateTime(2023, 3, 18, 1, 22, 9, 258, DateTimeKind.Local).AddTicks(8121), 8, 13.5849432274588m },
                    { 341, 129, new DateTime(2022, 12, 31, 6, 20, 9, 371, DateTimeKind.Local).AddTicks(120), new DateTime(2023, 1, 25, 8, 42, 21, 616, DateTimeKind.Local).AddTicks(265), 42, 24.6500064951622m },
                    { 342, 122, new DateTime(2022, 7, 3, 13, 47, 3, 490, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 8, 19, 9, 30, 58, 497, DateTimeKind.Local).AddTicks(7336), 17, 1.80332126574678m },
                    { 343, 78, new DateTime(2022, 10, 12, 0, 31, 18, 20, DateTimeKind.Local).AddTicks(437), new DateTime(2022, 9, 1, 14, 18, 42, 31, DateTimeKind.Local).AddTicks(3025), 25, 12.786839341253m },
                    { 344, 57, new DateTime(2022, 11, 1, 17, 27, 38, 567, DateTimeKind.Local).AddTicks(2036), new DateTime(2022, 12, 27, 15, 47, 54, 654, DateTimeKind.Local).AddTicks(940), 84, 22.9888633775354m },
                    { 345, 122, new DateTime(2022, 5, 24, 12, 40, 59, 449, DateTimeKind.Local).AddTicks(5425), new DateTime(2022, 6, 26, 16, 44, 30, 314, DateTimeKind.Local).AddTicks(3350), 72, 23.0895661898273m },
                    { 346, 144, new DateTime(2023, 3, 30, 20, 28, 38, 747, DateTimeKind.Local).AddTicks(7742), new DateTime(2023, 1, 31, 15, 12, 3, 883, DateTimeKind.Local).AddTicks(4241), 42, 4.25877128662748m },
                    { 347, 126, new DateTime(2022, 8, 23, 17, 58, 21, 809, DateTimeKind.Local).AddTicks(715), new DateTime(2023, 1, 22, 12, 44, 34, 815, DateTimeKind.Local).AddTicks(4666), 80, 21.4489558334332m },
                    { 348, 31, new DateTime(2022, 4, 21, 19, 54, 32, 210, DateTimeKind.Local).AddTicks(9385), new DateTime(2023, 1, 19, 23, 11, 9, 516, DateTimeKind.Local).AddTicks(4582), 92, 21.3426334924648m },
                    { 349, 77, new DateTime(2023, 4, 7, 0, 46, 48, 43, DateTimeKind.Local).AddTicks(6139), new DateTime(2022, 12, 16, 6, 36, 13, 250, DateTimeKind.Local).AddTicks(9295), 86, 18.2736202155216m },
                    { 350, 45, new DateTime(2022, 7, 13, 9, 14, 44, 451, DateTimeKind.Local).AddTicks(8904), new DateTime(2022, 5, 11, 22, 4, 49, 30, DateTimeKind.Local).AddTicks(5459), 4, 3.47852748207758m },
                    { 351, 103, new DateTime(2022, 5, 13, 1, 45, 33, 548, DateTimeKind.Local).AddTicks(8570), new DateTime(2022, 8, 14, 8, 38, 25, 713, DateTimeKind.Local).AddTicks(7993), 91, 7.70110861983633m },
                    { 352, 4, new DateTime(2022, 8, 14, 11, 0, 19, 749, DateTimeKind.Local).AddTicks(6998), new DateTime(2022, 10, 11, 22, 56, 39, 191, DateTimeKind.Local).AddTicks(2705), 10, 4.83352666304075m },
                    { 353, 109, new DateTime(2022, 7, 17, 14, 57, 2, 226, DateTimeKind.Local).AddTicks(5250), new DateTime(2023, 1, 10, 17, 21, 43, 72, DateTimeKind.Local).AddTicks(2625), 14, 15.8837343338417m },
                    { 354, 12, new DateTime(2022, 8, 16, 17, 26, 5, 181, DateTimeKind.Local).AddTicks(2422), new DateTime(2022, 10, 29, 20, 28, 4, 734, DateTimeKind.Local).AddTicks(8539), 45, 4.13209877997682m },
                    { 355, 13, new DateTime(2022, 11, 9, 17, 7, 44, 12, DateTimeKind.Local).AddTicks(2009), new DateTime(2022, 12, 15, 21, 20, 57, 368, DateTimeKind.Local).AddTicks(2618), 81, 25.467026136463m },
                    { 356, 84, new DateTime(2022, 7, 21, 1, 49, 30, 286, DateTimeKind.Local).AddTicks(7566), new DateTime(2023, 3, 31, 3, 59, 1, 715, DateTimeKind.Local).AddTicks(969), 17, 2.94270546177337m },
                    { 357, 42, new DateTime(2022, 7, 10, 14, 9, 24, 505, DateTimeKind.Local).AddTicks(5277), new DateTime(2022, 12, 17, 14, 12, 28, 736, DateTimeKind.Local).AddTicks(2729), 53, 28.8588087239603m },
                    { 358, 19, new DateTime(2023, 1, 10, 3, 38, 14, 852, DateTimeKind.Local).AddTicks(167), new DateTime(2022, 11, 13, 8, 2, 45, 324, DateTimeKind.Local).AddTicks(190), 36, 15.5812095165709m },
                    { 359, 145, new DateTime(2022, 5, 24, 16, 8, 3, 582, DateTimeKind.Local).AddTicks(7513), new DateTime(2022, 7, 23, 1, 40, 16, 604, DateTimeKind.Local).AddTicks(6304), 5, 24.6177499816259m },
                    { 360, 57, new DateTime(2023, 3, 8, 17, 34, 22, 600, DateTimeKind.Local).AddTicks(8919), new DateTime(2022, 7, 11, 12, 35, 21, 393, DateTimeKind.Local).AddTicks(2291), 3, 13.1358027004154m },
                    { 361, 21, new DateTime(2023, 3, 14, 7, 2, 26, 597, DateTimeKind.Local).AddTicks(390), new DateTime(2023, 2, 2, 22, 41, 51, 273, DateTimeKind.Local).AddTicks(4367), 17, 1.58354163353347m },
                    { 362, 109, new DateTime(2022, 7, 1, 18, 17, 27, 666, DateTimeKind.Local).AddTicks(1340), new DateTime(2022, 7, 6, 17, 41, 44, 388, DateTimeKind.Local).AddTicks(2797), 46, 4.27172202646586m },
                    { 363, 85, new DateTime(2022, 10, 7, 1, 13, 51, 540, DateTimeKind.Local).AddTicks(7318), new DateTime(2022, 5, 4, 15, 21, 19, 505, DateTimeKind.Local).AddTicks(4286), 85, 23.292399015477m },
                    { 364, 64, new DateTime(2022, 7, 10, 9, 9, 56, 14, DateTimeKind.Local).AddTicks(9805), new DateTime(2022, 12, 8, 17, 53, 43, 247, DateTimeKind.Local).AddTicks(5903), 87, 8.54219166401076m },
                    { 365, 133, new DateTime(2023, 2, 22, 20, 22, 16, 190, DateTimeKind.Local).AddTicks(5205), new DateTime(2022, 6, 19, 14, 37, 17, 969, DateTimeKind.Local).AddTicks(8888), 95, 25.111674482335m },
                    { 366, 52, new DateTime(2023, 2, 17, 20, 7, 58, 877, DateTimeKind.Local).AddTicks(7305), new DateTime(2023, 4, 10, 13, 10, 28, 93, DateTimeKind.Local).AddTicks(970), 26, 2.70969501895836m },
                    { 367, 49, new DateTime(2023, 1, 28, 14, 55, 3, 776, DateTimeKind.Local).AddTicks(3817), new DateTime(2022, 10, 23, 8, 37, 16, 622, DateTimeKind.Local).AddTicks(2725), 46, 17.3374683980486m },
                    { 368, 140, new DateTime(2022, 11, 8, 18, 45, 42, 27, DateTimeKind.Local).AddTicks(3008), new DateTime(2022, 11, 9, 11, 51, 53, 867, DateTimeKind.Local).AddTicks(1690), 19, 12.1556515150203m },
                    { 369, 101, new DateTime(2023, 2, 13, 4, 43, 6, 584, DateTimeKind.Local).AddTicks(1736), new DateTime(2023, 4, 6, 12, 12, 55, 588, DateTimeKind.Local).AddTicks(7120), 98, 10.3774662245552m },
                    { 370, 81, new DateTime(2022, 9, 12, 13, 41, 52, 508, DateTimeKind.Local).AddTicks(3496), new DateTime(2022, 6, 27, 4, 3, 5, 575, DateTimeKind.Local).AddTicks(5519), 47, 23.7077792615195m },
                    { 371, 149, new DateTime(2022, 10, 21, 12, 29, 57, 90, DateTimeKind.Local).AddTicks(6778), new DateTime(2022, 7, 2, 16, 49, 42, 195, DateTimeKind.Local).AddTicks(7305), 49, 19.2767526904812m },
                    { 372, 48, new DateTime(2022, 9, 24, 0, 19, 28, 599, DateTimeKind.Local).AddTicks(9217), new DateTime(2022, 9, 1, 8, 52, 37, 403, DateTimeKind.Local).AddTicks(2038), 60, 14.6567553838756m },
                    { 373, 82, new DateTime(2022, 7, 2, 8, 34, 29, 36, DateTimeKind.Local).AddTicks(6273), new DateTime(2023, 2, 22, 22, 15, 36, 64, DateTimeKind.Local).AddTicks(7364), 20, 16.8849927101735m },
                    { 374, 43, new DateTime(2022, 10, 13, 11, 5, 59, 306, DateTimeKind.Local).AddTicks(3371), new DateTime(2022, 6, 21, 14, 9, 44, 961, DateTimeKind.Local).AddTicks(6062), 23, 29.3219887897304m },
                    { 375, 12, new DateTime(2022, 7, 19, 4, 40, 58, 806, DateTimeKind.Local).AddTicks(778), new DateTime(2023, 3, 1, 1, 42, 37, 495, DateTimeKind.Local).AddTicks(1778), 98, 27.5834316574935m },
                    { 376, 47, new DateTime(2022, 9, 10, 14, 42, 44, 451, DateTimeKind.Local).AddTicks(6974), new DateTime(2022, 5, 19, 4, 16, 28, 259, DateTimeKind.Local).AddTicks(9212), 51, 5.86520577667855m },
                    { 377, 14, new DateTime(2022, 4, 26, 23, 27, 51, 427, DateTimeKind.Local).AddTicks(8307), new DateTime(2023, 2, 4, 21, 30, 39, 296, DateTimeKind.Local).AddTicks(650), 13, 2.60059439798674m },
                    { 378, 112, new DateTime(2022, 5, 27, 5, 33, 55, 978, DateTimeKind.Local).AddTicks(7920), new DateTime(2022, 11, 20, 8, 17, 53, 745, DateTimeKind.Local).AddTicks(6334), 26, 15.6666891076543m },
                    { 379, 52, new DateTime(2022, 12, 12, 13, 14, 51, 941, DateTimeKind.Local).AddTicks(5327), new DateTime(2023, 1, 8, 23, 21, 27, 160, DateTimeKind.Local).AddTicks(5958), 30, 22.7582333650396m },
                    { 380, 56, new DateTime(2022, 11, 14, 9, 13, 9, 126, DateTimeKind.Local).AddTicks(6488), new DateTime(2023, 2, 24, 0, 3, 42, 311, DateTimeKind.Local).AddTicks(7240), 86, 17.5138437948208m },
                    { 381, 89, new DateTime(2023, 1, 3, 8, 51, 17, 27, DateTimeKind.Local).AddTicks(3495), new DateTime(2022, 8, 26, 23, 4, 24, 792, DateTimeKind.Local).AddTicks(3759), 77, 16.0522291459296m },
                    { 382, 44, new DateTime(2023, 2, 1, 2, 4, 11, 832, DateTimeKind.Local).AddTicks(8064), new DateTime(2022, 8, 5, 7, 16, 8, 637, DateTimeKind.Local).AddTicks(5507), 15, 11.3713925735863m },
                    { 383, 53, new DateTime(2023, 3, 28, 18, 59, 26, 657, DateTimeKind.Local).AddTicks(7316), new DateTime(2022, 11, 25, 12, 47, 33, 955, DateTimeKind.Local).AddTicks(8138), 17, 9.13643746545542m },
                    { 384, 70, new DateTime(2022, 12, 29, 22, 5, 35, 22, DateTimeKind.Local).AddTicks(3465), new DateTime(2023, 2, 13, 10, 2, 0, 175, DateTimeKind.Local).AddTicks(4534), 80, 6.90377936432549m },
                    { 385, 87, new DateTime(2022, 8, 18, 12, 56, 55, 723, DateTimeKind.Local).AddTicks(3589), new DateTime(2022, 10, 14, 8, 55, 6, 483, DateTimeKind.Local).AddTicks(8457), 40, 28.195384110666m },
                    { 386, 56, new DateTime(2022, 12, 3, 7, 22, 11, 712, DateTimeKind.Local).AddTicks(8347), new DateTime(2022, 10, 31, 21, 8, 44, 359, DateTimeKind.Local).AddTicks(6165), 35, 7.87634887462119m },
                    { 387, 58, new DateTime(2022, 6, 8, 19, 51, 11, 548, DateTimeKind.Local).AddTicks(4011), new DateTime(2022, 5, 27, 11, 48, 16, 610, DateTimeKind.Local).AddTicks(3573), 66, 29.5207176246213m },
                    { 388, 36, new DateTime(2022, 4, 30, 11, 32, 5, 847, DateTimeKind.Local).AddTicks(9308), new DateTime(2022, 9, 7, 8, 14, 57, 439, DateTimeKind.Local).AddTicks(9451), 94, 26.4156607050935m },
                    { 389, 91, new DateTime(2022, 12, 5, 0, 48, 4, 1, DateTimeKind.Local).AddTicks(6656), new DateTime(2022, 5, 16, 18, 14, 49, 370, DateTimeKind.Local).AddTicks(9933), 66, 6.65168659242477m },
                    { 390, 144, new DateTime(2022, 7, 10, 2, 45, 23, 529, DateTimeKind.Local).AddTicks(75), new DateTime(2022, 6, 15, 1, 42, 25, 700, DateTimeKind.Local).AddTicks(7746), 3, 14.165372703447m },
                    { 391, 42, new DateTime(2023, 4, 4, 9, 44, 30, 792, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 5, 22, 5, 16, 49, 258, DateTimeKind.Local).AddTicks(7749), 89, 12.9707498904636m },
                    { 392, 75, new DateTime(2022, 9, 6, 15, 31, 28, 347, DateTimeKind.Local).AddTicks(4738), new DateTime(2022, 6, 19, 8, 44, 54, 694, DateTimeKind.Local).AddTicks(1384), 69, 14.9213362923202m },
                    { 393, 26, new DateTime(2022, 5, 31, 23, 16, 46, 304, DateTimeKind.Local).AddTicks(1264), new DateTime(2023, 1, 3, 12, 43, 55, 473, DateTimeKind.Local).AddTicks(8951), 5, 2.95540384492152m },
                    { 394, 138, new DateTime(2022, 6, 28, 16, 54, 53, 202, DateTimeKind.Local).AddTicks(461), new DateTime(2022, 11, 22, 16, 25, 29, 380, DateTimeKind.Local).AddTicks(6331), 71, 7.38033985426375m },
                    { 395, 124, new DateTime(2022, 4, 22, 12, 4, 15, 245, DateTimeKind.Local).AddTicks(849), new DateTime(2022, 7, 14, 19, 34, 14, 630, DateTimeKind.Local).AddTicks(8988), 23, 21.5265719162848m },
                    { 396, 48, new DateTime(2022, 7, 13, 23, 14, 10, 757, DateTimeKind.Local).AddTicks(1570), new DateTime(2022, 5, 15, 18, 21, 21, 548, DateTimeKind.Local).AddTicks(8043), 44, 25.708793294531m },
                    { 397, 67, new DateTime(2022, 7, 22, 9, 48, 59, 387, DateTimeKind.Local).AddTicks(5960), new DateTime(2023, 2, 5, 6, 28, 54, 94, DateTimeKind.Local).AddTicks(7922), 39, 25.4292173468782m },
                    { 398, 57, new DateTime(2023, 2, 23, 14, 53, 20, 968, DateTimeKind.Local).AddTicks(150), new DateTime(2022, 11, 10, 2, 46, 6, 388, DateTimeKind.Local).AddTicks(1354), 11, 29.2015130703785m },
                    { 399, 124, new DateTime(2022, 9, 3, 3, 17, 35, 452, DateTimeKind.Local).AddTicks(1617), new DateTime(2023, 3, 23, 9, 16, 51, 510, DateTimeKind.Local).AddTicks(3866), 81, 17.8005470147938m },
                    { 400, 70, new DateTime(2022, 7, 10, 0, 51, 25, 400, DateTimeKind.Local).AddTicks(1506), new DateTime(2023, 2, 19, 12, 33, 32, 715, DateTimeKind.Local).AddTicks(3029), 34, 12.4326950296556m },
                    { 401, 5, new DateTime(2022, 6, 12, 23, 14, 55, 826, DateTimeKind.Local).AddTicks(8048), new DateTime(2022, 7, 10, 23, 8, 51, 305, DateTimeKind.Local).AddTicks(3060), 78, 18.83105501423m },
                    { 402, 102, new DateTime(2022, 5, 23, 23, 33, 51, 290, DateTimeKind.Local).AddTicks(3723), new DateTime(2022, 7, 20, 21, 0, 17, 116, DateTimeKind.Local).AddTicks(4076), 37, 10.1640618306893m },
                    { 403, 145, new DateTime(2022, 8, 6, 1, 14, 49, 519, DateTimeKind.Local).AddTicks(7171), new DateTime(2023, 2, 2, 1, 45, 51, 730, DateTimeKind.Local).AddTicks(6998), 81, 6.65784821866364m },
                    { 404, 2, new DateTime(2022, 11, 21, 6, 43, 46, 95, DateTimeKind.Local).AddTicks(6769), new DateTime(2022, 9, 20, 9, 41, 21, 0, DateTimeKind.Local).AddTicks(2310), 98, 25.5354880770478m },
                    { 405, 17, new DateTime(2022, 10, 11, 7, 55, 48, 293, DateTimeKind.Local).AddTicks(1980), new DateTime(2023, 1, 18, 3, 52, 34, 932, DateTimeKind.Local).AddTicks(6766), 52, 27.8691095527963m },
                    { 406, 63, new DateTime(2022, 7, 26, 3, 13, 58, 491, DateTimeKind.Local).AddTicks(6904), new DateTime(2022, 8, 16, 3, 2, 20, 323, DateTimeKind.Local).AddTicks(1981), 77, 17.2717149470217m },
                    { 407, 67, new DateTime(2022, 10, 24, 12, 56, 4, 981, DateTimeKind.Local).AddTicks(2028), new DateTime(2022, 5, 28, 15, 46, 21, 317, DateTimeKind.Local).AddTicks(9886), 3, 28.5386464088122m },
                    { 408, 111, new DateTime(2023, 3, 24, 5, 1, 25, 678, DateTimeKind.Local).AddTicks(3315), new DateTime(2022, 7, 14, 9, 14, 22, 588, DateTimeKind.Local).AddTicks(2133), 30, 15.8676558747591m },
                    { 409, 125, new DateTime(2022, 4, 24, 16, 29, 22, 496, DateTimeKind.Local).AddTicks(4279), new DateTime(2022, 11, 19, 2, 12, 7, 941, DateTimeKind.Local).AddTicks(8334), 6, 29.9341586767564m },
                    { 410, 149, new DateTime(2022, 9, 25, 11, 33, 50, 516, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 7, 31, 16, 52, 35, 782, DateTimeKind.Local).AddTicks(5363), 48, 12.7667660986694m },
                    { 411, 150, new DateTime(2022, 11, 25, 0, 26, 45, 611, DateTimeKind.Local).AddTicks(5309), new DateTime(2023, 2, 26, 15, 28, 6, 772, DateTimeKind.Local).AddTicks(4118), 55, 1.24276643672377m },
                    { 412, 142, new DateTime(2022, 11, 1, 4, 52, 16, 782, DateTimeKind.Local).AddTicks(9435), new DateTime(2022, 7, 1, 10, 56, 26, 785, DateTimeKind.Local).AddTicks(5811), 69, 7.87813647111111m },
                    { 413, 8, new DateTime(2022, 9, 27, 21, 59, 34, 286, DateTimeKind.Local).AddTicks(3070), new DateTime(2023, 1, 26, 14, 20, 39, 649, DateTimeKind.Local).AddTicks(6048), 43, 10.0568119928642m },
                    { 414, 79, new DateTime(2022, 11, 25, 11, 16, 24, 888, DateTimeKind.Local).AddTicks(9627), new DateTime(2022, 12, 5, 12, 22, 3, 72, DateTimeKind.Local).AddTicks(7942), 96, 29.6375868601213m },
                    { 415, 27, new DateTime(2022, 7, 21, 16, 29, 35, 316, DateTimeKind.Local).AddTicks(2822), new DateTime(2022, 5, 16, 4, 36, 36, 307, DateTimeKind.Local).AddTicks(5821), 31, 17.668987984891m },
                    { 416, 2, new DateTime(2022, 11, 6, 5, 40, 4, 734, DateTimeKind.Local).AddTicks(8055), new DateTime(2023, 3, 22, 16, 43, 51, 982, DateTimeKind.Local).AddTicks(6094), 21, 11.4501682997019m },
                    { 417, 141, new DateTime(2023, 2, 22, 20, 34, 59, 272, DateTimeKind.Local).AddTicks(1555), new DateTime(2023, 2, 22, 16, 42, 52, 266, DateTimeKind.Local).AddTicks(4189), 91, 3.2567849692547m },
                    { 418, 150, new DateTime(2023, 3, 12, 0, 20, 36, 413, DateTimeKind.Local).AddTicks(6234), new DateTime(2022, 10, 7, 5, 31, 42, 963, DateTimeKind.Local).AddTicks(2391), 4, 17.3695845380441m },
                    { 419, 121, new DateTime(2022, 8, 5, 22, 22, 11, 814, DateTimeKind.Local).AddTicks(2976), new DateTime(2022, 7, 10, 6, 48, 10, 746, DateTimeKind.Local).AddTicks(1635), 56, 19.1566267482303m },
                    { 420, 89, new DateTime(2022, 4, 22, 6, 6, 39, 0, DateTimeKind.Local).AddTicks(5961), new DateTime(2023, 3, 15, 11, 51, 31, 942, DateTimeKind.Local).AddTicks(7218), 3, 25.1641531873738m },
                    { 421, 103, new DateTime(2022, 10, 29, 16, 55, 52, 200, DateTimeKind.Local).AddTicks(1140), new DateTime(2023, 1, 15, 16, 3, 43, 120, DateTimeKind.Local).AddTicks(6860), 99, 4.64230554675959m },
                    { 422, 127, new DateTime(2022, 6, 26, 20, 45, 3, 236, DateTimeKind.Local).AddTicks(3783), new DateTime(2022, 10, 5, 2, 31, 47, 182, DateTimeKind.Local).AddTicks(862), 19, 4.3904146708072m },
                    { 423, 93, new DateTime(2023, 3, 10, 0, 0, 4, 388, DateTimeKind.Local).AddTicks(2867), new DateTime(2022, 12, 29, 7, 27, 54, 274, DateTimeKind.Local).AddTicks(183), 45, 13.7826316091465m },
                    { 424, 96, new DateTime(2022, 10, 13, 12, 40, 45, 198, DateTimeKind.Local).AddTicks(7275), new DateTime(2022, 10, 3, 16, 2, 38, 337, DateTimeKind.Local).AddTicks(142), 26, 9.24980477074397m },
                    { 425, 49, new DateTime(2023, 1, 21, 17, 47, 12, 638, DateTimeKind.Local).AddTicks(7333), new DateTime(2022, 7, 18, 23, 14, 59, 582, DateTimeKind.Local).AddTicks(1186), 56, 6.40265582854367m },
                    { 426, 47, new DateTime(2022, 7, 14, 1, 54, 55, 192, DateTimeKind.Local).AddTicks(9258), new DateTime(2022, 11, 11, 12, 38, 36, 155, DateTimeKind.Local).AddTicks(572), 80, 13.1854414577526m },
                    { 427, 4, new DateTime(2022, 8, 17, 16, 11, 35, 731, DateTimeKind.Local).AddTicks(1708), new DateTime(2023, 2, 21, 15, 45, 52, 32, DateTimeKind.Local).AddTicks(2010), 95, 28.1964434093882m },
                    { 428, 94, new DateTime(2022, 12, 14, 9, 26, 29, 240, DateTimeKind.Local).AddTicks(6711), new DateTime(2022, 7, 30, 8, 45, 57, 25, DateTimeKind.Local).AddTicks(2971), 84, 6.56105076700797m },
                    { 429, 98, new DateTime(2022, 5, 11, 18, 38, 27, 983, DateTimeKind.Local).AddTicks(5607), new DateTime(2022, 10, 9, 20, 31, 57, 579, DateTimeKind.Local).AddTicks(2177), 20, 8.5687752258932m },
                    { 430, 29, new DateTime(2022, 5, 28, 12, 45, 39, 386, DateTimeKind.Local).AddTicks(2817), new DateTime(2023, 3, 27, 1, 19, 53, 295, DateTimeKind.Local).AddTicks(9834), 55, 9.74808556751086m },
                    { 431, 93, new DateTime(2022, 8, 2, 10, 8, 49, 434, DateTimeKind.Local).AddTicks(6232), new DateTime(2022, 11, 14, 23, 13, 57, 360, DateTimeKind.Local).AddTicks(590), 14, 8.01615895348741m },
                    { 432, 121, new DateTime(2023, 1, 8, 3, 36, 13, 636, DateTimeKind.Local).AddTicks(6925), new DateTime(2022, 5, 16, 9, 31, 34, 900, DateTimeKind.Local).AddTicks(8178), 90, 11.7434212435244m },
                    { 433, 25, new DateTime(2023, 1, 28, 5, 19, 48, 18, DateTimeKind.Local).AddTicks(8013), new DateTime(2022, 8, 3, 13, 32, 25, 394, DateTimeKind.Local).AddTicks(2420), 30, 13.7571610030419m },
                    { 434, 37, new DateTime(2022, 12, 31, 0, 59, 16, 786, DateTimeKind.Local).AddTicks(5815), new DateTime(2022, 8, 12, 16, 8, 28, 998, DateTimeKind.Local).AddTicks(5385), 36, 15.4496508832811m },
                    { 435, 6, new DateTime(2022, 12, 28, 4, 28, 19, 891, DateTimeKind.Local).AddTicks(3967), new DateTime(2023, 2, 18, 5, 50, 6, 464, DateTimeKind.Local).AddTicks(3030), 93, 15.0683569388694m },
                    { 436, 99, new DateTime(2022, 8, 4, 9, 35, 23, 337, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 6, 21, 20, 25, 33, 880, DateTimeKind.Local).AddTicks(412), 19, 24.5382339254054m },
                    { 437, 59, new DateTime(2023, 3, 8, 23, 2, 12, 580, DateTimeKind.Local).AddTicks(230), new DateTime(2022, 9, 7, 15, 37, 11, 144, DateTimeKind.Local).AddTicks(322), 28, 4.43932608749885m },
                    { 438, 149, new DateTime(2022, 4, 22, 6, 51, 15, 373, DateTimeKind.Local).AddTicks(7585), new DateTime(2022, 12, 6, 6, 11, 46, 304, DateTimeKind.Local).AddTicks(2902), 71, 23.6534071350196m },
                    { 439, 27, new DateTime(2022, 9, 5, 9, 39, 50, 696, DateTimeKind.Local).AddTicks(57), new DateTime(2023, 2, 9, 11, 8, 48, 257, DateTimeKind.Local).AddTicks(1197), 44, 28.4385765106721m },
                    { 440, 51, new DateTime(2022, 10, 2, 13, 47, 17, 198, DateTimeKind.Local).AddTicks(5073), new DateTime(2023, 2, 21, 13, 2, 26, 280, DateTimeKind.Local).AddTicks(7344), 61, 17.6755189112327m },
                    { 441, 112, new DateTime(2022, 6, 9, 19, 3, 39, 529, DateTimeKind.Local).AddTicks(2720), new DateTime(2022, 8, 15, 4, 56, 35, 557, DateTimeKind.Local).AddTicks(9279), 76, 11.8355330841281m },
                    { 442, 96, new DateTime(2022, 12, 7, 20, 27, 32, 753, DateTimeKind.Local).AddTicks(7556), new DateTime(2022, 5, 4, 19, 53, 47, 466, DateTimeKind.Local).AddTicks(5708), 41, 15.6762821743577m },
                    { 443, 39, new DateTime(2022, 9, 13, 2, 7, 29, 385, DateTimeKind.Local).AddTicks(5198), new DateTime(2022, 10, 10, 23, 13, 52, 109, DateTimeKind.Local).AddTicks(2491), 36, 6.39521301052998m },
                    { 444, 110, new DateTime(2022, 6, 1, 8, 30, 57, 807, DateTimeKind.Local).AddTicks(4239), new DateTime(2022, 10, 25, 2, 55, 42, 872, DateTimeKind.Local).AddTicks(9869), 90, 6.85472134295148m },
                    { 445, 133, new DateTime(2023, 2, 24, 10, 13, 21, 986, DateTimeKind.Local).AddTicks(913), new DateTime(2022, 10, 16, 1, 56, 56, 784, DateTimeKind.Local).AddTicks(6088), 92, 17.5068220845862m },
                    { 446, 100, new DateTime(2023, 1, 29, 2, 53, 3, 484, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 12, 25, 22, 53, 10, 74, DateTimeKind.Local).AddTicks(4687), 70, 6.52430409913448m },
                    { 447, 129, new DateTime(2023, 1, 10, 0, 15, 25, 960, DateTimeKind.Local).AddTicks(5943), new DateTime(2023, 2, 9, 14, 10, 50, 119, DateTimeKind.Local).AddTicks(8424), 18, 3.68998224119424m },
                    { 448, 17, new DateTime(2023, 3, 21, 19, 48, 8, 725, DateTimeKind.Local).AddTicks(6277), new DateTime(2022, 9, 14, 10, 3, 15, 551, DateTimeKind.Local).AddTicks(8873), 63, 29.0848386495871m },
                    { 449, 23, new DateTime(2022, 11, 20, 22, 38, 43, 586, DateTimeKind.Local).AddTicks(9168), new DateTime(2022, 11, 8, 4, 28, 39, 849, DateTimeKind.Local).AddTicks(2643), 50, 26.7869539376537m },
                    { 450, 5, new DateTime(2022, 11, 17, 2, 57, 22, 565, DateTimeKind.Local).AddTicks(309), new DateTime(2022, 8, 25, 11, 26, 16, 718, DateTimeKind.Local).AddTicks(5979), 81, 23.0894573350639m },
                    { 451, 24, new DateTime(2023, 1, 15, 17, 38, 39, 366, DateTimeKind.Local).AddTicks(396), new DateTime(2022, 11, 2, 22, 28, 17, 622, DateTimeKind.Local).AddTicks(1396), 4, 22.6561756922154m },
                    { 452, 71, new DateTime(2022, 10, 28, 2, 43, 59, 390, DateTimeKind.Local).AddTicks(5526), new DateTime(2022, 8, 1, 0, 41, 11, 702, DateTimeKind.Local).AddTicks(7311), 40, 13.7978452512656m },
                    { 453, 21, new DateTime(2023, 1, 9, 8, 21, 14, 313, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 7, 28, 0, 56, 49, 909, DateTimeKind.Local).AddTicks(3922), 31, 4.79775629183855m },
                    { 454, 6, new DateTime(2022, 11, 2, 0, 52, 11, 530, DateTimeKind.Local).AddTicks(1346), new DateTime(2023, 3, 14, 13, 32, 5, 575, DateTimeKind.Local).AddTicks(7907), 20, 24.5424092083586m },
                    { 455, 82, new DateTime(2022, 10, 18, 11, 8, 32, 263, DateTimeKind.Local).AddTicks(3839), new DateTime(2022, 9, 27, 12, 39, 54, 791, DateTimeKind.Local).AddTicks(5651), 54, 20.5734304718558m },
                    { 456, 27, new DateTime(2022, 12, 20, 4, 22, 13, 553, DateTimeKind.Local).AddTicks(786), new DateTime(2023, 1, 17, 2, 27, 48, 439, DateTimeKind.Local).AddTicks(5984), 38, 23.5074593230734m },
                    { 457, 1, new DateTime(2023, 4, 10, 14, 24, 8, 71, DateTimeKind.Local).AddTicks(6737), new DateTime(2022, 7, 20, 6, 21, 38, 494, DateTimeKind.Local).AddTicks(1443), 19, 1.53214530234754m },
                    { 458, 66, new DateTime(2022, 8, 14, 22, 40, 26, 7, DateTimeKind.Local).AddTicks(538), new DateTime(2022, 5, 28, 16, 28, 31, 354, DateTimeKind.Local).AddTicks(2313), 33, 11.1216375618801m },
                    { 459, 75, new DateTime(2022, 10, 28, 12, 50, 36, 984, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 10, 2, 3, 21, 34, 828, DateTimeKind.Local).AddTicks(2193), 48, 22.7416153817299m },
                    { 460, 115, new DateTime(2022, 5, 20, 14, 32, 6, 649, DateTimeKind.Local).AddTicks(4484), new DateTime(2022, 8, 2, 4, 30, 25, 221, DateTimeKind.Local).AddTicks(1079), 42, 8.46096635891936m },
                    { 461, 84, new DateTime(2022, 5, 30, 11, 54, 43, 393, DateTimeKind.Local).AddTicks(4843), new DateTime(2022, 10, 19, 3, 7, 11, 281, DateTimeKind.Local).AddTicks(5478), 39, 24.7241309290988m },
                    { 462, 53, new DateTime(2022, 11, 25, 23, 15, 54, 514, DateTimeKind.Local).AddTicks(870), new DateTime(2022, 10, 30, 15, 19, 8, 814, DateTimeKind.Local).AddTicks(7569), 85, 8.20847129164706m },
                    { 463, 47, new DateTime(2022, 5, 21, 6, 21, 57, 312, DateTimeKind.Local).AddTicks(6021), new DateTime(2023, 1, 12, 2, 24, 32, 602, DateTimeKind.Local).AddTicks(2114), 70, 24.0301285937527m },
                    { 464, 130, new DateTime(2023, 1, 7, 21, 27, 53, 641, DateTimeKind.Local).AddTicks(7360), new DateTime(2022, 6, 7, 1, 9, 22, 357, DateTimeKind.Local).AddTicks(4329), 54, 16.2837917337539m },
                    { 465, 1, new DateTime(2023, 1, 8, 21, 26, 42, 171, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 11, 23, 10, 36, 34, 782, DateTimeKind.Local).AddTicks(4723), 84, 29.834565225697m },
                    { 466, 109, new DateTime(2022, 11, 27, 22, 4, 37, 176, DateTimeKind.Local).AddTicks(6395), new DateTime(2022, 6, 5, 16, 33, 33, 959, DateTimeKind.Local).AddTicks(2842), 46, 6.05498110735528m },
                    { 467, 58, new DateTime(2023, 1, 16, 19, 51, 11, 728, DateTimeKind.Local).AddTicks(8098), new DateTime(2022, 8, 4, 6, 20, 0, 961, DateTimeKind.Local).AddTicks(3982), 47, 25.4733596132737m },
                    { 468, 138, new DateTime(2022, 8, 13, 0, 51, 57, 258, DateTimeKind.Local).AddTicks(1374), new DateTime(2022, 7, 9, 12, 1, 41, 865, DateTimeKind.Local).AddTicks(1780), 58, 13.3689354129702m },
                    { 469, 119, new DateTime(2023, 2, 15, 21, 56, 7, 276, DateTimeKind.Local).AddTicks(5726), new DateTime(2022, 6, 23, 8, 43, 54, 10, DateTimeKind.Local).AddTicks(929), 64, 23.0654216639009m },
                    { 470, 125, new DateTime(2022, 11, 21, 2, 38, 49, 33, DateTimeKind.Local).AddTicks(616), new DateTime(2022, 6, 17, 0, 30, 1, 825, DateTimeKind.Local).AddTicks(2829), 30, 7.88961297563637m },
                    { 471, 84, new DateTime(2023, 3, 31, 21, 28, 11, 222, DateTimeKind.Local).AddTicks(5796), new DateTime(2023, 4, 11, 11, 49, 41, 706, DateTimeKind.Local).AddTicks(623), 62, 3.96373845070733m },
                    { 472, 62, new DateTime(2022, 12, 10, 4, 38, 30, 646, DateTimeKind.Local).AddTicks(5785), new DateTime(2022, 9, 5, 9, 7, 55, 598, DateTimeKind.Local).AddTicks(2148), 54, 22.0255479722322m },
                    { 473, 92, new DateTime(2022, 8, 2, 10, 15, 38, 76, DateTimeKind.Local).AddTicks(8063), new DateTime(2022, 11, 17, 15, 49, 2, 582, DateTimeKind.Local).AddTicks(3116), 23, 28.5660819856444m },
                    { 474, 77, new DateTime(2023, 1, 14, 16, 57, 24, 837, DateTimeKind.Local).AddTicks(2313), new DateTime(2022, 8, 18, 12, 41, 11, 809, DateTimeKind.Local).AddTicks(6853), 50, 26.4221380153345m },
                    { 475, 3, new DateTime(2023, 4, 7, 0, 43, 44, 274, DateTimeKind.Local).AddTicks(5403), new DateTime(2022, 10, 30, 2, 16, 1, 637, DateTimeKind.Local).AddTicks(9100), 18, 12.2649251934305m },
                    { 476, 104, new DateTime(2022, 5, 26, 21, 59, 40, 194, DateTimeKind.Local).AddTicks(1560), new DateTime(2022, 7, 5, 5, 42, 35, 760, DateTimeKind.Local).AddTicks(7532), 11, 8.65815547156597m },
                    { 477, 21, new DateTime(2022, 9, 2, 2, 26, 24, 605, DateTimeKind.Local).AddTicks(8071), new DateTime(2022, 7, 17, 23, 31, 38, 856, DateTimeKind.Local).AddTicks(4820), 64, 5.129177349785m },
                    { 478, 69, new DateTime(2022, 9, 22, 12, 27, 37, 925, DateTimeKind.Local).AddTicks(9534), new DateTime(2023, 4, 15, 10, 10, 39, 670, DateTimeKind.Local).AddTicks(9888), 70, 9.85027682052229m },
                    { 479, 66, new DateTime(2022, 7, 5, 23, 28, 30, 271, DateTimeKind.Local).AddTicks(8704), new DateTime(2022, 5, 24, 6, 47, 46, 318, DateTimeKind.Local).AddTicks(634), 61, 22.2365408014015m },
                    { 480, 56, new DateTime(2022, 12, 17, 0, 33, 28, 122, DateTimeKind.Local).AddTicks(6686), new DateTime(2023, 3, 28, 0, 27, 18, 793, DateTimeKind.Local).AddTicks(2699), 69, 21.2831979910067m },
                    { 481, 96, new DateTime(2022, 10, 26, 10, 41, 4, 144, DateTimeKind.Local).AddTicks(5815), new DateTime(2022, 4, 29, 23, 57, 59, 184, DateTimeKind.Local).AddTicks(7901), 4, 6.7838598734266m },
                    { 482, 40, new DateTime(2023, 1, 5, 10, 43, 52, 983, DateTimeKind.Local).AddTicks(2568), new DateTime(2023, 3, 1, 14, 22, 21, 320, DateTimeKind.Local).AddTicks(5314), 22, 15.8654245968595m },
                    { 483, 76, new DateTime(2022, 8, 25, 12, 54, 31, 737, DateTimeKind.Local).AddTicks(8068), new DateTime(2023, 1, 5, 11, 40, 20, 188, DateTimeKind.Local).AddTicks(3839), 54, 13.7005176132429m },
                    { 484, 141, new DateTime(2022, 7, 25, 7, 10, 9, 546, DateTimeKind.Local).AddTicks(7935), new DateTime(2022, 5, 13, 12, 31, 56, 149, DateTimeKind.Local).AddTicks(230), 81, 28.1650340220402m },
                    { 485, 40, new DateTime(2022, 11, 29, 9, 15, 15, 762, DateTimeKind.Local).AddTicks(86), new DateTime(2022, 11, 22, 15, 59, 35, 580, DateTimeKind.Local).AddTicks(3029), 67, 7.00823653814983m },
                    { 486, 91, new DateTime(2022, 5, 17, 22, 26, 49, 910, DateTimeKind.Local).AddTicks(2552), new DateTime(2022, 7, 9, 1, 14, 42, 376, DateTimeKind.Local).AddTicks(2864), 80, 13.8144056337086m },
                    { 487, 106, new DateTime(2022, 6, 25, 8, 57, 15, 497, DateTimeKind.Local).AddTicks(8642), new DateTime(2023, 3, 26, 22, 40, 53, 726, DateTimeKind.Local).AddTicks(6017), 5, 29.5885609539022m },
                    { 488, 54, new DateTime(2022, 4, 24, 19, 27, 16, 944, DateTimeKind.Local).AddTicks(7875), new DateTime(2022, 6, 27, 3, 54, 11, 992, DateTimeKind.Local).AddTicks(8245), 74, 28.5254536868797m },
                    { 489, 146, new DateTime(2022, 11, 10, 20, 42, 4, 133, DateTimeKind.Local).AddTicks(6889), new DateTime(2022, 10, 27, 0, 56, 21, 339, DateTimeKind.Local).AddTicks(112), 69, 17.0074721035886m },
                    { 490, 139, new DateTime(2022, 9, 20, 0, 7, 51, 944, DateTimeKind.Local).AddTicks(5723), new DateTime(2022, 12, 2, 11, 51, 16, 459, DateTimeKind.Local).AddTicks(3462), 22, 12.1428047276962m },
                    { 491, 75, new DateTime(2023, 1, 29, 15, 31, 11, 460, DateTimeKind.Local).AddTicks(3639), new DateTime(2023, 2, 4, 19, 45, 55, 412, DateTimeKind.Local).AddTicks(1919), 86, 19.0985826755053m },
                    { 492, 44, new DateTime(2023, 2, 2, 15, 19, 36, 482, DateTimeKind.Local).AddTicks(9237), new DateTime(2022, 8, 18, 0, 48, 44, 880, DateTimeKind.Local).AddTicks(4169), 82, 10.8472806658487m },
                    { 493, 129, new DateTime(2023, 1, 22, 11, 22, 42, 64, DateTimeKind.Local).AddTicks(2225), new DateTime(2022, 11, 13, 19, 48, 4, 594, DateTimeKind.Local).AddTicks(1937), 71, 21.990961525058m },
                    { 494, 140, new DateTime(2023, 1, 10, 12, 18, 4, 803, DateTimeKind.Local).AddTicks(1530), new DateTime(2022, 11, 10, 18, 46, 50, 905, DateTimeKind.Local).AddTicks(2481), 99, 28.8056632773991m },
                    { 495, 106, new DateTime(2022, 5, 15, 6, 24, 37, 292, DateTimeKind.Local).AddTicks(7476), new DateTime(2022, 10, 12, 23, 49, 30, 601, DateTimeKind.Local).AddTicks(4883), 72, 27.1417499971394m },
                    { 496, 34, new DateTime(2022, 11, 23, 15, 35, 34, 534, DateTimeKind.Local).AddTicks(3413), new DateTime(2023, 2, 9, 16, 10, 34, 68, DateTimeKind.Local).AddTicks(764), 46, 18.0430314946596m },
                    { 497, 126, new DateTime(2022, 9, 12, 22, 32, 53, 685, DateTimeKind.Local).AddTicks(7712), new DateTime(2022, 6, 17, 12, 54, 22, 897, DateTimeKind.Local).AddTicks(9272), 53, 27.3644174458681m },
                    { 498, 39, new DateTime(2022, 7, 31, 11, 57, 21, 549, DateTimeKind.Local).AddTicks(8377), new DateTime(2022, 7, 20, 15, 43, 8, 435, DateTimeKind.Local).AddTicks(6089), 51, 3.15493303999246m },
                    { 499, 2, new DateTime(2022, 10, 1, 14, 3, 27, 925, DateTimeKind.Local).AddTicks(565), new DateTime(2022, 12, 29, 18, 24, 55, 895, DateTimeKind.Local).AddTicks(9766), 69, 13.2789786843952m },
                    { 500, 109, new DateTime(2022, 5, 2, 7, 5, 29, 291, DateTimeKind.Local).AddTicks(3698), new DateTime(2022, 7, 15, 11, 5, 49, 345, DateTimeKind.Local).AddTicks(6099), 40, 20.2667138620592m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 23, 59, 32, 723, DateTimeKind.Local).AddTicks(8972), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 129, DateTimeKind.Local).AddTicks(5060), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 15, 23, 59, 32, 726, DateTimeKind.Local).AddTicks(6720), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 132, DateTimeKind.Local).AddTicks(2805), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 15, 23, 59, 32, 729, DateTimeKind.Local).AddTicks(3602), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 134, DateTimeKind.Local).AddTicks(9741), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 15, 23, 59, 32, 731, DateTimeKind.Local).AddTicks(9694), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 137, DateTimeKind.Local).AddTicks(5781), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 15, 23, 59, 32, 734, DateTimeKind.Local).AddTicks(9520), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 140, DateTimeKind.Local).AddTicks(5622), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 15, 23, 59, 32, 737, DateTimeKind.Local).AddTicks(9467), "Metal_Chicken.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 143, DateTimeKind.Local).AddTicks(5559), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 15, 23, 59, 32, 741, DateTimeKind.Local).AddTicks(2270), "Metal_Shoes.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 146, DateTimeKind.Local).AddTicks(8375), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 15, 23, 59, 32, 743, DateTimeKind.Local).AddTicks(6707), "Metal_Shoes2.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 149, DateTimeKind.Local).AddTicks(2775), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 15, 23, 59, 32, 746, DateTimeKind.Local).AddTicks(3307), "Steel_Computer.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 151, DateTimeKind.Local).AddTicks(9395), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 15, 23, 59, 32, 748, DateTimeKind.Local).AddTicks(8658), "Cotton_Cheese.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 154, DateTimeKind.Local).AddTicks(4729), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 15, 23, 59, 32, 751, DateTimeKind.Local).AddTicks(2822), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 156, DateTimeKind.Local).AddTicks(8945), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 15, 23, 59, 32, 754, DateTimeKind.Local).AddTicks(1503), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 159, DateTimeKind.Local).AddTicks(7590), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 15, 23, 59, 32, 757, DateTimeKind.Local).AddTicks(987), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 7, 8, 12, 43, 162, DateTimeKind.Local).AddTicks(7082), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 9, 6 },
                    { 1, 7 },
                    { 4, 8 },
                    { 2, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 5, 12 },
                    { 8, 13 },
                    { 8, 14 },
                    { 5, 15 },
                    { 2, 16 },
                    { 1, 17 },
                    { 9, 18 },
                    { 6, 19 },
                    { 7, 20 },
                    { 1, 21 },
                    { 6, 22 },
                    { 2, 23 },
                    { 3, 24 },
                    { 4, 25 },
                    { 7, 26 },
                    { 5, 27 },
                    { 7, 28 },
                    { 9, 29 },
                    { 9, 30 },
                    { 3, 31 },
                    { 2, 32 },
                    { 3, 33 },
                    { 2, 34 },
                    { 3, 35 },
                    { 6, 36 },
                    { 2, 37 },
                    { 9, 38 },
                    { 6, 39 },
                    { 8, 40 },
                    { 3, 41 },
                    { 7, 42 },
                    { 4, 43 },
                    { 4, 44 },
                    { 8, 45 },
                    { 1, 46 },
                    { 6, 47 },
                    { 6, 48 },
                    { 3, 49 },
                    { 1, 50 },
                    { 5, 51 },
                    { 9, 52 },
                    { 6, 53 },
                    { 8, 54 },
                    { 6, 55 },
                    { 7, 56 },
                    { 7, 57 },
                    { 9, 58 },
                    { 8, 59 },
                    { 2, 60 },
                    { 4, 61 },
                    { 2, 62 },
                    { 2, 63 },
                    { 1, 64 },
                    { 2, 65 },
                    { 6, 66 },
                    { 9, 67 },
                    { 4, 68 },
                    { 6, 69 },
                    { 5, 70 },
                    { 1, 71 },
                    { 5, 72 },
                    { 4, 73 },
                    { 2, 74 },
                    { 9, 75 },
                    { 7, 76 },
                    { 5, 77 },
                    { 3, 78 },
                    { 1, 79 },
                    { 4, 80 },
                    { 3, 81 },
                    { 6, 82 },
                    { 9, 83 },
                    { 4, 84 },
                    { 4, 85 },
                    { 9, 86 },
                    { 8, 87 },
                    { 8, 88 },
                    { 8, 89 },
                    { 6, 90 },
                    { 2, 91 },
                    { 2, 92 },
                    { 7, 93 },
                    { 4, 94 },
                    { 6, 95 },
                    { 8, 96 },
                    { 2, 97 },
                    { 9, 98 },
                    { 6, 99 },
                    { 6, 100 }
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
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
