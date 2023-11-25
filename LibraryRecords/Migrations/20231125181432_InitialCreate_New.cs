using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryRecords.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryTransactions_Persons_PersonId",
                table: "LibraryTransactions");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_LibraryTransactions_PersonId",
                table: "LibraryTransactions");

            migrationBuilder.RenameColumn(
                name: "PenaltyAmount",
                table: "LibraryTransactions",
                newName: "LateFee");

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "LibraryTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LibraryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "LibraryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TCKN",
                table: "LibraryTransactions",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "LibraryTransactions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LibraryTransactions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "LibraryTransactions");

            migrationBuilder.DropColumn(
                name: "TCKN",
                table: "LibraryTransactions");

            migrationBuilder.RenameColumn(
                name: "LateFee",
                table: "LibraryTransactions",
                newName: "PenaltyAmount");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCKN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryTransactions_PersonId",
                table: "LibraryTransactions",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryTransactions_Persons_PersonId",
                table: "LibraryTransactions",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
