using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHwInfoTableConenction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA foreign_keys = OFF;");
            
            migrationBuilder.DropColumn(
                name: "Cpu",
                table: "Benchmarks");

            migrationBuilder.AddColumn<int>(
                name: "BenchmarkHardwareInfoId",
                table: "Benchmarks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.CreateIndex(
                name: "IX_Benchmarks_BenchmarkHardwareInfoId",
                table: "Benchmarks",
                column: "BenchmarkHardwareInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benchmarks_BenchmarkHardwareInfos_BenchmarkHardwareInfoId",
                table: "Benchmarks",
                column: "BenchmarkHardwareInfoId",
                principalTable: "BenchmarkHardwareInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benchmarks_BenchmarkHardwareInfos_BenchmarkHardwareInfoId",
                table: "Benchmarks");
            
            migrationBuilder.DropIndex(
                name: "IX_Benchmarks_BenchmarkHardwareInfoId",
                table: "Benchmarks");

            migrationBuilder.DropColumn(
                name: "BenchmarkHardwareInfoId",
                table: "Benchmarks");

            migrationBuilder.AddColumn<string>(
                name: "Cpu",
                table: "Benchmarks",
                type: "TEXT",
                nullable: true);
        }
    }
}
