using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Domain.Application
{
    [Serializable]
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string NameEnglish { get; set; }
        public virtual string NameArabic { get; set; }
        public virtual string DescriptionArabic { get; set; }
        public virtual string DescriptionEnglish { get; set; }
        public virtual string Description { get; set; }
        public virtual string URL { get; set; }
        public virtual PageContentType ContentType { get; set; }
        public virtual PageTextContent PageText { get; set; }
        public virtual IList<PageMediaContent> PageMedia { get; set; }
        public virtual int SortId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual IList<SubCategory> SubCategories { get; set; }
        public virtual string UserId { get; set; }
    }
}
