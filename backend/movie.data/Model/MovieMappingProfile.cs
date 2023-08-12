using AutoMapper;
using MDomain = movie.domain.Model.MovieList;
using MovieD = movie.domain.Model.Movie;
using MDD = movie.domain.Model.MovieData;

namespace movie.data.Model;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<MovieList, MDomain>()
           .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => BuildMovieList(src.Movies)));

        CreateMap<MovieData, MDD>()
           .ForMember(dest => dest.Released, opt => opt.MapFrom(src => DateTime.Parse(src.Released)))
           .ForMember(dest => dest.Metascore, opt => opt.MapFrom(src => int.Parse(src.Metascore)))
           .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => double.Parse(src.Rating)))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => double.Parse(src.Price)));
    }

    private List<MovieD> BuildMovieList(List<Movie> movies)
    {
        return movies.Select(mov => new MovieD
        {
            Title= mov.Title,
            Year= int.Parse(mov.Year),
            ID= mov.ID,
            Type= mov.Type,
            Poster= mov.Poster
        }).ToList();
    }
}
