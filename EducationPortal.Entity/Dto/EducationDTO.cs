using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entity.Dto
{
    public class EducationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int EductorID { get; set; }
        [Required]
        public int Quota { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public TimeSpan Time { get; set; }

        public string CategoryName { get; set; }


    }
}
