using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Configuration;
using System.Data.SqlClient;
namespace Data.Implementacion
{
    public class RepositorioDetallePedido : IRepositorioDetallePedido
    {
        public bool Insert(DetallePedido t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("Insert into DetallePedido values(@idPedido,@idProducto,@precio,@cantidad)", conexion);
                    query.Parameters.AddWithValue("@idPedido", t.IdPedido);
                    query.Parameters.AddWithValue("@idProducto", t.Producto.IdProducto);
                    query.Parameters.AddWithValue("@precio", t.Precio);
                    query.Parameters.AddWithValue("@cantidad", t.Cantidad);

                    query.ExecuteNonQuery();

                    rpta = true;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }

        public bool Update(DetallePedido t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("update DetallePedido set precio = @precio ,cantidad = @cantidad where idPedido = @idPedido and idProducto = @idProducto", conexion);
                    query.Parameters.AddWithValue("@precio", t.Precio);
                    query.Parameters.AddWithValue("@cantidad", t.Cantidad);
                    query.Parameters.AddWithValue("@idPedido", t.IdPedido);
                    query.Parameters.AddWithValue("@idProducto", t.Producto.IdProducto);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;

        }

        public bool Delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("Delete from DetallePedido where idPedido = " + id, conexion);

                    query.ExecuteNonQuery();

                    rpta = true;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }

        public bool Delete(DetallePedido t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("Delete from DetallePedido where idProducto = @idProducto and idPedido = @idPedido", conexion);
                    query.Parameters.AddWithValue("@idProducto", t.Producto.IdProducto);
                    query.Parameters.AddWithValue("@idPedido", t.IdPedido);

                    query.ExecuteNonQuery();

                    rpta = true;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }
        public List<DetallePedido> GetAll()
        {
            var detallePedidos = new List<DetallePedido>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("select dp.idPedido, dp.precio, dp.cantidad, p.idProducto, p.nombre as ProductoNombre, p.marca, p.descripcion, p.peso, p.categoria from DetallePedido dp , Producto p where dp.idProducto = p.idProducto", conexion);

                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            DetallePedido detallePedido = new DetallePedido();
                            Producto producto = new Producto();

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDecimal(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);
                            
                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Marca = dr["marca"].ToString();
                            producto.Descripcion = dr["descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["peso"]);
                            producto.Nombre = dr["ProductoNombre"].ToString();

                            producto.Categoria = dr["categoria"].ToString();
                            detallePedido.Producto = producto;

                            detallePedidos.Add(detallePedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return detallePedidos;
        }

        public List<DetallePedido> GetByIdPedido(int idPedido)
        {
            var detallePedidos = new List<DetallePedido>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("select dp.idPedido, dp.precio, dp.cantidad, p.idProducto, p.nombre as ProductoNombre, p.marca, p.descripcion, p.peso, p.categoria from DetallePedido dp, Producto p where dp.idProducto = p.idProducto and dp.idPedido = " + idPedido, conexion);

                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            DetallePedido detallePedido = new DetallePedido();
                            Producto producto = new Producto();

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDecimal(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);

                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Marca = dr["marca"].ToString();
                            producto.Descripcion = dr["descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["peso"]);
                            producto.Nombre = dr["ProductoNombre"].ToString();

                            producto.Categoria = dr["categoria"].ToString();
                            detallePedido.Producto = producto;

                            detallePedidos.Add(detallePedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return detallePedidos;
        }

        public DetallePedido GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public DetallePedido GetById(DetallePedido dp)
        {
            DetallePedido detallePedido = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("select dp.idPedido, dp.precio, dp.cantidad, p.idProducto, p.nombre as ProductoNombre, p.marca, p.descripcion, p.peso, p.categoria from DetallePedido dp , Producto p where dp.idProducto = p.idProducto and dp.idPedido = " + dp.IdPedido + " and dp.idProducto = " + dp.Producto.IdProducto, conexion);

                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            detallePedido = new DetallePedido();
                            Producto producto = new Producto();

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDecimal(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);
                            
                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Marca = dr["marca"].ToString();
                            producto.Descripcion = dr["descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["peso"]);
                            producto.Nombre = dr["ProductoNombre"].ToString();

                            producto.Categoria = dr["categoria"].ToString();

                            detallePedido.Producto = producto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return detallePedido;
        }

    }
}
