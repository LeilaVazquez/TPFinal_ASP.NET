using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;

namespace TPFinalNivel3_Vazquez
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Mensaje enviado con éxito";

            txtEmail.Text = "";
            txtAsunto.Text = "";
            txtMensaje.Text = "";
        }
    }
}