using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tourism.Model
{
    public class Nearby
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        [Key,Column(Order =2)]
        [ForeignKey("Near")]
        public int NearbyId { get; set; }

        public decimal? Distance { get; set; }


        public virtual Scenic Center { get; set; }
        public virtual Scenic Near{ get; set; }
    }
}
