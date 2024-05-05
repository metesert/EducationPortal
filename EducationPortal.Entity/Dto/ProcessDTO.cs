using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entity.Dto
{
    public class ProcessDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int EducationID { get; set; }
        [Required]
        public bool Isdeleted { get; set; }

    }
}
