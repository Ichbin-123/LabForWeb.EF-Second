﻿// <auto-generated />
using System;
using LabForWeb.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabForWeb.DAL.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArticoloCategoria", b =>
                {
                    b.Property<int>("ArticoliId")
                        .HasColumnType("int");

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.HasKey("ArticoliId", "CategorieId");

                    b.HasIndex("CategorieId");

                    b.ToTable("ArticoloCategoria");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Articolo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutoreId")
                        .HasColumnType("int");

                    b.Property<string>("Testo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AutoreId");

                    b.ToTable("Articoli");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.ArticoloTag", b =>
                {
                    b.Property<string>("TagId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ArticoloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAssociazione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("TagId", "ArticoloId");

                    b.HasIndex("ArticoloId");

                    b.ToTable("ArticoloTag");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Commento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticoloId")
                        .HasColumnType("int");

                    b.Property<int>("AutoreId")
                        .HasColumnType("int");

                    b.Property<string>("Testo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ArticoloId");

                    b.HasIndex("AutoreId");

                    b.ToTable("Commenti");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("ArticoloCategoria", b =>
                {
                    b.HasOne("LabForWeb.DAL.Models.Articolo", null)
                        .WithMany()
                        .HasForeignKey("ArticoliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabForWeb.DAL.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Articolo", b =>
                {
                    b.HasOne("LabForWeb.DAL.Models.Utente", "Autore")
                        .WithMany("Articoli")
                        .HasForeignKey("AutoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autore");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.ArticoloTag", b =>
                {
                    b.HasOne("LabForWeb.DAL.Models.Articolo", "Articolo")
                        .WithMany("ArticoloTags")
                        .HasForeignKey("ArticoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabForWeb.DAL.Models.Tag", "Tag")
                        .WithMany("ArticoloTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articolo");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Commento", b =>
                {
                    b.HasOne("LabForWeb.DAL.Models.Articolo", null)
                        .WithMany("Commenti")
                        .HasForeignKey("ArticoloId");

                    b.HasOne("LabForWeb.DAL.Models.Utente", "Autore")
                        .WithMany("Commenti")
                        .HasForeignKey("AutoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autore");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Articolo", b =>
                {
                    b.Navigation("ArticoloTags");

                    b.Navigation("Commenti");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Tag", b =>
                {
                    b.Navigation("ArticoloTags");
                });

            modelBuilder.Entity("LabForWeb.DAL.Models.Utente", b =>
                {
                    b.Navigation("Articoli");

                    b.Navigation("Commenti");
                });
#pragma warning restore 612, 618
        }
    }
}
