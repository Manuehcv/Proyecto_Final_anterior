using Proyecto_final;

namespace Manuel_Carvajal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testGetUsuario(2);
            //testGetProductsByUserID(1);


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
    }

}
