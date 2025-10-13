using AutoMapper;
using BusinessLogic.DTOs.Accounts;
using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.DTOs.MovieActorDto;
using BusinessLogic.DTOs.MovieDto;
using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.DTOs.UserDto;
using DataAccess.Data.Entities;

namespace BusinessLogic.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Movie
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<EditMovieDto, Movie>();
            CreateMap<MovieDto, Movie>().ReverseMap();

            // Genre
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<EditGenreDto, Genre>();
            CreateMap<GenreDto, Genre>().ReverseMap();

            // Actor
            CreateMap<CreateActorDto, Actor>();
            CreateMap<EditActorDto, Actor>();
            CreateMap<ActorDto, Actor>().ReverseMap();

            // User
            CreateMap<CreateUserDto, User>();
            CreateMap<EditUserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();

            // Review
            CreateMap<CreateReviewDto, Review>();
            CreateMap<EditReviewDto, Review>();
            CreateMap<ReviewDto, Review>().ReverseMap();

            // MovieActor
            CreateMap<CreateMovieActorDto, MovieActor>();
            CreateMap<EditMovieActorDto, MovieActor>();
            CreateMap<MovieActorDto, MovieActor>().ReverseMap();

            // Account
            CreateMap<RegisterModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore());
        }
    }
}
