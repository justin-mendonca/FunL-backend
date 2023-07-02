using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunL_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaWithFlattenedStreamingInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StreamingPlatforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserTitles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    StreamingServiceInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitles", x => new { x.UserId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_UserTitles_StreamingServiceInfos_StreamingServiceInfoId",
                        column: x => x.StreamingServiceInfoId,
                        principalTable: "StreamingServiceInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTitles_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTitles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTitles_StreamingServiceInfoId",
                table: "UserTitles",
                column: "StreamingServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitles_TitleId",
                table: "UserTitles",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTitles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StreamingPlatforms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
