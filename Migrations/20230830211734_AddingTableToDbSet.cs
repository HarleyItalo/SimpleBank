using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBank.Migrations
{
    /// <inheritdoc />
    public partial class AddingTableToDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_AccountAccoutId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountAccoutId",
                table: "Transactions",
                newName: "IX_Transactions_AccountAccoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountAccoutId",
                table: "Transactions",
                column: "AccountAccoutId",
                principalTable: "Accounts",
                principalColumn: "AccoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountAccoutId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountAccoutId",
                table: "Transaction",
                newName: "IX_Transaction_AccountAccoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Accounts_AccountAccoutId",
                table: "Transaction",
                column: "AccountAccoutId",
                principalTable: "Accounts",
                principalColumn: "AccoutId");
        }
    }
}
