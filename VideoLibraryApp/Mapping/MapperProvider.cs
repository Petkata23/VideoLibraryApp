using AutoMapper;
using VideoLibraryApp.Mapping;

namespace VideoLibraryApp;

/// <summary>
/// Статичен достъп до AutoMapper конфигурацията.
/// </summary>
internal static class MapperProvider
{
    private static IMapper _mapper;
    private static readonly object _lock = new object();

    public static IMapper Mapper
    {
        get
        {
            if (_mapper == null)
            {
                lock (_lock)
                {
                    if (_mapper == null)
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.AddProfile<VideoLibraryMappingProfile>();
                        });
                        _mapper = config.CreateMapper();
                    }
                }
            }
            return _mapper;
        }
    }
}
