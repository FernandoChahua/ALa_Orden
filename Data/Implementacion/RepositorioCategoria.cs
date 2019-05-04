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
    public class RepositorioCategoria : IRepositorioCategoria
    {
        public bool Insert(Categoria t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Categoria values(@nombre)", conexion);
                    query.Parameters.AddWithValue("@nombre", t.IdCategoria);

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

        public bool Update(Categoria t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Categoria set nombre = @nombre where idCategoria = " + t.IdCategoria, conexion);
                    query.Parameters.AddWithValue("@nombre", t.Nombre);

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
            if (id != 0)
            {
                try
                {
                    using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                    {
                        conexion.Open();

                        var query = new SqlCommand("delete from Categoria where idCategoria = " + id, conexion);

                        query.ExecuteNonQuery();

                        rpta = true;

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return rpta;
        }

        public List<Categoria> GetAll()
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select m.idCategoria, m.nombre as NombreCategoria from Categoria m", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var categoria = new Categoria();
                            categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            categoria.Nombre = dr["NombreCategoria"].ToString();

                            IRepositorioProducto repositorioProducto = new RepositorioProducto();
                            categoria.Productos = repositorioProducto.GetByCategoria(categoria.IdCategoria);

                            categorias.Add(categoria);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return categorias;
        }

        public Categoria FindById(int? id)
        {
            Categoria categoria = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select m.idCategoria, m.nombre as NombreCategoria from Categoria m where idCategoria = " + id.Value, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            categoria = new Categoria();
                            categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                            categoria.Nombre = dr["NombreCategoria"].ToString();

                            IRepositorioProducto repositorioProducto = new RepositorioProducto();
                            categoria.Productos = repositorioProducto.GetByCategoria(categoria.IdCategoria);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return categoria;
        }
    }
}
