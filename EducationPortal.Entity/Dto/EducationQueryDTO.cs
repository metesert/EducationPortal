using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entity.Dto
{
    public class EducationQueryDTO
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public string CategoryName { get; set; }
        public string EductorName { get; set; }
        public int Quota { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan Time { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}

