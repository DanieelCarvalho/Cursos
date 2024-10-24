﻿using AutoMapper;
using Cursos.Context;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos.Aluno;
using Cursos.Domain.Models.Dtos.Matricula;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Controllers;

[ApiController]
[Route("matriculas")]
public class MatriculasController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly CursosDbContext _cursosDbContext;

    public MatriculasController(IMapper mapper, CursosDbContext cursosDbContext)
    {
        _mapper = mapper;
        _cursosDbContext = cursosDbContext;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery(Name = "page")] int page = 0,
                                           [FromQuery(Name = "size")] int size = 10)
    {
        var offset = page * size;

        var matricula = await _cursosDbContext.Matriculas.Skip(offset).Take(size).ToListAsync();

        var MatriculaResponse = matricula.Select(_mapper.Map<MatriculaReadDto>);


        return Ok(MatriculaResponse);

    }

    [HttpGet("aluno/{alunoId}")]

    public async Task<IActionResult> GetByMatriculaPorAluno(int alunoId)
    {
        var matricula = await _cursosDbContext
            .Matriculas
            .Where((matricula) => matricula.AlunoId== alunoId)
            .ToListAsync();

        if (matricula.Count() == 0) return NotFound();

        var matriculasResponse = matricula.Select(_mapper.Map<MatriculaReadDto>);

        return Ok(matriculasResponse);

    }
    [HttpGet("curso/{cursoId}")]

    public async Task<IActionResult> GetByMatriculaPorCurso(int cursoId)
    {
        var matricula = await _cursosDbContext
            .Matriculas
            .Where((matricula) => matricula.CursoId == cursoId)
            .ToListAsync();

        if (matricula.Count() == 0) return NotFound();

        var matriculasResponse = matricula.Select(_mapper.Map<MatriculaReadDto>);

        return Ok(matriculasResponse);

    }

    [HttpGet("{alunoId:int}/{cursoId:int}")]

    public async Task<IActionResult> GetByMatricula([FromRoute]int alunoId, [FromRoute] int cursoId)
    {
        var matricula = await _cursosDbContext
            .Matriculas
            .FirstAsync((matricula) => matricula.AlunoId == alunoId && matricula.CursoId == cursoId);

        if (matricula == null) return NotFound();

        var matriculaResponse = _mapper.Map<MatriculaReadDto>(matricula);

        return Ok(matriculaResponse);

    }


    [HttpPost]
    public async Task<IActionResult> Register(MatriculaCreateDto matriculaCreateDto)
    {
      var exists = await _cursosDbContext.Matriculas
      .AnyAsync(m => m.AlunoId == matriculaCreateDto.AlunoId && m.CursoId == matriculaCreateDto.CursoId);

        if (exists)
        {
            return Conflict("A matrícula já existe para este aluno e curso.");
        }

        var matriculaParaCadastrar = _mapper.Map<Matricula>(matriculaCreateDto);

        var entityEntry = await _cursosDbContext.Matriculas.AddAsync(matriculaParaCadastrar);

        await _cursosDbContext.SaveChangesAsync();

        var matriculaSalva = entityEntry.Entity;
        var matriculasResponse = _mapper.Map<MatriculaReadDto>(matriculaSalva);

        return CreatedAtAction(nameof(GetByMatricula), 
         new { matriculaSalva.AlunoId, matriculaSalva.CursoId },
           matriculasResponse);
        
    }




    [HttpDelete("{alunoId}/{cursoId}")]
    public async Task<IActionResult> Delete(int alunoId, int cursoId)
    {
        var matricula = await _cursosDbContext.Matriculas.FindAsync(alunoId, cursoId);

        if (matricula == null)
        {
            return NotFound();
        }

        _cursosDbContext.Matriculas.Remove(matricula);
        await _cursosDbContext.SaveChangesAsync();

        return NoContent();
    }


}
