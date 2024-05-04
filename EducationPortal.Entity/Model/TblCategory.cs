using System;
using System.Collections.Generic;

namespace EducationPortal.UI;

public partial class TblCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    //public virtual ICollection<TblEducation> TblEducations { get; set; } = new List<TblEducation>();
}
