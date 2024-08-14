using AutoMapper;

namespace DesafioBackEnd.Mappings.Config
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
