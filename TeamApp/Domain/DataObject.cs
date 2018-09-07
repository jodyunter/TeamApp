using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class DataObject
    {
        int? Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModifiedOn { get; set; }

    }
}
