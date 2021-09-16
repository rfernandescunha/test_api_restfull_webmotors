using WebMotors.Application.ViewModels;
using WebMotors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Application.ViewModels.AnuncioWebMotors;

namespace WebMotors.Application.Interfaces
{
    public interface Itb_AnuncioWebMotorsAppServices //: IBaseAppServices<Product>
    {
        Task<AnuncioWebMotorsViewModel> Insert(AnuncioWebMotorsViewModel item);
        Task<AnuncioWebMotorsViewModel> Update(AnuncioWebMotorsViewModel item);
        Task<bool> Delete(int Id);
        Task<AnuncioWebMotorsViewModel> Find(int Id);
        Task<IEnumerable<AnuncioWebMotorsViewModel>> Find(Expression<Func<tb_AnuncioWebmotors, bool>> predicate = null);
    }
}
