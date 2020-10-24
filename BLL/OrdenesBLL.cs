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
    public class OrdenesBLL
    {

        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenID))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Ordenes.Any(o => o.OrdenID== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
        
        private static bool Insertar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;

              /*  List<OrdenesDetalle> detalle = ordenes.OrdenesDetalle;
                foreach (OrdenesDetalle det in detalle)
                {
                    Productos productos = OrdenesBLL.Buscar(det.ProductosID);
                    if (productos != null)
                    {
                        productos.Productos += Convert.ToSingle(det.Monto);
                        OrdenesBLL.Guardar(ProductosID);
                    }
                }*/
                
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

        public static bool Modificar(Ordenes ordenes){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenID = {ordenes.OrdenID}");
                foreach(var anterior in ordenes.OrdenesDetalle)
                {
                    contexto.Entry(anterior).State =EntityState.Added;
                }
                contexto.Entry(ordenes).State = EntityState.Modified;
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
                var ordenes = contexto.Ordenes.Find(id);
                contexto.Entry(ordenes).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Ordenes Buscar(int id){
            Ordenes ordenes = new Ordenes();
            Contexto contexto = new Contexto();
            try{
                ordenes = contexto.Ordenes.Include(x => x.OrdenesDetalle).Where(p => p.OrdenID  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return ordenes;
        }

    public static List <Ordenes> GetList(Expression<Func<Ordenes, bool>> ordenes)
        {
            List<Ordenes> Lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ordenes.Where(ordenes).ToList();
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