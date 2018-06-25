<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmIngresarNinio.aspx.cs" Inherits="Sembrar.Administrador.IngresarNiño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 22px;
        }
        .auto-style5 {
            height: 16px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td colspan="2"><h2>Agregar Niño</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>&nbsp;</p>
                <p>Código SAD: (*)</p></td>
            <td class="auto-style13" style="text-align: left">
                Prefijo PRO - QUI - OYE seguido de 4 numeros<br />
                <asp:TextBox ID="txtSAD" runat="server" Columns="50" MaxLength="7" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revSAD" runat="server" ControlToValidate="txtSAD" ErrorMessage="* Formato Incorrecto" ForeColor="#CC3300" ValidationExpression="(QUI|PRO|OYE)\d{4}" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Año Ingreso: (*)</p></td>
            <td class="auto-style13" style="text-align: left">
                <%--This works for 1900 to 2099--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="txtAnioIngreso" ErrorMessage="Revise que el dato sea un año válido" 
                    ValidationExpression="^(19|20)\d{2}$" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtAnioIngreso" runat="server" Columns="50" MaxLength="5" TextMode="Number" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RfAÑOIN" runat="server" ControlToValidate="txtAnioIngreso" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Ocupación:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:DropDownList ID="ddlAlimentacion2" runat="server" Width="290px" CssClass="MiCheck">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>        
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Nombre: (*)</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ControlToValidate="txtPrimerNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtPrimerNombre" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ControlToValidate="txtPrimerNombre" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Nombre:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                    ControlToValidate="txtSegundoNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoNombre" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Apellido: (*)</p></td>
            <td class="auto-style19" style="text-align: left">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                    ControlToValidate="txtPrimerApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtPrimerApellido" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Apellido:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                    ControlToValidate="txtSegundoApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoApellido" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Género:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:DropDownList ID="ddlGenero" runat="server" Height="16px" Width="300px" CssClass="MiCheck">
                    <asp:ListItem Value="TRUE">Masculino</asp:ListItem>
                    <asp:ListItem Value="FALSE">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Fecha Nacimiento: (*)</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" TextMode="Date" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="ctvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Fecha Nacimiento mayor que la actual o invalida" ForeColor="#CC3300" OnServerValidate="ctvFecha_ServerValidate" Display="Dynamic"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Cédula:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtCedula" runat="server" Columns="50" MaxLength="10" Width="154px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">
                <p>Teléfono:</p></td>
            <td class="auto-style19" style="text-align: left">
                Formato: 023350478 / 0968851369<br />
                <asp:TextBox ID="txtTelefono" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="MiCheck" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtTelefono0" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="numeros" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtTelefono1" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="numeros" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <br />
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*El teléfono es un campo númerico con formato de 9 a 10 dígitos" ForeColor="#CC3300" SetFocusOnError="True" ValidationExpression="\d{9,10}" ValidationGroup="Telefono"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Lugar de Nacimiento: (*)</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtLugarNacimiento" runat="server" Columns="50" Height="44px" MaxLength="50" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvLugarNacimiento" runat="server" ControlToValidate="txtLugarNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Discapacidades:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtDiscapacidad" runat="server" Columns="50" Height="75px" MaxLength="200" Rows="4" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style9" style="text-align: left"><p>Preguntas Generales</p></td>
            <td class="auto-style16" style="text-align: left">
                <asp:CheckBox ID="chbTrabaja" runat="server" OnCheckedChanged="chbTrabaja_CheckedChanged" Text="¿Trabaja el niño?" AutoPostBack="True" CssClass="MiCheck" />
            </td>
            <td class="auto-style9">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">
                <asp:Label ID="lblTrabaja" runat="server" Text="¿Cuánto tiempo trabaja a la semana?" CssClass="MiCheck"></asp:Label>
                </td>
            <td class="auto-style19" style="text-align: left">
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                         ControlToValidate="txtTiempoTrabajo" ErrorMessage="Este campo acepta números positivos" 
                     ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                  <br />
                <asp:TextBox ID="txtTiempoTrabajo" runat="server" TextMode="Number" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style9" style="text-align: left">&nbsp;</td>
            <td class="auto-style16" style="text-align: left">
                <asp:CheckBox ID="chbVacunas" runat="server" Text="¿Tiene todas sus vacunas?" CssClass="MiCheck" />
            </td>
            <td class="auto-style9">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>¿Cuántas veces a la semana come carne?:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                         ControlToValidate="txtAlimentacion" ErrorMessage="Este campo acepta números positivos" 
                     ValidationExpression="^[0-9]+$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtAlimentacion" runat="server" Columns="50" MaxLength="5" TextMode="Number" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style10" style="text-align: left"><p>Sacramento del niño:</p></td>
            <td class="auto-style17" style="text-align: left">
                <asp:TextBox ID="txtSacramento" runat="server" Columns="50" Height="75px" MaxLength="200" Rows="4" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Observaciones:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtObservacion" runat="server" Columns="50" Height="75px" MaxLength="1024" Rows="4" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="153px" CssClass="MiBrn" />
            </td>
        </tr>
    </table>
</asp:Content>
