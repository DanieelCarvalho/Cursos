using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Cursos.Domain.Models.Dtos;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Cursos.Context;
using System.Linq;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Cursos.Infra.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly CursosDbContext _dbContext;
   

    public AlunoRepository(CursosDbContext dbContext)
    {
        _dbContext = dbContext;
        
    }

    public async Task Delete(int id)
    {
        var alunoDeletar =  await _dbContext.Alunos.FindAsync(id);

        _dbContext.Remove(alunoDeletar);
        await _dbContext.SaveChangesAsync();

        
    }

    public async Task<IEnumerable<Aluno>> FindAll(int offset, int size)
    {
       
        var alunos = await _dbContext.Alunos.Skip(offset).Take(size).ToListAsync();
        return (alunos);
    }

    public async Task<Aluno> FindById(int ID)
    {
        return await _dbContext.Alunos.FindAsync(ID);
    }

    public async Task Save(Aluno entity)
    {
        var alunoCadastrado = await _dbContext.Alunos.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

 
    }

    public async Task<Aluno> Update(int id, Aluno newEntity)
    {
        
        var alunoExistente = await _dbContext.Alunos.FindAsync(id);
        if (alunoExistente == null)
            throw new Exception("Aluno não encontrado");

        alunoExistente.Nome = newEntity.Nome;
        alunoExistente.Email = newEntity.Email;

        _dbContext.Alunos.Update(alunoExistente);
        await _dbContext.SaveChangesAsync();
        return alunoExistente;
    }
}
