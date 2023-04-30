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
            try
            {

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (!IsPostBack)
                {

                    ArticuloMetodos articulo = new ArticuloMetodos();
                    Session.Add("listaArticulos", articulo.listarxId(id));
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();

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