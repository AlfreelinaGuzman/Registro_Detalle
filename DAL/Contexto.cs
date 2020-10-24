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
    
    protected override void OnModelCreating(ModelBuilder moderBuilder)
    {
        moderBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidoresID=1, Nombres="Ramon"});
        moderBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidoresID=2, Nombres="Pablo"});
        moderBuilder.Entity <Suplidores>().HasData(new Suplidores {SuplidoresID=3, Nombres="Cristian"});

        moderBuilder.Entity <Productos>().HasData(new Productos {ProductosID=1, Descripcion= "Arroz", Costo= 50.99, Inventario= 50});
    }
 }   
}