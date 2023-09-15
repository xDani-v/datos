using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EditorialNegocio
    {
        public List<Editorial> viewEditorials()
        {
            List<Editorial> lista = new List<Editorial>();
            Editorial op = null;
            try
            {
                List<sp_ListarEditorialesResult> auxlista = EditorialData.listarEditorial();
                foreach (sp_ListarEditorialesResult obj in auxlista)
                {
                    op = new Editorial(obj.EditorialID, obj.NombreEditorial);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Editorials capa negocio:" + ex);
            }
        }

        public bool createEditorial(Editorial op)
        {
            try
            {
                EditorialData.insertEditorial(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Editorial capa negocio:" + ex);
            }
        }

        public bool updateEditorial(Editorial op)
        {
            try
            {
                EditorialData.updateEditorial(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Editorial capa negocio:" + ex);
            }
        }

        public bool deleteEditorial(Editorial op)
        {
            try
            {
                EditorialData.deleteEditorial(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Editorial capa negocio:" + ex);
            }
        }

        public List<Editorial> Filtrar(string termino)
        {
            try
            {
                List<Editorial> lista = new List<Editorial>();
                Editorial op = null;

                List<Editoriales> auxlista = EditorialData.Filtrar(termino);
                foreach (Editoriales obj in auxlista)
                {
                    op = new Editorial(obj.EditorialID, obj.NombreEditorial);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar libros: " + ex.Message);
            }


        }
    }
}
