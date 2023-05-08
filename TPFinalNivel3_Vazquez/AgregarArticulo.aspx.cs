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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    Articulos seleccionado = (articulo.listar(id))[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
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

        //agregar validacion para no ingresar campos vacios validacion del back
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
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    articulo.modificarArticulo(nuevo);
                }
                else
                {
                    articulo.agregarArticulo(nuevo);
                }

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}