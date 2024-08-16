using AutoMapper;

namespace DesafioBackEnd.Application.Mapping.Config
{
    public class MappingsConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}
