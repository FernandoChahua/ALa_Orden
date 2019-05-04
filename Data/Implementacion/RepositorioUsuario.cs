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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conn.Open();
                    var query = "DELETE FROM Usuario WHERE idUsuario = " + id;
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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conn.Open();
                    var query = "insert into usuario (apodo,contrasena,email) values (@apodo,@contrasena,@email)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@apodo", c.Apodo);
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
            var usuarios = new List<Usuario>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conn.Open();
                    var query = "SELECT * from usuario";
                    var cmd = new SqlCommand(query, conn);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var obj = new Usuario();

                            obj.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                            obj.Apodo = dr["apodo"].ToString();
                            obj.Contrasena = dr["contrasena"].ToString();
                            obj.Email = dr["email"].ToString();
                            var direcciones = new List<Direccion>();
                            IRepositorioDireccion repositorioDireccion = new RepositorioDireccion();

                            direcciones = repositorioDireccion.FindByUsuario(obj.IdUsuario);




                            usuarios.Add(obj);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }

        public Usuario FindById(int? id)
        {
            Usuario usuario = null;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conn.Open();
                    var query = "SELECT * FROM Usuario where idUsuario = " + id;
                    var cmd = new SqlCommand(query, conn);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuario = new Usuario();

                            usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                            usuario.Apodo = dr["apodo"].ToString();
                            usuario.Contrasena = dr["contrasena"].ToString();
                            usuario.Email = dr["email"].ToString();
                            var direcciones = new List<Direccion>();
                            IRepositorioDireccion repositorioDireccion = new RepositorioDireccion();

                            direcciones = repositorioDireccion.FindByUsuario(usuario.IdUsuario);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public bool Update(Usuario c)
        {
            bool rpta = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conn.Open();
                    var query = "UPDATE usuario SET apodo = @apodo, contrasena = @contrasena, email = @email WHERE idUsuario = @id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@apodo", c.Apodo);
                    cmd.Parameters.AddWithValue("@contrasena", c.Contrasena);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@id", c.IdUsuario);

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
