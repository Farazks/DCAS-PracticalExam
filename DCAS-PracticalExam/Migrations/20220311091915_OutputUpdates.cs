using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class OutputUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "TotalPossiblePoints",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "TotalPossiblePoints",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AwardedPoints",
                table: "CPRAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "CPRAssessmentEvaluationFields");

            migrationBuilder.AddColumn<string>(
                name: "CRMRequest",
                table: "TraumaAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "TraumaAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentName",
                table: "TraumaAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CRMRequest",
                table: "MedicalAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "MedicalAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentName",
                table: "MedicalAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CRMRequest",
                table: "EvaluationInstructorsFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "EvaluationInstructorsFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentName",
                table: "EvaluationInstructorsFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CRMRequest",
                table: "CPRAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "CPRAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentName",
                table: "CPRAssessmentEvaluationFields",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRMRequest",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EstablishmentName",
                table: "TraumaAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "CRMRequest",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EstablishmentName",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "CRMRequest",
                table: "EvaluationInstructorsFields");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "EvaluationInstructorsFields");

            migrationBuilder.DropColumn(
                name: "EstablishmentName",
                table: "EvaluationInstructorsFields");

            migrationBuilder.DropColumn(
                name: "CRMRequest",
                table: "CPRAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "CPRAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EstablishmentName",
                table: "CPRAssessmentEvaluationFields");

            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "TraumaAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPossiblePoints",
                table: "TraumaAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "MedicalAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPossiblePoints",
                table: "MedicalAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwardedPoints",
                table: "CPRAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "CPRAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
