using System;
using System.Collections.Generic;
using System.Text;

namespace AML.Domain.Application
{
    public class PageContentType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual string UserId { get; set; }
    }
}
