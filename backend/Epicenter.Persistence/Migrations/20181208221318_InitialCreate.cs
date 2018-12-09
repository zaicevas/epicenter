using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Epicenter.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissingModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Reason = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FaceAPIID = table.Column<string>(nullable: true),
                    NumberPlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Timestamps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAndTime = table.Column<string>(nullable: true),
                    MissingModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timestamps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Timestamps_MissingModels_MissingModelID",
                        column: x => x.MissingModelID,
                        principalTable: "MissingModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timestamps_MissingModelID",
                table: "Timestamps",
                column: "MissingModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timestamps");

            migrationBuilder.DropTable(
                name: "MissingModels");
        }
    }
}
