using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entity.Dto
{
    public class FileDTO
    {
        [Required]
        public int EducationID { get; set; }
        [Required]
        public IFormFile? Files { get; set; }
    }
}
