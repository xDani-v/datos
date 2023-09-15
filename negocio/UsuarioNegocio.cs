using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> viewUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario op = null;
            try
            {
                List<sp_ListarUsuariosResult> auxlista = UsuarioData.listarUsuarios();
                foreach (sp_ListarUsuariosResult obj in auxlista)
                {
                    op = new Usuario(obj.UsuarioID,obj.NombreUsuario,obj.Contraseña,obj.Correo,obj.Rol);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Usuarios capa negocio:" + ex);
            }
        }

        public bool createUsuario(Usuario op)
        {
            try
            {
                UsuarioData.insertUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Usuario capa negocio:" + ex);
            }
        }

        public bool updateUsuario(Usuario op)
        {
            try
            {
                UsuarioData.updateUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Usuario capa negocio:" + ex);
            }
        }

        public bool deleteUsuario(Usuario op)
        {
            try
            {
                UsuarioData.deleteUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Usuario capa negocio:" + ex);
            }
        }

        public List<Usuario> Filtrar(string termino)
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                Usuario op = null;

                List<Usuarios> auxlista = UsuarioData.Filtrar(termino);
                foreach (Usuarios obj in auxlista)
                {
                    op = new Usuario(obj.UsuarioID, obj.NombreUsuario, obj.Contraseña, obj.Correo, obj.Rol);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar Usuario: " + ex.Message);
            }


        }
    }
}
