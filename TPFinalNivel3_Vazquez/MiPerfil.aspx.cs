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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["sesionActiva"]))
                    {
                        Usuario usuario = (Usuario)Session["sesionActiva"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil)) //VER
                            imgNuevoPerfil.ImageUrl = "~/ProfileImages/" + usuario.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                /*Page.Validate(); //ejecuta las validaciones q tengo configuradas en la pantalla
                if (!Page.IsValid)
                    return;*/

                UsuarioMetodos login = new UsuarioMetodos();
                Usuario user = (Usuario)Session["sesionActiva"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./ProfileImages/"); ///VER
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); 
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                login.actualizar(user);
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/ProfileImages/" + user.ImagenPerfil; 

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

    }
}