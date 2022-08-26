using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //For Database

namespace Varastohallinta
{
    public class Varastonhallinta : DbContext
    {
        public DbSet<Tuote>? Tuotteet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Varastonhallinta;" +
                "Integrated Security=true;" +   //"User Id=sa;" + "Password=password"
                "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
