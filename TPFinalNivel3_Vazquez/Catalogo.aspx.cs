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
            ListaArticulos = articulo.listarConSP();

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
            int index = Convert.ToInt32(btn.CommandArgument);
            var item = Repeater.Items[index];

            // implementar lógica para agregar el elemento a la lista de Favoritos
            // mostrar un mensaje de confirmación
        }

        protected void btnVerListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}