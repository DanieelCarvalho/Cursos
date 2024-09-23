using AutoMapper;
using Cursos.Context;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos;
using Cursos.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Controllers;


[ApiController]
[Route("alunos")]
public class AlunoController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly AlunoRepository _alunoRepository;

    public AlunoController(IMapper mapper, AlunoRepository alunoRepository)
    {
        _mapper = mapper;
        _alunoRepository = alunoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery(Name ="page")]int page=0, 
                                           [FromQuery(Name ="size")] int size=10)
    {

        var offset = page * size;


        var alunos = await _dbcontext.Alunos.Skip(offset).Take(size).ToListAsync();
        return Ok(alunos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buscarAluno = _dbcontext.Alunos.FindAsync(id);

        if(buscarAluno == null)
            return NotFound();

        return Ok(buscarAluno);

    }

    [HttpPost]
    public async Task<IActionResult> Register(AlunoCreateDto alunoDto)
    {
        var alunoParaCadastrar = _mapper.Map<Aluno>(alunoDto);

       var alunoCAdastrado = await _dbcontext.Alunos.AddAsync(alunoParaCadastrar);
       await _dbcontext.SaveChangesAsync();

        var alunoSalvo = alunoCAdastrado.Entity;

        return CreatedAtAction(nameof(GetById), new {id = alunoSalvo.Id }, alunoSalvo);


    }
}
