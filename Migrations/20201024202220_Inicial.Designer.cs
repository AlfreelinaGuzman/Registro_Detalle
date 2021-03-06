﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Detalle.DAL;

namespace Registro_Detalle.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20201024202220_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Registro_Detalle.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuplidorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenID");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Registro_Detalle.Entidades.OrdenesDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuplidorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OrdenID");

                    b.HasIndex("ProductosID");

                    b.HasIndex("SuplidorID");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("Registro_Detalle.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Inventario")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductosID");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductosID = 1,
                            Costo = 22m,
                            Descripcion = "Arroz",
                            Inventario = 10
                        },
                        new
                        {
                            ProductosID = 2,
                            Costo = 50m,
                            Descripcion = "Azucar",
                            Inventario = 6
                        },
                        new
                        {
                            ProductosID = 3,
                            Costo = 25m,
                            Descripcion = "Chocolate",
                            Inventario = 20
                        });
                });

            modelBuilder.Entity("Registro_Detalle.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorID");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            SuplidorID = 1,
                            Nombres = "Ramon"
                        },
                        new
                        {
                            SuplidorID = 2,
                            Nombres = "Pablo"
                        },
                        new
                        {
                            SuplidorID = 3,
                            Nombres = "Cristian"
                        });
                });

            modelBuilder.Entity("Registro_Detalle.Entidades.OrdenesDetalle", b =>
                {
                    b.HasOne("Registro_Detalle.Entidades.Ordenes", null)
                        .WithMany("OrdenesDetalle")
                        .HasForeignKey("OrdenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Detalle.Entidades.Productos", null)
                        .WithMany("OrdenesDetalle")
                        .HasForeignKey("ProductosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Detalle.Entidades.Suplidores", null)
                        .WithMany("OrdenesDetalle")
                        .HasForeignKey("SuplidorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
