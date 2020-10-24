using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Registro_Detalle.Entidades;


namespace Registro_Detalle.DAL{

    public class Contexto : DbContext{
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos{ get; set;}
        public DbSet<Suplidores> Suplidores { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source= DATA/Ordenes.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidorID=1, Nombres="Ramon"});
        modelBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidorID=2, Nombres="Pablo"});
        modelBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidorID=3, Nombres="Cristian"});


        modelBuilder.Entity <Productos>().HasData(new Productos {ProductosID=1, Descripcion="Arroz", Costo= 22, Inventario=10});
        modelBuilder.Entity <Productos>().HasData(new Productos {ProductosID=2, Descripcion="Azucar", Costo= 50, Inventario=6});
        modelBuilder.Entity <Productos>().HasData(new Productos {ProductosID=3, Descripcion="Chocolate", Costo= 25, Inventario=20});

    }

 }   
}