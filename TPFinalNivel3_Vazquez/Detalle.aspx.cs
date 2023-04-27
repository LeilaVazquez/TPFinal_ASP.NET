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
        public List<Articulos> Detalles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloMetodos detalle = new ArticuloMetodos();
            try
            {
                if (!IsPostBack)
                {

                    //string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    //if (id != "" && !IsPostBack)
                    //{
                    //    ArticuloMetodos articulo = new ArticuloMetodos();
                    //    Articulos seleccionado = (articulo.listar(id))[0];

                    //    txtId.Text = id;
                    //    txtCodigo.Text = seleccionado.Codigo;
                    //    txtNombre.Text = seleccionado.Nombre;
                    //    txtDescripcion.Text = seleccionado.Descripcion;
                    //    txtPrecio.Text = seleccionado.Precio.ToString();
                    //    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    //    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    //    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    //    txtImagenUrl_TextChanged(sender, e);
                    //}

                    //  utilizar el valor del ID para obtener la información correspondiente y mostrarla en la página
                    // Detalles = detalle.listarxId(valor);


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