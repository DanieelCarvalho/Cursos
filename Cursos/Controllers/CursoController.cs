using AutoMapper;
using Cursos.Domain.Models.Dtos;
using Cursos.Domain.Models;
using Cursos.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cursos.Controllers;

public class CursoController : ControllerBase
{
    private readonly IMapper _mapper;

    public CursoController(IMapper mapper)
    {

        
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery(Name = "page")] int page = 0,
                                           [FromQuery(Name = "size")] int size = 10)
    {


        var offset = page * size;

        var alunos = await _alunoRepository.FindAll(offset, size);
        return Ok(alunos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buscarAluno = _alunoRepository.FindById(id);

        if (buscarAluno == null)
            return NotFound();

        return Ok(buscarAluno);

    }

    [HttpPost]
    public async Task<IActionResult> Register(AlunoCreateDto alunoDto)
    {
        var alunoParaCadastrar = _mapper.Map<Aluno>(alunoDto);
        await _alunoRepository.Save(alunoParaCadastrar);

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
