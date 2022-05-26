using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


#nullable disable

namespace Example.Infra.Data.Migrations
{
    [DbContext(typeof(ExampleContext))]
    partial class ExampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {

            modelBuilder
                .HasAnnotation("ProductVersion", "1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Example.Domain.CityAggregate.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("District")
                     .IsRequired()
                     .HasColumnType("nvarchar(2)");

                    b.HasMany("People")
                    .WithOne("City")
                    .OnDelete(DeleteBehavior.Cascade);

                    b.HasKey("Id");

                    b.ToTable("City", "dbo");
                });

            modelBuilder.Entity("Example.Domain.PersonAggregate.Person", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(200)");

                b.Property<string>("DocumentNumber")
                 .IsRequired()
                 .HasColumnType("nvarchar(11)");

                b.Property<int>("Age")
                 .IsRequired()
                 .HasColumnType("int)");


                b.Property<int>("CityId")
                 .IsRequired()
                 .HasColumnType("int)");

                b.HasOne("City")
                  .WithMany("People");

                b.HasKey("Id");

                b.ToTable("Person", "dbo");
            });
       
        }
