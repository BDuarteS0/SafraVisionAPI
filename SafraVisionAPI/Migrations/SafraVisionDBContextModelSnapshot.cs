﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafraVisionAPI.Data;

#nullable disable

namespace SafraVisionAPI.Migrations
{
    [DbContext(typeof(SafraVisionDBContext))]
    partial class SafraVisionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SafraVisionAPI.Models.PessoaModel", b =>
                {
                    b.Property<int>("idPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPessoa"), 1L, 1);


                    b.Property<string>("nomePessoa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("idPessoa");

                    b.ToTable("Pessoa");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PessoaModel");
                });

            modelBuilder.Entity("SafraVisionAPI.Models.UsuarioModel", b =>
                {
                    b.HasBaseType("SafraVisionAPI.Models.PessoaModel");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UsuarioModel");
                });
#pragma warning restore 612, 618
        }
    }
}