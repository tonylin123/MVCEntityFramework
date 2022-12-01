using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguagesID = table.Column<int>(type: "int", nullable: false),
                    PeopleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguagesID, x.PeopleID });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Languages_LanguagesID",
                        column: x => x.LanguagesID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_People_PeopleID",
                        column: x => x.PeopleID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "China" },
                    { 2, "USA" },
                    { 3, "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Mandarin" },
                    { 2, "English" },
                    { 3, "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { 1, 1, "Peking" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { 2, 2, "NewYork" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { 3, 3, "Gothenburg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CityID", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "Tony", "123289" },
                    { 2, 2, "Tony Stark", "12345" },
                    { 3, 2, "Captain America", "3213213" },
                    { 4, 3, "KrallLexicon", "78998554" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesID", "PeopleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PeopleID",
                table: "LanguagePerson",
                column: "PeopleID");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
