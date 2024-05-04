using System;
using System.Collections.Generic;

namespace EducationPortal.UI;

public partial class TblEducation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public int EductorId { get; set; }

    public int Quota { get; set; }

    public decimal Cost { get; set; }

    public string Time { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    //public virtual TblCategory Category { get; set; } = null!;

    //public virtual TblEducator Eductor { get; set; } = null!;
}
