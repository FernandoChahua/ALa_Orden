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
    public class RepositorioMarca : IRepositorioMarca
    {
        public bool Insert(Marca t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Marca values(@nombre)", conexion);
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

        public bool Update(Marca t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Marca set nombre = @nombre where idMarca = "+t.IdMarca, conexion);
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
                try
                {
                    using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                    {
                        conexion.Open();

                        var query = new SqlCommand("delete from Marca where idMarca = " + id, conexion);

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

        public List<Marca> GetAll()
        {
            var marcas = new List<Marca>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select m.idMarca, m.nombre as NombreMarca from Marca m", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var marca = new Marca();
                            marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            marca.Nombre = dr["NombreMarca"].ToString();

                            IRepositorioProducto repositorioProducto = new RepositorioProducto();
                            marca.Productos = repositorioProducto.GetByMarca(marca.IdMarca);

                            marcas.Add(marca);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return marcas;
        }

        public Marca FindById(int? id)
        {
            Marca marca = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select m.idMarca, m.nombre as NombreMarca from Marca m where idMarca = " + id.Value, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            marca = new Marca();
                            marca.IdMarca = Convert.ToInt32(dr["idMarca"]);
                            marca.Nombre = dr["NombreMarca"].ToString();

                            IRepositorioProducto repositorioProducto = new RepositorioProducto();
                            marca.Productos = repositorioProducto.GetByMarca(marca.IdMarca);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return marca;
        }
    }
}
