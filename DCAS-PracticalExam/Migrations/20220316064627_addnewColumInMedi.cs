using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class addnewColumInMedi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergicReaction6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental7",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteredMental8",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Behavioral1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Behavioral2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Behavioral3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Behavioral4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Behavioral5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cardiac7",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnvironmentalEmergency1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnvironmentalEmergency2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnvironmentalEmergency3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnvironmentalEmergency4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnvironmentalEmergency5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstetrics7",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoisoningOverdose7",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory1",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory2",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory3",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory4",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory5",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory6",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RespiRespiratory7",
                table: "MedicalAssessmentEvaluationFields",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergicReaction1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AllergicReaction2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AllergicReaction3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AllergicReaction4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AllergicReaction5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AllergicReaction6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental7",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "AlteredMental8",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Behavioral1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Behavioral2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Behavioral3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Behavioral4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Behavioral5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Cardiac7",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EnvironmentalEmergency1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EnvironmentalEmergency2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EnvironmentalEmergency3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EnvironmentalEmergency4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "EnvironmentalEmergency5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "Obstetrics7",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "PoisoningOverdose7",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory1",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory2",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory3",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory4",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory5",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory6",
                table: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropColumn(
                name: "RespiRespiratory7",
                table: "MedicalAssessmentEvaluationFields");
        }
    }
}
