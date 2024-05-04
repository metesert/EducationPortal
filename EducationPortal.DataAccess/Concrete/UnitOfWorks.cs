using EducationPortal.DataAccess.Abstract;
using EducationPortal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly EducationPortalContext _context;
        public UnitOfWorks(EducationPortalContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}
