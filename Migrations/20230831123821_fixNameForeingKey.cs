using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBank.Migrations
{
    /// <inheritdoc />
    public partial class fixNameForeingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccoutId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "AccoutId",
                table: "Transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccoutId",
                table: "Transactions",
                newName: "IX_Transactions_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transactions",
                newName: "AccoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                newName: "IX_Transactions_AccoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccoutId",
                table: "Transactions",
                column: "AccoutId",
                principalTable: "Accounts",
                principalColumn: "AccoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
