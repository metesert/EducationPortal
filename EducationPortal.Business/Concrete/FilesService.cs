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
        public void Delete(TblEducationFile entity)
        {
            _filesDal.Delete(entity);
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
            try
            {
                await _filesDal.InsertAsync(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void Update(TblEducationFile entity)
        {
            _filesDal.Update(entity);
        }
    }
}
