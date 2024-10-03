using System.ComponentModel.DataAnnotations;

namespace Cursos.Domain.Models.Dtos.Curso;

public class CursoCreateDto
{
    [Required]
    public string Nome { get; set; }

    public string? Descricao { get; set; }
}
