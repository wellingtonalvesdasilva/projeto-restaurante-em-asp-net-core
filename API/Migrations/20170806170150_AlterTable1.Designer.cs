using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Models;

namespace API.Migrations
{
    [DbContext(typeof(SistemaDeRestauranteContext))]
    [Migration("20170806170150_AlterTable1")]
    partial class AlterTable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Prato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraInsercao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<long>("Restaurante_Id");

                    b.HasKey("Id");

                    b.HasIndex("Restaurante_Id");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("Models.Restaurante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraInsercao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Models.Prato", b =>
                {
                    b.HasOne("Models.Restaurante", "Restaurante")
                        .WithMany("Pratos")
                        .HasForeignKey("Restaurante_Id");
                });
        }
    }
}
