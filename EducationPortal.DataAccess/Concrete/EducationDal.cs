using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class EducationDal : GenericRepository<TblEducation>, IEducationDal
    {
        private readonly EducationPortalContext _context;
        public EducationDal(EducationPortalContext ctx) : base(ctx)
        {
            _context = ctx;
        }
        public async Task<List<EducationQueryDTO>> EducationQuery()
        {
            var query = await (from a in _context.TblEducations
                               join b in _context.TblCategories on a.CategoryId equals b.Id
                               join c in _context.TblEducators on a.EductorId equals c.Id
                               join d in _context.TblEducationFiles on a.Id equals d.EducationId
                               select new EducationQueryDTO
                               {
                                   EducationId = a.Id,
                                   EducationName = a.Name,
                                   CategoryName = b.Name,
                                   EductorName = c.Name,
                                   Quota = a.Quota,
                                   Time = a.Time,
                                   Cost = a.Cost,
                                   File = d.Files,
                                   FileName = d.Name
                               }).ToListAsync();
            var result = query;
            return result;
        }
    }
}
