using AutoMapper;
using WebMotors.Application.Interfaces;
using WebMotors.Application.ViewModels;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebMotors.Application.ViewModels.AnuncioWebMotors;

namespace WebMotors.Application.Services
{
    public class tb_AnuncioWebMotorsAppServices:Itb_AnuncioWebMotorsAppServices
    {
        private readonly IMapper _mapper;
        private readonly Itb_AnuncioWebMotorsServices _productServices;

        public tb_AnuncioWebMotorsAppServices(
                                                Itb_AnuncioWebMotorsServices productServices,
                                                IMapper mapper)
        {
            _mapper = mapper;
            _productServices = productServices;
        }

        public async Task<bool> Delete(int Id)
        {
            return await _productServices.Delete(Id);
        }

        public async Task<IEnumerable<AnuncioWebMotorsViewModel>> Find(Expression<Func<tb_AnuncioWebmotors, bool>> predicate = null)
        {
            var retorno = await _productServices.Find(predicate);

            return _mapper.Map<IEnumerable<AnuncioWebMotorsViewModel>>(retorno);
        }

        public async Task<AnuncioWebMotorsViewModel> Find(int Id)
        {          

            var item =  await _productServices.Find(Id);

            return _mapper.Map<AnuncioWebMotorsViewModel>(item);
        }

        public async Task<AnuncioWebMotorsViewModel> Insert(AnuncioWebMotorsViewModel Objeto)
        {
            var entrada = _mapper.Map<tb_AnuncioWebmotors>(Objeto);

            var retorno = await _productServices.Insert(entrada);

            return  _mapper.Map<AnuncioWebMotorsViewModel>(retorno);
        }

        public async Task<AnuncioWebMotorsViewModel> Update(AnuncioWebMotorsViewModel Objeto)
        {
            var entrada = _mapper.Map<tb_AnuncioWebmotors>(Objeto);

            var retorno = await _productServices.Update(entrada);

            return _mapper.Map<AnuncioWebMotorsViewModel>(retorno);
        }
    }
}
