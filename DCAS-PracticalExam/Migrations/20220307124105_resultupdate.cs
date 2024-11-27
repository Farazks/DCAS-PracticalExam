using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class resultupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "TraumaAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "MedicalAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "CPRAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "CPRAssessmentEvaluationFields");
        }
    }
}
