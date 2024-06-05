﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(SisContext))]
    [Migration("20240604150551_InsertInto_Curso")]
    partial class InsertInto_Curso
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Apellidos");

                    b.Property<int>("Edad")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Edad");

                    b.Property<int>("IdAula")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombres");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("IdAula");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Alumno", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Aula", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Curso", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("Login", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.MaestroDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Acreditado")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("Acreditado");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Estado");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdMatricula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdMatricula");

                    b.ToTable("MaestroDetalle", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("Fecha");

                    b.Property<int>("IdAlumno")
                        .HasColumnType("int");

                    b.Property<int>("IdLogin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdLogin");

                    b.ToTable("Matricula", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Alumno", b =>
                {
                    b.HasOne("Domain.Entity.Aula", "Aula")
                        .WithMany("Alumnos")
                        .HasForeignKey("IdAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Categoria", "Categoria")
                        .WithMany("Alumnos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Entity.MaestroDetalle", b =>
                {
                    b.HasOne("Domain.Entity.Curso", "Curso")
                        .WithMany("MaestroDetalles")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Matricula", "Matricula")
                        .WithMany("MaestroDetalles")
                        .HasForeignKey("IdMatricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("Domain.Entity.Matricula", b =>
                {
                    b.HasOne("Domain.Entity.Alumno", "Alumno")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Login", "Login")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Domain.Entity.Alumno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Domain.Entity.Aula", b =>
                {
                    b.Navigation("Alumnos");
                });

            modelBuilder.Entity("Domain.Entity.Categoria", b =>
                {
                    b.Navigation("Alumnos");
                });

            modelBuilder.Entity("Domain.Entity.Curso", b =>
                {
                    b.Navigation("MaestroDetalles");
                });

            modelBuilder.Entity("Domain.Entity.Login", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Domain.Entity.Matricula", b =>
                {
                    b.Navigation("MaestroDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
