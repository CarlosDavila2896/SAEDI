using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Orientador
{
    public partial class Ingresar_Adulto : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsAdulto objAdulto = new clsAdulto();
        clsDatosAdulto objDatosAdulto = new clsDatosAdulto();
        clsDAlimentacion2 objAlimentacion2 = new clsDAlimentacion2();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;
            
            if(!IsPostBack)
            {
                

                cargarDDLs();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            if (rfvPrimerNombre.IsValid && rfvPrimerApellido.IsValid && rfvLugarNacimiento.IsValid && ctvFecha.IsValid && revTelefono.IsValid)
            {

                cargarPersona(nacimiento);
                cargarAdulto();


                if (validaciones(nacimiento))
                {
                    if (objDatosAdulto.ingresaAdulto(objPersona, objAdulto))
                    {
                        Response.Write(@"
     <script>
        alert('Ingreso  Correcto .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Resultado Ingreso: INCORRECTO');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('El adulto debe tener al menos 18 años, por favor, comprobar');</script>");
                }


            }
            else
            {
                Response.Write("<script>window.alert('Algun dato es erroneo, por favor, comprobar');</script>");
            }
        }

        protected void ctvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime nacimiento;
            DateTime maxDate = DateTime.Now;

            args.IsValid = (DateTime.TryParse(args.Value, out nacimiento) && nacimiento <= maxDate);
        }
        private void cargarPersona(DateTime nacimiento)
        {
            objPersona.IdAlimentacion = int.Parse(ddlAlimentacion2.SelectedValue.ToString());
            objPersona.PrimerNombre = txtPrimerNombre.Text;
            objPersona.SegundoNombre = txtSegundoNombre.Text;
            objPersona.PrimerApellido = txtPrimerApellido.Text;
            objPersona.SegundoApellido = txtSegundoApellido.Text;
            objPersona.Genero = bool.Parse(ddlGenero.SelectedValue.ToString());
            objPersona.Nacimiento = nacimiento;
            objPersona.Telefono = txtTelefono.Text;
            objPersona.Cedula = txtCedula.Text;
            objPersona.LugarNacimiento = txtLugarNacimiento.Text;
            objPersona.Observacion = txtObservacion.Text;
            objPersona.Ingreso = DateTime.Now;
            objPersona.Numeros = cargarNumeros();
        }
        
        private void cargarAdulto()
        {
            objAdulto.DondeEstudiaAdulto = txtDondeEstudia.Text;
            objAdulto.NivelEducacion = ddlNivel.SelectedItem.Text;
        }

        private void cargarDDLs()
        {
            ddlAlimentacion2.DataSource = objAlimentacion2.D_consultarOcupacion();
            ddlAlimentacion2.DataTextField = "NOMBRE";
            ddlAlimentacion2.DataValueField = "IDALIMENTACION2";
            ddlAlimentacion2.DataBind();

        }

        private bool validaciones(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (edad >= 18 && nacimiento < DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        protected List<string> cargarNumeros()
        {
            List<string> numeros = new List<string>();

            if (txtTelefono.Text.Trim() != "")
            {
                numeros.Add(txtTelefono.Text);
            }
            if (txtTelefono0.Text.Trim() != "")
            {
                numeros.Add(txtTelefono0.Text);
            }
            if (txtTelefono1.Text.Trim() != "")
            {
                numeros.Add(txtTelefono1.Text);
            }
            return numeros;

        }
    }
}