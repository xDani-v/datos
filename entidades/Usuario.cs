using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Usuario
    {
        public Usuario(int usuarioID, string login, string password, string email, string rol)
        {
            UsuarioID = usuarioID;
            Login = login;
            Password = password;
            Email = email;
            Rol = rol;
        }

        public Usuario(int usuarioID)
        {
            UsuarioID = usuarioID;
        }

        public int UsuarioID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public DateTime fecha { get; set; }
    }
}
