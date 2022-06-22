using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Entities;

namespace WebApplication2.Data_DB
{
    public class Context_DB : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public Context_DB()
        {

        }
      
        public Context_DB(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            //foreach (var property in mutableProperties)
            //    property.Relational().ColumnType = "varchar(100)";

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context_DB).Assembly);
           // modelBuilder.ApplyConfiguration(new RoleForStudentsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=Ex;trusted_connection=true;");
            }
        }
    }
}
