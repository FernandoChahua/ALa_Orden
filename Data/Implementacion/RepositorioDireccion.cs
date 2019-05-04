using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Configuration;
namespace Data.Implementacion
{
    public class RepositorioDireccion :IRepositorioDireccion
    {
        public bool Insert(Direccion t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("insert into Direccion values(@idUsuario,@descripcion,@latitud,@longitud)", conexion);
                    query.Parameters.AddWithValue("@idUsuario", t.IdUsuario);
                    query.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@latitud", t.Latitud);
                    query.Parameters.AddWithValue("@longitud", t.Longitud);

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

        public bool Update(Direccion t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("update Direccion set descripcion = @descripcion , latitud = @latitud , longitud = @longitud where idDireccion = " + t.IdDireccion, conexion);
                    query.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@latitud", t.Latitud);
                    query.Parameters.AddWithValue("@longitud", t.Longitud);

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

                        var query = new SqlCommand("delete from Direccion where idDireccion = " + id, conexion);

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

        public List<Direccion> GetAll()
        {
            var direcciones = new List<Direccion>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select * from Direccion ", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var direccion = new Direccion();
                            direccion.IdDireccion = Convert.ToInt32(dr["idDireccion"]);
                            direccion.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            direccion.Descripcion = dr["descripcion"].ToString();
                            direccion.Latitud = dr["latitud"].ToString();
                            direccion.Longitud = dr["longitud"].ToString();


                            direcciones.Add(direccion);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return direcciones;
        }

        public Direccion FindById(int? id)
        {
            Direccion direccion = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select * from Direccion where idUsuario = " + id.Value, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            direccion = new Direccion();
                            direccion.IdDireccion = Convert.ToInt32(dr["idDireccion"]);
                            direccion.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            direccion.Descripcion = dr["descripcion"].ToString();
                            direccion.Latitud = dr["latitud"].ToString();
                            direccion.Longitud = dr["longitud"].ToString();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return direccion;
        }
        public List<Direccion> FindByUsuario(int idUsuario)
        {
            var direcciones = new List<Direccion>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select * from Direccion where idUsuario = "+idUsuario, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var direccion = new Direccion();
                            direccion.IdDireccion = Convert.ToInt32(dr["idDireccion"]);
                            direccion.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            direccion.Descripcion = dr["descripcion"].ToString();
                            direccion.Latitud = dr["latitud"].ToString();
                            direccion.Longitud = dr["longitud"].ToString();


                            direcciones.Add(direccion);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return direcciones;
        }
        public bool DeleteByUsuario(int idUsuario)
        {
            bool rpta = false;
            if (idUsuario != 0)
            {
                try
                {
                    using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                    {
                        conexion.Open();

                        var query = new SqlCommand("delete from Direccion where idDireccion = " + idUsuario, conexion);

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
    }
}
