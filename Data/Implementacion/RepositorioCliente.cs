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
    public class RepositorioCliente : IRepositorioCliente
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conn.Open();
                    var query = "DELETE FROM Cliente WHERE idCliente = " + id;
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

        public bool Insert(Usuario c)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conn.Open();
                    var query = "insert into cliente (usuario,contrasena,email) values (@usuario,@contrasena,@email)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", c.Usuario);
                    cmd.Parameters.AddWithValue("@contrasena", c.Contrasena);
                    cmd.Parameters.AddWithValue("@email", c.Email);

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

        public List<Usuario> GetAll()
        {
            var clientes = new List<Usuario>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conn.Open();
                    var query = "SELECT * FROM Cliente";
                    var cmd = new SqlCommand(query, conn);
                    using (var dr = cmd.ExecuteReader()){
                        while (dr.Read())
                        {
                            var obj = new Usuario();

                            obj.IdCliente = Int32.Parse(dr["idCliente"].ToString());
                            obj.Usuario = dr["usuario"].ToString();
                            obj.Contrasena = dr["contrasena"].ToString();
                            obj.Email = dr["email"].ToString();

                            clientes.Add(obj);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }

        public Usuario GetById(int? id)
        {
            Usuario cliente = null;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conn.Open();
                    var query = "SELECT * FROM Cliente where idCliente = " + id;
                    var cmd = new SqlCommand(query, conn);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Usuario();

                            cliente.IdCliente = Int32.Parse(dr["idCliente"].ToString());
                            cliente.Usuario = dr["usuario"].ToString();
                            cliente.Contrasena = dr["contrasena"].ToString();
                            cliente.Email = dr["email"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return cliente;
        }

        public bool Update(Usuario c)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALaOrden"].ToString()))
                {
                    conn.Open();
                    var query = "UPDATE cliente SET usuario = @usuario, contrasena = @contrasena, email = @email WHERE idCliente = @id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", c.Usuario);
                    cmd.Parameters.AddWithValue("@contrasena", c.Contrasena);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@id", c.IdCliente);

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
