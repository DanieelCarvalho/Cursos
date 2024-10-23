using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursos.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdFromMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Matriculas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Matriculas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
