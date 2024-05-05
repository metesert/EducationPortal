using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Concrete;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete
{
    public class FilesService : IFilesService
    {
        private readonly IFilesDal _filesDal;

        public FilesService(IFilesDal filesDal)
        {
            _filesDal = filesDal;
        }
        public async Task Delete(int id)
        {
            await _filesDal.Delete(id);
        }

        public List<TblEducationFile> GetAll()
        {
            return _filesDal.GetAll();
        }

        public async Task<List<TblEducationFile>> GetAllAsync()
        {
            return await _filesDal.GetAllAsync();
        }

        public TblEducationFile GetById(int id)
        {
            return _filesDal.GetById(id);
        }

        public Task<TblEducationFile> GetByIdAsync(int id)
        {
            return _filesDal.GetByIdAsync(id);
        }

        public void Insert(TblEducationFile entity)
        {
            _filesDal.Insert(entity);
        }

        public async Task InsertAsync(TblEducationFile entity)
        {
            await _filesDal.InsertAsync(entity);
        }
        public async Task Update(int id, TblEducationFile entity)
        {
            await _filesDal.Update(id, entity);
        }
    }
}
