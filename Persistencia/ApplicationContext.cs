using Dominio;
using Microsoft.EntityFrameworkCore;
namespace Persistencia
{
    public class ApplicationContext: DbContext
    {

        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog = NetCore_Asp;Integrated Security = True";
         public DbSet<Persona> Personas { get; set; }

        public ApplicationContext() { }

            public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer(connectionString);
            }
        }
    }
}