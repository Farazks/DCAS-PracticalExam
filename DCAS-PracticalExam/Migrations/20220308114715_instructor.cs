using Microsoft.EntityFrameworkCore.Migrations;

namespace DCAS_PracticalExam.Migrations
{
    public partial class instructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assessor1",
                table: "EvaluationInstructorsFields",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assessor1",
                table: "EvaluationInstructorsFields");
        }
    }
}
