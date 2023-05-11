using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using metodos;

namespace TPFinalNivel3_Vazquez
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.esAdmin(Session["sesionActiva"])))
            {
                Session.Add("error", "Se requieren permisos de administrador para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaMetodos categoria = new CategoriaMetodos();
                    List<Categoria> lista = categoria.listar();
                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descrip";
                    ddlCategoria.DataBind();
                    MarcaMetodos marca = new MarcaMetodos();
                    List<Marca> lista2 = marca.listar();
                    ddlMarca.DataSource = lista2;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descrip";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos nuevo = new Articulos();
                ArticuloMetodos articulo = new ArticuloMetodos();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                if (txtImagenUrl.Text == "")
                {
                    nuevo.ImagenUrl = null;
                }
                else
                {
                    nuevo.ImagenUrl = txtImagenUrl.Text;
                }
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.agregarArticulo(nuevo);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            Response.Redirect("Listado.aspx", false);
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}