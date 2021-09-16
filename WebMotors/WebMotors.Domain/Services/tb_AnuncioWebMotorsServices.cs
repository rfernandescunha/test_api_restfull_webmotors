using WebMotors.Domain.Entities;
using WebMotors.Domain.Validation;
using WebMotors.Domain.Interfaces.IRepository;
using WebMotors.Domain.Interfaces.IServices;
using WebMotors.Domain.Notifications;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Validation.AnuncioWebMotors;

namespace WebMotors.Domain.Services
{
    public class tb_AnuncioWebmotorsServices : Itb_AnuncioWebMotorsServices
    {
        private readonly Itb_AnuncioWebmotorsRepository _tb_AnuncioWebmotorsRepository;
        private readonly NotificationContext _notificationContext;

        public tb_AnuncioWebmotorsServices(Itb_AnuncioWebmotorsRepository tb_AnuncioWebmotorsRepository)
        {
            _tb_AnuncioWebmotorsRepository = tb_AnuncioWebmotorsRepository;
            _notificationContext = new NotificationContext();
        }
        public async Task<bool> Delete(int Id)
        {
            return await _tb_AnuncioWebmotorsRepository.Delete(Id);
        }

        public async Task<tb_AnuncioWebmotors> Find(int Id)
        {
            return await _tb_AnuncioWebmotorsRepository.Find(Id);
        }

        public async Task<IEnumerable<tb_AnuncioWebmotors>> Find(Expression<Func<tb_AnuncioWebmotors, bool>> predicate = null)
        {
            return await _tb_AnuncioWebmotorsRepository.Find(predicate);
        }

        public async Task<tb_AnuncioWebmotors> Insert(tb_AnuncioWebmotors entity)
        {
            entity.Validate(entity, new tb_AnuncioWebMotorsInsert());

            if(entity.Invalid)            
                return entity;
            

            return await _tb_AnuncioWebmotorsRepository.Insert(entity);
        }

        public async Task<tb_AnuncioWebmotors> Update(tb_AnuncioWebmotors entity)
        {
            entity.Validate(entity, new tb_AnuncioWebMotorsUpdate());

            return await _tb_AnuncioWebmotorsRepository.Update(entity);
        }
    }
}
