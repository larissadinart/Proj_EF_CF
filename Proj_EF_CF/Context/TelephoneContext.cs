using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj_EF_CF.Models;

namespace Proj_EF_CF.Context
{
    internal class TelephoneContext : DbContext
    {
        public DbSet<Telephone>Phones { get; set; }
    }
}
