using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class CategoriaData
    {
        public static List<sp_ListarCategoriasResult> listarCategorias()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarCategorias().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorías capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static void insertCategoria(Categoria op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_CrearCategoria(op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar categoría capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateCategoria(Categoria op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ModificarCategoria(op.CategoriaID, op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar categoría capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteCategoria(Categoria op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarCategoria(op.CategoriaID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar categoría capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Categorias> Filtrar(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Categorias.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.NombreCategoria.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
