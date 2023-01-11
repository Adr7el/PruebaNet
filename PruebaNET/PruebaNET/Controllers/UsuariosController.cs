using Microsoft.AspNetCore.Mvc;
using PruebaNET.Models;

namespace PruebaNET.Controllers
{
    [ApiController]
    [Route("APIUsuarios")]
    public class UsuariosController : ControllerBase
    {
        List<Usuario> lUsuarios = new List<Usuario>();

        [HttpGet]
        [Route("ObtenerDatos")]
        public dynamic ValidarC()
        {
            lUsuarios = llenarDatos();
            return lUsuarios;
        }

        [HttpGet]
        [Route("ValidarCredenciales")]
        public dynamic ValidarC(string user, string pass)
        {
            lUsuarios = llenarDatos();
            Usuario[] usuaArray = null;

            //definiendo los resultados por defecto
            bool validate = false; // respuesta de la request
            string mensaje = "Las credenciales son incorrectas"; //mensaje
            bool exists = false; // para validar si el usuario y la contraseña son validos
            var userV = "";

            usuaArray = lUsuarios.ToArray(); // convirtiendo la lista en arreglo para manejarlo mejor
            var rec = usuaArray.Count(); //obteniendo el total del arreglo

            //recorriendo y comprobando que exista el usuario
            for (int i = 0; i < rec; i++)
            {
                if(usuaArray[i].User == user && usuaArray[i].Password == pass)
                {
                    exists = true;
                    userV = usuaArray[i].User;
                }
            }

            //validando el response
            if (exists == true)
            {
                mensaje = $"Bienvenido/a {userV}";
                validate = true;
            }

            return new
            {
                success = validate,
                message = mensaje
            };
        }

        [HttpGet]
        [Route("ObtenerRolesUsuario")]
        public dynamic ObtenerRolesU(string user)
        {
            lUsuarios = llenarDatos();
            Usuario[] usuaArray = null;

            //definiendo los resultados por defecto
            bool validate = false; // respuesta de la request
            string mensaje = "El Usuario es incorrecto"; //mensaje
            bool exists = false; // para validar si el rol
            var userV = "";
            var rolV = "";

            usuaArray = lUsuarios.ToArray(); // convirtiendo la lista en arreglo para manejarlo mejor
            var rec = usuaArray.Count(); //obteniendo el total del arreglo

            //recorriendo y comprobando que exista el usuario
            for (int i = 0; i < rec; i++)
            {
                if (usuaArray[i].User == user)
                {
                    exists = true;
                    userV = usuaArray[i].User;
                    rolV = usuaArray[i].Rol;
                }
            }

            //validando el response
            if (exists == true)
            {
                mensaje = $"Bienvenido/a {userV}, con el rol {rolV}";
                validate = true;
            }

            return new
            {
                success = validate,
                message = mensaje
            };
        }

        public List<Usuario> llenarDatos()
        {
            List<Usuario> listaUsuarios = new List<Usuario>
            {
                new Usuario
                {
                    User = "User1",
                    Password = "Clave1",
                    Rol = "Principal"
                },
                new Usuario
                {
                    User = "User2",
                    Password = "Clave2",
                    Rol = "Delegado"
                }
            };
            return listaUsuarios;
        }
    }
}
