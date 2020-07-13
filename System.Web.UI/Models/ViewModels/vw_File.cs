using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Web.UI.Models.ViewModels
{
    public class vw_File
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastModified { get; set; }
        public float? FileSize { get; set; }
        public string FileExtension { get; set; }
        public byte[] Content { get; set; }
    }
}
