// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentsServise.StudentsData;

#nullable disable

namespace StudentsServise.Migrations
{
    [DbContext(typeof(StudentDataContext))]
    [Migration("20220711203720_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentsServise.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Email = "yevtushenko@gmail.com",
                            FirstName = "Oleksandr",
                            LastName = "Yevtushenko"
                        },
                        new
                        {
                            StudentId = 2,
                            Email = "kozhyn@gmail.com",
                            FirstName = "Viktor",
                            LastName = "Kozhyn"
                        },
                        new
                        {
                            StudentId = 3,
                            Email = "karpenko@gmail.com",
                            FirstName = "Mykola",
                            LastName = "Karpenko"
                        },
                        new
                        {
                            StudentId = 4,
                            Email = "shyrin@gmail.com",
                            FirstName = "Roman",
                            LastName = "Shyrin"
                        },
                        new
                        {
                            StudentId = 5,
                            Email = "karpneko@gmail.com",
                            FirstName = "Mykola",
                            LastName = "Karpenko"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
