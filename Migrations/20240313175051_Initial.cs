using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxNumOfAnimals = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    EnclosureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "MaxNumOfAnimals", "Name" },
                values: new object[] { -6, 500, "First Enclosure" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { -13, 3, "bumblebee" },
                    { -12, 3, "ladybug" },
                    { -11, 5, "startfish" },
                    { -10, 5, "octopus" },
                    { -9, 4, "seahorse" },
                    { -8, 4, "jellyfish" },
                    { -7, 1, "tortoise" },
                    { -6, 1, "python" },
                    { -5, 2, "swan" },
                    { -4, 2, "eagle" },
                    { -3, 0, "hippo" },
                    { -2, 0, "giraffe" },
                    { -1, 0, "lion" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -130, -6, "bumblebee-131", 0, -13 },
                    { -129, -6, "bumblebee-130", 1, -13 },
                    { -128, -6, "bumblebee-129", 0, -13 },
                    { -127, -6, "bumblebee-128", 0, -13 },
                    { -126, -6, "bumblebee-127", 1, -13 },
                    { -125, -6, "bumblebee-126", 0, -13 },
                    { -124, -6, "bumblebee-125", 0, -13 },
                    { -123, -6, "bumblebee-124", 0, -13 },
                    { -122, -6, "bumblebee-123", 0, -13 },
                    { -121, -6, "bumblebee-122", 1, -13 },
                    { -120, -6, "ladybug-121", 0, -12 },
                    { -119, -6, "ladybug-120", 0, -12 },
                    { -118, -6, "ladybug-119", 1, -12 },
                    { -117, -6, "ladybug-118", 1, -12 },
                    { -116, -6, "ladybug-117", 0, -12 },
                    { -115, -6, "ladybug-116", 0, -12 },
                    { -114, -6, "ladybug-115", 0, -12 },
                    { -113, -6, "ladybug-114", 1, -12 },
                    { -112, -6, "ladybug-113", 1, -12 },
                    { -111, -6, "ladybug-112", 0, -12 },
                    { -110, -6, "startfish-111", 0, -11 },
                    { -109, -6, "startfish-110", 0, -11 },
                    { -108, -6, "startfish-109", 1, -11 },
                    { -107, -6, "startfish-108", 1, -11 },
                    { -106, -6, "startfish-107", 0, -11 },
                    { -105, -6, "startfish-106", 1, -11 },
                    { -104, -6, "startfish-105", 1, -11 },
                    { -103, -6, "startfish-104", 0, -11 },
                    { -102, -6, "startfish-103", 1, -11 },
                    { -101, -6, "startfish-102", 0, -11 },
                    { -100, -6, "octopus-101", 1, -10 },
                    { -99, -6, "octopus-100", 1, -10 },
                    { -98, -6, "octopus-99", 1, -10 },
                    { -97, -6, "octopus-98", 1, -10 },
                    { -96, -6, "octopus-97", 1, -10 },
                    { -95, -6, "octopus-96", 0, -10 },
                    { -94, -6, "octopus-95", 0, -10 },
                    { -93, -6, "octopus-94", 0, -10 },
                    { -92, -6, "octopus-93", 0, -10 },
                    { -91, -6, "octopus-92", 0, -10 },
                    { -90, -6, "seahorse-91", 1, -9 },
                    { -89, -6, "seahorse-90", 0, -9 },
                    { -88, -6, "seahorse-89", 1, -9 },
                    { -87, -6, "seahorse-88", 0, -9 },
                    { -86, -6, "seahorse-87", 1, -9 },
                    { -85, -6, "seahorse-86", 1, -9 },
                    { -84, -6, "seahorse-85", 1, -9 },
                    { -83, -6, "seahorse-84", 0, -9 },
                    { -82, -6, "seahorse-83", 1, -9 },
                    { -81, -6, "seahorse-82", 1, -9 },
                    { -80, -6, "jellyfish-81", 1, -8 },
                    { -79, -6, "jellyfish-80", 1, -8 },
                    { -78, -6, "jellyfish-79", 1, -8 },
                    { -77, -6, "jellyfish-78", 0, -8 },
                    { -76, -6, "jellyfish-77", 1, -8 },
                    { -75, -6, "jellyfish-76", 0, -8 },
                    { -74, -6, "jellyfish-75", 0, -8 },
                    { -73, -6, "jellyfish-74", 1, -8 },
                    { -72, -6, "jellyfish-73", 1, -8 },
                    { -71, -6, "jellyfish-72", 1, -8 },
                    { -70, -6, "tortoise-71", 0, -7 },
                    { -69, -6, "tortoise-70", 1, -7 },
                    { -68, -6, "tortoise-69", 1, -7 },
                    { -67, -6, "tortoise-68", 1, -7 },
                    { -66, -6, "tortoise-67", 1, -7 },
                    { -65, -6, "tortoise-66", 0, -7 },
                    { -64, -6, "tortoise-65", 0, -7 },
                    { -63, -6, "tortoise-64", 1, -7 },
                    { -62, -6, "tortoise-63", 1, -7 },
                    { -61, -6, "tortoise-62", 1, -7 },
                    { -60, -6, "python-61", 0, -6 },
                    { -59, -6, "python-60", 0, -6 },
                    { -58, -6, "python-59", 1, -6 },
                    { -57, -6, "python-58", 1, -6 },
                    { -56, -6, "python-57", 0, -6 },
                    { -55, -6, "python-56", 1, -6 },
                    { -54, -6, "python-55", 0, -6 },
                    { -53, -6, "python-54", 1, -6 },
                    { -52, -6, "python-53", 1, -6 },
                    { -51, -6, "python-52", 1, -6 },
                    { -50, -6, "swan-51", 1, -5 },
                    { -49, -6, "swan-50", 0, -5 },
                    { -48, -6, "swan-49", 1, -5 },
                    { -47, -6, "swan-48", 0, -5 },
                    { -46, -6, "swan-47", 1, -5 },
                    { -45, -6, "swan-46", 1, -5 },
                    { -44, -6, "swan-45", 1, -5 },
                    { -43, -6, "swan-44", 0, -5 },
                    { -42, -6, "swan-43", 1, -5 },
                    { -41, -6, "swan-42", 0, -5 },
                    { -40, -6, "eagle-41", 0, -4 },
                    { -39, -6, "eagle-40", 1, -4 },
                    { -38, -6, "eagle-39", 0, -4 },
                    { -37, -6, "eagle-38", 1, -4 },
                    { -36, -6, "eagle-37", 1, -4 },
                    { -35, -6, "eagle-36", 0, -4 },
                    { -34, -6, "eagle-35", 1, -4 },
                    { -33, -6, "eagle-34", 1, -4 },
                    { -32, -6, "eagle-33", 1, -4 },
                    { -31, -6, "eagle-32", 0, -4 },
                    { -30, -6, "hippo-31", 0, -3 },
                    { -29, -6, "hippo-30", 0, -3 },
                    { -28, -6, "hippo-29", 0, -3 },
                    { -27, -6, "hippo-28", 0, -3 },
                    { -26, -6, "hippo-27", 1, -3 },
                    { -25, -6, "hippo-26", 0, -3 },
                    { -24, -6, "hippo-25", 1, -3 },
                    { -23, -6, "hippo-24", 0, -3 },
                    { -22, -6, "hippo-23", 1, -3 },
                    { -21, -6, "hippo-22", 1, -3 },
                    { -20, -6, "giraffe-21", 1, -2 },
                    { -19, -6, "giraffe-20", 0, -2 },
                    { -18, -6, "giraffe-19", 1, -2 },
                    { -17, -6, "giraffe-18", 1, -2 },
                    { -16, -6, "giraffe-17", 0, -2 },
                    { -15, -6, "giraffe-16", 0, -2 },
                    { -14, -6, "giraffe-15", 0, -2 },
                    { -13, -6, "giraffe-14", 0, -2 },
                    { -12, -6, "giraffe-13", 1, -2 },
                    { -11, -6, "giraffe-12", 0, -2 },
                    { -10, -6, "lion-11", 1, -1 },
                    { -9, -6, "lion-10", 1, -1 },
                    { -8, -6, "lion-9", 0, -1 },
                    { -7, -6, "lion-8", 0, -1 },
                    { -6, -6, "lion-7", 1, -1 },
                    { -5, -6, "lion-6", 0, -1 },
                    { -4, -6, "lion-5", 0, -1 },
                    { -3, -6, "lion-4", 1, -1 },
                    { -2, -6, "lion-3", 1, -1 },
                    { -1, -6, "lion-2", 1, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
