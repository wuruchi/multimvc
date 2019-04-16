using DataConsulting.Multimedia.Entidades;
using DataConsulting.Multimedia.Negocio.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Negocio.Main.BusinessRules
{
    public class SeccionBR
    {
        public static SeccionBE GetSeccionById(int IdSeccion)
        {
            SeccionBE seccion = GetSeccionByIdIn(IdSeccion);
            return seccion;
        }

        public static SeccionBE GetSeccionByIdIn(int IdSeccion)
        {
            try
            {
                SeccionBE seccion = new SeccionBE();
                using (IDataReader reader = SeccionDA.GetSeccionById(IdSeccion))
                {
                    if (reader.Read())
                        seccion = new SeccionBE(reader);

                    reader.Close();
                    reader.Dispose();
                }

                MainContext.ClearConnection();
                return seccion;
            }
            catch
            {
                MainContext.ClearConnection();
                throw;
            }
        }

        public static List<SeccionBE> GetSeccion(int IdSeccion, int Estado)
        {
            MainContext db = new MainContext();
            var listatotal = db.Seccion.ToList();
            var lista = listatotal.Where(o => (o.Estado == Estado || Estado == 0) && (o.IdSeccion == IdSeccion || IdSeccion == 0)).ToList();
            return lista;
        }

        public static List<SeccionBE> GetSeccionByFilter(int Estado, string Titulo)
        {
            MainContext db = new MainContext();
            var listatotal = db.Seccion.ToList();
            var lista = listatotal.Where(o => (o.Estado == Estado || Estado == 0) && o.Titulo == Titulo.ToUpper().Trim()).ToList();
            return lista;
        }

        public static string Guardar(SeccionBE oSeccion)
        {
            string mensaje = string.Empty;
            SeccionBE iSeccion;
            List<SeccionBE> Secciones = GetSeccion(0, 0);

            using (MainContext db = new MainContext())
            {
                if (oSeccion.IdSeccion == 0)
                {
                    ValidateIfExists(Secciones, oSeccion);
                    var listaordenada = db.Seccion.ToList().OrderBy(o => o.IdSeccion).ToList();
                    var obj = listaordenada.LastOrDefault();

                    oSeccion.IdSeccion = obj == null ? (short)1 : (short)(obj.IdSeccion + 1);
                    oSeccion.FechaCreacion = DateTime.Now;
                    oSeccion.FechaModificacion = DateTime.Now;
                    db.Seccion.Add(oSeccion);
                }
                else
                {
                    int id = oSeccion.IdSeccion;
                    iSeccion = db.Seccion.FirstOrDefault(x => x.IdSeccion == id);
                    Secciones = Secciones.Where(o => o.IdSeccion != id).ToList();
                    ValidateIfExists(Secciones, oSeccion);

                    iSeccion.Titulo = oSeccion.Titulo;
                    iSeccion.Descripcion = oSeccion.Descripcion;
                    iSeccion.Estado = oSeccion.Estado;
                    iSeccion.IdUsuarioModificador = oSeccion.IdUsuarioModificador;
                    iSeccion.FechaModificacion = DateTime.Now;

                }

                try
                {
                    //Guardamos cambios
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var e = ex.EntityValidationErrors;

                    foreach (var x in ex.EntityValidationErrors)
                    {
                        foreach (var y in x.ValidationErrors)
                        {
                            mensaje += y.ErrorMessage;
                        }
                    }
                }

                return mensaje;
            }
        }

        public static void ValidateIfExists(List<SeccionBE> Secciones, SeccionBE Seccion)
        {
            //VALIDACION RAZON SOCIAL
            if (Secciones.Exists(o => o.Titulo.ToUpper().Trim() == Seccion.Titulo.ToUpper().Trim()))
                throw new SCOPException("Ya existe una Sección registrada con este Título:  " + Seccion.Titulo);
            //VALIDACION NUMERO DOCUMENTO   
            //if (Secciones.Exists(o => o.NumDocumento.ToUpper().Trim() == Seccion.NumDocumento.ToUpper().Trim()))
            //    throw new SCOPException("Ya Existe una empresa registrada registrado con este RUC:  " + Seccion.NumDocumento);
            //VALIDACION USUARIO SUNAT 
            //if (Emp.Exists(o => o.UsuarioSunat.ToUpper().Trim() == res.UsuarioSunat.ToUpper().Trim()))
            //    throw new SCOPException("Ya Existe un Motivo de Nota registrado con este Usuario Sunat:  " + res.UsuarioSunat);
        }

    }
}
