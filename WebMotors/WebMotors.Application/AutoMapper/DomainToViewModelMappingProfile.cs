using AutoMapper;
using WebMotors.Domain.Entities;
using WebMotors.Application.ViewModels.AnuncioWebMotors;

namespace WebMotors.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<tb_AnuncioWebmotors, AnuncioWebMotorsViewModel>();
        }
    }
}
