using System;
using System.Collections.Generic;
using System.Text;

namespace AML.Domain.Helper
{
    public class FileIcon
    {
        public virtual int Id { get; set; }
        public virtual string FileExtension { get; set; }
        public virtual string IconPath { get; set; }
        public virtual string UserId { get; set; }
    }
}
