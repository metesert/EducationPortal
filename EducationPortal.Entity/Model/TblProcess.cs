using System;
using System.Collections.Generic;

namespace EducationPortal.UI;

public partial class TblProcess
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EducationId { get; set; }

    public bool IsOk { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
