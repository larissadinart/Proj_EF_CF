using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Proj_EF_CF.Context;
using Proj_EF_CF.Models;

namespace Proj_EF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            using (var context = new PersonContext())
            {
                Console.Clear();
                Console.WriteLine("O que gostaria de fazer?\n\n[1] Cadastrar Contato\n[2] Remover Contato\n[3] " +
                    "Listar Agenda Completa\n[4] Buscar Contato\n[5] Alterar Contato");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        #region INSERIR DADOS 
                        Console.Clear();
                        Telephone t = new Telephone();
                        Person p = new Person();

                        using (var cont = new PersonContext())
                        {
                            Console.WriteLine(">>> ADICIONAR CONTATO: <<<\n\n");
                            Console.WriteLine("Digite o nome do contato: ");
                            p.Name = Console.ReadLine();
                            Console.WriteLine("Digite o e-mail do contato: ");
                            p.Email = Console.ReadLine();
                            Console.WriteLine("Digite o número de telefone: ");
                            t.Phone = Console.ReadLine();
                            Console.WriteLine("Digite o número de celular: ");
                            t.Mobile = Console.ReadLine();
                            t.Name = p.Name; 
                            context.Phones.Add(t);
                            context.People.Add(p);
                            context.SaveChanges();
                            Console.WriteLine("\nContato Salvo com Sucesso!!\n\nAperte enter para continuar.");
                            Console.ReadKey();
                        }
                        Menu();
                        #endregion 
                        break;
                    case 2:
                        #region REMOVE //problemas com a chave estrangeira, não está removendo
                        Telephone phone = new Telephone();
                        Console.Clear();
                        Console.WriteLine(">>> REMOVER CONTATO: <<<\n\n");
                        Console.WriteLine("Digite o nome que deseja remover: ");
                        phone.Name = Console.ReadLine();
                        var p1 = context.Phones.FirstOrDefault(d => d.Name == phone.Name);
                        if (p1 != null)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine(phone.ToString());
                            Console.WriteLine("\nDeseja apagar este registro?\n\n[1] Sim\n[2] Não");
                            int opcao = int.Parse(Console.ReadLine());
                            switch (opcao)
                            {
                                case 1:
                                    context.Entry(phone).State = EntityState.Deleted;
                                    context.Phones.Remove(phone);
                                    context.SaveChanges();
                                    Console.WriteLine("\nContato excluído com sucesso!\n\nAperte enter para continuar");
                                    Console.ReadKey();
                                    Menu();
                                    break;
                                case 2:Menu();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado!");
                        }

                        #endregion
                        break;
                    case 3:
                        #region LISTAR TUDO // está funcionando, falta apenas tratamento de usuário

                        Console.Clear();
                        Console.WriteLine(">>> VER TODOS OS CONTATOS: <<<\n\n");

                        var phones = new PersonContext().Phones.ToList();

                        foreach (var item in phones)
                        {
                            Console.WriteLine(item.ToString());
                            Console.WriteLine("\n");
                        }
                        Console.WriteLine("Dados Listados!\n\nDigite enter para continuar.");
                        Console.ReadKey();
                        Menu();
                        #endregion
                        break;
                    case 4:
                        #region BUSCAR ESPECIFICO 

                        Console.Clear();
                        Console.WriteLine(">>> BUSCAR CONTATO: <<<\n");
                        Telephone person = new Telephone();
                        Console.WriteLine("Digite o nome que deseja buscar: ");
                        Console.WriteLine("\n");
                        person.Name = Console.ReadLine();
                        var find = context.Phones.FirstOrDefault(y => y.Name == person.Name);

                        if (find != null) {

                            Console.WriteLine("\n");
                            Console.WriteLine(find.ToString());
                            Console.WriteLine("\n");
                            Console.WriteLine("\nDigite enter para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado!\n\nAperte enter para continuar.");
                        }
                        Menu();
                        #endregion
                        break;
                    case 5:
                        #region UPDATE // funcionando alteração de telefone e celular
                        Telephone pessoa = new Telephone();
                        Console.Clear();
                        Console.WriteLine(">>> ALTERAR CONTATO: <<<\n\n");
                        Console.WriteLine("Digite o nome do contato que deseja alterar: ");
                        pessoa.Name  = Console.ReadLine();
                        var findx = context.Phones.FirstOrDefault(f => f.Name == pessoa.Name);

                        if (findx != null)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine(findx.ToString());
                            Console.WriteLine("\nAperte enter para alterar.");
                            Console.ReadKey();
                            Console.WriteLine("\nQual dado deseja alterar?\n\n[1] Nome\n[2] Telefone\n[3] Celular");
                            int option = int.Parse(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Alterar nome:\n\n");
                                    string n = Console.ReadLine();
                                    findx.Name = n;
                                    context.Entry(findx).State = EntityState.Modified;
                                    context.SaveChanges();
                                    Console.WriteLine("\nDado alterado!\n\n enter para continuar.");
                                    Console.ReadKey();
                                    Menu();
                                    break;
                                case 2:
                                    Console.WriteLine("Alterar Telefone:\n\n");
                                    string tel = Console.ReadLine();
                                    findx.Phone = tel;
                                    context.Entry(findx).State = EntityState.Modified;
                                    context.SaveChanges();
                                    Console.WriteLine("\nDado alterado!\n\n enter para continuar.");
                                    Console.ReadKey();
                                    Menu();
                                    break;
                                case 3:
                                    Console.WriteLine("Alterar Celular:\n\n");
                                    string cel = Console.ReadLine();
                                    findx.Mobile = cel;
                                    context.Entry(findx).State = EntityState.Modified;
                                    context.SaveChanges();
                                    Console.WriteLine("\nDado alterado!\n\n enter para continuar.");
                                    Console.ReadKey();
                                    Menu();
                                    break;
                            }
                        }
                        break;
                        #endregion
                }
            }
        }
    }
}
