using AutoMapper;
using JourneyMiles.API.Shared.Communication.Services;

namespace CommonTestUtilities.Mapper;
public class AutoMapperBuilder
{
    public static IMapper Build()
    {
        return new MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

    }
}
