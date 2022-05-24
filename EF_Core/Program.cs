using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EF_Core.Data;
using EF_Core.Domain;
using EF_Core.ValueObjects;

namespace EF_Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Verificando se tem migrações pendentes
            //MigracoesPendentes();

            //Inserindo dados na base
            //InserirDados();

            InserirDadosEmMassa();

            Console.ReadLine();
        }
        private static void InserirDados()
        {
            using (var db = new ApplicationContext())
            {
                var produto = new Produto
                {
                    CodigoBarras = "22222222222222222222",
                    Descricao = "Açucar",
                    Valor = 6m,
                    TipoProduto = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                };

                //Maneiras que o entity rastreia os dados
                db.Produtos.Add(produto);
                //db.Set<Produto>().Add(produto);
                //db.Entry(produto).State = EntityState.Added;
                //db.Add(produto);

                //salvando dados na base com SaveChanges
                var registros = db.SaveChanges();

                Console.WriteLine($"Total de Registros: {registros}");
            }
        }

        private static void InserirDadosEmMassa()
        {
            using (var db = new ApplicationContext())
            {
                var produto = new Produto
                {
                    CodigoBarras = "22222222222222222222",
                    Descricao = "Salmon",
                    Valor = 81.98m,
                    TipoProduto = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                };

                var cliente = new Cliente
                {
                    Nome = "Asael João da Silva",
                    CEP = "08345589",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Telefone = "11949583651"
                };

                var listaCliente = new[]
                {
                    new Cliente
                    {
                        Nome = "Jonatas João da Silva",
                        CEP = "08589632",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Telefone = "11123456789"
                    },
                    new Cliente
                    {
                        Nome = "Lais Cravalho de Lima",
                        CEP = "01234567",
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ",
                        Telefone = "11987456321"
                    },
                    new Cliente
                    {
                        Nome = "Luis Teodoroda Silva",
                        CEP = "08345589",
                        Cidade = "Belo Horizonte",
                        Estado = "BH",
                        Telefone = "11987612345"
                    },
                    new Cliente
                    {
                        Nome = "Amanda nunes Duarte",
                        CEP = "08345589",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Telefone = "11949583651"
                    },
                };

                //db.AddRange(produto, cliente);
                db.AddRange(listaCliente);

                var registros = db.SaveChanges();

                Console.WriteLine($"Total de registro(s): {registros}");

            }
        }
        private static void MigracoesPendentes()
        {
            using (var db = new ApplicationContext())
            {
                var existe = db.Database.GetAppliedMigrations().Any();

                if (existe)
                    Console.WriteLine("Existe migrações pendentes!");
                else
                    Console.WriteLine("Sem migrações!");
            }
        }
    }
}