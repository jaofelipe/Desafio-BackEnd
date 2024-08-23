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

            CreateMap<DeliveryPerson, DeliveryPersonResponseViewModel>().ReverseMap();
            CreateMap<DeliveryPerson, DeliveryPersonViewModel>().ReverseMap();

            CreateMap<Rental, RentalResponseViewModel>().ReverseMap();
            CreateMap<Rental, RentalViewModel>().ReverseMap();


        }
    }
}
