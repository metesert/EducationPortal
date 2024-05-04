using EducationPortal.DataAccess.Abstract;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class CategoryDal : GenericRepository<TblCategory>, ICategoryDal
    {
        public CategoryDal(EducationPortalContext ctx) : base(ctx)
        {
        }
    }
}
