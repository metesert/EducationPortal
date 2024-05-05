using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete
{
    public class EducationService : IEducationService
    {

        private readonly IEducationDal _educationDal;
        public EducationService(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }
        public async Task Delete(int id)
        {
            await _educationDal.Delete(id);
        }
        public List<TblEducation> GetAll()
        {
            return _educationDal.GetAll();
        }
        public async Task<List<TblEducation>> GetAllAsync()
        {
            return await _educationDal.GetAllAsync();
        }
        public TblEducation GetById(int id)
        {
            return _educationDal.GetById(id);
        }
        public Task<TblEducation> GetByIdAsync(int id)
        {
            return _educationDal.GetByIdAsync(id);
        }
        public void Insert(TblEducation entity)
        {
            _educationDal.Insert(entity);
        }
        public async Task InsertAsync(TblEducation entity)
        {
            await _educationDal.InsertAsync(entity);
        }
        public async Task Update(int id, TblEducation entity)
        {
            await _educationDal.Update(id, entity);
        }
        public async Task<List<EducationQueryDTO>> EducationQuery()
        {
            return await _educationDal.EducationQuery();
        }
    }
}
