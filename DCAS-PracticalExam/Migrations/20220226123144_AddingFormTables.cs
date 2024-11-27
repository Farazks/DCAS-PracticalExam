using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class AddingFormTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPRAssessmentEvaluationFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsStep1 = table.Column<int>(type: "int", nullable: false),
                    PointsStep2 = table.Column<int>(type: "int", nullable: false),
                    PointsStep3 = table.Column<int>(type: "int", nullable: false),
                    PointsStep4 = table.Column<int>(type: "int", nullable: false),
                    PointsStep5 = table.Column<int>(type: "int", nullable: false),
                    PointsStep6 = table.Column<int>(type: "int", nullable: false),
                    PointsStep7 = table.Column<int>(type: "int", nullable: false),
                    PointsStep8 = table.Column<int>(type: "int", nullable: false),
                    PointsStep9 = table.Column<int>(type: "int", nullable: false),
                    PointsStep10 = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    Assessor1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor1Sign = table.Column<byte>(type: "tinyint", nullable: false),
                    Assessor2Sign = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPRAssessmentEvaluationFields", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationInstructorsFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalQualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question1Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question1Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question2Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question2Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question3Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question3Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question4Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question4Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question5Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question5Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question6Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question6Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question7Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question7Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question8Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question8Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question9Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question10Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminerSign = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationInstructorsFields", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAssessmentEvaluationFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsStep1 = table.Column<int>(type: "int", nullable: false),
                    PointsStep2 = table.Column<int>(type: "int", nullable: false),
                    PointsStep3 = table.Column<int>(type: "int", nullable: false),
                    PointsStep4 = table.Column<int>(type: "int", nullable: false),
                    PointsStep5 = table.Column<int>(type: "int", nullable: false),
                    PointsStep6 = table.Column<int>(type: "int", nullable: false),
                    PointsStep7 = table.Column<int>(type: "int", nullable: false),
                    PointsStep8 = table.Column<int>(type: "int", nullable: false),
                    PointsStep9 = table.Column<int>(type: "int", nullable: false),
                    PointsStep10 = table.Column<int>(type: "int", nullable: false),
                    PointsStep11 = table.Column<int>(type: "int", nullable: false),
                    PointsStep12 = table.Column<int>(type: "int", nullable: false),
                    PointsStep13 = table.Column<int>(type: "int", nullable: false),
                    PointsStep14 = table.Column<int>(type: "int", nullable: false),
                    PointsStep15 = table.Column<int>(type: "int", nullable: false),
                    PointsStep16 = table.Column<int>(type: "int", nullable: false),
                    PointsStep17 = table.Column<int>(type: "int", nullable: false),
                    PointsStep18 = table.Column<int>(type: "int", nullable: false),
                    PointsStep19 = table.Column<int>(type: "int", nullable: false),
                    PointsStep20 = table.Column<int>(type: "int", nullable: false),
                    PointsStep21 = table.Column<int>(type: "int", nullable: false),
                    PointsStep22 = table.Column<int>(type: "int", nullable: false),
                    PointsStep23 = table.Column<int>(type: "int", nullable: false),
                    PointsStep24 = table.Column<int>(type: "int", nullable: false),
                    PointsStep25 = table.Column<int>(type: "int", nullable: false),
                    PointsStep26 = table.Column<int>(type: "int", nullable: false),
                    PointsStep27 = table.Column<int>(type: "int", nullable: false),
                    CriteriaCheck1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    TotalPossiblePoints = table.Column<int>(type: "int", nullable: false),
                    Assessor1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor1Sign = table.Column<byte>(type: "tinyint", nullable: false),
                    Assessor2Sign = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAssessmentEvaluationFields", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TraumaAssessmentEvaluationFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsStep1 = table.Column<int>(type: "int", nullable: false),
                    PointsStep2 = table.Column<int>(type: "int", nullable: false),
                    PointsStep3 = table.Column<int>(type: "int", nullable: false),
                    PointsStep4 = table.Column<int>(type: "int", nullable: false),
                    PointsStep5 = table.Column<int>(type: "int", nullable: false),
                    PointsStep6 = table.Column<int>(type: "int", nullable: false),
                    PointsStep7 = table.Column<int>(type: "int", nullable: false),
                    PointsStep8 = table.Column<int>(type: "int", nullable: false),
                    PointsStep9 = table.Column<int>(type: "int", nullable: false),
                    PointsStep10 = table.Column<int>(type: "int", nullable: false),
                    PointsStep11 = table.Column<int>(type: "int", nullable: false),
                    PointsStep12 = table.Column<int>(type: "int", nullable: false),
                    PointsStep13 = table.Column<int>(type: "int", nullable: false),
                    PointsStep14 = table.Column<int>(type: "int", nullable: false),
                    PointsStep15 = table.Column<int>(type: "int", nullable: false),
                    PointsStep16 = table.Column<int>(type: "int", nullable: false),
                    PointsStep17 = table.Column<int>(type: "int", nullable: false),
                    PointsStep18 = table.Column<int>(type: "int", nullable: false),
                    PointsStep19 = table.Column<int>(type: "int", nullable: false),
                    PointsStep20 = table.Column<int>(type: "int", nullable: false),
                    PointsStep21 = table.Column<int>(type: "int", nullable: false),
                    PointsStep22 = table.Column<int>(type: "int", nullable: false),
                    PointsStep23 = table.Column<int>(type: "int", nullable: false),
                    PointsStep24 = table.Column<int>(type: "int", nullable: false),
                    PointsStep25 = table.Column<int>(type: "int", nullable: false),
                    PointsStep26 = table.Column<int>(type: "int", nullable: false),
                    PointsStep27 = table.Column<int>(type: "int", nullable: false),
                    PointsStep28 = table.Column<int>(type: "int", nullable: false),
                    PointsStep29 = table.Column<int>(type: "int", nullable: false),
                    PointsStep30 = table.Column<int>(type: "int", nullable: false),
                    PointsStep31 = table.Column<int>(type: "int", nullable: false),
                    PointsStep32 = table.Column<int>(type: "int", nullable: false),
                    PointsStep33 = table.Column<int>(type: "int", nullable: false),
                    PointsStep34 = table.Column<int>(type: "int", nullable: false),
                    PointsStep35 = table.Column<int>(type: "int", nullable: false),
                    PointsStep36 = table.Column<int>(type: "int", nullable: false),
                    PointsStep37 = table.Column<int>(type: "int", nullable: false),
                    PointsStep38 = table.Column<int>(type: "int", nullable: false),
                    PointsStep39 = table.Column<int>(type: "int", nullable: false),
                    PointsStep40 = table.Column<int>(type: "int", nullable: false),
                    CriteriaCheck1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriteriaCheck8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    TotalPossiblePoints = table.Column<int>(type: "int", nullable: false),
                    Assessor1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessor1Sign = table.Column<byte>(type: "tinyint", nullable: false),
                    Assessor2Sign = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraumaAssessmentEvaluationFields", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPRAssessmentEvaluationFields");

            migrationBuilder.DropTable(
                name: "EvaluationInstructorsFields");

            migrationBuilder.DropTable(
                name: "MedicalAssessmentEvaluationFields");

            migrationBuilder.DropTable(
                name: "TraumaAssessmentEvaluationFields");
        }
    }
}
