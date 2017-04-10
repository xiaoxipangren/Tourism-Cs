using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Model
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Scenic> Scenics { get; set; }
    }
}
