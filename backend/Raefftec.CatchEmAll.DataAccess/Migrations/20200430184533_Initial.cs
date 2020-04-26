using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raefftec.CatchEmAll.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<long>(nullable: false),
                    ArticleInfo_Name = table.Column<string>(maxLength: 100, nullable: true),
                    ArticleInfo_Created = table.Column<DateTimeOffset>(nullable: true),
                    ArticleInfo_Ends = table.Column<DateTimeOffset>(nullable: true),
                    ArticleInfo_IsClosed = table.Column<bool>(nullable: true),
                    ArticleInfo_IsSold = table.Column<bool>(nullable: true),
                    PriceInfo_BidPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    PriceInfo_PurchasePrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    PriceInfo_FinalPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    UpdateInfo_Updated = table.Column<DateTimeOffset>(nullable: true),
                    UpdateInfo_IsLocked = table.Column<bool>(nullable: true),
                    UpdateInfo_NumberOfFailures = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchQueries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UpdateInfo_Updated = table.Column<DateTimeOffset>(nullable: true),
                    UpdateInfo_IsLocked = table.Column<bool>(nullable: true),
                    UpdateInfo_NumberOfFailures = table.Column<int>(nullable: true),
                    Criteria_WithAllTheseWords = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchQueries_UserReferences_UserId",
                        column: x => x.UserId,
                        principalTable: "UserReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QueryId = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchResults_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchResults_SearchQueries_QueryId",
                        column: x => x.QueryId,
                        principalTable: "SearchQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ExternalId",
                table: "Articles",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SearchQueries_UserId",
                table: "SearchQueries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_ArticleId",
                table: "SearchResults",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_QueryId",
                table: "SearchResults",
                column: "QueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchResults");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "SearchQueries");

            migrationBuilder.DropTable(
                name: "UserReferences");
        }
    }
}
