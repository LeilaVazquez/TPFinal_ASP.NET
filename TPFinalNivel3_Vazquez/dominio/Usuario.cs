using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenPerfil { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Admin { get; set; }


        //public Usuario(string user, string pass, bool admin)
        //{
        //    User = user;
        //    Pass = pass;
        //    TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        //}
    }

}
