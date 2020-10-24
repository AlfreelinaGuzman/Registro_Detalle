using System;
using System.Collections.Generic;
using System.Text;
using Registro_Detalle.DAL;
using Registro_Detalle.Entidades;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Registro_Detalle.BLL
{
    public class ProductosBLL
    {
          public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductosID ))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Productos.Any(o => o.ProductosID== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
        
        private static bool Insertar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Productos.Add(productos);
                paso = contexto.SaveChanges() > 0;
  
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Productos productos){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where ProductosID = {productos.ProductosID}");
                foreach(var anterior in productos.OrdenesDetalle)
                {
                    contexto.Entry(anterior).State =EntityState.Added;
                }
                contexto.Entry(productos).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges()>0);
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Modificado;
        }

        public static bool Eliminar(int id){
            bool Eliminado = false;
            Contexto contexto = new Contexto();
            try{
                var productos = contexto.Ordenes.Find(id);
                contexto.Entry(productos).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Productos Buscar(int id){
            Productos productos = new Productos();
            Contexto contexto = new Contexto();
            try{
                productos = contexto.Productos.Include(x => x.OrdenesDetalle).Where(p => p.ProductosID  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return productos;
        }

        public static List <Productos> GetList(Expression<Func<Productos, bool>> productos)
        {
            List<Productos> Lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Productos.Where(productos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
    }
    }
}