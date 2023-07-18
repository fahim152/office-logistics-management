using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mlbd_logistics_management.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Items",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                           .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(nullable: false),
                ItemTypeId = table.Column<int>(nullable: false),
                Quantity = table.Column<int>(nullable: false),
                IsAssignable = table.Column<bool>(nullable: false),
                CreatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                UpdatedAt = table.Column<DateTime>(precision: 0, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                DeletedAt = table.Column<DateTime>(precision: 0, nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Items", x => x.Id);
                table.ForeignKey(
                    name: "FK_Items_ItemTypes_ItemTypeId",
                    column: x => x.ItemTypeId,
                    principalTable: "ItemTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Items_ItemTypeId",
            table: "Items",
            column: "ItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                        name: "Items");
        }
    }
}
