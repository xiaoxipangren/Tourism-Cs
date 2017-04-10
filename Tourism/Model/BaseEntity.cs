using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Model
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
