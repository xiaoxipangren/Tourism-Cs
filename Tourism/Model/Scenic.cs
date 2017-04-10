using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tourism.Model
{
    public class Scenic:BaseEntity
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int? CostTime { get; set; }
        public int? Pics { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Traffic> Traffics { get; set; }
        public virtual ICollection<OpenSpan> OpenTimes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Category Category { get; set; }
    }
}
