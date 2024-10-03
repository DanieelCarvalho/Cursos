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

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Matricula>()
            .HasKey(matricula => new {matricula.AlunoId, matricula.CursoId});

        builder.Entity<Matricula>()
             .HasOne(matricula => matricula.Aluno)
             .WithMany(aluno => aluno.Matriculas)
             .HasForeignKey(matricula => matricula.AlunoId)
             .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Matricula>()
           .HasOne(matricula => matricula.Curso)
           .WithMany(curso => curso.Matriculas)
           .HasForeignKey(matricula => matricula.CursoId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
