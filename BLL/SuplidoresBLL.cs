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
    public class SuplidoresBLL
    {
        
          public static bool Guardar(Suplidores suplidores)
        {
            if (!Existe(suplidores.SuplidorID))
                return Insertar(suplidores);
            else
                return Modificar(suplidores);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Suplidores.Any(o => o.SuplidorID== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
        
        private static bool Insertar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Suplidores.Add(suplidores);
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

        public static bool Modificar(Suplidores suplidores){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenID = {suplidores.SuplidorID}");
                foreach(var anterior in suplidores.OrdenesDetalle)
                {
                    contexto.Entry(anterior).State =EntityState.Added;
                }
                contexto.Entry(suplidores).State = EntityState.Modified;
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
                var suplidores = contexto.Suplidores.Find(id);
                contexto.Entry(suplidores).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Suplidores Buscar(int id){
            Suplidores suplidores = new Suplidores();
            Contexto contexto = new Contexto();
            try{
                suplidores = contexto.Ordenes.Include(x => x.OrdenesDetalle).Where(p => p.SuplidorID  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return suplidores;
        }
        
        public static List <Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidores)
        {
            List<Suplidores> Lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Suplidores.Where(suplidores).ToList();
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