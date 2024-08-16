using AutoMapper;
using DesafioBackEnd.Application.ViewModels;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Motorcycle, MotorcycleResponseViewModel>().ReverseMap();
            CreateMap<Motorcycle, MotorcycleViewModel>().ReverseMap();



        }
    }
}
