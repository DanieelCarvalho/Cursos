using AutoMapper;
using Cursos.Context;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos.Aluno;
using Cursos.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Controllers;


[ApiController]
[Route("alunos")]
public class AlunoController : ControllerBase
{
    

    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public AlunoController(IMapper mapper, IAlunoRepository alunoRepository)
    {
        
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery(Name ="page")]int page=0, 
                                           [FromQuery(Name ="size")] int size=10)
    {


        var offset = page * size;

        var alunos = await _alunoRepository.FindAll(offset, size);
        var alunosResponse = alunos.Select(_mapper.Map<AlunoReadDto>).ToList();
        return Ok(alunosResponse);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buscarAluno = await _alunoRepository.FindById(id);

        if(buscarAluno == null)
            return NotFound();

        var alunoResponse = _mapper.Map<AlunoReadDto>(buscarAluno);
        return Ok(alunoResponse);

    }

    [HttpPost]
    public async Task<IActionResult> Register(AlunoCreateDto alunoDto)
    {
        var alunoParaCadastrar = _mapper.Map<Aluno>(alunoDto);
        await _alunoRepository.Save(alunoParaCadastrar);
        var alunoResponse = _mapper.Map<AlunoReadDto>(alunoParaCadastrar);

        return CreatedAtAction(nameof(GetById), new { id = alunoParaCadastrar.Id }, alunoParaCadastrar);

    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(AlunoUpdateDto alunoUpdateDto, int id)
    {
        var alunoUpdate = _mapper.Map<Aluno>(alunoUpdateDto);

        var alunoAtualizado = await _alunoRepository.Update(id, alunoUpdate);
        return Ok(alunoAtualizado);



    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _alunoRepository.Delete(id);
        return NoContent();
    }
}
