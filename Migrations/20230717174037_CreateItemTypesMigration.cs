using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mlbd_logistics_management.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemTypesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                        name: "ItemTypes",
                        columns: table => new
                        {
                            Id = table.Column<int>(nullable: false)
                                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(nullable: false),
                            DepartmentId = table.Column<int>(nullable: false),
                            CreatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                            UpdatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                            DeletedAt = table.Column<DateTime>(precision: 0, nullable: true)
                        },

                        constraints: table =>
                        {
                            table.PrimaryKey("PK_ItemTypes", x => x.Id);
                            table.ForeignKey(
                                name: "FK_ItemTypes_Departments_DepartmentId",
                                column: x => x.DepartmentId,
                                principalTable: "Departments",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);
                        });

                    migrationBuilder.CreateIndex(
                        name: "IX_ItemTypes_DepartmentId",
                        table: "ItemTypes",
                        column: "DepartmentId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                        name: "ItemTypes");
        }
    }
}
