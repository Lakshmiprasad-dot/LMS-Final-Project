using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loan_Types",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Details = table.Column<string>(type: "varchar(500)", nullable: false),
                    MinimumAmount = table.Column<int>(nullable: false),
                    MaximumAmount = table.Column<int>(nullable: false),
                    LoanGivenTo = table.Column<string>(nullable: false),
                    NumberOfGuaranters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Types", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "Loan_Applications",
                columns: table => new
                {
                    LoanApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationHolderName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountNumber = table.Column<int>(maxLength: 16, nullable: false),
                    ApplicationHolderEmail = table.Column<int>(nullable: false),
                    IfscCode = table.Column<string>(maxLength: 20, nullable: false),
                    LoanAmount = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Applications", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_Loan_Applications_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan_Eligibility_Criteria",
                columns: table => new
                {
                    LoanEligibilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeLimit = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    TypeOfEmployment = table.Column<string>(nullable: false),
                    MonthlyIncome = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Eligibility_Criteria", x => x.LoanEligibilityId);
                    table.ForeignKey(
                        name: "FK_Loan_Eligibility_Criteria_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rate_Of_Interests",
                columns: table => new
                {
                    RateOfInterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount1 = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate_Of_Interests", x => x.RateOfInterestId);
                    table.ForeignKey(
                        name: "FK_Rate_Of_Interests_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan_Applications_Status",
                columns: table => new
                {
                    AplicationStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    LoanApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Applications_Status", x => x.AplicationStatusId);
                    table.ForeignKey(
                        name: "FK_Loan_Applications_Status_Loan_Applications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loan_Applications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_LoanId",
                table: "Loan_Applications",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_Status_LoanApplicationId",
                table: "Loan_Applications_Status",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Eligibility_Criteria_LoanId",
                table: "Loan_Eligibility_Criteria",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_Of_Interests_LoanId",
                table: "Rate_Of_Interests",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan_Applications_Status");

            migrationBuilder.DropTable(
                name: "Loan_Eligibility_Criteria");

            migrationBuilder.DropTable(
                name: "Rate_Of_Interests");

            migrationBuilder.DropTable(
                name: "Loan_Applications");

            migrationBuilder.DropTable(
                name: "Loan_Types");
        }
    }
}
