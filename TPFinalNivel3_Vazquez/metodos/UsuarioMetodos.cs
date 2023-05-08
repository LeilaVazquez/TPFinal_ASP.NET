using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace metodos
{
    public class UsuarioMetodos
    {
        //metodo que genere el obj usuario en la DB con solo 2 valores, por defecto ponerlos en 
        //id - email - pass  admin:false


        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, urlImagenPerfil, nombre, apellido from Users where email = @email and pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int registrarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("Insert into USERS (Nombre, Apellido, urlImagenPerfil, email, pass, admin) output inserted.id ('" + nuevo.Nombre + "','" + nuevo.Apellido + "','" + nuevo.ImagenPerfil + "',@email, @pass, @admin)");
                datos.setearConsulta("Insert into USERS (email, pass, admin) output inserted.id values ('" + nuevo.Email + "' , '" + nuevo.Pass + "', '0')");
                //datos.setearParametro("@email", nuevo.Email);
                //datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Users set urlImagenPerfil = @urlImagenPerfil, nombre = @nombre, apellido = @apellido where Id = @Id");
                
                datos.setearParametro("@urlImagenPerfil", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@Id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
