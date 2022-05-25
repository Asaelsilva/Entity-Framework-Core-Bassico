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

            //InserirDados();

            //InserirDadosEmMassa();

            //ConsultarDados();

            //CadastarPedido();

            //ConsultarPedidoCarregamentoAdiantado();

            //AtualizarDados();

            Console.ReadLine();
        }
        
        private static void AtualizarDados()
        {
            using (var db = new ApplicationContext())
            {
                var prod = db.Produtos.Where(p => p.Id == new Guid("B828D973-34C4-4E8D-1DBF-08DA3D8D0679")).FirstOrDefault();

                prod.CodigoBarras = "12311111111111111120";
                //db.Produtos.Update(produto);

                db.SaveChanges();
            }
        }
        private static void ConsultarPedidoCarregamentoAdiantado()
        {
            using (var db = new ApplicationContext())
            {
                var pedido = db.Pedidos
                    .Include(p => p.Itens)
                    .ThenInclude(p => p.Produto)
                    .Include(p => p.Cliente).ToList();

                Console.WriteLine(pedido.Count);



                var pedidos = from pedidoo in db.Pedidos
                               join itens in db.PedidoItems on pedidoo.Id equals itens.PedidoId  
                               join produto in db.Produtos on itens.ProdutoId equals produto.Id 
                               join cliente in db.Clientes on pedidoo.ClienteId equals cliente.Id
                               select pedidoo;

                Console.WriteLine(pedidos.Count());
            }
        }

        private static void CadastarPedido()
        {
            using (var db = new ApplicationContext())
            {
                var cliente = db.Clientes.FirstOrDefault();
                var produto = db.Produtos.FirstOrDefault();
                var pedido = new Pedido
                {
                    ClienteId = cliente.Id,
                    IniciadoEm = DateTime.Now,
                    FinalizadoEm = DateTime.Now,
                    Observacao = "Pedido Teste",
                    StatusPedido = StatusPedido.Analise,
                    TipoFrete = TipoFrete.SemFrete,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem
                        {
                            ProdutoId = produto.Id,
                            Desconto = 0,
                            Quantidade = 1,
                            Valor = 10m,
                        }
                    }
                };

                db.Pedidos.Add(pedido);
                db.SaveChanges();
                
            }
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
                //db.Set<Cliente>().AddRange(listaCliente);

                var registros = db.SaveChanges();

                Console.WriteLine($"Total de registro(s): {registros}");

            }
        }
        private static void ConsultarDados()
        {
            using (var db = new ApplicationContext())
            {
                //Maneiras de realizar um select com o entity

                //var consultaPorSintaxe = (from c in db.Clientes
                //                            orderby c.Nome ascending
                //                            select c).ToList();

                //var consultaPorSintaxe = db.Clientes.FromSqlRaw(@"SELECT * FROM CLIENTES").ToList();
                //var clientes = db.Clientes.Where(p => !p.Id.Equals("0")).ToList();
                var clientes = db.Clientes;
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