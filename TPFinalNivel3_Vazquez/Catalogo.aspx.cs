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
                    ClientScript.RegisterClientScriptBlock(this.GetType(),"alert",
                        "swal('Listo!', 'Artículo agregado con éxito!', 'success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal(';)', 'Artículo ya agregado a la lista', 'info')", true);
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal(':(', 'Debe iniciar sesion para agregarlo', 'warning')", true);
            }

        }

        protected void btnVerListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}