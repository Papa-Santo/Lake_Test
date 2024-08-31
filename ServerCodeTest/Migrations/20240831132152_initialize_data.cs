using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerCodeTest.Migrations
{
    /// <inheritdoc />
    public partial class initialize_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "technicians",
                columns: table => new
                {
                    technicianid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    technicianname = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    technicianemail = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicians", x => x.technicianid);
                });

            migrationBuilder.CreateTable(
                name: "workorders",
                columns: table => new
                {
                    wonum = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: true),
                    datereceived = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    dateassigned = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    datecomplete = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    contactname = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: true),
                    techniciancomments = table.Column<string>(type: "text", nullable: true),
                    contactnumber = table.Column<string>(type: "VARCHAR", maxLength: 25, nullable: true),
                    technicianid = table.Column<int>(type: "integer", nullable: true),
                    problem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workorders", x => x.wonum);
                });

            migrationBuilder.InsertData(
                table: "technicians",
                columns: new[] { "technicianid", "technicianemail", "technicianname" },
                values: new object[,]
                {
                    { 5, "dschrute@dundermifflin.com", "Dwight Schrute" },
                    { 6, "mscott@dundermifflin.com", "Michael Scott" },
                    { 8, "creed@dundermifflin.com", "Creed" }
                });

            migrationBuilder.InsertData(
                table: "workorders",
                columns: new[] { "wonum", "contactname", "contactnumber", "dateassigned", "datecomplete", "datereceived", "email", "problem", "status", "techniciancomments", "technicianid" },
                values: new object[,]
                {
                    { 2, "Oscar", "555-456-0003", new DateTime(2014, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "oscar@lakecountyfl.gov", "Fax not working.", "Closed", "Fax has been disconnected. Uses too much power.", 5 },
                    { 3, "Jim Harper", "555-456-0002", new DateTime(2014, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "jharper@dundermifflin.com", "Unable to call Pam", "Closed", "Problem solved.", 5 },
                    { 4, "Pam Harper", "555-456-0001", new DateTime(2014, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2014, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pharper@dundermifflin.com", "Unable to call Jim", "Assigned", null, 6 },
                    { 5, "Pam Harper", "555-456-0001", new DateTime(2014, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2014, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "pharper@dundermifflin.com", "Phone is turning off.", "Assigned", null, 7 },
                    { 6, "Creed", "555-456-0004", null, null, new DateTime(2014, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "creed@lakecountyfl.gov", "Voicemail message is me. Need to change to me.", "Assigned", null, 7 },
                    { 7, null, null, null, null, new DateTime(2014, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "oscar@dundermifflin.com", null, "Assigned", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "technicians");

            migrationBuilder.DropTable(
                name: "workorders");
        }
    }
}
