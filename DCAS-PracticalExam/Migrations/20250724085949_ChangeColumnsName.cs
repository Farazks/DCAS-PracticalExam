using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class ChangeColumnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Assessor2Sign",
                table: "TraumaAssessmentEvaluationFields",
                newName: "MonitorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor2",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Monitor");

            migrationBuilder.RenameColumn(
                name: "Assessor1Sign",
                table: "TraumaAssessmentEvaluationFields",
                newName: "AssessorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor1",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Assessor");

            migrationBuilder.RenameColumn(
                name: "Assessor2Sign",
                table: "MedicalAssessmentEvaluationFields",
                newName: "MonitorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor2",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Monitor");

            migrationBuilder.RenameColumn(
                name: "Assessor1Sign",
                table: "MedicalAssessmentEvaluationFields",
                newName: "AssessorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor1",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Assessor");

            migrationBuilder.RenameColumn(
                name: "Assessor1",
                table: "EvaluationInstructorsFields",
                newName: "Assessor");

            migrationBuilder.RenameColumn(
                name: "Assessor2Sign",
                table: "CPRAssessmentEvaluationFields",
                newName: "MonitorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor2",
                table: "CPRAssessmentEvaluationFields",
                newName: "Monitor");

            migrationBuilder.RenameColumn(
                name: "Assessor1Sign",
                table: "CPRAssessmentEvaluationFields",
                newName: "AssessorSign");

            migrationBuilder.RenameColumn(
                name: "Assessor1",
                table: "CPRAssessmentEvaluationFields",
                newName: "Assessor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonitorSign",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Assessor2Sign");

            migrationBuilder.RenameColumn(
                name: "Monitor",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Assessor2");

            migrationBuilder.RenameColumn(
                name: "AssessorSign",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Assessor1Sign");

            migrationBuilder.RenameColumn(
                name: "Assessor",
                table: "TraumaAssessmentEvaluationFields",
                newName: "Assessor1");

            migrationBuilder.RenameColumn(
                name: "MonitorSign",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Assessor2Sign");

            migrationBuilder.RenameColumn(
                name: "Monitor",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Assessor2");

            migrationBuilder.RenameColumn(
                name: "AssessorSign",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Assessor1Sign");

            migrationBuilder.RenameColumn(
                name: "Assessor",
                table: "MedicalAssessmentEvaluationFields",
                newName: "Assessor1");

            migrationBuilder.RenameColumn(
                name: "Assessor",
                table: "EvaluationInstructorsFields",
                newName: "Assessor1");

            migrationBuilder.RenameColumn(
                name: "MonitorSign",
                table: "CPRAssessmentEvaluationFields",
                newName: "Assessor2Sign");

            migrationBuilder.RenameColumn(
                name: "Monitor",
                table: "CPRAssessmentEvaluationFields",
                newName: "Assessor2");

            migrationBuilder.RenameColumn(
                name: "AssessorSign",
                table: "CPRAssessmentEvaluationFields",
                newName: "Assessor1Sign");

            migrationBuilder.RenameColumn(
                name: "Assessor",
                table: "CPRAssessmentEvaluationFields",
                newName: "Assessor1");
        }
    }
}
