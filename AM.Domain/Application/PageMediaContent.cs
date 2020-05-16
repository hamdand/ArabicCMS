
using System;

namespace AML.Domain.Application
{
    public class PageMediaContent
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Desecription { get; set; }
        public virtual string FilePath { get; set; }
        public virtual bool IsEnglishFile { get; set; }
        public virtual DateTime FileDate { get; set; }
        public virtual string FileIcon { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string UserId { get; set; }
    }
}
