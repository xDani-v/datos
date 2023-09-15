using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocios
    {
        public List<Cliente> viewClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente op = null;
            try
            {
                List<sp_ListarClientesResult> auxlista = ClienteData.listarClientes();
                foreach (sp_ListarClientesResult obj in auxlista)
                {
                    op = new Cliente(obj.ClienteID, obj.Nombre, obj.Apellido, obj.Direccion, obj.Telefono, obj.Email);
                    lista.Add(op);
                }
                return lista;

            }
            catch(Exception ex) 
            {
                throw new Exception("Error al mostrar clientes capa negocio:"+ex);
            }
        }

        public bool createCliente(Cliente op)
        {
            try
            {
                ClienteData.insertCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente capa negocio:" + ex);
            }
        }

        public bool updateCliente(Cliente op)
        {
            try
            {
                ClienteData.updateCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente capa negocio:" + ex);
            }
        }

        public bool deleteCliente(Cliente op)
        {
            try
            {
                ClienteData.deleteCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente capa negocio:" + ex);
            }
        }

        public List<Cliente> FiltrarClientes(string termino)
        {
            try
            {
                List<Cliente> lista = new List<Cliente>();
                Cliente op = null;

                List<Clientes> auxlista = ClienteData.Filtrar(termino);
                foreach (Clientes obj in auxlista)
                {
                    op = new Cliente(obj.ClienteID, obj.Nombre, obj.Apellido, obj.Direccion, obj.Telefono, obj.Email);
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
