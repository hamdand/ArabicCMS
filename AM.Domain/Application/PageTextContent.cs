using System;
using System.Collections.Generic;
using System.Text;

namespace AML.Domain.Application
{
    public class PageTextContent
    {
        public virtual int Id { get; set; }
        public virtual string TextArabic { get; set; }
        public virtual string TextEnglish { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual string UserId { get; set; }
    }
}
