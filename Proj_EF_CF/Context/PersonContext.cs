using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj_EF_CF.Models;

namespace Proj_EF_CF.Context
{
    internal class PersonContext : DbContext
    {
        public DbSet<Person>People { get; set; }
    }
}
