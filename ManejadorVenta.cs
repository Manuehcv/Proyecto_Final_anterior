﻿using Proyecto_final;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuel_Carvajal
{
    internal class ManejadorVenta
    {
        const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Venta> GetVentaByUser(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @idUsuario", conn);
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    conn.Open();
                    using SqlDataReader reader = comando.ExecuteReader();
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = reader.GetInt64(0);
                                venta.Comentarios = reader.GetString(1);
                                venta.IdUsuario = reader.GetInt64(2);
                                ventas.Add(venta);
                            }
                        }
                    conn.Close();
                    }
                }
            }
            return ventas;
        }

    }
}
