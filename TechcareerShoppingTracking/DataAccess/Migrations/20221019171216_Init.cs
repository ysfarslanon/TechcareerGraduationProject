using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsShopping = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(4520))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Descripion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListDetails_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "İçecek" },
                    { 3, "Atıştırmalık" },
                    { 4, "Kahvaltılık" },
                    { 5, "Temizlik" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "PictureURL" },
                values: new object[,]
                {
                    { 1, 1, "Laptop A", "https://picsum.photos/id/1/200/300" },
                    { 2, 1, "Geniş Ekran", "https://picsum.photos/id/2/200/300" },
                    { 3, 1, "Bilgisayar Kasası", "https://picsum.photos/id/3/200/300" },
                    { 4, 1, "Kamera A", "https://picsum.photos/id/4/200/300" },
                    { 5, 1, "Yazıcı", "https://picsum.photos/id/5/200/300" },
                    { 6, 1, "Webcam", "https://picsum.photos/id/6/200/300" },
                    { 7, 1, "Akıllı Saat A", "https://picsum.photos/id/7/200/300" },
                    { 8, 1, "Telefon A350", "https://picsum.photos/id/8/200/300" },
                    { 9, 2, "Yeşil Çay", "https://picsum.photos/id/9/200/300" },
                    { 10, 2, "Siyah Çay", "https://picsum.photos/id/10/200/300" },
                    { 11, 2, "Süt", "https://picsum.photos/id/11/200/300" },
                    { 12, 2, "Kahve", "https://picsum.photos/id/12/200/300" },
                    { 13, 2, "Soda", "https://picsum.photos/id/13/200/300" },
                    { 14, 2, "Karpuzlu Soda", "https://picsum.photos/id/14/200/300" },
                    { 15, 3, "Goflet", "https://picsum.photos/id/15/200/300" },
                    { 16, 3, "Beyaz Çikolata", "https://picsum.photos/id/16/200/300" },
                    { 17, 3, "Çekirdek", "https://picsum.photos/id/429/17/300" },
                    { 18, 3, "Leblebi", "https://picsum.photos/id/429/18/300" },
                    { 19, 3, "Cips", "https://picsum.photos/id/429/19/300" },
                    { 20, 4, "Zeytin", "https://picsum.photos/id/20/200/300" },
                    { 21, 4, "Peynir", "https://picsum.photos/id/21/200/300" },
                    { 22, 4, "Bal", "https://picsum.photos/id/22/200/300" },
                    { 23, 4, "Tahin", "https://picsum.photos/id/23/200/300" },
                    { 24, 4, "Pekmez", "https://picsum.photos/id/24/200/300" },
                    { 25, 4, "Ekmek", "https://picsum.photos/id/25/200/300" },
                    { 26, 5, "Tuz Ruhu", "https://picsum.photos/id/26/200/300" },
                    { 27, 5, "Deterjan", "https://picsum.photos/id/27/200/300" },
                    { 28, 5, "Cam Sil", "https://picsum.photos/id/28/200/300" },
                    { 29, 5, "Yüzey Temizleyici", "https://picsum.photos/id/29/200/300" },
                    { 30, 5, "Sıvı Sabun", "https://picsum.photos/id/30/200/300" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "Admin", "Admin", new byte[] { 188, 70, 188, 100, 219, 117, 209, 31, 163, 26, 184, 51, 166, 147, 90, 63, 149, 47, 159, 148, 167, 205, 106, 8, 213, 93, 247, 189, 35, 59, 54, 164, 213, 203, 154, 178, 155, 103, 98, 204, 210, 15, 39, 57, 218, 224, 100, 124, 69, 52, 141, 209, 128, 172, 218, 126, 28, 48, 19, 147, 36, 64, 184, 110 }, new byte[] { 6, 231, 73, 25, 36, 247, 115, 123, 158, 41, 187, 193, 34, 75, 65, 52, 42, 102, 134, 96, 42, 245, 252, 3, 70, 73, 73, 0, 42, 8, 115, 196, 172, 36, 209, 130, 55, 132, 162, 229, 131, 254, 175, 96, 180, 63, 50, 81, 173, 255, 141, 204, 103, 244, 65, 89, 132, 70, 156, 152, 249, 89, 130, 116, 17, 211, 39, 176, 54, 134, 76, 201, 141, 7, 96, 185, 39, 222, 252, 211, 2, 209, 223, 158, 209, 193, 135, 157, 190, 59, 191, 178, 159, 113, 217, 109, 103, 5, 71, 221, 96, 251, 127, 40, 119, 110, 46, 203, 31, 104, 200, 72, 44, 235, 193, 68, 210, 59, 31, 152, 81, 152, 72, 89, 240, 66, 91, 157 }, 1 },
                    { 2, "14arslan.yusuf@gmail.com", "Yusuf", "Arslan", new byte[] { 188, 70, 188, 100, 219, 117, 209, 31, 163, 26, 184, 51, 166, 147, 90, 63, 149, 47, 159, 148, 167, 205, 106, 8, 213, 93, 247, 189, 35, 59, 54, 164, 213, 203, 154, 178, 155, 103, 98, 204, 210, 15, 39, 57, 218, 224, 100, 124, 69, 52, 141, 209, 128, 172, 218, 126, 28, 48, 19, 147, 36, 64, 184, 110 }, new byte[] { 6, 231, 73, 25, 36, 247, 115, 123, 158, 41, 187, 193, 34, 75, 65, 52, 42, 102, 134, 96, 42, 245, 252, 3, 70, 73, 73, 0, 42, 8, 115, 196, 172, 36, 209, 130, 55, 132, 162, 229, 131, 254, 175, 96, 180, 63, 50, 81, 173, 255, 141, 204, 103, 244, 65, 89, 132, 70, 156, 152, 249, 89, 130, 116, 17, 211, 39, 176, 54, 134, 76, 201, 141, 7, 96, 185, 39, 222, 252, 211, 2, 209, 223, 158, 209, 193, 135, 157, 190, 59, 191, 178, 159, 113, 217, 109, 103, 5, 71, 221, 96, 251, 127, 40, 119, 110, 46, 203, 31, 104, 200, 72, 44, 235, 193, 68, 210, 59, 31, 152, 81, 152, 72, 89, 240, 66, 91, 157 }, 2 },
                    { 3, "tech@career.com", "Tech", "Career", new byte[] { 188, 70, 188, 100, 219, 117, 209, 31, 163, 26, 184, 51, 166, 147, 90, 63, 149, 47, 159, 148, 167, 205, 106, 8, 213, 93, 247, 189, 35, 59, 54, 164, 213, 203, 154, 178, 155, 103, 98, 204, 210, 15, 39, 57, 218, 224, 100, 124, 69, 52, 141, 209, 128, 172, 218, 126, 28, 48, 19, 147, 36, 64, 184, 110 }, new byte[] { 6, 231, 73, 25, 36, 247, 115, 123, 158, 41, 187, 193, 34, 75, 65, 52, 42, 102, 134, 96, 42, 245, 252, 3, 70, 73, 73, 0, 42, 8, 115, 196, 172, 36, 209, 130, 55, 132, 162, 229, 131, 254, 175, 96, 180, 63, 50, 81, 173, 255, 141, 204, 103, 244, 65, 89, 132, 70, 156, 152, 249, 89, 130, 116, 17, 211, 39, 176, 54, 134, 76, 201, 141, 7, 96, 185, 39, 222, 252, 211, 2, 209, 223, 158, 209, 193, 135, 157, 190, 59, 191, 178, 159, 113, 217, 109, 103, 5, 71, 221, 96, 251, 127, 40, 119, 110, 46, 203, 31, 104, 200, 72, 44, 235, 193, 68, 210, 59, 31, 152, 81, 152, 72, 89, 240, 66, 91, 157 }, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedDate", "IsShopping", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(7699), false, "Yarın alınacaklar", 2 },
                    { 2, new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(7703), true, "Pazar gecesi sineması için alınacaklar", 2 },
                    { 3, new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(7704), true, "Aylık temizlik listesi", 2 },
                    { 4, new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(7705), false, "Bugün benim doğum günüm", 3 },
                    { 5, new DateTime(2022, 10, 19, 20, 12, 16, 636, DateTimeKind.Local).AddTicks(7706), true, "Bir çay delisinin istekleri", 3 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListDetails",
                columns: new[] { "Id", "Descripion", "IsBought", "ProductId", "ShoppingListId" },
                values: new object[,]
                {
                    { 1, "2 paket", true, 10, 1 },
                    { 2, "3 tane al. 2 tanesi beyaz paket, bir tanesi siyah", true, 15, 1 },
                    { 3, null, true, 22, 1 },
                    { 4, "Diğer marketten al", true, 23, 1 },
                    { 6, null, false, 15, 2 },
                    { 7, null, true, 16, 2 },
                    { 8, null, true, 17, 2 },
                    { 9, null, false, 18, 2 },
                    { 10, null, false, 19, 2 },
                    { 11, null, true, 14, 2 },
                    { 12, null, true, 10, 2 },
                    { 13, "2 lt den 2 adet", false, 26, 3 },
                    { 14, "KÜÇÜK PAKET DEĞİL BÜYÜK PAKETTEN OLACAK", false, 27, 3 },
                    { 15, null, false, 28, 3 },
                    { 16, "Bir tane yeter, mavi renkli bakkaldan alınacak", false, 29, 3 },
                    { 17, null, true, 9, 5 },
                    { 18, null, true, 10, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListDetails_ProductId",
                table: "ShoppingListDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListDetails_ShoppingListId",
                table: "ShoppingListDetails",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
