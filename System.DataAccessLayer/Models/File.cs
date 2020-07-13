using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace System.DataAccessLayer.Models
{
    public class File
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[MaxLength(150)]
        public string Title { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastModified { get; set; }
        public float? FileSize { get; set; }
        //[MaxLength(10)]
        public string FileExtension { get; set; }
        public byte[] Content { get; set; }
    }
}
