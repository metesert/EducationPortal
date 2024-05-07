using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract
{
    public interface IEducationDal : IGenericRepository<TblEducation>
    {

        public Task<List<EducationQueryDTO>> EducationQuery();

        


    }
}
