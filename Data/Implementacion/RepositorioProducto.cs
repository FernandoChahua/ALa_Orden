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
    public class RepositorioProducto : IRepositorioProducto
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("delete from Producto where idProducto = @idProducto", conexion);
                    query.Parameters.AddWithValue("@IdProducto", id);

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

        public List<Producto> GetAll()
        {
            var productos = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Producto p, Marca m, Categoria c where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            var categoria = new Categoria();
                            var marca = new Marca();

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
                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return productos;
        }

        public Producto FindById(int? id)
        {
            Producto producto = null;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Producto p, Marca m, Categoria c where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and p.idProducto = " + id.Value, conexion);
                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            producto = new Producto();
                            var marca = new Marca();
                            var categoria = new Categoria();

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return producto;
        }

        public bool Insert(Producto t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("insert into Producto values(@idCategoria, @idMarca, @nombre, @presentacion, @cantidad, @magnitud, @unidad, @descripcion, @imagen)", conexion);

                    query.Parameters.AddWithValue("@idCategoria", t.Categoria.IdCategoria);
                    query.Parameters.AddWithValue("@idMarca", t.Marca.IdMarca);
                    query.Parameters.AddWithValue("@nombre", t.Nombre);
                    query.Parameters.AddWithValue("@presentacion", t.Categoria);
                    query.Parameters.AddWithValue("@cantidad", t.Cantidad);
                    query.Parameters.AddWithValue("@magnitud", t.Magnitud);
                    query.Parameters.AddWithValue("@unidad", t.Unidad);
                    query.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@imagen", t.Imagen);

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

        public bool Update(Producto t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("update Producto set idCategoria=@idCategoria,idMarca=@idMarca,nombre=@nombre,presentacion=@presentacion,cantidad=@cantidad,magnitud=@magnitud,unidad=@unidad,descripcion=@descripcion,imagen=@imagen where idProducto = " + t.IdProducto, conexion);

                    query.Parameters.AddWithValue("@idCategoria", t.Categoria.IdCategoria);
                    query.Parameters.AddWithValue("@idMarca", t.Marca.IdMarca);
                    query.Parameters.AddWithValue("@nombre", t.Nombre);
                    query.Parameters.AddWithValue("@presentacion", t.Categoria);
                    query.Parameters.AddWithValue("@cantidad", t.Cantidad);
                    query.Parameters.AddWithValue("@magnitud", t.Magnitud);
                    query.Parameters.AddWithValue("@unidad", t.Unidad);
                    query.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@imagen", t.Imagen);

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

        public List<Producto> GetByCategoria(int idCategoria)
        {
            var productos = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Producto p, Marca m, Categoria c where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and p.idCategoria = " + idCategoria, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            var marca = new Marca();
                            var categoria = new Categoria();

                            producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                            producto.Nombre = dr["NombreProducto"].ToString();
                            producto.Presentacion = dr["PresentacionProducto"].ToString();
                            producto.Descripcion = dr["DescripcionProducto"].ToString();
                            producto.Cantidad = Convert.ToInt32(dr["CantidadProducto"]);
                            producto.Unidad = dr["UnidadProducto"].ToString();
                            producto.Magnitud = Convert.ToDouble(dr["MagnitudProducto"]);

                            categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            categoria.Nombre = dr["NombreCategoria"].ToString();

                            marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            marca.Nombre = dr["NombreMarca"].ToString();

                            producto.Marca = marca;
                            producto.Categoria = categoria;

                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return productos;
        }
        public List<Producto> GetByMarca(int idMarca)
        {
            var productos = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Producto p, Marca m, Categoria c where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and p.idMarca = " + idMarca, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            var marca = new Marca();
                            var categoria = new Categoria();

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

                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return productos;
        }

    }
}
