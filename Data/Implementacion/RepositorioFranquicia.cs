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
    public class RepositorioFranquicia : IRepositorioFranquicia
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Franquicia WHERE idFranquicia=" + id;
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return rpta;
        }

        public List<Franquicia> GetAll()
        {
            var franquicias = new List<Franquicia>();

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Franquicia";
                    var cmd = new SqlCommand(query, conn);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var franquicia = new Franquicia();
                        franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                        franquicia.Nombre = dr["nombre"].ToString();

                        franquicias.Add(franquicia);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return franquicias;
        }

        public Franquicia GetById(int? id)
        {
            Franquicia franquicia = null;

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Franquicia";
                    var cmd = new SqlCommand(query, conn);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        franquicia = new Franquicia();
                        franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                        franquicia.Nombre = dr["nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return franquicia;
        }

        public bool Insert(Franquicia f)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Franquicia VALUES (@nombre)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", f.Nombre);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return rpta;
        }

        public bool Update(Franquicia f)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Franquicia SET nombre = @nombre WHERE idFranquicia=" + f.IdFranquicia;
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", f.Nombre);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return rpta;
        }
    }
}
