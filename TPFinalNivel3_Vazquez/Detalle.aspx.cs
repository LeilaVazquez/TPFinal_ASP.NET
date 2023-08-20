using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using metodos;
using dominio;

namespace TPFinalNivel3_Vazquez
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNom.Enabled = false;
            txtCod.Enabled = false;
            txtDesc.Enabled = false;
            txtCat.Enabled = false;
            txtMarca.Enabled = false;
            txtPrecio.Enabled = false;
            try
            {

                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (!string.IsNullOrEmpty(id))
                    {
                        ArticuloMetodos articulo = new ArticuloMetodos();
                        List<Articulos> listaArticulos = articulo.listarxId(id);

                        if (listaArticulos.Count > 0)
                        {
                            Articulos seleccionado = listaArticulos[0];
                            txtNom.Text = seleccionado.Nombre;
                            txtCod.Text = seleccionado.Codigo;
                            txtDesc.Text = seleccionado.Descripcion;
                            txtPrecio.Text = seleccionado.Precio.ToString();
                            txtImg.Text = seleccionado.ImagenUrl;
                            txtMarca.Text = seleccionado.Marca.ToString();
                            txtCat.Text = seleccionado.Categoria.ToString();

                            if (!string.IsNullOrEmpty(seleccionado.ImagenUrl))
                            {
                                imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                            }
                            else
                            {
                                imgArticulo.ImageUrl = "Images/default.png";
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}