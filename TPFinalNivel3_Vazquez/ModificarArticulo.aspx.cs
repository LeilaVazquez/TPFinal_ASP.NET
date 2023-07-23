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
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.esAdmin(Session["sesionActiva"])))
            {
                Session.Add("error", "Se requieren permisos de administrador para ingresar");
                Response.Redirect("Error.aspx", false);
            }

            txtId.Enabled = false;
            ConfirmaEliminacion = false;
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

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloMetodos articulo = new ArticuloMetodos();
                    Articulos seleccionado = (articulo.listarxId(id))[0];
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    if (txtImagenUrl.Text == "")
                    {
                        seleccionado.ImagenUrl = null;
                    }
                    else
                    {
                        seleccionado.ImagenUrl = txtImagenUrl.Text;
                    }
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            if (ckConfirmaEliminacion.Checked)
            {
                ArticuloMetodos articulo = new ArticuloMetodos();
                articulo.eliminarArticulo(int.Parse(txtId.Text));
                Response.Redirect("Listado.aspx");
            }
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos seleccionado = new Articulos();
                ArticuloMetodos articulo = new ArticuloMetodos();

                seleccionado.Codigo = txtCodigo.Text;
                seleccionado.Nombre = txtNombre.Text;
                seleccionado.Precio = decimal.Parse(txtPrecio.Text);
                seleccionado.Descripcion = txtDescripcion.Text;
                seleccionado.ImagenUrl = txtImagenUrl.Text;
                if (txtImagenUrl.Text == "")
                {
                    seleccionado.ImagenUrl = null;
                }
                else
                {
                    seleccionado.ImagenUrl = txtImagenUrl.Text;
                }
                seleccionado.Marca = new Marca();
                seleccionado.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                seleccionado.Categoria = new Categoria();
                seleccionado.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                seleccionado.Id = int.Parse(txtId.Text);
                articulo.modificarArticulo(seleccionado);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            Response.Redirect("Listado.aspx", false);
        }
    }
}