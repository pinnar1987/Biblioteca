using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class biblioteca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Livros_LivroId",
                table: "Emprestimos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "livros");

            migrationBuilder.RenameTable(
                name: "Emprestimos",
                newName: "emprestimo");

            migrationBuilder.RenameIndex(
                name: "IX_Emprestimos_LivroId",
                table: "emprestimo",
                newName: "IX_emprestimo_LivroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_livros",
                table: "livros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emprestimo",
                table: "emprestimo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_emprestimo_livros_LivroId",
                table: "emprestimo",
                column: "LivroId",
                principalTable: "livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emprestimo_livros_LivroId",
                table: "emprestimo");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_livros",
                table: "livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emprestimo",
                table: "emprestimo");

            migrationBuilder.RenameTable(
                name: "livros",
                newName: "Livros");

            migrationBuilder.RenameTable(
                name: "emprestimo",
                newName: "Emprestimos");

            migrationBuilder.RenameIndex(
                name: "IX_emprestimo_LivroId",
                table: "Emprestimos",
                newName: "IX_Emprestimos_LivroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprestimos",
                table: "Emprestimos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Livros_LivroId",
                table: "Emprestimos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
