using System;
using System.Collections.Generic;
using System.Text;

namespace System.DataAccessLayer.Models
{
    public abstract class BaseInfoModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
