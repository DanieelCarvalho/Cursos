using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos;

namespace Cursos.Domain.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<AlunoCreateDto, Aluno>();

        CreateMap<AlunoUpdateDto, Aluno>();

    }
}
