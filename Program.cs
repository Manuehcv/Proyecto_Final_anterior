using Proyecto_final;

namespace Manuel_Carvajal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            testGetUsuario(2);

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
    }
}
