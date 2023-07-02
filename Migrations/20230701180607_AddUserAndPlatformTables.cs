using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunL_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndPlatformTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenre_Genre_GenreId",
                table: "TitleGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "StreamingInfo",
                table: "Titles");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StreamingPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreamingServiceInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudiosJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableSince = table.Column<int>(type: "int", nullable: true),
                    Leaving = table.Column<long>(type: "bigint", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitlesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    StreamingPlatformId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingServiceInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StreamingServiceInfos_StreamingPlatforms_StreamingPlatformId",
                        column: x => x.StreamingPlatformId,
                        principalTable: "StreamingPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StreamingServiceInfos_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStreamingPlatforms",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StreamingPlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStreamingPlatforms", x => new { x.UserId, x.StreamingPlatformId });
                    table.ForeignKey(
                        name: "FK_UserStreamingPlatforms_StreamingPlatforms_StreamingPlatformId",
                        column: x => x.StreamingPlatformId,
                        principalTable: "StreamingPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStreamingPlatforms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreamingServiceInfos_StreamingPlatformId",
                table: "StreamingServiceInfos",
                column: "StreamingPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingServiceInfos_TitleId",
                table: "StreamingServiceInfos",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStreamingPlatforms_StreamingPlatformId",
                table: "UserStreamingPlatforms",
                column: "StreamingPlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenre_Genres_GenreId",
                table: "TitleGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenre_Genres_GenreId",
                table: "TitleGenre");

            migrationBuilder.DropTable(
                name: "StreamingServiceInfos");

            migrationBuilder.DropTable(
                name: "UserStreamingPlatforms");

            migrationBuilder.DropTable(
                name: "StreamingPlatforms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "StreamingInfo",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenre_Genre_GenreId",
                table: "TitleGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
