using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mlbd_logistics_management.Migrations
{
    /// <inheritdoc />
    public partial class CreateDepartmentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                        name: "Departments",
                        columns: table => new
                        {
                            Id = table.Column<int>(nullable: false)
                                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(nullable: false),
                            OfficeName = table.Column<string>(nullable: false),
                            CreatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                            UpdatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                            DeletedAt = table.Column<DateTime>(precision: 0, nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Department", x => x.Id);
                        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Department");
        }
    }
}
