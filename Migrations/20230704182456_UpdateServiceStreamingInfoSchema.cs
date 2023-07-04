using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunL_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceStreamingInfoSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubtitlesJson",
                table: "StreamingServiceInfos",
                newName: "Subtitles");

            migrationBuilder.RenameColumn(
                name: "AudiosJson",
                table: "StreamingServiceInfos",
                newName: "Audios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subtitles",
                table: "StreamingServiceInfos",
                newName: "SubtitlesJson");

            migrationBuilder.RenameColumn(
                name: "Audios",
                table: "StreamingServiceInfos",
                newName: "AudiosJson");
        }
    }
}
