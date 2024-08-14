using AutoMapper;
using DesafioBackEnd.Models;
using DesafioBackEnd.ViewModels;

namespace DesafioBackEnd.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tarefa, RetornoTarefaViewModel>().ReverseMap();


           

        }
    }
}
