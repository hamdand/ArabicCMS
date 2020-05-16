using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Domain.Application
{
    public class Entity
    {
        public virtual int Id { get; set; }
        public virtual string NameArabic { get; set; }
        public virtual string NameEnglish { get; set; }
        public virtual string Name { get; set; }
        public virtual string LogoURL { get; set; }
        public virtual string UserId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int SortId { get; set; }
    }
}
