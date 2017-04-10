using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MySql.Data.Entity;
using Tourism.Model;

namespace Tourism.Data
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=Tourism")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Vistor> Vistors { get; set; }
        public virtual DbSet<Scenic> Scenics { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Nearby> Nearbys { get; set; }
    }
}
