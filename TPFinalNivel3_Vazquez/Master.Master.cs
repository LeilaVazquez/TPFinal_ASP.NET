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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Seguridad.sessionActiva(Session["sesionActiva"]))
            {
                Usuario user = (Usuario)Session["sesionActiva"];
                lblUser.Text = user.Nombre;

                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    imgPerfil.ImageUrl = "~/Images/Profile/" + user.ImagenPerfil;
                }
                else
                {
                    imgPerfil.ImageUrl = "~/Images/perfil.png";
                }

            }
            else
            {
                imgPerfil.ImageUrl = "~/Images/perfil.png";
            }

           
            if (!(Page is Login || Page is Registro || Page is Default || Page is Catalogo || Page is Contacto || Page is Detalle || Page is Listado))
            {
                if (!Seguridad.sessionActiva(Session["sesionActiva"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Usuario user = (Usuario)Session["sesionActiva"];
                    lblUser.Text = user.Nombre;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgPerfil.ImageUrl = "~/Images/Profile/" + user.ImagenPerfil;
                    }
                    else
                    {
                        imgPerfil.ImageUrl = "~/Images/perfil.png";
                    }
                }

            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}