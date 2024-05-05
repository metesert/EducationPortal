using EducationPortal.DataAccess.Abstract;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class ProcessDal : GenericRepository<TblProcess>, IProcessDal
    {
        public ProcessDal(EducationPortalContext ctx) : base(ctx)
        {
        }
    }
}



