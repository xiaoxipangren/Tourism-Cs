using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tourism.Model
{
    public class OpenSpan:BaseEntity
    {
        [ForeignKey("Scenic")]
        public int ScenicId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

        public virtual Scenic Scenic { get; set; }
    }
}
