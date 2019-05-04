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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();

                    var query = new SqlCommand("delete from Franquicia where idFranquicia = " + id, conexion);

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

        public List<Franquicia> GetAll()
        {
            var franquicias = new List<Franquicia>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select f.idFranquicia, f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var franquicia = new Franquicia();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            IRepositorioSede repositorioSede = new RepositorioSede();
                            franquicia.Sedes = repositorioSede.GetByFranquicia(franquicia.IdFranquicia);

                            franquicias.Add(franquicia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return franquicias;
        }

        public Franquicia FindById(int? id)
        {
            Franquicia franquicia = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select f.idFranquicia, f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            franquicia = new Franquicia();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            IRepositorioSede repositorioSede = new RepositorioSede();
                            franquicia.Sedes = repositorioSede.GetByFranquicia(franquicia.IdFranquicia);


                        }
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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Franquicia values(@nombre,@url,@logo)", conexion);
                    query.Parameters.AddWithValue("@nombre",f.Nombre);
                    query.Parameters.AddWithValue("@url", f.Url);
                    query.Parameters.AddWithValue("@logo", f.Logo);

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

        public bool Update(Franquicia f)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Franquicia set nombre = @nombre , url = @url, logo = @logo where idFranquicia = "+f.IdFranquicia, conexion);
                    query.Parameters.AddWithValue("@nombre", f.Nombre);
                    query.Parameters.AddWithValue("@url", f.Url);
                    query.Parameters.AddWithValue("@logo", f.Logo);

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
