using System;
using System.Collections.Generic;

namespace EducationPortal.UI;

public partial class TblEducationFile
{
    public int Id { get; set; }

    public int EducationId { get; set; }
    public string? Name { get; set; }

    public byte[] Files { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
