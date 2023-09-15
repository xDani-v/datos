using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class LenguajeNegocio
    {
        public List<Lenguaje> viewLenguajes()
        {
            List<Lenguaje> lista = new List<Lenguaje>();
            Lenguaje op = null;
            try
            {
                List<sp_ListarLenguajesResult> auxlista = LenguajeData.listarLenguajes();
                foreach (sp_ListarLenguajesResult obj in auxlista)
                {
                    op = new Lenguaje(obj.LenguajeID, obj.NombreLenguaje);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Lenguajes capa negocio:" + ex);
            }
        }

        public bool createLenguaje(Lenguaje op)
        {
            try
            {
                LenguajeData.insertLenguaje(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Lenguaje capa negocio:" + ex);
            }
        }

        public bool updateLenguaje(Lenguaje op)
        {
            try
            {
                LenguajeData.updateLenguaje(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Lenguaje capa negocio:" + ex);
            }
        }

        public bool deleteLenguaje(Lenguaje op)
        {
            try
            {
                LenguajeData.deleteLenguaje(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Lenguaje capa negocio:" + ex);
            }
        }

        public List<Lenguaje> Filtrar(string termino)
        {
            try
            {
                List<Lenguaje> lista = new List<Lenguaje>();
                Lenguaje op = null;

                List<Lenguajes> auxlista = LenguajeData.Filtrar(termino);
                foreach (Lenguajes obj in auxlista)
                {
                    op = new Lenguaje(obj.LenguajeID, obj.NombreLenguaje);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar lenguaje: " + ex.Message);
            }


        }
    }
}
