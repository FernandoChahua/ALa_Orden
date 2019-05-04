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
    public class RepositorioPedido : IRepositorioPedido
    {
        public bool Insert(Pedido t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("Insert into Pedido Values(@idCliente,@idSede,@estado,@fecha,@direccion,@nroTransaccion,@subtotal,@precioEnvio,@descuento)", conexion);
                    query.Parameters.AddWithValue("@idCliente", t.Usuario.IdUsuario);
                    query.Parameters.AddWithValue("@idSede", t.Sede.IdSede);
                    query.Parameters.AddWithValue("@estado", t.estado);
                    query.Parameters.AddWithValue("@fecha", t.fecha);
                    query.Parameters.AddWithValue("@direccion", t.direccion);
                    query.Parameters.AddWithValue("@nroTransaccion", t.nroTransaccion);
                    query.Parameters.AddWithValue("@subtotal", t.subtotal);
                    query.Parameters.AddWithValue("@precioEnvio", t.precioEnvio);
                    query.Parameters.AddWithValue("@descuento", t.descuento);

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

        public bool Update(Pedido t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("Update Pedido SET idCliente = @idCliente , idSede = @idSede , estado = @estado , fecha = @fecha , direccion = @direccion , nroTransaccion = @nroTransaccion , subtotal = @subtotal , precioEnvio = @precioEnvio , descuento = @descuento where idPedido = @idPedido", conexion);
                    query.Parameters.AddWithValue("@idCliente", t.Usuario.IdUsuario);
                    query.Parameters.AddWithValue("@idSede", t.Sede.IdSede);
                    query.Parameters.AddWithValue("@estado", t.estado);
                    query.Parameters.AddWithValue("@fecha", t.fecha);
                    query.Parameters.AddWithValue("@direccion", t.direccion);
                    query.Parameters.AddWithValue("@nroTransaccion", t.nroTransaccion);
                    query.Parameters.AddWithValue("@subtotal", t.subtotal);
                    query.Parameters.AddWithValue("@precioEnvio", t.precioEnvio);
                    query.Parameters.AddWithValue("@descuento", t.descuento);

                    query.Parameters.AddWithValue("@idPedido", t.IdPedido);

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

                        var query = new SqlCommand("Delete from Pedido where idPedido = @idPedido", conexion);

                        //jerarquia de 
                        IRepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido();
                        repositorioDetallePedido.Delete(id);

                        query.Parameters.AddWithValue("@idPedido", id);
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

        public List<Pedido> GetAll()
        {
            var pedidos = new List<Pedido>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idPedido,p.estado , p.fecha , p.direccion as PedidoDireccion,p.nroTransaccion,p.subtotal,p.precioEnvio,p.descuento,c.idCliente,c.usuario,c.email,c.contrasena,s.idSede,s.direccion as SedeDireccion, f.idFranquicia , f.nombre from Pedido p, Usuario c,Sede s , Franquicia f where p.idCliente = c.idCliente and p.idSede = s.idSede and s.idFranquicia = f.idFranquicia", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pedido = new Pedido();
                            var franquicia = new Franquicia();
                            var sede = new Sede();
                            var usuario = new Usuario();

                            pedido.IdPedido = Convert.ToInt32(dr["idPedido"]);

                            IRepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido();
                            var detallePedidos = repositorioDetallePedido.GetByIdPedido(pedido.IdPedido);

                            pedido.estado = dr["estado"].ToString();
                            pedido.fecha = dr["fecha"].ToString();
                            pedido.direccion = dr["PedidoDireccion"].ToString();
                            pedido.nroTransaccion = Convert.ToInt32(dr["nroTransaccion"]);
                            pedido.subtotal = Convert.ToDecimal(dr["subtotal"]);
                            pedido.precioEnvio = Convert.ToDecimal(dr["precioEnvio"]);
                            pedido.descuento = Convert.ToDecimal(dr["descuento"]);
                            
                            usuario.IdCliente = Convert.ToInt32(dr["idCliente"]);
                            usuario.Usuario = dr["usuario"].ToString();
                            usuario.Contrasena = dr["contrasena"].ToString();
                            usuario.Email = dr["email"].ToString();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["nombre"].ToString();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["SedeDireccion"].ToString();
                            sede.Franquicia = franquicia;

                            pedido.Usuario = cliente;
                            pedido.Sede = sede;
                            pedido.DetallePedidos = detallePedidos;

                            pedidos.Add(pedido);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pedidos;
        }

        public Pedido GetById(int? id)
        {
            Pedido pedido = null;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idPedido,p.estado , p.fecha , p.direccion as PedidoDireccion,p.nroTransaccion,p.subtotal,p.precioEnvio,p.descuento,c.idCliente,c.usuario,c.email,c.contrasena,s.idSede,s.direccion as SedeDireccion, f.idFranquicia , f.nombre from Pedido p, Usuario c,Sede s , Franquicia f where p.idCliente = c.idCliente and p.idSede = s.idSede and s.idFranquicia = f.idFranquicia and p.idPedido = " + id, conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pedido = new Pedido();
                            var franquicia = new Franquicia();
                            var sede = new Sede();
                            var usuario = new Usuario();

                            IRepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido();
                            var detallePedidos = repositorioDetallePedido.GetByIdPedido(id.Value);

                            pedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                            pedido.Estado = dr["estado"].ToString();
                            pedido.Fecha = dr["fecha"].ToString();
                            pedido.Direccion = dr["PedidoDireccion"].ToString();
                            pedido.NroTransaccion = Convert.ToInt32(dr["nroTransaccion"]);
                            pedido.SubTotal = Convert.ToDecimal(dr["subtotal"]);
                            pedido.PrecioEnvio = Convert.ToDecimal(dr["precioEnvio"]);
                            pedido.Descuento = Convert.ToDecimal(dr["descuento"]);

                            usuario.IdCliente = Convert.ToInt32(dr["idCliente"]);
                            usuario.Usuario = dr["usuario"].ToString();
                            usuario.Contrasena = dr["contrasena"].ToString();
                            usuario.Email = dr["email"].ToString();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["nombre"].ToString();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["SedeDireccion"].ToString();
                            sede.Franquicia = franquicia;

                            pedido.Usuario = cliente;
                            pedido.Sede = sede;
                            pedido.DetallePedidos = detallePedidos;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pedido;
        }

        public List<Pedido> GetByCliente(int idCliente)
        {
            var pedidos = new List<Pedido>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["alaorden"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("select p.idPedido,p.estado , p.fecha , p.direccion as PedidoDireccion,p.nroTransaccion,p.subtotal,p.precioEnvio,p.descuento,c.idCliente,c.usuario,c.email,c.contrasena,s.idSede,s.direccion as SedeDireccion, f.idFranquicia , f.nombre from Pedido p, Usuario c,Sede s , Franquicia f where p.idCliente = c.idCliente and p.idSede = s.idSede and s.idFranquicia = f.idFranquicia and p.idCliente = " + idCliente, conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pedido = new Pedido();
                            var franquicia = new Franquicia();
                            var sede = new Sede();
                            var cliente = new Usuario();

                            pedido.IdPedido = Convert.ToInt32(dr["idPedido"]);

                            IRepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido();
                            var detallePedidos = repositorioDetallePedido.GetByIdPedido(pedido.IdPedido);

                            pedido.Estado = dr["estado"].ToString();
                            pedido.Fecha = dr["fecha"].ToString();
                            pedido.Direccion = dr["PedidoDireccion"].ToString();
                            pedido.NroTransaccion = Convert.ToInt32(dr["nroTransaccion"]);
                            pedido.SubTotal = Convert.ToDecimal(dr["subtotal"]);
                            pedido.PrecioEnvio = Convert.ToDecimal(dr["precioEnvio"]);
                            pedido.Descuento = Convert.ToDecimal(dr["descuento"]);

                            cliente.IdCliente = Convert.ToInt32(dr["idCliente"]);
                            cliente.Usuario = dr["usuario"].ToString();
                            cliente.Contrasena = dr["contrasena"].ToString();
                            cliente.Email = dr["email"].ToString();

                            franquicia.IdFranquicia = Convert.ToInt32(dr["idFranquicia"]);
                            franquicia.Nombre = dr["nombre"].ToString();

                            sede.IdSede = Convert.ToInt32(dr["idSede"]);
                            sede.Direccion = dr["SedeDireccion"].ToString();
                            sede.Franquicia = franquicia;

                            pedido.Usuario = cliente;
                            pedido.Sede = sede;
                            pedido.DetallePedidos = detallePedidos;

                            pedidos.Add(pedido);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return pedidos;
        }

    }
}
