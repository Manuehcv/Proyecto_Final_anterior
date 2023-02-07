using Proyecto_final;
using System;

namespace Manuel_Carvajal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testGetUsuario(2);
            //testGetProductsByUserID(1);
            //testGetVentaByUserID(1);
            testUserLogIn("eperez", "SoyErnestoPerez");

        }

        static void testGetVentaByUserID(long id)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Lista de Ventas realizadas por el Usuario solicitado.");
            Console.WriteLine("---------------------------------");
            List<Venta> ventas = ManejadorVenta.GetVentaByUser(id);
            foreach (Venta venta in ventas)
            {
                Console.WriteLine("Id: " + venta.Id.ToString());
                Console.WriteLine("Comentarios: " + venta.Comentarios);
                Console.WriteLine("IdUsuario: " + venta.IdUsuario.ToString());
                Console.WriteLine("---------------------------------");
            }
        }
        static void testGetUsuario(long id)
        {
            Usuario user = ManejadorUsuario.GetUsuarioByID(id);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Datos de query");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(user.Id.ToString());
            Console.WriteLine(user.Nombre);
            Console.WriteLine(user.Apellido);
            Console.WriteLine(user.NombreUsuario);
            Console.WriteLine(user.Contraseña);
            Console.WriteLine(user.Mail);
        }
        static void testGetProductsByUserID(long id)
        {
            List<Producto> products = ManejadorProducto.GetProductosByUser(id);
            foreach (Producto product in products)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(product.Id.ToString());
                Console.WriteLine(product.Descripcion);
                Console.WriteLine(product.Costo.ToString());
                Console.WriteLine(product.PrecioVenta.ToString());
                Console.WriteLine(product.Stock.ToString());
                Console.WriteLine(product.IdUsuario.ToString());
            }
        }
        static void testUserLogIn(string user, string password)
        {
            Usuario testUser = ManejadorUsuario.Login(user, password);
            if (testUser.Id == 0)
            {

                Console.WriteLine("---------------------------------");
                Console.WriteLine("El Usuario o Contraseña ingresados no se corresponden con la base de datos.");
                Console.WriteLine("---------------------------------");
                return;
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Usuario Logeado Exitosamente");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(testUser.Id.ToString());
            Console.WriteLine(testUser.Nombre);
            Console.WriteLine(testUser.Apellido);
            Console.WriteLine(testUser.NombreUsuario);
            Console.WriteLine(testUser.Contraseña);
            Console.WriteLine(testUser.Mail);

        }

    }

}
