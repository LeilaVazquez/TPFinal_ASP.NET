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
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloMetodos articulo = new ArticuloMetodos();
            ListaArticulos = articulo.listar();

            if (!IsPostBack)
            {
                Repeater.DataSource = ListaArticulos;
                Repeater.DataBind();
            }
        }

        protected void btnVermas_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?Id=" + valor);
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idArt = Convert.ToInt32(btn.CommandArgument);
            UsuarioMetodos fav = new UsuarioMetodos();

            if (Seguridad.sessionActiva(Session["sesionActiva"]))
            {
                Usuario user = (Usuario)Session["sesionActiva"];
                int id = user.Id;

                if (fav.AgregarFavorito(id, idArt))
                {
                    Response.Write("<script>alert('El artículo ha sido agregado a tus favoritos.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Articulo ya agregado a la lista');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe iniciar sesion para agregar a favoritos');</script>");
            }
        }

        protected void btnVerListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}