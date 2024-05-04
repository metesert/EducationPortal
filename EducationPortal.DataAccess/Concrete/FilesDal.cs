using EducationPortal.DataAccess.Abstract;
using EducationPortal.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class FilesDal : GenericRepository<TblEducationFile>, IFilesDal
    {
        public FilesDal(EducationPortalContext ctx) : base(ctx)
        {
        }
    }
}
