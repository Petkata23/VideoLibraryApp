using AutoMapper;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Shared.Dtos;

namespace VideoLibraryApp.Mapping;

/// <summary>
/// AutoMapper профил за Entity -> DTO мапинга.
/// </summary>
public class VideoLibraryMappingProfile : Profile
{
    public VideoLibraryMappingProfile()
    {
        CreateMap<Cassette, CassetteDto>()
            .ForMember(d => d.Director, o => o.MapFrom(s => s.Director ?? "-"))
            .ForMember(d => d.Genre, o => o.MapFrom(s => s.Genre ?? "-"));

        CreateMap<User, UserDto>();

        CreateMap<UserSavedFilm, SavedFilmDto>()
            .ForMember(d => d.Cassette, o => o.MapFrom(s => s.Cassette))
            .ForMember(d => d.SavedAt, o => o.MapFrom(s => s.SavedAt));
    }
}
