using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        void Insert(T entity);
        Task InsertAsync(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
