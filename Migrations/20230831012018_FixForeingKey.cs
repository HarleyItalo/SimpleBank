using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBank.Migrations
{
    /// <inheritdoc />
    public partial class FixForeingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountAccoutId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountAccoutId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountAccoutId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccoutId",
                table: "Transactions",
                column: "AccoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccoutId",
                table: "Transactions",
                column: "AccoutId",
                principalTable: "Accounts",
                principalColumn: "AccoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccoutId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccoutId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "AccountAccoutId",
                table: "Transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountAccoutId",
                table: "Transactions",
                column: "AccountAccoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountAccoutId",
                table: "Transactions",
                column: "AccountAccoutId",
                principalTable: "Accounts",
                principalColumn: "AccoutId");
        }
    }
}
