using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistencia
{
    public class ApplicationContext: IdentityDbContext<Usuario>
    {

        //private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog = NetCore_Asp;Integrated Security = True";
         public DbSet<Empleado> Empleados { get; set; }

        public ApplicationContext() { }

            public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //    if(!optionsBuilder.IsConfigured){
        //        optionsBuilder
        //        .UseSqlServer(connectionString);
        //    }
        //}
    }
}