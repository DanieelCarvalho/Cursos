using System.ComponentModel.DataAnnotations;

namespace Cursos.Domain.Models.Dtos;

public class AlunoUpdateDto
{

    public string Nome { get; set; }

   
   
    [EmailAddress]
    public string Email { get; set; }
}
