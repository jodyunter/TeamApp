using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamApp.Domain
{
    public interface IDataObject
    {        
        long Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModifiedOn { get; set; }
        bool Equals(object other);


    }
}
