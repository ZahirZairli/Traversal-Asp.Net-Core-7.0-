using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigCommentDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Testimonials",
                newName: "TestimonialId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubAbouts",
                newName: "SubAboutId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NewsLetters",
                newName: "NewsLetterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Guides",
                newName: "GuideId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Features",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Destinations",
                newName: "DestinationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Abouts",
                newName: "AboutId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "About2s",
                newName: "About2Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DestinationId",
                table: "Comments",
                column: "DestinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.RenameColumn(
                name: "TestimonialId",
                table: "Testimonials",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubAboutId",
                table: "SubAbouts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NewsLetterId",
                table: "NewsLetters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "Guides",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "Features",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Destinations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AboutId",
                table: "Abouts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "About2Id",
                table: "About2s",
                newName: "Id");
        }
    }
}
