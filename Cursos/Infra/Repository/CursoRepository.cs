using Cursos.Context;
using Cursos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Infra.Repository;

public class CursoRepository : ICursoRepository
{

    private readonly CursosDbContext _dbContext;

    public CursoRepository(CursosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Delete(int id)
    {
        var cursoDeletar = await _dbContext.Curso.FindAsync(id);

        _dbContext.Remove(cursoDeletar);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Curso>> FindAll(int offset, int size)
    {
        var cursos = await _dbContext.Curso.Skip(offset).Take(size).ToListAsync();

        return (cursos);
    }

    public async Task<Curso> FindById(int ID)
    {
        return await _dbContext.Curso.FindAsync(ID);
    }

    public async Task Save(Curso entity)
    {
        var crusoCadastrado = await _dbContext.Curso.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Curso> Update(int id, Curso newEntity)
    {
        var cursoExistente = await _dbContext.Curso.FindAsync(id);
        
        if (cursoExistente == null)
            throw new Exception("Aluno não encontrado");

        cursoExistente.Nome = newEntity.Nome;
        cursoExistente.Descricao = newEntity.Descricao;
      

        _dbContext.Curso.Update(cursoExistente);
        await _dbContext.SaveChangesAsync();
        return cursoExistente;
    }
}
