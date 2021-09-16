using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Infra.Data.Repositories
{
    public class tb_AnuncioWebMotorsRepository:BaseRepository<tb_AnuncioWebmotors>, Itb_AnuncioWebmotorsRepository
    {
        public tb_AnuncioWebMotorsRepository(WMContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
