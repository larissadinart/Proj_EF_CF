using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_CF.Models
{
    public class Telephone
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Person")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public virtual List<Person> Person { get; set; }
        public override string ToString()
        {
            return $"Nome: {this.Name}\nTelefone: {this.Phone}\nMobile: {this.Mobile}";
        }
    }

}
