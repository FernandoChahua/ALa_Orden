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
   public class RepositorioTarjeta:IRepositorioTarjeta
    {

        public bool Insert(Tarjeta t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("INSERT INTO Tarjeta VALUES(@idUsuario,@nroCuenta, @titular, @fechaExp)", conexion);
                    query.Parameters.AddWithValue("@idUsuario", t.Usuario.IdUsuario);
                    query.Parameters.AddWithValue("@nroCuenta", t.NroCuenta);
                    query.Parameters.AddWithValue("@titular", t.Titular);
                    query.Parameters.AddWithValue("@fechaExp", t.FechaExp);


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


        public List<Tarjeta> GetAll()
        {
            var tarjetas = new List<Tarjeta>();
            try {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT * from Tarjeta", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        { var tarjeta = new Tarjeta() { Usuario = new Usuario() };
                            tarjeta.IdTarjeta = Convert.ToInt32(dr["idTarjeta"]);
                            tarjeta.Usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            tarjeta.NroCuenta = dr["nroCuenta"].ToString();
                            tarjeta.Titular = dr["titular"].ToString();
                            tarjeta.FechaExp = Convert.ToDateTime(dr["fechaExp"]).ToString("dd/MM/yyyy");

                            tarjetas.Add(tarjeta);


                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            return tarjetas;
        }


        public Tarjeta FindById(int? id)
        {
            Tarjeta tarjeta = null;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT * from tarjeta where idTarjeta = @idTarjeta", conexion);
                    query.Parameters.AddWithValue("@idTarjeta", Convert.ToInt32(id));
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tarjeta = new Tarjeta() { Usuario = new Usuario() };
                            tarjeta.IdTarjeta = Convert.ToInt32(dr["idTarjeta"]);
                            tarjeta.Usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            tarjeta.NroCuenta = dr["nroCuenta"].ToString();
                            tarjeta.Titular = dr["titular"].ToString();
                            tarjeta.FechaExp = Convert.ToDateTime(dr["fechaExp"]).ToString("dd/MM/yyyy");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tarjeta;
        }


        public bool Update(Tarjeta t)
        {
            bool rpta = false;
           
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("UPDATE Tarjeta SET nroCuenta = @nroCuenta,titular=@titular, fechaExp = @fechaExp WHERE idTarjeta = " + t.IdTarjeta, conexion);
                    query.Parameters.AddWithValue("@nroCuenta", t.NroCuenta);
                    query.Parameters.AddWithValue("@titular", t.Titular);
                    query.Parameters.AddWithValue("@fechaExp", t.FechaExp);

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
                    var query = new SqlCommand("DELETE FROM Tarjeta WHERE idTarjeta = " + id, conexion);
                    

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

        public List<Tarjeta> GetByUsuario(int idUsuario)
        {
            var tarjetas = new List<Tarjeta>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))

                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT t.* from Tarjeta t join Usuario c on t.idUsuario = c.IdUsuario WHERE t.idUsuario = " + idUsuario, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tarjeta = new Tarjeta() { Usuario = new Usuario() };
                            tarjeta.IdTarjeta = Convert.ToInt32(dr["idTarjeta"]);
                            tarjeta.Usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                            tarjeta.NroCuenta = dr["nroCuenta"].ToString();
                            tarjeta.Titular = dr["titular"].ToString();
                            tarjeta.FechaExp = Convert.ToDateTime(dr["fechaExp"]).ToString("dd/MM/yyyy");

                            tarjetas.Add(tarjeta);


                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            return tarjetas;
        }
    }
}
