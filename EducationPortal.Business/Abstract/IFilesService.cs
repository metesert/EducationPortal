using EducationPortal.DataAccess.Abstract;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract
{
    public interface IFilesService : IGenericRepository<TblEducationFile>
    {
    }
}
