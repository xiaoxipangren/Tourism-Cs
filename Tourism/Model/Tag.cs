using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tourism.Model
{
    public class Tag:BaseEntity
    {
        [ForeignKey("Scenic")]
        public int ScenicId { get; set; }
        public string Content { get; set; }

        public virtual Scenic Scenic { get; set; }
    }
}
