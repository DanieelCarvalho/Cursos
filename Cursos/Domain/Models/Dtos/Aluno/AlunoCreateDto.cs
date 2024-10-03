using System.ComponentModel.DataAnnotations;

namespace Cursos.Domain.Models.Dtos.Aluno;

public class AlunoCreateDto
{
    [Required]
    public string Nome { get; set; }

    //[DataType(DataType.EmailAddress)]
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
