using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CanadaGames.Data.CGMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contingents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contingents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 1, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlacementSummary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    AveragePlacement = table.Column<int>(nullable: false),
                    HighestPlacement = table.Column<int>(nullable: false),
                    LowestPlacement = table.Column<int>(nullable: false),
                    TotalEvents = table.Column<int>(nullable: false),
                    ContingentCode = table.Column<string>(nullable: true),
                    AthleteCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementSummary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: true),
                    FavouriteIceCream = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hometowns",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ContingentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hometowns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hometowns_Contingents_ContingentID",
                        column: x => x.ContingentID,
                        principalTable: "Contingents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: false),
                    SportID = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    AthleteCode = table.Column<string>(maxLength: 7, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    YearsInSport = table.Column<int>(nullable: false),
                    Affiliation = table.Column<string>(maxLength: 255, nullable: false),
                    Goals = table.Column<string>(maxLength: 255, nullable: false),
                    MediaInfo = table.Column<string>(maxLength: 2000, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ContingentID = table.Column<int>(nullable: false),
                    SportID = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false),
                    CoachID = table.Column<int>(nullable: true),
                    HometownID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Athletes_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Contingents_ContingentID",
                        column: x => x.ContingentID,
                        principalTable: "Contingents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Hometowns_HometownID",
                        column: x => x.HometownID,
                        principalTable: "Hometowns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthletePhotos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletePhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AthletePhotos_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteSports",
                columns: table => new
                {
                    AthleteID = table.Column<int>(nullable: false),
                    SportID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteSports", x => new { x.AthleteID, x.SportID });
                    table.ForeignKey(
                        name: "FK_AthleteSports_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteSports_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthleteThumbnails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteThumbnails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AthleteThumbnails_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Place = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(maxLength: 2000, nullable: true),
                    EventID = table.Column<int>(nullable: false),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Placements_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placements_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    AthleteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileContent",
                columns: table => new
                {
                    FileContentID = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContent", x => x.FileContentID);
                    table.ForeignKey(
                        name: "FK_FileContent_UploadedFiles_FileContentID",
                        column: x => x.FileContentID,
                        principalTable: "UploadedFiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AthletePhotos_AthleteID",
                table: "AthletePhotos",
                column: "AthleteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_AthleteCode",
                table: "Athletes",
                column: "AthleteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_CoachID",
                table: "Athletes",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_ContingentID",
                table: "Athletes",
                column: "ContingentID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_GenderID",
                table: "Athletes",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_HometownID",
                table: "Athletes",
                column: "HometownID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_SportID",
                table: "Athletes",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSports_SportID",
                table: "AthleteSports",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteThumbnails_AthleteID",
                table: "AthleteThumbnails",
                column: "AthleteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contingents_Code",
                table: "Contingents",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_GenderID",
                table: "Events",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SportID",
                table: "Events",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Code",
                table: "Genders",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hometowns_ContingentID",
                table: "Hometowns",
                column: "ContingentID");

            migrationBuilder.CreateIndex(
                name: "IX_Hometowns_Name_ContingentID",
                table: "Hometowns",
                columns: new[] { "Name", "ContingentID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placements_EventID",
                table: "Placements",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_AthleteID_EventID",
                table: "Placements",
                columns: new[] { "AthleteID", "EventID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Code",
                table: "Sports",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_AthleteID",
                table: "UploadedFiles",
                column: "AthleteID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            ExtraMigration.Steps(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletePhotos");

            migrationBuilder.DropTable(
                name: "AthleteSports");

            migrationBuilder.DropTable(
                name: "AthleteThumbnails");

            migrationBuilder.DropTable(
                name: "FileContent");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "PlacementSummary");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Hometowns");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Contingents");
        }
    }
}
