using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationHolderEmail",
                table: "Loan_Applications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApplicationHolderEmail",
                table: "Loan_Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
