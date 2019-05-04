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
    public class RepositorioProductoFranquicia : IRepositorioProductoFranquicia
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();

                    var query = new SqlCommand("delete from Producto_Franquicia where idProducto = " + id, conexion);

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
        public bool Delete(int idProducto, int idFranquicia)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();

                    var query = new SqlCommand("delete from Producto_Franquicia where idProducto = " + idProducto + " and idFranquicia = " + idFranquicia, conexion);

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

        public ProductoFranquicia FindById(ProductoFranquicia pf)
        {
            ProductoFranquicia productoFranquicia = null;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = @"SELECT 
                                    p_f.*, 
                                    p.nombre as nomProducto,
                                    f.nombre as nomFranquicia
                                FROM Producto_Franquicia p_f
                                JOIN Producto p ON p_f.idProducto = p.idProducto
                                JOIN Franquicia f ON p_f.idFranquicia = f.idFranquicia
                                WHERE p_f.idFranquicia = @idF AND p_f.idProducto = @idProducto = @idP" ;
                    var cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idF", pf.Franquicia.IdFranquicia);
                    cmd.Parameters.AddWithValue("@idP", pf.Producto.IdProducto);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            productoFranquicia = new ProductoFranquicia();
                            var producto = new Producto();
                            var franquicia = new Franquicia();

                            producto.IdProducto = Int32.Parse(dr["idProducto"].ToString());
                            producto.Nombre = dr["nomProducto"].ToString();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                            franquicia.Nombre = dr["nomFranquicia"].ToString();

                            productoFranquicia.Franquicia = franquicia;
                            productoFranquicia.Producto = producto;

                            productoFranquicia.CodRef = dr["codReferencia"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return productoFranquicia;
        }

        public List<ProductoFranquicia> GetAll()
        {
            var productosFranquicias = new List<ProductoFranquicia>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = @"SELECT 
                                    p_f.*, 
                                    p.nombre as nomProducto,
                                    f.nombre as nomFranquicia
                                FROM Producto_Franquicia p_f
                                JOIN Producto p ON p_f.idProducto = p.idProducto
                                JOIN Franquicia f ON p_f.idFranquicia = f.idFranquicia";
                    var cmd = new SqlCommand(query, conexion);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var productoFranquicia = new ProductoFranquicia();
                            var producto = new Producto();
                            var franquicia = new Franquicia();

                            producto.IdProducto = Int32.Parse(dr["idProducto"].ToString());
                            producto.Nombre = dr["nomProducto"].ToString();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                            franquicia.Nombre = dr["nomFranquicia"].ToString();

                            productoFranquicia.Franquicia = franquicia;
                            productoFranquicia.Producto = producto;

                            productoFranquicia.CodRef = dr["codReferencia"].ToString();
                            productosFranquicias.Add(productoFranquicia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return productosFranquicias;
        }

        public ProductoFranquicia FindById(int? id)
        {
            ProductoFranquicia productoFranquicia = null;

            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
            return productoFranquicia;
        }

        public bool Insert(ProductoFranquicia pf)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Producto_Franquicia values(@idProducto,@idFranquicia,@CodRef)", conexion);
                    query.Parameters.AddWithValue("@idProducto", pf.Producto.IdProducto);
                    query.Parameters.AddWithValue("@CodRef", pf.CodRef);
                    query.Parameters.AddWithValue("@idFranquicia", pf.Franquicia.IdFranquicia);

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

        public bool Update(ProductoFranquicia pf)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Producto_Franquicia set codReferencia = @codReferencia where idProducto = @idProducto , idFranquicia = @idFranquicia", conexion);
                    query.Parameters.AddWithValue("@codReferencia", pf.CodRef);
                    query.Parameters.AddWithValue("@idFranquicia", pf.Franquicia.IdFranquicia);
                    query.Parameters.AddWithValue("@idProducto", pf.Producto.IdProducto);

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
        public List<ProductoFranquicia> GetByFranquicia(int idFranquicia)
        {
            var productosFranquicias = new List<ProductoFranquicia>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca, f.idFranquicia, f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia,pf.codReferencia from Producto p, Marca m, Categoria c, Franquicia f,Producto_Franquicia pf where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and pf.idProducto = p.idProducto and pf.idFranquicia = f.idFranquicia and pf.idFranquicia = @idFranquicia", conexion);
                    query.Parameters.AddWithValue("@idFranquicia", idFranquicia);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var productoFranquicia = new ProductoFranquicia();
                            var producto = new Producto();
                            var marca = new Marca();
                            var categoria = new Categoria();

                            var franquicia = new Franquicia();


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

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            IRepositorioSede repositorioSede = new RepositorioSede();
                            franquicia.Sedes = repositorioSede.GetByFranquicia(franquicia.IdFranquicia);

                            IRepositorioProductoFranquicia repositorioProductoFranquicia = new RepositorioProductoFranquicia();
                            franquicia.ProductoFranquicias = repositorioProductoFranquicia.GetByFranquicia(franquicia.IdFranquicia);

                            productoFranquicia.CodRef = dr["codReferencia"].ToString();
                            productoFranquicia.Producto = producto;
                            productoFranquicia.Franquicia = franquicia;

                            productosFranquicias.Add(productoFranquicia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return productosFranquicias;
        }
    }
}

