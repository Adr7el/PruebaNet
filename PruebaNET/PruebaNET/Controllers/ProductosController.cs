using Microsoft.AspNetCore.Mvc;
using PruebaNET.Models;

namespace PruebaNET.Controllers
{
    [ApiController]
    [Route("ApiProductos")]
    public class ProductosController : ControllerBase
    {
        List<Producto> lProductos = new List<Producto>();

        [HttpGet]
        [Route("ObtenerDatos")]
        public dynamic ValidarC()
        {
            lProductos = llenarDatos();
            return lProductos;
        }

        [HttpGet]
        [Route("ProductosxRol")]
        public dynamic ValidarC(string rol)
        {
            lProductos = llenarDatos();
            Producto[] prodArray = null;

            //definiendo los resultados por defecto
            bool validate = false; // respuesta de la request
            string mensaje = "El Rol no existe"; //mensaje
            bool exists = false; // para validar si el rol existe
            var rolV = "";
            List<Producto> lP = new List<Producto>();

            prodArray = lProductos.ToArray(); // convirtiendo la lista en arreglo para manejarlo mejor
            var rec = prodArray.Count(); //obteniendo el total del arreglo

            //recorriendo y comprobando que exista el usuario
            for (int i = 0; i < rec; i++)
            {
                if (prodArray[i].Rol == rol)
                {
                    exists = true;
                    rolV = prodArray[i].Rol;
                    lP.Add(new Producto
                    {
                        Rol = prodArray[i].Rol,
                        Product = prodArray[i].Product
                });
                }
            }

            //validando el response
            if (exists == true)
            {
                mensaje = $"Bienvenido/a {rolV} Aqui estan sus productos";
                validate = true;
            }

            return new
            {
                success = validate,
                message = mensaje,
                result = lP
            };
        }
        public List<Producto> llenarDatos()
        {
            List<Producto> listaProductos = new List<Producto>
            {
                new Producto
                {
                    Rol = "Principal",
                    Product = "Prod_A"
                },
                new Producto
                {
                    Rol = "Principal",
                    Product = "Prod_B"
                },
                new Producto
                {
                    Rol = "Principal",
                    Product = "Prod_C"
                },
                new Producto
                {
                    Rol = "Delegado",
                    Product = "Prod_A"
                },
                new Producto
                {
                    Rol = "Delegado",
                    Product = "Prod_C"
                },
            };
            return listaProductos;
        }
    }
}
