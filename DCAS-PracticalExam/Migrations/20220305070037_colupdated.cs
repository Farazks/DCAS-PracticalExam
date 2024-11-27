using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class colupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwardedPoints",
                table: "CPRAssessmentEvaluationFields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardedPoints",
                table: "CPRAssessmentEvaluationFields");
        }
    }
}
