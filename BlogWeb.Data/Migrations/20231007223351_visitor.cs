using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWeb.Data.Migrations
{
    public partial class visitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "articles",
                keyColumn: "Id",
                keyValue: new Guid("194841ff-7ff6-4938-a80f-c158dbee8be2"));

            migrationBuilder.DeleteData(
                table: "articles",
                keyColumn: "Id",
                keyValue: new Guid("2ebf1ac4-01c6-4ce5-a7ce-a3bb3fd9733d"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1abf6077-198e-40f0-9701-4bb4b89ee057"),
                column: "ConcurrencyStamp",
                value: "eb770dc2-da76-42d7-bfc6-4afae3264d47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("306d6673-3821-4774-8946-7451e9ddbf40"),
                column: "ConcurrencyStamp",
                value: "fc6fb152-2d05-4b1c-8290-25ba8f932e98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff2d597c-fe16-4bff-a659-07d9a0c0bfa8"),
                column: "ConcurrencyStamp",
                value: "139ae772-4a87-4b44-bdf0-adf7f73e7786");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2251144b-5b3f-45e9-8297-10850635ba43"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c1eaae-1750-40c6-9bb3-afffda25ccd8", "AQAAAAEAACcQAAAAEGAyYgI1MuDJk2JDSSMi+3/yIBaRm5MRyhv/2n9CzbfN7/tjIK1R3dB/dFn+8uPZfw==", "d0201bb4-f8bd-461a-a742-aee1f7f32243" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6de21c5e-6c86-4912-ab4d-5411b56657f2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f56bd8a-9e35-4b23-8b7e-1bc9e4ea48d7", "AQAAAAEAACcQAAAAEBkX1JcwmY6S2wV2yiFyP0y07dihUl4uYTSbP84MT0muHR173CPqGBr2hIhxAb4Ivg==", "96641886-cb17-47c7-b3ea-ec9f60ae5f71" });

            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5be1655a-e496-491d-90cb-64b0c67929b2"), new Guid("983d6afc-b1df-4677-bace-bb9ddb4415de"), "uuuuuuuuuuuuoooooooooooo", "Admin Test", new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(832), null, null, new Guid("553df9b1-7c6f-42d5-8335-70bdda4dff40"), false, null, null, "Visual Studio makalesi 1", new Guid("2251144b-5b3f-45e9-8297-10850635ba43"), 15 },
                    { new Guid("e8f2b331-3602-45c2-9e70-4260076c965d"), new Guid("f4effd4c-7459-4e96-a759-090acc20a572"), "asuhfşısafashfpashfasıufhasıpfgasfasfasfasf", "Admin Test", new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(819), null, null, new Guid("944bd0c6-864b-4148-b771-270b7391aea0"), false, null, null, "Deneme makalesi 1", new Guid("6de21c5e-6c86-4912-ab4d-5411b56657f2"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("983d6afc-b1df-4677-bace-bb9ddb4415de"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("f4effd4c-7459-4e96-a759-090acc20a572"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "images",
                keyColumn: "Id",
                keyValue: new Guid("553df9b1-7c6f-42d5-8335-70bdda4dff40"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "images",
                keyColumn: "Id",
                keyValue: new Guid("944bd0c6-864b-4148-b771-270b7391aea0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 33, 51, 175, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "articles",
                keyColumn: "Id",
                keyValue: new Guid("5be1655a-e496-491d-90cb-64b0c67929b2"));

            migrationBuilder.DeleteData(
                table: "articles",
                keyColumn: "Id",
                keyValue: new Guid("e8f2b331-3602-45c2-9e70-4260076c965d"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1abf6077-198e-40f0-9701-4bb4b89ee057"),
                column: "ConcurrencyStamp",
                value: "127ac848-1217-4170-bc42-cc5e7a4fcf66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("306d6673-3821-4774-8946-7451e9ddbf40"),
                column: "ConcurrencyStamp",
                value: "5fa9181b-0d2f-4b6c-b290-fcb978e9e486");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff2d597c-fe16-4bff-a659-07d9a0c0bfa8"),
                column: "ConcurrencyStamp",
                value: "d2c7df8a-605e-497e-9e74-45958963f6d3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2251144b-5b3f-45e9-8297-10850635ba43"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "348e335b-da4b-45c7-b5fb-97bdc2c6b04d", "AQAAAAEAACcQAAAAEHJP/Jd77eO24Qwn6+DKux8Fh0NG7eL5tzZFQCk4wVJPzqHwvxmCzgUq5pGM7QlBFA==", "40a4777a-5266-45af-8997-114be3ec2773" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6de21c5e-6c86-4912-ab4d-5411b56657f2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd8dc595-820b-4d1c-a637-cf0466b5a890", "AQAAAAEAACcQAAAAEBSwVgrRH/mTSuAv+UHeUXa0RjCRDY2CbGusCdgaxUxJPFAgrVmrutQXZ6ejYhYWvQ==", "4797e23c-8f03-4f88-a54e-7bde07eb0d62" });

            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("194841ff-7ff6-4938-a80f-c158dbee8be2"), new Guid("983d6afc-b1df-4677-bace-bb9ddb4415de"), "uuuuuuuuuuuuoooooooooooo", "Admin Test", new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(6863), null, null, new Guid("553df9b1-7c6f-42d5-8335-70bdda4dff40"), false, null, null, "Visual Studio makalesi 1", new Guid("2251144b-5b3f-45e9-8297-10850635ba43"), 15 },
                    { new Guid("2ebf1ac4-01c6-4ce5-a7ce-a3bb3fd9733d"), new Guid("f4effd4c-7459-4e96-a759-090acc20a572"), "asuhfşısafashfpashfasıufhasıpfgasfasfasfasf", "Admin Test", new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(6850), null, null, new Guid("944bd0c6-864b-4148-b771-270b7391aea0"), false, null, null, "Deneme makalesi 1", new Guid("6de21c5e-6c86-4912-ab4d-5411b56657f2"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("983d6afc-b1df-4677-bace-bb9ddb4415de"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("f4effd4c-7459-4e96-a759-090acc20a572"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "images",
                keyColumn: "Id",
                keyValue: new Guid("553df9b1-7c6f-42d5-8335-70bdda4dff40"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "images",
                keyColumn: "Id",
                keyValue: new Guid("944bd0c6-864b-4148-b771-270b7391aea0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 1, 24, 57, 29, DateTimeKind.Local).AddTicks(7290));
        }
    }
}
