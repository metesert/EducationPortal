using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Concrete;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessDal _processDal;
        public ProcessService(IProcessDal processDal)
        {
            _processDal = processDal;
        }
        public async Task Delete(int id)
        {
            await _processDal.Delete(id);
        }

        public List<TblProcess> GetAll()
        {
            return _processDal.GetAll();
        }

        public async Task<List<TblProcess>> GetAllAsync()
        {
            return await _processDal.GetAllAsync();
        }

        public TblProcess GetById(int id)
        {
            return _processDal.GetById(id);
        }

        public Task<TblProcess> GetByIdAsync(int id)
        {
            return _processDal.GetByIdAsync(id);
        }

        public void Insert(TblProcess entity)
        {

            _processDal.Insert(entity);
        }

        public async Task InsertAsync(TblProcess entity)
        {
            try
            {
                await _processDal.InsertAsync(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task Update(int id, TblProcess entity)
        {
            await _processDal.Update(id, entity);
        }


    }
}
