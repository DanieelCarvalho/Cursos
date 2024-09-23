using System.ComponentModel.DataAnnotations;

namespace Cursos.Domain.Models;

interface IEntity
{
    public int Id { get; set; }

}

public abstract class Entity : IEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
}




