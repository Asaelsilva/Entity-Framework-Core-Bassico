using EF_Core.Data.Configurations;
using EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Cliente> Clientes { get; set; }    
        public DbSet<Pedido> Pedidos { get; set; }    
        public DbSet<PedidoItem> PedidoItems { get; set; }    
        public DbSet<Produto> Produtos { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data source=DESKTOP-E79S2CD\\SQL_ASAEL; Initial Catalog= CursoEFCoreBasico_DIO; Integrated Security= True");
                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Instanciando classe por classe dos orquivos de configurtação
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            //modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            //Ira procurar todas as classes concretas que estão implementando a Interface IEntityTypeConfiguration neste Assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
