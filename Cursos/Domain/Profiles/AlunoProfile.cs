using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos.Aluno;
using Cursos.Domain.Models.Dtos.Matricula;

namespace Cursos.Domain.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<AlunoCreateDto, Aluno>();

        CreateMap<AlunoUpdateDto, Aluno>();
        CreateMap< Aluno, AlunoMatriculaReadDto>();
        CreateMap<Aluno, AlunoReadDto>()
            .AfterMap((aluno, alunoDto) => {
                alunoDto.MatriculasUrl = $"http://localhost:5266/matriculas/aluno/{aluno.Id}";
            
            });


    }
}
