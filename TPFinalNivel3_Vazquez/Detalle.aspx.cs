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
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloMetodos articulo = new ArticuloMetodos();
                    Articulos seleccionado = (articulo.listarxId(id))[0];
                    txtNom.Text = seleccionado.Nombre;
                    txtCod.Text = seleccionado.Codigo;
                    txtDesc.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    //txtImagen.Text = seleccionado.ImagenUrl;
                    //if (txtImagen.Text == "")
                    //{
                    //    seleccionado.ImagenUrl = null;
                    //}
                    //else
                    //{
                    //    seleccionado.ImagenUrl = txtImagen.Text;
                    //}
                    txtMarca.Text = seleccionado.Marca.ToString();
                    txtCat.Text = seleccionado.Categoria.ToString();
                    //txtImagen_TextChanged(sender, e);
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