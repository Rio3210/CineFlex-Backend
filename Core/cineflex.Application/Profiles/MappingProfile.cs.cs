using AutoMapper;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Domain;

namespace cineflex.Application;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        
        CreateMap<GetMovieDto,Movie>().ReverseMap();
        CreateMap<CreateMovieDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieDto, Movie>().ReverseMap();


    }

}
