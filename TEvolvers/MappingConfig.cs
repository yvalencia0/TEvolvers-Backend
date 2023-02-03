using AutoMapper;
using TEvolvers.Models;
using TEvolvers.Models.Dto;

namespace TEvolvers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDto, Person>();
                config.CreateMap<Person, PersonDto>();
            });

            return mappingConfig;
        }
    }
}
