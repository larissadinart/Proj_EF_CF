using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj_EF_CF.Context;
using Proj_EF_CF.Models;

namespace Proj_EF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PersonContext())
            {
                #region INSERIR DADOS
                context.People.Add(new Person() { Name = "Rufus", Email = "lari_dinart@hotmail.com", Phone = "888888888", Mobile = "997400669" });
                context.SaveChanges();
                #endregion

                #region LISTAR TUDO
                var people = new PersonContext().People.ToList();
                foreach (var item in people)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Dados Listados!\n\nDigite enter para continuar.");
                Console.ReadKey();
                #endregion

                #region BUSCAR ESPECIFICO
                Console.WriteLine("Digite o nome que deseja buscar: ");
                string n = Console.ReadLine();
                Person find = new PersonContext().People.FirstOrDefault(f => f.Name == n);
                if (find != null)
                    Console.WriteLine(find.ToString());
                Console.WriteLine("Digite enter para continuar.");
                Console.ReadKey();
                #endregion

                #region REMOVE
                Console.WriteLine("Digite o nome que deseja remover: ");
                string x = Console.ReadLine();
                Person name = new PersonContext().People.FirstOrDefault(f => f.Name == x);
                context.Entry(name).State = EntityState.Deleted;
                context.People.Remove(name);
                context.SaveChanges();
                Console.WriteLine("Dados Removidos!\n\nDigite enter para continuar.");
                Console.ReadKey();
                #endregion

                #region UPDATE
                Console.WriteLine("Digite o nome buscado para alterar: ");
                string y = Console.ReadLine();
                Person findx = new PersonContext().People.FirstOrDefault(f => f.Name == y);

                if (findx != null)
                {
                    context.Entry(findx).State = EntityState.Modified;
                    findx.Name = "Paula";
                    context.SaveChanges();
                }
                Console.WriteLine("Dado alteraido!\n\n enter para continuar.");
                Console.ReadKey();
                #endregion

            }

        }


    }
}
