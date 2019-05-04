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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();

                    var query = new SqlCommand("delete from Sede where idSede = " + id, conexion);

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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select s.idSede,s.direccion as DireccionSede,f.idFranquicia,f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f,Sede s where s.idFranquicia = f.idFranquicia", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var sede = new Sede();
                            var franquicia = new Franquicia();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["DireccionSede"].ToString();
                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            sede.Franquicia = franquicia;

                            sedes.Add(sede);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return sedes;
        }

        public Sede FindById(int? id)
        {
            Sede sede = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select s.idSede,s.direccion as DireccionSede,f.idFranquicia,f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f,Sede s where s.idFranquicia = f.idFranquicia and s.idSede = "+id.Value, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sede = new Sede();
                            var franquicia = new Franquicia();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["DireccionSede"].ToString();
                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            sede.Franquicia = franquicia;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sede;
        }

        public bool Insert(Sede s)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Sede values(@idFranquicia,@direccion)", conexion);
                    query.Parameters.AddWithValue("@idFranquicia", s.Franquicia.IdFranquicia);
                    query.Parameters.AddWithValue("@url", s.Direccion);

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
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Sede set idFranquicia = @idFranquicia,direccion = @direccion where idSede = " + s.IdSede, conexion);
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
        public List<Sede> GetByFranquicia(int idFranquicia)
        {
            var sedes = new List<Sede>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ConnectionString))
                {
                    conexion.Open();
                    var query = new SqlCommand("select s.idSede,s.direccion as DireccionSede,f.idFranquicia,f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f,Sede s where s.idFranquicia = f.idFranquicia where s.idFranquicia = "+idFranquicia, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var sede = new Sede();
                            var franquicia = new Franquicia();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["DireccionSede"].ToString();
                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["NombreFranquicia"].ToString();
                            franquicia.Url = dr["UrlFranquicia"].ToString();
                            franquicia.Logo = dr["LogoFranquicia"].ToString();

                            sede.Franquicia = franquicia;

                            sedes.Add(sede);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return sedes;
        }
    }
}
