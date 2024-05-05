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

    public TimeSpan Time { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
