using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Domain.Application
{
    public class InquiryAnswer
    {
        public virtual int Id { get; set; }
        public virtual string Answer { get; set; }
        public virtual int SortId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual string UserId { get; set; }
        public virtual bool IsPublic { get; set; }
        public virtual bool IsArabic { get; set; }
    }
}
