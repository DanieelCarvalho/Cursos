using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos.Matricula;

namespace Cursos.Domain.Profiles;

public class MatriculaProfile : Profile
{
    

    public MatriculaProfile()
    {
        CreateMap<MatriculaCreateDto, Matricula>();

        CreateMap<Aluno, AlunoMatriculaReadDto>();
        CreateMap<Curso, CursoMatriculaReadDto>();


        CreateMap<Matricula, MatriculaReadDto>()
       .ForMember(matriculaDto => matriculaDto.AlunoDto, 
                  options => options.MapFrom(matricula => matricula.Aluno))
       .ForMember(matriculaDto => matriculaDto.CursoDto,
                  options => options.MapFrom(matricula => matricula.Curso));


    }

}
