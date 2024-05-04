using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract
{
    public interface IUnitOfWorks
    {
        void Save();
        Task<int> SaveAsync();
    }
}
