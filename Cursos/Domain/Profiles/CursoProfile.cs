using AutoMapper;
using Cursos.Domain.Models;
using Cursos.Domain.Models.Dtos;

namespace Cursos.Domain.Profiles;
    public class CursoProfile : Profile
    {
       public CursoProfile() 
        {

        CreateMap<CursoCreateDto, Curso>();
        }

    }

