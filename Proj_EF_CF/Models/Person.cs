using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_CF.Models
{
    internal class Person : Telephone
    {
        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Telephone Telephone { get; set; }
        public override string ToString()
        {
            return $"Nome: {this.Name}\nE-mail: {this.Email}\nTelefone: {this.Phone}\nCelular:{this.Mobile}";
        }
    }
}
