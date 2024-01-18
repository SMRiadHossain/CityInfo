using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class email_cs_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("ALTER TABLE Users ALTER COLUMN  email VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CS_AS");
            migrationBuilder.Sql("ALTER TABLE Users ALTER COLUMN  token VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CS_AS");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
