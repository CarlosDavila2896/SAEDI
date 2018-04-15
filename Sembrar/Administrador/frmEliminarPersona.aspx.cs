using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Administrador
{
    public partial class Eliminar_Persona : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsDatosPersona objDatoPersona = new clsDatosPersona();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            objPersona.Codigo = int.Parse(ddlIndividuo.SelectedValue.ToString());
            if (objDatoPersona.eliminaAdulto(objPersona))
            {
                Response.Write(@"
     <script>
        alert('Eliminado Correctamente .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
            }
            else if (objDatoPersona.eliminaNinio(objPersona))
            {
                Response.Write(@"
     <script>
        alert('Eliminado Correctamente .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
            }
            else if (objDatoPersona.eliminaJoven(objPersona))
            {
                Response.Write(@"
     <script>
        alert('Eliminado Correctamente .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
            }
            else
            {
                Response.Write("<script>window.alert('Resultado Eliminación: INCORRECTO');</script>");
            }
        }

        
    }
}