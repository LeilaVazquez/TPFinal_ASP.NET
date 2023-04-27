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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioMetodos usuario = new UsuarioMetodos();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = usuario.insertarNuevo(user);//autologin
                Session.Add("sesionActiva", user);
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}