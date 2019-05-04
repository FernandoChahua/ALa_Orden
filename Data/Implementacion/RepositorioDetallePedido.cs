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
                    var query = new SqlCommand("select dp.idPedido ,dp.precio as CantidadPrecio,dp.cantidad as CantidadDetalle,p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Marca m ,Categoria c, Producto p,DetallePedido dp where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and dp.idProducto = p.idProducto", conexion);

                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            DetallePedido detallePedido = new DetallePedido();
                            Producto producto = new Producto();
                            Marca marca = new Marca();
                            Categoria categoria = new Categoria();

                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Nombre = dr["NombreProducto"].ToString();
                            producto.Presentacion = dr["PresentacionProducto"].ToString();
                            producto.Descripcion = dr["DescripcionProducto"].ToString();
                            producto.Cantidad = Convert.ToInt32(dr["CantidadProducto"]);
                            producto.Unidad = dr["UnidadProducto"].ToString();
                            producto.Magnitud = Convert.ToDouble(dr["MagnitudProducto"]);

                            producto.Categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            producto.Categoria.Nombre = dr["NombreCategoria"].ToString();

                            producto.Marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            producto.Marca.Nombre = dr["NombreMarca"].ToString();

                            producto.Marca = marca;
                            producto.Categoria = categoria;

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDouble(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);

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
                    var query = new SqlCommand("select dp.idPedido ,dp.precio as CantidadPrecio,dp.cantidad as CantidadDetalle,p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Marca m ,Categoria c, Producto p,DetallePedido dp where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and dp.idProducto = p.idProducto and dp.idPedido = "+idPedido, conexion);

                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            DetallePedido detallePedido = new DetallePedido();
                            Producto producto = new Producto();
                            Marca marca = new Marca();
                            Categoria categoria = new Categoria();

                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Nombre = dr["NombreProducto"].ToString();
                            producto.Presentacion = dr["PresentacionProducto"].ToString();
                            producto.Descripcion = dr["DescripcionProducto"].ToString();
                            producto.Cantidad = Convert.ToInt32(dr["CantidadProducto"]);
                            producto.Unidad = dr["UnidadProducto"].ToString();
                            producto.Magnitud = Convert.ToDouble(dr["MagnitudProducto"]);

                            producto.Categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            producto.Categoria.Nombre = dr["NombreCategoria"].ToString();

                            producto.Marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            producto.Marca.Nombre = dr["NombreMarca"].ToString();

                            producto.Marca = marca;
                            producto.Categoria = categoria;

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDouble(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);

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

        public DetallePedido FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public DetallePedido FindById(DetallePedido dp)
        {
            DetallePedido detallePedido = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("select dp.idPedido ,dp.precio as CantidadPrecio,dp.cantidad as CantidadDetalle,p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Marca m ,Categoria c, Producto p,DetallePedido dp where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and dp.idProducto = p.idProducto and dp.idPedido = @idPedido and dp.idProducto = @idProducto", conexion);
                    query.Parameters.AddWithValue("@idPedido", dp.IdPedido);
                    query.Parameters.AddWithValue("@idProducot", dp.Producto.IdProducto);
                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            detallePedido = new DetallePedido();
                            Producto producto = new Producto();
                            Marca marca = new Marca();
                            Categoria categoria = new Categoria();

                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Nombre = dr["NombreProducto"].ToString();
                            producto.Presentacion = dr["PresentacionProducto"].ToString();
                            producto.Descripcion = dr["DescripcionProducto"].ToString();
                            producto.Cantidad = Convert.ToInt32(dr["CantidadProducto"]);
                            producto.Unidad = dr["UnidadProducto"].ToString();
                            producto.Magnitud = Convert.ToDouble(dr["MagnitudProducto"]);

                            producto.Categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            producto.Categoria.Nombre = dr["NombreCategoria"].ToString();

                            producto.Marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            producto.Marca.Nombre = dr["NombreMarca"].ToString();

                            producto.Marca = marca;
                            producto.Categoria = categoria;

                            detallePedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            detallePedido.Precio = Convert.ToDouble(dr["precio"]);
                            detallePedido.Cantidad = Convert.ToInt32(dr["cantidad"]);

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
