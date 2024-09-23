using Cursos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Context;

public class CursosDbContext : DbContext
{

    public DbSet<Aluno> Alunos { get; set; }

    public DbSet <Curso> Curso { get; set; }

    public DbSet <Matricula> Matriculas { get; set;}

    public CursosDbContext(DbContextOptions<CursosDbContext> options) : base(options)
    {
    }


}
