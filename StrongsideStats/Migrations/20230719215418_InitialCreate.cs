using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrongsideStats.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummonerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileIconId = table.Column<int>(type: "int", nullable: false),
                    RevisionDate = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummonerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummonerLevel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummonerEntity");
        }
    }
}
