using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuchverkaufBinder.Migrations
{
    /// <inheritdoc />
    public partial class imagesourceurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSourceUrl",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSourceUrl",
                table: "Books");
        }
    }
}
