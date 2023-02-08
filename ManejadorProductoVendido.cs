﻿using Proyecto_final;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuel_Carvajal
{
    internal class ManejadorProductoVendido
    {
        const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<ProductoVendido> GetProductoVendidoByIdVenta(long idVenta)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta = @idVenta", conn);
                {
                    comando.Parameters.AddWithValue("@idVenta", idVenta);
                    conn.Open();
                    using SqlDataReader reader = comando.ExecuteReader();
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productovendido = new ProductoVendido();
                                productovendido.Id = reader.GetInt64(0);
                                productovendido.Stock = reader.GetInt32(1);
                                productovendido.IdProducto = reader.GetInt64(2);
                                productovendido.IdVenta = reader.GetInt64(3);
                                productosVendidos.Add(productovendido);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            return productosVendidos;
        }
        public static List<ProductoVendido> GetProductosVendidosByUser(long idUsuario)
        {
            List<ProductoVendido> productosvendidosby = new List<ProductoVendido>();
            List<Venta> VentasDeUsuario = ManejadorVenta.GetVentaByUser(idUsuario);
            foreach (Venta venta in VentasDeUsuario)
            {
                List<ProductoVendido> productoVendidoTemporal = ManejadorProductoVendido.GetProductoVendidoByIdVenta(venta.Id);
                foreach (ProductoVendido productovendidotemporaldos in productoVendidoTemporal)
                {
                    if (!(productosvendidosby.Contains(productovendidotemporaldos)))
                    {
                        productosvendidosby.Add(productovendidotemporaldos);
                    }
                }
            }

            return productosvendidosby;
        }
        public static List<string> GetNombresDeProductosVendidos(long idUsuario)
        {
            List<string> nombresProductos = new List<string>();
            List<ProductoVendido> nombrarProducto = ManejadorProductoVendido.GetProductosVendidosByUser(idUsuario);
            foreach (ProductoVendido item in nombrarProducto)
            {
                Producto temporal = ManejadorProducto.GetProductosByIdProducto(item.IdProducto);
                nombresProductos.Add(temporal.Descripcion);
            }
            return nombresProductos;

        }

    }
}
