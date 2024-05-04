using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract
{
    public interface IEducationService : IGenericRepository<TblEducation>
    {

        public Task<List<EducationQueryDTO>> EducationQuery();
    }
}
