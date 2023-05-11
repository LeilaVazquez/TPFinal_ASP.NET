using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;
using dominio;

namespace TPFinalNivel3_Vazquez
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sessionActiva(Session["sesionActiva"]))
                {
                    Usuario user = (Usuario)Session["sesionActiva"];
                    int id = user.Id;
                    ArticuloMetodos articulo = new ArticuloMetodos();
                    Session.Add("listaFavoritos", articulo.listarFavoritos(id));
                    dgvMisFavoritos.DataSource = Session["listaFavoritos"];
                    dgvMisFavoritos.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }
        protected void dgvMisFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioMetodos usuario = new UsuarioMetodos();
            string id = dgvMisFavoritos.SelectedDataKey.Value.ToString();
            usuario.EliminarFavorito(id);
            Response.Redirect(Request.RawUrl);
        }
        protected void dgvMisFavoritos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMisFavoritos.PageIndex = e.NewPageIndex;
            dgvMisFavoritos.DataBind();
        }
    }
}