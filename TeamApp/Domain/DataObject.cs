using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamApp.Domain
{
    public class DataObject
    {        
        public virtual long Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime LastModifiedOn { get; set; }

    }
}
