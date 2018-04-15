using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNUsuario
    {
        public int idUser { get; set; }
        public string nombre { get; set; }
        public string appellido { get; set; }
        public string genero { get; set; }
        public bool estado { get; set; }        
        public string pass { get; set; }
        public string username { get; set; }
    }
}
