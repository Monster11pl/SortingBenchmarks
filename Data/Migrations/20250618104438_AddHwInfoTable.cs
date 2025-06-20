using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHwInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenchmarkHardwareInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OsUser = table.Column<string>(type: "TEXT", nullable: false),
                    Os = table.Column<string>(type: "TEXT", nullable: false),
                    SystemArchitecture = table.Column<string>(type: "TEXT", nullable: false),
                    ProcessorName = table.Column<string>(type: "TEXT", nullable: false),
                    CoresCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreadsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxClockSpeed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchmarkHardwareInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchmarkHardwareInfos");
        }
    }
}
