using EF_Core.Data.Configurations;
using EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data
{
    public class ApplicationContext : DbContext
    {       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-E79S2CD\\SQL_ASAEL; Initial Catalog= CursoEFCoreBasico_DIO; Integrated Security= True");
            
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
