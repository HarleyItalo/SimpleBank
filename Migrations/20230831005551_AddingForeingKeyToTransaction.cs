using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBank.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeingKeyToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccoutId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccoutId",
                table: "Transactions");
        }
    }
}
