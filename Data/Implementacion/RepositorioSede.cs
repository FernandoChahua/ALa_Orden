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
    public class RepositorioSede : IRepositorioSede
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("DELETE FROM Sede WHERE idSede = " + id, conexion);


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

        public List<Sede> GetAll()
        {
            var sedes = new List<Sede>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT s.*, f.nombre as Franquicia from Sede s, Franquicia f WHERE s.IdFranquicia = f.IdFranquicia", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var sede = new Sede() { Franquicia = new Franquicia() };

                            sede.IdSede = Convert.ToInt32(dr["idSede"].ToString());
                            sede.Franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                            sede.Direccion = dr["direccion"].ToString();
                            sede.Franquicia.Nombre = dr["Franquicia"].ToString();

                            sedes.Add(sede);


                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            return sedes;
        }


        public Sede GetById(int? id)
        {
            Sede sede = null;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT s.*, f.nombre as Franquicia from Sede s, Franquicia f WHERE s.IdFranquicia = f.IdFranquicia AND idSede = " + id, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sede = new Sede() { Franquicia = new Franquicia() };

                            sede.IdSede = Convert.ToInt32(dr["idSede"].ToString());
                            sede.Franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"].ToString());
                            sede.Direccion = dr["direccion"].ToString();
                            sede.Franquicia.Nombre = dr["Franquicia"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            return sede;
        }

        public bool Insert(Sede s)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("INSERT INTO Sede VALUES (@idFranquicia, @direccion)", conexion);
                    query.Parameters.AddWithValue("@idFranquicia", s.Franquicia.IdFranquicia);
                    query.Parameters.AddWithValue("@direccion", s.Direccion);

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

        public bool Update(Sede s)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("UPDATE Sede SET idFranquicia = @idFranquicia, direccion=@direccion WHERE idSede = " + s.IdSede, conexion);
                    query.Parameters.AddWithValue("@idFranquicia", s.Franquicia.IdFranquicia);
                    query.Parameters.AddWithValue("@direccion", s.Direccion);

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
    }
}
