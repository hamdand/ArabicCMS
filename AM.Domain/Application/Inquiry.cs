using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Domain.Application
{
    public class Inquiry
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int SortId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual string UserId { get; set; }
        public virtual bool IsPublic { get; set; }
        public virtual bool IsClosed { get; set; }
        public virtual bool IsArabic { get; set; }
        public virtual IList<InquiryAnswer> Answers { get; set; }
    }
}
