using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_CF.Models
{
    public class Telephone
    {
        [Key]
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }

    //public class People
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public Telephone telephone { get; set; }
    //}
}
