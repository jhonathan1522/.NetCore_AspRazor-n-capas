using Dominio;
using Microsoft.EntityFrameworkCore;
namespace Persistencia
{
    public class PersonaContext: DbContext
    {

        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog = Borrame;Integrated Security = True";
         public DbSet<Persona> personas { get; set; }
         public DbSet<Carro> carros { get; set; }

        public PersonaContext() { }

            public PersonaContext(DbContextOptions<PersonaContext> options)
            :base(options)
        {
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //    if(!optionsBuilder.IsConfigured){
        //        optionsBuilder
        //        .UseSqlServer(connectionString);
        //    }
        //}
    }
}