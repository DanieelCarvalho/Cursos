using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Cursos.Domain.Models.Dtos.Curso;

namespace Cursos.Controllers;
[ApiController]
[Route("cursos")]
public class CursoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICursoRepository _cursoRepository;

    public CursoController(IMapper mapper, ICursoRepository cursoRepository)
    {
        _mapper = mapper;
        _cursoRepository = cursoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery(Name = "page")] int page = 0,
                                          [FromQuery(Name = "size")] int size = 10)
    {

        var offset = page * size;

        var alunos = await _cursoRepository.FindAll(offset, size);
        return Ok(alunos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buscarCurso = _cursoRepository.FindById(id);

        if (buscarCurso == null)
            return NotFound();

        return Ok(buscarCurso);

    }

    [HttpPost]
    public async Task<IActionResult> Register(CursoCreateDto cursoDto)
    {
        var cursoParaCadastrar = _mapper.Map<Curso>(cursoDto);
        await _cursoRepository.Save(cursoParaCadastrar);

        return CreatedAtAction(nameof(GetById), new { id = cursoParaCadastrar.Id }, cursoParaCadastrar);

    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(CursoUpdateDto cursoUpdateDto, int id)
    {
        var cursoUpdate = _mapper.Map<Curso>(cursoUpdateDto);

        var alunoAtualizado = await _cursoRepository.Update(id, cursoUpdate);
        return Ok(alunoAtualizado);



    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cursoRepository.Delete(id);
        return NoContent();
    }



}
