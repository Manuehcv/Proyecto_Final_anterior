using Proyecto_final;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Manuel_Carvajal
{
    internal class ManejadorUsuario
    {
        public static Usuario GetUsuarioByID(long idToSearch)
        {
            Usuario user = new Usuario();
            const string connectionString = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var query = "SELECT * FROM Usuario WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                var parametro = new SqlParameter();
                parametro.ParameterName = "Id";
                parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                parametro.Value = idToSearch;
                comando.Parameters.Add(parametro);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Id = Convert.ToInt64(reader.GetInt64(0));
                    user.Nombre = reader.GetString(1);
                    user.Apellido = reader.GetString(2);
                    user.NombreUsuario = reader.GetString(3);
                    user.Contraseña = reader.GetString(4);
                    user.Mail = reader.GetString(5);
                }
                conn.Close();
            }
            return user;
        }

    }
}
