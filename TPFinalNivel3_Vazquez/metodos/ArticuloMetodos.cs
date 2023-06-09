﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using metodos;
using System.Web;

namespace metodos
{
    public class ArticuloMetodos
    {
        public List<Articulos> listar(string id = "")
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                // comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.ImagenUrl, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A,CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria ";
                string consulta = "Select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.ImagenUrl, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A,CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria ";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                if (id != "")
                {
                    consulta += " and A.id = " + id;
                }
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descrip = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descrip = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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
        public List<Articulos> listarxId(string id)
        {
            List<Articulos> art = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.ImagenUrl, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca WHERE A.Id = @id";
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux2 = new Articulos();

                    aux2.Id = (int)datos.Lector["Id"];
                    aux2.Codigo = (string)datos.Lector["Codigo"];
                    aux2.Nombre = (string)datos.Lector["Nombre"];
                    aux2.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux2.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux2.Marca = new Marca();
                    aux2.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux2.Marca.Descrip = (string)datos.Lector["Marca"];
                    aux2.Categoria = new Categoria();
                    aux2.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux2.Categoria.Descrip = (string)datos.Lector["Categoria"];
                    aux2.Precio = (decimal)datos.Lector["Precio"];
                    art.Add(aux2);
                }
                return art;
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
        public void agregarArticulo(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria, ImagenUrl) values ('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "','" + nuevo.Precio + "',@idMarca, @idCategoria, @ImagenUrl)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", (object)nuevo.ImagenUrl ?? DBNull.Value);
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
        public void modificarArticulo(Articulos art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descrip, IdMarca = @idMarca, IdCategoria = @idCat, ImagenUrl = @ImagenUrl, Precio = @precio Where Id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descrip", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCat", art.Categoria.Id);
                datos.setearParametro("@ImagenUrl", (object)art.ImagenUrl ?? DBNull.Value);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);
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
        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
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
        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.ImagenUrl, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Código")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descrip = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descrip = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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
        public List<Articulos> listarFavoritos(int idUser)
        {
            List<Articulos> art = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT  A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN FAVORITOS F ON F.IdArticulo = A.Id WHERE F.IdUser = @idUsuario";
                datos.setearConsulta(consulta);
                datos.setearParametro("@idUsuario", idUser);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux2 = new Articulos();
                    aux2.Id = (int)datos.Lector["Id"];
                    aux2.Codigo = (string)datos.Lector["Codigo"];
                    aux2.Nombre = (string)datos.Lector["Nombre"];
                    aux2.Descripcion = (string)datos.Lector["Descripcion"];
                    aux2.Marca = new Marca();
                    aux2.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux2.Marca.Descrip = (string)datos.Lector["Marca"];
                    aux2.Categoria = new Categoria();
                    aux2.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux2.Categoria.Descrip = (string)datos.Lector["Categoria"];
                    aux2.Precio = (decimal)datos.Lector["Precio"];
                    art.Add(aux2);
                }
                return art;
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
