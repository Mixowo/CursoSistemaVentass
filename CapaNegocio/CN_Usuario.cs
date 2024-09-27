using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_Usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_Usuario.Listar();
        }

        
        public Tuple<int, string> registrar (Usuario user, out  string Mensaje) { 

            Mensaje = string.Empty;

            if (user.NombreCompleto == "") Mensaje = "Es necesario el nombre del usuario";

            if (user.Documento == "") Mensaje = "Es necesario el documento para el usuario";

            if (user.Clave == "") Mensaje = "Es necesario la clave para el usuario";

            if (user.Correo == "") Mensaje = "Es necesario el correo para el usuario";

            if (Mensaje != string.Empty) return Tuple.Create(-1, Mensaje);

            return objcd_Usuario.registrar(user, out Mensaje);



        }
        public bool  editar(Usuario user, out string Mensaje)
        {
            return objcd_Usuario.editar(user, out Mensaje);

        }

        public bool eliminar(Usuario user, out string Mensaje)
        {
            return objcd_Usuario.eliminar(user, out Mensaje);
        }
    }
}
