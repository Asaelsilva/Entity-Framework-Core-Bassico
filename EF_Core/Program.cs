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