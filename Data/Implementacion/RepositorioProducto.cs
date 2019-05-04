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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE FROM Producto WHERE idProducto = @IdProducto", conexion);
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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT * FROM Producto", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();

                            producto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            producto.Nombre = dr["Nombre"].ToString();
                            producto.Marca = dr["Marca"].ToString();
                            producto.Descripcion = dr["Descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["Peso"].ToString());
                            producto.Categoria = dr["Categoria"].ToString();

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

        public Producto GetById(int? id)
        {
            Producto producto = null;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT * FROM Producto WHERE idProducto = @IdProducto", conexion);
                    query.Parameters.AddWithValue("@IdProducto", id);
                    using (var dr = query.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            producto = new Producto();

                            producto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            producto.Nombre = dr["Nombre"].ToString();
                            producto.Marca = dr["Marca"].ToString();
                            producto.Descripcion = dr["Descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["Peso"].ToString());
                            producto.Categoria = dr["Categoria"].ToString();
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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Producto VALUES(@Nombre, @Marca, @Descripcion, @Peso, @Categoria)", conexion);

                    query.Parameters.AddWithValue("@Nombre", t.Nombre);
                    query.Parameters.AddWithValue("@Marca", t.Marca);
                    query.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@Peso", t.Peso);
                    query.Parameters.AddWithValue("@Categoria", t.Categoria);

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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Producto SET nombre = @Nombre, marca = @Marca, descripcion = @Descripcion, peso = @Peso, categoria = @Categoria WHERE idProducto = @IdProducto", conexion);

                    query.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                    query.Parameters.AddWithValue("@Nombre", t.Nombre);
                    query.Parameters.AddWithValue("@Marca", t.Marca);
                    query.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@Peso", t.Peso);
                    query.Parameters.AddWithValue("@Categoria", t.Categoria);

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

        public List<Producto> GetByFranquicia(int idFranquicia)
        {
            var productos = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.* from Producto p JOIN Producto_Franquicia pf on p.idProducto = pf.idProducto JOIN Franquicia f on f.idFranquicia = pf.idFranquicia WHERE f.idFranquicia = " + idFranquicia, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();

                            producto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            producto.Nombre = dr["Nombre"].ToString();
                            producto.Marca = dr["Marca"].ToString();
                            producto.Descripcion = dr["Descripcion"].ToString();
                            producto.Peso = Convert.ToDouble(dr["Peso"].ToString());
                            producto.Categoria = dr["Categoria"].ToString();

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
