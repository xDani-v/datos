using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Cliente
    {
        public Cliente(int clienteID, string nombre, string apellido,string direccion, string telefono, string email)
        {
            ClienteID = clienteID;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
           
        }

        public Cliente(int clienteID)
        {
            ClienteID = clienteID;
        }

        public Cliente()
        {
        }

        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public string DisplayText
        {
            get { return $"{Nombre} - {Apellido}"; }
        }
    }
}
