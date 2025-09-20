using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoiceNote.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoiceNoteId",
                table: "Notes",
                newName: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Notes",
                newName: "ChoiceNoteId");
        }
    }
}
