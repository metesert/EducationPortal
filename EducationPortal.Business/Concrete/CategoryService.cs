using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Concrete;
using EducationPortal.UI;

namespace EducationPortal.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal educationDal)
        {
            _categoryDal = educationDal;
        }
        public async Task Delete(int id)
        {
            await _categoryDal.Delete(id);
        }
        public List<TblCategory> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public async Task<List<TblCategory>> GetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }
        public TblCategory GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public async Task<TblCategory> GetByIdAsync(int id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }
        public void Insert(TblCategory entity)
        {
            _categoryDal.Insert(entity);
        }
        public async Task InsertAsync(TblCategory entity)
        {
            await _categoryDal.InsertAsync(entity);
        }
        public async Task Update(int id, TblCategory entity)
        {
            await _categoryDal.Update(id, entity);
        }
    }
}
