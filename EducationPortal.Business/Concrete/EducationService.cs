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
        public void Delete(TblEducation entity)
        {
            _educationDal.Delete(entity);
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
        public void Update(TblEducation entity)
        {
            _educationDal.Update(entity);
        }
        public async Task<List<EducationQueryDTO>> EducationQuery()
        {
            return await _educationDal.EducationQuery();
        }
    }
}
