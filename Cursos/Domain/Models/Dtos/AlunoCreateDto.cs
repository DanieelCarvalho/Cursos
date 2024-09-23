using System.ComponentModel.DataAnnotations;

namespace Cursos.Domain.Models.Dtos;

public class AlunoCreateDto
{
    [Required]
    public string Nome { get; set; }

    //[DataType(DataType.EmailAddress)]
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
