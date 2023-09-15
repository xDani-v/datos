using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocios
    {
        public List<Categoria> viewCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria op = null;
            try
            {
                List<sp_ListarCategoriasResult> auxlista = CategoriaData.listarCategorias();
                foreach (sp_ListarCategoriasResult obj in auxlista)
                {
                    op = new Categoria(obj.CategoriaID, obj.NombreCategoria);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Categorias capa negocio:" + ex);
            }
        }

        public bool createCategoria(Categoria op)
        {
            try
            {
                CategoriaData.insertCategoria(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Categoria capa negocio:" + ex);
            }
        }

        public bool updateCategoria(Categoria op)
        {
            try
            {
                CategoriaData.updateCategoria(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Categoria capa negocio:" + ex);
            }
        }

        public bool deleteCategoria(Categoria op)
        {
            try
            {
                CategoriaData.deleteCategoria(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Categoria capa negocio:" + ex);
            }
        }

        public List<Categoria> Filtrar(string termino)
        {
            try
            {
                List<Categoria> lista = new List<Categoria>();
                Categoria op = null;

                List<Categorias> auxlista = CategoriaData.Filtrar(termino);
                foreach (Categorias obj in auxlista)
                {
                    op = new Categoria(obj.CategoriaID, obj.NombreCategoria);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar categoria: " + ex.Message);
            }


        }
    }
}
