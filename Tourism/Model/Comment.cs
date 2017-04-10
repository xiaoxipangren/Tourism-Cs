using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tourism.Model
{
    public class Comment:BaseEntity
    {
        [Key,Column(Order =1)]
        [ForeignKey("Vistor")]
        public int VistorId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Scenic")]
        public int ScenicId { get; set; }
        public int Star { get; set; }
        public int Like { get; set; }
        public bool HasPic { get; set; }
        public bool IsGold { get; set; }

        public string Content { get; set; }

        public virtual Scenic Scenic { get; set; }
        public virtual Vistor Vistor { get; set; }
    }
}
