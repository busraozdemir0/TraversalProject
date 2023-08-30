using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_contacUs_table_new_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ınstagramUrl",
                table: "Guides",
                newName: "InstagramUrl");

            migrationBuilder.AddColumn<bool>(
                name: "MessageStatus",
                table: "ContactUses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "ContactUses");

            migrationBuilder.RenameColumn(
                name: "InstagramUrl",
                table: "Guides",
                newName: "ınstagramUrl");
        }
    }
}
