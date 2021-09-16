
using AutoMapper;
using WebMotors.Application.ViewModels.AnuncioWebMotors;
using WebMotors.Domain.Entities;

namespace WebMotors.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AnuncioWebMotorsViewModel, tb_AnuncioWebmotors>();
        }
    }
}
