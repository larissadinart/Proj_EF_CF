using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_CF.Models
{
    public class Person 
    {
        [Key]
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
