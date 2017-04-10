using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Model
{
    public class Vistor:BaseEntity
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int? Age { get; set; }
        public int? Level { get; set; }
        public string Vocation { get; set; }
        public string Education { get; set; }
        public decimal? Income { get; set; }
        public decimal? Cost { get; set; }
    }

    public enum Sex
    {
        Male=0,
        Female
    }
}
