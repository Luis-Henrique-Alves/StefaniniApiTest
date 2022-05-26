using Example.Domain.CityAggregate;
using Example.Domain.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class ExampleContext : DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Person> Person { get; set; }
        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.Entity<City>();
            modelBuilder.Entity<Person>();

        }

        public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
        {
            public void Configure(EntityTypeBuilder<City> orderConfiguration)
            {
                orderConfiguration.ToTable("City", "dbo");

                orderConfiguration.HasKey(o => o.Id);
                orderConfiguration.Property(o => o.Id).UseIdentityColumn();
                orderConfiguration.Property(o => o.Name).IsRequired();
                orderConfiguration.Property(o => o.State).IsRequired();
                orderConfiguration.HasMany(x => x.People)
                    .WithOne(X => X.City)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
        public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
        {
            public void Configure(EntityTypeBuilder<Person> orderConfiguration)
            {
                orderConfiguration.ToTable("Person", "dbo");

                orderConfiguration.HasKey(o => o.Id);
                orderConfiguration.Property(o => o.Id).UseIdentityColumn();
                orderConfiguration.Property(o => o.Name).IsRequired();
                orderConfiguration.Property(o => o.DocumentNumber).IsRequired();
                orderConfiguration.Property(o => o.Age).IsRequired();
                orderConfiguration
                  .HasOne(x => x.City)
                  .WithMany(y => y.People).HasForeignKey(x => x.IdCity);

            }
        }
    }

}
