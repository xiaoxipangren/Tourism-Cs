using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Model
{
    public class Traffic:BaseEntity
    {
        public string Name { get; set; }
        public decimal? Distance { get; set; }

        public virtual ICollection<Scenic> Scenics { get; set; }
    }
}
